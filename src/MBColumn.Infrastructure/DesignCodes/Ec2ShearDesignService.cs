using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using static System.Math;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// EC2 EN 1992-1-1:2004 shear capacity check for rectangular column sections.
///
/// Step 1 — Without shear reinforcement (§6.2.2):
///   VRd,c = [CRd,c · k · (100 ρl · fck)^(1/3) + k₁ · σcp] · bw · d
///   Minimum: VRd,c ≥ (vmin + k₁ · σcp) · bw · d
///   where CRd,c = 0.18/γc = 0.12;  k = 1 + √(200/d) ≤ 2.0;  k₁ = 0.15
///         vmin = 0.035 · k^1.5 · fck^0.5;  σcp = NEd/Ac ≤ 0.2 fcd
///
/// Step 2 — With shear reinforcement (§6.2.3) — variable-angle truss:
///   VRd,s   = (Asw/s) · z · fywd · cot θ           [link capacity]
///   VRd,max = αcw · bw · z · ν₁ · fcd / (cot θ + tan θ)  [strut crushing]
///   z = 0.9 d;  ν₁ = 0.6·(1 − fck/250);  αcw = 1.0 (non-prestressed)
///   Optimal cot θ ∈ [1.0, 2.5] maximises min(VRd,s, VRd,max).
///
/// Sign convention (rectangular section b × h):
///   VEdX  → bw = h,  d_eff = b − 60 mm cover,  Asw/s from TotalLegsX
///   VEdY  → bw = b,  d_eff = h − 60 mm cover,  Asw/s from TotalLegsY
/// </summary>
public sealed class Ec2ShearDesignService : IShearDesignService
{
    private const double GammaC     = 1.50;
    private const double GammaS     = 1.15;
    private const double AlphaCc    = 0.85;          // Singapore/UK NA
    private const double K1         = 0.15;           // EC2 eq. (6.2.a)
    private const double CRdC       = 0.18 / GammaC; // = 0.12
    private const double AlphaCw    = 1.00;           // non-prestressed
    private const double CoverEffMm = 60.0;           // TODO: derive from bar data

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
        double acMm2 = bMm * hMm;
        double fcd   = AlphaCc * fckMpa / GammaC;

        // σcp (compressive +ve, capped at 0.2 fcd per §6.2.2(1))
        double sigCp = acMm2 > 0 ? Min(nedN / acMm2, 0.2 * fcd) : 0.0;

        // Geometry per direction
        double bwX   = hMm;
        double dEffX = Max(bMm - CoverEffMm, 1.0);
        double bwY   = bMm;
        double dEffY = Max(hMm - CoverEffMm, 1.0);

        var rx = CheckDirection(bwX, dEffX, totalAslMm2, fckMpa, fcd, sigCp, acMm2,
            links?.TotalLegsX ?? 0, links?.SpacingMm ?? 0, links?.LinkDiameterMm ?? 0, links?.FywkMpa ?? 0, vEdXN);
        var ry = CheckDirection(bwY, dEffY, totalAslMm2, fckMpa, fcd, sigCp, acMm2,
            links?.TotalLegsY ?? 0, links?.SpacingMm ?? 0, links?.LinkDiameterMm ?? 0, links?.FywkMpa ?? 0, vEdYN);

        double utilX = rx.VRd > 0 ? Abs(vEdXN) / rx.VRd : (Abs(vEdXN) > 0 ? double.PositiveInfinity : 0.0);
        double utilY = ry.VRd > 0 ? Abs(vEdYN) / ry.VRd : (Abs(vEdYN) > 0 ? double.PositiveInfinity : 0.0);

        return new ShearCheckResult(
            VEdXN:          vEdXN,
            VRdcXN:         rx.VRdc,
            VRdsXN:         rx.VRds,
            VRdMaxXN:       rx.VRdMax,
            VRdXN:          rx.VRd,
            UtilisationX:   utilX,
            StatusX:        utilX <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredX: rx.LinksRequired,

            VEdYN:          vEdYN,
            VRdcYN:         ry.VRdc,
            VRdsYN:         ry.VRds,
            VRdMaxYN:       ry.VRdMax,
            VRdYN:          ry.VRd,
            UtilisationY:   utilY,
            StatusY:        utilY <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredY: ry.LinksRequired,

            BwXMm:    bwX,
            DEffXMm:  dEffX,
            KFactorX: rx.K,
            RhoLX:    rx.RhoL,
            SigCpMpa: sigCp,

            BwYMm:    bwY,
            DEffYMm:  dEffY,
            KFactorY: ry.K,
            RhoLY:    ry.RhoL,

            AswSX:    rx.AswS,
            AswSY:    ry.AswS,
            FywdMpa:  rx.Fywd > 0 ? rx.Fywd : ry.Fywd,
            ZXMm:     rx.Z,
            ZYMm:     ry.Z,
            CotThetaX: rx.CotTheta,
            CotThetaY: ry.CotTheta);
    }

    private readonly record struct DirectionResult(
        double VRdc, double VRds, double VRdMax, double VRd,
        bool LinksRequired,
        double K, double RhoL,
        double AswS, double Fywd, double Z, double CotTheta);

    private static DirectionResult CheckDirection(
        double bwMm, double dMm,
        double totalAslMm2, double fckMpa, double fcdMpa, double sigCpMpa, double acMm2,
        int totalLegs, double spacingMm, double linkDiaMm, double fywkMpa,
        double vEdN)
    {
        // ── Step 1: §6.2.2 — VRd,c without shear reinforcement ───────────────
        double k    = Min(1.0 + Sqrt(200.0 / dMm), 2.0);
        double rhoL = Min(totalAslMm2 / (bwMm * dMm), 0.02);

        double vRdc = (CRdC * k * Pow(100.0 * rhoL * fckMpa, 1.0 / 3.0) + K1 * sigCpMpa) * bwMm * dMm;
        double vMin = 0.035 * Pow(k, 1.5) * Sqrt(fckMpa);
        vRdc = Max(vRdc, (vMin + K1 * sigCpMpa) * bwMm * dMm);

        bool linksRequired = Abs(vEdN) > vRdc;

        // ── Step 2: §6.2.3 — VRd,s and VRd,max with shear reinforcement ──────
        if (totalLegs <= 0 || spacingMm <= 0 || linkDiaMm <= 0 || fywkMpa <= 0)
            return new(vRdc, 0, 0, vRdc, linksRequired, k, rhoL, 0, 0, 0, 0);

        double fywd   = fywkMpa / GammaS;
        double nu1    = 0.6 * (1.0 - fckMpa / 250.0);
        double z      = 0.9 * dMm;
        double aSwMm2 = totalLegs * PI * linkDiaMm * linkDiaMm / 4.0;
        double aswS   = aSwMm2 / spacingMm;

        // Optimal cot θ: intersection of VRd,s and VRd,max curves
        // aswS · fywd · (cot² + 1) = αcw · bw · ν₁ · fcd  →  cot² = [αcw · bw · ν₁ · fcd / (aswS · fywd)] − 1
        double cotSq = AlphaCw * bwMm * nu1 * fcdMpa / (aswS * fywd) - 1.0;
        double cot = cotSq >= 6.25 ? 2.5       // links light — link governs at max angle
                   : cotSq <= 1.0  ? 1.0       // links heavy — strut governs at θ = 45°
                                   : Sqrt(cotSq);

        double vRds   = aswS * z * fywd * cot;
        double vRdMax = AlphaCw * bwMm * z * nu1 * fcdMpa / (cot + 1.0 / cot);
        double vRd    = Min(vRds, vRdMax);

        return new(vRdc, vRds, vRdMax, vRd, linksRequired, k, rhoL, aswS, fywd, z, cot);
    }
}
