using MBColumn.Application.DTOs;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using System.Globalization;
using static System.Math;

namespace MBColumn.Application.Services;

/// <summary>
/// Evaluates reinforcement code-compliance for a column section.
///
/// EC2 EN 1992-1-1:2004 checks:
///   Longitudinal (§9.5.1 / §9.5.2):
///     ds ≥ 8 mm                                  — §9.5.2(1) minimum bar diameter
///     As ≥ max(0.002 Ag, 0.1 NEd/(0.87 fyk))   — §9.5.2(2) minimum
///     As ≤ 0.04 Ag                               — §9.5.2(3) maximum (outside laps)
///     nBars ≥ 4 (rectangular) / ≥ 6 (circular)  — §9.5.1 implied, standard practice
///     clear spacing ≥ max(ds, 20 mm)             — §8.2 aggregate term not modelled
///
///   Transverse links (§9.5.3):
///     dsw ≥ max(6, 0.25 dsmax)                  — §9.5.3(1) minimum link diameter
///     s   ≤ min(20 dsmin, bmin, 400)             — §9.5.3(3) maximum link spacing
///     gap ≤ 150 mm between restrained bars       — §9.5.3(6)
///
/// ACI 318-19 checks (stubs — TODO):
///   0.01 Ag ≤ Ast ≤ 0.08 Ag                     — §10.6.1.1
///   nBars ≥ 4 (ties) / ≥ 6 (spirals)            — §10.7.3.1
///   Tie diameter and spacing                     — §25.7.2
/// </summary>
public sealed class RebarComplianceCheckService(IUnitConversionService units)
{
    private static string V(double v, int dp = 1) =>
        v.ToString($"F{dp}", CultureInfo.InvariantCulture);

    /// <param name="input">Column input DTO (geometry, materials, link data).</param>
    /// <param name="rebarCoordinates">Bar list with Diameter and Area per bar.</param>
    /// <param name="maxCompNedN">Maximum compressive axial force across active load cases (N, +ve = compression).</param>
    public RebarComplianceResult Check(
        ColumnInputDto input,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates,
        double maxCompNedN)
    {
        if (input.DesignCode == DesignCodeType.Aci318Style)
            return BuildAciStub(input, rebarCoordinates);

        return BuildEc2(input, rebarCoordinates, maxCompNedN);
    }

    // ── EC2 ──────────────────────────────────────────────────────────────────

    private RebarComplianceResult BuildEc2(
        ColumnInputDto input,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates,
        double maxCompNedN)
    {
        bool isCircular   = input.SectionShape == SectionShapeType.Circular;
        bool isIrregular  = input.SectionShape == SectionShapeType.Irregular;

        double bMm = isCircular ? units.LengthToMm(input.Diameter, input.LengthUnit)
                                : units.LengthToMm(input.Width,    input.LengthUnit);
        double hMm = isCircular ? bMm
                    : isIrregular ? units.LengthToMm(input.Height, input.LengthUnit)
                                  : units.LengthToMm(input.Height, input.LengthUnit);

        double agMm2  = isCircular ? PI * bMm * bMm / 4.0
                       : isIrregular ? GrossAreaForIrregular(input, bMm * hMm)
                                     : bMm * hMm;
        double fykMpa = units.StressToMpa(input.Fy, input.StressUnit);
        double coverMm = units.LengthToMm(input.Cover, input.LengthUnit);

        double totalAsMm2  = rebarCoordinates.Sum(r => r.Area);
        double maxBarDiaMm = rebarCoordinates.Count > 0 ? rebarCoordinates.Max(r => r.Diameter) : 20.0;
        double minBarDiaMm = rebarCoordinates.Count > 0 ? rebarCoordinates.Min(r => r.Diameter) : 20.0;
        int    nBars       = rebarCoordinates.Count;

        var checks = new List<ComplianceCheck>();

        checks.Add(new ComplianceCheck(
            "EC2 §9.5.2(1)",
            "Min. longitudinal bar diameter",
            "ds ≥ 8 mm",
            $"Ø{V(minBarDiaMm, 0)} mm",
            "≥ Ø8 mm",
            minBarDiaMm >= 8.0 - 0.01));

        // ── §9.5.2(2) — Minimum longitudinal reinforcement ───────────────────
        double asMinNed  = Max(0.0, 0.1 * maxCompNedN / (0.87 * fykMpa));
        double asMinFrac = 0.002 * agMm2;
        double asMin     = Max(asMinNed, asMinFrac);
        string nedStr    = maxCompNedN > 0
            ? $" (NEd = {V(maxCompNedN / 1000.0)} kN → 0.1 NEd / 0.87 fyk = {V(asMinNed, 0)} mm²)"
            : " (NEd ≈ 0 — 0.002 Ag governs)";
        checks.Add(new ComplianceCheck(
            "EC2 §9.5.2(2)",
            "Min. longitudinal reinforcement",
            "As ≥ max(0.002 Ag, 0.1 NEd / 0.87 fyk)",
            $"{V(totalAsMm2, 0)} mm²",
            $"≥ {V(asMin, 0)} mm²{nedStr}",
            totalAsMm2 >= asMin - 1.0));

        // ── §9.5.2(3) — Maximum longitudinal reinforcement ───────────────────
        double asMax = 0.04 * agMm2;
        checks.Add(new ComplianceCheck(
            "EC2 §9.5.2(3)",
            "Max. longitudinal reinforcement",
            "As ≤ 0.04 Ag  (outside lap zones)",
            $"{V(totalAsMm2, 0)} mm²  (ρg = {(totalAsMm2 / agMm2 * 100):F2}%)",
            $"≤ {V(asMax, 0)} mm²  (4.0%)",
            totalAsMm2 <= asMax + 1.0));

        // ── §9.5.1 — Minimum bar count ────────────────────────────────────────
        int minBars = isCircular ? 6 : 4;
        string shapeNote = isCircular ? "circular section" : "rectangular/irregular";
        checks.Add(new ComplianceCheck(
            "EC2 §9.5.1",
            "Minimum number of longitudinal bars",
            $"n ≥ {minBars}  ({shapeNote})",
            $"{nBars} bars",
            $"≥ {minBars}",
            nBars >= minBars));

        if (nBars > 1)
        {
            var (clearSpacingMm, clearSpacingMinMm) = GoverningClearSpacing(rebarCoordinates);
            checks.Add(new ComplianceCheck(
                "EC2 §8.2",
                "Minimum clear spacing between longitudinal bars",
                "clear spacing ≥ max(ds, 20 mm)  (aggregate-size term not available)",
                $"{V(clearSpacingMm, 1)} mm",
                $"≥ {V(clearSpacingMinMm, 1)} mm",
                clearSpacingMm >= clearSpacingMinMm - 0.5));
        }

        // ── §9.5.3 link checks — only when link data is supplied ──────────────
        if (isIrregular)
        {
            checks.Add(new ComplianceCheck(
                "EC2 §9.5.3",
                "Irregular transverse link detailing",
                "links must restrain longitudinal bars and satisfy §9.5.3 spacing/detailing",
                "Irregular section",
                "Not checked automatically for irregular sections",
                false));
        }
        else if (input.LinkDiameterMm > 0)
        {
            double dsw    = input.LinkDiameterMm;
            double s      = input.LinkSpacingMm;
            double dsMax  = maxBarDiaMm;
            double dsMin  = minBarDiaMm;
            double bMin   = isCircular ? bMm : Min(bMm, hMm);
            int    totX   = input.TotalLegsX;
            int    totY   = input.TotalLegsY;
            double aSwMm2 = PI * dsw * dsw / 4.0;
            bool   hasValidSpacing = s > 0.0;

            // §9.5.3(1): link diameter
            double dswMin = Max(6.0, 0.25 * dsMax);
            checks.Add(new ComplianceCheck(
                "EC2 §9.5.3(1)",
                "Min. link diameter",
                "dsw ≥ max(6, 0.25 × ds_max)",
                $"Ø{V(dsw, 0)} mm",
                $"≥ Ø{V(dswMin, 1)} mm  (0.25 × {V(dsMax, 0)} = {V(0.25 * dsMax, 1)})",
                dsw >= dswMin - 0.01));

            // §9.5.3(3): link spacing
            checks.Add(new ComplianceCheck(
                "EC2 §9.5.3(3)",
                "Link spacing provided",
                "s > 0",
                $"s = {V(s, 0)} mm",
                "> 0 mm",
                hasValidSpacing));

            double sMax = Min(Min(20.0 * dsMin, bMin), 400.0);
            checks.Add(new ComplianceCheck(
                "EC2 §9.5.3(3)",
                "Max. link spacing",
                "s ≤ min(20 ds_min, b_min, 400 mm)",
                $"s = {V(s, 0)} mm",
                $"≤ {V(sMax, 0)} mm  (min of 20×{V(dsMin, 0)} = {V(20 * dsMin, 0)}, {V(bMin, 0)}, 400)",
                hasValidSpacing && s <= sMax + 0.5));

            // §9.5.3(6): bar restraint gap
            if (!isCircular)
            {
                double xClear = bMm - 2.0 * (coverMm + dsw);
                double yClear = hMm - 2.0 * (coverMm + dsw);
                double gX     = totX > 1 && xClear > 0 ? xClear / (totX - 1) : double.PositiveInfinity;
                double gY     = totY > 1 && yClear > 0 ? yClear / (totY - 1) : double.PositiveInfinity;
                double gMax   = Max(gX, gY);
                bool gPass    = gMax <= 150.0 + 0.5;

                string gXStr  = double.IsInfinity(gX) ? "∞" : $"{V(gX, 0)}";
                string gYStr  = double.IsInfinity(gY) ? "∞" : $"{V(gY, 0)}";
                checks.Add(new ComplianceCheck(
                    "EC2 §9.5.3(6)",
                    "Max. gap between restrained bars",
                    "gap ≤ 150 mm in each direction",
                    $"ΔX = {gXStr} mm,  ΔY = {gYStr} mm",
                    "≤ 150 mm",
                    gPass));

                // Informational: Asw/s provided
                double aswSX = s > 0 ? totX * aSwMm2 / s : 0;
                double aswSY = s > 0 ? totY * aSwMm2 / s : 0;
                checks.Add(new ComplianceCheck(
                    "EC2 §9.5.3",
                    "Shear link reinforcement Asw/s",
                    "Asw/s = n_legs × (π/4 × dsw²) / s  [mm²/mm]",
                    $"X: {totX} × {V(aSwMm2, 2)} / {V(s, 0)} = {aswSX:F3} mm²/mm  |  " +
                    $"Y: {totY} × {V(aSwMm2, 2)} / {V(s, 0)} = {aswSY:F3} mm²/mm",
                    "Information only",
                    true));
            }
        }
        else
        {
            checks.Add(new ComplianceCheck(
                "EC2 §9.5.3",
                "Transverse link reinforcement",
                "Link data not provided",
                "—",
                "Specify link diameter and spacing to check §9.5.3(1), (3), (6)",
                false));
        }

        return new RebarComplianceResult(DesignCodeType.Ec2, input.SectionShape, checks);
    }

    // ── ACI 318-19 stub ───────────────────────────────────────────────────────

    private static double GrossAreaForIrregular(ColumnInputDto input, double fallbackAreaMm2)
    {
        if (input.Irregular?.BoundaryPoints is not { Count: >= 3 } boundary)
            return fallbackAreaMm2;

        var polygon = boundary
            .Select(p => new Point2D(p.X, p.Y))
            .ToList();

        double areaMm2 = PolygonGeometry.Area(polygon);
        return double.IsFinite(areaMm2) && areaMm2 > 0.0 ? areaMm2 : fallbackAreaMm2;
    }

    private static (double ClearSpacingMm, double RequiredMm) GoverningClearSpacing(
        IReadOnlyList<RebarCoordinateDto> bars)
    {
        double governingMargin = double.PositiveInfinity;
        double governingClear = double.PositiveInfinity;
        double governingRequired = 20.0;

        for (int i = 0; i < bars.Count; i++)
        {
            for (int j = i + 1; j < bars.Count; j++)
            {
                double dx = bars[i].X - bars[j].X;
                double dy = bars[i].Y - bars[j].Y;
                double centreDistance = Sqrt(dx * dx + dy * dy);
                double clear = centreDistance - 0.5 * (bars[i].Diameter + bars[j].Diameter);
                double required = Max(Max(bars[i].Diameter, bars[j].Diameter), 20.0);
                double margin = clear - required;

                if (margin < governingMargin)
                {
                    governingMargin = margin;
                    governingClear = clear;
                    governingRequired = required;
                }
            }
        }

        return (governingClear, governingRequired);
    }

    private static RebarComplianceResult BuildAciStub(
        ColumnInputDto input,
        IReadOnlyList<RebarCoordinateDto> rebarCoordinates)
    {
        var checks = new List<ComplianceCheck>
        {
            // TODO: ACI §10.6.1.1 — 0.01 Ag ≤ Ast ≤ 0.08 Ag
            new("ACI §10.6.1.1", "Longitudinal reinforcement ratio",
                "0.01 Ag ≤ Ast ≤ 0.08 Ag",
                "—", "TODO — not yet implemented", true),

            // TODO: ACI §10.7.3.1 — minimum bar count
            new("ACI §10.7.3.1", "Minimum bar count",
                "≥ 4 (tied columns) or ≥ 6 (spiral columns)",
                "—", "TODO — not yet implemented", true),

            // TODO: ACI §25.7.2 — tie diameter and spacing
            new("ACI §25.7.2", "Transverse tie reinforcement",
                "Tie diameter, spacing, and hook requirements",
                "—", "TODO — not yet implemented", true),
        };

        return new RebarComplianceResult(DesignCodeType.Aci318Style, input.SectionShape, checks);
    }
}
