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
    public SectionShapeType SectionShape { get; init; } = SectionShapeType.Rectangular;
    public double Diameter { get; init; }
    public RebarSideInputDto? TopRebarSide { get; init; }
    public RebarSideInputDto? BottomRebarSide { get; init; }
    public RebarSideInputDto? LeftRebarSide { get; init; }
    public RebarSideInputDto? RightRebarSide { get; init; }
    public IReadOnlyList<RebarCoordinateDto>? RebarCoordinates { get; init; }
    public DesignCodeType DesignCode { get; init; } = DesignCodeType.Aci318Style;
    public Ec2SolverType Ec2Solver { get; init; } = Ec2SolverType.Boundary;
    public SectionIntegrationMethod IntegrationMethod { get; init; } = SectionIntegrationMethod.Fiber;
    public double AlphaCc { get; init; } = 0.85;
    public IrregularSectionInputDto? Irregular { get; init; }
    public RebarSetLibraryType? RebarSetLibrary { get; init; }

    // ── Shear reinforcement (links / stirrups) ────────────────────────────────
    /// <summary>Link bar diameter in mm. Used for EC2 shear capacity check.</summary>
    public double LinkDiameterMm { get; init; } = 0.0;

    /// <summary>Link spacing in mm along the column height.</summary>
    public double LinkSpacingMm { get; init; } = 0.0;

    /// <summary>Total number of legs resisting shear in the X direction (2 + inner legs X).</summary>
    public int TotalLegsX { get; init; } = 2;

    /// <summary>Total number of legs resisting shear in the Y direction (2 + inner legs Y).</summary>
    public int TotalLegsY { get; init; } = 2;

    /// <summary>
    /// Characteristic yield strength of the links in MPa. Defaults to Fy (same grade).
    /// TODO: expose a separate link steel grade selector in the UI.
    /// </summary>
    public double FywkMpa { get; init; } = 0.0;
}

