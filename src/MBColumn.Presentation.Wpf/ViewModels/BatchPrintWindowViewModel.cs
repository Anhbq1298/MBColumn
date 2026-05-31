using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Reports.Graphics;
using MBColumn.Infrastructure.Reports.Pdf;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public enum BatchPrintMode
{
    KeepStructure,
    Flat,
    Compiled
}

// ── Tree node VMs ────────────────────────────────────────────────────────────

public sealed class BatchGroupNode : ViewModelBase
{
    private bool? isChecked = true;
    private bool isUpdating;

    public int Id { get; }
    public string Name { get; }
    public ObservableCollection<BatchColumnNode> Columns { get; } = [];

    public BatchGroupNode(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public bool? IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked == value) return;
            isChecked = value;
            Raise();
            if (!isUpdating && value.HasValue)
                PropagateToChildren(value.Value);
        }
    }

    private void PropagateToChildren(bool val)
    {
        foreach (var col in Columns)
            col.IsChecked = val;
    }

    public void RefreshFromChildren()
    {
        if (Columns.Count == 0) return;
        isUpdating = true;
        bool allOn  = Columns.All(c => c.IsChecked == true);
        bool allOff = Columns.All(c => c.IsChecked == false);
        isChecked = allOn ? true : allOff ? false : null;
        Raise(nameof(IsChecked));
        isUpdating = false;
    }
}

public sealed class BatchColumnNode : ViewModelBase
{
    private bool isChecked = true;

    public int    Id      { get; }
    public int?   GroupId { get; }
    public string Name    { get; }

    public BatchGroupNode? ParentGroup { get; set; }

    public BatchColumnNode(int id, int? groupId, string name)
    {
        Id      = id;
        GroupId = groupId;
        Name    = name;
    }

    public bool IsChecked
    {
        get => isChecked;
        set
        {
            if (isChecked == value) return;
            isChecked = value;
            Raise();
            ParentGroup?.RefreshFromChildren();
        }
    }
}

// ── Main ViewModel ───────────────────────────────────────────────────────────

public sealed class BatchPrintWindowViewModel : ViewModelBase
{
    private readonly IProjectService _projectService;
    private readonly ColumnCalculationService _calculationService;
    private readonly Func<InputViewModel> _inputFactory;
    private readonly IMessageService _messageService;
    private readonly ProjectSession _projectSession;

    private string _outputFolderPath = "";
    private BatchPrintMode _printMode = BatchPrintMode.KeepStructure;
    private bool _isBusy;
    private int _progressValue;
    private int _progressMax;
    private string _statusText = "";

    public BatchPrintWindowViewModel(
        IProjectService projectService,
        ColumnCalculationService calculationService,
        Func<InputViewModel> inputFactory,
        IMessageService messageService,
        ProjectSession projectSession)
    {
        _projectService     = projectService;
        _calculationService = calculationService;
        _inputFactory       = inputFactory;
        _messageService     = messageService;
        _projectSession     = projectSession;

        BrowseFolderCommand  = new RelayCommand(BrowseFolder);
        PrintSelectedCommand = new AsyncRelayCommand(async () => await PrintAsync(checkedOnly: true),
            () => !IsBusy && HasCheckedColumns);
        PrintAllCommand      = new AsyncRelayCommand(async () => await PrintAsync(checkedOnly: false),
            () => !IsBusy);
        SelectAllCommand     = new RelayCommand(() => SetAll(true));
        ClearAllCommand      = new RelayCommand(() => SetAll(false));

        BuildTree();
        OutputFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    public ObservableCollection<BatchGroupNode> Groups { get; } = [];

    public ICommand BrowseFolderCommand  { get; }
    public ICommand PrintSelectedCommand { get; }
    public ICommand PrintAllCommand      { get; }
    public ICommand SelectAllCommand     { get; }
    public ICommand ClearAllCommand      { get; }

    public string OutputFolderPath
    {
        get => _outputFolderPath;
        set => Set(ref _outputFolderPath, value);
    }

    public BatchPrintMode PrintMode
    {
        get => _printMode;
        set => Set(ref _printMode, value);
    }

    public bool ModeKeepStructure
    {
        get => _printMode == BatchPrintMode.KeepStructure;
        set { if (value) PrintMode = BatchPrintMode.KeepStructure; }
    }

    public bool ModeFlat
    {
        get => _printMode == BatchPrintMode.Flat;
        set { if (value) PrintMode = BatchPrintMode.Flat; }
    }

    public bool ModeCompiled
    {
        get => _printMode == BatchPrintMode.Compiled;
        set { if (value) PrintMode = BatchPrintMode.Compiled; }
    }

    public bool IsBusy
    {
        get => _isBusy;
        private set
        {
            Set(ref _isBusy, value);
            RaiseCommandStates();
        }
    }

    public int ProgressValue { get => _progressValue; private set => Set(ref _progressValue, value); }
    public int ProgressMax   { get => _progressMax;   private set => Set(ref _progressMax, value); }
    public string StatusText { get => _statusText;    private set => Set(ref _statusText, value); }

    public bool HasCheckedColumns => AllColumnNodes().Any(c => c.IsChecked);

    // ── Init ─────────────────────────────────────────────────────────────────

    private void BuildTree()
    {
        var groups  = _projectService.GetGroups();
        var columns = _projectService.GetColumns();

        // Ungrouped columns → synthetic "Ungrouped" group
        var ungrouped = columns.Where(c => c.GroupId is null).ToList();

        foreach (var g in groups)
        {
            var groupNode = new BatchGroupNode(g.Id, g.Name);
            foreach (var col in columns.Where(c => c.GroupId == g.Id).OrderBy(c => c.SortOrder))
            {
                var colNode = new BatchColumnNode(col.Id, col.GroupId, col.Name) { ParentGroup = groupNode };
                groupNode.Columns.Add(colNode);
            }
            if (groupNode.Columns.Count > 0)
                Groups.Add(groupNode);
        }

        if (ungrouped.Count > 0)
        {
            var synthGroup = new BatchGroupNode(-1, "Ungrouped");
            foreach (var col in ungrouped.OrderBy(c => c.SortOrder))
            {
                var colNode = new BatchColumnNode(col.Id, null, col.Name) { ParentGroup = synthGroup };
                synthGroup.Columns.Add(colNode);
            }
            Groups.Add(synthGroup);
        }
    }

    /// <summary>Pre-check only the columns in the specified group.</summary>
    public void CheckOnlyGroup(int groupId)
    {
        foreach (var g in Groups)
        {
            bool match = g.Id == groupId;
            foreach (var col in g.Columns)
                col.IsChecked = match;
        }
    }

    // ── Commands ─────────────────────────────────────────────────────────────

    private void BrowseFolder()
    {
        var dlg = new Microsoft.Win32.OpenFolderDialog
        {
            Title     = "Select output folder for PDF reports",
            Multiselect = false,
        };
        if (dlg.ShowDialog() == true)
            OutputFolderPath = dlg.FolderName;
    }

    private void SetAll(bool val)
    {
        foreach (var g in Groups)
            foreach (var col in g.Columns)
                col.IsChecked = val;
    }

    private IEnumerable<BatchColumnNode> AllColumnNodes()
        => Groups.SelectMany(g => g.Columns);

    private void RaiseCommandStates()
    {
        (PrintSelectedCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
        (PrintAllCommand      as AsyncRelayCommand)?.RaiseCanExecuteChanged();
        Raise(nameof(HasCheckedColumns));
    }

    // ── Print logic ──────────────────────────────────────────────────────────

    private async Task PrintAsync(bool checkedOnly)
    {
        if (string.IsNullOrWhiteSpace(OutputFolderPath))
        {
            _messageService.ShowWarning("Please select an output folder.", "Batch Print");
            return;
        }

        var targets = AllColumnNodes()
            .Where(c => !checkedOnly || c.IsChecked)
            .ToList();

        if (targets.Count == 0)
        {
            _messageService.ShowWarning("No sections selected.", "Batch Print");
            return;
        }

        IsBusy        = true;
        ProgressMax   = targets.Count;
        ProgressValue = 0;
        StatusText    = "Starting…";

        var tempDir = Path.Combine(Path.GetTempPath(), $"MBColumn_batch_{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempDir);

        var rendered = new List<(string TempPath, string GroupName, string ColumnName, ReportData Data)>();
        var errors   = new List<string>();

        try
        {
            await Task.Run(() =>
            {
                foreach (var col in targets)
                {
                    string groupName = Groups.FirstOrDefault(g => g.Id == col.GroupId || (col.GroupId is null && g.Id == -1))?.Name ?? "Default";

                    Report($"Rendering {col.Name}…");

                    try
                    {
                        // Ensure result is available
                        var result = _projectService.LoadColumnResult(col.Id);
                        if (result is null)
                        {
                            var snapshot = _projectService.LoadColumnInput(col.Id);
                            if (snapshot is null) { errors.Add($"{col.Name}: no input data"); Advance(); continue; }

                            var vm = _inputFactory();
                            vm.LoadFromSnapshot(snapshot);
                            result = _calculationService.Calculate(vm.ToDto());
                            if (result is null) { errors.Add($"{col.Name}: calculation failed"); Advance(); continue; }

                            _projectService.SaveColumnResult(col.Id, result);
                        }

                        // Build report data
                        var reportData = BuildReportData(result, _projectService.ProjectName, groupName, col.Name);

                        // Render to temp PDF
                        string tempPath = Path.Combine(tempDir, $"{Sanitize(col.Name)}.pdf");
                        var renderer = new QuestPdfCalculationReportRenderer();
                        renderer.RenderToFile(reportData, tempPath);
                        renderer.AddBookmarks(tempPath, reportData, col.Name);

                        rendered.Add((tempPath, groupName, col.Name, reportData));
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"{col.Name}: {ex.Message}");
                    }

                    Advance();
                }
            });

            if (rendered.Count == 0)
            {
                _messageService.ShowWarning("No reports were generated.", "Batch Print");
                return;
            }

            // Output phase
            StatusText = "Writing output…";
            await Task.Run(() => WriteOutput(rendered));

            string summary = $"Saved {rendered.Count} report(s) to:\n{OutputFolderPath}";
            if (errors.Count > 0)
                summary += $"\n\n{errors.Count} section(s) failed:\n" + string.Join("\n", errors);

            _messageService.ShowInformation(summary, "Batch Print Complete");
            StatusText = "Done.";
        }
        catch (Exception ex)
        {
            _messageService.ShowError($"Batch print failed:\n{ex.Message}", "Batch Print Error");
            StatusText = "Failed.";
        }
        finally
        {
            IsBusy = false;
            try { Directory.Delete(tempDir, true); } catch { }
        }

        void Report(string text) => System.Windows.Application.Current?.Dispatcher.InvokeAsync(
            () => StatusText = text);

        void Advance() => System.Windows.Application.Current?.Dispatcher.InvokeAsync(
            () => ProgressValue++);
    }

    private void WriteOutput(
        List<(string TempPath, string GroupName, string ColumnName, ReportData Data)> rendered)
    {
        Directory.CreateDirectory(OutputFolderPath);

        switch (_printMode)
        {
            case BatchPrintMode.KeepStructure:
                foreach (var (tempPath, groupName, colName, _) in rendered)
                {
                    string folder = Path.Combine(OutputFolderPath, Sanitize(groupName));
                    Directory.CreateDirectory(folder);
                    File.Copy(tempPath, Path.Combine(folder, Sanitize(colName) + ".pdf"), overwrite: true);
                }
                break;

            case BatchPrintMode.Flat:
                foreach (var (tempPath, _, colName, _) in rendered)
                    File.Copy(tempPath, Path.Combine(OutputFolderPath, Sanitize(colName) + ".pdf"), overwrite: true);
                break;

            case BatchPrintMode.Compiled:
                string projectName = Sanitize(_projectService.ProjectName.Length > 0
                    ? _projectService.ProjectName : "MBColumn");
                string outputPath = Path.Combine(OutputFolderPath, $"{projectName}_Combined_Report.pdf");
                PdfMergeUtility.MergePdfDocuments(rendered, outputPath);
                break;
        }
    }

    private static ReportData BuildReportData(
        MBColumn.Application.DTOs.CalculationResultDto result,
        string projectName, string groupName, string columnName)
    {
        IDesignCodeService codeService = result.DesignCode == MBColumn.Domain.Enums.DesignCodeType.Aci318Style
            ? new Aci318DesignCodeService()
            : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
        IUnitConversionService unitService = new UnitConversionService();

        string? sectionSvg = null;
        try
        {
            sectionSvg = SectionGeometryRenderer.RenderSection(
                result.SectionShape,
                result.SectionWidthMm, result.SectionHeightMm,
                result.DiameterMm > 0 ? result.DiameterMm : result.SectionWidthMm,
                result.CoverMm, result.RebarCoordinates);
        }
        catch { }

        DiagramBlock? pmDiagram = null, mmDiagram = null;
        try
        {
            var diag   = new DiagramDataService();
            double theta = result.GoverningThetaDegrees;
            var pmData   = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
            var pmAll    = pmData.Points
                .Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta))
                .Concat(pmData.SpecialCapacityPoints).ToList();
            pmDiagram = new DiagramBlock(pmAll, pmData.ReferenceLines,
                $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                UseEqualAspect: false, WidthPct: 90,
                Caption: $"P-M interaction diagram at θ = {theta:F1}°");

            var mmData = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
            var mmAll  = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
            mmDiagram = new DiagramBlock(mmAll, [],
                $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                UseEqualAspect: true, WidthPct: 80,
                Caption: "Mx-My interaction diagram at governing axial load");
        }
        catch { }

        return new CalculationReportBuilder().Build(
            projectName, groupName, columnName,
            result, codeService, unitService, sectionSvg,
            pmDiagram: pmDiagram, mmDiagram: mmDiagram);
    }

    private static string Sanitize(string name)
        => string.Concat(name.Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c)).Trim();
}
