using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciSolver;
    private readonly IInteractionSolver ec2BoundarySolver = new Ec2BoundaryInteractionSolver();
    private readonly IInteractionSolver ec2FiberSolver = new Ec2FiberInteractionSolver();

    public Ec2SolverType Ec2Solver { get; set; } = Ec2SolverType.Boundary;

    public InteractionSolverFactory(IDesignCodeService aci, IDesignCodeService ec2)
    {
        _ = ec2;
        aciSolver = new StrainCompatibilityInteractionSolver(aci);
    }

    public IInteractionSolver Get(DesignCodeType code) => code switch
    {
        DesignCodeType.Ec2 => Ec2Solver == Ec2SolverType.Boundary ? ec2BoundarySolver : ec2FiberSolver,
        _                  => aciSolver
    };
}

