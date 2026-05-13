using System.Collections.Generic;
using MBColumn.Application.DTOs;

namespace MBColumn.Tests.Verification;

public sealed record PmmComparisonOptions(
    double PercentTolerance = 5.0,
    double AbsoluteAxialTolerance = 25.0,
    double AbsoluteMomentTolerance = 25.0,
    double ZeroReferenceThreshold = 1e-6);

public sealed record PmmRunOptions(
    int NeutralAxisSamples = 100,
    int AngleStepDegrees = 1,
    PmmVerificationSolverKind SolverKind = PmmVerificationSolverKind.AnalyticParabolicFiber);

public enum PmmVerificationSolverKind
{
    AnalyticParabolicFiber,
    GridParabolicFiber,
    BoundaryParabolic,
    SimplifiedStressBlock
}

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

public sealed record DocxPmmReferenceData(
    string SourcePath,
    string SectionShape,
    double WidthMm,
    double HeightMm,
    double ClearCoverMm,
    string DesignCode,
    string UnitSystem,
    double ConcreteStrengthMpa,
    double SteelYieldStrengthMpa,
    double SteelElasticModulusMpa,
    string VerticalReinforcement,
    int BarCount,
    string BarSize,
    double BarDiameterMm,
    double TotalRebarAreaMm2,
    string LinkDescription,
    double? LinkDiameterMm,
    string BarArrangement,
    IReadOnlyList<int> ThetaDegrees,
    int ExpectedPointCountPerTheta,
    double ReferenceAxialStartKn,
    double ReferenceAxialEndKn,
    string ReferenceMomentUnit,
    string ReferenceMomentDefinition,
    string ReferenceSignConvention,
    IReadOnlyList<PmmReferencePoint> ReferencePoints,
    IReadOnlyList<string> ExtractionNotes);

public sealed record PmmMappedReferenceModel(
    DocxPmmReferenceData Reference,
    ColumnInputDto Input,
    IReadOnlyList<RebarCoordinateDto> RebarCoordinates,
    double BarCentroidCoverMm,
    double AlphaCc,
    IReadOnlyDictionary<int, int> ReferenceToMbColumnTheta,
    IReadOnlyList<string> MappingNotes);

public sealed record PmmDocxComparisonResult(
    DocxPmmReferenceData Reference,
    PmmMappedReferenceModel MappedModel,
    IReadOnlyList<PmmCalculatedPoint> CalculatedPoints,
    IReadOnlyList<PmmThetaComparison> ThetaComparisons,
    string CsvOutputPath,
    int TotalReferencePoints,
    int TotalCalculatedPoints,
    int TotalMatchedPoints,
    int TotalMissingPoints,
    int TotalFailedPoints,
    double MaxAbsDiffP,
    double MaxAbsDiffM,
    IReadOnlyList<string> ChartOutputPaths,
    string HtmlOutputPath,
    IReadOnlyList<string> ValidationNotes);
