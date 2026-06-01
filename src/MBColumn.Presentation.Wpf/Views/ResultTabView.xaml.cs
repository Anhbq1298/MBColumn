using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ResultTabView : UserControl
{
    public ResultTabView() => InitializeComponent();

    private void OpenPmmDetails_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ResultViewModel vm || vm.Result is null)
            return;

        var detailVm = new ResultViewModel
        {
            Result = vm.Result
        };
        detailVm.IsPmmDetailsOpen = true;

        var window = ShowDetails("PMM Interaction Details", new PmmInteractionWindow(), detailVm);
        detailVm.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(ResultViewModel.IsPmmDetailsOpen) && !detailVm.IsPmmDetailsOpen)
                window.Close();
        };
    }

    private void OpenShearDetails_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ResultViewModel vm || !vm.Shear.HasResult)
            return;

        ShowDetails("Shear Check in Details (EC2 6.2)", new ShearDetailView(), vm.Shear);
    }

    private void OpenRebarComplianceDetails_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ResultViewModel vm || !vm.RebarCompliance.HasResult)
            return;

        ShowDetails("Reinforcement Code Compliance in Details", new RebarComplianceDetailView(), vm.RebarCompliance);
    }

    private ResultDetailWindow ShowDetails(string title, FrameworkElement content, object detailDataContext)
    {
        var window = new ResultDetailWindow(title, content, detailDataContext)
        {
            Owner = Window.GetWindow(this)
        };
        ApplyResultTabSize(window);
        window.Show();
        return window;
    }

    private void ApplyResultTabSize(Window window)
    {
        var resultTabContent = FindResultTabContentElement();
        double width = GetElementWidth(resultTabContent);
        double height = GetElementHeight(resultTabContent);

        if (width <= 0 && window.Owner is not null)
            width = window.Owner.ActualWidth;

        if (height <= 0 && window.Owner is not null)
            height = window.Owner.ActualHeight;

        if (width <= 0 || height <= 0)
            return;

        window.Width = width;
        window.Height = height;
        window.MinWidth = width;
        window.MaxWidth = width;
        window.MinHeight = height;
        window.MaxHeight = height;
        window.ResizeMode = ResizeMode.NoResize;
    }

    private FrameworkElement FindResultTabContentElement()
    {
        var parent = VisualTreeHelper.GetParent(this) as FrameworkElement;
        return parent is not null && GetElementWidth(parent) > GetElementWidth(this)
            ? parent
            : this;
    }

    private static double GetElementWidth(FrameworkElement element)
        => element.ActualWidth > 0 ? element.ActualWidth : element.RenderSize.Width;

    private static double GetElementHeight(FrameworkElement element)
        => element.ActualHeight > 0 ? element.ActualHeight : element.RenderSize.Height;
}
