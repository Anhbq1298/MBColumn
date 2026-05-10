using ColumnDesigner.Domain.Entities;

namespace ColumnDesigner.Domain.Interfaces;

public interface IRatioCheckService
{
    RatioResult Check(InteractionSurface surface, LoadDemand demand);
}
