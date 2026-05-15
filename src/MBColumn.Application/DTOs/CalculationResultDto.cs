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
}

