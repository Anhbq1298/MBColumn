using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

/// <summary>
/// Collects validation errors during a validation pass.
/// Replaces the raw List&lt;string&gt; pattern so each error carries field and row context.
/// Only errors are collected — warnings are not surfaced by ValidationResultDto and
/// would be silently dropped, so Warning() is intentionally absent here.
/// </summary>
public sealed class ValidationContext
{
    private readonly List<ValidationIssue> _issues = [];

    public IReadOnlyList<ValidationIssue> Issues => _issues;
    public bool HasErrors => _issues.Any(i => i.Severity == ValidationSeverity.Error);

    public void Error(string message, string? field = null, int? rowIndex = null)
        => _issues.Add(new ValidationIssue(field ?? "", rowIndex, message, ValidationSeverity.Error));

    public ValidationResultDto ToResult()
    {
        if (!HasErrors) return ValidationResultDto.Valid;
        var errors = _issues.Select(i => i.Message).ToList();
        return new ValidationResultDto(false, errors);
    }
}
