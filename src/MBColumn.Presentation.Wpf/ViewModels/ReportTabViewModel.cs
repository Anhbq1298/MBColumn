using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using System.Linq;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ReportTabViewModel : ViewModelBase
{
    private readonly DiagramDataService _diagramSvc = new();
    private readonly PmSevenPointReportMapper _pm7Mapper = new();
    private readonly MBColumn.Domain.Interfaces.IUnitConversionService _units = new MBColumn.Infrastructure.Math.UnitConversionService();
    private CalculationResultDto? _cachedResult;

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
    private GoverningChartPreviewViewModel? governingChart;

    private double sectionWidth;
    private double sectionHeight;
    private double clearCover;

    public ReportTabViewModel()
    {
        GeneratePreviewCommand = new RelayCommand(GeneratePreview);

    }

    public ICommand GeneratePreviewCommand { get; }


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

    public void Clear()
    {
        ProjectName = GroupName = DesignTierName = SectionShape = DesignCode =
            UnitSystem = MaterialSummary = GeometrySummary = RebarSummary =
            ForceUnit = MomentUnit = "";
        ResultStatusText = "No result";
        IsOutdated = false;
        _cachedResult = null;
        DemandCases.Clear();
        Pm7Rows.Clear();
        GoverningChart = null;
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

        // Resolve display units from unit system
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
    }

    private void GeneratePreview()
    {
        BuildPm7Rows();
        BuildGoverningChart();
        Raise(nameof(HasPm7Data));
    }

    private void BuildPm7Rows()
    {
        Pm7Rows.Clear();
        if (_cachedResult?.SevenPointValidationRows is not { Count: > 0 } rows) return;

        var fUnit = string.IsNullOrEmpty(ForceUnit) ? "" : $" ({ForceUnit})";
        var mUnit = string.IsNullOrEmpty(MomentUnit) ? "" : $" ({MomentUnit})";

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

        // Identify governing load case by highest PMM ratio
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

        // PM curve for governing theta slice
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
            catch { /* leave PM chart empty — show placeholder */ }
        }

        // MM contour from MxMyDiagram (at governing P level)
        if (_cachedResult.MxMyDiagram?.Points is { Count: > 0 } mmPts)
        {
            vm.MmChartPoints = mmPts;
            if (string.IsNullOrEmpty(vm.MUnit))
                vm.MUnit = _cachedResult.MxMyDiagram.MUnit ?? "";
        }

        // Demand points for governing load case
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
