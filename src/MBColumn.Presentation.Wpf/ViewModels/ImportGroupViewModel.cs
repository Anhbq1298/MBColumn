using System.Collections.ObjectModel;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ImportGroupViewModel : ViewModelBase
{
    private string groupName;
    private bool isRenaming;
    private string editName;
    private readonly Action onChanged;

    public ImportGroupViewModel(string groupName, Action onChanged)
    {
        this.groupName = groupName;
        this.editName = groupName;
        this.onChanged = onChanged;

        Items = [];

        BeginRenameCommand = new RelayCommand(() =>
        {
            EditName = GroupName;
            IsRenaming = true;
        });
        CommitRenameCommand = new RelayCommand(CommitRename);
        CancelRenameCommand = new RelayCommand(() => IsRenaming = false);
        ClearGroupCommand = new RelayCommand(() =>
        {
            Items.Clear();
            onChanged();
        });
        RemoveItemCommand = new RelayCommand<EtabsColumnImportRowViewModel>(item =>
        {
            RemoveItem(item);
        });
    }

    public ObservableCollection<EtabsColumnImportRowViewModel> Items { get; }

    public string GroupName
    {
        get => groupName;
        private set => Set(ref groupName, value);
    }

    public string EditName
    {
        get => editName;
        set => Set(ref editName, value);
    }

    public bool IsRenaming
    {
        get => isRenaming;
        set => Set(ref isRenaming, value);
    }

    public int ItemCount => Items.Count;

    public string Summary => $"{GroupName} ({Items.Count})";

    public ICommand BeginRenameCommand { get; }
    public ICommand CommitRenameCommand { get; }
    public ICommand CancelRenameCommand { get; }
    public ICommand ClearGroupCommand { get; }
    public ICommand RemoveItemCommand { get; }

    public void AddItem(EtabsColumnImportRowViewModel item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            item.ImportGroupName = GroupName;
        }
        RaiseSummary();
        onChanged();
    }

    public void RemoveItem(EtabsColumnImportRowViewModel item)
    {
        if (Items.Remove(item))
        {
            if (string.Equals(item.ImportGroupName, GroupName, StringComparison.OrdinalIgnoreCase))
                item.ImportGroupName = "";
        }
        RaiseSummary();
        onChanged();
    }

    private void CommitRename()
    {
        var name = EditName?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(name)) return;

        var old = GroupName;
        GroupName = name;
        IsRenaming = false;

        foreach (var item in Items)
        {
            if (string.Equals(item.ImportGroupName, old, StringComparison.OrdinalIgnoreCase))
                item.ImportGroupName = name;
        }

        RaiseSummary();
        onChanged();
    }

    private void RaiseSummary()
    {
        Raise(nameof(ItemCount));
        Raise(nameof(Summary));
    }
}
