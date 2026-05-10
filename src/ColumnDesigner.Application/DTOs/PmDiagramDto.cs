namespace ColumnDesigner.Application.DTOs;

public sealed record PmDiagramDto(IReadOnlyList<ControlPointDto> Points, string PUnit, string MUnit);
