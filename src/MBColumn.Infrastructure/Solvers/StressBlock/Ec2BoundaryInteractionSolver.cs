using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using System.Numerics;

namespace MBColumn.Infrastructure.Solvers.StressBlock;

public sealed class Ec2BoundaryInteractionSolver(IDesignCodeService code) : IInteractionSolver
{
    private double GammaC => 1.50;
    private double GammaS => 1.15;


    public double AngleStepDegrees { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = (int)(360.0 / AngleStepDegrees);
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);
        for (int d = 0; d < NeutralAxisSamples - 1; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, d, NeutralAxisSamples - 1, a * AngleStepDegrees, a));
            }
        }
        for (int a = 0; a < angleCount; a++)
        {
            points.Add(EvaluatePureCompression(section, concrete, steel, NeutralAxisSamples - 1, a, a * AngleStepDegrees));
        }
        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        int depthIndex, int sweepSamples, double angleDegrees, int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        double w = section.WidthMm;
        double h = section.HeightMm;
        double dMax = GetProjectedDepth(w, h, nx, ny);
        double cMax = 3.0 * System.Math.Max(w, h);
        double c = 5.0 + depthIndex * (cMax - 5.0) / (sweepSamples - 1);

        double ecu = code.ConcreteUltimateStrain(concrete.FcMpa);
        double epsC2 = code.ConcretePeakStrain(concrete.FcMpa);
        double n = code.ConcreteParabolicExponent(concrete.FcMpa);

        double xC = 2.0 * dMax * (1.0 - epsC2 / ecu); 
        double epsilonTop = c <= 2.0 * dMax ? ecu : (c * epsC2) / (c - xC);

        double fcd = code.AlphaCc * concrete.FcMpa / GammaC;
        double fyd = steel.FyMpa / GammaS;

        var results = IntegrateConcrete(w, h, nx, ny, dMax, c, epsilonTop, fcd, epsC2, n);

        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        double maxTension = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double distFromCompFace = dMax - (bar.XMm * nx + bar.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            if (strain < 0) maxTension = System.Math.Max(maxTension, -strain);
            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double dispStress = GetConcreteStress(strain, fcd, epsC2, n);
            double force = (stress - dispStress) * bar.AreaMm2;
            steelN += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, results.N + steelN, results.Mx + steelMx, results.My + steelMy, 1.0,
            maxTension, results.N, steelN, results.Mx, results.My, steelMx, steelMy,
            epsilonTop, 0, 0, 0, "Exact Boundary Integration");
    }

    private static (double N, double Mx, double My) IntegrateConcrete(
        double w, double h, double nx, double ny, double dMax, double c, double epsTop, double fcd, double epsC2, double n)
    {
        // 1. New coordinate system (x', y') where y' is along the neutral axis normal (nx, ny)
        // Transformation: y' = x*nx + y*ny, x' = x*ny - y*nx (Rotation by -theta + 90)
        var poly = GetSectionPolygon(w, h);
        var rotatedPoly = poly.Select(p => new Vector2((float)(p.X * ny - p.Y * nx), (float)(p.X * nx + p.Y * ny))).ToList();

        double yTop = dMax;
        double yNA = dMax - c;
        var compressedPoly = ClipHorizontal(rotatedPoly, yNA);
        if (compressedPoly.Count < 3) return (0, 0, 0);

        double yTrans = yTop - c * (epsC2 / epsTop);
        var slices = compressedPoly.Select(p => (double)p.Y).Concat(new[] { yNA, yTop, yTrans })
                                   .Where(y => y >= yNA && y <= yTop)
                                   .Distinct().OrderBy(y => y).ToList();

        double totalN = 0, totalMxPrime = 0, totalMyPrime = 0;
        for (int i = 0; i < slices.Count - 1; i++)
        {
            double y0 = slices[i], y1 = slices[i + 1];
            if (System.Math.Abs(y1 - y0) < 1e-7) continue;

            var (w0, xc0) = GetPolygonSlice(compressedPoly, y0);
            var (w1, xc1) = GetPolygonSlice(compressedPoly, y1);

            var simpson = IntegrateSimpson(y0, y1, y => {
                double uStrain = epsTop * (c - (yTop - y)) / c;
                double stress = GetConcreteStress(uStrain, fcd, epsC2, n);
                double width = w0 + (w1 - w0) * (y - y0) / (y1 - y0);
                double xc = xc0 + (xc1 - xc0) * (y - y0) / (y1 - y0);
                return (stress * width, stress * width * xc, stress * width * y);
            });
            totalN += simpson.N;
            totalMxPrime += simpson.Mx; // integral of stress * width * x'
            totalMyPrime += simpson.My; // integral of stress * width * y'
        }

        // 2. Rotate back to global Mx, My
        // x = x'*ny + y'*nx
        // y = -x'*nx + y'*ny
        double My = totalMxPrime * ny + totalMyPrime * nx;
        double Mx = -totalMxPrime * nx + totalMyPrime * ny;
        return (totalN, Mx, My);
    }

    private static (double N, double Mx, double My) IntegrateSimpson(double y0, double y1, System.Func<double, (double N, double Mx, double My)> func)
    {
        var v0 = func(y0);
        var v1 = func((y0 + y1) / 2.0);
        var v2 = func(y1);
        double h = (y1 - y0) / 6.0;
        return (h * (v0.N + 4 * v1.N + v2.N), h * (v0.Mx + 4 * v1.Mx + v2.Mx), h * (v0.My + 4 * v1.My + v2.My));
    }

    private static (double Width, double XCenter) GetPolygonSlice(List<Vector2> poly, double y)
    {
        var intersections = new List<double>();
        for (int i = 0; i < poly.Count; i++)
        {
            var p1 = poly[i]; var p2 = poly[(i + 1) % poly.Count];
            if ((p1.Y <= y && p2.Y > y) || (p2.Y <= y && p1.Y > y))
                intersections.Add(p1.X + (y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X));
            else if (System.Math.Abs(p1.Y - y) < 1e-9) intersections.Add(p1.X);
        }
        if (intersections.Count < 2) return (0, 0);
        double xMin = intersections.Min(), xMax = intersections.Max();
        return (xMax - xMin, (xMax + xMin) / 2.0);
    }

    private static List<Vector2> ClipHorizontal(List<Vector2> poly, double yMin)
    {
        var result = new List<Vector2>();
        for (int i = 0; i < poly.Count; i++)
        {
            var p1 = poly[i]; var p2 = poly[(i + 1) % poly.Count];
            if (p1.Y >= yMin) {
                if (p2.Y >= yMin) result.Add(p2);
                else result.Add(new Vector2((float)(p1.X + (yMin - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X)), (float)yMin));
            } else if (p2.Y >= yMin) {
                result.Add(new Vector2((float)(p1.X + (yMin - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X)), (float)yMin));
                result.Add(p2);
            }
        }
        return result;
    }

    private static double GetConcreteStress(double strain, double fcd, double epsC2, double n)
    {
        if (strain <= 0) return 0;
        if (strain >= epsC2) return fcd;
        return fcd * (1.0 - System.Math.Pow(1.0 - strain / epsC2, n));
    }

    private InteractionPoint EvaluatePureCompression(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        int depthIndex, int angleIndex, double angleDegrees)
    {
        double epsC2 = code.ConcretePeakStrain(concrete.FcMpa);
        double fcd = code.AlphaCc * concrete.FcMpa / GammaC;
        double fyd = steel.FyMpa / GammaS;
        double sStress = System.Math.Min(steel.EsMpa * epsC2, fyd);
        
        double area = section.WidthMm * section.HeightMm;
        double nC = fcd * area;
        
        // Correct theory: moments at pure compression (uniform strain EpsilonC2)
        // are not necessarily zero if rebar or section is asymmetric about geometric centroid.
        double mxC = 0; // For rectangular section, concrete centroid is 0,0
        double myC = 0;
        
        double nS = 0, mxS = 0, myS = 0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double force = (sStress - fcd) * bar.AreaMm2;
            nS += force;
            mxS += force * bar.YMm;
            myS += force * bar.XMm;
        }

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, 1e9, nC + nS, mxC + mxS, myC + myS, 1.0,
            0, nC, nS, mxC, myC, mxS, myS,
            epsC2, epsC2, epsC2, epsC2, "Pure Compression");
    }

    private static double GetProjectedDepth(double w, double h, double nx, double ny)
    {
        return System.Math.Max(System.Math.Abs(0.5 * w * nx + 0.5 * h * ny), System.Math.Abs(0.5 * w * nx - 0.5 * h * ny));
    }

    private static List<Vector2> GetSectionPolygon(double w, double h)
    {
        return new List<Vector2> { new Vector2((float)(-0.5 * w), (float)(-0.5 * h)), new Vector2((float)( 0.5 * w), (float)(-0.5 * h)), new Vector2((float)( 0.5 * w), (float)( 0.5 * h)), new Vector2((float)(-0.5 * w), (float)( 0.5 * h)) };
    }
}
