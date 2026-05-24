using MBColumn.Application.DTOs.Etabs;
using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MBColumn.Presentation.Wpf.Views;

public partial class EtabsImportWindow : Window
{
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
        if (DataContext is EtabsImportViewModel vm && !vm.IsConnected)
            vm.ConnectCommand.Execute(null);
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
