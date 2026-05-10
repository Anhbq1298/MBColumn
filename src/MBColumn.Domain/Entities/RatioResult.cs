using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public sealed record RatioResult(
    double Ratio,
    CapacityStatus Status,
    InteractionPoint? GoverningPoint,
    double DemandMomentMagnitudeNmm,
    double CapacityMomentMagnitudeNmm,
    string Message);

