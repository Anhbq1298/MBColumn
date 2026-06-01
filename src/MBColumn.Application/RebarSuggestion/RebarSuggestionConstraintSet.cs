using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionConstraintSet
{
    public double TargetPmmUtilization { get; init; } = 0.90;
    public double MinimumAcceptablePmmUtilization { get; init; } = 0.80;
    public double MaximumAcceptablePmmUtilization { get; init; } = 1.00;

    public double? TargetReinforcementRatio { get; init; }
    public double? MinimumPreferredReinforcementRatio { get; init; }
    public double? MaximumPreferredReinforcementRatio { get; init; }

    public IReadOnlyList<string> AllowedBarSizeNames { get; init; } = Array.Empty<string>();
    public IReadOnlyList<int> AllowedBarCounts { get; init; } = Array.Empty<int>();

    public bool AllowChangeBarDiameter { get; init; } = true;
    public bool AllowChangeBarCount { get; init; } = true;
    public bool AllowChangeSideDistribution { get; init; } = true;
    public bool AllowChangeTieSpacing { get; init; } = true;

    // Layout type filters — at least one must be true
    public bool AllowAllSidesEqualLayout { get; init; } = true;
    public bool AllowSidesDifferentLayout { get; init; } = true;

    public bool RequireSymmetricLayout { get; init; } = true;
    public bool RequireCornerBars { get; init; } = true;

    public bool CheckClearSpacing { get; init; } = true;
    public bool CheckReinforcementRatio { get; init; } = true;
    public bool CheckTieCompatibility { get; init; } = true;
    public double AggregateSizeMm { get; init; } = 20.0;

    public RebarSuggestionPreset Preset { get; init; } = RebarSuggestionPreset.Balanced;

    public bool ShowFailedCandidates { get; init; } = true;
    public int MaximumSuggestionsToShow { get; init; } = 10;
}
