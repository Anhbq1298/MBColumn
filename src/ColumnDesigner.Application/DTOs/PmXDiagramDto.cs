namespace ColumnDesigner.Application.DTOs;

public sealed record PmXDiagramDto(IReadOnlyList<ControlPointDto> Points, string PUnit, string MUnit);
