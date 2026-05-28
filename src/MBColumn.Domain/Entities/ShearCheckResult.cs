using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

/// <summary>
/// Result of an EC2 §6.2 (or ACI §22.5/22.6) shear capacity check in both principal directions.
/// VEd positive by convention. All forces in Newtons.
/// </summary>
public sealed record ShearCheckResult(
    // ── X direction (shear force parallel to X axis) ───────────────────────────
    double VEdXN,
    double VRdcXN,      // concrete contribution without links (§6.2.2)
    double VRdsXN,      // link contribution (§6.2.3); 0 when no links provided
    double VRdMaxXN,    // strut crushing limit (§6.2.3); 0 when no links provided
    double VRdXN,       // governing capacity = min(VRds, VRdMax) if links, else VRdc
    double UtilisationX,
    CapacityStatus StatusX,
    bool LinksRequiredX,

    // ── Y direction (shear force parallel to Y axis) ───────────────────────────
    double VEdYN,
    double VRdcYN,
    double VRdsYN,
    double VRdMaxYN,
    double VRdYN,
    double UtilisationY,
    CapacityStatus StatusY,
    bool LinksRequiredY,

    // ── Intermediate values (for reporting) ───────────────────────────────────
    double DEffXMm,     // effective depth for X-direction shear
    double DEffYMm,     // effective depth for Y-direction shear
    double CotThetaX,   // governing strut angle (cot θ) for X direction
    double CotThetaY);  // governing strut angle (cot θ) for Y direction
