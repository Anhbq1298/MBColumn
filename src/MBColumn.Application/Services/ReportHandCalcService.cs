using System.Globalization;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Independently calculates selected PMM control points using transparent hand-calculation
/// formulas and compares results against the solver surface.
/// Supports ACI 318 (Whitney rectangular stress block) and EC2 (simplified rectangular block, λ/η).
/// Only rectangular sections are supported.
/// </summary>
public static class ReportHandCalcService
{
    private const double PassTolP = 1.5;
    private const double WarnTolP = 3.5;
    private const double PassTolM = 3.0;
    private const double WarnTolM = 6.0;

    // -----------------------------------------------------------------------
    // Public entry point
    // -----------------------------------------------------------------------
    public static HandCalcValidationReport Build(
        SectionShapeType shape,
        double bMm,
        double hMm,
        double fcMpa,
        double fyMpa,
        double esMpa,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? solverTable,
        IDesignCodeService code,
        IUnitConversionService units,
        UnitSystem unitSystem,
        DesignCodeType designCode)
    {
        if (shape != SectionShapeType.Rectangular)
            return HandCalcValidationReport.NotSupported(
                "Hand calculation validation is available for rectangular sections only.");

        if (bars.Count == 0)
            return HandCalcValidationReport.NotSupported(
                "No rebar coordinates available for validation.");

        bool isAci  = designCode == DesignCodeType.Aci318Style;
        double ecu  = code.ConcreteUltimateStrain(fcMpa);
        double beta1 = code.Beta1(fcMpa);
        double eta  = code.ConcreteEffectiveStrengthFactor(fcMpa);

        // Effective concrete block stress: 0.85·fc (ACI) or η·αcc·fc/γc (EC2)
        double fConc = code.ConcreteStressBlockFactor * fcMpa * eta;

        // Design steel strength: fy (ACI) or fy/γs (EC2)
        double fyd  = code.SteelDesignStrength(fyMpa);
        double eyd  = fyd / esMpa;   // yield strain using design strength

        // Tension-control strain limit: ey+0.003 (ACI §21.2.2) or εud (EC2 §3.2.7)
        double etLimit = isAci ? eyd + 0.003 : code.SteelMaxTensileStrain(fyMpa, esMpa);

        // Unit labels
        var fu = unitSystem == UnitSystem.Metric ? ForceUnit.kN   : ForceUnit.Kip;
        var mu = unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;
        string fLabel = unitSystem == UnitSystem.Metric ? "kN"    : "kip";
        string mLabel = unitSystem == UnitSystem.Metric ? "kNm"   : "kip-ft";

        // LaTeX notation strings differ by code
        string fcdL  = isAci ? @"0.85 f'_c"       : @"\eta f_{cd}";
        string fydL  = isAci ? @"f_y"              : @"f_{yd}";
        string ecuL  = isAci ? @"\varepsilon_{cu}" : @"\varepsilon_{cu2}";
        string beta1L = isAci ? @"\beta_1"          : @"\lambda";
        string etLimitL = isAci
            ? $@"\varepsilon_y + 0.003"
            : $@"\varepsilon_{{ud}} = {F(etLimit, 4)}";

        string lblComp   = isAci ? "Max Compression" : "A";
        string lblZeroT  = isAci ? "Zero Tension"    : "ZeroTension"; // Matching the solver label from SpecialCapacityPointsService
        string lblHalfY  = isAci ? "50% Yield"       : "HalfYield";
        string lblBal    = isAci ? "Balanced"        : "D";
        string lblTc     = isAci ? "Tension Control" : "E";
        string lblPb     = isAci ? "Pure Bending"    : "F";
        string lblMaxTen = isAci ? "Max Tension"     : "G";

        var rows = new List<ControlPointValidationRow>
        {
            CalcPureAxialCompression(
                bMm, hMm, fcMpa, fyMpa, fyd, fConc, eta,
                bars, solverTable, code, units,
                fu, fLabel, mLabel, lblComp, isAci, fcdL, fydL),

            CalcZeroTensionPoint(
                bMm, hMm, fyd, esMpa, fConc, ecu, beta1, eyd,
                bars, solverTable, code, units,
                fu, mu, fLabel, mLabel, lblZeroT, ecuL, beta1L, fcdL, fydL),

            CalcHalfYieldPoint(
                bMm, hMm, fyd, esMpa, fConc, ecu, beta1, eyd,
                bars, solverTable, code, units,
                fu, mu, fLabel, mLabel, lblHalfY, ecuL, beta1L, fcdL, fydL),

            CalcBalancedPoint(
                bMm, hMm, fyd, esMpa, fConc, ecu, beta1, eyd,
                bars, solverTable, code, units,
                fu, mu, fLabel, mLabel, lblBal, ecuL, beta1L, fcdL, fydL),

            CalcTensionControlled(
                bMm, hMm, fyd, esMpa, fConc, ecu, beta1, eyd, etLimit,
                bars, solverTable, code, units,
                fu, mu, fLabel, mLabel, lblTc, isAci, ecuL, beta1L, etLimitL, fcdL, fydL),

            CalcPureBending(
                bMm, hMm, fyd, esMpa, fConc, ecu, beta1,
                bars, solverTable, code, units,
                fu, mu, fLabel, mLabel, lblPb, ecuL, beta1L, fcdL, fydL),

            CalcPureTension(
                fyd, bars, solverTable, code, units,
                fu, fLabel, mLabel, lblMaxTen, isAci, fydL),
        };

        // Code-specific metadata
        string designCodeNote, comparisonNote;
        if (isAci)
        {
            designCodeNote =
                "ACI 318 — tied column (α = 0.80, φₙ = 0.65, φₜ = 0.90). " +
                "Whitney equivalent rectangular stress block (0.85f'c).";
            comparisonNote =
                "Hand calculations use the Whitney rectangular stress block. " +
                "The solver uses Hognestad parabolic fiber integration. " +
                "Differences of 1–5 % at balanced / tension-controlled points are expected.";
        }
        else
        {
            double alphaCc = code.AlphaCc;
            designCodeNote =
                $"EC2 (EN 1992-1-1) — αcc = {alphaCc:0.##}, γc = 1.50, γs = 1.15, " +
                $"λ = {beta1:0.###}, η = {eta:0.###}. Simplified rectangular stress block.";
            comparisonNote =
                "Hand calculations use the EC2 simplified rectangular stress block (η·fcd, λ). " +
                "The solver uses parabolic-rectangular fiber integration per EN 1992. " +
                "Differences ≤ 3 % are expected.";
        }

        return new HandCalcValidationReport(
            IsSupported: true,
            NotSupportedReason: "",
            AxisConvention:
                "X-axis bending: compression at the +Y face (top of section). " +
                "Y measured from section centroid, positive upward.",
            SignConvention:
                "Compression forces and strains: positive. " +
                "Tensile forces and strains: negative.",
            DesignCodeNote: designCodeNote,
            Rows: rows)
        { ComparisonNote = comparisonNote };
    }

    // -----------------------------------------------------------------------
    // CP-01  Pure Axial Compression
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureAxialCompression(
        double b, double h, double fc, double fy, double fyd, double fConc, double eta,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, string fLabel, string mLabel,
        string solverLabel, bool isAci, string fcdL, string fydL)
    {
        double Ag  = b * h;
        double Ast = bars.Sum(r => r.Area);

        // Nominal pure axial: concrete (net) + steel
        double P0 = fConc * (Ag - Ast) + fyd * Ast;

        // ACI: apply 0.80 tied-column cap and φ = 0.65
        // EC2: no cap, φ = 1.0
        double PnMax   = code.NominalCompressionLimit(P0);   // 0.80×P0 for ACI, P0 for EC2
        double phi     = isAci ? 0.65 : 1.0;
        double PhiPnMax = phi * PnMax;

        double HandPDisp = units.ForceFromN(PhiPnMax, fu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P ?? 0;
        var (diffP, _, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(HandPDisp, 0, solverP, 0, compareM: false);

        // Build formula blocks (ACI vs EC2 differ only in stress/strength notation)
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
        };

        if (!isAci)
        {
            double alphaCc = code.AlphaCc;
            double fcd = alphaCc * fc / 1.5;
            blocks.Add(new("Design concrete strength  (EC2 §3.1.6, Table 2.1N)",
                @"f_{cd} = \alpha_{cc} f_{ck} / \gamma_c",
                $$"""f_{cd} = {{F(alphaCc,2)}} \times {{F(fc,1)}} / 1.50""",
                $$"""f_{cd} = {{F(fcd,2)}}\ \mathrm{MPa}"""));

            blocks.Add(new($"Effectiveness factor  η = {F(eta,3)}",
                @"\eta f_{cd} = \eta \cdot \alpha_{cc} f_{ck} / \gamma_c",
                $$"""\eta = {{F(eta,3)}},\quad \eta f_{cd} = {{F(eta,3)}} \times {{F(fcd,2)}}""",
                $$"""\eta f_{cd} = {{F(fConc,2)}}\ \mathrm{MPa}"""));

            double fydVal = code.SteelDesignStrength(fy);
            blocks.Add(new("Design steel strength  (EC2 Table 2.1N)",
                @"f_{yd} = f_{yk} / \gamma_s",
                $$"""f_{yd} = {{F(fy,1)}} / 1.15""",
                $$"""f_{yd} = {{F(fydVal,2)}}\ \mathrm{MPa}"""));
        }

        blocks.Add(new(isAci
                ? "Nominal pure axial compression  (ACI 318 §22.4.2.2)"
                : "Nominal pure axial compression  (EC2, simplified rect. block)",
            $$"""P_0 = {{fcdL}} (A_g - A_{st}) + {{fydL}} A_{st}""",
            $$"""P_0 = {{F(fConc,2)}} \times ({{F(Ag,0)}} - {{F(Ast,0)}}) + {{F(fyd,2)}} \times {{F(Ast,0)}}""",
            $$"""P_0 = {{F(P0/1000,1)}}\ \mathrm{kN}"""));

        if (isAci)
        {
            blocks.Add(new("Design maximum compression  (ACI tied column α = 0.80, φ = 0.65)",
                @"\phi P_{n,max} = \phi \cdot 0.80 \cdot P_0",
                $$"""\phi P_{n,max} = 0.65 \times 0.80 \times {{F(P0/1000,1)}}""",
                $$"""\phi P_{n,max} = {{F(PhiPnMax/1000,1)}}\ \mathrm{kN}"""));
        }
        else
        {
            blocks.Add(new("Design axial capacity  (EC2: φ = 1.0, no compression cap)",
                @"P_{Rd,max} = \phi \cdot P_0",
                $$"""P_{Rd,max} = 1.0 \times {{F(P0/1000,1)}}""",
                $$"""P_{Rd,max} = {{F(PhiPnMax/1000,1)}}\ \mathrm{kN}"""));
        }

        string assumption = isAci
            ? "Full section in uniform compression. ACI tied column cap α = 0.80 applies."
            : "Full section in uniform compression. EC2 simplified rectangular stress block with η·fcd and fyd.";

        return new ControlPointValidationRow(
            "CP-01", isAci ? "Pure Axial Compression" : "Pure Axial Compression (EC2 Point A)",
            assumption,
            IsSupported: true, blocks,
            HandPnDisplay: HandPDisp, HandMxDisplay: 0, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: 0, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: 0,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-02  Zero Tension Point
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcZeroTensionPoint(
        double b, double h, double fyd, double Es, double fConc,
        double ecu, double beta1, double eyd,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel,
        string solverLabel, string ecuL, string beta1L, string fcdL, string fydL)
    {
        double dt  = h / 2.0 - bars.Min(r => r.Y);
        double c   = dt;
        double a   = Math.Min(beta1 * c, h);
        double Cc  = fConc * b * a;

        var (Pn, Mn) = CalcPnMn(b, h, fConc, fyd, Es, bars, c, beta1, ecu);
        double et   = TensileStrain(ecu, c, dt);
        double phi  = code.Phi(et, fyd, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;
        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Extreme tension bar strain",
                @"\varepsilon_{t} = 0",
                $$"""\varepsilon_t = 0""", ""),

            new("Neutral axis depth",
                $$"""c_{zero} = d_t""",
                $$"""c_{zero} = {{F(dt,1)}}""",
                $$"""c_{zero} = {{F(c,1)}}\ \mathrm{mm}"""),

            new($"Stress block depth  ({beta1L} = {F(beta1,4)})",
                $$"""a = {{beta1L}} c_{zero}""",
                $$"""a = {{F(beta1,4)}} \times {{F(c,1)}}""",
                $$"""a = {{F(a,1)}}\ \mathrm{mm}"""),

            new("Concrete compression force",
                $$"""C_c = {{fcdL}} \cdot b \cdot a""",
                $$"""C_c = {{F(fConc,2)}} \times {{F(b,0)}} \times {{F(a,1)}}""",
                $$"""C_c = {{F(Cc/1000,1)}}\ \mathrm{kN}"""),

            new("Nominal axial and moment",
                $$"""P_n = C_c + \sum A_{si} f_{si},\quad f_{si} = \mathrm{clamp}(E_s \varepsilon_{si},\,-{{fydL}},\,{{fydL}})""",
                $$"""P_n = {{F(Pn/1000,1)}}\ \mathrm{kN},\quad M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN\cdot m}""",
                $$"""\phi = {{F(phi,3)}},\quad \phi P_n = {{F(phi*Pn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN\cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-02", "Zero Tension Point",
            "Neutral axis depth where the extreme tension bar is exactly at zero strain.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-03  50% Yield Tension Point
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcHalfYieldPoint(
        double b, double h, double fyd, double Es, double fConc,
        double ecu, double beta1, double eyd,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel,
        string solverLabel, string ecuL, string beta1L, string fcdL, string fydL)
    {
        double dt  = h / 2.0 - bars.Min(r => r.Y);
        double c   = ecu * dt / (ecu + 0.5 * eyd);
        double a   = Math.Min(beta1 * c, h);
        double Cc  = fConc * b * a;

        var (Pn, Mn) = CalcPnMn(b, h, fConc, fyd, Es, bars, c, beta1, ecu);
        double et   = TensileStrain(ecu, c, dt);
        double phi  = code.Phi(et, fyd, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;
        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Extreme tension bar strain",
                @"\varepsilon_{t} = 0.5 \varepsilon_{y}",
                $$"""\varepsilon_t = 0.5 \times {{F(eyd,5)}}""", ""),

            new("Neutral axis depth",
                $$$"""c_{half} = \\frac{ {{{ecuL}}} \\cdot d_t }{ {{{ecuL}}} + 0.5 \varepsilon_{y}}""",
                $$"""c_{half} = \\frac{ {{F(ecu,4)}} \\times {{F(dt,1)}} }{ {{F(ecu,4)}} + {{F(0.5*eyd,5)}} }""",
                $$"""c_{half} = {{F(c,1)}}\ \mathrm{mm}"""),

            new($"Stress block depth  ({beta1L} = {F(beta1,4)})",
                $$"""a = {{beta1L}} c_{half}""",
                $$"""a = {{F(beta1,4)}} \times {{F(c,1)}}""",
                $$"""a = {{F(a,1)}}\ \mathrm{mm}"""),

            new("Concrete compression force",
                $$"""C_c = {{fcdL}} \cdot b \cdot a""",
                $$"""C_c = {{F(fConc,2)}} \times {{F(b,0)}} \times {{F(a,1)}}""",
                $$"""C_c = {{F(Cc/1000,1)}}\ \mathrm{kN}"""),

            new("Nominal axial and moment",
                $$"""P_n = C_c + \sum A_{si} f_{si},\quad f_{si} = \mathrm{clamp}(E_s \varepsilon_{si},\,-{{fydL}},\,{{fydL}})""",
                $$"""P_n = {{F(Pn/1000,1)}}\ \mathrm{kN},\quad M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN\cdot m}""",
                $$"""\phi = {{F(phi,3)}},\quad \phi P_n = {{F(phi*Pn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN\cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-03", "50% Yield Tension Point",
            "Neutral axis depth where the extreme tension bar reaches 50% of design yield strain.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-04  Balanced Point (X-axis bending)
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcBalancedPoint(
        double b, double h, double fyd, double Es, double fConc,
        double ecu, double beta1, double eyd,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel,
        string solverLabel, string ecuL, string beta1L, string fcdL, string fydL)
    {
        double dt  = h / 2.0 - bars.Min(r => r.Y);
        double cb  = ecu * dt / (ecu + eyd);
        double ab  = Math.Min(beta1 * cb, h);
        double Cc  = fConc * b * ab;

        var (Pn, Mn) = CalcPnMn(b, h, fConc, fyd, Es, bars, cb, beta1, ecu);
        double et   = TensileStrain(ecu, cb, dt);
        double phi  = code.Phi(et, fyd, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;
        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        var blocks = new List<ReportFormulaBlock>
        {
            new("Design steel yield strain",
                $$"""{{(fydL == @"f_y" ? @"\varepsilon_y" : @"\varepsilon_{yd}")}} = {{fydL}} / E_s""",
                $$"""{{{(fydL == @"f_y" ? @"\varepsilon_y" : @"\varepsilon_{yd}")}}} = {{F(fyd,2)}} / {{F(Es,0)}}""",
                $$"""{{{(fydL == @"f_y" ? @"\varepsilon_y" : @"\varepsilon_{yd}")}}} = {{F(eyd,5)}}"""),

            new($"Concrete ultimate strain  ({ecuL})",
                $$"""{{ecuL}}""",
                $$"""{{ecuL}} = {{F(ecu,4)}}""", ""),

            new("Extreme tension bar depth from compression face",
                @"d_t = h/2 - y_{min}",
                $$"""d_t = {{F(h/2,1)}} - ({{F(bars.Min(r=>r.Y),1)}})""",
                $$"""d_t = {{F(dt,1)}}\ \mathrm{mm}"""),

            new("Balanced neutral axis depth",
                $$"""c_b = \\frac{ {{ecuL}} \\cdot d_t }{ {{ecuL}} + {{(fydL == @"f_y" ? @"\varepsilon_y" : @"\varepsilon_{yd}")}}}""",
                $$"""c_b = \\frac{ {{F(ecu,4)}} \\times {{F(dt,1)}} }{ {{F(ecu,4)}} + {{F(eyd,5)}} }""",
                $$"""c_b = {{F(cb,1)}}\ \mathrm{mm}"""),

            new($"Stress block depth  ({beta1L} = {F(beta1,4)})",
                $$"""a_b = {{beta1L}} c_b""",
                $$"""a_b = {{F(beta1,4)}} \times {{F(cb,1)}}""",
                $$"""a_b = {{F(ab,1)}}\ \mathrm{mm}"""),

            new("Concrete compression force",
                $$"""C_c = {{fcdL}} \cdot b \cdot a_b""",
                $$"""C_c = {{F(fConc,2)}} \times {{F(b,0)}} \times {{F(ab,1)}}""",
                $$"""C_c = {{F(Cc/1000,1)}}\ \mathrm{kN}"""),

            new("Nominal axial and moment at balanced NA",
                $$"""P_n = C_c + \sum A_{si} f_{si},\quad f_{si} = \mathrm{clamp}(E_s \varepsilon_{si},\,-{{fydL}},\,{{fydL}})""",
                $$"""P_n = {{F(Pn/1000,1)}}\ \mathrm{kN},\quad M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN\cdot m}""",
                $$"""\phi = {{F(phi,3)}},\quad \phi P_n = {{F(phi*Pn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN\cdot m}"""),
        };

        string cp2Name = "Balanced Point";
        string assumption = "Neutral axis depth where the extreme tension bar just reaches " +
            "design yield strain simultaneously with concrete reaching ultimate strain at the compression face.";

        return new ControlPointValidationRow(
            "CP-04", cp2Name,
            assumption,
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-05  Tension-Controlled / Design Strain Limit
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcTensionControlled(
        double b, double h, double fyd, double Es, double fConc,
        double ecu, double beta1, double eyd, double etLimit,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel,
        string solverLabel, bool isAci, string ecuL, string beta1L, string etLimitL,
        string fcdL, string fydL)
    {
        double dt  = h / 2.0 - bars.Min(r => r.Y);
        double ct  = ecu * dt / (ecu + etLimit);
        double at  = Math.Min(beta1 * ct, h);

        var (Pn, Mn) = CalcPnMn(b, h, fConc, fyd, Es, bars, ct, beta1, ecu);
        double et   = TensileStrain(ecu, ct, dt);
        double phi  = code.Phi(et, fyd, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;
        var (diffP, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        string tcName = isAci ? "Tension-Controlled Point" : "Design Strain Limit (EC2 Point E)";
        string tcRef  = isAci ? "ACI 318 §21.2.2" : "EC2 §3.2.7(2)";
        string tcDesc = isAci
            ? "Neutral axis depth where the extreme tension bar strain equals ε_y + 0.003 " +
              "(ACI boundary for φ = 0.90)."
            : $"Neutral axis depth where the extreme tension bar reaches the design ultimate tensile " +
              $"strain εud = {F(etLimit,4)} (EC2 §3.2.7(2), EC2 control point E).";

        var blocks = new List<ReportFormulaBlock>
        {
            new($"Tension strain limit  ({tcRef})",
                $$"""{{etLimitL}}""",
                $$"""\varepsilon_{t,limit} = {{F(etLimit,4)}}""", ""),

            new("Neutral axis depth at tension limit",
                $$"""c_t = \\frac{ {{ecuL}} \\cdot d_t }{ {{ecuL}} + \varepsilon_{t,limit} }""",
                $$"""c_t = \\frac{ {{F(ecu,4)}} \\times {{F(dt,1)}} }{ {{F(ecu,4)}} + {{F(etLimit,4)}} }""",
                $$"""c_t = {{F(ct,1)}}\ \mathrm{mm}"""),

            new($"Stress block depth  ({beta1L} = {F(beta1,4)})",
                $$"""a_t = {{beta1L}} c_t""",
                $$"""a_t = {{F(beta1,4)}} \times {{F(ct,1)}}""",
                $$"""a_t = {{F(at,1)}}\ \mathrm{mm}"""),

            new($"Design capacities  (φ = {F(phi,2)})",
                $$"""\phi P_n,\quad \phi M_{nx}""",
                $$"""\phi = {{F(phi,2)}},\quad P_n = {{F(Pn/1000,1)}}\ \mathrm{kN},\quad M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN\cdot m}""",
                $$"""\phi P_n = {{F(phi*Pn/1000,1)}}\ \mathrm{kN},\quad \phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN\cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-05", tcName,
            tcDesc,
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: diffP, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-06  Pure Bending (Pn ≈ 0, bisection)
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureBending(
        double b, double h, double fyd, double Es, double fConc,
        double ecu, double beta1,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, MomentUnit mu, string fLabel, string mLabel,
        string solverLabel, string ecuL, string beta1L, string fcdL, string fydL)
    {
        // Bisect to find c where Pn(c) ≈ 0
        const double tolN = 0.1;
        double cLow = 1e-3, cHigh = h;
        double c = (cLow + cHigh) / 2.0;
        for (int i = 0; i < 120; i++)
        {
            var (Pn_mid, _) = CalcPnMn(b, h, fConc, fyd, Es, bars, c, beta1, ecu);
            if (Math.Abs(Pn_mid) < tolN) break;
            if (Pn_mid > 0) cHigh = c; else cLow = c;
            c = (cLow + cHigh) / 2.0;
        }

        double dt   = h / 2.0 - bars.Min(r => r.Y);
        var (Pn, Mn) = CalcPnMn(b, h, fConc, fyd, Es, bars, c, beta1, ecu);
        double et   = TensileStrain(ecu, c, dt);
        double phi  = code.Phi(et, fyd, Es);

        double PhiPnDisp = units.ForceFromN(phi * Pn, fu);
        double PhiMnDisp = units.MomentFromNmm(phi * Mn, mu);

        var solverRow = FindRow(table, "X", solverLabel);
        double solverP = solverRow?.P  ?? 0;
        double solverM = solverRow?.Mx ?? 0;
        var (_, diffM, status) = solverRow is null
            ? (0.0, 0.0, "N/A")
            : CalcDiff(PhiPnDisp, PhiMnDisp, solverP, solverM, compareM: true);

        string pbName = "Pure Bending (P ≈ 0)";
        var blocks = new List<ReportFormulaBlock>
        {
            new("Find NA depth c where net axial = 0  (bisection)",
                @"\left| P_n(c) \right| \leq \varepsilon_P \approx 0",
                $$"""c\ \text{solved by bisection in}\ [0,\,h],\quad \varepsilon_P = 0.1\ \mathrm{N}""",
                $$"""c = {{F(c,2)}}\ \mathrm{mm}"""),

            new("Moment capacity at pure bending NA",
                $$"""M_{nx}(c) = C_c \!\left(\\tfrac{h}{2}-\\tfrac{a}{2}\\right) + \sum A_{si} f_{si} y_i""",
                $$"""a = {{beta1L}} c = {{F(beta1,4)}} \times {{F(c,2)}} = {{F(beta1*c,2)}}\ \mathrm{mm}""",
                $$"""M_{nx} = {{F(Mn/1e6,1)}}\ \mathrm{kN \cdot m}"""),

            new($"Design moment capacity  (φ = {F(phi,2)} at ε_t = {F(et,4)})",
                @"\phi M_{nx}",
                $$"""\phi = {{F(phi,2)}}""",
                $$"""\phi M_{nx} = {{F(phi*Mn/1e6,1)}}\ \mathrm{kN \cdot m}"""),
        };

        return new ControlPointValidationRow(
            "CP-06", pbName,
            "Neutral axis depth where net axial capacity is approximately zero. Solved by bisection.",
            IsSupported: true, blocks,
            HandPnDisplay: PhiPnDisp, HandMxDisplay: PhiMnDisp, HandMyDisplay: 0,
            SolverPnDisplay: solverP, SolverMxDisplay: solverM, SolverMyDisplay: 0,
            DifferencePPercent: 0, DifferenceMPercent: diffM,
            Status: status, fLabel, mLabel);
    }

    // -----------------------------------------------------------------------
    // CP-07  Pure Tension
    // -----------------------------------------------------------------------
    private static ControlPointValidationRow CalcPureTension(
        double fyd,
        IReadOnlyList<RebarCoordinateDto> bars,
        ControlPointTableDto? table,
        IDesignCodeService code,
        IUnitConversionService units,
        ForceUnit fu, string fLabel, string mLabel,
        string solverLabel, bool isAci, string fydL)
    {
        double Ast    = bars.Sum(r => r.Area);
        double PnTen  = -fyd * Ast;                       // N, negative = tension
        double phi    = isAci ? 0.90 : 1.0;
        double PhiPn  = phi * PnTen;

        double HandPDisp = units.ForceFromN(PhiPn, fu);

        var solverRow = FindRow(table, "X", solverLabel);
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
                $$"""P_{n,ten} = -{{fydL}} A_{st}""",
                $$"""P_{n,ten} = -{{F(fyd,2)}} \times {{F(Ast,1)}}""",
                $$"""P_{n,ten} = {{F(PnTen/1000,1)}}\ \mathrm{kN}"""),

            new($"Design pure tension  (φ = {F(phi,2)})",
                $$"""\phi P_{n,ten} = \phi \cdot P_{n,ten}""",
                $$"""\phi P_{n,ten} = {{F(phi,2)}} \times {{F(PnTen/1000,1)}}""",
                $$"""\phi P_{n,ten} = {{F(PhiPn/1000,1)}}\ \mathrm{kN}"""),
        };

        return new ControlPointValidationRow(
            "CP-07", "Pure Tension",
            "All steel bars reach design yield in tension. Concrete tensile strength is neglected.",
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
    /// Nominal Pn and Mnx at a given NA depth c (N, N·mm). Compression positive.
    /// fConc = effective block stress (0.85·f'c for ACI, η·fcd for EC2).
    /// fyd   = design steel strength (fy for ACI, fy/γs for EC2).
    /// </summary>
    private static (double Pn, double Mn) CalcPnMn(
        double b, double h, double fConc, double fyd, double Es,
        IReadOnlyList<RebarCoordinateDto> bars,
        double c, double beta1, double ecu)
    {
        double a  = Math.Min(beta1 * c, h);
        double Cc = fConc * b * a;

        double Pn = Cc;
        double Mn = Cc * (h / 2.0 - a / 2.0);

        foreach (var bar in bars)
        {
            double di   = h / 2.0 - bar.Y;
            double epsi = ecu * (c - di) / c;
            double fsi  = Math.Clamp(Es * epsi, -fyd, fyd);
            Pn += bar.Area * fsi;
            Mn += bar.Area * fsi * bar.Y;
        }

        return (Pn, Mn);
    }

    /// <summary>Tensile strain at the extreme tension bar (positive = tensile).</summary>
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
