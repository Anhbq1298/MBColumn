using MBColumn.Application.RebarSuggestion;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;

public sealed class CandidateSuggestionRowViewModel : ViewModelBase
{
    public int Rank { get; init; }
    public string Config { get; init; } = string.Empty;
    public string LayoutTypeLabel { get; init; } = string.Empty;
    public double TotalSteelAreaMm2 { get; init; }
    public double ReinforcementRatioPercent { get; init; }
    public double MaxPmmUtilization { get; init; }
    public string MaxShearDisplay { get; init; } = "—";
    public string SpacingStatus { get; init; } = "OK";
    public string MinClearSpacingDisplay { get; init; } = "—";

    // Shear link auto-design
    public string LinkLabel { get; init; } = "—";
    public string LinkSpacingDisplay { get; init; } = "—";
    public string InternalLinksDisplay { get; init; } = "—";

    public string RecommendationTag { get; init; } = string.Empty;
    public RebarSuggestionStatus Status { get; init; }

    public string StatusLabel => Status switch
    {
        RebarSuggestionStatus.Valid   => "OK",
        RebarSuggestionStatus.Warning => "Warn",
        _                             => "Failed"
    };

    public string Reason { get; init; } = string.Empty;

    public string AsMm2Display  => $"{TotalSteelAreaMm2:F0}";
    public string RhoDisplay     => $"{ReinforcementRatioPercent:F2}%";
    public string PmmDisplay     => $"{MaxPmmUtilization:F2}";

    public RebarSuggestionOption? Option { get; init; }
}
