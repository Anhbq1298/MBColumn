namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionResult
{
    public IReadOnlyList<RebarSuggestionOption> Options { get; init; } = Array.Empty<RebarSuggestionOption>();

    // Best PMM Utilization: highest PMM ratio while still <= UserTargetPmmRatio
    public RebarSuggestionOption? BestPmmUtilizationOption { get; init; }

    // Lowest Rebar Ratio: least reinforcement while passing all constraints
    public RebarSuggestionOption? LowestRebarRatioOption { get; init; }

    // RecommendedOption kept for existing UI code.
    public RebarSuggestionOption? RecommendedOption { get; init; }

    public int TotalCandidateCount { get; init; }
    public int PassedCandidateCount { get; init; }
    public int WarningCandidateCount { get; init; }
    public int FailedCandidateCount { get; init; }
    public string SummaryMessage { get; init; } = string.Empty;
}
