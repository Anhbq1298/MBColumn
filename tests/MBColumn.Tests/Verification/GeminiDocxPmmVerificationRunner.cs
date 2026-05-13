using System.Globalization;
using System.IO;
using System.Text;

namespace MBColumn.Tests.Verification;

public sealed class GeminiDocxPmmVerificationRunner
{
    private readonly DocxPmmReferenceReader reader = new();
    private readonly PmmReferenceMapper mapper = new();
    private readonly MbColumnPmmRunner mbColumnRunner = new();
    private readonly PmmPointMatcher matcher = new(new PmmDifferenceCalculator(), new PmmStatisticsCalculator());
    private readonly PmmChartGenerator chartGenerator = new();

    public PmmDocxComparisonResult Run(
        string docxPath,
        string csvOutputPath,
        PmmComparisonOptions? options = null,
        PmmRunOptions? runOptions = null)
    {
        options ??= new PmmComparisonOptions();
        runOptions ??= new PmmRunOptions();

        var reference = reader.Read(docxPath);
        var mapped = mapper.Map(reference);
        var calculated = mbColumnRunner.Run(mapped, runOptions);
        var projectedCalculated = ProjectMomentsToReferenceAxis(calculated);
        var comparisons = matcher.Match(reference.ReferencePoints, projectedCalculated, options);

        Directory.CreateDirectory(Path.GetDirectoryName(csvOutputPath) ?? ".");
        string actualCsvOutputPath = WriteComparisonCsv(csvOutputPath, comparisons);
        string chartDirectory = Path.Combine(Path.GetDirectoryName(actualCsvOutputPath) ?? ".", "charts");
        var chartOutputPaths = chartGenerator.GenerateFromCsv(actualCsvOutputPath, chartDirectory);
        string htmlOutputPath = chartGenerator.GenerateInteractiveHtmlFromCsv(
            actualCsvOutputPath,
            Path.Combine(Path.GetDirectoryName(actualCsvOutputPath) ?? ".", "PMM_Comparison_Interactive.html"));

        int totalMatched = comparisons.Sum(c => c.Rows.Count);
        int totalMissing = comparisons.Sum(c => c.MissingReferencePoints + c.MissingCalculatedPoints);
        int totalFailed = comparisons.Sum(c => c.Statistics.FailCount);
        double maxAbsDiffP = comparisons.Any() ? comparisons.Max(c => c.Statistics.MaxAbsDiffP) : 0.0;
        double maxAbsDiffM = comparisons.Any() ? comparisons.Max(c => c.Statistics.MaxAbsDiffM) : 0.0;

        var validationNotes = new List<string>();
        validationNotes.AddRange(reference.ExtractionNotes);
        validationNotes.AddRange(mapped.MappingNotes);
        validationNotes.Add($"MBColumn verification runner used {runOptions.NeutralAxisSamples} neutral-axis fiber samples and {runOptions.AngleStepDegrees} degree theta spacing.");
        validationNotes.Add("MBColumn Mx/My components are projected onto the reference N-vs-M moment axis before comparison.");
        validationNotes.AddRange(BuildMatchingNotes(comparisons));

        return new PmmDocxComparisonResult(
            reference,
            mapped,
            projectedCalculated,
            comparisons,
            actualCsvOutputPath,
            reference.ReferencePoints.Count,
            projectedCalculated.Count,
            totalMatched,
            totalMissing,
            totalFailed,
            maxAbsDiffP,
            maxAbsDiffM,
            chartOutputPaths,
            htmlOutputPath,
            validationNotes);
    }

    public static void PrintDebugOutput(PmmDocxComparisonResult result)
    {
        var reference = result.Reference;
        var mapped = result.MappedModel;

        Console.WriteLine();
        Console.WriteLine("=== Gemini DOCX PMM extraction and comparison ===");
        Console.WriteLine($"DOCX: {reference.SourcePath}");
        Console.WriteLine($"Section shape: {reference.SectionShape}");
        Console.WriteLine($"Section dimensions: {reference.WidthMm:F3} mm x {reference.HeightMm:F3} mm");
        Console.WriteLine($"Clear cover: {reference.ClearCoverMm:F3} mm");
        Console.WriteLine($"Bar centroid cover used in MBColumn coordinates: {mapped.BarCentroidCoverMm:F3} mm");
        Console.WriteLine($"Design code: {reference.DesignCode}");
        Console.WriteLine($"Units: {reference.UnitSystem}");
        Console.WriteLine($"Material strengths: fck = {reference.ConcreteStrengthMpa:F3} MPa, fyk = {reference.SteelYieldStrengthMpa:F3} MPa, Es = {reference.SteelElasticModulusMpa:F3} MPa");
        Console.WriteLine($"Reinforcement summary: {reference.VerticalReinforcement}, As = {reference.TotalRebarAreaMm2:F3} mm2, links = {reference.LinkDescription}");
        Console.WriteLine("Rebar coordinates:");
        foreach (var bar in mapped.RebarCoordinates)
        {
            Console.WriteLine($"  {bar.Id}: {bar.BarSizeLabel} x={bar.X:F3} mm, y={bar.Y:F3} mm, area={bar.Area:F3} mm2, side={bar.SourceSide}");
        }

        Console.WriteLine($"Theta list: {string.Join(", ", reference.ThetaDegrees)}");
        Console.WriteLine("Theta mapping:");
        foreach (var map in mapped.ReferenceToMbColumnTheta.OrderBy(m => m.Key))
        {
            Console.WriteLine($"  Reference theta {map.Key} deg -> MBColumn theta {map.Value} deg");
        }

        Console.WriteLine($"Reference total PM points: {result.TotalReferencePoints}");
        Console.WriteLine($"MBColumn generated PM points for reference theta set: {result.TotalCalculatedPoints}");
        Console.WriteLine($"Matched points: {result.TotalMatchedPoints}");
        Console.WriteLine($"Missing points: {result.TotalMissingPoints}");
        Console.WriteLine($"Mismatched/failed points: {result.TotalFailedPoints}");
        Console.WriteLine($"Max P difference: {result.MaxAbsDiffP:F6} kN");
        Console.WriteLine($"Max M difference: {result.MaxAbsDiffM:F6} kNm");
        Console.WriteLine($"Structured comparison CSV: {result.CsvOutputPath}");
        Console.WriteLine("Primary chart outputs:");
        foreach (string chart in result.ChartOutputPaths)
        {
            Console.WriteLine($"  {chart}");
        }

        Console.WriteLine($"Interactive HTML viewer: {result.HtmlOutputPath}");
        Console.WriteLine("Validation notes:");
        foreach (string note in result.ValidationNotes)
        {
            Console.WriteLine($"  - {note}");
        }
    }

    private static IReadOnlyList<string> BuildMatchingNotes(IReadOnlyList<PmmThetaComparison> comparisons)
    {
        var notes = new List<string>();
        foreach (var comparison in comparisons)
        {
            if (!string.Equals(comparison.MatchMethod, "Index", StringComparison.OrdinalIgnoreCase))
            {
                notes.Add($"Theta {comparison.ThetaDegrees}: MBColumn neutral-axis sample points did not align with reference axial-load levels, so MBColumn results were interpolated at the reference P levels without changing reference point order.");
            }

            if (comparison.MissingReferencePoints > 0 || comparison.MissingCalculatedPoints > 0)
            {
                notes.Add($"Theta {comparison.ThetaDegrees}: missing reference points = {comparison.MissingReferencePoints}, missing MBColumn points = {comparison.MissingCalculatedPoints}.");
            }

            if (comparison.Statistics.FailCount > 0)
            {
                notes.Add($"Theta {comparison.ThetaDegrees}: {comparison.Statistics.FailCount} point comparisons failed acceptance criteria.");
            }
        }

        return notes;
    }

    private static IReadOnlyList<PmmCalculatedPoint> ProjectMomentsToReferenceAxis(IReadOnlyList<PmmCalculatedPoint> calculated)
        => calculated.Select(point =>
        {
            double theta = point.ThetaDegrees * Math.PI / 180.0;
            double projectedMoment = Math.Abs(point.CalcMx * Math.Cos(theta) + point.CalcMy * Math.Sin(theta));
            return point with { CalcMx = projectedMoment, CalcMy = 0.0 };
        }).ToList();

    private static string WriteComparisonCsv(string path, IReadOnlyList<PmmThetaComparison> comparisons)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Theta,PointIndex,MatchMethod,MBColumnP_kN,MBColumnM_kNm,ReferenceP_kN,ReferenceM_kNm,DiffP_kN,DiffM_kNm,PercentDiffP,PercentDiffM,PPass,MPass,OverallPass");

        foreach (var theta in comparisons.OrderBy(c => c.ThetaDegrees))
        {
            foreach (var row in theta.Rows.OrderBy(r => r.PointIndex))
            {
                builder.Append(row.ThetaDegrees.ToString(CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.PointIndex.ToString(CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.MatchMethod).Append(',');
                builder.Append(row.CalcP.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.CalcM.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.RefP.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.RefM.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.DiffP.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.DiffM.ToString("G17", CultureInfo.InvariantCulture)).Append(',');
                builder.Append(row.PercentDiffP.HasValue ? row.PercentDiffP.Value.ToString("G17", CultureInfo.InvariantCulture) : "N/A").Append(',');
                builder.Append(row.PercentDiffM.HasValue ? row.PercentDiffM.Value.ToString("G17", CultureInfo.InvariantCulture) : "N/A").Append(',');
                builder.Append(row.PStatus).Append(',');
                builder.Append(row.MStatus).Append(',');
                builder.AppendLine(row.OverallStatus);
            }
        }

        string content = builder.ToString();
        try
        {
            File.WriteAllText(path, content, Encoding.UTF8);
            return path;
        }
        catch (IOException)
        {
            string directory = Path.GetDirectoryName(path) ?? ".";
            string fallbackPath = Path.Combine(
                directory,
                $"{Path.GetFileNameWithoutExtension(path)}_latest{Path.GetExtension(path)}");
            File.WriteAllText(fallbackPath, content, Encoding.UTF8);
            return fallbackPath;
        }
    }
}
