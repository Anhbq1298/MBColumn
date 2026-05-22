using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceCacheService : IDisposable
{
    bool IsBuilt { get; }
    string StatusText { get; }

    EtabsForceCacheBuildResult Build(IReadOnlyList<EtabsForceResultDto> forces);
    IReadOnlyList<EtabsForceResultDto> Query(EtabsForceCacheQuery query);
    void Clear();
}
