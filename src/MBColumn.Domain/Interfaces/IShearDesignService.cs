using MBColumn.Domain.Entities;

namespace MBColumn.Domain.Interfaces;

/// <summary>
/// Code-specific shear design check for a rectangular (or circular) column cross-section.
/// Implementations: EC2 §6.2, ACI §22.5/22.6.
/// </summary>
public interface IShearDesignService
{
    /// <summary>
    /// Performs shear capacity checks in both principal directions independently.
    /// </summary>
    /// <param name="bMm">Section width (X dimension), mm. For circular: 0.8 D (effective width).</param>
    /// <param name="hMm">Section height (Y dimension), mm. For circular: D.</param>
    /// <param name="totalAslMm2">Total longitudinal reinforcement area, mm².</param>
    /// <param name="fckMpa">Characteristic concrete compressive strength, MPa.</param>
    /// <param name="nedN">Applied axial force, N. Positive = compression.</param>
    /// <param name="vEdXN">Applied shear in X direction, N.</param>
    /// <param name="vEdYN">Applied shear in Y direction, N.</param>
    /// <param name="links">Link (stirrup) reinforcement details; null → check without-links only.</param>
    /// <param name="coverMm">Nominal concrete cover to the link outer face, mm.</param>
    /// <param name="mainBarDiaMm">Largest longitudinal bar diameter, mm. Used to compute d_eff.</param>
    ShearCheckResult Check(
        double bMm,
        double hMm,
        double totalAslMm2,
        double fckMpa,
        double nedN,
        double vEdXN,
        double vEdYN,
        ShearLinkReinforcement? links,
        double coverMm,
        double mainBarDiaMm);
}
