using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// ACI 318-19 shear capacity check — PLACEHOLDER.
/// Full implementation to be added in a future sprint.
/// </summary>
public sealed class Aci318ShearDesignService : IShearDesignService
{
    public ShearCheckResult Check(
        double bMm,
        double hMm,
        double totalAslMm2,
        double fckMpa,
        double nedN,
        double vEdXN,
        double vEdYN,
        ShearLinkReinforcement? links)
    {
        // TODO: ACI 318-19 §22.5 — Vc for members without transverse reinforcement.
        //       Table 22.5.5.1 simplified: Vc = 2λ√f'c · bw · d  (in psi units).
        //       Detailed (§22.5.5.1): Vc = [8λ(ρw)^(1/3)(Nu/Ag)^(1/4)√f'c + Nu/6Ag] · bw · d.
        //
        // TODO: ACI 318-19 §22.6 — Vs for members with transverse reinforcement.
        //       Vs = Av · fy · d / s  (vertical stirrups).
        //       Vn = Vc + Vs ≤ Vn,max = Vc + 8√f'c · bw · d  (psi).
        //
        // TODO: ACI 318-19 §21.2.1 — φ = 0.75 for shear.
        //
        // TODO: Unit conversion — ACI formulae are in psi/in; convert MPa/mm inputs first.
        //
        // TODO: ACI biaxial shear — check both directions independently, same as EC2.

        throw new NotImplementedException(
            "ACI 318 shear check is not yet implemented. Switch to EC2 design code for shear.");
    }
}
