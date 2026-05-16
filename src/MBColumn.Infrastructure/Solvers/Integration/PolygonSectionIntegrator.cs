using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers.Integration;

public sealed class PolygonSectionIntegrator : ISectionIntegrator
{
    private readonly Dictionary<string, Point[]> boundaryCache = new();

    public SectionIntegrationResult Integrate(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IDesignCodeService designCode,
        NeutralAxisState neutralAxis,
        SolverSettings settings)
    {
        var boundary = GetBoundary(section, settings);
        double nx = neutralAxis.CompressionNormal.X;
        double ny = neutralAxis.CompressionNormal.Y;
        double beta = designCode.Beta1(concrete.FcMpa);
        double stressBlockProjection = ProjectExtreme(boundary, nx, ny) - beta * neutralAxis.NeutralAxisDepth;
        double concreteStress = designCode.ConcreteStressBlockFactor
            * designCode.ConcreteEffectiveStrengthFactor(concrete.FcMpa)
            * concrete.FcMpa;

        var compressed = ClipPolygon(boundary, nx, ny, stressBlockProjection);
        var props = CalculatePolygonProperties(compressed);

        double concreteN = concreteStress * props.Area;
        double concreteMx = -concreteN * props.CentroidY;
        double concreteMy = concreteN * props.CentroidX;
        var steelResult = FiberSectionIntegrator.IntegrateSteel(
            section,
            steel,
            designCode,
            concrete,
            neutralAxis,
            stressBlockProjection,
            designCode.ConcretePeakStrain(concrete.FcMpa),
            designCode.ConcreteParabolicExponent(concrete.FcMpa),
            concreteStress);

        var concreteStrains = boundary
            .Select(p => neutralAxis.ExtremeCompressionStrain * ((p.X * nx + p.Y * ny) - neutralAxis.NeutralAxisOffset) / neutralAxis.NeutralAxisDepth)
            .ToList();

        return new SectionIntegrationResult
        {
            NominalP = concreteN + steelResult.N,
            NominalMx = concreteMx + steelResult.Mx,
            NominalMy = concreteMy + steelResult.My,
            ConcreteForce = concreteN,
            SteelForce = steelResult.N,
            ConcreteMx = concreteMx,
            ConcreteMy = concreteMy,
            SteelMx = steelResult.Mx,
            SteelMy = steelResult.My,
            MaxTensionSteelStrain = steelResult.MaxTensionStrain,
            MaxConcreteStrain = concreteStrains.Count == 0 ? 0.0 : concreteStrains.Max(),
            MinConcreteStrain = concreteStrains.Count == 0 ? 0.0 : concreteStrains.Min(),
            MaxSteelStrain = double.IsInfinity(steelResult.MaxStrain) ? 0.0 : steelResult.MaxStrain,
            MinSteelStrain = double.IsInfinity(steelResult.MinStrain) ? 0.0 : steelResult.MinStrain,
            HasConcreteCompression = props.Area > 1e-9,
            IsValid = props.Area >= 0.0
        };
    }

    private Point[] GetBoundary(ColumnSection section, SolverSettings settings)
    {
        if (section is IrregularSection irregular)
        {
            // Irregular polygons are unique per section instance — cache by identity hash.
            string irregularKey = $"I:{irregular.GetHashCode():X}:{irregular.BoundaryPoints.Count}";
            if (boundaryCache.TryGetValue(irregularKey, out var cachedIrregular))
            {
                return cachedIrregular;
            }
            var arr = irregular.BoundaryPoints.Select(p => new Point(p.X, p.Y)).ToArray();
            boundaryCache[irregularKey] = arr;
            return arr;
        }

        string key = section is CircularSection circular
            ? $"C:{circular.DiameterMm:G17}:{settings.CirclePolygonSegmentCount}"
            : $"R:{section.WidthMm:G17}:{section.HeightMm:G17}";

        if (boundaryCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        Point[] boundary = section is CircularSection circle
            ? BuildCircleBoundary(circle, settings.CirclePolygonSegmentCount)
            :
            [
                new Point(-section.WidthMm / 2.0, -section.HeightMm / 2.0),
                new Point( section.WidthMm / 2.0, -section.HeightMm / 2.0),
                new Point( section.WidthMm / 2.0,  section.HeightMm / 2.0),
                new Point(-section.WidthMm / 2.0,  section.HeightMm / 2.0)
            ];
        boundaryCache[key] = boundary;
        return boundary;
    }

    private static Point[] BuildCircleBoundary(CircularSection section, int segments)
    {
        int count = SMath.Max(32, segments);
        var points = new Point[count];
        for (int i = 0; i < count; i++)
        {
            double theta = i * 2.0 * SMath.PI / count;
            points[i] = new Point(section.RadiusMm * SMath.Cos(theta), section.RadiusMm * SMath.Sin(theta));
        }

        return points;
    }

    private static double ProjectExtreme(IReadOnlyList<Point> boundary, double nx, double ny)
        => boundary.Max(p => p.X * nx + p.Y * ny);

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
        double t = SMath.Abs(da - db) < 1e-12 ? 0.0 : da / (da - db);
        return new Point(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
    }

    private static (double Area, double CentroidX, double CentroidY) CalculatePolygonProperties(IReadOnlyList<Point> polygon)
    {
        if (polygon.Count < 3) return (0.0, 0.0, 0.0);
        double area = 0.0;
        double cx = 0.0;
        double cy = 0.0;
        for (int i = 0; i < polygon.Count; i++)
        {
            var p1 = polygon[i];
            var p2 = polygon[(i + 1) % polygon.Count];
            double cross = p1.X * p2.Y - p2.X * p1.Y;
            area += cross;
            cx += (p1.X + p2.X) * cross;
            cy += (p1.Y + p2.Y) * cross;
        }

        area /= 2.0;
        if (SMath.Abs(area) < 1e-9) return (0.0, 0.0, 0.0);
        return (SMath.Abs(area), cx / (6.0 * area), cy / (6.0 * area));
    }

    private readonly record struct Point(double X, double Y);
}
