using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Builds the design-code control-point table
/// for each of the four principal bending axes: X, Y, -X, -Y.
/// </summary>
public static class ControlPointTableBuilderService
{
    private const double MaxStrainClamp = 9.99999;

    // theta=90 -> compression in +y -> bending about X axis -> Mnx moment.
    // theta=0  -> compression in +x -> bending about Y axis -> Mny moment.
    private static readonly (string Axis, double AngleDeg)[] Axes =
    [
        ("X",  270.0),
        ("Y",    0.0),
        ("-X",  90.0),
        ("-Y", 180.0),
    ];

    private static readonly string[] AciPointLabels =
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

    // EC2 7-point A–G format (no ACI-style compression cap row)
    private static readonly string[] Ec2PointLabels = ["A", "B", "C", "D", "E", "F", "G"];

    public static ControlPointTableDto Build(
        InteractionSurface surface,
        ColumnSection section,
        double fyMpa,
        double esMpa,
        double fckMpa,
        UnitSystem unitSystem,
        IUnitConversionService units,
        IDesignCodeService code)
    {
        double maxPhiPn = surface.Points.Where(p => p.PhiPn > 0).Select(p => p.PhiPn).DefaultIfEmpty(0).Max();
        double compressionLimitN = code.CompressionDesignLimit(maxPhiPn);

        double ecu = code.ConcreteUltimateStrain(fckMpa);
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
            // extreme tension bar).
            double dtMm = ComputeDt(section, angleDeg);
            double dtDisplay = DisplayLength(dtMm, unitSystem, units);

            // Analytical c for strain-defined points: c = ÎµcuÂ·dt / (Îµcu + Îµt_target)
            // Using depth-based interpolation avoids error from the non-linear P-c curve
            // where bars transition between elastic and yielded zones.
            double cFsHalf  = ecu * dtMm / (ecu + 0.5 * eyield);
            double cBalance = ecu * dtMm / (ecu + eyield);
            double cTension = ecu * dtMm / (ecu + eyield + 0.003);

            // Labeled points: 7 (EC2 A–G) or 8 (ACI)
            bool ec2 = code.UseLetterControlPoints;
            string[] labels = ec2 ? Ec2PointLabels : AciPointLabels;

            InteractionPoint?[] labeled = ec2
                ? [
                    pts[0],                                            // A Max compression
                    InterpolateAtDepth(pts, dtMm),                    // B fs = 0.0 (c = dt)
                    InterpolateAtDepth(pts, cFsHalf),                 // C fs = 0.5 fyd
                    InterpolateAtDepth(pts, cBalance),                // D Balanced
                    InterpolateAtDepth(pts, cTension),                // E Tension control
                    InterpolateAtPn(pts, 0.0),                        // F Pure bending
                    pts[^1],                                           // G Max tension
                  ]
                : [
                    pts[0],                                            // 0 Max compression
                    InterpolateAtPhiPn(pts, compressionLimitN),       // 1 Allowable comp.
                    InterpolateAtDepth(pts, dtMm),                    // 2 fs = 0.0 (NA = dt by definition)
                    InterpolateAtDepth(pts, cFsHalf),                 // 3 fs = 0.5 fy
                    InterpolateAtDepth(pts, cBalance),                // 4 Balanced point
                    InterpolateAtDepth(pts, cTension),                // 5 Tension control
                    InterpolateAtPn(pts, 0.0),                        // 6 Pure bending
                    pts[^1],                                           // 7 Max tension
                  ];

            for (int k = 0; k < labeled.Length; k++)
            {
                var pt = labeled[k];
                if (pt is null) continue;

                bool isMaxTension  = k == labeled.Length - 1;
                bool isPureBending = k == labeled.Length - 2;
                double naDepthMm = isMaxTension ? 0.0 : Math.Max(0, pt.NeutralAxisDepthMm);

                // Signed Îµt = Îµcu*(dt - c)/c  (positive = tension, negative = all bars in compression).
                // Max tension row uses the table sentinel for c -> 0.
                double epsilonT;
                if (isMaxTension)
                    epsilonT = MaxStrainClamp;
                else if (pt.NeutralAxisDepthMm > 1e-6 && dtMm > 0)
                    epsilonT = Math.Clamp(ecu * (dtMm - pt.NeutralAxisDepthMm) / pt.NeutralAxisDepthMm, -MaxStrainClamp, MaxStrainClamp);
                else
                    epsilonT = MaxStrainClamp;

                double analyticalPhi = code.Phi(Math.Max(0.0, epsilonT), fyMpa, esMpa);
                // Pure bending: P is zero by definition.
                // Max tension: Pure steel capacity (sum of As * fy).
                double rowAxialN;
                if (isPureBending) 
                    rowAxialN = 0.0;
                else if (isMaxTension)
                    rowAxialN = -analyticalPhi * section.RebarLayout.Bars.Sum(b => b.AreaMm2 * fyMpa);
                else
                    rowAxialN = analyticalPhi * pt.Pn;
                rows.Add(new ControlPointTableRowDto(
                    axisLabel,
                    labels[k],
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
    /// Pn is nonzero at the interpolated point. The P=0 row is built at the
    /// neutral-axis depth that satisfies axial equilibrium directly.
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
    /// Analytical dt: distance from the extreme compression fiber to the most
    /// distant bar centroid in the tension direction, measured along the neutral
    /// axis normal. For circular sections the extreme fiber is always at R from
    /// centre; for rectangular sections it is the outermost corner.
    /// </summary>
    private static double ComputeDt(ColumnSection section, double angleDeg)
    {
        double theta = angleDeg * Math.PI / 180.0;
        double nx = Math.Cos(theta), ny = Math.Sin(theta);

        double maxProjection;
        if (section.Shape == SectionShapeType.Circular)
        {
            // Extreme compression fiber is always at radius in the compression direction
            maxProjection = section.WidthMm / 2.0;
        }
        else
        {
            double hx = section.WidthMm / 2.0, hy = section.HeightMm / 2.0;
            maxProjection = new[] { -hx * nx - hy * ny, hx * nx - hy * ny, hx * nx + hy * ny, -hx * nx + hy * ny }.Max();
        }

        double minBarProjection = section.RebarLayout.Bars.Min(b => b.XMm * nx + b.YMm * ny);
        return maxProjection - minBarProjection;
    }

}

