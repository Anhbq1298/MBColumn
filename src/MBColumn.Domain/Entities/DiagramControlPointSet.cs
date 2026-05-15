namespace MBColumn.Domain.Entities;

public sealed record DiagramControlPointSet(
    IReadOnlyList<ControlPoint> PmPoints,
    IReadOnlyList<ControlPoint> MmPoints,
    IReadOnlyList<ControlPoint> PmmSurfacePoints,
    IReadOnlyList<ControlPoint> MmSlicePoints,
    double NominalCompressionLimitDisplay,
    double DesignCompressionLimitDisplay)
{
    public IReadOnlyList<ControlPoint> SpecialCapacityPoints { get; init; } = [];
}

