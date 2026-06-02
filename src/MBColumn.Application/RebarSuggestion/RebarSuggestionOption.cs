using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed record RebarSuggestionOption
{
    public int Rank { get; init; }
    public required string ConfigurationName { get; init; }
    public required IReadOnlyList<RebarCoordinateDto> Coordinates { get; init; }
    public double TotalSteelAreaMm2 { get; init; }
    public double ReinforcementRatio { get; init; }
    public int TotalBarCount { get; init; }
    public int BarsOnTopBottomFace { get; init; }
    public int BarsOnLeftRightFace { get; init; }
    public double BarDiameterMm { get; init; }
    public string BarSizeName { get; init; } = string.Empty;
    public RebarCandidateLayoutType LayoutType { get; init; } = RebarCandidateLayoutType.AllSidesEqual;
    public double MaximumPmmUtilization { get; init; }
    public double? MaximumShearUtilization { get; init; }
    public double? VxUtilization { get; init; }
    public double? VyUtilization { get; init; }
    public string GoverningLoadCaseName { get; init; } = string.Empty;
    public double Score { get; init; }
    public double MinimumClearSpacingMm { get; init; }
    public RebarSuggestionStatus Status { get; init; }
    public required string Reason { get; init; }
    public string RecommendationTag { get; init; } = string.Empty;
    public IReadOnlyList<RebarSuggestionWarning> Warnings { get; init; } = Array.Empty<RebarSuggestionWarning>();
}
