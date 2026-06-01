using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace MBColumn.Presentation.Wpf.Views;

public partial class PmmInteractionWindow : UserControl
{
    public PmmInteractionWindow() => InitializeComponent();

    public string CapturePmChartDataUri(DiagramBlock block)
        => CaptureChartDataUri(PmCanvas, block);

    public string CaptureMmChartDataUri(DiagramBlock block)
        => CaptureChartDataUri(MmCanvas, block);

    private void ResetMmChart_Click(object sender, RoutedEventArgs e) => MmCanvas.ResetView();
    private void ResetPmChart_Click(object sender, RoutedEventArgs e) => PmCanvas.ResetView();

    private void ExportMmChart_Click(object sender, RoutedEventArgs e)
        => ExportToPng(MmCanvas, "MM_Diagram");

    private void ExportPmChart_Click(object sender, RoutedEventArgs e)
        => ExportToPng(PmCanvas, "PM_Diagram");

    private static void ExportToPng(FrameworkElement element, string defaultName)
    {
        var dialog = new SaveFileDialog { Filter = "PNG Image|*.png", FileName = defaultName };
        if (dialog.ShowDialog() != true) return;

        var rtb = new RenderTargetBitmap(
            (int)element.ActualWidth, (int)element.ActualHeight,
            96, 96, PixelFormats.Pbgra32);
        rtb.Render(element);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(rtb));
        using var stream = File.Create(dialog.FileName);
        encoder.Save(stream);
    }

    private static string CaptureChartDataUri(MBColumn.Presentation.Wpf.Controls.DiagramCanvas2D canvas, DiagramBlock block)
    {
        var oldWidth = canvas.Width;
        var oldHeight = canvas.Height;
        var oldPoints = canvas.Points;
        var oldReferenceLines = canvas.ReferenceLines;
        var oldXAxisLabel = canvas.XAxisLabel;
        var oldYAxisLabel = canvas.YAxisLabel;
        var oldRatio = canvas.Ratio;
        var oldUseEqualAspect = canvas.UseEqualAspect;
        var oldShowInteractionHint = canvas.ShowInteractionHint;
        var oldShowDemandLabel = canvas.ShowDemandLabel;
        var oldSelectedPoint = canvas.SelectedPoint;
        var oldHighlightedDemandLabel = canvas.HighlightedDemandLabel;

        try
        {
            var highlightedDemand = block.Points
                .Where(p => p.IsDemand)
                .OrderByDescending(p => p.Utilization)
                .FirstOrDefault();

            canvas.Width = 1800;
            canvas.Height = 1120;
            canvas.Points = block.Points;
            canvas.ReferenceLines = block.ReferenceLines;
            canvas.XAxisLabel = block.XAxisLabel;
            canvas.YAxisLabel = block.YAxisLabel;
            canvas.Ratio = block.Ratio;
            canvas.UseEqualAspect = block.UseEqualAspect;
            canvas.ShowInteractionHint = false;
            canvas.ShowDemandLabel = true;
            canvas.SelectedPoint = highlightedDemand;
            canvas.HighlightedDemandLabel = highlightedDemand?.Label;
            canvas.ResetView();

            canvas.Measure(new Size(canvas.Width, canvas.Height));
            canvas.Arrange(new Rect(0, 0, canvas.Width, canvas.Height));
            canvas.UpdateLayout();
            PrimeHoverCallout(canvas, highlightedDemand);

            const double dpi = 192.0;
            var bitmap = new RenderTargetBitmap(
                (int)Math.Ceiling(canvas.Width * dpi / 96.0),
                (int)Math.Ceiling(canvas.Height * dpi / 96.0),
                dpi,
                dpi,
                PixelFormats.Pbgra32);
            bitmap.Render(canvas);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            using var stream = new MemoryStream();
            encoder.Save(stream);
            return "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
        }
        finally
        {
            canvas.Width = oldWidth;
            canvas.Height = oldHeight;
            canvas.Points = oldPoints;
            canvas.ReferenceLines = oldReferenceLines;
            canvas.XAxisLabel = oldXAxisLabel;
            canvas.YAxisLabel = oldYAxisLabel;
            canvas.Ratio = oldRatio;
            canvas.UseEqualAspect = oldUseEqualAspect;
            canvas.ShowInteractionHint = oldShowInteractionHint;
            canvas.ShowDemandLabel = oldShowDemandLabel;
            canvas.SelectedPoint = oldSelectedPoint;
            canvas.HighlightedDemandLabel = oldHighlightedDemandLabel;
        }
    }

    private static void PrimeHoverCallout(MBColumn.Presentation.Wpf.Controls.DiagramCanvas2D canvas, ControlPointDto? point)
    {
        if (point is null)
        {
            return;
        }

        try
        {
            var transform = typeof(MBColumn.Presentation.Wpf.Controls.DiagramCanvas2D)
                .GetMethod("BuildCurrentTransform", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.Invoke(canvas, null);
            var toScreen = transform?.GetType().GetMethod("ToScreen", [typeof(double), typeof(double)]);
            if (toScreen?.Invoke(transform, [point.X, point.Y]) is not Point screen)
            {
                return;
            }

            typeof(MBColumn.Presentation.Wpf.Controls.DiagramCanvas2D)
                .GetField("hoverPoint", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(canvas, point);
            typeof(MBColumn.Presentation.Wpf.Controls.DiagramCanvas2D)
                .GetField("hoverPosition", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(canvas, screen);
        }
        catch
        {
            // Snapshot still includes the selected marker when hover internals change.
        }
    }
}
