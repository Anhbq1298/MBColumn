using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public sealed class InteractionSolverFactory : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciSolver;
    private readonly IInteractionSolver ec2Solver = new Ec2FiberInteractionSolver();

    public InteractionSolverFactory(IDesignCodeService aci, IDesignCodeService ec2)
    {
        _ = ec2;
        aciSolver = new StrainCompatibilityInteractionSolver(aci);
    }

    public IInteractionSolver Get(DesignCodeType code) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver,
        _                  => aciSolver
    };
}

