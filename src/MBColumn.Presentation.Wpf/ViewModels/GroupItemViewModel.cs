using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class GroupItemViewModel : ExplorerNodeViewModel
{
    private bool isUpdatingCheckState;

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

        Columns.CollectionChanged += OnColumnsCollectionChanged;
    }

    public BulkObservableCollection<ColumnItemViewModel> Columns { get; } = new();

    public ICommand AddSectionCommand { get; }
    public ICommand AddExistingSectionsCommand { get; }

    protected override void OnCheckedChanged()
    {
        if (isUpdatingCheckState) return;

        if (IsChecked.HasValue)
        {
            isUpdatingCheckState = true;
            try
            {
                foreach (var col in Columns)
                {
                    col.IsChecked = IsChecked.Value;
                }
            }
            finally
            {
                isUpdatingCheckState = false;
            }
        }
    }

    private void OnColumnsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is not null)
        {
            foreach (ColumnItemViewModel col in e.OldItems)
            {
                col.PropertyChanged -= OnColumnPropertyChanged;
            }
        }
        if (e.NewItems is not null)
        {
            foreach (ColumnItemViewModel col in e.NewItems)
            {
                col.PropertyChanged += OnColumnPropertyChanged;
            }
        }
        UpdateCheckStateFromChildren();
    }

    private void OnColumnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(IsChecked))
        {
            UpdateCheckStateFromChildren();
        }
    }

    public void UpdateCheckStateFromChildren()
    {
        if (isUpdatingCheckState) return;
        isUpdatingCheckState = true;
        try
        {
            if (Columns.Count == 0)
            {
                IsChecked = true;
                return;
            }

            bool allChecked = true;
            bool allUnchecked = true;
            foreach (var col in Columns)
            {
                if (col.IsChecked == true)
                {
                    allUnchecked = false;
                }
                else
                {
                    allChecked = false;
                }
            }

            if (allChecked)
                IsChecked = true;
            else if (allUnchecked)
                IsChecked = false;
            else
                IsChecked = null;
        }
        finally
        {
            isUpdatingCheckState = false;
        }
    }
}
