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
}

