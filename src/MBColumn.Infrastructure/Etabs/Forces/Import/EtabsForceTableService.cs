using ETABSv1;
using MBColumn.Application.DTOs.Etabs.Forces;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using System.Globalization;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

/// <summary>
/// Unified ETABS force import pipeline using cDatabaseTables.
///
/// Pipeline:
///   1. Resolve table key from ForceSourceType + ObjectType.
///   2. Read raw ETABS table via GetTableForDisplayArray.
///   3. Normalize field names to EtabsForceRecord.
///   4. Apply EtabsForceFilterCriteria.
///   5. Group by (Story+Label+UniqueName+OutputCase), keep min/max stations (Bottom/Top).
///   6. Convert units and apply MB Column force convention.
///   7. Generate MB Column load case names.
/// </summary>
public sealed class EtabsForceTableService : IEtabsForceTableService
{
    private readonly EtabsConnectionService connection;

    public EtabsForceTableService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    // -------------------------------------------------------------------------
    // Public API
    // -------------------------------------------------------------------------

    public IReadOnlyList<EtabsForceRecord> GetNormalizedRecords(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType,
        EtabsForceFilterCriteria criteria)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var tableKeys = EtabsTableKeyResolver.GetFallbackTableKeys(sourceType, objectType);
        var (fields, tableData, numRecords) = LoadRawTable(model, tableKeys);
        if (numRecords == 0 || fields.Length == 0)
            return [];

        var raw = ParseToForceRecords(sourceType, objectType, fields, numRecords, tableData);
        return ApplyFilters(raw, criteria);
    }

    public IReadOnlyList<MbColumnForceRecord> MapToMbColumnRecords(
        IReadOnlyList<EtabsForceRecord> records,
        UnitSystem targetSystem)
    {
        if (records.Count == 0)
            return [];

        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        model.SetPresentUnits(eUnits.kN_m_C);
        var (forceFactor, _, momentFactor) = GetUnitFactors(eUnits.kN_m_C, targetSystem);

        return GroupAndMapRecords(records, forceFactor, momentFactor);
    }

    public IReadOnlyList<MbColumnForceRecord> GetMbColumnForceRecords(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType,
        EtabsForceFilterCriteria criteria,
        UnitSystem targetSystem)
    {
        var normalized = GetNormalizedRecords(sourceType, objectType, criteria);
        return MapToMbColumnRecords(normalized, targetSystem);
    }

    // -------------------------------------------------------------------------
    // Step 2: load raw ETABS table
    // -------------------------------------------------------------------------

    private static (string[] Fields, string[] TableData, int NumRecords) LoadRawTable(
        cSapModel model, IReadOnlyList<string> tableKeys)
    {
        string[] fieldsIn  = [];
        string[] fields    = [];
        int tableVersion   = 0;
        string[] tableData = [];
        int numRecords     = 0;

        foreach (var key in tableKeys)
        {
            var ret = model.DatabaseTables.GetTableForDisplayArray(
                key, ref fieldsIn, "", ref tableVersion, ref fields, ref numRecords, ref tableData);

            if (ret == 0 && numRecords > 0 && fields.Length > 0)
                return (fields, tableData, numRecords);
        }

        return ([], [], 0);
    }

    // -------------------------------------------------------------------------
    // Step 3: normalize field names → EtabsForceRecord
    // -------------------------------------------------------------------------

    private static IReadOnlyList<EtabsForceRecord> ParseToForceRecords(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType,
        string[] fields,
        int numRecords,
        string[] tableData)
    {
        var fieldCount = fields.Length;
        var records    = new List<EtabsForceRecord>(numRecords);

        for (var row = 0; row < numRecords; row++)
        {
            var baseIdx = row * fieldCount;
            var dict    = new Dictionary<string, string>(fieldCount, StringComparer.OrdinalIgnoreCase);

            for (var col = 0; col < fieldCount; col++)
                dict[fields[col].Trim()] = tableData[baseIdx + col] ?? "";

            var story      = ResolveField(dict, "Story", "StoryName");
            var label      = ResolveLabel(dict, objectType);
            var uniqueName = ResolveField(dict, "UniqueName", "Unique Name", "UniqueLabel");
            var outputCase = ResolveField(dict, "OutputCase", "Output Case", "Combo", "DesignCombo",
                                          "Design Combo", "LoadCase", "Load Case");
            var caseType   = ResolveField(dict, "CaseType", "Case Type");
            var stepType   = ResolveField(dict, "StepType", "Step Type");
            var stationRaw = ResolveField(dict, "Station", "ElemStation", "ObjSta", "Location", "Loc");

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(label)) continue;
            if (string.IsNullOrEmpty(outputCase)) continue;

            if (!double.TryParse(stationRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out var station))
                station = 0.0;

            records.Add(new EtabsForceRecord
            {
                SourceType  = sourceType,
                ObjectType  = objectType,
                Story       = story.Trim(),
                Label       = label.Trim(),
                UniqueName  = uniqueName.Trim(),
                OutputCase  = NormalizeOutputCase(outputCase.Trim(), stepType.Trim()),
                CaseType    = caseType.Trim(),
                StepType    = stepType.Trim(),
                Station     = station,
                P           = ParseD(ResolveField(dict, "P", "Pu")),
                V2          = ParseD(ResolveField(dict, "V2", "V22", "Shear 2", "Vu2")),
                V3          = ParseD(ResolveField(dict, "V3", "V33", "Shear 3", "Vu3")),
                T           = ParseD(ResolveField(dict, "T", "Torsion")),
                M2          = ParseD(ResolveField(dict, "M2", "M22", "Moment 2", "M2 Top", "M2-Top", "Mu2")),
                M3          = ParseD(ResolveField(dict, "M3", "M33", "Moment 3", "M3 Top", "M3-Top", "Mu3"))
            });
        }

        return records;
    }

    private static string ResolveLabel(IReadOnlyDictionary<string, string> dict, EtabsForceObjectType objectType)
    {
        // Column tables use "Column" or "Label"; pier tables use "Pier" or "PierLabel"
        return objectType == EtabsForceObjectType.Column
            ? ResolveField(dict, "Column", "ColumnLabel", "Label", "UniqueName")
            : ResolveField(dict, "Pier", "PierLabel", "Pier Name", "Label");
    }

    // -------------------------------------------------------------------------
    // Step 4: apply user filter criteria
    // -------------------------------------------------------------------------

    private static IReadOnlyList<EtabsForceRecord> ApplyFilters(
        IReadOnlyList<EtabsForceRecord> records,
        EtabsForceFilterCriteria criteria)
    {
        if (records.Count == 0) return records;

        var result = new List<EtabsForceRecord>(records.Count);
        foreach (var r in records)
        {
            if (criteria.SelectedStories.Count > 0      && !criteria.SelectedStories.Contains(r.Story))      continue;
            if (criteria.SelectedLabels.Count > 0       && !criteria.SelectedLabels.Contains(r.Label))       continue;
            if (criteria.SelectedUniqueNames.Count > 0  && !criteria.SelectedUniqueNames.Contains(r.UniqueName)) continue;
            if (criteria.SelectedOutputCases.Count > 0  && !MatchesAny(r.OutputCase, criteria.SelectedOutputCases)) continue;
            result.Add(r);
        }
        return result;
    }

    // -------------------------------------------------------------------------
    // Steps 5–7: group by key, resolve stations, convert units, map convention
    // -------------------------------------------------------------------------

    private static IReadOnlyList<MbColumnForceRecord> GroupAndMapRecords(
        IReadOnlyList<EtabsForceRecord> records,
        double forceFactor,
        double momentFactor)
    {
        // Group by: Story + Label + UniqueName + OutputCase
        var groups = new Dictionary<string, List<EtabsForceRecord>>(StringComparer.OrdinalIgnoreCase);
        foreach (var r in records)
        {
            var key = $"{r.Story}\x00{r.Label}\x00{r.UniqueName}\x00{r.OutputCase}";
            if (!groups.TryGetValue(key, out var list))
                groups[key] = list = [];
            list.Add(r);
        }

        const double stationTolerance = 1e-6;
        var result = new List<MbColumnForceRecord>(groups.Count * 2);

        foreach (var (_, group) in groups)
        {
            if (group.Count == 0) continue;

            var minStation = group.Min(r => r.Station);
            var maxStation = group.Max(r => r.Station);

            foreach (var r in group)
            {
                bool isBottom = SMath.Abs(r.Station - minStation) < stationTolerance;
                bool isTop    = SMath.Abs(r.Station - maxStation) < stationTolerance;

                if (!isBottom && !isTop) continue; // skip intermediate stations

                var location = isBottom ? "Bottom" : "Top";
                result.Add(MapRecord(r, location, forceFactor, momentFactor));
            }
        }

        return result;
    }

    private static MbColumnForceRecord MapRecord(
        EtabsForceRecord r,
        string location,
        double forceFactor,
        double momentFactor)
    {
        // MB Column force convention:
        //   NEd = -P    (positive = compression, ETABS P negative = compression)
        //   Vx  = V2    (V2 + M3 pair)
        //   Vy  = V3    (V3 + M2 pair)
        //   Mx  = M2
        //   My  = M3

        return new MbColumnForceRecord
        {
            MBCLCNName       = BuildLoadCaseName(r.OutputCase, r.Label, r.Story, location),
            Story            = r.Story,
            ColumnLabel      = r.Label,
            UniqueName       = r.UniqueName,
            OriginalOutputCase = r.OutputCase,
            EndLocation      = location,
            Station          = r.Station,
            NEd              = SMath.Round(-r.P  * forceFactor,  3),
            Vx               = SMath.Round( r.V2 * forceFactor,  3),
            Vy               = SMath.Round( r.V3 * forceFactor,  3),
            Mx               = SMath.Round( r.M2 * momentFactor, 3),
            My               = SMath.Round( r.M3 * momentFactor, 3),
            T                = SMath.Round( r.T  * momentFactor, 3),
            SourceType       = r.SourceType,
            ObjectType       = r.ObjectType,
            MatchStatus      = string.Empty
        };
    }

    // -------------------------------------------------------------------------
    // Helpers
    // -------------------------------------------------------------------------

    private static string BuildLoadCaseName(string outputCase, string label, string story, string location)
        => $"{outputCase}-{label}-{story}-{location}";

    // Append StepType suffix only for multi-step cases (envelope rows have StepType = "Max", "Min", etc.)
    private static string NormalizeOutputCase(string outputCase, string stepType)
    {
        if (string.IsNullOrEmpty(stepType)) return outputCase;
        if (stepType.Equals("Linear Add",    StringComparison.OrdinalIgnoreCase)) return outputCase;
        if (stepType.Equals("NonLinear Add", StringComparison.OrdinalIgnoreCase)) return outputCase;
        return $"{outputCase} ({stepType})";
    }

    private static string ResolveField(IReadOnlyDictionary<string, string> dict, params string[] keys)
    {
        foreach (var k in keys)
        {
            if (dict.TryGetValue(k.Trim(), out var v)) return v ?? "";
        }
        // Fallback: partial prefix match (handles "Station (m)" for key "Station")
        foreach (var k in keys)
        {
            var match = dict.Keys.FirstOrDefault(dk =>
                dk.StartsWith(k.Trim(), StringComparison.OrdinalIgnoreCase));
            if (match != null) return dict[match] ?? "";
        }
        return "";
    }

    // ETABS appends numeric suffixes to combo names in design tables (e.g. "1.35DL-1").
    // Accept the row if the table value starts with the requested combo name.
    private static bool MatchesAny(string tableValue, HashSet<string> selected)
        => selected.Contains(tableValue)
        || selected.Any(s => tableValue.StartsWith(s, StringComparison.OrdinalIgnoreCase));

    private static double ParseD(string s)
        => double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : 0.0;

    private static (double ForceFactor, double LengthFactor, double MomentFactor) GetUnitFactors(
        eUnits presentUnits, UnitSystem targetSystem)
    {
        var (fKn, lMm) = EtabsConnectionService.GetConversionFactors(presentUnits, targetSystem);
        return (fKn, lMm, EtabsConnectionService.GetMomentFactor(fKn, lMm, targetSystem));
    }
}
