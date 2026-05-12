using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Solvers;

/// <summary>
/// Eurocode 2 (EN 1992-1-1:2004) §3.1.7 — simplified rectangular concrete stress block.
/// Uses analytical polygon clipping instead of fiber integration.
/// Block stress = eta × fcd, block depth = lambda × c.
/// For fck ≤ 50 MPa: lambda = 0.8, eta = 1.0, epsilon_cu3 = 0.0035, epsilon_c3 = 0.00175.
/// Material factors: alpha_cc = 0.80 (UK NA), gamma_c = 1.50, gamma_s = 1.15 (Table 2.1N).
/// Moment sign convention follows Ec2FiberInteractionSolver: Mnx = Σ(force × y), Mny = Σ(force × x).
/// Phi = 1.0 (material partial factors carry the reduction; no member-level phi).
/// </summary>
public sealed class Ec2SimplifiedStressBlockInteractionSolver : IInteractionSolver
{
    private const double AlphaCc    = 0.80;    // UK National Annex (clause 3.1.6)
    private const double GammaC     = 1.50;    // EC2 Table 2.1N
    private const double GammaS     = 1.15;    // EC2 Table 2.1N
    private const double EpsilonCu3 = 0.0035;  // EC2 Table 3.1 — strain at compression face
    private const double EpsilonC3  = 0.00175; // EC2 Table 3.1 — onset of uniform plateau

    public int AngleStepDegrees   { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var boundary = BuildSectionPolygon(section);
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        int sweepSamples = NeutralAxisSamples - 1;
        for (int d = 0; d < sweepSamples; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, boundary, d, sweepSamples, a * AngleStepDegrees, a));
            }
        }

        // Pure compression pole: uniform strain epsilon_c3 across the full section.
        int pcIndex = NeutralAxisSamples - 1;
        for (int a = 0; a < angleCount; a++)
        {
            points.Add(EvaluatePureCompression(section, concrete, steel, pcIndex, a, a * AngleStepDegrees));
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private static InteractionPoint Evaluate(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IReadOnlyList<SectionPoint> boundary,
        int depthIndex,
        int sweepSamples,
        double angleDegrees,
        int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);

        double fck = concrete.FcMpa;
        double fcd = AlphaCc * fck / GammaC;
        double fyd = steel.FyMpa / GammaS;
        double lambda = Lambda(fck);
        double eta    = Eta(fck);
        double blockStress = eta * fcd;   // Uniform stress in the rectangular block

        // Linear sweep: c from 5 mm (near pure tension) to 3 × section depth (near pure compression).
        double cMax = 3.0 * System.Math.Max(section.WidthMm, section.HeightMm);
        double c    = 5.0 + depthIndex * (cMax - 5.0) / (sweepSamples - 1);

        double maxProj        = ProjectExtreme(section, nx, ny);
        double blockLimit     = maxProj - lambda * c;   // Compression face to block bottom

        // Clip section to the rectangular stress block region.
        var compPoly = ClipPolygon(boundary, nx, ny, blockLimit);
        var (blockArea, blockCx, blockCy) = PolygonProperties(compPoly);

        double concreteN  = blockStress * blockArea;
        double concreteMx = concreteN * blockCy;   // Σ force × y (EC2 sign convention)
        double concreteMy = concreteN * blockCx;   // Σ force × x

        double steelN = 0, steelMx = 0, steelMy = 0, maxTension = 0;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;

        foreach (var bar in section.RebarLayout.Bars)
        {
            double barProj = bar.XMm * nx + bar.YMm * ny;
            // Linear strain profile from compression face at epsilonCu3.
            double strain = EpsilonCu3 * (c - (maxProj - barProj)) / c;
            maxSteelStrain = System.Math.Max(maxSteelStrain, strain);
            minSteelStrain = System.Math.Min(minSteelStrain, strain);
            if (strain < 0.0) maxTension = System.Math.Max(maxTension, -strain);

            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            // Displaced concrete: apply only where bar centroid is inside the stress block.
            double disp  = barProj >= blockLimit - 1e-9 ? blockStress : 0.0;
            double force = (stress - disp) * bar.AreaMm2;
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
            EpsilonCu3, 0.0,
            maxSteelStrain == double.NegativeInfinity ? 0.0 : maxSteelStrain,
            minSteelStrain == double.PositiveInfinity  ? 0.0 : minSteelStrain,
            ClassifyState(hasConcrete, maxTension));
    }

    private static InteractionPoint EvaluatePureCompression(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        int depthIndex,
        int angleIndex,
        double angleDegrees)
    {
        double fck = concrete.FcMpa;
        double fcd = AlphaCc * fck / GammaC;
        double fyd = steel.FyMpa / GammaS;
        double eta = Eta(fck);
        double blockStress = eta * fcd;

        // Full gross section in uniform compression.
        double grossArea = section.WidthMm * section.HeightMm;
        double concreteN = blockStress * grossArea;
        // Symmetric rectangular section: concrete centroid is at (0, 0).

        double steelN = 0, steelMx = 0, steelMy = 0;
        double steelStress = System.Math.Clamp(steel.EsMpa * EpsilonC3, -fyd, fyd);
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
            EpsilonC3, EpsilonC3, EpsilonC3, EpsilonC3,
            "Pure axial compression");
    }

    // EC2 3.1.7(3): depth factor for simplified rectangular block.
    // lambda = 0.8 for fck ≤ 50; decreasing linearly above 50, minimum 0.5.
    public static double Lambda(double fck)
    {
        if (fck <= 50.0) return 0.8;
        return System.Math.Max(0.8 - (fck - 50.0) / 400.0, 0.5);
    }

    // EC2 3.1.7(3): effective strength factor for simplified rectangular block.
    // eta = 1.0 for fck ≤ 50; decreasing linearly above 50, minimum 0.8.
    public static double Eta(double fck)
    {
        if (fck <= 50.0) return 1.0;
        return System.Math.Max(1.0 - (fck - 50.0) / 200.0, 0.8);
    }

    private static string ClassifyState(bool hasConcrete, double maxTension)
    {
        if (!hasConcrete)          return "Pure tension";
        if (maxTension >= 0.005)   return "Tension controlled";
        return "Compression controlled";
    }

    // Maximum projection of the section corners onto the neutral-axis normal direction (nx, ny).
    // This defines the extreme compression fiber distance from the section centroid.
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

    // Counter-clockwise section boundary polygon centred at the section centroid.
    private static IReadOnlyList<SectionPoint> BuildSectionPolygon(RectangularSection section)
    {
        double hx = section.WidthMm  / 2.0;
        double hy = section.HeightMm / 2.0;
        return new SectionPoint[]
        {
            new(-hx, -hy), new(hx, -hy),
            new( hx,  hy), new(-hx,  hy)
        };
    }

    // Sutherland-Hodgman half-plane clip: keep vertices where x*nx + y*ny >= projection.
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

    // Signed area and centroid via the Shoelace / Green's theorem formula.
    // Returns (|area|, centroidX, centroidY). Handles both CW and CCW winding.
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

    private sealed record SectionPoint(double X, double Y);
}
