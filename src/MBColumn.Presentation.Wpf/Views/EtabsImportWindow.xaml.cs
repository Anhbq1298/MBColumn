using MBColumn.Application.DTOs.Etabs;
using MBColumn.Presentation.Wpf.ViewModels;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsImportWindow : Window
{
    private bool _suppressStorySync;
    private bool _suppressUniqueSectionSync;

    public EtabsImportWindow(EtabsImportViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.RequestClose += (_, accepted) =>
        {
            DialogResult = accepted;
            Close();
        };
    }

    private void OnWindowLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is EtabsImportViewModel vm)
        {
            if (!vm.IsConnected)
                vm.ConnectCommand.Execute(null);

            vm.StoryOptions.CollectionChanged += OnStoryOptionsCollectionChanged;
            SyncStoryListBoxToVm(vm);

            vm.UniqueSectionOptions.CollectionChanged += OnUniqueSectionOptionsCollectionChanged;
            SyncUniqueSectionListBoxToVm(vm);

            vm.RequestGroupName = defaultName =>
            {
                var dlg = new ProjectNameDialog(defaultName, "New Project Group", "Group name:")
                {
                    Owner = this
                };
                return dlg.ShowDialog() == true ? dlg.ProjectName : null;
            };
        }
    }

    private void OnStoryOptionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        _suppressStorySync = true;
        try
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    StoryListBox.SelectedItems.Clear();
                    break;
                case NotifyCollectionChangedAction.Add when e.NewItems is not null:
                    foreach (var item in e.NewItems)
                        if ((item as EtabsStoryOptionViewModel)?.IsSelected == true)
                            StoryListBox.SelectedItems.Add(item);
                    break;
                case NotifyCollectionChangedAction.Remove when e.OldItems is not null:
                    foreach (var item in e.OldItems)
                        StoryListBox.SelectedItems.Remove(item);
                    break;
            }
        }
        finally
        {
            _suppressStorySync = false;
        }
    }

    private void SyncStoryListBoxToVm(EtabsImportViewModel vm)
    {
        _suppressStorySync = true;
        try
        {
            StoryListBox.SelectedItems.Clear();
            foreach (var s in vm.StoryOptions)
                if (s.IsSelected)
                    StoryListBox.SelectedItems.Add(s);
        }
        finally
        {
            _suppressStorySync = false;
        }
    }

    private void OnUniqueSectionOptionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        _suppressUniqueSectionSync = true;
        try
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    UniqueSectionListBox.SelectedItem = null;
                    break;
                case NotifyCollectionChangedAction.Add when e.NewItems is not null:
                    var newSelected = e.NewItems.OfType<EtabsUniqueSectionOptionViewModel>().FirstOrDefault(i => i.IsSelected);
                    if (newSelected is not null)
                        UniqueSectionListBox.SelectedItem = newSelected;
                    break;
                case NotifyCollectionChangedAction.Remove when e.OldItems is not null:
                    foreach (var item in e.OldItems.OfType<EtabsUniqueSectionOptionViewModel>())
                        if (ReferenceEquals(UniqueSectionListBox.SelectedItem, item))
                            UniqueSectionListBox.SelectedItem = null;
                    break;
            }
        }
        finally
        {
            _suppressUniqueSectionSync = false;
        }
    }

    private void SyncUniqueSectionListBoxToVm(EtabsImportViewModel vm)
    {
        _suppressUniqueSectionSync = true;
        try
        {
            UniqueSectionListBox.SelectedItem = vm.UniqueSectionOptions.FirstOrDefault(s => s.IsSelected);
        }
        finally
        {
            _suppressUniqueSectionSync = false;
        }
    }

    private void OnUniqueSectionListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressUniqueSectionSync) return;
        foreach (var item in e.AddedItems.OfType<EtabsUniqueSectionOptionViewModel>())
            item.IsSelected = true;
        foreach (var item in e.RemovedItems.OfType<EtabsUniqueSectionOptionViewModel>())
            item.IsSelected = false;
    }

    private void OnStoryListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressStorySync) return;
        foreach (var item in e.AddedItems.OfType<EtabsStoryOptionViewModel>())
            item.IsSelected = true;
        foreach (var item in e.RemovedItems.OfType<EtabsStoryOptionViewModel>())
            item.IsSelected = false;
    }

    private void OnAvailableItemsContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        if (DataContext is not EtabsImportViewModel vm) return;
        var cm = new ContextMenu();

        if (vm.MbColumnSections.Count == 0)
        {
            cm.Items.Add(new MenuItem { Header = "No sections yet — use [+ New Section] first", IsEnabled = false });
        }
        else
        {
            foreach (var section in vm.MbColumnSections)
            {
                var s = section;
                var item = new MenuItem { Header = $"Assign to: {s.SectionName}" };
                item.Click += (_, _) => vm.AssignSelectedItemsToSection(s);
                cm.Items.Add(item);
            }
        }

        ((FrameworkElement)sender).ContextMenu = cm;
    }

    private void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            if (item is EtabsColumnImportRowViewModel col)
                col.IsSelected = true;
        }
        foreach (var item in e.RemovedItems)
        {
            if (item is EtabsColumnImportRowViewModel col)
                col.IsSelected = false;
        }
    }

    private void OnListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.AddedItems)
        {
            if (item is EtabsLoadCombinationViewModel combo)
                combo.IsSelected = true;
        }
        foreach (var item in e.RemovedItems)
        {
            if (item is EtabsLoadCombinationViewModel combo)
                combo.IsSelected = false;
        }
    }
}
