namespace ColumnDesigner.Application.DTOs;

public sealed record ValidationResultDto(bool IsValid, IReadOnlyList<string> Errors)
{
    public static ValidationResultDto Valid { get; } = new(true, Array.Empty<string>());
}
