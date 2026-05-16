namespace MBColumn.Application.DTOs;

public sealed record IrregularSectionValidationResult(
    bool IsValid,
    IReadOnlyList<ValidationIssue> Issues)
{
    public static readonly IrregularSectionValidationResult Valid =
        new(true, Array.Empty<ValidationIssue>());

    public static IrregularSectionValidationResult Errors(IEnumerable<ValidationIssue> issues)
    {
        var list = issues.ToArray();
        bool anyError = list.Any(i => i.Severity == ValidationSeverity.Error);
        return new IrregularSectionValidationResult(!anyError, list);
    }
}
