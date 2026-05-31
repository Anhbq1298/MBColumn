using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

internal static class ConclusionSectionBuilder
{
    public static ReportSection Build(ReportData d)
    {
        string codeRef = d.DesignCode == DesignCodeType.Aci318Style
            ? "ACI 318"
            : "Eurocode 2 (EN 1992-1-1)";

        string compliance = d.IsPass
            ? $"The section is ADEQUATE. The governing utilization ratio of {d.GoverningPmmRatio:F4} does not exceed 1.000."
            : $"The section is INADEQUATE. The governing utilization ratio of {d.GoverningPmmRatio:F4} exceeds 1.000.";

        return new("12", "Conclusion and Appendix",
        [
            new SummaryBoxBlock(compliance, "", d.IsPass) { EstimatedHeight = 50 },
            new TableBlock(
                ["Parameter", "Value"],
                [
                    ["Design Code", codeRef],
                    ["Governing PMM Ratio", d.GoverningPmmRatio.ToString("F4", CultureInfo.InvariantCulture)],
                    ["Governing Load Case", d.GoverningLoadCaseName],
                    [$"Governing θ", $"{d.GoverningThetaDeg:F1}°"],
                    ["Compliance", d.IsPass ? "PASS" : "FAIL"],
                ])
            { CanSplitByRows = false }
        ]);
    }
}
