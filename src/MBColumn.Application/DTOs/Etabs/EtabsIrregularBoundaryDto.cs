using MBColumn.Domain.Entities;

namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsIrregularBoundaryDto
{
    public IReadOnlyList<IReadOnlyList<Point2D>> ClockwisePolylines { get; init; } = [];

    // Counter-clockwise rings representing voids (hollow interiors detected by NTS union).
    // Each entry is one opening boundary; MBColumn treats these as subtracted regions.
    public IReadOnlyList<IReadOnlyList<Point2D>> OpeningPolylines { get; init; } = [];

    public string PierLabel { get; init; } = "";
    public string StoryName { get; init; } = "";
    public IReadOnlyList<string> SourceShellNames { get; init; } = [];
    public IReadOnlyList<string> SourceSectionProperties { get; init; } = [];
    public string? WarningMessage { get; init; }

    public bool HasMultiplePolylines => ClockwisePolylines.Count > 1;
    public bool HasOpenings => OpeningPolylines.Count > 0;
    public bool IsEmpty => ClockwisePolylines.Count == 0;
}
