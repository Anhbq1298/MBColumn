using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Solvers.Legacy;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciConventionalSolver;
    private readonly IInteractionSolver aciFiberSolver;
    private readonly IInteractionSolver ec2SimplifiedBlockSolver;
    private readonly IInteractionSolver ec2FiberSolver;
    private readonly PmmInteractionSolver aciPmmFiberSolver;
    private readonly PmmInteractionSolver aciPmmPolygonSolver;
    private readonly PmmInteractionSolver ec2PmmFiberSolver;
    private readonly PmmInteractionSolver ec2PmmPolygonSolver;
    private readonly ICircularInteractionSolver aciCircularPolygonSolver;
    private readonly ICircularInteractionSolver ec2CircularPolygonSolver;
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
        aciPmmFiberSolver      = new PmmInteractionSolver(aci, DesignCodeType.Aci318Style, SectionIntegrationMethod.Fiber) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        aciPmmPolygonSolver    = new PmmInteractionSolver(aci, DesignCodeType.Aci318Style, SectionIntegrationMethod.Polygon) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2PmmFiberSolver      = new PmmInteractionSolver(ec2, DesignCodeType.Ec2, SectionIntegrationMethod.Fiber) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2PmmPolygonSolver    = new PmmInteractionSolver(ec2, DesignCodeType.Ec2, SectionIntegrationMethod.Polygon) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        aciCircularSolver      = new CircularFiberInteractionSolver(aci) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2CircularSolver      = new CircularFiberInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        aciCircularPolygonSolver = new PmmInteractionSolver(aci, DesignCodeType.Aci318Style, SectionIntegrationMethod.Polygon) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2CircularPolygonSolver = new PmmInteractionSolver(ec2, DesignCodeType.Ec2, SectionIntegrationMethod.Polygon) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ec2BoundarySolver      = new Ec2BoundaryInteractionSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
        ecPmmFiberAnalytic     = new EcPmmFiberAnalyticSolver(ec2) { AngleStepDegrees = 10.0, NeutralAxisSamples = 100 };
    }

    public IInteractionSolver Get(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.SimplifiedStressBlock,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Fiber) => integrationMethod switch
    {
        SectionIntegrationMethod.Polygon => code == DesignCodeType.Ec2 ? ec2PmmPolygonSolver : aciPmmPolygonSolver,
        SectionIntegrationMethod.Fiber => code == DesignCodeType.Ec2 ? ec2PmmFiberSolver : aciPmmFiberSolver,
        _ => throw new NotSupportedException($"Unsupported integration method: {integrationMethod}")
    };

    public IInteractionSolver GetLegacy(
        DesignCodeType code,
        Ec2SolverType ec2Solver = Ec2SolverType.SimplifiedStressBlock) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver switch
        {
            Ec2SolverType.Fiber                => ec2FiberSolver,
            Ec2SolverType.Boundary             => ec2BoundarySolver,
            Ec2SolverType.AnalyticFiber        => ecPmmFiberAnalytic,
            _                                  => ec2SimplifiedBlockSolver   // SimplifiedStressBlock is default
        },
        _ => aciConventionalSolver
    };

    public ICircularInteractionSolver GetCircular(
        DesignCodeType code,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Fiber)
        => integrationMethod switch
        {
            SectionIntegrationMethod.Polygon => code == DesignCodeType.Ec2 ? ec2CircularPolygonSolver : aciCircularPolygonSolver,
            SectionIntegrationMethod.Fiber => code == DesignCodeType.Ec2 ? ec2PmmFiberSolver : aciPmmFiberSolver,
            _ => throw new NotSupportedException($"Unsupported integration method: {integrationMethod}")
        };

    public IIrregularInteractionSolver GetIrregular(
        DesignCodeType code,
        SectionIntegrationMethod integrationMethod = SectionIntegrationMethod.Fiber)
        => integrationMethod switch
        {
            SectionIntegrationMethod.Fiber => code == DesignCodeType.Ec2 ? ec2PmmFiberSolver : aciPmmFiberSolver,
            SectionIntegrationMethod.Polygon => code == DesignCodeType.Ec2 ? ec2PmmPolygonSolver : aciPmmPolygonSolver,
            _ => throw new NotSupportedException($"Unsupported integration method: {integrationMethod}")
        };
}
