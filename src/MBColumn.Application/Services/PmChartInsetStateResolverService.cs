using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services;

public sealed class PmChartInsetStateResolverService
{
    private const double Tolerance = 1e-9;
    private const double MomentTolerance = 1e-6;
    private readonly DiagramDataService diagramData = new();

    public PmChartInsetSelectedStateDto FromLoadCase(
        CalculationResultDto result,
        LoadCaseResultDto loadCase)
    {
        double loadAngle = DemandVectorAngle(loadCase.MuxDisplay, loadCase.MuyDisplay);
        double radians = loadAngle * Math.PI / 180.0;
        double mtheta = loadCase.MuxDisplay * Math.Cos(radians) + loadCase.MuyDisplay * Math.Sin(radians);
        if (IsPureAxialTension(loadCase.PuDisplay, loadCase.MuxDisplay, loadCase.MuyDisplay))
        {
            return new PmChartInsetSelectedStateDto(
                loadCase.LoadCaseName,
                loadCase.LoadCaseId,
                loadAngle,
                null,
                null,
                loadCase.PuDisplay,
                loadCase.MuxDisplay,
                loadCase.MuyDisplay,
                mtheta,
                IsEntireConcreteTension: true);
        }

        var boundary = ResolveBoundaryState(result, loadCase.PuDisplay, loadAngle);
        return new PmChartInsetSelectedStateDto(
            loadCase.LoadCaseName,
            loadCase.LoadCaseId,
            loadAngle,
            NeutralAxisAngleFromSlice(loadAngle),
            boundary?.NeutralAxisDepth,
            loadCase.PuDisplay,
            loadCase.MuxDisplay,
            loadCase.MuyDisplay,
            mtheta);
    }

    public PmChartInsetSelectedStateDto FromNavigation(
        CalculationResultDto result,
        double thetaDegrees,
        double axialDisplay)
    {
        double theta = NormalizeAngle(thetaDegrees);
        var boundary = ResolveBoundaryState(result, axialDisplay, theta);
        return new PmChartInsetSelectedStateDto(
            "",
            "Navigation",
            theta,
            NeutralAxisAngleFromSlice(theta),
            boundary?.NeutralAxisDepth,
            axialDisplay,
            boundary?.Mx,
            boundary?.My,
            boundary?.SortKey);
    }

    public PmChartInsetSelectedStateDto FromCapacityPoint(ControlPointDto point)
    {
        bool isEntireConcreteTension = IsPureAxialTension(point.P, point.Mx, point.My);
        double theta = DemandVectorAngle(point.Mx, point.My);
        return new PmChartInsetSelectedStateDto(
            point.Label,
            string.IsNullOrWhiteSpace(point.SliceKey) ? point.GroupKey : point.SliceKey,
            theta,
            isEntireConcreteTension ? null : NeutralAxisAngleFromSlice(theta),
            !isEntireConcreteTension && point.NeutralAxisDepth > 0 ? point.NeutralAxisDepth : null,
            point.P,
            point.Mx,
            point.My,
            point.DiagramType == DiagramType.PM ? point.X : Math.Sqrt(point.Mx * point.Mx + point.My * point.My),
            isEntireConcreteTension);
    }

    private static double NeutralAxisAngleFromSlice(double thetaDegrees)
        => NormalizeAngle(thetaDegrees + 90.0);

    private ControlPointDto? ResolveBoundaryState(CalculationResultDto result, double axialDisplay, double loadAngleDegrees)
    {
        var boundary = diagramData
            .BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, axialDisplay)
            .Points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
            .ToList();

        if (boundary.Count < 2)
        {
            return null;
        }

        double radians = loadAngleDegrees * Math.PI / 180.0;
        var direction = (X: Math.Cos(radians), Y: Math.Sin(radians));
        ControlPointDto? best = null;
        double bestRayDistance = double.NegativeInfinity;

        for (int i = 0; i < boundary.Count; i++)
        {
            var a = boundary[i];
            var b = boundary[(i + 1) % boundary.Count];
            var hit = IntersectRaySegment(direction, a.Mx, a.My, b.Mx, b.My);
            if (hit is null)
            {
                continue;
            }

            var (segmentT, rayDistance) = hit.Value;
            if (rayDistance <= bestRayDistance)
            {
                continue;
            }

            bestRayDistance = rayDistance;
            best = Interpolate(a, b, segmentT, axialDisplay, loadAngleDegrees);
        }

        if (best is not null)
        {
            return best;
        }

        return boundary
            .Where(p => p.Mx * direction.X + p.My * direction.Y > 0)
            .MaxBy(p => Alignment(p.Mx, p.My, direction.X, direction.Y));
    }

    private static (double SegmentT, double RayDistance)? IntersectRaySegment(
        (double X, double Y) direction,
        double ax,
        double ay,
        double bx,
        double by)
    {
        double sx = bx - ax;
        double sy = by - ay;
        double denominator = Cross(direction.X, direction.Y, sx, sy);
        if (Math.Abs(denominator) <= Tolerance)
        {
            return null;
        }

        double rayDistance = Cross(ax, ay, sx, sy) / denominator;
        double segmentT = Cross(ax, ay, direction.X, direction.Y) / denominator;
        if (rayDistance < -Tolerance || segmentT < -Tolerance || segmentT > 1.0 + Tolerance)
        {
            return null;
        }

        return (Math.Clamp(segmentT, 0.0, 1.0), Math.Max(0.0, rayDistance));
    }

    private static ControlPointDto Interpolate(ControlPointDto a, ControlPointDto b, double t, double axialDisplay, double loadAngleDegrees)
    {
        double mx = Linear(a.Mx, b.Mx, t);
        double my = Linear(a.My, b.My, t);
        double radians = loadAngleDegrees * Math.PI / 180.0;
        double mtheta = mx * Math.Cos(radians) + my * Math.Sin(radians);
        return new ControlPointDto(
            DiagramType.MM,
            mx,
            my,
            axialDisplay,
            axialDisplay,
            mx,
            my,
            Linear(a.Phi, b.Phi, t),
            LinearAngle(a.ThetaDegrees, b.ThetaDegrees, t),
            Linear(a.NeutralAxisDepth, b.NeutralAxisDepth, t),
            "DesignCapacity",
            "InsetBoundary",
            false,
            false,
            false,
            false,
            mtheta);
    }

    private static double DemandVectorAngle(double mx, double my)
    {
        if (Math.Abs(mx) < Tolerance && Math.Abs(my) < Tolerance) return 0.0;
        var angle = Math.Atan2(my, mx) * 180.0 / Math.PI;
        return NormalizeAngle(angle);
    }

    private static bool IsPureAxialTension(double p, double mx, double my)
        => p < -Tolerance && Math.Sqrt(mx * mx + my * my) <= MomentTolerance;

    private static double Alignment(double mx, double my, double dx, double dy)
    {
        double length = Math.Sqrt(mx * mx + my * my);
        return length <= Tolerance ? double.NegativeInfinity : (mx * dx + my * dy) / length;
    }

    private static double Cross(double ax, double ay, double bx, double by) => ax * by - ay * bx;
    private static double Linear(double a, double b, double t) => a + (b - a) * t;

    private static double LinearAngle(double a, double b, double t)
    {
        double delta = NormalizeSignedAngle(b - a);
        return NormalizeAngle(a + delta * t);
    }

    private static double NormalizeAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle)) return 0.0;
        var normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    private static double NormalizeSignedAngle(double angle)
    {
        var normalized = (angle + 180.0) % 360.0;
        if (normalized < 0) normalized += 360.0;
        return normalized - 180.0;
    }
}

