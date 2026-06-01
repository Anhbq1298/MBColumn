using MBColumn.Application.Reports.Models;
using MBColumn.Presentation.Wpf.Controls;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MBColumn.Presentation.Wpf.Services;

public static class ReportDiagramPngRenderer
{
    public static string RenderDataUri(DiagramBlock block, int width = 900, int height = 620, double dpi = 144)
    {
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
            ShowCapacityControlPoints = false,
            ShowCpLabels = false,
            ShowDemandLabel = false,
            ShowGrid = true,
            ShowLabels = true,
            ShowNominalCurve = true,
            ShowReferenceLines = true,
            ShowSpecialPoints = true
        };

        chart.Measure(new Size(width, height));
        chart.Arrange(new Rect(0, 0, width, height));
        chart.UpdateLayout();

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
}
