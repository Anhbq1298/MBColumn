using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

/// <summary>
/// Result of an EC2 §6.2 (or ACI §22.5/22.6) shear capacity check in both principal directions.
/// VEd positive by convention. All forces in Newtons, lengths in mm, stresses in MPa.
/// </summary>
public sealed record ShearCheckResult(
    // ── X direction — capacity components ─────────────────────────────────────
    double VEdXN,
    double VRdcXN,      // concrete contribution without links (§6.2.2)
    double VRdsXN,      // link contribution (§6.2.3); 0 when no links provided
    double VRdMaxXN,    // strut crushing limit (§6.2.3); 0 when no links provided
    double VRdXN,       // governing capacity = min(VRds, VRdMax) if links, else VRdc
    double UtilisationX,
    CapacityStatus StatusX,
    bool LinksRequiredX,

    // ── Y direction — capacity components ─────────────────────────────────────
    double VEdYN,
    double VRdcYN,
    double VRdsYN,
    double VRdMaxYN,
    double VRdYN,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,

    // ── Intermediate values — X direction ─────────────────────────────────────
    double BwXMm,       // web width for X-direction shear
    double DEffXMm,     // effective depth for X-direction shear
    double KFactorX,    // size-effect factor k = 1 + √(200/d) ≤ 2
    double RhoLX,       // long. reinforcement ratio ρl ≤ 0.02
    double SigCpMpa,    // axial compressive stress (shared: same for both directions)

    // ── Intermediate values — Y direction ─────────────────────────────────────
    double BwYMm,
    double DEffYMm,
    double KFactorY,
    double RhoLY,

    // ── Link intermediate values (0 when no links) ─────────────────────────────
    double AswSX,       // Asw/s for X direction (mm²/mm)
    double AswSY,       // Asw/s for Y direction (mm²/mm)
    double FywdMpa,     // design link yield strength
    double ZXMm,        // lever arm z for X direction
    double ZYMm,        // lever arm z for Y direction
    double CotThetaX,   // governing strut angle cot θ for X direction
    double CotThetaY);  // governing strut angle cot θ for Y direction
