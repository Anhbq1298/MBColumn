using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.DesignCodes;
using System.Linq;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public sealed class Ec2StrainLimitAdapter : IStrainLimitDesignCodeAdapter
{
    private readonly Ec2DesignCodeService _baseService;

    public Ec2StrainLimitAdapter(Ec2DesignCodeService baseService)
    {
        _baseService = baseService;
    }

    public string CodeName => "Eurocode 2";

    public double GetConcreteUltimateCompressionStrain(ConcreteMaterial concrete)
        => _baseService.ConcreteUltimateStrain(concrete.FcMpa);

    public double GetSteelYieldStrain(SteelMaterial steel)
        => steel.FyMpa / steel.EsMpa;

    // EC2 limit εud
    public double GetSteelTensionStrainLimit(SteelMaterial steel)
        => _baseService.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

    public StressBlockParameters GetStressBlockParameters(ConcreteMaterial concrete)
        => new()
        {
            DepthFactorBeta = _baseService.Beta1(concrete.FcMpa),
            StrengthEffectivenessFactor = _baseService.ConcreteEffectiveStrengthFactor(concrete.FcMpa)
        };

    // EC2 Design stress: αcc * fck / γc (where GammaC is 1.5, AlphaCc is typically 0.85)
    public double GetConcreteDesignStress(ConcreteMaterial concrete)
        => _baseService.ConcreteStressBlockFactor * concrete.FcMpa;

    // EC2 Design steel stress: fyk / γs
    public double GetSteelDesignStressLimit(SteelMaterial steel)
        => _baseService.SteelDesignStrength(steel.FyMpa);

    public double GetPureCompressionCapacityLimit(ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        double ast = section.RebarLayout.Bars.Sum(b => b.AreaMm2);
        double ag = section.AreaMm2;
        
        double fcd = GetConcreteDesignStress(concrete) * GetStressBlockParameters(concrete).StrengthEffectivenessFactor;
        double fyd = GetSteelDesignStressLimit(steel);
        
        double pn0 = fcd * (ag - ast) + fyd * ast;
        return pn0;
    }

    public StrengthReductionResult GetStrengthReductionFactor(double maxTensionSteelStrain, SteelMaterial steel, double nominalAxialForceN)
    {
        // EC2 uses material partial factors, no member level phi
        double phi = _baseService.Phi(maxTensionSteelStrain, steel.FyMpa, steel.EsMpa);
        
        string classification = maxTensionSteelStrain >= 0.005 ? "Tension controlled" : "Compression controlled";
        return new StrengthReductionResult { Phi = phi, Classification = classification };
    }
}
