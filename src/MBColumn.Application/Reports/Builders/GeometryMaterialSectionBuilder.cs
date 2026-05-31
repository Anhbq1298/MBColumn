using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using System.Globalization;

namespace MBColumn.Application.Reports.Builders;

internal static class GeometryMaterialSectionBuilder
{
    private static string F(double v, int d = 2) =>
        v.ToString($"F{d}", CultureInfo.InvariantCulture);

    public static ReportSection Build(ReportData d)
    {
        bool isAci = d.DesignCode == DesignCodeType.Aci318Style;
        var blocks = new List<ReportBlock>();

        // ── 2.1 Section Geometry and Reinforcement Layout ──────────────────────
        blocks.Add(new HeadingBlock("2.1  Section Geometry and Reinforcement Layout", 2));

        blocks.Add(new SectionPreviewBlock(
            d.WidthMm, d.HeightMm, d.CoverMm, d.UnitSystem, d.SectionShape, 
            d.Rebars, d.IrregularSectionBoundaryPoints, 
            "Figure 2.1 – Section geometry and reinforcement layout", 50, d.SectionGeometrySvg));

        string[] geoHeaders = ["Parameter", "Value"];
        string[][] geoRows = d.SectionShape switch
        {
            SectionShapeType.Circular => [
                ["Diameter D", $"{F(d.DiameterMm)} mm"],
                ["Clear Cover", $"{F(d.CoverMm)} mm"],
                ["Gross Area Ag", $"{F(Math.PI * (d.DiameterMm / 2) * (d.DiameterMm / 2), 0)} mm²"],
            ],
            _ => [
                ["Width b", $"{F(d.WidthMm)} mm"],
                ["Height h", $"{F(d.HeightMm)} mm"],
                ["Clear Cover", $"{F(d.CoverMm)} mm"],
                ["Gross Area Ag", $"{F(d.WidthMm * d.HeightMm, 0)} mm²"],
            ]
        };
        blocks.Add(new TableBlock(geoHeaders, geoRows) { CanSplitByRows = false });

        double totalAst = d.Rebars.Sum(r => r.Area);
        double agForRatio = d.SectionShape == SectionShapeType.Circular
            ? Math.PI * (d.DiameterMm / 2) * (d.DiameterMm / 2)
            : d.WidthMm * d.HeightMm;
        double rhoG = agForRatio > 0 ? totalAst / agForRatio * 100 : 0;

        blocks.Add(new TableBlock(["Parameter", "Value"],
        [
            ["Number of Bars", d.Rebars.Count.ToString()],
            ["Bar Size", d.BarSize],
            ["Total Steel Area Ast", $"{F(totalAst, 0)} mm²"],
            ["Gross Steel Ratio ρg", $"{F(rhoG, 3)} %"],
        ])
        { CanSplitByRows = false });

        // Rebar coordinate table
        var rebarHeaders = new[] { "Bar", "X (mm)", "Y (mm)", "Dia (mm)", "As (mm²)" };
        var rebarRows = d.Rebars
            .Select((r, i) => new[] { (i + 1).ToString(), F(r.X), F(r.Y), F(r.Diameter), F(r.Area, 0) })
            .ToArray();
        blocks.Add(new TableBlock(rebarHeaders, rebarRows, RepeatHeaderOnNewPage: true)
        { CanSplitByRows = true, EstimatedHeight = 20 * (d.Rebars.Count + 1) });

        // ── 2.2 Material Properties ───────────────────────────────────────────
        blocks.Add(new HeadingBlock("2.2  Material Properties", 2));

        if (isAci)
            blocks.AddRange(BuildAciMaterialBlocks(d));
        else
            blocks.AddRange(BuildEc2MaterialBlocks(d));

        return new("2", "Geometry and Material Properties", blocks);
    }

    private static IEnumerable<ReportBlock> BuildAciMaterialBlocks(ReportData d)
    {
        double beta1 = d.FcMpa <= 28 ? 0.85
            : Math.Max(0.65, 0.85 - 0.05 * (d.FcMpa - 28) / 7);

        yield return new TableBlock(["Parameter", "Symbol", "Value"],
        [
            ["Concrete compressive strength", "f'c", $"{F(d.FcMpa)} MPa"],
            ["Steel yield strength", "fy", $"{F(d.FyMpa)} MPa"],
            ["Steel elastic modulus", "Es", $"{F(d.EsMpa, 0)} MPa"],
            ["Concrete ultimate strain", "εcu", "0.003"],
            ["Stress block depth factor", "β₁", F(beta1, 4)],
            ["Block stress factor", "0.85 f'c", $"{F(0.85 * d.FcMpa)} MPa"],
            ["Reduction factor (compression, tied)", "φ", "0.65"],
            ["Reduction factor (tension)", "φ", "0.90"],
        ])
        { CanSplitByRows = false };

        yield return new FormulaBlock(
            "Steel yield strain",
            @"\varepsilon_y = f_y / E_s",
            $@"\varepsilon_y = {F(d.FyMpa)} / {F(d.EsMpa, 0)}",
            $@"\varepsilon_y = {F(d.FyMpa / d.EsMpa, 5)}");

        yield return new FormulaBlock(
            "Maximum nominal axial compression (ACI tied column, §22.4.2.1)",
            @"P_{n,max} = 0.80 \left[ 0.85 f'_c (A_g - A_{st}) + f_y A_{st} \right]",
            "", "");
    }

    private static IEnumerable<ReportBlock> BuildEc2MaterialBlocks(ReportData d)
    {
        double fcd = d.AlphaCc * d.FcMpa / 1.5;
        double fyd = d.FyMpa / 1.15;
        double lambda = d.FcMpa <= 50 ? 0.8 : Math.Max(0.7, 0.8 - (d.FcMpa - 50) / 400.0);
        double eta   = d.FcMpa <= 50 ? 1.0 : Math.Max(0.8, 1.0 - (d.FcMpa - 50) / 200.0);
        double ecuMpa = d.FcMpa <= 50 ? 0.0035 : 0.0026 + 0.035 * Math.Pow((90 - d.FcMpa) / 100.0, 4);

        yield return new TableBlock(["Parameter", "Symbol", "Value"],
        [
            ["Characteristic cylinder strength", "fck", $"{F(d.FcMpa)} MPa"],
            ["Steel characteristic yield strength", "fyk", $"{F(d.FyMpa)} MPa"],
            ["Steel elastic modulus", "Es", $"{F(d.EsMpa, 0)} MPa"],
            ["Concrete strength coefficient", "αcc", F(d.AlphaCc, 2)],
            ["Concrete partial factor", "γc", "1.50"],
            ["Steel partial factor", "γs", "1.15"],
            ["Design concrete strength", "fcd = αcc fck / γc", $"{F(fcd)} MPa"],
            ["Design steel strength", "fyd = fyk / γs", $"{F(fyd)} MPa"],
            ["Depth factor", "λ", F(lambda, 3)],
            ["Strength factor", "η", F(eta, 3)],
            ["Ultimate concrete strain", "εcu2", F(ecuMpa, 4)],
        ])
        { CanSplitByRows = false };

        yield return new FormulaBlock(
            "Design concrete strength  (EC2 §3.1.6)",
            @"f_{cd} = \alpha_{cc} f_{ck} / \gamma_c",
            $@"f_{{cd}} = {F(d.AlphaCc, 2)} \times {F(d.FcMpa)} / 1.50",
            $@"f_{{cd}} = {F(fcd)} \text{{ MPa}}");

        yield return new FormulaBlock(
            "Design steel strength  (EC2 Table 2.1N)",
            @"f_{yd} = f_{yk} / \gamma_s",
            $@"f_{{yd}} = {F(d.FyMpa)} / 1.15",
            $@"f_{{yd}} = {F(fyd)} \text{{ MPa}}");

        yield return new FormulaBlock(
            "Nominal capacity (EC2 simplified block)",
            @"N_{Rd} = \eta f_{cd} A_c + \sum F_{s,i}",
            "", "");
    }
}
