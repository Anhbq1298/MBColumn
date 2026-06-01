namespace MBColumn.Application.RebarSuggestion;

public interface IRebarCandidateGenerator
{
    IReadOnlyList<RebarSuggestionCandidate> Generate(RebarSuggestionInput input);
}
