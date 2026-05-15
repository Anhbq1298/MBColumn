using MBColumn.Domain.Enums;

namespace MBColumn.Infrastructure.Solvers.Pmm;

public static class SectionIntegratorFactory
{
    public static ISectionIntegrator Create(SectionIntegrationMethod method)
        => method switch
        {
            SectionIntegrationMethod.Fiber => new FiberSectionIntegrator(),
            SectionIntegrationMethod.Polygon => new PolygonSectionIntegrator(),
            _ => throw new NotSupportedException($"Unsupported integration method: {method}")
        };
}
