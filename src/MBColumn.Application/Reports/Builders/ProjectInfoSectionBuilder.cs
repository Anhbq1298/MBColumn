using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Builders;

internal static class ProjectInfoSectionBuilder
{
    public static ReportSection Build(ReportData d) => new("1", "Project and Design Information",
    [
        new TableBlock(
            ["Parameter", "Value"],
            [
                ["Project", d.ProjectName],
                ["Group", d.GroupName],
                ["Design Tier", d.DesignTierName],
                ["Section Shape", FormatShape(d.SectionShape)],
                ["Design Code", FormatCode(d.DesignCode)],
                ["Unit System", d.UnitSystem == UnitSystem.Metric ? "Metric (kN, kNm, mm, MPa)" : "Imperial (kip, kip-ft, in, ksi)"],
                ["Force Unit", d.ForceUnitLabel],
                ["Moment Unit", d.MomentUnitLabel],
                ["Report Generated", d.GeneratedAt.ToString("yyyy-MM-dd HH:mm")],
            ])
        { CanSplitByRows = false, EstimatedHeight = 200 }
    ]);

    private static string FormatShape(SectionShapeType s) => s switch
    {
        SectionShapeType.Rectangular => "Rectangular",
        SectionShapeType.Circular    => "Circular",
        SectionShapeType.Irregular   => "Irregular",
        _                            => s.ToString()
    };

    private static string FormatCode(DesignCodeType c) => c switch
    {
        DesignCodeType.Aci318Style => "ACI 318",
        DesignCodeType.Ec2        => "Eurocode 2 (EN 1992-1-1)",
        _                         => c.ToString()
    };
}
