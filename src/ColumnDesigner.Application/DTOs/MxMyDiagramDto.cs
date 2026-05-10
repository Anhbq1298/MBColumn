namespace ColumnDesigner.Application.DTOs;

public sealed record MxMyDiagramDto(IReadOnlyList<ControlPointDto> Points, string MUnit, double SelectedP, string PUnit);
