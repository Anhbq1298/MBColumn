using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using System.Globalization;

namespace MBColumn.Application.Services.ImportExport;

public sealed class DxfImportService : IDxfImportService
{
    private const double DuplicateTolerance = 1e-7;
    private const double CircularityToleranceRatio = 0.01;

    public IReadOnlyList<string> GetLayerNames(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            return [];
        }

        var pairs = ReadPairs(filePath);
        var layers = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < pairs.Count; i++)
        {
            if (pairs[i].Code == 8 || (pairs[i].Code == 2 && i > 0 && IsEntityStart(pairs[i - 1], "LAYER")))
            {
                string name = pairs[i].Value.Trim();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    layers.Add(name);
                }
            }
        }

        return layers.ToList();
    }

    public DxfSectionImportResult ImportSection(DxfSectionImportRequest request)
    {
        var result = new DxfSectionImportResult();
        ValidateRequest(request, result);
        if (result.Errors.Count > 0)
        {
            return result;
        }

        IReadOnlyList<DxfCodePair> pairs;
        try
        {
            pairs = ReadPairs(request.FilePath);
        }
        catch (Exception ex)
        {
            result.Errors.Add($"Unable to read DXF file: {ex.Message}");
            return result;
        }

        var entities = ParseEntities(pairs);
        var boundaryPolylines = entities
            .OfType<DxfPolylineEntity>()
            .Where(p => string.Equals(p.LayerName, request.BoundaryLayerName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        foreach (var open in boundaryPolylines.Where(p => !p.IsClosed))
        {
            result.Warnings.Add($"Ignored open polyline on boundary layer '{open.LayerName}'.");
        }

        var closedBoundaryPolylines = boundaryPolylines
            .Where(p => p.IsClosed)
            .Select(p => RemoveRepeatedClosingPoint(ScalePoints(p.Vertices, request.ScaleFactor)))
            .Where(p => p.Count > 0)
            .ToList();

        result.BoundaryPolylineCount = closedBoundaryPolylines.Count;
        result.BoundaryVertexCount = closedBoundaryPolylines.Sum(p => p.Count);

        if (closedBoundaryPolylines.Count == 0)
        {
            result.Errors.Add($"No closed polyline was found on boundary layer '{request.BoundaryLayerName}'.");
        }

        var rebarEntities = entities
            .Where(e => string.Equals(e.LayerName, request.RebarLayerName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        double? overrideRadius = request.OverrideRebarDiameterMm.HasValue
            ? request.OverrideRebarDiameterMm.Value / 2.0
            : null;

        var rebars = new List<DxfRebarImportItem>();
        foreach (var entity in rebarEntities)
        {
            switch (entity)
            {
                case DxfCircleEntity circle:
                    if (IsFinite(circle.Center.X) && IsFinite(circle.Center.Y) && (circle.Radius > 0.0 || overrideRadius.HasValue))
                    {
                        double radius = overrideRadius ?? circle.Radius * request.ScaleFactor;
                        var center = new Point2D(circle.Center.X * request.ScaleFactor, circle.Center.Y * request.ScaleFactor);
                        rebars.Add(new DxfRebarImportItem(center, radius, Math.PI * radius * radius));
                    }
                    else
                    {
                        result.Warnings.Add("Ignored a CIRCLE with invalid center or radius on the rebar layer.");
                    }
                    break;

                case DxfPolylineEntity polyline when polyline.IsClosed:
                    var scaled = RemoveRepeatedClosingPoint(ScalePoints(polyline.Vertices, request.ScaleFactor));
                    if (TryConvertCircularPolyline(scaled, out var item))
                    {
                        double radius = overrideRadius ?? item.Radius;
                        rebars.Add(new DxfRebarImportItem(item.Center, radius, Math.PI * radius * radius));
                    }
                    else
                    {
                        result.Warnings.Add("Ignored a closed polyline on the rebar layer because it is not approximately circular.");
                    }
                    break;

                default:
                    result.Warnings.Add($"Ignored non-circular {entity.EntityType} entity on rebar layer '{request.RebarLayerName}'.");
                    break;
            }
        }

        result.RebarCircleCount = rebars.Count;
        if (rebars.Count == 0)
        {
            result.Errors.Add($"No valid circular rebar entities were found on rebar layer '{request.RebarLayerName}'.");
        }

        if (result.Errors.Count > 0)
        {
            return result;
        }

        var boundary = closedBoundaryPolylines
            .OrderByDescending(PolygonGeometry.Area)
            .First();

        if (closedBoundaryPolylines.Count > 1)
        {
            result.Warnings.Add($"Found {closedBoundaryPolylines.Count} closed boundary polylines; the largest area polyline was used.");
        }

        boundary = PolygonGeometry.EnsureClockwise(boundary).ToList();
        ValidateGeometry(boundary, rebars, result);
        if (result.Errors.Count > 0)
        {
            return result;
        }

        result.Area = PolygonGeometry.Area(boundary);
        var shiftedBoundary = PolygonGeometry.MoveToCentroidOrigin(boundary, out var centroid);
        result.OriginalCentroidX = centroid.X;
        result.OriginalCentroidY = centroid.Y;

        result.BoundaryVertices.AddRange(shiftedBoundary);
        foreach (var rebar in rebars)
        {
            var shifted = new Point2D(rebar.Center.X - centroid.X, rebar.Center.Y - centroid.Y);
            result.Rebars.Add(new DxfRebarImportItem(shifted, rebar.Radius, rebar.AreaMm2));
        }

        return result;
    }

    private static void ValidateRequest(DxfSectionImportRequest request, DxfSectionImportResult result)
    {
        if (string.IsNullOrWhiteSpace(request.FilePath))
        {
            result.Errors.Add("Select a DXF file.");
        }
        else if (!File.Exists(request.FilePath))
        {
            result.Errors.Add("The selected DXF file does not exist.");
        }

        if (string.IsNullOrWhiteSpace(request.BoundaryLayerName))
        {
            result.Errors.Add("Select a boundary layer.");
        }

        if (string.IsNullOrWhiteSpace(request.RebarLayerName))
        {
            result.Errors.Add("Select a rebar layer.");
        }

        if (!double.IsFinite(request.ScaleFactor) || request.ScaleFactor <= 0.0)
        {
            result.Errors.Add("Scale factor must be a positive number.");
        }

        if (request.OverrideRebarDiameterMm.HasValue &&
            (!double.IsFinite(request.OverrideRebarDiameterMm.Value) || request.OverrideRebarDiameterMm.Value <= 0.0))
        {
            result.Errors.Add("Override rebar diameter must be a positive number.");
        }

        if (!string.IsNullOrWhiteSpace(request.BoundaryLayerName) &&
            string.Equals(request.BoundaryLayerName, request.RebarLayerName, StringComparison.OrdinalIgnoreCase))
        {
            result.Errors.Add("Boundary layer and rebar layer must be different.");
        }
    }

    private static void ValidateGeometry(
        IReadOnlyList<Point2D> boundary,
        IReadOnlyList<DxfRebarImportItem> rebars,
        DxfSectionImportResult result)
    {
        if (boundary.Count < 3)
        {
            result.Errors.Add("Boundary must have at least 3 unique vertices.");
        }

        int uniqueCount = 0;
        for (int i = 0; i < boundary.Count; i++)
        {
            bool duplicate = false;
            for (int j = 0; j < i; j++)
            {
                if (Distance(boundary[i], boundary[j]) < DuplicateTolerance)
                {
                    duplicate = true;
                    result.Errors.Add($"Boundary vertices {j + 1} and {i + 1} are duplicates.");
                    break;
                }
            }

            if (!duplicate)
            {
                uniqueCount++;
            }
        }

        if (uniqueCount < 3)
        {
            result.Errors.Add("Boundary must have at least 3 unique vertices.");
        }

        if (boundary.Any(p => !IsFinite(p.X) || !IsFinite(p.Y)))
        {
            result.Errors.Add("Boundary coordinates must be finite numbers.");
        }

        if (rebars.Any(r => !IsFinite(r.Center.X) || !IsFinite(r.Center.Y) || !IsFinite(r.Radius) || r.Radius <= 0.0))
        {
            result.Errors.Add("Rebar coordinates and radii must be finite positive numbers.");
        }

        if (PolygonGeometry.Area(boundary) <= 0.0)
        {
            result.Errors.Add("Boundary polygon area must be greater than zero.");
        }

        if (PolygonGeometry.IsSelfIntersecting(boundary))
        {
            result.Errors.Add("Boundary polygon must not be self-intersecting.");
        }

        for (int i = 0; i < rebars.Count; i++)
        {
            var center = rebars[i].Center;
            bool inside = PolygonGeometry.PointInPolygon(boundary, center.X, center.Y);
            double distance = PolygonGeometry.DistanceToBoundary(boundary, center.X, center.Y);
            if (!inside && distance > 1e-6)
            {
                result.Errors.Add($"Rebar circle {i + 1} center is outside the boundary polygon.");
            }
        }
    }

    private static IReadOnlyList<Point2D> ScalePoints(IReadOnlyList<Point2D> points, double scale)
        => points.Select(p => new Point2D(p.X * scale, p.Y * scale)).ToList();

    private static IReadOnlyList<Point2D> RemoveRepeatedClosingPoint(IReadOnlyList<Point2D> points)
    {
        var clean = points.Where(p => IsFinite(p.X) && IsFinite(p.Y)).ToList();
        if (clean.Count > 1 && Distance(clean[0], clean[^1]) < DuplicateTolerance)
        {
            clean.RemoveAt(clean.Count - 1);
        }

        return clean;
    }

    private static bool TryConvertCircularPolyline(IReadOnlyList<Point2D> vertices, out DxfRebarImportItem item)
    {
        item = new DxfRebarImportItem(default, 0.0, 0.0);
        if (vertices.Count < 6)
        {
            return false;
        }

        double cx = vertices.Average(p => p.X);
        double cy = vertices.Average(p => p.Y);
        var center = new Point2D(cx, cy);
        var radii = vertices.Select(p => Distance(p, center)).ToList();
        double radius = radii.Average();
        if (!IsFinite(radius) || radius <= 0.0)
        {
            return false;
        }

        double maxDeviation = radii.Max(r => Math.Abs(r - radius));
        double tolerance = Math.Max(radius * CircularityToleranceRatio, 1e-6);
        if (maxDeviation > tolerance)
        {
            return false;
        }

        item = new DxfRebarImportItem(center, radius, Math.PI * radius * radius);
        return true;
    }

    private static IReadOnlyList<DxfEntity> ParseEntities(IReadOnlyList<DxfCodePair> pairs)
    {
        var entities = new List<DxfEntity>();
        for (int i = 0; i < pairs.Count; i++)
        {
            if (pairs[i].Code != 0)
            {
                continue;
            }

            string type = pairs[i].Value.Trim().ToUpperInvariant();
            if (type == "LWPOLYLINE")
            {
                entities.Add(ParseLwPolyline(pairs, ref i));
            }
            else if (type == "POLYLINE")
            {
                entities.Add(ParsePolyline(pairs, ref i));
            }
            else if (type == "CIRCLE")
            {
                entities.Add(ParseCircle(pairs, ref i));
            }
            else
            {
                var entity = ParseGenericEntity(type, pairs, ref i);
                if (!string.IsNullOrWhiteSpace(entity.LayerName))
                {
                    entities.Add(entity);
                }
            }
        }

        return entities;
    }

    private static DxfPolylineEntity ParseLwPolyline(IReadOnlyList<DxfCodePair> pairs, ref int index)
    {
        string layer = "";
        int flags = 0;
        var vertices = new List<Point2D>();
        double? x = null;

        int i = index + 1;
        for (; i < pairs.Count && pairs[i].Code != 0; i++)
        {
            var pair = pairs[i];
            if (pair.Code == 8) layer = pair.Value.Trim();
            else if (pair.Code == 70) flags = ParseInt(pair.Value);
            else if (pair.Code == 10) x = ParseDouble(pair.Value);
            else if (pair.Code == 20 && x is double vx)
            {
                vertices.Add(new Point2D(vx, ParseDouble(pair.Value)));
                x = null;
            }
        }

        index = i - 1;
        return new DxfPolylineEntity(layer, "LWPOLYLINE", (flags & 1) == 1, vertices);
    }

    private static DxfPolylineEntity ParsePolyline(IReadOnlyList<DxfCodePair> pairs, ref int index)
    {
        string layer = "";
        int flags = 0;
        int i = index + 1;
        for (; i < pairs.Count; i++)
        {
            if (pairs[i].Code == 0) break;
            if (pairs[i].Code == 8) layer = pairs[i].Value.Trim();
            else if (pairs[i].Code == 70) flags = ParseInt(pairs[i].Value);
        }

        var vertices = new List<Point2D>();
        for (; i < pairs.Count; i++)
        {
            if (!IsEntityStart(pairs[i], "VERTEX"))
            {
                if (IsEntityStart(pairs[i], "SEQEND"))
                {
                    break;
                }

                if (pairs[i].Code == 0)
                {
                    i--;
                    break;
                }

                continue;
            }

            double? x = null;
            double? y = null;
            for (i++; i < pairs.Count && pairs[i].Code != 0; i++)
            {
                if (pairs[i].Code == 10) x = ParseDouble(pairs[i].Value);
                else if (pairs[i].Code == 20) y = ParseDouble(pairs[i].Value);
            }

            if (x is double vx && y is double vy)
            {
                vertices.Add(new Point2D(vx, vy));
            }

            i--;
        }

        index = i;
        return new DxfPolylineEntity(layer, "POLYLINE", (flags & 1) == 1, vertices);
    }

    private static DxfCircleEntity ParseCircle(IReadOnlyList<DxfCodePair> pairs, ref int index)
    {
        string layer = "";
        double x = double.NaN;
        double y = double.NaN;
        double radius = double.NaN;

        int i = index + 1;
        for (; i < pairs.Count && pairs[i].Code != 0; i++)
        {
            if (pairs[i].Code == 8) layer = pairs[i].Value.Trim();
            else if (pairs[i].Code == 10) x = ParseDouble(pairs[i].Value);
            else if (pairs[i].Code == 20) y = ParseDouble(pairs[i].Value);
            else if (pairs[i].Code == 40) radius = ParseDouble(pairs[i].Value);
        }

        index = i - 1;
        return new DxfCircleEntity(layer, "CIRCLE", new Point2D(x, y), radius);
    }

    private static DxfGenericEntity ParseGenericEntity(string entityType, IReadOnlyList<DxfCodePair> pairs, ref int index)
    {
        string layer = "";
        int i = index + 1;
        for (; i < pairs.Count && pairs[i].Code != 0; i++)
        {
            if (pairs[i].Code == 8)
            {
                layer = pairs[i].Value.Trim();
            }
        }

        index = i - 1;
        return new DxfGenericEntity(layer, entityType);
    }

    private static IReadOnlyList<DxfCodePair> ReadPairs(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var pairs = new List<DxfCodePair>(lines.Length / 2);
        for (int i = 0; i + 1 < lines.Length; i += 2)
        {
            if (!int.TryParse(lines[i].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int code))
            {
                continue;
            }

            pairs.Add(new DxfCodePair(code, lines[i + 1].Trim()));
        }

        return pairs;
    }

    private static bool IsEntityStart(DxfCodePair pair, string value)
        => pair.Code == 0 && string.Equals(pair.Value.Trim(), value, StringComparison.OrdinalIgnoreCase);

    private static double ParseDouble(string value)
        => double.TryParse(value.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double d) ? d : double.NaN;

    private static int ParseInt(string value)
        => int.TryParse(value.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int i) ? i : 0;

    private static bool IsFinite(double value)
        => !double.IsNaN(value) && !double.IsInfinity(value);

    private static double Distance(Point2D a, Point2D b)
    {
        double dx = a.X - b.X;
        double dy = a.Y - b.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private readonly record struct DxfCodePair(int Code, string Value);

    private abstract record DxfEntity(string LayerName, string EntityType);
    private sealed record DxfGenericEntity(string LayerName, string EntityType) : DxfEntity(LayerName, EntityType);
    private sealed record DxfPolylineEntity(string LayerName, string EntityType, bool IsClosed, IReadOnlyList<Point2D> Vertices)
        : DxfEntity(LayerName, EntityType);
    private sealed record DxfCircleEntity(string LayerName, string EntityType, Point2D Center, double Radius)
        : DxfEntity(LayerName, EntityType);
}
