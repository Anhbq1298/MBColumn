using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;

namespace MBColumn.Tests.Verification;

public sealed class MbColumnPmmRunner
{
    public IReadOnlyList<PmmCalculatedPoint> Run(
        PmmMappedReferenceModel model,
        PmmRunOptions? options = null,
        IReadOnlyDictionary<int, int>? referenceToMbColumnTheta = null)
    {
        options ??= new PmmRunOptions();
        referenceToMbColumnTheta ??= model.ReferenceToMbColumnTheta;
        var service = CreateService(model.AlphaCc, options);
        var result = service.Calculate(model.Input);
        var calculated = new List<PmmCalculatedPoint>();

        foreach (var theta in model.Reference.ThetaDegrees)
        {
            int mbTheta = referenceToMbColumnTheta[theta];
            var points = result.Surface.Points
                .Where(p => (int)Math.Round(p.ThetaDegrees) == mbTheta)
                .OrderBy(p => p.DepthIndex)
                .ToList();

            if (points.Count == 0)
            {
                continue;
            }

            calculated.AddRange(points.Select(p => new PmmCalculatedPoint(
                theta,
                p.DepthIndex,
                -p.Pn / 1000.0,
                p.Mnx / 1_000_000.0,
                p.Mny / 1_000_000.0)));
        }

        return calculated;
    }

    public IReadOnlyList<PmmCalculatedPoint> RunAllAngles(PmmMappedReferenceModel model, PmmRunOptions? options = null)
    {
        options ??= new PmmRunOptions();
        var service = CreateService(model.AlphaCc, options);
        var result = service.Calculate(model.Input);

        return result.Surface.Points
            .OrderBy(p => p.ThetaDegrees)
            .ThenBy(p => p.DepthIndex)
            .Select(p => new PmmCalculatedPoint(
                (int)Math.Round(p.ThetaDegrees),
                p.DepthIndex,
                -p.Pn / 1000.0,
                p.Mnx / 1_000_000.0,
                p.Mny / 1_000_000.0))
            .ToList();
    }

    private static ColumnCalculationService CreateService(double alphaCc, PmmRunOptions options)
    {
        var aci = new Aci318DesignCodeService();
        var ec2 = new Ec2DesignCodeService { AlphaCc = alphaCc };
        var codeFactory = new DesignCodeServiceFactory(aci, ec2);
        var solverFactory = new OneDegreeEc2FiberSolverFactory(aci, ec2, options);
        IUnitConversionService units = new UnitConversionService();
        IRebarDatabase metric = new SingaporeRebarDatabase();
        IRebarDatabase imperial = new ImperialRebarDatabase();
        IRatioCheckService ratio = new RatioCheckService();
        IControlPointBuilder control = new ControlPointBuilderService(units);
        return new ColumnCalculationService(
            solverFactory,
            codeFactory,
            units,
            metric,
            imperial,
            ratio,
            control,
            new DiagramDataService(),
            new InputValidationService());
    }

    private sealed class OneDegreeEc2FiberSolverFactory : IInteractionSolverFactory
    {
        private readonly IInteractionSolver aciSolver;
        private readonly IInteractionSolver ec2Solver;

        public OneDegreeEc2FiberSolverFactory(IDesignCodeService aci, IDesignCodeService ec2, PmmRunOptions options)
        {
            aciSolver = new StrainCompatibilityInteractionSolver(aci);
            ec2Solver = options.SolverKind switch
            {
                PmmVerificationSolverKind.AnalyticParabolicFiber => new EcPmmFiberAnalyticSolver(ec2)
                {
                    AngleStepDegrees = options.AngleStepDegrees,
                    NeutralAxisSamples = options.NeutralAxisSamples
                },
                PmmVerificationSolverKind.GridParabolicFiber => new Ec2FiberInteractionSolver
                {
                    AngleStepDegrees = options.AngleStepDegrees,
                    NeutralAxisSamples = options.NeutralAxisSamples,
                    ConcreteGridDivisions = 80
                },
                PmmVerificationSolverKind.BoundaryParabolic => new Ec2BoundaryInteractionSolver
                {
                    AngleStepDegrees = options.AngleStepDegrees,
                    NeutralAxisSamples = options.NeutralAxisSamples
                },
                PmmVerificationSolverKind.SimplifiedStressBlock => new Ec2SimplifiedStressBlockInteractionSolver
                {
                    AngleStepDegrees = options.AngleStepDegrees,
                    NeutralAxisSamples = options.NeutralAxisSamples
                },
                _ => throw new ArgumentOutOfRangeException(nameof(options.SolverKind), options.SolverKind, "Unknown PMM verification solver kind.")
            };
        }

        public IInteractionSolver Get(
            DesignCodeType code,
            Ec2SolverType ec2SolverType = Ec2SolverType.Boundary,
            AciSolverType aciSolverType = AciSolverType.Conventional)
            => code == DesignCodeType.Ec2 ? ec2Solver : aciSolver;
    }
}
