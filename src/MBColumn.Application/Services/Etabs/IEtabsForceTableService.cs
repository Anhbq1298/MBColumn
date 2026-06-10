using MBColumn.Application.DTOs.Etabs.Forces;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

/// <summary>
/// Unified ETABS force import pipeline using cDatabaseTables.
/// Both Element Forces and Design Forces go through the same pipeline;
/// the only difference is the resolved table key.
/// </summary>
public interface IEtabsForceTableService
{
    /// <summary>
    /// Reads the appropriate ETABS database table for the given source and object type,
    /// normalizes all field names, applies the user filter criteria, and returns
    /// <see cref="EtabsForceRecord"/> rows with raw ETABS values (no unit conversion).
    /// Station values are numeric doubles as stored in the ETABS table.
    /// </summary>
    IReadOnlyList<EtabsForceRecord> GetNormalizedRecords(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType,
        EtabsForceFilterCriteria criteria);

    /// <summary>
    /// Takes the normalized records from <see cref="GetNormalizedRecords"/>,
    /// applies station grouping (min = Bottom, max = Top), converts force values
    /// to <paramref name="targetSystem"/> units, maps to MB Column convention
    /// (NEd = -P, Vx = V2, Vy = V3, Mx = M2, My = M3), and generates MB Column
    /// load case names.
    /// MBColumn X equals ETABS local 2 and MBColumn Y equals ETABS local 3;
    /// shear-flexure pairs remain Vx/My and Vy/Mx.
    /// </summary>
    IReadOnlyList<MbColumnForceRecord> MapToMbColumnRecords(
        IReadOnlyList<EtabsForceRecord> records,
        UnitSystem targetSystem);

    /// <summary>
    /// Convenience: calls <see cref="GetNormalizedRecords"/> then
    /// <see cref="MapToMbColumnRecords"/> in one step.
    /// </summary>
    IReadOnlyList<MbColumnForceRecord> GetMbColumnForceRecords(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType,
        EtabsForceFilterCriteria criteria,
        UnitSystem targetSystem);
}
