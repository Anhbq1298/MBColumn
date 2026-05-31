using MBColumn.Application.Reports.Models;
using System.Globalization;
using MBColumn.Domain.Interfaces;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Reports.Builders;

internal static class PmmAngleSweepSectionBuilder
{
    private static string F(double v, int d = 1) =>
        v.ToString($"F{d}", CultureInfo.InvariantCulture);

    public static ReportSection Build(ReportData d, IUnitConversionService units)
    {
        var blocks = new List<ReportBlock>
        {
            new ParagraphBlock(
                "The following table summarises the PMM angle sweep. For each bending angle θ, " +
                "the neutral axis depth and capacity envelope boundary points at pure compression (+) " +
                "and pure tension (−) are listed. Intermediate angles use the general numerical " +
                "strain-compatibility procedure."),

            new HeadingBlock("P-M Interaction Diagram  (governing angle θ = " +
                d.GoverningThetaDeg.ToString("F1", CultureInfo.InvariantCulture) + "°)", 3),
        };

        if (d.PmDiagram is not null)
            blocks.Add(d.PmDiagram);
        else if (!string.IsNullOrEmpty(d.PmDiagramSvg))
            blocks.Add(new ImageBlock(d.PmDiagramSvg, WidthPct: 90, Caption:
                $"Figure 8.1 – P-M interaction diagram at θ = {d.GoverningThetaDeg:F1}°"));

        blocks.Add(new HeadingBlock("Mx-My Interaction Diagram", 3));

        if (d.MmDiagram is not null)
            blocks.Add(d.MmDiagram);
        else if (!string.IsNullOrEmpty(d.MmDiagramSvg))
            blocks.Add(new ImageBlock(d.MmDiagramSvg, WidthPct: 80, Caption:
                "Figure 8.2 – Mx-My interaction diagram at governing axial load"));

        blocks.Add(new HeadingBlock("Angle Sweep Table", 3));

        if (d.PmmSevenPointRows.Count > 0)
        {
            var fu = d.UnitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip;
            var mu = d.UnitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;

            var headers = new[]
            {
                "Point Name", "Hand Calc State", "Hand Calc c (mm)",
                $"Hand Calc Pn ({d.ForceUnitLabel})", $"Hand Calc Mn ({d.MomentUnitLabel})",
                $"Solver Pn ({d.ForceUnitLabel})", $"Solver Mn ({d.MomentUnitLabel})",
                "ΔPn (%)", "ΔMn (%)"
            };
            var rows = d.PmmSevenPointRows.Select(r => new[]
            {
                r.PointName,
                r.HandCalcState,
                F(r.HandCalcC),
                F(units.ForceFromN(r.HandCalcPn, fu), 2),
                F(units.MomentFromNmm(r.HandCalcMn, mu), 2),
                F(units.ForceFromN(r.SolverPn, fu), 2),
                F(units.MomentFromNmm(r.SolverMn, mu), 2),
                F(r.PnDeviationPercent, 2),
                F(r.MnDeviationPercent, 2),
            }).ToArray();

            blocks.Add(new TableBlock(headers, rows, RepeatHeaderOnNewPage: true)
            { CanSplitByRows = true, EstimatedHeight = 30 * (d.PmmSevenPointRows.Count + 1) });
        }
        else
        {
            blocks.Add(new NoteBlock("Angle sweep data not available. Calculate the section first."));
        }

        return new("10", "PMM Angle Sweep and Interaction Diagrams", blocks);
    }
}
