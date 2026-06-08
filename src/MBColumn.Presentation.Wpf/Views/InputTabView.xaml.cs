using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Views;

public partial class InputTabView : UserControl
{
    private Window? slendernessDetailsWindow;

    private DispatcherTimer? _calcRefreshTimer;
    private InputViewModel? _subscribedInputVm;
    private LoadCaseViewModel? _subscribedLoadCase;

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
    public InputTabView()
    {
        InitializeComponent();
        _calcRefreshTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(200) };
        _calcRefreshTimer.Tick += (_, _) => { _calcRefreshTimer.Stop(); RefreshCalculationFormulas(); };
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        UnsubscribeVm();
        if (e.NewValue is InputViewModel vm)
        {
            _subscribedInputVm = vm;
            vm.PropertyChanged += OnVmOrLcPropertyChanged;
            ResubscribeLoadCase(vm.SelectedLoadCase);
            RefreshCalculationFormulas();
        }
    }

    private void ResubscribeLoadCase(LoadCaseViewModel? lc)
    {
        if (_subscribedLoadCase != null)
            _subscribedLoadCase.PropertyChanged -= OnVmOrLcPropertyChanged;
        _subscribedLoadCase = lc;
        if (lc != null)
            lc.PropertyChanged += OnVmOrLcPropertyChanged;
    }

    private void UnsubscribeVm()
    {
        if (_subscribedInputVm != null)
        {
            _subscribedInputVm.PropertyChanged -= OnVmOrLcPropertyChanged;
            _subscribedInputVm = null;
        }
        ResubscribeLoadCase(null);
    }

    private void OnVmOrLcPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is InputViewModel vm && e.PropertyName == nameof(InputViewModel.SelectedLoadCase))
            ResubscribeLoadCase(vm.SelectedLoadCase);

        if (sender is InputViewModel detailsVm
            && (e.PropertyName == nameof(InputViewModel.IsSlendernessCalculationDetailsOpen)
                || e.PropertyName == nameof(InputViewModel.SlendernessCalculationLoadCase))
            && detailsVm.IsSlendernessCalculationDetailsOpen)
        {
            OpenSlendernessDetailsWindow(detailsVm);
        }

        _calcRefreshTimer?.Stop();
        _calcRefreshTimer?.Start();
    }

    private void RefreshCalculationFormulas()
    {
        if (DataContext is not InputViewModel vm) return;
        var lc = vm.SelectedLoadCase;

        CalcL0x.Formula = vm.L0xLatex;
        CalcL0y.Formula = vm.L0yLatex;
        CalcLambdaFormula.Formula = lc?.LambdaFormulaLatex ?? string.Empty;
        CalcLambdaX.Formula = lc?.LambdaXResultLatex ?? string.Empty;
        CalcLambdaY.Formula = lc?.LambdaYResultLatex ?? string.Empty;
        CalcLimitFormula.Formula = lc?.LambdaLimitFormulaLatex ?? string.Empty;
        CalcLimitX.Formula = lc?.LambdaLimitXResultLatex ?? string.Empty;
        CalcLimitY.Formula = lc?.LambdaLimitYResultLatex ?? string.Empty;
        CalcRmFormula.Formula = lc?.MomentRatioFormulaLatex ?? string.Empty;
        CalcRmX.Formula = lc?.MomentRatioXResultLatex ?? string.Empty;
        CalcRmY.Formula = lc?.MomentRatioYResultLatex ?? string.Empty;
        CalcBranchFormula.Formula = lc?.BranchFormulaLatex ?? string.Empty;
        CalcCurvFormula.Formula = lc?.NominalCurvatureFormulaLatex ?? string.Empty;
        CalcCurvX.Formula = lc?.NominalCurvatureXResultLatex ?? string.Empty;
        CalcCurvY.Formula = lc?.NominalCurvatureYResultLatex ?? string.Empty;
        CalcMomentUsedFormula.Formula = lc?.MomentUsedFormulaLatex ?? string.Empty;
        CalcMxUsed.Formula = lc?.MxUsedResultLatex ?? string.Empty;
        CalcMyUsed.Formula = lc?.MyUsedResultLatex ?? string.Empty;
        SumRmX.Formula = lc?.MomentRatioXResultLatex ?? string.Empty;
        SumLambdaX.Formula = lc?.LambdaXResultLatex ?? string.Empty;
        SumLimitX.Formula = lc?.LambdaLimitXResultLatex ?? string.Empty;
        SumBranchX.Formula = lc?.Ec2BranchXLatex ?? string.Empty;
        SumCurvX.Formula = lc?.NominalCurvatureXResultLatex ?? string.Empty;
        SumMxUsed.Formula = lc?.MxUsedResultLatex ?? string.Empty;
        SumRmY.Formula = lc?.MomentRatioYResultLatex ?? string.Empty;
        SumLambdaY.Formula = lc?.LambdaYResultLatex ?? string.Empty;
        SumLimitY.Formula = lc?.LambdaLimitYResultLatex ?? string.Empty;
        SumBranchY.Formula = lc?.Ec2BranchYLatex ?? string.Empty;
        SumCurvY.Formula = lc?.NominalCurvatureYResultLatex ?? string.Empty;
        SumMyUsed.Formula = lc?.MyUsedResultLatex ?? string.Empty;
    }

    private void OpenSlendernessDetailsWindow(InputViewModel vm)
    {
        if (vm.SlendernessCalculationLoadCase is not LoadCaseViewModel loadCase)
            return;

        if (slendernessDetailsWindow is not null)
        {
            slendernessDetailsWindow.Title = BuildSlendernessDetailsTitle(loadCase);
            slendernessDetailsWindow.Activate();
            return;
        }

        SlendernessDetailsPanel.DataContext = vm;
        SlendernessDetailsOverlay.Child = null;

        var window = new Window
        {
            Title = BuildSlendernessDetailsTitle(loadCase),
            Owner = Window.GetWindow(this),
            Content = SlendernessDetailsPanel,
            DataContext = vm,
            Width = 1500,
            Height = 920,
            MinWidth = 1100,
            MinHeight = 720,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            ResizeMode = ResizeMode.CanResize
        };

        window.Closed += (_, _) =>
        {
            window.Content = null;
            if (SlendernessDetailsOverlay.Child is null)
                SlendernessDetailsOverlay.Child = SlendernessDetailsPanel;

            SlendernessDetailsPanel.DataContext = null;
            slendernessDetailsWindow = null;
            if (vm.CloseSlendernessCalculationDetailsCommand.CanExecute(null))
                vm.CloseSlendernessCalculationDetailsCommand.Execute(null);
        };

        slendernessDetailsWindow = window;
        window.Show();
    }

    private static string BuildSlendernessDetailsTitle(LoadCaseViewModel loadCase)
        => "EC2 Moment Determination";

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
