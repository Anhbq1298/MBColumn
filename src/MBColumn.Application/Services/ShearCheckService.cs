using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Orchestrates the shear capacity check (EC2 §6.2 / ACI §22.5-22.6) for a column section
/// against one or more load cases.  Capacity is always computed even when VEd = 0.
/// </summary>
public sealed class ShearCheckService(IUnitConversionService units)
{
    public (IReadOnlyList<ShearResultDto?> PerCase, ShearResultDto? Governing) Check(
        ColumnInputDto input,
        IReadOnlyList<LoadCaseDto> activeCases,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates,
        IShearDesignService? shearService)
    {
        if (shearService is null)
            return (activeCases.Select(_ => (ShearResultDto?)null).ToList(), null);

        // ── Fix 5: Circular bw = 0.8 D per EC2 §6.2.2(5) ────────────────────
        double bMm, hMm;
        if (input.SectionShape == SectionShapeType.Circular)
        {
            double d = units.LengthToMm(input.Diameter, input.LengthUnit);
            bMm = 0.8 * d;   // EC2 §6.2.2(5): effective width for circular
            hMm = d;         // full diameter for d_eff = bMm − coverEff ≈ 0.8D − c
        }
        else
        {
            bMm = units.LengthToMm(input.Width,  input.LengthUnit);
            hMm = units.LengthToMm(input.Height, input.LengthUnit);
        }

        double fywkMpa = input.FywkMpa > 0
            ? input.FywkMpa
            : units.StressToMpa(input.Fy, input.StressUnit);
        double fckMpa   = units.StressToMpa(input.Fc,    input.StressUnit);
        double coverMm  = units.LengthToMm(input.Cover, input.LengthUnit);

        // ── Fix 1: main bar diameter from actual rebar layout ────────────────
        double mainBarDiaMm = rebarCoordinates.Count > 0
            ? rebarCoordinates.Max(r => r.Diameter)
            : 20.0; // conservative fallback

        ShearLinkReinforcement? links = null;
        if (input.LinkDiameterMm > 0 && input.LinkSpacingMm > 0)
        {
            links = new ShearLinkReinforcement(
                input.LinkDiameterMm,
                input.LinkSpacingMm,
                input.TotalLegsX,
                input.TotalLegsY,
                fywkMpa);
        }

        double totalAslMm2 = rebarCoordinates.Sum(r => r.Area);
        var perCase   = new List<ShearResultDto?>();
        ShearResultDto? governing = null;

        foreach (var lc in activeCases)
        {
            double vEdXN = units.ForceToN(lc.Vux, lc.ForceUnit);
            double vEdYN = units.ForceToN(lc.Vuy, lc.ForceUnit);
            double nedN  = units.ForceToN(lc.Pu,  lc.ForceUnit);

            ShearCheckResult result;
            try
            {
                result = shearService.Check(
                    bMm, hMm, totalAslMm2, fckMpa, nedN,
                    vEdXN, vEdYN, links,
                    coverMm, mainBarDiaMm);  // Fix 1 + Fix 5 data passed here
            }
            catch (NotImplementedException)
            {
                perCase.Add(null);
                continue;
            }

            var dto = ToDto(result, input);
            perCase.Add(dto);

            bool better = governing is null
                || dto.GoverningUtilisation > governing.GoverningUtilisation
                || (dto.HasDemand && !governing.HasDemand);
            if (better) governing = dto;
        }

        return (perCase, governing);
    }

    private ShearResultDto ToDto(ShearCheckResult r, ColumnInputDto input)
    {
        string fUnit = input.UnitSystem == UnitSystem.Metric ? "kN" : "kip";
        double F(double n) => units.ForceFromN(n, input.ForceUnit);

        double utilX = double.IsInfinity(r.UtilisationX) ? 999.0 : r.UtilisationX;
        double utilY = double.IsInfinity(r.UtilisationY) ? 999.0 : r.UtilisationY;

        return new ShearResultDto(
            VEdXDisplay:          F(r.VEdXN),
            VRdcXDisplay:         F(r.VRdcXN),
            VRdsXDisplay:         F(r.VRdsXN),
            VRdMaxXDisplay:       F(r.VRdMaxXN),
            VRdXDisplay:          F(r.VRdXN),
            UtilisationX:         utilX,
            StatusX:              r.StatusX,
            LinksRequiredX:       r.LinksRequiredX,
            IsStruttingCriticalX: r.IsStruttingCriticalX,
            AswSMinRequiredX:     r.AswSMinRequiredX,
            AswSMinPassX:         r.AswSMinPassX,

            VEdYDisplay:          F(r.VEdYN),
            VRdcYDisplay:         F(r.VRdcYN),
            VRdsYDisplay:         F(r.VRdsYN),
            VRdMaxYDisplay:       F(r.VRdMaxYN),
            VRdYDisplay:          F(r.VRdYN),
            UtilisationY:         utilY,
            StatusY:              r.StatusY,
            LinksRequiredY:       r.LinksRequiredY,
            IsStruttingCriticalY: r.IsStruttingCriticalY,
            AswSMinRequiredY:     r.AswSMinRequiredY,
            AswSMinPassY:         r.AswSMinPassY,

            BwXMm:    r.BwXMm,    DEffXMm:  r.DEffXMm,
            KFactorX: r.KFactorX, RhoLX:    r.RhoLX,
            SigCpMpa: r.SigCpMpa,
            BwYMm:    r.BwYMm,    DEffYMm:  r.DEffYMm,
            KFactorY: r.KFactorY, RhoLY:    r.RhoLY,

            AswSX:     r.AswSX,   AswSY:    r.AswSY,
            FywdMpa:   r.FywdMpa,
            ZXMm:      r.ZXMm,    ZYMm:     r.ZYMm,
            CotThetaX: r.CotThetaX, CotThetaY: r.CotThetaY,
            ForceUnit: fUnit);
    }
}
