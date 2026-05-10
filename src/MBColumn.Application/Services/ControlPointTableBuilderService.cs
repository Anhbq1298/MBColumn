using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Builds the 8-point control-point table (spColumn "Control Points" report format)
/// for each of the four principal bending axes: X, Y, -X, -Y.
/// </summary>
public static class ControlPointTableBuilderService
{
    private const double MaxStrainClamp = 9.99999;

    // theta=90 â†’ compression in +y â†’ bending about X axis â†’ Mnx moment (spColumn "X")
    // theta=0  â†’ compression in +x â†’ bending about Y axis â†’ Mny moment (spColumn "Y")
    private static readonly (string Axis, double AngleDeg)[] Axes =
    [
        ("X",   90.0),
        ("Y",    0.0),
        ("-X", 270.0),
        ("-Y", 180.0),
    ];

    private static readonly string[] PointLabels =
    [
        "Max compression",
        "Allowable comp.",
        "fs = 0.0",
        "fs = 0.5 fy",
        "Balanced point",
        "Tension control",
        "Pure bending",
        "Max tension",
    ];

    public static ControlPointTableDto Build(
        InteractionSurface surface,
        RectangularSection section,
        double fyMpa,
        double esMpa,
        UnitSystem unitSystem,
        IUnitConversionService units,
        IDesignCodeService code)
    {
        double maxPhiPn = surface.Points.Where(p => p.PhiPn > 0).Select(p => p.PhiPn).DefaultIfEmpty(0).Max();
        double compressionLimitN = code.CompressionDesignLimit(maxPhiPn);

        double ecu = code.ConcreteUltimateStrain;
        double eyield = fyMpa / esMpa;

        var rows = new List<ControlPointTableRowDto>();

        foreach (var (axisLabel, angleDeg) in Axes)
        {
            int ai = NearestAngleIndex(surface, angleDeg);

            // Sorted descending by depth â†’ descending c â†’ descending P (compression â†’ tension)
            var pts = surface.Points
                .Where(p => p.AngleIndex == ai)
                .OrderByDescending(p => p.DepthIndex)
                .ToList();

            if (pts.Count == 0) continue;

            // dt computed analytically from bar geometry (distance from compression face to
            // extreme tension bar), matching spColumn's approach.
            double dtMm = ComputeDt(section, angleDeg);
            double dtDisplay = DisplayLength(dtMm, unitSystem, units);

            // Analytical c for strain-defined points: c = ÎµcuÂ·dt / (Îµcu + Îµt_target)
            // Using depth-based interpolation avoids error from the non-linear P-c curve
            // where bars transition between elastic and yielded zones.
            double cFsHalf  = ecu * dtMm / (ecu + 0.5 * eyield);
            double cBalance = ecu * dtMm / (ecu + eyield);
            double cTension = ecu * dtMm / (ecu + 0.005);

            // The 8 labeled points
            InteractionPoint?[] labeled =
            [
                pts[0],                                                // 0 Max compression
                InterpolateAtPhiPn(pts, compressionLimitN),           // 1 Allowable comp.
                InterpolateAtDepth(pts, dtMm),                        // 2 fs = 0.0 (NA = dt by definition)
                InterpolateAtDepth(pts, cFsHalf),                     // 3 fs = 0.5 fy
                InterpolateAtDepth(pts, cBalance),                    // 4 Balanced point
                InterpolateAtDepth(pts, cTension),                    // 5 Tension control
                InterpolateAtPn(pts, 0.0),                            // 6 Pure bending â€” bracket on Pn (not PhiPn)
                pts[^1],                                               // 7 Max tension
            ];

            for (int k = 0; k < labeled.Length; k++)
            {
                var pt = labeled[k];
                if (pt is null) continue;

                bool isMaxTension  = k == 7;
                bool isPureBending = k == 6;
                double naDepthMm = isMaxTension ? 0.0 : Math.Max(0, pt.NeutralAxisDepthMm);

                // Signed Îµt = Îµcu*(dt - c)/c  (positive = tension, negative = all bars in compression).
                // Max tension row uses the sentinel 9.99999 (spColumn convention for c â†’ 0).
                double epsilonT;
                if (isMaxTension)
                    epsilonT = MaxStrainClamp;
                else if (pt.NeutralAxisDepthMm > 1e-6 && dtMm > 0)
                    epsilonT = Math.Clamp(ecu * (dtMm - pt.NeutralAxisDepthMm) / pt.NeutralAxisDepthMm, -MaxStrainClamp, MaxStrainClamp);
                else
                    epsilonT = MaxStrainClamp;

                double analyticalPhi = code.Phi(Math.Max(0.0, epsilonT), fyMpa, esMpa);
                // Pure bending: P is zero by definition â€” hardcode to eliminate floating-point
                // residue from the Pn-bracket lerp. Mirrors spColumn's convention where the P=0
                // row is constructed at the converged neutral-axis depth, not interpolated.
                double rowAxialN = isPureBending ? 0.0 : analyticalPhi * pt.Pn;
                rows.Add(new ControlPointTableRowDto(
                    axisLabel,
                    PointLabels[k],
                    DisplayForce(rowAxialN, unitSystem, units),
                    DisplayMoment(analyticalPhi * pt.Mnx, unitSystem, units),
                    DisplayMoment(analyticalPhi * pt.Mny, unitSystem, units),
                    DisplayLength(naDepthMm, unitSystem, units),
                    dtDisplay,
                    epsilonT,
                    analyticalPhi));
            }
        }

        bool metric = unitSystem == UnitSystem.Metric;
        return new ControlPointTableDto(
            rows,
            metric ? "kN"    : "kip",
            metric ? "kN-m"  : "kip-ft",
            metric ? "mm"    : "in");
    }

    // â”€â”€ Interpolation helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Interpolates within <paramref name="pts"/> (sorted descending P) to find
    /// where PhiPn = <paramref name="target"/>.
    /// </summary>
    private static InteractionPoint? InterpolateAtPhiPn(
        IReadOnlyList<InteractionPoint> pts, double target)
    {
        for (int i = 0; i < pts.Count - 1; i++)
        {
            double a = pts[i].PhiPn, b = pts[i + 1].PhiPn;
            if ((a >= target && b <= target) || (a <= target && b >= target))
                return Lerp(pts[i], pts[i + 1], Fraction(a, b, target));
        }
        return pts.MinBy(p => Math.Abs(p.PhiPn - target));
    }

    /// <summary>
    /// Interpolates within <paramref name="pts"/> (sorted descending P) to find
    /// where Pn = <paramref name="target"/>. Used for the pure-bending row where
    /// Ï† varies between bracket samples (compression-controlled vs tension-
    /// controlled Ï† values differ); bracketing on PhiPn would otherwise leave
    /// Pn â‰  0 at the interpolated point. Mirrors spColumn's invariant that
    /// the P=0 row is built at the c that satisfies axial equilibrium directly.
    /// </summary>
    private static InteractionPoint? InterpolateAtPn(
        IReadOnlyList<InteractionPoint> pts, double target)
    {
        for (int i = 0; i < pts.Count - 1; i++)
        {
            double a = pts[i].Pn, b = pts[i + 1].Pn;
            if ((a >= target && b <= target) || (a <= target && b >= target))
                return Lerp(pts[i], pts[i + 1], Fraction(a, b, target));
        }
        return pts.MinBy(p => Math.Abs(p.Pn - target));
    }

    /// <summary>
    /// Interpolates within <paramref name="pts"/> (sorted descending c) to find
    /// where MaxTensionSteelStrain = <paramref name="target"/>.
    /// Searches from the tension end so target=0 finds the fs=0 transition rather than
    /// the first of many zero-valued compression-dominated points at the top of the list.
    /// </summary>
    private static InteractionPoint? InterpolateAtStrain(
        IReadOnlyList<InteractionPoint> pts, double target)
    {
        for (int i = pts.Count - 1; i > 0; i--)
        {
            double a = pts[i].MaxTensionSteelStrain, b = pts[i - 1].MaxTensionSteelStrain;
            if ((a <= target && b >= target) || (a >= target && b <= target))
                return Lerp(pts[i], pts[i - 1], Fraction(a, b, target));
        }
        return pts.MinBy(p => Math.Abs(p.MaxTensionSteelStrain - target));
    }

    /// <summary>
    /// Interpolates within <paramref name="pts"/> (sorted descending c) to find
    /// where NeutralAxisDepthMm = <paramref name="targetC"/>. Used to evaluate forces
    /// at an exact c value (e.g. c = dt for the fs = 0 point).
    /// </summary>
    private static InteractionPoint? InterpolateAtDepth(
        IReadOnlyList<InteractionPoint> pts, double targetC)
    {
        for (int i = 0; i < pts.Count - 1; i++)
        {
            double a = pts[i].NeutralAxisDepthMm, b = pts[i + 1].NeutralAxisDepthMm;
            if ((a >= targetC && b <= targetC) || (a <= targetC && b >= targetC))
                return Lerp(pts[i], pts[i + 1], Fraction(a, b, targetC));
        }
        return pts.MinBy(p => Math.Abs(p.NeutralAxisDepthMm - targetC));
    }

    private static double Fraction(double a, double b, double target)
    {
        double d = b - a;
        return Math.Abs(d) < 1e-12 ? 0.0 : Math.Clamp((target - a) / d, 0, 1);
    }

    private static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t)
        => new(a.DepthIndex, a.AngleIndex,
               Lin(a.ThetaDegrees,          b.ThetaDegrees,          t),
               Lin(a.NeutralAxisDepthMm,     b.NeutralAxisDepthMm,     t),
               Lin(a.Pn,                     b.Pn,                     t),
               Lin(a.Mnx,                    b.Mnx,                    t),
               Lin(a.Mny,                    b.Mny,                    t),
               Lin(a.Phi,                    b.Phi,                    t),
               Lin(a.MaxTensionSteelStrain,  b.MaxTensionSteelStrain,  t),
               Lin(a.ConcretePn,             b.ConcretePn,             t),
               Lin(a.SteelPn,                b.SteelPn,                t),
               Lin(a.ConcreteMnx,            b.ConcreteMnx,            t),
               Lin(a.ConcreteMny,            b.ConcreteMny,            t),
               Lin(a.SteelMnx,               b.SteelMnx,               t),
               Lin(a.SteelMny,               b.SteelMny,               t),
               Lin(a.MaxConcreteStrain,      b.MaxConcreteStrain,      t),
               Lin(a.MinConcreteStrain,      b.MinConcreteStrain,      t),
               Lin(a.MaxSteelStrain,         b.MaxSteelStrain,         t),
               Lin(a.MinSteelStrain,         b.MinSteelStrain,         t),
               string.IsNullOrWhiteSpace(a.StateLabel) ? b.StateLabel : a.StateLabel);

    private static double Lin(double a, double b, double t) => a + (b - a) * t;

    // â”€â”€ Geometry helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static int NearestAngleIndex(InteractionSurface surface, double angleDeg)
    {
        double norm = ((angleDeg % 360) + 360) % 360;
        double step = 360.0 / surface.AngleCount;
        return (int)Math.Round(norm / step) % surface.AngleCount;
    }

    // â”€â”€ Unit helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    private static double DisplayForce(double n, UnitSystem u, IUnitConversionService s)
        => s.ForceFromN(n, u == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip);

    private static double DisplayMoment(double nmm, UnitSystem u, IUnitConversionService s)
        => s.MomentFromNmm(nmm, u == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt);

    private static double DisplayLength(double mm, UnitSystem u, IUnitConversionService s)
        => u == UnitSystem.Metric ? mm : s.LengthFromMm(mm, LengthUnit.Inch);

    // â”€â”€ Geometry helpers â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€

    /// <summary>
    /// Analytical dt: distance from the compression face to the extreme tension bar
    /// along the neutral axis direction (matching spColumn's Depth.OfReinforcement approach).
    /// </summary>
    private static double ComputeDt(RectangularSection section, double angleDeg)
    {
        double theta = angleDeg * Math.PI / 180.0;
        double nx = Math.Cos(theta), ny = Math.Sin(theta);
        double hx = section.WidthMm / 2.0, hy = section.HeightMm / 2.0;
        double maxProjection = new[] { -hx * nx - hy * ny, hx * nx - hy * ny, hx * nx + hy * ny, -hx * nx + hy * ny }.Max();
        double minBarProjection = section.RebarLayout.Bars.Min(b => b.XMm * nx + b.YMm * ny);
        return maxProjection - minBarProjection;
    }

}

