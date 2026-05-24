using MBColumn.Domain.Entities;
using System.Collections.Generic;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public enum StrainPointType
{
    PureCompression,
    ExtremeTensionStrainZero,
    HalfYieldStrain,
    BalancedYieldStrain,
    TensionControlled,
    StrainCapLimit,
    PureTension
}

public sealed class StrainPointDefinition
{
    public string PointName { get; init; } = "";
    public StrainPointType PointType { get; init; }
    public double? TargetTensileSteelStrain { get; init; }
    public string Description { get; init; } = "";
}

public sealed class RebarStrainStressResult
{
    public double Strain { get; init; }
    public double StressMpa { get; init; }
    public double ForceN { get; init; }
    public double AreaMm2 { get; init; }
    public double XMm { get; init; }
    public double YMm { get; init; }
}

public sealed class StrainStateResult
{
    public double ExtremeCompressionStrain { get; init; }
    public double ExtremeTensionSteelStrain { get; init; }
    public string RegionClassification { get; init; } = "";
}

public sealed class StrainControlledPmPointResult
{
    public string CodeName { get; init; } = "";
    public string PointName { get; init; } = "";
    public double? TargetTensileSteelStrain { get; init; }
    public double? NeutralAxisDepthMm { get; init; }
    public double NeutralAxisAngleDegrees { get; init; }
    public double NominalAxialForceN { get; init; }
    public double NominalMomentMxNmm { get; init; }
    public double NominalMomentMyNmm { get; init; }
    public double DesignAxialForceN { get; init; }
    public double DesignMomentMxNmm { get; init; }
    public double DesignMomentMyNmm { get; init; }
    public StrainStateResult StrainState { get; init; } = new();
    public string FailureRegion { get; init; } = "";
    public IReadOnlyList<RebarStrainStressResult> RebarResults { get; init; } = [];
}
