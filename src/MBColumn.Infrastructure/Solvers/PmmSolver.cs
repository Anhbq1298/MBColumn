using MBColumn.Domain.Entities;

namespace MBColumn.Infrastructure.Solvers;

public sealed class PmmSolver(
    ISweepStrategy sweepStrategy,
    ISectionIntegrator sectionIntegrator,
    IDesignCodeAdapter designCodeAdapter)
{
    public PmmResult Solve(PmmInput input)
    {
        var states = sweepStrategy.GenerateStates(input);
        var points = new List<InteractionPoint>(states.Count);

        foreach (var state in states)
        {
            var nominalResult = sectionIntegrator.Integrate(
                input.Section,
                input.Concrete,
                input.Steel,
                input.DesignCode,
                state,
                input.Settings);

            if (!nominalResult.IsValid)
            {
                continue;
            }

            var designPoint = designCodeAdapter.ApplyDesignRules(input, state, nominalResult);
            points.Add(designPoint.Point);
        }

        return new PmmResult(points);
    }
}
