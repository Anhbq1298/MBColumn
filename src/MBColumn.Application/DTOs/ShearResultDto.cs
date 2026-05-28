using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

/// <summary>
/// Display-ready shear check result for one load case, values converted to the user's unit system.
/// Force values are in the user's ForceUnit; lengths and stresses remain in mm / MPa.
/// </summary>
public sealed record ShearResultDto(
    // ── X direction — capacity ────────────────────────────────────────────────
    double VEdXDisplay,
    double VRdcXDisplay,
    double VRdsXDisplay,
    double VRdMaxXDisplay,
    double VRdXDisplay,
    double UtilisationX,
    CapacityStatus StatusX,
    bool LinksRequiredX,

    // ── Y direction — capacity ────────────────────────────────────────────────
    double VEdYDisplay,
    double VRdcYDisplay,
    double VRdsYDisplay,
    double VRdMaxYDisplay,
    double VRdYDisplay,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,

    // ── Intermediate values — X direction (mm / MPa) ──────────────────────────
    double BwXMm,
    double DEffXMm,
    double KFactorX,
    double RhoLX,
    double SigCpMpa,    // shared for both directions

    // ── Intermediate values — Y direction ─────────────────────────────────────
    double BwYMm,
    double DEffYMm,
    double KFactorY,
    double RhoLY,

    // ── Link intermediate values ───────────────────────────────────────────────
    double AswSX,       // Asw/s X  [mm²/mm]
    double AswSY,       // Asw/s Y  [mm²/mm]
    double FywdMpa,     // fywd [MPa]
    double ZXMm,        // lever arm z X [mm]
    double ZYMm,        // lever arm z Y [mm]
    double CotThetaX,
    double CotThetaY,
    string ForceUnit)
{
    public CapacityStatus GoverningStatus =>
        StatusX == CapacityStatus.Fail || StatusY == CapacityStatus.Fail
            ? CapacityStatus.Fail
            : CapacityStatus.Pass;

    public double GoverningUtilisation => Math.Max(UtilisationX, UtilisationY);

    public bool HasDemand => VEdXDisplay != 0.0 || VEdYDisplay != 0.0;
    public bool HasLinks  => AswSX > 0 || AswSY > 0;
}
