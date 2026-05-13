using System.Globalization;

namespace MBColumn.Tests.Verification;

public sealed class PmmSampleCountDiagnostic
{
    private readonly PmmPointMatcher matcher = new(new PmmDifferenceCalculator(), new PmmStatisticsCalculator());

    public IReadOnlyList<PmmSampleCountDiagnosticRow> Run(string docxPath, int thetaDegrees)
    {
        var reference = new DocxPmmReferenceReader().Read(docxPath);
        var mapped = new PmmReferenceMapper().Map(reference);
        var runner = new MbColumnPmmRunner();
        var options = new PmmComparisonOptions();

        return new[]
        {
            RunCase("150 samples", reference, mapped, runner, options, new PmmRunOptions(150, 1), thetaDegrees),
            RunCase("100 samples", reference, mapped, runner, options, new PmmRunOptions(100, 1), thetaDegrees)
        };
    }

    public static void Print(IReadOnlyList<PmmSampleCountDiagnosticRow> rows)
    {
        Console.WriteLine();
        Console.WriteLine("=== PMM neutral-axis sample count diagnostic ===");
        foreach (var row in rows)
        {
            Console.WriteLine(
                $"{row.Label}: MB points={row.TotalCalculatedPoints}, matched={row.TotalMatchedPoints}, " +
                $"failed={row.TotalFailedPoints}, max |DiffP|={row.MaxAbsDiffP.ToString("F3", CultureInfo.InvariantCulture)} kN, " +
                $"max |DiffM|={row.MaxAbsDiffM.ToString("F3", CultureInfo.InvariantCulture)} kNm");
            Console.WriteLine(
                $"  Theta {row.ThetaDegrees}: match={row.ThetaMatchMethod}, calc points={row.ThetaCalculatedPoints}, " +
                $"failed={row.ThetaFailedPoints}, max |DiffP|={row.ThetaMaxAbsDiffP.ToString("F3", CultureInfo.InvariantCulture)} kN, " +
                $"max |DiffM|={row.ThetaMaxAbsDiffM.ToString("F3", CultureInfo.InvariantCulture)} kNm, " +
                $"mean |DiffM|={row.ThetaMeanAbsDiffM.ToString("F3", CultureInfo.InvariantCulture)} kNm");
        }
    }

    private PmmSampleCountDiagnosticRow RunCase(
        string label,
        DocxPmmReferenceData reference,
        PmmMappedReferenceModel mapped,
        MbColumnPmmRunner runner,
        PmmComparisonOptions options,
        PmmRunOptions runOptions,
        int thetaDegrees)
    {
        var calculated = runner.Run(mapped, runOptions);
        var comparisons = matcher.Match(reference.ReferencePoints, calculated, options);
        var theta = comparisons.Single(comparison => comparison.ThetaDegrees == thetaDegrees);
        var thetaCalculatedPoints = calculated.Count(point => point.ThetaDegrees == thetaDegrees);

        return new PmmSampleCountDiagnosticRow(
            label,
            runOptions.NeutralAxisSamples,
            calculated.Count,
            comparisons.Sum(comparison => comparison.Rows.Count),
            comparisons.Sum(comparison => comparison.Statistics.FailCount),
            comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffP),
            comparisons.Max(comparison => comparison.Statistics.MaxAbsDiffM),
            thetaDegrees,
            theta.MatchMethod,
            thetaCalculatedPoints,
            theta.Statistics.FailCount,
            theta.Statistics.MaxAbsDiffP,
            theta.Statistics.MaxAbsDiffM,
            theta.Rows.Count == 0 ? 0.0 : theta.Rows.Average(row => Math.Abs(row.DiffM)));
    }
}

public sealed record PmmSampleCountDiagnosticRow(
    string Label,
    int NeutralAxisSamples,
    int TotalCalculatedPoints,
    int TotalMatchedPoints,
    int TotalFailedPoints,
    double MaxAbsDiffP,
    double MaxAbsDiffM,
    int ThetaDegrees,
    string ThetaMatchMethod,
    int ThetaCalculatedPoints,
    int ThetaFailedPoints,
    double ThetaMaxAbsDiffP,
    double ThetaMaxAbsDiffM,
    double ThetaMeanAbsDiffM);
