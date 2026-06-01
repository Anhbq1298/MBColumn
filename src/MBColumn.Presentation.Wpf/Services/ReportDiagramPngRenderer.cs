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
    public static string RenderDataUri(DiagramBlock block, int width = 1400, int height = 900, double dpi = 192)
    {
        var highlightedDemand = block.Points
            .Where(p => p.IsDemand)
            .OrderByDescending(p => p.Utilization)
            .FirstOrDefault();

        var chart = new DiagramCanvas2D
        {
            Width = width,
            Height = height,
            Points = block.Points,
            ReferenceLines = block.ReferenceLines,
            XAxisLabel = block.XAxisLabel,
            YAxisLabel = block.YAxisLabel,
            Ratio = block.Ratio,
            UseEqualAspect = block.UseEqualAspect,
            ShowInteractionHint = false,
            ShowCapacityControlPoints = true,
            ShowCpLabels = false,
            ShowDemandLabel = true,
            ShowGrid = true,
            ShowLabels = true,
            ShowNominalCurve = true,
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
