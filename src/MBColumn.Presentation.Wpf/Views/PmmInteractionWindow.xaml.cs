using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace MBColumn.Presentation.Wpf.Views;

public partial class PmmInteractionWindow : UserControl
{
    public PmmInteractionWindow() => InitializeComponent();

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
}
