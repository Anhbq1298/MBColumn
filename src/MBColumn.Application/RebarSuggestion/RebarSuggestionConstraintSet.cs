using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionConstraintSet
{
    // ── Spacing-first generation parameters ───────────────────────────────────
    public double MinimumBarDiameterMm { get; init; } = 20.0;
    public double InitialTargetSpacingMm { get; init; } = 150.0;
    public double SpacingReductionStepMm { get; init; } = 10.0;
    public double MinimumSpacingSearchLimitMm { get; init; } = 50.0;
    public double MaximumBarSpacingMm { get; init; } = 300.0;

    // ── PMM target ────────────────────────────────────────────────────────────
    // Candidates with PMM > UserTargetPmmRatio are rejected.
    // Must satisfy 0 < UserTargetPmmRatio <= 1.00.
    public double UserTargetPmmRatio { get; init; } = 1.00;

    // Legacy scoring inputs kept while the UI/scorer still use target bands.
    public double TargetPmmUtilization { get; init; } = 0.90;
    public double MinimumAcceptablePmmUtilization { get; init; } = 0.80;
    public double MaximumAcceptablePmmUtilization { get; init; } = 1.00;
    public double? TargetReinforcementRatio { get; init; }

    // ── Steel ratio limits (used by RebarCodeValidator) ───────────────────────
    // These are kept for backward compat with the validator; new engine uses
    // the validator's failure status to filter candidates.
    public double? MinimumPreferredReinforcementRatio { get; init; }
    public double? MaximumPreferredReinforcementRatio { get; init; }

    // ── Allowed bars ──────────────────────────────────────────────────────────
    public IReadOnlyList<string> AllowedBarSizeNames { get; init; } = Array.Empty<string>();

    // AllowedBarCounts is kept for any existing code paths; the automated
    // spacing-first generator does not use it.
    public IReadOnlyList<int> AllowedBarCounts { get; init; } = Array.Empty<int>();

    // Legacy UI switches kept for compatibility with the existing dialog.
    public bool AllowChangeBarDiameter { get; init; } = true;
    public bool AllowChangeBarCount { get; init; } = true;
    public bool AllowChangeSideDistribution { get; init; } = true;
    public bool AllowChangeTieSpacing { get; init; } = true;

    // ── Layout type filters ───────────────────────────────────────────────────
    public bool AllowAllSidesEqualLayout { get; init; } = true;
    public bool AllowSidesDifferentLayout { get; init; } = true;

    public bool RequireSymmetricLayout { get; init; } = true;
    public bool RequireCornerBars { get; init; } = true;

    // ── Code / detailing checks ───────────────────────────────────────────────
    public bool CheckClearSpacing { get; init; } = true;
    public bool CheckReinforcementRatio { get; init; } = true;
    public bool CheckTieCompatibility { get; init; } = true;
    public double AggregateSizeMm { get; init; } = 20.0;
    public RebarSuggestionPreset Preset { get; init; } = RebarSuggestionPreset.Balanced;

    // ── PMM target ────────────────────────────────────────────────────────────
    // Shear utilization ceiling: design loop iterates until Vu ≤ this value.
    // 0 = use 1.00 (full utilization).
    public double TargetShearUtilization { get; init; } = 1.00;

    // ── Shear link auto-design ────────────────────────────────────────────────
    // 0 = use EC2 formula automatically; positive value = user override (must still
    // satisfy EC2 minimum / maximum).
    public IReadOnlyList<string> AllowedLinkBarSizeNames { get; init; } = Array.Empty<string>();
    public double MinLinkDiameterMm { get; init; } = 0;    // 0 = EC2 auto
    public double MaxLinkSpacingMm { get; init; } = 0;     // 0 = EC2 auto
    public double CrossTieThresholdMm { get; init; } = 150.0;  // EC2 §9.5.3(6)

    // ── Display options ───────────────────────────────────────────────────────
    public bool ShowFailedCandidates { get; init; } = false;
    public int MaximumSuggestionsToShow { get; init; } = 20;
}
