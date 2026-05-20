using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ColumnItemViewModel : ViewModelBase
{
    private string name;
    private bool isSelected;
    private bool isRenaming;
    private string editName;

    public ColumnItemViewModel(
        ColumnRecord record,
        Action<ColumnItemViewModel> onSelect,
        Action<ColumnItemViewModel> onDuplicate,
        Action<ColumnItemViewModel> onDelete)
    {
        Id = record.Id;
        name = record.Name;
        editName = record.Name;
        SelectCommand = new RelayCommand(() => onSelect(this));
        BeginRenameCommand = new RelayCommand(() => { EditName = Name; IsRenaming = true; });
        DuplicateCommand = new RelayCommand(() => onDuplicate(this));
        DeleteCommand = new RelayCommand(() => onDelete(this));
    }

    public int Id { get; }

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

    public ICommand SelectCommand { get; }
    public ICommand BeginRenameCommand { get; }
    public ICommand DuplicateCommand { get; }
    public ICommand DeleteCommand { get; }
}
