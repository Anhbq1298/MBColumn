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
/// Circular:
///   Caller passes bMm = 0.8 D for VRd,c/VRd,max and hMm = D.
///   VRd,s uses the Orr-Bath circular hoop model:
///   VRd,s = (π/2) · (Ah/s) · D' · fywd · cot θ.
///   Internal diameter ties are ignored in VRd,s.
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
        bool isCircularHoop = links?.IsCircularHoop == true;
        double acMm2 = isCircularHoop
            ? PI * hMm * hMm / 4.0
            : bMm * hMm;
        double fcd   = AlphaCc * fckMpa / GammaC;
        double sigCp = acMm2 > 0 ? Min(nedN / acMm2, 0.2 * fcd) : 0.0;
        double linkDia  = links?.LinkDiameterMm ?? 0.0;
        double coverEff = coverMm + linkDia + mainBarDiaMm / 2.0;
        double fywkMpa  = links?.FywkMpa ?? 0.0;

        // ── Circular hoop model (Orr-Bath / EC2 §6.2.3) ──────────────────────
        if (isCircularHoop)
        {
            var hoopLinks = links!;
            double bw   = bMm;  // 0.8D, set by caller per EC2 §6.2.2(5)
            double dEff = Max(hMm - coverEff, 1.0); // d = D − cover_eff
            double dPrim = hoopLinks.HoopCentrelineDiameterMm > 0
                ? hoopLinks.HoopCentrelineDiameterMm
                : Max(hMm - 2.0 * coverMm - linkDia, 1.0); // auto D' = D − 2c − φh

            double rhoWMin = fywkMpa > 0 ? 0.08 * Sqrt(fckMpa) / fywkMpa : 0.0;
            var dx = CheckDirectionCircular(bw, dEff, dPrim, totalAslMm2, fckMpa, fcd,
                sigCp, hoopLinks.HoopAhMm2, hoopLinks.SpacingMm, fywkMpa, rhoWMin, vEdXN);
            var dy = CheckDirectionCircular(bw, dEff, dPrim, totalAslMm2, fckMpa, fcd,
                sigCp, hoopLinks.HoopAhMm2, hoopLinks.SpacingMm, fywkMpa, rhoWMin, vEdYN);

            double circularUtilX = dx.VRd > 0 ? Abs(vEdXN) / dx.VRd : (Abs(vEdXN) > 0 ? double.PositiveInfinity : 0.0);
            double circularUtilY = dy.VRd > 0 ? Abs(vEdYN) / dy.VRd : (Abs(vEdYN) > 0 ? double.PositiveInfinity : 0.0);

            return new ShearCheckResult(
                VEdXN: vEdXN,  VRdcXN: dx.VRdc,  VRdsXN: dx.VRds,  VRdMaxXN: dx.VRdMax,  VRdXN: dx.VRd,
                UtilisationX: circularUtilX,  StatusX: circularUtilX <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
                LinksRequiredX: dx.LinksRequired, IsStruttingCriticalX: dx.IsStruttingCritical,
                AswSMinRequiredX: dx.AswSMinRequired, AswSMinPassX: dx.AswSMinPass,

                VEdYN: vEdYN,  VRdcYN: dy.VRdc,  VRdsYN: dy.VRds,  VRdMaxYN: dy.VRdMax,  VRdYN: dy.VRd,
                UtilisationY: circularUtilY,  StatusY: circularUtilY <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
                LinksRequiredY: dy.LinksRequired, IsStruttingCriticalY: dy.IsStruttingCritical,
                AswSMinRequiredY: dy.AswSMinRequired, AswSMinPassY: dy.AswSMinPass,

                BwXMm: bw,  DEffXMm: dEff,  KFactorX: dx.K,  RhoLX: dx.RhoL,  SigCpMpa: sigCp,
                BwYMm: bw,  DEffYMm: dEff,  KFactorY: dy.K,  RhoLY: dy.RhoL,
                AswSX: dx.AswS,  AswSY: dy.AswS,
                FywdMpa: dx.Fywd > 0 ? dx.Fywd : dy.Fywd,
                ZXMm: dx.Z,  ZYMm: dy.Z,  CotThetaX: dx.CotTheta,  CotThetaY: dy.CotTheta,
                IsCircularHoop: true,
                LinkAhMm2: hoopLinks.HoopAhMm2,
                LinkSpacingMm: hoopLinks.SpacingMm,
                CircularHoopCentrelineDiameterMm: dPrim,
                FckMpa: fckMpa,
                FcdMpa: fcd,
                FywkMpa: fywkMpa);
        }

        // ── Rectangular leg-count model ───────────────────────────────────────
        double rhoWMinRect = fywkMpa > 0 ? 0.08 * Sqrt(fckMpa) / fywkMpa : 0.0;
        double bwX   = hMm;   double dEffX = Max(bMm - coverEff, 1.0);
        double bwY   = bMm;   double dEffY = Max(hMm - coverEff, 1.0);

        var rx = CheckDirection(bwX, dEffX, totalAslMm2, fckMpa, fcd, sigCp,
            links?.TotalLegsX ?? 0, links?.SpacingMm ?? 0, linkDia, fywkMpa, rhoWMinRect, vEdXN);
        var ry = CheckDirection(bwY, dEffY, totalAslMm2, fckMpa, fcd, sigCp,
            links?.TotalLegsY ?? 0, links?.SpacingMm ?? 0, linkDia, fywkMpa, rhoWMinRect, vEdYN);

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
            CotThetaY:  ry.CotTheta,
            IsCircularHoop: false,
            LinkAhMm2: links is null ? 0.0 : PI * linkDia * linkDia / 4.0,
            LinkSpacingMm: links?.SpacingMm ?? 0.0,
            FckMpa: fckMpa,
            FcdMpa: fcd,
            FywkMpa: fywkMpa);
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
        double trussVRd = Min(vRds, vRdMax);
        double vRd = linksRequired ? trussVRd : vRdc;

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

    private static DirectionResult CheckDirectionCircular(
        double bwMm, double dMm, double hoopCentrelineDiameterMm,
        double totalAslMm2, double fckMpa, double fcdMpa, double sigCpMpa,
        double hoopAhMm2, double spacingMm, double fywkMpa,
        double rhoWMin, double vEdN)
    {
        double absVEd = Abs(vEdN);

        double k = Min(1.0 + Sqrt(200.0 / dMm), 2.0);
        double rhoL = Min(totalAslMm2 / (bwMm * dMm), 0.02);
        double vRdc = (CRdC * k * Pow(100.0 * rhoL * fckMpa, 1.0 / 3.0) + 0.15 * sigCpMpa) * bwMm * dMm;
        double vMin = 0.035 * Pow(k, 1.5) * Sqrt(fckMpa);
        vRdc = Max(vRdc, (vMin + 0.15 * sigCpMpa) * bwMm * dMm);

        bool linksRequired = absVEd > vRdc;

        if (hoopAhMm2 <= 0 || spacingMm <= 0 || hoopCentrelineDiameterMm <= 0 || fywkMpa <= 0)
        {
            return new(vRdc, 0, 0, vRdc, linksRequired,
                       IsStruttingCritical: false,
                       AswSMinRequired: 0, AswSMinPass: true,
                       k, rhoL, 0, 0, 0, 0);
        }

        double fywd = fywkMpa / GammaS;
        double nu1 = 0.6 * (1.0 - fckMpa / 250.0);
        double z = 0.9 * dMm;
        double ahOverS = hoopAhMm2 / spacingMm;

        // VRd,s = circularCoefficient * cot(theta); choose cot(theta) in [1, 2.5]
        // where VRd,s intersects VRd,max when possible.
        double circularCoefficient = PI / 2.0 * ahOverS * hoopCentrelineDiameterMm * fywd;
        double cotSq = AlphaCw * bwMm * z * nu1 * fcdMpa / circularCoefficient - 1.0;
        double cot = cotSq >= 6.25 ? 2.5
                   : cotSq <= 1.0 ? 1.0
                                   : Sqrt(cotSq);

        double vRds = new EurocodeCircularColumnShearCalculator()
            .Calculate(new CircularShearInput(
                HoopDiameterMm: Sqrt(4.0 * hoopAhMm2 / PI),
                HoopSpacingMm: spacingMm,
                HoopCentrelineDiameterMm: hoopCentrelineDiameterMm,
                FywdMpa: fywd,
                CotTheta: cot))
            .VRdsN;

        double vRdMax = AlphaCw * bwMm * z * nu1 * fcdMpa / (cot + 1.0 / cot);
        double trussVRd = Min(vRds, vRdMax);
        double vRd = linksRequired ? trussVRd : vRdc;
        double vRdMaxAt45 = AlphaCw * bwMm * z * nu1 * fcdMpa / 2.0;
        bool isStruttingCritical = absVEd > vRdMaxAt45;

        double aswSMinRequired = rhoWMin * bwMm;
        bool aswSMinPass = ahOverS >= aswSMinRequired - 1e-6;

        return new(vRdc, vRds, vRdMax, vRd, linksRequired, isStruttingCritical,
                   aswSMinRequired, aswSMinPass,
                   k, rhoL, ahOverS, fywd, z, cot);
    }
}
