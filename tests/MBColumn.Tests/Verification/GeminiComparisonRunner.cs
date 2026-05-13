using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBColumn.Tests.Verification;

/// <summary>
/// Runs MBColumn with Gemini test case parameters and compares results
/// </summary>
public static class GeminiComparisonRunner
{
    /// <summary>
    /// Extract test case from Gemini_NvsM_Test_Package_v2.docx (placeholder)
    /// </summary>
    public class GeminiTestCase
    {
        public string SectionDescription { get; set; } = "To be extracted from Gemini docx";
        public double SectionWidth { get; set; }
        public double SectionHeight { get; set; }
        public double Cover { get; set; }
        public string RebarSize { get; set; } = "Unknown";
        public int RebarCount { get; set; }
        public double FcMpa { get; set; }
        public double FyMpa { get; set; }
        public string DesignCode { get; set; } = "Unknown";
        public Dictionary<int, List<(double P_kN, double Mx_kNm, double My_kNm)>> ReferenceData { get; set; } = new();
    }

    /// <summary>
    /// Comparison result for a single point
    /// </summary>
    public class PointComparison
    {
        public int Theta { get; set; }
        public int PointIndex { get; set; }
        public double RefP { get; set; }
        public double CalcP { get; set; }
        public double DiffP => CalcP - RefP;
        public double PctDiffP => Math.Abs(RefP) > 1e-6 ? (DiffP / RefP * 100.0) : 0;

        public double RefMx { get; set; }
        public double CalcMx { get; set; }
        public double DiffMx => CalcMx - RefMx;
        public double PctDiffMx => Math.Abs(RefMx) > 1e-6 ? (DiffMx / RefMx * 100.0) : 0;

        public double RefMy { get; set; }
        public double CalcMy { get; set; }
        public double DiffMy => CalcMy - RefMy;
        public double PctDiffMy => Math.Abs(RefMy) > 1e-6 ? (DiffMy / RefMy * 100.0) : 0;

        public string PStatus { get; set; } = "N/A";
        public string MxStatus { get; set; } = "N/A";
        public string MyStatus { get; set; } = "N/A";
        public string OverallStatus => (PStatus == "PASS" && MxStatus == "PASS" && MyStatus == "PASS") ? "PASS" : "FAIL";
    }

    /// <summary>
    /// Placeholder: Try to extract Gemini reference test case
    /// In production, this would parse the .docx file
    /// </summary>
    public static GeminiTestCase CreateGeminiTestCase()
    {
        // TODO: Parse Gemini_NvsM_Test_Package_v2.docx
        // For now, return a default test case based on common structural parameters
        
        var testCase = new GeminiTestCase
        {
            SectionWidth = 500,      // Typical medium-sized column
            SectionHeight = 500,     // Square section
            Cover = 40,              // Standard concrete cover
            RebarSize = "T25",       // 25mm diameter bars
            RebarCount = 16,         // 4 bars per side
            FcMpa = 30,              // 30 MPa concrete
            FyMpa = 400,             // 400 MPa steel
            DesignCode = "ACI 318"
        };

        // Placeholder: Would extract real data from Gemini docx
        // Example structure:
        // Theta = 0°: [(P1, Mx1, My1), (P2, Mx2, My2), ...]
        // Theta = 10°: [(P1, Mx1, My1), ...]
        // etc.

        return testCase;
    }

    /// <summary>
    /// Print comparison report
    /// </summary>
    public static void PrintComparisonReport(GeminiTestCase testCase, List<PointComparison> comparisons)
    {
        Console.WriteLine("\n" + new string('=', 100));
        Console.WriteLine("GEMINI vs MBColumn COMPARISON REPORT");
        Console.WriteLine(new string('=', 100));

        Console.WriteLine($"\nTEST CASE: {testCase.SectionDescription}");
        Console.WriteLine($"  Section: {testCase.SectionWidth} × {testCase.SectionHeight} mm");
        Console.WriteLine($"  Reinforcement: {testCase.RebarCount} × {testCase.RebarSize}");
        Console.WriteLine($"  Materials: f'c = {testCase.FcMpa} MPa, fy = {testCase.FyMpa} MPa");
        Console.WriteLine($"  Design Code: {testCase.DesignCode}");
        Console.WriteLine($"  Cover: {testCase.Cover} mm");

        // Group by theta
        var byTheta = comparisons.GroupBy(c => c.Theta).OrderBy(g => g.Key).ToList();

        Console.WriteLine($"\nCOMPARISON SUMMARY:");
        Console.WriteLine($"  Total theta angles: {byTheta.Count}");
        Console.WriteLine($"  Total points: {comparisons.Count}");
        Console.WriteLine($"  PASS points: {comparisons.Count(c => c.OverallStatus == "PASS")}");
        Console.WriteLine($"  FAIL points: {comparisons.Count(c => c.OverallStatus == "FAIL")}");

        // Statistics
        var passing = comparisons.Where(c => c.OverallStatus == "PASS").ToList();
        if (passing.Count > 0)
        {
            var pctDiffs = passing.Select(c => Math.Abs(c.PctDiffP)).ToList();
            Console.WriteLine($"\n  Average %ΔP (passing): {pctDiffs.Average():F3}%");
            Console.WriteLine($"  Max %ΔP (passing): {pctDiffs.Max():F3}%");
            Console.WriteLine($"  Stddev %ΔP (passing): {CalculateStdDev(pctDiffs):F4}");
        }

        // Detail by theta
        Console.WriteLine($"\nDETAIL BY THETA:");
        Console.WriteLine(new string('-', 100));
        foreach (var thetaGroup in byTheta.Take(5)) // First 5 theta angles
        {
            Console.WriteLine($"\nΘ = {thetaGroup.Key}°:");
            Console.WriteLine($"  Points: {thetaGroup.Count()}");
            Console.WriteLine($"  PASS: {thetaGroup.Count(c => c.OverallStatus == "PASS")}");
            Console.WriteLine($"  FAIL: {thetaGroup.Count(c => c.OverallStatus == "FAIL")}");

            var passingTheta = thetaGroup.Where(c => c.OverallStatus == "PASS").ToList();
            if (passingTheta.Count > 0)
            {
                var pDiffs = passingTheta.Select(c => Math.Abs(c.PctDiffP)).ToList();
                Console.WriteLine($"  Mean %ΔP: {pDiffs.Average():F3}%");
                Console.WriteLine($"  Max |%ΔP|: {pDiffs.Max():F3}%");
            }
        }

        Console.WriteLine($"\nOVERALL CONCLUSION: {(comparisons.All(c => c.OverallStatus == "PASS") ? "✓ PASS" : "✗ FAIL")}");
    }

    private static double CalculateStdDev(List<double> values)
    {
        if (values.Count == 0) return 0;
        double mean = values.Average();
        double variance = values.Average(v => (v - mean) * (v - mean));
        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Apply acceptance criteria (dual tolerance)
    /// </summary>
    public static void ApplyAcceptanceCriteria(List<PointComparison> comparisons, 
        double percentTolerance = 5.0, 
        double axialTolerance = 25.0,
        double momentTolerance = 25.0)
    {
        foreach (var comp in comparisons)
        {
            // P: passes if abs(%diff) <= 5% OR abs(diff) <= 25 kN
            comp.PStatus = (Math.Abs(comp.PctDiffP) <= percentTolerance || Math.Abs(comp.DiffP) <= axialTolerance) 
                ? "PASS" 
                : "FAIL";

            // Mx: passes if abs(%diff) <= 5% OR abs(diff) <= 25 kNm
            comp.MxStatus = (Math.Abs(comp.PctDiffMx) <= percentTolerance || Math.Abs(comp.DiffMx) <= momentTolerance)
                ? "PASS"
                : "FAIL";

            // My: passes if abs(%diff) <= 5% OR abs(diff) <= 25 kNm
            comp.MyStatus = (Math.Abs(comp.PctDiffMy) <= percentTolerance || Math.Abs(comp.DiffMy) <= momentTolerance)
                ? "PASS"
                : "FAIL";
        }
    }
}
