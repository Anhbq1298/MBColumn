using System.Globalization;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Solvers;

CultureInfo.CurrentCulture   = CultureInfo.InvariantCulture;
CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

var aci      = new Aci318DesignCodeService();
var ec2      = new Ec2DesignCodeService();
var factory  = new InteractionSolverFactory(aci, ec2);

var section  = BuildSection();
var concrete = new ConcreteMaterial("C28", 28.0);
var steel    = new SteelMaterial("Gr420", 420.0, 200_000.0);

int failed = 0;

Check("Factory routes Conventional",
    () => factory.Get(DesignCodeType.Aci318Style, aciSolver: AciSolverType.Conventional) is StrainCompatibilityInteractionSolver);
Check("Factory routes Fiber",
    () => factory.Get(DesignCodeType.Aci318Style, aciSolver: AciSolverType.Fiber) is AciFiberInteractionSolver);
Check("Factory default ACI is Conventional",
    () => factory.Get(DesignCodeType.Aci318Style) is StrainCompatibilityInteractionSolver);

var conventional = new StrainCompatibilityInteractionSolver(aci) { AngleStepDegrees = 10, NeutralAxisSamples = 50 };
var fiber        = new AciFiberInteractionSolver(aci) { AngleStepDegrees = 10, NeutralAxisSamples = 50, ConcreteGridDivisions = 60 };

var convSurface  = conventional.Solve(section, concrete, steel);
var fiberSurface = fiber.Solve(section, concrete, steel);

double convP0  = convSurface.Points.Max(p => p.Pn);
double fiberP0 = fiberSurface.Points.Max(p => p.Pn);
double convPnt  = convSurface.Points.Min(p => p.Pn);
double fiberPnt = fiberSurface.Points.Min(p => p.Pn);
double convMx  = convSurface.Points.Max(p => p.Mnx);
double fiberMx = fiberSurface.Points.Max(p => p.Mnx);
double convMy  = convSurface.Points.Max(p => p.Mny);
double fiberMy = fiberSurface.Points.Max(p => p.Mny);

Console.WriteLine();
Console.WriteLine("Pure-compression / pure-tension and primary-axis flexure comparison");
Console.WriteLine($"  P0  (compression peak)  conv = {convP0/1000.0,12:F1} kN,  fiber = {fiberP0/1000.0,12:F1} kN,  rel = {Rel(convP0, fiberP0):P2}");
Console.WriteLine($"  Pnt (tension minimum)   conv = {convPnt/1000.0,12:F1} kN,  fiber = {fiberPnt/1000.0,12:F1} kN,  rel = {Rel(convPnt, fiberPnt):P2}");
Console.WriteLine($"  Mnx peak                conv = {convMx/1e6,12:F1} kNm, fiber = {fiberMx/1e6,12:F1} kNm, rel = {Rel(convMx, fiberMx):P2}");
Console.WriteLine($"  Mny peak                conv = {convMy/1e6,12:F1} kNm, fiber = {fiberMy/1e6,12:F1} kNm, rel = {Rel(convMy, fiberMy):P2}");
Console.WriteLine();

Check("P0  agrees within 5%",            () => Rel(convP0, fiberP0) < 0.05);
Check("Pnt agrees within 0.001%",        () => Rel(convPnt, fiberPnt) < 1e-5);
Check("Mnx peak agrees within 5%",       () => Rel(convMx, fiberMx) < 0.05);
Check("Mny peak agrees within 5%",       () => Rel(convMy, fiberMy) < 0.05);

Check("Fiber phi spans full ACI range",
    () => fiberSurface.Points.Any(p => p.Phi <= 0.66) && fiberSurface.Points.Any(p => p.Phi >= 0.89));
Check("Fiber phi stays in [0.65, 0.90]",
    () => fiberSurface.Points.All(p => p.Phi >= 0.65 - 1e-9 && p.Phi <= 0.90 + 1e-9));
Check("Fiber surface has no NaN",
    () => !fiberSurface.Points.Any(p =>
        double.IsNaN(p.Pn) || double.IsInfinity(p.Pn) ||
        double.IsNaN(p.Mnx) || double.IsInfinity(p.Mnx) ||
        double.IsNaN(p.Mny) || double.IsInfinity(p.Mny) ||
        double.IsNaN(p.Phi) || double.IsInfinity(p.Phi)));

if (failed > 0)
{
    Console.WriteLine();
    Console.WriteLine($"FAILED: {failed} check(s).");
    return 1;
}

Console.WriteLine();
Console.WriteLine("All checks passed.");
return 0;

void Check(string name, Func<bool> predicate)
{
    bool ok;
    try { ok = predicate(); }
    catch (Exception ex) { Console.WriteLine($"  FAIL {name}: threw {ex.GetType().Name}: {ex.Message}"); failed++; return; }
    Console.WriteLine($"  {(ok ? "PASS" : "FAIL")} {name}");
    if (!ok) failed++;
}

static double Rel(double a, double b)
{
    double denom = Math.Max(Math.Abs(a), 1.0);
    return Math.Abs(a - b) / denom;
}

static RectangularSection BuildSection()
{
    // 700 mm x 700 mm column, 28 #25 bars on perimeter, 55 mm cover.
    const double width = 700.0;
    const double height = 700.0;
    const double cover = 55.0;
    const double dia = 25.0;
    double area = Math.PI * dia * dia / 4.0;

    var positions = new List<(double X, double Y)>();
    double hx = width / 2.0 - cover - dia / 2.0;
    double hy = height / 2.0 - cover - dia / 2.0;
    int barsPerSide = 8;
    for (int i = 0; i < barsPerSide; i++)
    {
        double t = i / (double)(barsPerSide - 1);
        positions.Add((-hx + 2 * hx * t, -hy));
        positions.Add((-hx + 2 * hx * t,  hy));
    }
    for (int i = 1; i < barsPerSide - 1; i++)
    {
        double t = i / (double)(barsPerSide - 1);
        positions.Add((-hx, -hy + 2 * hy * t));
        positions.Add(( hx, -hy + 2 * hy * t));
    }

    var bars = positions.Select((p, idx) => new Rebar($"B{idx + 1:00}", dia, area, p.X, p.Y)).ToList();
    return new RectangularSection(width, height, new RebarLayout("Perimeter bars", "T25", cover, bars));
}
