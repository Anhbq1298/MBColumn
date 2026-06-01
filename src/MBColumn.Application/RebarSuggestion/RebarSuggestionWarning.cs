using MBColumn.Domain.Enums;

namespace MBColumn.Application.RebarSuggestion;

public sealed record RebarSuggestionWarning(
    RebarSuggestionWarningType Type,
    string Message);
