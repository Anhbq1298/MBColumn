using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionEngine(
    IRebarCandidateGenerator generator,
    IReadOnlyList<IRebarCandidateValidator> validators,
    IRebarCandidateEvaluator evaluator,
    IRebarSuggestionScorer scorer)
{
    public RebarSuggestionResult Suggest(RebarSuggestionInput input)
    {
        var rawCandidates = generator.Generate(input);

        var validatedCandidates = rawCandidates
            .Select(c => Validate(c, input))
            .ToList();

        var options = new List<RebarSuggestionOption>(validatedCandidates.Count);
        int passed = 0, warned = 0, failed = 0;

        foreach (var candidate in validatedCandidates)
        {
            CandidateEvaluationResult eval;
            RebarSuggestionStatus finalStatus = candidate.Status;
            var allWarnings = new List<RebarSuggestionWarning>(candidate.Warnings);

            if (candidate.Status == RebarSuggestionStatus.Failed)
            {
                eval = new CandidateEvaluationResult(0, null, null, null, string.Empty, false, null);
                failed++;
            }
            else
            {
                eval = evaluator.Evaluate(candidate, input);

                if (eval.EvaluationFailed)
                {
                    finalStatus = RebarSuggestionStatus.Failed;
                    allWarnings.Add(new RebarSuggestionWarning(
                        RebarSuggestionWarningType.SolverError, eval.EvaluationError ?? "Solver error."));
                    failed++;
                }
                else
                {
                    var pmmStatus = ClassifyPmm(eval.MaxPmmUtilization, input.Constraints);
                    if (pmmStatus == RebarSuggestionStatus.Failed)
                    {
                        finalStatus = RebarSuggestionStatus.Failed;
                        allWarnings.Add(new RebarSuggestionWarning(
                            RebarSuggestionWarningType.PmmExceedsMaximum,
                            $"PMM utilization {eval.MaxPmmUtilization:F2} exceeds maximum {input.Constraints.MaximumAcceptablePmmUtilization:F2}."));
                        failed++;
                    }
                    else
                    {
                        if (finalStatus != RebarSuggestionStatus.Failed)
                            finalStatus = pmmStatus == RebarSuggestionStatus.Warning
                                ? RebarSuggestionStatus.Warning
                                : finalStatus;

                        if (pmmStatus == RebarSuggestionStatus.Warning)
                            allWarnings.Add(new RebarSuggestionWarning(
                                RebarSuggestionWarningType.PmmBelowMinimum,
                                $"PMM utilization {eval.MaxPmmUtilization:F2} is below preferred minimum {input.Constraints.MinimumAcceptablePmmUtilization:F2}."));

                        if (finalStatus == RebarSuggestionStatus.Warning) warned++;
                        else passed++;
                    }
                }
            }

            double score = finalStatus != RebarSuggestionStatus.Failed
                ? scorer.Score(candidate, eval, input)
                : 0;

            string config = BuildConfigName(candidate);
            string reason = scorer.GenerateReason(candidate, eval, finalStatus, allWarnings, input, isRecommended: false);

            options.Add(new RebarSuggestionOption
            {
                Rank                    = 0,
                ConfigurationName       = config,
                Coordinates             = candidate.Coordinates,
                TotalSteelAreaMm2       = candidate.TotalSteelAreaMm2,
                ReinforcementRatio      = candidate.ReinforcementRatio,
                TotalBarCount           = candidate.TotalBarCount,
                BarsOnTopBottomFace     = candidate.BarsOnTopBottomFace,
                BarsOnLeftRightFace     = candidate.BarsOnLeftRightFace,
                BarDiameterMm           = candidate.Bar.DiameterMm,
                BarSizeName             = candidate.Bar.Name,
                MaximumPmmUtilization   = eval.MaxPmmUtilization,
                MaximumShearUtilization = eval.MaxShearUtilization,
                VxUtilization           = eval.VxUtilization,
                VyUtilization           = eval.VyUtilization,
                GoverningLoadCaseName   = eval.GoverningLoadCaseName,
                Score                   = score,
                Status                  = finalStatus,
                Reason                  = reason,
                Warnings                = allWarnings
            });
        }

        // Rank: valid first, warning second, failed last; within each group sort by score desc
        var ranked = options
            .OrderBy(o => o.Status switch
            {
                RebarSuggestionStatus.Valid   => 0,
                RebarSuggestionStatus.Warning => 1,
                _                             => 2
            })
            .ThenByDescending(o => o.Score)
            .Select((o, i) => o with { Rank = i + 1 })
            .ToList();

        // Fix reasons for recommended
        if (ranked.Count > 0 && ranked[0].Status != RebarSuggestionStatus.Failed)
        {
            var best = ranked[0];
            var bestCandidate = validatedCandidates.FirstOrDefault(c =>
                c.Bar.Name == best.BarSizeName && c.TotalBarCount == best.TotalBarCount &&
                c.BarsOnTopBottomFace == best.BarsOnTopBottomFace);
            if (bestCandidate is not null)
            {
                var bestEval = new CandidateEvaluationResult(
                    best.MaximumPmmUtilization, best.MaximumShearUtilization,
                    best.VxUtilization, best.VyUtilization, best.GoverningLoadCaseName, false, null);
                ranked[0] = ranked[0] with
                {
                    Reason = scorer.GenerateReason(bestCandidate, bestEval, best.Status, best.Warnings, input, isRecommended: true)
                };
            }
        }

        var maxShow = input.Constraints.MaximumSuggestionsToShow;
        var displayed = input.Constraints.ShowFailedCandidates
            ? ranked.Take(maxShow).ToList()
            : ranked.Where(o => o.Status != RebarSuggestionStatus.Failed).Take(maxShow).ToList();

        var recommended = ranked.FirstOrDefault(o => o.Status != RebarSuggestionStatus.Failed);

        string summary = ranked.Count > 0
            ? $"Generated {ranked.Count} candidates. {passed} passed, {warned} warnings, {failed} failed." +
              (recommended is not null ? $" Recommended: {recommended.ConfigurationName}." : " No valid candidate found.")
            : "No candidates generated. Check allowed bar sizes and counts.";

        return new RebarSuggestionResult
        {
            Options              = displayed,
            RecommendedOption    = recommended,
            TotalCandidateCount  = ranked.Count,
            PassedCandidateCount = passed,
            WarningCandidateCount = warned,
            FailedCandidateCount  = failed,
            SummaryMessage        = summary
        };
    }

    private RebarSuggestionCandidate Validate(RebarSuggestionCandidate candidate, RebarSuggestionInput input)
    {
        var ctx = new CandidateValidationContext();
        foreach (var v in validators)
            v.Validate(candidate, input, ctx);

        if (ctx.Status == RebarSuggestionStatus.Valid && ctx.Warnings.Count == 0)
            return candidate;

        return new RebarSuggestionCandidate
        {
            Bar                 = candidate.Bar,
            TotalBarCount       = candidate.TotalBarCount,
            BarsOnTopBottomFace = candidate.BarsOnTopBottomFace,
            BarsOnLeftRightFace = candidate.BarsOnLeftRightFace,
            Coordinates         = candidate.Coordinates,
            TotalSteelAreaMm2   = candidate.TotalSteelAreaMm2,
            ReinforcementRatio  = candidate.ReinforcementRatio,
            Status              = ctx.Status,
            Warnings            = ctx.Warnings,
            FailureReason       = ctx.FailureReason
        };
    }

    private static RebarSuggestionStatus ClassifyPmm(double pmm, RebarSuggestionConstraintSet c)
    {
        if (pmm > c.MaximumAcceptablePmmUtilization) return RebarSuggestionStatus.Failed;
        if (pmm < c.MinimumAcceptablePmmUtilization) return RebarSuggestionStatus.Warning;
        return RebarSuggestionStatus.Valid;
    }

    private static string BuildConfigName(RebarSuggestionCandidate c)
        => $"{c.TotalBarCount}{c.Bar.DisplayLabel ?? c.Bar.Name}";
}
