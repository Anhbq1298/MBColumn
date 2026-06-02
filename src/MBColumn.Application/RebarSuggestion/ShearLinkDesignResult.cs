namespace MBColumn.Application.RebarSuggestion;

public sealed record ShearLinkDesignResult
{
    public string LinkBarName { get; init; } = "—";
    public string LinkBarLabel { get; init; } = "—";
    public double LinkDiameterMm { get; init; }
    public double LinkSpacingMm { get; init; }
    public bool InternalLinksRequired { get; init; }

    // Cross-ties for top/bottom face intermediate bars → maps to InnerLegsX in InputViewModel
    public int InternalLinksX { get; init; }

    // Cross-ties for left/right face intermediate bars → maps to InnerLegsY in InputViewModel
    public int InternalLinksY { get; init; }

    // Total cross-tie count per stirrup set
    public int InternalLinkCount => InternalLinksX + InternalLinksY;

    // EC2 computed limits (informational)
    public double MinRequiredDiameterMm { get; init; }
    public double MaxAllowedSpacingMm { get; init; }

    public bool NoSuitableLinkBarFound { get; init; }
}
