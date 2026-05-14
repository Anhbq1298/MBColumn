using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciConventionalSolver;
    private readonly IInteractionSolver aciFiberSolver;
    private readonly IInteractionSolver ec2SimplifiedBlockSolver;
    private readonly IInteractionSolver ec2FiberSolver;
    private readonly ICircularInteractionSolver aciCircularSolver;
    private readonly ICircularInteractionSolver ec2CircularSolver;

    // Legacy solvers kept for backward compatibility — not routed as defaults.
    private readonly IInteractionSolver ec2BoundarySolver;
    private readonly IInteractionSolver ecPmmFiberAnalytic;

    public InteractionSolverFactory(IDesignCodeService aci, IDesignCodeService ec2)
    {
        aciConventionalSolver  = new StrainCompatibilityInteractionSolver(aci) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        aciFiberSolver         = new AciFiberInteractionSolver(aci) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2SimplifiedBlockSolver = new Ec2SimplifiedStressBlockInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2FiberSolver         = new Ec2FiberInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        aciCircularSolver      = new CircularFiberInteractionSolver(aci) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2CircularSolver      = new CircularFiberInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2BoundarySolver      = new Ec2BoundaryInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ecPmmFiberAnalytic     = new EcPmmFiberAnalyticSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
    }

    public IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.SimplifiedStressBlock,
        AciSolverType aciSolver = AciSolverType.Conventional) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver switch
        {
            Ec2SolverType.Fiber                => ec2FiberSolver,
            Ec2SolverType.Boundary             => ec2BoundarySolver,
            Ec2SolverType.AnalyticFiber        => ecPmmFiberAnalytic,
            _                                  => ec2SimplifiedBlockSolver   // SimplifiedStressBlock is default
        },
        _ => aciSolver == AciSolverType.Fiber ? aciFiberSolver : aciConventionalSolver
    };

    public ICircularInteractionSolver GetCircular(DesignCodeType code)
        => code == DesignCodeType.Ec2 ? ec2CircularSolver : aciCircularSolver;
}
