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
    private const double NExponent = 2.0; // Standard for <= C50/60
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

        // Determine strain state (epsTop, epsBot) based on depthIndex
        // We follow the Python sweep logic but mapped to NeutralAxisSamples.
        (double epsTop, double epsBot) = GetStrainState(depthIndex, h);

        double axialN = 0;
        double mxNmm = 0;
        double myNmm = 0;
        double maxTensionStrain = 0;

        // Concrete Integration (Fiber/Strip Method)
        double fcd = code.ConcreteStressBlockFactor * concrete.FcMpa;
        double dy = h / FiberCount;
        for (int i = 0; i < FiberCount; i++)
        {
            double yLocal = yMin + (i + 0.5) * dy;
            double strain = epsBot + (epsTop - epsBot) * (yLocal - yMin) / h;
            double stress = GetConcreteStress(strain, fcd);
            
            if (stress > 0)
            {
                double width = GetRectangleWidthAt(section, nx, ny, yLocal);
                double force = stress * (width * dy); // Compression is positive
                axialN += force;
                
                var (cx, cy) = GetRectangleStripCentroid(section, nx, ny, yLocal);
                mxNmm -= force * cy;
                myNmm += force * cx;
            }
        }

        // Steel Integration
        foreach (var bar in section.RebarLayout.Bars)
        {
            double yp = bar.XMm * nx + bar.YMm * ny;
            double strain = epsBot + (epsTop - epsBot) * (yp - yMin) / h;
            if (strain < 0) maxTensionStrain = System.Math.Max(maxTensionStrain, -strain);

            double fyd = code.SteelDesignStrength(steel.FyMpa);
            double stress = System.Math.Clamp(Es * strain, -fyd, fyd);
            
            // Displaced concrete
            double concStress = GetConcreteStress(strain, fcd);
            double force = (stress - concStress) * bar.AreaMm2;
            
            axialN += force;
            mxNmm -= force * bar.YMm;
            myNmm += force * bar.XMm;
        }

        return new InteractionPoint(
            depthIndex, 
            angleIndex, 
            angleDegrees, 
            GetNeutralAxisDepth(epsTop, epsBot, h), 
            axialN, 
            mxNmm, 
            myNmm, 
            1.0, 
            maxTensionStrain);
    }

    private (double epsTop, double epsBot) GetStrainState(int index, double h)
    {
        int part1Samples = (int)(NeutralAxisSamples * 0.8);
        int part2Samples = NeutralAxisSamples - part1Samples;

        if (index < part1Samples)
        {
            // Part 1: epsTop = 0.0035, epsBot goes from -0.25 to 0.0035 (compression)
            double t = (double)index / (part1Samples - 1);
            double epsBotStart = -0.25; 
            double epsBotEnd = EpsCu2;
            return (EpsCu2, epsBotStart + t * (epsBotEnd - epsBotStart));
        }
        else
        {
            // Part 2: Pivot transition
            // pivot_y = h/2 - (1 - epsC2/epsCu2) * h (from top)
            // But our y is from yMin to yMax. top is yMax.
            // pivot_y_abs = yMax - (1 - EpsC2/EpsCu2) * h
            double ratio = 1.0 - EpsC2 / EpsCu2; // ~0.428
            double t = (double)(index - part1Samples + 1) / part2Samples;
            // epsTop goes from 0.0035 down to 0.002
            double epsTop = EpsCu2 - t * (EpsCu2 - EpsC2);
            // epsBot is constrained by pivot: (epsTop - epsBot)/h = (epsTop - EpsC2) / (ratio * h)
            // epsBot = epsTop - (epsTop - EpsC2) / ratio
            double epsBot = epsTop - (epsTop - EpsC2) / (1.0 - ratio);
            return (epsTop, epsBot);
        }
    }

    private double GetConcreteStress(double strain, double fcd)
    {
        if (strain <= 0) return 0;
        double eps = System.Math.Min(strain, EpsCu2);
        if (eps < EpsC2)
        {
            return fcd * (1.0 - System.Math.Pow(1.0 - eps / EpsC2, NExponent));
        }
        return fcd;
    }

    private double GetRectangleWidthAt(RectangularSection section, double nx, double ny, double p)
    {
        // Length of intersection of line L: x*nx + y*ny = p with rectangle
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

        // Check 4 edges
        // 1. x = hx, -hy <= y <= hy
        if (System.Math.Abs(ny) > 1e-9)
        {
            double y = (p - hx * nx) / ny;
            if (y >= -hy - 1e-7 && y <= hy + 1e-7) result.Add((hx, y));
        }
        else if (System.Math.Abs(nx) > 1e-9 && System.Math.Abs(hx * nx - p) < 1e-7)
        {
             // Line is vertical and coincides with this edge? 
             // This doesn't happen with our p sweep usually, but for completeness:
             result.Add((hx, -hy));
             result.Add((hx, hy));
        }

        // 2. x = -hx, -hy <= y <= hy
        if (System.Math.Abs(ny) > 1e-9)
        {
            double y = (p + hx * nx) / ny;
            if (y >= -hy - 1e-7 && y <= hy + 1e-7) result.Add((-hx, y));
        }
        else if (System.Math.Abs(nx) > 1e-9 && System.Math.Abs(-hx * nx - p) < 1e-7)
        {
             result.Add((-hx, -hy));
             result.Add((-hx, hy));
        }

        // 3. y = hy, -hx <= x <= hx
        if (System.Math.Abs(nx) > 1e-9)
        {
            double x = (p - hy * ny) / nx;
            if (x >= -hx - 1e-7 && x <= hx + 1e-7) result.Add((x, hy));
        }
        else if (System.Math.Abs(ny) > 1e-9 && System.Math.Abs(hy * ny - p) < 1e-7)
        {
             result.Add((-hx, hy));
             result.Add((hx, hy));
        }

        // 4. y = -hy, -hx <= x <= hx
        if (System.Math.Abs(nx) > 1e-9)
        {
            double x = (p + hy * ny) / nx;
            if (x >= -hx - 1e-7 && x <= hx + 1e-7) result.Add((x, -hy));
        }
        else if (System.Math.Abs(ny) > 1e-9 && System.Math.Abs(-hy * ny - p) < 1e-7)
        {
             result.Add((-hx, -hy));
             result.Add((hx, -hy));
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
        if (System.Math.Abs(epsTop - epsBot) < 1e-10) return 10000.0; // Large depth for pure compression
        return epsTop * h / (epsTop - epsBot);
    }
}
