using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ProjectExplorerViewModel : ViewModelBase
{
    private readonly IProjectService projectService;
    private readonly Action<ColumnItemViewModel?> onColumnSelected;
    private readonly Func<string, string?> promptColumnName;
    private readonly IMessageService messageService;
    private string projectName = "New Project";
    private bool isRenamingProject;
    private string editProjectName = "New Project";
    private ColumnItemViewModel? selectedColumn;

    public ProjectExplorerViewModel(
        IProjectService projectService,
        Action<ColumnItemViewModel?> onColumnSelected,
        Func<string, string?> promptColumnName,
        IMessageService messageService)
    {
        this.projectService = projectService;
        this.onColumnSelected = onColumnSelected;
        this.promptColumnName = promptColumnName;
        this.messageService = messageService;

        Columns = new ObservableCollection<ColumnItemViewModel>();

        AddColumnCommand = new RelayCommand(AddColumn);
        BeginRenameProjectCommand = new RelayCommand(() =>
        {
            EditProjectName = ProjectName;
            IsRenamingProject = true;
        });

        projectService.ProjectChanged += (_, _) =>
        {
            UpdateProjectName();
        };

        projectService.ColumnsChanged += (_, _) => RefreshColumns();

        RefreshColumns();
    }

    public string ProjectName
    {
        get => projectName;
        private set => Set(ref projectName, value);
    }

    public bool IsRenamingProject
    {
        get => isRenamingProject;
        set => Set(ref isRenamingProject, value);
    }

    public string EditProjectName
    {
        get => editProjectName;
        set => Set(ref editProjectName, value);
    }

    public ObservableCollection<ColumnItemViewModel> Columns { get; }

    public ColumnItemViewModel? SelectedColumn
    {
        get => selectedColumn;
        private set => Set(ref selectedColumn, value);
    }

    public ICommand AddColumnCommand { get; }
    public ICommand BeginRenameProjectCommand { get; }

    public void SelectColumn(ColumnItemViewModel item)
    {
        if (selectedColumn is not null)
            selectedColumn.IsSelected = false;

        selectedColumn = item;
        item.IsSelected = true;
        Raise(nameof(SelectedColumn));
        onColumnSelected(item);
    }

    public void CommitRenameProject()
    {
        var newName = EditProjectName.Trim();
        if (string.IsNullOrWhiteSpace(newName)) newName = ProjectName;
        projectService.RenameProject(newName);
        IsRenamingProject = false;
    }

    public void CancelRenameProject()
    {
        IsRenamingProject = false;
    }

    public void CommitRename(ColumnItemViewModel item)
    {
        var newName = item.EditName.Trim();
        if (string.IsNullOrWhiteSpace(newName)) newName = item.Name;

        try
        {
            projectService.RenameColumn(item.Id, newName);
            item.Name = newName;
            item.IsRenaming = false;
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ex.Message, "Duplicate Column Name");
            item.IsRenaming = true;
        }
    }

    public void CancelRename(ColumnItemViewModel item)
    {
        item.IsRenaming = false;
    }

    private void AddColumn()
    {
        var defaultName = $"Column {Columns.Count + 1}";
        var name = promptColumnName(defaultName);
        if (name is null) return;

        try
        {
            var record = projectService.AddColumn(name);

            // The ProjectService raises ColumnsChanged when a column is added
            // which triggers RefreshColumns. To avoid adding the item twice
            // we refresh the list and then select the newly created column.
            RefreshColumns();
            var item = Columns.FirstOrDefault(c => c.Id == record.Id);
            if (item is not null) SelectColumn(item);
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ex.Message, "Duplicate Column Name");
        }
    }

    private void DeleteColumn(ColumnItemViewModel item)
    {
        projectService.DeleteColumn(item.Id);
        Columns.Remove(item);
        if (selectedColumn == item)
        {
            var next = Columns.FirstOrDefault();
            if (next is not null) SelectColumn(next);
            else
            {
                selectedColumn = null;
                Raise(nameof(SelectedColumn));
                onColumnSelected(null);
            }
        }
    }

    private void RefreshColumns()
    {
        var previousId = selectedColumn?.Id;
        Columns.Clear();

        foreach (var record in projectService.GetColumns())
        {
            Columns.Add(CreateItem(record));
        }

        UpdateProjectName();

        var toReselect = previousId.HasValue
            ? Columns.FirstOrDefault(c => c.Id == previousId.Value)
            : null;

        if (toReselect is not null)
        {
            SelectColumn(toReselect);
        }
        else if (Columns.Count > 0)
        {
            SelectColumn(Columns[0]);
        }
        else
        {
            selectedColumn = null;
            Raise(nameof(SelectedColumn));
            onColumnSelected(null);
        }
    }

    private ColumnItemViewModel CreateItem(ColumnRecord record)
        => new(record, SelectColumn, DeleteColumn);

    private void UpdateProjectName()
    {
        ProjectName = projectService.CurrentFilePath is null
            ? projectService.ProjectName
            : Path.GetFileName(projectService.CurrentFilePath);
    }
}
