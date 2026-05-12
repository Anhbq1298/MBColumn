using System.Collections.Generic;

namespace MBColumn.Tests.Verification;

public sealed record PmmComparisonOptions(
    double PercentTolerance = 5.0,
    double AbsoluteAxialTolerance = 25.0,
    double AbsoluteMomentTolerance = 25.0,
    double ZeroReferenceThreshold = 1e-6);

public sealed record PmmReferencePoint(
    int ThetaDegrees,
    int PointIndex,
    double RefP,
    double RefMx,
    double RefMy)
{
    public double RefM => Math.Sqrt(RefMx * RefMx + RefMy * RefMy);
}

public sealed record PmmCalculatedPoint(
    int ThetaDegrees,
    int PointIndex,
    double CalcP,
    double CalcMx,
    double CalcMy)
{
    public double CalcM => Math.Sqrt(CalcMx * CalcMx + CalcMy * CalcMy);
}

public sealed record PmmComparisonRow(
    int PointIndex,
    int ThetaDegrees,
    double RefP,
    double CalcP,
    double DiffP,
    double? PercentDiffP,
    double RefM,
    double CalcM,
    double DiffM,
    double? PercentDiffM,
    bool PPass,
    bool MPass,
    bool OverallPass,
    string PStatus,
    string MStatus,
    string OverallStatus,
    string MatchMethod)
{
    public string PassFail => OverallPass ? "PASS" : "FAIL";
}

public sealed record PmmComparisonStatistics(
    double MeanPercentDiffP,
    double VariancePercentDiffP,
    double StandardDeviationPercentDiffP,
    double MeanPercentDiffM,
    double VariancePercentDiffM,
    double StandardDeviationPercentDiffM,
    double MaxAbsPercentDiffP,
    double MaxAbsPercentDiffM,
    double MaxAbsDiffP,
    double MaxAbsDiffM,
    int PassCount,
    int FailCount,
    int TotalPoints);

public sealed record PmmThetaComparison(
    int ThetaDegrees,
    string MatchMethod,
    IReadOnlyList<PmmComparisonRow> Rows,
    int MissingReferencePoints,
    int MissingCalculatedPoints,
    PmmComparisonStatistics Statistics);

public sealed record PmmComparisonReport(
    string Title,
    string GeneratedAt,
    string SectionSummary,
    string MaterialSummary,
    string ReinforcementSummary,
    string UnitSystem,
    string MomentDefinition,
    IReadOnlyList<PmmThetaComparison> ThetaComparisons,
    int TotalThetaCount,
    int TotalMatchedPoints,
    int TotalMissingPoints,
    int TotalFailedPoints,
    double OverallMeanPercentDiffP,
    double OverallMeanPercentDiffM,
    double OverallVariancePercentDiffP,
    double OverallVariancePercentDiffM,
    double OverallStandardDeviationPercentDiffP,
    double OverallStandardDeviationPercentDiffM,
    string OverallConclusion,
    IReadOnlyList<string> MismatchNotes,
    string FinalAnalysis);
