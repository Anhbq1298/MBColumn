using MBColumn.Application.DTOs;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RebarSuggestionInput
{
    public required ColumnInputDto BaseInput { get; init; }
    public required RebarSuggestionConstraintSet Constraints { get; init; }
    public required IReadOnlyList<RebarDefinition> AllowedBars { get; init; }
}
