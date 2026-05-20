using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ColumnCalculationService calculationService;
    private readonly IProjectService projectService;
    private readonly IMessageService messageService;
    private readonly IProjectFileDialogService projectFileDialogService;
    private readonly IProjectNameDialogService projectNameDialogService;
    private readonly ProjectSession projectSession;
    private string validationMessage = "";
    private bool isCalculationOutdated;
    private ColumnItemViewModel? currentColumn;
    private string windowTitle = "MBColumn";
    private bool isCalculating;
    private string calculationStatus = "";
    private int selectedMainTabIndex;
    private bool suppressModified;

    public MainWindowViewModel(
        ColumnCalculationService calculationService,
        IProjectService projectService,
        InputViewModel input,
        IMessageService messageService,
        IProjectFileDialogService projectFileDialogService,
        IProjectNameDialogService projectNameDialogService,
        ProjectSession projectSession)
    {
        this.calculationService = calculationService;
        this.projectService = projectService;
        this.messageService = messageService;
        this.projectFileDialogService = projectFileDialogService;
        this.projectNameDialogService = projectNameDialogService;
        this.projectSession = projectSession;
        Input = input;
        Result = new ResultViewModel();

        Explorer = new ProjectExplorerViewModel(projectService, OnColumnSelected, projectNameDialogService.PromptColumnName, messageService);

        CalculateCommand = new AsyncRelayCommand(CalculateCurrentColumnAsync, () => !IsCalculating);
        CalculateCurrentColumnCommand = CalculateCommand;
        CalculateAllColumnsCommand = new AsyncRelayCommand(CalculateAllColumnsAsync, () => !IsCalculating);
        NewProjectCommand = new RelayCommand(NewProject);
        OpenProjectCommand = new RelayCommand(OpenProject);
        SaveProjectCommand = new RelayCommand(SaveProject);
        SaveProjectAsCommand = new RelayCommand(SaveProjectAs);

        SubscribeToInputChanges();
        UpdateWindowTitle();

        projectService.ProjectChanged += (_, _) => UpdateWindowTitle();
    }

    public InputViewModel Input { get; }
    public ResultViewModel Result { get; }
    public ProjectExplorerViewModel Explorer { get; }

    public ICommand CalculateCommand { get; }
    public ICommand CalculateCurrentColumnCommand { get; }
    public ICommand CalculateAllColumnsCommand { get; }
    public ICommand NewProjectCommand { get; }
    public ICommand OpenProjectCommand { get; }
    public ICommand SaveProjectCommand { get; }
    public ICommand SaveProjectAsCommand { get; }

    public string ValidationMessage { get => validationMessage; set => Set(ref validationMessage, value); }
    public string WindowTitle { get => windowTitle; private set => Set(ref windowTitle, value); }
    public string CalculationStatus { get => calculationStatus; private set => Set(ref calculationStatus, value); }
    public int SelectedMainTabIndex { get => selectedMainTabIndex; set => Set(ref selectedMainTabIndex, value); }

    public bool IsCalculating
    {
        get => isCalculating;
        private set
        {
            if (isCalculating == value) return;
            isCalculating = value;
            Raise();
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
        }
    }

    public bool IsResultsTabAvailable => Result.HasResult;

    private async Task CalculateCurrentColumnAsync()
        => await RunWithProgressAsync("Calculating this column...", CalculateCurrentColumn);

    private async Task CalculateAllColumnsAsync()
        => await RunWithProgressAsync("Calculating all columns...", CalculateAllColumns);

    private async Task RunWithProgressAsync(string status, Action calculate)
    {
        IsCalculating = true;
        CalculationStatus = status;
        var elapsed = Stopwatch.StartNew();

        try
        {
            await Task.Yield();
            calculate();
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

    private void CalculateCurrentColumn()
    {
        try
        {
            ValidationMessage = "";
            var result = calculationService.Calculate(Input.ToDto());
            projectSession.StoreCurrentColumnResult(result);
            Result.Result = result;
            IsCalculationOutdated = false;
            SelectedMainTabIndex = 1;
            Raise(nameof(IsResultsTabAvailable));

            // Auto-save column input after successful calculation
            if (currentColumn is not null)
                SaveCurrentColumnInput();
        }
        catch (Exception ex)
        {
            ValidationMessage = ex.Message;
            messageService.ShowWarning(ex.Message, "Validation");
        }
    }

    private void CalculateAllColumns()
    {
        var columns = projectService.GetColumns();
        if (columns.Count == 0)
        {
            CalculateCurrentColumn();
            return;
        }

        SaveCurrentColumnInput();

        var selectedId = currentColumn?.Id;
        var failedColumns = new List<string>();

        suppressModified = true;
        try
        {
            foreach (var column in columns)
            {
                var snapshot = projectService.LoadColumnInput(column.Id);
                if (snapshot is null)
                    continue;

                try
                {
                    Input.LoadFromSnapshot(snapshot);
                    var result = calculationService.Calculate(Input.ToDto());
                    projectSession.StoreColumnResult(column.Id, result);
                }
                catch (Exception ex)
                {
                    failedColumns.Add($"{column.Name}: {ex.Message}");
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
                $"Some columns could not be calculated:\n\n{ValidationMessage}",
                "Validation");
            return;
        }

        ValidationMessage = "";
        ApplyCurrentColumnResult();
        SelectedMainTabIndex = 1;
        Raise(nameof(IsResultsTabAvailable));
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
        isCalculationOutdated = false;
        SelectedMainTabIndex = 0;
        Raise(nameof(IsResultsTabAvailable));
    }

    private void OpenProject()
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

            projectService.OpenProject(filePath);
            ClearResults();
            isCalculationOutdated = false;
            SelectedMainTabIndex = 0;
            Raise(nameof(IsResultsTabAvailable));
        }
        catch (Exception ex)
        {
            messageService.ShowError($"Failed to open project:\n{ex.Message}");
        }
    }

    private void SaveProject()
    {
        if (!ValidateColumnNamesBeforeSave())
            return;

        if (projectService.CurrentFilePath is null)
        {
            SaveProjectAs();
            return;
        }

        try
        {
            SaveCurrentColumnInput();
            projectService.SaveProject();
        }
        catch (Exception ex)
        {
            messageService.ShowError($"Failed to save project:\n{ex.Message}");
        }
    }

    private void SaveProjectAs()
    {
        if (!ValidateColumnNamesBeforeSave())
            return;

        var filePath = projectFileDialogService.ShowSaveProjectAsDialog(projectService.ProjectName);
        if (filePath is null) return;

        try
        {
            SaveCurrentColumnInput();
            projectService.SaveProjectAs(filePath);
        }
        catch (Exception ex)
        {
            messageService.ShowError($"Failed to save project:\n{ex.Message}");
        }
    }

    private void OnColumnSelected(ColumnItemViewModel? column)
    {
        // Save current column before switching
        if (currentColumn is not null && currentColumn != column)
            SaveCurrentColumnInput();

        currentColumn = column;
        projectSession.SelectColumn(column?.Id);

        if (column is not null)
        {
            suppressModified = true;
            try
            {
                var snapshot = projectService.LoadColumnInput(column.Id);
                if (snapshot is not null)
                    Input.LoadFromSnapshot(snapshot);

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
            $"Cannot save project because duplicate column names exist: {duplicateList}. Each column name must be unique.",
            "Duplicate Column Names");

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

    private void OnInputChanged(object? sender, PropertyChangedEventArgs e)
    {
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
            return;
        }

        if (!projectSession.CurrentColumnHasResult()) return;
        projectSession.MarkCurrentColumnOutdated();
        IsCalculationOutdated = true;
    }

    private void MarkProjectModified()
    {
        if (!suppressModified && currentColumn is not null)
            projectService.MarkModified();
    }

    private void RaiseCommandStates()
    {
        if (CalculateCommand is AsyncRelayCommand calculate)
            calculate.RaiseCanExecuteChanged();
        if (CalculateAllColumnsCommand is AsyncRelayCommand calculateAll)
            calculateAll.RaiseCanExecuteChanged();
    }

    private void ApplyCurrentColumnResult()
    {
        if (projectSession.TryGetCurrentColumnResult(out var cachedResult))
        {
            Result.Result = cachedResult;
            IsCalculationOutdated = projectSession.IsCurrentColumnOutdated();
        }
        else
        {
            Result.Result = null;
            IsCalculationOutdated = false;
            if (SelectedMainTabIndex == 1)
                SelectedMainTabIndex = 0;
        }

        Raise(nameof(IsResultsTabAvailable));
    }

    private void ClearResults()
    {
        projectSession.ClearResults();
        Result.Result = null;
    }
}
