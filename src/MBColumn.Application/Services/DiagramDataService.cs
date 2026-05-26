using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services;

public sealed class DiagramDataService
{
    public MmDiagramDto BuildMm(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(BuildMxMyDiagramData(set, unitSystem).Points, MomentUnit(unitSystem));

    public PmmSurfaceDto BuildSurface(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
        => BuildPmmSurfaceRenderData(points, unitSystem);

    public PmDiagramDto BuildPmDiagramRenderData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(ToDto(CleanAndSortPmPoints(set.PmPoints)), ForceUnit(unitSystem), MomentUnit(unitSystem));

    public MmDiagramDto BuildMmDiagramRenderData(DiagramControlPointSet set, UnitSystem unitSystem)
        => new(ToDto(CleanAndSortMmBoundaryPoints(set.MmPoints)), MomentUnit(unitSystem));

    public PmAngleDiagramDto BuildPmAngleDiagramData(DiagramControlPointSet set, UnitSystem unitSystem, double angleDegrees)
    {
        var points = PmCurveBuilderService.BuildPmAngleCurve(set.PmmSurfacePoints, set.DesignCompressionLimitDisplay, set.NominalCompressionLimitDisplay, angleDegrees);
        var reducedPoints = ReducedCapacity(points);
        return new PmAngleDiagramDto(points, angleDegrees, ForceUnit(unitSystem), MomentUnit(unitSystem))
        {
            ReferenceLines = PmCurveBuilderService.BuildPmAngleReferenceLines(points),
            NominalCapacityPoints = NominalCapacity(points),
            ReducedCapacityPoints = reducedPoints,
            SpecialCapacityPoints = ExtractSpecialPointsFromCurve(reducedPoints)
        };
    }

    // Derive special capacity points directly from the 2D reduced PM curve so they
    // always lie exactly on the envelope regardless of chart angle.
    // Phi stored on each curve point identifies ACI strain zones:
    //   phiMin → compression-controlled boundary, phiMax → tension-controlled.
    private static IReadOnlyList<ControlPointDto> ExtractSpecialPointsFromCurve(IReadOnlyList<ControlPointDto> reducedPoints)
    {
        var valid = reducedPoints
            .Where(p => double.IsFinite(p.X) && double.IsFinite(p.Y) && double.IsFinite(p.Phi))
            .ToList();
        if (valid.Count < 3) return [];

        double phiMin = valid.Min(p => p.Phi);
        double phiMax = valid.Max(p => p.Phi);
        bool phiVaries = phiMax - phiMin > 1e-3;

        var result = new List<ControlPointDto>();
        result.Add(SpecialOnCurve(MaxAxialCompression(valid), "Max Compression", "MaxCompression"));
        result.Add(SpecialOnCurve(valid.MinBy(p => p.Y)!, "Max Tension",     "MaxTension"));

        // Positive (M+) and negative (M-) branches sorted by P descending
        var pos = valid.Where(p => p.X >= 0).OrderByDescending(p => p.Y).ToList();
        var neg = valid.Where(p => p.X < 0).OrderByDescending(p => p.Y).ToList();
        AddBranchSpecials(result, pos, phiMin, phiMax, phiVaries);
        AddBranchSpecials(result, neg, phiMin, phiMax, phiVaries);

        return result;
    }

    private static ControlPointDto MaxAxialCompression(IReadOnlyList<ControlPointDto> points)
    {
        var source = points.MaxBy(p => p.Y)!;
        double pmax = source.Y;
        return source with
        {
            X = 0.0,
            Y = pmax,
            Z = pmax,
            P = pmax,
            Mx = 0.0,
            My = 0.0
        };
    }

    // Adds Balanced, Tension Control, Pure Bending for one branch (sorted by P desc).
    // Points are emitted in natural P order — for heavily reinforced sections TC can
    // legitimately appear at negative P (below Pure Bending), which is correct ACI behaviour.
    // TC search starts from the balanced index to avoid phi non-monotonicity placing TC
    // above the balanced point (which is physically impossible).
    private static void AddBranchSpecials(
        List<ControlPointDto> result, List<ControlPointDto> branch,
        double phiMin, double phiMax, bool phiVaries)
    {
        if (branch.Count < 2) return;

        // Pure Bending: exact envelope intersection at P = 0.
        TryAddOnCurve(result, InterpolatePureBending(branch), "Pure Bending", "PureBending");

        if (!phiVaries)
        {
            // phi nearly constant (EC2 etc.) — place at 1/3 and 2/3 of branch by index
            if (branch.Count >= 3)
            {
                TryAddOnCurve(result, branch[branch.Count / 3],     "Balanced",        "Balanced");
                TryAddOnCurve(result, branch[2 * branch.Count / 3], "Tension Control", "TensionControl");
            }
            return;
        }

        double phiRange     = phiMax - phiMin;
        double balThreshold = phiMin + phiRange * 0.02;
        double tcThreshold  = phiMax - phiRange * 0.02;

        // Balanced: first from top where phi rises above compression-controlled zone
        int balIdx = branch.FindIndex(p => p.Phi > balThreshold);
        TryAddOnCurve(result, balIdx >= 0 ? branch[balIdx] : null, "Balanced", "Balanced");

        // Tension Control: first point AFTER balanced where phi reaches the TC zone.
        // Starting from balIdx prevents non-monotonic phi from placing TC above balanced.
        // No upper bound — TC may validly fall below Pure Bending for high-ρ sections.
        int searchFrom = Math.Max(0, balIdx);
        ControlPointDto? tc = branch.Skip(searchFrom).FirstOrDefault(p => p.Phi >= tcThreshold);
        // Fallback: phi threshold never reached (e.g. lightly reinforced, wide transition)
        if (tc is null && branch.Count - searchFrom > 2)
            tc = branch[searchFrom + 2 * (branch.Count - searchFrom) / 3];
        TryAddOnCurve(result, tc, "Tension Control", "TensionControl");
    }

    private static void TryAddOnCurve(List<ControlPointDto> result, ControlPointDto? src, string label, string keyPart)
    {
        if (src is not null) result.Add(SpecialOnCurve(src, label, keyPart));
    }

    private static ControlPointDto? InterpolatePureBending(IReadOnlyList<ControlPointDto> branch)
    {
        const double zeroTolerance = 1e-9;

        foreach (var point in branch)
        {
            if (Math.Abs(point.P) <= zeroTolerance || Math.Abs(point.Y) <= zeroTolerance)
            {
                return point with { Y = 0.0, Z = 0.0, P = 0.0 };
            }
        }

        for (int i = 0; i < branch.Count - 1; i++)
        {
            var a = branch[i];
            var b = branch[i + 1];
            if (!CrossesZero(a.P, b.P) && !CrossesZero(a.Y, b.Y))
            {
                continue;
            }

            double denominator = b.P - a.P;
            if (Math.Abs(denominator) <= zeroTolerance)
            {
                denominator = b.Y - a.Y;
            }

            double t = Math.Abs(denominator) <= zeroTolerance ? 0.0 : -a.P / denominator;
            t = Math.Clamp(t, 0.0, 1.0);

            return a with
            {
                X = Linear(a.X, b.X, t),
                Y = 0.0,
                Z = 0.0,
                P = 0.0,
                Mx = Linear(a.Mx, b.Mx, t),
                My = Linear(a.My, b.My, t),
                Phi = Linear(a.Phi, b.Phi, t),
                ThetaDegrees = Linear(a.ThetaDegrees, b.ThetaDegrees, t),
                NeutralAxisDepth = Linear(a.NeutralAxisDepth, b.NeutralAxisDepth, t),
                SortKey = Linear(a.SortKey, b.SortKey, t),
                Utilization = Linear(a.Utilization, b.Utilization, t)
            };
        }

        return null;
    }

    private static bool CrossesZero(double a, double b)
        => (a <= 0.0 && b >= 0.0) || (a >= 0.0 && b <= 0.0);

    private static ControlPointDto SpecialOnCurve(ControlPointDto src, string label, string keyPart)
        => src with
        {
            Label     = label,
            GroupKey  = $"SpecialCapacity|{keyPart}",
            IsSpecialPoint = true,
            IsDemand  = false,
            IsGoverning = false,
            IsReference = false,
            IsNominal = false
        };

    private static IReadOnlyList<ControlPointDto> NominalCapacity(IReadOnlyList<ControlPointDto> points)
        => points.Where(p => p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint).ToList();

    private static IReadOnlyList<ControlPointDto> ReducedCapacity(IReadOnlyList<ControlPointDto> points)
        => points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint).ToList();

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

        points.AddRange(BuildMxMyBoundaryAtDisplayP(surface, selectedPDisplay, nominal: false));
        points.AddRange(BuildMxMyBoundaryAtDisplayP(surface, selectedPDisplay, nominal: true));

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
        => BuildPmmSurfaceRenderDataAtPLevels(points, unitSystem, pLevelCount: 100);

    public PmmSurfaceDto BuildPmmSurfaceData(IReadOnlyList<ControlPoint> points, UnitSystem unitSystem)
        => BuildPmmSurfaceRenderDataAtPLevels(points, unitSystem, pLevelCount: 100);

    /// <summary>
    /// Builds the 3D PMM surface by resampling the interaction surface at
    /// <paramref name="pLevelCount"/> uniformly-spaced P levels.
    /// Each ring is a true constant-P contour (Mx-My boundary at that axial load),
    /// giving a clean, evenly-spaced mesh regardless of neutral-axis sweep density.
    /// </summary>
    public PmmSurfaceDto BuildPmmSurfaceRenderDataAtPLevels(
        IReadOnlyList<ControlPoint> points, UnitSystem unitSystem, int pLevelCount = 50)
    {
        var dto = ToDto(BuildPLevelSurfaceMesh(points, pLevelCount));
        return new PmmSurfaceDto(dto, ForceUnit(unitSystem), MomentUnit(unitSystem))
        {
            MeshTriangles  = BuildTriangles(dto),
            WireframeLines = BuildWireframe(dto)
        };
    }

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

    /// <summary>
    /// Resamples the PMM surface at <paramref name="pLevelCount"/> uniformly-spaced P levels.
    /// For each P level, interpolates the Mx and My capacity at every angle θ from
    /// the existing PM curves. The resulting mesh has one ring per P level — true
    /// constant-P contours — so the 3D mesh is evenly distributed along the P axis.
    /// </summary>
    private static IReadOnlyList<ControlPoint> BuildPLevelSurfaceMesh(
        IEnumerable<ControlPoint> rawPoints, int pLevelCount)
    {
        // Separate nominal and design surfaces; process each independently.
        var allPoints = Clean(rawPoints).ToList();
        var result    = new List<ControlPoint>();

        foreach (var isNominal in new[] { false, true })
        {
            var surface = allPoints
                .Where(p => p.DiagramType == DiagramType.Pm3D
                         && !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint
                         && (isNominal
                             ? p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)
                             : !p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (surface.Count == 0) continue;

            // Group by angle (theta).
            var byAngle = surface
                .GroupBy(p => Math.Round(p.ThetaDegrees, 4))
                .OrderBy(g => g.Key)
                .Select(g => g.OrderBy(p => isNominal ? p.NominalDisplayP : p.DisplayP).ToList())
                .Where(g => g.Count >= 2)
                .ToList();

            if (byAngle.Count == 0) continue;

            // Determine global P range across all angles.
            double pMin = byAngle.Min(g => isNominal ? g.First().NominalDisplayP : g.First().DisplayP);
            double pMax = byAngle.Max(g => isNominal ? g.Last().NominalDisplayP  : g.Last().DisplayP);
            if (Math.Abs(pMax - pMin) < 1e-9) continue;

            string groupKey = isNominal ? "NominalCapacity" : "DesignCapacity";

            for (int pi = 0; pi < pLevelCount; pi++)
            {
                double pTarget = pMin + (pMax - pMin) * pi / (pLevelCount - 1);
                string sliceKey = $"P={pTarget:F2}";

                foreach (var angleCurve in byAngle)
                {
                    var interpolated = InterpolatePLevel(angleCurve, pTarget, isNominal);
                    if (interpolated is null) continue;

                    var (mx, my, phi, theta, naDepth) = interpolated.Value;
                    
                    // Pole perturbation for top/bottom rings
                    if (pi == 0 || pi == pLevelCount - 1)
                    {
                        const double eps = 0.05;
                        double angleRad = theta * Math.PI / 180.0;
                        double dx = eps * Math.Cos(angleRad);
                        double dy = eps * Math.Sin(angleRad);
                        mx += isNominal ? dx : dx * phi;
                        my += isNominal ? dy : dy * phi;
                    }

                    result.Add(new ControlPoint(
                        Id:              $"{groupKey}|{theta:F4}|{pi}",
                        DiagramType:     DiagramType.Pm3D,
                        Pn:              pTarget,
                        Mnx:             mx,
                        Mny:             my,
                        Phi:             phi,
                        PhiPn:           pTarget,
                        PhiMnx:          mx,
                        PhiMny:          my,
                        DisplayP:        pTarget,
                        DisplayMx:       mx,
                        DisplayMy:       my,
                        NominalDisplayP: pTarget,
                        NominalDisplayMx: mx,
                        NominalDisplayMy: my,
                        ThetaDegrees:    theta,
                        NeutralAxisDepth: naDepth,
                        IsDemandPoint:   false,
                        IsGoverningPoint: false,
                        IsReferencePoint: false,
                        Label:           string.Empty,
                        SortKey:         pi,
                        GroupKey:        groupKey,
                        SliceKey:        $"depth={pi}"));
                }
            }
        }

        // Re-add demand and governing markers
        result.AddRange(allPoints.Where(p => p.IsDemandPoint || p.IsGoverningPoint || p.IsReferencePoint));

        return result;
    }

    private static (double Mx, double My, double Phi, double Theta, double NaDepth)?
        InterpolatePLevel(IReadOnlyList<ControlPoint> curve, double pTarget, bool nominal)
    {
        double GetP(ControlPoint p)  => nominal ? p.NominalDisplayP  : p.DisplayP;
        double GetMx(ControlPoint p) => nominal ? p.NominalDisplayMx : p.DisplayMx;
        double GetMy(ControlPoint p) => nominal ? p.NominalDisplayMy : p.DisplayMy;

        // Clamp to curve endpoints rather than returning null for out-of-range.
        if (pTarget <= GetP(curve[0]))
            return (GetMx(curve[0]), GetMy(curve[0]), curve[0].Phi, curve[0].ThetaDegrees, curve[0].NeutralAxisDepth);
        if (pTarget >= GetP(curve[^1]))
            return (GetMx(curve[^1]), GetMy(curve[^1]), curve[^1].Phi, curve[^1].ThetaDegrees, curve[^1].NeutralAxisDepth);

        for (int i = 0; i < curve.Count - 1; i++)
        {
            double pa = GetP(curve[i]);
            double pb = GetP(curve[i + 1]);
            if (pa <= pTarget && pb >= pTarget)
            {
                double t = Math.Abs(pb - pa) < 1e-9 ? 0.0 : (pTarget - pa) / (pb - pa);
                t = Math.Clamp(t, 0.0, 1.0);
                return (
                    Linear(GetMx(curve[i]), GetMx(curve[i + 1]), t),
                    Linear(GetMy(curve[i]), GetMy(curve[i + 1]), t),
                    Linear(curve[i].Phi,    curve[i + 1].Phi,    t),
                    curve[i].ThetaDegrees,
                    Linear(curve[i].NeutralAxisDepth, curve[i + 1].NeutralAxisDepth, t));
            }
        }
        return null;
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
            return new ControlPointDto(p.DiagramType, p.DisplayMx, chartY, p.DisplayP, p.DisplayP, p.DisplayMx, p.DisplayMy, p.Phi, p.ThetaDegrees, p.NeutralAxisDepth, p.Label, p.GroupKey, p.IsDemandPoint, p.IsGoverningPoint, p.IsReferencePoint, isNominal, p.SortKey, p.SliceKey)
            { IsSpecialPoint = p.IsSpecialPoint };
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
            var rows = surface
                .GroupBy(DepthRowKey)
                .OrderBy(g => g.Key)
                .Select(g => g.OrderBy(p => NormalizeTheta(p.ThetaDegrees)).ToList())
                .Where(g => g.Count >= 3) // Minimum 3 points to form a ring
                .ToList();

            for (int i = 0; i < rows.Count - 1; i++)
            {
                var rowA = rows[i];
                var rowB = rows[i + 1];
                int n = rowA.Count;
                int m = rowB.Count;
                
                // For a structured mesh, we expect n == m == 36.
                // We use the smaller count to be safe, but the user expects exactly 36.
                int count = Math.Min(n, m);
                for (int j = 0; j < count; j++)
                {
                    int next = (j + 1) % count;
                    
                    // Quad face (p0, p1, p2, p3) split into two triangles
                    // p0 = rowA[j], p1 = rowA[next], p2 = rowB[next], p3 = rowB[j]
                    triangles.Add((rowA[j], rowA[next], rowB[j]));
                    triangles.Add((rowA[next], rowB[next], rowB[j]));
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
                .Where(g => g.Count >= 2)
                .ToList();

            // 1. Horizontal Rings (connect points in each P-level)
            foreach (var row in rows)
            {
                for (int j = 0; j < row.Count; j++)
                {
                    int next = (j + 1) % row.Count;
                    lines.Add((row[j], row[next]));
                }
            }

            // 2. Vertical Meridian Curves (connect same theta across P-levels)
            if (rows.Count > 1)
            {
                int maxThetaCount = rows.Max(r => r.Count);
                for (int t = 0; t < maxThetaCount; t++)
                {
                    for (int i = 0; i < rows.Count - 1; i++)
                    {
                        // Ensure both rows have a point at this index
                        if (t < rows[i].Count && t < rows[i + 1].Count)
                        {
                            lines.Add((rows[i][t], rows[i + 1][t]));
                        }
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

