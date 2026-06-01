using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionEngine(
    IRebarCandidateGenerator generator,
    IReadOnlyList<IRebarCandidateValidator> validators,
    IRebarCandidateEvaluator evaluator,
    IRebarSuggestionScorer scorer)
{
    public RebarSuggestionResult Suggest(
        RebarSuggestionInput input,
        IProgress<(int done, int total)>? progress = null,
        CancellationToken ct = default)
    {
        var rawCandidates       = generator.Generate(input);
        var validatedCandidates = rawCandidates.Select(c => Validate(c, input)).ToList();

        var failedByValidation = validatedCandidates.Where(c => c.Status == RebarSuggestionStatus.Failed).ToList();
        var activeCandidates   = validatedCandidates.Where(c => c.Status != RebarSuggestionStatus.Failed).ToList();

        // Group active candidates: barName → count-groups sorted ascending count.
        // This structure supports the per-bar binary search.
        var perBarGroups = activeCandidates
            .GroupBy(c => c.Bar.Name)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(c => c.TotalBarCount)
                       .OrderBy(cg => cg.Key)
                       .Select(cg => (Count: cg.Key, Candidates: cg.ToList()))
                       .ToList());

        int totalToEvaluate = activeCandidates.Count;
        int evaluatedSoFar  = 0;
        int solverCallCount = 0;

        var options   = new List<RebarSuggestionOption>(validatedCandidates.Count);
        // O(1) lookup: (barName, totalCount, barsOnTopBottomFace) → (candidate, eval)
        var evalCache = new Dictionary<(string, int, int), (RebarSuggestionCandidate candidate, CandidateEvaluationResult eval)>();

        int passed = 0, warned = 0, failed = 0, pruned = 0;

        // ── Evaluate each bar's candidate groups with binary-search pruning ────
        foreach (var (_, countGroups) in perBarGroups)
        {
            ct.ThrowIfCancellationRequested();

            int nGroups = countGroups.Count;
            if (nGroups == 0) continue;

            // Binary search: find the index of the minimum count where the probe
            // candidate yields PMM ≤ MaxAcceptablePmmUtilization.
            // Monotonicity: more bars → lower PMM, so once a count is "viable",
            // all larger counts are at-most-as-stressed (may still be Warning if PMM < Min).
            // If no count is viable (all over-stressed), threshIdx = null.
            int? threshIdx = BinarySearchThreshold(
                countGroups, input, evalCache, ct, ref solverCallCount);

            // Evaluation window: [threshIdx-1, threshIdx, threshIdx+1] catches both the
            // just-viable count and its neighbours (transition zone where Valid ↔ Warning).
            // When nothing is viable, still evaluate the largest count (most information).
            int winLo = threshIdx.HasValue ? Math.Max(0, threshIdx.Value - 1) : nGroups - 1;
            int winHi = threshIdx.HasValue ? Math.Min(nGroups - 1, threshIdx.Value + 1) : nGroups - 1;

            for (int gi = 0; gi < nGroups; gi++)
            {
                ct.ThrowIfCancellationRequested();
                var (_, candidates) = countGroups[gi];

                if (gi < winLo || gi > winHi)
                {
                    // Outside window: no solver call — mark as pruned Failed.
                    bool overStressed = gi < winLo;
                    foreach (var c in candidates)
                    {
                        pruned++;
                        failed++;
                        options.Add(BuildPrunedOption(c, overStressed, scorer, input));
                        evaluatedSoFar++;
                        progress?.Report((evaluatedSoFar, totalToEvaluate));
                    }
                    continue;
                }

                // ── Full evaluation for window group ──────────────────────────
                foreach (var candidate in candidates)
                {
                    ct.ThrowIfCancellationRequested();

                    var cacheKey = (candidate.Bar.Name, candidate.TotalBarCount, candidate.BarsOnTopBottomFace);

                    // Probe during binary search may have already evaluated this candidate.
                    CandidateEvaluationResult eval;
                    if (evalCache.TryGetValue(cacheKey, out var cached))
                    {
                        eval = cached.eval;
                    }
                    else
                    {
                        eval = evaluator.Evaluate(candidate, input);
                        evalCache[cacheKey] = (candidate, eval);
                        solverCallCount++;
                    }

                    var (finalStatus, allWarnings) = ClassifyCandidate(candidate, eval, input.Constraints);

                    if (finalStatus == RebarSuggestionStatus.Valid)        passed++;
                    else if (finalStatus == RebarSuggestionStatus.Warning) warned++;
                    else                                                   failed++;

                    double score = finalStatus != RebarSuggestionStatus.Failed
                        ? scorer.Score(candidate, eval, input) : 0;

                    string reason = scorer.GenerateReason(candidate, eval, finalStatus, allWarnings, input, isRecommended: false);

                    options.Add(BuildOption(candidate, eval, finalStatus, allWarnings, score, reason));

                    evaluatedSoFar++;
                    progress?.Report((evaluatedSoFar, totalToEvaluate));
                }
            }
        }

        // ── Pre-validation-failed candidates (no solver call needed) ──────────
        foreach (var candidate in failedByValidation)
        {
            failed++;
            string reason = candidate.Warnings.Count > 0
                ? $"Failed — {candidate.Warnings[0].Message}"
                : "Failed — does not meet geometric or code requirements.";
            var dummyEval = new CandidateEvaluationResult(0, null, null, null, string.Empty, false, null);
            options.Add(BuildOption(candidate, dummyEval, RebarSuggestionStatus.Failed, candidate.Warnings, 0, reason));
        }

        // ── Rank: valid first, warning second, failed last; score desc within tier ──
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

        // Fix reason for the recommended candidate using O(1) eval cache.
        if (ranked.Count > 0 && ranked[0].Status != RebarSuggestionStatus.Failed)
        {
            var best     = ranked[0];
            var cacheKey = (best.BarSizeName, best.TotalBarCount, best.BarsOnTopBottomFace);
            if (evalCache.TryGetValue(cacheKey, out var cached))
            {
                ranked[0] = ranked[0] with
                {
                    Reason = scorer.GenerateReason(
                        cached.candidate, cached.eval,
                        best.Status, best.Warnings,
                        input, isRecommended: true)
                };
            }
        }

        var maxShow   = input.Constraints.MaximumSuggestionsToShow;
        var displayed = input.Constraints.ShowFailedCandidates
            ? ranked.Take(maxShow).ToList()
            : ranked.Where(o => o.Status != RebarSuggestionStatus.Failed).Take(maxShow).ToList();

        var recommended = ranked.FirstOrDefault(o => o.Status != RebarSuggestionStatus.Failed);

        int totalEvaluated = options.Count;
        string pruneNote   = pruned > 0
            ? $" {pruned} pruned by binary search ({solverCallCount} solver calls)."
            : string.Empty;
        string summary = totalEvaluated > 0
            ? $"Generated {totalEvaluated} candidates. {passed} passed, {warned} warnings, {failed} failed.{pruneNote}" +
              (recommended is not null ? $" Recommended: {recommended.ConfigurationName}." : " No valid candidate found.")
            : "No candidates generated. Check allowed bar sizes and counts.";

        return new RebarSuggestionResult
        {
            Options               = displayed,
            RecommendedOption     = recommended,
            TotalCandidateCount   = totalEvaluated,
            PassedCandidateCount  = passed,
            WarningCandidateCount = warned,
            FailedCandidateCount  = failed,
            SummaryMessage        = summary
        };
    }

    // ── Binary search ─────────────────────────────────────────────────────────

    private int? BinarySearchThreshold(
        IList<(int Count, List<RebarSuggestionCandidate> Candidates)> countGroups,
        RebarSuggestionInput input,
        Dictionary<(string, int, int), (RebarSuggestionCandidate candidate, CandidateEvaluationResult eval)> evalCache,
        CancellationToken ct,
        ref int solverCallCount)
    {
        int lo = 0, hi = countGroups.Count - 1;
        int? threshIdx = null;

        while (lo <= hi)
        {
            ct.ThrowIfCancellationRequested();
            int mid = (lo + hi) / 2;

            var (_, midCandidates) = countGroups[mid];
            if (midCandidates.Count == 0) { lo = mid + 1; continue; }

            var probe    = midCandidates.First();
            var probeKey = (probe.Bar.Name, probe.TotalBarCount, probe.BarsOnTopBottomFace);

            if (!evalCache.TryGetValue(probeKey, out var cachedProbe))
            {
                var probeEval = evaluator.Evaluate(probe, input);
                evalCache[probeKey] = (probe, probeEval);
                cachedProbe = (probe, probeEval);
                solverCallCount++;
            }

            // Viable: probe passed (PMM ≤ MaxAcceptable) → try fewer bars.
            // Not viable (over-stressed or solver error) → need more bars.
            bool viable = !cachedProbe.eval.EvaluationFailed
                          && cachedProbe.eval.MaxPmmUtilization <= input.Constraints.MaximumAcceptablePmmUtilization;

            if (viable) { threshIdx = mid; hi = mid - 1; }
            else          lo = mid + 1;
        }

        return threshIdx;
    }

    // ── Classification ────────────────────────────────────────────────────────

    private static (RebarSuggestionStatus status, List<RebarSuggestionWarning> warnings)
        ClassifyCandidate(
            RebarSuggestionCandidate candidate,
            CandidateEvaluationResult eval,
            RebarSuggestionConstraintSet c)
    {
        var warnings = new List<RebarSuggestionWarning>(candidate.Warnings);

        if (eval.EvaluationFailed)
        {
            warnings.Add(new RebarSuggestionWarning(
                RebarSuggestionWarningType.SolverError,
                eval.EvaluationError ?? "Solver error."));
            return (RebarSuggestionStatus.Failed, warnings);
        }

        double pmm = eval.MaxPmmUtilization;

        // Both bounds are hard failures — candidates outside [Min, Max] are excluded.
        if (pmm > c.MaximumAcceptablePmmUtilization)
        {
            warnings.Add(new RebarSuggestionWarning(
                RebarSuggestionWarningType.PmmExceedsMaximum,
                $"PMM {pmm:F2} exceeds maximum {c.MaximumAcceptablePmmUtilization:F2}."));
            return (RebarSuggestionStatus.Failed, warnings);
        }

        if (pmm < c.MinimumAcceptablePmmUtilization)
        {
            warnings.Add(new RebarSuggestionWarning(
                RebarSuggestionWarningType.PmmBelowMinimum,
                $"PMM {pmm:F2} below minimum {c.MinimumAcceptablePmmUtilization:F2} — over-reinforced for demand."));
            return (RebarSuggestionStatus.Failed, warnings);
        }

        // PMM is within [Min, Max]. Inherit validation status (may be Warning from
        // tight spacing, tie diameter, etc.) and add shear as informational warning.
        var status = candidate.Status;

        if (eval.MaxShearUtilization is { } shear && shear > 1.0)
        {
            status = RebarSuggestionStatus.Warning;
            warnings.Add(new RebarSuggestionWarning(
                RebarSuggestionWarningType.ShearExceedsMaximum,
                $"Shear utilization {shear:F2} exceeds 1.0."));
        }

        return (status, warnings);
    }

    // ── Option builders ───────────────────────────────────────────────────────

    private static RebarSuggestionOption BuildOption(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult eval,
        RebarSuggestionStatus status,
        IReadOnlyList<RebarSuggestionWarning> warnings,
        double score,
        string reason)
        => new()
        {
            Rank                    = 0,
            ConfigurationName       = BuildConfigName(candidate),
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
            Status                  = status,
            Reason                  = reason,
            Warnings                = warnings
        };

    private static RebarSuggestionOption BuildPrunedOption(
        RebarSuggestionCandidate candidate,
        bool overStressed,
        IRebarSuggestionScorer scorer,
        RebarSuggestionInput input)
    {
        string reason = overStressed
            ? $"Pruned — {candidate.TotalBarCount}{candidate.Bar.DisplayLabel ?? candidate.Bar.Name}: likely over-stressed (binary search skipped)."
            : $"Pruned — {candidate.TotalBarCount}{candidate.Bar.DisplayLabel ?? candidate.Bar.Name}: likely under-reinforced (binary search skipped).";

        var dummyEval = new CandidateEvaluationResult(0, null, null, null, string.Empty, false, null);
        return BuildOption(candidate, dummyEval, RebarSuggestionStatus.Failed, candidate.Warnings, 0, reason);
    }

    // ── Validation ────────────────────────────────────────────────────────────

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

    private static string BuildConfigName(RebarSuggestionCandidate c)
        => $"{c.TotalBarCount}{c.Bar.DisplayLabel ?? c.Bar.Name}";
}
