using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Reports.Builders.Ec2;

/// <summary>
/// Builds the full calculation report for the EC2 (EN 1992-1-1) design code.
/// </summary>
internal sealed class Ec2ReportBuilder
{
    internal ReportData Build(
        string projectName, string groupName, string designTierName,
        CalculationResultDto r,
        IDesignCodeService code,
        IUnitConversionService units,
        string? sectionSvg,
        DiagramBlock? pmDiagram, DiagramBlock? mmDiagram)
    {
        bool isMetric = r.UnitSystem == UnitSystem.Metric;
        string fUnit  = isMetric ? "kN"   : "kip";
        string mUnit  = isMetric ? "kN·m" : "kip-ft";
        bool hasShearResult = r.GoverningShearResult is not null;
        bool hasSlend = r.IncludeEc2Slenderness && r.Ec2Slenderness.LoadCases.Count > 0;

        var sections = new List<ReportSection>
        {
            S1_ProjectInfo(projectName, groupName, designTierName, r),
            S2_Materials(r, code),
            S3_SectionProperties(r, sectionSvg),
            S4_DemandsAndSlenderness(r, fUnit, mUnit, isMetric, hasSlend),
            S5_ResultsSummary(r, fUnit, mUnit, hasShearResult),
            S51_PmmDetails(r, fUnit, mUnit, pmDiagram, mmDiagram),
            S52_ShearDetails(r, fUnit),
        };

        if (r.RebarCompliance is not null)
            sections.Add(S6_Compliance(r.RebarCompliance));

        sections.Add(S7_Conclusion(r));

        // ── Annexes ───────────────────────────────────────────────────────────

        sections.Add(AnnexA_Coordinates(r));
        sections.Add(AnnexBTheorySectionBuilder.Build(r));

        var handCalc = ReportHandCalcService.Build(
            r.SectionShape, r.SectionWidthMm, r.SectionHeightMm,
            r.FcMpa, r.FyMpa, r.EsMpa, r.RebarCoordinates,
            r.ControlPointTable, code, units, r.UnitSystem, r.DesignCode);

        // Annex C removed per user request
        // if (handCalc.IsSupported)
        //     sections.Add(AnnexC_HandCalc(handCalc));

        return new ReportData
        {
            ProjectName    = projectName,
            GroupName      = groupName,
            DesignTierName = designTierName,
            GeneratedAt    = DateTime.Now,
            Sections       = sections,
        };
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 1 · Project Information
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S1_ProjectInfo(
        string proj, string grp, string tier, CalculationResultDto r)
        => new("1", "Project Information",
        [
            new TableBlock(
                ["Field", "Value"],
                [
                    ["Project",     Dash(proj)],
                    ["Group",       Dash(grp)],
                    ["Section",     Dash(tier)],
                    ["Design Code", "EC2  EN 1992-1-1 : 2004"],
                    ["Unit System", r.UnitSystem.ToString()],
                    ["Integration", r.IntegrationMethod.ToString()],
                    ["Generated",   DateTime.Now.ToString("yyyy-MM-dd HH:mm")],
                ]),
        ]);

    // ─────────────────────────────────────────────────────────────────────────
    // 2 · Material Properties  (EC2)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S2_Materials(CalculationResultDto r, IDesignCodeService code)
    {
        double fcd    = r.AlphaCc * r.FcMpa / 1.5;
        double fyd    = r.FyMpa / 1.15;
        double eta    = code.ConcreteEffectiveStrengthFactor(r.FcMpa);
        double lambda = code.Beta1(r.FcMpa);
        double ecu2   = code.ConcreteUltimateStrain(r.FcMpa);
        double ec2    = code.ConcretePeakStrain(r.FcMpa);
        double ecm    = 22_000 * Math.Pow((r.FcMpa + 8.0) / 10.0, 0.3);
        double eyd    = fyd / r.EsMpa;

        return new("2", "Material Properties",
        [
            new TableBlock(
                ["Property", "Symbol", "Value"],
                [
                    ["Char. cylinder strength",        "fck",           $"{r.FcMpa:0.#} MPa"],
                    ["Mean cylinder strength",         "fcm = fck + 8", $"{r.FcMpa + 8:0.#} MPa"],
                    ["Secant modulus",                 "Ecm",           $"{ecm:0.#} MPa"],
                    ["Ultimate compressive strain",    "εcu2",          $"{ecu2:F4}"],
                    ["Strain at peak stress",          "εc2",           $"{ec2:F4}"],
                    ["Strength coeff.  (NA value)",    "αcc",           $"{r.AlphaCc:0.##}"],
                    ["Concrete partial factor",        "γc",            "1.50"],
                    ["Design strength  αcc·fck/γc",   "fcd",           $"{fcd:0.##} MPa"],
                    ["Effectiveness factor",           "η",             $"{eta:0.###}"],
                    ["Stress-block depth factor",      "λ",             $"{lambda:0.###}"],
                ]),

            new TableBlock(
                ["Property", "Symbol", "Value"],
                [
                    ["Char. yield strength",           "fyk",          $"{r.FyMpa:0.#} MPa"],
                    ["Elastic modulus",                "Es",           $"{r.EsMpa:0.#} MPa"],
                    ["Steel partial factor",           "γs",           "1.15"],
                    ["Design yield strength  fyk/γs", "fyd",          $"{fyd:0.##} MPa"],
                    ["Design yield strain    fyd/Es", "εyd",          $"{eyd:F5}"],
                    ["Design tensile strain limit",   "εud = 0.9 εuk","0.045 0  (class B/C, NA)"],
                ]),
        ]);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 3 · Section Properties
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S3_SectionProperties(CalculationResultDto r, string? svg)
    {
        var blocks = new List<ReportBlock>();
        if (!string.IsNullOrWhiteSpace(svg))
            blocks.Add(new ImageBlock(svg, Caption: "Figure 3.1 – Cross-section geometry"));

        string dims = r.SectionShape switch
        {
            SectionShapeType.Circular  => $"D = {r.DiameterMm:0.#} mm",
            SectionShapeType.Irregular => "Irregular cross-section",
            _                          => $"b = {r.SectionWidthMm:0.#} mm,  h = {r.SectionHeightMm:0.#} mm",
        };
        double ag  = r.SectionShape == SectionShapeType.Circular
                     ? Math.PI / 4 * r.DiameterMm * r.DiameterMm
                     : r.SectionShape == SectionShapeType.Irregular
                       && r.IrregularSectionBoundaryPoints.Count >= 3
                         ? PolygonArea(r.IrregularSectionBoundaryPoints)
                         : r.SectionWidthMm * r.SectionHeightMm;
        double ast = r.RebarCoordinates.Sum(b => b.Area);

        blocks.Add(new TableBlock(
            ["Property", "Value"],
            [
                ["Shape",          r.SectionShape.ToString()],
                ["Dimensions",     dims],
                ["Clear cover",    $"{r.CoverMm:0.#} mm"],
                ["Gross area  Ac", $"{ag:0.#} mm²"],
            ]));

        blocks.Add(new TableBlock(
            ["Property", "Value"],
            [
                ["Total bars",              r.RebarCoordinates.Count.ToString()],
                ["Total As",                $"{ast:0.#} mm²"],
                ["Ratio  ρ = As/Ac",        $"{ast / ag:F4}"],
                ["Min  ρ_min (EC2 §9.5.2)", "0.002  (check in Annex A)"],
                ["Max  ρ_max (EC2 §9.5.2)", "0.040"],
            ]));

        return new("3", "Section Properties", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 4 · Demand Cases + EC2 Slenderness
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S4_DemandsAndSlenderness(
        CalculationResultDto r, string fUnit, string mUnit,
        bool isMetric, bool hasSlend)
    {
        var blocks = new List<ReportBlock>();

        // 4.1  First-order demands
        var rows = r.LoadCaseResults
            .OrderByDescending(lc => lc.PmmRatio)
            .Select(lc => new[]
            {
                lc.LoadCaseName,
                $"{lc.PuDisplay:0.##}",
                $"{lc.MuxDisplay:0.##}",
                $"{lc.MuyDisplay:0.##}",
                $"{lc.PmmRatio:0.###}",
                lc.Status.ToString(),
            }).ToArray();

        blocks.Add(new TableBlock(
            ["Load Case", $"NEd ({fUnit})", $"MEd,x ({mUnit})", $"MEd,y ({mUnit})", "UR", "Status"],
            rows));

        if (!hasSlend)
            return new("4", "Demand Cases", blocks);

        // 4.2  Factored demands (with M2)
        var sl = r.Ec2Slenderness;
        double mScale = isMetric ? 1e-6 : 1e-6 / 1.356;

        var factored = r.LoadCaseResults
            .OrderByDescending(lc => lc.PmmRatio)
            .Select(lc =>
            {
                var s = sl.LoadCases.FirstOrDefault(c => c.LoadCaseId == lc.LoadCaseId);
                string mxU = s?.X is not null ? $"{s.X.MUsedNmm * mScale:0.##}" : $"{lc.MuxDisplay:0.##}";
                string myU = s?.Y is not null ? $"{s.Y.MUsedNmm * mScale:0.##}" : $"{lc.MuyDisplay:0.##}";
                return new[] { lc.LoadCaseName, $"{lc.PuDisplay:0.##}", mxU, myU, s?.Status ?? "—" };
            }).ToArray();

        blocks.Add(new TableBlock(
            ["Load Case", $"NEd ({fUnit})", $"MEd,x,used ({mUnit})", $"MEd,y,used ({mUnit})", "Slend. Status"],
            factored));

        // 4.3  Governing case step-by-step detail (rich block, rendered by HTML renderer)
        var govLc = r.LoadCaseResults
            .Where(lc => double.IsFinite(lc.PmmRatio))
            .OrderByDescending(lc => lc.PmmRatio)
            .FirstOrDefault();

        if (govLc is not null)
        {
            var govSl = sl.LoadCases.FirstOrDefault(c => c.LoadCaseId == govLc.LoadCaseId);
            if (govSl is not null)
            {
                blocks.Add(new HeadingBlock(
                    $"EC2 §5.8 — Governing load case: {govSl.CaseName}", 2));
                blocks.Add(new Ec2SlendernessDetailBlock(govSl, sl, isMetric, mUnit));
            }
        }

        return new("4", "Demand Cases & EC2 §5.8 Slenderness", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5 · Section Analysis Results — Summary
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S5_ResultsSummary(
        CalculationResultDto r, string fUnit, string mUnit, bool hasShear)
    {
        bool pmmPass = r.Ratio <= 1.0;
        var shear = r.GoverningShearResult;
        bool shearHasDemand = hasShear && shear?.HasDemand == true;
        bool shearPass = !shearHasDemand || shear!.GoverningStatus == CapacityStatus.Pass;
        bool allPass = pmmPass && shearPass;

        var rows = new List<string[]>
        {
            new[] { "PMM Interaction", $"{r.Ratio:0.###}", pmmPass ? "✓ Pass" : "✗ Fail" },
        };
        if (hasShear && shear is not null)
        {
            rows.Add(shearHasDemand
                ? ["Shear (governing)", $"{shear.GoverningUtilisation:0.###}", shearPass ? "Pass" : "Fail"]
                : ["Shear Check", "No VEd", "Capacity shown for reference"]);
        }

        return new("5", "Section Analysis Results",
        [
            new SummaryBoxBlock(
                allPass ? "ALL CHECKS PASS" : "ONE OR MORE CHECKS FAIL",
                allPass ? "Pass" : "Fail",
                allPass),
            new TableBlock(
                ["Check", "UR", "Result"],
                [.. rows]),
        ]);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5.1 · PMM Details
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S51_PmmDetails(
        CalculationResultDto r, string fUnit, string mUnit,
        DiagramBlock? pm, DiagramBlock? mm)
    {
        var lcRows = r.LoadCaseResults
            .OrderByDescending(lc => lc.PmmRatio)
            .Select(lc => new[]
            {
                lc.LoadCaseName,
                $"{lc.PuDisplay:0.##}", $"{lc.MuxDisplay:0.##}", $"{lc.MuyDisplay:0.##}",
                PmmAngleConvention.FormatMomentTheta(lc.GoverningMomentThetaDegrees),
                $"{lc.CapacityPDisplay:0.##}", $"{lc.CapacityMxDisplay:0.##}", $"{lc.CapacityMyDisplay:0.##}",
                $"{lc.PmmRatio:0.###}", lc.Status.ToString(),
            }).ToArray();

        var blocks = new List<ReportBlock>
        {
            new TableBlock(
                ["Property", "Nominal  Rn", "Design  Rd = Rn/γ"],
                [
                    [$"Axial   NRd ({fUnit})", $"{r.NominalPnDisplay:0.##}", $"{r.DesignPnDisplay:0.##}"],
                    [$"MRd,x   ({mUnit})",     $"{r.NominalMxDisplay:0.##}", $"{r.DesignMxDisplay:0.##}"],
                    [$"MRd,y   ({mUnit})",     $"{r.NominalMyDisplay:0.##}", $"{r.DesignMyDisplay:0.##}"],
                ]),

            new TableBlock(
                ["Property", "Value"],
                [
                    [$"NEd ({fUnit})",     $"{r.PuDisplay:0.##}"],
                    [$"MEd,x ({mUnit})",   $"{r.MuxDisplay:0.##}"],
                    [$"MEd,y ({mUnit})",   $"{r.MuyDisplay:0.##}"],
                    // Report output uses the shared user-facing moment theta from the calculation result.
                    ["Governing θ",        PmmAngleConvention.FormatMomentTheta(r.GoverningMomentThetaDegrees)],
                    ["Utilization UR",     $"{r.Ratio:0.###}"],
                ]),

            new TableBlock(
                ["Load Case", "NEd", "MEd,x", "MEd,y", "Theta", "NRd", "MRd,x", "MRd,y", "UR", "Status"],
                lcRows),
        };

        if (pm is not null) blocks.Add(pm);
        if (mm is not null) blocks.Add(mm);

        return new("5.1", "PMM Interaction — Details", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5.2 · Shear Details  (EC2 §6.2)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S52_ShearDetails(CalculationResultDto r, string fUnit)
    {
        var blocks = new List<ReportBlock>();
        var s = r.GoverningShearResult;
        if (s is null)
        {
            blocks.Add(new NoteBlock("Shear check could not be computed for this configuration."));
            return new("5.2", "Shear Check - Details (EC2 6.2)", blocks);
        }

        if (!s.HasDemand)
        {
            blocks.Add(new NoteBlock(
                "No shear demand was entered for the active load cases (VEd,x = VEd,y = 0). " +
                "Shear capacities are shown for reference only."));
        }

        var shearRows = r.LoadCaseResults
            .Where(lc => lc.ShearResult is not null)
            .Select(lc =>
            {
                var sh = lc.ShearResult!;
                return new[]
                {
                    lc.LoadCaseName,
                    $"{sh.VEdXDisplay:0.##}",
                    $"{sh.VRdXDisplay:0.##}",
                    $"{sh.UtilisationX:0.###}",
                    sh.StatusX.ToString(),
                    $"{sh.VEdYDisplay:0.##}",
                    $"{sh.VRdYDisplay:0.##}",
                    $"{sh.UtilisationY:0.###}",
                    sh.StatusY.ToString(),
                };
            })
            .ToArray();

        if (shearRows.Length > 0)
        {
            blocks.Add(new TableBlock(
                ["Load Case", $"VEd,x ({fUnit})", $"VRd,x ({fUnit})", "URx", "X Status", $"VEd,y ({fUnit})", $"VRd,y ({fUnit})", "URy", "Y Status"],
                shearRows));
        }

        blocks.Add(new Ec2ShearDetailBlock(s, fUnit));

        return new("5.2", "Shear Check - Details (EC2 6.2)", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 6 · Code Compliance Check  (EC2 §9.5)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S6_Compliance(RebarComplianceResult c)
    {
        var rows = c.Checks
            .Select(ch => new[] { ch.Reference, ch.Description, ch.Requirement,
                                   ch.Provided, ch.Limit, ch.Pass ? "✓ Pass" : "✗ Fail" })
            .ToArray();

        return new("6", "Code Compliance Check  (EC2 §9.5)",
        [
            new SummaryBoxBlock(
                c.AllPass ? "All compliance checks PASS"
                          : $"{c.FailCount} compliance check(s) FAIL",
                c.AllPass ? "Pass" : "Fail",
                c.AllPass),

            new TableBlock(
                ["Reference", "Description", "Requirement", "Provided", "Limit", "Result"],
                rows),
        ]);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 7 · Conclusion
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S7_Conclusion(CalculationResultDto r)
    {
        bool pass = r.Ratio <= 1.0;
        return new("7", "Conclusion",
        [
            new ParagraphBlock(
                pass
                ? $"The column section satisfies the EC2 PMM interaction check. " +
                  $"Governing UR = {r.Ratio:0.###} ≤ 1.0  ({r.Status})."
                : $"The column section FAILS the EC2 PMM interaction check. " +
                  $"Governing UR = {r.Ratio:0.###} > 1.0  ({r.Status}). Section redesign is required."),
            new NoteBlock(
                "This report was generated automatically by MBColumn. " +
                "All inputs and results must be independently verified by a qualified " +
                "structural engineer before use in design."),
        ]);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Annex A · Rebar and Section Boundary Coordinates
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection AnnexA_Coordinates(CalculationResultDto r)
    {
        var blocks = new List<ReportBlock>();

        if (r.RebarCoordinates.Count > 0)
        {
            blocks.Add(new NoteBlock(
                $"Coordinates from section centroid. Positive X rightward, positive Y upward. " +
                $"Total: {r.RebarCoordinates.Count} bars,  As = {r.RebarCoordinates.Sum(b => b.Area):0.#} mm²."));

            blocks.Add(new TableBlock(
                ["#", "Bar", "X (mm)", "Y (mm)", "d (mm)", "As (mm²)", "Side"],
                r.RebarCoordinates
                    .Select((b, i) => new[]
                    {
                        (i + 1).ToString(), b.BarSizeLabel,
                        $"{b.X:0.##}", $"{b.Y:0.##}",
                        $"{b.Diameter:0.#}", $"{b.Area:0.#}", b.SourceSide,
                    }).ToArray()));
        }

        if (r.SectionShape == SectionShapeType.Irregular
            && r.IrregularSectionBoundaryPoints.Count > 0)
        {
            blocks.Add(new TableBlock(
                ["#", "X (mm)", "Y (mm)"],
                r.IrregularSectionBoundaryPoints
                    .Select((p, i) => new[] { (i + 1).ToString(), $"{p.X:0.##}", $"{p.Y:0.##}" })
                    .ToArray()));
        }

        if (blocks.Count == 0)
            blocks.Add(new NoteBlock("No coordinate data available for this section."));

        return new("Annex A", "Rebar and Section Boundary Coordinates", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Annex C · Hand-Calculation Verification  (rectangular sections, EC2)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection AnnexC_HandCalc(HandCalcValidationReport report)
    {
        var blocks = new List<ReportBlock>
        {
            new NoteBlock(report.DesignCodeNote),
            new NoteBlock($"Axis convention: {report.AxisConvention}"),
            new NoteBlock($"Sign convention:  {report.SignConvention}"),
        };

        string fLbl = report.Rows.FirstOrDefault()?.ForceUnitLabel  ?? "kN";
        string mLbl = report.Rows.FirstOrDefault()?.MomentUnitLabel ?? "kN·m";

        blocks.Add(new TableBlock(
            ["CP", "Name",
             $"Hand  P ({fLbl})", $"Hand  M ({mLbl})",
             $"Solver P ({fLbl})", $"Solver M ({mLbl})",
             "ΔP (%)", "ΔM (%)", "Status"],
            report.Rows.Select(row => new[]
            {
                row.ControlPointId, row.ControlPointName,
                $"{row.HandPnDisplay:0.##}", $"{row.HandMxDisplay:0.##}",
                $"{row.SolverPnDisplay:0.##}", $"{row.SolverMxDisplay:0.##}",
                $"{row.DifferencePPercent:0.#}%", $"{row.DifferenceMPercent:0.#}%",
                row.Status,
            }).ToArray()));

        foreach (var row in report.Rows.Where(row => row.IsSupported))
        {
            blocks.Add(new HeadingBlock($"{row.ControlPointId}  —  {row.ControlPointName}", 3));
            blocks.Add(new ParagraphBlock(row.Assumption));
            foreach (var fb in row.FormulaBlocks)
                blocks.Add(new FormulaBlock(fb.Title, fb.LatexFormula, fb.SubstitutionLatex, fb.ResultLatex));
        }

        if (!string.IsNullOrWhiteSpace(report.ComparisonNote))
            blocks.Add(new NoteBlock(report.ComparisonNote));

        return new("Annex C", "Hand-Calculation Verification  (EC2 — rectangular sections)", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Helpers
    // ─────────────────────────────────────────────────────────────────────────

    private static string Dash(string? s) => string.IsNullOrWhiteSpace(s) ? "—" : s;

    private static double PolygonArea(IReadOnlyList<InsetPointDto> points)
    {
        if (points.Count < 3)
            return 0.0;

        double sum = 0.0;
        for (int i = 0; i < points.Count; i++)
        {
            var a = points[i];
            var b = points[(i + 1) % points.Count];
            sum += a.X * b.Y - b.X * a.Y;
        }

        return Math.Abs(sum) * 0.5;
    }
}
