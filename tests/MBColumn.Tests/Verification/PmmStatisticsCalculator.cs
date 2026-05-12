using System.Collections.Generic;
using System.Linq;

namespace MBColumn.Tests.Verification;

public sealed class PmmStatisticsCalculator
{
    public PmmComparisonStatistics Calculate(IReadOnlyList<PmmComparisonRow> rows)
    {
        var pDiffs = rows.Select(r => r.PercentDiffP).Where(p => p.HasValue).Select(p => p!.Value).ToList();
        var mDiffs = rows.Select(r => r.PercentDiffM).Where(p => p.HasValue).Select(p => p!.Value).ToList();

        double meanP = pDiffs.Any() ? pDiffs.Average() : 0.0;
        double meanM = mDiffs.Any() ? mDiffs.Average() : 0.0;
        double varianceP = pDiffs.Any() ? pDiffs.Average(v => (v - meanP) * (v - meanP)) : 0.0;
        double varianceM = mDiffs.Any() ? mDiffs.Average(v => (v - meanM) * (v - meanM)) : 0.0;
        double stddevP = Math.Sqrt(varianceP);
        double stddevM = Math.Sqrt(varianceM);
        double maxAbsPercentDiffP = pDiffs.Any() ? pDiffs.Max(v => Math.Abs(v)) : 0.0;
        double maxAbsPercentDiffM = mDiffs.Any() ? mDiffs.Max(v => Math.Abs(v)) : 0.0;
        double maxAbsDiffP = rows.Any() ? rows.Max(r => Math.Abs(r.DiffP)) : 0.0;
        double maxAbsDiffM = rows.Any() ? rows.Max(r => Math.Abs(r.DiffM)) : 0.0;
        int passCount = rows.Count(r => r.OverallPass);
        int failCount = rows.Count(r => !r.OverallPass);

        return new PmmComparisonStatistics(
            meanP,
            varianceP,
            stddevP,
            meanM,
            varianceM,
            stddevM,
            maxAbsPercentDiffP,
            maxAbsPercentDiffM,
            maxAbsDiffP,
            maxAbsDiffM,
            passCount,
            failCount,
            rows.Count);
    }
}
