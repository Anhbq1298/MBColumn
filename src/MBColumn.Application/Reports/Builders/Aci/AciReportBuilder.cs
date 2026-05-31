using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Reports.Builders.Aci;

/// <summary>
/// Builds the calculation report for the ACI 318 design code.
/// Sections marked [PLACEHOLDER] contain stub content pending full ACI implementation.
/// </summary>
internal sealed class AciReportBuilder
{
    internal ReportData Build(
        string projectName, string groupName, string designTierName,
        CalculationResultDto r,
        IDesignCodeService code,
        IUnitConversionService units,
        string? sectionSvg,
        DiagramBlock? pmDiagram, DiagramBlock? mmDiagram)
    {
        bool isMetric = r.UnitSystem == Domain.Enums.UnitSystem.Metric;
        string fUnit  = isMetric ? "kip" : "kip";
        string mUnit  = isMetric ? "kip-ft" : "kip-ft";
        bool hasShear = r.GoverningShearResult is { HasDemand: true };

        var sections = new List<ReportSection>
        {
            S1_ProjectInfo(projectName, groupName, designTierName, r),
            S2_Materials(r, code),
            S3_SectionProperties(r, sectionSvg),
            S4_Demands(r, fUnit, mUnit),
            S5_ResultsSummary(r, fUnit, mUnit, hasShear),
            S51_PmmDetails(r, fUnit, mUnit, pmDiagram, mmDiagram),
        };

        if (hasShear)
            sections.Add(S52_ShearPlaceholder(fUnit));

        if (r.RebarCompliance is not null)
            sections.Add(S6_CompliancePlaceholder(r.RebarCompliance));

        sections.Add(S7_Conclusion(r));

        // ── Annexes ───────────────────────────────────────────────────────────

        sections.Add(AnnexA_Coordinates(r));
        sections.Add(AnnexB_TheoryPlaceholder());

        var handCalc = ReportHandCalcService.Build(
            r.SectionShape, r.SectionWidthMm, r.SectionHeightMm,
            r.FcMpa, r.FyMpa, r.EsMpa, r.RebarCoordinates,
            r.ControlPointTable, code, units, r.UnitSystem, r.DesignCode);

        if (handCalc.IsSupported)
            sections.Add(AnnexC_HandCalc(handCalc));

        return new ReportData
        {
            ProjectName    = projectName,
            GroupName      = groupName,
            DesignTierName = designTierName,
            GeneratedAt    = DateTime.Now,
            Sections       = sections,
        };
    }

    private static NoteBlock Placeholder(string context)
        => new($"[PLACEHOLDER — ACI 318] {context}");

    private static string Dash(string? s) => string.IsNullOrWhiteSpace(s) ? "—" : s;

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
                    ["Design Code", "ACI 318-19"],
                    ["Unit System", r.UnitSystem.ToString()],
                    ["Integration", r.IntegrationMethod.ToString()],
                    ["Generated",   DateTime.Now.ToString("yyyy-MM-dd HH:mm")],
                ]),
        ]);

    // ─────────────────────────────────────────────────────────────────────────
    // 2 · Material Properties  (ACI 318)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S2_Materials(CalculationResultDto r, IDesignCodeService code)
    {
        double beta1 = code.Beta1(r.FcMpa);
        double ecu   = code.ConcreteUltimateStrain(r.FcMpa);
        double ecm   = 4700 * Math.Sqrt(r.FcMpa);   // ACI §19.2.2.1 (in MPa units)
        double ey    = r.FyMpa / r.EsMpa;

        return new("2", "Material Properties",
        [
            new TableBlock(
                ["Property", "Symbol", "Value"],
                [
                    ["Specified compressive strength",  "f'c",          $"{r.FcMpa:0.#} MPa"],
                    ["Modulus of elasticity",            "Ec = 4700√f'c",$"{ecm:0.#} MPa"],
                    ["Ultimate strain",                  "εcu = 0.003",  $"{ecu:F4}"],
                    ["Whitney block factor  (§22.2.2.4)","β1",          $"{beta1:F4}"],
                    ["Concrete block stress",            "0.85·f'c",     $"{0.85 * r.FcMpa:0.##} MPa"],
                ]),

            new TableBlock(
                ["Property", "Symbol", "Value"],
                [
                    ["Specified yield strength", "fy",           $"{r.FyMpa:0.#} MPa"],
                    ["Elastic modulus",           "Es = 200,000", $"{r.EsMpa:0.#} MPa"],
                    ["Yield strain",              "εy = fy/Es",   $"{ey:F5}"],
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
            Domain.Enums.SectionShapeType.Circular  => $"D = {r.DiameterMm:0.#} mm",
            Domain.Enums.SectionShapeType.Irregular => "Irregular cross-section",
            _                                        => $"b = {r.SectionWidthMm:0.#} mm,  h = {r.SectionHeightMm:0.#} mm",
        };
        double ag  = r.SectionShape == Domain.Enums.SectionShapeType.Circular
                     ? Math.PI / 4 * r.DiameterMm * r.DiameterMm
                     : r.SectionWidthMm * r.SectionHeightMm;
        double ast = r.RebarCoordinates.Sum(b => b.Area);

        blocks.Add(new TableBlock(
            ["Property", "Value"],
            [
                ["Shape",       r.SectionShape.ToString()],
                ["Dimensions",  dims],
                ["Clear cover", $"{r.CoverMm:0.#} mm"],
                ["Gross area Ag",$"{ag:0.#} mm²"],
            ]));

        blocks.Add(new TableBlock(
            ["Property", "Value"],
            [
                ["Total bars",                    r.RebarCoordinates.Count.ToString()],
                ["Total Ast",                     $"{ast:0.#} mm²"],
                ["ρg = Ast/Ag",                   $"{ast / ag:F4}"],
                ["Min ρg  (ACI §10.6.1.1)",       "0.01"],
                ["Max ρg  (ACI §10.6.1.1)",       "0.08"],
            ]));

        return new("3", "Section Properties", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 4 · Demand Cases  (ACI — no built-in slenderness module)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S4_Demands(
        CalculationResultDto r, string fUnit, string mUnit)
    {
        var rows = r.LoadCaseResults
            .OrderByDescending(lc => lc.PmmRatio)
            .Select(lc => new[]
            {
                lc.LoadCaseName,
                $"{lc.PuDisplay:0.##}", $"{lc.MuxDisplay:0.##}", $"{lc.MuyDisplay:0.##}",
                $"{lc.PmmRatio:0.###}", lc.Status.ToString(),
            }).ToArray();

        return new("4", "Demand Cases",
        [
            new TableBlock(
                ["Load Case", $"Pu ({fUnit})", $"Mux ({mUnit})", $"Muy ({mUnit})", "UR", "Status"],
                rows),

            Placeholder(
                "ACI 318 §6.6: Moment magnification for slenderness is not yet implemented. " +
                "For slender columns (klu/r > 40 for braced frames), " +
                "manually apply the δns or δs magnifier per ACI §6.6.4 before entering demand cases."),
        ]);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5 · Section Analysis Results — Summary
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S5_ResultsSummary(
        CalculationResultDto r, string fUnit, string mUnit, bool hasShear)
    {
        bool pmmPass  = r.Ratio <= 1.0;
        var  shear    = r.GoverningShearResult;
        bool shearPass = shear is null || shear.GoverningStatus == Domain.Enums.CapacityStatus.Pass;
        bool allPass  = pmmPass && (!hasShear || shearPass);

        var rows = new List<string[]>
        {
            new[] { "PMM Interaction", $"{r.Ratio:0.###}", pmmPass ? "✓ Pass" : "✗ Fail" },
        };
        if (hasShear && shear is not null)
            rows.Add(new[] { "Shear (governing)", $"{shear.GoverningUtilisation:0.###}",
                             shearPass ? "✓ Pass" : "✗ Fail" });

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
    // 5.1 · PMM Details  (ACI 318)
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
                $"{lc.CapacityPDisplay:0.##}", $"{lc.CapacityMxDisplay:0.##}", $"{lc.CapacityMyDisplay:0.##}",
                $"{lc.PmmRatio:0.###}", lc.Status.ToString(),
            }).ToArray();

        var blocks = new List<ReportBlock>
        {
            new TableBlock(
                ["Property", "Nominal  Rn", "Design  φRn"],
                [
                    [$"Axial   φPn ({fUnit})", $"{r.NominalPnDisplay:0.##}", $"{r.DesignPnDisplay:0.##}"],
                    [$"φMnx  ({mUnit})",        $"{r.NominalMxDisplay:0.##}", $"{r.DesignMxDisplay:0.##}"],
                    [$"φMny  ({mUnit})",        $"{r.NominalMyDisplay:0.##}", $"{r.DesignMyDisplay:0.##}"],
                ]),

            new TableBlock(
                ["Property", "Value"],
                [
                    [$"Pu ({fUnit})",     $"{r.PuDisplay:0.##}"],
                    [$"Mux ({mUnit})",    $"{r.MuxDisplay:0.##}"],
                    [$"Muy ({mUnit})",    $"{r.MuyDisplay:0.##}"],
                    ["φ (Phi)",           $"{r.Phi:0.###}"],
                    ["Governing θ",      $"{r.GoverningThetaDegrees:0.#}°"],
                    ["UR",               $"{r.Ratio:0.###}"],
                ]),

            new TableBlock(
                ["Load Case", "Pu", "Mux", "Muy", "φPn", "φMnx", "φMny", "UR", "Status"],
                lcRows),
        };

        if (pm is not null) blocks.Add(pm);
        if (mm is not null) blocks.Add(mm);

        return new("5.1", "PMM Interaction — Details", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5.2 · Shear  [PLACEHOLDER]
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S52_ShearPlaceholder(string fUnit)
        => new("5.2", "Shear — Details",
        [
            Placeholder(
                "ACI 318-19 §22.5 shear detailed report is not yet implemented. " +
                "Shear utilization ratio is computed by the solver. " +
                "Full ACI §22.5 breakdown (Vc, Vs, Vn, φVn tables and intermediate " +
                "values including ρw, Av/s, stirrup design) will be added in a future release."),
        ]);

    // ─────────────────────────────────────────────────────────────────────────
    // 6 · Code Compliance Check  [PLACEHOLDER]
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S6_CompliancePlaceholder(RebarComplianceResult c)
    {
        var rows = c.Checks
            .Select(ch => new[] { ch.Reference, ch.Description, ch.Requirement,
                                   ch.Provided, ch.Limit, ch.Pass ? "✓ Pass" : "✗ Fail" })
            .ToArray();

        return new("6", "Code Compliance Check  (ACI 318-19)",
        [
            Placeholder(
                "ACI 318-19 §10.6 / §25.7.2 compliance checks are partially implemented. " +
                "Items below are flagged by the solver; detailed ACI reference citations " +
                "and formulae will be expanded in a future release."),

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
                ? $"The column section satisfies the ACI 318-19 PMM interaction check. " +
                  $"Governing UR = {r.Ratio:0.###} ≤ 1.0  ({r.Status})."
                : $"The column section FAILS the ACI 318-19 PMM interaction check. " +
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
                $"Total: {r.RebarCoordinates.Count} bars,  Ast = {r.RebarCoordinates.Sum(b => b.Area):0.#} mm²."));

            blocks.Add(new TableBlock(
                ["#", "Bar", "X (mm)", "Y (mm)", "d (mm)", "Ast (mm²)", "Side"],
                r.RebarCoordinates
                    .Select((b, i) => new[]
                    {
                        (i + 1).ToString(), b.BarSizeLabel,
                        $"{b.X:0.##}", $"{b.Y:0.##}",
                        $"{b.Diameter:0.#}", $"{b.Area:0.#}", b.SourceSide,
                    }).ToArray()));
        }

        if (r.SectionShape == Domain.Enums.SectionShapeType.Irregular
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
    // Annex B · PMM Sweeping Theory  [PLACEHOLDER]
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection AnnexB_TheoryPlaceholder()
        => new("Annex B", "MB Column PMM Sweeping Theory",
        [
            Placeholder(
                "Full ACI 318 theory annex — including Whitney rectangular stress block " +
                "derivation, φ-factor transition diagram (ACI §21.2.2), and step-by-step " +
                "PMM sweep algorithm with ACI-specific notation — will be added in a future release."),

            new HeadingBlock("Overview", 2),
            new ParagraphBlock(
                "MB Column determines the three-dimensional P-M-M interaction surface by sweeping " +
                "the neutral axis orientation θ from 0° to 360° and iterating the neutral axis " +
                "depth c to trace the full interaction curve per ACI 318-19 §22.4."),

            new HeadingBlock("Whitney Rectangular Stress Block  (ACI 318-19 §22.2.2)", 2),
            new FormulaBlock("Equivalent rectangular stress block depth",
                @"a = \beta_1 \, c",
                @"\beta_1 = 0.85 - 0.05\,\frac{f'_c - 28}{7} \quad (0.65 \leq \beta_1 \leq 0.85)",
                ""),

            new FormulaBlock("Concrete compression resultant",
                @"C_c = 0.85\,f'_c \cdot b \cdot a",
                "", ""),

            new HeadingBlock("Strength Reduction Factor φ  (ACI 318-19 §21.2.2)", 2),
            new FormulaBlock("φ for combined axial and flexure (tied column)",
                @"\phi = \begin{cases} 0.65 & \varepsilon_t \leq \varepsilon_y \\ " +
                @"0.65 + 0.25\,\dfrac{\varepsilon_t - \varepsilon_y}{0.003} & \varepsilon_y < \varepsilon_t < \varepsilon_y + 0.003 \\ " +
                @"0.90 & \varepsilon_t \geq \varepsilon_y + 0.003 \end{cases}",
                "", ""),
        ]);

    // ─────────────────────────────────────────────────────────────────────────
    // Annex C · Hand-Calculation Verification  (ACI 318)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection AnnexC_HandCalc(HandCalcValidationReport report)
    {
        var blocks = new List<ReportBlock>
        {
            new NoteBlock(report.DesignCodeNote),
            new NoteBlock($"Axis convention: {report.AxisConvention}"),
            new NoteBlock($"Sign convention:  {report.SignConvention}"),
        };

        string fLbl = report.Rows.FirstOrDefault()?.ForceUnitLabel  ?? "kip";
        string mLbl = report.Rows.FirstOrDefault()?.MomentUnitLabel ?? "kip-ft";

        blocks.Add(new TableBlock(
            ["CP", "Name",
             $"Hand  P ({fLbl})", $"Hand  M ({mLbl})",
             $"Solver P ({fLbl})", $"Solver M ({mLbl})",
             "ΔP (%)", "ΔM (%)", "Status"],
            report.Rows.Select(row => new[]
            {
                row.ControlPointId, row.ControlPointName,
                $"{row.HandPnDisplay:F2}", $"{row.HandMxDisplay:F2}",
                $"{row.SolverPnDisplay:F2}", $"{row.SolverMxDisplay:F2}",
                $"{row.DifferencePPercent:F1}%", $"{row.DifferenceMPercent:F1}%",
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

        return new("Annex C", "Hand-Calculation Verification  (ACI 318 — rectangular sections)", blocks);
    }
}
