using MBColumn.Domain.Enums;
using static System.Math;

namespace MBColumn.Application.RebarSuggestion;

public sealed class DefaultRebarSuggestionScorer : IRebarSuggestionScorer
{
    public double Score(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult evaluation,
        RebarSuggestionInput input)
    {
        if (evaluation.EvaluationFailed) return 0;

        var c = input.Constraints;
        double pmm  = evaluation.MaxPmmUtilization;
        double rho  = candidate.ReinforcementRatio;
        double as_  = candidate.TotalSteelAreaMm2;

        return c.Preset switch
        {
            RebarSuggestionPreset.MinimumSteel           => ScoreMinimumSteel(pmm, rho, as_, c),
            RebarSuggestionPreset.ClosestToTargetReinforcementRatio => ScoreClosestRho(pmm, rho, c),
            RebarSuggestionPreset.ClosestToTargetPmm     => ScoreClosestPmm(pmm, c),
            RebarSuggestionPreset.Conservative           => ScoreConservative(pmm, rho, c),
            _                                            => ScoreBalanced(pmm, rho, as_, c)
        };
    }

    private static double ScoreBalanced(double pmm, double rho, double as_, RebarSuggestionConstraintSet c)
    {
        double pmmScore  = 100.0 - Abs(pmm - c.TargetPmmUtilization) * 200.0;
        double rhoScore  = c.TargetReinforcementRatio.HasValue
            ? 20.0 - Abs(rho - c.TargetReinforcementRatio.Value) * 1000.0
            : 10.0;
        double economy   = 10.0 - as_ / 10000.0;  // favour lower As
        return Max(0, pmmScore + rhoScore + economy);
    }

    private static double ScoreMinimumSteel(double pmm, double rho, double as_, RebarSuggestionConstraintSet c)
    {
        if (pmm > c.MaximumAcceptablePmmUtilization) return 0;
        return 100.0 - as_ / 1000.0;
    }

    private static double ScoreClosestRho(double pmm, double rho, RebarSuggestionConstraintSet c)
    {
        if (pmm > c.MaximumAcceptablePmmUtilization) return 0;
        double target = c.TargetReinforcementRatio ?? 0.02;
        return 100.0 - Abs(rho - target) * 2000.0;
    }

    private static double ScoreClosestPmm(double pmm, RebarSuggestionConstraintSet c)
    {
        if (pmm > c.MaximumAcceptablePmmUtilization) return 0;
        return 100.0 - Abs(pmm - c.TargetPmmUtilization) * 200.0;
    }

    private static double ScoreConservative(double pmm, double rho, RebarSuggestionConstraintSet c)
    {
        if (pmm > c.MaximumAcceptablePmmUtilization) return 0;
        // Reward PMM well below the limit, but penalise excessive steel
        double margin  = c.MaximumAcceptablePmmUtilization - pmm;
        double economy = Max(0, 0.04 - rho) * 500.0;
        return Max(0, margin * 100.0 + economy);
    }

    public string GenerateReason(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult evaluation,
        RebarSuggestionStatus status,
        IReadOnlyList<RebarSuggestionWarning> warnings,
        RebarSuggestionInput input,
        bool isRecommended)
    {
        if (evaluation.EvaluationFailed)
            return $"PMM solver failed: {evaluation.EvaluationError}";

        double pmm = evaluation.MaxPmmUtilization;
        var c      = input.Constraints;

        if (status == RebarSuggestionStatus.Failed)
        {
            if (pmm > c.MaximumAcceptablePmmUtilization)
                return $"Failed — PMM utilization {pmm:F2} exceeds maximum {c.MaximumAcceptablePmmUtilization:F2}.";
            if (warnings.Count > 0)
                return $"Failed — {warnings[0].Message}";
            return "Failed — does not meet all requirements.";
        }

        if (isRecommended)
            return $"Recommended — PMM = {pmm:F2}, closest to target {c.TargetPmmUtilization:F2}.";

        if (status == RebarSuggestionStatus.Warning)
        {
            var w = warnings.FirstOrDefault();
            return w is not null
                ? $"Warning — {w.Message}"
                : $"Passes PMM ({pmm:F2}) with warnings.";
        }

        // Valid
        if (pmm < c.MinimumAcceptablePmmUtilization)
            return $"Conservative — PMM = {pmm:F2}, well below limit.";

        return c.Preset switch
        {
            RebarSuggestionPreset.MinimumSteel =>
                $"Good economy — lowest steel area that passes PMM = {pmm:F2}.",
            RebarSuggestionPreset.ClosestToTargetReinforcementRatio =>
                $"ρ = {candidate.ReinforcementRatio * 100:F2}% close to target. PMM = {pmm:F2}.",
            RebarSuggestionPreset.ClosestToTargetPmm =>
                $"PMM = {pmm:F2} is close to target {c.TargetPmmUtilization:F2}.",
            RebarSuggestionPreset.Conservative =>
                $"Conservative — PMM = {pmm:F2} with comfortable margin.",
            _ =>
                $"Good balance — PMM = {pmm:F2}, ρ = {candidate.ReinforcementRatio * 100:F2}%."
        };
    }
}
