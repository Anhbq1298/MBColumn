using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

// Reads ETABS area/shell objects assigned to a PierLabel and Story.
// Each matching shell is converted into one plan-view centerline segment with its thickness.
//
// Performance: BuildCache() runs once per connection and uses two bulk API calls:
//   - AreaObj.GetLabelNameList  → all area names / labels / stories  (1 COM call)
//   - AreaObj.GetAllAreas       → all area corner XYZ coordinates    (1 COM call)
// Subsequent calls to GetPierGroups() / GetSegments() are pure dictionary lookups.
public sealed class EtabsPierShellImportService : IEtabsPierShellImportService
{
    private const double FallbackThicknessMm = 200.0;
    private const double PlanSnapToleranceMm = 0.01;

    private readonly EtabsConnectionService connection;

    // Cache is keyed to the model COM object; rebuilds automatically on reconnect.
    private AreaScanCache? _cache;
    private cSapModel? _cacheModel;
    private UnitSystem? _cacheTargetSystem;

    public EtabsPierShellImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<(string PierLabel, string StoryName, string SectionProperty)> GetPierGroups(UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var c = EnsureCache(model, targetSystem);

        return [.. c.PierAreaMap.Keys
            .Select(key =>
            {
                var first = c.PierAreaMap[key][0];
                var info = c.AreaInfo[first];
                return (info.Pier, info.Story, info.Prop);
            })
            .OrderBy(g => g.Pier, StringComparer.OrdinalIgnoreCase)
            .ThenBy(g => g.Story, StringComparer.OrdinalIgnoreCase)];
    }

    public IReadOnlyList<string> GetStoryNames()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int storyCount = 0;
        string[] storyNames = [];
        model.Story.GetNameList(ref storyCount, ref storyNames);
        return storyNames ?? [];
    }

    public IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName, UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var c = EnsureCache(model, targetSystem);

        var key = $"{pierLabel.Trim()}|{storyName.Trim()}";
        if (!c.PierAreaMap.TryGetValue(key, out var areaNames) || areaNames.Count == 0)
            return [];

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, _, lengthFactor, _) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);

            var segments = new List<EtabsPierShellSegmentDto>(areaNames.Count);
            foreach (var areaName in areaNames)
            {
                if (!c.AreaInfo.TryGetValue(areaName, out var info)) continue;
                if (!c.AreaPoints.TryGetValue(areaName, out var points)) continue;

                var centerline = ExtractPlanCenterlineSegment(points);
                if (centerline is null) continue;

                var thicknessMm = c.GetOrFetchThickness(model, info.Prop, lengthFactor)
                                  ?? FallbackThicknessMm;
                var (start, end) = centerline.Value;
                segments.Add(new EtabsPierShellSegmentDto(
                    areaName, pierLabel, storyName, info.Label,
                    info.Prop, thicknessMm, start, end, info.AxisAngleDegrees));
            }

            return segments;
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    // -------------------------------------------------------------------
    // Cache management
    // -------------------------------------------------------------------

    private AreaScanCache EnsureCache(cSapModel model, UnitSystem targetSystem)
    {
        if (_cache != null && ReferenceEquals(_cacheModel, model) && _cacheTargetSystem == targetSystem) return _cache;
        _cache = BuildCache(model, targetSystem);
        _cacheModel = model;
        _cacheTargetSystem = targetSystem;
        return _cache;
    }

    // Two bulk calls cover the whole model; only pier-assigned areas get a GetPier COM call.
    private static AreaScanCache BuildCache(cSapModel model, UnitSystem targetSystem)
    {
        var originalUnits = model.GetPresentUnits();
        var (targetUnits, _, lengthFactor, _) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);

            // ── Bulk 1: label + story for every area (1 COM call) ────────────────────────────
            int nAreas = 0;
            string[] bulkNames = [], bulkLabels = [], bulkStories = [];
            model.AreaObj.GetLabelNameList(ref nAreas, ref bulkNames, ref bulkLabels, ref bulkStories);

            var labelStory = new Dictionary<string, (string Label, string Story)>(
                nAreas, StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < nAreas; i++)
                labelStory[bulkNames[i]] = (bulkLabels[i] ?? "", bulkStories[i] ?? "");

            // ── Per area: XY coordinates via joint connectivity (GetPoints + GetCoordCartesian) ──
            var areaPoints = new Dictionary<string, List<(double X, double Y)>>(
                nAreas, StringComparer.OrdinalIgnoreCase);
            foreach (var name in bulkNames)
                areaPoints[name] = GetPointsFallback(model, name, lengthFactor);

            // ── Per area: pier label + section property (only 1 COM call per area) ──────────
            var areaInfo = new Dictionary<string, AreaRecord>(StringComparer.OrdinalIgnoreCase);
            var pierAreaMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            var axisAnglesByPier = new Dictionary<string, IReadOnlyDictionary<string, double>>(
                StringComparer.OrdinalIgnoreCase);

            foreach (var areaName in bulkNames)
            {
                string pier = "";
                try { model.AreaObj.GetPier(areaName, ref pier); } catch { }
                if (string.IsNullOrEmpty(pier) || string.Equals(pier, "None", StringComparison.OrdinalIgnoreCase)) continue;

                if (!labelStory.TryGetValue(areaName, out var ls) || string.IsNullOrEmpty(ls.Story))
                    continue;

                string prop = "";
                try { model.AreaObj.GetProperty(areaName, ref prop); } catch { }

                var axisAngle = GetPierStoryAxisAngle(model, pier, ls.Story, axisAnglesByPier);

                areaInfo[areaName] = new AreaRecord(pier, ls.Story, ls.Label, prop ?? "", axisAngle);

                var mapKey = $"{pier}|{ls.Story}";
                if (!pierAreaMap.TryGetValue(mapKey, out var list))
                    pierAreaMap[mapKey] = list = [];
                list.Add(areaName);
            }

            return new AreaScanCache(areaInfo, pierAreaMap, areaPoints);
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    // -------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------

    private static List<(double X, double Y)> GetPointsFallback(
        cSapModel model, string areaName, double lengthToMm)
    {
        int nPoints = 0;
        string[] pointNames = [];
        if (model.AreaObj.GetPoints(areaName, ref nPoints, ref pointNames) != 0 || nPoints == 0)
            return [];

        var pts = new List<(double X, double Y)>(nPoints);
        foreach (var ptName in pointNames)
        {
            double x = 0, y = 0, z = 0;
            if (model.PointObj.GetCoordCartesian(ptName, ref x, ref y, ref z) == 0)
                pts.Add((x * lengthToMm, y * lengthToMm));
        }
        return pts;
    }

    // Thickness priority: GetWall → GetSlab → GetShellLayer_1
    private static double? GetAreaThicknessMm(cSapModel model, string propName, double lengthToMm)
    {
        if (string.IsNullOrEmpty(propName))
            return null;

        try
        {
            eWallPropType wallType = default;
            eShellType shellType = default;
            string matProp = "";
            double thickness = 0;
            int color = 0;
            string notes = "", guid = "";

            if (model.PropArea.GetWall(propName, ref wallType, ref shellType,
                    ref matProp, ref thickness, ref color, ref notes, ref guid) == 0
                && thickness > 0)
                return thickness * lengthToMm;
        }
        catch { }

        try
        {
            eSlabType slabType = default;
            eShellType shellType = default;
            string matProp = "";
            double thickness = 0;
            int color = 0;
            string notes = "", guid = "";

            if (model.PropArea.GetSlab(propName, ref slabType, ref shellType,
                    ref matProp, ref thickness, ref color, ref notes, ref guid) == 0
                && thickness > 0)
                return thickness * lengthToMm;
        }
        catch { }

        try
        {
            int nLayers = 0;
            string[] layerNames = [];
            double[] dist = [], thick = [];
            int[] myType = [], nIntPts = [], s11 = [], s22 = [], s12 = [];
            string[] matProps = [];
            double[] matAng = [];

            if (model.PropArea.GetShellLayer_1(propName, ref nLayers, ref layerNames,
                    ref dist, ref thick, ref myType, ref nIntPts, ref matProps, ref matAng,
                    ref s11, ref s22, ref s12) == 0
                && thick.Length > 0)
                return thick.Sum() * lengthToMm;
        }
        catch { }

        return null;
    }

    // Projects all 3-D points to plan (XY) and extracts the wall centerline segment.
    //
    // For a rectangular wall shell (4 unique corners), the correct centerline is the
    // axis that runs along the mid-thickness of the wall — NOT the diagonal.
    // Algorithm: try all 3 ways to partition 4 points into two pairs; the partition
    // whose pair-midpoints are FARTHEST apart defines the face direction, so those two
    // midpoints are the correct centerline endpoints.
    //
    // For 2-point or degenerate cases the existing endpoints are returned directly.
    private static ((double X, double Y) Start, (double X, double Y) End)? ExtractPlanCenterlineSegment(
        List<(double X, double Y)> xyPoints)
    {
        if (xyPoints.Count < 2)
            return null;

        var unique = new List<(double X, double Y)>();
        foreach (var p in xyPoints)
        {
            if (!unique.Any(q => Dist2D(p, q) <= PlanSnapToleranceMm))
                unique.Add(p);
        }

        if (unique.Count < 2)
            return null;

        if (unique.Count == 2)
            return (unique[0], unique[1]);

        // Rectangular wall shell: exactly 4 corners → find true centerline
        if (unique.Count == 4)
        {
            // All 3 ways to split 4 points into 2 pairs: (0,1|2,3), (0,2|1,3), (0,3|1,2)
            (int a, int b, int c, int d)[] splits = [(0, 1, 2, 3), (0, 2, 1, 3), (0, 3, 1, 2)];

            (double X, double Y) bestM0 = default, bestM1 = default;
            double bestDist = -1;

            foreach (var (a, b, c, d) in splits)
            {
                var m0 = Midpoint2D(unique[a], unique[b]);
                var m1 = Midpoint2D(unique[c], unique[d]);
                var dist = Dist2D(m0, m1);
                if (dist > bestDist) { bestDist = dist; bestM0 = m0; bestM1 = m1; }
            }

            if (bestDist > PlanSnapToleranceMm)
                return (bestM0, bestM1);
        }

        // Fallback for ≠4 corners: use the two most-distant unique points
        (double X, double Y) fallbackA = unique[0], fallbackB = unique[1];
        double maxDist = 0;
        for (var i = 0; i < unique.Count; i++)
        {
            for (var j = i + 1; j < unique.Count; j++)
            {
                var d = Dist2D(unique[i], unique[j]);
                if (d > maxDist) { maxDist = d; fallbackA = unique[i]; fallbackB = unique[j]; }
            }
        }

        return (fallbackA, fallbackB);
    }

    private static (double X, double Y) Midpoint2D(
        (double X, double Y) a, (double X, double Y) b)
        => ((a.X + b.X) / 2.0, (a.Y + b.Y) / 2.0);

    private static double Dist2D((double X, double Y) a, (double X, double Y) b)
        => SMath.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));

    private static double GetPierStoryAxisAngle(
        cSapModel model,
        string pierName,
        string storyName,
        Dictionary<string, IReadOnlyDictionary<string, double>> cache)
    {
        if (string.IsNullOrWhiteSpace(pierName) || string.IsNullOrWhiteSpace(storyName))
            return 0.0;

        if (!cache.TryGetValue(pierName, out var byStory))
        {
            byStory = LoadPierStoryAxisAngles(model, pierName);
            cache[pierName] = byStory;
        }

        return byStory.TryGetValue(storyName, out var axisAngle) ? axisAngle : 0.0;
    }

    private static IReadOnlyDictionary<string, double> LoadPierStoryAxisAngles(cSapModel model, string pierName)
    {
        int numberStories = 0;
        string[] storyNames = [];
        double[] axisAngles = [];
        int[] numAreaObjs = [];
        int[] numLineObjs = [];
        double[] widthBot = [];
        double[] thicknessBot = [];
        double[] widthTop = [];
        double[] thicknessTop = [];
        string[] matProp = [];
        double[] cgBotX = [];
        double[] cgBotY = [];
        double[] cgBotZ = [];
        double[] cgTopX = [];
        double[] cgTopY = [];
        double[] cgTopZ = [];

        try
        {
            var ret = model.PierLabel.GetSectionProperties(
                pierName,
                ref numberStories,
                ref storyNames,
                ref axisAngles,
                ref numAreaObjs,
                ref numLineObjs,
                ref widthBot,
                ref thicknessBot,
                ref widthTop,
                ref thicknessTop,
                ref matProp,
                ref cgBotX,
                ref cgBotY,
                ref cgBotZ,
                ref cgTopX,
                ref cgTopY,
                ref cgTopZ);

            if (ret != 0 || numberStories <= 0 || storyNames.Length == 0 || axisAngles.Length == 0)
                return new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        }
        catch
        {
            return new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        }

        var result = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        var count = SMath.Min(numberStories, SMath.Min(storyNames.Length, axisAngles.Length));
        for (var i = 0; i < count; i++)
        {
            var story = storyNames[i];
            if (string.IsNullOrWhiteSpace(story)) continue;
            result[story] = axisAngles[i];
        }

        return result;
    }

    // -------------------------------------------------------------------
    // Inner types
    // -------------------------------------------------------------------

    private sealed record AreaRecord(string Pier, string Story, string Label, string Prop, double AxisAngleDegrees);

    private sealed class AreaScanCache(
        Dictionary<string, AreaRecord> areaInfo,
        Dictionary<string, List<string>> pierAreaMap,
        Dictionary<string, List<(double X, double Y)>> areaPoints)
    {
        private readonly Dictionary<string, double?> thicknessCache =
            new(StringComparer.OrdinalIgnoreCase);

        public Dictionary<string, AreaRecord> AreaInfo { get; } = areaInfo;
        public Dictionary<string, List<string>> PierAreaMap { get; } = pierAreaMap;
        public Dictionary<string, List<(double X, double Y)>> AreaPoints { get; } = areaPoints;

        public double? GetOrFetchThickness(cSapModel model, string propName, double lengthToMm)
        {
            if (string.IsNullOrEmpty(propName)) return null;
            if (thicknessCache.TryGetValue(propName, out var cached)) return cached;
            var result = GetAreaThicknessMm(model, propName, lengthToMm);
            thicknessCache[propName] = result;
            return result;
        }
    }
}
