using ColumnDesigner.Application.DTOs;
using ColumnDesigner.Application.Services;
using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;
using ColumnDesigner.Infrastructure.DesignCodes;
using ColumnDesigner.Infrastructure.Math;
using ColumnDesigner.Infrastructure.Rebar;
using ColumnDesigner.Infrastructure.Solvers;

// Composition root — mirror MainWindow.xaml.cs
IDesignCodeService aciCode = new Aci318DesignCodeService();
IDesignCodeService ec2Code = new Ec2DesignCodeService();
IDesignCodeServiceFactory codeFactory = new DesignCodeServiceFactory(aciCode, ec2Code);
IInteractionSolverFactory solverFactory = new InteractionSolverFactory(aciCode, ec2Code);
IUnitConversionService units = new UnitConversionService();
IRebarDatabase metricBars = new SingaporeRebarDatabase();
IRebarDatabase imperialBars = new ImperialRebarDatabase();
IRatioCheckService ratio = new RatioCheckService();
IControlPointBuilder control = new ControlPointBuilderService(units);
var diagrams = new DiagramDataService();
var validation = new InputValidationService();
IRebarCoordinateBuilderService rebarCoordinates = new RebarCoordinateBuilderService(units, metricBars, imperialBars);
var calculation = new ColumnCalculationService(solverFactory, codeFactory, units, ratio, control, diagrams, validation, rebarCoordinates);

// spColumn v10.10 reference test case: 700×300 mm, fc=28, fy=420, 28-T25, cover=55, ACI 318-19 tied
var input = new ColumnInputDto(
    UnitSystem: UnitSystem.Metric,
    Width: 700,
    Height: 300,
    Cover: 55,
    BarSize: "T25",
    // NOTE: BarCount=32 → 8 per side; corner dedup → 28 unique bars matching spColumn's "28-bar perimeter".
    // The AllSidesEqual preset double-counts corners; BarCount=28 would give only 24 unique bars.
    BarCount: 32,
    RebarLayoutPreset: "All Sides Equal",
    Fc: 28,
    Fy: 420,
    Es: 200000,
    Pu: 0,
    Mux: 0,
    Muy: 0,
    ForceUnit: ForceUnit.kN,
    LengthUnit: LengthUnit.Millimeter,
    MomentUnit: MomentUnit.kNm,
    StressUnit: StressUnit.MPa,
    SelectedPmAngleDegrees: 0,
    SelectedAxialLoad: 0)
{
    DesignCode = DesignCodeType.Aci318Style,
    RebarLayoutType = RebarLayoutType.AllSidesEqual
};

var result = calculation.Calculate(input);
var table  = result.ControlPointTable!;

// Reference (spColumn v10.10) — Axis X bends about X-axis (depth=300), reports Mx
// Order: MaxComp, AllowComp, fs=0, fs=0.5fy, Balanced, PureBending, TensionCtrl, MaxTension
var refX = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  6789.2,    0.00, 775,  -0.00210, 0.65000),
    ("Allowable comp.",  5431.4,  107.44, 320,  -0.00082, 0.65000),
    ("fs = 0.0",         3883.4,  208.48, 233,   0.00000, 0.65000),
    ("fs = 0.5 fy",      2165.1,  257.81, 172,   0.00105, 0.65000),
    ("Balanced point",    644.3,  288.76, 137,   0.00210, 0.65000),
    ("Pure bending",        0.0,  303.36, 118,   0.00290, 0.71682),
    ("Tension control", -1657.6,  305.11,  86,   0.00510, 0.90000),
    ("Max tension",     -5196.7,    0.00,   0,   9.99999, 0.90000),
};
// Axis Y bends about Y-axis (depth=700), reports My
var refY = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  6789.2,    0.00, 2108, -0.00210, 0.65000),
    ("Allowable comp.",  5431.4,  330.28,  779, -0.00056, 0.65000),
    ("fs = 0.0",         4423.0,  550.90,  633,  0.00000, 0.65000),
    ("fs = 0.5 fy",      2837.5,  804.70,  469,  0.00105, 0.65000),
    ("Balanced point",   1492.4,  981.98,  372,  0.00210, 0.65000),
    ("Tension control",   110.2, 1298.63,  234,  0.00510, 0.90000),
    ("Pure bending",        0.0, 1287.76,  227,  0.00537, 0.90000),
    ("Max tension",     -5196.7,    0.00,    0,  9.99999, 0.90000),
};

var rowsX = table.Rows.Where(r => r.Axis == "X").ToList();
var rowsY = table.Rows.Where(r => r.Axis == "Y").ToList();

Console.WriteLine($"Force unit: {table.ForceUnitLabel} | Moment: {table.MomentUnitLabel} | Length: {table.LengthUnitLabel}");
Console.WriteLine();

int Verify(string axis, IReadOnlyList<ControlPointTableRowDto> calc, (string Label, double P, double M, double C, double Eps, double Phi)[] refs)
{
    Console.WriteLine($"[AXIS {axis}]");
    Console.WriteLine($"{"Control Point",-18} | {"P_calc",10} | {"P_ref",10} | {"ΔP%",6} | {"M_calc",10} | {"M_ref",10} | {"ΔM%",6} | {"c_calc",7} | {"c_ref",7} | {"εt_calc",10} | {"φ_calc",7} | STATUS");
    int passed = 0;
    foreach (var rRef in refs)
    {
        var rCalc = calc.FirstOrDefault(c => c.PointLabel == rRef.Label);
        if (rCalc is null) { Console.WriteLine($"{rRef.Label,-18} | NOT FOUND"); continue; }
        double mCalc = axis == "X" ? rCalc.Mx : rCalc.My;
        double dP = Math.Abs(rRef.P) < 1e-3 ? Math.Abs(rCalc.P - rRef.P) : Math.Abs(rCalc.P - rRef.P) / Math.Abs(rRef.P) * 100.0;
        double dM = Math.Abs(rRef.M) < 1e-3 ? Math.Abs(mCalc   - rRef.M) : Math.Abs(mCalc   - rRef.M) / Math.Abs(rRef.M) * 100.0;
        bool okP = Math.Abs(rRef.P) < 1e-3 ? dP < 5.0 : dP <= 5.0;
        bool okM = Math.Abs(rRef.M) < 1e-3 ? dM < 5.0 : dM <= 5.0;
        bool ok  = okP && okM;
        if (ok) passed++;
        Console.WriteLine(
            $"{rRef.Label,-18} | {rCalc.P,10:F2} | {rRef.P,10:F2} | {dP,6:F2} | {mCalc,10:F2} | {rRef.M,10:F2} | {dM,6:F2} | {rCalc.NaDepth,7:F1} | {rRef.C,7:F0} | {rCalc.EpsilonT,10:F5} | {rCalc.Phi,7:F5} | {(ok ? "PASS" : "FAIL")}");
    }
    Console.WriteLine();
    return passed;
}

int passX = Verify("X", rowsX, refX);
int passY = Verify("Y", rowsY, refY);

Console.WriteLine("SUMMARY");
Console.WriteLine($"  Axis X: {passX}/{refX.Length} PASSED");
Console.WriteLine($"  Axis Y: {passY}/{refY.Length} PASSED");
Console.WriteLine($"  Overall: {(passX == refX.Length && passY == refY.Length ? "PASS" : "FAIL")}");
