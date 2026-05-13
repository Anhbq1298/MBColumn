using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class StrainCompatibilityInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public int AngleStepDegrees { get; init; } = 10;
    public int NeutralAxisSamples { get; init; } = 150;
    public int ConcreteGridDivisions { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);
        var boundary = new List<Point>
        {
            new Point(-section.WidthMm / 2.0, -section.HeightMm / 2.0),
            new Point( section.WidthMm / 2.0, -section.HeightMm / 2.0),
            new Point( section.WidthMm / 2.0,  section.HeightMm / 2.0),
            new Point(-section.WidthMm / 2.0,  section.HeightMm / 2.0)
        };

        for (int d = 0; d < NeutralAxisSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, boundary, d, a * AngleStepDegrees, a));
            }
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel, IReadOnlyList<Point> boundary, int depthIndex, double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        // c_max = 10.0Ã—max(width,height) ensures all bars reach compression yield (fy)
        // even for large sections, giving a stable pure-compression pole.
        double cMax = 10.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c = 0.1 + depthIndex * (cMax - 0.1) / (NeutralAxisSamples - 1);
        double maxProjection = ProjectExtreme(section, nx, ny);
        double neutralAxisProjection = maxProjection - c;

        // Whitney rectangular stress block: depth a = Î²â‚ Â·c, uniform stress 0.85Â·fc.
        double beta1 = code.Beta1(concrete.FcMpa);
        double stressBlockBoundary = maxProjection - beta1 * c;

        // Analytical concrete integration using polygon clipping
        var poly = ClipPolygon(boundary, nx, ny, stressBlockBoundary);
        var props = CalculatePolygonProperties(poly);
        
        double concreteForce = code.ConcreteStressBlockFactor * concrete.FcMpa * props.Area;
        double axialN = concreteForce;
        double concreteMx = -concreteForce * props.CentroidY;
        double concreteMy =  concreteForce * props.CentroidX;
        double mxNmm = concreteMx;
        double myNmm = concreteMy;
        double maxTensionStrain = 0.0;
        double steelN = 0.0;
        double steelMx = 0.0;
        double steelMy = 0.0;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;

        foreach (var vertex in boundary)
        {
            double concreteStrain = code.ConcreteUltimateStrain * ((vertex.X * nx + vertex.Y * ny) - neutralAxisProjection) / c;
            maxConcreteStrain = System.Math.Max(maxConcreteStrain, concreteStrain);
            minConcreteStrain = System.Math.Min(minConcreteStrain, concreteStrain);
        }

        foreach (var bar in section.RebarLayout.Bars)
        {
            double strain = code.ConcreteUltimateStrain * ((bar.XMm * nx + bar.YMm * ny) - neutralAxisProjection) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
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
            steelN += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
            axialN += force;
            mxNmm -= force * bar.YMm;
            myNmm += force * bar.XMm;
        }

        double phi = code.Phi(maxTensionStrain, steel.FyMpa, steel.EsMpa);
        string stateLabel = ClassifyAciStrainRegion(maxTensionStrain, steel);
        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, axialN, mxNmm, myNmm, phi, maxTensionStrain,
            concreteForce, steelN, concreteMx, concreteMy, steelMx, steelMy,
            maxConcreteStrain, minConcreteStrain, maxSteelStrain, minSteelStrain,
            stateLabel);
    }

    private static string ClassifyAciStrainRegion(double maxTensionStrain, SteelMaterial steel)
    {
        double yieldStrain = steel.FyMpa / steel.EsMpa;
        if (maxTensionStrain <= yieldStrain) return "Compression controlled";
        if (maxTensionStrain >= yieldStrain + 0.003) return "Tension controlled";
        return "Transition";
    }

    private static (double Area, double CentroidX, double CentroidY) CalculatePolygonProperties(IReadOnlyList<Point> polygon)
    {
        if (polygon.Count < 3) return (0, 0, 0);
        double area = 0, mx = 0, my = 0;
        for (int i = 0; i < polygon.Count; i++)
        {
            var p1 = polygon[i];
            var p2 = polygon[(i + 1) % polygon.Count];
            double cross = p1.X * p2.Y - p2.X * p1.Y;
            area += cross;
            mx += (p1.X + p2.X) * cross;
            my += (p1.Y + p2.Y) * cross;
        }
        area /= 2.0;
        if (System.Math.Abs(area) < 1e-9) return (0, 0, 0);
        return (System.Math.Abs(area), mx / (6.0 * area), my / (6.0 * area));
    }

    private static IReadOnlyList<Point> ClipPolygon(IReadOnlyList<Point> subject, double nx, double ny, double projection)
    {
        var result = new List<Point>();
        if (subject.Count == 0) return result;
        var start = subject[^1];
        bool startInside = start.X * nx + start.Y * ny >= projection - 1e-9;
        foreach (var end in subject)
        {
            bool endInside = end.X * nx + end.Y * ny >= projection - 1e-9;
            if (endInside)
            {
                if (!startInside) result.Add(Intersect(start, end, nx, ny, projection));
                result.Add(end);
            }
            else if (startInside)
            {
                result.Add(Intersect(start, end, nx, ny, projection));
            }
            start = end;
            startInside = endInside;
        }
        return result;
    }

    private static Point Intersect(Point a, Point b, double nx, double ny, double projection)
    {
        double da = a.X * nx + a.Y * ny - projection;
        double db = b.X * nx + b.Y * ny - projection;
        double t = System.Math.Abs(da - db) < 1e-12 ? 0 : da / (da - db);
        return new Point(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
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

    private sealed record Point(double X, double Y);
}

