using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ReportTabViewModel : ViewModelBase
{
    private bool includeInputData = true;
    private bool includeBoundaryCoordinates = true;
    private bool includeRebarCoordinates = true;
    private bool includeDemandCases = true;
    private bool includePmCharts = true;
    private int chartAngleStepDegrees = 30;
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

    public ReportTabViewModel()
    {
        GeneratePreviewCommand = new RelayCommand(GeneratePreview);
    }

    public ICommand GeneratePreviewCommand { get; }
    public ObservableCollection<ReportDemandCaseRowViewModel> DemandCases { get; } = [];
    public ObservableCollection<ReportChartPreviewViewModel> ChartPreviews { get; } = [];

    public bool IncludeInputData { get => includeInputData; set => Set(ref includeInputData, value); }
    public bool IncludeBoundaryCoordinates { get => includeBoundaryCoordinates; set => Set(ref includeBoundaryCoordinates, value); }
    public bool IncludeRebarCoordinates { get => includeRebarCoordinates; set => Set(ref includeRebarCoordinates, value); }
    public bool IncludeDemandCases { get => includeDemandCases; set => Set(ref includeDemandCases, value); }
    public bool IncludePmCharts { get => includePmCharts; set => Set(ref includePmCharts, value); }
    public int ChartAngleStepDegrees
    {
        get => chartAngleStepDegrees;
        set => Set(ref chartAngleStepDegrees, Math.Clamp(value, 5, 90));
    }

    public bool IsOutdated { get => isOutdated; private set => Set(ref isOutdated, value); }
    public string ResultStatusText { get => resultStatusText; private set => Set(ref resultStatusText, value); }
    public string ProjectName { get => projectName; private set => Set(ref projectName, value); }
    public string GroupName { get => groupName; private set => Set(ref groupName, value); }
    public string DesignTierName { get => designTierName; private set => Set(ref designTierName, value); }
    public string SectionShape { get => sectionShape; private set => Set(ref sectionShape, value); }
    public string DesignCode { get => designCode; private set => Set(ref designCode, value); }
    public string UnitSystem { get => unitSystem; private set => Set(ref unitSystem, value); }
    public string MaterialSummary { get => materialSummary; private set => Set(ref materialSummary, value); }
    public string GeometrySummary { get => geometrySummary; private set => Set(ref geometrySummary, value); }
    public string RebarSummary { get => rebarSummary; private set => Set(ref rebarSummary, value); }

    public void Clear()
    {
        ProjectName = "";
        GroupName = "";
        DesignTierName = "";
        SectionShape = "";
        DesignCode = "";
        UnitSystem = "";
        MaterialSummary = "";
        GeometrySummary = "";
        RebarSummary = "";
        ResultStatusText = "No result";
        IsOutdated = false;
        DemandCases.Clear();
        ChartPreviews.Clear();
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
        MaterialSummary = $"{input.FcLabel} = {input.Fc:0.##} {input.StressLabel}, {input.FyLabel} = {input.Fy:0.##} {input.StressLabel}, Es = {input.Es:0.##} {input.StressLabel}";
        GeometrySummary = BuildGeometrySummary(input);
        RebarSummary = BuildRebarSummary(input);
        IsOutdated = isOutdated && result.HasResult;
        ResultStatusText = result.HasResult ? (IsOutdated ? "Outdated" : "Current") : "No result";

        DemandCases.Clear();
        foreach (var loadCase in input.LoadCases)
        {
            DemandCases.Add(new ReportDemandCaseRowViewModel(
                loadCase.Name,
                loadCase.OriginalLoadCaseName,
                loadCase.SourceObjectLabel,
                loadCase.Story,
                loadCase.Station,
                loadCase.Pu,
                loadCase.Mux,
                loadCase.Muy,
                string.IsNullOrWhiteSpace(loadCase.Source) ? "Manual" : loadCase.Source,
                result.Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == loadCase.Id)?.PmmRatio ?? 0,
                result.Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == loadCase.Id)?.CapacityPDisplay ?? 0,
                result.Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == loadCase.Id)?.CapacityMxDisplay ?? 0,
                result.Result?.LoadCaseResults?.FirstOrDefault(r => r.LoadCaseId == loadCase.Id)?.CapacityMyDisplay ?? 0));
        }

        GeneratePreview();
    }

    private void GeneratePreview()
    {
        ChartPreviews.Clear();
        if (!IncludePmCharts)
            return;

        var step = Math.Clamp(ChartAngleStepDegrees, 5, 90);
        for (var angle = 0; angle < 360; angle += step)
        {
            ChartPreviews.Add(new ReportChartPreviewViewModel(angle, $"PM Interaction Diagram - theta = {angle} deg"));
        }
    }

    private static string BuildGeometrySummary(InputViewModel input)
        => input.SelectedSectionShape switch
        {
            SectionShapeType.Circular => $"D = {input.Diameter:0.##} {input.LengthLabel}, cover = {input.Cover:0.##} {input.LengthLabel}",
            SectionShapeType.Irregular => $"{input.IrregularInput.BoundaryPoints.Count} boundary points, cover = {input.Cover:0.##} {input.LengthLabel}",
            _ => $"b = {input.Width:0.##} {input.LengthLabel}, h = {input.Height:0.##} {input.LengthLabel}, cover = {input.Cover:0.##} {input.LengthLabel}"
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
    double CapacityMy);

public sealed record ReportChartPreviewViewModel(int AngleDegrees, string Title);
