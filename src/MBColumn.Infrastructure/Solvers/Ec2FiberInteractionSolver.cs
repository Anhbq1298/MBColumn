using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class Ec2FiberInteractionSolver : IInteractionSolver
{
    private const double AlphaCc    = 0.85;
    private const double GammaC     = 1.50;
    private const double GammaS     = 1.15;
    private const double LambdaRect = 0.8;      // EC2 Table 3.1 – rectangular block depth factor
    private const double EtaRect    = 1.0;      // EC2 Table 3.1 – effective strength factor
    private const double EpsilonC3  = 0.00175;  // EC2 Table 3.1 – strain at uniform stress (Pivot C)
    private const double EpsilonCu3 = 0.0035;   // EC2 Table 3.1 – ultimate compressive strain

    public int AngleStepDegrees { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 80;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var fibers = BuildConcreteFibers(section).ToList();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        // Last depth slot is reserved for the explicit pure-compression point (c → ∞, uniform εc3).
        // The sweep covers depthIndex 0 .. NeutralAxisSamples-2 using NeutralAxisSamples-1 as the
        // denominator so the final sweep sample still reaches cMax.
        int sweepSamples = NeutralAxisSamples - 1;
        for (int d = 0; d < sweepSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, sweepSamples, a * AngleStepDegrees, a));
            }
        }

        // Pure compression: uniform strain = εc3 across the full section.
        // All concrete fibres at fcd; all steel bars at Es·εc3 (≤ fyd). Moment = 0 for symmetric sections.
        int pcIndex = NeutralAxisSamples - 1;
        for (int a = 0; a < angleCount; a++)
        {
            points.Add(EvaluatePureCompression(section, concrete, steel, fibers, pcIndex, a, a * AngleStepDegrees));
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

        // EC2 rectangular stress block – Pivot C for full-compression case (c > hTheta):
        // xC is the distance from extreme compression face where strain = EpsilonC3
        double xC = hTheta * (1.0 - EpsilonC3 / EpsilonCu3);  // = 0.5 * hTheta
        double epsilonTop = c <= hTheta
            ? EpsilonCu3
            : (c * EpsilonC3) / (c - xC);

        double fcd     = AlphaCc * concrete.FcMpa / GammaC;
        double fyd     = steel.FyMpa / GammaS;
        double lambdaC = LambdaRect * c;  // depth of rectangular stress block from compression face

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

            // Rectangular stress block: uniform η·fcd within [0, λ·c] from compression face
            if (distFromCompFace < 0.0 || distFromCompFace > lambdaC) continue;

            hasCompressedConcrete = true;
            double force = EtaRect * fcd * fiber.AreaMm2;
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
            double displacedConcreteStress = (distFromCompFace >= 0.0 && distFromCompFace <= lambdaC)
                ? EtaRect * fcd : 0.0;
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

    // Pure compression: c → ∞, uniform strain = εc3. Steel stress = Es·εc3 < fyd (steel does not yield).
    // Moment is zero for symmetric sections; any residual is only numerical rounding in the fiber grid.
    private static InteractionPoint EvaluatePureCompression(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IReadOnlyList<Fiber> fibers,
        int depthIndex,
        int angleIndex,
        double angleDegrees)
    {
        double fcd          = AlphaCc * concrete.FcMpa / GammaC;
        double fyd          = steel.FyMpa / GammaS;
        double steelStress  = System.Math.Min(steel.EsMpa * EpsilonC3, fyd);   // Es·εc3 = 350 MPa for B500
        double dispStress   = EtaRect * fcd;                                   // concrete stress at bar location

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        foreach (var fiber in fibers)
        {
            double force = EtaRect * fcd * fiber.AreaMm2;
            concreteN  += force;
            concreteMx += force * fiber.YMm;
            concreteMy += force * fiber.XMm;
        }

        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double force = (steelStress - dispStress) * bar.AreaMm2;
            steelN  += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        // Use a large nominal c so the point sorts correctly at the compression tip of the surface.
        double cNominal = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm) * 10.0;

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, cNominal,
            concreteN + steelN,
            concreteMx + steelMx,
            concreteMy + steelMy,
            1.0,
            0.0,                        // no tension steel at pure compression
            concreteN, steelN,
            concreteMx, concreteMy,
            steelMx, steelMy,
            EpsilonC3, EpsilonC3,       // max/min concrete strain – uniform
            EpsilonC3, EpsilonC3,       // max/min steel strain   – uniform
            "Pure axial compression");
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
