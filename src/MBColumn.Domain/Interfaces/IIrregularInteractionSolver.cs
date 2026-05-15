using MBColumn.Domain.Entities;

namespace MBColumn.Domain.Interfaces;

public interface IIrregularInteractionSolver
{
    InteractionSurface Solve(IrregularSection section, ConcreteMaterial concrete, SteelMaterial steel);
}
