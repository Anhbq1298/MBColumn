using System.Globalization;
using System.Text;
using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.Solvers;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

var root = FindRepositoryRoot();
var outputDir = Path.Combine(root, "docs", "validation");
Directory.CreateDirectory(outputDir);

var section = BuildSConcreteSection();
var concrete = new ConcreteMaterial("C35/45", 35.0);
var steel = new SteelMaterial("B500", 500.0, 200000.0);
var solver = new Ec2FiberInteractionSolver
{
    AngleStepDegrees = 5,
    NeutralAxisSamples = 100,
    ConcreteGridDivisions = 80
};

var surface = solver.Solve(section, concrete, steel);
var comparisons = BuildComparisons(surface);

WriteSurfaceCsv(Path.Combine(outputDir, "ec2-fiber-pmm-sconcrete-generated-curves.csv"), surface);
WriteDebugCsv(Path.Combine(outputDir, "ec2-fiber-pmm-sconcrete-debug-state.csv"), comparisons);
WriteReport(Path.Combine(outputDir, "ec2-fiber-pmm-sconcrete-verification.txt"), comparisons);

Console.WriteLine($"Wrote {Path.Combine(outputDir, "ec2-fiber-pmm-sconcrete-verification.txt")}");

static RectangularSection BuildSConcreteSection()
{
    const double diameter = 25.0;
    double area = Math.PI * diameter * diameter / 4.0;
    var coords = new (double X, double Y)[]
    {
        (-237.5,  337.5),
        (-118.75, 337.5),
        (   0.0,  337.5),
        ( 118.75, 337.5),
        ( 237.5,  337.5),
        (-237.5,  168.75),
        ( 237.5,  168.75),
        (-237.5,    0.0),
        ( 237.5,    0.0),
        (-237.5, -168.75),
        ( 237.5, -168.75),
        (-237.5, -337.5),
        (-118.75,-337.5),
        (   0.0, -337.5),
        ( 118.75,-337.5),
        ( 237.5, -337.5)
    };

    var bars = coords.Select((p, i) => new Rebar($"B{i + 1:00}", diameter, area, p.X, p.Y)).ToList();
    return new RectangularSection(600.0, 800.0, new RebarLayout("S-CONCRETE 16H25", "H25", 62.5, bars));
}

static List<ComparisonRow> BuildComparisons(InteractionSurface surface)
{
    var checkpoints = new[]
    {
        new ReferenceCheckpoint(0, 0.0000, 1142.475, "pure bending"),
        new ReferenceCheckpoint(0, 3670.6850, 1644.959, "near peak moment"),
        new ReferenceCheckpoint(0, 12113.2600, 0.000, "max compression"),
        new ReferenceCheckpoint(90, 0.0000, 815.4838, "pure bending"),
        new ReferenceCheckpoint(90, 3670.6850, 1184.984, "near peak moment"),
        new ReferenceCheckpoint(90, 12113.2600, 0.000, "max compression"),
        new ReferenceCheckpoint(135, 0.0000, 906.3369, "pure bending"),
        new ReferenceCheckpoint(135, 3303.6160, 1164.707, "near peak moment"),
        new ReferenceCheckpoint(135, 12113.2600, 0.000, "max compression"),
        new ReferenceCheckpoint(180, 0.0000, 1142.475, "pure bending by symmetry"),
        new ReferenceCheckpoint(180, 3670.6850, 1644.959, "near peak moment by symmetry"),
        new ReferenceCheckpoint(180, 12113.2600, 0.000, "max compression"),
        new ReferenceCheckpoint(270, 0.0000, 815.4838, "pure bending by symmetry"),
        new ReferenceCheckpoint(270, 3670.6850, 1184.984, "near peak moment by symmetry"),
        new ReferenceCheckpoint(270, 12113.2600, 0.000, "max compression")
    };

    return checkpoints.Select(cp =>
    {
        var point = cp.MbAxialCompressionKn >= 12113.2600
            ? surface.Points.MaxBy(p => p.Pn)!
            : InterpolateAtAxial(surface, SolverAngleFromSConcrete(cp.ThetaDegrees), cp.MbAxialCompressionKn * 1000.0);
        double moment = Math.Abs(point.Mnx * Math.Cos(cp.ThetaDegrees * Math.PI / 180.0) + point.Mny * Math.Sin(cp.ThetaDegrees * Math.PI / 180.0)) / 1_000_000.0;
        double axial = point.Pn / 1000.0;
        double mbValue = cp.ReferenceMomentKnM == 0.0 ? axial : moment;
        double refValue = cp.ReferenceMomentKnM == 0.0 ? cp.MbAxialCompressionKn : cp.ReferenceMomentKnM;
        double diff = mbValue - refValue;
        double percent = refValue == 0.0 ? 0.0 : Math.Abs(diff) / Math.Abs(refValue) * 100.0;
        return new ComparisonRow(cp, point, axial, moment, diff, percent);
    }).ToList();
}

static int SolverAngleFromSConcrete(double sConcreteThetaDegrees)
{
    double solverAngle = (90.0 - sConcreteThetaDegrees) % 360.0;
    if (solverAngle < 0.0)
    {
        solverAngle += 360.0;
    }

    return (int)(solverAngle / 5.0);
}

static InteractionPoint InterpolateAtAxial(InteractionSurface surface, int angleIndex, double axialN)
{
    var points = surface.Points.Where(p => p.AngleIndex == angleIndex).OrderBy(p => p.Pn).ToList();
    for (int i = 0; i < points.Count - 1; i++)
    {
        var a = points[i];
        var b = points[i + 1];
        if ((a.Pn <= axialN && b.Pn >= axialN) || (a.Pn >= axialN && b.Pn <= axialN))
        {
            double t = Math.Abs(b.Pn - a.Pn) < 1e-9 ? 0.0 : (axialN - a.Pn) / (b.Pn - a.Pn);
            return Lerp(a, b, t);
        }
    }

    return points.MinBy(p => Math.Abs(p.Pn - axialN))!;
}

static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t)
    => new(
        a.DepthIndex,
        a.AngleIndex,
        L(a.ThetaDegrees, b.ThetaDegrees, t),
        L(a.NeutralAxisDepthMm, b.NeutralAxisDepthMm, t),
        L(a.Pn, b.Pn, t),
        L(a.Mnx, b.Mnx, t),
        L(a.Mny, b.Mny, t),
        L(a.Phi, b.Phi, t),
        L(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, t),
        L(a.ConcretePn, b.ConcretePn, t),
        L(a.SteelPn, b.SteelPn, t),
        L(a.ConcreteMnx, b.ConcreteMnx, t),
        L(a.ConcreteMny, b.ConcreteMny, t),
        L(a.SteelMnx, b.SteelMnx, t),
        L(a.SteelMny, b.SteelMny, t),
        L(a.MaxConcreteStrain, b.MaxConcreteStrain, t),
        L(a.MinConcreteStrain, b.MinConcreteStrain, t),
        L(a.MaxSteelStrain, b.MaxSteelStrain, t),
        L(a.MinSteelStrain, b.MinSteelStrain, t),
        a.StateLabel);

static double L(double a, double b, double t) => a + (b - a) * t;

static void WriteSurfaceCsv(string path, InteractionSurface surface)
{
    var sb = new StringBuilder();
    sb.AppendLine("theta_deg,state_id,N_kN,Mx_kNm,My_kNm,concrete_N_kN,steel_N_kN,concrete_Mx_kNm,concrete_My_kNm,steel_Mx_kNm,steel_My_kNm,max_concrete_strain,min_concrete_strain,max_steel_strain,min_steel_strain,label");
    foreach (var p in surface.Points)
    {
        sb.AppendLine($"{p.ThetaDegrees:0.###},{p.DepthIndex},{p.Pn / 1000.0:0.######},{p.Mnx / 1_000_000.0:0.######},{p.Mny / 1_000_000.0:0.######},{p.ConcretePn / 1000.0:0.######},{p.SteelPn / 1000.0:0.######},{p.ConcreteMnx / 1_000_000.0:0.######},{p.ConcreteMny / 1_000_000.0:0.######},{p.SteelMnx / 1_000_000.0:0.######},{p.SteelMny / 1_000_000.0:0.######},{p.MaxConcreteStrain:0.########},{p.MinConcreteStrain:0.########},{p.MaxSteelStrain:0.########},{p.MinSteelStrain:0.########},{p.StateLabel}");
    }

    File.WriteAllText(path, sb.ToString());
}

static void WriteDebugCsv(string path, IReadOnlyList<ComparisonRow> rows)
{
    var sb = new StringBuilder();
    sb.AppendLine("sconcrete_theta_deg,note,solver_theta_deg,c_mm,N_kN,Mtheta_kNm,concrete_N_kN,steel_N_kN,concrete_Mx_kNm,concrete_My_kNm,steel_Mx_kNm,steel_My_kNm,max_concrete_strain,min_concrete_strain,max_steel_strain,min_steel_strain,label");
    foreach (var row in rows)
    {
        var p = row.Point;
        sb.AppendLine($"{row.Checkpoint.ThetaDegrees},{row.Checkpoint.Note},{p.ThetaDegrees:0.###},{p.NeutralAxisDepthMm:0.###},{p.Pn / 1000.0:0.######},{row.MbMomentKnM:0.######},{p.ConcretePn / 1000.0:0.######},{p.SteelPn / 1000.0:0.######},{p.ConcreteMnx / 1_000_000.0:0.######},{p.ConcreteMny / 1_000_000.0:0.######},{p.SteelMnx / 1_000_000.0:0.######},{p.SteelMny / 1_000_000.0:0.######},{p.MaxConcreteStrain:0.########},{p.MinConcreteStrain:0.########},{p.MaxSteelStrain:0.########},{p.MinSteelStrain:0.########},{p.StateLabel}");
    }

    File.WriteAllText(path, sb.ToString());
}

static void WriteReport(string path, IReadOnlyList<ComparisonRow> rows)
{
    double maxPercent = rows.Max(r => r.PercentDifference);
    var sb = new StringBuilder();
    sb.AppendLine("MBColumn EC2 Fiber PMM vs S-CONCRETE Verification");
    sb.AppendLine("=================================================");
    sb.AppendLine();
    sb.AppendLine("EC2 assumptions used");
    sb.AppendLine("- fck = 35 MPa, fyk = 500 MPa, Es = 200000 MPa");
    sb.AppendLine("- alpha_cc = 0.85, gamma_c = 1.50, gamma_s = 1.15");
    sb.AppendLine("- fcd = 19.833333 MPa, fyd = 434.782609 MPa");
    sb.AppendLine("- Concrete model: EC2 parabola-rectangle, epsilon_c2 = 0.002, epsilon_cu2 = 0.0035, n = 2.0");
    sb.AppendLine("- Concrete tension stress is ignored; compressed concrete is integrated whenever fibers have compressive strain.");
    sb.AppendLine("- Steel model: elastic-perfectly plastic in tension and compression.");
    sb.AppendLine("- ACI phi factors and ACI control-point labels are not used in the EC2 fiber solver.");
    sb.AppendLine();
    sb.AppendLine("Mesh and sweep");
    sb.AppendLine("- Concrete mesh: 80 x 80 rectangular fibers.");
    sb.AppendLine("- Neutral-axis sweep: 100 depths from 5 mm to 2400 mm.");
    sb.AppendLine("- Angle sweep: 0 to 355 degrees at 5 degree spacing.");
    sb.AppendLine("- S-CONCRETE theta is treated as moment direction; MBColumn solver compression-normal angle = 90 degrees - S-CONCRETE theta.");
    sb.AppendLine();
    sb.AppendLine("Sign convention mapping");
    sb.AppendLine("- S-CONCRETE compression is negative.");
    sb.AppendLine("- MBColumn internal compression is positive.");
    sb.AppendLine("- S-CONCRETE N = -3670.685 kN maps to MBColumn N = +3670.685 kN.");
    sb.AppendLine();
    sb.AppendLine("Comparison table");
    sb.AppendLine("theta_deg | checkpoint | SC N (kN, comp +) | SC M (kNm) | MB N (kN) | MB Mtheta (kNm) | abs diff | diff % | status");
    sb.AppendLine("--- | --- | ---: | ---: | ---: | ---: | ---: | ---: | ---");
    foreach (var row in rows)
    {
        bool axialComparison = row.Checkpoint.ReferenceMomentKnM == 0.0;
        double absDiff = Math.Abs(row.Difference);
        string status = row.PercentDifference <= 3.0 ? "good" : row.PercentDifference <= 5.0 ? "acceptable" : "investigate";
        sb.AppendLine($"{row.Checkpoint.ThetaDegrees:0} | {row.Checkpoint.Note} | {row.Checkpoint.MbAxialCompressionKn:0.###} | {row.Checkpoint.ReferenceMomentKnM:0.###} | {row.MbAxialKn:0.###} | {row.MbMomentKnM:0.###} | {absDiff:0.###} {(axialComparison ? "kN" : "kNm")} | {row.PercentDifference:0.##}% | {status}");
    }

    sb.AppendLine();
    sb.AppendLine($"Maximum percentage difference: {maxPercent:0.##}%");
    sb.AppendLine("Pass/fail summary: initial EC2 fiber path is implemented and exportable, but the comparison has points above 5%; treat this validation as INVESTIGATE, not accepted final calibration.");
    sb.AppendLine();
    sb.AppendLine("Engineering explanation of discrepancies");
    sb.AppendLine("- MBColumn uses a documented EC2 parabola-rectangle fiber model with the explicit 16H25 coordinate assumption from the validation material file.");
    sb.AppendLine("- S-CONCRETE may apply hidden assumptions for stress block shape, minimum eccentricity, slenderness, concrete area displaced by bars, or material law details.");
    sb.AppendLine("- The available repository reference is checkpoint data only; the original NvsM.TXT curve file was not present in the workspace, so comparisons use the stated checkpoints and symmetry assumptions for 180 and 270 degrees.");
    sb.AppendLine();
    sb.AppendLine("Generated files");
    sb.AppendLine("- docs/validation/ec2-fiber-pmm-sconcrete-generated-curves.csv");
    sb.AppendLine("- docs/validation/ec2-fiber-pmm-sconcrete-debug-state.csv");
    sb.AppendLine();
    sb.AppendLine("Follow-up validation required");
    sb.AppendLine("- Add the full NvsM.TXT export to the repository and compare by curve interpolation instead of checkpoint-only interpolation.");
    sb.AppendLine("- Confirm S-CONCRETE theta definition and whether second-order effects or minimum eccentricity were disabled.");
    sb.AppendLine("- Confirm whether S-CONCRETE subtracts bar-displaced concrete area and which EC2 concrete diagram it uses for column PMM.");
    File.WriteAllText(path, sb.ToString());
}

static string FindRepositoryRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir is not null && !File.Exists(Path.Combine(dir.FullName, "MBColumn.sln")))
    {
        dir = dir.Parent;
    }

    return dir?.FullName ?? Directory.GetCurrentDirectory();
}

internal sealed record ReferenceCheckpoint(int ThetaDegrees, double MbAxialCompressionKn, double ReferenceMomentKnM, string Note);
internal sealed record ComparisonRow(ReferenceCheckpoint Checkpoint, InteractionPoint Point, double MbAxialKn, double MbMomentKnM, double Difference, double PercentDifference);
