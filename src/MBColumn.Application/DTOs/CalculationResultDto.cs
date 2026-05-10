using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record CalculationResultDto(
    UnitSystem UnitSystem,
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
    PmXDiagramDto PmXDiagram,
    PmYDiagramDto PmYDiagram,
    MxMyDiagramDto MxMyDiagram,
    PmDiagramDto PmDiagram,
    MmDiagramDto MmDiagram,
    PmmSurfaceDto PmmSurface,
    PmmSurfaceDto MmSlice,
    InteractionSurface Surface,
    DiagramControlPointSet ControlPoints)
{
    public IReadOnlyList<LoadCaseResultDto> LoadCaseResults { get; init; } = [];
    public string GoverningLoadCaseId { get; init; } = "";
    public ControlPointTableDto? ControlPointTable { get; init; }
    public double SectionWidthMm { get; init; }
    public double SectionHeightMm { get; init; }
    public double CoverMm { get; init; }
    public IReadOnlyList<RebarCoordinateDto> RebarCoordinates { get; init; } = [];
}

