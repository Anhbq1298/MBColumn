using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

public readonly record struct Vector2D(double X, double Y);

public sealed record SolverSettings
{
    public double AngleStepDegrees { get; init; } = 10.0;
    public int NeutralAxisSamples { get; init; } = 100;
    public int RectangularFiberCountX { get; init; } = 40;
    public int RectangularFiberCountY { get; init; } = 40;
    public int CircularRadialFiberCount { get; init; } = 32;
    public int CircularAngularFiberCount { get; init; } = 72;
    public int CirclePolygonSegmentCount { get; init; } = 128;
    public SectionIntegrationMethod IntegrationMethod { get; init; } = SectionIntegrationMethod.Fiber;
}

public sealed record PmmInput(
    ColumnSection Section,
    ConcreteMaterial Concrete,
    SteelMaterial Steel,
    IDesignCodeService DesignCode,
    DesignCodeType DesignCodeType,
    SolverSettings Settings);

public sealed record NeutralAxisState
{
    public int DepthIndex { get; init; }
    public int AngleIndex { get; init; }
    public double ThetaRad { get; init; }
    public double NeutralAxisDepth { get; init; }
    public double ExtremeCompressionStrain { get; init; }
    public double NeutralAxisOffset { get; init; }
    public Vector2D CompressionNormal { get; init; }
    public bool IsSpecialState { get; init; }
    public string? SpecialStateType { get; init; }
}

public sealed record SectionIntegrationResult
{
    public double NominalP { get; init; }
    public double NominalMx { get; init; }
    public double NominalMy { get; init; }
    public double ConcreteForce { get; init; }
    public double SteelForce { get; init; }
    public double ConcreteMx { get; init; }
    public double ConcreteMy { get; init; }
    public double SteelMx { get; init; }
    public double SteelMy { get; init; }
    public double MaxTensionSteelStrain { get; init; }
    public double MaxConcreteStrain { get; init; }
    public double MinConcreteStrain { get; init; }
    public double MaxSteelStrain { get; init; }
    public double MinSteelStrain { get; init; }
    public bool HasConcreteCompression { get; init; }
    public bool IsValid { get; init; } = true;
    public string? Warning { get; init; }
}

public sealed record DesignCapacityPoint(InteractionPoint Point);

public sealed record PmmResult(IReadOnlyList<InteractionPoint> Points);

public interface ISweepStrategy
{
    IReadOnlyList<NeutralAxisState> GenerateStates(PmmInput input);
}

public interface ISectionIntegrator
{
    SectionIntegrationResult Integrate(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IDesignCodeService designCode,
        NeutralAxisState neutralAxis,
        SolverSettings settings);
}

public interface IDesignCodeAdapter
{
    DesignCapacityPoint ApplyDesignRules(
        PmmInput input,
        NeutralAxisState neutralAxis,
        SectionIntegrationResult nominalResult);
}
