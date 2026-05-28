using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>ACI 318-19 shear capacity check — PLACEHOLDER.</summary>
public sealed class Aci318ShearDesignService : IShearDesignService
{
    public ShearCheckResult Check(
        double bMm, double hMm, double totalAslMm2, double fckMpa,
        double nedN, double vEdXN, double vEdYN,
        ShearLinkReinforcement? links,
        double coverMm, double mainBarDiaMm)
    {
        // TODO: ACI 318-19 §22.5 — Vc without transverse reinforcement.
        //       Table 22.5.5.1 simplified: Vc = 2λ√f'c · bw · d  (psi).
        //       Detailed: Vc = [8λ(ρw)^(1/3)(Nu/Ag)^(1/4)√f'c + Nu/6Ag] · bw · d
        //
        // TODO: ACI 318-19 §22.6 — Vs = Av · fy · d / s; Vn = Vc + Vs ≤ Vn,max
        //
        // TODO: ACI §21.2.1 — φ = 0.75 for shear.
        //
        // TODO: ACI §9.6.3.3 — minimum Av: Av,min = 0.75√f'c/fyt · bw · s  (or 50 bw s / fyt)
        //
        // TODO: Unit conversion — ACI formulae use psi/in; convert MPa/mm inputs.
        //
        // TODO: Biaxial shear — check X and Y directions independently, same as EC2.

        throw new NotImplementedException(
            "ACI 318 shear check is not yet implemented. Switch to EC2 design code for shear.");
    }
}
