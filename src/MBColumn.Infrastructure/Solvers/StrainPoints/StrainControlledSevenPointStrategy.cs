using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public sealed class StrainControlledSevenPointStrategy
{
    private readonly ISectionIntegrator _integrator;
    private readonly IStrainLimitDesignCodeAdapter _codeAdapter;
    private readonly IDesignCodeService _baseService;

    public StrainControlledSevenPointStrategy(
        ISectionIntegrator integrator, 
        IStrainLimitDesignCodeAdapter codeAdapter,
        IDesignCodeService baseService)
    {
        _integrator = integrator;
        _codeAdapter = codeAdapter;
        _baseService = baseService;
    }

    public IReadOnlyList<StrainControlledPmPointResult> GeneratePoints(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        double angleDegrees,
        SolverSettings settings)
    {
        var ey = _codeAdapter.GetSteelYieldStrain(steel);
        var cap = _codeAdapter.GetSteelTensionStrainLimit(steel);
        var ecu = _codeAdapter.GetConcreteUltimateCompressionStrain(concrete);

        // Transition strain for ACI is ey + 0.003, for EC2 is 0.005. We use max of 2*ey and ey+0.003 as a safe "tension controlled" point
        double transitionStrain = SMath.Max(2.0 * ey, ey + 0.003);

        List<StrainPointDefinition> definitions;
        if (_codeAdapter.CodeName == "Eurocode 2")
        {
            definitions = new List<StrainPointDefinition>
            {
                new() { PointName = "Pure Compression", PointType = StrainPointType.PureCompression },
                new() { PointName = "εs,t = 0", PointType = StrainPointType.ExtremeTensionStrainZero, TargetTensileSteelStrain = 0.0 },
                new() { PointName = "εs,t = 0.5εyd", PointType = StrainPointType.HalfYieldStrain, TargetTensileSteelStrain = 0.5 * ey },
                new() { PointName = "εs,t = εyd (Balanced)", PointType = StrainPointType.BalancedYieldStrain, TargetTensileSteelStrain = ey },
                new() { PointName = "N = 0 (Pure Bending)", PointType = StrainPointType.PureBending },
                new() { PointName = "εs,t = εud (Strain Cap)", PointType = StrainPointType.StrainCapLimit, TargetTensileSteelStrain = cap },
                new() { PointName = "Pure Tension", PointType = StrainPointType.PureTension }
            };
        }
        else
        {
            definitions = new List<StrainPointDefinition>
            {
                new() { PointName = "Pure Compression", PointType = StrainPointType.PureCompression },
                new() { PointName = "es = 0", PointType = StrainPointType.ExtremeTensionStrainZero, TargetTensileSteelStrain = 0.0 },
                new() { PointName = "es = 0.5ey", PointType = StrainPointType.HalfYieldStrain, TargetTensileSteelStrain = 0.5 * ey },
                new() { PointName = "es = ey (Balanced)", PointType = StrainPointType.BalancedYieldStrain, TargetTensileSteelStrain = ey },
                new() { PointName = "es = Transition", PointType = StrainPointType.TensionControlled, TargetTensileSteelStrain = transitionStrain },
                new() { PointName = "es = Strain Cap", PointType = StrainPointType.StrainCapLimit, TargetTensileSteelStrain = cap },
                new() { PointName = "Pure Tension", PointType = StrainPointType.PureTension }
            };
        }

        var results = new List<StrainControlledPmPointResult>(definitions.Count);

        double theta = angleDegrees * SMath.PI / 180.0;
        double nx = SMath.Cos(theta);
        double ny = SMath.Sin(theta);

        // Find max projection (compression edge)
        double maxProjection = NeutralAxisSweepStrategy.ProjectExtreme(section, nx, ny);

        // Find min projection of rebars (extreme tension steel)
        double minRebarProjection = double.PositiveInfinity;
        if (section.RebarLayout.Bars.Count > 0)
        {
            minRebarProjection = section.RebarLayout.Bars.Min(b => b.XMm * nx + b.YMm * ny);
        }
        else
        {
            minRebarProjection = -maxProjection; // Fallback if no rebars
        }

        double dt = maxProjection - minRebarProjection;

        foreach (var def in definitions)
        {
            if (def.PointType == StrainPointType.PureCompression)
            {
                results.Add(CalculatePureCompression(section, concrete, steel, def));
            }
            else if (def.PointType == StrainPointType.PureTension)
            {
                results.Add(CalculatePureTension(section, steel, def, nx, ny));
            }
            else if (def.PointType == StrainPointType.PureBending)
            {
                results.Add(CalculatePureBending(section, concrete, steel, def, nx, ny, theta, maxProjection, dt, ecu, angleDegrees, settings));
            }
            else
            {
                double es = def.TargetTensileSteelStrain ?? 0.0;
                double c = ecu * dt / (ecu + es);
                double na = maxProjection - c;

                var state = new NeutralAxisState
                {
                    AngleIndex = 0,
                    DepthIndex = 0,
                    CompressionNormal = new Vector2D(nx, ny),
                    ThetaRad = theta,
                    ExtremeCompressionStrain = ecu,
                    NeutralAxisDepth = c,
                    NeutralAxisOffset = na
                };

                var nomResult = _integrator.Integrate(section, concrete, steel, _baseService, state, settings);
                var reduction = _codeAdapter.GetStrengthReductionFactor(nomResult.MaxTensionSteelStrain, steel, nomResult.NominalP);

                results.Add(new StrainControlledPmPointResult
                {
                    CodeName = _codeAdapter.CodeName,
                    PointName = def.PointName,
                    TargetTensileSteelStrain = es,
                    NeutralAxisDepthMm = c,
                    NeutralAxisAngleDegrees = angleDegrees,
                    NominalAxialForceN = nomResult.NominalP,
                    NominalMomentMxNmm = nomResult.NominalMx,
                    NominalMomentMyNmm = nomResult.NominalMy,
                    DesignAxialForceN = nomResult.NominalP * reduction.Phi,
                    DesignMomentMxNmm = nomResult.NominalMx * reduction.Phi,
                    DesignMomentMyNmm = nomResult.NominalMy * reduction.Phi,
                    FailureRegion = reduction.Classification,
                    StrainState = new StrainStateResult
                    {
                        ExtremeCompressionStrain = nomResult.MaxConcreteStrain,
                        ExtremeTensionSteelStrain = nomResult.MaxTensionSteelStrain,
                        RegionClassification = reduction.Classification
                    },
                    RebarResults = ExtractRebarResults(section, state, ecu, c, na, steel)
                });
            }
        }

        return results;
    }

    private StrainControlledPmPointResult CalculatePureCompression(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        StrainPointDefinition def)
    {
        double pn0Nominal = _codeAdapter.GetPureCompressionCapacityLimit(section, concrete, steel);
        var reduction = _codeAdapter.GetStrengthReductionFactor(0.0, steel, pn0Nominal);
        
        // Check if there's any eccentric moment for pure compression
        double mx = 0.0;
        double my = 0.0;
        double fcd = _codeAdapter.GetConcreteDesignStress(concrete); // simplified logic
        double fyd = _codeAdapter.GetSteelDesignStressLimit(steel);
        
        foreach (var bar in section.RebarLayout.Bars)
        {
            double force = bar.AreaMm2 * (fyd - fcd);
            mx -= force * bar.YMm;
            my += force * bar.XMm;
        }

        double ecu = _codeAdapter.GetConcreteUltimateCompressionStrain(concrete);

        return new StrainControlledPmPointResult
        {
            CodeName = _codeAdapter.CodeName,
            PointName = def.PointName,
            TargetTensileSteelStrain = 0.0,
            NeutralAxisDepthMm = null,
            NeutralAxisAngleDegrees = 0.0,
            NominalAxialForceN = pn0Nominal,
            NominalMomentMxNmm = mx,
            NominalMomentMyNmm = my,
            DesignAxialForceN = pn0Nominal * reduction.Phi, // includes tied cap inside Phi or Nominal Compression Limit?
            DesignMomentMxNmm = mx * reduction.Phi,
            DesignMomentMyNmm = my * reduction.Phi,
            FailureRegion = reduction.Classification,
            StrainState = new StrainStateResult
            {
                ExtremeCompressionStrain = ecu,
                ExtremeTensionSteelStrain = 0.0,
                RegionClassification = reduction.Classification
            },
            RebarResults = section.RebarLayout.Bars.Select(b => new RebarStrainStressResult
            {
                AreaMm2 = b.AreaMm2,
                ForceN = b.AreaMm2 * steel.FyMpa,
                Strain = ecu,
                StressMpa = steel.FyMpa,
                XMm = b.XMm,
                YMm = b.YMm
            }).ToList()
        };
    }

    private StrainControlledPmPointResult CalculatePureTension(
        ColumnSection section,
        SteelMaterial steel,
        StrainPointDefinition def,
        double nx, double ny)
    {
        double fyd = _codeAdapter.GetSteelDesignStressLimit(steel);
        double fyk = steel.FyMpa;
        double pntNominal = 0.0;
        double mxNominal = 0.0;
        double myNominal = 0.0;

        var rebarResults = new List<RebarStrainStressResult>(section.RebarLayout.Bars.Count);
        double epsTension = _codeAdapter.GetSteelTensionStrainLimit(steel);

        foreach (var bar in section.RebarLayout.Bars)
        {
            double nomForce = -bar.AreaMm2 * fyk; // tension is negative
            pntNominal += nomForce;
            mxNominal -= nomForce * bar.YMm;
            myNominal += nomForce * bar.XMm;

            rebarResults.Add(new RebarStrainStressResult
            {
                AreaMm2 = bar.AreaMm2,
                ForceN = nomForce,
                Strain = -epsTension, // arbitrary max strain
                StressMpa = -fyk,
                XMm = bar.XMm,
                YMm = bar.YMm
            });
        }

        var reduction = _codeAdapter.GetStrengthReductionFactor(epsTension, steel, pntNominal);

        return new StrainControlledPmPointResult
        {
            CodeName = _codeAdapter.CodeName,
            PointName = def.PointName,
            TargetTensileSteelStrain = epsTension,
            NeutralAxisDepthMm = null,
            NeutralAxisAngleDegrees = 0.0,
            NominalAxialForceN = pntNominal,
            NominalMomentMxNmm = mxNominal,
            NominalMomentMyNmm = myNominal,
            DesignAxialForceN = pntNominal * reduction.Phi,
            DesignMomentMxNmm = mxNominal * reduction.Phi,
            DesignMomentMyNmm = myNominal * reduction.Phi,
            FailureRegion = "Pure tension",
            StrainState = new StrainStateResult
            {
                ExtremeCompressionStrain = 0.0,
                ExtremeTensionSteelStrain = epsTension,
                RegionClassification = "Pure tension"
            },
            RebarResults = rebarResults
        };
    }

    private IReadOnlyList<RebarStrainStressResult> ExtractRebarResults(
        ColumnSection section,
        NeutralAxisState state,
        double ecu,
        double c,
        double na,
        SteelMaterial steel)
    {
        var results = new List<RebarStrainStressResult>(section.RebarLayout.Bars.Count);
        double nx = state.CompressionNormal.X;
        double ny = state.CompressionNormal.Y;
        
        foreach (var bar in section.RebarLayout.Bars)
        {
            double projection = bar.XMm * nx + bar.YMm * ny;
            double strain = ecu * (projection - na) / c;
            double stress = SMath.Clamp(strain * steel.EsMpa, -steel.FyMpa, steel.FyMpa);
            results.Add(new RebarStrainStressResult
            {
                AreaMm2 = bar.AreaMm2,
                Strain = strain,
                StressMpa = stress,
                ForceN = stress * bar.AreaMm2,
                XMm = bar.XMm,
                YMm = bar.YMm
            });
        }
        return results;
    }

    private StrainControlledPmPointResult CalculatePureBending(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        StrainPointDefinition def,
        double nx, double ny, double theta,
        double maxProjection, double dt,
        double ecu, double angleDegrees,
        SolverSettings settings)
    {
        // Bisection search for c where Pn = 0
        double cLow = 1e-3;
        double cHigh = 10.0 * SMath.Max(10.0, maxProjection);
        double c = (cLow + cHigh) / 2.0;

        SectionIntegrationResult nomResult = null!;
        for (int i = 0; i < 100; i++)
        {
            double na = maxProjection - c;
            var state = new NeutralAxisState
            {
                AngleIndex = 0,
                DepthIndex = 0,
                CompressionNormal = new Vector2D(nx, ny),
                ThetaRad = theta,
                ExtremeCompressionStrain = ecu,
                NeutralAxisDepth = c,
                NeutralAxisOffset = na
            };

            nomResult = _integrator.Integrate(section, concrete, steel, _baseService, state, settings);
            double Pn = nomResult.NominalP;

            if (SMath.Abs(Pn) < 1e-1)
                break;

            if (Pn > 0)
                cHigh = c;
            else
                cLow = c;

            c = (cLow + cHigh) / 2.0;
        }

        double convergedNa = maxProjection - c;
        var convergedState = new NeutralAxisState
        {
            AngleIndex = 0,
            DepthIndex = 0,
            CompressionNormal = new Vector2D(nx, ny),
            ThetaRad = theta,
            ExtremeCompressionStrain = ecu,
            NeutralAxisDepth = c,
            NeutralAxisOffset = convergedNa
        };

        var reduction = _codeAdapter.GetStrengthReductionFactor(nomResult.MaxTensionSteelStrain, steel, nomResult.NominalP);

        return new StrainControlledPmPointResult
        {
            CodeName = _codeAdapter.CodeName,
            PointName = def.PointName,
            TargetTensileSteelStrain = nomResult.MaxTensionSteelStrain,
            NeutralAxisDepthMm = c,
            NeutralAxisAngleDegrees = angleDegrees,
            NominalAxialForceN = nomResult.NominalP,
            NominalMomentMxNmm = nomResult.NominalMx,
            NominalMomentMyNmm = nomResult.NominalMy,
            DesignAxialForceN = nomResult.NominalP * reduction.Phi,
            DesignMomentMxNmm = nomResult.NominalMx * reduction.Phi,
            DesignMomentMyNmm = nomResult.NominalMy * reduction.Phi,
            FailureRegion = reduction.Classification,
            StrainState = new StrainStateResult
            {
                ExtremeCompressionStrain = nomResult.MaxConcreteStrain,
                ExtremeTensionSteelStrain = nomResult.MaxTensionSteelStrain,
                RegionClassification = reduction.Classification
            },
            RebarResults = ExtractRebarResults(section, convergedState, ecu, c, convergedNa, steel)
        };
    }
}
