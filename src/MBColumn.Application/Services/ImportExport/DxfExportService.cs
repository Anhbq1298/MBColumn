using netDxf;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Tables;
using netDxf.Units;
using System.Globalization;
using System.Text;

namespace MBColumn.Application.Services.ImportExport;

public sealed class DxfExportService
{
    private const string DefaultBoundaryLayer = "BOUNDARY";
    private const string DefaultRebarLayer = "REBAR";
    private const string DefaultGuideLayer = "GUIDE";

    public DxfExportResult Export(
        string filePath,
        IReadOnlyList<(double X, double Y)> boundaryPoints,
        IReadOnlyList<(double X, double Y, double AreaMm2)> rebars,
        IReadOnlyList<(double StartX, double StartY, double EndX, double EndY, string? LayerName)>? guideLines = null)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("A target DXF file path is required.", nameof(filePath));

        var warnings = new List<string>();
        var validBoundary = ValidateBoundary(boundaryPoints, warnings);
        var validRebars = ValidateRebars(rebars, warnings);
        var validGuideLines = ValidateGuideLines(guideLines ?? [], warnings);

        if (validBoundary.Count < 3)
            throw new ArgumentException("DXF export requires at least 3 valid boundary points.", nameof(boundaryPoints));

        var document = CreateDocument(validBoundary, validRebars, validGuideLines);

        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(filePath))!);
        using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            document.Save(stream, false);
            stream.Flush(true);
        }

        EnsureAsciiFriendlyNumberFormatting(filePath);

        return new DxfExportResult(
            validBoundary.Count,
            validRebars.Count,
            validGuideLines.Count,
            warnings);
    }

    private static DxfDocument CreateDocument(
        IReadOnlyList<(double X, double Y)> boundary,
        IReadOnlyList<ValidatedRebar> rebars,
        IReadOnlyList<ValidatedLine> guideLines)
    {
        var document = new DxfDocument(DxfVersion.AutoCad2000);
        document.DrawingVariables.InsUnits = DrawingUnits.Millimeters;
        document.DrawingVariables.LUnits = LinearUnitType.Decimal;
        document.DrawingVariables.AUnits = AngleUnitType.DecimalDegrees;

        var boundaryLayer = CreateLayer(DefaultBoundaryLayer, AciColor.Blue);
        var rebarLayer = CreateLayer(DefaultRebarLayer, AciColor.Red);
        var guideLayer = CreateLayer(DefaultGuideLayer, AciColor.DarkGray);

        var polyline = new Polyline2D(boundary.Select(p => new netDxf.Vector2(p.X, p.Y)), true)
        {
            Layer = boundaryLayer,
            Linetype = Linetype.Continuous,
            Color = AciColor.ByLayer
        };
        document.Entities.Add(polyline);

        foreach (var rebar in rebars)
        {
            var circle = new Circle(new netDxf.Vector2(rebar.X, rebar.Y), rebar.Radius)
            {
                Layer = rebarLayer,
                Linetype = Linetype.Continuous,
                Color = AciColor.ByLayer
            };
            document.Entities.Add(circle);
        }

        foreach (var line in guideLines)
        {
            var entity = new Line(
                new netDxf.Vector2(line.StartX, line.StartY),
                new netDxf.Vector2(line.EndX, line.EndY))
            {
                Layer = CreateLayer(line.LayerName, AciColor.DarkGray),
                Linetype = Linetype.Continuous,
                Color = AciColor.ByLayer
            };
            document.Entities.Add(entity);
        }

        return document;
    }

    private static Layer CreateLayer(string rawName, AciColor color)
    {
        var name = SanitizeLayerName(rawName);
        return new Layer(name)
        {
            Color = color,
            Linetype = Linetype.Continuous
        };
    }

    private static List<(double X, double Y)> ValidateBoundary(
        IReadOnlyList<(double X, double Y)> boundaryPoints,
        List<string> warnings)
    {
        if (boundaryPoints is null || boundaryPoints.Count == 0)
            throw new ArgumentException("DXF export requires boundary points.", nameof(boundaryPoints));

        var valid = new List<(double X, double Y)>();
        for (int i = 0; i < boundaryPoints.Count; i++)
        {
            var point = boundaryPoints[i];
            if (!IsFinite(point.X) || !IsFinite(point.Y))
            {
                warnings.Add($"Skipped boundary point {i + 1} because it contains NaN or Infinity.");
                continue;
            }

            if (valid.Count > 0 && SamePoint(valid[^1], point))
            {
                warnings.Add($"Skipped duplicate consecutive boundary point {i + 1}.");
                continue;
            }

            valid.Add((point.X, point.Y));
        }

        if (valid.Count > 1 && SamePoint(valid[0], valid[^1]))
        {
            warnings.Add("Removed duplicated closing boundary point because the DXF polyline is explicitly marked closed.");
            valid.RemoveAt(valid.Count - 1);
        }

        if (valid.Count < 3)
        {
            throw new ArgumentException("DXF export requires at least 3 valid boundary points after validation.", nameof(boundaryPoints));
        }

        return valid;
    }

    private static List<ValidatedRebar> ValidateRebars(
        IReadOnlyList<(double X, double Y, double AreaMm2)> rebars,
        List<string> warnings)
    {
        var valid = new List<ValidatedRebar>();
        for (int i = 0; i < rebars.Count; i++)
        {
            var rebar = rebars[i];
            if (!IsFinite(rebar.X) || !IsFinite(rebar.Y) || !IsFinite(rebar.AreaMm2))
            {
                warnings.Add($"Skipped rebar {i + 1} because it contains NaN or Infinity.");
                continue;
            }

            if (rebar.AreaMm2 <= 0)
            {
                warnings.Add($"Skipped rebar {i + 1} because its area is not positive.");
                continue;
            }

            double radius = Math.Sqrt(rebar.AreaMm2 / Math.PI);
            if (!IsFinite(radius) || radius <= 0)
            {
                warnings.Add($"Skipped rebar {i + 1} because its radius is invalid.");
                continue;
            }

            valid.Add(new ValidatedRebar(rebar.X, rebar.Y, radius));
        }

        return valid;
    }

    private static List<ValidatedLine> ValidateGuideLines(
        IReadOnlyList<(double StartX, double StartY, double EndX, double EndY, string? LayerName)> guideLines,
        List<string> warnings)
    {
        var valid = new List<ValidatedLine>();
        for (int i = 0; i < guideLines.Count; i++)
        {
            var line = guideLines[i];
            if (!IsFinite(line.StartX) || !IsFinite(line.StartY) || !IsFinite(line.EndX) || !IsFinite(line.EndY))
            {
                warnings.Add($"Skipped guide line {i + 1} because it contains NaN or Infinity.");
                continue;
            }

            if (SamePoint((line.StartX, line.StartY), (line.EndX, line.EndY)))
            {
                warnings.Add($"Skipped guide line {i + 1} because start and end points are identical.");
                continue;
            }

            valid.Add(new ValidatedLine(
                line.StartX,
                line.StartY,
                line.EndX,
                line.EndY,
                SanitizeLayerName(line.LayerName)));
        }

        return valid;
    }

    private static void EnsureAsciiFriendlyNumberFormatting(string filePath)
    {
        var lines = File.ReadAllLines(filePath, Encoding.ASCII);
        using var writer = new StreamWriter(filePath, false, new UTF8Encoding(false));
        foreach (var line in lines)
        {
            writer.WriteLine(line);
        }
    }

    private static string SanitizeLayerName(string? layerName)
    {
        if (string.IsNullOrWhiteSpace(layerName))
            return "0";

        const string invalidChars = "<>/\\\":;?*|=";
        var sanitized = new string(layerName
            .Trim()
            .Select(ch => invalidChars.Contains(ch) ? '_' : ch)
            .ToArray());

        return string.IsNullOrWhiteSpace(sanitized) ? "0" : sanitized;
    }

    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);

    private static bool SamePoint((double X, double Y) a, (double X, double Y) b)
        => Math.Abs(a.X - b.X) < 1e-9 && Math.Abs(a.Y - b.Y) < 1e-9;

    private readonly record struct ValidatedRebar(double X, double Y, double Radius);
    private readonly record struct ValidatedLine(double StartX, double StartY, double EndX, double EndY, string LayerName);
}

public sealed record DxfExportResult(
    int BoundaryVertexCount,
    int RebarCount,
    int GuideLineCount,
    IReadOnlyList<string> Warnings)
{
    public bool HasWarnings => Warnings.Count > 0;
}
