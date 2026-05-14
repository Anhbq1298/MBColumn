using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public abstract record ColumnSection(SectionShapeType Shape, RebarLayout RebarLayout)
{
    public abstract double WidthMm { get; }
    public abstract double HeightMm { get; }
    public abstract double AreaMm2 { get; }
}

