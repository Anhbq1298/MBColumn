using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Interfaces;

public interface IInteractionSolverFactory
{
    IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.SimplifiedStressBlock,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Fiber);

    ICircularInteractionSolver GetCircular(
        DesignCodeType code,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Fiber);

    IIrregularInteractionSolver GetIrregular(
        DesignCodeType code,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Polygon);
}
