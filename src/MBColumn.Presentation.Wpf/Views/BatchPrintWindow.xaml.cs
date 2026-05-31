using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class BatchPrintWindow : System.Windows.Window
{
    public BatchPrintWindow(BatchPrintWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        => Close();
}
