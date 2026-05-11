using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using System.Numerics;

namespace MBColumn.Infrastructure.Solvers;

/// <summary>
/// EC2 Interaction Solver using Boundary Integration (Green's Theorem).
/// Provides exact results for Bi-linear concrete models without fiber mesh artifacts.
/// </summary>
public sealed class Ec2BoundaryInteractionSolver : IInteractionSolver
{
    private const double AlphaCc    = 0.85;
    private const double GammaC     = 1.50;
    private const double GammaS     = 1.15;
    private const double EpsilonC3  = 0.00175;
    private const double EpsilonCu3 = 0.0035;

    public int AngleStepDegrees { get; init; } = 5;
    public int NeutralAxisSamples { get; init; } = 100;

    public InteractionSurface Solve(RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        int angleCount = 360 / AngleStepDegrees;
        var points = new List<InteractionPoint>(angleCount * NeutralAxisSamples);

        for (int d = 0; d < NeutralAxisSamples - 1; d++)
        {
            for (int a = 0; a < angleCount; a++)
            {
                points.Add(Evaluate(section, concrete, steel, d, NeutralAxisSamples - 1, a * AngleStepDegrees, a));
            }
        }

        // Pure compression
        for (int a = 0; a < angleCount; a++)
        {
            points.Add(EvaluatePureCompression(section, concrete, steel, NeutralAxisSamples - 1, a, a * AngleStepDegrees));
        }

        return new InteractionSurface(NeutralAxisSamples, angleCount, points);
    }

    private InteractionPoint Evaluate(
        RectangularSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        int depthIndex,
        int sweepSamples,
        double angleDegrees,
        int angleIndex)
    {
        double theta = angleDegrees * System.Math.PI / 180.0;
        double nx = System.Math.Cos(theta);
        double ny = System.Math.Sin(theta);
        
        double w = section.WidthMm;
        double h = section.HeightMm;
        double dMax = GetProjectedDepth(w, h, nx, ny);
        double hTheta = 2.0 * dMax;

        double cMax = 3.0 * System.Math.Max(w, h);
        double c = 5.0 + depthIndex * (cMax - 5.0) / (sweepSamples - 1);

        // Pivot logic (Standard EC2 Bi-linear)
        double xC = hTheta * (1.0 - EpsilonC3 / EpsilonCu3); 
        double epsilonTop = c <= hTheta ? EpsilonCu3 : (c * EpsilonC3) / (c - xC);

        double fcd = AlphaCc * concrete.FcMpa / GammaC;
        double fyd = steel.FyMpa / GammaS;

        // 1. Concrete Integration via Boundary
        // Get polygon of section
        var poly = GetSectionPolygon(w, h);
        // Transform poly so compression face is at some coordinate? 
        // Better: work in local coordinates but project strains.
        
        var results = IntegrateConcrete(poly, nx, ny, dMax, c, epsilonTop, fcd);

        // 2. Steel (Still discrete, but accurate)
        double steelN = 0.0, steelMx = 0.0, steelMy = 0.0;
        double maxTension = 0.0;
        foreach (var bar in section.RebarLayout.Bars)
        {
            double distFromCompFace = dMax - (bar.XMm * nx + bar.YMm * ny);
            double strain = epsilonTop * (c - distFromCompFace) / c;
            if (strain < 0) maxTension = System.Math.Max(maxTension, -strain);

            double stress = System.Math.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double dispStress = GetConcreteStress(strain, fcd);
            
            double force = (stress - dispStress) * bar.AreaMm2;
            steelN += force;
            steelMx += force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        double axial = results.N + steelN;
        double mx = results.Mx + steelMx;
        double my = results.My + steelMy;

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, c, axial, mx, my, 1.0,
            maxTension, results.N, steelN, results.Mx, results.My, steelMx, steelMy,
            epsilonTop, 0, 0, 0, "Boundary Integration");
    }

    private static (double N, double Mx, double My) IntegrateConcrete(
        List<Vector2> poly, double nx, double ny, double dMax, double c, double epsTop, double fcd)
    {
        // Line equation: nx*x + ny*y = dMax - c  (Neutral axis)
        // We clip the polygon to find the compressed region.
        var compressedPoly = ClipPolygon(poly, nx, ny, dMax - c);
        if (compressedPoly.Count < 3) return (0, 0, 0);

        // For Bi-linear, we might need to clip again at epsilon_c3 transition
        double cLinear = c * (EpsilonC3 / epsTop);
        double dLinear = dMax - c + cLinear;

        var constantPoly = ClipPolygon(compressedPoly, nx, ny, dLinear);
        var linearPoly = ClipPolygon(compressedPoly, -nx, -ny, -dLinear);

        // 1. Constant Part: N = fcd * Area
        var statsConst = GetPolygonStats(constantPoly);
        double nC = fcd * statsConst.Area;
        double mxC = fcd * statsConst.Qy;
        double myC = fcd * statsConst.Qx;

        // 2. Linear Part: stress = fcd * (strain / epsC3)
        // strain = epsTop * (c - (dMax - proj)) / c = (epsTop/c) * (proj - (dMax - c))
        // stress = (fcd / epsC3) * (epsTop/c) * (nx*x + ny*y - (dMax - c))
        // stress = k * (nx*x + ny*y - C0) where C0 = dMax - c
        if (linearPoly.Count >= 3)
        {
            double k = (fcd / EpsilonC3) * (epsTop / c);
            double C0 = dMax - c;
            var sL = GetPolygonStats(linearPoly);
            
            // N = k * (nx*Qx + ny*Qy - C0*Area)
            double nL = k * (nx * sL.Qx + ny * sL.Qy - C0 * sL.Area);
            // Mx = k * (nx*Ixy + ny*Iy2 - C0*Qy)
            double mxL = k * (nx * sL.Ixy + ny * sL.Iy2 - C0 * sL.Qy);
            // My = k * (nx*Ix2 + ny*Ixy - C0*Qx)
            double myL = k * (nx * sL.Ix2 + ny * sL.Ixy - C0 * sL.Qx);

            return (nC + nL, mxC + mxL, myC + myL);
        }

        return (nC, mxC, myC);
    }

    private static double GetConcreteStress(double strain, double fcd)
    {
        if (strain <= 0) return 0;
        return strain >= EpsilonC3 ? fcd : fcd * (strain / EpsilonC3);
    }

    private InteractionPoint EvaluatePureCompression(
        RectangularSection section, ConcreteMaterial concrete, SteelMaterial steel,
        int depthIndex, int angleIndex, double angleDegrees)
    {
        double fcd = AlphaCc * concrete.FcMpa / GammaC;
        double fyd = steel.FyMpa / GammaS;
        double sStress = System.Math.Min(steel.EsMpa * EpsilonC3, fyd);
        
        double area = section.WidthMm * section.HeightMm;
        double nC = fcd * area;
        double nS = (sStress - fcd) * section.RebarLayout.Bars.Sum(b => b.AreaMm2);

        return new InteractionPoint(
            depthIndex, angleIndex, angleDegrees, 1e9, nC + nS, 0, 0, 1, 0,
            nC, nS, 0, 0, 0, 0, EpsilonC3, EpsilonC3, EpsilonC3, EpsilonC3, "Pure Compression");
    }

    private static double GetProjectedDepth(double w, double h, double nx, double ny)
    {
        return System.Math.Max(
            System.Math.Abs(0.5 * w * nx + 0.5 * h * ny),
            System.Math.Abs(0.5 * w * nx - 0.5 * h * ny));
    }

    private static List<Vector2> GetSectionPolygon(double w, double h)
    {
        return new List<Vector2>
        {
            new Vector2((float)(-0.5 * w), (float)(-0.5 * h)),
            new Vector2((float)( 0.5 * w), (float)(-0.5 * h)),
            new Vector2((float)( 0.5 * w), (float)( 0.5 * h)),
            new Vector2((float)(-0.5 * w), (float)( 0.5 * h))
        };
    }

    private static List<Vector2> ClipPolygon(List<Vector2> poly, double nx, double ny, double d)
    {
        // Clips polygon to keep points where nx*x + ny*y >= d
        var result = new List<Vector2>();
        for (int i = 0; i < poly.Count; i++)
        {
            var p1 = poly[i];
            var p2 = poly[(i + 1) % poly.Count];
            double val1 = nx * p1.X + ny * p1.Y - d;
            double val2 = nx * p2.X + ny * p2.Y - d;

            if (val1 >= 0)
            {
                if (val2 >= 0) result.Add(p2);
                else result.Add(Intersect(p1, p2, val1, val2));
            }
            else if (val2 >= 0)
            {
                result.Add(Intersect(p1, p2, val1, val2));
                result.Add(p2);
            }
        }
        return result;
    }

    private static Vector2 Intersect(Vector2 p1, Vector2 p2, double v1, double v2)
    {
        double t = v1 / (v1 - v2);
        return p1 + (float)t * (p2 - p1);
    }

    private record PolygonStats(double Area, double Qx, double Qy, double Ix2, double Iy2, double Ixy);

    private static PolygonStats GetPolygonStats(List<Vector2> poly)
    {
        double area = 0, qx = 0, qy = 0, ix2 = 0, iy2 = 0, ixy = 0;
        for (int i = 0; i < poly.Count; i++)
        {
            var p1 = poly[i];
            var p2 = poly[(i + 1) % poly.Count];
            double common = p1.X * p2.Y - p2.X * p1.Y;
            
            area += common;
            qx += common * (p1.X + p2.X);
            qy += common * (p1.Y + p2.Y);
            ix2 += common * (p1.X * p1.X + p1.X * p2.X + p2.X * p2.X);
            iy2 += common * (p1.Y * p1.Y + p1.Y * p2.Y + p2.Y * p2.Y);
            ixy += common * (2 * p1.X * p1.Y + p1.X * p2.Y + p2.X * p1.Y + 2 * p2.X * p2.Y);
        }
        return new PolygonStats(
            0.5 * area, 
            qx / 6.0, 
            qy / 6.0, 
            ix2 / 12.0, 
            iy2 / 12.0, 
            ixy / 24.0);
    }
}
