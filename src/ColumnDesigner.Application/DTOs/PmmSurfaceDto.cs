namespace ColumnDesigner.Application.DTOs;

public sealed record PmmSurfaceDto(IReadOnlyList<ControlPointDto> Points, string ForceUnit, string MomentUnit)
{
    public IReadOnlyList<(ControlPointDto A, ControlPointDto B, ControlPointDto C)> MeshTriangles { get; init; } = [];
    public IReadOnlyList<(ControlPointDto A, ControlPointDto B)> WireframeLines { get; init; } = [];
    public string XAxisLabel => "Mx";
    public string YAxisLabel => "My";
    public string ZAxisLabel => "P";
}
