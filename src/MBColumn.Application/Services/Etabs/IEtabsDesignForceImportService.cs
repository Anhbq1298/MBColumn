using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsDesignForceImportService
{
    ImportedEtabsForceDatabase ImportDesignForces(
        string modelFilePath,
        string modelName,
        UnitSystem targetSystem,
        bool loadColumnForces = true,
        bool loadPierForces = true,
        Action<int, string, int>? progressCallback = null,
        IReadOnlyList<string>? combosFilter = null);

    /// <summary>
    /// Returns true if the database contains any design force records (column or pier).
    /// </summary>
    bool HasDesignResults(ImportedEtabsForceDatabase database);

    // ── Per-table loaders (used for step-by-step preload progress) ──────────

    EtabsDesignForceTable LoadColumnElementForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null);
    EtabsDesignForceTable LoadPierElementForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null);
    EtabsDesignForceTable LoadColumnDesignForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null);
    EtabsDesignForceTable LoadPierDesignForcesTable(UnitSystem targetSystem, IReadOnlyList<string>? combosFilter = null);

    ImportedEtabsForceDatabase BuildDatabase(
        string modelFilePath,
        string modelName,
        UnitSystem targetSystem,
        EtabsDesignForceTable colElementForces,
        EtabsDesignForceTable pierElementForces,
        EtabsDesignForceTable colDesignForces,
        EtabsDesignForceTable pierDesignForces);

    /// <summary>
    /// Parses column forces from a previously imported raw database, applying column filter,
    /// combo filter, and unit conversion to the target system.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParseColumnForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    /// <summary>
    /// Parses pier forces from a previously imported raw database, applying pier filter,
    /// combo filter, and unit conversion to the target system.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParsePierForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    /// <summary>
    /// Parses ALL column forces from the raw database without any column or combo filter.
    /// Used by the force cache resolver to retrieve complete cached data for per-section filtering.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParseAllColumnForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem);

    /// <summary>
    /// Parses ALL pier forces from the raw database without any pier or combo filter.
    /// Used by the force cache resolver to retrieve complete cached data for per-section filtering.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParseAllPierForces(
        ImportedEtabsForceDatabase database,
        UnitSystem targetSystem);

    /// <summary>
    /// Parses column element forces from a previously imported raw database, applying column filter,
    /// combo filter, and unit conversion to the target system.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParseColumnElementForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    /// <summary>
    /// Parses pier element forces from a previously imported raw database, applying pier filter,
    /// combo filter, and unit conversion to the target system.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> ParsePierElementForces(
        ImportedEtabsForceDatabase database,
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);
}
