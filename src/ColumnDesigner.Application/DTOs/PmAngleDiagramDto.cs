namespace ColumnDesigner.Application.DTOs;

public sealed record PmAngleDiagramDto(IReadOnlyList<ControlPointDto> Points, double AngleDegrees, string PUnit, string MUnit)
{
    public IReadOnlyList<ChartReferenceLineDto> ReferenceLines { get; init; } = [];
}
