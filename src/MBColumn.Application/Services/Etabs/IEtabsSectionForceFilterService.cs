using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsSectionForceFilterService
{
    /// <summary>
    /// For each MB Column Section, filters force rows from the resolver by selected Story+Label,
    /// maps ETABS M2/M3 to MBColumn Mx/My, and generates LoadCaseName.
    /// </summary>
    IReadOnlyList<MbColumnMappedForceRow> FilterForcesForSection(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows,
        EtabsImportedObjectType objectType);

    /// <summary>
    /// Returns items in the section that have no matching force rows.
    /// </summary>
    IReadOnlyList<MbColumnSectionImportItem> FindMissingItems(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows);
}
