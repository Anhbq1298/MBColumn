using System.Globalization;

namespace MBColumn.Tests.Verification;

public sealed class PmmInterpolationPowerDiagnostic
{
    public PmmInterpolationPowerDiagnosticResult Run(string docxPath, int thetaDegrees)
    {
        var reference = new DocxPmmReferenceReader().Read(docxPath);
        var mapped = new PmmReferenceMapper().Map(reference);
        var calculated = new MbColumnPmmRunner().Run(mapped);

        var curve = calculated
            .Where(point => point.ThetaDegrees == thetaDegrees)
            .OrderBy(point => point.CalcP)
            .ThenBy(point => point.CalcM)
            .ToList();
        if (curve.Count < 3)
        {
            throw new InvalidOperationException($"Theta {thetaDegrees} does not have enough MBColumn points for interpolation diagnostics.");
        }

        var x = new List<double>();
        var y = new List<double>();
        foreach (var group in curve.GroupBy(point => point.CalcP).OrderBy(group => group.Key))
        {
            x.Add(group.Key);
            y.Add(group.Average(point => point.CalcM));
        }

        double[] xs = x.ToArray();
        double[] ys = y.ToArray();
        double[] y2 = BuildNaturalSplineSecondDerivatives(xs, ys);

        var rows = reference.ReferencePoints
            .Where(point => point.ThetaDegrees == thetaDegrees)
            .OrderBy(point => point.PointIndex)
            .Select(point =>
            {
                double linearM = InterpolateLinear(xs, ys, point.RefP);
                double cubicM = InterpolateNaturalCubic(xs, ys, y2, point.RefP);
                return new PmmInterpolationPowerDiagnosticRow(
                    point.PointIndex,
                    point.RefP,
                    point.RefM,
                    linearM,
                    cubicM,
                    cubicM - linearM,
                    linearM - point.RefM,
                    cubicM - point.RefM);
            })
            .ToList();

        return new PmmInterpolationPowerDiagnosticResult(
            thetaDegrees,
            curve.Count,
            xs.Length,
            rows,
            rows.Max(row => Math.Abs(row.CubicMinusLinear)),
            rows.Average(row => Math.Abs(row.CubicMinusLinear)),
            rows.Max(row => Math.Abs(row.LinearDiff)),
            rows.Max(row => Math.Abs(row.CubicDiff)),
            rows.Average(row => Math.Abs(row.LinearDiff)),
            rows.Average(row => Math.Abs(row.CubicDiff)));
    }

    public static void Print(PmmInterpolationPowerDiagnosticResult result)
    {
        Console.WriteLine();
        Console.WriteLine($"=== Interpolation power sensitivity: theta {result.ThetaDegrees} ===");
        Console.WriteLine($"Raw MBColumn points: {result.RawMbPointCount}");
        Console.WriteLine($"Unique axial-load points: {result.UniqueAxialPointCount}");
        Console.WriteLine($"Max |cubic - linear|: {result.MaxAbsCubicMinusLinear.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine($"Mean |cubic - linear|: {result.MeanAbsCubicMinusLinear.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine($"Max |linear - reference|: {result.MaxAbsLinearDiff.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine($"Max |cubic - reference|: {result.MaxAbsCubicDiff.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine($"Mean |linear - reference|: {result.MeanAbsLinearDiff.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine($"Mean |cubic - reference|: {result.MeanAbsCubicDiff.ToString("F6", CultureInfo.InvariantCulture)} kNm");
        Console.WriteLine("Largest cubic-vs-linear rows:");
        foreach (var row in result.Rows.OrderByDescending(row => Math.Abs(row.CubicMinusLinear)).Take(8))
        {
            Console.WriteLine(
                $"  idx {row.PointIndex,3}: P={row.RefP,10:F3} kN, RefM={row.RefM,10:F3} kNm, " +
                $"LinearM={row.LinearM,10:F3}, CubicM={row.CubicM,10:F3}, Cubic-Linear={row.CubicMinusLinear,9:F3}");
        }
    }

    private static double[] BuildNaturalSplineSecondDerivatives(double[] x, double[] y)
    {
        int n = x.Length;
        var y2 = new double[n];
        var u = new double[Math.Max(1, n - 1)];

        y2[0] = 0.0;
        u[0] = 0.0;

        for (int i = 1; i < n - 1; i++)
        {
            double sig = (x[i] - x[i - 1]) / (x[i + 1] - x[i - 1]);
            double p = sig * y2[i - 1] + 2.0;
            y2[i] = (sig - 1.0) / p;
            u[i] = (6.0 * (((y[i + 1] - y[i]) / (x[i + 1] - x[i])) - ((y[i] - y[i - 1]) / (x[i] - x[i - 1]))) / (x[i + 1] - x[i - 1]) - sig * u[i - 1]) / p;
        }

        y2[n - 1] = 0.0;
        for (int k = n - 2; k >= 0; k--)
        {
            y2[k] = y2[k] * y2[k + 1] + u[k];
        }

        return y2;
    }

    private static double InterpolateLinear(double[] x, double[] y, double xp)
    {
        int upper = FindUpperIndex(x, xp);
        if (upper == 0)
        {
            return y[0];
        }

        if (upper >= x.Length)
        {
            return y[^1];
        }

        int lower = upper - 1;
        double t = (xp - x[lower]) / (x[upper] - x[lower]);
        return y[lower] + (y[upper] - y[lower]) * t;
    }

    private static double InterpolateNaturalCubic(double[] x, double[] y, double[] y2, double xp)
    {
        int upper = FindUpperIndex(x, xp);
        if (upper == 0)
        {
            return y[0];
        }

        if (upper >= x.Length)
        {
            return y[^1];
        }

        int lower = upper - 1;
        double h = x[upper] - x[lower];
        if (Math.Abs(h) <= 1e-12)
        {
            return y[lower];
        }

        double a = (x[upper] - xp) / h;
        double b = (xp - x[lower]) / h;
        return a * y[lower]
            + b * y[upper]
            + ((a * a * a - a) * y2[lower] + (b * b * b - b) * y2[upper]) * h * h / 6.0;
    }

    private static int FindUpperIndex(double[] x, double xp)
    {
        if (xp <= x[0])
        {
            return 0;
        }

        if (xp >= x[^1])
        {
            return x.Length;
        }

        int lower = 0;
        int upper = x.Length - 1;
        while (upper - lower > 1)
        {
            int mid = (upper + lower) / 2;
            if (x[mid] > xp)
            {
                upper = mid;
            }
            else
            {
                lower = mid;
            }
        }

        return upper;
    }
}

public sealed record PmmInterpolationPowerDiagnosticResult(
    int ThetaDegrees,
    int RawMbPointCount,
    int UniqueAxialPointCount,
    IReadOnlyList<PmmInterpolationPowerDiagnosticRow> Rows,
    double MaxAbsCubicMinusLinear,
    double MeanAbsCubicMinusLinear,
    double MaxAbsLinearDiff,
    double MaxAbsCubicDiff,
    double MeanAbsLinearDiff,
    double MeanAbsCubicDiff);

public sealed record PmmInterpolationPowerDiagnosticRow(
    int PointIndex,
    double RefP,
    double RefM,
    double LinearM,
    double CubicM,
    double CubicMinusLinear,
    double LinearDiff,
    double CubicDiff);
