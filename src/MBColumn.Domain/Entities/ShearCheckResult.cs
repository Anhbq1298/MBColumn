using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

/// <summary>
/// Result of an EC2 §6.2 (or ACI §22.5/22.6) shear capacity check in both principal directions.
/// VEd positive by convention. All forces in Newtons, lengths in mm, stresses in MPa.
/// </summary>
public sealed record ShearCheckResult(
    // ── X direction — capacity components ─────────────────────────────────────
    double VEdXN,
    double VRdcXN,
    double VRdsXN,
    double VRdMaxXN,
    double VRdXN,
    double UtilisationX,
    CapacityStatus StatusX,
    bool LinksRequiredX,
    /// <summary>True when VEd > VRd,max even at cot θ = 1 — adding more links will NOT help; increase section or fck.</summary>
    bool IsStruttingCriticalX,
    /// <summary>Minimum Asw/s required by §9.2.2(5): ρw,min × bw [mm²/mm]. 0 when not applicable.</summary>
    double AswSMinRequiredX,
    bool AswSMinPassX,

    // ── Y direction — capacity components ─────────────────────────────────────
    double VEdYN,
    double VRdcYN,
    double VRdsYN,
    double VRdMaxYN,
    double VRdYN,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,
    bool IsStruttingCriticalY,
    double AswSMinRequiredY,
    bool AswSMinPassY,

    // ── Intermediate values — X direction ─────────────────────────────────────
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

    // ── Link intermediate values (0 when no links) ─────────────────────────────
    double AswSX,
    double AswSY,
    double FywdMpa,
    double ZXMm,
    double ZYMm,
    double CotThetaX,
    double CotThetaY,

    bool IsCircularHoop = false,
    double LinkAhMm2 = 0.0,
    double LinkSpacingMm = 0.0,
    double CircularHoopCentrelineDiameterMm = 0.0,
    double FckMpa = 0.0,
    double FcdMpa = 0.0,
    double FywkMpa = 0.0);
