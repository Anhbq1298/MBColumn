using MBColumn.Domain.Entities;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public sealed class StressBlockParameters
{
    public double DepthFactorBeta { get; init; }
    public double StrengthEffectivenessFactor { get; init; }
}

public sealed class StrengthReductionResult
{
    public double Phi { get; init; }
    public string Classification { get; init; } = "";
}

public interface IStrainLimitDesignCodeAdapter
{
    string CodeName { get; }

    double GetConcreteUltimateCompressionStrain(ConcreteMaterial concrete);
    double GetSteelYieldStrain(SteelMaterial steel);
    double GetSteelTensionStrainLimit(SteelMaterial steel);

    StressBlockParameters GetStressBlockParameters(ConcreteMaterial concrete);
    double GetConcreteDesignStress(ConcreteMaterial concrete);
    double GetSteelDesignStressLimit(SteelMaterial steel);

    double GetPureCompressionCapacityLimit(ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel);
    StrengthReductionResult GetStrengthReductionFactor(double maxTensionSteelStrain, SteelMaterial steel, double nominalAxialForceN);
}
