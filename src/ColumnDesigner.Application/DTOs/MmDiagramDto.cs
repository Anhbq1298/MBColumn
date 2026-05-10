namespace ColumnDesigner.Application.DTOs;

public sealed record MmDiagramDto(IReadOnlyList<ControlPointDto> Points, string MUnit);
