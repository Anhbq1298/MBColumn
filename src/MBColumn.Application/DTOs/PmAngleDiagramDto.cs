namespace MBColumn.Application.DTOs;

public sealed record PmAngleDiagramDto(IReadOnlyList<ControlPointDto> Points, double AngleDegrees, string PUnit, string MUnit)
{
    public IReadOnlyList<ChartReferenceLineDto> ReferenceLines { get; init; } = [];
    public IReadOnlyList<ControlPointDto> NominalCapacityPoints { get; init; } = [];
    public IReadOnlyList<ControlPointDto> ReducedCapacityPoints { get; init; } = [];
}

