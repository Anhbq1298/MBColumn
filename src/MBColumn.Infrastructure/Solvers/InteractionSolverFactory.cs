using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciConventionalSolver;
    private readonly IInteractionSolver aciFiberSolver;
    private readonly IInteractionSolver ec2BoundarySolver         = new Ec2BoundaryInteractionSolver();
    private readonly IInteractionSolver ec2FiberSolver;
    private readonly IInteractionSolver ec2SimplifiedBlockSolver  = new Ec2SimplifiedStressBlockInteractionSolver();

    public InteractionSolverFactory(IDesignCodeService aci, IDesignCodeService ec2)
    {
        aciConventionalSolver = new StrainCompatibilityInteractionSolver(aci);
        aciFiberSolver = new AciFiberInteractionSolver(aci);
        ec2FiberSolver = new EcPmmFiberAnalyticSolver(ec2);
    }

    public IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.Boundary,
        AciSolverType aciSolver = AciSolverType.Conventional) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver switch
        {
            Ec2SolverType.Fiber                => ec2FiberSolver,
            Ec2SolverType.SimplifiedStressBlock => ec2SimplifiedBlockSolver,
            _                                   => ec2BoundarySolver
        },
        _ => aciSolver == AciSolverType.Fiber ? aciFiberSolver : aciConventionalSolver
    };
}
