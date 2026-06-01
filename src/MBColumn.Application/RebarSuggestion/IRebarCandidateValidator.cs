namespace MBColumn.Application.RebarSuggestion;

public interface IRebarCandidateValidator
{
    void Validate(RebarSuggestionCandidate candidate, RebarSuggestionInput input, CandidateValidationContext context);
}
