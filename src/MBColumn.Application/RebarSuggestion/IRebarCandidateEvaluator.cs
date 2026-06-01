namespace MBColumn.Application.RebarSuggestion;

public interface IRebarCandidateEvaluator
{
    CandidateEvaluationResult Evaluate(RebarSuggestionCandidate candidate, RebarSuggestionInput input);
}
