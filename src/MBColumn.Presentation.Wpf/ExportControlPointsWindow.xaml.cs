using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

namespace MBColumn.Presentation.Wpf;

public partial class ExportControlPointsWindow : Window
{
    public ExportControlPointsWindow(ExportControlPointsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.CloseRequested += (_, _) => Close();
    }
}
