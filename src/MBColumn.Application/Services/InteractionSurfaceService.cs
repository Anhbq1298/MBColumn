using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public sealed class InteractionSurfaceService(IInteractionSolver solver)
{
    public InteractionSurface Build(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
        => solver.Solve(section, concrete, steel);
}

