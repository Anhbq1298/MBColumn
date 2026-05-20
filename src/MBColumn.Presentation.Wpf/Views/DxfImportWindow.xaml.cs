using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class DxfImportWindow : Window
{
    public DxfImportWindow(DxfImportViewModel viewModel)
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
