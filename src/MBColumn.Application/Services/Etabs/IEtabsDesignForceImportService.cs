using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsDesignForceImportService
{
    /// <summary>
    /// Reads raw Design Forces - Columns and Design Forces - Piers tables from the currently
    /// connected ETABS model and returns them as unfiltered, unconverted records.
    /// </summary>
    ImportedEtabsForceDatabase ImportDesignForces(string modelFilePath, string modelName);

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
}
