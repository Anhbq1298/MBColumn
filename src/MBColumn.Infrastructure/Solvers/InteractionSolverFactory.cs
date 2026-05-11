using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciConventionalSolver;
    private readonly IInteractionSolver aciFiberSolver;
    private readonly IInteractionSolver ec2BoundarySolver = new Ec2BoundaryInteractionSolver();
    private readonly IInteractionSolver ec2FiberSolver = new Ec2FiberInteractionSolver();

    public InteractionSolverFactory(IDesignCodeService aci, IDesignCodeService ec2)
    {
        _ = ec2;
        aciConventionalSolver = new StrainCompatibilityInteractionSolver(aci);
        aciFiberSolver = new AciFiberInteractionSolver(aci);
    }

    public IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.Boundary,
        AciSolverType aciSolver = AciSolverType.Conventional) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver == Ec2SolverType.Boundary ? ec2BoundarySolver : ec2FiberSolver,
        _                  => aciSolver == AciSolverType.Fiber ? aciFiberSolver : aciConventionalSolver
    };
}
