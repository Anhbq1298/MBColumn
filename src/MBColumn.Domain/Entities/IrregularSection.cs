using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

// Solver-facing irregular section. BoundaryPoints are in centroid-based local
// coordinates so that (0, 0) is the polygon centroid. Original user coordinates
// are kept separately for UI/export and never used by the solver.
public sealed record IrregularSection(
    IReadOnlyList<Point2D> BoundaryPoints,
    IReadOnlyList<Point2D> BoundaryPointsOriginalMm,
    Point2D CentroidOriginalMm,
    Rect2D BoundingBoxMm,
    double ComputedAreaMm2,
    RebarLayout Layout) : ColumnSection(SectionShapeType.Irregular, Layout)
{
    public override double WidthMm => BoundingBoxMm.Width;
    public override double HeightMm => BoundingBoxMm.Height;
    public override double AreaMm2 => ComputedAreaMm2;
}
