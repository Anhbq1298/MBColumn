using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MBColumn.Tests.Verification;

/// <summary>
/// Generates a simplified PMM reference CSV from the EC2 reference data for testing.
/// This utility converts the full EC2 CSV to a simple format: Theta,PointIndex,RefP,RefMx,RefMy
/// </summary>
public sealed class ReferenceDataSetup
{
    /// <summary>
    /// Converts EC2 CSV (with many columns) to simplified format (Theta, PointIndex, P, Mx, My in internal units).
    /// </summary>
    public static string ConvertEc2ReferenceToSimplified(string repositoryRoot)
    {
        string inputCsv = Path.Combine(repositoryRoot, "docs", "validation", "ec2-fiber-pmm-sconcrete-generated-curves.csv");
        string outputCsv = Path.Combine(repositoryRoot, "docs", "validation", "ec2-fiber-pmm-reference-simple.csv");

        if (!File.Exists(inputCsv))
        {
            throw new FileNotFoundException($"Reference CSV not found: {inputCsv}");
        }

        var lines = File.ReadAllLines(inputCsv);
        if (lines.Length == 0)
        {
            throw new InvalidOperationException("Reference CSV is empty");
        }

        // Parse header to find column indices
        var header = lines[0].Split(',');
        int thetaIdx = Array.IndexOf(header, "theta_deg");
        int nIdx = Array.IndexOf(header, "N_kN");
        int mxIdx = Array.IndexOf(header, "Mx_kNm");
        int myIdx = Array.IndexOf(header, "My_kNm");

        if (thetaIdx < 0 || nIdx < 0 || mxIdx < 0 || myIdx < 0)
        {
            throw new InvalidOperationException("Required columns (theta_deg, N_kN, Mx_kNm, My_kNm) not found in EC2 CSV");
        }

        var dataByTheta = new SortedDictionary<int, List<(double P, double Mx, double My)>>();

        // Parse data rows
        for (int i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');
            if (columns.Length <= Math.Max(Math.Max(thetaIdx, nIdx), Math.Max(mxIdx, myIdx)))
            {
                continue;
            }

            if (!int.TryParse(columns[thetaIdx].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int theta))
                continue;
            if (!double.TryParse(columns[nIdx].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double nKn))
                continue;
            if (!double.TryParse(columns[mxIdx].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double mxKnm))
                continue;
            if (!double.TryParse(columns[myIdx].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double myKnm))
                continue;

            // Convert to internal units: kN -> N, kNm -> N-mm
            double pN = nKn * 1000.0;
            double mxNmm = mxKnm * 1_000_000.0;
            double myNmm = myKnm * 1_000_000.0;

            if (!dataByTheta.ContainsKey(theta))
            {
                dataByTheta[theta] = new List<(double, double, double)>();
            }

            dataByTheta[theta].Add((pN, mxNmm, myNmm));
        }

        // Write simplified CSV
        using (var writer = new StreamWriter(outputCsv, false, System.Text.Encoding.UTF8))
        {
            writer.WriteLine("Theta,PointIndex,RefP,RefMx,RefMy");

            int totalPoints = 0;
            foreach (var theta in dataByTheta.Keys)
            {
                var points = dataByTheta[theta];
                for (int idx = 0; idx < points.Count; idx++)
                {
                    var (p, mx, my) = points[idx];
                    writer.WriteLine(CultureInfo.InvariantCulture, $"{theta},{idx},{p:F4},{mx:F4},{my:F4}");
                    totalPoints++;
                }
            }

            writer.Flush();
        }

        Console.WriteLine($"✓ Generated reference CSV with {dataByTheta.Count} theta angles, {dataByTheta.Values.Sum(p => p.Count)} total points");
        return outputCsv;
    }
}
