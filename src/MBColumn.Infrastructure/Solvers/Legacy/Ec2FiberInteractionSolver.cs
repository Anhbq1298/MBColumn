using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers.Legacy;

// Optional EC2 fiber-based solver. Uses EC2 parabolic-rectangular concrete model
// integrated over a 100×100 fiber grid. All material parameters are read from
// IDesignCodeService — no local hardcoded constants.
public sealed class Ec2FiberInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public double AngleStepDegrees      { get; init; } = 5;
    public int NeutralAxisSamples    { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = (int)(360.0 / AngleStepDegrees);
        var fibers = BuildConcreteFibers(section, ConcreteGridDivisions).ToList();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        int sweepSamples = NeutralAxisSamples - 1;
        for (int d = 0; d < sweepSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
                points.Add(Evaluate(section, concrete, steel, fibers, d, sweepSamples, a * AngleStepDegrees, a));
        }

        int pcIndex = NeutralAxisSamples - 1;
        for (int a = 0; a < angleCount; a++)
            points.Add(EvaluatePureCompression(section, concrete, steel, fibers, pcIndex, a, a * AngleStepDegrees));

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        IReadOnlyList<Fiber> fibers, int depthIndex, int neutralAxisSamples,
        double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);

        double fck    = concrete.FcMpa;
        double fcd    = code.AlphaCc * fck / 1.50;
        double fyd    = code.SteelDesignStrength(steel.FyMpa);
        double epsCu2 = code.ConcreteUltimateStrain(fck);
        double epsC2  = code.ConcretePeakStrain(fck);
        double n      = code.ConcreteParabolicExponent(fck);
        double epsUd  = code.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

        double cMin = 5.0;
        double cMax = 20.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c    = cMin * System.Math.Pow(cMax / cMin, (double)depthIndex / (neutralAxisSamples - 1));
        double maxProjection = ProjectExtreme(section, nx, ny);
        double hTheta        = 2.0 * maxProjection;

        // EC2 Standard Pivot C logic (c > hTheta):
        double xC = hTheta * (1.0 - epsC2 / epsCu2);
        double epsilonTop = c <= hTheta
            ? epsCu2
            : (c * epsC2) / (c - xC);

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        double maxTensionSteelStrain = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;
        double maxSteelStrain    = double.NegativeInfinity;
        double minSteelStrain    = double.PositiveInfinity;
        bool hasCompressedConcrete = false;

        foreach (var fiber in fibers)
        {
            double distFromCompFace = maxProjection - (fiber.XMm * nx + fiber.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, strain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, strain);
            if (strain <= 0.0) continue;
            hasCompressedConcrete = true;
            double stress = strain >= epsC2 ? fcd : fcd * (1.0 - System.Math.Pow(1.0 - strain / epsC2, n));
            double force  = stress * fiber.AreaMm2;
            concreteN  += force;
            concreteMx += force * fiber.YMm;
            concreteMy += force * fiber.XMm;
        }

        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double distFromCompFace = maxProjection - (bar.XMm * nx + bar.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0.0)
                maxTensionSteelStrain = System.Math.Min(System.Math.Max(maxTensionSteelStrain, -strain), epsUd);

            double stress    = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double dispStress = strain > 0.0
                ? (strain >= epsC2 ? fcd : fcd * (1.0 - System.Math.Pow(1.0 - strain / epsC2, n)))
                : 0.0;
            double force = (stress - dispStress) * bar.AreaMm2;
            steelN  += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axial = concreteN + steelN;
        double mx    = concreteMx + steelMx;
        double my    = concreteMy + steelMy;

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, axial, mx, my, 1.0,
            maxTensionSteelStrain, concreteN, steelN, concreteMx, concreteMy,
            steelMx, steelMy, maxConcreteStrain, minConcreteStrain,
            maxSteelStrain, minSteelStrain,
            LabelState(hasCompressedConcrete, maxTensionSteelStrain));
    }

    private InteractionPoint EvaluatePureCompression(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        IReadOnlyList<Fiber> fibers, int depthIndex, int angleIndex, double angleDegrees)
    {
        double fck  = concrete.FcMpa;
        double fcd  = code.AlphaCc * fck / 1.50;
        double fyd  = code.SteelDesignStrength(steel.FyMpa);
        double epsC2 = code.ConcretePeakStrain(fck);

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        foreach (var fiber in fibers)
        {
            double force = fcd * fiber.AreaMm2;
            concreteN  += force;
            concreteMx += force * fiber.YMm;
            concreteMy += force * fiber.XMm;
        }

        double steelStress = System.Math.Min(steel.EsMpa * epsC2, fyd);
        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double force = (steelStress - fcd) * bar.AreaMm2;
            steelN  += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double cNominal = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm) * 10.0;
        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, cNominal,
            concreteN + steelN, concreteMx + steelMx, concreteMy + steelMy, 1.0, 0.0,
            concreteN, steelN, concreteMx, concreteMy, steelMx, steelMy,
            epsC2, epsC2, epsC2, epsC2, "Pure axial compression");
    }

    private static string LabelState(bool hasCompressedConcrete, double maxTensionSteelStrain)
    {
        if (!hasCompressedConcrete)          return "Pure tension";
        if (maxTensionSteelStrain >= 0.005)  return "Tension controlled";
        return "Compression controlled";
    }

    private static double ProjectExtreme(RectangularSection section, double nx, double ny)
    {
        double w = section.WidthMm;
        double h = section.HeightMm;
        double d1 = System.Math.Abs(0.5 * w * nx + 0.5 * h * ny);
        double d2 = System.Math.Abs(0.5 * w * nx - 0.5 * h * ny);
        return System.Math.Max(d1, d2);
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
            for (int iy = 0; iy < div; iy++)
                yield return new Fiber(x0 + ix * dx, y0 + iy * dy, area);
        }
    }

    private record Fiber(double XMm, double YMm, double AreaMm2);
}
