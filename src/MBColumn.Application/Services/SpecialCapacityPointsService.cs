using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

/// <summary>
/// Generates five structurally significant capacity points for every neutral-axis angle
/// on an interaction surface: max compression, balanced, tension-controlled, pure bending,
/// and max tension. The source InteractionSurface is searched/interpolated; no additional
/// solver passes are performed.
/// </summary>
public static class SpecialCapacityPointsService
{
    public static IReadOnlyList<SpecialCapacityEntry> Build(
        InteractionSurface surface,
        ColumnSection section,
        double fyMpa,
        double esMpa,
        double fckMpa,
        IDesignCodeService code)
    {
        var result = new List<SpecialCapacityEntry>();

        if (surface.Points.Count == 0 || section.RebarLayout.Bars.Count == 0)
            return result;

        double ecu = code.ConcreteUltimateStrain(fckMpa);
        double eyield = fyMpa / esMpa;

        for (int a = 0; a < surface.AngleCount; a++)
        {
            var pts = surface.Points
                .Where(p => p.AngleIndex == a)
                .OrderByDescending(p => p.DepthIndex)
                .ToList();

            if (pts.Count == 0) continue;

            double theta = pts[0].ThetaDegrees;
            double dtMm = ComputeDt(section, theta);

            double cZeroTension = dtMm;
            double cHalfYield = dtMm > 1e-6 ? ecu * dtMm / (ecu + 0.5 * eyield) : 0;
            double cBalance = dtMm > 1e-6 ? ecu * dtMm / (ecu + eyield) : 0;
            double cTension = dtMm > 1e-6 ? ecu * dtMm / (ecu + eyield + 0.003) : 0;

            result.Add(new SpecialCapacityEntry("Max Compression", a, theta, pts[0]));

            var zeroTension = InterpolateAtDepth(pts, cZeroTension);
            if (zeroTension is not null)
                result.Add(new SpecialCapacityEntry("Zero Tension", a, theta, zeroTension));

            var halfYield = InterpolateAtDepth(pts, cHalfYield);
            if (halfYield is not null)
                result.Add(new SpecialCapacityEntry("50% Yield", a, theta, halfYield));

            var balanced = InterpolateAtDepth(pts, cBalance);
            if (balanced is not null)
                result.Add(new SpecialCapacityEntry("Balanced", a, theta, balanced));

            var tensionCtrl = InterpolateAtDepth(pts, cTension);
            if (tensionCtrl is not null)
                result.Add(new SpecialCapacityEntry("Tension Control", a, theta, tensionCtrl));

            var pureBending = InterpolateAtPn(pts, 0.0);
            if (pureBending is not null)
                result.Add(new SpecialCapacityEntry("Pure Bending", a, theta, pureBending));

            result.Add(new SpecialCapacityEntry("Max Tension", a, theta, pts[^1]));
        }

        return result;
    }

    private static double ComputeDt(ColumnSection section, double angleDeg)
    {
        double theta = angleDeg * Math.PI / 180.0;
        double nx = Math.Cos(theta), ny = Math.Sin(theta);

        double maxProjection;
        if (section.Shape == Domain.Enums.SectionShapeType.Circular)
        {
            maxProjection = section.WidthMm / 2.0;
        }
        else
        {
            double hx = section.WidthMm / 2.0, hy = section.HeightMm / 2.0;
            maxProjection = new[] { -hx * nx - hy * ny, hx * nx - hy * ny, hx * nx + hy * ny, -hx * nx + hy * ny }.Max();
        }

        if (section.RebarLayout.Bars.Count == 0) return 0;
        double minBarProjection = section.RebarLayout.Bars.Min(b => b.XMm * nx + b.YMm * ny);
        return maxProjection - minBarProjection;
    }

    private static InteractionPoint? InterpolateAtDepth(IReadOnlyList<InteractionPoint> pts, double targetC)
    {
        for (int i = 0; i < pts.Count - 1; i++)
        {
            double a = pts[i].NeutralAxisDepthMm, b = pts[i + 1].NeutralAxisDepthMm;
            if ((a >= targetC && b <= targetC) || (a <= targetC && b >= targetC))
                return Lerp(pts[i], pts[i + 1], Fraction(a, b, targetC));
        }
        return pts.MinBy(p => Math.Abs(p.NeutralAxisDepthMm - targetC));
    }

    private static InteractionPoint? InterpolateAtPn(IReadOnlyList<InteractionPoint> pts, double target)
    {
        for (int i = 0; i < pts.Count - 1; i++)
        {
            double a = pts[i].Pn, b = pts[i + 1].Pn;
            if ((a >= target && b <= target) || (a <= target && b >= target))
                return Lerp(pts[i], pts[i + 1], Fraction(a, b, target));
        }
        return pts.MinBy(p => Math.Abs(p.Pn - target));
    }

    private static double Fraction(double a, double b, double target)
    {
        double d = b - a;
        return Math.Abs(d) < 1e-12 ? 0.0 : Math.Clamp((target - a) / d, 0, 1);
    }

    private static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t)
        => new(a.DepthIndex, a.AngleIndex,
               Lin(a.ThetaDegrees,         b.ThetaDegrees,         t),
               Lin(a.NeutralAxisDepthMm,    b.NeutralAxisDepthMm,    t),
               Lin(a.Pn,                    b.Pn,                    t),
               Lin(a.Mnx,                   b.Mnx,                   t),
               Lin(a.Mny,                   b.Mny,                   t),
               Lin(a.Phi,                   b.Phi,                   t),
               Lin(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, t),
               Lin(a.ConcretePn,            b.ConcretePn,            t),
               Lin(a.SteelPn,               b.SteelPn,               t),
               Lin(a.ConcreteMnx,           b.ConcreteMnx,           t),
               Lin(a.ConcreteMny,           b.ConcreteMny,           t),
               Lin(a.SteelMnx,              b.SteelMnx,              t),
               Lin(a.SteelMny,              b.SteelMny,              t),
               Lin(a.MaxConcreteStrain,     b.MaxConcreteStrain,     t),
               Lin(a.MinConcreteStrain,     b.MinConcreteStrain,     t),
               Lin(a.MaxSteelStrain,        b.MaxSteelStrain,        t),
               Lin(a.MinSteelStrain,        b.MinSteelStrain,        t),
               string.IsNullOrWhiteSpace(a.StateLabel) ? b.StateLabel : a.StateLabel);

    private static double Lin(double a, double b, double t) => a + (b - a) * t;
}

public sealed record SpecialCapacityEntry(
    string Label,
    int AngleIndex,
    double ThetaDegrees,
    InteractionPoint Source);
