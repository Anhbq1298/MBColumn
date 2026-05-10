using ColumnDesigner.Application.DTOs;

namespace ColumnDesigner.Application.Services;

public sealed class CompressionZonePolygonBuilder
{
    private const double Tolerance = 1e-9;

    public IReadOnlyList<InsetPointDto> ClipByNeutralAxis(
        IReadOnlyList<InsetPointDto> sectionBoundary,
        double normalX,
        double normalY,
        double neutralAxisProjection)
        => ClipByNeutralAxis(sectionBoundary, normalX, normalY, neutralAxisProjection, keepCompressionSide: true);

    public IReadOnlyList<InsetPointDto> ClipTensionSideByNeutralAxis(
        IReadOnlyList<InsetPointDto> sectionBoundary,
        double normalX,
        double normalY,
        double neutralAxisProjection)
        => ClipByNeutralAxis(sectionBoundary, normalX, normalY, neutralAxisProjection, keepCompressionSide: false);

    private static IReadOnlyList<InsetPointDto> ClipByNeutralAxis(
        IReadOnlyList<InsetPointDto> sectionBoundary,
        double normalX,
        double normalY,
        double neutralAxisProjection,
        bool keepCompressionSide)
    {
        if (sectionBoundary.Count < 3)
        {
            return [];
        }

        var input = sectionBoundary.ToList();
        var result = new List<InsetPointDto>();
        var start = input[^1];
        var startInside = IsInside(start, normalX, normalY, neutralAxisProjection, keepCompressionSide);

        foreach (var end in input)
        {
            var endInside = IsInside(end, normalX, normalY, neutralAxisProjection, keepCompressionSide);
            if (endInside)
            {
                if (!startInside)
                {
                    result.Add(Intersection(start, end, normalX, normalY, neutralAxisProjection));
                }

                result.Add(end);
            }
            else if (startInside)
            {
                result.Add(Intersection(start, end, normalX, normalY, neutralAxisProjection));
            }

            start = end;
            startInside = endInside;
        }

        return result;
    }

    private static bool IsInside(InsetPointDto point, double normalX, double normalY, double projection, bool keepCompressionSide)
    {
        double distance = point.X * normalX + point.Y * normalY - projection;
        return keepCompressionSide
            ? distance >= -Tolerance
            : distance <= Tolerance;
    }

    private static InsetPointDto Intersection(InsetPointDto a, InsetPointDto b, double normalX, double normalY, double projection)
    {
        double da = a.X * normalX + a.Y * normalY - projection;
        double db = b.X * normalX + b.Y * normalY - projection;
        double denominator = da - db;
        double t = Math.Abs(denominator) <= Tolerance ? 0.0 : da / denominator;
        t = Math.Clamp(t, 0.0, 1.0);
        return new InsetPointDto(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
    }
}
