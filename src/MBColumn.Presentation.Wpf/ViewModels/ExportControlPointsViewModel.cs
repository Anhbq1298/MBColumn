using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Views;
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
    public string AngleUnitHeader => "[deg]";
    public string ForceUnitHeader => $"[{ForceUnitLabel}]";
    public string MomentUnitHeader => $"[{MomentUnitLabel}]";
    public string LengthUnitHeader => $"[{LengthUnitLabel}]";
    public string StrainUnitHeader => "[-]";
    public string PhiUnitHeader => "[-]";
    public string CurrentViewDescription => $"Current view theta = {CurrentThetaDegrees:F1}\u00b0";
    public string CurrentViewScopeDescription => $"Export only \u03b8 = {CurrentThetaDegrees:F1}\u00b0";
    public string StrainSignConventionNote => "Strain sign: + tension, - compression.";
    public string ColumnHeaderNote =>
        "Column headers:\n" +
        "θ  = Bending angle\n" +
        "P  = Axial force\n" +
        "Mx/My = Moments about x/y axes\n" +
        "Mθ = Moment about θ axis\n" +
        "c  = Neutral axis depth\n" +
        "εt = Extreme tension steel fiber strain\n" +
        "εc = Extreme compression concrete fiber strain\n" +
        "φ  = Strength reduction factor";
    public string PreviewSummary { get => previewSummary; private set => Set(ref previewSummary, value); }
    public string EmptyStateMessage { get => emptyStateMessage; private set => Set(ref emptyStateMessage, value); }
    public string ThetaValidationMessage { get => thetaValidationMessage; private set => Set(ref thetaValidationMessage, value); }
    public bool HasPreviewRows => PreviewRows.Count > 0;
    public bool HasEmptyState => !HasPreviewRows && !string.IsNullOrWhiteSpace(EmptyStateMessage);

    public bool IsEc2 => result.DesignCode == DesignCodeType.Ec2;
    public bool IsEurocodeEc3Profile => IsEc2 && result.EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3;
    public string ActiveDesignCodeText => IsEc2 ? (IsEurocodeEc3Profile ? "EC3" : "EC2") : "ACI 318";

    public string ConcreteUltimateStrainLabel => IsEc2 ? (IsEurocodeEc3Profile ? "\u03b5cu3" : "\u03b5cu2") : "\u03b5cu";
    public string ConcretePeakStrainLabel => IsEc2 ? (IsEurocodeEc3Profile ? "\u03b5c3" : "\u03b5c2") : "\u03b5c0";

    public double EpsilonC2
    {
        get
        {
            if (IsEc2)
            {
                double fck = result.FcMpa;
                return IsEurocodeEc3Profile
                    ? EurocodeConcreteStrainProfileValues.Ec3Peak(fck)
                    : EurocodeConcreteStrainProfileValues.Ec2Peak(fck);
            }
            else
            {
                return 0.0020;
            }
        }
    }

    public double EpsilonCu2
    {
        get
        {
            if (IsEc2)
            {
                return EurocodeConcreteStrainProfileValues.Ec2Ultimate(result.FcMpa);
            }
            else
            {
                return 0.003;
            }
        }
    }

    public double EpsilonYd
    {
        get
        {
            if (IsEc2)
            {
                double fyd = result.FyMpa / 1.15;
                return result.EsMpa > 0 ? fyd / result.EsMpa : 0.0;
            }
            else
            {
                return result.EsMpa > 0 ? result.FyMpa / result.EsMpa : 0.0;
            }
        }
    }

    public double EpsilonUd
    {
        get
        {
            if (IsEc2)
            {
                return 0.045;
            }
            else
            {
                return 0.08;
            }
        }
    }

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
            return $"No rows to export. Units: P [{ForceUnitLabel}], Mx/My/M\u03b8 [{MomentUnitLabel}], Neutral Axis Depth [{LengthUnitLabel}]";
        }

        int thetaCount = preview.ThetaValues.Count;
        string datasetLabel = thetaCount == 1 ? "theta dataset" : "theta datasets";
        return $"{preview.Rows.Count} rows across {thetaCount} {datasetLabel}. Units: P [{ForceUnitLabel}], Mx/My/M\u03b8 [{MomentUnitLabel}], Neutral Axis Depth [{LengthUnitLabel}]";
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
        AppNotificationDialog.Show(
            $"Exported {PreviewRows.Count} preview rows to:\n{dialog.FileName}",
            "Export Complete",
            MessageBoxImage.Information,
            owner: System.Windows.Application.Current.MainWindow);
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
