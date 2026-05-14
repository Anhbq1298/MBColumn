using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed record LoadCaseResultRowViewModel(
    string Id,
    string Name,
    double Pu,
    double Mux,
    double Muy,
    double AngleDegrees,
    double Utilization,
    bool IsPass,
    bool IsCritical,
    string ForceUnit,
    string MomentUnit)
{
    public string PDisplay => $"{Pu:F2}";
    public string MxDisplay => $"{Mux:F2}";
    public string MyDisplay => $"{Muy:F2}";
    public string AngleDisplay => $"{AngleDegrees:F1}\u00b0";
    public string UtilizationDisplay => $"{Utilization:F3}";
    public string StatusDisplay => IsPass ? "PASS" : "FAIL";
    public bool IsFailing => !IsPass;
}

public sealed class ResultViewModel : ViewModelBase
{
    private readonly PmChartInsetBuilderService insetBuilder = new();
    private readonly PmChartInsetStateResolverService insetStateResolver = new();
    private CalculationResultDto? result;
    private RelayCommand showControlPointsCommand = null!;
    private RelayCommand exportAllPointsCommand = null!;
    private bool showGrid = true;
    private bool showLabels = true;
    private bool showLegend = true;
    private bool showDemandPoint = true;
    private bool showPmaxPmin;
    private bool showSurface3D = true;
    private bool showWireframe3D = true;
    private bool showNominalCurve = true;
    private bool useEqualAspectForMM = true;
    private ControlPointDto? selectedChartPoint;
    private IReadOnlyList<ControlPointDto> pmAnglePoints = [];
    private IReadOnlyList<ControlPointDto> pmXPoints = [];
    private IReadOnlyList<ControlPointDto> pmYPoints = [];
    private IReadOnlyList<ControlPointDto> mxMyPoints = [];
    private IReadOnlyList<ChartReferenceLineDto> pmReferenceLines = [];
    private IReadOnlyList<ChartReferenceLineDto> pmXReferenceLines = [];
    private IReadOnlyList<ChartReferenceLineDto> pmYReferenceLines = [];
    private PmChartInsetFigureDto? pmChartInset;
    private IReadOnlyList<LoadCaseResultRowViewModel> loadCaseRows = [];
    private LoadCaseResultRowViewModel? selectedLoadCaseRow;
    private double selectedSliceAngleDegrees;
    private double selectedAxialLoad;
    private double pmPGridStep = 2000.0;
    private double pmMGridStep = 500.0;
    private double mmMxGridStep = 500.0;
    private double mmMyGridStep = 500.0;
    private Rect? sharedPmBounds;
    private int layoutVersion;
    private bool isApplyingLoadCaseSelection;

    public ResultViewModel()
    {
        PM = new PMDiagramViewModel();
        PMx = new PMDiagramViewModel();
        PMy = new PMDiagramViewModel();
        MM = new MMDiagramViewModel();
        PM3D = new PM3DViewModel();
        MM3D = new MM3DViewModel();
        ToggleGridCommand = new RelayCommand(() => ShowGrid = !ShowGrid);
        ToggleLabelsCommand = new RelayCommand(() => ShowLabels = !ShowLabels);
        ToggleLegendCommand = new RelayCommand(() => ShowLegend = !ShowLegend);
        ToggleDemandPointCommand = new RelayCommand(() => ShowDemandPoint = !ShowDemandPoint);
        TogglePmaxPminCommand = new RelayCommand(() => ShowPmaxPmin = !ShowPmaxPmin);
        ToggleEqualAspectCommand = new RelayCommand(() => UseEqualAspectForMM = !UseEqualAspectForMM);
        ToggleSurface3DCommand = new RelayCommand(() => ShowSurface3D = !ShowSurface3D);
        ToggleWireframe3DCommand = new RelayCommand(() => ShowWireframe3D = !ShowWireframe3D);
        UpdateSliceAngleCommand = new RelayCommand(ApplyNavigation);
        UpdateAxialLoadCommand = new RelayCommand(ApplyNavigation);
        ResetAllChartsCommand = new RelayCommand(Reset3DCharts);
        FitAllChartsCommand = new RelayCommand(Reset3DCharts);
        Reset3DChartsCommand = new RelayCommand(Reset3DCharts);
        ClearSelectedChartPointCommand = new RelayCommand(() => SelectedChartPoint = null);
        ResetViewportsCommand = new RelayCommand(ResetViewports);
        CloseViewportCommand = new RelayCommand<DiagramViewportType>(CloseViewport);
        showControlPointsCommand = new RelayCommand(ShowControlPoints, () => HasResult);
        ShowControlPointsCommand = showControlPointsCommand;
        exportAllPointsCommand = new RelayCommand(ExportAllPoints, () => HasResult);
        ExportAllPointsCommand = exportAllPointsCommand;

        // Viewport options
        ViewportOptions = new ObservableCollection<ViewportOptionViewModel>
        {
            new(DiagramViewportType.PM2D, "2D PM", true),
            new(DiagramViewportType.PMx2D, "2D PMx", false),
            new(DiagramViewportType.PMy2D, "2D PMy", false),
            new(DiagramViewportType.Pmm3D, "3D PMM", true),
            new(DiagramViewportType.MxMy2D, "2D Mx-My", false)
        };
        foreach (var opt in ViewportOptions)
            opt.PropertyChanged += (_, e) => { if (e.PropertyName == nameof(ViewportOptionViewModel.IsSelected)) OnViewportSelectionChanged(); };
        OnViewportSelectionChanged();

        PropagateDisplaySettings();
    }

    public PMDiagramViewModel PM { get; }
    public PMDiagramViewModel PMx { get; }
    public PMDiagramViewModel PMy { get; }
    public MMDiagramViewModel MM { get; }
    public PM3DViewModel PM3D { get; }
    public MM3DViewModel MM3D { get; }
    public CalculationResultDto? Result
    {
        get => result;
        set
        {
            Set(ref result, value);
            showPmaxPmin = false;
            Raise(nameof(ShowPmaxPmin));
            MM.Load(value);
            PM3D.Load(value);
            MM3D.Load(value);
            selectedSliceAngleDegrees = value?.GoverningThetaDegrees ?? 0;
            selectedAxialLoad = value?.PuDisplay ?? 0;
            // Task F fix: raise so TextBoxes reflect the newly loaded values
            Raise(nameof(SelectedSliceAngleDegrees));
            Raise(nameof(SelectedAxialLoad));
            // Build load case result rows
            var govId = value?.GoverningLoadCaseId ?? "";
            var fUnit = value?.PmXDiagram?.PUnit ?? "";
            var mUnit = value?.PmXDiagram?.MUnit ?? "";
            loadCaseRows = value?.LoadCaseResults?.Count > 0
                ? value.LoadCaseResults.Select(r => new LoadCaseResultRowViewModel(
                    r.LoadCaseId, r.LoadCaseName,
                    r.PuDisplay, r.MuxDisplay, r.MuyDisplay,
                    DemandVectorAngle(r.MuxDisplay, r.MuyDisplay),
                    r.PmmRatio, r.Status == CapacityStatus.Pass,
                    r.LoadCaseId == govId, fUnit, mUnit)).ToList()
                : [];
            Raise(nameof(LoadCaseRows));
            Raise(nameof(HasLoadCaseRows));
            Raise(nameof(GoverningLoadCaseName));
            Raise(nameof(CriticalLoadCaseName));
            Raise(nameof(MaxUtilization));
            SelectedLoadCaseRow = loadCaseRows.FirstOrDefault(r => r.IsCritical);
            ApplyNavigation();
            SelectedChartPoint = null;
            Raise(nameof(HasResult));
            showControlPointsCommand.RaiseCanExecuteChanged();
            exportAllPointsCommand.RaiseCanExecuteChanged();
            Raise(nameof(StatusText));
            Raise(nameof(PmmRatio));
            Raise(nameof(Pu));
            Raise(nameof(Mux));
            Raise(nameof(Muy));
            Raise(nameof(Phi));
            Raise(nameof(ThetaDegrees));
            Raise(nameof(NeutralAxisDepth));
            Raise(nameof(ForceUnitLabel));
            Raise(nameof(MomentUnitLabel));
            Raise(nameof(LengthUnitLabel));
            Raise(nameof(SelectedPmAngleText));
            Raise(nameof(SelectedPuLevelText));
            RaiseNavigationLabels();
        }
    }
    public IReadOnlyList<ControlPointDto> PmAnglePoints { get => pmAnglePoints; private set => Set(ref pmAnglePoints, value); }
    public IReadOnlyList<ControlPointDto> PmXPoints { get => pmXPoints; private set => Set(ref pmXPoints, value); }
    public IReadOnlyList<ControlPointDto> PmYPoints { get => pmYPoints; private set => Set(ref pmYPoints, value); }
    public IReadOnlyList<ControlPointDto> MxMyPoints { get => mxMyPoints; private set => Set(ref mxMyPoints, value); }
    public IReadOnlyList<ChartReferenceLineDto> PmReferenceLines { get => pmReferenceLines; private set => Set(ref pmReferenceLines, value); }
    public IReadOnlyList<ChartReferenceLineDto> PmXReferenceLines { get => pmXReferenceLines; private set => Set(ref pmXReferenceLines, value); }
    public IReadOnlyList<ChartReferenceLineDto> PmYReferenceLines { get => pmYReferenceLines; private set => Set(ref pmYReferenceLines, value); }
    public PmChartInsetFigureDto? PmChartInset { get => pmChartInset; private set => Set(ref pmChartInset, value); }
    public IReadOnlyList<LoadCaseResultRowViewModel> LoadCaseRows { get => loadCaseRows; private set => Set(ref loadCaseRows, value); }
    public LoadCaseResultRowViewModel? SelectedLoadCaseRow
    {
        get => selectedLoadCaseRow;
        set
        {
            if (Equals(selectedLoadCaseRow, value)) return;
            Set(ref selectedLoadCaseRow, value);
            if (value != null)
            {
                SelectedChartPoint = null;
                isApplyingLoadCaseSelection = true;
                try
                {
                    SelectedSliceAngleDegrees = value.AngleDegrees;
                    SelectedAxialLoad = value.Pu;
                }
                finally
                {
                    isApplyingLoadCaseSelection = false;
                }
            }
            UpdatePmChartInset();
        }
    }
    public Rect? SharedPmBounds { get => sharedPmBounds; private set => Set(ref sharedPmBounds, value); }
    public bool HasResult => Result is not null;
    public bool HasLoadCaseRows => loadCaseRows.Count > 0;
    public string StatusText => Result is null ? "Not calculated" : Result.Status == CapacityStatus.Pass ? "PASS" : "FAIL";
    public double PmmRatio => Result?.Ratio ?? 0;
    public double MaxUtilization => LoadCaseRows.Count == 0 ? PmmRatio : LoadCaseRows.Max(r => r.Utilization);
    public double Pu => Result?.PuDisplay ?? 0;
    public double Mux => Result?.MuxDisplay ?? 0;
    public double Muy => Result?.MuyDisplay ?? 0;
    public double Phi => Result?.Phi ?? 0;
    public double ThetaDegrees => Result?.GoverningThetaDegrees ?? 0;
    public double NeutralAxisDepth => Result is null ? 0 : Result.UnitSystem == UnitSystem.Imperial ? Result.GoverningNeutralAxisDepth / 25.4 : Result.GoverningNeutralAxisDepth;
    public string ForceUnitLabel => Result?.PmXDiagram?.PUnit ?? "";
    public string MomentUnitLabel => Result?.PmXDiagram?.MUnit ?? "";
    public string LengthUnitLabel => Result is null ? "" : Result.UnitSystem == UnitSystem.Imperial ? "in" : "mm";
    public string GoverningLoadCaseName => Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == (Result?.GoverningLoadCaseId ?? ""))?.LoadCaseName ?? "";
    public string CriticalLoadCaseName => string.IsNullOrWhiteSpace(GoverningLoadCaseName) ? "-" : GoverningLoadCaseName;
    public string SelectedPmAngleText => $"{SelectedSliceAngleDegrees:F1} deg";
    public string SelectedPuLevelText => $"{SelectedAxialLoad:F2} {ForceUnitLabel}";
    public double SelectedSliceAngleDegrees
    {
        get => selectedSliceAngleDegrees;
        set
        {
            if (!isApplyingLoadCaseSelection)
            {
                ClearExplicitInspectionState();
            }

            Set(ref selectedSliceAngleDegrees, NormalizeAngle(value));
            ApplyNavigation();
        }
    }

    public double SelectedAxialLoad
    {
        get => selectedAxialLoad;
        set
        {
            if (!isApplyingLoadCaseSelection)
            {
                ClearExplicitInspectionState();
            }

            Set(ref selectedAxialLoad, value);
            ApplyNavigation();
        }
    }
    public string SelectedSliceAngleDisplay => $"{SelectedSliceAngleDegrees:F1} deg";
    public string SelectedAxialLoadDisplay => $"{SelectedAxialLoad:F1} {ForceUnitLabel}";
    public string PmSliceLabel => $"PM at \u03b8 = {SelectedSliceAngleDegrees:F1}\u00b0";
    public string MxMySliceLabel => $"Mx-My at P = {SelectedAxialLoad:F1} {ForceUnitLabel}";
    public ICommand UpdateSliceAngleCommand { get; }
    public ICommand UpdateAxialLoadCommand { get; }

    private void ApplyNavigation()
    {
        PM3D.SelectedPmAngleDegrees = SelectedSliceAngleDegrees;
        PM3D.SelectedAxialLoad = SelectedAxialLoad;

        if (Result is not null)
        {
            var diagramService = new DiagramDataService();
            var pmDiagram = diagramService.BuildPmAngleDiagramData(Result.ControlPoints, Result.UnitSystem, SelectedSliceAngleDegrees);
            var pmPoints = ReplaceDemandAndRemoveGoverning(pmDiagram.Points, diagramService.BuildPmAngleDemandPoints(Result.LoadCaseResults, SelectedSliceAngleDegrees));
            var pmDiagramWithDemand = pmDiagram with { Points = pmPoints };
            PmAnglePoints = pmDiagramWithDemand.Points;
            PmReferenceLines = pmDiagram.ReferenceLines;
            PM.LoadPmAngle(pmDiagramWithDemand, Result.Ratio);

            var pmXDiagram = Result.PmXDiagram;
            var pmXDemand = diagramService.BuildPmAngleDemandPoints(Result.LoadCaseResults, 0.0);
            var pmXPoints = ReplaceDemandAndRemoveGoverning(pmXDiagram.Points, pmXDemand);
            pmXPoints = pmXPoints.Concat(GetLabeledPointsForPMx(Result.ControlPointTable)).ToList();
            PmXPoints = pmXPoints;
            PmXReferenceLines = [];
            PMx.LoadPmX(Result);

            var pmYDiagram = Result.PmYDiagram;
            var pmYDemand = diagramService.BuildPmAngleDemandPoints(Result.LoadCaseResults, 90.0);
            var pmYPoints = ReplaceDemandAndRemoveGoverning(pmYDiagram.Points, pmYDemand);
            pmYPoints = pmYPoints.Concat(GetLabeledPointsForPMy(Result.ControlPointTable)).ToList();
            PmYPoints = pmYPoints;
            PmYReferenceLines = [];
            PMy.LoadPmY(Result);

            UpdateSharedPmBoundsFromAnglePoints(pmDiagramWithDemand.Points);

            var mmDiagram = diagramService.BuildMxMyDiagramDataAtDisplayP(Result.ControlPoints, Result.UnitSystem, SelectedAxialLoad);
            var mxMyPoints = ReplaceDemandAndRemoveGoverning(mmDiagram.Points, diagramService.BuildMxMyDemandPoints(Result.LoadCaseResults));
            var mmDiagramWithDemand = mmDiagram with { Points = mxMyPoints };
            MxMyPoints = mmDiagramWithDemand.Points;
            MM.Load(mmDiagramWithDemand, Result.Ratio);
            PM3D.DemandPoints = diagramService.BuildPmmDemandPoints(Result.LoadCaseResults);
        }
        else
        {
            PmAnglePoints = [];
            PmReferenceLines = [];
            PmXPoints = [];
            PmXReferenceLines = [];
            PmYPoints = [];
            PmYReferenceLines = [];
            PM.LoadPmAngle(null, 0);
            PMx.LoadPmAngle(null, 0);
            PMx.OverrideTitleAndXAxis("PMx Diagram", "Mx");
            PMy.LoadPmAngle(null, 0);
            PMy.OverrideTitleAndXAxis("PMy Diagram", "My");
            MxMyPoints = [];
            MM.Load(null, 0);
            PM3D.DemandPoints = [];
            SharedPmBounds = null;
        }

        UpdatePmChartInset();
        Raise(nameof(SelectedPmAngleText));
        Raise(nameof(SelectedPuLevelText));
        RaiseNavigationLabels();
    }

    private void ClearExplicitInspectionState()
    {
        if (selectedLoadCaseRow is not null)
        {
            Set(ref selectedLoadCaseRow, null, nameof(SelectedLoadCaseRow));
        }

        if (selectedChartPoint is not null)
        {
            Set(ref selectedChartPoint, null, nameof(SelectedChartPoint));
            RaiseSelectedPointProperties();
        }
    }

    private static IReadOnlyList<ControlPointDto> GetLabeledPointsForPMx(ControlPointTableDto? table)
    {
        if (table == null) return [];
        return table.Rows.Where(r => r.Axis == "X" || r.Axis == "-X")
            .Select(r => new ControlPointDto(
                DiagramType.PM, r.Mx != 0 ? Math.Abs(r.Mx) : Math.Abs(r.My), r.P, r.P, r.P, r.Mx, r.My, r.Phi, 90.0, r.NaDepth,
                r.PointLabel, "LabeledPoint", false, false, true, false))
            .ToList();
    }

    private static IReadOnlyList<ControlPointDto> GetLabeledPointsForPMy(ControlPointTableDto? table)
    {
        if (table == null) return [];
        return table.Rows.Where(r => r.Axis == "Y" || r.Axis == "-Y")
            .Select(r => new ControlPointDto(
                DiagramType.PM, r.My != 0 ? Math.Abs(r.My) : Math.Abs(r.Mx), r.P, r.P, r.P, r.Mx, r.My, r.Phi, 0.0, r.NaDepth,
                r.PointLabel, "LabeledPoint", false, false, true, false))
            .ToList();
    }

    private static IReadOnlyList<ControlPointDto> ReplaceDemandAndRemoveGoverning(IReadOnlyList<ControlPointDto> points, IReadOnlyList<ControlPointDto> demandPoints)
        => points.Where(p => !p.IsDemand && !p.IsGoverning).Concat(demandPoints).ToList();

    private void RaiseNavigationLabels()
    {
        Raise(nameof(SelectedSliceAngleDisplay));
        Raise(nameof(SelectedAxialLoadDisplay));
        Raise(nameof(PmSliceLabel));
        Raise(nameof(MxMySliceLabel));
    }

    private static double NormalizeAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle)) return 0;
        var normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    private static double DemandVectorAngle(double mx, double my)
    {
        if (Math.Abs(mx) < 1e-12 && Math.Abs(my) < 1e-12) return 0;
        return NormalizeAngle(Math.Atan2(my, mx) * 180.0 / Math.PI);
    }

    private void UpdateSharedPmBounds(CalculationResultDto? result)
    {
        if (result != null && result.PmXDiagram.Points.Count > 0 && result.PmYDiagram.Points.Count > 0)
        {
            var xPts = result.PmXDiagram.Points;
            var yPts = result.PmYDiagram.Points;
            double minP = Math.Min(xPts.Min(p => p.Y), yPts.Min(p => p.Y));
            double maxP = Math.Max(xPts.Max(p => p.Y), yPts.Max(p => p.Y));
            double maxAbsM = Math.Max(
                xPts.Max(p => Math.Max(Math.Abs(p.X), Math.Abs(p.X))), // Wait, p.X is the absolute value already for symmetric? Wait, for non-symmetric it might be negative. Let's just use Math.Abs(p.X).
                yPts.Max(p => Math.Max(Math.Abs(p.X), Math.Abs(p.X))));
            
            // Recompute maxAbsM properly
            double maxAbsMx = xPts.Max(p => Math.Abs(p.X));
            double maxAbsMy = yPts.Max(p => Math.Abs(p.X));
            double finalMaxM = Math.Max(maxAbsMx, maxAbsMy);
            
            SharedPmBounds = new Rect(new Point(-finalMaxM, minP), new Point(finalMaxM, maxP));
        }
        else
        {
            SharedPmBounds = null;
        }
    }

    private void UpdateSharedPmBoundsFromAnglePoints(IReadOnlyList<ControlPointDto> points)
    {
        var visible = points.Where(p => !p.IsDemand && !p.IsGoverning).ToList();
        if (visible.Count == 0)
        {
            SharedPmBounds = null;
            return;
        }

        double minP = visible.Min(p => p.Y);
        double maxP = visible.Max(p => p.Y);
        double maxAbsM = visible.Max(p => Math.Abs(p.X));
        SharedPmBounds = new Rect(new Point(-maxAbsM, minP), new Point(maxAbsM, maxP));
    }

    // â”€â”€â”€â”€ Selected chart point (Task 2) â”€â”€â”€â”€

    public ControlPointDto? SelectedChartPoint
    {
        get => selectedChartPoint;
        set
        {
            Set(ref selectedChartPoint, value);
            RaiseSelectedPointProperties();
            UpdatePmChartInset();
        }
    }

    public bool HasSelectedPoint => SelectedChartPoint is not null;
    public bool SelectedPointIsPm => SelectedChartPoint?.DiagramType == DiagramType.PM;
    public string SelectedPointPDisplay => SelectedChartPoint is null ? "-" : $"{SelectedChartPoint.P:F2} {ForceUnitLabel}";
    public string SelectedPointMxDisplay => SelectedChartPoint is null ? "-" : $"{SelectedChartPoint.Mx:F2} {MomentUnitLabel}";
    public string SelectedPointMyDisplay => SelectedChartPoint is null ? "-" : $"{SelectedChartPoint.My:F2} {MomentUnitLabel}";
    public string SelectedPointMthetaDisplay => SelectedChartPoint?.DiagramType == DiagramType.PM ? $"{SelectedChartPoint.X:F2} {MomentUnitLabel}" : "-";

    public string SelectedPointTypeDisplay
    {
        get
        {
            if (SelectedChartPoint is null) return "-";
            if (SelectedChartPoint.IsDemand) return "Demand";
            if (SelectedChartPoint.IsReference) return "Reference";
            return SelectedChartPoint.IsNominal ? "Nominal Capacity" : "Design Capacity";
        }
    }

    public string SelectedPointPhiDisplay => SelectedChartPoint is null ? "-" : $"{SelectedChartPoint.Phi:F3}";
    public string SelectedPointThetaDisplay => SelectedChartPoint is null ? "-" : $"{SelectedChartPoint.ThetaDegrees:F1} deg";
    public string SelectedPointNeutralAxisDepthDisplay
    {
        get
        {
            if (SelectedChartPoint is null) return "-";
            double c = Result?.UnitSystem == UnitSystem.Imperial ? SelectedChartPoint.NeutralAxisDepth / 25.4 : SelectedChartPoint.NeutralAxisDepth;
            return $"{c:F1} {LengthUnitLabel}";
        }
    }
    public string SelectedPointDcrDisplay => SelectedChartPoint is null ? "-" : $"{(SelectedChartPoint.IsDemand && SelectedChartPoint.Utilization > 0 ? SelectedChartPoint.Utilization : PmmRatio):F3}";

    public ICommand ClearSelectedChartPointCommand { get; }
    public ICommand ShowControlPointsCommand { get; }
    public ICommand ExportAllPointsCommand { get; }

    private void RaiseSelectedPointProperties()
    {
        Raise(nameof(HasSelectedPoint));
        Raise(nameof(SelectedPointIsPm));
        Raise(nameof(SelectedPointPDisplay));
        Raise(nameof(SelectedPointMxDisplay));
        Raise(nameof(SelectedPointMyDisplay));
        Raise(nameof(SelectedPointMthetaDisplay));
        Raise(nameof(SelectedPointTypeDisplay));
        Raise(nameof(SelectedPointPhiDisplay));
        Raise(nameof(SelectedPointThetaDisplay));
        Raise(nameof(SelectedPointNeutralAxisDepthDisplay));
        Raise(nameof(SelectedPointDcrDisplay));
    }

    private void ShowControlPoints()
    {
        if (Result?.ControlPointTable is null) return;
        var win = new ControlPointsWindow(Result.ControlPointTable) { Owner = System.Windows.Application.Current.MainWindow };
        win.Show();
    }

    private void ExportAllPoints()
    {
        if (Result is null) return;

        var dlg = new SaveFileDialog
        {
            Title = "Export PMM Points",
            Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt",
            FilterIndex = 1,
            DefaultExt = "csv",
            FileName = "PMM_Points"
        };

        if (dlg.ShowDialog(System.Windows.Application.Current.MainWindow) != true)
            return;

        bool isCsv = Path.GetExtension(dlg.FileName).Equals(".csv", StringComparison.OrdinalIgnoreCase);
        string delim = isCsv ? "," : "\t";
        bool isImperial = Result.UnitSystem == UnitSystem.Imperial;

        string[] headers =
        [
            "theTa",
            $"P ({ForceUnitLabel})",
            $"Mx ({MomentUnitLabel})",
            $"My ({MomentUnitLabel})",
            $"NA Depth ({LengthUnitLabel})",
            "phi"
        ];

        var sb = new StringBuilder();

        var groups = Result.ControlPoints.PmPoints
            .Where(p => !p.IsDemandPoint && !p.IsGoverningPoint)
            .GroupBy(p => Math.Round(p.ThetaDegrees, 1))
            .OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            // Section label + header immediately below it
            sb.AppendLine($"theta = {group.Key:F1} deg  ({group.Count()} points)");
            sb.AppendLine(Join(delim, isCsv, headers));

            foreach (var pt in group.OrderByDescending(p => p.DisplayP))
            {
                double naDisplay = isImperial ? pt.NeutralAxisDepth / 25.4 : pt.NeutralAxisDepth;
                sb.AppendLine(Join(delim, isCsv,
                [
                    $"{pt.ThetaDegrees:F1}",
                    $"{pt.DisplayP:F2}",
                    $"{pt.DisplayMx:F2}",
                    $"{pt.DisplayMy:F2}",
                    $"{naDisplay:F1}",
                    $"{pt.Phi:F3}"
                ]));
            }

            sb.AppendLine();
        }

        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

        int total = Result.ControlPoints.PmPoints.Count(p => !p.IsDemandPoint && !p.IsGoverningPoint);
        MessageBox.Show(System.Windows.Application.Current.MainWindow,
            $"Exported {total} points across {groups.Count()} angle slices to:\n{dlg.FileName}",
            "Export Complete",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    private static string Join(string delim, bool isCsv, string[] values)
        => string.Join(delim, values.Select(v => isCsv && (v.Contains(',') || v.Contains('"')) ? $"\"{v.Replace("\"", "\"\"")}\"" : v));

    // â”€â”€â”€â”€ Viewport selection (Task 6) â”€â”€â”€â”€

    public ObservableCollection<ViewportOptionViewModel> ViewportOptions { get; }

    public bool ShowPM => ViewportOptions.First(v => v.Type == DiagramViewportType.PM2D).IsSelected;
    public bool ShowPMx => ViewportOptions.First(v => v.Type == DiagramViewportType.PMx2D).IsSelected;
    public bool ShowPMy => ViewportOptions.First(v => v.Type == DiagramViewportType.PMy2D).IsSelected;
    public bool ShowMxMy => ViewportOptions.First(v => v.Type == DiagramViewportType.MxMy2D).IsSelected;
    public bool ShowPmm3D => ViewportOptions.First(v => v.Type == DiagramViewportType.Pmm3D).IsSelected;

    public int ActiveViewportCount => ViewportOptions.Count(v => v.IsSelected);

    public string ViewportDropdownText
    {
        get
        {
            int count = ActiveViewportCount;
            if (count == 1) return ViewportOptions.First(v => v.IsSelected).DisplayName;
            return $"{count} Viewports";
        }
    }

    // Layout: all viewports in one row â€” no empty cells, charts auto-stretch
    public int LayoutColumns => ActiveViewportCount <= 1 ? 1 : ActiveViewportCount <= 4 ? 2 : 3;
    public int LayoutRows => Math.Max(1, (int)Math.Ceiling(ActiveViewportCount / (double)LayoutColumns));

    public int LayoutVersion { get => layoutVersion; private set => Set(ref layoutVersion, value); }

    public ICommand ResetViewportsCommand { get; }
    public ICommand CloseViewportCommand { get; }

    public void ToggleViewport(DiagramViewportType type)
    {
        var option = ViewportOptions.FirstOrDefault(v => v.Type == type);
        if (option is null) return;
        // Prevent unchecking the last viewport
        if (option.IsSelected && ActiveViewportCount <= 1) return;
        option.IsSelected = !option.IsSelected;
    }

    public void CloseViewport(DiagramViewportType type) => ToggleViewport(type);

    private void OnViewportSelectionChanged()
    {
        LayoutVersion++;
        Raise(nameof(ShowPMx));
        Raise(nameof(ShowPMy));
        Raise(nameof(ShowPM));
        Raise(nameof(ShowMxMy));
        Raise(nameof(ShowPmm3D));
        Raise(nameof(ActiveViewportCount));
        Raise(nameof(ViewportDropdownText));
        Raise(nameof(LayoutColumns));
        Raise(nameof(LayoutRows));
    }

    private void ResetViewports()
    {
        foreach (var opt in ViewportOptions) opt.IsSelected = true;
    }

    // â”€â”€â”€â”€ Display toggles â”€â”€â”€â”€

    public bool ShowGrid { get => showGrid; set { Set(ref showGrid, value); PropagateDisplaySettings(); } }
    public bool ShowLabels { get => showLabels; set { Set(ref showLabels, value); PropagateDisplaySettings(); } }
    public bool ShowLegend { get => showLegend; set => Set(ref showLegend, value); }
    public bool ShowDemandPoint { get => showDemandPoint; set => Set(ref showDemandPoint, value); }
    public bool ShowPmaxPmin { get => showPmaxPmin; set => Set(ref showPmaxPmin, value); }
    public bool ShowSurface3D { get => showSurface3D; set { Set(ref showSurface3D, value); PropagateDisplaySettings(); } }
    public bool ShowWireframe3D { get => showWireframe3D; set { Set(ref showWireframe3D, value); PropagateDisplaySettings(); } }
    public bool ShowNominalCurve { get => showNominalCurve; set => Set(ref showNominalCurve, value); }
    public bool UseEqualAspectForMM { get => useEqualAspectForMM; set => Set(ref useEqualAspectForMM, value); }
    public double PStep { get => pmPGridStep; set => Set(ref pmPGridStep, SanitizeGridStep(value)); }
    public double MStep { get => pmMGridStep; set => Set(ref pmMGridStep, SanitizeGridStep(value)); }
    public double MStepX { get => mmMxGridStep; set => Set(ref mmMxGridStep, SanitizeGridStep(value)); }
    public double MStepY { get => mmMyGridStep; set => Set(ref mmMyGridStep, SanitizeGridStep(value)); }

    public ICommand ToggleGridCommand { get; }
    public ICommand ToggleLabelsCommand { get; }
    public ICommand ToggleLegendCommand { get; }
    public ICommand ToggleDemandPointCommand { get; }
    public ICommand TogglePmaxPminCommand { get; }
    public ICommand ToggleEqualAspectCommand { get; }
    public ICommand ToggleSurface3DCommand { get; }
    public ICommand ToggleWireframe3DCommand { get; }
    public ICommand ResetAllChartsCommand { get; }
    public ICommand FitAllChartsCommand { get; }
    public ICommand Reset3DChartsCommand { get; }

    private void PropagateDisplaySettings()
    {
        PM.ShowGrid = ShowGrid;
        PM.ShowLabels = ShowLabels;
        PMx.ShowGrid = ShowGrid;
        PMx.ShowLabels = ShowLabels;
        PMy.ShowGrid = ShowGrid;
        PMy.ShowLabels = ShowLabels;
        MM.ShowGrid = ShowGrid;
        MM.ShowLabels = ShowLabels;
        PM3D.ShowSurface = ShowSurface3D;
        PM3D.ShowWireframe = ShowSurface3D;
        MM3D.ShowSurface = ShowSurface3D;
        MM3D.ShowWireframe = ShowSurface3D;
    }

    private static double SanitizeGridStep(double value)
        => double.IsNaN(value) || double.IsInfinity(value) || value < 0 ? 0.0 : value;

    private void Reset3DCharts()
    {
        PM3D.ResetCameraCommand.Execute(null);
        MM3D.ResetCameraCommand.Execute(null);
    }

    private void UpdatePmChartInset()
    {
        if (Result is null)
        {
            PmChartInset = null;
            return;
        }

        PmChartInset = insetBuilder.Build(
            Result.SectionWidthMm,
            Result.SectionHeightMm,
            Result.CoverMm,
            Result.RebarCoordinates,
            BuildInsetSelectedState(),
            SelectedSliceAngleDegrees);
    }

    private PmChartInsetSelectedStateDto? BuildInsetSelectedState()
    {
        if (Result is null) return null;

        if (SelectedChartPoint is { } point)
        {
            if (point.IsDemand)
            {
                var loadCase = Result.LoadCaseResults.FirstOrDefault(lc => lc.LoadCaseId == point.SliceKey);
                if (loadCase is not null)
                {
                    return insetStateResolver.FromLoadCase(Result, loadCase);
                }
            }

            return insetStateResolver.FromCapacityPoint(point);
        }

        if (SelectedLoadCaseRow is { } row)
        {
            var loadCase = Result.LoadCaseResults.FirstOrDefault(lc => lc.LoadCaseId == row.Id);
            if (loadCase is not null)
            {
                return insetStateResolver.FromLoadCase(Result, loadCase);
            }
        }

        return insetStateResolver.FromNavigation(Result, SelectedSliceAngleDegrees, SelectedAxialLoad);
    }
}

