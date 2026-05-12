using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record ColumnInputDto(
    UnitSystem UnitSystem,
    double Width,
    double Height,
    double Cover,
    string BarSize,
    int BarCount,
    string RebarLayoutPreset,
    double Fc,
    double Fy,
    double Es,
    double Pu,
    double Mux,
    double Muy,
    ForceUnit ForceUnit,
    LengthUnit LengthUnit,
    MomentUnit MomentUnit,
    StressUnit StressUnit,
    double SelectedPmAngleDegrees,
    double SelectedAxialLoad)
{
    public IReadOnlyList<LoadCaseDto>? LoadCases { get; init; }
    public RebarLayoutType RebarLayoutType { get; init; } = RebarLayoutType.AllSidesEqual;
    public RebarSideInputDto? TopRebarSide { get; init; }
    public RebarSideInputDto? BottomRebarSide { get; init; }
    public RebarSideInputDto? LeftRebarSide { get; init; }
    public RebarSideInputDto? RightRebarSide { get; init; }
    public IReadOnlyList<RebarCoordinateDto>? RebarCoordinates { get; init; }
    public DesignCodeType DesignCode { get; init; } = DesignCodeType.Aci318Style;
    public Ec2SolverType Ec2Solver { get; init; } = Ec2SolverType.Boundary;
    public AciSolverType AciSolver { get; init; } = AciSolverType.Conventional;
    public double AlphaCc { get; init; } = 0.85;
}

