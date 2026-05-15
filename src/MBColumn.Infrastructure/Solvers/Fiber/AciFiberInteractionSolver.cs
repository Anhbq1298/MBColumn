using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers.Fiber;

// Optional ACI fiber-based solver. Uses Hognestad-style parabolic concrete integration
// over a 100×100 fiber grid. Steel follows the same strain-compatibility treatment as
// the conventional solver. Phi factor is driven by IDesignCodeService.
public sealed class AciFiberInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public double AngleStepDegrees    { get; init; } = 10;
    public int NeutralAxisSamples  { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = (int)(360.0 / AngleStepDegrees);
        var fibers = BuildConcreteFibers(section, ConcreteGridDivisions).ToArray();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        double ecu       = code.ConcreteUltimateStrain(concrete.FcMpa);
        double peakStrain = code.ConcretePeakStrain(concrete.FcMpa);
        double n          = code.ConcreteParabolicExponent(concrete.FcMpa);
        double fcCap      = code.ConcreteStressBlockFactor * concrete.FcMpa; // 0.85 f'c cap

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, a * AngleStepDegrees, a, ecu, peakStrain, n, fcCap));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        Fiber[] fibers, int depthIndex, double angleDegrees, int angleIndex,
        double ecu, double peakStrain, double n, double fcCap)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        double cMax = 10.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = 0.1 + depthIndex * (cMax - 0.1) / (NeutralAxisSamples - 1);
        double maxProjection       = ProjectExtreme(section, nx, ny);
        double neutralAxisProjection = maxProjection - c;

        double fyd   = code.SteelDesignStrength(steel.FyMpa);
        double epsUd = code.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;

        for (int i = 0; i < fibers.Length; i++)
        {
            ref readonly var f = ref fibers[i];
            double projection = f.XMm * nx + f.YMm * ny;
            double strain     = ecu * (projection - neutralAxisProjection) / c;
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, strain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, strain);
            if (strain <= 0.0) continue;

            double stress = HognestadStress(strain, peakStrain, n, fcCap);
            double force  = stress * f.AreaMm2;
            concreteN  += force;
            concreteMx -= force * f.YMm;
            concreteMy += force * f.XMm;
        }

        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        double maxTensionStrain  = 0.0;
        double maxSteelStrain    = double.NegativeInfinity;
        double minSteelStrain    = double.PositiveInfinity;

        foreach (var bar in section.RebarLayout.Bars)
        {
            double projection = bar.XMm * nx + bar.YMm * ny;
            double strain     = ecu * (projection - neutralAxisProjection) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0.0)
                maxTensionStrain = System.Math.Min(System.Math.Max(maxTensionStrain, -strain), epsUd);

            double steelStress    = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double displacedStress = strain > 0.0 ? HognestadStress(strain, peakStrain, n, fcCap) : 0.0;
            double force = (steelStress - displacedStress) * bar.AreaMm2;
            steelN  += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axialN = concreteN + steelN;
        double mxNmm  = concreteMx + steelMx;
        double myNmm  = concreteMy + steelMy;
        double phi    = code.Phi(maxTensionStrain, steel.FyMpa, steel.EsMpa);
        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, axialN, mxNmm, myNmm, phi, maxTensionStrain,
            concreteN, steelN, concreteMx, concreteMy, steelMx, steelMy,
            maxConcreteStrain, minConcreteStrain, maxSteelStrain, minSteelStrain,
            ClassifyAciStrainRegion(maxTensionStrain, steel));
    }

    private static string ClassifyAciStrainRegion(double maxTensionStrain, SteelMaterial steel)
    {
        double yieldStrain = steel.FyMpa / steel.EsMpa;
        if (maxTensionStrain <= yieldStrain) return "Compression controlled";
        if (maxTensionStrain >= yieldStrain + 0.003) return "Tension controlled";
        return "Transition";
    }

    // Generalised Hognestad parabola: σ = fcCap × [2(ε/ε0) - (ε/ε0)^n]  for ε ≤ ε0
    //                                 σ = fcCap                            for ε > ε0
    private static double HognestadStress(double strain, double peakStrain, double n, double fcCap)
    {
        if (strain <= 0.0) return 0.0;
        if (strain >= peakStrain) return fcCap;
        double r = strain / peakStrain;
        return fcCap * (2.0 * r - System.Math.Pow(r, n));
    }

    private static double ProjectExtreme(RectangularSection section, double nx, double ny)
    {
        double hx = section.WidthMm / 2.0;
        double hy = section.HeightMm / 2.0;
        return new[]
        {
            -hx * nx + -hy * ny,
             hx * nx + -hy * ny,
             hx * nx +  hy * ny,
            -hx * nx +  hy * ny
        }.Max();
    }

    private static IEnumerable<Fiber> BuildConcreteFibers(RectangularSection section, int divisions)
    {
        int div = System.Math.Max(8, divisions);
        double w  = section.WidthMm;
        double h  = section.HeightMm;
        double dx = w / div;
        double dy = h / div;
        double area = dx * dy;
        double x0 = -0.5 * w + 0.5 * dx;
        double y0 = -0.5 * h + 0.5 * dy;
        for (int ix = 0; ix < div; ix++)
        {
            double x = x0 + ix * dx;
            for (int iy = 0; iy < div; iy++)
                yield return new Fiber(x, y0 + iy * dy, area);
        }
    }

    private readonly record struct Fiber(double XMm, double YMm, double AreaMm2);
}
