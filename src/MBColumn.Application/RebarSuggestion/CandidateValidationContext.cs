using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed class CandidateValidationContext
{
    public RebarSuggestionStatus Status { get; private set; } = RebarSuggestionStatus.Valid;
    public List<RebarSuggestionWarning> Warnings { get; } = new();
    public string? FailureReason { get; private set; }

    public void Fail(RebarSuggestionWarningType warningType, string reason)
    {
        Status = RebarSuggestionStatus.Failed;
        FailureReason ??= reason;
        Warnings.Add(new RebarSuggestionWarning(warningType, reason));
    }

    public void Warn(RebarSuggestionWarningType warningType, string message)
    {
        if (Status == RebarSuggestionStatus.Valid)
            Status = RebarSuggestionStatus.Warning;
        Warnings.Add(new RebarSuggestionWarning(warningType, message));
    }
}
