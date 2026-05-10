using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class StrainCompatibilityInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public int AngleStepDegrees { get; init; } = 10;
    public int NeutralAxisSamples { get; init; } = 70;
    public int ConcreteGridDivisions { get; init; } = 42;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var fibers = BuildConcreteFibers(section).ToList();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        // The sweep mirrors the reference chart grid convention: depth rows first and 36 angular
        // columns per row. Compression is positive; concrete tension is ignored.
        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, a * AngleStepDegrees, a));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel, IReadOnlyList<Fiber> fibers, int depthIndex, double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        // c_max = 3Ã—max(width,height) ensures the extreme tension bar reaches fy in compression,
        // matching spColumn's sweep range (e.g. 2100mm for a 700Ã—700 section).
        double cMax = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = 5.0 + depthIndex * (cMax - 5.0) / (NeutralAxisSamples - 1);
        double maxProjection = ProjectExtreme(section, nx, ny);
        double neutralAxisProjection = maxProjection - c;

        double axialN = 0.0;
        double mxNmm = 0.0;
        double myNmm = 0.0;
        double maxTensionStrain = 0.0;

        // Whitney rectangular stress block: depth a = Î²â‚Â·c, uniform stress 0.85Â·fc.
        double beta1 = code.Beta1(concrete.FcMpa);
        double stressBlockBoundary = maxProjection - beta1 * c;

        foreach (var fiber in fibers)
        {
            if (fiber.XMm * nx + fiber.YMm * ny <= stressBlockBoundary) continue;
            double force = code.ConcreteStressBlockFactor * concrete.FcMpa * fiber.AreaMm2;
            axialN += force;
            mxNmm += force * fiber.YMm;
            myNmm += force * fiber.XMm;
        }

        foreach (var bar in section.RebarLayout.Bars)
        {
            double strain = code.ConcreteUltimateStrain * ((bar.XMm * nx + bar.YMm * ny) - neutralAxisProjection) / c;
            if (strain < 0)
            {
                maxTensionStrain = System.Math.Max(maxTensionStrain, -strain);
            }

            double fyd = code.SteelDesignStrength(steel.FyMpa);
            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            // Subtract displaced concrete at bar location (bar is in stress block when projection > stressBlockBoundary).
            double barProjection = bar.XMm * nx + bar.YMm * ny;
            double displacedConcrete = barProjection > stressBlockBoundary
                ? code.ConcreteStressBlockFactor * concrete.FcMpa
                : 0.0;
            double force = (stress - displacedConcrete) * bar.AreaMm2;
            axialN += force;
            mxNmm += force * bar.YMm;
            myNmm += force * bar.XMm;
        }

        double phi = code.Phi(maxTensionStrain, steel.FyMpa, steel.EsMpa);
        return new InteractionPoint(depthIndex, angleIndex, angleDegrees, c, axialN, mxNmm, myNmm, phi, maxTensionStrain);
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

