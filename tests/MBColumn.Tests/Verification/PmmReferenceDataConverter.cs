using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MBColumn.Tests.Verification;

/// <summary>
/// Utility to convert EC2 reference CSV to simplified PMM comparison format.
/// Input CSV format: theta_deg,state_id,N_kN,Mx_kNm,My_kNm,...
/// Output CSV format: Theta,PointIndex,RefP,RefMx,RefMy (in N, N-mm, N-mm)
/// </summary>
public sealed class PmmReferenceDataConverter
{
    public static void ConvertEc2CsvToSimplifiedFormat(string inputCsvPath, string outputCsvPath)
    {
        var lines = File.ReadAllLines(inputCsvPath);
        if (lines.Length == 0)
        {
            throw new InvalidOperationException("Input CSV is empty");
        }

        var header = lines[0].Split(',');
        int thetaColIndex = Array.IndexOf(header, "theta_deg");
        int nColIndex = Array.IndexOf(header, "N_kN");
        int mxColIndex = Array.IndexOf(header, "Mx_kNm");
        int myColIndex = Array.IndexOf(header, "My_kNm");

        if (thetaColIndex < 0 || nColIndex < 0 || mxColIndex < 0 || myColIndex < 0)
        {
            throw new InvalidOperationException($"Required columns not found in header: {lines[0]}");
        }

        var dataByTheta = new SortedDictionary<int, List<(double P, double Mx, double My)>>();

        for (int i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');
            if (columns.Length <= Math.Max(Math.Max(thetaColIndex, nColIndex), Math.Max(mxColIndex, myColIndex)))
            {
                continue;
            }

            if (!int.TryParse(columns[thetaColIndex].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int theta) ||
                !double.TryParse(columns[nColIndex].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double nKn) ||
                !double.TryParse(columns[mxColIndex].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double mxKnm) ||
                !double.TryParse(columns[myColIndex].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double myKnm))
            {
                continue;
            }

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
        using var writer = new StreamWriter(outputCsvPath, false, System.Text.Encoding.UTF8);
        writer.WriteLine("Theta,PointIndex,RefP,RefMx,RefMy");

        int totalPoints = 0;
        foreach (var theta in dataByTheta.Keys)
        {
            var points = dataByTheta[theta];
            for (int idx = 0; idx < points.Count; idx++)
            {
                var (p, mx, my) = points[idx];
                writer.WriteLine($"{theta},{idx},{p:F4},{mx:F4},{my:F4}");
                totalPoints++;
            }
        }

        writer.Flush();
        Console.WriteLine($"✓ Converted {dataByTheta.Count} theta angles, {totalPoints} total points");
        Console.WriteLine($"✓ Output: {outputCsvPath}");
    }

    public static void Main(string[] args)
    {
        string inputCsv = args.Length > 0 ? args[0] : "./docs/validation/ec2-fiber-pmm-sconcrete-generated-curves.csv";
        string outputCsv = args.Length > 1 ? args[1] : "./docs/validation/ec2-fiber-pmm-reference-simple.csv";

        if (!File.Exists(inputCsv))
        {
            Console.WriteLine($"ERROR: Input file not found: {inputCsv}");
            return;
        }

        ConvertEc2CsvToSimplifiedFormat(inputCsv, outputCsv);
    }
}
