using System.Diagnostics;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Web.WebView2.Core;

namespace MBColumn.Presentation.Wpf.Controls.MathRendering;

public partial class MathEquationView : UserControl
{
    private static CoreWebView2Environment? _sharedEnvironment;
    private static readonly SemaphoreSlim _envLock = new(1, 1);
    // Limits concurrent EnsureCoreWebView2Async calls — too many simultaneous initializations thrash the process.
    private static readonly SemaphoreSlim _initSemaphore = new(4, 4);

    /// <summary>Fire-and-forget at app startup to pre-initialize the shared WebView2 environment.</summary>
    public static void PreWarm() => _ = GetSharedEnvironmentAsync();

    private static async Task<CoreWebView2Environment> GetSharedEnvironmentAsync()
    {
        if (_sharedEnvironment != null) return _sharedEnvironment;
        await _envLock.WaitAsync();
        try
        {
            _sharedEnvironment ??= await CoreWebView2Environment.CreateAsync();
            return _sharedEnvironment;
        }
        finally
        {
            _envLock.Release();
        }
    }

    public static readonly DependencyProperty LatexProperty = DependencyProperty.Register(
        nameof(Latex), typeof(string), typeof(MathEquationView),
        new PropertyMetadata("", OnRenderPropertyChanged));

    public static readonly DependencyProperty FallbackTextProperty = DependencyProperty.Register(
        nameof(FallbackText), typeof(string), typeof(MathEquationView),
        new PropertyMetadata("", OnRenderPropertyChanged));

    public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register(
        nameof(DisplayMode), typeof(bool), typeof(MathEquationView),
        new PropertyMetadata(false, OnRenderPropertyChanged));

    public static readonly DependencyProperty EquationFontSizeProperty = DependencyProperty.Register(
        nameof(EquationFontSize), typeof(double), typeof(MathEquationView),
        new PropertyMetadata(14.0, OnRenderPropertyChanged));

    public static readonly DependencyProperty UseEnhancedMathProperty = DependencyProperty.Register(
        nameof(UseEnhancedMath), typeof(bool), typeof(MathEquationView),
        new PropertyMetadata(true, OnRenderPropertyChanged));

    private readonly DispatcherTimer renderDebounce;
    private readonly MathRenderService renderService = new();
    private TaskCompletionSource<object?> renderCompletion = CreateRenderCompletionSource();
    private string? queuedRenderSignature;
    private string? completedRenderSignature;
    private bool webViewReady;
    private ScrollViewer? _ancestorScrollViewer;
    private bool _clippedByScrollViewer;

    public MathEquationView()
    {
        InitializeComponent();

        renderDebounce = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(150) };
        renderDebounce.Tick += (_, _) =>
        {
            renderDebounce.Stop();
            _ = RenderAsync();
        };

        Loaded += OnControlLoaded;
        Unloaded += OnControlUnloaded;
        IsVisibleChanged += (_, _) =>
        {
            if (IsVisible)
            {
                QueueRender();
            }
        };
        IsEnabledChanged += (_, _) => QueueRender();
    }

    private void OnControlLoaded(object sender, RoutedEventArgs e)
    {
        QueueRender();
        try
        {
            var sv = FindAncestorScrollViewer();
            if (sv != _ancestorScrollViewer)
            {
                if (_ancestorScrollViewer != null)
                    _ancestorScrollViewer.ScrollChanged -= OnAncestorScrollChanged;
                _ancestorScrollViewer = sv;
                if (sv != null)
                    sv.ScrollChanged += OnAncestorScrollChanged;
            }
            // Immediately cancel render for controls outside the initial viewport so only
            // visible rows render on open; off-screen rows render lazily on scroll.
            if (_ancestorScrollViewer != null)
                UpdateWebViewClipping();
        }
        catch { }
    }

    private void OnControlUnloaded(object sender, RoutedEventArgs e)
    {
        if (_ancestorScrollViewer != null)
        {
            _ancestorScrollViewer.ScrollChanged -= OnAncestorScrollChanged;
            _ancestorScrollViewer = null;
        }
        _clippedByScrollViewer = false;
    }

    private void OnAncestorScrollChanged(object sender, ScrollChangedEventArgs e)
        => UpdateWebViewClipping();

    private void UpdateWebViewClipping()
    {
        if (_ancestorScrollViewer == null || !IsLoaded) return;
        try
        {
            var transform = TransformToAncestor(_ancestorScrollViewer);
            var myBounds = transform.TransformBounds(new Rect(0, 0, Math.Max(1, ActualWidth), Math.Max(1, ActualHeight)));
            var viewport = new Rect(0, 0, _ancestorScrollViewer.ViewportWidth, _ancestorScrollViewer.ViewportHeight);
            bool inViewport = myBounds.IntersectsWith(viewport);

            if (!inViewport && MathWebView.Visibility != Visibility.Collapsed)
            {
                _clippedByScrollViewer = true;
                renderDebounce.Stop();
                MathWebView.Visibility = Visibility.Collapsed;
                // Mark complete so Task.WhenAll in the loading overlay doesn't wait forever.
                if (!IsRenderComplete)
                {
                    FallbackTextBlock.Visibility = Visibility.Visible;
                    LoadingIndicator.Visibility = Visibility.Collapsed;
                    CompleteRender();
                }
            }
            else if (inViewport && _clippedByScrollViewer)
            {
                _clippedByScrollViewer = false;
                completedRenderSignature = null; // force fresh KaTeX render now in viewport
                QueueRender();
            }
        }
        catch { }
    }

    private ScrollViewer? FindAncestorScrollViewer()
    {
        DependencyObject? parent = VisualTreeHelper.GetParent(this);
        while (parent != null)
        {
            if (parent is ScrollViewer sv) return sv;
            parent = VisualTreeHelper.GetParent(parent);
        }
        return null;
    }

    public event EventHandler? RenderCompleted;

    public bool IsRenderComplete { get; private set; } = true;

    public Task RenderCompletion => IsRenderComplete
        ? Task.CompletedTask
        : renderCompletion.Task;

    public string Latex
    {
        get => (string)GetValue(LatexProperty);
        set => SetValue(LatexProperty, value);
    }

    public string FallbackText
    {
        get => (string)GetValue(FallbackTextProperty);
        set => SetValue(FallbackTextProperty, value);
    }

    public bool DisplayMode
    {
        get => (bool)GetValue(DisplayModeProperty);
        set => SetValue(DisplayModeProperty, value);
    }

    public double EquationFontSize
    {
        get => (double)GetValue(EquationFontSizeProperty);
        set => SetValue(EquationFontSizeProperty, value);
    }

    public bool UseEnhancedMath
    {
        get => (bool)GetValue(UseEnhancedMathProperty);
        set => SetValue(UseEnhancedMathProperty, value);
    }

    private static void OnRenderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        => ((MathEquationView)d).QueueRender();

    private void QueueRender()
    {
        FallbackTextBlock.Text = string.IsNullOrWhiteSpace(FallbackText)
            ? MathRenderService.NormalizeLatex(Latex)
            : FallbackText;
        FallbackTextBlock.FontSize = System.Math.Max(12.0, EquationFontSize);
        string signature = BuildRenderSignature();

        if (IsRenderComplete
            && string.Equals(completedRenderSignature, signature, StringComparison.Ordinal)
            && (MathWebView.Visibility == Visibility.Visible || FallbackTextBlock.Visibility == Visibility.Visible))
        {
            return;
        }

        // Don't restart render state for off-screen controls; they already completed via clipping.
        if (_clippedByScrollViewer)
            return;

        queuedRenderSignature = signature;
        ResetRenderCompletion();

        LoadingIndicator.Visibility = Visibility.Visible;
        FallbackTextBlock.Visibility = Visibility.Hidden;
        MathWebView.Visibility = Visibility.Hidden;

        if (!IsLoaded || !IsVisible)
        {
            return;
        }

        renderDebounce.Stop();
        renderDebounce.Start();
    }

    private async Task RenderAsync()
    {
        // Skip if this control was clipped off-screen before the debounce fired.
        if (_clippedByScrollViewer)
            return;

        if (!IsEnabled)
        {
            ShowFallback();
            CompleteRender();
            return;
        }

        if (!UseEnhancedMath || string.IsNullOrWhiteSpace(Latex) || !renderService.HasLocalAssets())
        {
            ShowFallback();
            CompleteRender();
            return;
        }

        try
        {
            if (MathWebView.Visibility == Visibility.Collapsed)
            {
                MathWebView.Visibility = Visibility.Hidden;
            }

            if (!webViewReady)
            {
                MathWebView.WebMessageReceived += OnWebMessageReceived;
                var env = await GetSharedEnvironmentAsync();
                // Throttle concurrent EnsureCoreWebView2Async calls to avoid thrashing.
                await _initSemaphore.WaitAsync();
                try
                {
                    await MathWebView.EnsureCoreWebView2Async(env);
                }
                finally
                {
                    _initSemaphore.Release();
                }
                MathWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                MathWebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
                webViewReady = true;
            }

            string color = BrushToCss(Foreground);
            string html = renderService.BuildHtml(Latex, DisplayMode, EquationFontSize, color);
            MathWebView.Visibility = Visibility.Hidden;
            MathWebView.NavigateToString(html);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("KaTeX/WebView2 render failed: " + ex.Message);
            ShowFallback();
            CompleteRender();
        }
    }

    private void OnWebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
    {
        try
        {
            using var doc = JsonDocument.Parse(e.WebMessageAsJson);
            string? type = doc.RootElement.TryGetProperty("type", out var typeElement)
                ? typeElement.GetString()
                : null;

            if (type == "wheel")
            {
                double deltaY = doc.RootElement.TryGetProperty("deltaY", out var deltaYElement)
                    ? deltaYElement.GetDouble()
                    : 0.0;

                var mouseWheelEventArgs = new MouseWheelEventArgs(
                    Mouse.PrimaryDevice,
                    Environment.TickCount,
                    (int)-deltaY)
                {
                    RoutedEvent = MouseWheelEvent,
                    Source = this
                };
                RaiseEvent(mouseWheelEventArgs);
                return;
            }

            if (type == "rendered")
            {
                double height = doc.RootElement.TryGetProperty("height", out var heightElement)
                    ? heightElement.GetDouble()
                    : System.Math.Max(24.0, EquationFontSize * 1.8);
                Height = System.Math.Min(DisplayMode ? 120.0 : 80.0, System.Math.Max(24.0, height + 2.0));
                FallbackTextBlock.Visibility = Visibility.Collapsed;
                MathWebView.Visibility = Visibility.Visible;
                CompleteRender();
                return;
            }

            if (type == "error")
            {
                Debug.WriteLine("KaTeX render warning: " + e.WebMessageAsJson);
                ShowFallback();
                CompleteRender();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("KaTeX render message failed: " + ex.Message);
            ShowFallback();
            CompleteRender();
        }
    }

    private void ShowFallback()
    {
        LoadingIndicator.Visibility = Visibility.Collapsed;
        MathWebView.Visibility = Visibility.Collapsed;
        FallbackTextBlock.Visibility = Visibility.Visible;
        Height = double.NaN;
    }

    private static TaskCompletionSource<object?> CreateRenderCompletionSource()
        => new(TaskCreationOptions.RunContinuationsAsynchronously);

    private void ResetRenderCompletion()
    {
        IsRenderComplete = false;
        renderCompletion = CreateRenderCompletionSource();
    }

    private void CompleteRender()
    {
        if (IsRenderComplete)
        {
            return;
        }

        LoadingIndicator.Visibility = Visibility.Collapsed;
        IsRenderComplete = true;
        completedRenderSignature = queuedRenderSignature;
        renderCompletion.TrySetResult(null);
        RenderCompleted?.Invoke(this, EventArgs.Empty);
    }

    private string BuildRenderSignature()
        => string.Create(
            System.Globalization.CultureInfo.InvariantCulture,
            $"{MathRenderService.NormalizeLatex(Latex)}|{FallbackText}|{DisplayMode}|{EquationFontSize:0.###}|{UseEnhancedMath}|{BrushToCss(Foreground)}");

    private static string BrushToCss(Brush brush)
    {
        if (brush is SolidColorBrush solid)
        {
            return $"#{solid.Color.R:X2}{solid.Color.G:X2}{solid.Color.B:X2}";
        }
        return "#1F2933";
    }
}
