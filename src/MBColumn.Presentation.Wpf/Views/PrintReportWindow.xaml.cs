using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class PrintReportWindow : Window
{
    public PrintReportWindow(PrintReportViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
