using MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class AutomatedRebarDesignDialog : Window
{
    public AutomatedRebarDesignDialog(AutomatedRebarDesignViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.CloseRequested += (_, _) =>
        {
            DialogResult = viewModel.DialogResult;
            Close();
        };
    }
}
