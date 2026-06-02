namespace MBColumn.Application.RebarSuggestion;

public sealed record ShearLinkDesignResult
{
    public string LinkBarName { get; init; } = "—";
    public string LinkBarLabel { get; init; } = "—";
    public double LinkDiameterMm { get; init; }
    public double LinkSpacingMm { get; init; }

    // Cross-ties for top/bottom face → InnerLegsX in InputViewModel
    public int InternalLinksX { get; init; }

    // Cross-ties for left/right face → InnerLegsY in InputViewModel
    public int InternalLinksY { get; init; }

    public bool InternalLinksRequired { get; init; }
    public int InternalLinkCount => InternalLinksX + InternalLinksY;

    // Gap check (EC2 §9.5.3(6) geometric condition)
    public double ActualGapX { get; init; }
    public double ActualGapY { get; init; }
    public double ThresholdMm { get; init; }
    public bool GapCheckPass { get; init; }
    public bool IsLinkCheckFeasible { get; init; }

    // Shear demand (Asw/s in mm²/mm for each principal direction)
    public double RequiredAswsX { get; init; }
    public double RequiredAswsY { get; init; }
    public double ProvidedAswsX { get; init; }
    public double ProvidedAswsY { get; init; }
    public bool ShearDemandSatisfied { get; init; }
    public bool HasShearDemand { get; init; }

    // EC2 detailing limits (informational)
    public double MinRequiredDiameterMm { get; init; }
    public double MaxAllowedSpacingMm { get; init; }

    public bool NoSuitableLinkBarFound { get; init; }
}
