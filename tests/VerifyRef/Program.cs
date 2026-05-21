using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Infrastructure.Solvers.Integration;

// --export-pmm mode: export PMM CSV for the 700x700 irregular square test case (ACI 318)
if (args.Contains("--export-pmm"))
{
    int idx = Array.IndexOf(args, "--export-pmm");
    string csvPath = idx + 1 < args.Length ? args[idx + 1]
        : Path.Combine(Path.GetTempPath(), "mbcolumn_pmm_ref.csv");
    ExportIrregularPmmCsv(csvPath);
    return;
}

// --export-lshape-pmm mode: export PMM CSV for the L-shape irregular test case (EC2)
if (args.Contains("--export-lshape-pmm"))
{
    int idx = Array.IndexOf(args, "--export-lshape-pmm");
    string csvPath = idx + 1 < args.Length ? args[idx + 1]
        : Path.Combine(Path.GetTempPath(), "mbcolumn_lshape_ec2.csv");
    ExportLshapePmmCsv(csvPath);
    return;
}

static void ExportIrregularPmmCsv(string outPath)
{
    var boundary = new List<Point2D>
    {
        new(-350, -350),
        new(-350,  350),
        new( 350,  350),
        new( 350, -350),
    };
    var bars = new List<Rebar>
    {
        new("B1", 25.0, 491.0, -270.0, -270.0),
        new("B2", 25.0, 491.0,  270.0, -270.0),
        new("B3", 25.0, 491.0,  270.0,  270.0),
        new("B4", 25.0, 491.0, -270.0,  270.0),
    };
    var layout  = new RebarLayout("Test", "T25", 55.0, bars);
    var bbox    = new Rect2D(-350, -350, 350, 350);
    var section = new IrregularSection(boundary, boundary, new Point2D(0, 0), bbox, 700.0 * 700.0, layout);

    var concrete = new ConcreteMaterial("C28", 28.0);
    var steel    = new SteelMaterial("Gr420", 420.0, 200_000.0);
    var code     = new Aci318DesignCodeService();

    var settings = new SolverSettings
    {
        AngleStepDegrees   = 10.0,
        NeutralAxisSamples = 100,
        IntegrationMethod  = SectionIntegrationMethod.Polygon,
    };

    var input  = new PmmInput(section, concrete, steel, code, DesignCodeType.Aci318Style, settings);
    var solver = new PmmSolver(new NeutralAxisSweepStrategy(), new PolygonSectionIntegrator(), new Aci318DesignAdapter());
    var result = solver.Solve(input);

    Console.WriteLine("Solved " + result.Points.Count + " PMM points.");

    using var w = new StreamWriter(outPath);
    w.WriteLine("depth_index,angle_index,theta_deg,na_depth,Pn_kN,Mnx_kNm,Mny_kNm,phi,PhiPn_kN,PhiMnx_kNm,PhiMny_kNm,max_tension_strain,concrete_force_kN,steel_force_kN,state");
    foreach (var pt in result.Points)
    {
        w.WriteLine(
            pt.DepthIndex + "," + pt.AngleIndex + "," + pt.ThetaDegrees.ToString("F2") + "," + pt.NeutralAxisDepthMm.ToString("F6") + "," +
            (pt.Pn / 1000.0).ToString("F4") + "," + (pt.Mnx / 1e6).ToString("F4") + "," + (pt.Mny / 1e6).ToString("F4") + "," +
            pt.Phi.ToString("F6") + "," + (pt.PhiPn / 1000.0).ToString("F4") + "," + (pt.PhiMnx / 1e6).ToString("F4") + "," + (pt.PhiMny / 1e6).ToString("F4") + "," +
            pt.MaxTensionSteelStrain.ToString("F8") + "," +
            (pt.ConcretePn / 1000.0).ToString("F4") + "," + (pt.SteelPn / 1000.0).ToString("F4") + "," +
            pt.StrainState.RegionClassification);
    }

    Console.WriteLine("Exported -> " + outPath);
}

// L-shape irregular section, EC2 design code
// Plan: apple_to_apple_comparison_plan_rapt_vs_mb_column.md Section 2
// Boundary: 6-point L-shape, centroid at (0,0), area = 437,500 mm2
// 26 T25 bars (A = pi*25^2/4 mm2), cover 55 mm to bar face
static void ExportLshapePmmCsv(string outPath)
{
    double t25Area = Math.PI * 25.0 * 25.0 / 4.0;

    var boundary = new List<Point2D>
    {
        new(-339.2857,  339.2857),
        new(-339.2857, -660.7143),
        new( -89.28571, -660.7143),
        new( -89.28571,   89.28571),
        new( 660.7143,   89.28571),
        new( 660.7143,  339.2857),
    };

    var bars = new List<Rebar>
    {
        new("B01", 25.0, t25Area, -271.79,  271.79),
        new("B02", 25.0, t25Area, -271.79,  127.62),
        new("B03", 25.0, t25Area, -271.79,  -16.55),
        new("B04", 25.0, t25Area, -271.79, -160.71),
        new("B05", 25.0, t25Area, -271.79, -304.88),
        new("B06", 25.0, t25Area, -271.79, -449.05),
        new("B07", 25.0, t25Area, -271.79, -593.21),
        new("B08", 25.0, t25Area, -156.79, -593.21),
        new("B09", 25.0, t25Area, -156.79, -468.21),
        new("B10", 25.0, t25Area, -156.79, -343.21),
        new("B11", 25.0, t25Area, -156.79, -218.21),
        new("B12", 25.0, t25Area, -156.79,  -93.21),
        new("B13", 25.0, t25Area, -156.79,   31.79),
        new("B14", 25.0, t25Area, -156.79,  156.79),
        new("B15", 25.0, t25Area,  -31.79,  156.79),
        new("B16", 25.0, t25Area,   93.21,  156.79),
        new("B17", 25.0, t25Area,  218.21,  156.79),
        new("B18", 25.0, t25Area,  343.21,  156.79),
        new("B19", 25.0, t25Area,  468.21,  156.79),
        new("B20", 25.0, t25Area,  593.21,  156.79),
        new("B21", 25.0, t25Area,  593.21,  271.79),
        new("B22", 25.0, t25Area,  449.05,  271.79),
        new("B23", 25.0, t25Area,  304.88,  271.79),
        new("B24", 25.0, t25Area,  160.71,  271.79),
        new("B25", 25.0, t25Area,   16.55,  271.79),
        new("B26", 25.0, t25Area, -127.62,  271.79),
    };

    var layout  = new RebarLayout("Lshape", "T25", 55.0, bars);
    var bbox    = new Rect2D(-339.2857, -660.7143, 660.7143, 339.2857);
    var section = new IrregularSection(boundary, boundary, new Point2D(0, 0), bbox, 437500.0, layout);

    var concrete = new ConcreteMaterial("C28", 28.0);
    var steel    = new SteelMaterial("Gr420", 420.0, 200_000.0);
    var code     = new Ec2DesignCodeService();

    var settings = new SolverSettings
    {
        AngleStepDegrees   = 10.0,
        NeutralAxisSamples = 100,
        IntegrationMethod  = SectionIntegrationMethod.Polygon,
    };

    var input  = new PmmInput(section, concrete, steel, code, DesignCodeType.Ec2, settings);
    var solver = new PmmSolver(new NeutralAxisSweepStrategy(), new PolygonSectionIntegrator(), new Eurocode2DesignAdapter());
    var result = solver.Solve(input);

    Console.WriteLine("Solved " + result.Points.Count + " PMM points.");

    using var w = new StreamWriter(outPath);
    w.WriteLine("depth_index,angle_index,theta_deg,na_depth,Pn_kN,Mnx_kNm,Mny_kNm,phi,PhiPn_kN,PhiMnx_kNm,PhiMny_kNm,max_tension_strain,concrete_force_kN,steel_force_kN,state");
    foreach (var pt in result.Points)
    {
        w.WriteLine(
            pt.DepthIndex + "," + pt.AngleIndex + "," + pt.ThetaDegrees.ToString("F2") + "," + pt.NeutralAxisDepthMm.ToString("F6") + "," +
            (pt.Pn / 1000.0).ToString("F4") + "," + (pt.Mnx / 1e6).ToString("F4") + "," + (pt.Mny / 1e6).ToString("F4") + "," +
            pt.Phi.ToString("F6") + "," + (pt.PhiPn / 1000.0).ToString("F4") + "," + (pt.PhiMnx / 1e6).ToString("F4") + "," + (pt.PhiMny / 1e6).ToString("F4") + "," +
            pt.MaxTensionSteelStrain.ToString("F8") + "," +
            (pt.ConcretePn / 1000.0).ToString("F4") + "," + (pt.SteelPn / 1000.0).ToString("F4") + "," +
            pt.StrainState.RegionClassification);
    }

    Console.WriteLine("Exported -> " + outPath);
}

// Composition root - mirror MainWindow.xaml.cs
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

// ref reference test case 2: 900x400 mm, fc=32, fy=500, 16-T20 (314mm2), cover=55, ACI 318-19 biaxial tied
var input = new ColumnInputDto(
    UnitSystem: UnitSystem.Metric,
    Width: 900,
    Height: 400,
    Cover: 55,
    BarSize: "T20",
    BarCount: 16,
    RebarLayoutPreset: "All Sides Equal",
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
    RebarLayoutType = RebarLayoutType.AllSidesEqual
};

var result = calculation.Calculate(input);
var table  = result.ControlPointTable!;

// Axis X bends about X-axis (depth=400), reports Mx
var refX = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  7908.8,    0.00, 2010, -0.00250, 0.65000),
    ("Allowable comp.",  6327.0,  221.11,  415, -0.00058, 0.65000),
    ("fs = 0.0",         5088.6,  344.20,  335,  0.00000, 0.65000),
    ("fs = 0.5 fy",      3341.0,  417.22,  236,  0.00125, 0.65000),
    ("Balanced point",   2154.2,  427.78,  183,  0.00250, 0.65000),
    ("Tension control",  1209.5,  481.15,  118,  0.00550, 0.90000),
    ("Pure bending",        0.0,  349.18,   77,  0.01007, 0.90000),
    ("Max tension",     -2260.8,    0.00,    0,  9.99999, 0.90000),
};
// Axis Y bends about Y-axis (depth=900), reports My
var refY = new (string Label, double P, double M, double C, double Eps, double Phi)[]
{
    ("Max compression",  7908.8,    0.00, 5010, -0.00250, 0.65000),
    ("Allowable comp.",  6327.0,  538.65,  938, -0.00033, 0.65000),
    ("fs = 0.0",         5618.0,  731.60,  835,  0.00000, 0.65000),
    ("fs = 0.5 fy",      3788.4, 1025.04,  589,  0.00125, 0.65000),
    ("Balanced point",   2604.5, 1114.74,  455,  0.00250, 0.65000),
    ("Tension control",  1857.8, 1351.95,  295,  0.00550, 0.90000),
    ("Pure bending",        0.0,  877.90,  141,  0.01473, 0.90000),
    ("Max tension",     -2260.8,    0.00,    0,  9.99999, 0.90000),
};

var rowsX = table.Rows.Where(r => r.Axis == "X").ToList();
var rowsY = table.Rows.Where(r => r.Axis == "Y").ToList();

Console.WriteLine("Force unit: " + table.ForceUnitLabel + " | Moment: " + table.MomentUnitLabel + " | Length: " + table.LengthUnitLabel);
Console.WriteLine();

int Verify(string axis, IReadOnlyList<ControlPointTableRowDto> calc, (string Label, double P, double M, double C, double Eps, double Phi)[] refs)
{
    Console.WriteLine("[AXIS " + axis + "]");
    Console.WriteLine("{0,-18} | {1,10} | {2,10} | {3,6} | {4,10} | {5,10} | {6,10} | {7,6} | STATUS",
        "Control Point", "P_calc", "P_ref", "dP%", "Mx_calc", "My_calc", "M_ref", "dM%");
    int passed = 0;
    foreach (var rRef in refs)
    {
        var rCalc = calc.FirstOrDefault(c => c.PointLabel == rRef.Label);
        if (rCalc is null) { Console.WriteLine("{0,-18} | NOT FOUND", rRef.Label); continue; }
        double mCalc = axis == "X" ? rCalc.Mx : rCalc.My;
        double dP = Math.Abs(rRef.P) < 1e-3 ? Math.Abs(rCalc.P - rRef.P) : Math.Abs(rCalc.P - rRef.P) / Math.Abs(rRef.P) * 100.0;
        double dM = Math.Abs(rRef.M) < 1e-3 ? Math.Abs(mCalc   - rRef.M) : Math.Abs(mCalc   - rRef.M) / Math.Abs(rRef.M) * 100.0;

        bool okP = Math.Abs(rRef.P) < 1e-3 ? dP < 5.0 : dP <= 3.0;
        bool okM = Math.Abs(rRef.M) < 1e-3 ? dM < 5.0 : dM <= 3.0;
        string status = (okP && okM) ? "PASS" : (dP <= 5.0 && dM <= 5.0 ? "WARNING" : "FAIL");
        if (status != "FAIL") passed++;

        Console.WriteLine(
            "{0,-18} | {1,10:F2} | {2,10:F2} | {3,6:F2} | {4,10:F2} | {5,10:F2} | {6,10:F2} | {7,6:F2} | {8}",
            rRef.Label, rCalc.P, rRef.P, dP, rCalc.Mx, rCalc.My, rRef.M, dM, status);
    }
    Console.WriteLine();
    return passed;
}

int passX = Verify("X", rowsX, refX);
int passY = Verify("Y", rowsY, refY);

Console.WriteLine("SUMMARY");
Console.WriteLine("  Axis X: " + passX + "/" + refX.Length + " PASSED/WARNING");
Console.WriteLine("  Axis Y: " + passY + "/" + refY.Length + " PASSED/WARNING");
Console.WriteLine("  Overall: " + (passX == refX.Length && passY == refY.Length ? "PASS" : "FAIL"));
