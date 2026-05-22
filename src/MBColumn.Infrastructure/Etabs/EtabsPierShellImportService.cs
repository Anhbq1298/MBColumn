using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using System.Globalization;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

// Reads ETABS area/shell objects assigned to a PierLabel and Story.
// Each matching shell is converted into one plan-view centerline segment with its thickness.
//
// NOTE: ETABS COM API signatures (PropArea.GetShell_1 in particular) vary by version.
// If thickness values look wrong, verify the parameter order against MBColumn_ref/ETABS.
public sealed class EtabsPierShellImportService : IEtabsPierShellImportService
{
    private const double FallbackThicknessMm = 200.0;
    private const double PlanSnapToleranceMm = 0.01;

    private readonly EtabsConnectionService connection;

    public EtabsPierShellImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<(string PierLabel, string StoryName, string SectionProperty)> GetPierGroups()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var areaNames = GetAreaNames(model);
        var groups = new Dictionary<string, (string Pier, string Story, string Prop)>(StringComparer.OrdinalIgnoreCase);

        foreach (var areaName in areaNames)
        {
            var pier = GetAreaPierLabel(model, areaName);
            if (string.IsNullOrEmpty(pier)) continue;

            var (_, story) = GetAreaLabelAndStory(model, areaName);
            if (string.IsNullOrEmpty(story)) continue;

            var key = $"{pier}|{story}";
            if (!groups.ContainsKey(key))
            {
                var prop = GetAreaPropertyName(model, areaName);
                groups[key] = (pier, story, prop);
            }
        }

        return [.. groups.Values
            .OrderBy(g => g.Pier, StringComparer.OrdinalIgnoreCase)
            .ThenBy(g => g.Story, StringComparer.OrdinalIgnoreCase)
            .Select(g => (g.Pier, g.Story, g.Prop))];
    }

    public IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var units = model.GetPresentUnits();
        var (_, lengthToMm) = EtabsConnectionService.GetConversionFactors(units);

        var areaNames = GetAreaNames(model);
        var segments = new List<EtabsPierShellSegmentDto>();

        foreach (var areaName in areaNames)
        {
            var (areaLabel, story) = GetAreaLabelAndStory(model, areaName);
            if (!string.Equals(story, storyName, StringComparison.OrdinalIgnoreCase))
                continue;

            var pier = GetAreaPierLabel(model, areaName);
            if (!string.Equals(pier, pierLabel, StringComparison.OrdinalIgnoreCase))
                continue;

            var pointsXyz = GetAreaPointsXyz(model, areaName, lengthToMm);
            var centerline = ExtractPlanCenterlineSegment(pointsXyz);
            if (centerline is null)
                continue;

            var propName = GetAreaPropertyName(model, areaName);
            var thicknessMm = GetAreaThicknessMm(model, propName, lengthToMm) ?? FallbackThicknessMm;

            var (start, end) = centerline.Value;
            segments.Add(new EtabsPierShellSegmentDto(
                areaName, pierLabel, storyName, areaLabel,
                propName, thicknessMm, start, end));
        }

        return segments;
    }

    private static IReadOnlyList<string> GetAreaNames(cSapModel model)
    {
        int count = 0;
        string[] names = [];
        return model.AreaObj.GetNameList(ref count, ref names) == 0 ? names ?? [] : [];
    }

    private static (string Label, string Story) GetAreaLabelAndStory(cSapModel model, string areaName)
    {
        string label = "";
        string story = "";
        var ret = model.AreaObj.GetLabelFromName(areaName, ref label, ref story);
        return ret == 0 ? (label ?? "", story ?? "") : ("", "");
    }

    private static string GetAreaPierLabel(cSapModel model, string areaName)
    {
        string pierName = "";
        try
        {
            // AreaObj.GetPier mirrors FrameObj.GetPier in the ETABSv1 COM API
            var ret = model.AreaObj.GetPier(areaName, ref pierName);
            return ret == 0 ? pierName ?? "" : "";
        }
        catch
        {
            return "";
        }
    }

    private static List<(double X, double Y)> GetAreaPointsXyz(
        cSapModel model, string areaName, double lengthToMm)
    {
        int nPoints = 0;
        string[] pointNames = [];
        if (model.AreaObj.GetPoints(areaName, ref nPoints, ref pointNames) != 0 || nPoints == 0)
            return [];

        var xyPoints = new List<(double X, double Y)>(nPoints);
        foreach (var ptName in pointNames)
        {
            double x = 0, y = 0, z = 0;
            if (model.PointObj.GetCoordCartesian(ptName, ref x, ref y, ref z) == 0)
                xyPoints.Add((x * lengthToMm, y * lengthToMm));
        }

        return xyPoints;
    }

    private static string GetAreaPropertyName(cSapModel model, string areaName)
    {
        string propName = "";
        try
        {
            // Python prototype: sap_model.AreaObj.GetProperty(area_name) -> (ret, propName)
            var ret = model.AreaObj.GetProperty(areaName, ref propName);
            return ret == 0 ? propName ?? "" : "";
        }
        catch
        {
            return "";
        }
    }

    // Thickness priority:
    //   1. GetWall  — standard homogeneous wall section (most common for pier shells)
    //   2. GetSlab  — slab/shell sections sometimes used for thin walls
    //   3. GetShellLayer_1 — layered shells: sum of all layer thicknesses
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

            var ret = model.PropArea.GetWall(propName, ref wallType, ref shellType,
                ref matProp, ref thickness, ref color, ref notes, ref guid);

            if (ret == 0 && thickness > 0)
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

            var ret = model.PropArea.GetSlab(propName, ref slabType, ref shellType,
                ref matProp, ref thickness, ref color, ref notes, ref guid);

            if (ret == 0 && thickness > 0)
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

            var ret = model.PropArea.GetShellLayer_1(propName, ref nLayers, ref layerNames,
                ref dist, ref thick, ref myType, ref nIntPts, ref matProps, ref matAng,
                ref s11, ref s22, ref s12);

            if (ret == 0 && thick.Length > 0)
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

        // Deduplicate with snap tolerance
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

        // More than 2 unique XY points: use farthest pair
        (double X, double Y) bestA = unique[0], bestB = unique[1];
        double maxDist = 0;

        for (int i = 0; i < unique.Count; i++)
        {
            for (int j = i + 1; j < unique.Count; j++)
            {
                var d = Dist2D(unique[i], unique[j]);
                if (d > maxDist)
                {
                    maxDist = d;
                    bestA = unique[i];
                    bestB = unique[j];
                }
            }
        }

        return (bestA, bestB);
    }

    private static double Dist2D((double X, double Y) a, (double X, double Y) b)
        => SMath.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
}
