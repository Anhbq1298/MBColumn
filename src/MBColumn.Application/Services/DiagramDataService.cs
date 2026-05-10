using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services;

public sealed class DiagramDataService
{
    public PmDiagramDto BuildPm(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(BuildPmXDiagramData(set, unitSystem).Points, ForceUnit(unitSystem), MomentUnit(unitSystem));

    public MmDiagramDto BuildMm(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(BuildMxMyDiagramData(set, unitSystem).Points, MomentUnit(unitSystem));

    public PmmSurfaceDto BuildSurface(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
        => BuildPmmSurfaceRenderData(points, unitSystem);

    public PmDiagramDto BuildPmDiagramRenderData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(ToDto(CleanAndSortPmPoints(set.PmPoints)), ForceUnit(unitSystem), MomentUnit(unitSystem));

    public MmDiagramDto BuildMmDiagramRenderData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(ToDto(CleanAndSortMmBoundaryPoints(set.MmPoints)), MomentUnit(unitSystem));

    public PmXDiagramDto BuildPmXDiagramData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(PmCurveBuilderService.BuildPmXCurve(set.PmmSurfacePoints, set.DesignCompressionLimitDisplay), ForceUnit(unitSystem), MomentUnit(unitSystem));

    public PmYDiagramDto BuildPmYDiagramData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(PmCurveBuilderService.BuildPmYCurve(set.PmmSurfacePoints, set.DesignCompressionLimitDisplay), ForceUnit(unitSystem), MomentUnit(unitSystem));

    public PmAngleDiagramDto BuildPmAngleDiagramData(DiagramControlPointSet set, UnitSystem unitSystem, double angleDegrees)
    {
        var points = PmCurveBuilderService.BuildPmAngleCurve(set.PmmSurfacePoints, set.DesignCompressionLimitDisplay, angleDegrees);
        return new PmAngleDiagramDto(points, angleDegrees, ForceUnit(unitSystem), MomentUnit(unitSystem))
        {
            ReferenceLines = PmCurveBuilderService.BuildPmAngleReferenceLines(points)
        };
    }

    public IReadOnlyList<ControlPointDto> BuildPmAngleDemandPoints(IEnumerable<LoadCaseResultDto> loadCases, double angleDegrees)
    {
        double radians = angleDegrees * Math.PI / 180.0;
        double cos = Math.Cos(radians);
        double sin = Math.Sin(radians);

        return loadCases
            .Where(IsFiniteLoadCase)
            .Select((loadCase, index) =>
            {
                double mtheta = loadCase.MuxDisplay * cos + loadCase.MuyDisplay * sin;
                return BuildDemandPoint(DiagramType.PM, mtheta, loadCase.PuDisplay, loadCase.PuDisplay, loadCase, angleDegrees, index);
            })
            .ToList();
    }

    public IReadOnlyList<ControlPointDto> BuildMxMyDemandPoints(IEnumerable<LoadCaseResultDto> loadCases)
        => loadCases
            .Where(IsFiniteLoadCase)
            .Select((loadCase, index) => BuildDemandPoint(DiagramType.MM, loadCase.MuxDisplay, loadCase.MuyDisplay, loadCase.PuDisplay, loadCase, 0, index))
            .ToList();

    public IReadOnlyList<ControlPointDto> BuildPmmDemandPoints(IEnumerable<LoadCaseResultDto> loadCases)
        => loadCases
            .Where(IsFiniteLoadCase)
            .Select((loadCase, index) => BuildDemandPoint(DiagramType.Pm3D, loadCase.MuxDisplay, loadCase.MuyDisplay, loadCase.PuDisplay, loadCase, 0, index))
            .ToList();

    public MxMyDiagramDto BuildMxMyDiagramData(DiagramControlPointSet set, UnitSystem unitSystem)
    {
        var points = ToDto(CleanAndSortMmBoundaryPoints(set.MmPoints));
        var selectedP = points.FirstOrDefault(p => !p.IsDemand && !p.IsGoverning && !p.IsNominal)?.P ?? 0;
        return new(points, MomentUnit(unitSystem), selectedP, ForceUnit(unitSystem));
    }

    public MxMyDiagramDto BuildMxMyDiagramDataAtDisplayP(DiagramControlPointSet set, UnitSystem unitSystem, double selectedPDisplay)
    {
        var surface = Clean(set.PmmSurfacePoints)
            .Where(p => p.DiagramType == DiagramType.Pm3D && !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint)
            .ToList();
        var points = new List<ControlPointDto>();

        points.AddRange(BuildMxMyBoundaryAtDisplayP(surface.Where(p => !IsNominal(p)).ToList(), selectedPDisplay, nominal: false));
        points.AddRange(BuildMxMyBoundaryAtDisplayP(surface.Where(IsNominal).ToList(), selectedPDisplay, nominal: true));

        foreach (var marker in set.MmPoints.Where(p => p.IsDemandPoint || p.IsGoverningPoint))
        {
            points.Add(ToDto([marker]).First());
        }

        return new MxMyDiagramDto(points, MomentUnit(unitSystem), selectedPDisplay, ForceUnit(unitSystem));
    }

    private static ControlPointDto BuildDemandPoint(DiagramType diagramType, double x, double y, double z, LoadCaseResultDto loadCase, double angleDegrees, int index)
        => new(
            diagramType,
            x,
            y,
            z,
            loadCase.PuDisplay,
            loadCase.MuxDisplay,
            loadCase.MuyDisplay,
            loadCase.Phi,
            angleDegrees,
            loadCase.GoverningNeutralAxisDepth,
            loadCase.LoadCaseName,
            "Demand",
            true,
            false,
            false,
            false,
            index,
            loadCase.LoadCaseId,
            loadCase.PmmRatio,
            loadCase.Status == CapacityStatus.Pass ? "PASS" : "FAIL");

    private static bool IsFiniteLoadCase(LoadCaseResultDto loadCase)
        => IsFinite(loadCase.PuDisplay) && IsFinite(loadCase.MuxDisplay) && IsFinite(loadCase.MuyDisplay);

    public PmmSurfaceDto BuildPmmSurfaceRenderData(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
    {
        var dto = ToDto(BuildSurfaceMesh(points));
        return new PmmSurfaceDto(dto, ForceUnit(unitSystem), MomentUnit(unitSystem))
        {
            MeshTriangles = BuildTriangles(dto),
            WireframeLines = BuildWireframe(dto)
        };
    }

    public PmmSurfaceDto BuildPmmSurfaceData(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
        => BuildPmmSurfaceRenderData(points, unitSystem);

    public PmmSurfaceDto BuildMmSliceRenderData(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
        => new(ToDto(BuildStackedMmContours(points)), ForceUnit(unitSystem), MomentUnit(unitSystem));

    public IReadOnlyList<ControlPoint> CleanAndSortPmPoints(IEnumerable<ControlPoint> points)
        => Clean(points).OrderBy(p => p.IsDemandPoint || p.IsGoverningPoint || p.IsReferencePoint ? 1 : 0).ThenBy(p => p.GroupKey).ThenBy(p => p.SortKey).ToList();

    public IReadOnlyList<ControlPoint> CleanAndSortMmBoundaryPoints(IEnumerable<ControlPoint> points)
    {
        var clean = Clean(points).ToList();
        var specials = clean.Where(p => p.IsReferencePoint || p.IsDemandPoint || p.IsGoverningPoint).ToList();
        var capacity = clean.Where(p => !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint).ToList();

        // Sort design and nominal boundaries separately by polar angle around their own centroid
        var design = capacity.Where(p => p.GroupKey == "DesignCapacity" || (!p.GroupKey.Contains("Nominal") && p.GroupKey != "NominalCapacity")).ToList();
        var nominal = capacity.Where(p => p.GroupKey == "NominalCapacity" || p.GroupKey.Contains("Nominal")).ToList();

        var sortedDesign = SortByPolarAngle(design);
        var sortedNominal = SortByPolarAngle(nominal);

        // If no explicit nominal/design split (old data), sort all together
        if (design.Count == 0 && nominal.Count == 0)
            return SortByPolarAngle(capacity).Concat(specials).ToList();

        return sortedDesign.Concat(sortedNominal).Concat(specials).ToList();
    }

    private static IReadOnlyList<ControlPoint> SortByPolarAngle(IReadOnlyList<ControlPoint> points)
    {
        if (points.Count == 0) return points;
        double cx = points.Average(p => p.DisplayMx);
        double cy = points.Average(p => p.DisplayMy);
        return points.OrderBy(p => Math.Atan2(p.DisplayMy - cy, p.DisplayMx - cx)).ToList();
    }

    public IReadOnlyList<ControlPoint> BuildSurfaceMesh(IEnumerable<ControlPoint> points)
        => Clean(points).OrderBy(p => p.SliceKey).ThenBy(p => p.SortKey).ToList();

    public IReadOnlyList<ControlPoint> BuildStackedMmContours(IEnumerable<ControlPoint> points)
        => CleanAndSortMmBoundaryPoints(points);

    private static IReadOnlyList<ControlPointDto> ToDto(IEnumerable<ControlPoint> points)
        => points.Select(p =>
        {
            var chartY = p.DiagramType == DiagramType.PM ? p.DisplayP : p.DisplayMy;
            bool isNominal = p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase);
            return new ControlPointDto(p.DiagramType, p.DisplayMx, chartY, p.DisplayP, p.DisplayP, p.DisplayMx, p.DisplayMy, p.Phi, p.ThetaDegrees, p.NeutralAxisDepth, p.Label, p.GroupKey, p.IsDemandPoint, p.IsGoverningPoint, p.IsReferencePoint, isNominal, p.SortKey, p.SliceKey);
        }).ToList();

    private static IReadOnlyList<ControlPointDto> BuildMxMyBoundaryAtDisplayP(IReadOnlyList<ControlPoint> points, double selectedPDisplay, bool nominal)
    {
        if (points.Count == 0) return [];

        var boundary = points
            .GroupBy(p => p.GroupKey)
            .Select(g => InterpolateDisplayBoundaryPoint(g.OrderBy(p => nominal ? p.NominalDisplayP : p.DisplayP).ToList(), selectedPDisplay, nominal))
            .Where(p => p is not null)
            .Select(p => p!.Value)
            .ToList();

        if (boundary.Count == 0) return [];
        double cx = boundary.Average(p => p.Mx);
        double cy = boundary.Average(p => p.My);
        return boundary
            .OrderBy(p => Math.Atan2(p.My - cy, p.Mx - cx))
            .Select((p, i) => new ControlPointDto(
                DiagramType.MM,
                p.Mx,
                p.My,
                selectedPDisplay,
                selectedPDisplay,
                p.Mx,
                p.My,
                p.Phi,
                p.Theta,
                p.NeutralAxisDepth,
                nominal ? "NominalCapacity" : "DesignCapacity",
                nominal ? "NominalCapacity" : "DesignCapacity",
                false,
                false,
                false,
                nominal,
                i,
                $"P={selectedPDisplay:F1}"))
            .ToList();
    }

    private static (double Mx, double My, double Phi, double Theta, double NeutralAxisDepth)? InterpolateDisplayBoundaryPoint(IReadOnlyList<ControlPoint> row, double selectedPDisplay, bool nominal)
    {
        if (row.Count == 0) return null;
        double GetP(ControlPoint p) => nominal ? p.NominalDisplayP : p.DisplayP;
        double GetMx(ControlPoint p) => nominal ? p.NominalDisplayMx : p.DisplayMx;
        double GetMy(ControlPoint p) => nominal ? p.NominalDisplayMy : p.DisplayMy;

        for (int i = 0; i < row.Count - 1; i++)
        {
            double pa = GetP(row[i]);
            double pb = GetP(row[i + 1]);
            if ((pa <= selectedPDisplay && pb >= selectedPDisplay) || (pa >= selectedPDisplay && pb <= selectedPDisplay))
            {
                double t = Math.Abs(pb - pa) < 1e-9 ? 0 : (selectedPDisplay - pa) / (pb - pa);
                t = Math.Clamp(t, 0, 1);
                return (
                    Linear(GetMx(row[i]), GetMx(row[i + 1]), t),
                    Linear(GetMy(row[i]), GetMy(row[i + 1]), t),
                    Linear(row[i].Phi, row[i + 1].Phi, t),
                    Linear(row[i].ThetaDegrees, row[i + 1].ThetaDegrees, t),
                    Linear(row[i].NeutralAxisDepth, row[i + 1].NeutralAxisDepth, t));
            }
        }

        var nearest = row.MinBy(p => Math.Abs(GetP(p) - selectedPDisplay))!;
        return (GetMx(nearest), GetMy(nearest), nearest.Phi, nearest.ThetaDegrees, nearest.NeutralAxisDepth);
    }

    private static bool IsNominal(ControlPoint point)
        => point.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase) || point.Label.Contains("Nominal", StringComparison.OrdinalIgnoreCase);

    private static double Linear(double a, double b, double t) => a + (b - a) * t;

    private static IEnumerable<ControlPoint> Clean(IEnumerable<ControlPoint> points)
        => points.Where(p => IsFinite(p.DisplayP) && IsFinite(p.DisplayMx) && IsFinite(p.DisplayMy))
            .GroupBy(p => $"{p.DiagramType}|{p.GroupKey}|{p.IsDemandPoint}|{p.IsGoverningPoint}|{p.IsReferencePoint}|{Math.Round(p.DisplayP, 6)}|{Math.Round(p.DisplayMx, 6)}|{Math.Round(p.DisplayMy, 6)}")
            .Select(g => g.First());

    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);

    private static IReadOnlyList<(ControlPointDto A, ControlPointDto B, ControlPointDto C)> BuildTriangles(IReadOnlyList<ControlPointDto> points)
    {
        var triangles = new List<(ControlPointDto A, ControlPointDto B, ControlPointDto C)>();
        foreach (var surface in points.Where(p => !p.IsDemand && !p.IsGoverning).GroupBy(p => p.IsNominal))
        {
            var groups = surface
                .GroupBy(DepthRowKey)
                .OrderBy(g => g.Key)
                .Select(g => g.OrderBy(p => NormalizeTheta(p.ThetaDegrees)).ToList())
                .Where(g => g.Count > 2)
                .ToList();
            for (int i = 0; i < groups.Count - 1; i++)
            {
                var a = groups[i];
                var b = groups[i + 1];
                int count = Math.Min(a.Count, b.Count);
                for (int j = 0; j < count; j++)
                {
                    int next = (j + 1) % count;
                    triangles.Add((a[j], a[next], b[j]));
                    triangles.Add((a[next], b[next], b[j]));
                }
            }
        }

        return triangles;
    }

    private static IReadOnlyList<(ControlPointDto A, ControlPointDto B)> BuildWireframe(IReadOnlyList<ControlPointDto> points)
    {
        var lines = new List<(ControlPointDto A, ControlPointDto B)>();
        foreach (var surface in points.Where(p => !p.IsDemand && !p.IsGoverning).GroupBy(p => p.IsNominal))
        {
            var rows = surface
                .GroupBy(DepthRowKey)
                .OrderBy(g => g.Key)
                .Select(g => g.OrderBy(p => NormalizeTheta(p.ThetaDegrees)).ToList())
                .Where(g => g.Count > 2)
                .ToList();

            foreach (var group in rows)
            {
                ControlPointDto? previous = null;
                foreach (var point in group)
                {
                    if (previous is not null)
                    {
                        lines.Add((previous, point));
                    }

                    previous = point;
                }
                if (group.Count > 2)
                {
                    lines.Add((group[^1], group[0]));
                }
            }

            if (rows.Count > 1)
            {
                int count = rows.Min(r => r.Count);
                for (int theta = 0; theta < count; theta++)
                {
                    for (int row = 0; row < rows.Count - 1; row++)
                    {
                        lines.Add((rows[row][theta], rows[row + 1][theta]));
                    }
                }
            }
        }

        return lines;
    }

    private static double DepthRowKey(ControlPointDto point)
    {
        if (point.SliceKey.StartsWith("depth=", StringComparison.OrdinalIgnoreCase) &&
            double.TryParse(point.SliceKey["depth=".Length..], out double depthIndex))
        {
            return depthIndex;
        }

        return Math.Round(point.NeutralAxisDepth, 6);
    }

    private static double NormalizeTheta(double theta)
    {
        var value = theta % 360.0;
        return value < 0 ? value + 360.0 : value;
    }

    private static string ForceUnit(UnitSystem unitSystem) => unitSystem == UnitSystem.Metric ? "kN" : "kip";
    private static string MomentUnit(UnitSystem unitSystem) => unitSystem == UnitSystem.Metric ? "kN-m" : "kip-ft";
}

