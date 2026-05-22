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

    public IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName, UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var c = EnsureCache(model, targetSystem);

        var key = $"{pierLabel.Trim()}|{storyName.Trim()}";
        if (!c.PierAreaMap.TryGetValue(key, out var areaNames) || areaNames.Count == 0)
            return [];

        var units = model.GetPresentUnits();
        var (_, lengthToMm) = EtabsConnectionService.GetConversionFactors(units, targetSystem);

        var segments = new List<EtabsPierShellSegmentDto>(areaNames.Count);
        foreach (var areaName in areaNames)
        {
            if (!c.AreaInfo.TryGetValue(areaName, out var info)) continue;
            if (!c.AreaPoints.TryGetValue(areaName, out var points)) continue;

            var centerline = ExtractPlanCenterlineSegment(points);
            if (centerline is null) continue;

            var thicknessMm = c.GetOrFetchThickness(model, info.Prop, lengthToMm)
                              ?? FallbackThicknessMm;
            var (start, end) = centerline.Value;
            segments.Add(new EtabsPierShellSegmentDto(
                areaName, pierLabel, storyName, info.Label,
                info.Prop, thicknessMm, start, end));
        }

        return segments;
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
        var units = model.GetPresentUnits();
        var (_, lengthToMm) = EtabsConnectionService.GetConversionFactors(units, targetSystem);

        // ── Bulk 1: label + story for every area (1 COM call) ────────────────────────────
        int nAreas = 0;
        string[] bulkNames = [], bulkLabels = [], bulkStories = [];
        model.AreaObj.GetLabelNameList(ref nAreas, ref bulkNames, ref bulkLabels, ref bulkStories);

        var labelStory = new Dictionary<string, (string Label, string Story)>(
            nAreas, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < nAreas; i++)
            labelStory[bulkNames[i]] = (bulkLabels[i] ?? "", bulkStories[i] ?? "");

        // ── Bulk 2: all area corner XYZ coordinates (1 COM call) ─────────────────────────
        int nAreasBulk = 0, totalPts = 0;
        string[] allAreaNames = [];
        eAreaDesignOrientation[] orientations = [];
        int[] ptDelimiter = [];       // cumulative point count up to each area
        string[] ptNames = [];
        double[] ptX = [], ptY = [], ptZ = [];

        var areaPoints = new Dictionary<string, List<(double X, double Y)>>(
            nAreas, StringComparer.OrdinalIgnoreCase);

        if (model.AreaObj.GetAllAreas(
                ref nAreasBulk, ref allAreaNames, ref orientations,
                ref totalPts, ref ptDelimiter, ref ptNames,
                ref ptX, ref ptY, ref ptZ) == 0 && nAreasBulk > 0)
        {
            var pStart = 0;
            for (var i = 0; i < nAreasBulk; i++)
            {
                var pEnd = ptDelimiter[i]; // cumulative exclusive end
                var pts = new List<(double X, double Y)>(pEnd - pStart);
                for (var p = pStart; p < pEnd; p++)
                    pts.Add((ptX[p] * lengthToMm, ptY[p] * lengthToMm));
                areaPoints[allAreaNames[i]] = pts;
                pStart = pEnd;
            }
        }
        else
        {
            // Fallback path: ETABS version that doesn't support GetAllAreas
            foreach (var name in bulkNames)
                areaPoints[name] = GetPointsFallback(model, name, lengthToMm);
        }

        // ── Per area: pier label + section property (only 1 COM call per area) ──────────
        var areaInfo = new Dictionary<string, AreaRecord>(StringComparer.OrdinalIgnoreCase);
        var pierAreaMap = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        foreach (var areaName in bulkNames)
        {
            string pier = "";
            try { model.AreaObj.GetPier(areaName, ref pier); } catch { }
            if (string.IsNullOrEmpty(pier)) continue;

            if (!labelStory.TryGetValue(areaName, out var ls) || string.IsNullOrEmpty(ls.Story))
                continue;

            string prop = "";
            try { model.AreaObj.GetProperty(areaName, ref prop); } catch { }

            areaInfo[areaName] = new AreaRecord(pier, ls.Story, ls.Label, prop ?? "");

            var mapKey = $"{pier}|{ls.Story}";
            if (!pierAreaMap.TryGetValue(mapKey, out var list))
                pierAreaMap[mapKey] = list = [];
            list.Add(areaName);
        }

        return new AreaScanCache(areaInfo, pierAreaMap, areaPoints);
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

    // Projects all 3-D points to plan (XY) and returns the unique pair of
    // points that are farthest apart — the wall centerline in plan view.
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

        (double X, double Y) bestA = unique[0], bestB = unique[1];
        double maxDist = 0;
        for (var i = 0; i < unique.Count; i++)
        {
            for (var j = i + 1; j < unique.Count; j++)
            {
                var d = Dist2D(unique[i], unique[j]);
                if (d > maxDist) { maxDist = d; bestA = unique[i]; bestB = unique[j]; }
            }
        }

        return (bestA, bestB);
    }

    private static double Dist2D((double X, double Y) a, (double X, double Y) b)
        => SMath.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));

    // -------------------------------------------------------------------
    // Inner types
    // -------------------------------------------------------------------

    private sealed record AreaRecord(string Pier, string Story, string Label, string Prop);

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
