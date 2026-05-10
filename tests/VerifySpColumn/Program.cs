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

// spColumn reference test case 1: 700Ã—300 mm, fc=28, fy=420, 16-T20 (314mm2), cover=55, ACI 318-19 biaxial tied
var input = new ColumnInputDto(
    UnitSystem: UnitSystem.Metric,
    Width: 700,
    Height: 300,
    Cover: 55,
    BarSize: "T20",
    BarCount: 16,
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

// Reference (spColumn) â€” Axis X bends about X-axis (depth=300), reports Mx
var refX = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  4542.5,    0.00, 783,  -0.00210, 0.65000),
    ("Allowable comp.",  3634.0,   88.34, 303,  -0.00082, 0.65000),
    ("fs = 0.0",         2796.3,  146.94, 235,   0.00000, 0.65000),
    ("fs = 0.5 fy",      1833.5,  175.22, 174,   0.00105, 0.65000),
    ("Balanced point",   1067.1,  183.89, 138,   0.00210, 0.65000),
    ("Tension control",   138.4,  197.59,  87,   0.00500, 0.90000),
    ("Pure bending",        0.0,  187.45,  82,   0.00557, 0.90000),
    ("Max tension",     -1899.1,    0.00,   0,   9.99999, 0.90000),
};
// Axis Y bends about Y-axis (depth=700), reports My
var refY = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  4542.5,    0.00, 2117, -0.00210, 0.65000),
    ("Allowable comp.",  3634.0,  240.20,  716, -0.00056, 0.65000),
    ("fs = 0.0",         3201.0,  333.30,  635,  0.00000, 0.65000),
    ("fs = 0.5 fy",      2207.5,  474.90,  470,  0.00105, 0.65000),
    ("Balanced point",   1480.5,  544.27,  374,  0.00210, 0.65000),
    ("Tension control",   883.4,  688.72,  235,  0.00500, 0.90000),
    ("Pure bending",        0.0,  531.69,  144,  0.01150, 0.90000),
    ("Max tension",     -1899.1,    0.00,    0,   9.99999, 0.90000),
};

var rowsX = table.Rows.Where(r => r.Axis == "X").ToList();
var rowsY = table.Rows.Where(r => r.Axis == "Y").ToList();

Console.WriteLine($"Force unit: {table.ForceUnitLabel} | Moment: {table.MomentUnitLabel} | Length: {table.LengthUnitLabel}");
Console.WriteLine();

int Verify(string axis, IReadOnlyList<ControlPointTableRowDto> calc, (string Label, double P, double M, double C, double Eps, double Phi)[] refs)
{
    Console.WriteLine($"[AXIS {axis}]");
    Console.WriteLine($"{"Control Point",-18} | {"P_calc",10} | {"P_ref",10} | {"Î”P%",6} | {"M_calc",10} | {"M_ref",10} | {"Î”M%",6} | {"c_calc",7} | {"c_ref",7} | STATUS");
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
            $"{rRef.Label,-18} | {rCalc.P,10:F2} | {rRef.P,10:F2} | {dP,6:F2} | {mCalc,10:F2} | {rRef.M,10:F2} | {dM,6:F2} | {rCalc.NaDepth,7:F1} | {rRef.C,7:F0} | {status}");
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

