using MBColumn.Presentation.Wpf.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsPreloadWindow : Window
{
    public EtabsPreloadWindow(EtabsPreloadViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.RequestClose += (_, accepted) =>
        {
            DialogResult = accepted;
            Close();
        };
    }

    private async void OnWindowLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is EtabsPreloadViewModel vm)
            await vm.StartAsync();
    }

    private void OnWindowClosing(object sender, CancelEventArgs e)
    {
        if (DataContext is EtabsPreloadViewModel vm && !vm.IsComplete)
            vm.Cancel();
    }
}
