using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Renders an SVG string as a WPF image using SharpVectors.
/// Rendering is deferred to background priority so it never blocks the UI thread.
/// </summary>
public sealed class SvgImageControl : FrameworkElement
{
    public static readonly DependencyProperty SvgContentProperty = DependencyProperty.Register(
        nameof(SvgContent), typeof(string), typeof(SvgImageControl),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnChanged));

    public static readonly DependencyProperty MaxDisplayWidthProperty = DependencyProperty.Register(
        nameof(MaxDisplayWidth), typeof(double), typeof(SvgImageControl),
        new FrameworkPropertyMetadata(400.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnChanged));

    public string? SvgContent
    {
        get => (string?)GetValue(SvgContentProperty);
        set => SetValue(SvgContentProperty, value);
    }

    public double MaxDisplayWidth
    {
        get => (double)GetValue(MaxDisplayWidthProperty);
        set => SetValue(MaxDisplayWidthProperty, value);
    }

    private Image? _image;
    private TextBlock? _placeholder;

    public SvgImageControl()
    {
        _placeholder = new TextBlock
        {
            Text = "Loading diagram…",
            FontSize = 10,
            Foreground = Brushes.Gray,
            FontStyle = FontStyles.Italic,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
        };
        AddVisualChild(_placeholder);
        AddLogicalChild(_placeholder);
    }

    protected override int VisualChildrenCount => _image is not null ? 1 : (_placeholder is not null ? 1 : 0);

    protected override Visual GetVisualChild(int index) =>
        (Visual?)_image ?? _placeholder ?? throw new InvalidOperationException();

    protected override Size MeasureOverride(Size constraint)
    {
        var child = (UIElement?)_image ?? _placeholder;
        if (child is null) return new Size(0, 0);
        child.Measure(constraint);
        return child.DesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        ((UIElement?)_image ?? _placeholder)?.Arrange(new Rect(finalSize));
        return finalSize;
    }

    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((SvgImageControl)d).Refresh();

    private void Refresh()
    {
        var svg = SvgContent;

        // Reset to placeholder
        if (_image is not null)
        {
            RemoveVisualChild(_image);
            RemoveLogicalChild(_image);
            _image = null;
        }
        if (_placeholder is null)
        {
            _placeholder = new TextBlock
            {
                Text = string.IsNullOrWhiteSpace(svg) ? "No diagram." : "Loading diagram…",
                FontSize = 10,
                Foreground = Brushes.Gray,
                FontStyle = FontStyles.Italic,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            AddVisualChild(_placeholder);
            AddLogicalChild(_placeholder);
        }
        else
        {
            _placeholder.Text = string.IsNullOrWhiteSpace(svg) ? "No diagram." : "Loading diagram…";
        }
        InvalidateMeasure();

        if (string.IsNullOrWhiteSpace(svg)) return;

        var capturedSvg = svg;
        var capturedWidth = MaxDisplayWidth;

        Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
        {
            if (SvgContent != capturedSvg) return;
            try
            {
                DrawingGroup? drawing = null;
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(capturedSvg)))
                {
                    var settings = new WpfDrawingSettings
                    {
                        IncludeRuntime = false,
                        TextAsGeometry = false,
                    };
                    var reader = new FileSvgReader(settings);
                    drawing = reader.Read(stream);
                }

                if (drawing is null) return;

                var drawingImage = new DrawingImage(drawing);
                drawingImage.Freeze();

                var img = new Image
                {
                    Source = drawingImage,
                    MaxWidth = capturedWidth,
                    Stretch = Stretch.Uniform,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                RenderOptions.SetBitmapScalingMode(img, BitmapScalingMode.HighQuality);

                // Swap placeholder → image
                if (_placeholder is not null)
                {
                    RemoveVisualChild(_placeholder);
                    RemoveLogicalChild(_placeholder);
                    _placeholder = null;
                }
                _image = img;
                AddVisualChild(_image);
                AddLogicalChild(_image);
                InvalidateMeasure();
            }
            catch
            {
                if (_placeholder is not null)
                    _placeholder.Text = "Diagram unavailable.";
            }
        });
    }
}
