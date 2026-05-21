using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsImportWindow : Window
{
    public EtabsImportWindow(EtabsImportViewModel viewModel)
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
