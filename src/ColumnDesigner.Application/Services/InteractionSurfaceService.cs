using ColumnDesigner.Domain.Entities;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Application.Services;

public sealed class InteractionSurfaceService(IInteractionSolver solver)
{
    public InteractionSurface Build(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
        => solver.Solve(section, concrete, steel);
}
