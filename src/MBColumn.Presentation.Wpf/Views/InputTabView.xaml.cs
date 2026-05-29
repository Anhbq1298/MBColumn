using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class InputTabView : UserControl
{
    private bool isDraggingSlendernessDetails;
    private Point slendernessDetailsDragStart;
    private double slendernessDetailsStartX;
    private double slendernessDetailsStartY;

    protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.Key == System.Windows.Input.Key.Enter && System.Windows.Input.Keyboard.FocusedElement is TextBox textBox)
        {
            var binding = textBox.GetBindingExpression(TextBox.TextProperty);
            binding?.UpdateSource();
            textBox.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
            e.Handled = true;
        }
    }
    public InputTabView() => InitializeComponent();

    private void SlendernessDetailsHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        isDraggingSlendernessDetails = true;
        slendernessDetailsDragStart = e.GetPosition(InputRoot);
        slendernessDetailsStartX = SlendernessDetailsPanelTransform.X;
        slendernessDetailsStartY = SlendernessDetailsPanelTransform.Y;
        Mouse.Capture((IInputElement)sender);
        e.Handled = true;
    }

    private void SlendernessDetailsHeader_MouseMove(object sender, MouseEventArgs e)
    {
        if (!isDraggingSlendernessDetails || e.LeftButton != MouseButtonState.Pressed) return;

        Point current = e.GetPosition(InputRoot);
        double nextX = slendernessDetailsStartX + current.X - slendernessDetailsDragStart.X;
        double nextY = slendernessDetailsStartY + current.Y - slendernessDetailsDragStart.Y;

        var bounds = GetSlendernessDetailsDragBounds();
        SlendernessDetailsPanelTransform.X = Math.Clamp(nextX, bounds.minX, bounds.maxX);
        SlendernessDetailsPanelTransform.Y = Math.Clamp(nextY, bounds.minY, bounds.maxY);
        e.Handled = true;
    }

    private void SlendernessDetailsHeader_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (!isDraggingSlendernessDetails) return;

        isDraggingSlendernessDetails = false;
        Mouse.Capture(null);
        e.Handled = true;
    }

    private (double minX, double maxX, double minY, double maxY) GetSlendernessDetailsDragBounds()
    {
        double rootWidth = Math.Max(InputRoot.ActualWidth, 1.0);
        double rootHeight = Math.Max(InputRoot.ActualHeight, 1.0);
        double panelWidth = Math.Max(SlendernessDetailsPanel.ActualWidth, 1.0);
        double panelHeight = Math.Max(SlendernessDetailsPanel.ActualHeight, 1.0);

        double centeredLeft = (rootWidth - panelWidth) / 2.0;
        double centeredTop = (rootHeight - panelHeight) / 2.0;
        const double visibleMargin = 72.0;

        double minX = -centeredLeft - panelWidth + visibleMargin;
        double maxX = rootWidth - centeredLeft - visibleMargin;
        double minY = -centeredTop;
        double maxY = rootHeight - centeredTop - visibleMargin;
        return (minX, maxX, minY, maxY);
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
        if (dlg.ShowDialog() == true)
        {
            try
            {
                vm.IrregularInput.ImportBoundaryFile(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void ExportBoundary_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "boundary.csv" };
        if (dlg.ShowDialog() == true)
        {
            try
            {
                vm.IrregularInput.ExportBoundaryFile(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void ImportRebar_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new OpenFileDialog { Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*" };
        if (dlg.ShowDialog() == true)
        {
            try
            {
                vm.IrregularInput.ImportRebarFile(dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void ExportRebar_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not InputViewModel vm) return;
        var dlg = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = "rebars.csv" };
        if (dlg.ShowDialog() == true)
        {
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
}

