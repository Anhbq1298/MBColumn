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

        if (vm.ImportGroups.Count == 0)
        {
            cm.Items.Add(new MenuItem { Header = "No groups yet — use [+ New Group] first", IsEnabled = false });
        }
        else
        {
            foreach (var group in vm.ImportGroups)
            {
                var g = group;
                var item = new MenuItem { Header = $"Assign to: {g.GroupName}" };
                item.Click += (_, _) => vm.AssignSelectedItemsToGroup(g);
                cm.Items.Add(item);
            }
        }

        ((FrameworkElement)sender).ContextMenu = cm;
    }
}
