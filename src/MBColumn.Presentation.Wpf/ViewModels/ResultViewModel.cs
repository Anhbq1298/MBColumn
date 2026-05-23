using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
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
    public string PDisplay => $"{Pu:F1}";
    public string MxDisplay => $"{Mux:F1}";
    public string MyDisplay => $"{Muy:F1}";
    public string AngleDisplay => $"{AngleDegrees:F1}\u00b0";
    public string UtilizationDisplay => $"{Utilization:F3}";
    public string StatusDisplay => IsPass ? "PASS" : "FAIL";
    public bool IsFailing => !IsPass;
}

public sealed class ResultViewModel : ViewModelBase
{
    private readonly PmChartInsetBuilderService insetBuilder = new();
    private readonly PmChartInsetStateResolverService insetStateResolver = new();
    private readonly IControlPointExportDialogService controlPointExportDialogService;
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
    private IReadOnlyList<ControlPointDto> mxMyPoints = [];
    private IReadOnlyList<ChartReferenceLineDto> pmReferenceLines = [];
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
        : this(new ControlPointExportDialogService())
    {
    }

    public ResultViewModel(IControlPointExportDialogService controlPointExportDialogService)
    {
        this.controlPointExportDialogService = controlPointExportDialogService;
        PM = new PMDiagramViewModel();
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
            new(DiagramViewportType.Pmm3D, "3D PMM", true),
            new(DiagramViewportType.MxMy2D, "2D Mx-My", false)
        };
        foreach (var opt in ViewportOptions)
            opt.PropertyChanged += (_, e) => { if (e.PropertyName == nameof(ViewportOptionViewModel.IsSelected)) OnViewportSelectionChanged(); };
        OnViewportSelectionChanged();

        PropagateDisplaySettings();
    }

    public PMDiagramViewModel PM { get; }
    public MMDiagramViewModel MM { get; }
    public PM3DViewModel PM3D { get; }
    public MM3DViewModel MM3D { get; }
    public CalculationResultDto? Result
    {
        get => result;
        set
        {
            Set(ref result, value);
            
            if (value != null && value.ControlPoints.PmmSurfacePoints.Count > 0)
            {
                var pRange = value.ControlPoints.PmmSurfacePoints.Max(p => p.DisplayP) - value.ControlPoints.PmmSurfacePoints.Min(p => p.DisplayP);
                var mxMax = value.ControlPoints.PmmSurfacePoints.Max(p => Math.Abs(p.DisplayMx));
                var myMax = value.ControlPoints.PmmSurfacePoints.Max(p => Math.Abs(p.DisplayMy));
                
                PStep = CalculateNiceStep(pRange);
                MStep = CalculateNiceStep(Math.Max(mxMax * 2, myMax * 2));
                MStepX = CalculateNiceStep(mxMax * 2);
                MStepY = CalculateNiceStep(myMax * 2);
            }
            
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
            var fUnit = value?.ControlPointTable?.ForceUnitLabel ?? value?.MxMyDiagram?.PUnit ?? "";
            var mUnit = value?.ControlPointTable?.MomentUnitLabel ?? value?.MxMyDiagram?.MUnit ?? "";
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
            Raise(nameof(IsAciCode));
        }
    }
    public IReadOnlyList<ControlPointDto> PmAnglePoints { get => pmAnglePoints; private set => Set(ref pmAnglePoints, value); }
    public IReadOnlyList<ControlPointDto> MxMyPoints { get => mxMyPoints; private set => Set(ref mxMyPoints, value); }
    public IReadOnlyList<ChartReferenceLineDto> PmReferenceLines { get => pmReferenceLines; private set => Set(ref pmReferenceLines, value); }
    public PmChartInsetFigureDto? PmChartInset { get => pmChartInset; private set => Set(ref pmChartInset, value); }
    public IReadOnlyList<LoadCaseResultRowViewModel> LoadCaseRows { get => loadCaseRows; private set => Set(ref loadCaseRows, value); }
    public string? HighlightedDemandLabel => selectedLoadCaseRow?.Name;
    public LoadCaseResultRowViewModel? SelectedLoadCaseRow
    {
        get => selectedLoadCaseRow;
        set
        {
            if (Equals(selectedLoadCaseRow, value)) return;
            Set(ref selectedLoadCaseRow, value);
            Raise(nameof(HighlightedDemandLabel));
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
    public bool IsAciCode => Result?.DesignCode == DesignCodeType.Aci318Style;
    public double PmmRatio => Result?.Ratio ?? 0;
    public double MaxUtilization => LoadCaseRows.Count == 0 ? PmmRatio : LoadCaseRows.Max(r => r.Utilization);
    public double Pu => Result?.PuDisplay ?? 0;
    public double Mux => Result?.MuxDisplay ?? 0;
    public double Muy => Result?.MuyDisplay ?? 0;
    public double Phi => Result?.Phi ?? 0;
    public double ThetaDegrees => Result?.GoverningThetaDegrees ?? 0;
    public double NeutralAxisDepth => Result is null ? 0 : Result.UnitSystem == UnitSystem.Imperial ? Result.GoverningNeutralAxisDepth / 25.4 : Result.GoverningNeutralAxisDepth;
    public string ForceUnitLabel => Result?.ControlPointTable?.ForceUnitLabel ?? Result?.MxMyDiagram?.PUnit ?? "";
    public string MomentUnitLabel => Result?.ControlPointTable?.MomentUnitLabel ?? Result?.MxMyDiagram?.MUnit ?? "";
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
            var pmAllPoints = pmPoints.Concat(pmDiagram.SpecialCapacityPoints).ToList();
            var pmDiagramWithDemand = pmDiagram with { Points = pmAllPoints };
            PmAnglePoints = pmAllPoints;
            PmReferenceLines = pmDiagram.ReferenceLines;
            PM.LoadPmAngle(pmDiagramWithDemand, Result.Ratio);

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
            PM.LoadPmAngle(null, 0);
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

    // ---- Selected chart point (Task 2) ----

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
    public string SelectedPointMthetaDisplay
    {
        get
        {
            if (SelectedChartPoint is null) return "-";
            double thetaRadians = SelectedChartPoint.ThetaDegrees * Math.PI / 180.0;
            double mtheta = SelectedChartPoint.Mx * Math.Cos(thetaRadians) + SelectedChartPoint.My * Math.Sin(thetaRadians);
            return $"{mtheta:F2} {MomentUnitLabel}";
        }
    }

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
        if (Result is null) return;
        controlPointExportDialogService.ShowDialog(Result, SelectedSliceAngleDegrees, System.Windows.Application.Current.MainWindow);
    }

    private void ExportAllPoints()
    {
        ShowControlPoints();
    }

    // â”€â”€â”€â”€ Viewport selection (Task 6) â”€â”€â”€â”€

    public ObservableCollection<ViewportOptionViewModel> ViewportOptions { get; }

    public bool ShowPM => ViewportOptions.First(v => v.Type == DiagramViewportType.PM2D).IsSelected;
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
        MM.ShowGrid = ShowGrid;
        MM.ShowLabels = ShowLabels;
        PM3D.ShowSurface = ShowSurface3D;
        PM3D.ShowWireframe = ShowSurface3D;
        MM3D.ShowSurface = ShowSurface3D;
        MM3D.ShowWireframe = ShowSurface3D;
    }

    private static double CalculateNiceStep(double range)
    {
        if (range <= 0 || double.IsNaN(range)) return 100.0;
        double roughStep = range / 10.0;
        double magnitude = Math.Pow(10.0, Math.Floor(Math.Log10(roughStep)));
        double normalizedStep = roughStep / magnitude;
        
        double niceMultiplier = 1.0;
        if (normalizedStep >= 5.0) niceMultiplier = 5.0;
        else if (normalizedStep >= 2.0) niceMultiplier = 2.0;
        
        return niceMultiplier * magnitude;
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
            SelectedSliceAngleDegrees,
            Result.SectionShape,
            Result.IrregularSectionBoundaryPoints);
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

