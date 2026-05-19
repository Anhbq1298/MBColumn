using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services;

public sealed class PmChartInsetBuilderService(CompressionZonePolygonBuilder compressionZoneBuilder)
{
    private const double Tolerance = 1e-9;
    private const double AreaToleranceRatio = 1e-6;

    public PmChartInsetBuilderService()
        : this(new CompressionZonePolygonBuilder())
    {
    }

    public PmChartInsetFigureDto? Build(
        double sectionWidthMm,
        double sectionHeightMm,
        double coverMm,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates,
        PmChartInsetSelectedStateDto? selectedState,
        double fallbackThetaDegrees,
        SectionShapeType sectionShape = SectionShapeType.Rectangular,
        IReadOnlyList<InsetPointDto>? irregularBoundaryPoints = null)
    {
        if (!IsFinite(sectionWidthMm) || !IsFinite(sectionHeightMm) || sectionWidthMm <= 0 || sectionHeightMm <= 0)
        {
            return null;
        }

        double hx = sectionWidthMm / 2.0;
        double hy = sectionHeightMm / 2.0;
        InsetPointDto[] sectionBoundary;
        IReadOnlyList<InsetPointDto> coverBoundary;

        if (sectionShape == SectionShapeType.Circular)
        {
            sectionBoundary = BuildCirclePolygon(hx, 64);
            coverBoundary = BuildCircleCoverBoundary(hx, coverMm);
        }
        else if (sectionShape == SectionShapeType.Irregular && irregularBoundaryPoints is { Count: >= 3 })
        {
            sectionBoundary = [.. irregularBoundaryPoints];
            coverBoundary = [];
        }
        else
        {
            sectionBoundary =
            [
                new InsetPointDto(-hx, -hy),
                new InsetPointDto( hx, -hy),
                new InsetPointDto( hx,  hy),
                new InsetPointDto(-hx,  hy)
            ];
            coverBoundary = BuildCoverBoundary(hx, hy, coverMm);
        }
        var rebarPoints = rebarCoordinates
            .Where(b => IsFinite(b.X) && IsFinite(b.Y))
            .Select(b => new InsetPointDto(b.X, b.Y))
            .ToList();

        double theta = NormalizeAngle(selectedState?.ThetaDegrees ?? fallbackThetaDegrees);
        double neutralAxisAngle = NormalizeAngle(selectedState?.NeutralAxisAngleDegrees ?? theta);
        var thetaDirection = Unit(theta);
        var neutralAxisNormal = Unit(neutralAxisAngle);
        double axisLength = Math.Max(Math.Min(sectionWidthMm, sectionHeightMm) * 0.28, 1.0);
        double thetaLength = Math.Max(Math.Min(sectionWidthMm, sectionHeightMm) * 0.42, 1.0);

        InsetLineDto? neutralAxisLine = null;
        IReadOnlyList<InsetPointDto> compressionPolygon = [];
        IReadOnlyList<InsetPointDto> tensionPolygon = [];
        double? neutralAxisDepth = selectedState?.NeutralAxisDepth;
        if (selectedState?.IsEntireConcreteTension == true)
        {
            // Pure axial tension has no concrete compression block. This is intentionally
            // separate from P < 0 with bending, where a neutral-axis strain field can still
            // leave part of the concrete in compression.
            tensionPolygon = sectionBoundary;
            neutralAxisDepth = null;
        }
        else if (neutralAxisDepth is > 0 && IsFinite(neutralAxisDepth.Value))
        {
            // The displayed theta follows the PM load angle (Mx/My). The neutral-axis angle
            // may differ because the solver stores the section compression-normal direction.
            // Do not infer concrete compression from the sign of P. Even for P < 0, bending can
            // leave part of the concrete section in compressive strain; the polygon below is
            // clipped only from the neutral-axis strain field.
            double maxProjection = ProjectExtreme(sectionBoundary, neutralAxisNormal.X, neutralAxisNormal.Y);
            double neutralAxisProjection = maxProjection - neutralAxisDepth.Value;
            compressionPolygon = compressionZoneBuilder.ClipByNeutralAxis(sectionBoundary, neutralAxisNormal.X, neutralAxisNormal.Y, neutralAxisProjection);
            tensionPolygon = compressionZoneBuilder.ClipTensionSideByNeutralAxis(sectionBoundary, neutralAxisNormal.X, neutralAxisNormal.Y, neutralAxisProjection);

            double sectionArea = Math.Abs(PolygonArea(sectionBoundary));
            double areaTolerance = Math.Max(sectionArea * AreaToleranceRatio, Tolerance);
            bool hasCompressionArea = Math.Abs(PolygonArea(compressionPolygon)) > areaTolerance;
            bool hasTensionArea = Math.Abs(PolygonArea(tensionPolygon)) > areaTolerance;
            if (hasCompressionArea && hasTensionArea)
            {
                neutralAxisLine = BuildNeutralAxisLine(hx, hy, neutralAxisNormal.X, neutralAxisNormal.Y, neutralAxisProjection);
            }
            else
            {
                if (!hasCompressionArea)
                {
                    compressionPolygon = [];
                }

                if (!hasTensionArea)
                {
                    tensionPolygon = [];
                }

                neutralAxisDepth = null;
            }
        }

        return new PmChartInsetFigureDto(
            sectionBoundary,
            coverBoundary,
            rebarPoints,
            new InsetLineDto(new InsetPointDto(0, 0), new InsetPointDto(axisLength, 0)),
            new InsetLineDto(new InsetPointDto(0, 0), new InsetPointDto(0, axisLength)),
            new InsetLineDto(new InsetPointDto(0, 0), new InsetPointDto(thetaDirection.X * thetaLength, thetaDirection.Y * thetaLength)),
            theta,
            neutralAxisLine is not null && neutralAxisDepth is > 0 && IsFinite(neutralAxisDepth.Value) ? neutralAxisAngle : null,
            neutralAxisLine,
            neutralAxisDepth,
            compressionPolygon,
            tensionPolygon,
            selectedState?.SelectedLoadCaseName ?? "",
            selectedState?.SelectedLoadCaseStateId ?? "",
            selectedState?.P,
            selectedState?.Mx,
            selectedState?.My,
            selectedState?.Mtheta);
    }

    private static IReadOnlyList<InsetPointDto> BuildCoverBoundary(double hx, double hy, double coverMm)
    {
        if (!IsFinite(coverMm) || coverMm <= 0 || coverMm >= hx || coverMm >= hy)
        {
            return [];
        }

        return
        [
            new InsetPointDto(-hx + coverMm, -hy + coverMm),
            new InsetPointDto( hx - coverMm, -hy + coverMm),
            new InsetPointDto( hx - coverMm,  hy - coverMm),
            new InsetPointDto(-hx + coverMm,  hy - coverMm)
        ];
    }

    private static InsetLineDto? BuildNeutralAxisLine(double hx, double hy, double normalX, double normalY, double projection)
    {
        double pad = Math.Max(hx, hy) * 0.12;
        double minX = -hx - pad;
        double maxX = hx + pad;
        double minY = -hy - pad;
        double maxY = hy + pad;
        var intersections = new List<InsetPointDto>();
        AddVerticalIntersection(intersections, minX, minY, maxY, normalX, normalY, projection);
        AddVerticalIntersection(intersections, maxX, minY, maxY, normalX, normalY, projection);
        AddHorizontalIntersection(intersections, minY, minX, maxX, normalX, normalY, projection);
        AddHorizontalIntersection(intersections, maxY, minX, maxX, normalX, normalY, projection);

        var distinct = intersections
            .GroupBy(p => (Math.Round(p.X, 6), Math.Round(p.Y, 6)))
            .Select(g => g.First())
            .Take(2)
            .ToList();

        return distinct.Count == 2 ? new InsetLineDto(distinct[0], distinct[1]) : null;
    }

    private static void AddVerticalIntersection(List<InsetPointDto> points, double x, double minY, double maxY, double normalX, double normalY, double projection)
    {
        if (Math.Abs(normalY) <= Tolerance) return;
        double y = (projection - x * normalX) / normalY;
        if (y >= minY - Tolerance && y <= maxY + Tolerance)
        {
            points.Add(new InsetPointDto(x, Math.Clamp(y, minY, maxY)));
        }
    }

    private static void AddHorizontalIntersection(List<InsetPointDto> points, double y, double minX, double maxX, double normalX, double normalY, double projection)
    {
        if (Math.Abs(normalX) <= Tolerance) return;
        double x = (projection - y * normalY) / normalX;
        if (x >= minX - Tolerance && x <= maxX + Tolerance)
        {
            points.Add(new InsetPointDto(Math.Clamp(x, minX, maxX), y));
        }
    }

    private static double ProjectExtreme(IEnumerable<InsetPointDto> points, double normalX, double normalY)
        => points.Max(p => p.X * normalX + p.Y * normalY);

    private static double PolygonArea(IReadOnlyList<InsetPointDto> polygon)
    {
        if (polygon.Count < 3)
        {
            return 0.0;
        }

        double twiceArea = 0.0;
        for (int i = 0; i < polygon.Count; i++)
        {
            var a = polygon[i];
            var b = polygon[(i + 1) % polygon.Count];
            twiceArea += a.X * b.Y - b.X * a.Y;
        }

        return twiceArea / 2.0;
    }

    private static (double X, double Y) Unit(double degrees)
    {
        double radians = degrees * Math.PI / 180.0;
        return (Math.Cos(radians), Math.Sin(radians));
    }

    private static double NormalizeAngle(double angle)
    {
        if (!IsFinite(angle)) return 0.0;
        var normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);

    // Approximates a circle with N evenly-spaced polygon vertices.
    private static InsetPointDto[] BuildCirclePolygon(double radius, int n)
    {
        var pts = new InsetPointDto[n];
        for (int i = 0; i < n; i++)
        {
            double angle = 2.0 * Math.PI * i / n;
            pts[i] = new InsetPointDto(radius * Math.Cos(angle), radius * Math.Sin(angle));
        }
        return pts;
    }

    private static IReadOnlyList<InsetPointDto> BuildCircleCoverBoundary(double radius, double coverMm)
    {
        double innerRadius = radius - coverMm;
        if (!IsFinite(coverMm) || coverMm <= 0 || innerRadius <= 0)
        {
            return [];
        }
        return BuildCirclePolygon(innerRadius, 64);
    }
}

