using MBColumn.Application.Reports.Models;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

internal static class PmmSummarySectionBuilder
{
    public static ReportSection Build(ReportData d)
    {
        string pct = (d.GoverningPmmRatio * 100).ToString("F1", CultureInfo.InvariantCulture);
        string pass = d.IsPass ? "PASS" : "FAIL";
        string thetaStr = d.GoverningThetaDeg.ToString("F1", CultureInfo.InvariantCulture);
        string naStr = d.GoverningNaDepthMm.ToString("F1", CultureInfo.InvariantCulture);

        var blocks = new List<ReportBlock>
        {
            new SummaryBoxBlock($"Governing PMM Ratio: {d.GoverningPmmRatio:F4}  ({pct} %)  —  {pass}", "", d.IsPass)
            { EstimatedHeight = 50 },

            new TableBlock(
                ["Parameter", "Value"],
                [
                    ["Governing Utilization Ratio (UR)", d.GoverningPmmRatio.ToString("F4", CultureInfo.InvariantCulture)],
                    ["Governing Load Case", d.GoverningLoadCaseName],
                    [$"Governing Angle θ", $"{thetaStr}°"],
                    ["Governing Neutral Axis Depth", $"{naStr} mm"],
                    [$"Capacity P ({d.ForceUnitLabel})", d.GoverningCapPDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                    [$"Capacity Mx ({d.MomentUnitLabel})", d.GoverningCapMxDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                    [$"Capacity My ({d.MomentUnitLabel})", d.GoverningCapMyDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                ])
            { CanSplitByRows = false }
        };

        return new("5", "PMM Capacity Summary", blocks);
    }
}
