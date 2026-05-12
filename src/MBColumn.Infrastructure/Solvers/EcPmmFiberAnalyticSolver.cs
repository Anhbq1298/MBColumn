using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class EcPmmFiberAnalyticSolver(IDesignCodeService code) : IInteractionSolver
{
    public int AngleStepDegrees { get; init; } = 10;
    public int NeutralAxisSamples { get; init; } = 150;
    public int FiberCount { get; init; } = 500;

    // Eurocode 2 Material Constants (Table 3.1)
    private const double EpsC2 = 0.002;
    private const double EpsCu2 = 0.0035;
    private const double NExponent = 2.0; 
    private const double Es = 200000.0;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, d, a * AngleStepDegrees, a));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel, int depthIndex, double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);

        // Project corners to find total height in NA direction
        double hx = section.WidthMm / 2.0;
        double hy = section.HeightMm / 2.0;
        double[] projections = 
        {
            -hx * nx - hy * ny,
             hx * nx - hy * ny,
             hx * nx + hy * ny,
            -hx * nx + hy * ny
        };
        double yMax = projections.Max();
        double yMin = projections.Min();
        double h = yMax - yMin;

        (double epsTop, double epsBot) = GetStrainState(depthIndex, h);

        double concreteN = 0, concreteMx = 0, concreteMy = 0;
        double steelN = 0, steelMx = 0, steelMy = 0;
        double maxTensionStrain = 0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;
        bool hasCompressedConcrete = false;

        // Concrete Integration
        double fcd = code.ConcreteStressBlockFactor * concrete.FcMpa;
        double dy = h / FiberCount;
        for (int i = 0; i < FiberCount; i++)
        {
            double yLocal = yMin + (i + 0.5) * dy;
            double strain = epsBot + (epsTop - epsBot) * (yLocal - yMin) / h;
            
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, strain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, strain);
            
            double stress = GetConcreteStress(strain, fcd);
            if (stress > 0)
            {
                hasCompressedConcrete = true;
                double width = GetRectangleWidthAt(section, nx, ny, yLocal);
                double force = stress * width * dy;
                
                concreteN += force;
                var (cx, cy) = GetRectangleStripCentroid(section, nx, ny, yLocal);
                concreteMx -= force * cy;
                concreteMy += force * cx;
            }
        }

        // Steel Integration
        double fyd = code.SteelDesignStrength(steel.FyMpa);
        bool isPureAxial = System.Math.Abs(epsTop - EpsC2) < 1e-9 && System.Math.Abs(epsBot - EpsC2) < 1e-9;

        foreach (var bar in section.RebarLayout.Bars)
        {
            double yp = bar.XMm * nx + bar.YMm * ny;
            double strain = epsBot + (epsTop - epsBot) * (yp - yMin) / h;
            
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0) maxTensionStrain = System.Math.Max(maxTensionStrain, -strain);

            double stress = isPureAxial ? fyd : System.Math.Clamp(Es * strain, -fyd, fyd);
            
            // Displaced concrete
            double concStress = GetConcreteStress(strain, fcd);
            double force = (stress - concStress) * bar.AreaMm2;
            
            steelN += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axialN = concreteN + steelN;
        double mxNmm = concreteMx + steelMx;
        double myNmm = concreteMy + steelMy;

        return new InteractionPoint(
            depthIndex, 
            angleIndex, 
            angleDegrees, 
            GetNeutralAxisDepth(epsTop, epsBot, h), 
            axialN, 
            mxNmm, 
            myNmm, 
            1.0, 
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
            LabelState(axialN, hasCompressedConcrete, maxTensionStrain, maxSteelStrain));
    }

    private static string LabelState(double axialN, bool hasCompressedConcrete, double maxTensionSteelStrain, double maxSteelStrain)
    {
        if (!hasCompressedConcrete) return "Pure tension";
        if (maxTensionSteelStrain >= 0.005) return "Tension controlled";
        return "Compression controlled";
    }

    private (double epsTop, double epsBot) GetStrainState(int index, double h)
    {
        int part1Samples = (int)(NeutralAxisSamples * 0.8);
        int part2Samples = NeutralAxisSamples - part1Samples;

        if (index < part1Samples)
        {
            double t = (double)index / (part1Samples - 1);
            double epsBotStart = -0.05; 
            double epsBotEnd = 0.0;
            return (EpsCu2, epsBotStart + t * (epsBotEnd - epsBotStart));
        }
        else
        {
            double pivotRatio = EpsC2 / EpsCu2; 
            double t = (double)(index - part1Samples + 1) / part2Samples;
            double epsTop = EpsCu2 - t * (EpsCu2 - EpsC2);
            double epsBot = (EpsC2 - epsTop * pivotRatio) / (1.0 - pivotRatio);
            return (epsTop, epsBot);
        }
    }

    private double GetConcreteStress(double eps, double fcd)
    {
        if (eps <= 0) return 0;
        if (eps >= EpsCu2) return fcd;
        if (eps >= EpsC2) return fcd;
        return fcd * (1.0 - System.Math.Pow(1.0 - eps / EpsC2, NExponent));
    }

    private double GetRectangleWidthAt(RectangularSection section, double nx, double ny, double p)
    {
        var points = GetIntersectionPoints(section, nx, ny, p);
        if (points.Count < 2) return 0;
        double dx = points[0].X - points[1].X;
        double dy = points[0].Y - points[1].Y;
        return System.Math.Sqrt(dx * dx + dy * dy);
    }

    private (double X, double Y) GetRectangleStripCentroid(RectangularSection section, double nx, double ny, double p)
    {
        var points = GetIntersectionPoints(section, nx, ny, p);
        if (points.Count < 2) return (0, 0);
        return ((points[0].X + points[1].X) / 2.0, (points[0].Y + points[1].Y) / 2.0);
    }

    private List<(double X, double Y)> GetIntersectionPoints(RectangularSection section, double nx, double ny, double p)
    {
        double hx = section.WidthMm / 2.0;
        double hy = section.HeightMm / 2.0;
        var result = new List<(double X, double Y)>();

        if (System.Math.Abs(ny) > 1e-9)
        {
            double y = (p - hx * nx) / ny;
            if (y >= -hy - 1e-7 && y <= hy + 1e-7) result.Add((hx, y));
            y = (p + hx * nx) / ny;
            if (y >= -hy - 1e-7 && y <= hy + 1e-7) result.Add((-hx, y));
        }
        if (System.Math.Abs(nx) > 1e-9)
        {
            double x = (p - hy * ny) / nx;
            if (x >= -hx - 1e-7 && x <= hx + 1e-7) result.Add((x, hy));
            x = (p + hy * ny) / nx;
            if (x >= -hx - 1e-7 && x <= hx + 1e-7) result.Add((x, -hy));
        }

        // Remove duplicates
        for (int i = 0; i < result.Count; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                if (System.Math.Abs(result[i].X - result[j].X) < 1e-6 && System.Math.Abs(result[i].Y - result[j].Y) < 1e-6)
                {
                    result.RemoveAt(j);
                    j--;
                }
            }
        }
        return result;
    }

    private double GetNeutralAxisDepth(double epsTop, double epsBot, double h)
    {
        if (System.Math.Abs(epsTop - epsBot) < 1e-10) return 10000.0;
        return epsTop * h / (epsTop - epsBot);
    }
}
