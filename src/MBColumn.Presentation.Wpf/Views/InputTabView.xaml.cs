using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        double maxY = centeredTop - visibleMargin;
        return (minX, maxX, minY, maxY);
    }

    private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.V || (Keyboard.Modifiers & ModifierKeys.Control) == 0) return;
        if (sender is not DataGrid grid) return;
        e.Handled = true;
        PasteToDataGrid(grid);
    }

    private static void PasteToDataGrid(DataGrid grid)
    {
        if (!Clipboard.ContainsText()) return;
        string[] clipRows = Clipboard.GetText().TrimEnd('\r', '\n').Split('\n');

        int startRow = grid.SelectedIndex >= 0 ? grid.SelectedIndex : 0;
        int startCol = 0;
        if (grid.CurrentCell.Column is DataGridColumn current)
        {
            int idx = grid.Columns.IndexOf(current);
            if (idx >= 0) startCol = idx;
        }

        for (int r = 0; r < clipRows.Length; r++)
        {
            int rowIdx = startRow + r;
            if (rowIdx >= grid.Items.Count) break;
            if (grid.Items[rowIdx] is not LoadCaseViewModel lc) continue;

            string[] clipCells = clipRows[r].TrimEnd('\r').Split('\t');
            for (int c = 0; c < clipCells.Length; c++)
            {
                int colIdx = startCol + c;
                if (colIdx >= grid.Columns.Count) break;
                if (grid.Columns[colIdx] is not DataGridTextColumn col) continue;
                if (col.IsReadOnly) continue;
                if (col.Binding is not Binding binding) continue;
                SetLoadCaseProperty(lc, binding.Path.Path, clipCells[c].Trim());
            }
        }
    }

    private static void SetLoadCaseProperty(LoadCaseViewModel lc, string path, string value)
    {
        var prop = typeof(LoadCaseViewModel).GetProperty(path);
        if (prop == null || !prop.CanWrite) return;
        try
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(lc, value);
            }
            else if (prop.PropertyType == typeof(double))
            {
                if (TryParseDouble(value, out double d)) prop.SetValue(lc, d);
            }
            else if (prop.PropertyType == typeof(double?))
            {
                if (string.IsNullOrWhiteSpace(value)) prop.SetValue(lc, (double?)null);
                else if (TryParseDouble(value, out double d)) prop.SetValue(lc, (double?)d);
            }
        }
        catch { }
    }

    private static bool TryParseDouble(string value, out double result) =>
        double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out result) ||
        double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result);

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

