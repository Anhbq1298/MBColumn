using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using System.Globalization;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

/// <summary>
/// Preloads raw Design Forces - Columns and Design Forces - Piers tables from ETABS
/// into <see cref="ImportedEtabsForceDatabase"/> without filtering or unit conversion,
/// so the data can later be parsed on demand by the Force Filter without additional COM calls.
/// </summary>
public sealed class EtabsDesignForceImportService : IEtabsDesignForceImportService
{
    // Same fallback key sets as EtabsForceImportService to handle different ETABS versions
    private static readonly string[] ColumnTableKeys =
        ["Design Forces - Columns", "Concrete Column Design Forces",
         "Concrete Design 1 - Column Summary", "Concrete Column Design Summary"];

    private static readonly string[] PierTableKeys =
        ["Design Forces - Piers", "Shear Wall Pier Design Forces",
         "Shear Wall 1 - Pier Summary", "Shear Wall Pier Summary"];

    private readonly EtabsConnectionService connection;

    public EtabsDesignForceImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public ImportedEtabsForceDatabase ImportDesignForces(string modelFilePath, string modelName)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var dbUnits = (int)model.GetDatabaseUnits();
        var warnings = new List<string>();

        var columnTable = LoadRawTable(model, ColumnTableKeys, "Design Forces - Columns", warnings);
        var pierTable   = LoadRawTable(model, PierTableKeys,   "Design Forces - Piers",   warnings);

        return new ImportedEtabsForceDatabase
        {
            ModelFilePath = modelFilePath,
            ModelName     = modelName,
            ImportedAt    = DateTime.UtcNow,
            DatabaseUnits = dbUnits,
            ColumnForces  = columnTable,
            PierForces    = pierTable,
            Warnings      = warnings
        };
    }

    public IReadOnlyList<EtabsForceResultDto> ParseColumnForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        if (!database.ColumnForces.HasRecords || columns.Count == 0 || loadCombinations.Count == 0)
            return [];

        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(
            (eUnits)database.DatabaseUnits, targetSystem);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);
        var columnByStoryLabel = new Dictionary<(string Story, string Label), EtabsColumnImportDto>(
            columns.Count);
        foreach (var col in columns)
            columnByStoryLabel.TryAdd((col.StoryName, col.Label), col);

        // Phase 1: collect matching candidates with raw station string
        var candidates = new List<(EtabsColumnImportDto Col, string Combo, string RawStation,
                                   double P, double M2, double M3, double V2)>();

        foreach (var record in database.ColumnForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story");
            var label = GetFieldAny(f, "Label", "Column", "UniqueName");
            var combo = GetFieldAny(f, "Combo", "DesignCombo", "Design Combo").Trim();

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(label)) continue;
            if (!selectedCombos.Contains(combo)) continue;
            if (!columnByStoryLabel.TryGetValue((story, label), out var col)) continue;

            var rawStation = GetFieldAny(f, "Location", "Station");
            if (string.IsNullOrEmpty(rawStation)) rawStation = "Top";

            candidates.Add((col, combo, rawStation,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "Vu2"))));
        }

        // Phase 2: build min/max numeric station per (ObjectName|Combo) so we can label
        //          0 → Bottom, max → Top, in-between → Mid
        var stationRanges = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var grp in candidates.GroupBy(r => $"{r.Col.ObjectName}|{r.Combo}", StringComparer.OrdinalIgnoreCase))
        {
            var nums = grp.Select(r => TryParseDouble(r.RawStation)).Where(v => v.HasValue).Select(v => v!.Value).ToList();
            if (nums.Count > 0)
                stationRanges[grp.Key] = (nums.Min(), nums.Max());
        }

        // Phase 3: emit results with normalized station labels
        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (col, combo, rawStation, p, m2, m3, v2) in candidates)
        {
            var rangeKey = $"{col.ObjectName}|{combo}";
            var station  = stationRanges.TryGetValue(rangeKey, out var range)
                ? NormalizeNumericStation(rawStation, range.Min, range.Max)
                : NormalizeStation(rawStation);

            var key = $"{col.ObjectName}|{combo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                col.ObjectName, col.PierName, col.StoryName, col.Label, col.EtabsSectionName,
                combo,
                SMath.Round(p  * forceToKn,   3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                0.0,
                station,
                "Design Force"));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> ParsePierForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        if (!database.PierForces.HasRecords || piers.Count == 0 || loadCombinations.Count == 0)
            return [];

        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(
            (eUnits)database.DatabaseUnits, targetSystem);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var requestedPiers = new HashSet<string>(
            piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
            StringComparer.OrdinalIgnoreCase);
        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        var results = new List<EtabsForceResultDto>();
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var record in database.PierForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story");
            var pier  = GetFieldAny(f, "Pier", "Label", "Pier Name");
            var combo = GetFieldAny(f, "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();
            var loc   = GetFieldAny(f, "Location", "Station", "Loc");
            if (string.IsNullOrEmpty(loc)) loc = "Top";

            if (!selectedCombos.Contains(combo)) continue;
            if (!requestedPiers.Contains($"{pier.Trim()}|{story.Trim()}")) continue;

            var key = $"{pier}|{story}|{combo}|{loc}";
            if (!seen.Add(key)) continue;

            var p  = ParseDouble(GetFieldAny(f, "P",  "Pu"));
            var m2 = ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2"));
            var m3 = ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3"));
            var v2 = ParseDouble(GetFieldAny(f, "V2", "Vu2"));
            var v3 = ParseDouble(GetFieldAny(f, "V3", "Vu3"));

            var status = string.Equals(loc, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Design Bottom"
                : string.IsNullOrEmpty(loc) ? "Design Force" : $"Design {loc}";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                combo,
                SMath.Round(p  * forceToKn,   3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                SMath.Round(v3 * forceToKn,   3),
                NormalizeStation(loc),
                status));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> ParseAllColumnForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem)
    {
        if (!database.ColumnForces.HasRecords) return [];

        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(
            (eUnits)database.DatabaseUnits, targetSystem);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var candidates = new List<(string Story, string Label, string Combo, string RawStation,
                                   double P, double M2, double M3, double V2)>();

        foreach (var record in database.ColumnForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story");
            var label = GetFieldAny(f, "Label", "Column", "UniqueName");
            var combo = GetFieldAny(f, "Combo", "DesignCombo", "Design Combo").Trim();
            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(label)) continue;

            var rawStation = GetFieldAny(f, "Location", "Station");
            if (string.IsNullOrEmpty(rawStation)) rawStation = "Top";

            candidates.Add((story, label, combo, rawStation,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "Vu2"))));
        }

        var stationRanges = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var grp in candidates.GroupBy(r => $"{r.Story}|{r.Label}|{r.Combo}", StringComparer.OrdinalIgnoreCase))
        {
            var nums = grp.Select(r => TryParseDouble(r.RawStation)).Where(v => v.HasValue).Select(v => v!.Value).ToList();
            if (nums.Count > 0)
                stationRanges[grp.Key] = (nums.Min(), nums.Max());
        }

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (story, label, combo, rawStation, p, m2, m3, v2) in candidates)
        {
            var rangeKey = $"{story}|{label}|{combo}";
            var station  = stationRanges.TryGetValue(rangeKey, out var range)
                ? NormalizeNumericStation(rawStation, range.Min, range.Max)
                : NormalizeStation(rawStation);

            var key = $"{story}|{label}|{combo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                $"{story}/{label}", "", story, label, "",
                combo,
                SMath.Round(p  * forceToKn,   3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                0.0,
                station,
                "Design Force"));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> ParseAllPierForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem)
    {
        if (!database.PierForces.HasRecords) return [];

        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(
            (eUnits)database.DatabaseUnits, targetSystem);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var results = new List<EtabsForceResultDto>();
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var record in database.PierForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story");
            var pier  = GetFieldAny(f, "Pier", "Label", "Pier Name");
            var combo = GetFieldAny(f, "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();
            var loc   = GetFieldAny(f, "Location", "Station", "Loc");
            if (string.IsNullOrEmpty(loc)) loc = "Top";

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(pier)) continue;

            var key = $"{pier}|{story}|{combo}|{loc}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                combo,
                SMath.Round(ParseDouble(GetFieldAny(f, "P",  "Pu"))  * forceToKn,   3),
                SMath.Round(ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")) * momentFactor, 3),
                SMath.Round(ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")) * momentFactor, 3),
                SMath.Round(ParseDouble(GetFieldAny(f, "V2", "Vu2"))  * forceToKn,   3),
                SMath.Round(ParseDouble(GetFieldAny(f, "V3", "Vu3"))  * forceToKn,   3),
                NormalizeStation(loc),
                "Design Force"));
        }

        return results;
    }

    // -----------------------------------------------------------------------
    // Private helpers
    // -----------------------------------------------------------------------

    private static EtabsDesignForceTable LoadRawTable(
        cSapModel model, string[] tableKeys, string defaultKey, List<string> warnings)
    {
        string[] fieldsIn  = [];
        string[] fields    = [];
        int tableVersion   = 0;
        string[] tableData = [];
        int numRecords     = 0;
        int ret            = -1;
        string usedKey     = defaultKey;

        foreach (var key in tableKeys)
        {
            ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsIn, "", ref tableVersion, ref fields, ref numRecords, ref tableData);
            if (ret == 0 && numRecords > 0 && fields.Length > 0)
            {
                usedKey = key;
                break;
            }
        }

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
        {
            warnings.Add($"{defaultKey}: table not found or empty — ensure the ETABS model has been designed.");
            return new EtabsDesignForceTable
            {
                TableKey  = defaultKey,
                FieldKeys = [],
                Records   = []
            };
        }

        return new EtabsDesignForceTable
        {
            TableKey     = usedKey,
            TableVersion = tableVersion,
            FieldKeys    = fields,
            Records      = ParseRecords(usedKey, fields, numRecords, tableData)
        };
    }

    private static IReadOnlyList<EtabsDesignForceRecord> ParseRecords(
        string tableKey, string[] fields, int numRecords, string[] tableData)
    {
        var fieldCount = fields.Length;
        var records    = new List<EtabsDesignForceRecord>(numRecords);

        for (var row = 0; row < numRecords; row++)
        {
            var dict     = new Dictionary<string, string>(fieldCount, StringComparer.OrdinalIgnoreCase);
            var baseIdx  = row * fieldCount;
            for (var col = 0; col < fieldCount; col++)
                dict[fields[col]] = tableData[baseIdx + col] ?? "";

            records.Add(new EtabsDesignForceRecord
            {
                SourceTableKey = tableKey,
                Fields         = dict
            });
        }

        return records;
    }

    private static string GetField(IReadOnlyDictionary<string, string> f, string key)
        => f.TryGetValue(key, out var v) ? v ?? "" : "";

    private static string GetFieldAny(IReadOnlyDictionary<string, string> f, params string[] keys)
    {
        foreach (var k in keys)
            if (f.TryGetValue(k, out var v)) return v ?? "";
        return "";
    }

    private static string NormalizeStation(string station) =>
        string.Equals(station, "Top",    StringComparison.OrdinalIgnoreCase) ? "Top"    :
        string.Equals(station, "Bottom", StringComparison.OrdinalIgnoreCase) ? "Bottom" :
        string.Equals(station, "Mid",    StringComparison.OrdinalIgnoreCase) ? "Mid"    :
        station;

    private static string NormalizeNumericStation(string rawStation, double min, double max)
    {
        if (string.Equals(rawStation, "Top",    StringComparison.OrdinalIgnoreCase)) return "Top";
        if (string.Equals(rawStation, "Bottom", StringComparison.OrdinalIgnoreCase)) return "Bottom";
        if (string.Equals(rawStation, "Mid",    StringComparison.OrdinalIgnoreCase)) return "Mid";
        if (!double.TryParse(rawStation, NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
            return rawStation;
        if (SMath.Abs(v - min) < 1e-6) return "Bottom";
        if (SMath.Abs(v - max) < 1e-6) return "Top";
        return "Mid";
    }

    private static double? TryParseDouble(string s) =>
        double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : null;

    private static double ParseDouble(string s) =>
        double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0.0;
}
