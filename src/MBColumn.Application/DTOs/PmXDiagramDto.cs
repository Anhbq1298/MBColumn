namespace MBColumn.Application.DTOs;

public sealed record PmXDiagramDto(IReadOnlyList<ControlPointDto> Points, string PUnit, string MUnit)
{
    public IReadOnlyList<ControlPointDto> NominalCapacityPoints { get; init; } = [];
    public IReadOnlyList<ControlPointDto> ReducedCapacityPoints { get; init; } = [];
}

