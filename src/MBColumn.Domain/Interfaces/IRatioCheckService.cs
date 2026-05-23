using MBColumn.Domain.Entities;

namespace MBColumn.Domain.Interfaces;

public interface IRatioCheckService
{
    RatioResult Check(InteractionSurface surface, LoadDemand demand);
    IReadOnlyList<RatioResult> CheckBatch(InteractionSurface surface, IReadOnlyList<LoadDemand> demands);
}

