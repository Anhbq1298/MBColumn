using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Reports.Graphics;
using MBColumn.Infrastructure.Reports.Pdf;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public enum PrintMode
{
    Individual,
    MirrorFolderStructure,
    Combined
}

// ── Tree node view-models ────────────────────────────────────────────────────

public sealed class PrintGroupNode : ViewModelBase
{
    private bool? isChecked = true;
    private bool isExpanded = true;

    public int Id { get; }
    public string Name { get; }
    public ObservableCollection<PrintColumnNode> Columns { get; } = [];

    public PrintGroupNode(int id, string name) { Id = id; Name = name; }

    public bool? IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked == value) return;
            isChecked = value;
            Raise();
            if (value.HasValue)
            {
                foreach (var col in Columns)
                    col.IsChecked = value.Value;
            }
        }
    }

    public bool IsExpanded
    {
        get => isExpanded;
        set => Set(ref isExpanded, value);
    }

    public void RefreshCheckedState()
    {
        if (Columns.Count == 0) return;
        bool allChecked = Columns.All(c => c.IsChecked);
        bool noneChecked = Columns.All(c => !c.IsChecked);
        isChecked = allChecked ? true : noneChecked ? false : null;
        Raise(nameof(IsChecked));
    }
}

public sealed class PrintColumnNode : ViewModelBase
{
    private bool isChecked = true;

    public int Id { get; }
    public int? GroupId { get; }
    public string Name { get; }
    public bool HasResult { get; }
    public PrintGroupNode? ParentGroup { get; set; }

    public PrintColumnNode(int id, int? groupId, string name, bool hasResult)
    {
        Id = id;
        GroupId = groupId;
        Name = name;
        HasResult = hasResult;
        isChecked = hasResult; // only pre-check columns that have results
    }

    public bool IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked == value) return;
            isChecked = value;
            Raise();
            ParentGroup?.RefreshCheckedState();
        }
    }
}

// ── Main ViewModel ───────────────────────────────────────────────────────────

public sealed class PrintReportViewModel : ViewModelBase
{
    private readonly IProjectService _projectService;
    private string _outputFolderPath = "";
    private PrintMode _printMode = PrintMode.Individual;
    private bool _isBusy;
    private string _statusText = "Ready";
    private int _progressValue;
    private int _progressMax = 1;

    public ObservableCollection<object> ExplorerNodes { get; } = [];

    public string OutputFolderPath
    {
        get => _outputFolderPath;
        set => Set(ref _outputFolderPath, value);
    }

    public PrintMode PrintMode
    {
        get => _printMode;
        set => Set(ref _printMode, value);
    }

    public bool IsPrintModeIndividual
    {
        get => _printMode == PrintMode.Individual;
        set { if (value) PrintMode = PrintMode.Individual; }
    }

    public bool IsPrintModeMirror
    {
        get => _printMode == PrintMode.MirrorFolderStructure;
        set { if (value) PrintMode = PrintMode.MirrorFolderStructure; }
    }

    public bool IsPrintModeCombined
    {
        get => _printMode == PrintMode.Combined;
        set { if (value) PrintMode = PrintMode.Combined; }
    }

    public bool IsBusy
    {
        get => _isBusy;
        private set
        {
            Set(ref _isBusy, value);
            (PrintCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
            (BrowseOutputFolderCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }
    }

    public string StatusText
    {
        get => _statusText;
        private set => Set(ref _statusText, value);
    }

    public int ProgressValue
    {
        get => _progressValue;
        private set => Set(ref _progressValue, value);
    }

    public int ProgressMax
    {
        get => _progressMax;
        private set => Set(ref _progressMax, value);
    }

    public ICommand BrowseOutputFolderCommand { get; }
    public ICommand PrintCommand { get; }
    public ICommand SelectAllCommand { get; }
    public ICommand DeselectAllCommand { get; }

    public PrintReportViewModel(IProjectService projectService)
    {
        _projectService = projectService;

        // Default output folder to desktop
        _outputFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        BrowseOutputFolderCommand = new RelayCommand(BrowseOutputFolder, () => !_isBusy);
        PrintCommand = new AsyncRelayCommand(PrintAsync, CanPrint);
        SelectAllCommand = new RelayCommand(() => SetAllChecked(true));
        DeselectAllCommand = new RelayCommand(() => SetAllChecked(false));

        LoadProjectStructure();
    }

    private void LoadProjectStructure()
    {
        ExplorerNodes.Clear();

        var groups = _projectService.GetGroups();
        var columns = _projectService.GetColumns();
        var groupDict = new Dictionary<int, PrintGroupNode>();

        foreach (var g in groups)
        {
            var groupNode = new PrintGroupNode(g.Id, g.Name);
            groupDict[g.Id] = groupNode;
            ExplorerNodes.Add(groupNode);
        }

        foreach (var col in columns)
        {
            bool hasResult = _projectService.LoadColumnResult(col.Id) is not null;
            var colNode = new PrintColumnNode(col.Id, col.GroupId, col.Name, hasResult);

            if (col.GroupId.HasValue && groupDict.TryGetValue(col.GroupId.Value, out var groupNode))
            {
                colNode.ParentGroup = groupNode;
                groupNode.Columns.Add(colNode);
                groupNode.RefreshCheckedState();
            }
            else
            {
                ExplorerNodes.Add(colNode);
            }
        }
    }

    private void BrowseOutputFolder()
    {
        var dialog = new Microsoft.Win32.OpenFolderDialog
        {
            Title = "Select output folder for reports",
            InitialDirectory = Directory.Exists(_outputFolderPath) ? _outputFolderPath : ""
        };
        if (dialog.ShowDialog() == true)
            OutputFolderPath = dialog.FolderName;
    }

    private bool CanPrint() => !_isBusy && !string.IsNullOrWhiteSpace(_outputFolderPath);

    private async Task PrintAsync()
    {
        if (string.IsNullOrWhiteSpace(_outputFolderPath))
        {
            StatusText = "Please specify an output folder.";
            return;
        }

        var selectedColumns = GetSelectedColumnsWithGroups();
        if (selectedColumns.Count == 0)
        {
            StatusText = "No sections selected.";
            return;
        }

        // Check that at least some have results
        var withResults = selectedColumns.Where(c => _projectService.LoadColumnResult(c.ColumnId) is not null).ToList();
        if (withResults.Count == 0)
        {
            StatusText = "None of the selected sections have been calculated.";
            return;
        }

        IsBusy = true;
        ProgressValue = 0;
        ProgressMax = withResults.Count;
        StatusText = "Building reports…";

        try
        {
            // Build ReportData for each column on background thread
            var entries = await Task.Run(() => BuildEntries(withResults));

            if (entries.Count == 0)
            {
                StatusText = "No reports could be generated.";
                return;
            }

            var renderer = new BatchPdfReportRenderer();

            await Task.Run(() =>
            {
                switch (_printMode)
                {
                    case PrintMode.Individual:
                        RenderIndividual(renderer, entries);
                        break;
                    case PrintMode.MirrorFolderStructure:
                        RenderMirror(renderer, entries);
                        break;
                    case PrintMode.Combined:
                        RenderCombined(renderer, entries);
                        break;
                }
            });

            StatusText = $"Done. {entries.Count} report(s) saved to: {_outputFolderPath}";
        }
        catch (Exception ex)
        {
            StatusText = $"Error: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private List<BatchPdfReportRenderer.ColumnEntry> BuildEntries(
        List<(int ColumnId, string? GroupName, string ColumnName)> items)
    {
        var projectName = _projectService.ProjectName;
        var results = new List<BatchPdfReportRenderer.ColumnEntry>();

        foreach (var item in items)
        {
            var calcResult = _projectService.LoadColumnResult(item.ColumnId);
            if (calcResult is null) continue;

            var reportData = BuildReportData(calcResult, projectName, item.GroupName ?? "", item.ColumnName);
            results.Add(new BatchPdfReportRenderer.ColumnEntry(item.GroupName, item.ColumnName, reportData));
        }
        return results;
    }

    private void RenderIndividual(BatchPdfReportRenderer renderer, List<BatchPdfReportRenderer.ColumnEntry> entries)
    {
        foreach (var entry in entries)
        {
            var safeFileName = MakeSafeFileName(entry.ColumnName) + ".pdf";
            var filePath = Path.Combine(_outputFolderPath, safeFileName);
            renderer.RenderIndividual(entry.ReportData, filePath);

            System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
            {
                ProgressValue++;
                StatusText = $"Rendering {ProgressValue} / {ProgressMax}…";
            });
        }
    }

    private void RenderMirror(BatchPdfReportRenderer renderer, List<BatchPdfReportRenderer.ColumnEntry> entries)
    {
        foreach (var entry in entries)
        {
            string folder = entry.GroupName is not null
                ? Path.Combine(_outputFolderPath, MakeSafeFileName(entry.GroupName))
                : _outputFolderPath;
            Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, MakeSafeFileName(entry.ColumnName) + ".pdf");
            renderer.RenderIndividual(entry.ReportData, filePath);

            System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
            {
                ProgressValue++;
                StatusText = $"Rendering {ProgressValue} / {ProgressMax}…";
            });
        }
    }

    private void RenderCombined(BatchPdfReportRenderer renderer, List<BatchPdfReportRenderer.ColumnEntry> entries)
    {
        var projectName = MakeSafeFileName(_projectService.ProjectName);
        var filePath = Path.Combine(_outputFolderPath, $"{projectName}_Combined_Report.pdf");
        renderer.RenderCombined(entries, filePath);

        System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
        {
            ProgressValue = ProgressMax;
            StatusText = $"Combined report saved.";
        });
    }

    private List<(int ColumnId, string? GroupName, string ColumnName)> GetSelectedColumnsWithGroups()
    {
        var result = new List<(int, string?, string)>();

        foreach (var node in ExplorerNodes)
        {
            if (node is PrintGroupNode group)
            {
                foreach (var col in group.Columns)
                {
                    if (col.IsChecked)
                        result.Add((col.Id, group.Name, col.Name));
                }
            }
            else if (node is PrintColumnNode col && col.IsChecked)
            {
                result.Add((col.Id, null, col.Name));
            }
        }

        return result;
    }

    private void SetAllChecked(bool value)
    {
        foreach (var node in ExplorerNodes)
        {
            if (node is PrintGroupNode group)
                group.IsChecked = value;
            else if (node is PrintColumnNode col)
                col.IsChecked = value;
        }
    }

    private static ReportData BuildReportData(
        CalculationResultDto result,
        string projectName,
        string groupName,
        string columnName)
    {
        string? sectionSvg = null;
        try
        {
            sectionSvg = InteractionDiagramSvgRenderer.SectionGeometryRenderer.RenderSection(
                result.SectionShape,
                result.SectionWidthMm, result.SectionHeightMm,
                result.DiameterMm > 0 ? result.DiameterMm : result.SectionWidthMm,
                result.CoverMm, result.RebarCoordinates);
        }
        catch { }

        DiagramBlock? pmDiagram = null, mmDiagram = null;
        try
        {
            var diag = new DiagramDataService();
            double theta = result.GoverningThetaDegrees;
            var pmData = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
            var pmAll = pmData.Points
                .Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta))
                .Concat(pmData.SpecialCapacityPoints)
                .ToList();
            pmDiagram = new DiagramBlock(pmAll, pmData.ReferenceLines,
                $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                UseEqualAspect: false, WidthPct: 90,
                Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

            var mmData = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
            var mmAll = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
            mmDiagram = new DiagramBlock(mmAll, [],
                $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                UseEqualAspect: true, WidthPct: 80,
                Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");
        }
        catch { }

        IDesignCodeService codeService = result.DesignCode == DesignCodeType.Aci318Style
            ? new Aci318DesignCodeService()
            : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
        IUnitConversionService unitService = new UnitConversionService();

        return new CalculationReportBuilder().Build(
            projectName, groupName, columnName,
            result, codeService, unitService, sectionSvg,
            pmDiagram: pmDiagram, mmDiagram: mmDiagram);
    }

    private static string MakeSafeFileName(string name)
    {
        var invalid = Path.GetInvalidFileNameChars();
        return string.Concat(name.Select(c => invalid.Contains(c) ? '_' : c)).Trim();
    }
}
