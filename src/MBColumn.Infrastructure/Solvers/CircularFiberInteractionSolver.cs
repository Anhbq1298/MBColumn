using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers;

/// <summary>
/// Circular RC interaction solver using strain compatibility and numerical concrete fibers.
/// Concrete is integrated over the circular area and reinforcing bars are handled as
/// discrete steel fibers at centroid-based coordinates.
/// </summary>
public sealed class CircularFiberInteractionSolver(IDesignCodeService code) : ICircularInteractionSolver
{
    public double AngleStepDegrees { get; init; } = 10.0;
    public int NeutralAxisSamples { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 80;

    public InteractionSurface Solve(CircularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = SMath.Max(1, (int)SMath.Round(360.0 / AngleStepDegrees));
        var concreteFibers = BuildConcreteFibers(section);
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        double ecu = code.ConcreteUltimateStrain(concrete.FcMpa);
        double peakStrain = code.ConcretePeakStrain(concrete.FcMpa);
        double n = code.ConcreteParabolicExponent(concrete.FcMpa);
        double fcCap = code.ConcreteStressBlockFactor * concrete.FcMpa;

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, concreteFibers, d, a * AngleStepDegrees, a, ecu, peakStrain, n, fcCap));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        CircularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IReadOnlyList<ConcreteFiber> concreteFibers,
        int depthIndex,
        double angleDegrees,
        int angleIndex,
        double ecu,
        double peakStrain,
        double n,
        double fcCap)
    {
        double theta = angleDegrees * SMath.PI / 180.0;
        double nx = SMath.Cos(theta);
        double ny = SMath.Sin(theta);
        double maxProjection = section.RadiusMm;
        double cMax = 10.0 * section.DiameterMm;
        double c = 0.1 + depthIndex * (cMax - 0.1) / SMath.Max(1, NeutralAxisSamples - 1);
        double neutralAxisProjection = maxProjection - c;

        double concreteN = 0.0;
        double concreteMx = 0.0;
        double concreteMy = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;

        foreach (var fiber in concreteFibers)
        {
            double projection = fiber.X * nx + fiber.Y * ny;
            double strain = ecu * (projection - neutralAxisProjection) / c;
            maxConcreteStrain = SMath.Max(maxConcreteStrain, strain);
            minConcreteStrain = SMath.Min(minConcreteStrain, strain);
            if (strain <= 0) continue;

            double stress = ConcreteStress(strain, peakStrain, n, fcCap);
            double force = stress * fiber.Area;
            concreteN += force;
            concreteMx -= force * fiber.Y;
            concreteMy += force * fiber.X;
        }

        double axialN = concreteN;
        double mxNmm = concreteMx;
        double myNmm = concreteMy;
        double steelN = 0.0;
        double steelMx = 0.0;
        double steelMy = 0.0;
        double maxTensionStrain = 0.0;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;
        double fyd = code.SteelDesignStrength(steel.FyMpa);
        double epsUd = code.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

        foreach (var bar in section.RebarLayout.Bars)
        {
            double projection = bar.XMm * nx + bar.YMm * ny;
            double strain = ecu * (projection - neutralAxisProjection) / c;
            maxSteelStrain = SMath.Max(maxSteelStrain, strain);
            minSteelStrain = SMath.Min(minSteelStrain, strain);
            if (strain < 0)
            {
                maxTensionStrain = SMath.Min(SMath.Max(maxTensionStrain, -strain), epsUd);
            }

            double stress = SMath.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double displacedConcrete = strain > 0 ? ConcreteStress(strain, peakStrain, n, fcCap) : 0.0;
            double force = (stress - displacedConcrete) * bar.AreaMm2;
            steelN += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
            axialN += force;
            mxNmm -= force * bar.YMm;
            myNmm += force * bar.XMm;
        }

        if (maxConcreteStrain == double.NegativeInfinity) maxConcreteStrain = 0.0;
        if (minConcreteStrain == double.PositiveInfinity) minConcreteStrain = 0.0;
        if (maxSteelStrain == double.NegativeInfinity) maxSteelStrain = 0.0;
        if (minSteelStrain == double.PositiveInfinity) minSteelStrain = 0.0;

        double phi = code.Phi(maxTensionStrain, steel.FyMpa, steel.EsMpa);
        return new InteractionPoint(
            depthIndex,
            angleIndex,
            angleDegrees,
            c,
            axialN,
            mxNmm,
            myNmm,
            phi,
            maxTensionStrain,
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
            ClassifyState(concreteN > 1e-9, maxTensionStrain, steel));
    }

    private static double ConcreteStress(double strain, double peakStrain, double n, double fcCap)
    {
        if (strain <= 0.0) return 0.0;
        if (strain >= peakStrain) return fcCap;
        double r = strain / peakStrain;
        return fcCap * (1.0 - SMath.Pow(1.0 - r, n));
    }

    private IReadOnlyList<ConcreteFiber> BuildConcreteFibers(CircularSection section)
    {
        double radius = section.RadiusMm;
        int divisions = SMath.Max(20, ConcreteGridDivisions);
        double step = section.DiameterMm / divisions;
        double cellArea = step * step;
        var fibers = new List<ConcreteFiber>(divisions * divisions);

        for (int ix = 0; ix < divisions; ix++)
        {
            double x = -radius + (ix + 0.5) * step;
            for (int iy = 0; iy < divisions; iy++)
            {
                double y = -radius + (iy + 0.5) * step;
                if (x * x + y * y <= radius * radius)
                {
                    fibers.Add(new ConcreteFiber(x, y, cellArea));
                }
            }
        }

        return fibers;
    }

    private static string ClassifyState(bool hasConcreteCompression, double maxTensionStrain, SteelMaterial steel)
    {
        if (!hasConcreteCompression) return "Pure tension";
        double yieldStrain = steel.FyMpa / steel.EsMpa;
        if (maxTensionStrain <= yieldStrain) return "Compression controlled";
        if (maxTensionStrain >= yieldStrain + 0.003) return "Tension controlled";
        return "Transition";
    }

    private sealed record ConcreteFiber(double X, double Y, double Area);
}
