using System.Collections.ObjectModel;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.Commands;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MbColumnSectionViewModel : ViewModelBase
{
    private string sectionName;
    private bool isRenaming;
    private string editName;
    private string? renameError;
    private ProjectGroupOptionViewModel? selectedTargetGroup;
    private readonly Action onChanged;
    private readonly Func<string, bool>? isDuplicateName;

    public MbColumnSectionViewModel(string sectionName, Action onChanged, Func<string, bool>? isDuplicateName = null)
    {
        this.sectionName = sectionName;
        this.editName = sectionName;
        this.onChanged = onChanged;
        this.isDuplicateName = isDuplicateName;

        Items = [];

        BeginRenameCommand = new RelayCommand(() =>
        {
            EditName = SectionName;
            IsRenaming = true;
        });
        CommitRenameCommand = new RelayCommand(CommitRename);
        CancelRenameCommand = new RelayCommand(() => IsRenaming = false);
        ClearSectionCommand = new RelayCommand(() =>
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

    public string SectionName
    {
        get => sectionName;
        private set => Set(ref sectionName, value);
    }

    public string EditName
    {
        get => editName;
        set => Set(ref editName, value);
    }

    public bool IsRenaming
    {
        get => isRenaming;
        set
        {
            Set(ref isRenaming, value);
            if (!value) RenameError = null;
        }
    }

    public string? RenameError
    {
        get => renameError;
        private set => Set(ref renameError, value);
    }

    public ProjectGroupOptionViewModel? SelectedTargetGroup
    {
        get => selectedTargetGroup;
        set => Set(ref selectedTargetGroup, value);
    }

    public int ItemCount => Items.Count;

    public string Summary => $"{SectionName} ({Items.Count})";

    public ICommand BeginRenameCommand { get; }
    public ICommand CommitRenameCommand { get; }
    public ICommand CancelRenameCommand { get; }
    public ICommand ClearSectionCommand { get; }
    public ICommand RemoveItemCommand { get; }

    public void AddItem(EtabsColumnImportRowViewModel item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            item.ImportGroupName = SectionName;
        }
        RaiseSummary();
        onChanged();
    }

    public void RemoveItem(EtabsColumnImportRowViewModel item)
    {
        if (Items.Remove(item))
        {
            if (string.Equals(item.ImportGroupName, SectionName, StringComparison.OrdinalIgnoreCase))
                item.ImportGroupName = "";
        }
        RaiseSummary();
        onChanged();
    }

    private void CommitRename()
    {
        var name = EditName?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(name))
        {
            RenameError = "Name cannot be empty.";
            return;
        }

        if (!string.Equals(name, SectionName, StringComparison.OrdinalIgnoreCase)
            && isDuplicateName?.Invoke(name) == true)
        {
            RenameError = $"'{name}' is already used by another section.";
            return;
        }

        RenameError = null;
        var old = SectionName;
        SectionName = name;
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
