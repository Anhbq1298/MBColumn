using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Reports.Pdf;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using MBColumn.Presentation.Wpf.Views;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ColumnCalculationService calculationService;
    private readonly IProjectService projectService;
    private readonly IMessageService messageService;
    private readonly IProjectFileDialogService projectFileDialogService;
    private readonly IProjectNameDialogService projectNameDialogService;
    private readonly IEtabsImportDialogService etabsImportDialogService;
    private readonly IEtabsForceRefreshDialogService? etabsForceRefreshDialogService;
    private readonly ProjectSession projectSession;
    private string validationMessage = "";
    private bool isCalculationOutdated;
    private ColumnItemViewModel? currentColumn;
    private string windowTitle = "MBColumn";
    private bool isCalculating;
    private string calculationStatus = "";
    private int selectedMainTabIndex;
    private bool suppressModified;
    private bool isSaving;
    private bool isImporting;
    private int importProgressValue;
    private int importProgressMax;
    private string importStatusText = "";
    private bool isSaveNotificationVisible;
    private string saveNotificationText = "";
    private CancellationTokenSource? saveNotificationCts;

    private readonly Func<InputViewModel> inputFactory;

    public MainWindowViewModel(
        ColumnCalculationService calculationService,
        IProjectService projectService,
        InputViewModel input,
        Func<InputViewModel> inputFactory,
        IMessageService messageService,
        IProjectFileDialogService projectFileDialogService,
        IProjectNameDialogService projectNameDialogService,
        IEtabsImportDialogService etabsImportDialogService,
        ProjectSession projectSession,
        IEtabsForceRefreshDialogService? etabsForceRefreshDialogService = null)
    {
        this.calculationService = calculationService;
        this.projectService = projectService;
        this.inputFactory = inputFactory;
        this.messageService = messageService;
        this.projectFileDialogService = projectFileDialogService;
        this.projectNameDialogService = projectNameDialogService;
        this.etabsImportDialogService = etabsImportDialogService;
        this.etabsForceRefreshDialogService = etabsForceRefreshDialogService;
        this.projectSession = projectSession;
        Input = input;
        Result = new ResultViewModel();
        Report = new ReportTabViewModel();

        Explorer = new ProjectExplorerViewModel(
            projectService,
            OnColumnSelected,
            SaveCurrentColumnInput,
            projectNameDialogService,
            projectNameDialogService.PromptSelectSections,
            messageService);

        CalculateCommand = new AsyncRelayCommand(CalculateCurrentColumnAsync, () => !IsCalculating && HasCurrentSection);
        CalculateCurrentColumnCommand = CalculateCommand;
        CalculateAllColumnsCommand = new AsyncRelayCommand(CalculateAllColumnsAsync, () => !IsCalculating && HasSections);
        CalculateSelectedColumnsCommand = new AsyncRelayCommand(CalculateSelectedColumnsAsync, () => !IsCalculating && HasSelectedColumns);
        NewProjectCommand = new RelayCommand(NewProject);
        OpenProjectCommand = new AsyncRelayCommand(OpenProjectAsync);
        SaveProjectCommand = new AsyncRelayCommand(SaveProjectAsync);
        SaveProjectAsCommand = new AsyncRelayCommand(SaveProjectAsAsync);

        // ETABS commands — explicit source-differentiated versions plus legacy wrappers
        ImportSectionsFromEtabsCommand = new AsyncRelayCommand(ImportFromEtabsAsync);
        ImportElementForcesCommand = new AsyncRelayCommand(ImportElementForcesAsync,
            () => etabsForceRefreshDialogService is not null);
        ImportDesignForcesCommand = new AsyncRelayCommand(ImportDesignForcesAsync,
            () => etabsForceRefreshDialogService is not null);
        RefreshElementForcesCommand = new AsyncRelayCommand(RefreshEtabsForcesAsync,
            () => etabsForceRefreshDialogService is not null);
        RefreshDesignForcesCommand = new AsyncRelayCommand(RefreshEtabsForcesAsync,
            () => etabsForceRefreshDialogService is not null);

        // Legacy wrappers kept for existing XAML bindings
        ImportFromEtabsCommand = ImportSectionsFromEtabsCommand;
        RefreshEtabsForcesCommand = RefreshElementForcesCommand;

        PrintSingleReportCommand = new AsyncRelayCommand(
            () => PrintSingleReportAsync(currentColumn), () => !IsCalculating && HasCurrentSection);

        BatchPrintCommand        = new RelayCommand(() => OpenBatchPrintWindow(), () => HasSections);
        PrintGroupReportsCommand = new RelayCommand<GroupItemViewModel>(OpenBatchPrintForGroup);

        SubscribeToInputChanges();
        UpdateWindowTitle();

        Explorer.Nodes.CollectionChanged += (_, _) =>
        {
            Raise(nameof(HasSections));
            Raise(nameof(HasSelectedColumns));
            RaiseCommandStates();
            RaiseStatusProperties();
        };

        Explorer.SelectedColumnsChanged += () =>
        {
            Raise(nameof(HasSelectedColumns));
            RaiseCommandStates();
        };

        projectService.ProjectChanged += (_, _) =>
        {
            UpdateWindowTitle();
            RaiseStatusProperties();
        };
    }

    public InputViewModel Input { get; }
    public ResultViewModel Result { get; }
    public ReportTabViewModel Report { get; }
    public ProjectExplorerViewModel Explorer { get; }

    public ICommand CalculateCommand { get; }
    public ICommand CalculateCurrentColumnCommand { get; }
    public ICommand CalculateAllColumnsCommand { get; }
    public ICommand CalculateSelectedColumnsCommand { get; }
    public ICommand NewProjectCommand { get; }
    public ICommand OpenProjectCommand { get; }
    public ICommand SaveProjectCommand { get; }
    public ICommand SaveProjectAsCommand { get; }

    // Explicit ETABS commands
    public ICommand ImportSectionsFromEtabsCommand { get; }
    public ICommand ImportElementForcesCommand { get; }
    public ICommand ImportDesignForcesCommand { get; }
    public ICommand RefreshElementForcesCommand { get; }
    public ICommand RefreshDesignForcesCommand { get; }

    // Legacy — kept so existing XAML bindings continue to work
    public ICommand ImportFromEtabsCommand { get; }
    public ICommand RefreshEtabsForcesCommand { get; }

    public ICommand PrintSingleReportCommand  { get; }
    public ICommand BatchPrintCommand         { get; }
    public ICommand PrintGroupReportsCommand  { get; }


    public string ValidationMessage { get => validationMessage; set => Set(ref validationMessage, value); }
    public string WindowTitle { get => windowTitle; private set => Set(ref windowTitle, value); }
    public string CalculationStatus
    {
        get => calculationStatus;
        private set
        {
            if (calculationStatus == value) return;
            calculationStatus = value;
            Raise();
            Raise(nameof(AppStatusText));
        }
    }
    public int SelectedMainTabIndex { get => selectedMainTabIndex; set => Set(ref selectedMainTabIndex, value); }
    public bool HasCurrentSection => currentColumn is not null;
    public bool HasSections => Explorer is not null && Explorer.Nodes.Count > 0;
    public bool HasSelectedColumns => Explorer is not null && Explorer.GetSelectedColumnIds().Count > 0;
    public bool HasCurrentResult => Result.HasResult;
    public bool ShowInputEmptyState => !HasCurrentSection;
    public bool ShowResultContent => HasCurrentSection && HasCurrentResult && !IsCalculationOutdated;
    public bool ShowNoSectionResultEmptyState => !HasCurrentSection;
    public bool ShowNoResultEmptyState => HasCurrentSection && !HasCurrentResult;
    public bool ShowOutdatedResultEmptyState => HasCurrentSection && HasCurrentResult && IsCalculationOutdated;
    public bool IsProjectModified => projectService.IsModified;
    public bool IsCurrentResultOutdated => IsCalculationOutdated;
    public string AppStatusText => IsCalculating
        ? (string.IsNullOrWhiteSpace(CalculationStatus) ? "Calculating..." : CalculationStatus)
        : IsCalculationOutdated ? "Result outdated" : "Ready";
    public string ProjectStatusText => projectService.CurrentFilePath is null
        ? $"Project: {projectService.ProjectName}"
        : $"Project: {System.IO.Path.GetFileName(projectService.CurrentFilePath)}";
    public string CurrentSectionStatusText => currentColumn is null
        ? "No section selected"
        : $"Section: {currentColumn.Name}";
    public string ModifiedStatusText => projectService.IsModified ? "Modified" : "Saved";
    public bool IsSaving
    {
        get => isSaving;
        private set => Set(ref isSaving, value);
    }

    public bool IsImporting
    {
        get => isImporting;
        private set => Set(ref isImporting, value);
    }

    public int ImportProgressValue
    {
        get => importProgressValue;
        set => Set(ref importProgressValue, value);
    }

    public int ImportProgressMax
    {
        get => importProgressMax;
        set => Set(ref importProgressMax, value);
    }

    public string ImportStatusText
    {
        get => importStatusText;
        private set => Set(ref importStatusText, value);
    }

    public bool IsSaveNotificationVisible
    {
        get => isSaveNotificationVisible;
        private set => Set(ref isSaveNotificationVisible, value);
    }

    public string SaveNotificationText
    {
        get => saveNotificationText;
        private set => Set(ref saveNotificationText, value);
    }

    public string ResultFreshnessStatusText => IsCalculationOutdated
        ? "Input changed after last calculation"
        : HasCurrentResult ? "Result current" : "No result";

    public bool IsCalculating
    {
        get => isCalculating;
        private set
        {
            if (isCalculating == value) return;
            isCalculating = value;
            Raise();
            RaiseStatusProperties();
            RaiseCommandStates();
        }
    }

    public bool IsCalculationOutdated
    {
        get => isCalculationOutdated;
        private set
        {
            Set(ref isCalculationOutdated, value);
            Raise(nameof(IsResultsTabAvailable));
            RaiseResultStateProperties();
            RaiseStatusProperties();
        }
    }

    public bool IsResultsTabAvailable => true;

    private async Task CalculateCurrentColumnAsync()
        => await RunWithProgressAsync("Calculating this section...", async () =>
        {
            try
            {
                ValidationMessage = "";
                var dto = Input.ToDto();
                var result = await Task.Run(() => calculationService.Calculate(dto));
                
                Input.ApplySlendernessResults(result);
                projectSession.StoreCurrentColumnResult(result);
                Result.Result = result;
                IsCalculationOutdated = false;
                if (Explorer is not null && currentColumn is not null)
                    Explorer.SetSectionStatus(currentColumn.Id, SectionStatus.Calculated);
                SelectedMainTabIndex = 1;
                RaiseResultStateProperties();

                // Auto-save column input and result after successful calculation
                if (currentColumn is not null)
                {
                    SaveCurrentColumnInput();
                    projectService.SaveColumnResult(currentColumn.Id, result);
                }

                RefreshReportFromCurrentWorkspace();

                // Wait for WPF rendering to complete
                await Task.Delay(250);
            }
            catch (Exception ex)
            {
                ValidationMessage = ex.Message;
                if (Explorer is not null && currentColumn is not null)
                    Explorer.SetSectionStatus(currentColumn.Id, SectionStatus.Error);
                RaiseStatusProperties();
                messageService.ShowWarning(ex.Message, "Validation");
            }
        });

    private async Task CalculateAllColumnsAsync()
        => await RunWithProgressAsync("Calculating all sections...", CalculateAllColumnsBackgroundAsync);

    private async Task CalculateSelectedColumnsAsync()
        => await RunWithProgressAsync("Calculating selected sections...", CalculateSelectedColumnsBackgroundAsync);

    private async Task CalculateSelectedColumnsBackgroundAsync()
    {
        var selectedIds = Explorer.GetSelectedColumnIds().ToHashSet();
        if (selectedIds.Count == 0) return;

        var columns = projectService.GetColumns().Where(c => selectedIds.Contains(c.Id)).ToList();
        if (columns.Count == 0) return;

        SaveCurrentColumnInput();

        var selectedId = currentColumn?.Id;
        var failedColumns = new List<string>();

        var inputs = columns
            .Select(c => new
            {
                Column = c,
                Snapshot = projectService.LoadColumnInput(c.Id)
            })
            .Where(x => x.Snapshot is not null)
            .ToList();

        CalculationProgressWindow? progressWindow = null;
        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            progressWindow = new CalculationProgressWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                ProgressMax = inputs.Count,
                ProgressValue = 0,
                StatusText = $"Calculating: [0/{inputs.Count}] calculated"
            };
            progressWindow.Show();
        });

        var backgroundResults = await Task.Run(() =>
        {
            var results = new List<(int ColumnId, string Name, MBColumn.Application.DTOs.CalculationResultDto? Result, string? Error)>();
            var localInput = inputFactory();

            int calculatedCount = 0;
            foreach (var item in inputs)
            {
                try
                {
                    localInput.LoadFromSnapshot(item.Snapshot!);
                    var result = calculationService.Calculate(localInput.ToDto());
                    results.Add((item.Column.Id, item.Column.Name, result, null));
                }
                catch (Exception ex)
                {
                    results.Add((item.Column.Id, item.Column.Name, null, ex.Message));
                }
                finally
                {
                    calculatedCount++;
                    int currentCount = calculatedCount;
                    System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            if (progressWindow is not null && progressWindow.IsLoaded)
                            {
                                progressWindow.ProgressValue = currentCount;
                                progressWindow.StatusText = $"Calculating: [{currentCount}/{inputs.Count}] calculated";
                            }
                        }
                        catch
                        {
                            // ignore
                        }
                    });
                }
            }
            return results;
        });

        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            try
            {
                if (progressWindow is not null && progressWindow.IsLoaded)
                {
                    progressWindow.Close();
                }
            }
            catch
            {
                // ignore
            }
        });

        suppressModified = true;
        try
        {
            foreach (var item in backgroundResults)
            {
                var columnId = item.ColumnId;
                if (item.Result is not null)
                {
                    projectSession.StoreColumnResult(columnId, item.Result);
                    projectService.SaveColumnResult(columnId, item.Result);
                    Explorer.SetSectionStatus(columnId, SectionStatus.Calculated);
                }
                else if (item.Error is not null)
                {
                    Explorer.SetSectionStatus(columnId, SectionStatus.Error);
                    failedColumns.Add($"{item.Name}: {item.Error}");
                }
            }

            if (selectedId is not null)
            {
                var selectedSnapshot = projectService.LoadColumnInput(selectedId.Value);
                if (selectedSnapshot is not null)
                    Input.LoadFromSnapshot(selectedSnapshot);
            }
        }
        finally
        {
            suppressModified = false;
        }

        if (failedColumns.Count > 0)
        {
            ValidationMessage = string.Join(Environment.NewLine, failedColumns);
            messageService.ShowWarning(
                $"Some sections could not be calculated:\n\n{ValidationMessage}",
                "Validation");
            return;
        }

        ValidationMessage = "";
        ApplyCurrentColumnResult();
        RefreshReportFromCurrentWorkspace();
        SelectedMainTabIndex = 1;
        RaiseResultStateProperties();
    }

    private void OpenBatchPrintWindow(GroupItemViewModel? preselectedGroup = null)
    {
        var vm = new BatchPrintWindowViewModel(
            projectService, calculationService, inputFactory, messageService, projectSession);

        if (preselectedGroup is not null)
            vm.CheckOnlyGroup(preselectedGroup.Id);

        var win = new BatchPrintWindow(vm)
        {
            Owner = System.Windows.Application.Current?.MainWindow
        };
        win.ShowDialog();
    }

    private void OpenBatchPrintForGroup(GroupItemViewModel? group)
        => OpenBatchPrintWindow(group);

    private async Task PrintSingleReportAsync(ColumnItemViewModel? column)
    {
        if (column is null) return;

        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Print Report as PDF",
            Filter = "PDF files (*.pdf)|*.pdf",
            FileName = $"{column.Name}_Report.pdf"
        };
        if (dialog.ShowDialog() != true) return;

        string pdfPath = dialog.FileName;

        var result = projectService.LoadColumnResult(column.Id);
        if (result is null || column.Status != SectionStatus.Calculated)
        {
            IsCalculating = true;
            CalculationStatus = "Calculating...";
            try
            {
                await Task.Run(() =>
                {
                    var snapshot = projectService.LoadColumnInput(column.Id);
                    if (snapshot is not null)
                    {
                        var localInput = inputFactory();
                        localInput.LoadFromSnapshot(snapshot);
                        var calcResult = calculationService.Calculate(localInput.ToDto());
                        if (calcResult is not null)
                        {
                            projectSession.StoreColumnResult(column.Id, calcResult);
                            projectService.SaveColumnResult(column.Id, calcResult);
                            Explorer.SetSectionStatus(column.Id, SectionStatus.Calculated);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                messageService.ShowError($"Calculation failed:\n{ex.Message}", "Print Error");
                IsCalculating = false;
                return;
            }
            finally
            {
                IsCalculating = false;
            }
        }

        IsCalculating = true;
        CalculationStatus = "Generating report...";
        try
        {
            await Task.Run(() =>
            {
                var res = projectService.LoadColumnResult(column.Id);
                if (res is null) throw new InvalidOperationException("No calculation result available.");

                string groupName = projectService.GetGroups().FirstOrDefault(g => g.Id == column.GroupId)?.Name ?? "Default";
                string projectName = projectService.ProjectName;

                IDesignCodeService codeService = res.DesignCode == Domain.Enums.DesignCodeType.Aci318Style
                    ? new Aci318DesignCodeService()
                    : new Ec2DesignCodeService { AlphaCc = res.AlphaCc };
                IUnitConversionService unitService = new UnitConversionService();

                string? sectionSvg = null;
                try
                {
                    sectionSvg = MBColumn.Infrastructure.Reports.Graphics.SectionGeometryRenderer.RenderSection(
                        res.SectionShape,
                        res.SectionWidthMm, res.SectionHeightMm,
                        res.DiameterMm > 0 ? res.DiameterMm : res.SectionWidthMm,
                        res.CoverMm, res.RebarCoordinates,
                        irregularBoundaryPoints: res.IrregularSectionBoundaryPoints);
                }
                catch { }

                DiagramBlock? pmDiagramBlock = null, mmDiagramBlock = null;
                try
                {
                    var diag = new DiagramDataService();
                    double theta = res.GoverningThetaDegrees;
                    var pmData = diag.BuildPmAngleDiagramData(res.ControlPoints, res.UnitSystem, theta);
                    var pmAll = pmData.Points.Concat(diag.BuildPmAngleDemandPoints(res.LoadCaseResults, theta)).Concat(pmData.SpecialCapacityPoints).ToList();
                    pmDiagramBlock = new DiagramBlock(pmAll, pmData.ReferenceLines,
                        $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", res.Ratio,
                        UseEqualAspect: false, WidthPct: 90,
                        Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

                    var mmData = diag.BuildMxMyDiagramDataAtDisplayP(res.ControlPoints, res.UnitSystem, res.PuDisplay);
                    var mmAll = mmData.Points.Concat(diag.BuildMxMyDemandPoints(res.LoadCaseResults)).ToList();
                    mmDiagramBlock = new DiagramBlock(mmAll, [],
                        $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", res.Ratio,
                        UseEqualAspect: true, WidthPct: 80,
                        Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");
                }
                catch { }

                var builder = new CalculationReportBuilder();
                var reportData = builder.Build(projectName, groupName, column.Name,
                                               res, codeService, unitService, sectionSvg,
                                               pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);

                var renderer = new QuestPdfCalculationReportRenderer();
                renderer.RenderToFile(reportData, pdfPath);
            });

            messageService.ShowInformation($"Report successfully saved to:\n{pdfPath}", "Print Complete");
        }
        catch (Exception ex)
        {
            messageService.ShowError($"Printing report failed:\n{ex.Message}", "Print Error");
        }
        finally
        {
            IsCalculating = false;
        }
    }

    private async Task RunWithProgressAsync(string status, Func<Task> calculateAsync)
    {
        IsCalculating = true;
        CalculationStatus = status;
        var elapsed = Stopwatch.StartNew();

        try
        {
            await calculateAsync();
        }
        finally
        {
            var remaining = TimeSpan.FromSeconds(1) - elapsed.Elapsed;
            if (remaining > TimeSpan.Zero)
                await Task.Delay(remaining);

            CalculationStatus = "";
            IsCalculating = false;
        }
    }

    private async Task CalculateAllColumnsBackgroundAsync()
    {
        var columns = projectService.GetColumns();
        if (columns.Count == 0) return;

        SaveCurrentColumnInput();

        var selectedId = currentColumn?.Id;
        var failedColumns = new List<string>();

        var inputs = columns
            .Select(c => new
            {
                Column = c,
                Snapshot = projectService.LoadColumnInput(c.Id)
            })
            .Where(x => x.Snapshot is not null)
            .ToList();

        CalculationProgressWindow? progressWindow = null;
        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            progressWindow = new CalculationProgressWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                ProgressMax = inputs.Count,
                ProgressValue = 0,
                StatusText = $"Calculating: [0/{inputs.Count}] calculated"
            };
            progressWindow.Show();
        });

        var backgroundResults = await Task.Run(() =>
        {
            var results = new List<(int ColumnId, string Name, MBColumn.Application.DTOs.CalculationResultDto? Result, string? Error)>();
            var localInput = inputFactory();

            int calculatedCount = 0;
            foreach (var item in inputs)
            {
                try
                {
                    localInput.LoadFromSnapshot(item.Snapshot!);
                    var result = calculationService.Calculate(localInput.ToDto());
                    results.Add((item.Column.Id, item.Column.Name, result, null));
                }
                catch (Exception ex)
                {
                    results.Add((item.Column.Id, item.Column.Name, null, ex.Message));
                }
                finally
                {
                    calculatedCount++;
                    int currentCount = calculatedCount;
                    System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            if (progressWindow is not null && progressWindow.IsLoaded)
                            {
                                progressWindow.ProgressValue = currentCount;
                                progressWindow.StatusText = $"Calculating: [{currentCount}/{inputs.Count}] calculated";
                            }
                        }
                        catch
                        {
                            // ignore
                        }
                    });
                }
            }
            return results;
        });

        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            try
            {
                if (progressWindow is not null && progressWindow.IsLoaded)
                {
                    progressWindow.Close();
                }
            }
            catch
            {
                // ignore
            }
        });

        suppressModified = true;
        try
        {
            foreach (var item in backgroundResults)
            {
                var columnId = item.ColumnId;
                if (item.Result is not null)
                {
                    projectSession.StoreColumnResult(columnId, item.Result);
                    projectService.SaveColumnResult(columnId, item.Result);
                    Explorer.SetSectionStatus(columnId, SectionStatus.Calculated);
                }
                else if (item.Error is not null)
                {
                    Explorer.SetSectionStatus(columnId, SectionStatus.Error);
                    failedColumns.Add($"{item.Name}: {item.Error}");
                }
            }

            if (selectedId is not null)
            {
                var selectedSnapshot = projectService.LoadColumnInput(selectedId.Value);
                if (selectedSnapshot is not null)
                    Input.LoadFromSnapshot(selectedSnapshot);
            }
        }
        finally
        {
            suppressModified = false;
        }

        if (failedColumns.Count > 0)
        {
            ValidationMessage = string.Join(Environment.NewLine, failedColumns);
            messageService.ShowWarning(
                $"Some sections could not be calculated:\n\n{ValidationMessage}",
                "Validation");
            return;
        }

        ValidationMessage = "";
        ApplyCurrentColumnResult();
        RefreshReportFromCurrentWorkspace();
        SelectedMainTabIndex = 1;
        RaiseResultStateProperties();
    }

    private void NewProject()
    {
        if (!ConfirmDiscardChanges()) return;

        var name = projectNameDialogService.PromptProjectName("New Project");
        if (name is null) return;

        // Save + detach before firing any project events
        SaveCurrentColumnInput();
        currentColumn = null;
        projectSession.SelectColumn(null);

        projectService.NewProject(name);
        ClearResults();
        Report.Clear();
        Explorer.ClearSectionStatuses();
        IsCalculationOutdated = false;
        SelectedMainTabIndex = 0;
        RaiseResultStateProperties();
        RaiseStatusProperties();
    }

    private async Task OpenProjectAsync()
    {
        if (!ConfirmDiscardChanges()) return;

        var filePath = projectFileDialogService.ShowOpenProjectDialog();
        if (filePath is null) return;

        try
        {
            // Save + detach before firing any project events
            SaveCurrentColumnInput();
            currentColumn = null;
            projectSession.SelectColumn(null);

            CalculationStatus = "Opening project...";
            IsCalculating = true;

            await Task.Run(() => projectService.OpenProject(filePath));

            ClearResults();
            Report.Clear();
            Explorer.ClearSectionStatuses();

            // Load statuses in background thread to keep UI perfectly smooth
            var columns = projectService.GetColumns();
            await Task.Run(() =>
            {
                foreach (var col in columns)
                {
                    var persisted = projectService.LoadColumnResult(col.Id);
                    if (persisted is not null)
                    {
                        System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
                        {
                            Explorer.SetSectionStatus(col.Id, SectionStatus.Calculated);
                        });
                    }
                }
            });

            IsCalculationOutdated = false;
            SelectedMainTabIndex = 0;
            RaiseResultStateProperties();
            RaiseStatusProperties();
        }
        catch (Exception ex)
        {
            messageService.ShowError($"Failed to open project:\n{ex.Message}");
        }
        finally
        {
            CalculationStatus = "";
            IsCalculating = false;
        }
    }

    private async Task ImportFromEtabsAsync()
    {
        SaveCurrentColumnInput();

        var existingNames = projectService.GetColumns()
            .Select(column => column.Name)
            .ToList();
        var groups = projectService.GetGroups();
        var defaultTargetGroupId = Explorer.SelectedNode switch
        {
            GroupItemViewModel group => group.Id,
            ColumnItemViewModel column => column.GroupId,
            _ => currentColumn?.GroupId ?? groups.FirstOrDefault()?.Id
        };
        var result = etabsImportDialogService.ShowDialog(
            System.Windows.Application.Current?.MainWindow,
            existingNames,
            groups,
            defaultTargetGroupId,
            Input.UnitSystem);
        if (result is null || result.Sections.Count == 0)
        {
            return;
        }

        try
        {
            IsImporting = true;
            ImportProgressMax = result.Sections.Count;
            ImportProgressValue = 0;
            ImportStatusText = $"Importing 0 of {result.Sections.Count} sections...";

            // Yield to UI to show the overlay
            await Task.Yield();

            var columnsByName = projectService.GetColumns()
                .ToDictionary(column => column.Name, StringComparer.OrdinalIgnoreCase);
            int created = 0;
            int updated = 0;
            int? lastImportedId = null;

            foreach (var imported in result.Sections)
            {
                var targetGroupId = imported.TargetGroupId;
                var targetGroupName = imported.TargetGroupName;
                if (imported.CreateTargetGroup)
                {
                    var group = projectService.AddGroup(imported.TargetGroupName);
                    targetGroupId = group.Id;
                    targetGroupName = group.Name;
                }

                if (imported.UpdateExisting && columnsByName.TryGetValue(imported.SectionName, out var existing))
                {
                    if (existing.GroupId != targetGroupId)
                        projectService.MoveColumn(existing.Id, targetGroupId);
                    projectService.SaveColumnInput(existing.Id, imported.Snapshot);
                    projectSession.ClearColumnResult(existing.Id);
                    Explorer.SetSectionStatus(existing.Id, SectionStatus.NotCalculated);
                    lastImportedId = existing.Id;
                    updated++;
                }
                else
                {
                    var record = projectService.AddColumn(imported.SectionName, targetGroupId);
                    projectService.SaveColumnInput(record.Id, imported.Snapshot);
                    projectSession.ClearColumnResult(record.Id);
                    Explorer.SetSectionStatus(record.Id, SectionStatus.NotCalculated);
                    columnsByName[record.Name] = record;
                    lastImportedId = record.Id;
                    created++;
                }

                ImportProgressValue++;
                ImportStatusText = $"Importing {ImportProgressValue} of {ImportProgressMax} sections...";
                
                // Yield to UI thread occasionally to keep progress bar smooth (every 5 items)
                if (ImportProgressValue % 5 == 0)
                    await Task.Yield();
            }

            if (lastImportedId is not null)
            {
                Explorer.SelectColumnById(lastImportedId.Value);
            }

            SelectedMainTabIndex = 0;
            ValidationMessage = "";
            RaiseStatusProperties();
            var importedTier = result.Sections.Count == 1 ? result.Sections[0] : null;
            
            // Hide progress overlay before showing dialog
            IsImporting = false;
            
            messageService.ShowInformation(
                importedTier is not null
                    ? $"Imported ETABS design tier '{importedTier.SectionName}' into '{importedTier.TargetGroupName}' with {importedTier.Snapshot.EtabsTierMetadata?.SourceObjects.Count ?? 0} objects and {importedTier.Snapshot.LoadCases.Count} demand cases."
                    : $"Imported {created + updated} ETABS design tiers.",
                "ETABS Import");
        }
        catch (Exception ex)
        {
            IsImporting = false;
            messageService.ShowError($"Failed to import ETABS sections:\n{ex.Message}", "ETABS Import");
        }
        finally
        {
            IsImporting = false;
        }
    }

    private async Task ImportElementForcesAsync()
    {
        var bindings = GetEtabsBindings();
        if (bindings.Count == 0)
        {
            messageService.ShowInformation(
                "No ETABS-linked sections found.\nImport sections from ETABS first to create a binding, then use this command to import element forces.",
                "Import Element Forces");
            return;
        }
        // Route through the existing refresh dialog for now.
        // A dedicated element-force import dialog will replace this in a later phase.
        await RefreshEtabsForcesAsync();
    }

    private async Task ImportDesignForcesAsync()
    {
        var bindings = GetEtabsBindings();
        if (bindings.Count == 0)
        {
            messageService.ShowInformation(
                "No ETABS-linked sections found.\nImport sections from ETABS first to create a binding, then use this command to import design forces.",
                "Import Design Forces");
            return;
        }
        // Route through the existing refresh dialog for now.
        // A dedicated design-force import dialog will replace this in a later phase.
        await RefreshEtabsForcesAsync();
    }

    private IReadOnlyList<Application.DTOs.Etabs.EtabsSectionBinding> GetEtabsBindings()
    {
        var bindings = new List<Application.DTOs.Etabs.EtabsSectionBinding>();
        foreach (var col in projectService.GetColumns())
        {
            var snapshot = projectService.LoadColumnInput(col.Id);
            if (snapshot?.EtabsBinding is not null)
                bindings.Add(snapshot.EtabsBinding);
        }
        return bindings;
    }

    private async Task RefreshEtabsForcesAsync()
    {
        if (etabsForceRefreshDialogService is null) return;
        await Task.Yield();

        SaveCurrentColumnInput();

        var allColumns = projectService.GetColumns();
        var bindings = new List<Application.DTOs.Etabs.EtabsSectionBinding>();
        var existingLoadCases = new Dictionary<string, IReadOnlyList<SnapshotLoadCase>>(StringComparer.OrdinalIgnoreCase);

        foreach (var col in allColumns)
        {
            var snapshot = projectService.LoadColumnInput(col.Id);
            if (snapshot?.EtabsBinding is null) continue;

            bindings.Add(snapshot.EtabsBinding);
            existingLoadCases[col.Name] = snapshot.LoadCases;
        }

        if (bindings.Count == 0)
        {
            messageService.ShowInformation(
                "No ETABS-linked sections found.\nImport from ETABS first to create a section binding.",
                "Refresh Forces from ETABS");
            return;
        }

        var result = etabsForceRefreshDialogService.ShowDialog(
            System.Windows.Application.Current?.MainWindow,
            bindings,
            existingLoadCases,
            Input.UnitSystem);

        if (result is null || !result.Success || result.UpdatedLoadCasesBySection.Count == 0)
            return;

        var columnByName = allColumns.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);

        int updated = 0;
        foreach (var kvp in result.UpdatedLoadCasesBySection)
        {
            if (!columnByName.TryGetValue(kvp.Key, out var colRecord)) continue;

            var snapshot = projectService.LoadColumnInput(colRecord.Id);
            if (snapshot is null) continue;

            snapshot.LoadCases = kvp.Value.ToList();
            snapshot.LastEtabsRefreshAt = DateTime.UtcNow;
            snapshot.LastEtabsRefreshSummary = result.Message;

            projectService.SaveColumnInput(colRecord.Id, snapshot);
            projectSession.ClearColumnResult(colRecord.Id);
            Explorer.SetSectionStatus(colRecord.Id, SectionStatus.NotCalculated);
            updated++;
        }

        RaiseStatusProperties();

        if (updated > 0)
            messageService.ShowInformation(result.Message, "Forces Refreshed");
    }

    private async Task SaveProjectAsync()
    {
        if (!ValidateColumnNamesBeforeSave())
            return;

        if (projectService.CurrentFilePath is null)
        {
            await SaveProjectAsAsync();
            return;
        }

        try
        {
            IsSaving = true;
            SaveCurrentColumnInput();
            await Task.Yield();
            projectService.SaveProject();
            IsSaving = false;
            await ShowSaveNotificationAsync("Project saved successfully!");
        }
        catch (Exception ex)
        {
            IsSaving = false;
            messageService.ShowError($"Failed to save project:\n{ex.Message}");
        }
    }

    private async Task SaveProjectAsAsync()
    {
        if (!ValidateColumnNamesBeforeSave())
            return;

        var filePath = projectFileDialogService.ShowSaveProjectAsDialog(projectService.ProjectName);
        if (filePath is null) return;

        try
        {
            IsSaving = true;
            SaveCurrentColumnInput();
            await Task.Yield();
            projectService.SaveProjectAs(filePath);
            IsSaving = false;
            await ShowSaveNotificationAsync("Project saved successfully!");
        }
        catch (Exception ex)
        {
            IsSaving = false;
            messageService.ShowError($"Failed to save project:\n{ex.Message}");
        }
    }

    private async Task ShowSaveNotificationAsync(string message)
    {
        // Cancel any previous notification timer
        saveNotificationCts?.Cancel();
        var cts = new CancellationTokenSource();
        saveNotificationCts = cts;

        SaveNotificationText = message;
        IsSaveNotificationVisible = true;

        try
        {
            await Task.Delay(TimeSpan.FromSeconds(1), cts.Token);
            IsSaveNotificationVisible = false;
        }
        catch (TaskCanceledException)
        {
            // A new notification replaced this one
        }
    }

    private void OnColumnSelected(ColumnItemViewModel? column)
    {
        // Save current column before switching
        if (currentColumn is not null && currentColumn != column)
            SaveCurrentColumnInput();

        currentColumn = column;
        projectSession.SelectColumn(column?.Id);
        RaiseStatusProperties();
        RaiseCommandStates();

        if (column is not null)
        {
            suppressModified = true;
            try
            {
                var snapshot = projectService.LoadColumnInput(column.Id);
                if (snapshot != null)
                {
                    Input.LoadFromSnapshot(snapshot);
                }
                else
                {
                    Input.ResetToDefaults();
                }

                ApplyCurrentColumnResult();
            }
            finally
            {
                suppressModified = false;
            }
        }
        else
        {
            ApplyCurrentColumnResult();
        }

        RaiseResultStateProperties();
        RefreshReportFromCurrentWorkspace();
    }

    private void SaveCurrentColumnInput()
    {
        if (currentColumn is null) return;
        projectService.SaveColumnInput(currentColumn.Id, Input.ToSnapshot());
    }

    private void UpdateWindowTitle()
    {
        var modified = projectService.IsModified ? " *" : "";
        var file = projectService.CurrentFilePath is not null
            ? $" — {System.IO.Path.GetFileName(projectService.CurrentFilePath)}"
            : "";
        WindowTitle = $"MBColumn{file}{modified}";
    }

    private bool ConfirmDiscardChanges()
    {
        if (!projectService.IsModified) return true;
        return messageService.ConfirmWarning(
            "The current project has unsaved changes. Discard and continue?",
            "Unsaved Changes");
    }

    private bool ValidateColumnNamesBeforeSave()
    {
        var duplicates = projectService.GetColumns()
            .GroupBy(c => c.Name.Trim(), StringComparer.OrdinalIgnoreCase)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (!duplicates.Any())
            return true;

        var duplicateList = string.Join(", ", duplicates.Select(name => $"'{name}'"));
        messageService.ShowWarning(
            $"Cannot save project because duplicate section names exist: {duplicateList}. Each section name must be unique.",
            "Duplicate Section Names");

        return false;
    }

    private void SubscribeToInputChanges()
    {
        Input.PropertyChanged += OnInputChanged;
        Input.LoadCases.CollectionChanged += OnLoadCasesChanged;
        foreach (var loadCase in Input.LoadCases)
            loadCase.PropertyChanged += OnInputChanged;

        Input.RebarLayout.Top.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Bottom.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Left.PropertyChanged += OnInputChanged;
        Input.RebarLayout.Right.PropertyChanged += OnInputChanged;
    }

    private void OnLoadCasesChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is not null)
            foreach (LoadCaseViewModel lc in e.OldItems)
                lc.PropertyChanged -= OnInputChanged;

        if (e.NewItems is not null)
            foreach (LoadCaseViewModel lc in e.NewItems)
                lc.PropertyChanged += OnInputChanged;

        MarkCalculationOutdated();
        MarkProjectModified();
    }

    private static readonly HashSet<string> s_displayOnlyProperties = new(StringComparer.Ordinal)
    {
        // InputViewModel — derived display labels, not user input
        "PreviewAreaText", "PreviewAsTotalText", "PreviewIxxText", "PreviewIyyText",
        "PreviewIxText", "PreviewIyText", "PreviewFcdText", "PreviewFydText",
        "PreviewEcmText", "PreviewDxText", "PreviewDyText", "PreviewOmegaText",
        "PreviewNRatioText", "PreviewRebarPercentageText",
        "PreviewShapeSummaryText", "PreviewRebarLayoutText",
        "FcdDisplayText", "FcmDisplayText", "EcmDisplayText",
        "SlendernessWarningText", "HasSlendernessWarnings",
        "L0xText", "L0yText", "L0xLatex", "L0yLatex", "MemberLengthLInM", "AFactorDisplayText",
        "ImperfectionCalculationText", "MinimumEccentricityCalculationText",
        "ImperfectionXCalculationLatex", "ImperfectionYCalculationLatex",
        "MinimumEccentricityXCalculationLatex", "MinimumEccentricityYCalculationLatex",
        "DemandInputModeText", "SlendernessSettingsVisibility",
        "IsSlendernessCalculationDetailsOpen", "SlendernessCalculationLoadCase",
        "SectionPreviewLabel", "RebarPreviewLabel", "CoverPreviewLabel", "IsSectionPreviewValid",
        // Section geometry alias/derived properties — underlying properties (Width, Height, etc.) still trigger correctly
        "SectionWidth", "SectionHeight", "NumberOfBars", "SelectedRebarSize", "SelectedRebarLayout",
        "CircularHoopCentrelineDiameter", "CircularHoopCentrelineDiameterText",
        "LinkSpacing",
        // LoadCaseViewModel — computed slenderness results, not user input
        "Status", "HasValidationError", "SlendernessStatusText", "CalculationStatusText",
        "LambdaX", "LambdaLimitX", "LambdaY", "LambdaLimitY",
        "RmX", "RmY", "M01x", "M02x", "M0ex", "M2x", "M01y", "M02y", "M0ey", "M2y",
        "MxUsed", "MyUsed", "SlendernessStatus",
        "FactorN", "FactorA", "FactorB", "FactorCx", "FactorCy",
        "NominalCurvatureX", "E2X", "NominalCurvatureY", "E2Y",
        "Ec2BranchXText", "Ec2BranchYText",
        // LaTeX display properties derived from slenderness results
        "LambdaXResultLatex", "LambdaYResultLatex", "LambdaLimitXResultLatex", "LambdaLimitYResultLatex",
        "MomentRatioXResultLatex", "MomentRatioYResultLatex",
        "NominalCurvatureXResultLatex", "NominalCurvatureYResultLatex",
        "NominalCurvatureXM0eLatex", "NominalCurvatureYM0eLatex",
        "NominalCurvatureXM2Latex", "NominalCurvatureYM2Latex",
        "NominalCurvatureX1rLatex", "NominalCurvatureY1rLatex",
        "NominalCurvatureXE2Latex", "NominalCurvatureYE2Latex",
        "FactorNLatex", "FactorALatex", "FactorBLatex", "FactorCxLatex", "FactorCyLatex",
        "MxUsedResultLatex", "MyUsedResultLatex",
        "IsAnyAxisSlender", "IsNeitherAxisSlender",
        "LambdaXDisplay", "LambdaLimitXDisplay", "LambdaYDisplay", "LambdaLimitYDisplay",
        "AngleDisplay", "UtilizationDisplay", "StatusDisplay", "IsCritical", "IsFailing",
    };

    private void OnInputChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is not null && s_displayOnlyProperties.Contains(e.PropertyName)) return;
        MarkCalculationOutdated();
        MarkProjectModified();
    }

    private void MarkCalculationOutdated()
    {
        if (suppressModified) return;

        if (currentColumn is null)
        {
            if (!Result.HasResult) return;
            IsCalculationOutdated = true;
            Report.MarkOutdated();
            return;
        }

        if (!projectSession.CurrentColumnHasResult()) return;
        projectSession.MarkCurrentColumnOutdated();
        Explorer.SetSectionStatus(currentColumn.Id, SectionStatus.Outdated);
        IsCalculationOutdated = true;
        Report.MarkOutdated();
    }

    private void MarkProjectModified()
    {
        if (!suppressModified && currentColumn is not null)
            projectService.MarkModified();
    }

    private void RaiseCommandStates()
    {
        if (PrintSingleReportCommand is AsyncRelayCommand printSingle)
            printSingle.RaiseCanExecuteChanged();
        (BatchPrintCommand as RelayCommand)?.RaiseCanExecuteChanged();
        if (CalculateCommand is AsyncRelayCommand calculate)
            calculate.RaiseCanExecuteChanged();
        if (CalculateAllColumnsCommand is AsyncRelayCommand calculateAll)
            calculateAll.RaiseCanExecuteChanged();
        if (CalculateSelectedColumnsCommand is AsyncRelayCommand calculateSelected)
            calculateSelected.RaiseCanExecuteChanged();
        if (ImportElementForcesCommand is AsyncRelayCommand importElem)
            importElem.RaiseCanExecuteChanged();
        if (ImportDesignForcesCommand is AsyncRelayCommand importDes)
            importDes.RaiseCanExecuteChanged();
        if (RefreshElementForcesCommand is AsyncRelayCommand refreshElem)
            refreshElem.RaiseCanExecuteChanged();
        if (RefreshDesignForcesCommand is AsyncRelayCommand refreshDes)
            refreshDes.RaiseCanExecuteChanged();
    }

    private void RaiseStatusProperties()
    {
        Raise(nameof(HasCurrentSection));
        Raise(nameof(HasSections));
        Raise(nameof(IsProjectModified));
        Raise(nameof(IsCurrentResultOutdated));
        Raise(nameof(AppStatusText));
        Raise(nameof(ProjectStatusText));
        Raise(nameof(CurrentSectionStatusText));
        Raise(nameof(ModifiedStatusText));
        Raise(nameof(ResultFreshnessStatusText));
        RaiseResultStateProperties();
    }

    private void RaiseResultStateProperties()
    {
        Raise(nameof(IsResultsTabAvailable));
        Raise(nameof(HasCurrentResult));
        Raise(nameof(ShowInputEmptyState));
        Raise(nameof(ShowResultContent));
        Raise(nameof(ShowNoSectionResultEmptyState));
        Raise(nameof(ShowNoResultEmptyState));
        Raise(nameof(ShowOutdatedResultEmptyState));
    }

    private void ApplyCurrentColumnResult()
    {
        if (projectSession.TryGetCurrentColumnResult(out var cachedResult))
        {
            Result.Result = cachedResult;
            IsCalculationOutdated = projectSession.IsCurrentColumnOutdated();
            if (Explorer is not null && currentColumn is not null)
            {
                Explorer.SetSectionStatus(
                    currentColumn.Id,
                    IsCalculationOutdated ? SectionStatus.Outdated : SectionStatus.Calculated);
            }
        }
        else if (currentColumn is not null)
        {
            // Try restoring persisted result from the last saved calculation
            var persisted = projectService.LoadColumnResult(currentColumn.Id);
            if (persisted is not null)
            {
                projectSession.StoreColumnResult(currentColumn.Id, persisted);
                Result.Result = persisted;
                IsCalculationOutdated = false;
                if (Explorer is not null)
                    Explorer.SetSectionStatus(currentColumn.Id, SectionStatus.Calculated);
            }
            else
            {
                Result.Result = null;
                IsCalculationOutdated = false;
                if (Explorer is not null)
                    Explorer.SetSectionStatus(currentColumn.Id, SectionStatus.NotCalculated);
                if (SelectedMainTabIndex == 1)
                    SelectedMainTabIndex = 0;
            }
        }
        else
        {
            Result.Result = null;
            IsCalculationOutdated = false;
            if (SelectedMainTabIndex == 1)
                SelectedMainTabIndex = 0;
        }

        RaiseResultStateProperties();
        RaiseStatusProperties();
    }

    private void ClearResults()
    {
        projectSession.ClearResults();
        Result.Result = null;
        RaiseResultStateProperties();
    }

    private void RefreshReportFromCurrentWorkspace()
    {
        if (currentColumn is null)
        {
            Report.Clear();
            return;
        }

        Report.LoadFromCurrentWorkspace(
            Input,
            Result,
            projectService.ProjectName,
            CurrentGroupName(),
            currentColumn.Name,
            IsCalculationOutdated);
    }

    private string CurrentGroupName()
    {
        if (currentColumn?.GroupId is not int groupId)
            return "";

        return projectService.GetGroups().FirstOrDefault(group => group.Id == groupId)?.Name ?? "";
    }
}
