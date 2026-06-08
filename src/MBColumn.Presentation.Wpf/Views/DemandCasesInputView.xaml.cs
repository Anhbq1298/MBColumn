using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class DemandCasesInputView : UserControl
{
    public DemandCasesInputView()
    {
        InitializeComponent();
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
        catch
        {
        }
    }

    private static bool TryParseDouble(string value, out double result) =>
        double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out result) ||
        double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
}
