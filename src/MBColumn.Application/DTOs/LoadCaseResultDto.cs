using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record LoadCaseResultDto(
    string LoadCaseId,
    string LoadCaseName,
    double PuDisplay,
    double MuxDisplay,
    double MuyDisplay,
    double PmmRatio,
    CapacityStatus Status,
    double Phi,
    double GoverningThetaDegrees,
    double GoverningNeutralAxisDepth)
{
    public double CapacityPDisplay { get; init; }
    public double CapacityMxDisplay { get; init; }
    public double CapacityMyDisplay { get; init; }
}

