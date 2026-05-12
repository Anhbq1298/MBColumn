using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Solvers;

namespace MBColumn.Tests;

public static class EurocodeMultiAngleValidation
{
    public static void Run()
    {
        Console.WriteLine("\n--- Eurocode 2 PMM Multi-Angle Validation ---");

        // 1. Load Benchmark Data
        string jsonPath = @"C:\Users\NCPC\OneDrive - Meinhardt Singapore Pte Ltd\_ReverseEngineering\spColumnReversed-Solution\tests\MBColumn.Tests\benchmark_multi_angle.json";
        if (!File.Exists(jsonPath))
        {
            Console.WriteLine("Benchmark JSON not found!");
            return;
        }
        var benchmarkData = JsonSerializer.Deserialize<Dictionary<string, List<BenchmarkPoint>>>(File.ReadAllText(jsonPath));

        // 2. Setup Section (600x800, 16H20, d'=60mm)
        // d' = 60mm -> offsets 240, 340
        var bars = new List<Rebar>();
        double[] xs = { -240, -120, 0, 120, 240 };
        double[] ys = { -340, -170, 0, 170, 340 };
        foreach (var x in xs)
        {
            foreach (var y in ys)
            {
                if (Math.Abs(x) == 240 || Math.Abs(y) == 340)
                {
                    bars.Add(new Rebar("H20", 20, 314.16, x, y));
                }
            }
        }
        var section = new RectangularSection(600, 800, new RebarLayout("Custom", "H20", 40, bars));
        var concrete = new ConcreteMaterial("C32/40", 32);
        var steel = new SteelMaterial("B500B", 500, 200000);
        
        var ec2Code = new Ec2DesignCodeService { AlphaCc = 0.80 };
        var solver = new EcPmmFiberAnalyticSolver(ec2Code) { AngleStepDegrees = 1 };
        
        // 3. Run Solver
        var surface = solver.Solve(section, concrete, steel);

        // 4. Compare Target Angles
        // S-CONCRETE Angles: 0 (Strong), 16, 75, 90 (Weak), 135
        // MBColumn: 90 is Strong, 0 is Weak.
        // Mapping: MBAngle = (90 - SCAngle)
        // SCAngle 0   -> MB 90
        // SCAngle 90  -> MB 0
        // SCAngle 16  -> MB 74
        // SCAngle 75  -> MB 15
        // SCAngle 135 -> MB -45 -> 315
        
        var angleMapping = new Dictionary<int, int>
        {
            { 0, 90 },
            { 16, 74 },
            { 75, 15 },
            { 90, 0 },
            { 135, 315 }
        };

        foreach (var kvp in angleMapping)
        {
            int scAngle = kvp.Key;
            int mbAngle = kvp.Value;
            
            if (!benchmarkData.ContainsKey(scAngle.ToString())) continue;
            
            Console.WriteLine($"\nValidating S-CONCRETE Angle {scAngle} (MB Angle {mbAngle})");
            var refPoints = benchmarkData[scAngle.ToString()];
            var calcPoints = surface.Points.Where(p => Math.Abs(p.ThetaDegrees - mbAngle) < 0.1 || Math.Abs(p.ThetaDegrees - (mbAngle + 360)) < 0.1).ToList();
            
            if (calcPoints.Count == 0)
            {
                // Try finding closest angle if 10 deg step
                double closest = surface.Points.Min(p => Math.Abs(p.ThetaDegrees - mbAngle));
                calcPoints = surface.Points.Where(p => Math.Abs(Math.Abs(p.ThetaDegrees - mbAngle) - closest) < 0.1).ToList();
                Console.WriteLine($"  Note: Using closest solver angle {calcPoints.First().ThetaDegrees}");
            }

            Console.WriteLine($"{"Ref P (kN)",12} | {"Calc P (kN)",12} | {"Ref M (kNm)",12} | {"Calc M (kNm)",12} | {"deltaM",10} | {"Error %",10}");
            Console.WriteLine(new string('-', 90));
            
            int count = 0;
            double sumError = 0;
            foreach (var b in refPoints)
            {
                double targetPkN = b.P;
                double calcM = InterpolateM(calcPoints, targetPkN);
                double deltaM = calcM - b.M;
                double error = Math.Abs(deltaM) / Math.Max(b.M, 1.0) * 100.0;
                sumError += error;
                count++;
                Console.WriteLine($"{b.P,12:F1} | {targetPkN,12:F1} | {b.M,12:F4} | {calcM,12:F4} | {deltaM,10:F2} | {error,10:F2}%");
            }
            
            // Compare Pure Axial Capacity (deltaP)
            double refPMax = refPoints.Min(p => p.P); // S-CONC uses negative for compression (-10372)
            double calcPMax = -calcPoints.Max(p => p.Pn) / 1000.0; // MB uses positive (10798) -> map to -10798
            double deltaP = calcPMax - refPMax;
            Console.WriteLine(new string('-', 75));
            Console.WriteLine($"Pure Axial Capacity Check:");
            Console.WriteLine($"  Ref Pmax:  {refPMax,12:F1} kN");
            Console.WriteLine($"  Calc Pmax: {calcPMax,12:F1} kN");
            Console.WriteLine($"  deltaP:    {deltaP,12:F1} kN ({(deltaP/refPMax)*100.0:F2}%)");
            Console.WriteLine($"  Average Error for Angle {scAngle}: {sumError/count:F2}%");
        }
    }

    private static double InterpolateM(List<InteractionPoint> points, double targetPkN)
    {
        // S-CONCRETE P is negative for compression. MB Pn is positive for compression.
        double internalTargetP = -targetPkN * 1000.0;
        var sorted = points.OrderBy(p => p.Pn).ToList();
        
        for (int i = 0; i < sorted.Count - 1; i++)
        {
            var p1 = sorted[i];
            var p2 = sorted[i+1];
            if ((p1.Pn <= internalTargetP && p2.Pn >= internalTargetP) || (p1.Pn >= internalTargetP && p2.Pn <= internalTargetP))
            {
                double t = Math.Abs(p2.Pn - p1.Pn) < 1.0 ? 0 : (internalTargetP - p1.Pn) / (p2.Pn - p1.Pn);
                double m1 = Math.Sqrt(p1.Mnx * p1.Mnx + p1.Mny * p1.Mny);
                double m2 = Math.Sqrt(p2.Mnx * p2.Mnx + p2.Mny * p2.Mny);
                return (m1 * (1 - t) + m2 * t) / 1e6;
            }
        }
        var closest = sorted.OrderBy(p => Math.Abs(p.Pn - internalTargetP)).First();
        return Math.Sqrt(closest.Mnx * closest.Mnx + closest.Mny * closest.Mny) / 1e6;
    }

    public class BenchmarkPoint
    {
        public double P { get; set; }
        public double M { get; set; }
    }
}
