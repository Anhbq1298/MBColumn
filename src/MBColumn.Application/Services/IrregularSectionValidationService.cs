using MBColumn.Application.DTOs;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using SMath = System.Math;

namespace MBColumn.Application.Services;

public sealed class IrregularSectionValidationService : IIrregularSectionValidationService
{
    public const double DuplicateToleranceMm = 1e-6;
    public const double BoundaryAreaToleranceMm2 = 1e-3;
    public const double InsidePolygonToleranceMm = 1e-3;
    // Absorbs ~0.007 mm of arithmetic noise from 2 d.p. rounding + OffsetPolygon FP errors.
    public const double CoverToleranceMm = 0.5;

    private readonly IRebarDatabase? metricBars;
    private readonly IRebarDatabase? imperialBars;

    public IrregularSectionValidationService()
    {
    }

    public IrregularSectionValidationService(IRebarDatabase metricBars, IRebarDatabase imperialBars)
    {
        this.metricBars = metricBars;
        this.imperialBars = imperialBars;
    }

    public IrregularSectionValidationResult ValidateBoundary(IReadOnlyList<Point2D> points)
    {
        var issues = new List<ValidationIssue>();

        if (points is null || points.Count < 3)
        {
            issues.Add(new ValidationIssue("Boundary", null, "At least 3 boundary points are required.", ValidationSeverity.Error));
            return IrregularSectionValidationResult.Errors(issues);
        }

        for (int i = 0; i < points.Count; i++)
        {
            var p = points[i];
            if (!IsFiniteNumber(p.X) || !IsFiniteNumber(p.Y))
            {
                issues.Add(new ValidationIssue("Boundary", i, $"Boundary point {i + 1} has non-finite coordinate.", ValidationSeverity.Error));
            }
        }

        if (issues.Count > 0) return IrregularSectionValidationResult.Errors(issues);

        for (int i = 0; i < points.Count; i++)
        {
            int next = (i + 1) % points.Count;
            if (Distance(points[i], points[next]) < DuplicateToleranceMm)
            {
                if (i == points.Count - 1)
                {
                    issues.Add(new ValidationIssue("Boundary", i,
                        "First point must not be repeated as the last point. The polygon is implicitly closed.",
                        ValidationSeverity.Error));
                }
                else
                {
                    issues.Add(new ValidationIssue("Boundary", i + 1,
                        $"Boundary points {i + 1} and {next + 1} are duplicate consecutive points.",
                        ValidationSeverity.Error));
                }
            }
        }

        for (int i = 0; i < points.Count; i++)
        {
            for (int j = i + 1; j < points.Count; j++)
            {
                if (Distance(points[i], points[j]) < DuplicateToleranceMm)
                {
                    issues.Add(new ValidationIssue("Boundary", j,
                        $"Boundary points {i + 1} and {j + 1} are duplicates.",
                        ValidationSeverity.Error));
                }
            }
        }

        double area = PolygonGeometry.Area(points);
        if (area < BoundaryAreaToleranceMm2)
        {
            issues.Add(new ValidationIssue("Boundary", null,
                "Polygon area is zero or near-zero.", ValidationSeverity.Error));
        }

        if (PolygonGeometry.IsSelfIntersecting(points))
        {
            issues.Add(new ValidationIssue("Boundary", null,
                "Polygon is self-intersecting.", ValidationSeverity.Error));
        }

        return IrregularSectionValidationResult.Errors(issues);
    }

    public IrregularSectionValidationResult ValidateRebars(
        IReadOnlyList<Point2D> boundary,
        IReadOnlyList<IrregularRebarInputDto> rebars,
        double coverMm)
    {
        var issues = new List<ValidationIssue>();
        if (rebars is null || rebars.Count == 0)
        {
            issues.Add(new ValidationIssue("Rebars", null,
                "At least one rebar is required.", ValidationSeverity.Error));
            return IrregularSectionValidationResult.Errors(issues);
        }

        var resolved = new List<(int Row, IrregularRebarInputDto Bar, double Diameter)>();
        for (int i = 0; i < rebars.Count; i++)
        {
            var bar = rebars[i];
            if (string.IsNullOrWhiteSpace(bar.RebarIndex))
            {
                issues.Add(new ValidationIssue("RebarIndex", i,
                    "Rebar index must not be blank.", ValidationSeverity.Error));
            }
            if (!IsFiniteNumber(bar.X) || !IsFiniteNumber(bar.Y))
            {
                issues.Add(new ValidationIssue("Rebar", i,
                    $"Rebar row {i + 1} has non-finite coordinate.", ValidationSeverity.Error));
                continue;
            }

            if (!TryResolveDiameter(bar, out double diameter, out string? resolveError))
            {
                issues.Add(new ValidationIssue("Rebar", i, resolveError!, ValidationSeverity.Error));
                continue;
            }

            resolved.Add((i, bar, diameter));
        }

        if (boundary is null || boundary.Count < 3)
        {
            return IrregularSectionValidationResult.Errors(issues);
        }

        foreach (var (row, bar, diameter) in resolved)
        {
            bool inside = PolygonGeometry.PointInPolygon(boundary, bar.X, bar.Y);
            double dist = PolygonGeometry.DistanceToBoundary(boundary, bar.X, bar.Y);
            if (!inside && dist > InsidePolygonToleranceMm)
            {
                issues.Add(new ValidationIssue("Rebar", row,
                    $"Rebar '{bar.RebarIndex}' is outside the polygon.", ValidationSeverity.Error));
                continue;
            }

            double requiredClearance = coverMm + diameter / 2.0;
            if (dist + CoverToleranceMm < requiredClearance)
            {
                issues.Add(new ValidationIssue("Rebar", row,
                    $"Rebar '{bar.RebarIndex}' violates cover. Distance to boundary {dist:F2} mm, required {requiredClearance:F2} mm.",
                    ValidationSeverity.Error));
            }
        }

        for (int i = 0; i < resolved.Count; i++)
        {
            for (int j = i + 1; j < resolved.Count; j++)
            {
                var (rowA, barA, dA) = resolved[i];
                var (rowB, barB, dB) = resolved[j];
                double clearance = (dA + dB) / 2.0;
                double dist = SMath.Sqrt(SMath.Pow(barA.X - barB.X, 2) + SMath.Pow(barA.Y - barB.Y, 2));
                if (dist + InsidePolygonToleranceMm < clearance)
                {
                    issues.Add(new ValidationIssue("Rebar", rowB,
                        $"Rebars '{barA.RebarIndex}' and '{barB.RebarIndex}' overlap. Distance {dist:F2} mm, required {clearance:F2} mm.",
                        ValidationSeverity.Error));
                }
            }
        }

        return IrregularSectionValidationResult.Errors(issues);
    }

    public bool TryResolveDiameter(IrregularRebarInputDto bar, out double diameterMm, out string? error)
    {
        diameterMm = 0.0;
        error = null;
        if (bar.AreaMm2 is double area && area > 0.0)
        {
            diameterMm = SMath.Sqrt(4.0 * area / SMath.PI);
            return true;
        }

        if (!string.IsNullOrWhiteSpace(bar.BarSize))
        {
            if (metricBars is not null && metricBars.TryGet(bar.BarSize!, out var def))
            {
                diameterMm = def.DiameterMm;
                return true;
            }
            if (imperialBars is not null && imperialBars.TryGet(bar.BarSize!, out var def2))
            {
                diameterMm = def2.DiameterMm;
                return true;
            }
            error = $"Unknown bar size '{bar.BarSize}' for rebar '{bar.RebarIndex}'.";
            return false;
        }

        error = $"Rebar '{bar.RebarIndex}' must provide either BarSize or AreaMm2.";
        return false;
    }

    private static bool IsFiniteNumber(double value)
        => !double.IsNaN(value) && !double.IsInfinity(value);

    private static double Distance(Point2D a, Point2D b)
        => SMath.Sqrt(SMath.Pow(a.X - b.X, 2) + SMath.Pow(a.Y - b.Y, 2));
}
