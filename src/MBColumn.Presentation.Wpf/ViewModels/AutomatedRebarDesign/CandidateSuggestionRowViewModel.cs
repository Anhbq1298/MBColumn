using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;

public sealed class CandidateSuggestionRowViewModel : ViewModelBase
{
    public int Rank { get; init; }
    public string Config { get; init; } = string.Empty;
    public double TotalSteelAreaMm2 { get; init; }
    public double ReinforcementRatioPercent { get; init; }
    public double MaxPmmUtilization { get; init; }
    public string MaxShearDisplay { get; init; } = "—";
    public string SpacingStatus { get; init; } = "OK";
    public double Score { get; init; }
    public RebarSuggestionStatus Status { get; init; }
    public string StatusLabel => Status switch
    {
        RebarSuggestionStatus.Valid   => "OK",
        RebarSuggestionStatus.Warning => "Warning",
        _                             => "Failed"
    };
    public string Reason { get; init; } = string.Empty;

    public string AsMm2Display  => $"{TotalSteelAreaMm2:F0}";
    public string RhoDisplay     => $"{ReinforcementRatioPercent:F2}%";
    public string PmmDisplay     => $"{MaxPmmUtilization:F2}";
    public string ScoreDisplay   => Status == RebarSuggestionStatus.Failed ? "—" : $"{Score:F0}";

    // Reference back to the full option for preview/apply
    public MBColumn.Application.RebarSuggestion.RebarSuggestionOption? Option { get; init; }
}
