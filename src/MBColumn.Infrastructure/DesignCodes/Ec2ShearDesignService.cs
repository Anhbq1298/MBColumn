using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using static System.Math;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// EC2 EN 1992-1-1:2004 shear capacity check for rectangular column sections.
///
/// Without shear reinforcement — §6.2.2:
///   VRd,c = [CRd,c · k · (100 ρl · fck)^(1/3) + k1 · σcp] · bw · d
///   VRd,c ≥ (vmin + k1 · σcp) · bw · d
///   CRd,c = 0.18/γc, k = 1 + √(200/d) ≤ 2, k1 = 0.15
///   vmin = 0.035 · k^1.5 · fck^0.5
///   σcp = NEd/Ac (compressive +ve) ≤ 0.2·fcd
///
/// With shear reinforcement — §6.2.3 variable-angle truss:
///   VRd,s   = (Asw/s) · z · fywd · cotθ
///   VRd,max = αcw · bw · z · ν1 · fcd / (cotθ + tanθ)
///   Optimal cotθ ∈ [1, 2.5] where VRd,s = VRd,max; if links are too strong, strut governs.
///   z = 0.9·d,  ν1 = 0.6·(1 − fck/250),  αcw = 1.0  (non-prestressed)
///
/// Sign convention for shear geometry (rectangular section b × h):
///   VEdX  →  bw = h (Y dim),  d = b − cover_eff,  Asw/s uses TotalLegsX
///   VEdY  →  bw = b (X dim),  d = h − cover_eff,  Asw/s uses TotalLegsY
/// </summary>
public sealed class Ec2ShearDesignService : IShearDesignService
{
    private const double GammaC  = 1.50;
    private const double GammaS  = 1.15;
    private const double AlphaCc = 0.85; // Singapore/UK NA
    private const double K1      = 0.15; // EC2 eq. (6.2.a)
    private const double CRdC    = 0.18 / GammaC;   // 0.12
    private const double AlphaCw = 1.00; // non-prestressed

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

        // σcp  (compressive positive, capped at 0.2 fcd per §6.2.2(1))
        double sigCp = nedN / acMm2;
        sigCp = Min(sigCp, 0.2 * fcd);

        double linkDia = links?.LinkDiameterMm ?? 0.0;
        // Effective depth = section dim − nominal cover − link dia − half main bar dia.
        // We do not have the main bar dia explicitly in the interface, so we approximate
        // cover_eff = 60 mm (conservative fallback). With links supplied, main bar contribution
        // is folded into this value.
        // TODO: expose main bar diameter so d_eff can be computed precisely.
        const double DefaultCoverEffMm = 60.0;

        // For shear in X: bw = h, d = b − coverEff
        // For shear in Y: bw = b, d = h − coverEff
        double bwX   = hMm;
        double dEffX = Max(bMm - DefaultCoverEffMm, 1.0);
        double bwY   = bMm;
        double dEffY = Max(hMm - DefaultCoverEffMm, 1.0);

        var (vRdcX, vRdsX, vRdMaxX, vRdX, linksReqX, cotX) =
            CheckDirection(bwX, dEffX, totalAslMm2, fckMpa, fcd, sigCp,
                links?.TotalLegsX ?? 0, links?.SpacingMm ?? 0, linkDia, links?.FywkMpa ?? 0, vEdXN);

        var (vRdcY, vRdsY, vRdMaxY, vRdY, linksReqY, cotY) =
            CheckDirection(bwY, dEffY, totalAslMm2, fckMpa, fcd, sigCp,
                links?.TotalLegsY ?? 0, links?.SpacingMm ?? 0, linkDia, links?.FywkMpa ?? 0, vEdYN);

        double utilX = vRdX > 0 ? Abs(vEdXN) / vRdX : (Abs(vEdXN) > 0 ? double.PositiveInfinity : 0.0);
        double utilY = vRdY > 0 ? Abs(vEdYN) / vRdY : (Abs(vEdYN) > 0 ? double.PositiveInfinity : 0.0);

        return new ShearCheckResult(
            VEdXN:          vEdXN,
            VRdcXN:         vRdcX,
            VRdsXN:         vRdsX,
            VRdMaxXN:       vRdMaxX,
            VRdXN:          vRdX,
            UtilisationX:   utilX,
            StatusX:        utilX <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredX: linksReqX,
            VEdYN:          vEdYN,
            VRdcYN:         vRdcY,
            VRdsYN:         vRdsY,
            VRdMaxYN:       vRdMaxY,
            VRdYN:          vRdY,
            UtilisationY:   utilY,
            StatusY:        utilY <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail,
            LinksRequiredY: linksReqY,
            DEffXMm:        dEffX,
            DEffYMm:        dEffY,
            CotThetaX:      cotX,
            CotThetaY:      cotY);
    }

    /// <summary>Checks one shear direction, returning capacity components and status.</summary>
    private static (double VRdc, double VRds, double VRdMax, double VRd,
                    bool LinksRequired, double CotTheta)
        CheckDirection(
            double bwMm, double dMm,
            double totalAslMm2, double fckMpa, double fcdMpa, double sigCpMpa,
            int totalLegs, double spacingMm, double linkDiaMm, double fywkMpa,
            double vEdN)
    {
        double absVEd = Abs(vEdN);

        // ── §6.2.2 — VRd,c without shear reinforcement ───────────────────────
        double k       = Min(1.0 + Sqrt(200.0 / dMm), 2.0);
        double rhoL    = Min(totalAslMm2 / (bwMm * dMm), 0.02);
        double vRdc    = (CRdC * k * Pow(100.0 * rhoL * fckMpa, 1.0 / 3.0) + K1 * sigCpMpa) * bwMm * dMm;
        double vMin    = 0.035 * Pow(k, 1.5) * Sqrt(fckMpa);
        double vRdcMin = (vMin + K1 * sigCpMpa) * bwMm * dMm;
        vRdc = Max(vRdc, vRdcMin);

        bool linksRequired = absVEd > vRdc;

        // ── §6.2.3 — VRd,s and VRd,max with shear reinforcement ─────────────
        if (totalLegs <= 0 || spacingMm <= 0 || linkDiaMm <= 0 || fywkMpa <= 0)
            return (vRdc, 0.0, 0.0, vRdc, linksRequired, 0.0);

        double fywd   = fywkMpa / GammaS;
        double nu1    = 0.6 * (1.0 - fckMpa / 250.0);
        double z      = 0.9 * dMm;
        double aSwMm2 = totalLegs * PI * linkDiaMm * linkDiaMm / 4.0;
        double aswS   = aSwMm2 / spacingMm;

        // Optimal cot θ where VRd,s = VRd,max:
        //   aswS · fywd · (cot² + 1) = αcw · bw · ν1 · fcd
        //   cot² = [αcw · bw · ν1 · fcd / (aswS · fywd)] − 1
        double cotSq = AlphaCw * bwMm * nu1 * fcdMpa / (aswS * fywd) - 1.0;
        double cot;
        if (cotSq >= 6.25)      // ≥ 2.5²
            cot = 2.5;          // links are light — link capacity governs; use max angle benefit
        else if (cotSq <= 1.0)
            cot = 1.0;          // links are heavy — strut governs; use steepest allowed angle
        else
            cot = Sqrt(cotSq);

        double vRds   = aswS * z * fywd * cot;
        double vRdMax = AlphaCw * bwMm * z * nu1 * fcdMpa / (cot + 1.0 / cot);
        double vRd    = Min(vRds, vRdMax);

        return (vRdc, vRds, vRdMax, vRd, linksRequired, cot);
    }
}
