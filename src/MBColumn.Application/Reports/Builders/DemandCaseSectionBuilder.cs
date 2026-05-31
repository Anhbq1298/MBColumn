using MBColumn.Application.Reports.Models;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

internal static class DemandCaseSectionBuilder
{
    public static ReportSection BuildAppliedDemand(ReportData d)
    {
        var governing = d.DemandCases
            .OrderByDescending(c => c.PmmRatio)
            .FirstOrDefault();

        var blocks = new List<ReportBlock>();

        if (governing is not null)
        {
            blocks.Add(new TableBlock(
                ["Parameter", "Value"],
                [
                    ["Governing Case", governing.LoadCaseName],
                    [$"Pu ({d.ForceUnitLabel})", governing.PuDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                    [$"Mux ({d.MomentUnitLabel})", governing.MuxDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                    [$"Muy ({d.MomentUnitLabel})", governing.MuyDisplay.ToString("F2", CultureInfo.InvariantCulture)],
                    ["PMM Ratio", governing.PmmRatio.ToString("F4", CultureInfo.InvariantCulture)],
                ])
            { CanSplitByRows = false });
        }

        blocks.Add(new NoteBlock(
            "MB Column sign convention: Design force P is positive in compression. " +
            "The element axial force P from structural analysis is multiplied by −1 to obtain the design force."));

        return new("4", "Applied Design Demand", blocks);
    }

    public static ReportSection BuildDemandResults(ReportData d)
    {
        var governing = d.DemandCases
            .OrderByDescending(c => c.PmmRatio)
            .FirstOrDefault();

        var blocks = new List<ReportBlock>();

        if (governing is not null)
        {
            var headers = new[]
            {
                "Case Name", $"Pu ({d.ForceUnitLabel})", $"Mux ({d.MomentUnitLabel})", $"Muy ({d.MomentUnitLabel})",
                $"ϕPn ({d.ForceUnitLabel})", $"ϕMnx ({d.MomentUnitLabel})", $"ϕMny ({d.MomentUnitLabel})",
                "PMM Ratio", "Status"
            };

            var row = new[]
            {
                governing.LoadCaseName,
                governing.PuDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.MuxDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.MuyDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.CapacityPDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.CapacityMxDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.CapacityMyDisplay.ToString("F2", CultureInfo.InvariantCulture),
                governing.PmmRatio.ToString("F4", CultureInfo.InvariantCulture),
                governing.PmmRatio <= 1.0 ? "Pass" : "Fail",
            };

            blocks.Add(new TableBlock(headers, [row]) { CanSplitByRows = false });
        }
        else
        {
            blocks.Add(new NoteBlock("No demand case results available."));
        }

        return new("11", "Governing Demand Case", blocks);
    }
}
