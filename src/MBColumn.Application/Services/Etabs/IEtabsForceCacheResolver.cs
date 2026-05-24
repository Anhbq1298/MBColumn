using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceCacheResolver
{
    /// <summary>
    /// Returns cached force rows for the given source mode and object type.
    /// Resolver must not call ETABS — only returns from cached data.
    /// </summary>
    IReadOnlyList<EtabsForceResultDto> Resolve(
        MbColumnForceSourceMode sourceMode,
        EtabsImportedObjectType objectType);

    bool HasData(MbColumnForceSourceMode sourceMode, EtabsImportedObjectType objectType);
}
