using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

/// <summary>
/// Display-ready shear check result for one load case, values converted to the user's unit system.
/// </summary>
public sealed record ShearResultDto(
    // ── X direction ──────────────────────────────────────────────────────────
    double VEdXDisplay,
    double VRdcXDisplay,
    double VRdsXDisplay,
    double VRdMaxXDisplay,
    double VRdXDisplay,
    double UtilisationX,
    CapacityStatus StatusX,
    bool LinksRequiredX,

    // ── Y direction ──────────────────────────────────────────────────────────
    double VEdYDisplay,
    double VRdcYDisplay,
    double VRdsYDisplay,
    double VRdMaxYDisplay,
    double VRdYDisplay,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,

    // ── Meta ─────────────────────────────────────────────────────────────────
    double DEffXMm,
    double DEffYMm,
    double CotThetaX,
    double CotThetaY,
    string ForceUnit)
{
    public CapacityStatus GoverningStatus =>
        StatusX == CapacityStatus.Fail || StatusY == CapacityStatus.Fail
            ? CapacityStatus.Fail
            : CapacityStatus.Pass;

    public double GoverningUtilisation => Math.Max(UtilisationX, UtilisationY);
}
