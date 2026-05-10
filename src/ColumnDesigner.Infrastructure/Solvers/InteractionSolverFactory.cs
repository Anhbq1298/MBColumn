using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Infrastructure.Solvers;

public sealed class InteractionSolverFactory(
    IDesignCodeService aci,
    IDesignCodeService ec2) : IInteractionSolverFactory
{
    private readonly IInteractionSolver aciSolver = new StrainCompatibilityInteractionSolver(aci);
    private readonly IInteractionSolver ec2Solver = new StrainCompatibilityInteractionSolver(ec2);

    public IInteractionSolver Get(DesignCodeType code) => code switch
    {
        DesignCodeType.Ec2 => ec2Solver,
        _                  => aciSolver
    };
}
