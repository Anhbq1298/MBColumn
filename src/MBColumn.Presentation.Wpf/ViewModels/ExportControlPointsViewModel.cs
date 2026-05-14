using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ExportControlPointsViewModel : ViewModelBase
{
    private readonly CalculationResultDto result;
    private readonly IControlPointPreviewService previewService;
    private readonly IControlPointCsvExportService csvExportService;
    private readonly RelayCommand exportCsvCommand;
    private ControlPointThetaSelectionMode selectedThetaMode = ControlPointThetaSelectionMode.CurrentView;
    private string customThetaText = "0";
    private string emptyStateMessage = "";
    private string previewSummary = "";
    private string thetaValidationMessage = "";

    public ExportControlPointsViewModel(
        CalculationResultDto result,
        double currentThetaDegrees,
        IControlPointPreviewService previewService,
        IControlPointCsvExportService csvExportService)
    {
        this.result = result;
        this.previewService = previewService;
        this.csvExportService = csvExportService;
        CurrentThetaDegrees = NormalizeAngle(currentThetaDegrees);
        customThetaText = CurrentThetaDegrees.ToString("F1", CultureInfo.InvariantCulture);
        PreviewRows = new ObservableCollection<ControlPointExportRow>();

        RefreshPreviewCommand = new RelayCommand(RefreshPreview);
        exportCsvCommand = new RelayCommand(ExportCsv, () => PreviewRows.Count > 0);
        ExportCsvCommand = exportCsvCommand;
        CloseCommand = new RelayCommand(() => CloseRequested?.Invoke(this, EventArgs.Empty));

        RefreshPreview();
    }

    public event EventHandler? CloseRequested;

    public ObservableCollection<ControlPointExportRow> PreviewRows { get; }
    public ICommand RefreshPreviewCommand { get; }
    public ICommand ExportCsvCommand { get; }
    public ICommand CloseCommand { get; }

    public double CurrentThetaDegrees { get; }
    public string ForceUnitLabel => result.ControlPointTable?.ForceUnitLabel ?? result.MxMyDiagram.PUnit;
    public string MomentUnitLabel => result.ControlPointTable?.MomentUnitLabel ?? result.MxMyDiagram.MUnit;
    public string LengthUnitLabel => result.ControlPointTable?.LengthUnitLabel ?? (result.UnitSystem == UnitSystem.Metric ? "mm" : "in");
    public string CurrentViewDescription => $"Current view theta = {CurrentThetaDegrees:F1}\u00b0";
    public string CurrentViewScopeDescription => $"Export only \u03b8 = {CurrentThetaDegrees:F1}\u00b0";
    public string PreviewSummary { get => previewSummary; private set => Set(ref previewSummary, value); }
    public string EmptyStateMessage { get => emptyStateMessage; private set => Set(ref emptyStateMessage, value); }
    public string ThetaValidationMessage { get => thetaValidationMessage; private set => Set(ref thetaValidationMessage, value); }
    public bool HasPreviewRows => PreviewRows.Count > 0;
    public bool HasEmptyState => !HasPreviewRows && !string.IsNullOrWhiteSpace(EmptyStateMessage);

    public bool IsCurrentViewSelected
    {
        get => SelectedThetaMode == ControlPointThetaSelectionMode.CurrentView;
        set
        {
            if (value)
            {
                SelectedThetaMode = ControlPointThetaSelectionMode.CurrentView;
            }
        }
    }

    public bool IsCustomThetaSelected
    {
        get => SelectedThetaMode == ControlPointThetaSelectionMode.CustomTheta;
        set
        {
            if (value)
            {
                SelectedThetaMode = ControlPointThetaSelectionMode.CustomTheta;
            }
        }
    }

    public bool IsAllThetaSelected
    {
        get => SelectedThetaMode == ControlPointThetaSelectionMode.AllTheta;
        set
        {
            if (value)
            {
                SelectedThetaMode = ControlPointThetaSelectionMode.AllTheta;
            }
        }
    }

    public ControlPointThetaSelectionMode SelectedThetaMode
    {
        get => selectedThetaMode;
        set
        {
            if (selectedThetaMode == value)
            {
                return;
            }

            Set(ref selectedThetaMode, value);
            Raise(nameof(IsCurrentViewSelected));
            Raise(nameof(IsCustomThetaSelected));
            Raise(nameof(IsAllThetaSelected));
            Raise(nameof(IsCustomThetaInputEnabled));
            RefreshPreview();
        }
    }

    public bool IsCustomThetaInputEnabled => SelectedThetaMode == ControlPointThetaSelectionMode.CustomTheta;

    public string CustomThetaText
    {
        get => customThetaText;
        set
        {
            Set(ref customThetaText, value);
            if (SelectedThetaMode == ControlPointThetaSelectionMode.CustomTheta)
            {
                RefreshPreview();
            }
        }
    }

    public void RefreshPreview()
    {
        double? customTheta = null;
        ThetaValidationMessage = "";

        if (SelectedThetaMode == ControlPointThetaSelectionMode.CustomTheta)
        {
            if (!double.TryParse(CustomThetaText, NumberStyles.Float, CultureInfo.InvariantCulture, out double parsedTheta))
            {
                ThetaValidationMessage = "Enter a numeric theta angle in degrees.";
                ApplyPreview(new ControlPointPreviewResult([], [], ThetaValidationMessage));
                return;
            }

            customTheta = NormalizeAngle(parsedTheta);
        }

        ApplyPreview(previewService.BuildPreview(result, SelectedThetaMode, CurrentThetaDegrees, customTheta));
    }

    private void ApplyPreview(ControlPointPreviewResult preview)
    {
        PreviewRows.Clear();
        foreach (var row in preview.Rows)
        {
            PreviewRows.Add(row);
        }

        EmptyStateMessage = preview.EmptyStateMessage;
        PreviewSummary = BuildSummary(preview);
        Raise(nameof(HasPreviewRows));
        Raise(nameof(HasEmptyState));
        exportCsvCommand.RaiseCanExecuteChanged();
    }

    private string BuildSummary(ControlPointPreviewResult preview)
    {
        if (preview.Rows.Count == 0)
        {
            return $"No rows to export. Units: P [{ForceUnitLabel}], M\u03b8 [{MomentUnitLabel}], c [{LengthUnitLabel}]";
        }

        int thetaCount = preview.ThetaValues.Count;
        string datasetLabel = thetaCount == 1 ? "theta dataset" : "theta datasets";
        return $"{preview.Rows.Count} rows across {thetaCount} {datasetLabel}. Units: P [{ForceUnitLabel}], M\u03b8 [{MomentUnitLabel}], c [{LengthUnitLabel}]";
    }

    private void ExportCsv()
    {
        var dialog = new SaveFileDialog
        {
            Title = "Export Control Points CSV",
            Filter = "CSV file (*.csv)|*.csv",
            FilterIndex = 1,
            DefaultExt = "csv",
            FileName = BuildSuggestedFileName()
        };

        if (dialog.ShowDialog(System.Windows.Application.Current.MainWindow) != true)
        {
            return;
        }

        csvExportService.Export(dialog.FileName, PreviewRows);
        MessageBox.Show(
            System.Windows.Application.Current.MainWindow,
            $"Exported {PreviewRows.Count} preview rows to:\n{dialog.FileName}",
            "Export Complete",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    private string BuildSuggestedFileName()
    {
        return SelectedThetaMode switch
        {
            ControlPointThetaSelectionMode.CurrentView => $"ControlPoints_theta_{CurrentThetaDegrees:F1}",
            ControlPointThetaSelectionMode.CustomTheta when double.TryParse(CustomThetaText, NumberStyles.Float, CultureInfo.InvariantCulture, out double theta)
                => $"ControlPoints_theta_{NormalizeAngle(theta):F1}",
            ControlPointThetaSelectionMode.AllTheta => "ControlPoints_all_theta",
            _ => "ControlPoints"
        };
    }

    private static double NormalizeAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle))
        {
            return 0.0;
        }

        double normalized = angle % 360.0;
        return normalized < 0.0 ? normalized + 360.0 : normalized;
    }
}
