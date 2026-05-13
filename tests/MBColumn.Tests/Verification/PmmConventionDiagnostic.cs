using System.Globalization;

namespace MBColumn.Tests.Verification;

public sealed class PmmConventionDiagnostic
{
    private readonly PmmPointMatcher matcher = new(new PmmDifferenceCalculator(), new PmmStatisticsCalculator());

    public IReadOnlyList<PmmConventionDiagnosticRow> Run(string docxPath)
    {
        var reference = new DocxPmmReferenceReader().Read(docxPath);
        var mapped = new PmmReferenceMapper().Map(reference);
        var runner = new MbColumnPmmRunner();
        var options = new PmmComparisonOptions();
        var runOptions = new PmmRunOptions(100, 1);
        var rows = new List<PmmConventionDiagnosticRow>();

        foreach (var thetaConvention in BuildThetaConventions(reference.ThetaDegrees))
        {
            var raw = runner.Run(mapped, runOptions, thetaConvention.Map);
            foreach (var momentMode in BuildMomentModes(thetaConvention.Map))
            {
                var transformed = raw.Select(point => TransformMoment(point, momentMode)).ToList();
                var comparisons = matcher.Match(reference.ReferencePoints, transformed, options);
                var theta153 = comparisons.Single(comparison => comparison.ThetaDegrees == 153);
                rows.Add(new PmmConventionDiagnosticRow(
                    thetaConvention.Name,
                    momentMode.Name,
                    comparisons.Sum(comparison => comparison.Statistics.FailCount),
                    comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffM),
                    comparisons.Average(comparison => comparison.Rows.Count == 0 ? 0.0 : comparison.Rows.Average(row => Math.Abs(row.DiffM))),
                    theta153.Statistics.FailCount,
                    theta153.Statistics.MaxAbsDiffM,
                    theta153.Rows.Count == 0 ? 0.0 : theta153.Rows.Average(row => Math.Abs(row.DiffM))));
            }
        }

        return rows
            .OrderBy(row => row.Theta153MeanAbsDiffM)
            .ThenBy(row => row.Theta153MaxAbsDiffM)
            .ThenBy(row => row.TotalFailedPoints)
            .ToList();
    }

    public IReadOnlyList<PmmConventionDiagnosticRow> RunOffsetSweep(string docxPath)
    {
        var reference = new DocxPmmReferenceReader().Read(docxPath);
        var mapped = new PmmReferenceMapper().Map(reference);
        var runner = new MbColumnPmmRunner();
        var options = new PmmComparisonOptions();
        var runOptions = new PmmRunOptions(100, 1);
        var allAngles = runner.RunAllAngles(mapped, runOptions);
        var allAnglesByTheta = allAngles
            .GroupBy(point => point.ThetaDegrees)
            .ToDictionary(group => group.Key, group => group.OrderBy(point => point.PointIndex).ToList());
        var rows = new List<PmmConventionDiagnosticRow>();

        for (int offset = 0; offset < 360; offset++)
        {
            int currentOffset = offset;
            var thetaMap = reference.ThetaDegrees.ToDictionary(
                theta => theta,
                theta => NormalizeTheta(theta + currentOffset));
            var raw = BuildReferenceMappedCalculations(reference.ThetaDegrees, thetaMap, allAnglesByTheta);

            foreach (var momentMode in new[]
            {
                new MomentMode("Resultant", (_, point) => Math.Sqrt(point.CalcMx * point.CalcMx + point.CalcMy * point.CalcMy)),
                new MomentMode("Ref-axis cos/sin", (theta, point) => Project(point, theta))
            })
            {
                var transformed = raw.Select(point => TransformMoment(point, momentMode)).ToList();
                var comparisons = matcher.Match(reference.ReferencePoints, transformed, options);
                var theta153 = comparisons.Single(comparison => comparison.ThetaDegrees == 153);
                rows.Add(new PmmConventionDiagnosticRow(
                    $"Ref+{currentOffset}",
                    momentMode.Name,
                    comparisons.Sum(comparison => comparison.Statistics.FailCount),
                    comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffM),
                    comparisons.Average(comparison => comparison.Rows.Count == 0 ? 0.0 : comparison.Rows.Average(row => Math.Abs(row.DiffM))),
                    theta153.Statistics.FailCount,
                    theta153.Statistics.MaxAbsDiffM,
                    theta153.Rows.Count == 0 ? 0.0 : theta153.Rows.Average(row => Math.Abs(row.DiffM))));
            }
        }

        return rows
            .OrderBy(row => row.OverallMeanAbsDiffM)
            .ThenBy(row => row.TotalFailedPoints)
            .ThenBy(row => row.Theta153MeanAbsDiffM)
            .ToList();
    }

    private static IReadOnlyList<PmmCalculatedPoint> BuildReferenceMappedCalculations(
        IReadOnlyList<int> referenceThetas,
        IReadOnlyDictionary<int, int> thetaMap,
        IReadOnlyDictionary<int, List<PmmCalculatedPoint>> allAnglesByTheta)
    {
        var result = new List<PmmCalculatedPoint>();
        foreach (int referenceTheta in referenceThetas)
        {
            int mbTheta = thetaMap[referenceTheta];
            if (!allAnglesByTheta.TryGetValue(mbTheta, out var points))
            {
                continue;
            }

            result.AddRange(points.Select(point => point with { ThetaDegrees = referenceTheta }));
        }

        return result;
    }

    public static void Print(IReadOnlyList<PmmConventionDiagnosticRow> rows)
    {
        Console.WriteLine();
        Console.WriteLine("=== PMM theta and moment convention diagnostic ===");
        Console.WriteLine("Best candidates by theta 153 mean |DiffM|:");
        foreach (var row in rows.Take(12))
        {
            Console.WriteLine(
                $"{row.ThetaConvention,-22} | {row.MomentMode,-24} | " +
                $"theta153 fail={row.Theta153FailedPoints,3}, mean |dM|={row.Theta153MeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"max |dM|={row.Theta153MaxAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"total fail={row.TotalFailedPoints,4}, all-theta mean |dM|={row.OverallMeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm");
        }

        Console.WriteLine();
        Console.WriteLine("Best candidates by all-theta mean |DiffM|:");
        foreach (var row in rows.OrderBy(row => row.OverallMeanAbsDiffM).ThenBy(row => row.TotalFailedPoints).Take(8))
        {
            Console.WriteLine(
                $"{row.ThetaConvention,-22} | {row.MomentMode,-24} | " +
                $"all-theta mean |dM|={row.OverallMeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"theta153 mean |dM|={row.Theta153MeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"total fail={row.TotalFailedPoints,4}");
        }
    }

    public static void PrintOffsetSweep(IReadOnlyList<PmmConventionDiagnosticRow> rows)
    {
        Console.WriteLine();
        Console.WriteLine("=== PMM theta offset sweep diagnostic ===");
        foreach (var row in rows.Take(12))
        {
            Console.WriteLine(
                $"{row.ThetaConvention,-10} | {row.MomentMode,-18} | " +
                $"all-theta mean |dM|={row.OverallMeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"total fail={row.TotalFailedPoints,4}, " +
                $"theta153 mean |dM|={row.Theta153MeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm, " +
                $"theta153 max |dM|={row.Theta153MaxAbsDiffM.ToString("F3", CultureInfo.InvariantCulture),8} kNm");
        }
    }

    private static IReadOnlyList<ThetaConvention> BuildThetaConventions(IReadOnlyList<int> referenceThetas)
        => new[]
        {
            Convention("Current 90-ref", referenceThetas, theta => NormalizeTheta(90 - theta)),
            Convention("Direct ref", referenceThetas, theta => NormalizeTheta(theta)),
            Convention("Negative ref", referenceThetas, theta => NormalizeTheta(-theta)),
            Convention("Ref+90", referenceThetas, theta => NormalizeTheta(theta + 90)),
            Convention("Ref-90", referenceThetas, theta => NormalizeTheta(theta - 90)),
            Convention("180-ref", referenceThetas, theta => NormalizeTheta(180 - theta)),
            Convention("Ref+180", referenceThetas, theta => NormalizeTheta(theta + 180)),
            Convention("270-ref", referenceThetas, theta => NormalizeTheta(270 - theta))
        };

    private static ThetaConvention Convention(
        string name,
        IReadOnlyList<int> referenceThetas,
        Func<int, int> map)
        => new(name, referenceThetas.ToDictionary(theta => theta, map));

    private static IReadOnlyList<MomentMode> BuildMomentModes(IReadOnlyDictionary<int, int> thetaMap)
        => new[]
        {
            new MomentMode("Resultant", (_, point) => Math.Sqrt(point.CalcMx * point.CalcMx + point.CalcMy * point.CalcMy)),
            new MomentMode("Abs Mx", (_, point) => Math.Abs(point.CalcMx)),
            new MomentMode("Abs My", (_, point) => Math.Abs(point.CalcMy)),
            new MomentMode("Ref-axis cos/sin", (theta, point) => Project(point, theta)),
            new MomentMode("Ref-axis sin/cos", (theta, point) => ProjectSwapped(point, theta)),
            new MomentMode("MB-axis cos/sin", (theta, point) => Project(point, thetaMap[theta])),
            new MomentMode("MB-axis sin/cos", (theta, point) => ProjectSwapped(point, thetaMap[theta]))
        };

    private static PmmCalculatedPoint TransformMoment(PmmCalculatedPoint point, MomentMode mode)
    {
        double moment = mode.Value(point.ThetaDegrees, point);
        return point with { CalcMx = moment, CalcMy = 0.0 };
    }

    private static double Project(PmmCalculatedPoint point, int thetaDegrees)
    {
        double theta = thetaDegrees * Math.PI / 180.0;
        return Math.Abs(point.CalcMx * Math.Cos(theta) + point.CalcMy * Math.Sin(theta));
    }

    private static double ProjectSwapped(PmmCalculatedPoint point, int thetaDegrees)
    {
        double theta = thetaDegrees * Math.PI / 180.0;
        return Math.Abs(point.CalcMx * Math.Sin(theta) + point.CalcMy * Math.Cos(theta));
    }

    private static int NormalizeTheta(int theta)
    {
        int normalized = theta % 360;
        return normalized < 0 ? normalized + 360 : normalized;
    }

    private sealed record ThetaConvention(string Name, IReadOnlyDictionary<int, int> Map);

    private sealed record MomentMode(string Name, Func<int, PmmCalculatedPoint, double> Value);
}

public sealed record PmmConventionDiagnosticRow(
    string ThetaConvention,
    string MomentMode,
    int TotalFailedPoints,
    double OverallMaxAbsDiffM,
    double OverallMeanAbsDiffM,
    int Theta153FailedPoints,
    double Theta153MaxAbsDiffM,
    double Theta153MeanAbsDiffM);
