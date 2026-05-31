using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record LoadCaseDto(
    string Id,
    string Name,
    double Pu,
    double Mux,
    double Muy,
    bool IsActive,
    ForceUnit ForceUnit,
    MomentUnit MomentUnit)
{
    /// <summary>Shear force in X direction in the user's current ForceUnit. Defaults to 0.</summary>
    public double Vux { get; init; } = 0.0;

    /// <summary>Shear force in Y direction in the user's current ForceUnit. Defaults to 0.</summary>
    public double Vuy { get; init; } = 0.0;

    /// <summary>Member-end Mx at the top restraint in the user's current MomentUnit.</summary>
    public double? MxTop { get; init; }

    /// <summary>Member-end Mx at the bottom restraint in the user's current MomentUnit.</summary>
    public double? MxBottom { get; init; }

    /// <summary>Member-end My at the top restraint in the user's current MomentUnit.</summary>
    public double? MyTop { get; init; }

    /// <summary>Member-end My at the bottom restraint in the user's current MomentUnit.</summary>
    public double? MyBottom { get; init; }

    /// <summary>Final Mx demand after EC2 slenderness amplification in the user's current MomentUnit.</summary>
    public double? MxUsed { get; init; }

    /// <summary>Final My demand after EC2 slenderness amplification in the user's current MomentUnit.</summary>
    public double? MyUsed { get; init; }

}
