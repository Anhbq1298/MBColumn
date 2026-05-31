using System.Collections;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Models;

public sealed record SectionPreviewBlock : ReportBlock
{
    public double SectionWidth { get; }
    public double SectionHeight { get; }
    public double Cover { get; }
    public UnitSystem UnitSystem { get; }
    public SectionShapeType SectionShape { get; }
    public IEnumerable Rebars { get; }
    public IEnumerable BoundaryPoints { get; }
    public string Caption { get; }
    public int WidthPct { get; }
    public string? SvgFallback { get; }

    public SectionPreviewBlock(
        double sectionWidth,
        double sectionHeight,
        double cover,
        UnitSystem unitSystem,
        SectionShapeType sectionShape,
        IEnumerable rebars,
        IEnumerable boundaryPoints,
        string caption = "",
        int widthPct = 100,
        string? svgFallback = null)
    {
        SectionWidth = sectionWidth;
        SectionHeight = sectionHeight;
        Cover = cover;
        UnitSystem = unitSystem;
        SectionShape = sectionShape;
        Rebars = rebars;
        BoundaryPoints = boundaryPoints;
        Caption = caption;
        WidthPct = widthPct;
        SvgFallback = svgFallback;
    }
}
