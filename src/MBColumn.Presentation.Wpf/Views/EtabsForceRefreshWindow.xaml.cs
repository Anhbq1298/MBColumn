using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsForceRefreshWindow : Window
{
    public EtabsForceRefreshWindow(EtabsForceRefreshViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.RequestClose += (_, accepted) =>
        {
            DialogResult = accepted;
            Close();
        };
    }

    private void OnComboListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            if (item is EtabsLoadCombinationViewModel combo)
                combo.IsSelected = true;
        }
        foreach (var item in e.RemovedItems)
        {
            if (item is EtabsLoadCombinationViewModel combo)
                combo.IsSelected = false;
        }
    }

    private void OnBackClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is EtabsForceRefreshViewModel vm)
        {
            // Go back to step 2 by resetting preview
            vm.StatusMessage = "";
        }
    }
}
