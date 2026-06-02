using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

/// <summary>
/// Automated Rebar Design engine.
///
/// Filter pipeline (applied in order):
///   1. Spacing and geometry validation (via IRebarCandidateValidator)
///   2. Min / max steel ratio validation (via IRebarCandidateValidator)
///   3. PMM solver — only for candidates that passed steps 1-2
///   4. PMM target filter — reject if PMM > UserTargetPmmRatio
///
/// No scoring system. Passing candidates are sorted deterministically and
/// tagged with "Best PMM Utilization" and "Lowest Rebar Ratio".
/// </summary>
public sealed class RebarSuggestionEngine(
    IRebarCandidateGenerator generator,
    IReadOnlyList<IRebarCandidateValidator> validators,
    IRebarCandidateEvaluator evaluator)
{
    public RebarSuggestionEngine(
        IRebarCandidateGenerator generator,
        IReadOnlyList<IRebarCandidateValidator> validators,
        IRebarCandidateEvaluator evaluator,
        IRebarSuggestionScorer _)
        : this(generator, validators, evaluator)
    {
    }

    public RebarSuggestionResult Suggest(
        RebarSuggestionInput input,
        IProgress<(int done, int total)>? progress = null,
        CancellationToken ct = default)
    {
        double pmmTarget = input.Constraints.UserTargetPmmRatio;
        double maxBarSpacing = input.Constraints.MaximumBarSpacingMm;

        var rawCandidates = generator.Generate(input);
        int total = rawCandidates.Count;
        int done = 0;

        int passedCount = 0;
        int failedCount = 0;

        var passingOptions = new List<RebarSuggestionOption>();

        foreach (var raw in rawCandidates)
        {
            ct.ThrowIfCancellationRequested();

            // ── Step 1 & 2: Geometry + spacing + steel ratio validation ──────
            var candidate = Validate(raw, input);

            if (candidate.Status == RebarSuggestionStatus.Failed)
            {
                failedCount++;
                done++;
                progress?.Report((done, total));
                continue;
            }

            // ── Additional max-bar-spacing check (center-to-center) ──────────
            if (maxBarSpacing > 0 && ExceedsMaxBarSpacing(candidate, input, maxBarSpacing))
            {
                failedCount++;
                done++;
                progress?.Report((done, total));
                continue;
            }

            // ── Step 3: PMM solver ───────────────────────────────────────────
            var eval = evaluator.Evaluate(candidate, input);

            if (eval.EvaluationFailed)
            {
                failedCount++;
                done++;
                progress?.Report((done, total));
                continue;
            }

            // ── Step 4: PMM target filter ────────────────────────────────────
            if (eval.MaxPmmUtilization > pmmTarget + 1e-9)
            {
                failedCount++;
                done++;
                progress?.Report((done, total));
                continue;
            }

            // ── Candidate passes all checks ──────────────────────────────────
            passedCount++;
            var finalStatus = candidate.Status; // Valid or Warning (from validator)

            // Shear warning (informational — does not fail the candidate)
            var warnings = new List<RebarSuggestionWarning>(candidate.Warnings);
            if (eval.MaxShearUtilization is { } shear && shear > 1.0)
            {
                finalStatus = RebarSuggestionStatus.Warning;
                warnings.Add(new RebarSuggestionWarning(
                    RebarSuggestionWarningType.ShearExceedsMaximum,
                    $"Shear utilization {shear:F2} exceeds 1.0."));
            }

            double minClearSpacing = ComputeMinClearSpacing(candidate, input);

            // ── Shear link auto-design ───────────────────────────────────────
            ShearLinkDesignResult? linkDesign = null;
            if (input.AllowedLinkBars.Count > 0)
            {
                linkDesign = ShearLinkDesigner.Design(candidate, input);

                // Reject candidate if the required inner legs exceed the
                // intermediate bar count — the ΔX/ΔY check cannot pass.
                if (!linkDesign.IsLinkCheckFeasible)
                {
                    failedCount++;
                    done++;
                    progress?.Report((done, total));
                    continue;
                }
            }

            passingOptions.Add(new RebarSuggestionOption
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
                LayoutType              = candidate.LayoutType,
                MaximumPmmUtilization   = eval.MaxPmmUtilization,
                MaximumShearUtilization = eval.MaxShearUtilization,
                VxUtilization           = eval.VxUtilization,
                VyUtilization           = eval.VyUtilization,
                GoverningLoadCaseName   = eval.GoverningLoadCaseName,
                MinimumClearSpacingMm   = minClearSpacing,
                ShearLinkDesign         = linkDesign,
                Status                  = finalStatus,
                Reason                  = BuildReason(candidate, eval, candidate.Warnings),
                Warnings                = warnings
            });

            done++;
            progress?.Report((done, total));
        }

        // ── Sort deterministically (no scoring) ──────────────────────────────
        // Priority: 1. Layout type (AllSidesEqual first)
        //           2. Bar diameter ascending
        //           3. rho ascending
        //           4. PMM utilization descending
        var sorted = passingOptions
            .OrderBy(o => LayoutPriority(o.LayoutType))
            .ThenBy(o => o.BarDiameterMm)
            .ThenBy(o => o.ReinforcementRatio)
            .ThenByDescending(o => o.MaximumPmmUtilization)
            .Select((o, i) => o with { Rank = i + 1 })
            .ToList();

        // ── Identify best-PMM and lowest-rho candidates ──────────────────────
        // Best PMM Utilization: highest PMM (most efficient use of section capacity)
        var bestPmmCandidateKey = sorted
            .OrderByDescending(o => o.MaximumPmmUtilization)
            .ThenBy(o => o.ReinforcementRatio)
            .ThenBy(o => LayoutPriority(o.LayoutType))
            .Select(o => MakeKey(o))
            .FirstOrDefault();

        // Lowest Rebar Ratio: least reinforcement
        var lowestRhoCandidateKey = sorted
            .OrderBy(o => o.ReinforcementRatio)
            .ThenByDescending(o => o.MaximumPmmUtilization)
            .ThenBy(o => LayoutPriority(o.LayoutType))
            .Select(o => MakeKey(o))
            .FirstOrDefault();

        bool sameCandidate = bestPmmCandidateKey != default
                             && bestPmmCandidateKey == lowestRhoCandidateKey;

        // ── Apply recommendation tags ────────────────────────────────────────
        var tagged = sorted.Select(o =>
        {
            var key = MakeKey(o);
            bool isBestPmm   = key == bestPmmCandidateKey;
            bool isLowestRho = key == lowestRhoCandidateKey;

            string tag = (isBestPmm, isLowestRho) switch
            {
                (true, true)  => sameCandidate
                    ? "Best PMM Utilization | Lowest Rebar Ratio"
                    : "Best PMM Utilization",   // safety fallback — same key → same candidate
                (true, false) => "Best PMM Utilization",
                (false, true) => "Lowest Rebar Ratio",
                _             => string.Empty
            };

            return o with { RecommendationTag = tag };
        }).ToList();

        // ── Limit display count ──────────────────────────────────────────────
        var maxShow   = input.Constraints.MaximumSuggestionsToShow;
        var displayed = tagged.Take(maxShow).ToList();

        // Extract the two recommendation options from the tagged list
        var bestPmm   = tagged.FirstOrDefault(o => o.RecommendationTag.Contains("Best PMM Utilization"));
        var lowestRho = tagged.FirstOrDefault(o => o.RecommendationTag.Contains("Lowest Rebar Ratio"));

        string summary = total > 0
            ? $"Generated {total} candidates. {passedCount} passed, {failedCount} filtered out." +
              (bestPmm is not null ? $" Best PMM: {bestPmm.ConfigurationName} ({bestPmm.MaximumPmmUtilization:F2})." : " No passing candidate.")
            : "No candidates generated. Check allowed bar sizes and section geometry.";

        int warningCount = tagged.Count(o => o.Status == RebarSuggestionStatus.Warning);

        return new RebarSuggestionResult
        {
            Options                  = displayed,
            BestPmmUtilizationOption = bestPmm,
            LowestRebarRatioOption   = lowestRho,
            RecommendedOption        = bestPmm,
            TotalCandidateCount      = total,
            PassedCandidateCount     = passedCount,
            WarningCandidateCount    = warningCount,
            FailedCandidateCount     = failedCount,
            SummaryMessage           = summary
        };
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static int LayoutPriority(RebarCandidateLayoutType t) => t switch
    {
        RebarCandidateLayoutType.AllSidesEqual         => 0,
        RebarCandidateLayoutType.SideDifferentSymmetric => 1,
        _                                               => 2
    };

    private static (string barName, int totalCount, int nTop, int nLeft) MakeKey(RebarSuggestionOption o)
        => (o.BarSizeName, o.TotalBarCount, o.BarsOnTopBottomFace, o.BarsOnLeftRightFace);

    private static string BuildConfigName(RebarSuggestionCandidate c)
        => $"{c.TotalBarCount}{c.Bar.DisplayLabel ?? c.Bar.Name}";

    private static string BuildReason(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult eval,
        IReadOnlyList<RebarSuggestionWarning> warnings)
    {
        string shearNote = eval.MaxShearUtilization is { } sh && sh > 1.0
            ? $"  ⚠ Shear = {sh:F2}"
            : string.Empty;

        if (warnings.Count > 0)
            return $"PMM = {eval.MaxPmmUtilization:F2}, ρ = {candidate.ReinforcementRatio * 100:F2}% — {warnings[0].Message}{shearNote}";

        return $"PMM = {eval.MaxPmmUtilization:F2}, ρ = {candidate.ReinforcementRatio * 100:F2}%{shearNote}";
    }

    private static bool ExceedsMaxBarSpacing(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input,
        double maxBarSpacingMm)
    {
        var dto    = input.BaseInput;
        double db  = candidate.Bar.DiameterMm;
        double link = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;

        double coverToBarCtr = dto.Cover + link + db / 2.0;
        double availableWidth  = dto.Width  - 2.0 * coverToBarCtr;
        double availableHeight = dto.Height - 2.0 * coverToBarCtr;

        int nx = candidate.BarsOnTopBottomFace;
        int ny = candidate.BarsOnLeftRightFace;

        double spacingX = nx > 1 ? availableWidth  / (nx - 1) : double.PositiveInfinity;
        double spacingY = ny > 1 ? availableHeight / (ny - 1) : double.PositiveInfinity;

        return spacingX > maxBarSpacingMm + 1e-3 || spacingY > maxBarSpacingMm + 1e-3;
    }

    private static double ComputeMinClearSpacing(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input)
    {
        var dto    = input.BaseInput;
        double db  = candidate.Bar.DiameterMm;
        double link = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;

        double coverToBarCtr = dto.Cover + link + db / 2.0;
        double availableWidth  = dto.Width  - 2.0 * coverToBarCtr;
        double availableHeight = dto.Height - 2.0 * coverToBarCtr;

        int nx = candidate.BarsOnTopBottomFace;
        int ny = candidate.BarsOnLeftRightFace;

        double clearX = nx > 1 ? availableWidth  / (nx - 1) - db : double.PositiveInfinity;
        double clearY = ny > 1 ? availableHeight / (ny - 1) - db : double.PositiveInfinity;

        return Math.Min(clearX, clearY);
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
            LayoutType          = candidate.LayoutType,
            Status              = ctx.Status,
            Warnings            = ctx.Warnings,
            FailureReason       = ctx.FailureReason
        };
    }
}
