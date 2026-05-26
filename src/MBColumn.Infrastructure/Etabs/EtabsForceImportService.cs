using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using System.Globalization;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceImportService : IEtabsForceImportService
{
    private static readonly string[] DesignForcesTableKeys = ["Design Forces - Columns", "Concrete Column Design Forces", "Concrete Design 1 - Column Summary", "Concrete Column Design Summary"];
    private static readonly string[] PierDesignForcesTableKeys = ["Design Forces - Piers", "Shear Wall Pier Design Forces", "Shear Wall 1 - Pier Summary", "Shear Wall Pier Summary"];
    private static readonly string[] ElementForcesTableKeys = ["Element Forces - Columns", "Element Forces - Frames", "Frame Object Internal Forces"];

    private readonly EtabsConnectionService connection;

    public EtabsForceImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<EtabsForceResultDto> GetForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, forceFactor, _, momentFactor) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);
            ConfigureOutput(model, loadCombinations);

            var selectedComboSet = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

            return QueryDesignForcesTable(model, columns, selectedComboSet, forceFactor, momentFactor);
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    public IReadOnlyList<EtabsForceResultDto> GetPierForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        if (piers.Count == 0 || loadCombinations.Count == 0)
            return [];

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, forceFactor, _, momentFactor) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);
            ConfigureOutput(model, loadCombinations);

            var requestedPiers = new HashSet<string>(
                piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
                StringComparer.OrdinalIgnoreCase);
            var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

            return QueryPierDesignForcesTable(model, requestedPiers, selectedCombos, forceFactor, momentFactor);
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    public IReadOnlyList<EtabsForceResultDto> GetElementForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        if (columns.Count == 0 || loadCombinations.Count == 0)
            return [];

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, forceFactor, lengthFactor, momentFactor) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);
            ConfigureOutput(model, loadCombinations);

            var selectedComboSet = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);
            return QueryElementForcesTable(model, columns, selectedComboSet, forceFactor, momentFactor, lengthFactor);
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    public IReadOnlyList<EtabsForceResultDto> GetPierElementForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        if (piers.Count == 0 || loadCombinations.Count == 0)
            return [];

        var originalUnits = model.GetPresentUnits();
        var (targetUnits, forceFactor, _, momentFactor) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);

        try
        {
            model.SetPresentUnits(targetUnits);
            ConfigureOutput(model, loadCombinations);

            var requestedPiers = new HashSet<string>(
                piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
                StringComparer.OrdinalIgnoreCase);
            var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

            return QueryPierElementForcesTable(model, requestedPiers, selectedCombos, forceFactor, momentFactor);
        }
        finally
        {
            model.SetPresentUnits(originalUnits);
        }
    }

    private static string GetAvailableTablesErrorMsg(cSapModel model, string label)
    {
        int tableCount = 0;
        string[] allTables = [];
        string[] importTypes = [];
        int[] empty = [];
        bool[] isEmpty = [];
        try
        {
            model.DatabaseTables.GetAllTables(ref tableCount, ref allTables, ref importTypes, ref empty, ref isEmpty);
            var tableList = string.Join(", ", allTables.Where(t => t.Contains("Design", StringComparison.OrdinalIgnoreCase) || t.Contains("Force", StringComparison.OrdinalIgnoreCase)));
            return $"Could not find {label}. Available related tables: {tableList}";
        }
        catch
        {
            return $"Could not find {label}. Please ensure you have run Design in ETABS.";
        }
    }

    private static void ConfigureOutput(cSapModel model, IReadOnlyList<string> loadCombinations)
    {
        model.Results.Setup.DeselectAllCasesAndCombosForOutput();
        foreach (var combo in loadCombinations)
            model.Results.Setup.SetComboSelectedForOutput(combo, true);
        model.Results.Setup.SetOptionMultiValuedCombo(0);

        // DatabaseTables API — limits rows returned by GetTableForEditingArray to selected combos only
        var comboArray = loadCombinations.ToArray();
        model.DatabaseTables.SetLoadCombinationsSelectedForDisplay(ref comboArray);
    }

    private static List<EtabsForceResultDto> QueryDesignForcesTable(
        cSapModel model,
        IReadOnlyList<EtabsColumnImportDto> columns,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        string[] fieldsKeysIncluded = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;
        int ret = -1;

        foreach (var key in DesignForcesTableKeys)
        {
            ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsKeysIncluded, "", ref tableVersion, ref fields, ref numRecords, ref tableData);
            if (ret == 0 && numRecords > 0 && fields.Length > 0)
                break;
        }

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx = IndexOf(fields, "Story");
        var labelIdx = IndexOf(fields, "Label", "Column", "UniqueName");
        var comboIdx = IndexOf(fields, "Combo", "DesignCombo", "Design Combo");
        var pIdx = IndexOf(fields, "P", "Pu");
        var m2Idx = IndexOf(fields, "M2", "M2 Top", "M2-Top", "Mu2");
        var m3Idx = IndexOf(fields, "M3", "M3 Top", "M3-Top", "Mu3");
        var v2Idx = IndexOf(fields, "V2", "Vu2");
        var locIdx = IndexOf(fields, "Station", "Location");

        if (storyIdx < 0 || labelIdx < 0 || comboIdx < 0 || pIdx < 0)
        {
            throw new InvalidOperationException($"Found Column Design Forces table but it is missing required columns. Available columns: {string.Join(", ", fields)}");
        }

        var columnByStoryLabel = new Dictionary<(string Story, string Label), EtabsColumnImportDto>();
        foreach (var col in columns)
            columnByStoryLabel.TryAdd((col.StoryName, col.Label), col);

        var fieldCount = fields.Length;

        // Phase 1: collect matching candidates
        var candidates = new List<(EtabsColumnImportDto Col, string Combo, string RawLoc,
                                   double P, double M2, double M3, double V2)>();

        for (var r = 0; r < numRecords; r++)
        {
            var b     = r * fieldCount;
            var story = tableData[b + storyIdx];
            var label = tableData[b + labelIdx];
            var combo = (tableData[b + comboIdx] ?? "").Trim();

            if (!selectedCombos.Contains(combo)) continue;
            if (!columnByStoryLabel.TryGetValue((story, label), out var column)) continue;

            var rawLoc = locIdx >= 0 ? tableData[b + locIdx] : "Top";
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((column, combo, rawLoc,
                ParseDouble(tableData[b + pIdx]),
                m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0,
                m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0,
                v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0));
        }

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (column, combo, rawLoc, p, m2, m3, v2) in candidates)
        {
            var station = TryParseDouble(rawLoc) is double sv
                ? sv.ToString("G6", CultureInfo.InvariantCulture)
                : NormalizeStation(rawLoc);

            var key = $"{column.ObjectName}|{combo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                column.ObjectName, column.PierName, column.StoryName, column.Label, column.EtabsSectionName,
                combo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                0.0,
                station,
                "Design Force"));
        }

        return results;
    }

    private static List<EtabsForceResultDto> QueryPierDesignForcesTable(
        cSapModel model,
        HashSet<string> requestedPiers,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        string[] fieldsIn = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;
        int ret = -1;

        foreach (var key in PierDesignForcesTableKeys)
        {
            ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsIn, "", ref tableVersion, ref fields, ref numRecords, ref tableData);
            if (ret == 0 && numRecords > 0 && fields.Length > 0)
                break;
        }

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx = IndexOf(fields, "Story");
        var pierIdx = IndexOf(fields, "Pier", "Label", "Pier Name");
        var comboIdx = IndexOf(fields, "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo");
        var pIdx = IndexOf(fields, "P", "Pu");
        var m2Idx = IndexOf(fields, "M2", "M2 Top", "M2-Top", "Mu2");
        var m3Idx = IndexOf(fields, "M3", "M3 Top", "M3-Top", "Mu3");
        var v2Idx = IndexOf(fields, "V2", "Vu2");
        var v3Idx = IndexOf(fields, "V3", "Vu3");
        var locIdx = IndexOf(fields, "Location", "Station", "Loc");

        if (storyIdx < 0 || pierIdx < 0 || comboIdx < 0 || pIdx < 0)
        {
            throw new InvalidOperationException($"Found Pier Design Forces table but it is missing required columns. Available columns: {string.Join(", ", fields)}");
        }

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var fieldCount = fields.Length;

        for (var r = 0; r < numRecords; r++)
        {
            var b = r * fieldCount;
            var story = tableData[b + storyIdx] ?? "";
            var pier = tableData[b + pierIdx] ?? "";
            var combo = (tableData[b + comboIdx] ?? "").Trim();
            var loc = locIdx >= 0 ? tableData[b + locIdx] ?? "" : "Top";

            if (!selectedCombos.Contains(combo)) continue;
            if (!requestedPiers.Contains($"{pier.Trim()}|{story.Trim()}")) continue;

            var key = $"{pier}|{story}|{combo}|{loc}";
            if (!seen.Add(key)) continue;

            var p = ParseDouble(tableData[b + pIdx]);
            var m2 = m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0;
            var m3 = m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0;
            var v2 = v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0;
            var v3 = v3Idx >= 0 ? ParseDouble(tableData[b + v3Idx]) : 0.0;

            var status = string.Equals(loc, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Design Bottom"
                : string.IsNullOrEmpty(loc) ? "Design Force" : $"Design {loc}";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}",
                pier, story, pier, pier,
                combo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                NormalizeStation(loc),
                status));
        }

        return results;
    }

    private static List<EtabsForceResultDto> QueryElementForcesTable(
        cSapModel model,
        IReadOnlyList<EtabsColumnImportDto> columns,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor,
        double lengthToMm)
    {
        string[] fieldsKeysIncluded = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;
        int ret = -1;

        foreach (var key in ElementForcesTableKeys)
        {
            ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsKeysIncluded, "", ref tableVersion, ref fields, ref numRecords, ref tableData);
            if (ret == 0 && numRecords > 0 && fields.Length > 0)
                break;
        }

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx = IndexOf(fields, "Story");
        var labelIdx = IndexOf(fields, "Label", "Column", "UniqueName");
        var comboIdx = IndexOf(fields, "OutputCase", "Combo");
        var stepIdx  = IndexOf(fields, "StepType");
        var pIdx     = IndexOf(fields, "P");
        var m2Idx    = IndexOf(fields, "M2", "M22", "Moment 2", "Mu2", "M2 Top", "M2-Top");
        var m3Idx    = IndexOf(fields, "M3", "M33", "Moment 3", "Mu3", "M3 Top", "M3-Top");
        var v2Idx    = IndexOf(fields, "V2", "V22", "Shear 2", "Vu2");
        var locIdx   = IndexOf(fields, "Station", "Location", "Loc", "Item", "ElemStation", "ObjSta");

        if (storyIdx < 0 || labelIdx < 0 || comboIdx < 0 || pIdx < 0)
            return [];

        var columnByStoryLabel = new Dictionary<(string Story, string Label), EtabsColumnImportDto>();
        foreach (var col in columns)
            columnByStoryLabel.TryAdd((col.StoryName, col.Label), col);

        var fieldCount = fields.Length;

        // Phase 1: collect candidates
        var candidates = new List<(EtabsColumnImportDto Col, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2)>();

        for (var r = 0; r < numRecords; r++)
        {
            var b     = r * fieldCount;
            var story = tableData[b + storyIdx];
            var label = tableData[b + labelIdx];
            var combo = (tableData[b + comboIdx] ?? "").Trim();

            if (!selectedCombos.Contains(combo)) continue;
            if (!columnByStoryLabel.TryGetValue((story, label), out var col)) continue;

            var stepType = stepIdx >= 0 ? (tableData[b + stepIdx] ?? "") : "";
            var rawLoc   = locIdx >= 0 ? tableData[b + locIdx] : "Top";
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((col, combo, stepType, rawLoc,
                ParseDouble(tableData[b + pIdx]),
                m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0,
                m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0,
                v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0));
        }

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (col, combo, stepType, rawLoc, p, m2, m3, v2) in candidates)
        {
            // Keep raw numeric station value for specificity; normalize named stations only.
            var station = TryParseDouble(rawLoc) is double sv
                ? sv.ToString("G6", CultureInfo.InvariantCulture)
                : NormalizeStation(rawLoc);

            // Envelope combos produce Max and Min rows — append step type to distinguish them
            var isSingleStep = string.IsNullOrEmpty(stepType)
                || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
            var effectiveCombo = isSingleStep ? combo : $"{combo} ({stepType})";

            var key = $"{col.ObjectName}|{effectiveCombo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                col.ObjectName, col.PierName, col.StoryName, col.Label, col.EtabsSectionName,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                0.0,
                station,
                "Element Force"));
        }

        return results;
    }

    private static List<EtabsForceResultDto> QueryPierElementForcesTable(
        cSapModel model,
        HashSet<string> requestedPiers,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        string[] fieldsKeysIncluded = [];
        string[] fields = [];
        int tableVersion = 0;
        string[] tableData = [];
        int numRecords = 0;
        int ret = -1;

        foreach (var key in new[] { "Pier Forces" })
        {
            ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsKeysIncluded, "", ref tableVersion, ref fields, ref numRecords, ref tableData);
            if (ret == 0 && numRecords > 0 && fields.Length > 0)
                break;
        }

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx = IndexOf(fields, "Story");
        var pierIdx  = IndexOf(fields, "Pier", "Label", "Pier Name");
        var comboIdx = IndexOf(fields, "OutputCase", "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo");
        var stepIdx  = IndexOf(fields, "StepType");
        var pIdx     = IndexOf(fields, "P", "Pu");
        var m2Idx    = IndexOf(fields, "M2", "M2 Top", "M2-Top", "Mu2");
        var m3Idx    = IndexOf(fields, "M3", "M3 Top", "M3-Top", "Mu3");
        var v2Idx    = IndexOf(fields, "V2", "Vu2");
        var v3Idx    = IndexOf(fields, "V3", "Vu3");
        var locIdx   = IndexOf(fields, "Station", "Location", "Loc");

        if (storyIdx < 0 || pierIdx < 0 || comboIdx < 0 || pIdx < 0)
            return [];

        var fieldCount = fields.Length;

        var candidates = new List<(string Pier, string Story, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2, double V3)>();

        for (var r = 0; r < numRecords; r++)
        {
            var b     = r * fieldCount;
            var story = (tableData[b + storyIdx] ?? "").Trim();
            var pier  = (tableData[b + pierIdx] ?? "").Trim();
            var combo = (tableData[b + comboIdx] ?? "").Trim();

            if (!selectedCombos.Contains(combo)) continue;
            if (!requestedPiers.Contains($"{pier}|{story}")) continue;

            var stepType = stepIdx >= 0 ? (tableData[b + stepIdx] ?? "") : "";
            var rawLoc   = locIdx >= 0 ? tableData[b + locIdx] : "Top";
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((pier, story, combo, stepType, rawLoc,
                ParseDouble(tableData[b + pIdx]),
                m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0,
                m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0,
                v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0,
                v3Idx >= 0 ? ParseDouble(tableData[b + v3Idx]) : 0.0));
        }

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (pier, story, combo, stepType, rawLoc, p, m2, m3, v2, v3) in candidates)
        {
            var station = TryParseDouble(rawLoc) is double sv
                ? sv.ToString("G6", CultureInfo.InvariantCulture)
                : NormalizeStation(rawLoc);

            var isSingleStep = string.IsNullOrEmpty(stepType)
                || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
            var effectiveCombo = isSingleStep ? combo : $"{combo} ({stepType})";

            var key = $"{pier}|{story}|{effectiveCombo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3), // convention for pier
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                station,
                "Element Force"));
        }

        return results;
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

    private static int IndexOf(string[] fields, params string[] candidates)
    {
        foreach (var candidate in candidates)
        {
            var idx = Array.FindIndex(fields, f => string.Equals(f.Trim(), candidate, StringComparison.OrdinalIgnoreCase));
            if (idx >= 0) return idx;
        }

        // Fallback for fields with units, e.g. "Station (m)"
        foreach (var candidate in candidates)
        {
            var idx = Array.FindIndex(fields, f => f.Trim().StartsWith(candidate, StringComparison.OrdinalIgnoreCase));
            if (idx >= 0) return idx;
        }

        return -1;
    }

    private static double ParseDouble(string s) =>
        double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0.0;
}
