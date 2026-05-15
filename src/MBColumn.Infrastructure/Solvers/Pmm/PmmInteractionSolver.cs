using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers.Pmm;

public sealed class PmmInteractionSolver(
    IDesignCodeService code,
    DesignCodeType designCodeType,
    SectionIntegrationMethod integrationMethod) : IInteractionSolver, ICircularInteractionSolver
{
    public double AngleStepDegrees { get; init; } = 10.0;
    public int NeutralAxisSamples { get; init; } = 100;
    public int RectangularFiberCountX { get; init; } = 40;
    public int RectangularFiberCountY { get; init; } = 40;
    public int CircularRadialFiberCount { get; init; } = 32;
    public int CircularAngularFiberCount { get; init; } = 72;
    public int CirclePolygonSegmentCount { get; init; } = 128;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
        => SolveCore(section, concrete, steel);

    public InteractionSurface Solve(CircularSection section, ConcreteMaterial concrete, SteelMaterial steel)
        => SolveCore(section, concrete, steel);

    private InteractionSurface SolveCore(ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        var settings = new SolverSettings
        {
            AngleStepDegrees = AngleStepDegrees,
            NeutralAxisSamples = NeutralAxisSamples,
            RectangularFiberCountX = RectangularFiberCountX,
            RectangularFiberCountY = RectangularFiberCountY,
            CircularRadialFiberCount = CircularRadialFiberCount,
            CircularAngularFiberCount = CircularAngularFiberCount,
            CirclePolygonSegmentCount = CirclePolygonSegmentCount,
            IntegrationMethod = integrationMethod
        };
        var solver = new PmmSolver(
            new NeutralAxisSweepStrategy(),
            SectionIntegratorFactory.Create(integrationMethod),
            DesignCodeAdapterFactory.Create(designCodeType));
        var result = solver.Solve(new PmmInput(section, concrete, steel, code, designCodeType, settings));
        int angleCount = SMath.Max(1, (int)SMath.Round(360.0 / AngleStepDegrees));
        return new InteractionSurface(NeutralAxisSamples, angleCount, result.Points);
    }
}
