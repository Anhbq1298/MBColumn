using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

// Optional ACI fiber-based solver: an alternative to the Whitney rectangular stress block
// implemented in StrainCompatibilityInteractionSolver. Concrete compression is integrated
// numerically over a regular fiber grid using a Hognestad-style parabolic ascending branch
// capped at 0.85 f'c. Steel rebars keep the existing strain-compatibility treatment.
//
// The solver preserves the ACI sign convention, phi-factor logic from IDesignCodeService,
// and the same (NeutralAxisSamples, AngleStepDegrees) sampling shape as the conventional
// solver so that downstream surface/diagram consumers see identical surface dimensions.
public sealed class AciFiberInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public int AngleStepDegrees { get; init; } = 10;
    public int NeutralAxisSamples { get; init; } = 150;
    public int ConcreteGridDivisions { get; init; } = 80;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var fibers = BuildConcreteFibers(section, ConcreteGridDivisions).ToArray();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        double peakStrain = ComputePeakStrain(code.ConcreteUltimateStrain);

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, a * AngleStepDegrees, a, peakStrain));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        Fiber[] fibers,
        int depthIndex,
        double angleDegrees,
        int angleIndex,
        double peakStrain)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        // Match conventional solver's c sweep so InteractionSurface domain aligns.
        double cMax = 10.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = 0.1 + depthIndex * (cMax - 0.1) / (NeutralAxisSamples - 1);
        double maxProjection = ProjectExtreme(section, nx, ny);
        double neutralAxisProjection = maxProjection - c;

        double ecu = code.ConcreteUltimateStrain;
        double fcCap = code.ConcreteStressBlockFactor * concrete.FcMpa; // 0.85 f'c
        double fyd = code.SteelDesignStrength(steel.FyMpa);

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        for (int i = 0; i < fibers.Length; i++)
        {
            ref readonly var f = ref fibers[i];
            double projection = f.XMm * nx + f.YMm * ny;
            double strain = ecu * (projection - neutralAxisProjection) / c;
            if (strain <= 0.0) continue;

            double stress = HognestadStress(strain, peakStrain, fcCap);
            double force = stress * f.AreaMm2;
            concreteN += force;
            concreteMx -= force * f.YMm;
            concreteMy += force * f.XMm;
        }

        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        double maxTensionStrain = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double projection = bar.XMm * nx + bar.YMm * ny;
            double strain = ecu * (projection - neutralAxisProjection) / c;
            if (strain < 0.0)
            {
                maxTensionStrain = System.Math.Max(maxTensionStrain, -strain);
            }

            double steelStress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double displacedStress = strain > 0.0
                ? HognestadStress(strain, peakStrain, fcCap)
                : 0.0;
            double force = (steelStress - displacedStress) * bar.AreaMm2;
            steelN += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axialN = concreteN + steelN;
        double mxNmm = concreteMx + steelMx;
        double myNmm = concreteMy + steelMy;
        double phi = code.Phi(maxTensionStrain, steel.FyMpa, steel.EsMpa);
        return new InteractionPoint(depthIndex, angleIndex, angleDegrees, c, axialN, mxNmm, myNmm, phi, maxTensionStrain);
    }

    // Hognestad-style ascending parabola with flat top at fcCap, zero in tension.
    // sigma = fcCap * [2(eps/eps0) - (eps/eps0)^2]   for 0 < eps <= eps0
    // sigma = fcCap                                  for eps0 < eps <= ecu
    // sigma = 0                                      otherwise
    private static double HognestadStress(double strain, double peakStrain, double fcCap)
    {
        if (strain <= 0.0) return 0.0;
        if (strain >= peakStrain) return fcCap;
        double r = strain / peakStrain;
        return fcCap * (2.0 * r - r * r);
    }

    // Peak strain eps0 is conventionally ~2/3 * ecu. With ecu = 0.003 -> eps0 = 0.002.
    private static double ComputePeakStrain(double ultimateStrain) => 2.0 * ultimateStrain / 3.0;

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
        double w = section.WidthMm;
        double h = section.HeightMm;
        double dx = w / div;
        double dy = h / div;
        double area = dx * dy;
        double x0 = -0.5 * w + 0.5 * dx;
        double y0 = -0.5 * h + 0.5 * dy;

        for (int ix = 0; ix < div; ix++)
        {
            double x = x0 + ix * dx;
            for (int iy = 0; iy < div; iy++)
            {
                yield return new Fiber(x, y0 + iy * dy, area);
            }
        }
    }

    private readonly record struct Fiber(double XMm, double YMm, double AreaMm2);
}
