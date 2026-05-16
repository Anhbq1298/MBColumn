namespace MBColumn.Application.DTOs;

public enum ValidationSeverity
{
    Info,
    Warning,
    Error
}

public sealed record ValidationIssue(
    string Field,
    int? RowIndex,
    string Message,
    ValidationSeverity Severity);
