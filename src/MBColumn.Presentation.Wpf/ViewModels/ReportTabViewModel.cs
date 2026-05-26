using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Reports.Graphics;
using static MBColumn.Infrastructure.Reports.Graphics.InteractionDiagramSvgRenderer;
using MBColumn.Presentation.Wpf.Commands;
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
    private readonly MBColumn.Domain.Interfaces.IUnitConversionService _units = new MBColumn.Infrastructure.Math.UnitConversionService();
    private CalculationResultDto? _cachedResult;
    private CancellationTokenSource? _reportCts;

    // Cached project metadata (set from LoadFromCurrentWorkspace)
    private string _cachedProjectName = "";
    private string _cachedGroupName = "";
    private string _cachedDesignTierName = "";

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
    private bool isExportBusy;
    private bool isGeneratingReport;
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

    public ReportTabViewModel()
    {
        GeneratePreviewCommand = new RelayCommand(GeneratePreview);
        PreviewPdfCommand = new RelayCommand(PreviewPdf, CanExport);
        SaveAsPdfCommand = new RelayCommand(SaveAsPdf, CanExport);
        SaveAsHtmlCommand = new RelayCommand(SaveAsHtml, CanExport);
    }

    public ICommand GeneratePreviewCommand { get; }
    public ICommand PreviewPdfCommand { get; }
    public ICommand SaveAsPdfCommand { get; }
    public ICommand SaveAsHtmlCommand { get; }

    public ObservableCollection<ReportSection> ReportSections { get; } = new();
    public bool IsGeneratingReport { get => isGeneratingReport; private set { Set(ref isGeneratingReport, value); Raise(nameof(HasReportSections)); } }
    public bool HasReportSections  => ReportSections.Count > 0 && !isGeneratingReport;

    public ObservableCollection<ReportDemandCaseRowViewModel> DemandCases { get; } = [];
    public ObservableCollection<ReportPm7RowViewModel> Pm7Rows { get; } = [];
    public ObservableCollection<PreviewBoundaryPoint> BoundaryPoints { get; } = [];
    public ObservableCollection<PreviewRebarPoint> Rebars { get; } = [];

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

    public void Clear()
    {
        ProjectName = GroupName = DesignTierName = SectionShape = DesignCode =
            UnitSystem = MaterialSummary = GeometrySummary = RebarSummary =
            ForceUnit = MomentUnit = "";
        _cachedProjectName = _cachedGroupName = _cachedDesignTierName = "";
        ResultStatusText = "No result";
        IsOutdated = false;
        _cachedResult = null;
        _reportCts?.Cancel();
        ReportSections.Clear();
        Raise(nameof(HasReportSections));
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
        if (_cachedResult is not null) BuildChartData(_cachedResult);

        bool isMetric = input.UnitSystem == Domain.Enums.UnitSystem.Metric;
        ForceUnit  = isMetric ? "kN"   : "kip";
        MomentUnit = isMetric ? "kNm"  : "kip-ft";

        BoundaryPoints.Clear();
        foreach (var p in input.PreviewBoundaryPoints) BoundaryPoints.Add(p);

        Rebars.Clear();
        foreach (var r in input.PreviewRebars) Rebars.Add(r);

        DemandCases.Clear();
        foreach (var lc in input.LoadCases)
        {
            var lcResult = result.Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == lc.Id);
            DemandCases.Add(new ReportDemandCaseRowViewModel(
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
                lcResult?.CapacityMyDisplay ?? 0));
        }

        GeneratePreview();
        RaiseExportCanExecute();
        _ = RefreshReportSectionsAsync();
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
        _reportCts = new CancellationTokenSource();
        var ct = _reportCts.Token;

        if (_cachedResult is null)
        {
            ReportSections.Clear();
            Raise(nameof(HasReportSections));
            return;
        }

        try
        {
            IsGeneratingReport = true;
            ReportSections.Clear();
            Raise(nameof(HasReportSections));

            var result    = _cachedResult;
            var projName  = _cachedProjectName;
            var grpName   = _cachedGroupName;
            var tierName  = _cachedDesignTierName;

            var sections = await Task.Run(() =>
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
                    result.CoverMm, result.RebarCoordinates); }
                catch { }

                ct.ThrowIfCancellationRequested();

                DiagramBlock? pmDiagramBlock = null, mmDiagramBlock = null;
                try
                {
                    var diag = new DiagramDataService();
                    double theta = result.GoverningThetaDegrees;
                    var pmData   = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
                    var pmAll    = pmData.Points.Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta)).Concat(pmData.SpecialCapacityPoints).ToList();
                    pmDiagramBlock = new DiagramBlock(pmAll, pmData.ReferenceLines,
                        $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                        UseEqualAspect: false, WidthPct: 90,
                        Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

                    var mmData  = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
                    var mmAll   = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
                    mmDiagramBlock = new DiagramBlock(mmAll, [],
                        $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                        UseEqualAspect: true, WidthPct: 80,
                        Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");
                }
                catch { }

                ct.ThrowIfCancellationRequested();

                var builder = new CalculationReportBuilder();
                var data    = builder.Build(projName, grpName, tierName, result, codeService, unitService,
                                            sectionSvg, pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);
                return data.Sections;
            }, ct);

            ct.ThrowIfCancellationRequested();

            foreach (var section in sections)
                ReportSections.Add(section);
            Raise(nameof(HasReportSections));
        }
        catch (OperationCanceledException) { }
        catch (Exception ex)
        {
            if (!ct.IsCancellationRequested)
            {
                ReportSections.Add(new ReportSection("!", "Report Generation Error",
                    [new NoteBlock($"Failed to generate report: {ex.Message}")]));
                Raise(nameof(HasReportSections));
            }
        }
        finally
        {
            if (!ct.IsCancellationRequested)
                IsGeneratingReport = false;
        }
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
            System.Windows.MessageBox.Show($"PDF preview failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
        finally { IsExportBusy = false; }
    }

    private void SaveAsPdf()
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
            var data = BuildReportData();
            var renderer = new MBColumn.Infrastructure.Reports.Pdf.QuestPdfCalculationReportRenderer();
            renderer.RenderToFile(data, dialog.FileName);
            System.Windows.MessageBox.Show($"PDF saved to:\n{dialog.FileName}", "Export Complete",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"PDF export failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }
        finally { IsExportBusy = false; }
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
            System.Windows.MessageBox.Show($"HTML saved to:\n{dialog.FileName}", "Export Complete",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"HTML export failed:\n{ex.Message}", "Export Error",
                System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
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
            result.CoverMm, result.RebarCoordinates); }
        catch { }

        DiagramBlock? pmDiagramBlock = null, mmDiagramBlock = null;
        try
        {
            var diag = new DiagramDataService();
            double theta = result.GoverningThetaDegrees;
            var pmData   = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
            var pmAll    = pmData.Points.Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta)).Concat(pmData.SpecialCapacityPoints).ToList();
            pmDiagramBlock = new DiagramBlock(pmAll, pmData.ReferenceLines,
                $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                UseEqualAspect: false, WidthPct: 90,
                Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

            var mmData  = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
            var mmAll   = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
            mmDiagramBlock = new DiagramBlock(mmAll, [],
                $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                UseEqualAspect: true, WidthPct: 80,
                Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");
        }
        catch { }

        IDesignCodeService codeService = result.DesignCode == DesignCodeType.Aci318Style
            ? new Aci318DesignCodeService()
            : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
        IUnitConversionService unitService = new UnitConversionService();

        var builder = new CalculationReportBuilder();
        return builder.Build(_cachedProjectName, _cachedGroupName, _cachedDesignTierName,
                             result, codeService, unitService, sectionSvg,
                             pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);
    }

    // ── Preview helpers ───────────────────────────────────────────────────────

    private void GeneratePreview()
    {
        BuildPm7Rows();
        BuildGoverningChart();
        Raise(nameof(HasPm7Data));
        _ = RefreshReportSectionsAsync();
    }

    private void BuildPm7Rows()
    {
        Pm7Rows.Clear();
        if (_cachedResult?.SevenPointValidationRows is not { Count: > 0 } rows) return;

        bool isMetric = ForceUnit == "kN";
        var mapped = _pm7Mapper.Map(rows, _units, isMetric);
        foreach (var r in mapped)
        {
            Pm7Rows.Add(new ReportPm7RowViewModel
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
            });
        }
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
