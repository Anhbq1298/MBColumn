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

        var    c   = input.Constraints;
        double pmm = evaluation.MaxPmmUtilization;
        double rho = candidate.ReinforcementRatio;

        // Candidates outside the UR band are already Failed — score is irrelevant.
        if (pmm < c.MinimumAcceptablePmmUtilization || pmm > c.MaximumAcceptablePmmUtilization)
            return 0;

        return c.Preset switch
        {
            // Rank by closeness to a target utilization ratio.
            RebarSuggestionPreset.ClosestToTargetPmm =>
                Max(0, 100.0 - Abs(pmm - c.TargetPmmUtilization) * 200.0),

            // Rank by closeness to a target reinforcement ratio.
            RebarSuggestionPreset.ClosestToTargetReinforcementRatio =>
                Max(0, 100.0 - Abs(rho - (c.TargetReinforcementRatio ?? 0.02)) * 2000.0),

            // Rank by PMM margin below the maximum — most conservative first.
            RebarSuggestionPreset.Conservative =>
                (c.MaximumAcceptablePmmUtilization - pmm) * 100.0,

            // Default / Balanced / MinimumSteel: minimize steel area.
            // Score decreases linearly from 100 (ρ→0) to 0 (ρ=4 %, EC2 limit).
            _ => 100.0 * (1.0 - rho / 0.04)
        };
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
            return $"Failed — solver error: {evaluation.EvaluationError}";

        double pmm = evaluation.MaxPmmUtilization;
        double rho = candidate.ReinforcementRatio;
        var    c   = input.Constraints;

        if (status == RebarSuggestionStatus.Failed)
        {
            if (warnings.Count > 0) return $"Failed — {warnings[0].Message}";
            return "Failed — does not meet requirements.";
        }

        string shearNote = evaluation.MaxShearUtilization is { } sh && sh > 1.0
            ? $"  ⚠ Shear = {sh:F2}"
            : string.Empty;

        if (isRecommended)
        {
            return c.Preset switch
            {
                RebarSuggestionPreset.ClosestToTargetPmm =>
                    $"Recommended — PMM = {pmm:F2} (target {c.TargetPmmUtilization:F2}), ρ = {rho * 100:F2}%.{shearNote}",
                RebarSuggestionPreset.ClosestToTargetReinforcementRatio =>
                    $"Recommended — ρ = {rho * 100:F2}% (target {(c.TargetReinforcementRatio ?? 0.02) * 100:F2}%), PMM = {pmm:F2}.{shearNote}",
                RebarSuggestionPreset.Conservative =>
                    $"Recommended — PMM = {pmm:F2}, margin = {c.MaximumAcceptablePmmUtilization - pmm:F2}.{shearNote}",
                _ =>
                    $"Recommended — minimum steel: ρ = {rho * 100:F2}%, PMM = {pmm:F2}.{shearNote}"
            };
        }

        return c.Preset switch
        {
            RebarSuggestionPreset.ClosestToTargetPmm =>
                $"PMM = {pmm:F2} (target {c.TargetPmmUtilization:F2}), ρ = {rho * 100:F2}%.{shearNote}",
            RebarSuggestionPreset.ClosestToTargetReinforcementRatio =>
                $"ρ = {rho * 100:F2}%, PMM = {pmm:F2}.{shearNote}",
            RebarSuggestionPreset.Conservative =>
                $"PMM = {pmm:F2}, margin = {c.MaximumAcceptablePmmUtilization - pmm:F2}.{shearNote}",
            _ =>
                $"ρ = {rho * 100:F2}%, PMM = {pmm:F2}.{shearNote}"
        };
    }
}
