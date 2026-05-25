using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public sealed class EtabsForceCacheIdentity
{
    public MbColumnForceSourceMode ForceSource { get; set; }
    public EtabsImportedObjectType ObjectType { get; set; }
    public IReadOnlyList<string> SelectedCombos { get; set; } = [];
    public EtabsModelFingerprint Model { get; set; } = new();
    public DateTime CachedAt { get; set; }
}

public interface IEtabsForceCacheStore
{
    bool HasCache(EtabsForceCacheIdentity identity);
    void SaveCache(EtabsForceCacheIdentity identity, IReadOnlyList<EtabsForceResultDto> forces);
    IReadOnlyList<EtabsForceResultDto>? LoadCache(EtabsForceCacheIdentity identity);
    void Clear();
}
