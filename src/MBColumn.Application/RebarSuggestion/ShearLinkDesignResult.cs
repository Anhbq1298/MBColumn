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

    // Actual gap between restrained positions (same quantities checked by UpdateEc2LinkChecks)
    public double ActualGapX { get; init; }
    public double ActualGapY { get; init; }
    public double ThresholdMm { get; init; }
    public bool GapCheckPass { get; init; }

    // True if the required inner legs can be physically placed at intermediate bar positions
    public bool IsLinkCheckFeasible { get; init; }

    // EC2 computed limits (informational)
    public double MinRequiredDiameterMm { get; init; }
    public double MaxAllowedSpacingMm { get; init; }

    public bool NoSuitableLinkBarFound { get; init; }
}
