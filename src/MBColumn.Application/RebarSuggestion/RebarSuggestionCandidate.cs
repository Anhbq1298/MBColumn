using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionCandidate
{
    public required RebarDefinition Bar { get; init; }
    public int TotalBarCount { get; init; }
    public int BarsOnTopBottomFace { get; init; }
    public int BarsOnLeftRightFace { get; init; }
    public required IReadOnlyList<RebarCoordinateDto> Coordinates { get; init; }
    public double TotalSteelAreaMm2 { get; init; }
    public double ReinforcementRatio { get; init; }
    public RebarCandidateLayoutType LayoutType { get; init; } = RebarCandidateLayoutType.AllSidesEqual;
    public RebarSuggestionStatus Status { get; init; } = RebarSuggestionStatus.Valid;
    public IReadOnlyList<RebarSuggestionWarning> Warnings { get; init; } = Array.Empty<RebarSuggestionWarning>();
    public string? FailureReason { get; init; }
}
