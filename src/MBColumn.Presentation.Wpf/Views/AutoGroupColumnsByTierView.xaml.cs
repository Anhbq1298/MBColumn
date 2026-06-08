using MBColumn.Presentation.Wpf.ViewModels.AutoGrouping;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Views;

public partial class AutoGroupColumnsByTierView : Window
{
    public AutoGroupColumnsByTierView(AutoGroupColumnsByTierViewModel viewModel)
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
