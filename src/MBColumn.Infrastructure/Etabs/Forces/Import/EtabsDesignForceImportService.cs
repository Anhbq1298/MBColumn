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

    public ImportedEtabsForceDatabase ImportDesignForces(
        string modelFilePath,
        string modelName,
        UnitSystem targetSystem,
        bool loadColumnForces = true,
        bool loadPierForces = true,
        Action<int, string, int>? progressCallback = null,
        IReadOnlyList<string>? combosFilter = null)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        var dbUnits = (int)model.GetDatabaseUnits();
        var warnings = new List<string>();
        var comboSet = BuildComboSet(combosFilter);

        SetCombosForOutput(model, comboSet);

        progressCallback?.Invoke(10, "Loading Column Design Forces...", 4);
        var columnTable = loadColumnForces
            ? LoadAndFilter(model, ColumnTableKeys, "Design Forces - Columns", warnings, comboSet)
            : EmptyTable("Design Forces - Columns");

        progressCallback?.Invoke(30, "Loading Pier Design Forces...", 4);
        var pierTable = loadPierForces
            ? LoadAndFilter(model, PierTableKeys, "Design Forces - Piers", warnings, comboSet)
            : EmptyTable("Design Forces - Piers");

        progressCallback?.Invoke(50, "Loading Column Element Forces...", 4);
        var colElementTable = loadColumnForces
            ? LoadAndFilter(model, ["Element Forces - Columns"], "Element Forces - Columns", warnings, comboSet)
            : EmptyTable("Element Forces - Columns");

        progressCallback?.Invoke(70, "Loading Pier Element Forces...", 4);
        var pierElementTable = loadPierForces
            ? LoadAndFilter(model, ["Pier Forces"], "Pier Forces", warnings, comboSet)
            : EmptyTable("Pier Forces");

        progressCallback?.Invoke(90, "Finalizing Database...", 4);

        return new ImportedEtabsForceDatabase
        {
            ModelFilePath       = modelFilePath,
            ModelName           = modelName,
            ImportedAt          = DateTime.UtcNow,
            DatabaseUnits       = dbUnits,
            ColumnForces        = columnTable,
            PierForces          = pierTable,
            ColumnElementForces = colElementTable,
            PierElementForces   = pierElementTable,
            Warnings            = warnings
        };
    }

    public bool HasDesignResults(ImportedEtabsForceDatabase database)
        => database.ColumnForces.HasRecords || database.PierForces.HasRecords;

    public EtabsDesignForceTable LoadColumnElementForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null)
    {
        var model = connection.Model ?? throw new InvalidOperationException("Not connected to ETABS.");
        var comboSet = BuildComboSet(combosFilter);
        SetCombosForOutput(model, comboSet);
        return LoadAndFilter(model, ["Element Forces - Columns"], "Element Forces - Columns", [], comboSet);
    }

    public EtabsDesignForceTable LoadPierElementForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null)
    {
        var model = connection.Model ?? throw new InvalidOperationException("Not connected to ETABS.");
        var comboSet = BuildComboSet(combosFilter);
        SetCombosForOutput(model, comboSet);
        return LoadAndFilter(model, ["Pier Forces"], "Pier Forces", [], comboSet);
    }

    public EtabsDesignForceTable LoadColumnDesignForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null)
    {
        var model = connection.Model ?? throw new InvalidOperationException("Not connected to ETABS.");
        var comboSet = BuildComboSet(combosFilter);
        SetCombosForOutput(model, comboSet);
        return LoadAndFilter(model, ColumnTableKeys, "Design Forces - Columns", [], comboSet);
    }

    public EtabsDesignForceTable LoadPierDesignForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null)
    {
        var model = connection.Model ?? throw new InvalidOperationException("Not connected to ETABS.");
        var comboSet = BuildComboSet(combosFilter);
        SetCombosForOutput(model, comboSet);
        return LoadAndFilter(model, PierTableKeys, "Design Forces - Piers", [], comboSet);
    }

    public ImportedEtabsForceDatabase BuildDatabase(
        string modelFilePath,
        string modelName,
        UnitSystem targetSystem,
        EtabsDesignForceTable colElementForces,
        EtabsDesignForceTable pierElementForces,
        EtabsDesignForceTable colDesignForces,
        EtabsDesignForceTable pierDesignForces)
    {
        var model = connection.Model ?? throw new InvalidOperationException("Not connected to ETABS.");
        return new ImportedEtabsForceDatabase
        {
            ModelFilePath       = modelFilePath,
            ModelName           = modelName,
            ImportedAt          = DateTime.UtcNow,
            DatabaseUnits       = (int)model.GetDatabaseUnits(),
            ColumnForces        = colDesignForces,
            PierForces          = pierDesignForces,
            ColumnElementForces = colElementForces,
            PierElementForces   = pierElementForces,
            Warnings            = []
        };
    }

    private static (double ForceFactor, double LengthFactor, double MomentFactor) GetParseMultipliers(ImportedEtabsForceDatabase database, UnitSystem targetSystem)
    {
        var (targetUnits, fFactor, lFactor, mFactor) = EtabsConnectionService.GetSyncUnitFactors(targetSystem);
        if (database.DatabaseUnits == (int)targetUnits)
        {
            return (fFactor, lFactor, mFactor);
        }
        
        var (fKn, lMm) = EtabsConnectionService.GetConversionFactors((eUnits)database.DatabaseUnits, targetSystem);
        return (fKn, lMm, EtabsConnectionService.GetMomentFactor(fKn, lMm, targetSystem));
    }

    public IReadOnlyList<EtabsForceResultDto> ParseColumnForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        if (!database.ColumnForces.HasRecords || columns.Count == 0 || loadCombinations.Count == 0)
            return [];

        var (forceToKn, lengthToMm, momentFactor) = GetParseMultipliers(database, targetSystem);

        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);
        var columnByStoryLabel = new Dictionary<string, EtabsColumnImportDto>(
            StringComparer.OrdinalIgnoreCase);
        foreach (var col in columns)
            columnByStoryLabel.TryAdd($"{col.StoryName.Trim()}|{col.Label.Trim()}", col);

        // Phase 1: collect matching candidates with raw station string
        var candidates = new List<(EtabsColumnImportDto Col, string Combo, string RawStation,
                                   double P, double M2, double M3, double V2, double V3)>();

        foreach (var record in database.ColumnForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story").Trim();
            var label = GetFieldAny(f, "Label", "Column", "UniqueName").Trim();
            var combo = GetFieldAny(f, "Combo", "DesignCombo", "Design Combo").Trim();

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(label)) continue;
            if (!ComboMatches(combo, selectedCombos)) continue;
            if (!columnByStoryLabel.TryGetValue($"{story}|{label}", out var col)) continue;

            var rawStation = GetFieldAny(f, "Station", "Location");
            if (string.IsNullOrEmpty(rawStation)) rawStation = "Top";

            candidates.Add((col, combo, rawStation,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "Vu2")),
                ParseDouble(GetFieldAny(f, "V3", "Vu3"))));
        }

        // Phase 2: build station ranges per (objectName, combo) → min = Bottom, max = Top
        var stationRanges = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var (col, combo, rawStation, _, _, _, _, _) in candidates)
        {
            if (TryParseDouble(rawStation) is double sv)
            {
                var rk = $"{col.ObjectName}|{combo}";
                if (stationRanges.TryGetValue(rk, out var ex))
                    stationRanges[rk] = (SMath.Min(ex.Min, sv), SMath.Max(ex.Max, sv));
                else
                    stationRanges[rk] = (sv, sv);
            }
        }

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (col, combo, rawStation, p, m2, m3, v2, v3) in candidates)
        {
            string station;
            if (TryParseDouble(rawStation) is double sv)
            {
                var rk = $"{col.ObjectName}|{combo}";
                station = stationRanges.TryGetValue(rk, out var range)
                    ? NormalizeNumericStation(rawStation, range.Min, range.Max)
                    : NormalizeStation(rawStation);
            }
            else
            {
                station = NormalizeStation(rawStation);
            }

            if (station == "Mid") continue;

            var key = $"{col.ObjectName}|{combo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                col.ObjectName, col.PierName, col.StoryName, col.Label, col.EtabsSectionName,
                combo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn,   3),
                SMath.Round(v3 * forceToKn,   3),
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

        var (forceToKn, _, momentFactor) = GetParseMultipliers(database, targetSystem);

        var requestedPiers = new HashSet<string>(
            piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
            StringComparer.OrdinalIgnoreCase);
        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        var candidates = new List<(string Pier, string Story, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2, double V3)>();

        foreach (var record in database.PierForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story").Trim();
            var pier  = GetFieldAny(f, "Pier", "Label", "Pier Name").Trim();
            var combo = GetFieldAny(f, "OutputCase", "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(pier)) continue;
            if (!ComboMatches(combo, selectedCombos)) continue;
            if (!requestedPiers.Contains($"{pier}|{story}")) continue;

            var stepType = GetField(f, "StepType");
            var rawLoc = GetFieldAny(f, "Location", "Station", "Loc");
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((pier, story, combo, stepType, rawLoc,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "Vu2")),
                ParseDouble(GetFieldAny(f, "V3", "Vu3"))));
        }

        // Phase 2: build station ranges per (pier|story, effectiveCombo)
        var stationRangesPier = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var (pier, story, combo, stepType, rawLoc, _, _, _, _, _) in candidates)
        {
            if (TryParseDouble(rawLoc) is double sv)
            {
                var isSingle = string.IsNullOrEmpty(stepType)
                    || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                    || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
                var effCombo = isSingle ? combo : $"{combo} ({stepType})";
                var rk = $"{pier}|{story}|{effCombo}";
                if (stationRangesPier.TryGetValue(rk, out var ex))
                    stationRangesPier[rk] = (SMath.Min(ex.Min, sv), SMath.Max(ex.Max, sv));
                else
                    stationRangesPier[rk] = (sv, sv);
            }
        }

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (pier, story, combo, stepType, rawLoc, p, m2, m3, v2, v3) in candidates)
        {
            var isSingleStep = string.IsNullOrEmpty(stepType)
                || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
            var effectiveCombo = isSingleStep ? combo : $"{combo} ({stepType})";

            string station;
            if (TryParseDouble(rawLoc) is double sv)
            {
                var rk = $"{pier}|{story}|{effectiveCombo}";
                station = stationRangesPier.TryGetValue(rk, out var range)
                    ? NormalizeNumericStation(rawLoc, range.Min, range.Max)
                    : NormalizeStation(rawLoc);
            }
            else
            {
                station = NormalizeStation(rawLoc);
            }

            if (station == "Mid") continue;

            var key = $"{pier}|{story}|{effectiveCombo}|{station}";
            if (!seen.Add(key)) continue;

            var status = string.Equals(station, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Design Bottom"
                : "Design Force";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                station,
                status));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> ParseAllColumnForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem)
    {
        if (!database.ColumnForces.HasRecords) return [];

        var (forceToKn, _, momentFactor) = GetParseMultipliers(database, targetSystem);

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

        var results = new List<EtabsForceResultDto>(candidates.Count);
        var seen    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (story, label, combo, rawStation, p, m2, m3, v2) in candidates)
        {
            var station = TryParseDouble(rawStation) is double sv
                ? sv.ToString("G6", CultureInfo.InvariantCulture)
                : NormalizeStation(rawStation);

            var key = $"{story}|{label}|{combo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                $"{story}/{label}", "", story, label, "",
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

    public IReadOnlyList<EtabsForceResultDto> ParseAllPierForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem)
    {
        if (!database.PierForces.HasRecords) return [];

        var (forceToKn, _, momentFactor) = GetParseMultipliers(database, targetSystem);

        var candidates = new List<(string Pier, string Story, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2, double V3)>();

        foreach (var record in database.PierForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story").Trim();
            var pier  = GetFieldAny(f, "Pier", "Label", "Pier Name").Trim();
            var combo = GetFieldAny(f, "OutputCase", "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();
            var stepType = GetField(f, "StepType");
            var rawLoc = GetFieldAny(f, "Location", "Station", "Loc");
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(pier)) continue;

            candidates.Add((pier, story, combo, stepType, rawLoc,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "Vu2")),
                ParseDouble(GetFieldAny(f, "V3", "Vu3"))));
        }

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

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

            var status = string.Equals(station, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Design Bottom"
                : "Design Force";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                station,
                status));
        }

        return results;
    }

    // -----------------------------------------------------------------------
    // Private helpers
    public IReadOnlyList<EtabsForceResultDto> ParseColumnElementForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        if (!database.ColumnElementForces.HasRecords || columns.Count == 0 || loadCombinations.Count == 0)
            return [];

        var (forceToKn, lengthToMm, momentFactor) = GetParseMultipliers(database, targetSystem);

        var columnByStoryLabel = new Dictionary<string, EtabsColumnImportDto>(StringComparer.OrdinalIgnoreCase);
        foreach (var col in columns)
            columnByStoryLabel.TryAdd($"{col.StoryName.Trim()}|{col.Label.Trim()}", col);
        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        var candidates = new List<(EtabsColumnImportDto Col, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2, double V3)>();

        foreach (var record in database.ColumnElementForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story").Trim();
            var label = GetFieldAny(f, "Column", "Label", "UniqueName").Trim();
            var combo = GetFieldAny(f, "OutputCase", "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(label)) continue;
            if (!ComboMatches(combo, selectedCombos)) continue;
            if (!columnByStoryLabel.TryGetValue($"{story}|{label}", out var col)) continue;

            var stepType = GetField(f, "StepType");
            var rawLoc = GetFieldAny(f, "Station", "Location", "Loc", "ElemStation", "ObjSta");
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((col, combo, stepType, rawLoc,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M22", "Moment 2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M33", "Moment 3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "V22", "Shear 2", "Vu2")),
                ParseDouble(GetFieldAny(f, "V3", "V33", "Shear 3", "Vu3"))));
        }

        // Build numeric station ranges per (objectName, effectiveCombo) for Bottom/Top normalization
        var stationRangesCol = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var (col, combo, stepType, rawLoc, _, _, _, _, _) in candidates)
        {
            if (TryParseDouble(rawLoc) is double sv)
            {
                var isSingle = string.IsNullOrEmpty(stepType)
                    || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                    || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
                var effCombo = isSingle ? combo : $"{combo} ({stepType})";
                var rk = $"{col.ObjectName}|{effCombo}";
                if (stationRangesCol.TryGetValue(rk, out var ex))
                    stationRangesCol[rk] = (SMath.Min(ex.Min, sv), SMath.Max(ex.Max, sv));
                else
                    stationRangesCol[rk] = (sv, sv);
            }
        }

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (col, combo, stepType, rawLoc, p, m2, m3, v2, v3) in candidates)
        {
            var isSingleStep = string.IsNullOrEmpty(stepType)
                || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
            var effectiveCombo = isSingleStep ? combo : $"{combo} ({stepType})";

            string station;
            if (TryParseDouble(rawLoc) is double sv)
            {
                var rk = $"{col.ObjectName}|{effectiveCombo}";
                station = stationRangesCol.TryGetValue(rk, out var range)
                    ? NormalizeNumericStation(rawLoc, range.Min, range.Max)
                    : NormalizeStation(rawLoc);
            }
            else
            {
                station = NormalizeStation(rawLoc);
            }

            if (station == "Mid") continue;

            var key = $"{col.StoryName}|{col.Label}|{effectiveCombo}|{station}";
            if (!seen.Add(key)) continue;

            results.Add(new EtabsForceResultDto(
                $"{col.StoryName}:{col.Label}", col.Label, col.StoryName, col.Label, col.Label,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                station,
                "Element Force"));
        }

        return results;
    }

    public IReadOnlyList<EtabsForceResultDto> ParsePierElementForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem)
    {
        if (!database.PierElementForces.HasRecords || piers.Count == 0 || loadCombinations.Count == 0)
            return [];

        var (forceToKn, _, momentFactor) = GetParseMultipliers(database, targetSystem);

        var requestedPiers = new HashSet<string>(
            piers.Select(x => $"{x.PierLabel.Trim()}|{x.StoryName.Trim()}"),
            StringComparer.OrdinalIgnoreCase);
        var selectedCombos = new HashSet<string>(loadCombinations, StringComparer.OrdinalIgnoreCase);

        var candidates = new List<(string Pier, string Story, string Combo, string StepType,
                                   string RawLoc, double P, double M2, double M3, double V2, double V3)>();

        foreach (var record in database.PierElementForces.Records)
        {
            var f     = record.Fields;
            var story = GetField(f, "Story").Trim();
            var pier  = GetFieldAny(f, "Pier", "Label", "Pier Name").Trim();
            var combo = GetFieldAny(f, "OutputCase", "Combo", "DesignCombo", "Design Combo", "Load Combo", "LoadCombo").Trim();

            if (string.IsNullOrEmpty(story) || string.IsNullOrEmpty(pier)) continue;
            if (!ComboMatches(combo, selectedCombos)) continue;
            if (!requestedPiers.Contains($"{pier}|{story}")) continue;

            var stepType = GetField(f, "StepType");
            var rawLoc = GetFieldAny(f, "Station", "Location", "Loc", "ElemStation", "ObjSta");
            if (string.IsNullOrEmpty(rawLoc)) rawLoc = "Top";

            candidates.Add((pier, story, combo, stepType, rawLoc,
                ParseDouble(GetFieldAny(f, "P", "Pu")),
                ParseDouble(GetFieldAny(f, "M2", "M22", "Moment 2", "M2 Top", "M2-Top", "Mu2")),
                ParseDouble(GetFieldAny(f, "M3", "M33", "Moment 3", "M3 Top", "M3-Top", "Mu3")),
                ParseDouble(GetFieldAny(f, "V2", "V22", "Shear 2", "Vu2")),
                ParseDouble(GetFieldAny(f, "V3", "V33", "Shear 3", "Vu3"))));
        }

        // Build numeric station ranges per (pier|story, effectiveCombo) for Bottom/Top normalization
        var stationRangesPier = new Dictionary<string, (double Min, double Max)>(StringComparer.OrdinalIgnoreCase);
        foreach (var (pier, story, combo, stepType, rawLoc, _, _, _, _, _) in candidates)
        {
            if (TryParseDouble(rawLoc) is double sv)
            {
                var isSingle = string.IsNullOrEmpty(stepType)
                    || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                    || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
                var effCombo = isSingle ? combo : $"{combo} ({stepType})";
                var rk = $"{pier}|{story}|{effCombo}";
                if (stationRangesPier.TryGetValue(rk, out var ex))
                    stationRangesPier[rk] = (SMath.Min(ex.Min, sv), SMath.Max(ex.Max, sv));
                else
                    stationRangesPier[rk] = (sv, sv);
            }
        }

        var results = new List<EtabsForceResultDto>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var (pier, story, combo, stepType, rawLoc, p, m2, m3, v2, v3) in candidates)
        {
            var isSingleStep = string.IsNullOrEmpty(stepType)
                || stepType.Contains("Linear Add", StringComparison.OrdinalIgnoreCase)
                || stepType.Contains("NonLinear Add", StringComparison.OrdinalIgnoreCase);
            var effectiveCombo = isSingleStep ? combo : $"{combo} ({stepType})";

            string station;
            if (TryParseDouble(rawLoc) is double sv)
            {
                var rk = $"{pier}|{story}|{effectiveCombo}";
                station = stationRangesPier.TryGetValue(rk, out var range)
                    ? NormalizeNumericStation(rawLoc, range.Min, range.Max)
                    : NormalizeStation(rawLoc);
            }
            else
            {
                station = NormalizeStation(rawLoc);
            }

            if (station == "Mid") continue;

            var key = $"{pier}|{story}|{effectiveCombo}|{station}";
            if (!seen.Add(key)) continue;

            var status = string.Equals(station, "Bottom", StringComparison.OrdinalIgnoreCase)
                ? "Element Bottom"
                : "Element Force";

            results.Add(new EtabsForceResultDto(
                $"pier:{pier}:{story}", pier, story, pier, pier,
                effectiveCombo,
                SMath.Round(-p * forceToKn, 3),
                SMath.Round(m2 * momentFactor, 3),
                SMath.Round(m3 * momentFactor, 3),
                SMath.Round(v2 * forceToKn, 3),
                SMath.Round(v3 * forceToKn, 3),
                station,
                status));
        }

        return results;
    }

    // -----------------------------------------------------------------------
    // Combo-filtered loading helpers

    private static HashSet<string>? BuildComboSet(IReadOnlyList<string>? combosFilter)
        => combosFilter is { Count: > 0 }
            ? new HashSet<string>(combosFilter, StringComparer.OrdinalIgnoreCase)
            : null;

    // Tell ETABS which combos to include in display tables before querying.
    // This is the primary filter — ETABS will only write rows for selected combos,
    // which avoids fetching thousands of unneeded rows from a large model.
    private static void SetCombosForOutput(cSapModel model, HashSet<string>? comboSet)
    {
        if (comboSet is null) return;

        // Results API (affects cResults tables)
        model.Results.Setup.DeselectAllCasesAndCombosForOutput();
        foreach (var name in comboSet)
            model.Results.Setup.SetComboSelectedForOutput(name, true);

        // DatabaseTables API (affects GetTableForDisplayArray / GetTableForEditingArray)
        var comboArray = comboSet.ToArray();
        model.DatabaseTables.SetLoadCombinationsSelectedForDisplay(ref comboArray);
    }

    private static EtabsDesignForceTable LoadAndFilter(
        cSapModel model, string[] tableKeys, string defaultKey,
        List<string> warnings, HashSet<string>? comboSet)
    {
        var table = LoadRawTable(model, tableKeys, defaultKey, warnings);
        return comboSet is not null ? FilterTableByCombos(table, comboSet) : table;
    }

    private static EtabsDesignForceTable FilterTableByCombos(
        EtabsDesignForceTable table, HashSet<string> comboSet)
    {
        if (!table.HasRecords) return table;

        var filtered = table.Records
            .Where(r =>
            {
                var combo = GetFieldAny(r.Fields,
                    "Combo", "DesignCombo", "Design Combo",
                    "OutputCase", "Load Combo", "LoadCombo").Trim();
                return ComboMatches(combo, comboSet);
            })
            .ToList();

        return new EtabsDesignForceTable
        {
            TableKey     = table.TableKey,
            TableVersion = table.TableVersion,
            FieldKeys    = table.FieldKeys,
            Records      = filtered
        };
    }

    private static EtabsDesignForceTable EmptyTable(string key)
        => new() { TableKey = key, FieldKeys = [], Records = [] };

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
                dict[fields[col].Trim()] = tableData[baseIdx + col] ?? "";

            records.Add(new EtabsDesignForceRecord
            {
                SourceTableKey = tableKey,
                Fields         = dict
            });
        }

        return records;
    }

    // ETABS appends a numeric suffix (e.g. "-1", "-2") to combination names in the Design Forces table.
    private static bool ComboMatches(string tableCombo, HashSet<string> selected)
        => selected.Contains(tableCombo)
        || selected.Any(s => tableCombo.StartsWith(s, StringComparison.OrdinalIgnoreCase));

    private static string GetField(IReadOnlyDictionary<string, string> f, string key)
        => f.TryGetValue(key, out var v) ? v ?? "" : "";

    private static string GetFieldAny(IReadOnlyDictionary<string, string> f, params string[] keys)
    {
        foreach (var k in keys)
            if (f.TryGetValue(k.Trim(), out var v)) return v ?? "";

        // Fallback: check if any dictionary key STARTS WITH the key (e.g., "Station (m)" starts with "Station")
        foreach (var k in keys)
        {
            var match = f.Keys.FirstOrDefault(dk => dk.StartsWith(k.Trim(), StringComparison.OrdinalIgnoreCase));
            if (match != null) return f[match] ?? "";
        }

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
