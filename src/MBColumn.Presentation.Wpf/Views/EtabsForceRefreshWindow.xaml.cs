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
}
