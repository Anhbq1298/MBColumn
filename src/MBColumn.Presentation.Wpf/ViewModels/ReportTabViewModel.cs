using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Domain.Units;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Reports.Graphics;
using MBColumn.Infrastructure.Reports.Html;
using MBColumn.Presentation.Wpf.Collections;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using MBColumn.Presentation.Wpf.Views;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ReportTabViewModel : ViewModelBase
{
    private readonly DiagramDataService _diagramSvc = new();
    private readonly PmSevenPointReportMapper _pm7Mapper = new();
    private readonly IUnitConversionService _units = new UnitConversionService();
    private readonly ReportWebViewRenderer _htmlRenderer = new();
    private ReportData? _cachedReportData;
    private CalculationResultDto? _cachedResult;
    private CancellationTokenSource? _reportCts;

    // Cached project metadata (set from LoadFromCurrentWorkspace)
    private string _cachedProjectName = "";
    private string _cachedGroupName = "";
    private string _cachedDesignTierName = "";
    private double _cachedLinkDiameterMm;
    private int _cachedTotalLegsX = 2;
    private int _cachedTotalLegsY = 2;

    private bool includeInputData = true;
    private bool includeBoundaryCoordinates = true;
    private bool includeRebarCoordinates = true;
    private bool includeDemandCases = true;
    private bool includeGoverningChart = true;
    private bool includePm7Table = true;
    private bool isOutdated;
    private string resultStatusText = "No result";
    private string projectName = "";
    private string groupName = "";
    private string designTierName = "";
    private string sectionShape = "";
    private string designCode = "";
    private string unitSystem = "";
    private string materialSummary = "";
    private string geometrySummary = "";
    private string rebarSummary = "";
    private string forceUnit = "";
    private string momentUnit = "";
    private bool _suppressToggleUpdate;
    private bool isExportBusy;
    private bool isGeneratingReport;
    private bool isReportPreviewVisible;
    private string reportHtmlContent = "";
    private GoverningChartPreviewViewModel? governingChart;

    private double sectionWidth;
    private double sectionHeight;
    private double clearCover;

    // Interaction diagram chart data
    private IReadOnlyList<ControlPointDto> pmPoints = [];
    private IReadOnlyList<ChartReferenceLineDto> pmReferenceLines = [];
    private IReadOnlyList<ControlPointDto> mmPoints = [];
    private string pmXAxisLabel = "M";
    private string pmYAxisLabel = "P";
    private string mmXAxisLabel = "Mx";
    private string mmYAxisLabel = "My";
    private double pmRatio;
    private double mmRatio;
    private string pmSliceLabel = "P-M Interaction";

    /// <summary>Set by the View so the ViewModel can trigger a WebView2 PDF print.</summary>
    public Func<string, Task>? WebViewPrintToPdfAsync { get; set; }

    /// <summary>Set by the View so the ViewModel can scroll the WebView2 to an anchor.</summary>
    public Action<string>? WebViewScrollToAnchor { get; set; }

    /// <summary>Set by the View to capture the actual PM/MM visualization controls for report figures.</summary>
    public Func<string, DiagramBlock, string?>? ChartSnapshotProvider { get; set; }

    public ReportTabViewModel()
    {
        GeneratePreviewCommand = new RelayCommand(RevealReportPreview, CanRevealReportPreview);
        RevealReportPreviewCommand = GeneratePreviewCommand;
        HideReportPreviewCommand = new RelayCommand(HideReportPreview, () => IsReportPreviewVisible);
        PreviewPdfCommand = new RelayCommand(PreviewPdf, CanExport);
        SaveAsPdfCommand = new RelayCommand(async () => await SaveAsPdfAsync(), CanExport);
        SaveAsHtmlCommand = new RelayCommand(SaveAsHtml, CanExport);
        SelectAllSectionsCommand = new RelayCommand(() => SetAllToggles(true));
        DeselectAllSectionsCommand = new RelayCommand(() => SetAllToggles(false));
        ScrollToSectionCommand = new RelayCommand<string>(ScrollToSection);
    }

    public ICommand GeneratePreviewCommand { get; }
    public ICommand RevealReportPreviewCommand { get; }
    public ICommand HideReportPreviewCommand { get; }
    public ICommand PreviewPdfCommand { get; }
    public ICommand SaveAsPdfCommand { get; }
    public ICommand SaveAsHtmlCommand { get; }
    public ICommand SelectAllSectionsCommand { get; }
    public ICommand DeselectAllSectionsCommand { get; }
    public ICommand ScrollToSectionCommand { get; }

    public BulkObservableCollection<ReportSection> ReportSections { get; } = [];
    public BulkObservableCollection<ReportSectionToggleViewModel> SectionToggles { get; } = [];
    public BulkObservableCollection<ReportTreeItemViewModel> ReportTreeNodes { get; } = [];
    public bool HasSectionToggles => SectionToggles.Count > 0;
    public int VisibleSectionCount => SectionToggles.Count(t => t.IsVisible);

    public bool IsGeneratingReport
    {
        get => isGeneratingReport;
        private set
        {
            if (isGeneratingReport == value) return;
            isGeneratingReport = value;
            Raise();
            RaiseReportPreviewState();
        }
    }

    public string ReportHtmlContent
    {
        get => reportHtmlContent;
        private set => Set(ref reportHtmlContent, value);
    }

    public bool HasReportSections  => ReportSections.Count > 0 && !isGeneratingReport;
    public bool IsReportPreviewVisible => isReportPreviewVisible;
    public bool ShowReportContent => IsReportPreviewVisible && HasReportSections;
    public bool ShowReportPreviewPlaceholder => !ShowReportContent;
    public bool ShowRevealReportPreviewButton => HasResult && !IsReportPreviewVisible && !IsGeneratingReport;
    public bool ShowHideReportPreviewButton => IsReportPreviewVisible;
    public IEnumerable<ReportSection> VisibleReportSections => ShowReportContent
        ? (HasSectionToggles
            ? SectionToggles.Where(t => t.IsVisible).Select(t => t.Section)
            : ReportSections)
        : Enumerable.Empty<ReportSection>();

    public string ReportPreviewStatusText
    {
        get
        {
            if (!HasResult) return "No report result available.";
            if (IsGeneratingReport) return "Rendering preview...";
            if (!IsReportPreviewVisible) return "Preview hidden";
            if (!HasReportSections) return "Preview not rendered";
            int visible = VisibleSectionCount;
            return visible == ReportSections.Count
                ? $"{ReportSections.Count} sections visible"
                : $"{visible} of {ReportSections.Count} sections visible";
        }
    }

    public string ReportPreviewPlaceholderTitle
    {
        get
        {
            if (!HasResult) return "MB Column - Engineering Calculation Report";
            if (IsGeneratingReport) return "Rendering report preview";
            if (!IsReportPreviewVisible) return "Report preview hidden";
            return "Report preview";
        }
    }

    public string ReportPreviewPlaceholderText
    {
        get
        {
            if (!HasResult) return "Run a calculation to generate the full report.";
            if (IsGeneratingReport) return "Preparing sections...";
            if (!IsReportPreviewVisible) return "Open the preview when you want to render the full report.";
            return ResultStatusText;
        }
    }

    public BulkObservableCollection<ReportDemandCaseRowViewModel> DemandCases { get; } = [];
    public BulkObservableCollection<ReportPm7RowViewModel> Pm7Rows { get; } = [];
    public BulkObservableCollection<PreviewBoundaryPoint> BoundaryPoints { get; } = [];
    public BulkObservableCollection<PreviewRebarPoint> Rebars { get; } = [];

    public GoverningChartPreviewViewModel? GoverningChart
    {
        get => governingChart;
        private set
        {
            Set(ref governingChart, value);
            Raise(nameof(HasGoverningChart));
            Raise(nameof(HasNoPmChartData));
        }
    }

    public bool HasGoverningChart  => governingChart?.IsAvailable == true;
    public bool HasNoPmChartData   => governingChart?.IsAvailable != true;

    // Interaction diagram data for in-report charts
    public IReadOnlyList<ControlPointDto>    PmPoints         { get => pmPoints;         private set => Set(ref pmPoints, value); }
    public IReadOnlyList<ChartReferenceLineDto> PmReferenceLines { get => pmReferenceLines; private set => Set(ref pmReferenceLines, value); }
    public IReadOnlyList<ControlPointDto>    MmPoints         { get => mmPoints;         private set => Set(ref mmPoints, value); }
    public string PmXAxisLabel { get => pmXAxisLabel; private set => Set(ref pmXAxisLabel, value); }
    public string PmYAxisLabel { get => pmYAxisLabel; private set => Set(ref pmYAxisLabel, value); }
    public string MmXAxisLabel { get => mmXAxisLabel; private set => Set(ref mmXAxisLabel, value); }
    public string MmYAxisLabel { get => mmYAxisLabel; private set => Set(ref mmYAxisLabel, value); }
    public double PmRatio      { get => pmRatio;      private set => Set(ref pmRatio, value); }
    public double MmRatio      { get => mmRatio;      private set => Set(ref mmRatio, value); }
    public string PmSliceLabel { get => pmSliceLabel; private set => Set(ref pmSliceLabel, value); }
    public bool   HasChartData => pmPoints.Count > 0;

    public bool IncludeInputData           { get => includeInputData;           set => Set(ref includeInputData, value); }
    public bool IncludeBoundaryCoordinates { get => includeBoundaryCoordinates; set => Set(ref includeBoundaryCoordinates, value); }
    public bool IncludeRebarCoordinates    { get => includeRebarCoordinates;    set => Set(ref includeRebarCoordinates, value); }
    public bool IncludeDemandCases         { get => includeDemandCases;         set => Set(ref includeDemandCases, value); }

    public double SectionWidth { get => sectionWidth; set => Set(ref sectionWidth, value); }
    public double SectionHeight { get => sectionHeight; set => Set(ref sectionHeight, value); }
    public double ClearCover { get => clearCover; set => Set(ref clearCover, value); }

    public bool IncludeGoverningChart      { get => includeGoverningChart;      set => Set(ref includeGoverningChart, value); }
    public bool IncludePm7Table            { get => includePm7Table;            set => Set(ref includePm7Table, value); }

    public bool IsOutdated          { get => isOutdated;          private set => Set(ref isOutdated, value); }
    public bool IsExportBusy        { get => isExportBusy;        private set { Set(ref isExportBusy, value); RaiseExportCanExecute(); } }

    public string ResultStatusText  { get => resultStatusText;    private set => Set(ref resultStatusText, value); }
    public string ProjectName       { get => projectName;         private set => Set(ref projectName, value); }
    public string GroupName         { get => groupName;           private set => Set(ref groupName, value); }
    public string DesignTierName    { get => designTierName;      private set => Set(ref designTierName, value); }
    public string SectionShape      { get => sectionShape;        private set => Set(ref sectionShape, value); }
    public string DesignCode        { get => designCode;          private set => Set(ref designCode, value); }
    public string UnitSystem        { get => unitSystem;          private set => Set(ref unitSystem, value); }
    public string MaterialSummary   { get => materialSummary;     private set => Set(ref materialSummary, value); }
    public string GeometrySummary   { get => geometrySummary;     private set => Set(ref geometrySummary, value); }
    public string RebarSummary      { get => rebarSummary;        private set => Set(ref rebarSummary, value); }
    public string ForceUnit         { get => forceUnit;           private set => Set(ref forceUnit, value); }
    public string MomentUnit        { get => momentUnit;          private set => Set(ref momentUnit, value); }

    public bool HasPm7Data => Pm7Rows.Count > 0;
    public bool HasResult  => _cachedResult is not null;

    private bool CanRevealReportPreview() => HasResult && !IsGeneratingReport;

    private void SetAllToggles(bool visible)
    {
        _suppressToggleUpdate = true;
        foreach (var t in SectionToggles)
            t.IsVisible = visible;
        _suppressToggleUpdate = false;
        OnToggleVisibilityChanged();
    }

    private void ScrollToSection(string sectionNumber)
    {
        var anchorId = $"sec-{sectionNumber.Replace(".", "-")}";
        WebViewScrollToAnchor?.Invoke(anchorId);
    }

    private void OnToggleVisibilityChanged()
    {
        if (_suppressToggleUpdate) return;
        Raise(nameof(VisibleReportSections));
        Raise(nameof(VisibleSectionCount));
        Raise(nameof(ReportPreviewStatusText));

        if (_cachedReportData is not null && _htmlRenderer.CanRender())
        {
            var visible = SectionToggles.Where(t => t.IsVisible).Select(t => t.Section);
            ReportHtmlContent = _htmlRenderer.BuildHtml(_cachedReportData, visible);
        }
    }

    private void SetReportPreviewVisible(bool value)
    {
        if (isReportPreviewVisible == value) return;
        isReportPreviewVisible = value;
        RaiseReportPreviewState();
    }

    private void RaiseReportPreviewState()
    {
        Raise(nameof(HasReportSections));
        Raise(nameof(IsReportPreviewVisible));
        Raise(nameof(ShowReportContent));
        Raise(nameof(ShowReportPreviewPlaceholder));
        Raise(nameof(ShowRevealReportPreviewButton));
        Raise(nameof(ShowHideReportPreviewButton));
        Raise(nameof(VisibleReportSections));
        Raise(nameof(ReportPreviewStatusText));
        Raise(nameof(ReportPreviewPlaceholderTitle));
        Raise(nameof(ReportPreviewPlaceholderText));
        (GeneratePreviewCommand as RelayCommand)?.RaiseCanExecuteChanged();
        (HideReportPreviewCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }

    private void RevealReportPreview()
    {
        if (_cachedResult is null) return;

        SetReportPreviewVisible(true);

        if (ReportSections.Count == 0 && !IsGeneratingReport)
            _ = RefreshReportSectionsAsync();
        else
            RaiseReportPreviewState();
    }

    private void HideReportPreview()
    {
        if (IsGeneratingReport)
        {
            _reportCts?.Cancel();
            ReportSections.Clear();
            IsGeneratingReport = false;
        }

        SetReportPreviewVisible(false);
        RaiseReportPreviewState();
    }

    public void Clear()
    {
        ProjectName = GroupName = DesignTierName = SectionShape = DesignCode =
            UnitSystem = MaterialSummary = GeometrySummary = RebarSummary =
            ForceUnit = MomentUnit = "";
        _cachedProjectName = _cachedGroupName = _cachedDesignTierName = "";
        _cachedLinkDiameterMm = 0;
        _cachedTotalLegsX = 2;
        _cachedTotalLegsY = 2;
        ResultStatusText = "No result";
        IsOutdated = false;
        _cachedResult = null;
        _reportCts?.Cancel();
        IsGeneratingReport = false;
        SetReportPreviewVisible(false);
        ReportSections.Clear();
        SectionToggles.Clear();
        ReportTreeNodes.Clear();
        Raise(nameof(HasResult));
        Raise(nameof(HasSectionToggles));
        RaiseReportPreviewState();
        DemandCases.Clear();
        Pm7Rows.Clear();
        GoverningChart = null;
        PmPoints = [];
        PmReferenceLines = [];
        MmPoints = [];
        PmRatio = 0;
        MmRatio = 0;
        Raise(nameof(HasChartData));
        RaiseExportCanExecute();
    }

    public void MarkOutdated()
    {
        if (string.Equals(ResultStatusText, "No result", StringComparison.OrdinalIgnoreCase))
            return;
        IsOutdated = true;
        ResultStatusText = "Outdated";
        _reportCts?.Cancel();
        SetReportPreviewVisible(false);
        ReportSections.Clear();
        SectionToggles.Clear();
        ReportTreeNodes.Clear();
        IsGeneratingReport = false;
        Raise(nameof(HasSectionToggles));
        RaiseReportPreviewState();
    }

    public void LoadFromCurrentWorkspace(
        InputViewModel input,
        ResultViewModel result,
        string projectName,
        string groupName,
        string designTierName,
        bool isOutdated)
    {
        _cachedProjectName  = projectName;
        _cachedGroupName    = groupName;
        _cachedDesignTierName = designTierName;
        _cachedLinkDiameterMm = input.StirrupDiameterMm;
        _cachedTotalLegsX = input.TotalLegsX;
        _cachedTotalLegsY = input.TotalLegsY;

        ProjectName = projectName;
        GroupName = groupName;
        DesignTierName = designTierName;
        SectionShape = input.SelectedSectionShape.ToString();
        DesignCode = input.SelectedDesignCode.ToString();
        UnitSystem = input.UnitSystem.ToString();
        MaterialSummary = $"{input.FcLabel} = {input.Fc:0.##} {input.StressLabel}, " +
                          $"{input.FyLabel} = {input.Fy:0.##} {input.StressLabel}, " +
                          $"Es = {input.Es:0.##} {input.StressLabel}";
        GeometrySummary = BuildGeometrySummary(input);
        RebarSummary = BuildRebarSummary(input);
        SectionWidth = input.SectionWidth;
        SectionHeight = input.SectionHeight;
        ClearCover = input.Cover;
        IsOutdated = isOutdated && result.HasResult;
        ResultStatusText = result.HasResult ? (IsOutdated ? "Outdated" : "Current") : "No result";

        _cachedResult = result.Result;
        _reportCts?.Cancel();
        IsGeneratingReport = false;
        ReportSections.Clear();
        SetReportPreviewVisible(false);
        Raise(nameof(HasResult));
        RaiseReportPreviewState();
        if (_cachedResult is not null) BuildChartData(_cachedResult);

        var unitProfile = UnitProfile.For(input.UnitSystem);
        ForceUnit = unitProfile.ForceLabel;
        MomentUnit = unitProfile.MomentLabel;

        BoundaryPoints.Clear();
        BoundaryPoints.AddRange(input.PreviewBoundaryPoints);

        Rebars.Clear();
        Rebars.AddRange(input.PreviewRebars);

        DemandCases.Clear();
        var lcResultById = result.Result?.LoadCaseResults?.ToDictionary(r => r.LoadCaseId)
            ?? new System.Collections.Generic.Dictionary<string, LoadCaseResultDto>();
        DemandCases.AddRange(input.LoadCases.Select(lc =>
        {
            lcResultById.TryGetValue(lc.Id, out var lcResult);
            return new ReportDemandCaseRowViewModel(
                lc.Name,
                lc.OriginalLoadCaseName,
                lc.SourceObjectLabel,
                lc.Story,
                lc.Station,
                lc.Pu,
                lc.Mux,
                lc.Muy,
                string.IsNullOrWhiteSpace(lc.Source) ? "Manual" : lc.Source,
                lcResult?.PmmRatio ?? 0,
                lcResult?.CapacityPDisplay ?? 0,
                lcResult?.CapacityMxDisplay ?? 0,
                lcResult?.CapacityMyDisplay ?? 0);
        }));

        RefreshReportSummaryPreview();
        RaiseExportCanExecute();
    }

    // ── Interaction diagram chart data ────────────────────────────────────────

    private void BuildChartData(CalculationResultDto result)
    {
        try
        {
            var theta = result.GoverningThetaDegrees;
            var pmDiagram = _diagramSvc.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
            var pmDemand  = _diagramSvc.BuildPmAngleDemandPoints(result.LoadCaseResults, theta);

            PmPoints         = [..pmDiagram.Points, ..pmDemand, ..pmDiagram.SpecialCapacityPoints];
            PmReferenceLines = pmDiagram.ReferenceLines;
            PmXAxisLabel     = $"M ({pmDiagram.MUnit})";
            PmYAxisLabel     = $"P ({pmDiagram.PUnit})";
            PmRatio          = result.Ratio;
            PmSliceLabel     = $"P-M  at θ = {theta:F1}°  (governing)";

            var mmDiagram = _diagramSvc.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
            var mmDemand  = _diagramSvc.BuildMxMyDemandPoints(result.LoadCaseResults);
            MmPoints     = [..mmDiagram.Points, ..mmDemand];
            MmXAxisLabel = $"Mx ({mmDiagram.MUnit})";
            MmYAxisLabel = $"My ({mmDiagram.MUnit})";
            MmRatio      = result.Ratio;
        }
        catch
        {
            PmPoints = [];
            PmReferenceLines = [];
            MmPoints = [];
        }
        Raise(nameof(HasChartData));
    }

    // ── Report sections (full dynamic preview) ────────────────────────────────

    private async Task RefreshReportSectionsAsync()
    {
        _reportCts?.Cancel();
        _reportCts?.Dispose();
        _reportCts = new CancellationTokenSource();
        var ct = _reportCts.Token;

        if (_cachedResult is null)
        {
            ReportSections.Clear();
            RaiseReportPreviewState();
            return;
        }

        try
        {
            IsGeneratingReport = true;
            ReportSections.Clear();
            RaiseReportPreviewState();

            var result    = _cachedResult;
            var projName  = _cachedProjectName;
            var grpName   = _cachedGroupName;
            var tierName  = _cachedDesignTierName;

            var (pmDiagramBlock, mmDiagramBlock) = BuildReportDiagramBlocks(result, withPng: true);

            var (reportData, reportHtml) = await Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();

                IDesignCodeService codeService = result.DesignCode == DesignCodeType.Aci318Style
                    ? new Aci318DesignCodeService()
                    : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
                IUnitConversionService unitService = new UnitConversionService();

                // Generate all SVGs before Build() so section builders can embed them
                string? sectionSvg = null;
                try { sectionSvg = SectionGeometryRenderer.RenderSection(
                    result.SectionShape,
                    result.SectionWidthMm, result.SectionHeightMm,
                    result.DiameterMm > 0 ? result.DiameterMm : result.SectionWidthMm,
                    result.CoverMm, result.RebarCoordinates,
                    _cachedLinkDiameterMm, _cachedTotalLegsX, _cachedTotalLegsY,
                    result.IrregularSectionBoundaryPoints); }
                catch { }

                ct.ThrowIfCancellationRequested();

                ct.ThrowIfCancellationRequested();

                var builder = new CalculationReportBuilder();
                var data    = builder.Build(projName, grpName, tierName, result, codeService, unitService,
                                            sectionSvg, pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);
                string html = _htmlRenderer.CanRender() ? _htmlRenderer.BuildHtml(data) : "";
                return (data, html);
            }, ct);

            ct.ThrowIfCancellationRequested();

            _cachedReportData = reportData;
            ReportHtmlContent = reportHtml;
            ReportSections.AddRange(reportData.Sections);

            SectionToggles.Clear();
            SectionToggles.AddRange(reportData.Sections.Select(s =>
            {
                var toggle = new ReportSectionToggleViewModel(s);
                toggle.PropertyChanged += (_, _) => OnToggleVisibilityChanged();
                return toggle;
            }));
            BuildReportTree();
            Raise(nameof(HasSectionToggles));
            Raise(nameof(VisibleSectionCount));

            RaiseReportPreviewState();
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            if (!ct.IsCancellationRequested)
            {
                ReportSections.Add(new ReportSection("!", "Report Generation Error",
                    [new NoteBlock($"Failed to generate report: {ex.Message}")]));
                RaiseReportPreviewState();
            }
        }
        finally
        {
            if (!ct.IsCancellationRequested)
                IsGeneratingReport = false;
        }
    }

    public override void Dispose()
    {
        _reportCts?.Cancel();
        _reportCts?.Dispose();
        _reportCts = null;
    }

    // ── Export commands ───────────────────────────────────────────────────────

    private bool CanExport() => _cachedResult is not null && !IsExportBusy;

    private void RaiseExportCanExecute()
    {
        (PreviewPdfCommand as RelayCommand)?.RaiseCanExecuteChanged();
        (SaveAsPdfCommand  as RelayCommand)?.RaiseCanExecuteChanged();
        (SaveAsHtmlCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }

    private void PreviewPdf()
    {
        if (_cachedResult is null) return;
        try
        {
            IsExportBusy = true;
            var data = BuildReportData();
            string tmp = Path.Combine(Path.GetTempPath(),
                $"MBColumn_Calculation_Report_Preview_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            var renderer = new MBColumn.Infrastructure.Reports.Pdf.QuestPdfCalculationReportRenderer();
            renderer.RenderToFile(data, tmp);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tmp) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            AppNotificationDialog.Show($"PDF preview failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxImage.Error);
        }
        finally { IsExportBusy = false; }
    }

    private async Task SaveAsPdfAsync()
    {
        if (_cachedResult is null) return;
        var dialog = new SaveFileDialog
        {
            Title = "Save as PDF",
            Filter = "PDF files (*.pdf)|*.pdf",
            FileName = "MBColumn_Calculation_Report.pdf"
        };
        if (dialog.ShowDialog() != true) return;
        try
        {
            IsExportBusy = true;
            await Task.Yield();
            var data = BuildReportData();
            var visibleNumbers = SectionToggles
                .Where(t => t.IsVisible)
                .Select(t => t.Section.Number)
                .ToHashSet();
            if (visibleNumbers.Count > 0 && visibleNumbers.Count < data.Sections.Count)
                data = data with { Sections = data.Sections.Where(s => visibleNumbers.Contains(s.Number)).ToArray() };

            var renderer = new MBColumn.Infrastructure.Reports.Pdf.QuestPdfCalculationReportRenderer();
            renderer.RenderToFile(data, dialog.FileName);
            if (TryOpenFileWithDefaultApp(dialog.FileName, out var openError))
            {
                AppNotificationDialog.Show($"PDF saved and opened:\n{dialog.FileName}", "Export Complete",
                    System.Windows.MessageBoxImage.Information);
            }
            else
            {
                AppNotificationDialog.Show(
                    $"PDF saved to:\n{dialog.FileName}\n\nCould not open automatically:\n{openError}",
                    "Open PDF Error",
                    System.Windows.MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            AppNotificationDialog.Show($"PDF export failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxImage.Error);
        }
        finally { IsExportBusy = false; }
    }

    private static bool TryOpenFileWithDefaultApp(string fileName, out string errorMessage)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileName)
            {
                UseShellExecute = true
            });
            errorMessage = string.Empty;
            return true;
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return false;
        }
    }

    private void SaveAsHtml()
    {
        if (_cachedResult is null) return;
        var dialog = new SaveFileDialog
        {
            Title = "Save as HTML",
            Filter = "HTML files (*.html)|*.html",
            FileName = "MBColumn_Calculation_Report.html"
        };
        if (dialog.ShowDialog() != true) return;
        try
        {
            IsExportBusy = true;
            var data = BuildReportData();
            var renderer = new MBColumn.Infrastructure.Reports.Html.HtmlCalculationReportRenderer();
            renderer.RenderToFile(data, dialog.FileName);
            AppNotificationDialog.Show($"HTML saved to:\n{dialog.FileName}", "Export Complete",
                System.Windows.MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            AppNotificationDialog.Show($"HTML export failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxImage.Error);
        }
        finally { IsExportBusy = false; }
    }

    // ── Report data builder ───────────────────────────────────────────────────

    private ReportData BuildReportData()
    {
        var result = _cachedResult ?? throw new InvalidOperationException("No calculation result available.");

        string? sectionSvg = null;
        try { sectionSvg = SectionGeometryRenderer.RenderSection(
            result.SectionShape,
            result.SectionWidthMm, result.SectionHeightMm,
            result.DiameterMm > 0 ? result.DiameterMm : result.SectionWidthMm,
            result.CoverMm, result.RebarCoordinates,
            _cachedLinkDiameterMm, _cachedTotalLegsX, _cachedTotalLegsY,
            result.IrregularSectionBoundaryPoints); }
        catch { }

        var (pmDiagramBlock, mmDiagramBlock) = BuildReportDiagramBlocks(result, withPng: true);

        IDesignCodeService codeService = result.DesignCode == DesignCodeType.Aci318Style
            ? new Aci318DesignCodeService()
            : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
        IUnitConversionService unitService = new UnitConversionService();

        var builder = new CalculationReportBuilder();
        return builder.Build(_cachedProjectName, _cachedGroupName, _cachedDesignTierName,
                             result, codeService, unitService, sectionSvg,
                             pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);
    }

    private (DiagramBlock? Pm, DiagramBlock? Mm) BuildReportDiagramBlocks(CalculationResultDto result, bool withPng)
    {
        try
        {
            var diag = new DiagramDataService();
            double theta = result.GoverningThetaDegrees;
            var pmData = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
            var governing = result.LoadCaseResults
                .Where(r => double.IsFinite(r.PmmRatio))
                .OrderByDescending(r => r.PmmRatio)
                .ThenByDescending(r => Math.Sqrt(r.MuxDisplay * r.MuxDisplay + r.MuyDisplay * r.MuyDisplay))
                .FirstOrDefault();
            var pmAll = pmData.Points
                .Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta))
                .Concat(pmData.SpecialCapacityPoints)
                .ToList();
            var pmReferenceLines = pmData.ReferenceLines.ToList();
            if (governing is not null)
            {
                double thetaRad = theta * Math.PI / 180.0;
                double capacityMtheta = governing.CapacityMxDisplay * Math.Cos(thetaRad) + governing.CapacityMyDisplay * Math.Sin(thetaRad);
                pmReferenceLines.Add(new ChartReferenceLineDto(
                    0,
                    0,
                    capacityMtheta,
                    governing.CapacityPDisplay,
                    $"UR {governing.PmmRatio:F3}",
                    "Proportional",
                    IsDashed: true));
            }

            var pm = new DiagramBlock(pmAll, pmReferenceLines,
                $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                UseEqualAspect: false, WidthPct: 90,
                Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

            var mmData = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
            var mmAll = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
            var mmReferenceLines = new List<ChartReferenceLineDto>();
            if (governing is not null)
            {
                mmReferenceLines.Add(new ChartReferenceLineDto(
                    0,
                    0,
                    governing.CapacityMxDisplay,
                    governing.CapacityMyDisplay,
                    $"UR {governing.PmmRatio:F3}",
                    "Proportional",
                    IsDashed: true));
            }

            var mm = new DiagramBlock(mmAll, mmReferenceLines,
                $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                UseEqualAspect: true, WidthPct: 80,
                Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");

            if (!withPng)
            {
                return (pm, mm);
            }

            var pmSnapshot = ChartSnapshotProvider?.Invoke("PM", pm);
            var mmSnapshot = ChartSnapshotProvider?.Invoke("MM", mm);
            pm = pm with { PngDataUri = string.IsNullOrWhiteSpace(pmSnapshot) ? ReportDiagramPngRenderer.RenderDataUri(pm) : pmSnapshot };
            mm = mm with { PngDataUri = string.IsNullOrWhiteSpace(mmSnapshot) ? ReportDiagramPngRenderer.RenderDataUri(mm) : mmSnapshot };
            return (pm, mm);
        }
        catch
        {
            return (null, null);
        }
    }

    private void BuildReportTree()
    {
        ReportTreeNodes.Clear();

        var mainReportRoot = new ReportTreeItemViewModel { Title = "Main report" };
        var appendixRoot = new ReportTreeItemViewModel { Title = "Annex" };

        var mainChildren = new List<ReportTreeItemViewModel>();
        var annexChildren = new List<ReportTreeItemViewModel>();

        foreach (var toggle in SectionToggles)
        {
            var treeItem = new ReportTreeItemViewModel();
            treeItem.InitializeFromToggle(toggle);
            bool isAppendix = toggle.SectionNumber.StartsWith("A", StringComparison.OrdinalIgnoreCase);
            treeItem.Parent = isAppendix ? appendixRoot : mainReportRoot;
            (isAppendix ? annexChildren : mainChildren).Add(treeItem);
        }

        if (mainChildren.Count > 0)
        {
            mainReportRoot.Children.AddRange(mainChildren);
            mainReportRoot.VerifyCheckedState();
            ReportTreeNodes.Add(mainReportRoot);
        }

        if (annexChildren.Count > 0)
        {
            appendixRoot.Children.AddRange(annexChildren);
            appendixRoot.VerifyCheckedState();
            ReportTreeNodes.Add(appendixRoot);
        }
    }

    // ── Preview helpers ───────────────────────────────────────────────────────

    private void RefreshReportSummaryPreview()
    {
        BuildPm7Rows();
        BuildGoverningChart();
        Raise(nameof(HasPm7Data));
    }

    private void BuildPm7Rows()
    {
        Pm7Rows.Clear();
        if (_cachedResult?.SevenPointValidationRows is not { Count: > 0 } rows) return;

        bool isMetric = _cachedResult?.UnitSystem == Domain.Enums.UnitSystem.Metric;
        var mapped = _pm7Mapper.Map(rows, _units, isMetric);
        Pm7Rows.AddRange(mapped.Select(r => new ReportPm7RowViewModel
        {
            Index = r.Index,
            PointCode = r.PointCode,
            PointName = r.PointName,
            StrainDescription = r.StrainDescription,
            HandCalcPDisplay = PmSevenPointReportMapper.FormatOrNa(r.HandCalcAxialForce),
            HandCalcMDisplay = PmSevenPointReportMapper.FormatOrNa(r.HandCalcMoment),
            SolverPDisplay   = PmSevenPointReportMapper.FormatOrNa(r.SolverAxialForce),
            SolverMDisplay   = PmSevenPointReportMapper.FormatOrNa(r.SolverMoment),
            DeviationPDisplay = PmSevenPointReportMapper.FormatPctOrNa(r.AxialForceDeviationPct),
            DeviationMDisplay = PmSevenPointReportMapper.FormatPctOrNa(r.MomentDeviationPct),
        }));
    }

    private void BuildGoverningChart()
    {
        GoverningChart = null;
        if (_cachedResult is null) return;

        var governing = _cachedResult.LoadCaseResults
            .Where(r => double.IsFinite(r.PmmRatio))
            .OrderByDescending(r => r.PmmRatio)
            .ThenByDescending(r => Math.Sqrt(r.MuxDisplay * r.MuxDisplay + r.MuyDisplay * r.MuyDisplay))
            .FirstOrDefault();

        double thetaDeg = governing?.GoverningThetaDegrees ?? _cachedResult.GoverningThetaDegrees;

        var vm = new GoverningChartPreviewViewModel
        {
            CriticalThetaDeg = thetaDeg,
            UtilizationRatio = governing?.PmmRatio,
            DemandP  = governing?.PuDisplay,
            DemandMx = governing?.MuxDisplay,
            DemandMy = governing?.MuyDisplay,
            LoadCaseName = governing?.LoadCaseName ?? "",
        };

        if (_cachedResult.ControlPoints is not null)
        {
            try
            {
                var pmDiag = _diagramSvc.BuildPmAngleDiagramData(
                    _cachedResult.ControlPoints, _cachedResult.UnitSystem, thetaDeg);
                vm.PmChartPoints = pmDiag.ReducedCapacityPoints.Concat(pmDiag.SpecialCapacityPoints).ToList();
                vm.PmReferenceLines = pmDiag.ReferenceLines;
                vm.PUnit = pmDiag.PUnit;
                vm.MUnit = pmDiag.MUnit;
            }
            catch { }
        }

        if (_cachedResult.MxMyDiagram?.Points is { Count: > 0 } mmPts)
        {
            vm.MmChartPoints = mmPts;
            if (string.IsNullOrEmpty(vm.MUnit))
                vm.MUnit = _cachedResult.MxMyDiagram.MUnit ?? "";
        }

        if (governing is not null && double.IsFinite(governing.PmmRatio) && governing.PmmRatio > 0)
        {
            string label = governing.LoadCaseName;
            double thetaRad = thetaDeg * Math.PI / 180.0;
            double mtheta = governing.MuxDisplay * Math.Cos(thetaRad) + governing.MuyDisplay * Math.Sin(thetaRad);
            vm.DemandMtheta = mtheta;

            vm.PmDemandPoint = new ControlPointDto(
                DiagramType.PM, mtheta, governing.PuDisplay,
                governing.PuDisplay, governing.PuDisplay,
                governing.MuxDisplay, governing.MuyDisplay,
                1.0, thetaDeg, 0,
                label, "Demand",
                IsDemand: true, IsGoverning: false, IsReference: false, IsNominal: false,
                Utilization: governing.PmmRatio);

            double capacityMtheta = governing.CapacityMxDisplay * Math.Cos(thetaRad) + governing.CapacityMyDisplay * Math.Sin(thetaRad);
            var pmLine = new ChartReferenceLineDto(0, 0, capacityMtheta, governing.CapacityPDisplay, "", "Proportional", IsDashed: true);
            var pmRefLines = vm.PmReferenceLines.ToList();
            pmRefLines.Add(pmLine);
            vm.PmReferenceLines = pmRefLines;

            vm.MmDemandPoint = new ControlPointDto(
                DiagramType.MM, governing.MuxDisplay, governing.MuyDisplay,
                0, 0,
                governing.MuxDisplay, governing.MuyDisplay,
                1.0, 0, 0,
                label, "Demand",
                IsDemand: true, IsGoverning: false, IsReference: false, IsNominal: false,
                Utilization: governing.PmmRatio);

            var mmLine = new ChartReferenceLineDto(0, 0, governing.CapacityMxDisplay, governing.CapacityMyDisplay, "", "Proportional", IsDashed: true);
            vm.MmReferenceLines = [mmLine];
        }

        GoverningChart = vm;
    }

    private static string BuildGeometrySummary(InputViewModel input)
        => input.SelectedSectionShape switch
        {
            SectionShapeType.Circular  => $"D = {input.Diameter:0.##} {input.LengthLabel}, cover = {input.Cover:0.##} {input.LengthLabel}",
            SectionShapeType.Irregular => $"{input.IrregularInput.BoundaryPoints.Count} boundary points, cover = {input.Cover:0.##} {input.LengthLabel}",
            _                          => $"b = {input.Width:0.##} {input.LengthLabel}, h = {input.Height:0.##} {input.LengthLabel}, cover = {input.Cover:0.##} {input.LengthLabel}",
        };

    private static string BuildRebarSummary(InputViewModel input)
        => input.SelectedSectionShape == SectionShapeType.Irregular
            ? $"{input.IrregularInput.Rebars.Count} bars, {input.IrregularInput.BarSize}, {input.SelectedRebarLayoutType}"
            : $"{input.BarCount} bars, {input.BarSize}, {input.SelectedRebarLayoutType}";
}

public sealed class ReportSectionToggleViewModel : ViewModelBase
{
    private bool _isVisible = true;

    public ReportSectionToggleViewModel(MBColumn.Application.Reports.Models.ReportSection section)
        => Section = section;

    public MBColumn.Application.Reports.Models.ReportSection Section { get; }
    public string Title => $"{Section.Number}.  {Section.Title}";
    public string SectionNumber => Section.Number;

    public bool IsVisible
    {
        get => _isVisible;
        set => Set(ref _isVisible, value);
    }
}

public sealed record ReportDemandCaseRowViewModel(
    string CaseName,
    string OriginalLoadCase,
    string Label,
    string Story,
    string Station,
    double Pu,
    double Mux,
    double Muy,
    string Source,
    double PmmRatio,
    double CapacityP,
    double CapacityMx,
    double CapacityMy)
{
    public bool IsFailing => PmmRatio > 1.0;
}

public sealed class ReportTreeItemViewModel : ViewModelBase
{
    private string _title = "";
    private bool? _isChecked = true;
    private ReportTreeItemViewModel? _parent;

    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    public string SectionNumber { get; set; } = "";

    public bool? IsChecked
    {
        get => _isChecked;
        set => SetIsChecked(value, updateChildren: true, updateParent: true);
    }

    public ReportTreeItemViewModel? Parent
    {
        get => _parent;
        set => Set(ref _parent, value);
    }

    public ReportSectionToggleViewModel? SectionToggle { get; set; }

    public BulkObservableCollection<ReportTreeItemViewModel> Children { get; } = [];

    public bool HasChildren => Children.Count > 0;

    public ReportTreeItemViewModel()
    {
    }

    public void InitializeFromToggle(ReportSectionToggleViewModel toggle)
    {
        SectionToggle = toggle;
        _title = toggle.Title;
        SectionNumber = toggle.SectionNumber;
        _isChecked = toggle.IsVisible;
        
        toggle.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(ReportSectionToggleViewModel.IsVisible))
            {
                SetIsChecked(toggle.IsVisible, updateChildren: false, updateParent: true);
            }
        };
    }

    private void SetIsChecked(bool? value, bool updateChildren, bool updateParent)
    {
        if (_isChecked == value) return;

        _isChecked = value;
        Raise(nameof(IsChecked));

        if (updateChildren && value.HasValue)
        {
            foreach (var child in Children)
            {
                child.SetIsChecked(value.Value, updateChildren: true, updateParent: false);
            }
        }

        if (SectionToggle is not null && value.HasValue)
        {
            SectionToggle.IsVisible = value.Value;
        }

        if (updateParent && Parent is not null)
        {
            Parent.VerifyCheckedState();
        }
    }

    public void VerifyCheckedState()
    {
        bool? state = null;
        for (int i = 0; i < Children.Count; ++i)
        {
            bool? current = Children[i].IsChecked;
            if (i == 0)
            {
                state = current;
            }
            else if (state != current)
            {
                state = null;
                break;
            }
        }
        SetIsChecked(state, updateChildren: false, updateParent: true);
    }
}
