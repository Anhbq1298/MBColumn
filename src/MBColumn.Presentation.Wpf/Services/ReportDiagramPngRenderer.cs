using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Presentation.Wpf.Controls;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MBColumn.Presentation.Wpf.Services;

public static class ReportDiagramPngRenderer
{
    public static string RenderDataUri(DiagramBlock block, int width = 3200, int height = 2200, double dpi = 600)
    {
        // Compute font scale so labels appear at their nominal pt size in the PDF.
        // PDF content width = 180 mm = 510.24 pt; diagram occupies WidthPct% of that.
        // "Ideal" canvas DIP = targetPdfPt × (96/72) → 1 DIP maps to 1 pt.
        // fontScale = actual canvas / ideal canvas; fonts are multiplied by this inside DiagramCanvas2D.
        const double pdfContentWidthPt = 180.0 / 25.4 * 72.0;
        double targetPdfPt = pdfContentWidthPt * block.WidthPct / 100.0;
        double idealCanvasDip = targetPdfPt * 96.0 / 72.0;
        double fontScale = width / idealCanvasDip;

        var highlightedDemand = block.Points
            .Where(p => p.IsDemand)
            .OrderByDescending(p => p.Utilization)
            .FirstOrDefault();

        var chart = new DiagramCanvas2D
        {
            Width = width,
            Height = height,
            RendererFontScale = fontScale,
            Points = block.Points,
            ReferenceLines = block.ReferenceLines,
            XAxisLabel = block.XAxisLabel,
            YAxisLabel = block.YAxisLabel,
            Ratio = block.Ratio,
            UseEqualAspect = block.UseEqualAspect,
            ShowInteractionHint = false,
            ShowCapacityControlPoints = false,
            ShowCpLabels = false,
            ShowDemandLabel = true,
            ShowGrid = true,
            ShowLabels = true,
            ShowNominalCurve = false,
            ShowReferenceLines = true,
            ShowSpecialPoints = true,
            SelectedPoint = highlightedDemand,
            HighlightedDemandLabel = highlightedDemand?.Label
        };

        chart.Measure(new Size(width, height));
        chart.Arrange(new Rect(0, 0, width, height));
        chart.UpdateLayout();
        PrimeHoverCallout(chart, highlightedDemand);

        double scale = dpi / 96.0;
        var bitmap = new RenderTargetBitmap(
            (int)Math.Ceiling(width * scale),
            (int)Math.Ceiling(height * scale),
            dpi,
            dpi,
            PixelFormats.Pbgra32);
        bitmap.Render(chart);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));

        using var stream = new MemoryStream();
        encoder.Save(stream);
        return "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
    }

    private static void PrimeHoverCallout(DiagramCanvas2D chart, ControlPointDto? point)
    {
        if (point is null)
        {
            return;
        }

        try
        {
            var transform = (ChartTransformHelper?)typeof(DiagramCanvas2D)
                .GetMethod("BuildCurrentTransform", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.Invoke(chart, null);
            if (transform is null)
            {
                return;
            }

            var screen = transform.ToScreen(point.X, point.Y);
            typeof(DiagramCanvas2D)
                .GetField("hoverPoint", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(chart, point);
            typeof(DiagramCanvas2D)
                .GetField("hoverPosition", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(chart, screen);
        }
        catch
        {
            // A selected marker is still rendered if the private hover overlay changes.
        }
    }
}
