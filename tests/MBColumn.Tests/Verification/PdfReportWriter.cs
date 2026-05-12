using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MBColumn.Tests.Verification;

public sealed class PdfReportWriter
{
    public void Write(string outputPath, PmmComparisonReport report)
    {
        var pages = BuildPages(report);
        WritePdf(outputPath, pages);
    }

    private static IReadOnlyList<string> BuildPages(PmmComparisonReport report)
    {
        var pages = new List<string>();
        pages.Add(BuildCoverPage(report));
        pages.Add(BuildSummaryPage(report));

        foreach (var theta in report.ThetaComparisons)
        {
            pages.AddRange(BuildThetaPages(report, theta));
        }

        pages.Add(BuildFinalAnalysisPage(report));
        return pages;
    }

    private static string BuildCoverPage(PmmComparisonReport report)
    {
        var lines = new List<string>
        {
            report.Title,
            "",
            $"Generated: {report.GeneratedAt}",
            "",
            "Section summary:",
            report.SectionSummary,
            "",
            "Material summary:",
            report.MaterialSummary,
            "",
            "Reinforcement summary:",
            report.ReinforcementSummary,
            "",
            $"Unit system: {report.UnitSystem}",
            report.MomentDefinition
        };

        return string.Join("\n", lines);
    }

    private static string BuildSummaryPage(PmmComparisonReport report)
    {
        var lines = new List<string>
        {
            "Summary",
            "",
            $"Theta angles compared: {report.TotalThetaCount}",
            $"Total matched points: {report.TotalMatchedPoints}",
            $"Total missing points: {report.TotalMissingPoints}",
            $"Total failed points: {report.TotalFailedPoints}",
            "",
            $"Overall average %DiffP: {report.OverallMeanPercentDiffP:F3}",
            $"Overall average %DiffM: {report.OverallMeanPercentDiffM:F3}",
            $"Overall variance %DiffP: {report.OverallVariancePercentDiffP:F4}",
            $"Overall variance %DiffM: {report.OverallVariancePercentDiffM:F4}",
            $"Overall standard deviation %DiffP: {report.OverallStandardDeviationPercentDiffP:F4}",
            $"Overall standard deviation %DiffM: {report.OverallStandardDeviationPercentDiffM:F4}",
            "",
            $"Overall conclusion: {report.OverallConclusion}",
            "",
            "Mismatch / Missing Data:",
        };

        lines.AddRange(report.MismatchNotes);
        return string.Join("\n", lines);
    }

    private static IEnumerable<string> BuildThetaPages(PmmComparisonReport report, PmmThetaComparison theta)
    {
        const int maxRowsPerPage = 32;
        var header = new[]
        {
            $"Theta = {theta.ThetaDegrees}°   MatchMethod: {theta.MatchMethod}",
            "Point  RefP(kN)  CalcP(kN)  DiffP(kN)  %DiffP  RefM(kNm)  CalcM(kNm)  DiffM(kNm)  %DiffM  P  M  Status"
        };

        var pageLines = new List<string>();
        pageLines.AddRange(header);

        int rowCount = 0;
        foreach (var row in theta.Rows)
        {
            if (rowCount >= maxRowsPerPage)
            {
                pageLines.AddRange(BuildThetaSummaryLines(theta));
                yield return string.Join("\n", pageLines);
                pageLines = new List<string>(header);
                rowCount = 0;
            }

            pageLines.Add(FormatThetaRow(row));
            rowCount++;
        }

        pageLines.AddRange(BuildThetaSummaryLines(theta));
        if (theta.MissingReferencePoints > 0)
        {
            pageLines.Add($"Missing reference points: {theta.MissingReferencePoints}");
        }

        if (theta.MissingCalculatedPoints > 0)
        {
            pageLines.Add($"Missing calculated points: {theta.MissingCalculatedPoints}");
        }

        yield return string.Join("\n", pageLines);
    }

    private static IEnumerable<string> BuildThetaSummaryLines(PmmThetaComparison theta)
    {
        return new[]
        {
            "",
            $"Mean %DiffP: {theta.Statistics.MeanPercentDiffP:F3}",
            $"Variance %DiffP: {theta.Statistics.VariancePercentDiffP:F4}",
            $"StdDev %DiffP: {theta.Statistics.StandardDeviationPercentDiffP:F4}",
            $"Mean %DiffM: {theta.Statistics.MeanPercentDiffM:F3}",
            $"Variance %DiffM: {theta.Statistics.VariancePercentDiffM:F4}",
            $"StdDev %DiffM: {theta.Statistics.StandardDeviationPercentDiffM:F4}",
            $"Max abs %DiffP: {theta.Statistics.MaxAbsPercentDiffP:F3}",
            $"Max abs %DiffM: {theta.Statistics.MaxAbsPercentDiffM:F3}",
            $"Max abs DiffP: {theta.Statistics.MaxAbsDiffP:F3}",
            $"Max abs DiffM: {theta.Statistics.MaxAbsDiffM:F3}",
            $"PASS points: {theta.Statistics.PassCount}",
            $"FAIL points: {theta.Statistics.FailCount}",
            ""
        };
    }

    private static string BuildFinalAnalysisPage(PmmComparisonReport report)
    {
        var lines = new List<string>
        {
            "Final Analysis",
            "",
            report.FinalAnalysis
        };

        return string.Join("\n", lines);
    }

    private static string FormatThetaRow(PmmComparisonRow row)
    {
        string pctP = row.PercentDiffP.HasValue ? row.PercentDiffP.Value.ToString("F3", CultureInfo.InvariantCulture) : "N/A";
        string pctM = row.PercentDiffM.HasValue ? row.PercentDiffM.Value.ToString("F3", CultureInfo.InvariantCulture) : "N/A";
        string pPass = row.PPass ? "PASS" : "FAIL";
        string mPass = row.MPass ? "PASS" : "FAIL";
        string overall = row.OverallPass ? "PASS" : "FAIL";

        return string.Format(
            CultureInfo.InvariantCulture,
            "{0,5}  {1,8:F3}  {2,9:F3}  {3,9:F3}  {4,7}  {5,9:F3}  {6,10:F3}  {7,9:F3}  {8,7}  {9,3}  {10,3}  {11}",
            row.PointIndex,
            row.RefP,
            row.CalcP,
            row.DiffP,
            pctP,
            row.RefM,
            row.CalcM,
            row.DiffM,
            pctM,
            pPass,
            mPass,
            overall);
    }

    private static void WritePdf(string outputPath, IReadOnlyList<string> pages)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        using var stream = File.Create(outputPath);
        using var writer = new StreamWriter(stream, Encoding.ASCII, leaveOpen: true) { AutoFlush = true };

        var pageContents = pages.Select(CreatePageContent).ToList();
        var pageIds = new List<int>();
        var contentIds = new List<int>();

        int catalogId = 1;
        int pagesId = 2;
        int fontId = 3;
        int nextId = 4;

        for (int i = 0; i < pages.Count; i++)
        {
            pageIds.Add(nextId++);
            contentIds.Add(nextId++);
        }

        var objects = new List<string>
        {
            BuildObject(catalogId, $"<< /Type /Catalog /Pages {pagesId} 0 R >>"),
            BuildObject(pagesId, $"<< /Type /Pages /Kids [{string.Join(' ', pageIds.Select(id => id + " 0 R"))}] /Count {pages.Count} >>"),
            BuildObject(fontId, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>")
        };

        for (int i = 0; i < pages.Count; i++)
        {
            objects.Add(BuildObject(contentIds[i], EncodeStream(pageContents[i])));
            objects.Add(BuildObject(pageIds[i], $"<< /Type /Page /Parent {pagesId} 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 {fontId} 0 R >> >> /Contents {contentIds[i]} 0 R >>"));
        }

        var xrefOffsets = new List<long>();
        long currentOffset = 0;

        foreach (var obj in objects)
        {
            xrefOffsets.Add(currentOffset);
            writer.WriteLine(obj);
            currentOffset = stream.Position;
        }

        long xrefStart = currentOffset;
        writer.WriteLine("xref");
        writer.WriteLine($"0 {objects.Count + 1}");
        writer.WriteLine("0000000000 65535 f ");
        foreach (var offset in xrefOffsets)
        {
            writer.WriteLine(offset.ToString("D10") + " 00000 n ");
        }

        writer.WriteLine("trailer");
        writer.WriteLine($"<< /Size {objects.Count + 1} /Root {catalogId} 0 R >>");
        writer.WriteLine("startxref");
        writer.WriteLine(xrefStart);
        writer.WriteLine("%%EOF");
    }

    private static byte[] CreatePageContent(string pageText)
    {
        var builder = new StringBuilder();
        builder.AppendLine("BT");
        builder.AppendLine("/F1 10 Tf");
        builder.AppendLine("1 0 0 1 40 800 Tm");
        foreach (var line in pageText.Split('\n'))
        {
            builder.AppendLine($"({EscapePdfString(line)}) Tj");
            builder.AppendLine("0 -12 Td");
        }

        builder.AppendLine("ET");
        return Encoding.ASCII.GetBytes(builder.ToString());
    }

    private static string EscapePdfString(string text)
        => text.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)");

    private static string EncodeStream(byte[] data)
        => $"<< /Length {data.Length} >>\nstream\n{Encoding.ASCII.GetString(data)}\nendstream";

    private static string BuildObject(int id, string data)
        => $"{id} 0 obj\n{data}\nendobj";
}
