using ETABSv1;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using System.Globalization;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceImportService : IEtabsForceImportService
{
    private const string DesignForcesTableKey = "Design Forces - Columns";

    private readonly EtabsConnectionService connection;

    public EtabsForceImportService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    public IReadOnlyList<EtabsForceResultDto> GetForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        // Present units: used by analysis-results API (FrameForce, PierForce).
        // Database units: used by GetTableForDisplayArray — may differ from display units.
        var units = model.GetPresentUnits();
        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(units);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var dbUnits = model.GetDatabaseUnits();
        var (dbForceToKn, dbLengthToMm) = EtabsConnectionService.GetConversionFactors(dbUnits);
        var dbMomentFactor = dbForceToKn * dbLengthToMm / 1000.0;

        ConfigureOutput(model, loadCombinations);

        var results = new List<EtabsForceResultDto>();
        var selectedComboSet = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        foreach (var column in columns)
        {
            results.AddRange(QueryColumnForces(model, column, selectedComboSet, forceToKn, momentFactor));
        }

        // No element forces means the model hasn't been analyzed yet —
        // fall back to the design forces table (single bulk call).
        if (results.Count == 0)
        {
            results.AddRange(QueryDesignForcesTable(model, columns, selectedComboSet, dbForceToKn, dbMomentFactor));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> GetPierForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        if (piers.Count == 0 || loadCombinations.Count == 0)
            return [];

        // Present units: used by analysis-results API (FrameForce, PierForce).
        // Database units: used by GetTableForDisplayArray — may differ from display units.
        var units = model.GetPresentUnits();
        var (forceToKn, lengthToMm) = EtabsConnectionService.GetConversionFactors(units);
        var momentFactor = forceToKn * lengthToMm / 1000.0;

        var dbUnits = model.GetDatabaseUnits();
        var (dbForceToKn, dbLengthToMm) = EtabsConnectionService.GetConversionFactors(dbUnits);
        var dbMomentFactor = dbForceToKn * dbLengthToMm / 1000.0;

        var requestedPiers = new HashSet<string>(
            piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
            StringComparer.OrdinalIgnoreCase);
        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        // Primary: bulk design-forces table (populated after ETABS design run)
        var results = QueryPierDesignForcesTable(model, requestedPiers, selectedCombos, dbForceToKn, dbMomentFactor);

        // Fallback: analysis results API (requires analysis output to be set up)
        if (results.Count == 0)
        {
            ConfigureOutput(model, loadCombinations);
            results = QueryPierForceApi(model, requestedPiers, selectedCombos, forceToKn, momentFactor);
        }

        return results;
    }

    private const string PierDesignForcesTableKey = "Design Forces - Piers";

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

        var ret = model.DatabaseTables.GetTableForDisplayArray(
            PierDesignForcesTableKey, ref fieldsIn, "",
            ref tableVersion, ref fields, ref numRecords, ref tableData);

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx  = IndexOf(fields, "Story");
        var pierIdx   = IndexOf(fields, "Pier", "Label", "Pier Name");
        var comboIdx  = IndexOf(fields, "Combo", "Load Combo", "LoadCombo");
        var locIdx    = IndexOf(fields, "Location", "Loc");
        var pIdx      = IndexOf(fields, "P");
        var v2Idx     = IndexOf(fields, "V2");
        var v3Idx     = IndexOf(fields, "V3");
        var m2Idx     = IndexOf(fields, "M2");
        var m3Idx     = IndexOf(fields, "M3");

        if (storyIdx < 0 || pierIdx < 0 || comboIdx < 0 || pIdx < 0)
            return [];

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var fc = fields.Length;

        for (var r = 0; r < numRecords; r++)
        {
            var b = r * fc;
            var story = tableData[b + storyIdx] ?? "";
            var pier  = tableData[b + pierIdx]  ?? "";
            var combo = tableData[b + comboIdx] ?? "";
            var loc   = locIdx >= 0 ? tableData[b + locIdx] ?? "" : "";

            if (!selectedCombos.Contains(combo)) continue;
            if (!requestedPiers.Contains($"{pier.Trim()}|{story.Trim()}")) continue;

            var key = $"{pier}|{story}|{combo}|{loc}";
            if (!seen.Add(key)) continue;

            var p  = ParseDouble(tableData[b + pIdx]);
            var v2 = v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0;
            var v3 = v3Idx >= 0 ? ParseDouble(tableData[b + v3Idx]) : 0.0;
            var m2 = m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0;
            var m3 = m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0;

            var status = string.Equals(loc, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Design Bottom"
                : string.IsNullOrEmpty(loc) ? "Design Force" : $"Design {loc}";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}",
                pier, story, pier, pier,
                combo,
                SMath.Round(p  * forceToKn,    3),
                SMath.Round(m2 * momentFactor,  3),
                SMath.Round(m3 * momentFactor,  3),
                SMath.Round(v2 * forceToKn,     3),
                SMath.Round(v3 * forceToKn,     3),
                status));
        }

        return results;
    }

    private static List<EtabsForceResultDto> QueryPierForceApi(
        cSapModel model,
        HashSet<string> requestedPiers,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        int numberResults = 0;
        string[] storyName = [];
        string[] pierName  = [];
        string[] loadCase  = [];
        string[] location  = [];
        double[] p = [], v2 = [], v3 = [], t = [], m2 = [], m3 = [];

        var ret = model.Results.PierForce(
            ref numberResults,
            ref storyName, ref pierName, ref loadCase, ref location,
            ref p, ref v2, ref v3, ref t, ref m2, ref m3);

        if (ret != 0 || numberResults == 0)
            return [];

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < numberResults; i++)
        {
            var combo = loadCase[i]  ?? "";
            var pier  = pierName[i]  ?? "";
            var story = storyName[i] ?? "";
            var loc   = location[i]  ?? "";

            if (!selectedCombos.Contains(combo)) continue;
            if (!requestedPiers.Contains($"{pier.Trim()}|{story.Trim()}")) continue;

            var key = $"{pier}|{story}|{combo}|{loc}";
            if (!seen.Add(key)) continue;

            var status = string.Equals(loc, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Pier Bottom" : "Pier Top";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}",
                pier, story, pier, pier,
                combo,
                SMath.Round(p[i]  * forceToKn,   3),
                SMath.Round(m2[i] * momentFactor, 3),
                SMath.Round(m3[i] * momentFactor, 3),
                SMath.Round(v2[i] * forceToKn,    3),
                SMath.Round(v3[i] * forceToKn,    3),
                status));
        }

        return results;
    }

    private static void ConfigureOutput(cSapModel model, IReadOnlyList<string> loadCombinations)
    {
        model.Results.Setup.DeselectAllCasesAndCombosForOutput();
        foreach (var combo in loadCombinations)
        {
            model.Results.Setup.SetComboSelectedForOutput(combo, true);
        }

        // Envelope mode: returns Max and Min rows per combo
        model.Results.Setup.SetOptionMultiValuedCombo(0);
    }

    private static IReadOnlyList<EtabsForceResultDto> QueryDesignForcesTable(
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

        var ret = model.DatabaseTables.GetTableForDisplayArray(
            DesignForcesTableKey,
            ref fieldsKeysIncluded,
            "",
            ref tableVersion,
            ref fields,
            ref numRecords,
            ref tableData);

        if (ret != 0 || numRecords == 0 || fields.Length == 0)
            return [];

        var storyIdx = IndexOf(fields, "Story");
        var labelIdx = IndexOf(fields, "Label");
        var comboIdx = IndexOf(fields, "Combo");
        var pIdx = IndexOf(fields, "P");
        // ETABS may expose either M2/M3 or M2 Top/M3 Top depending on version
        var m2Idx = IndexOf(fields, "M2", "M2 Top", "M2-Top");
        var m3Idx = IndexOf(fields, "M3", "M3 Top", "M3-Top");
        var v2Idx = IndexOf(fields, "V2");

        if (storyIdx < 0 || labelIdx < 0 || comboIdx < 0 || pIdx < 0)
            return [];

        var columnByStoryLabel = new Dictionary<(string Story, string Label), EtabsColumnImportDto>();
        foreach (var col in columns)
            columnByStoryLabel.TryAdd((col.StoryName, col.Label), col);

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var fieldCount = fields.Length;

        for (var r = 0; r < numRecords; r++)
        {
            var b = r * fieldCount;
            var story = tableData[b + storyIdx];
            var label = tableData[b + labelIdx];
            var combo = tableData[b + comboIdx];

            if (!selectedCombos.Contains(combo))
                continue;

            if (!columnByStoryLabel.TryGetValue((story, label), out var column))
                continue;

            var key = $"{column.ObjectName}|{combo}";
            if (!seen.Add(key))
                continue;

            var p = ParseDouble(tableData[b + pIdx]);
            var m2 = m2Idx >= 0 ? ParseDouble(tableData[b + m2Idx]) : 0.0;
            var m3 = m3Idx >= 0 ? ParseDouble(tableData[b + m3Idx]) : 0.0;
            var v2 = v2Idx >= 0 ? ParseDouble(tableData[b + v2Idx]) : 0.0;

            results.Add(new EtabsForceResultDto(
                column.ObjectName,
                column.PierName,
                column.StoryName,
                column.Label,
                column.EtabsSectionName,
                combo,
                SMath.Round(p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                0.0,
                "Design Force"));
        }

        return results;
    }

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

    private static IEnumerable<EtabsForceResultDto> QueryColumnForces(
        cSapModel model,
        EtabsColumnImportDto column,
        HashSet<string> selectedCombos,
        double forceToKn,
        double momentFactor)
    {
        int numResults = 0;
        string[] obj = [];
        double[] objSta = [];
        string[] elm = [];
        double[] elmSta = [];
        string[] loadCase = [];
        string[] stepType = [];
        double[] stepNum = [];
        double[] p = [];
        double[] v2 = [];
        double[] v3 = [];
        double[] t = [];
        double[] m2 = [];
        double[] m3 = [];

        var ret = model.Results.FrameForce(
            column.ObjectName,
            eItemTypeElm.ObjectElm,
            ref numResults,
            ref obj,
            ref objSta,
            ref elm,
            ref elmSta,
            ref loadCase,
            ref stepType,
            ref stepNum,
            ref p,
            ref v2,
            ref v3,
            ref t,
            ref m2,
            ref m3);

        if (ret != 0 || numResults == 0)
            yield break;

        // Group by (loadCombo, stepType) and take one representative row per combo
        // For envelope output, stepType is "Max" or "Min"; we keep both
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < numResults; i++)
        {
            var combo = loadCase[i];
            if (!selectedCombos.Contains(combo))
                continue;

            var key = $"{combo}|{stepType[i]}";
            if (!seen.Add(key))
                continue;

            var status = stepType[i] switch
            {
                "Max" => "Envelope Max",
                "Min" => "Envelope Min",
                _ => stepType[i]
            };

            yield return new EtabsForceResultDto(
                column.ObjectName,
                column.PierName,
                column.StoryName,
                column.Label,
                column.EtabsSectionName,
                combo,
                SMath.Round(p[i] * forceToKn, 3),
                SMath.Round(m2[i] * momentFactor, 3),
                SMath.Round(m3[i] * momentFactor, 3),
                SMath.Round(v2[i] * forceToKn, 3),
                SMath.Round(v3[i] * forceToKn, 3),
                status);
        }
    }
}
