using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Interfaces;

public interface IInteractionSolverFactory
{
    IInteractionSolver Get(DesignCodeType code);
}
