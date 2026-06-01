using System.Windows;
using System.Windows.Controls;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class ResultTabView : UserControl
{
    public ResultTabView() => InitializeComponent();

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

    private void ShowDetails(string title, FrameworkElement content, object detailDataContext)
    {
        var window = new ResultDetailWindow(title, content, detailDataContext)
        {
            Owner = Window.GetWindow(this)
        };
        window.Show();
    }
}
