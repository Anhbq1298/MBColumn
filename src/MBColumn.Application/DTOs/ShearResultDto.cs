using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

/// <summary>
/// Display-ready shear check result for one load case, values converted to the user's unit system.
/// Force values in the user's ForceUnit; lengths and stresses remain in mm / MPa.
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
    bool IsStruttingCriticalX,
    double AswSMinRequiredX,    // mm²/mm (§9.2.2(5) ρw,min × bw)
    bool AswSMinPassX,

    // ── Y direction — capacity ────────────────────────────────────────────────
    double VEdYDisplay,
    double VRdcYDisplay,
    double VRdsYDisplay,
    double VRdMaxYDisplay,
    double VRdYDisplay,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,
    bool IsStruttingCriticalY,
    double AswSMinRequiredY,
    bool AswSMinPassY,

    // ── Intermediate values — X direction (mm / MPa) ──────────────────────────
    double BwXMm,
    double DEffXMm,
    double KFactorX,
    double RhoLX,
    double SigCpMpa,

    // ── Intermediate values — Y direction ─────────────────────────────────────
    double BwYMm,
    double DEffYMm,
    double KFactorY,
    double RhoLY,

    // ── Link intermediate values ───────────────────────────────────────────────
    double AswSX,
    double AswSY,
    double FywdMpa,
    double ZXMm,
    double ZYMm,
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

    /// <summary>True when any strut-crushing failure is detected — increasing links will not help.</summary>
    public bool AnyStruttingCritical => IsStruttingCriticalX || IsStruttingCriticalY;

    /// <summary>True when minimum shear reinforcement §9.2.2(5) is not met in either direction.</summary>
    public bool AnyMinAswSFail => !AswSMinPassX || !AswSMinPassY;
}
