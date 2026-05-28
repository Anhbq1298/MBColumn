using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Orchestrates the shear capacity check (EC2 §6.2 or ACI §22.5/22.6) for a rectangular
/// column section against one or more load cases.
/// </summary>
public sealed class ShearCheckService(IUnitConversionService units)
{
    /// <summary>
    /// Runs the shear check for every load case and returns per-case results plus the
    /// governing (maximum utilisation) result. Returns null when the design code does not
    /// support shear yet (ACI) or when no shear forces are present.
    /// </summary>
    public (IReadOnlyList<ShearResultDto?> PerCase, ShearResultDto? Governing) Check(
        ColumnInputDto input,
        IReadOnlyList<LoadCaseDto> activeCases,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates,
        IShearDesignService? shearService)
    {
        // Shear service null → not yet implemented for this code (ACI stub).
        if (shearService is null)
            return (activeCases.Select(_ => (ShearResultDto?)null).ToList(), null);

        double bMm, hMm;
        if (input.SectionShape == SectionShapeType.Circular)
        {
            // TODO: EC2 §6.2 for circular cross-sections uses bw ≈ D·sin(α); use D as conservative fallback.
            bMm = hMm = units.LengthToMm(input.Diameter, input.LengthUnit);
        }
        else
        {
            bMm = units.LengthToMm(input.Width,  input.LengthUnit);
            hMm = units.LengthToMm(input.Height, input.LengthUnit);
        }

        // Use the link yield strength from input; fall back to longitudinal Fy.
        double fywkMpa = input.FywkMpa > 0
            ? input.FywkMpa
            : units.StressToMpa(input.Fy, input.StressUnit);

        double fckMpa = units.StressToMpa(input.Fc, input.StressUnit);

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

        // Total longitudinal reinforcement area (all bars) in mm².
        double totalAslMm2 = rebarCoordinates.Sum(r => r.Area);

        var perCase = new List<ShearResultDto?>();
        ShearResultDto? governing = null;

        foreach (var lc in activeCases)
        {
            // Skip load cases with no shear demand.
            if (lc.Vux == 0.0 && lc.Vuy == 0.0)
            {
                perCase.Add(null);
                continue;
            }

            double vEdXN = units.ForceToN(lc.Vux, lc.ForceUnit);
            double vEdYN = units.ForceToN(lc.Vuy, lc.ForceUnit);
            double nedN  = units.ForceToN(lc.Pu,  lc.ForceUnit);

            ShearCheckResult result;
            try
            {
                result = shearService.Check(bMm, hMm, totalAslMm2, fckMpa, nedN, vEdXN, vEdYN, links);
            }
            catch (NotImplementedException)
            {
                perCase.Add(null);
                continue;
            }

            var dto = ToDto(result, input);
            perCase.Add(dto);

            if (governing is null || dto.GoverningUtilisation > governing.GoverningUtilisation)
                governing = dto;
        }

        return (perCase, governing);
    }

    private ShearResultDto ToDto(ShearCheckResult r, ColumnInputDto input)
    {
        string forceUnitLabel = input.UnitSystem == UnitSystem.Metric ? "kN" : "kip";

        double ToForce(double n) => units.ForceFromN(n, input.ForceUnit);

        double utilX = double.IsInfinity(r.UtilisationX) ? 999.0 : r.UtilisationX;
        double utilY = double.IsInfinity(r.UtilisationY) ? 999.0 : r.UtilisationY;

        return new ShearResultDto(
            VEdXDisplay:    ToForce(r.VEdXN),
            VRdcXDisplay:   ToForce(r.VRdcXN),
            VRdsXDisplay:   ToForce(r.VRdsXN),
            VRdMaxXDisplay: ToForce(r.VRdMaxXN),
            VRdXDisplay:    ToForce(r.VRdXN),
            UtilisationX:   utilX,
            StatusX:        r.StatusX,
            LinksRequiredX: r.LinksRequiredX,
            VEdYDisplay:    ToForce(r.VEdYN),
            VRdcYDisplay:   ToForce(r.VRdcYN),
            VRdsYDisplay:   ToForce(r.VRdsYN),
            VRdMaxYDisplay: ToForce(r.VRdMaxYN),
            VRdYDisplay:    ToForce(r.VRdYN),
            UtilisationY:   utilY,
            StatusY:        r.StatusY,
            LinksRequiredY: r.LinksRequiredY,
            DEffXMm:        r.DEffXMm,
            DEffYMm:        r.DEffYMm,
            CotThetaX:      r.CotThetaX,
            CotThetaY:      r.CotThetaY,
            ForceUnit:      forceUnitLabel);
    }
}
