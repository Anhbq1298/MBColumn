using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public interface IRebarSuggestionScorer
{
    double Score(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult evaluation,
        RebarSuggestionInput input);

    string GenerateReason(
        RebarSuggestionCandidate candidate,
        CandidateEvaluationResult evaluation,
        RebarSuggestionStatus status,
        IReadOnlyList<RebarSuggestionWarning> warnings,
        RebarSuggestionInput input,
        bool isRecommended);
}
