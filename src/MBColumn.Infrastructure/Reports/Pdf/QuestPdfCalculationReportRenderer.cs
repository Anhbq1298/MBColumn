using MBColumn.Application.Reports.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MBColumn.Infrastructure.Reports.Pdf;

public sealed class QuestPdfCalculationReportRenderer
{
    static QuestPdfCalculationReportRenderer()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void RenderToFile(ReportData data, string filePath)
    {
        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(15, Unit.Millimetre);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

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
                col.Item().Text(data.GeneratedAt).FontSize(8).FontColor("#888888");
            });
        });
    }

    private static void RenderContent(IContainer container, ReportData data)
    {
        container.Column(col =>
        {
            foreach (var section in data.Sections)
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
            }
        });
    }

    private static void RenderBlock(ColumnDescriptor col, ReportBlock block)
    {
        switch (block)
        {
            case HeadingBlock h:
                col.Item().PaddingTop(6)
                    .Text(h.Text).FontSize(10 + (3 - h.Level)).Bold();
                break;

            case ParagraphBlock p:
                col.Item().PaddingTop(4).Text(p.Text).FontSize(10);
                break;

            case NoteBlock n:
                col.Item().PaddingTop(4)
                    .Background("#FFF8DC").Padding(4)
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

            // Header row
            foreach (var h in headers)
                table.Header(hdr => hdr.Cell().Background("#1A3A5C").Padding(3)
                    .Text(h).FontColor(Colors.White).Bold().FontSize(9));

            // Data rows
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
}
