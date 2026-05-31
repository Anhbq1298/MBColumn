using MBColumn.Application.DTOs;
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
        bool hasShear = r.GoverningShearResult is { HasDemand: true };
        bool hasSlend = r.IncludeEc2Slenderness && r.Ec2Slenderness.LoadCases.Count > 0;

        var sections = new List<ReportSection>
        {
            S1_ProjectInfo(projectName, groupName, designTierName, r),
            S2_Materials(r, code),
            S3_SectionProperties(r, sectionSvg),
            S4_DemandsAndSlenderness(r, fUnit, mUnit, isMetric, hasSlend),
            S5_ResultsSummary(r, fUnit, mUnit, hasShear),
            S51_PmmDetails(r, fUnit, mUnit, pmDiagram, mmDiagram),
        };

        if (hasShear)
            sections.Add(S52_ShearDetails(r.GoverningShearResult!, fUnit));

        if (r.RebarCompliance is not null)
            sections.Add(S6_Compliance(r.RebarCompliance));

        sections.Add(S7_Conclusion(r));

        // ── Annexes ───────────────────────────────────────────────────────────

        sections.Add(AnnexA_Coordinates(r));
        sections.Add(AnnexB_Theory());

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
            GeneratedAt    = DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
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
            new TableBlock("",
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
            new TableBlock("Table 2.1 – Concrete  (EC2 §3.1, Table 3.1)",
                ["Property", "Symbol", "Value"],
                [
                    ["Char. cylinder strength",        "fck",           $"{r.FcMpa:0.#} MPa"],
                    ["Mean cylinder strength",         "fcm = fck + 8", $"{r.FcMpa + 8:0.#} MPa"],
                    ["Secant modulus",                 "Ecm",           $"{ecm:0.#} MPa"],
                    ["Ultimate compressive strain",    "εcu2",          $"{ecu2:0.4f}"],
                    ["Strain at peak stress",          "εc2",           $"{ec2:0.4f}"],
                    ["Strength coeff.  (NA value)",    "αcc",           $"{r.AlphaCc:0.##}"],
                    ["Concrete partial factor",        "γc",            "1.50"],
                    ["Design strength  αcc·fck/γc",   "fcd",           $"{fcd:0.##} MPa"],
                    ["Effectiveness factor",           "η",             $"{eta:0.###}"],
                    ["Stress-block depth factor",      "λ",             $"{lambda:0.###}"],
                ]),

            new TableBlock("Table 2.2 – Reinforcing steel  (EC2 §3.2)",
                ["Property", "Symbol", "Value"],
                [
                    ["Char. yield strength",           "fyk",          $"{r.FyMpa:0.#} MPa"],
                    ["Elastic modulus",                "Es",           $"{r.EsMpa:0.#} MPa"],
                    ["Steel partial factor",           "γs",           "1.15"],
                    ["Design yield strength  fyk/γs", "fyd",          $"{fyd:0.##} MPa"],
                    ["Design yield strain    fyd/Es", "εyd",          $"{eyd:0.5f}"],
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
            blocks.Add(new ImageBlock(svg, "Figure 3.1 – Cross-section geometry"));

        string dims = r.SectionShape switch
        {
            SectionShapeType.Circular  => $"D = {r.DiameterMm:0.#} mm",
            SectionShapeType.Irregular => "Irregular cross-section",
            _                          => $"b = {r.SectionWidthMm:0.#} mm,  h = {r.SectionHeightMm:0.#} mm",
        };
        double ag  = r.SectionShape == SectionShapeType.Circular
                     ? Math.PI / 4 * r.DiameterMm * r.DiameterMm
                     : r.SectionWidthMm * r.SectionHeightMm;
        double ast = r.RebarCoordinates.Sum(b => b.Area);

        blocks.Add(new TableBlock("Table 3.1 – Geometry",
            ["Property", "Value"],
            [
                ["Shape",          r.SectionShape.ToString()],
                ["Dimensions",     dims],
                ["Clear cover",    $"{r.CoverMm:0.#} mm"],
                ["Gross area  Ac", $"{ag:0.#} mm²"],
            ]));

        blocks.Add(new TableBlock("Table 3.2 – Reinforcement",
            ["Property", "Value"],
            [
                ["Total bars",              r.RebarCoordinates.Count.ToString()],
                ["Total As",                $"{ast:0.#} mm²"],
                ["Ratio  ρ = As/Ac",        $"{ast / ag:0.4f}"],
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
            $"Table 4.1 – First-order demand cases  [{fUnit}, {mUnit}]",
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
            $"Table 4.2 – Design moments after EC2 §5.8 second-order amplification  [{fUnit}, {mUnit}]",
            ["Load Case", $"NEd ({fUnit})", $"MEd,x,used ({mUnit})", $"MEd,y,used ({mUnit})", "Slend. Status"],
            factored));

        // 4.3  Governing case detail
        var govLc = r.LoadCaseResults
            .Where(lc => double.IsFinite(lc.PmmRatio))
            .OrderByDescending(lc => lc.PmmRatio)
            .FirstOrDefault();

        if (govLc is not null)
        {
            var govSl = sl.LoadCases.FirstOrDefault(c => c.LoadCaseId == govLc.LoadCaseId);
            if (govSl is not null)
                blocks.AddRange(SlendernessDetail(govSl, sl, isMetric, mUnit, mScale));
        }

        return new("4", "Demand Cases & EC2 §5.8 Slenderness", blocks);
    }

    private static IEnumerable<ReportBlock> SlendernessDetail(
        Ec2SlendernessLoadCaseResultDto lc,
        Ec2SlendernessBatchResultDto batch,
        bool isMetric, string mUnit, double mScale)
    {
        yield return new HeadingBlock(
            $"EC2 §5.8 — Governing load case: {lc.CaseName}", 2);

        if (batch.SectionValues is { } sv)
            yield return new TableBlock("Table 4.3 – Stiffness properties for slenderness",
                ["Property", "Symbol", "Value"],
                [
                    ["Gross concrete area",   "Ac",  $"{sv.AcMm2:0.#} mm²"],
                    ["Second moment (X-axis)","Ic,xx",$"{sv.IxxMm4:0.3e} mm⁴"],
                    ["Second moment (Y-axis)","Ic,yy",$"{sv.IyyMm4:0.3e} mm⁴"],
                    ["Total steel area",      "As",  $"{sv.AsTotalMm2:0.#} mm²"],
                    ["Mech. reinf. ratio",    "ω",   $"{sv.Omega:0.4f}"],
                    ["Concrete modulus",      "Ecm", $"{sv.EcmMpa:0.#} MPa"],
                    ["Design concr. strength","fcd", $"{sv.FcdMpa:0.##} MPa"],
                ]);

        foreach (var (axis, ax) in new[] { ("X", lc.X), ("Y", lc.Y) })
        {
            if (ax is null) continue;
            double l0 = axis == "X" ? (batch.L0xMm ?? 0) : (batch.L0yMm ?? 0);
            int tblIdx = axis == "X" ? 4 : 5;

            yield return new TableBlock(
                $"Table 4.{tblIdx} – EC2 §5.8 slenderness detail — {axis}-axis bending",
                ["Parameter", "Symbol", "Value"],
                [
                    ["Effective length",                "L0",      $"{l0:0.#} mm"],
                    ["Slenderness ratio  L0/i",         "λ",       $"{ax.Lambda:0.#}"],
                    ["Slenderness limit  20·A·B·C/√n",  "λ_lim",  $"{ax.LambdaLimit:0.#}"],
                    ["Slender?",                        "",        ax.IsSlender ? "Yes — 2nd-order applied" : "No — 1st-order sufficient"],
                    ["Relative axial force  NEd/(Ac·fcd)","n",      $"{ax.FactorN:0.4f}"],
                    ["Factor A  (eff. creep)",           "A",      $"{ax.FactorA:0.4f}"],
                    ["Factor B  (reinf.)",               "B",      $"{ax.FactorB:0.4f}"],
                    ["Factor C  (moment shape)",         "C",      $"{ax.FactorC:0.4f}"],
                    ["Smaller first-order moment",       "M01",    $"{ax.M01Nmm * mScale:0.##} {mUnit}"],
                    ["Larger first-order moment",        "M02",    $"{ax.M02Nmm * mScale:0.##} {mUnit}"],
                    ["Moment ratio",                     "rm = M01/M02", $"{ax.Rm:0.3f}"],
                    ["Equivalent first-order moment",    "M0e",    $"{ax.M0eNmm * mScale:0.##} {mUnit}"],
                    ["Nominal curvature  (§5.8.8)",      "1/r",    $"{ax.NominalCurvature1PerMm:0.3e} mm⁻¹"],
                    ["Deflection  e2 = (1/r)·L0²/c",    "e2",     $"{ax.E2Mm:0.#} mm"],
                    ["Second-order moment  NEd · e2",    "M2",     $"{ax.M2Nmm * mScale:0.##} {mUnit}"],
                    ["Design moment used",               "MEd,used",$"{ax.MUsedNmm * mScale:0.##} {mUnit}"],
                ]);
        }

        foreach (var w in lc.Warnings)
            yield return new NoteBlock(w);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5 · Section Analysis Results — Summary
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S5_ResultsSummary(
        CalculationResultDto r, string fUnit, string mUnit, bool hasShear)
    {
        bool pmmPass  = r.Ratio <= 1.0;
        var  shear    = r.GoverningShearResult;
        bool shearPass = shear is null || shear.GoverningStatus == CapacityStatus.Pass;
        bool allPass  = pmmPass && shearPass;

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
                Math.Max(r.Ratio, shear?.GoverningUtilisation ?? 0),
                [
                    ("PMM  UR",      $"{r.Ratio:0.###}  →  {(pmmPass ? "Pass" : "Fail")}"),
                    .. (hasShear && shear is not null
                        ? new (string, string)[] { ("Shear  UR", $"{shear.GoverningUtilisation:0.###}  →  {(shearPass ? "Pass" : "Fail")}") }
                        : Array.Empty<(string, string)>()),
                ]),
            new TableBlock("Table 5.1 – Check summary",
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
                $"{lc.CapacityPDisplay:0.##}", $"{lc.CapacityMxDisplay:0.##}", $"{lc.CapacityMyDisplay:0.##}",
                $"{lc.PmmRatio:0.###}", lc.Status.ToString(),
            }).ToArray();

        var blocks = new List<ReportBlock>
        {
            new TableBlock("Table 5.1.1 – Governing section capacity",
                ["Property", "Nominal  Rn", "Design  Rd = Rn/γ"],
                [
                    [$"Axial   NRd ({fUnit})", $"{r.NominalPnDisplay:0.##}", $"{r.DesignPnDisplay:0.##}"],
                    [$"MRd,x   ({mUnit})",     $"{r.NominalMxDisplay:0.##}", $"{r.DesignMxDisplay:0.##}"],
                    [$"MRd,y   ({mUnit})",     $"{r.NominalMyDisplay:0.##}", $"{r.DesignMyDisplay:0.##}"],
                ]),

            new TableBlock("Table 5.1.2 – Governing demand",
                ["Property", "Value"],
                [
                    [$"NEd ({fUnit})",     $"{r.PuDisplay:0.##}"],
                    [$"MEd,x ({mUnit})",   $"{r.MuxDisplay:0.##}"],
                    [$"MEd,y ({mUnit})",   $"{r.MuyDisplay:0.##}"],
                    ["Governing θ",        $"{r.GoverningThetaDegrees:0.#}°"],
                    ["Utilization UR",     $"{r.Ratio:0.###}"],
                ]),

            new TableBlock($"Table 5.1.3 – PMM results per load case  [{fUnit}, {mUnit}]",
                ["Load Case", "NEd", "MEd,x", "MEd,y", "NRd", "MRd,x", "MRd,y", "UR", "Status"],
                lcRows),
        };

        if (pm is not null) blocks.Add(pm);
        if (mm is not null) blocks.Add(mm);

        return new("5.1", "PMM Interaction — Details", blocks);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // 5.2 · Shear Details  (EC2 §6.2)
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection S52_ShearDetails(ShearResultDto s, string fUnit)
    {
        var blocks = new List<ReportBlock>
        {
            new NoteBlock(
                "Shear capacity per EC2 §6.2. " +
                "VRdc = concrete contribution; VRds = link contribution; VRdmax = strut crushing limit."),

            new TableBlock($"Table 5.2.1 – Shear demand and capacity  [{fUnit}]",
                ["Dir", $"VEd ({fUnit})", $"VRdc ({fUnit})", $"VRds ({fUnit})", $"VRd,max ({fUnit})", $"VRd ({fUnit})", "UR", "Status"],
                [
                    ["X", $"{s.VEdXDisplay:0.##}", $"{s.VRdcXDisplay:0.##}", $"{s.VRdsXDisplay:0.##}",
                           $"{s.VRdMaxXDisplay:0.##}", $"{s.VRdXDisplay:0.##}", $"{s.UtilisationX:0.###}", s.StatusX.ToString()],
                    ["Y", $"{s.VEdYDisplay:0.##}", $"{s.VRdcYDisplay:0.##}", $"{s.VRdsYDisplay:0.##}",
                           $"{s.VRdMaxYDisplay:0.##}", $"{s.VRdYDisplay:0.##}", $"{s.UtilisationY:0.###}", s.StatusY.ToString()],
                ]),

            new TableBlock("Table 5.2.2 – Shear intermediate values  (EC2 §6.2.2, §6.2.3)",
                ["Parameter", "Symbol", "X-direction", "Y-direction"],
                [
                    ["Web width",                  "bw (mm)",  $"{s.BwXMm:0.#}",     $"{s.BwYMm:0.#}"],
                    ["Effective depth",             "deff (mm)",$"{s.DEffXMm:0.#}",    $"{s.DEffYMm:0.#}"],
                    ["Size factor  1+√(200/d)",    "k",        $"{s.KFactorX:0.###}",  $"{s.KFactorY:0.###}"],
                    ["Long. reinf. ratio",          "ρl",       $"{s.RhoLX:0.4f}",    $"{s.RhoLY:0.4f}"],
                    ["Axial stress",                "σcp (MPa)",$"{s.SigCpMpa:0.##}",  "—"],
                    ["Links required?",             "",         s.LinksRequiredX ? "Yes" : "No", s.LinksRequiredY ? "Yes" : "No"],
                ]),
        };

        if (s.HasLinks)
            blocks.Add(new TableBlock("Table 5.2.3 – Link design  (EC2 §6.2.3, §9.2.2)",
                ["Parameter", "Symbol", "X-direction", "Y-direction"],
                [
                    ["Inner lever arm",            "z (mm)",       $"{s.ZXMm:0.#}",   $"{s.ZYMm:0.#}"],
                    ["Strut inclination",           "cot θ",        $"{s.CotThetaX:0.###}", $"{s.CotThetaY:0.###}"],
                    ["Link design strength",        "fywd (MPa)",   $"{s.FywdMpa:0.#}", "—"],
                    ["Required Asw/s",              "mm²/mm",       $"{s.AswSX:0.###}", $"{s.AswSY:0.###}"],
                    ["Min Asw/s  (§9.2.2(5))",     "mm²/mm",       $"{s.AswSMinRequiredX:0.3f}", $"{s.AswSMinRequiredY:0.3f}"],
                    ["Min pass",                    "",             s.AswSMinPassX ? "✓" : "✗", s.AswSMinPassY ? "✓" : "✗"],
                ]));

        if (s.AnyStruttingCritical)
            blocks.Add(new NoteBlock(
                "CRITICAL: Strut crushing governs in one or both directions. " +
                "Adding more links will NOT resolve the failure. Increase the section size."));

        return new("5.2", "Shear — Details  (EC2 §6.2)", blocks);
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
                c.AllPass ? 0.0 : 1.5,
                [
                    ("Design code",   "EC2  EN 1992-1-1"),
                    ("Section shape", c.SectionShape.ToString()),
                    ("Total checks",  c.Checks.Count.ToString()),
                    ("Failures",      c.FailCount.ToString()),
                ]),

            new TableBlock("Table 6.1 – EC2 §9.5 reinforcement checks",
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

            blocks.Add(new TableBlock("Table A.1 – Rebar coordinates",
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
            blocks.Add(new TableBlock("Table A.2 – Irregular section boundary vertices",
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
    // Annex B · MB Column PMM Sweeping Theory
    // ─────────────────────────────────────────────────────────────────────────

    private static ReportSection AnnexB_Theory()
        => new("Annex B", "MB Column PMM Sweeping Theory",
        [
            new HeadingBlock("Overview", 2),
            new ParagraphBlock(
                "MB Column determines the three-dimensional P-M-M interaction surface by sweeping " +
                "the neutral axis orientation θ from 0° to 360° and, for each angle, iterating the " +
                "neutral axis depth c to trace the full interaction curve."),

            new HeadingBlock("Strain Compatibility", 2),
            new ParagraphBlock(
                "For a given neutral axis angle θ and depth c, the strain at any point (x, y) " +
                "in the cross-section is determined by a planar strain distribution pinned to " +
                "the ultimate concrete strain εcu2 at the extreme compression fibre."),

            new FormulaBlock("Strain at distance d from the neutral axis",
                @"\varepsilon(d) = \varepsilon_{cu2} \cdot \frac{c - d}{c}",
                @"\varepsilon_{cu2} = \text{EC2 Table 3.1, fck-dependent}",
                @"d = \text{perpendicular distance from neutral axis, positive towards compression}"),

            new HeadingBlock("Section Integration  (Fibre Method)", 2),
            new ParagraphBlock(
                "The concrete compression zone is discretized into a grid of fibres. Each fibre " +
                "contributes to the resultant forces through the EC2 parabolic-rectangular " +
                "stress-strain relationship."),

            new FormulaBlock("Internal forces",
                @"N_{Rd} = \int_{A_c} \sigma_c \, dA + \sum_i A_{si} \sigma_{si}",
                @"\sigma_c = f(\varepsilon_c)\ \text{per EC2 §3.1.7 parabolic-rectangular model}",
                @"\sigma_{si} = \operatorname{clamp}(E_s \varepsilon_{si},\,-f_{yd},\,f_{yd})"),

            new FormulaBlock("Bending moments about section centroid",
                @"M_{Rd,x} = \int_{A_c} \sigma_c \, y \, dA + \sum_i A_{si} \sigma_{si} \, y_i",
                @"M_{Rd,y} = \int_{A_c} \sigma_c \, x \, dA + \sum_i A_{si} \sigma_{si} \, x_i",
                ""),

            new HeadingBlock("EC2 Material Partial Factors", 2),
            new ParagraphBlock(
                "EC2 applies material partial factors to characteristic strengths rather than " +
                "a member-level φ factor. The design strengths fcd = αcc·fck/γc and " +
                "fyd = fyk/γs are used directly in the section analysis."),

            new FormulaBlock("Design concrete strength",
                @"f_{cd} = \frac{\alpha_{cc} \, f_{ck}}{\gamma_c}",
                @"\alpha_{cc} = \text{National Annex value (default 0.85)},\quad \gamma_c = 1.50",
                ""),

            new FormulaBlock("Design steel strength",
                @"f_{yd} = \frac{f_{yk}}{\gamma_s}",
                @"\gamma_s = 1.15",
                ""),

            new HeadingBlock("PMM Utilization Ratio", 2),
            new ParagraphBlock(
                "For each load case demand (NEd, MEd,x, MEd,y), the governing utilization ratio " +
                "is found by maximizing UR over all neutral axis orientations θ."),

            new FormulaBlock("Utilization ratio",
                @"\mathrm{UR} = \frac{\lVert (N_{Ed},\,M_{Ed,x},\,M_{Ed,y}) \rVert}{\lVert (N_{Rd},\,M_{Rd,x},\,M_{Rd,y}) \rVert}\Bigg|_{\theta = \theta_{gov}}",
                @"\mathrm{UR} \leq 1.0 \implies \text{section adequate}",
                ""),

            new NoteBlock(
                "The governing angle θ_gov is the neutral axis orientation that maximises UR. " +
                "The reported capacity (NRd, MRd,x, MRd,y) is the intersection of the " +
                "proportional loading ray with the design interaction surface."),
        ]);

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

        blocks.Add(new TableBlock("Table C.1 – Control point summary",
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
}
