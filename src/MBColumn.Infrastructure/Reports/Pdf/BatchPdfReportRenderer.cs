using MBColumn.Application.Reports.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MBColumn.Infrastructure.Reports.Pdf;

/// <summary>
/// Renders column reports to individual files or a combined PDF with nested PDF outline bookmarks.
/// </summary>
public sealed class BatchPdfReportRenderer
{
    static BatchPdfReportRenderer()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public sealed record ColumnEntry(string? GroupName, string ColumnName, ReportData ReportData);

    // ── Public API ───────────────────────────────────────────────────────────

    /// <summary>Renders a single column's report with flat PDF bookmarks per section.</summary>
    public void RenderIndividual(ReportData data, string filePath)
    {
        var sectionPdfs = data.Sections
            .Select(s => (Section: s, Bytes: RenderSectionToBytes(data, s)))
            .ToList();

        MergeAndSave(sectionPdfs.Select(x => x.Bytes).ToList(), filePath,
            (doc, starts) =>
            {
                for (int i = 0; i < sectionPdfs.Count; i++)
                {
                    var sec = sectionPdfs[i].Section;
                    doc.Outlines.Add($"{sec.Number}  {sec.Title}", doc.Pages[starts[i]], true);
                }
            });
    }

    /// <summary>
    /// Renders all provided column reports into one combined PDF with nested bookmarks:
    /// Group (bold) → Column → Section.
    /// </summary>
    public void RenderCombined(IReadOnlyList<ColumnEntry> entries, string filePath)
    {
        // Flatten all sections in document order, preserving entry association
        var flatSections = new List<(ColumnEntry Entry, ReportSection Section, byte[] Bytes)>();
        foreach (var entry in entries)
        {
            foreach (var section in entry.ReportData.Sections)
                flatSections.Add((entry, section, RenderSectionToBytes(entry.ReportData, section)));
        }

        MergeAndSave(flatSections.Select(x => x.Bytes).ToList(), filePath,
            (doc, starts) => BuildNestedOutlines(doc, entries, flatSections, starts));
    }

    // ── QuestPDF rendering ───────────────────────────────────────────────────

    private static byte[] RenderSectionToBytes(ReportData data, ReportSection section)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(15, Unit.Millimetre);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                page.Header().Element(c => RenderHeader(c, data));
                page.Content().Element(c => RenderSingleSection(c, section));
                // No QuestPDF footer — global page numbers are added by PdfSharp after merge
            });
        }).GeneratePdf();
    }

    private static void RenderHeader(IContainer container, ReportData data)
    {
        container.BorderBottom(1).BorderColor("#1A3A5C").PaddingBottom(4).Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().Text("MB Column — Calculation Report")
                    .FontSize(13).Bold().FontColor("#1A3A5C");
                if (!string.IsNullOrEmpty(data.ProjectName))
                    col.Item().Text($"Project: {data.ProjectName}").FontSize(9);
                if (!string.IsNullOrEmpty(data.GroupName))
                    col.Item().Text($"Group: {data.GroupName}").FontSize(9);
                if (!string.IsNullOrEmpty(data.DesignTierName))
                    col.Item().Text($"Section: {data.DesignTierName}").FontSize(9);
            });
            row.ConstantItem(120).AlignRight().Column(col =>
            {
                col.Item().Text(data.GeneratedAt).FontSize(8).FontColor("#888888");
            });
        });
    }

    private static void RenderSingleSection(IContainer container, ReportSection section)
    {
        container.Column(col =>
        {
            col.Item().PaddingTop(10).Column(secCol =>
            {
                secCol.Item()
                    .BorderBottom(1).BorderColor("#1A3A5C")
                    .PaddingBottom(2)
                    .Text($"{section.Number}  {section.Title}")
                    .FontSize(12).Bold().FontColor("#1A3A5C");

                foreach (var block in section.Blocks)
                    RenderBlock(secCol, block);
            });
        });
    }

    private static void RenderBlock(ColumnDescriptor col, ReportBlock block)
    {
        switch (block)
        {
            case HeadingBlock h:
                col.Item().PaddingTop(6).Text(h.Text).FontSize(10 + (3 - h.Level)).Bold();
                break;

            case ParagraphBlock p:
                col.Item().PaddingTop(4).Text(p.Text).FontSize(10);
                break;

            case NoteBlock n:
                col.Item().PaddingTop(4).Background("#FFF8DC").Padding(4)
                    .Text(n.Text).FontSize(9).Italic();
                break;

            case TableBlock t:
                RenderTable(col, t.Caption, t.Headers, t.Rows);
                break;

            case SteelTableBlock st:
                RenderTable(col, st.Caption, st.Headers, st.Rows);
                break;

            case ImageBlock img:
                col.Item().PaddingTop(4).AlignCenter()
                    .Text("[Section Geometry — see HTML export for SVG]").FontSize(9).Italic().FontColor("#888");
                if (!string.IsNullOrEmpty(img.Caption))
                    col.Item().AlignCenter().Text(img.Caption).FontSize(8).Italic().FontColor("#555");
                break;

            case DiagramBlock diag:
                col.Item().PaddingTop(4).AlignCenter()
                    .Text($"[Diagram — {diag.Caption}]").FontSize(9).Italic().FontColor("#888");
                break;

            case SummaryBoxBlock sum:
                col.Item().PaddingTop(6).Background("#F0F4FF").Border(1).BorderColor("#1A3A5C").Padding(8)
                    .Column(inner =>
                    {
                        inner.Item().Text(sum.Title).Bold().FontSize(11);
                        inner.Item().Text($"Status: {sum.Status}   UR: {sum.Ratio:0.###}").FontSize(10);
                        foreach (var (label, value) in sum.Entries)
                            inner.Item().Text($"  {label}: {value}").FontSize(9);
                    });
                break;

            case DividerBlock:
                col.Item().PaddingTop(4).LineHorizontal(0.5f).LineColor("#CCCCCC");
                break;

            case PageBreakBlock:
                col.Item().PageBreak();
                break;
        }
    }

    private static void RenderTable(ColumnDescriptor col, string caption, string[] headers, string[][] rows)
    {
        if (!string.IsNullOrEmpty(caption))
            col.Item().PaddingTop(6).Text(caption).FontSize(9).Italic().FontColor("#555");

        col.Item().PaddingTop(2).Table(table =>
        {
            table.ColumnsDefinition(cd =>
            {
                foreach (var _ in headers)
                    cd.RelativeColumn();
            });

            foreach (var h in headers)
                table.Header(hdr => hdr.Cell().Background("#1A3A5C").Padding(3)
                    .Text(h).FontColor(Colors.White).Bold().FontSize(9));

            bool alt = false;
            foreach (var row in rows)
            {
                string bg = alt ? "#F5F7FA" : Colors.White;
                foreach (var cell in row)
                    table.Cell().Background(bg).BorderBottom(1).BorderColor("#DDDDDD").Padding(3)
                        .Text(cell).FontSize(9);
                alt = !alt;
            }
        });
    }

    // ── PdfSharp merge + bookmarks ───────────────────────────────────────────

    /// <summary>
    /// Merges section byte arrays into one PdfDocument, adds global page numbers,
    /// then invokes the caller-supplied bookmark builder.
    /// </summary>
    private static void MergeAndSave(
        List<byte[]> sectionBytes,
        string filePath,
        Action<PdfDocument, int[]> addBookmarks)
    {
        using var merged = new PdfDocument();
        merged.Info.Title = "MB Column — Calculation Report";

        var pageStarts = new int[sectionBytes.Count];
        var sourceDocs = new List<PdfDocument>(sectionBytes.Count);

        try
        {
            int currentPage = 0;
            for (int i = 0; i < sectionBytes.Count; i++)
            {
                pageStarts[i] = currentPage;

                var ms = new MemoryStream(sectionBytes[i]);
                var src = PdfReader.Open(ms, PdfDocumentOpenMode.Import);
                sourceDocs.Add(src);

                for (int p = 0; p < src.PageCount; p++)
                    merged.AddPage(src.Pages[p]);

                currentPage += src.PageCount;
            }

            AddPageNumbers(merged);
            addBookmarks(merged, pageStarts);

            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            merged.Save(filePath);
        }
        finally
        {
            foreach (var doc in sourceDocs)
                doc.Dispose();
        }
    }

    private static void AddPageNumbers(PdfDocument doc)
    {
        var font = new XFont("Arial", 8);
        var brush = XBrushes.Gray;
        var format = new XStringFormat
        {
            Alignment = XStringAlignment.Center,
            LineAlignment = XLineAlignment.Near
        };
        int total = doc.PageCount;

        for (int i = 0; i < total; i++)
        {
            var page = doc.Pages[i];
            using var gfx = XGraphics.FromPdfPage(page);
            // 15 points from bottom edge (≈5mm), centred horizontally
            gfx.DrawString(
                $"Page {i + 1} / {total}",
                font, brush,
                new XPoint(page.Width.Point / 2, page.Height.Point - 15),
                format);
        }
    }

    private static void BuildNestedOutlines(
        PdfDocument doc,
        IReadOnlyList<ColumnEntry> entries,
        List<(ColumnEntry Entry, ReportSection Section, byte[] Bytes)> flatSections,
        int[] pageStarts)
    {
        int sectionIndex = 0;
        var groupOutlines = new Dictionary<string, PdfOutline>();

        foreach (var entry in entries)
        {
            int sectionCount = entry.ReportData.Sections.Count;
            int columnFirstPage = pageStarts[sectionIndex];

            // Create or reuse group-level bookmark
            PdfOutline columnOutline;
            if (entry.GroupName is not null)
            {
                if (!groupOutlines.TryGetValue(entry.GroupName, out var groupOutline))
                {
                    groupOutline = doc.Outlines.Add(entry.GroupName, doc.Pages[columnFirstPage], true);
                    groupOutlines[entry.GroupName] = groupOutline;
                }
                columnOutline = groupOutline.Outlines.Add(entry.ColumnName, doc.Pages[columnFirstPage], true);
            }
            else
            {
                columnOutline = doc.Outlines.Add(entry.ColumnName, doc.Pages[columnFirstPage], true);
            }

            // Section-level bookmarks nested under the column
            for (int s = 0; s < sectionCount; s++)
            {
                var sec = entry.ReportData.Sections[s];
                columnOutline.Outlines.Add(
                    $"{sec.Number}  {sec.Title}",
                    doc.Pages[pageStarts[sectionIndex + s]],
                    false);
            }

            sectionIndex += sectionCount;
        }
    }
}
