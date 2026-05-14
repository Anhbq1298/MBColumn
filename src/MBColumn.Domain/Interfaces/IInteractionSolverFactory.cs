using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IInteractionSolverFactory
{
    IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.SimplifiedStressBlock,
        AciSolverType aciSolver = AciSolverType.Conventional);
}
