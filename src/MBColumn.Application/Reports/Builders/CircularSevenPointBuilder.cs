using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

/// <summary>
/// Generates the 7-point independent verification for circular sections
/// using the circular compression segment method.
/// Correct centroid formula: ybar = (2/3)(R²-y_a²)^(3/2) / Aseg
/// </summary>
internal static class CircularSevenPointBuilder
{
    private static string F(double v, int d = 2) =>
        v.ToString($"F{d}", CultureInfo.InvariantCulture);

    public static ReportSection Build(ReportData d, IDesignCodeService code, IUnitConversionService units)
    {
        bool isAci = d.DesignCode == DesignCodeType.Aci318Style;
        double R = d.DiameterMm / 2.0;
        double fcMpa = d.FcMpa;
        double fyMpa = d.FyMpa;
        double esMpa = d.EsMpa;

        double ecu = code.ConcreteUltimateStrain(fcMpa);
        double beta1 = code.Beta1(fcMpa);
        double fyd = code.SteelDesignStrength(fyMpa);
        double eyd = fyd / esMpa;
        double fConc = code.ConcreteStressBlockFactor * fcMpa * code.ConcreteEffectiveStrengthFactor(fcMpa);
        double etLimit = isAci ? eyd + 0.003 : code.SteelMaxTensileStrain(fyMpa, esMpa);

        var bars = d.Rebars;
        double Ast = bars.Sum(r => r.Area);
        double Ag = Math.PI * R * R;
        double dt = R - bars.Min(r => r.Y);

        string fcdL = isAci ? @"0.85 f'_c" : @"\eta f_{cd}";
        string fydL = isAci ? @"f_y" : @"f_{yd}";
        string ecuL = isAci ? @"\varepsilon_{cu}" : @"\varepsilon_{cu2}";

        var fuEnum = d.UnitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip;
        var muEnum = d.UnitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;

        var blocks = new List<ReportBlock>
        {
            new ParagraphBlock(
                $"Circular section verification uses the circular compression segment method. " +
                $"Diameter D = {F(d.DiameterMm, 0)} mm, R = {F(R, 0)} mm. " +
                $"Compression at top (+Y face). Neutral axis depth c measured from top compression face."),

            new FormulaBlock(
                "Compression segment area (above chord at y_a)",
                @"A_{seg} = R^2 \cos^{-1}\!\!\left(\frac{y_a}{R}\right) - y_a\sqrt{R^2 - y_a^2}",
                "where y_a = R - a", ""),

            new FormulaBlock(
                "Compression segment centroid (from section centre, verified formula)",
                @"\bar{y} = \frac{2}{3} \cdot \frac{(R^2 - y_a^2)^{3/2}}{A_{seg}}",
                "", ""),

            new HeadingBlock("Summary Table", 3),
        };

        // Build all 7 CPs
        var cpList = new List<(string Id, string Name, double PhiPnDisp, double PhiMnDisp)>();

        // CP-01
        {
            double P0 = fConc * (Ag - Ast) + fyd * Ast;
            double PnMax = code.NominalCompressionLimit(P0);
            double phi = isAci ? 0.65 : 1.0;
            cpList.Add(("CP-01", "Pure Compression",
                units.ForceFromN(phi * PnMax, fuEnum), 0));
        }

        (string id, string name, double c)[] strainPoints =
        [
            ("CP-02", $"Zero Tension ({ecuL} at top, εs = 0)", dt),
            ("CP-03", "Half Yield (εs = 0.5εy)", ecu * dt / (ecu + 0.5 * eyd)),
            ("CP-04", "Balanced (εs = εy)", ecu * dt / (ecu + eyd)),
            ("CP-05", isAci ? "Tension Limit (εs = εy + 0.003)" : "Design Strain Limit (εs = εud)",
                ecu * dt / (ecu + etLimit)),
            ("CP-06", "Pure Bending (Pn ≈ 0)", FindPureBendingNA(R, fConc, fyd, esMpa, bars, ecu, beta1)),
        ];

        foreach (var (id, name, c) in strainPoints)
        {
            var (Pn, Mn) = CalcCircularPnMn(R, fConc, fyd, esMpa, bars, c, beta1, ecu);
            double et = dt > 0 && c > 0 ? ecu * (dt - c) / c : 0;
            double phi = code.Phi(et, fyd, esMpa);
            cpList.Add((id, name,
                units.ForceFromN(phi * Pn, fuEnum),
                units.MomentFromNmm(phi * Mn, muEnum)));
        }

        // CP-07
        {
            double PnTen = -fyd * Ast;
            double phi = isAci ? 0.90 : 1.0;
            cpList.Add(("CP-07", "Pure Tension",
                units.ForceFromN(phi * PnTen, fuEnum), 0));
        }

        // Summary table
        blocks.Add(new TableBlock(
            ["CP", "Point Name", $"φPn ({d.ForceUnitLabel})", $"φMn ({d.MomentUnitLabel})"],
            cpList.Select(cp => new[] { cp.Id, cp.Name, F(cp.PhiPnDisp), F(cp.PhiMnDisp) }).ToArray()));

        // Detailed blocks
        blocks.Add(new HeadingBlock("Detailed Calculations", 3));

        // CP-01 detail
        {
            double P0 = fConc * (Ag - Ast) + fyd * Ast;
            double PnMax = code.NominalCompressionLimit(P0);
            double phi = isAci ? 0.65 : 1.0;
            blocks.Add(new HeadingBlock("CP-01 – Pure Compression", 4));
            blocks.Add(new FormulaBlock("Gross area", @"A_g = \pi R^2",
                $@"A_g = \pi \times {F(R, 0)}^2", $@"A_g = {F(Ag, 0)}\ \mathrm{{mm^2}}"));
            blocks.Add(new FormulaBlock($"Nominal axial capacity",
                $@"P_0 = {fcdL}(A_g - A_{{st}}) + {fydL} A_{{st}}",
                $@"P_0 = {F(fConc)} \times ({F(Ag, 0)} - {F(Ast, 0)}) + {F(fyd)} \times {F(Ast, 0)}",
                $@"P_0 = {F(P0 / 1000, 1)}\ \mathrm{{kN}}"));
            blocks.Add(new FormulaBlock($"Design capacity (φ = {F(phi, 2)})",
                isAci ? @"\phi P_{n,max} = \phi \cdot 0.80 \cdot P_0" : @"P_{Rd,max} = P_0",
                $@"\phi P_{{n,max}} = {F(phi, 2)} \times {F(PnMax / 1000, 1)}",
                $@"\phi P_{{n,max}} = {F(phi * PnMax / 1000, 1)}\ \mathrm{{kN}}"));
        }

        // CP-02 to CP-06 details
        foreach (var (id, name, c) in strainPoints)
        {
            double a = Math.Min(beta1 * c, 2.0 * R);
            double y_a = R - a;
            double Aseg = CircleSegArea(R, y_a);
            double ybar = CircleSegCentroid(R, y_a, Aseg);
            double Cc = fConc * Aseg;
            var (Pn, Mn) = CalcCircularPnMn(R, fConc, fyd, esMpa, bars, c, beta1, ecu);
            double et = dt > 0 && c > 0 ? ecu * (dt - c) / c : 0;
            double phi = code.Phi(et, fyd, esMpa);

            blocks.Add(new HeadingBlock($"{id} – {name}", 4));
            blocks.Add(new FormulaBlock("Neutral axis and stress block depth",
                "c,\\ a = \\beta_1 c,\\ y_a = R - a",
                "", $@"c = {F(c)}\ \mathrm{{mm}},\quad a = {F(a)}\ \mathrm{{mm}},\quad y_a = {F(y_a)}\ \mathrm{{mm}}"));
            blocks.Add(new FormulaBlock("Compression segment area",
                @"A_{seg} = R^2 \cos^{-1}(y_a/R) - y_a\sqrt{R^2 - y_a^2}",
                $@"y_a/R = {F(y_a / R, 4)}",
                $@"A_{{seg}} = {F(Aseg, 0)}\ \mathrm{{mm^2}}"));
            blocks.Add(new FormulaBlock("Segment centroid from centre",
                @"\bar{y} = \frac{2}{3}(R^2 - y_a^2)^{3/2} / A_{seg}",
                "",
                $@"\bar{{y}} = {F(ybar, 1)}\ \mathrm{{mm}}"));
            blocks.Add(new FormulaBlock("Concrete compression force",
                $@"C_c = {fcdL} \cdot A_{{seg}}",
                $@"C_c = {F(fConc)} \times {F(Aseg, 0)}",
                $@"C_c = {F(Cc / 1000, 1)}\ \mathrm{{kN}}"));

            blocks.Add(new HeadingBlock("Steel Contribution", 4));
            blocks.Add(BuildCircleSteelTable(bars, R, c, ecu, fyd, esMpa));

            blocks.Add(new FormulaBlock("Design capacities",
                @"\phi P_n,\quad \phi M_n",
                $@"\phi = {F(phi, 3)},\quad P_n = {F(Pn / 1000, 1)}\ \mathrm{{kN}},\quad M_n = {F(Mn / 1e6, 1)}\ \mathrm{{kNm}}",
                $@"\phi P_n = {F(phi * Pn / 1000, 1)}\ \mathrm{{kN}},\quad \phi M_n = {F(phi * Mn / 1e6, 1)}\ \mathrm{{kNm}}"));
        }

        // CP-07 detail
        {
            double PnTen = -fyd * Ast;
            double phi = isAci ? 0.90 : 1.0;
            blocks.Add(new HeadingBlock("CP-07 – Pure Tension", 4));
            blocks.Add(new FormulaBlock("Nominal pure tension",
                $@"P_{{n,ten}} = -{fydL} A_{{st}}",
                $@"P_{{n,ten}} = -{F(fyd)} \times {F(Ast, 0)}",
                $@"P_{{n,ten}} = {F(PnTen / 1000, 1)}\ \mathrm{{kN}}"));
            blocks.Add(new FormulaBlock($"Design pure tension (φ = {F(phi, 2)})",
                @"\phi P_{n,ten} = \phi \cdot P_{n,ten}",
                $@"\phi P_{{n,ten}} = {F(phi, 2)} \times {F(PnTen / 1000, 1)}",
                $@"\phi P_{{n,ten}} = {F(phi * PnTen / 1000, 1)}\ \mathrm{{kN}}"));
        }

        return new("8", "Independent 7-Point Verification — Circular Section", blocks);
    }

    // ── Circular geometry helpers ─────────────────────────────────────────────

    internal static double CircleSegArea(double R, double y_a)
    {
        double ratio = Math.Clamp(y_a / R, -1.0, 1.0);
        return R * R * Math.Acos(ratio) - y_a * Math.Sqrt(Math.Max(0, R * R - y_a * y_a));
    }

    internal static double CircleSegCentroid(double R, double y_a, double Aseg)
    {
        if (Aseg < 1e-10) return R;
        return (2.0 / 3.0) * Math.Pow(Math.Max(0, R * R - y_a * y_a), 1.5) / Aseg;
    }

    private static (double Pn, double Mn) CalcCircularPnMn(
        double R, double fConc, double fyd, double Es,
        IReadOnlyList<RebarCoordinateDto> bars, double c, double beta1, double ecu)
    {
        double a = Math.Min(beta1 * c, 2.0 * R);
        double y_a = R - a;
        double Aseg = CircleSegArea(R, y_a);
        double ybar = CircleSegCentroid(R, y_a, Aseg);
        double Cc = fConc * Aseg;
        double Pn = Cc, Mn = Cc * ybar;

        foreach (var bar in bars)
        {
            double di = R - bar.Y;
            double epsi = c > 0 ? ecu * (c - di) / c : 0;
            double fsi = Math.Clamp(Es * epsi, -fyd, fyd);
            Pn += bar.Area * fsi;
            Mn += bar.Area * fsi * bar.Y;
        }
        return (Pn, Mn);
    }

    private static double FindPureBendingNA(double R, double fConc, double fyd, double Es,
        IReadOnlyList<RebarCoordinateDto> bars, double ecu, double beta1)
    {
        double cLow = 1e-3, cHigh = 2 * R;
        double c = (cLow + cHigh) / 2;
        for (int i = 0; i < 120; i++)
        {
            var (Pn, _) = CalcCircularPnMn(R, fConc, fyd, Es, bars, c, beta1, ecu);
            if (Math.Abs(Pn) < 0.1) break;
            if (Pn > 0) cHigh = c; else cLow = c;
            c = (cLow + cHigh) / 2;
        }
        return c;
    }

    private static SteelTableBlock BuildCircleSteelTable(
        IReadOnlyList<RebarCoordinateDto> bars, double R, double c, double ecu, double fyd, double Es)
    {
        var rows = new List<RebarContributionRow>();
        double sumFs = 0, sumFsY = 0, sumFsX = 0;

        for (int i = 0; i < bars.Count; i++)
        {
            var bar = bars[i];
            double di = R - bar.Y;
            double epsi = c > 0 ? ecu * (c - di) / c : 0;
            double fsi = Math.Clamp(Es * epsi, -fyd, fyd);
            double Fsi = bar.Area * fsi / 1000.0;
            double FsiY = Fsi * bar.Y / 1000.0;
            double FsiX = Fsi * bar.X / 1000.0;
            sumFs += Fsi; sumFsY += FsiY; sumFsX += FsiX;

            rows.Add(new RebarContributionRow(
                i + 1, F(bar.X), F(bar.Y), F(di),
                F(epsi, 5), F(fsi, 1), F(bar.Area, 0),
                F(Fsi), F(FsiY), F(FsiX)));
        }

        return new SteelTableBlock(rows, F(sumFs), F(sumFsY), F(sumFsX));
    }
}
