using ColumnDesigner.Domain.Entities;

namespace ColumnDesigner.Domain.Interfaces;

public interface IInteractionSolver
{
    InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel);
}
