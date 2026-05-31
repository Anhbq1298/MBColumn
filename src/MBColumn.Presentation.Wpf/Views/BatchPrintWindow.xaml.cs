using System;
using System.Windows;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class BatchPrintWindow : Window
{
    public BatchPrintWindow(BatchPrintWindowViewModel viewModel)
    {
        InitializeComponent();
        Owner = System.Windows.Application.Current.MainWindow;
        DataContext = viewModel;
        viewModel.RequestClose += (s, e) =>
        {
            DialogResult = true;
            Close();
        };
    }
}
