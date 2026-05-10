using MBColumn.Domain.Entities;

namespace MBColumn.Domain.Interfaces;

public interface IInteractionSolver
{
    InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel);
}

