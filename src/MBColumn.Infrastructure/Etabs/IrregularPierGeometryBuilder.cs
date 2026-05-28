using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Buffer;
using NetTopologySuite.Operation.Union;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

// Converts a list of ETABS wall-shell centerline segments into one (or more)
// clockwise boundary polygon(s) for MBColumn irregular section import.
//
// This is the C# equivalent of the Python prototype's Shapely-based geometry flow:
//   centerline + thickness → wall body (Buffer)
//   joint node patches (orthogonal or convex-hull approximation)
//   → unary union → clockwise polyline export
//
// Joint logic is preview-grade (see etabs_pier_centerline_preview.py).
// Replace with offset-line intersection solver for production-grade corners if needed.
public sealed class IrregularPierGeometryBuilder : IIrregularPierGeometryBuilder
{
    private static readonly GeometryFactory Factory =
        new GeometryFactory(new PrecisionModel(PrecisionModels.Floating));

    private const double SnapToleranceMm = 0.01;
    private const double OrthogonalDotThreshold = 0.20;

    public EtabsIrregularBoundaryDto BuildBoundary(IReadOnlyList<EtabsPierShellSegmentDto> segments)
    {
        if (segments.Count == 0)
        {
            return new EtabsIrregularBoundaryDto
            {
                WarningMessage = "No shell segments provided."
            };
        }

        var workingSegments = RotateSegmentsToPierAxes(segments);
        var geoms = new List<Geometry>(workingSegments.Count * 2);

        foreach (var seg in workingSegments)
        {
            var body = BuildSegmentBody(seg);
            if (!body.IsEmpty)
                geoms.Add(body);
        }

        var nodeMap = BuildNodeConnections(workingSegments);
        foreach (var (x, y, connected) in nodeMap)
        {
            if (connected.Count >= 2)
            {
                var patch = BuildJointPatch(x, y, connected);
                if (patch is not null && !patch.IsEmpty)
                    geoms.Add(patch);
            }
        }

        if (geoms.Count == 0)
        {
            return new EtabsIrregularBoundaryDto
            {
                PierLabel = segments[0].PierLabel,
                StoryName = segments[0].StoryName,
                WarningMessage = "Geometry union produced no output."
            };
        }

        var raw   = UnaryUnionOp.Union(geoms);
        var union = NetTopologySuite.Simplify.DouglasPeuckerSimplifier.Simplify(raw, SnapToleranceMm);
        var (outerPolylines, openingPolylines) = ExportPolylines(union);

        // Largest polygon first so callers can pick [0] without extra sorting
        var sortedPolylines = outerPolylines
            .OrderByDescending(p => SMath.Abs(PolygonGeometry.SignedArea(p)))
            .ToList<IReadOnlyList<Point2D>>();

        string? warning = null;
        if (sortedPolylines.Count > 1)
            warning = $"{sortedPolylines.Count} disconnected shell groups found for pier '{segments[0].PierLabel}'.";

        return new EtabsIrregularBoundaryDto
        {
            ClockwisePolylines = sortedPolylines,
            OpeningPolylines   = openingPolylines,
            PierLabel = segments[0].PierLabel,
            StoryName = segments[0].StoryName,
            SourceShellNames = segments.Select(s => s.ShellName).ToList(),
            SourceSectionProperties = segments.Select(s => s.SectionProperty).Distinct().ToList(),
            WarningMessage = warning
        };
    }

    // -------------------------------------------------------------------
    // Wall body: buffer the centerline segment by half-thickness (flat cap)
    // Equivalent to Python: LineString([start, end]).buffer(t/2, cap_style=2, join_style=2)
    // -------------------------------------------------------------------

    private static Geometry BuildSegmentBody(EtabsPierShellSegmentDto seg)
    {
        var line = Factory.CreateLineString([
            new Coordinate(seg.Start.X, seg.Start.Y),
            new Coordinate(seg.End.X, seg.End.Y)
        ]);

        var bufParams = new BufferParameters
        {
            EndCapStyle = EndCapStyle.Flat,
            JoinStyle = JoinStyle.Mitre
        };

        return BufferOp.Buffer(line, seg.ThicknessMm / 2.0, bufParams);
    }

    private static IReadOnlyList<EtabsPierShellSegmentDto> RotateSegmentsToPierAxes(
        IReadOnlyList<EtabsPierShellSegmentDto> segments)
    {
        if (!segments.Any(s => double.IsFinite(s.AxisAngleDegrees) && SMath.Abs(s.AxisAngleDegrees) > 1e-9))
            return segments;

        return [.. segments.Select(RotateSegmentClockwise)];
    }

    private static EtabsPierShellSegmentDto RotateSegmentClockwise(EtabsPierShellSegmentDto seg)
    {
        if (!double.IsFinite(seg.AxisAngleDegrees) || SMath.Abs(seg.AxisAngleDegrees) <= 1e-9)
            return seg;

        var radians = seg.AxisAngleDegrees * SMath.PI / 180.0;
        var cos = SMath.Cos(radians);
        var sin = SMath.Sin(radians);

        return seg with
        {
            Start = RotatePointClockwise(seg.Start, cos, sin),
            End = RotatePointClockwise(seg.End, cos, sin)
        };
    }

    private static (double X, double Y) RotatePointClockwise((double X, double Y) point, double cos, double sin)
        => (point.X * cos + point.Y * sin, -point.X * sin + point.Y * cos);

    // -------------------------------------------------------------------
    // Joint patch: fills the gap at nodes where ≥2 segments meet.
    // For near-orthogonal L joints, use an axis-aligned rectangle.
    // For all other cases (T, cross, acute), use a convex-hull approximation.
    // -------------------------------------------------------------------

    private static Geometry? BuildJointPatch(
        double x0, double y0, List<EtabsPierShellSegmentDto> connected)
    {
        if (connected.Count == 2)
        {
            var u1 = UnitVectorFromNode(connected[0], x0, y0);
            var u2 = UnitVectorFromNode(connected[1], x0, y0);
            double dot = SMath.Abs(u1.X * u2.X + u1.Y * u2.Y);

            if (dot < OrthogonalDotThreshold)
            {
                double xHalf = 0, yHalf = 0;
                foreach (var s in connected)
                {
                    var u = UnitVectorFromNode(s, x0, y0);
                    double half = s.ThicknessMm / 2.0;
                    if (SMath.Abs(u.Y) >= SMath.Abs(u.X)) xHalf = SMath.Max(xHalf, half);
                    if (SMath.Abs(u.X) > SMath.Abs(u.Y)) yHalf = SMath.Max(yHalf, half);
                }

                if (xHalf > 0 && yHalf > 0)
                {
                    var ring = Factory.CreateLinearRing([
                        new Coordinate(x0 - xHalf, y0 - yHalf),
                        new Coordinate(x0 + xHalf, y0 - yHalf),
                        new Coordinate(x0 + xHalf, y0 + yHalf),
                        new Coordinate(x0 - xHalf, y0 + yHalf),
                        new Coordinate(x0 - xHalf, y0 - yHalf)
                    ]);
                    return Factory.CreatePolygon(ring);
                }
            }
        }

        // General case: convex hull of sample points around the node
        var sampleCoords = new List<Coordinate> { new Coordinate(x0, y0) };
        foreach (var s in connected)
        {
            var u = UnitVectorFromNode(s, x0, y0);
            double nx = -u.Y, ny = u.X;
            double half = s.ThicknessMm / 2.0;
            double segLen = SMath.Sqrt(
                (s.End.X - s.Start.X) * (s.End.X - s.Start.X) +
                (s.End.Y - s.Start.Y) * (s.End.Y - s.Start.Y));
            // Cap forward at segment length: a patch that extends beyond the segment's
            // far end produces an extra stub outside the buffer body.
            double forward = SMath.Min(SMath.Min(SMath.Max(s.ThicknessMm, 1.0), 500.0), segLen);

            sampleCoords.Add(new Coordinate(x0 + nx * half, y0 + ny * half));
            sampleCoords.Add(new Coordinate(x0 - nx * half, y0 - ny * half));
            sampleCoords.Add(new Coordinate(x0 + u.X * forward + nx * half, y0 + u.Y * forward + ny * half));
            sampleCoords.Add(new Coordinate(x0 + u.X * forward - nx * half, y0 + u.Y * forward - ny * half));
        }

        var multiPoint = Factory.CreateMultiPointFromCoords([.. sampleCoords]);
        return multiPoint.ConvexHull();
    }

    // -------------------------------------------------------------------
    // Node connection map: group segments by their shared endpoint (snapped)
    // -------------------------------------------------------------------

    private static List<(double X, double Y, List<EtabsPierShellSegmentDto> Segments)> BuildNodeConnections(
        IReadOnlyList<EtabsPierShellSegmentDto> segments)
    {
        var map = new Dictionary<string, (double X, double Y, List<EtabsPierShellSegmentDto>)>();

        foreach (var seg in segments)
        {
            foreach (var pt in new[] { seg.Start, seg.End })
            {
                var key = SnapKey(pt.X, pt.Y);
                if (map.TryGetValue(key, out var entry))
                {
                    entry.Item3.Add(seg);
                }
                else
                {
                    map[key] = (pt.X, pt.Y, [seg]);
                }
            }
        }

        return [.. map.Values];
    }

    // -------------------------------------------------------------------
    // Export NTS union result as clockwise outer polylines + CCW opening polylines.
    // MBColumn uses: clockwise = negative signed area (standard frame).
    // NTS exterior rings are CCW by default → reverse to CW for outer boundary.
    // Interior rings (holes detected by NTS) → kept CCW, represent voids/openings.
    // All rings are translated to the same centroid origin as the outer polygon.
    // -------------------------------------------------------------------

    private static (List<IReadOnlyList<Point2D>> Outer, List<IReadOnlyList<Point2D>> Openings)
        ExportPolylines(Geometry geometry)
    {
        IEnumerable<Geometry> polys = geometry switch
        {
            MultiPolygon mp => mp.Geometries,
            Polygon => [geometry],
            _ => []
        };

        var outer    = new List<IReadOnlyList<Point2D>>();
        var openings = new List<IReadOnlyList<Point2D>>();

        foreach (var g in polys)
        {
            if (g is not Polygon poly || poly.IsEmpty) continue;

            // Exterior ring → clockwise, centroid origin
            var extCoords = poly.ExteriorRing.Coordinates;
            var extPts = extCoords
                .Take(extCoords.Length - 1)
                .Select(c => new Point2D(c.X, c.Y))
                .ToList();

            var cw = PolygonGeometry.EnsureClockwise(extPts);
            var centered = PolygonGeometry.MoveToCentroidOrigin(cw, out var centroid);
            outer.Add(centered);

            // Interior rings → voids/openings, shifted by the same centroid
            for (int i = 0; i < poly.NumInteriorRings; i++)
            {
                var holeCoords = poly.GetInteriorRingN(i).Coordinates;
                var holePts = holeCoords
                    .Take(holeCoords.Length - 1)
                    .Select(c => new Point2D(c.X - centroid.X, c.Y - centroid.Y))
                    .ToList();
                openings.Add(holePts);
            }
        }

        return (outer, openings);
    }

    // -------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------

    private static (double X, double Y) UnitVectorFromNode(
        EtabsPierShellSegmentDto seg, double nodeX, double nodeY)
    {
        // Use the same snap-key comparison as BuildNodeConnections so that endpoints
        // within SnapToleranceMm of the node are correctly identified as being at it.
        // A raw squared-distance threshold (formerly 1e-9) was tighter than the snap
        // tolerance (0.01 mm → 1e-4 mm²), which caused reversed unit vectors when
        // two segments shared a snapped node but their actual coordinates differed by
        // a few microns — producing a spurious "leg" in the joint-patch convex hull.
        bool startIsNode = SnapKey(seg.Start.X, seg.Start.Y) == SnapKey(nodeX, nodeY);

        (double x0, double y0) = startIsNode ? seg.Start : seg.End;
        (double x1, double y1) = startIsNode ? seg.End : seg.Start;

        double dx = x1 - x0;
        double dy = y1 - y0;
        double len = SMath.Sqrt(dx * dx + dy * dy);

        return len <= 1e-9 ? (1.0, 0.0) : (dx / len, dy / len);
    }

    private static string SnapKey(double x, double y)
    {
        var xi = (long)SMath.Round(x / SnapToleranceMm);
        var yi = (long)SMath.Round(y / SnapToleranceMm);
        return $"{xi},{yi}";
    }
}
