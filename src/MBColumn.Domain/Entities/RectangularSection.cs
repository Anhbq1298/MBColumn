using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public sealed record RectangularSection(
    double Bmm,
    double Hmm,
    RebarLayout Layout) : ColumnSection(SectionShapeType.Rectangular, Layout)
{
    public override double WidthMm => Bmm;
    public override double HeightMm => Hmm;
    public override double AreaMm2 => Bmm * Hmm;
}

