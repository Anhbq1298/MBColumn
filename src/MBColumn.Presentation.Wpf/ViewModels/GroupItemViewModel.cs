using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class GroupItemViewModel : ExplorerNodeViewModel
{
    public GroupItemViewModel(
        MBColumn.Application.Services.GroupRecord record,
        Action<ExplorerNodeViewModel> onSelect,
        Action<GroupItemViewModel> onAddSection,
        Action<GroupItemViewModel> onDelete,
        Action<GroupItemViewModel> onAddExisting)
    {
        Id = record.Id;
        Name = record.Name;
        EditName = record.Name;
        
        SelectCommand = new RelayCommand(() => onSelect(this));
        BeginRenameCommand = new RelayCommand(() => { EditName = Name; IsRenaming = true; });
        AddSectionCommand = new RelayCommand(() => onAddSection(this));
        DeleteCommand = new RelayCommand(() => onDelete(this));
        AddExistingSectionsCommand = new RelayCommand(() => onAddExisting(this));
    }

    public BulkObservableCollection<ColumnItemViewModel> Columns { get; } = new();

    public ICommand AddSectionCommand { get; }
    public ICommand AddExistingSectionsCommand { get; }
}
