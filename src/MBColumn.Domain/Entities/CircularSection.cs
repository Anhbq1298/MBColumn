using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public sealed record CircularSection(
    double DiameterMm,
    RebarLayout Layout) : ColumnSection(SectionShapeType.Circular, Layout)
{
    public double RadiusMm => DiameterMm / 2.0;
    public override double WidthMm => DiameterMm;
    public override double HeightMm => DiameterMm;
    public override double AreaMm2 => Math.PI * RadiusMm * RadiusMm;
}
