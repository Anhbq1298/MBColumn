using System;
using System.Collections.Generic;
using System.Linq;
using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Solvers;

namespace MBColumn.Tests;

public static class EurocodeValidation
{
    public static void Run()
    {
        Console.WriteLine("\n--- Eurocode 2 PMM Solver Validation ---");
        
        // 1. Setup Section (600x800, 16H20)
        // Bars are arranged in a 5x5 grid minus the 3x3 center
        // Using 40mm cover to center as requested: 300-40=260, 400-40=360
        var bars = new List<Rebar>();
        double[] xs = { -260, -130, 0, 130, 260 };
        double[] ys = { -360, -180, 0, 180, 360 };
        foreach (var x in xs)
        {
            foreach (var y in ys)
            {
                if (Math.Abs(x) == 260 || Math.Abs(y) == 360)
                {
                    bars.Add(new Rebar("H20", 20, 314.16, x, y));
                }
            }
        }
        var section = new RectangularSection(600, 800, new RebarLayout("Custom", "H20", 40, bars));
        var concrete = new ConcreteMaterial("C32/40", 32);
        var steel = new SteelMaterial("B500B", 500, 200000);
        
        // Use Ec2DesignCodeService which should now be routed to EcPmmFiberAnalyticSolver
        var ec2Code = new Ec2DesignCodeService();
        var solver = new EcPmmFiberAnalyticSolver(ec2Code);
        
        // 2. Solve for full surface
        var surface = solver.Solve(section, concrete, steel);
        
        // 3. Extract Theta = 90 points (Strong axis bending, depth=800)
        var theta90Points = surface.Points.Where(p => Math.Abs(p.ThetaDegrees - 90) < 0.1).ToList();
        Console.WriteLine($"Found {theta90Points.Count} points for Theta=90");
        for (int i = 0; i < Math.Min(5, theta90Points.Count); i++)
        {
            var p = theta90Points[i];
            Console.WriteLine($"Pt {i}: P={p.Pn/1000:F1} kN, Mx={p.Mnx/1e6:F1} kNm, My={p.Mny/1e6:F1} kNm");
        }
        
        // 4. Benchmark data from Word file (Theta 0 block)
        // Note: P is given as negative (compression) in S-CONCRETE, converted to positive for MBColumn.
        var benchmark = new[]
        {
            new { P = 0.0, M = 753.5 },
            new { P = 1047.7, M = 1018.9 },
            new { P = 2095.4, M = 1190.8 },
            new { P = 3143.1, M = 1277.7 },
            new { P = 4190.9, M = 1244.6 },
            new { P = 5238.6, M = 1137.0 },
            new { P = 6286.3, M = 990.5 },
            new { P = 7334.0, M = 780.2 },
            new { P = 8381.7, M = 518.2 },
            new { P = 9429.4, M = 244.9 }
        };

        Console.WriteLine($"{"Ref P (kN)":>10} | {"Ref M (kNm)":>12} | {"Calc M (kNm)":>12} | {"Error %":>10} | Status");
        Console.WriteLine(new string('-', 70));

        bool allPassed = true;
        foreach (var b in benchmark)
        {
            // Theta 90 in solver is Mx
            double calcM = InterpolateMWithDebug(theta90Points, b.P);
            double error = Math.Abs(calcM - b.M) / Math.Max(b.M, 1.0) * 100.0;
            string status = error < 5.0 ? "PASS" : "FAIL";
            if (error >= 5.0) allPassed = false;
            Console.WriteLine($"{b.P,10:F1} | {b.M,12:F1} | {calcM,12:F1} | {error,10:F2}% | {status}");
        }
        
        if (allPassed)
            Console.WriteLine("\nOverall Result: PASS (All points within 5% tolerance)");
        else
            Console.WriteLine("\nOverall Result: FAIL (Some points exceed 5% tolerance)");
    }

    private static double InterpolateMWithDebug(List<InteractionPoint> points, double targetPkN)
    {
        double targetP = targetPkN * 1000.0;
        var sorted = points.OrderBy(p => p.Pn).ToList();
        for (int i = 0; i < sorted.Count - 1; i++)
        {
            var p1 = sorted[i];
            var p2 = sorted[i+1];
            // Our solver uses positive for compression.
            // Search for targetP = targetPkN * 1000.0
            double internalTargetP = targetPkN * 1000.0;
            
            if ((p1.Pn <= internalTargetP && p2.Pn >= internalTargetP) || 
                (p1.Pn >= internalTargetP && p2.Pn <= internalTargetP))
            {
                double t = Math.Abs(p2.Pn - p1.Pn) < 1.0 ? 0 : (internalTargetP - p1.Pn) / (p2.Pn - p1.Pn);
                return (Math.Abs(p1.Mnx) * (1-t) + Math.Abs(p2.Mnx) * t) / 1e6;
            }
        }
        // Fallback to closest
        var closest = sorted.OrderBy(p => Math.Abs(p.Pn - (targetPkN * 1000.0))).First();
        return Math.Abs(closest.Mnx) / 1e6;
    }
}
