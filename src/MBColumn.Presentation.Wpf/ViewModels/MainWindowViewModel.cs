using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ColumnCalculationService calculationService;
    private readonly IProjectService projectService;
    private string validationMessage = "";
    private bool isCalculationOutdated;
    private bool hasSuccessfulCalculation;
    private ColumnItemViewModel? currentColumn;
    private string windowTitle = "MBColumn";
    private bool suppressModified;

    public MainWindowViewModel(
        ColumnCalculationService calculationService,
        IProjectService projectService,
        InputViewModel input)
    {
        this.calculationService = calculationService;
        this.projectService = projectService;
        Input = input;
        Result = new ResultViewModel();

        Explorer = new ProjectExplorerViewModel(projectService, OnColumnSelected, PromptColumnName);

        CalculateCommand = new RelayCommand(Calculate);
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
    public ICommand NewProjectCommand { get; }
    public ICommand OpenProjectCommand { get; }
    public ICommand SaveProjectCommand { get; }
    public ICommand SaveProjectAsCommand { get; }

    public string ValidationMessage { get => validationMessage; set => Set(ref validationMessage, value); }
    public string WindowTitle { get => windowTitle; private set => Set(ref windowTitle, value); }

    public bool IsCalculationOutdated
    {
        get => isCalculationOutdated;
        private set
        {
            Set(ref isCalculationOutdated, value);
            Raise(nameof(IsResultsTabAvailable));
        }
    }

    public bool IsResultsTabAvailable => Result.HasResult && !IsCalculationOutdated;

    private void Calculate()
    {
        try
        {
            ValidationMessage = "";
            Result.Result = calculationService.Calculate(Input.ToDto());
            hasSuccessfulCalculation = true;
            IsCalculationOutdated = false;
            Raise(nameof(IsResultsTabAvailable));

            // Auto-save column input after successful calculation
            if (currentColumn is not null)
                SaveCurrentColumnInput();
        }
        catch (Exception ex)
        {
            ValidationMessage = ex.Message;
            MessageBox.Show(ex.Message, "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void NewProject()
    {
        if (!ConfirmDiscardChanges()) return;

        var name = PromptProjectName("New Project");
        if (name is null) return;

        // Save + detach before firing any project events
        SaveCurrentColumnInput();
        currentColumn = null;

        projectService.NewProject(name);
        hasSuccessfulCalculation = false;
        isCalculationOutdated = false;
        Raise(nameof(IsResultsTabAvailable));
    }

    private void OpenProject()
    {
        if (!ConfirmDiscardChanges()) return;

        var dlg = new Microsoft.Win32.OpenFileDialog
        {
            Title = "Open MBColumn Project",
            Filter = "MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*",
            DefaultExt = ".msd"
        };

        if (dlg.ShowDialog() != true) return;

        try
        {
            // Save + detach before firing any project events
            SaveCurrentColumnInput();
            currentColumn = null;

            projectService.OpenProject(dlg.FileName);
            hasSuccessfulCalculation = false;
            isCalculationOutdated = false;
            Raise(nameof(IsResultsTabAvailable));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to open project:\n{ex.Message}", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
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
            MessageBox.Show($"Failed to save project:\n{ex.Message}", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void SaveProjectAs()
    {
        if (!ValidateColumnNamesBeforeSave())
            return;

        var dlg = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Save MBColumn Project As",
            Filter = "MBColumn Project (*.msd)|*.msd|All Files (*.*)|*.*",
            DefaultExt = ".msd",
            FileName = projectService.ProjectName
        };

        if (dlg.ShowDialog() != true) return;

        try
        {
            SaveCurrentColumnInput();
            projectService.SaveProjectAs(dlg.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to save project:\n{ex.Message}", "Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void OnColumnSelected(ColumnItemViewModel? column)
    {
        // Save current column before switching
        if (currentColumn is not null && currentColumn != column)
            SaveCurrentColumnInput();

        currentColumn = column;

        if (column is not null)
        {
            suppressModified = true;
            try
            {
                var snapshot = projectService.LoadColumnInput(column.Id);
                if (snapshot is not null)
                    Input.LoadFromSnapshot(snapshot);
            }
            finally
            {
                suppressModified = false;
            }
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
        var result = MessageBox.Show(
            "The current project has unsaved changes. Discard and continue?",
            "Unsaved Changes",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);
        return result == MessageBoxResult.Yes;
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
        MessageBox.Show(
            $"Cannot save project because duplicate column names exist: {duplicateList}. Each column name must be unique.",
            "Duplicate Column Names",
            MessageBoxButton.OK,
            MessageBoxImage.Warning);

        return false;
    }

    private static string? PromptProjectName(string defaultName)
        => Prompt(defaultName, "New Project");

    private static string? PromptColumnName(string defaultName)
        => Prompt(defaultName, "New Column");

    private static string? Prompt(string defaultName, string title)
    {
        var dialog = new Views.ProjectNameDialog(defaultName, title);
        return dialog.ShowDialog() == true ? dialog.ProjectName : null;
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
        if (!hasSuccessfulCalculation) return;
        IsCalculationOutdated = true;
    }

    private void MarkProjectModified()
    {
        if (!suppressModified && currentColumn is not null)
            projectService.MarkModified();
    }
}
