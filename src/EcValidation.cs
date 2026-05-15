using System;
using System.Collections.Generic;
using System.Linq;
using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Infrastructure.Solvers.Legacy;

namespace MBColumn.Validation;

public static class EcValidation
{
    public static void Run()
    {
        // 1. Setup Section (600x800, 16H20)
        var bars = new List<Rebar>();
        double[] xs = { -250, -125, 0, 125, 250 };
        double[] ys = { -350, -175, 0, 175, 350 };
        foreach (var x in xs)
        {
            foreach (var y in ys)
            {
                if (Math.Abs(x) == 250 || Math.Abs(y) == 350)
                {
                    bars.Add(new Rebar(x, y, 314.16));
                }
            }
        }
        var section = new RectangularSection(600, 800, new RebarLayout(bars));
        var concrete = new ConcreteMaterial("C32/40", 32);
        var steel = new SteelMaterial("B500B", 500, 200000);
        
        var ec2Code = new Ec2DesignCodeService();
        var solver = new EcPmmFiberAnalyticSolver(ec2Code);
        
        // 2. Solve
        var surface = solver.Solve(section, concrete, steel);
        
        // 3. Extract Theta = 0 points
        var theta0Points = surface.Points.Where(p => Math.Abs(p.ThetaDegrees - 0) < 0.1).ToList();
        
        // 4. Benchmark data from Word file (extracted via validate_pmm.py)
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

        Console.WriteLine($"{"Ref P":>10} | {"Ref M":>10} | {"Calc M":>10} | {"Error %":>10} | Status");
        Console.WriteLine(new string('-', 60));

        foreach (var b in benchmark)
        {
            // Find point on our surface with closest P
            // Since our surface is a grid, we interpolate
            double calcM = InterpolateM(theta0Points, b.P);
            double error = Math.Abs(calcM - b.M) / Math.Max(b.M, 1.0) * 100.0;
            string status = error < 5.0 ? "PASS" : "FAIL";
            Console.WriteLine($"{b.P,10:F1} | {b.M,10:F1} | {calcM,10:F1} | {error,10:F2}% | {status}");
        }
    }

    private static double InterpolateM(List<InteractionPoint> points, double targetP)
    {
        // Sort points by P
        var sorted = points.OrderBy(p => p.Pn).ToList();
        for (int i = 0; i < sorted.Count - 1; i++)
        {
            var p1 = sorted[i];
            var p2 = sorted[i+1];
            if (p1.Pn <= targetP && p2.Pn >= targetP)
            {
                double t = (targetP - p1.Pn) / (p2.Pn - p1.Pn);
                // Theta 0 is Mx
                return (p1.Mnx * (1-t) + p2.Mnx * t) / 1e6;
            }
        }
        // Fallback to closest if out of range
        if (targetP <= sorted.First().Pn) return sorted.First().Mnx / 1e6;
        return sorted.Last().Mnx / 1e6;
    }
}
