using MBColumn.Application.DTOs;

namespace MBColumn.Application.Services;

public sealed class PmSevenPointReportMapper
{
    private static readonly string[] Codes =
    [
        "CP-01", "CP-02", "CP-03", "CP-04", "CP-05", "CP-06", "CP-07"
    ];

    private static readonly string[] Names =
    [
        "Pure Compression",
        "εs = 0",
        "εs = 0.5εy",
        "εs = εy  (Balanced)",
        "εs > εy  (Transition)",
        "εs = εsu  (Strain cap)",
        "Pure Tension"
    ];

    private static readonly string[] Strains =
    [
        "All steel in compression, εs ≤ 0",
        "Neutral axis at extreme tension steel (εs = 0)",
        "Tension steel at half yield strain (εs = 0.5εy)",
        "Balanced condition – tension steel just yields (εs = εy)",
        "Post-yield transition point (εs > εy)",
        "Steel strain reaches code limit (εs = εsu)",
        "All steel at full yield, no concrete contribution"
    ];

    public IReadOnlyList<ReportVerificationPointRow> Map(
        IReadOnlyList<SevenPointValidationRowDto> rows)
    {
        var result = new List<ReportVerificationPointRow>(rows.Count);
        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            result.Add(new ReportVerificationPointRow
            {
                Index = i + 1,
                PointCode = i < Codes.Length ? Codes[i] : $"CP-{i + 1:D2}",
                PointName = i < Names.Length ? Names[i] : row.PointName,
                StrainDescription = i < Strains.Length ? Strains[i] : row.HandCalcState,
                HandCalcAxialForce = Safe(row.HandCalcPn),
                HandCalcMoment = Safe(row.HandCalcMn),
                SolverAxialForce = Safe(row.SolverPn),
                SolverMoment = Safe(row.SolverMn),
                AxialForceDeviationPct = Safe(row.PnDeviationPercent),
                MomentDeviationPct = Safe(row.MnDeviationPercent),
                Note = row.HandCalcState,
            });
        }
        return result;
    }

    private static double? Safe(double value)
        => double.IsFinite(value) ? value : null;

    public static string FormatOrNa(double? value, string format = "0.##")
    {
        if (!value.HasValue) return "N/A";
        if (!double.IsFinite(value.Value)) return "N/A";
        return value.Value.ToString(format);
    }

    public static string FormatPctOrNa(double? value)
    {
        if (!value.HasValue) return "N/A";
        if (!double.IsFinite(value.Value)) return "N/A";
        return $"{value.Value:0.00}%";
    }
}
