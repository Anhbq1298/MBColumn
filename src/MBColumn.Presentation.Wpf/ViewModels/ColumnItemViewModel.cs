using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ColumnItemViewModel : ExplorerNodeViewModel
{
    private SectionStatus status;

    public ColumnItemViewModel(
        ColumnRecord record,
        Action<ExplorerNodeViewModel> onSelect,
        Action<ColumnItemViewModel> onDuplicate,
        Action<ColumnItemViewModel> onDelete)
    {
        Id = record.Id;
        GroupId = record.GroupId;
        Name = record.Name;
        EditName = record.Name;
        status = SectionStatus.NotCalculated;
        SelectCommand = new RelayCommand(() => onSelect(this));
        BeginRenameCommand = new RelayCommand(() => { EditName = Name; IsRenaming = true; });
        DuplicateCommand = new RelayCommand(() => onDuplicate(this));
        DeleteCommand = new RelayCommand(() => onDelete(this));
    }

    public int? GroupId { get; set; }

    public ObservableCollection<GroupActionViewModel> MoveToGroupOptions { get; } = new();

    public SectionStatus Status
    {
        get => status;
        set
        {
            if (status == value) return;
            status = value;
            Raise();
            Raise(nameof(StatusText));
        }
    }

    public string StatusText => Status switch
    {
        SectionStatus.Calculated => "Calculated",
        SectionStatus.Outdated => "Outdated",
        SectionStatus.Error => "Error",
        _ => "Not calculated"
    };

    public ICommand DuplicateCommand { get; }
}
