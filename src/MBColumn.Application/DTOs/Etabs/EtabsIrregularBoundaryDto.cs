using MBColumn.Domain.Entities;

namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsIrregularBoundaryDto
{
    public IReadOnlyList<IReadOnlyList<Point2D>> ClockwisePolylines { get; init; } = [];
    public string PierLabel { get; init; } = "";
    public string StoryName { get; init; } = "";
    public IReadOnlyList<string> SourceShellNames { get; init; } = [];
    public IReadOnlyList<string> SourceSectionProperties { get; init; } = [];
    public string? WarningMessage { get; init; }

    public bool HasMultiplePolylines => ClockwisePolylines.Count > 1;
    public bool IsEmpty => ClockwisePolylines.Count == 0;
}
