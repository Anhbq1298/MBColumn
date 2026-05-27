using MBColumn.Presentation.Wpf.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsPreloadWindow : Window
{
    private bool _closingFromEvent;

    public EtabsPreloadWindow(EtabsPreloadViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.RequestClose += (_, accepted) =>
        {
            if (_closingFromEvent) return; // already in Closing — let WPF finish
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
        _closingFromEvent = true;
        if (DataContext is EtabsPreloadViewModel vm && !vm.IsComplete)
            vm.Cancel();
    }
}
