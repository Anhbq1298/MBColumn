using System.Globalization;
using System.IO;
using System.Text;

namespace MBColumn.Tests.Verification;

public static class InternalAciEcPdfReportWriter
{
    private const double PageWidth = 595.0;
    private const double PageHeight = 842.0;

    public static void Write(string outputPath, IReadOnlyList<InternalCodeAngleSummary> summaries)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        var pages = new[]
        {
            BuildInputAndSectionPage(),
            BuildComparisonTablePage(summaries)
        };

        WritePdf(outputPath, pages);
    }

    private static string BuildInputAndSectionPage()
    {
        var c = new PdfCanvas();
        c.Text(40, 800, "MBColumn Internal ACI vs Eurocode Report", 16, bold: true);
        c.Text(40, 780, "Same section configuration, two MBColumn design-code paths.", 10);

        c.Text(40, 742, "Input Information", 13, bold: true);
        var inputs = new[]
        {
            "Section: Rectangular, width = 1200 mm, depth = 500 mm",
            "Concrete input: 32 MPa",
            "Steel input: 500 MPa, Es = 200000 MPa",
            "Cover: 40 mm to longitudinal bar surface",
            "Bar size: T20, diameter = 20 mm",
            "Layout: top 7, bottom 7, left 3 intermediate, right 3 intermediate",
            "ACI path: ACI 318-style conventional solver, phi = 0.65 to 0.90, compression cap = 0.80 * max(phi Pn)",
            "Eurocode path: EC2 fiber solver, fyk / 1.15, alpha_cc / gamma_c with alpha_cc = 0.85, phi = 1.0"
        };

        double y = 722;
        foreach (string line in inputs)
        {
            c.Text(54, y, "- " + line, 9);
            y -= 16;
        }

        c.Text(40, 570, "Cross Section", 13, bold: true);
        DrawSection(c, 92, 330, 410, 170);
        c.Text(98, 312, "Rebar centroids: x = +/-550 mm, y = +/-200 mm. Corners are shared by top/bottom rows.", 9);
        c.Text(98, 296, "This is the same MBColumn placement logic used by the comparison export.", 9);

        c.Text(40, 250, "Report Contents", 13, bold: true);
        c.Text(54, 230, "- Page 1: input data and cross-section sketch.", 9);
        c.Text(54, 214, "- Page 2: comparison table for five PM angles.", 9);
        c.Text(54, 198, "- Companion CSV contains 100 exported PM points per code per angle.", 9);
        return c.Content;
    }

    private static string BuildComparisonTablePage(IReadOnlyList<InternalCodeAngleSummary> summaries)
    {
        var c = new PdfCanvas();
        c.Text(40, 800, "Comparison Table", 16, bold: true);
        c.Text(40, 780, "Design PM envelope summary from 100-point resampled curves.", 10);

        double x = 40;
        double y = 735;
        double[] widths = [50, 78, 78, 82, 88, 88, 92];
        string[] headers = ["Angle", "ACI Pmax", "EC Pmax", "EC-ACI P", "ACI max M", "EC max M", "EC-ACI M"];
        DrawTableRow(c, x, y, widths, headers, header: true);
        y -= 24;

        foreach (var s in summaries)
        {
            string[] values =
            [
                s.AngleDegrees.ToString("F0", CultureInfo.InvariantCulture),
                s.AciPMax.ToString("F1", CultureInfo.InvariantCulture),
                s.EcPMax.ToString("F1", CultureInfo.InvariantCulture),
                s.PMaxDiff.ToString("F1", CultureInfo.InvariantCulture),
                s.AciMaxAbsM.ToString("F1", CultureInfo.InvariantCulture),
                s.EcMaxAbsM.ToString("F1", CultureInfo.InvariantCulture),
                s.MaxAbsMDiff.ToString("F1", CultureInfo.InvariantCulture)
            ];
            DrawTableRow(c, x, y, widths, values, header: false);
            y -= 24;
        }

        c.Text(40, 565, "Units", 12, bold: true);
        c.Text(54, 547, "P values are kN. M values are kN-m using the selected PM angle projection Mtheta.", 9);

        c.Text(40, 514, "Engineering Reading", 12, bold: true);
        c.Text(54, 496, "Eurocode Pmax is higher here because this MBColumn EC path uses material factors and no ACI 0.80 tied-column cap.", 9);
        c.Text(54, 480, "Moment capacity does not shift by a constant ratio; it varies by angle because the stress block, strain limit, and steel design strength differ.", 9);
        c.Text(54, 464, "The exported overlay chart should be used with the CSV for point-by-point visual review.", 9);

        return c.Content;
    }

    private static void DrawSection(PdfCanvas c, double x, double y, double width, double height)
    {
        c.SetStroke(0.12, 0.18, 0.26);
        c.SetFill(0.96, 0.98, 1.0);
        c.Rect(x, y, width, height, fill: true, stroke: true);

        double coverX = 40.0 / 1200.0 * width;
        double coverY = 40.0 / 500.0 * height;
        c.SetStroke(0.58, 0.64, 0.72);
        c.Rect(x + coverX, y + coverY, width - 2 * coverX, height - 2 * coverY, fill: false, stroke: true);

        double ToX(double sectionX) => x + (sectionX + 600.0) / 1200.0 * width;
        double ToY(double sectionY) => y + (sectionY + 250.0) / 500.0 * height;
        double r = Math.Max(3.2, 20.0 / 1200.0 * width / 2.0);

        var bars = new List<(double X, double Y)>();
        for (int i = 0; i < 7; i++)
        {
            double bx = -550.0 + i * (1100.0 / 6.0);
            bars.Add((bx, 200.0));
            bars.Add((bx, -200.0));
        }

        foreach (double by in new[] { -100.0, 0.0, 100.0 })
        {
            bars.Add((-550.0, by));
            bars.Add((550.0, by));
        }

        c.SetFill(0.12, 0.37, 0.62);
        c.SetStroke(0.05, 0.16, 0.27);
        foreach (var bar in bars)
        {
            c.Circle(ToX(bar.X), ToY(bar.Y), r, fill: true, stroke: true);
        }

        c.SetStroke(0.1, 0.1, 0.1);
        c.Line(x, y - 18, x + width, y - 18);
        c.Text(x + width / 2 - 38, y - 34, "1200 mm", 9);
        c.Line(x - 18, y, x - 18, y + height);
        c.Text(x - 52, y + height / 2, "500 mm", 9);

        c.Text(x, y + height + 16, "20 T20 bars total", 9, bold: true);
    }

    private static void DrawTableRow(PdfCanvas c, double x, double y, double[] widths, string[] values, bool header)
    {
        double rowHeight = 22;
        double cursor = x;
        c.SetFill(header ? 0.90 : 1.0, header ? 0.93 : 1.0, header ? 0.97 : 1.0);
        c.SetStroke(0.72, 0.76, 0.82);
        for (int i = 0; i < widths.Length; i++)
        {
            c.Rect(cursor, y - rowHeight, widths[i], rowHeight, fill: true, stroke: true);
            c.Text(cursor + 4, y - 15, values[i], header ? 7.5 : 8, bold: header);
            cursor += widths[i];
        }
    }

    private static void WritePdf(string outputPath, IReadOnlyList<string> pages)
    {
        using var stream = File.Create(outputPath);
        using var writer = new StreamWriter(stream, Encoding.ASCII, leaveOpen: true) { AutoFlush = true };

        writer.WriteLine("%PDF-1.4");

        var pageIds = new List<int>();
        var contentIds = new List<int>();
        int catalogId = 1;
        int pagesId = 2;
        int fontId = 3;
        int boldFontId = 4;
        int nextId = 5;

        for (int i = 0; i < pages.Count; i++)
        {
            pageIds.Add(nextId++);
            contentIds.Add(nextId++);
        }

        var objects = new List<string>
        {
            BuildObject(catalogId, $"<< /Type /Catalog /Pages {pagesId} 0 R >>"),
            BuildObject(pagesId, $"<< /Type /Pages /Kids [{string.Join(' ', pageIds.Select(id => id + " 0 R"))}] /Count {pages.Count} >>"),
            BuildObject(fontId, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>"),
            BuildObject(boldFontId, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold >>")
        };

        for (int i = 0; i < pages.Count; i++)
        {
            objects.Add(BuildObject(contentIds[i], EncodeStream(Encoding.ASCII.GetBytes(pages[i]))));
            objects.Add(BuildObject(pageIds[i], $"<< /Type /Page /Parent {pagesId} 0 R /MediaBox [0 0 {PageWidth.ToString(CultureInfo.InvariantCulture)} {PageHeight.ToString(CultureInfo.InvariantCulture)}] /Resources << /Font << /F1 {fontId} 0 R /F2 {boldFontId} 0 R >> >> /Contents {contentIds[i]} 0 R >>"));
        }

        var offsets = new List<long>();
        foreach (var obj in objects)
        {
            offsets.Add(stream.Position);
            writer.WriteLine(obj);
        }

        long xrefStart = stream.Position;
        writer.WriteLine("xref");
        writer.WriteLine($"0 {objects.Count + 1}");
        writer.WriteLine("0000000000 65535 f ");
        foreach (long offset in offsets)
        {
            writer.WriteLine(offset.ToString("D10", CultureInfo.InvariantCulture) + " 00000 n ");
        }

        writer.WriteLine("trailer");
        writer.WriteLine($"<< /Size {objects.Count + 1} /Root {catalogId} 0 R >>");
        writer.WriteLine("startxref");
        writer.WriteLine(xrefStart.ToString(CultureInfo.InvariantCulture));
        writer.WriteLine("%%EOF");
    }

    private static string BuildObject(int id, string body)
        => $"{id} 0 obj\n{body}\nendobj";

    private static string EncodeStream(byte[] bytes)
        => $"<< /Length {bytes.Length} >>\nstream\n{Encoding.ASCII.GetString(bytes)}\nendstream";

    private sealed class PdfCanvas
    {
        private readonly StringBuilder builder = new();

        public string Content => builder.ToString();

        public void Text(double x, double y, string text, double size, bool bold = false)
        {
            builder.AppendLine("BT");
            builder.AppendLine($"/{(bold ? "F2" : "F1")} {Fmt(size)} Tf");
            builder.AppendLine($"1 0 0 1 {Fmt(x)} {Fmt(y)} Tm");
            builder.AppendLine($"({Escape(text)}) Tj");
            builder.AppendLine("ET");
        }

        public void Rect(double x, double y, double w, double h, bool fill, bool stroke)
        {
            builder.AppendLine($"{Fmt(x)} {Fmt(y)} {Fmt(w)} {Fmt(h)} re");
            builder.AppendLine(fill && stroke ? "B" : fill ? "f" : "S");
        }

        public void Circle(double x, double y, double r, bool fill, bool stroke)
        {
            const double k = 0.5522847498;
            double c = r * k;
            builder.AppendLine($"{Fmt(x + r)} {Fmt(y)} m");
            builder.AppendLine($"{Fmt(x + r)} {Fmt(y + c)} {Fmt(x + c)} {Fmt(y + r)} {Fmt(x)} {Fmt(y + r)} c");
            builder.AppendLine($"{Fmt(x - c)} {Fmt(y + r)} {Fmt(x - r)} {Fmt(y + c)} {Fmt(x - r)} {Fmt(y)} c");
            builder.AppendLine($"{Fmt(x - r)} {Fmt(y - c)} {Fmt(x - c)} {Fmt(y - r)} {Fmt(x)} {Fmt(y - r)} c");
            builder.AppendLine($"{Fmt(x + c)} {Fmt(y - r)} {Fmt(x + r)} {Fmt(y - c)} {Fmt(x + r)} {Fmt(y)} c");
            builder.AppendLine(fill && stroke ? "B" : fill ? "f" : "S");
        }

        public void Line(double x1, double y1, double x2, double y2)
        {
            builder.AppendLine($"{Fmt(x1)} {Fmt(y1)} m {Fmt(x2)} {Fmt(y2)} l S");
        }

        public void SetStroke(double r, double g, double b)
        {
            builder.AppendLine($"{Fmt(r)} {Fmt(g)} {Fmt(b)} RG");
        }

        public void SetFill(double r, double g, double b)
        {
            builder.AppendLine($"{Fmt(r)} {Fmt(g)} {Fmt(b)} rg");
        }

        private static string Escape(string text)
            => text.Replace("\\", "\\\\", StringComparison.Ordinal)
                .Replace("(", "\\(", StringComparison.Ordinal)
                .Replace(")", "\\)", StringComparison.Ordinal);
    }

    private static string Fmt(double value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);
}
