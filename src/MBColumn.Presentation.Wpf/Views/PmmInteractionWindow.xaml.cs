using System.Windows;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class PmmInteractionWindow : Window
{
    public PmmInteractionWindow(ResultViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
