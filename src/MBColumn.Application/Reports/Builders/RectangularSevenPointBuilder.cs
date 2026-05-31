using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

internal static class RectangularSevenPointBuilder
{
    private static string F(double v, int d = 2) =>
        v.ToString($"F{d}", CultureInfo.InvariantCulture);

    public static ReportSection BuildTheta0(ReportData d, IDesignCodeService code, IUnitConversionService units) =>
        BuildSection(d, isTheta90: false, code, units);

    public static ReportSection BuildTheta90(ReportData d, IDesignCodeService code, IUnitConversionService units) =>
        BuildSection(d, isTheta90: true, code, units);

    private static ReportSection BuildSection(ReportData d, bool isTheta90,
        IDesignCodeService code, IUnitConversionService units)
    {
        string thetaLabel = isTheta90 ? "θ = 90°" : "θ = 0°";
        string secNum = isTheta90 ? "9" : "8";

        // For θ=90°, swap b/h and rotate bar coordinates (x ↔ y)
        double bMm = isTheta90 ? d.HeightMm : d.WidthMm;
        double hMm = isTheta90 ? d.WidthMm : d.HeightMm;
        var bars = isTheta90
            ? d.Rebars.Select(r => r with { X = r.Y, Y = r.X }).ToList()
            : d.Rebars.ToList();

        var report = ReportHandCalcService.Build(
            SectionShapeType.Rectangular,
            bMm, hMm,
            d.FcMpa, d.FyMpa, d.EsMpa,
            bars,
            solverTable: null,
            code, units,
            d.UnitSystem,
            d.DesignCode);

        var blocks = new List<ReportBlock>();

        if (!report.IsSupported)
        {
            blocks.Add(new NoteBlock($"Independent 7-point verification not available: {report.NotSupportedReason}"));
            return new(secNum, $"Independent 7-Point Verification — {thetaLabel}", blocks);
        }

        blocks.Add(new ParagraphBlock(
            $"The following seven control points are independently computed for bending about the " +
            $"principal axis corresponding to {thetaLabel}. " +
            $"For {thetaLabel}: beff = {F(bMm, 0)} mm (compression face width), heff = {F(hMm, 0)} mm."));

        if (!string.IsNullOrEmpty(report.DesignCodeNote))
            blocks.Add(new NoteBlock(report.DesignCodeNote));

        // Summary table
        var summaryHeaders = new[] { "CP", "Point Name", $"φPn ({d.ForceUnitLabel})", $"φMn ({d.MomentUnitLabel})" };
        var summaryRows = report.Rows.Select(r => new[]
        {
            r.ControlPointId,
            r.ControlPointName,
            F(r.HandPnDisplay),
            F(r.HandMxDisplay),
        }).ToArray();
        blocks.Add(new TableBlock(summaryHeaders, summaryRows) { CanSplitByRows = true });

        // Detailed CP blocks
        double fConc = code.ConcreteStressBlockFactor * d.FcMpa * code.ConcreteEffectiveStrengthFactor(d.FcMpa);
        double fyd = code.SteelDesignStrength(d.FyMpa);
        double ecu = code.ConcreteUltimateStrain(d.FcMpa);
        double beta1 = code.Beta1(d.FcMpa);

        foreach (var cp in report.Rows)
        {
            blocks.Add(new HeadingBlock($"{cp.ControlPointId} – {cp.ControlPointName}", 3));
            blocks.Add(new ParagraphBlock(cp.Assumption));

            foreach (var fb in cp.FormulaBlocks)
            {
                blocks.Add(new FormulaBlock(fb.Title, fb.LatexFormula, fb.SubstitutionLatex, fb.ResultLatex)
                { KeepTogether = true, EstimatedHeight = 70 });
            }

            // Steel contribution table (skip pure compression and tension)
            if (cp.ControlPointId is not ("CP-01" or "CP-07"))
            {
                double c = ExtractNaDepth(cp);
                if (!double.IsNaN(c) && c > 0)
                {
                    var steelTable = BuildSteelContributionTable(bars, hMm, c, ecu, fyd, d.EsMpa);
                    if (steelTable is not null)
                    {
                        blocks.Add(new HeadingBlock("Steel Contribution", 4));
                        blocks.Add(steelTable);
                    }
                }
            }

            blocks.Add(new TableBlock(
                ["Result", d.ForceUnitLabel, d.MomentUnitLabel],
                [["Hand Calc", F(cp.HandPnDisplay), F(cp.HandMxDisplay)]])
            { CanSplitByRows = false });
        }

        if (!string.IsNullOrEmpty(report.ComparisonNote))
            blocks.Add(new NoteBlock(report.ComparisonNote));

        return new(secNum, $"Independent 7-Point Verification — {thetaLabel}", blocks);
    }

    private static SteelTableBlock? BuildSteelContributionTable(
        IReadOnlyList<RebarCoordinateDto> bars, double h, double c, double ecu, double fyd, double esMpa)
    {
        var rows = new List<RebarContributionRow>();
        double sumFs = 0, sumFsY = 0, sumFsX = 0;

        for (int i = 0; i < bars.Count; i++)
        {
            var bar = bars[i];
            double di = h / 2.0 - bar.Y;
            double epsi = c > 0 ? ecu * (c - di) / c : 0;
            double fsi = Math.Clamp(esMpa * epsi, -fyd, fyd);
            double Fsi = bar.Area * fsi / 1000.0;
            double FsiY = Fsi * bar.Y / 1000.0;
            double FsiX = Fsi * bar.X / 1000.0;
            sumFs += Fsi; sumFsY += FsiY; sumFsX += FsiX;

            rows.Add(new RebarContributionRow(
                i + 1,
                F(bar.X), F(bar.Y), F(di),
                F(epsi, 5), F(fsi, 1), F(bar.Area, 0),
                F(Fsi), F(FsiY), F(FsiX)));
        }

        return new SteelTableBlock(rows, F(sumFs), F(sumFsY), F(sumFsX));
    }

    private static double ExtractNaDepth(ControlPointValidationRow cp)
    {
        foreach (var fb in cp.FormulaBlocks)
        {
            var result = fb.ResultLatex ?? fb.SubstitutionLatex ?? "";
            var idx = result.IndexOf("= ", StringComparison.Ordinal);
            if (idx >= 0)
            {
                var afterEq = result[(idx + 2)..].Trim().Split([' ', '\\', '\r', '\n'])[0];
                if (double.TryParse(afterEq, NumberStyles.Float, CultureInfo.InvariantCulture, out double c))
                    return c;
            }
        }
        return double.NaN;
    }
}
