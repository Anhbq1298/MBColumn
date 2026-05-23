using System.Globalization;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Independently calculates selected PMM control points using transparent hand-calculation
/// formulas (ACI 318 rectangular stress block) and compares results against the solver surface.
/// Only supports ACI 318 with rectangular sections.
/// </summary>
public static class ReportHandCalcService
{
    private const double PassTolP = 1.5;   // % – axial
    private const double WarnTolP = 3.5;
    private const double PassTolM = 3.0;   // % – moment
    private const double WarnTolM = 6.0;

    public static HandCalcValidationReport Build(
        SectionShapeType shape,
        double bMm,
        double hMm,
        double fcMpa,
        double fyMpa,
        double esMpa,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? solverTable,
        IDesignCodeService codeService,
        IUnitConversionService units,
        UnitSystem unitSystem,
        DesignCodeType designCode)
    {
        if (shape != SectionShapeType.Rectangular)
            return HandCalcValidationReport.NotSupported(
                "Hand calculation validation is available for rectangular sections only.");

        if (designCode != DesignCodeType.Aci318Style)
            return HandCalcValidationReport.NotSupported(
                "Hand calculation validation is currently implemented for ACI 318 only.");

        if (bars.Count == 0)
            return HandCalcValidationReport.NotSupported(
                "No rebar coordinates available for validation.");

        var fu = unitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip;
        var mu = unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;
        string fLabel = unitSystem == UnitSystem.Metric ? "kN" : "kip";
        string mLabel = unitSystem == UnitSystem.Metric ? "kN·m" : "kip·ft";

        var rows = new List<ControlPointValidationRow>
        {
            CalcPureAxialCompression(bMm, hMm, fcMpa, fyMpa, bars, solverTable, codeService, units, fu, fLabel, mLabel),
            CalcBalancedPoint(bMm, hMm, fcMpa, fyMpa, esMpa, bars, solverTable, codeService, units, fu, mu, fLabel, mLabel),
            CalcTensionControlledPoint(bMm, hMm, fcMpa, fyMpa, esMpa, bars, solverTable, codeService, units, fu, mu, fLabel, mLabel),
            CalcPureBending(bMm, hMm, fcMpa, fyMpa, esMpa, bars, solverTable, codeService, units, fu, mu, fLabel, mLabel),
            CalcPureTension(fyMpa, bars, solverTable, codeService, units, fu, fLabel, mLabel),
        };

        return new HandCalcValidationReport(
            IsSupported: true,
            NotSupportedReason: "",
            AxisConvention:
                "X-axis bending: compression at the +Y face (top of section). " +
                "Y measured from section centroid, positive upward.",
            SignConvention:
                "Compression forces and strains: positive. " +
                "Tensile forces and strains: negative.",
            DesignCodeNote:
                "ACI 318 — tied column (α = 0.80, φₙ = 0.65, " +
                "φₜ = 0.90). Whitney equivalent rectangular stress block.",
            Rows: rows);
    }

    // -----------------------------------------------------------------------
    // CP-01  Pure Axial Compression
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureAxialCompression(
        double b, double h, double fc, double fy,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, string fLabel, string mLabel)
    {
        double Ag  = b * h;
        double Ast = bars.Sum(r => r.Area);
        double P0  = 0.85 * fc * (Ag - Ast) + fy * Ast;   // nominal (N)
        double PnMax = code.NominalCompressionLimit(P0);    // 0.80 × P0 (N)
        double phi = 0.65;                                   // ACI compression-controlled
        double PhiPnMax = phi * PnMax;                       // design limit (N)

        double P0disp      = units.ForceFromN(P0, fu);
        double PhiPnDisplay = units.ForceFromN(PhiPnMax, fu);

        // Solver comparison: "Allowable comp." row, X axis = design compression limit
        var solverRow = FindRow(table, "X", "Allowable comp.");
        double solverP = solverRow?.P ?? 0;

        var (diffP, _, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisplay, 0, solverP, 0, compareM: false);

        string beta1s = F(code.Beta1(fc), 4);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Gross concrete area",
                @"A_g = b \times h",
                $$"""A_g = {{F(b,0)}} \times {{F(h,0)}}""",
                $$"""A_g = {{F(Ag,0)}}\ \mathrm{mm^2}"""),

            new("Total steel area",
                @"A_{st} = \sum A_{si}",
                $$"""{{bars.Count}}\ \text{bars}""",
                $$"""A_{st} = {{F(Ast,1)}}\ \mathrm{mm^2}"""),

            new("Nominal pure axial compression  (ACI 318 §22.4.2.2)",
                @"P_0 = 0.85 f'_c (A_g - A_{st}) + f_y A_{st}",
                $$"""P_0 = 0.85 \times {{F(fc,1)}} \times ({{F(Ag,0)}} - {{F(Ast,0)}}) + {{F(fy,1)}} \times {{F(Ast,0)}}""",
                $$"""P_0 = {{F(P0/1000,1)}}\ \mathrm{kN}"""),

            new("Design maximum compression  (ACI tied column α = 0.80, φ = 0.65)",
                @"\phi P_{n,max} = \phi \cdot 0.80 \cdot P_0",
                $$"""\phi P_{n,max} = 0.65 \times 0.80 \times {{F(P0/1000,1)}}""",
                $$"""\phi P_{n,max} = {{F(PhiPnMax/1000,1)}}\ \mathrm{kN}"""),
        };

        return new ControlPointValidationRow(
            "CP-01", "Pure Axial Compression",
            "Full section in uniform compression. Concrete and all steel bars resist compression. " +
            "ACI tied column axial capacity limit α = 0.80 applies.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisplay, HandMxDisplay: 0, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: 0, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: 0,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-02  Balanced Point (X-axis bending, compression at +Y face)
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcBalancedPoint(
        double b, double h, double fc, double fy, double Es,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel)
    {
        double ecu  = code.ConcreteUltimateStrain(fc);   // 0.003
        double ey   = fy / Es;
        double dt   = h / 2.0 - bars.Min(r => r.Y);     // dist from comp. face to extreme tension bar
        double beta1 = code.Beta1(fc);
        double cb   = ecu * dt / (ecu + ey);
        double ab   = Math.Min(beta1 * cb, h);
        double Cc   = 0.85 * fc * b * ab;               // N

        var (Pn, Mn) = CalcPnMn(b, h, fc, fy, Es, bars, cb, beta1, ecu);
        double et   = TensileStrain(ecu, cb, dt);        // positive = tensile
        double phi  = code.Phi(et, fy, Es);

        double PhiPn = phi * Pn;
        double PhiMn = phi * Mn;

        double PhiPnDisp = units.ForceFromN(PhiPn, fu);
        double PhiMnDisp = units.MomentFromNmm(PhiMn, mu);

        var solverRow = FindRow(table, "X", "Balanced point");
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;

        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Steel yield strain",
                @"\varepsilon_y = f_y / E_s",
                $$"""\varepsilon_y = {{F(fy,1)}} / {{F(Es,0)}}""",
                $$"""\varepsilon_y = {{F(ey,5)}}"""),

            new("Concrete ultimate strain  (ACI 318 §22.2.2.1)",
                @"\varepsilon_{cu} = 0.003",
                @"\varepsilon_{cu} = 0.003", ""),

            new("Extreme tension bar depth from compression face",
                @"d_t = h/2 - y_{min}",
                $$"""d_t = {{F(h/2,1)}} - ({{F(bars.Min(r=>r.Y),1)}})""",
                $$"""d_t = {{F(dt,1)}}\ \mathrm{mm}"""),

            new("Balanced neutral axis depth",
                @"c_b = \frac{\varepsilon_{cu} \cdot d_t}{\varepsilon_{cu} + \varepsilon_y}",
                $$"""c_b = \frac{0.003 \times {{F(dt,1)}}}{0.003 + {{F(ey,5)}} }""",
                $$"""c_b = {{F(cb,1)}}\ \mathrm{mm}"""),

            new("Equivalent stress block depth  (β₁)",
                @"a_b = \beta_1 c_b",
                $$"""a_b = {{F(beta1,4)}} \times {{F(cb,1)}}""",
                $$"""a_b = {{F(ab,1)}}\ \mathrm{mm}"""),

            new("Concrete compression force",
                @"C_c = 0.85 f'_c \cdot b \cdot a_b",
                $$"""C_c = 0.85 \times {{F(fc,1)}} \times {{F(b,0)}} \times {{F(ab,1)}}""",
                $$"""C_c = {{F(Cc/1000,1)}}\ \mathrm{kN}"""),

            new("Nominal axial capacity at balanced NA",
                @"P_n = C_c + \sum A_{si} f_{si},\quad f_{si} = \mathrm{clamp}(E_s \varepsilon_{si},\,-f_y,\,f_y)",
                $$"""P_n = {{F(Cc/1000,1)}} + \sum A_i f_{si}""",
                $$"""P_n = {{F(Pn/1000,1)}}\ \mathrm{kN}"""),

            new("Nominal moment capacity about X at balanced NA",
                @"M_{nx} = C_c \!\left(\tfrac{h}{2} - \tfrac{a_b}{2}\right) + \sum A_{si} f_{si} y_i",
                $$"""M_{nx} = {{F(Cc/1000,1)}} \times {{F(h/2-ab/2,1)}} + \sum A_i f_i y_i""",
                $$"""M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN \cdot m}"""),

            new($"Strength reduction factor  (φ at ε_t = {F(et,4)})",
                @"\phi = \phi(\varepsilon_t)",
                $$"""\varepsilon_t = {{F(et,4)}},\quad \phi = {{F(phi,3)}}""",
                $$"""\phi P_n = {{F(PhiPn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(PhiMn/1e6,1)}}\ \mathrm{kN \cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-02", "Balanced Point (X-axis bending)",
            "Neutral axis depth where the extreme tension bar just reaches yield strain (ε_s = ε_y) " +
            "simultaneously with concrete reaching ε_cu at the compression face.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-03  Tension-Controlled Point
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcTensionControlledPoint(
        double b, double h, double fc, double fy, double Es,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel)
    {
        double ecu  = code.ConcreteUltimateStrain(fc);
        double ey   = fy / Es;
        double et_tc = ey + 0.003;                        // ACI tension-controlled boundary
        double dt   = h / 2.0 - bars.Min(r => r.Y);
        double beta1 = code.Beta1(fc);
        double ct   = ecu * dt / (ecu + et_tc);
        double at   = Math.Min(beta1 * ct, h);

        var (Pn, Mn) = CalcPnMn(b, h, fc, fy, Es, bars, ct, beta1, ecu);
        double et   = TensileStrain(ecu, ct, dt);
        double phi  = code.Phi(et, fy, Es);               // should be 0.90

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", "Tension control");
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;

        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Tension-controlled strain limit  (ACI 318 §21.2.2)",
                @"\varepsilon_t = \varepsilon_y + 0.003",
                $$"""\varepsilon_t = {{F(ey,5)}} + 0.003""",
                $$"""\varepsilon_t = {{F(et_tc,5)}}"""),

            new("Neutral axis depth at tension-controlled boundary",
                @"c_t = \frac{\varepsilon_{cu} \cdot d_t}{\varepsilon_{cu} + \varepsilon_t}",
                $$"""c_t = \frac{0.003 \times {{F(dt,1)}}}{0.003 + {{F(et_tc,5)}}}""",
                $$"""c_t = {{F(ct,1)}}\ \mathrm{mm}"""),

            new("Stress block depth",
                @"a_t = \beta_1 c_t",
                $$"""a_t = {{F(beta1,4)}} \times {{F(ct,1)}}""",
                $$"""a_t = {{F(at,1)}}\ \mathrm{mm}"""),

            new("Design capacities at tension-controlled point  (φ = 0.90)",
                @"\phi P_n,\quad \phi M_{nx}",
                $$"""\phi = {{F(phi,2)}},\quad P_n = {{F(Pn/1000,1)}}\ \mathrm{kN},\quad M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN\cdot m}""",
                $$"""\phi P_n = {{F(phi*Pn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN\cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-03", "Tension-Controlled Point (X-axis bending)",
            "Neutral axis depth where the extreme tension bar strain equals ε_y + 0.003 " +
            "(ACI boundary for φ = 0.90). " +
            "This represents the transition to fully tension-controlled behaviour.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-04  Pure Bending (Pn ≈ 0)
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureBending(
        double b, double h, double fc, double fy, double Es,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel)
    {
        double ecu  = code.ConcreteUltimateStrain(fc);
        double beta1 = code.Beta1(fc);

        // Bisection: find c where Pn(c) = 0
        const double tolN = 0.1;   // 0.1 N tolerance
        double cLow = 1e-3;
        double cHigh = h;
        double c = (cLow + cHigh) / 2.0;

        for (int i = 0; i < 120; i++)
        {
            var (Pn_mid, _) = CalcPnMn(b, h, fc, fy, Es, bars, c, beta1, ecu);
            if (Math.Abs(Pn_mid) < tolN) break;
            if (Pn_mid > 0) cHigh = c; else cLow = c;
            c = (cLow + cHigh) / 2.0;
        }

        double dt   = h / 2.0 - bars.Min(r => r.Y);
        var (Pn, Mn) = CalcPnMn(b, h, fc, fy, Es, bars, c, beta1, ecu);
        double et   = TensileStrain(ecu, c, dt);
        double phi  = code.Phi(et, fy, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", "Pure bending");
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;

        // For pure bending, Pn ≈ 0, compare only moment
        var (_, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Find NA depth c where net axial = 0  (bisection)",
                @"\left| P_n(c) \right| \leq \varepsilon_P \approx 0",
                $$"""c\ \text{solved by bisection in}\ [0,\,h],\quad \varepsilon_P = 0.1\ \mathrm{N}""",
                $$"""c = {{F(c,2)}}\ \mathrm{mm}"""),

            new("Moment capacity at pure bending NA",
                @"M_{nx}(c) = C_c \!\left(\tfrac{h}{2}-\tfrac{a}{2}\right) + \sum A_{si} f_{si} y_i",
                $$"""a = \beta_1 c = {{F(beta1,4)}} \times {{F(c,2)}} = {{F(beta1*c,2)}}\ \mathrm{mm}""",
                $$"""M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN \cdot m}"""),

            new($"Design moment capacity  (φ = {F(phi,2)} at ε_t = {F(et,4)})",
                @"\phi M_{nx}",
                $$"""\phi = {{F(phi,2)}}""",
                $$"""\phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN \cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-04", "Pure Bending (X-axis, P ≈ 0)",
            "Neutral axis depth where net axial capacity is approximately zero. " +
            "Solved iteratively using bisection on P_n(c).",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: 0, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-05  Pure Tension
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureTension(
        double fy,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, string fLabel, string mLabel)
    {
        double Ast = bars.Sum(r => r.Area);
        double PnTen = -fy * Ast;              // N, negative = tension
        double phi  = 0.90;                    // ACI tension-controlled
        double PhiPn = phi * PnTen;

        double HandPDisp = units.ForceFromN(PhiPn, fu);

        var solverRow = FindRow(table, "X", "Max tension");
        double solverP = solverRow?.P ?? 0;

        var (diffP, _, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(HandPDisp, 0, solverP, 0, compareM: false);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Total steel area",
                @"A_{st} = \sum A_{si}",
                $$"""{{bars.Count}}\ \text{bars}""",
                $$"""A_{st} = {{F(Ast,1)}}\ \mathrm{mm^2}"""),

            new("Nominal pure tension (concrete neglected)",
                @"P_{n,ten} = -f_y A_{st}",
                $$"""P_{n,ten} = -{{F(fy,1)}} \times {{F(Ast,1)}}""",
                $$"""P_{n,ten} = {{F(PnTen/1000,1)}}\ \mathrm{kN}"""),

            new("Design pure tension  (φ = 0.90)",
                @"\phi P_{n,ten} = \phi \cdot P_{n,ten}",
                $$"""\phi P_{n,ten} = 0.90 \times {{F(PnTen/1000,1)}}""",
                $$"""\phi P_{n,ten} = {{F(PhiPn/1000,1)}}\ \mathrm{kN}"""),
        };

        return new ControlPointValidationRow(
            "CP-05", "Pure Tension",
            "All steel bars reach yield in tension. Concrete tensile strength is neglected.",
            IsSupported: true, blocks,
            HandPnDisplay: HandPDisp, HandMxDisplay: 0, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: 0, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: 0,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // Shared helpers
    // -----------------------------------------------------------------------

    /// <summary>
    /// Calculates Pn and Mnx (about X-axis, compression at +Y face) at a given NA depth c.
    /// All values in N and N·mm. Compression positive.
    /// </summary>
    private static (double Pn, double Mn) CalcPnMn(
        double b, double h, double fc, double fy, double Es,
        IReadOnlyList<RebarCoordinateDto> bars,
        double c, double beta1, double ecu)
    {
        double a  = Math.Min(beta1 * c, h);
        double Cc = 0.85 * fc * b * a;          // concrete block force (N, compression +)

        double Pn = Cc;
        double Mn = Cc * (h / 2.0 - a / 2.0);  // moment arm from centroid

        foreach (var bar in bars)
        {
            double di   = h / 2.0 - bar.Y;      // distance from compression face to bar
            double epsi = ecu * (c - di) / c;   // strain, compression positive
            double fsi  = Math.Clamp(Es * epsi, -fy, fy);
            Pn += bar.Area * fsi;
            Mn += bar.Area * fsi * bar.Y;        // bar.Y from centroid, positive up
        }

        return (Pn, Mn);
    }

    /// <summary>
    /// Tensile strain at the extreme tension bar (positive = tensile), for φ calculation.
    /// </summary>
    private static double TensileStrain(double ecu, double c, double dt)
        => ecu * (dt - c) / c;

    private static ControlPointTableRowDto? FindRow(ControlPointTableDto? table, string axis, string label)
        => table?.Rows.FirstOrDefault(r =>
            string.Equals(r.Axis, axis, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(r.PointLabel, label, StringComparison.OrdinalIgnoreCase));

    private static (double diffP, double diffM, string status) CalcDiff(
        double handP, double handM, double solverP, double solverM, bool compareM)
    {
        double diffP = Math.Abs(solverP - handP) / Math.Max(Math.Abs(handP), 0.01) * 100.0;
        double diffM = compareM
            ? Math.Abs(solverM - handM) / Math.Max(Math.Abs(handM), 0.01) * 100.0
            : 0.0;

        bool passP = diffP <= PassTolP;
        bool passM = !compareM || diffM <= PassTolM;
        bool warnP = diffP <= WarnTolP;
        bool warnM = !compareM || diffM <= WarnTolM;

        string status = (passP && passM)  ? "Pass"    :
                        (warnP && warnM)  ? "Warning" : "Fail";
        return (diffP, diffM, status);
    }

    private static string F(double v, int d = 1)
        => v.ToString($"F{d}", CultureInfo.InvariantCulture);
}
