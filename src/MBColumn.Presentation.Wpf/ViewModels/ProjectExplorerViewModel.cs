using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using MBColumn.Presentation.Wpf.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ProjectExplorerViewModel : ViewModelBase
{
    private readonly IProjectService projectService;
    private readonly Action<ColumnItemViewModel?> onColumnSelected;
    private readonly Action saveCurrentColumnInput;
    private readonly IProjectNameDialogService projectNameDialogService;
    private readonly Func<IEnumerable<ColumnRecord>, IEnumerable<int>?> promptSelectSections;
    private readonly IMessageService messageService;
    private readonly Dictionary<int, SectionStatus> sectionStatuses = [];
    private readonly Dictionary<int, bool> columnCheckedStates = [];
    public event Action? SelectedColumnsChanged;
    private string projectName = "New Project";
    private ExplorerNodeViewModel? selectedNode;
    private ColumnItemViewModel? selectedColumn;

    public ProjectExplorerViewModel(
        IProjectService projectService,
        Action<ColumnItemViewModel?> onColumnSelected,
        Action saveCurrentColumnInput,
        IProjectNameDialogService projectNameDialogService,
        Func<IEnumerable<ColumnRecord>, IEnumerable<int>?> promptSelectSections,
        IMessageService messageService)
    {
        this.projectService = projectService;
        this.onColumnSelected = onColumnSelected;
        this.saveCurrentColumnInput = saveCurrentColumnInput;
        this.projectNameDialogService = projectNameDialogService;
        this.promptSelectSections = promptSelectSections;
        this.messageService = messageService;

        Nodes = new BulkObservableCollection<ExplorerNodeViewModel>();

        AddGroupCommand = new RelayCommand(AddGroup);
        AddColumnCommand = new RelayCommand(() => AddColumn(null));

        projectService.ProjectChanged += (_, _) =>
        {
            System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
            {
                UpdateProjectName();
            });
        };

        projectService.ColumnsChanged += (_, _) =>
        {
            System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
            {
                RefreshColumns();
            });
        };

        RefreshColumns();
    }

    public string ProjectName
    {
        get => projectName;
        private set => Set(ref projectName, value);
    }

    public BulkObservableCollection<ExplorerNodeViewModel> Nodes { get; }

    public ExplorerNodeViewModel? SelectedNode
    {
        get => selectedNode;
        private set => Set(ref selectedNode, value);
    }

    public ColumnItemViewModel? SelectedColumn
    {
        get => selectedColumn;
        private set => Set(ref selectedColumn, value);
    }

    public ICommand AddGroupCommand { get; }
    public ICommand AddColumnCommand { get; }

    public void SetSectionStatus(int sectionId, SectionStatus status)
    {
        sectionStatuses[sectionId] = status;
        var section = FindColumn(sectionId);
        if (section is not null)
            section.Status = status;
    }

    public void ClearSectionStatuses()
    {
        sectionStatuses.Clear();
        foreach (var node in Nodes)
        {
            if (node is ColumnItemViewModel section)
                section.Status = SectionStatus.NotCalculated;
            else if (node is GroupItemViewModel group)
            {
                foreach (var child in group.Columns)
                    child.Status = SectionStatus.NotCalculated;
            }
        }
    }

    public void SelectNode(ExplorerNodeViewModel? item)
    {
        if (selectedNode == item) return;

        if (selectedNode is not null)
            selectedNode.IsSelected = false;

        selectedNode = item;
        if (item is not null)
            item.IsSelected = true;
            
        Raise(nameof(SelectedNode));
        
        var column = item as ColumnItemViewModel;
        SelectedColumn = column;
        onColumnSelected(column);
    }

    public void SelectColumnById(int columnId)
    {
        var item = FindColumn(columnId);
        if (item is not null)
            SelectNode(item);
    }

    private ColumnItemViewModel? FindColumn(int id)
    {
        foreach (var node in Nodes)
        {
            if (node is ColumnItemViewModel c && c.Id == id) return c;
            if (node is GroupItemViewModel g)
            {
                var found = g.Columns.FirstOrDefault(x => x.Id == id);
                if (found is not null) return found;
            }
        }
        return null;
    }

    private GroupItemViewModel? FindGroup(int id)
    {
        return Nodes.OfType<GroupItemViewModel>().FirstOrDefault(g => g.Id == id);
    }

    public void CommitRename(ExplorerNodeViewModel item)
    {
        var newName = item.EditName.Trim();
        if (string.IsNullOrWhiteSpace(newName)) newName = item.Name;

        try
        {
            if (item is ColumnItemViewModel)
            {
                projectService.RenameColumn(item.Id, newName);
            }
            else if (item is GroupItemViewModel)
            {
                projectService.RenameGroup(item.Id, newName);
            }
            
            item.Name = newName;
            item.IsRenaming = false;
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ToSectionWording(ex.Message), "Duplicate Name");
            item.IsRenaming = true;
        }
    }

    public void CancelRename(ExplorerNodeViewModel item)
    {
        item.IsRenaming = false;
    }

    private void AddGroup()
    {
        var defaultName = $"Group {Nodes.OfType<GroupItemViewModel>().Count() + 1}";
        var name = projectNameDialogService.PromptColumnName(defaultName);
        if (name is null) return;

        try
        {
            var record = projectService.AddGroup(name);
            RefreshColumns();
            var item = FindGroup(record.Id);
            if (item is not null) SelectNode(item);
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ToSectionWording(ex.Message), "Duplicate Group Name");
        }
    }

    private void AddColumn(GroupItemViewModel? group)
    {
        var totalColumns = Nodes.OfType<ColumnItemViewModel>().Count() + Nodes.OfType<GroupItemViewModel>().SelectMany(g => g.Columns).Count();
        var defaultName = $"Section {totalColumns + 1}";
        
        var availableGroups = projectService.GetGroups();
        var result = projectNameDialogService.PromptAddSection(defaultName, availableGroups, group?.Id);
        if (result is null) return;

        try
        {
            var record = projectService.AddColumn(result.Value.Name, result.Value.GroupId);
            RefreshColumns();
            var item = FindColumn(record.Id);
            if (item is not null) SelectNode(item);
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ToSectionWording(ex.Message), "Duplicate Section Name");
        }
    }

    private void DuplicateColumn(ColumnItemViewModel item)
    {
        saveCurrentColumnInput();
        var name = NextDuplicateName(item.Name);

        try
        {
            var record = projectService.DuplicateColumn(item.Id, name, item.GroupId);
            RefreshColumns();
            var duplicated = FindColumn(record.Id);
            if (duplicated is not null) SelectNode(duplicated);
        }
        catch (InvalidOperationException ex)
        {
            messageService.ShowWarning(ToSectionWording(ex.Message), "Duplicate Section Name");
        }
    }

    private void MoveColumn(int columnId, int? groupId)
    {
        try
        {
            projectService.MoveColumn(columnId, groupId);
            // RefreshColumns is automatically called via ColumnsChanged
        }
        catch (Exception ex)
        {
            messageService.ShowWarning(ToSectionWording(ex.Message), "Move Section Error");
        }
    }

    private void DeleteColumn(ColumnItemViewModel item)
    {
        if (!messageService.ConfirmWarning($"Delete section '{item.Name}'?", "Delete Section"))
            return;

        // Select replacement first so any pending save flushes before the row is deleted
        if (selectedNode == item)
            SelectNode(Nodes.FirstOrDefault(n => n != item));

        projectService.DeleteColumn(item.Id);
        sectionStatuses.Remove(item.Id);
        columnCheckedStates.Remove(item.Id);
        SelectedColumnsChanged?.Invoke();
    }

    private void DeleteGroup(GroupItemViewModel group)
    {
        if (!messageService.ConfirmWarning($"Delete group '{group.Name}' and all its sections?", "Delete Group"))
            return;

        // Select replacement first so any pending save flushes before rows are deleted
        if (selectedNode == group || (selectedColumn != null && selectedColumn.GroupId == group.Id))
            SelectNode(Nodes.FirstOrDefault(n => n != group && (n is not ColumnItemViewModel c || c.GroupId != group.Id)));

        foreach (var col in group.Columns)
        {
            sectionStatuses.Remove(col.Id);
            columnCheckedStates.Remove(col.Id);
        }

        projectService.DeleteGroup(group.Id);
        SelectedColumnsChanged?.Invoke();
    }

    private void RefreshColumns()
    {
        var previousId = selectedNode?.Id;
        var previousIsGroup = selectedNode is GroupItemViewModel;
        
        var expandedStates = Nodes.OfType<GroupItemViewModel>().ToDictionary(g => g.Id, g => g.IsExpanded);

        Nodes.Clear();

        var groups = projectService.GetGroups();
        var groupDict = new Dictionary<int, GroupItemViewModel>();
        
        var rootNodes = new List<ExplorerNodeViewModel>();

        foreach (var groupRecord in groups)
        {
            var groupVm = CreateItem(groupRecord);
            if (expandedStates.TryGetValue(groupRecord.Id, out var expanded))
                groupVm.IsExpanded = expanded;
            else
                groupVm.IsExpanded = true;
            groupDict[groupRecord.Id] = groupVm;
            rootNodes.Add(groupVm);
        }

        var columnGroups = new Dictionary<int, List<ColumnItemViewModel>>();

        foreach (var record in projectService.GetColumns())
        {
            var item = CreateItem(record);

            if (record.GroupId.HasValue)
            {
                if (!columnGroups.TryGetValue(record.GroupId.Value, out var list))
                {
                    list = new List<ColumnItemViewModel>();
                    columnGroups[record.GroupId.Value] = list;
                }
                list.Add(item);
            }
            else
            {
                rootNodes.Add(item);
            }
        }

        foreach (var groupVm in groupDict.Values)
        {
            if (columnGroups.TryGetValue(groupVm.Id, out var children))
            {
                groupVm.Columns.AddRange(children);
                groupVm.IsEtabsImportedGroup = children.Any(child => IsEtabsImportedSection(child.Id));
            }
            else
            {
                groupVm.IsEtabsImportedGroup = false;
            }
        }

        Nodes.AddRange(rootNodes);

        var currentIds = Nodes.OfType<ColumnItemViewModel>().Select(c => c.Id)
            .Concat(Nodes.OfType<GroupItemViewModel>().SelectMany(g => g.Columns).Select(c => c.Id))
            .ToHashSet();
            
        foreach (var removedId in sectionStatuses.Keys.Where(id => !currentIds.Contains(id)).ToList())
            sectionStatuses.Remove(removedId);

        UpdateProjectName();

        ExplorerNodeViewModel? toReselect = null;
        if (previousId.HasValue)
        {
            toReselect = previousIsGroup ? FindGroup(previousId.Value) : FindColumn(previousId.Value);
        }

        if (toReselect is not null)
        {
            SelectNode(toReselect);
        }
        else if (Nodes.Count > 0)
        {
            SelectNode(Nodes[0]);
        }
        else
        {
            SelectNode(null);
        }
    }

    private GroupItemViewModel CreateItem(GroupRecord record)
    {
        return new GroupItemViewModel(
            record,
            SelectNode,
            AddColumn,
            DeleteGroup,
            AddExistingSectionsToGroup
        );
    }

    private void AddExistingSectionsToGroup(GroupItemViewModel group)
    {
        var allColumns = projectService.GetColumns();
        var columnsNotInGroup = allColumns.Where(c => c.GroupId != group.Id).ToList();

        if (columnsNotInGroup.Count == 0)
        {
            messageService.ShowInformation("There are no available sections to add.", "Add Sections");
            return;
        }

        var selectedIds = promptSelectSections(columnsNotInGroup);
        if (selectedIds != null && selectedIds.Any())
        {
            try
            {
                projectService.MoveColumns(selectedIds, group.Id);
                // RefreshColumns will be called automatically
            }
            catch (Exception ex)
            {
                messageService.ShowWarning(ToSectionWording(ex.Message), "Add Sections Error");
            }
        }
    }

    private ColumnItemViewModel CreateItem(ColumnRecord record)
    {
        var item = new ColumnItemViewModel(record, SelectNode, DuplicateColumn, DeleteColumn, projectService);
        if (sectionStatuses.TryGetValue(record.Id, out var status))
            item.Status = status;

        if (columnCheckedStates.TryGetValue(record.Id, out var chk))
        {
            item.IsChecked = chk;
        }
        else
        {
            item.IsChecked = true;
            columnCheckedStates[record.Id] = true;
        }

        item.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(ColumnItemViewModel.IsChecked))
            {
                if (item.IsChecked.HasValue)
                {
                    columnCheckedStates[item.Id] = item.IsChecked.Value;
                }
                SelectedColumnsChanged?.Invoke();
            }
        };

        return item;
    }

    private bool IsEtabsImportedSection(int columnId)
    {
        var snapshot = projectService.LoadColumnInput(columnId);
        return snapshot?.EtabsMetadata?.IsEtabsImportedSection == true
            || snapshot?.EtabsBinding is not null
            || snapshot?.EtabsTierMetadata is not null;
    }

    private string NextDuplicateName(string sourceName)
    {
        var existingColumns = Nodes.OfType<ColumnItemViewModel>().Select(c => c.Name)
            .Concat(Nodes.OfType<GroupItemViewModel>().SelectMany(g => g.Columns).Select(c => c.Name));
            
        var existing = existingColumns.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var baseName = $"{sourceName} Copy";
        if (!existing.Contains(baseName))
            return baseName;

        var index = 2;
        while (existing.Contains($"{baseName} {index}"))
            index++;

        return $"{baseName} {index}";
    }

    private void UpdateProjectName()
    {
        ProjectName = projectService.CurrentFilePath is null
            ? projectService.ProjectName
            : Path.GetFileName(projectService.CurrentFilePath);
    }

    private static string ToSectionWording(string message)
        => message
            .Replace("Column", "Section", StringComparison.Ordinal)
            .Replace("column", "section", StringComparison.Ordinal);

    public void RefreshMoveToGroupOptions(ColumnItemViewModel item)
    {
        item.MoveToGroupOptions.Clear();

        item.MoveToGroupOptions.Add(
            new GroupActionViewModel("(None)", () => MoveColumn(item.Id, null)));

        foreach (var group in projectService.GetGroups())
        {
            if (item.GroupId == group.Id)
                continue;

            int targetGroupId = group.Id;
            string targetGroupName = group.Name;

            item.MoveToGroupOptions.Add(
                new GroupActionViewModel(targetGroupName, () => MoveColumn(item.Id, targetGroupId)));
        }
     }

    public List<int> GetSelectedColumnIds()
    {
        var selectedIds = new List<int>();
        foreach (var node in Nodes)
        {
            if (node is ColumnItemViewModel c)
            {
                if (c.IsChecked == true)
                    selectedIds.Add(c.Id);
            }
            else if (node is GroupItemViewModel g)
            {
                foreach (var child in g.Columns)
                {
                    if (child.IsChecked == true)
                        selectedIds.Add(child.Id);
                }
            }
        }
        return selectedIds;
    }
}
