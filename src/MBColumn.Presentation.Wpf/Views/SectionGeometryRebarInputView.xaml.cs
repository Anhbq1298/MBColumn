using System;
using System.Windows;
using System.Windows.Controls;
using MBColumn.Presentation.Wpf.ViewModels;
using Microsoft.Win32;

namespace MBColumn.Presentation.Wpf.Views;

public partial class SectionGeometryRebarInputView : UserControl
{
    public SectionGeometryRebarInputView()
    {
        InitializeComponent();
    }

    private void OpenCadEditor_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dialog = new SectionCadEditorWindow(vm)
        {
            Owner = Window.GetWindow(this)
        };
        dialog.ShowDialog();
    }

    private void ImportBoundary_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*" };
        if (dlg.ShowDialog() != true) return;

        try
        {
            vm.IrregularInput.ImportBoundaryFile(dlg.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ExportBoundary_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "boundary.csv" };
        if (dlg.ShowDialog() != true) return;

        try
        {
            vm.IrregularInput.ExportBoundaryFile(dlg.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ImportRebar_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*" };
        if (dlg.ShowDialog() != true) return;

        try
        {
            vm.IrregularInput.ImportRebarFile(dlg.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ExportRebar_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "rebars.csv" };
        if (dlg.ShowDialog() != true) return;

        try
        {
            vm.IrregularInput.ExportRebarFile(dlg.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
