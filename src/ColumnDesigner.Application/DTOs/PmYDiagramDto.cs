namespace ColumnDesigner.Application.DTOs;

public sealed record PmYDiagramDto(IReadOnlyList<ControlPointDto> Points, string PUnit, string MUnit);
