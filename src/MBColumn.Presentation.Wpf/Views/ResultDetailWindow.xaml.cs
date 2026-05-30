using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using MBColumn.Presentation.Wpf.Controls.MathRendering;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ResultDetailWindow : Window
{
    public ResultDetailWindow(string title, FrameworkElement content, object dataContext)
    {
        InitializeComponent();

        Title = title;
        content.DataContext = dataContext;
        DetailHost.Content = content;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        Loaded -= OnLoaded;
        await RevealWhenReadyAsync();
    }

    private async Task RevealWhenReadyAsync()
    {
        await Dispatcher.Yield(DispatcherPriority.Loaded);
        UpdateLayout();
        await Dispatcher.Yield(DispatcherPriority.Render);
        await Task.Delay(250);
        UpdateLayout();

        await WaitForMathRenderAsync();
        await WaitForStableLayoutAsync();
        LoadingOverlay.Visibility = Visibility.Collapsed;
        DetailHost.Opacity = 1;
    }

    private async Task WaitForMathRenderAsync()
    {
        var deadline = Task.Delay(TimeSpan.FromSeconds(20));
        int emptyPolls = 0;

        while (!deadline.IsCompleted)
        {
            await Dispatcher.Yield(DispatcherPriority.Render);
            UpdateLayout();

            var mathViews = FindVisualChildren<MathEquationView>(DetailHost).ToList();

            if (mathViews.Count == 0)
            {
                // Visual tree may not be fully built yet; poll briefly then give up.
                if (++emptyPolls >= 5) return;
                await Task.WhenAny(Task.Delay(100), deadline);
                continue;
            }

            emptyPolls = 0;
            var pending = mathViews
                .Where(view => !view.IsRenderComplete)
                .Select(view => view.RenderCompletion)
                .ToArray();

            if (pending.Length == 0) return; // All equations fully rendered

            // Block until every pending equation finishes or the deadline fires.
            await Task.WhenAny(Task.WhenAll(pending), deadline);
        }
    }

    private async Task WaitForStableLayoutAsync()
    {
        double lastWidth = -1;
        double lastHeight = -1;
        int stableFrames = 0;

        for (int i = 0; i < 12 && stableFrames < 3; i++)
        {
            await Dispatcher.Yield(DispatcherPriority.Render);
            UpdateLayout();

            double width = DetailHost.ActualWidth;
            double height = DetailHost.ActualHeight;
            if (Math.Abs(width - lastWidth) < 0.5 && Math.Abs(height - lastHeight) < 0.5)
            {
                stableFrames++;
            }
            else
            {
                stableFrames = 0;
                lastWidth = width;
                lastHeight = height;
            }
        }
    }

    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject root)
        where T : DependencyObject
    {
        int childCount = VisualTreeHelper.GetChildrenCount(root);
        for (int i = 0; i < childCount; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(root, i);
            if (child is T typed)
            {
                yield return typed;
            }

            foreach (T descendant in FindVisualChildren<T>(child))
            {
                yield return descendant;
            }
        }
    }
}
