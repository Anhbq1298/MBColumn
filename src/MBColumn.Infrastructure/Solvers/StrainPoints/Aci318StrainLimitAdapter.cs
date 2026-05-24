using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.DesignCodes;
using System.Linq;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public sealed class Aci318StrainLimitAdapter : IStrainLimitDesignCodeAdapter
{
    private readonly Aci318DesignCodeService _baseService;

    public Aci318StrainLimitAdapter(Aci318DesignCodeService baseService)
    {
        _baseService = baseService;
    }

    public string CodeName => "ACI 318";

    // ACI 318: 0.003
    public double GetConcreteUltimateCompressionStrain(ConcreteMaterial concrete)
        => _baseService.ConcreteUltimateStrain(concrete.FcMpa);

    // Yield strain = fy / Es
    public double GetSteelYieldStrain(SteelMaterial steel)
        => steel.FyMpa / steel.EsMpa;

    // ACI 318 doesn't impose a strict limit, we use a practical upper limit of 0.08
    public double GetSteelTensionStrainLimit(SteelMaterial steel)
        => _baseService.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

    public StressBlockParameters GetStressBlockParameters(ConcreteMaterial concrete)
        => new()
        {
            DepthFactorBeta = _baseService.Beta1(concrete.FcMpa),
            StrengthEffectivenessFactor = _baseService.ConcreteEffectiveStrengthFactor(concrete.FcMpa)
        };

    // ACI 318 Whitney block design stress: 0.85 * f'c
    public double GetConcreteDesignStress(ConcreteMaterial concrete)
        => _baseService.ConcreteStressBlockFactor * concrete.FcMpa;

    // ACI uses nominal steel strength, Phi is applied later
    public double GetSteelDesignStressLimit(SteelMaterial steel)
        => _baseService.SteelDesignStrength(steel.FyMpa);

    public double GetPureCompressionCapacityLimit(ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        double ast = section.RebarLayout.Bars.Sum(b => b.AreaMm2);
        double ag = section.AreaMm2;
        double fc = concrete.FcMpa;
        double fy = steel.FyMpa;
        
        // Nominal P0
        double pn0 = 0.85 * fc * (ag - ast) + fy * ast;
        return _baseService.NominalCompressionLimit(pn0);
    }

    public StrengthReductionResult GetStrengthReductionFactor(double maxTensionSteelStrain, SteelMaterial steel, double nominalAxialForceN)
    {
        double phi = _baseService.Phi(maxTensionSteelStrain, steel.FyMpa, steel.EsMpa);
        double yieldStrain = GetSteelYieldStrain(steel);
        string classification = "Transition";
        if (maxTensionSteelStrain <= yieldStrain)
            classification = "Compression controlled";
        else if (maxTensionSteelStrain >= yieldStrain + 0.003)
            classification = "Tension controlled";
        
        // Pure compression is handled as Compression Controlled
        return new StrengthReductionResult { Phi = phi, Classification = classification };
    }
}
