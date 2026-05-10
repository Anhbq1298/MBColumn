namespace ColumnDesigner.Domain.Entities;

public sealed record InteractionSurface(
    int DepthCount,
    int AngleCount,
    IReadOnlyList<InteractionPoint> Points)
{
    public const int ReferenceAngleCount = 36;
    public int RowLength => AngleCount;
}
