using MBColumn.Domain.Entities;
using SMath = System.Math;

namespace MBColumn.Application.Services.Geometry;

// Polygon helpers used by the irregular-section validator and mapper.
// All routines operate on raw Point2D arrays in millimetres.
public static class PolygonGeometry
{
    public const double DefaultTolerance = 1e-9;

    public static double SignedArea(IReadOnlyList<Point2D> polygon)
    {
        if (polygon.Count < 3) return 0.0;
        double sum = 0.0;
        for (int i = 0; i < polygon.Count; i++)
        {
            var p1 = polygon[i];
            var p2 = polygon[(i + 1) % polygon.Count];
            sum += p1.X * p2.Y - p2.X * p1.Y;
        }
        return 0.5 * sum;
    }

    public static double Area(IReadOnlyList<Point2D> polygon) => SMath.Abs(SignedArea(polygon));

    public static Point2D Centroid(IReadOnlyList<Point2D> polygon)
    {
        double a = SignedArea(polygon);
        if (SMath.Abs(a) < DefaultTolerance)
        {
            double mx = 0.0;
            double my = 0.0;
            foreach (var p in polygon) { mx += p.X; my += p.Y; }
            return new Point2D(mx / polygon.Count, my / polygon.Count);
        }

        double cx = 0.0;
        double cy = 0.0;
        for (int i = 0; i < polygon.Count; i++)
        {
            var p1 = polygon[i];
            var p2 = polygon[(i + 1) % polygon.Count];
            double cross = p1.X * p2.Y - p2.X * p1.Y;
            cx += (p1.X + p2.X) * cross;
            cy += (p1.Y + p2.Y) * cross;
        }
        return new Point2D(cx / (6.0 * a), cy / (6.0 * a));
    }

    // Clockwise winding in a standard +X right, +Y up coordinate frame yields negative signed area.
    public static bool IsClockwise(IReadOnlyList<Point2D> polygon) => SignedArea(polygon) < 0.0;

    public static Rect2D BoundingBox(IReadOnlyList<Point2D> polygon)
    {
        if (polygon.Count == 0) return new Rect2D(0, 0, 0, 0);
        double minX = double.PositiveInfinity, minY = double.PositiveInfinity;
        double maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
        foreach (var p in polygon)
        {
            if (p.X < minX) minX = p.X;
            if (p.Y < minY) minY = p.Y;
            if (p.X > maxX) maxX = p.X;
            if (p.Y > maxY) maxY = p.Y;
        }
        return new Rect2D(minX, minY, maxX, maxY);
    }

    public static bool SegmentsIntersect(Point2D a, Point2D b, Point2D c, Point2D d, double tol = DefaultTolerance)
    {
        double d1 = Cross(c, d, a);
        double d2 = Cross(c, d, b);
        double d3 = Cross(a, b, c);
        double d4 = Cross(a, b, d);
        if (((d1 > tol && d2 < -tol) || (d1 < -tol && d2 > tol)) &&
            ((d3 > tol && d4 < -tol) || (d3 < -tol && d4 > tol)))
        {
            return true;
        }
        return false;
    }

    public static bool IsSelfIntersecting(IReadOnlyList<Point2D> polygon, double tol = DefaultTolerance)
    {
        int n = polygon.Count;
        if (n < 4) return false;
        for (int i = 0; i < n; i++)
        {
            var a = polygon[i];
            var b = polygon[(i + 1) % n];
            for (int j = i + 2; j < n; j++)
            {
                // Skip adjacent edges (i,i+1) and (n-1,0)
                if (i == 0 && j == n - 1) continue;
                var c = polygon[j];
                var d = polygon[(j + 1) % n];
                if (SegmentsIntersect(a, b, c, d, tol)) return true;
            }
        }
        return false;
    }

    // Ray-casting point-in-polygon test. Returns true if (px, py) is inside the polygon.
    public static bool PointInPolygon(IReadOnlyList<Point2D> polygon, double px, double py)
    {
        bool inside = false;
        int n = polygon.Count;
        for (int i = 0, j = n - 1; i < n; j = i++)
        {
            var pi = polygon[i];
            var pj = polygon[j];
            bool cross = ((pi.Y > py) != (pj.Y > py)) &&
                          (px < (pj.X - pi.X) * (py - pi.Y) / (pj.Y - pi.Y + 1e-300) + pi.X);
            if (cross) inside = !inside;
        }
        return inside;
    }

    public static double PointToSegmentDistance(double px, double py, Point2D a, Point2D b)
    {
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        double lenSq = dx * dx + dy * dy;
        if (lenSq < 1e-30)
        {
            double ddx = px - a.X;
            double ddy = py - a.Y;
            return SMath.Sqrt(ddx * ddx + ddy * ddy);
        }
        double t = ((px - a.X) * dx + (py - a.Y) * dy) / lenSq;
        t = SMath.Clamp(t, 0.0, 1.0);
        double cx = a.X + t * dx;
        double cy = a.Y + t * dy;
        double ex = px - cx;
        double ey = py - cy;
        return SMath.Sqrt(ex * ex + ey * ey);
    }

    public static double DistanceToBoundary(IReadOnlyList<Point2D> polygon, double px, double py)
    {
        double min = double.PositiveInfinity;
        int n = polygon.Count;
        for (int i = 0; i < n; i++)
        {
            var a = polygon[i];
            var b = polygon[(i + 1) % n];
            double d = PointToSegmentDistance(px, py, a, b);
            if (d < min) min = d;
        }
        return min;
    }

    private static double Cross(Point2D a, Point2D b, Point2D c)
        => (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);

    public static IReadOnlyList<Point2D> OffsetPolygon(IReadOnlyList<Point2D> polygon, double offset)
    {
        if (polygon.Count < 3) return [.. polygon];
        if (SMath.Abs(offset) < 1e-6) return [.. polygon];

        bool isClockwise = IsClockwise(polygon);
        int n = polygon.Count;
        var offsetPoints = new List<Point2D>(n);

        for (int i = 0; i < n; i++)
        {
            int prev = (i - 1 + n) % n;
            int next = (i + 1) % n;

            var pPrev = polygon[prev];
            var pI = polygon[i];
            var pNext = polygon[next];

            // Unit vector of edge (prev -> i)
            double dx1 = pI.X - pPrev.X;
            double dy1 = pI.Y - pPrev.Y;
            double len1 = SMath.Sqrt(dx1 * dx1 + dy1 * dy1);
            if (len1 > 1e-9) { dx1 /= len1; dy1 /= len1; }

            // Unit vector of edge (i -> next)
            double dx2 = pNext.X - pI.X;
            double dy2 = pNext.Y - pI.Y;
            double len2 = SMath.Sqrt(dx2 * dx2 + dy2 * dy2);
            if (len2 > 1e-9) { dx2 /= len2; dy2 /= len2; }

            // Inward normal vectors (assuming positive offset means inward)
            double nx1, ny1, nx2, ny2;
            if (isClockwise)
            {
                nx1 = dy1; ny1 = -dx1;
                nx2 = dy2; ny2 = -dx2;
            }
            else
            {
                nx1 = -dy1; ny1 = dx1;
                nx2 = -dy2; ny2 = dx2;
            }

            // Offset lines
            // L1: P1 + t * D1
            double p1x = pPrev.X + offset * nx1;
            double p1y = pPrev.Y + offset * ny1;
            // L2: P2 + s * D2
            double p2x = pI.X + offset * nx2;
            double p2y = pI.Y + offset * ny2;

            double cross = dx1 * dy2 - dy1 * dx2;
            if (SMath.Abs(cross) < 1e-6)
            {
                // Parallel edges, no clear intersection, just use offset point
                offsetPoints.Add(new Point2D(pI.X + offset * nx1, pI.Y + offset * ny1));
            }
            else
            {
                double t = ((p2x - p1x) * dy2 - (p2y - p1y) * dx2) / cross;
                offsetPoints.Add(new Point2D(p1x + t * dx1, p1y + t * dy1));
            }
        }

        return offsetPoints;
    }
}
