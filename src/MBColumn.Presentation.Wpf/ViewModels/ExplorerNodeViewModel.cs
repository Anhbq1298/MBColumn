using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public abstract class ExplorerNodeViewModel : ViewModelBase
{
    private string name = "";
    private bool isSelected;
    private bool isRenaming;
    private string editName = "";

    // Keep project explorer nodes collapsed by default.
    // Large .mbc files may contain many groups/sections; expanding every group during load
    // forces WPF to create a large visual tree and can make unrelated toolbar interactions lag.
    private bool isExpanded;

    public int Id { get; protected set; }

    public string Name
    {
        get => name;
        set => Set(ref name, value);
    }

    public bool IsSelected
    {
        get => isSelected;
        set => Set(ref isSelected, value);
    }

    public bool IsExpanded
    {
        get => isExpanded;
        set => Set(ref isExpanded, value);
    }

    public bool IsRenaming
    {
        get => isRenaming;
        set => Set(ref isRenaming, value);
    }

    public string EditName
    {
        get => editName;
        set => Set(ref editName, value);
    }

    public ICommand SelectCommand { get; protected set; } = null!;
    public ICommand BeginRenameCommand { get; protected set; } = null!;
    public ICommand DeleteCommand { get; protected set; } = null!;
}
