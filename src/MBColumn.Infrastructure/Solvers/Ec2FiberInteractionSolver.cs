using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class Ec2FiberInteractionSolver : IInteractionSolver
{
    private const double AlphaCc = 0.85;
    private const double GammaC = 1.50;
    private const double GammaS = 1.15;
    private const double EpsilonC2 = 0.002;
    private const double EpsilonCu2 = 0.0035;
    private const double ParabolaPower = 2.0;

    public int AngleStepDegrees { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 80;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var fibers = BuildConcreteFibers(section).ToList();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, NeutralAxisSamples, a * AngleStepDegrees, a));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private static InteractionPoint Evaluate(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IReadOnlyList<Fiber> fibers,
        int depthIndex,
        int neutralAxisSamples,
        double angleDegrees,
        int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        double cMax = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = 5.0 + depthIndex * (cMax - 5.0) / (neutralAxisSamples - 1);
        double maxProjection = ProjectExtreme(section, nx, ny);
        double hTheta = 2.0 * maxProjection;
        double neutralAxisProjection = maxProjection - c;
        
        // EC2 Pivot C logic for sections entirely in compression (c > hTheta)
        // xC is the distance from the extreme compression fiber to Pivot C
        double xC = hTheta * (1.0 - EpsilonC2 / EpsilonCu2);
        double epsilonTop = c <= hTheta 
            ? EpsilonCu2 
            : (c * EpsilonC2) / (c - xC);

        double fcd = AlphaCc * concrete.FcMpa / GammaC;
        double fyd = steel.FyMpa / GammaS;

        double concreteN = 0.0;
        double concreteMx = 0.0;
        double concreteMy = 0.0;
        double steelN = 0.0;
        double steelMx = 0.0;
        double steelMy = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;
        double maxTensionSteelStrain = 0.0;
        bool hasCompressedConcrete = false;

        foreach (var fiber in fibers)
        {
            double distFromCompFace = maxProjection - (fiber.XMm * nx + fiber.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, strain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, strain);
            double stress = ConcreteStress(strain, fcd);
            if (stress <= 0.0)
            {
                continue;
            }

            hasCompressedConcrete = true;
            double force = stress * fiber.AreaMm2;
            concreteN += force;
            concreteMx += force * fiber.YMm;
            concreteMy += force * fiber.XMm;
        }

        foreach (var bar in section.RebarLayout.Bars)
        {
            double distFromCompFace = maxProjection - (bar.XMm * nx + bar.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0.0)
            {
                maxTensionSteelStrain = System.Math.Max(maxTensionSteelStrain, -strain);
            }

            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double displacedConcreteStress = ConcreteStress(strain, fcd);
            double force = (stress - displacedConcreteStress) * bar.AreaMm2;
            steelN += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axial = concreteN + steelN;
        double mx = concreteMx + steelMx;
        double my = concreteMy + steelMy;
        return new InteractionPoint(
            depthIndex,
            angleIndex,
            angleDegrees,
            c,
            axial,
            mx,
            my,
            1.0,
            maxTensionSteelStrain,
            concreteN,
            steelN,
            concreteMx,
            concreteMy,
            steelMx,
            steelMy,
            maxConcreteStrain,
            minConcreteStrain,
            maxSteelStrain,
            minSteelStrain,
            LabelState(axial, hasCompressedConcrete, maxTensionSteelStrain, maxSteelStrain));
    }

    private static double ConcreteStress(double strain, double fcd)
    {
        if (strain <= 0.0)
        {
            return 0.0;
        }

        if (strain <= EpsilonC2)
        {
            return fcd * (1.0 - System.Math.Pow(1.0 - strain / EpsilonC2, ParabolaPower));
        }

        return strain <= EpsilonCu2 ? fcd : fcd;
    }

    private static string LabelState(double axialN, bool hasCompressedConcrete, double maxTensionSteelStrain, double maxSteelStrain)
    {
        if (!hasCompressedConcrete)
        {
            return "Maximum tension resistance";
        }

        if (System.Math.Abs(axialN) < 50_000.0)
        {
            return "Pure bending, N approximately 0";
        }

        const double yieldStrain = (500.0 / GammaS) / 200000.0;
        if (maxTensionSteelStrain >= yieldStrain || maxSteelStrain >= yieldStrain)
        {
            return "Steel yielding boundary";
        }

        return axialN > 0 ? "Compression with bending" : "Tension with bending";
    }

    private IEnumerable<Fiber> BuildConcreteFibers(RectangularSection section)
    {
        double dx = section.WidthMm / ConcreteGridDivisions;
        double dy = section.HeightMm / ConcreteGridDivisions;
        double area = dx * dy;
        double x0 = -section.WidthMm / 2.0 + dx / 2.0;
        double y0 = -section.HeightMm / 2.0 + dy / 2.0;

        for (int ix = 0; ix < ConcreteGridDivisions; ix++)
        {
            for (int iy = 0; iy < ConcreteGridDivisions; iy++)
            {
                yield return new Fiber(x0 + ix * dx, y0 + iy * dy, area);
            }
        }
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

    private sealed record Fiber(double XMm, double YMm, double AreaMm2);
}
