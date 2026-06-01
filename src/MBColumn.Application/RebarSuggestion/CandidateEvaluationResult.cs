namespace MBColumn.Application.RebarSuggestion;

public sealed record CandidateEvaluationResult(
    double MaxPmmUtilization,
    double? MaxShearUtilization,
    double? VxUtilization,
    double? VyUtilization,
    string GoverningLoadCaseName,
    bool EvaluationFailed,
    string? EvaluationError);
