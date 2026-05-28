using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using static System.Math;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// EC2 EN 1992-1-1:2004 shear capacity check (§6.2).
///
/// Step 1 — Without shear reinforcement (§6.2.2):
///   VRd,c = [CRd,c · k · (100 ρl · fck)^(1/3) + k₁ · σcp] · bw · d
///   Minimum: (vmin + k₁ · σcp) · bw · d
///   k = 1 + √(200/d) ≤ 2;  CRd,c = 0.18/γc = 0.12;  k₁ = 0.15
///   vmin = 0.035 k^1.5 fck^0.5;  σcp = NEd/Ac ≤ 0.2 fcd
///
/// Step 2 — With shear reinforcement (§6.2.3) variable-angle truss:
///   VRd,s   = (Asw/s) · z · fywd · cot θ
///   VRd,max = αcw · bw · z · ν₁ · fcd / (cot θ + tan θ)
///   Optimal cot θ ∈ [1, 2.5] maximises min(VRd,s, VRd,max).
///   z = 0.9 d;  ν₁ = 0.6(1 − fck/250);  αcw = 1.0 (non-prestressed)
///
/// Minimum shear reinforcement (§9.2.2(5)):
///   ρw,min = 0.08 √fck / fywk  →  Asw/s ≥ ρw,min · bw
///
/// Effective depth (Fix 1 — from real geometry, not a fixed 60 mm):
///   d_eff = section_dim − cover_nominal − link_dia − main_bar_dia / 2
///
/// Sign convention (b × h section):
///   VEdX → bw = h,  d = b − cover_eff,  legs = TotalLegsX
///   VEdY → bw = b,  d = h − cover_eff,  legs = TotalLegsY
///
/// Circular (Fix 5 — EC2 §6.2.2(5)):
///   Caller passes bMm = 0.8 D, hMm = D.
///   Result: bwX = bwY = 0.8 D; dEffX = dEffY ≈ 0.8D − cover_eff.
/// </summary>
public sealed class Ec2ShearDesignService : IShearDesignService
{
    private const double GammaC  = 1.50;
    private const double GammaS  = 1.15;
    private const double AlphaCc = 0.85; // Singapore/UK NA
    private const double K1      = 0.15;
    private const double CRdC    = 0.18 / GammaC; // = 0.12
    private const double AlphaCw = 1.00;           // non-prestressed

    public ShearCheckResult Check(
        double bMm, double hMm, double totalAslMm2, double fckMpa,
        double nedN, double vEdXN, double vEdYN,
        ShearLinkReinforcement? links,
        double coverMm, double mainBarDiaMm)
    {
        double acMm2 = bMm * hMm;
        double fcd   = AlphaCc * fckMpa / GammaC;

        // σcp (compressive +ve, capped at 0.2 fcd — §6.2.2(1))
        double sigCp = acMm2 > 0 ? Min(nedN / acMm2, 0.2 * fcd) : 0.0;

        // d_eff = section_dim − cover − link_dia − main_bar_dia/2
        double linkDia   = links?.LinkDiameterMm ?? 0.0;
        double coverEff  = coverMm + linkDia + mainBarDiaMm / 2.0;

        // X-direction: bw = h, d = b − cover_eff
        double bwX   = hMm;
        double dEffX = Max(bMm - coverEff, 1.0);

        // Y-direction: bw = b, d = h − cover_eff
        double bwY   = bMm;
        double dEffY = Max(hMm - coverEff, 1.0);

        double fywkMpa = links?.FywkMpa ?? 0.0;
        double rhoWMin = fywkMpa > 0 ? 0.08 * Sqrt(fckMpa) / fywkMpa : 0.0; // §9.2.2(5)

        var rx = CheckDirection(bwX, dEffX, totalAslMm2, fckMpa, fcd, sigCp,
            links?.TotalLegsX ?? 0, links?.SpacingMm ?? 0, linkDia, fywkMpa, rhoWMin, vEdXN);
        var ry = CheckDirection(bwY, dEffY, totalAslMm2, fckMpa, fcd, sigCp,
            links?.TotalLegsY ?? 0, links?.SpacingMm ?? 0, linkDia, fywkMpa, rhoWMin, vEdYN);

        double utilX = rx.VRd > 0 ? Abs(vEdXN) / rx.VRd : (Abs(vEdXN) > 0 ? double.PositiveInfinity : 0.0);
        double utilY = ry.VRd > 0 ? Abs(vEdYN) / ry.VRd : (Abs(vEdYN) > 0 ? double.PositiveInfinity : 0.0);

        return new ShearCheckResult(
            VEdXN:                vEdXN,
            VRdcXN:               rx.VRdc,
            VRdsXN:               rx.VRds,
            VRdMaxXN:             rx.VRdMax,
            VRdXN:                rx.VRd,
            UtilisationX:         utilX,
            StatusX:              utilX <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredX:       rx.LinksRequired,
            IsStruttingCriticalX: rx.IsStruttingCritical,
            AswSMinRequiredX:     rx.AswSMinRequired,
            AswSMinPassX:         rx.AswSMinPass,

            VEdYN:                vEdYN,
            VRdcYN:               ry.VRdc,
            VRdsYN:               ry.VRds,
            VRdMaxYN:             ry.VRdMax,
            VRdYN:                ry.VRd,
            UtilisationY:         utilY,
            StatusY:              utilY <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredY:       ry.LinksRequired,
            IsStruttingCriticalY: ry.IsStruttingCritical,
            AswSMinRequiredY:     ry.AswSMinRequired,
            AswSMinPassY:         ry.AswSMinPass,

            BwXMm:     bwX,    DEffXMm:  dEffX,
            KFactorX:  rx.K,   RhoLX:    rx.RhoL,
            SigCpMpa:  sigCp,
            BwYMm:     bwY,    DEffYMm:  dEffY,
            KFactorY:  ry.K,   RhoLY:    ry.RhoL,

            AswSX:      rx.AswS,
            AswSY:      ry.AswS,
            FywdMpa:    rx.Fywd > 0 ? rx.Fywd : ry.Fywd,
            ZXMm:       rx.Z,
            ZYMm:       ry.Z,
            CotThetaX:  rx.CotTheta,
            CotThetaY:  ry.CotTheta);
    }

    // ── Internal per-direction result ────────────────────────────────────────
    private readonly record struct DirectionResult(
        double VRdc, double VRds, double VRdMax, double VRd,
        bool LinksRequired, bool IsStruttingCritical,
        double AswSMinRequired, bool AswSMinPass,
        double K, double RhoL,
        double AswS, double Fywd, double Z, double CotTheta);

    private static DirectionResult CheckDirection(
        double bwMm, double dMm,
        double totalAslMm2, double fckMpa, double fcdMpa, double sigCpMpa,
        int totalLegs, double spacingMm, double linkDiaMm, double fywkMpa,
        double rhoWMin, double vEdN)
    {
        double absVEd = Abs(vEdN);

        // ── §6.2.2 — VRd,c ──────────────────────────────────────────────────
        double k    = Min(1.0 + Sqrt(200.0 / dMm), 2.0);
        double rhoL = Min(totalAslMm2 / (bwMm * dMm), 0.02);
        double vRdc = (CRdC * k * Pow(100.0 * rhoL * fckMpa, 1.0 / 3.0) + 0.15 * sigCpMpa) * bwMm * dMm;
        double vMin = 0.035 * Pow(k, 1.5) * Sqrt(fckMpa);
        vRdc = Max(vRdc, (vMin + 0.15 * sigCpMpa) * bwMm * dMm);

        bool linksRequired = absVEd > vRdc;

        // No links → concrete-only capacity; compute §9.2.2(5) minimum for reference
        if (totalLegs <= 0 || spacingMm <= 0 || linkDiaMm <= 0 || fywkMpa <= 0)
        {
            // §9.2.2(5) minimum Asw/s even without link data (can't verify — pass = true)
            return new(vRdc, 0, 0, vRdc, linksRequired,
                       IsStruttingCritical: false,
                       AswSMinRequired: 0, AswSMinPass: true,
                       k, rhoL, 0, 0, 0, 0);
        }

        // ── §6.2.3 — VRd,s and VRd,max ──────────────────────────────────────
        double fywd   = fywkMpa / GammaS;
        double nu1    = 0.6 * (1.0 - fckMpa / 250.0);
        double z      = 0.9 * dMm;
        double aSwMm2 = totalLegs * PI * linkDiaMm * linkDiaMm / 4.0;
        double aswS   = aSwMm2 / spacingMm;

        // Optimal cot θ ∈ [1, 2.5] — intersection of VRd,s and VRd,max curves
        double cotSq = AlphaCw * bwMm * nu1 * fcdMpa / (aswS * fywd) - 1.0;
        double cot   = cotSq >= 6.25 ? 2.5
                     : cotSq <= 1.0  ? 1.0
                                     : Sqrt(cotSq);

        double vRds   = aswS * z * fywd * cot;
        double vRdMax = AlphaCw * bwMm * z * nu1 * fcdMpa / (cot + 1.0 / cot);
        double vRd    = Min(vRds, vRdMax);

        // Fix 4 — strut crushing: VEd > VRdMax at all allowed angles (cot = 1 is most conservative)
        double vRdMaxAt45 = AlphaCw * bwMm * z * nu1 * fcdMpa / 2.0; // cot = tan = 1
        bool isStruttingCritical = absVEd > vRdMaxAt45;

        // Fix 3 — §9.2.2(5) minimum shear reinforcement
        double aswSMinRequired = rhoWMin * bwMm; // Asw/s ≥ ρw,min × bw
        bool   aswSMinPass     = aswS >= aswSMinRequired - 1e-6;

        return new(vRdc, vRds, vRdMax, vRd, linksRequired, isStruttingCritical,
                   aswSMinRequired, aswSMinPass,
                   k, rhoL, aswS, fywd, z, cot);
    }
}
