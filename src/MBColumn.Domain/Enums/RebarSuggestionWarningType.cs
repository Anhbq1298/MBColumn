namespace MBColumn.Domain.Enums;

public enum RebarSuggestionWarningType
{
    PmmExceedsMaximum,
    PmmBelowMinimum,
    ClearSpacingTight,
    ClearSpacingFailed,
    ReinforcementRatioTooLow,
    ReinforcementRatioTooHigh,
    ReinforcementRatioOutsidePreferredRange,
    InternalLinksRequired,
    TieCompatibilityIssue,
    MissingCornerBar,
    BarOutsideLinkBoundary,
    CoordinateGenerationFailed,
    SolverError,
    ShearExceedsMaximum
}
