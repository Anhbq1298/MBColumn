using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

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
        IReadOnlyList<SevenPointValidationRowDto> rows,
        IUnitConversionService units,
        bool isMetric)
    {
        var forceUnit = isMetric ? ForceUnit.kN : ForceUnit.Kip;
        var momentUnit = isMetric ? MomentUnit.kNm : MomentUnit.KipFt;

        bool isEc2 = rows.Any(r => r.PointName.Contains("εs,t") || r.PointName.Contains("N = 0"));

        var strains = isEc2 ? new[]
        {
            "All steel in compression, εs,t ≤ 0",
            "Neutral axis at extreme tension steel (εs,t = 0)",
            "Tension steel at half design yield strain (εs,t = 0.5εyd)",
            "Balanced condition – tension steel yields (εs,t = εyd)",
            "Pure bending condition (axial force N = 0)",
            "Steel strain reaches design ultimate limit (εs,t = εud)",
            "All steel at full yield, no concrete contribution"
        } : new[]
        {
            "All steel in compression, es ≤ 0",
            "Neutral axis at extreme tension steel (es = 0)",
            "Tension steel at half yield strain (es = 0.5ey)",
            "Balanced condition – tension steel yields (es = ey)",
            "Post-yield transition point (es = Transition)",
            "Steel strain reaches ultimate limit (es = Strain Cap)",
            "All steel at full yield, no concrete contribution"
        };

        var result = new List<ReportVerificationPointRow>(rows.Count);
        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            result.Add(new ReportVerificationPointRow
            {
                Index = i + 1,
                PointCode = i < Codes.Length ? Codes[i] : $"CP-{i + 1:D2}",
                PointName = row.PointName,
                StrainDescription = i < strains.Length ? strains[i] : row.HandCalcState,
                HandCalcAxialForce = Safe(units.ForceFromN(row.HandCalcPn, forceUnit)),
                HandCalcMoment = Safe(units.MomentFromNmm(row.HandCalcMn, momentUnit)),
                SolverAxialForce = Safe(units.ForceFromN(row.SolverPn, forceUnit)),
                SolverMoment = Safe(units.MomentFromNmm(row.SolverMn, momentUnit)),
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
