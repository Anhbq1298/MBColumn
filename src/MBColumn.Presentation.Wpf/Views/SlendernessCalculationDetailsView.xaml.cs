using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MBColumn.Presentation.Wpf.Controls.MathRendering;

namespace MBColumn.Presentation.Wpf.Views;

public partial class SlendernessCalculationDetailsView : UserControl
{
    public SlendernessCalculationDetailsView()
    {
        InitializeComponent();
        IsVisibleChanged += OnIsVisibleChanged;
    }

    private async void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if ((bool)e.NewValue != true) return;

        FormulaLoadingOverlay.Visibility = Visibility.Visible;

        // Small yield so WPF completes layout and the MathEquationView controls start their renders.
        await Task.Yield();

        var tasks = new List<Task>();
        foreach (var view in FindVisualChildren<MathEquationView>(this))
            tasks.Add(view.RenderCompletion);

        if (tasks.Count > 0)
            await Task.WhenAll(tasks);

        FormulaLoadingOverlay.Visibility = Visibility.Collapsed;
    }

    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T t) yield return t;
            foreach (var grandchild in FindVisualChildren<T>(child))
                yield return grandchild;
        }
    }
}
