using MBColumn.Application.Reports.Models;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MBColumn.Infrastructure.Reports.Pdf;

public sealed class QuestPdfCalculationReportRenderer
{
    private const string ReportFont = "Inter";

    static QuestPdfCalculationReportRenderer()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        RegisterInterFont();
    }

    private static void RegisterInterFont()
    {
        try
        {
            string fontsDir = System.IO.Path.Combine(AppContext.BaseDirectory, "Resources", "Fonts");
            foreach (var file in new[] { "Inter-Regular.ttf", "Inter-Medium.ttf", "Inter-SemiBold.ttf", "Inter-Bold.ttf" })
            {
                string path = System.IO.Path.Combine(fontsDir, file);
                if (!System.IO.File.Exists(path)) continue;
                using var stream = System.IO.File.OpenRead(path);
                FontManager.RegisterFont(stream);
            }
        }
        catch { }
    }

    public void RenderToFile(ReportData data, string filePath)
    {
        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(15, Unit.Millimetre);
                page.DefaultTextStyle(x => x.FontSize(12).FontFamily(ReportFont));

                page.Header().Element(c => RenderHeader(c, data));
                page.Content().Element(c => RenderContent(c, data));
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
        });

        doc.GeneratePdf(filePath);
    }

    /// <summary>
    /// Injects a column-level bookmark with section sub-bookmarks into an
    /// already-generated PDF using PDFsharp. Call after RenderToFile().
    /// Page positions are estimated proportionally (one section per page assumed).
    /// </summary>
    public void AddBookmarks(string pdfPath, ReportData data, string columnName)
    {
        using var doc = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);
        if (doc.PageCount == 0) return;

        var colOutline = doc.Outlines.Add(columnName, doc.Pages[0], true);
        for (int i = 0; i < data.Sections.Count; i++)
        {
            var section = data.Sections[i];
            int pageIdx = System.Math.Min(i, doc.PageCount - 1);
            colOutline.Outlines.Add(
                $"{section.Number}  {section.Title}", doc.Pages[pageIdx], true);
        }

        doc.Save(pdfPath);
    }

    private static void RenderHeader(IContainer container, ReportData data)
    {
        container.BorderBottom(1).BorderColor("#1A3A5C").PaddingBottom(4).Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().Text("MB Column — Calculation Report")
                    .FontSize(14).Bold().FontColor("#1A3A5C");
                if (!string.IsNullOrEmpty(data.ProjectName))
                    col.Item().Text($"Project: {data.ProjectName}").FontSize(9);
                if (!string.IsNullOrEmpty(data.GroupName))
                    col.Item().Text($"Group: {data.GroupName}").FontSize(9);
            });
            row.ConstantItem(120).AlignRight().Column(col =>
            {
                col.Item().Text(data.GeneratedAt.ToString("yyyy-MM-dd HH:mm")).FontSize(8).FontColor("#888888");
            });
        });
    }

    private static void RenderContent(IContainer container, ReportData data)
    {
        container.Column(col =>
        {
            bool first = true;
            foreach (var section in data.Sections)
            {
                if (!first) col.Item().PageBreak();
                first = false;

                col.Item().PaddingTop(10).Column(secCol =>
                {
                    secCol.Item()
                        .BorderBottom(1).BorderColor("#1A3A5C")
                        .PaddingBottom(2)
                        .Text($"{section.Number}  {section.Title}")
                        .FontSize(14).Bold().FontColor("#1A3A5C");

                    foreach (var block in section.Blocks)
                        RenderBlock(secCol, block);
                });
            }
        });
    }

    private static void RenderBlock(ColumnDescriptor col, ReportBlock block)
    {
        switch (block)
        {
            case HeadingBlock h:
                col.Item().PaddingTop(6)
                    .Text(h.Text).FontSize(System.Math.Max(12, 14 - h.Level)).Bold();
                break;

            case ParagraphBlock p:
                col.Item().PaddingTop(4).Text(p.Text).FontSize(12);
                break;

            case NoteBlock n:
                col.Item().PaddingTop(4)
                    .Background("#FFF8DC").Padding(4)
                    .Text(n.Text).FontSize(12).Italic();
                break;

            case TableBlock t:
                RenderTable(col, null, t.Headers, t.Rows);
                break;

            case SteelTableBlock st:
                RenderSteelTable(col, st);
                break;

            case ImageBlock img:
                col.Item().PaddingTop(4).AlignCenter()
                    .Text("[Section Geometry — see HTML export for SVG]").FontSize(12).Italic().FontColor("#888");
                if (!string.IsNullOrEmpty(img.Caption))
                    col.Item().AlignCenter().Text(img.Caption).FontSize(12).Italic().FontColor("#555");
                break;

            case DiagramBlock diag:
                col.Item().PaddingTop(4).AlignCenter()
                    .Text($"[Diagram — {diag.Caption}]").FontSize(12).Italic().FontColor("#888");
                break;

            case SummaryBoxBlock sum:
                col.Item().PaddingTop(6).Background(sum.IsPass ? "#EAFAF1" : "#FDEDEC")
                    .Border(1).BorderColor(sum.IsPass ? "#27AE60" : "#E74C3C").Padding(8)
                    .Column(inner =>
                    {
                        inner.Item().Text(sum.Label).Bold().FontSize(14)
                            .FontColor(sum.IsPass ? "#1E8449" : "#C0392B");
                        if (!string.IsNullOrWhiteSpace(sum.Value))
                            inner.Item().Text(sum.Value).FontSize(12);
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

    private static void RenderSteelTable(ColumnDescriptor col, SteelTableBlock st)
    {
        string[] headers = ["#", "x (mm)", "y (mm)", "d (mm)", "εs", "fs (MPa)", "As (mm²)", "Fs (kN)", "Fs·y (kN·m)", "Fs·x (kN·m)"];
        var rows = st.Rows.Select(r => new[] { r.Index.ToString(), r.XMm, r.YMm, r.DMm, r.EpsilonS, r.FsMpa, r.AsMm2, r.FsKn, r.FsYKnm, r.FsXKnm }).ToArray();
        RenderTable(col, null, headers, rows);
        if (!string.IsNullOrEmpty(st.SumFs))
            col.Item().PaddingTop(2).Text($"ΣFs = {st.SumFs} kN   ΣFs·y = {st.SumFsY} kN·m   ΣFs·x = {st.SumFsX} kN·m").FontSize(12).Italic();
    }

    private static void RenderTable(ColumnDescriptor col, string? caption, string[] headers, string[][] rows)
    {
        if (!string.IsNullOrEmpty(caption))
            col.Item().PaddingTop(6).Text(caption).FontSize(12).Italic().FontColor("#555");

        col.Item().PaddingTop(2).Table(table =>
        {
            table.ColumnsDefinition(cd =>
            {
                foreach (var _ in headers)
                    cd.RelativeColumn();
            });

            // Header row
            foreach (var h in headers)
                table.Header(hdr => hdr.Cell().Background("#1A3A5C").Padding(3)
                    .Text(h).FontColor(Colors.White).Bold().FontSize(10));

            // Data rows
            bool alt = false;
            foreach (var row in rows)
            {
                string bg = alt ? "#F5F7FA" : Colors.White;
                foreach (var cell in row)
                    table.Cell().Background(bg).BorderBottom(1).BorderColor("#DDDDDD").Padding(3)
                        .Text(cell).FontSize(10);
                alt = !alt;
            }
        });
    }
}
