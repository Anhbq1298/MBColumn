namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionResult
{
    public IReadOnlyList<RebarSuggestionOption> Options { get; init; } = Array.Empty<RebarSuggestionOption>();
    public RebarSuggestionOption? RecommendedOption { get; init; }
    public int TotalCandidateCount { get; init; }
    public int PassedCandidateCount { get; init; }
    public int WarningCandidateCount { get; init; }
    public int FailedCandidateCount { get; init; }
    public string SummaryMessage { get; init; } = string.Empty;
}
