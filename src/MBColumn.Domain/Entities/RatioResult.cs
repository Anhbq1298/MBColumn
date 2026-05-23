using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public sealed record RatioResult(
    double Ratio,
    CapacityStatus Status,
    InteractionPoint? GoverningPoint,
    double DemandMomentMagnitudeNmm,
    double CapacityMomentMagnitudeNmm,
    string Message)
{
    /// <summary>Full 3-D magnitude of the demand vector √(P² + Mx² + My²) in N / N·mm.</summary>
    public double DemandMagnitude { get; init; }

    /// <summary>Full 3-D magnitude of the capacity intersection point √(Pc² + Mxc² + Myc²) in N / N·mm.</summary>
    public double CapacityMagnitude { get; init; }

    /// <summary>Axial force at the radial capacity intersection point (N, design/reduced).</summary>
    public double CapacityPn { get; init; }

    /// <summary>Mx moment at the radial capacity intersection point (N·mm, design/reduced).</summary>
    public double CapacityMnx { get; init; }

    /// <summary>My moment at the radial capacity intersection point (N·mm, design/reduced).</summary>
    public double CapacityMny { get; init; }

    /// <summary>Theta angle (°) of the demand vector projected onto the Mx–My plane.</summary>
    public double CriticalThetaDegrees { get; init; }
}

