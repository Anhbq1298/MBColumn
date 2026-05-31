using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using MBColumn.Application.Reports.Models;

namespace MBColumn.Infrastructure.Reports.Pdf;

/// <summary>
/// Merges multiple individual column PDFs into a single compiled document
/// with a two-level Group → Column bookmark outline tree, with section
/// sub-bookmarks under each column.
/// </summary>
public static class PdfMergeUtility
{
    public static void MergePdfDocuments(
        List<(string TempPath, string GroupName, string ColumnName, ReportData Data)> sources,
        string outputPath)
    {
        using var output = new PdfDocument();
        output.Info.Title = "MB Column — Batch Calculation Report";

        string? lastGroup = null;
        PdfOutline? groupOutline = null;

        foreach (var (tempPath, groupName, columnName, data) in sources)
        {
            if (!File.Exists(tempPath)) continue;

            using var src = PdfReader.Open(tempPath, PdfDocumentOpenMode.Import);
            if (src.PageCount == 0) continue;

            int startPage = output.PageCount;
            var pages = new List<PdfPage>(src.PageCount);
            for (int i = 0; i < src.PageCount; i++)
                pages.Add(output.AddPage(src.Pages[i]));

            // Group bookmark (bold, reused across consecutive columns in same group)
            if (groupName != lastGroup)
            {
                groupOutline = output.Outlines.Add(
                    groupName, pages[0], true, PdfOutlineStyle.Bold);
                lastGroup = groupName;
            }

            // Column bookmark under group
            var colOutline = (groupOutline != null ? groupOutline.Outlines : output.Outlines).Add(
                columnName, pages[0], true);

            // Section sub-bookmarks (page positions estimated proportionally)
            for (int i = 0; i < data.Sections.Count; i++)
            {
                var section = data.Sections[i];
                int pageIdx = System.Math.Min(i, pages.Count - 1);
                colOutline.Outlines.Add(
                    $"{section.Number}  {section.Title}", pages[pageIdx], true);
            }
        }

        var dir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);

        output.Save(outputPath);
    }
}
