using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IInteractionSolverFactory
{
    Ec2SolverType Ec2Solver { get; set; }
    IInteractionSolver Get(DesignCodeType code);
}

