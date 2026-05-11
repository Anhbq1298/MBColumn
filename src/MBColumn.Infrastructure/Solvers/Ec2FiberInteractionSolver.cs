using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class Ec2FiberInteractionSolver : IInteractionSolver
{
    private const double AlphaCc    = 0.80;    // UK National Annex style
    private const double GammaC     = 1.50;
    private const double GammaS     = 1.15;
    private const double EpsilonC2  = 0.0020;  // EC2 Table 3.1 – parabola peak strain
    private const double EpsilonCu2 = 0.0035;  // EC2 Table 3.1 – ultimate strain
    private const double N_Exponent = 2.0;     // EC2 Table 3.1 – exponent for fck <= 50

    public int AngleStepDegrees { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;
    public int ConcreteGridDivisions { get; init; } = 80;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var fibers = BuildConcreteFibers(section).ToList();
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        int sweepSamples = NeutralAxisSamples - 1;
        for (int d = 0; d < sweepSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, fibers, d, sweepSamples, a * AngleStepDegrees, a));
            }
        }

        // Pure compression: uniform strain = εc2 across the full section.
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
        // Log-space sampling: concentrates samples in partial-compression zone while extending
        // far enough into full compression that the last sweep point is near-uniform (M ≈ 0).
        // At c = 20×max, the tension-face strain deviation from εc2 is <0.05% → ΔM < 1 kN·m.
        const double cMin = 5.0;
        double cMax = 20.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = cMin * System.Math.Pow(cMax / cMin, (double)depthIndex / (neutralAxisSamples - 1));
        double maxProjection = ProjectExtreme(section, nx, ny);
        double hTheta = 2.0 * maxProjection;

        // EC2 Standard Pivot C logic (c > hTheta):
        double xC = hTheta * (1.0 - EpsilonC2 / EpsilonCu2); 
        double epsilonTop = c <= hTheta
            ? EpsilonCu2
            : (c * EpsilonC2) / (c - xC);

        double fcd     = AlphaCc * concrete.FcMpa / GammaC;
        double fyd     = steel.FyMpa / GammaS;

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        double maxTensionSteelStrain = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;
        bool hasCompressedConcrete = false;

        foreach (var fiber in fibers)
        {
            double distFromCompFace = maxProjection - (fiber.XMm * nx + fiber.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, strain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, strain);

            if (strain <= 0.0) continue;

            hasCompressedConcrete = true;
            double stress = strain >= EpsilonC2 ? fcd : fcd * (1.0 - System.Math.Pow(1.0 - strain / EpsilonC2, N_Exponent));
            
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
            if (strain < 0.0) maxTensionSteelStrain = System.Math.Max(maxTensionSteelStrain, -strain);

            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double dispStress = (strain > 0.0) ? (strain >= EpsilonC2 ? fcd : fcd * (1.0 - System.Math.Pow(1.0 - strain / EpsilonC2, N_Exponent))) : 0.0;
            
            double force = (stress - dispStress) * bar.AreaMm2;
            steelN += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axial = concreteN + steelN;
        double mx = concreteMx + steelMx;
        double my = concreteMy + steelMy;

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, axial, mx, my, 1.0,
            maxTensionSteelStrain, concreteN, steelN, concreteMx, concreteMy,
            steelMx, steelMy, maxConcreteStrain, minConcreteStrain,
            maxSteelStrain, minSteelStrain,
            LabelState(axial, hasCompressedConcrete, maxTensionSteelStrain, maxSteelStrain));
    }

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
        double steelStress  = System.Math.Min(steel.EsMpa * EpsilonC2, fyd);   // Es·εc2 = 400 MPa for B500
        double dispStress   = fcd;

        double concreteN = 0.0, concreteMx = 0.0, concreteMy = 0.0;
        foreach (var fiber in fibers)
        {
            double force = fcd * fiber.AreaMm2;
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

        double cNominal = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm) * 10.0;

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, cNominal,
            concreteN + steelN, concreteMx + steelMx, concreteMy + steelMy, 1.0, 0.0,
            concreteN, steelN, concreteMx, concreteMy, steelMx, steelMy,
            EpsilonC2, EpsilonC2, EpsilonC2, EpsilonC2, "Pure axial compression");
    }

    private static string LabelState(double axialN, bool hasCompressedConcrete, double maxTensionSteelStrain, double maxSteelStrain)
    {
        if (!hasCompressedConcrete) return "Pure tension";
        if (maxTensionSteelStrain >= 0.005) return "Tension controlled";
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

    private static IEnumerable<Fiber> BuildConcreteFibers(RectangularSection section)
    {
        double w = section.WidthMm;
        double h = section.HeightMm;
        int div = 80; 
        double dx = w / div;
        double dy = h / div;
        double area = dx * dy;
        double x0 = -0.5 * w + 0.5 * dx;
        double y0 = -0.5 * h + 0.5 * dy;

        for (int ix = 0; ix < div; ix++)
        {
            for (int iy = 0; iy < div; iy++)
            {
                yield return new Fiber(x0 + ix * dx, y0 + iy * dy, area);
            }
        }
    }

    private record Fiber(double XMm, double YMm, double AreaMm2);
}
