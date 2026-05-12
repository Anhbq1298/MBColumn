using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

namespace MBColumn.Tests.Verification;

public sealed class PmmComparisonRunner
{
    private readonly PmmPointMatcher matcher;
    private readonly PdfReportWriter reportWriter;

    public PmmComparisonRunner()
    {
        matcher = new PmmPointMatcher(new PmmDifferenceCalculator(), new PmmStatisticsCalculator());
        reportWriter = new PdfReportWriter();
    }

    public PmmComparisonReport Run(ColumnCalculationService service, ColumnInputDto input, string referenceCsvPath, string pdfOutputPath, PmmComparisonOptions? options = null)
    {
        options ??= new PmmComparisonOptions();
        var referencePoints = LoadReferencePoints(referenceCsvPath).ToList();
        var result = service.Calculate(input);

        var calculatedPoints = BuildCalculatedPoints(result.Surface).ToList();
        var thetaComparisons = matcher.Match(referencePoints, calculatedPoints, options);

        var totalMatched = thetaComparisons.Sum(t => t.Rows.Count);
        var totalMissing = thetaComparisons.Sum(t => t.MissingReferencePoints + t.MissingCalculatedPoints);
        var totalFailed = thetaComparisons.Sum(t => t.Statistics.FailCount);

        var overallMeanP = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.MeanPercentDiffP) : 0.0;
        var overallMeanM = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.MeanPercentDiffM) : 0.0;
        var overallVarP = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.VariancePercentDiffP) : 0.0;
        var overallVarM = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.VariancePercentDiffM) : 0.0;
        var overallStdP = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.StandardDeviationPercentDiffP) : 0.0;
        var overallStdM = thetaComparisons.Any() ? thetaComparisons.Average(t => t.Statistics.StandardDeviationPercentDiffM) : 0.0;

        var mismatchNotes = new List<string>();
        if (totalMissing > 0)
        {
            mismatchNotes.Add($"Reference and calculated boundary counts differ: {totalMissing} missing points.");
        }

        if (totalFailed > 0)
        {
            mismatchNotes.Add($"{totalFailed} point comparisons failed acceptance criteria.");
        }

        if (!thetaComparisons.Any())
        {
            mismatchNotes.Add("No theta comparisons were created.");
        }

        var report = new PmmComparisonReport(
            Title: "PMM Apple-to-Apple Comparison Report",
            GeneratedAt: DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC", CultureInfo.InvariantCulture),
            SectionSummary: BuildSectionSummary(input),
            MaterialSummary: BuildMaterialSummary(input.UnitSystem),
            ReinforcementSummary: BuildReinforcementSummary(input),
            UnitSystem: input.UnitSystem.ToString(),
            MomentDefinition: "Mx = force * y; My = force * x",
            ThetaComparisons: thetaComparisons,
            TotalThetaCount: thetaComparisons.Count,
            TotalMatchedPoints: totalMatched,
            TotalMissingPoints: totalMissing,
            TotalFailedPoints: totalFailed,
            OverallMeanPercentDiffP: overallMeanP,
            OverallMeanPercentDiffM: overallMeanM,
            OverallVariancePercentDiffP: overallVarP,
            OverallVariancePercentDiffM: overallVarM,
            OverallStandardDeviationPercentDiffP: overallStdP,
            OverallStandardDeviationPercentDiffM: overallStdM,
            OverallConclusion: totalFailed == 0 && totalMissing == 0 ? "PASS" : "FAIL",
            MismatchNotes: mismatchNotes,
            FinalAnalysis: BuildFinalAnalysis(totalMatched, totalMissing, totalFailed));

        reportWriter.Write(pdfOutputPath, report);
        return report;
    }

    public IReadOnlyList<PmmReferencePoint> LoadReferencePoints(string csvPath)
    {
        var lines = File.ReadAllLines(csvPath).Skip(1);
        var points = new List<PmmReferencePoint>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var columns = line.Split(',');
            if (columns.Length < 5)
            {
                continue;
            }

            if (!int.TryParse(columns[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var theta) ||
                !int.TryParse(columns[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var pointIndex) ||
                !double.TryParse(columns[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var p) ||
                !double.TryParse(columns[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var mx) ||
                !double.TryParse(columns[4], NumberStyles.Float, CultureInfo.InvariantCulture, out var my))
            {
                continue;
            }

            points.Add(new PmmReferencePoint(theta, pointIndex, p, mx, my));
        }

        return points;
    }

    public IReadOnlyList<PmmCalculatedPoint> BuildCalculatedPoints(InteractionSurface surface)
    {
        return surface.Points
            .Select(p => new PmmCalculatedPoint(p.ThetaDegrees == 360 ? 0 : (int)Math.Round(p.ThetaDegrees), p.DepthIndex, p.Pn, p.Mnx, p.Mny))
            .ToList();
    }

    private static string BuildSectionSummary(ColumnInputDto input)
        => $"Section: {input.Width} x {input.Height} ({input.UnitSystem}) with cover {input.Cover}, layout '{input.RebarLayoutPreset}', {input.BarCount} x {input.BarSize}";

    private static string BuildMaterialSummary(UnitSystem unitSystem)
        => unitSystem == UnitSystem.Metric
            ? "Concrete strength and steel properties were specified in metric units for the comparison run."
            : "Concrete strength and steel properties were specified in imperial units for the comparison run.";

    private static string BuildReinforcementSummary(ColumnInputDto input)
        => $"Reinforcement: {input.BarCount} bars of size {input.BarSize} arranged as '{input.RebarLayoutPreset}'.";

    private static string BuildFinalAnalysis(int matched, int missing, int failed)
    {
        var builder = new System.Text.StringBuilder();
        builder.AppendLine("This report compares apple-to-apple PMM points by theta and nearest-match index.");
        builder.AppendLine($"Matched points: {matched}. Missing points: {missing}. Failed points: {failed}.");
        builder.AppendLine("Strict acceptance is based on percent tolerance and absolute difference thresholds.");
        return builder.ToString();
    }
}
