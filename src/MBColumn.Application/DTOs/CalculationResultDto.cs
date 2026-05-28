using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record CalculationResultDto(
    UnitSystem UnitSystem,
    DesignCodeType DesignCode,
    double Ratio,
    CapacityStatus Status,
    double PuDisplay,
    double MuxDisplay,
    double MuyDisplay,
    double Phi,
    double GoverningThetaDegrees,
    double GoverningNeutralAxisDepth,
    double NominalPnDisplay,
    double DesignPnDisplay,
    double NominalMxDisplay,
    double NominalMyDisplay,
    double DesignMxDisplay,
    double DesignMyDisplay,
    MxMyDiagramDto MxMyDiagram,
    MmDiagramDto MmDiagram,
    PmmSurfaceDto PmmSurface,
    PmmSurfaceDto MmSlice,
    InteractionSurface Surface,
    DiagramControlPointSet ControlPoints)
{
    public IReadOnlyList<LoadCaseResultDto> LoadCaseResults { get; init; } = [];
    public string GoverningLoadCaseId { get; init; } = "";
    public ControlPointTableDto? ControlPointTable { get; init; }
    public SectionShapeType SectionShape { get; init; } = SectionShapeType.Rectangular;
    public SectionIntegrationMethod IntegrationMethod { get; init; } = SectionIntegrationMethod.Fiber;
    public int ConcreteFiberCountX { get; init; } = 40;
    public int ConcreteFiberCountY { get; init; } = 40;
    public int CircularRadialFiberCount { get; init; } = 32;
    public int CircularAngularFiberCount { get; init; } = 72;
    public int CirclePolygonSegmentCount { get; init; } = 128;
    public double SectionWidthMm { get; init; }
    public double SectionHeightMm { get; init; }
    public double CoverMm { get; init; }
    public IReadOnlyList<RebarCoordinateDto> RebarCoordinates { get; init; } = [];
    public IReadOnlyList<CapacityDebugPointDto> CapacityDebugPoints { get; init; } = [];
    public IReadOnlyList<InsetPointDto> IrregularSectionBoundaryPoints { get; init; } = [];
    public HandCalcValidationReport? HandCalcValidation { get; init; }
    public string SevenPointValidationReport { get; init; } = "";
    public IReadOnlyList<SevenPointValidationRowDto> SevenPointValidationRows { get; init; } = [];

    // Raw material values in SI units (MPa) for report generation
    public double FcMpa { get; init; }
    public double FyMpa { get; init; }
    public double EsMpa { get; init; }
    public double AlphaCc { get; init; } = 0.85;
    public double GammaC { get; init; } = 1.50;
    public double DiameterMm { get; init; }
    public bool IncludeEc2Slenderness { get; init; }
    public string DemandSourceSummary => IncludeEc2Slenderness
        ? "EC2 Slenderness: Enabled"
        : "EC2 Slenderness: Disabled";
    public string DemandSourceDetail => IncludeEc2Slenderness
        ? "Method: Nominal Curvature"
        : "PMM uses direct section moments Mx and My.";
    public Ec2SlendernessBatchResultDto Ec2Slenderness { get; init; } = Ec2SlendernessBatchResultDto.Empty;

    /// <summary>
    /// Governing (worst-utilisation) shear result across all active load cases.
    /// Null when no shear forces were supplied or the design code does not support shear yet.
    /// </summary>
    public ShearResultDto? GoverningShearResult { get; init; }

    /// <summary>
    /// Reinforcement code-compliance checks (EC2 §9.5 / ACI §10.6, §25.7.2).
    /// Always populated when a calculation completes successfully.
    /// </summary>
    public RebarComplianceResult? RebarCompliance { get; init; }
}

