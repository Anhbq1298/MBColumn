using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;

// Composition root â€” mirror MainWindow.xaml.cs
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

// spColumn reference test case 3: 1200Ã—400 mm, fc=32, fy=500, 16-T20 asymmetric (Sides Different), cover=55, ACI 318-19 biaxial tied
var input = new ColumnInputDto(
    UnitSystem: UnitSystem.Metric,
    Width: 1200,
    Height: 400,
    Cover: 55,
    BarSize: "T20",
    BarCount: 16,
    RebarLayoutPreset: "Sides Different",
    Fc: 32,
    Fy: 500,
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
    RebarLayoutType = RebarLayoutType.SidesDifferent,
    TopRebarSide = new RebarSideInputDto(8, "T20", 55),
    BottomRebarSide = new RebarSideInputDto(6, "T20", 55),
    LeftRebarSide = new RebarSideInputDto(2, "T20", 55),
    RightRebarSide = new RebarSideInputDto(0, "T20", 55)
};

var result = calculation.Calculate(input);
var table  = result.ControlPointTable!;

// Reference (spColumn) â€” Axis X bends about X-axis (depth=400), reports Mx
var refX = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression", 10030.4,   -26.05, 2010, -0.00250, 0.65000),
    ("Allowable comp.",  8024.3,   280.17,  414, -0.00057, 0.65000),
    ("fs = 0.0",         6459.9,   443.14,  335,  0.00000, 0.65000),
    ("fs = 0.5 fy",      4227.1,   548.25,  236,  0.00125, 0.65000),
    ("Balanced point",   2771.5,   569.56,  183,  0.00250, 0.65000),
    ("Tension control",  1928.5,   643.02,  118,  0.00550, 0.90000),
    ("Pure bending",        0.0,   402.18,   61,  0.01339, 0.90000),
    ("Max tension",     -2260.8,    38.15,    0,  9.99999, 0.90000),
};
// Axis Y bends about Y-axis (depth=1200), reports My
var refY = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression", 10030.4,  -103.25, 6810, -0.00250, 0.65000),
    ("Allowable comp.",  8024.3,   793.99, 1246, -0.00027, 0.65000),
    ("fs = 0.0",         7285.7,  1061.64, 1135,  0.00000, 0.65000),
    ("fs = 0.5 fy",      4903.1,  1565.89,  801,  0.00125, 0.65000),
    ("Balanced point",   3381.5,  1684.02,  619,  0.00250, 0.65000),
    ("Tension control",  2275.0,  2034.74,  401,  0.00550, 0.90000),
    ("Pure bending",        0.0,  1302.78,  196,  0.01433, 0.90000),
    ("Max tension",     -2260.8,   151.19,    0,  9.99999, 0.90000),
};

var rowsX = table.Rows.Where(r => r.Axis == "X").ToList();
var rowsY = table.Rows.Where(r => r.Axis == "Y").ToList();

Console.WriteLine($"Force unit: {table.ForceUnitLabel} | Moment: {table.MomentUnitLabel} | Length: {table.LengthUnitLabel}");
Console.WriteLine();

int Verify(string axis, IReadOnlyList<ControlPointTableRowDto> calc, (string Label, double P, double M, double C, double Eps, double Phi)[] refs)
{
    Console.WriteLine($"[AXIS {axis}]");
    Console.WriteLine($"{"Control Point",-18} | {"P_calc",10} | {"P_ref",10} | {"Î”P%",6} | {"Mx_calc",10} | {"My_calc",10} | {"M_ref",10} | {"Î”M%",6} | STATUS");
    int passed = 0;
    foreach (var rRef in refs)
    {
        var rCalc = calc.FirstOrDefault(c => c.PointLabel == rRef.Label);
        if (rCalc is null) { Console.WriteLine($"{rRef.Label,-18} | NOT FOUND"); continue; }
        double mCalc = axis == "X" ? rCalc.Mx : rCalc.My;
        double dP = Math.Abs(rRef.P) < 1e-3 ? Math.Abs(rCalc.P - rRef.P) : Math.Abs(rCalc.P - rRef.P) / Math.Abs(rRef.P) * 100.0;
        double dM = Math.Abs(rRef.M) < 1e-3 ? Math.Abs(mCalc   - rRef.M) : Math.Abs(mCalc   - rRef.M) / Math.Abs(rRef.M) * 100.0;
        
        bool okP = Math.Abs(rRef.P) < 1e-3 ? dP < 5.0 : dP <= 3.0;
        bool okM = Math.Abs(rRef.M) < 1e-3 ? dM < 5.0 : dM <= 3.0;
        string status = (okP && okM) ? "PASS" : (dP <= 5.0 && dM <= 5.0 ? "WARNING" : "FAIL");
        if (status != "FAIL") passed++;

        Console.WriteLine(
            $"{rRef.Label,-18} | {rCalc.P,10:F2} | {rRef.P,10:F2} | {dP,6:F2} | {rCalc.Mx,10:F2} | {rCalc.Mny,10:F2} | {rRef.M,10:F2} | {dM,6:F2} | {status}");
    }
    Console.WriteLine();
    return passed;
}

int passX = Verify("X", rowsX, refX);
int passY = Verify("Y", rowsY, refY);

Console.WriteLine("SUMMARY");
Console.WriteLine($"  Axis X: {passX}/{refX.Length} PASSED/WARNING");
Console.WriteLine($"  Axis Y: {passY}/{refY.Length} PASSED/WARNING");
Console.WriteLine($"  Overall: {(passX == refX.Length && passY == refY.Length ? "PASS" : "FAIL")}");

