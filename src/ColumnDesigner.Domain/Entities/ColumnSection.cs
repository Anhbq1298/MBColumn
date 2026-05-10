using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Entities;

public abstract record ColumnSection(SectionShapeType Shape, RebarLayout RebarLayout)
{
    public abstract double WidthMm { get; }
    public abstract double HeightMm { get; }
    public double AreaMm2 => WidthMm * HeightMm;
}
