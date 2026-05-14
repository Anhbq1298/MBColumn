using MBColumn.Domain.Entities;

namespace MBColumn.Domain.Interfaces;

public interface ICircularInteractionSolver
{
    InteractionSurface Solve(CircularSection section, ConcreteMaterial concrete, SteelMaterial steel);
}
