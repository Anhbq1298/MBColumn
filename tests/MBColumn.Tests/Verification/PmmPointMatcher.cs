using System.Collections.Generic;
using System.Linq;

namespace MBColumn.Tests.Verification;

public sealed class PmmPointMatcher
{
    private readonly PmmDifferenceCalculator differenceCalculator;
    private readonly PmmStatisticsCalculator statisticsCalculator;

    public PmmPointMatcher(PmmDifferenceCalculator differenceCalculator, PmmStatisticsCalculator statisticsCalculator)
    {
        this.differenceCalculator = differenceCalculator;
        this.statisticsCalculator = statisticsCalculator;
    }

    public IReadOnlyList<PmmThetaComparison> Match(
        IReadOnlyList<PmmReferencePoint> references,
        IReadOnlyList<PmmCalculatedPoint> calculations,
        PmmComparisonOptions options)
    {
        var comparisons = new List<PmmThetaComparison>();
        var thetaGroups = new SortedSet<int>(references.Select(r => r.ThetaDegrees).Concat(calculations.Select(c => c.ThetaDegrees)));

        foreach (var theta in thetaGroups)
        {
            var refGroup = references.Where(r => r.ThetaDegrees == theta).OrderBy(r => r.PointIndex).ToList();
            var calcGroup = calculations.Where(c => c.ThetaDegrees == theta).OrderBy(c => c.PointIndex).ToList();
            string matchMethod = refGroup.Count == calcGroup.Count ? "Index" : "NearestNeighbour";
            var rows = new List<PmmComparisonRow>();

            if (refGroup.Count > 0 && calcGroup.Count > 0)
            {
                if (refGroup.Count == calcGroup.Count)
                {
                    for (int i = 0; i < refGroup.Count; i++)
                    {
                        var row = differenceCalculator.Calculate(refGroup[i], calcGroup[i], options) with { MatchMethod = matchMethod };
                        rows.Add(row);
                    }
                }
                else
                {
                    rows.AddRange(MatchByNearestNeighbour(refGroup, calcGroup, options, matchMethod));
                }
            }

            int missingReference = refGroup.Count == 0 ? 0 : Math.Max(0, refGroup.Count - rows.Count);
            int missingCalculated = calcGroup.Count == 0 ? 0 : Math.Max(0, calcGroup.Count - rows.Count);
            var stats = statisticsCalculator.Calculate(rows);

            comparisons.Add(new PmmThetaComparison(theta, matchMethod, rows, missingReference, missingCalculated, stats));
        }

        return comparisons;
    }

    private IEnumerable<PmmComparisonRow> MatchByNearestNeighbour(
        IReadOnlyList<PmmReferencePoint> references,
        IReadOnlyList<PmmCalculatedPoint> calculations,
        PmmComparisonOptions options,
        string matchMethod)
    {
        var unmatched = new List<PmmCalculatedPoint>(calculations);
        double pScale = Math.Max(1.0, references.Max(r => r.RefP) - references.Min(r => r.RefP));
        double mScale = Math.Max(1.0, references.Max(r => r.RefM) - references.Min(r => r.RefM));

        foreach (var reference in references)
        {
            var nearest = unmatched.OrderBy(c => NormalizedDistance(reference, c, pScale, mScale)).First();
            var row = differenceCalculator.Calculate(reference, nearest, options) with { MatchMethod = matchMethod };
            yield return row;
            unmatched.Remove(nearest);
            if (!unmatched.Any()) break;
        }
    }

    private static double NormalizedDistance(PmmReferencePoint reference, PmmCalculatedPoint calculated, double pScale, double mScale)
    {
        double dp = (reference.RefP - calculated.CalcP) / pScale;
        double dm = (reference.RefM - calculated.CalcM) / mScale;
        return Math.Sqrt(dp * dp + dm * dm);
    }
}
