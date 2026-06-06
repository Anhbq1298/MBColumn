using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Infrastructure.Etabs;

/// <summary>
/// Resolves the correct cached force rows by source mode and object type.
/// Design Forces use the preloaded ImportedEtabsForceDatabase.
/// Element Forces require ETABS connection (live COM) and are not pre-cached.
/// </summary>
public sealed class EtabsForceCacheResolver : IEtabsForceCacheResolver
{
    private readonly IImportedEtabsForceCache importedForceCache;
    private readonly IEtabsDesignForceImportService designForceImportService;
    private readonly UnitSystem targetUnitSystem;

    public EtabsForceCacheResolver(
        IImportedEtabsForceCache importedForceCache,
        IEtabsDesignForceImportService designForceImportService,
        UnitSystem targetUnitSystem)
    {
        this.importedForceCache = importedForceCache;
        this.designForceImportService = designForceImportService;
        this.targetUnitSystem = targetUnitSystem;
    }

    public IReadOnlyList<EtabsForceResultDto> Resolve(
        MbColumnForceSourceMode sourceMode,
        EtabsImportedObjectType objectType)
    {
        if (sourceMode == MbColumnForceSourceMode.DesignForces)
        {
            var db = importedForceCache.Current;
            if (db is null) return [];

            return objectType == EtabsImportedObjectType.Column
                ? designForceImportService.ParseAllColumnForces(db, targetUnitSystem)
                : designForceImportService.ParseAllPierForces(db, targetUnitSystem);
        }

        // Element Forces: not pre-cached — caller must use live COM
        return [];
    }

    public bool HasData(MbColumnForceSourceMode sourceMode, EtabsImportedObjectType objectType)
    {
        if (sourceMode == MbColumnForceSourceMode.DesignForces)
        {
            var db = importedForceCache.Current;
            if (db is null) return false;
            return objectType == EtabsImportedObjectType.Column
                ? db.ColumnForces.HasRecords
                : db.PierForces.HasRecords;
        }

        // Element Forces considered available only if connected (caller responsibility)
        return false;
    }
}
