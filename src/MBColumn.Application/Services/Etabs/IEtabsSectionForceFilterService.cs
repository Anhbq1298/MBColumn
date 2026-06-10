using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsSectionForceFilterService
{
    /// <summary>
    /// For each MB Column Section, filters force rows from the resolver by selected Story+Label,
    /// maps ETABS M2 to MBColumn Mx, ETABS M3 to MBColumn My, ETABS V2 to Vx,
    /// and ETABS V3 to Vy. Shear-flexure pairs are Vx/My and Vy/Mx.
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
