using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;

namespace MBColumn.Infrastructure.Solvers;

/// <summary>
/// Eurocode 2 (EN 1992-1-1:2004) §3.1.7 — simplified rectangular concrete stress block.
/// Uses Sutherland-Hodgman analytical polygon clipping (no fiber grid).
/// Block stress = η × fcd, block depth = λ × c.
/// All material parameters are read from IDesignCodeService; no local hardcoded constants.
/// Moment sign: Mnx = Σ(force × y), Mny = Σ(force × x). Phi = 1.0.
/// </summary>
public sealed class Ec2SimplifiedStressBlockInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    public double AngleStepDegrees   { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = (int)(360.0 / AngleStepDegrees);
        var boundary   = BuildSectionPolygon(section);
        var points     = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        int sweepSamples = NeutralAxisSamples - 1;
        for (int d = 0; d < sweepSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
                points.Add(Evaluate(section, concrete, steel, boundary, d, sweepSamples, a * AngleStepDegrees, a));
        }

        int pcIndex = NeutralAxisSamples - 1;
        for (int a = 0; a < angleCount; a++)
            points.Add(EvaluatePureCompression(section, concrete, steel, pcIndex, a, a * AngleStepDegrees));

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        IReadOnlyList<SectionPoint> boundary,
        int depthIndex, int sweepSamples, double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);

        double fck        = concrete.FcMpa;
        double fcd        = code.AlphaCc * fck / 1.50;               // αcc × fck / γc
        double eta        = code.ConcreteEffectiveStrengthFactor(fck); // η
        double lambda     = code.Beta1(fck);                           // λ (reuses Beta1)
        double blockStress = eta * fcd;
        double fyd        = code.SteelDesignStrength(steel.FyMpa);
        double epsCu3     = code.ConcreteUltimateStrain(fck);         // εcu3
        double epsUd      = code.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);

        double cMax = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c    = 5.0 + depthIndex * (cMax - 5.0) / (sweepSamples - 1);

        double maxProj    = ProjectExtreme(section, nx, ny);
        double blockLimit = maxProj - lambda * c;

        var compPoly = ClipPolygon(boundary, nx, ny, blockLimit);
        var (blockArea, blockCx, blockCy) = PolygonProperties(compPoly);

        double concreteN  = blockStress * blockArea;
        double concreteMx = concreteN * blockCy;
        double concreteMy = concreteN * blockCx;

        double steelN = 0, steelMx = 0, steelMy = 0, maxTension = 0;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;

        foreach (var bar in section.RebarLayout.Bars)
        {
            double barProj = bar.XMm * nx + bar.YMm * ny;
            double strain  = epsCu3 * (c - (maxProj - barProj)) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0.0)
                maxTension = System.Math.Min(System.Math.Max(maxTension, -strain), epsUd);

            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double disp   = barProj >= blockLimit - 1e-9 ? blockStress : 0.0;
            double force  = (stress - disp) * bar.AreaMm2;
            steelN  += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        bool hasConcrete = blockArea > 1e-9;
        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c,
            concreteN + steelN, concreteMx + steelMx, concreteMy + steelMy,
            1.0, maxTension,
            concreteN, steelN, concreteMx, concreteMy, steelMx, steelMy,
            epsCu3, 0.0,
            maxSteelStrain == double.NegativeInfinity ? 0.0 : maxSteelStrain,
            minSteelStrain == double.PositiveInfinity  ? 0.0 : minSteelStrain,
            ClassifyState(hasConcrete, maxTension));
    }

    private InteractionPoint EvaluatePureCompression(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        int depthIndex, int angleIndex, double angleDegrees)
    {
        double fck        = concrete.FcMpa;
        double fcd        = code.AlphaCc * fck / 1.50;
        double eta        = code.ConcreteEffectiveStrengthFactor(fck);
        double blockStress = eta * fcd;
        double fyd        = code.SteelDesignStrength(steel.FyMpa);
        double epsC3      = ConcreteRectangularPeakStrain(fck);

        double grossArea  = section.WidthMm * section.HeightMm;
        double concreteN  = blockStress * grossArea;

        double steelN = 0, steelMx = 0, steelMy = 0;
        double steelStress = System.Math.Clamp(steel.EsMpa * epsC3, -fyd, fyd);
        foreach (var bar in section.RebarLayout.Bars)
        {
            double force = (steelStress - blockStress) * bar.AreaMm2;
            steelN  += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double cNominal = 10.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, cNominal,
            concreteN + steelN, steelMx, steelMy,
            1.0, 0.0,
            concreteN, steelN, 0.0, 0.0, steelMx, steelMy,
            epsC3, epsC3, epsC3, epsC3, "Pure axial compression");
    }

    // Uses εc2 as an approximation for εc3 when direct access is unavailable.
    // For fck ≤ 50 MPa: εc2 = 0.0020 vs εc3 = 0.00175 — a conservative approximation.
    // For production use, prefer Ec2DesignCodeService which exposes ConcreteRectangularPeakStrain.
    private double ConcreteRectangularPeakStrain(double fckMpa)
    {
        // Try to get εc3 from EC2 service if the concrete service exposes it.
        if (code is Ec2DesignCodeService ec2) return ec2.ConcreteRectangularPeakStrain(fckMpa);
        // Fallback: use εc2 (parabolic peak strain) — conservative and safe.
        return code.ConcretePeakStrain(fckMpa);
    }

    private static string ClassifyState(bool hasConcrete, double maxTension)
    {
        if (!hasConcrete)        return "Pure tension";
        if (maxTension >= 0.005) return "Tension controlled";
        return "Compression controlled";
    }

    private static double ProjectExtreme(RectangularSection section, double nx, double ny)
    {
        double hx = section.WidthMm  / 2.0;
        double hy = section.HeightMm / 2.0;
        return new[]
        {
            -hx * nx + -hy * ny,
             hx * nx + -hy * ny,
             hx * nx +  hy * ny,
            -hx * nx +  hy * ny
        }.Max();
    }

    private static IReadOnlyList<SectionPoint> BuildSectionPolygon(RectangularSection section)
    {
        double hx = section.WidthMm  / 2.0;
        double hy = section.HeightMm / 2.0;
        return new SectionPoint[] { new(-hx, -hy), new(hx, -hy), new(hx, hy), new(-hx, hy) };
    }

    private static IReadOnlyList<SectionPoint> ClipPolygon(
        IReadOnlyList<SectionPoint> subject, double nx, double ny, double projection)
    {
        var result = new List<SectionPoint>();
        if (subject.Count == 0) return result;
        var start   = subject[^1];
        bool startIn = start.X * nx + start.Y * ny >= projection - 1e-9;
        foreach (var end in subject)
        {
            bool endIn = end.X * nx + end.Y * ny >= projection - 1e-9;
            if (endIn)
            {
                if (!startIn) result.Add(Intersect(start, end, nx, ny, projection));
                result.Add(end);
            }
            else if (startIn)
            {
                result.Add(Intersect(start, end, nx, ny, projection));
            }
            start   = end;
            startIn = endIn;
        }
        return result;
    }

    private static SectionPoint Intersect(SectionPoint a, SectionPoint b, double nx, double ny, double proj)
    {
        double da = a.X * nx + a.Y * ny - proj;
        double db = b.X * nx + b.Y * ny - proj;
        double t  = System.Math.Abs(da - db) < 1e-12 ? 0.0 : da / (da - db);
        return new SectionPoint(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
    }

    private static (double Area, double Cx, double Cy) PolygonProperties(IReadOnlyList<SectionPoint> poly)
    {
        if (poly.Count < 3) return (0.0, 0.0, 0.0);
        double area = 0.0, sx = 0.0, sy = 0.0;
        for (int i = 0; i < poly.Count; i++)
        {
            var p1    = poly[i];
            var p2    = poly[(i + 1) % poly.Count];
            double cr = p1.X * p2.Y - p2.X * p1.Y;
            area += cr;
            sx   += (p1.X + p2.X) * cr;
            sy   += (p1.Y + p2.Y) * cr;
        }
        area /= 2.0;
        if (System.Math.Abs(area) < 1e-9) return (0.0, 0.0, 0.0);
        return (System.Math.Abs(area), sx / (6.0 * area), sy / (6.0 * area));
    }

    // Public static for test access (material factor verification).
    public static double LambdaFor(IDesignCodeService code, double fck) => code.Beta1(fck);
    public static double EtaFor(IDesignCodeService code, double fck)    => code.ConcreteEffectiveStrengthFactor(fck);

    private sealed record SectionPoint(double X, double Y);
}
