using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using System.Globalization;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsColumnImportService : IEtabsColumnImportService
{
    private const string RectTableKey = "Frame Section Property Definitions - Concrete Rectangular";
    private const string CircleTableKey = "Frame Section Property Definitions - Concrete Circle";

    private readonly EtabsConnectionService connection;

    public EtabsColumnImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<EtabsColumnImportDto> GetCandidateColumns(UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, _, lengthFactor, _) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);
        // GetCoordCartesian returns coordinates in the present units (set by SetPresentUnits below).
        // Convert from targetUnits to mm so LengthMm is always in mm regardless of targetSystem.
        var geoLengthFactor = EtabsConnectionService.GetConversionFactors(targetUnits, MBColumn.Domain.Enums.UnitSystem.Metric).LengthFactor;

        try
        {
            model.SetPresentUnits(targetUnits);

            // Two bulk table calls instead of one PropFrame API call per section
            var sections = LoadConcreteSections(model, lengthFactor);

            int count = 0;
            string[] names = [];
            string[] labels = [];
            string[] stories = [];
            model.FrameObj.GetLabelNameList(ref count, ref names, ref labels, ref stories);

            var columns = new List<EtabsColumnImportDto>();
            for (var i = 0; i < count; i++)
            {
                var orientation = eFrameDesignOrientation.Null;
                if (model.FrameObj.GetDesignOrientation(names[i], ref orientation) != 0
                    || orientation != eFrameDesignOrientation.Column)
                    continue;

                var sectionName = "";
                var sAuto = "";
                model.FrameObj.GetSection(names[i], ref sectionName, ref sAuto);

                // Skip non-concrete and unsupported shapes — only rect and circle imported
                if (!sections.TryGetValue(sectionName, out var sec))
                    continue;

                var pierName = "";
                model.FrameObj.GetPier(names[i], ref pierName);

                string point1 = "", point2 = "";
                model.FrameObj.GetPoints(names[i], ref point1, ref point2);
                double x1 = 0, y1 = 0, z1 = 0;
                model.PointObj.GetCoordCartesian(point1, ref x1, ref y1, ref z1);
                double x2 = 0, y2 = 0, z2 = 0;
                model.PointObj.GetCoordCartesian(point2, ref x2, ref y2, ref z2);
                double lengthMm = System.Math.Sqrt(System.Math.Pow(x1 - x2, 2) + System.Math.Pow(y1 - y2, 2) + System.Math.Pow(z1 - z2, 2)) * geoLengthFactor;

                var uniqueSection = BuildUniqueSectionKey(sectionName, sec.Type, sec.Width, sec.Height, sec.Diameter);

                columns.Add(new EtabsColumnImportDto(
                    names[i],
                    pierName ?? "",
                    stories[i] ?? "",
                    labels[i] ?? "",
                    uniqueSection,
                    sectionName,
                    sec.Material,
                    sec.Type,
                    sec.Width,
                    sec.Height,
                    sec.Diameter,
                    lengthMm,
                    "",
                    "Ready"));
            }

            return columns;
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    public IReadOnlyList<string> GetLoadCombinations()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int count = 0;
        string[] names = [];
        model.RespCombo.GetNameList(ref count, ref names);
        return names ?? [];
    }

    public IReadOnlyList<string> GetLoadCases()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int count = 0;
        string[] names = [];
        model.LoadCases.GetNameList(ref count, ref names);
        return names ?? [];
    }

    public IReadOnlyList<(string Name, double Elevation)> GetStoryElevations()
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int count = 0;
        string[] names = [];
        model.Story.GetNameList(ref count, ref names);
        if (names is null || names.Length == 0) return [];

        var result = new List<(string, double)>(names.Length);
        foreach (var name in names)
        {
            double elev = 0;
            model.Story.GetElevation(name, ref elev);
            result.Add((name, elev));
        }
        return [.. result.OrderBy(s => s.Item2)];
    }

    private static Dictionary<string, ConcreteSectionInfo> LoadConcreteSections(cSapModel model, double lengthToMm)
    {
        var result = new Dictionary<string, ConcreteSectionInfo>(StringComparer.OrdinalIgnoreCase);
        LoadRectangularSections(model, lengthToMm, result);
        LoadCircularSections(model, lengthToMm, result);
        return result;
    }

    private static void LoadRectangularSections(
        cSapModel model, double lengthToMm,
        Dictionary<string, ConcreteSectionInfo> target)
    {
        string[] fieldsIn = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;

        if (model.DatabaseTables.GetTableForDisplayArray(
                RectTableKey, ref fieldsIn, "", ref tableVersion,
                ref fields, ref numRecords, ref tableData) != 0
            || numRecords == 0 || fields.Length == 0)
            return;

        var nameIdx = IndexOf(fields, "Name");
        var matIdx  = IndexOf(fields, "Material");
        var t3Idx   = IndexOf(fields, "t3", "Depth", "Height");
        var t2Idx   = IndexOf(fields, "t2", "Width");

        if (nameIdx < 0 || t3Idx < 0 || t2Idx < 0)
            return;

        var fc = fields.Length;
        for (var r = 0; r < numRecords; r++)
        {
            var b = r * fc;
            var name = tableData[b + nameIdx];
            if (string.IsNullOrEmpty(name)) continue;

            var material = matIdx >= 0 ? tableData[b + matIdx] : "";
            var height   = ParseDouble(tableData[b + t3Idx]) * lengthToMm;
            var width    = ParseDouble(tableData[b + t2Idx]) * lengthToMm;

            target[name] = new ConcreteSectionInfo(SectionShapeType.Rectangular, width, height, 0.0, material);
        }
    }

    private static void LoadCircularSections(
        cSapModel model, double lengthToMm,
        Dictionary<string, ConcreteSectionInfo> target)
    {
        string[] fieldsIn = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;

        if (model.DatabaseTables.GetTableForDisplayArray(
                CircleTableKey, ref fieldsIn, "", ref tableVersion,
                ref fields, ref numRecords, ref tableData) != 0
            || numRecords == 0 || fields.Length == 0)
            return;

        var nameIdx = IndexOf(fields, "Name");
        var matIdx  = IndexOf(fields, "Material");
        var diamIdx = IndexOf(fields, "t3", "Diameter", "D");

        if (nameIdx < 0 || diamIdx < 0)
            return;

        var fc = fields.Length;
        for (var r = 0; r < numRecords; r++)
        {
            var b = r * fc;
            var name = tableData[b + nameIdx];
            if (string.IsNullOrEmpty(name)) continue;

            var material = matIdx >= 0 ? tableData[b + matIdx] : "";
            var diameter = ParseDouble(tableData[b + diamIdx]) * lengthToMm;

            target[name] = new ConcreteSectionInfo(SectionShapeType.Circular, 0.0, 0.0, diameter, material);
        }
    }

    private static string BuildUniqueSectionKey(
        string sectionName, SectionShapeType type, double width, double height, double diameter)
        => type == SectionShapeType.Circular
            ? $"{sectionName} (D{diameter:0.#})"
            : $"{sectionName} ({width:0.#}x{height:0.#})";

    private static int IndexOf(string[] fields, params string[] candidates)
    {
        foreach (var candidate in candidates)
        {
            var idx = Array.FindIndex(fields, f => string.Equals(f, candidate, StringComparison.OrdinalIgnoreCase));
            if (idx >= 0) return idx;
        }
        return -1;
    }

    private static double ParseDouble(string s) =>
        double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0.0;

    private readonly record struct ConcreteSectionInfo(
        SectionShapeType Type, double Width, double Height, double Diameter, string Material);
}
