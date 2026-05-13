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
            bool canMatchByIndex = refGroup.Count == calcGroup.Count && PointIndexPLevelsMatch(refGroup, calcGroup, options);
            string matchMethod = canMatchByIndex ? "Index" : "InterpolatedByReferenceP";
            var rows = new List<PmmComparisonRow>();

            if (refGroup.Count > 0 && calcGroup.Count > 0)
            {
                if (canMatchByIndex)
                {
                    for (int i = 0; i < refGroup.Count; i++)
                    {
                        var row = differenceCalculator.Calculate(refGroup[i], calcGroup[i], options) with { MatchMethod = matchMethod };
                        rows.Add(row);
                    }
                }
                else
                {
                    rows.AddRange(MatchByReferenceAxialLoad(refGroup, calcGroup, options, matchMethod));
                }
            }

            int missingReference = calcGroup.Count == 0 ? refGroup.Count : Math.Max(0, refGroup.Count - rows.Count);
            int missingCalculated = refGroup.Count == 0 ? calcGroup.Count : 0;
            var stats = statisticsCalculator.Calculate(rows);

            comparisons.Add(new PmmThetaComparison(theta, matchMethod, rows, missingReference, missingCalculated, stats));
        }

        return comparisons;
    }

    private static bool PointIndexPLevelsMatch(
        IReadOnlyList<PmmReferencePoint> references,
        IReadOnlyList<PmmCalculatedPoint> calculations,
        PmmComparisonOptions options)
    {
        for (int i = 0; i < references.Count; i++)
        {
            double tolerance = Math.Max(
                options.AbsoluteAxialTolerance,
                Math.Abs(references[i].RefP) * options.PercentTolerance / 100.0);
            if (Math.Abs(calculations[i].CalcP - references[i].RefP) > tolerance)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerable<PmmComparisonRow> MatchByReferenceAxialLoad(
        IReadOnlyList<PmmReferencePoint> references,
        IReadOnlyList<PmmCalculatedPoint> calculations,
        PmmComparisonOptions options,
        string matchMethod)
    {
        var curve = calculations
            .OrderBy(c => c.CalcP)
            .ThenBy(c => c.CalcM)
            .ToList();

        foreach (var reference in references)
        {
            var calculated = InterpolateAtReferenceP(reference, curve);
            var row = differenceCalculator.Calculate(reference, calculated, options) with { MatchMethod = matchMethod };
            yield return row;
        }
    }

    private static PmmCalculatedPoint InterpolateAtReferenceP(
        PmmReferencePoint reference,
        IReadOnlyList<PmmCalculatedPoint> curve)
    {
        if (curve.Count == 1)
        {
            return curve[0] with { PointIndex = reference.PointIndex };
        }

        if (reference.RefP <= curve[0].CalcP)
        {
            return curve[0] with { PointIndex = reference.PointIndex };
        }

        if (reference.RefP >= curve[^1].CalcP)
        {
            return curve[^1] with { PointIndex = reference.PointIndex };
        }

        for (int i = 0; i < curve.Count - 1; i++)
        {
            var lower = curve[i];
            var upper = curve[i + 1];
            if (reference.RefP < lower.CalcP || reference.RefP > upper.CalcP)
            {
                continue;
            }

            double span = upper.CalcP - lower.CalcP;
            if (Math.Abs(span) <= 1e-12)
            {
                var stronger = lower.CalcM >= upper.CalcM ? lower : upper;
                return stronger with { PointIndex = reference.PointIndex };
            }

            double t = (reference.RefP - lower.CalcP) / span;
            double interpolatedM = lower.CalcM + (upper.CalcM - lower.CalcM) * t;
            return new PmmCalculatedPoint(
                reference.ThetaDegrees,
                reference.PointIndex,
                reference.RefP,
                interpolatedM,
                0.0);
        }

        var nearest = curve.OrderBy(c => Math.Abs(c.CalcP - reference.RefP)).First();
        return nearest with { PointIndex = reference.PointIndex };
    }
}
