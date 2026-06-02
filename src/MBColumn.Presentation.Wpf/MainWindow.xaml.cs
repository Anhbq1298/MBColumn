using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;

        // Keyboard shortcuts
        InputBindings.Add(new KeyBinding(vm.NewProjectCommand, Key.N, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.OpenProjectCommand, Key.O, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.SaveProjectCommand, Key.S, ModifierKeys.Control));
        InputBindings.Add(new KeyBinding(vm.CalculateCommand, Key.F5, ModifierKeys.None));
    }

    // Auto-focus and select-all when a rename TextBox becomes visible
    private void RenameBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is TextBox tb && tb.IsVisible)
        {
            tb.Focus();
            tb.SelectAll();
        }
    }

    // Node rename handlers
    private void NodeRenameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (sender is not TextBox tb || tb.DataContext is not ExplorerNodeViewModel item) return;
        if (e.Key == Key.Enter) { Explorer().CommitRename(item); e.Handled = true; }
        else if (e.Key == Key.Escape) { Explorer().CancelRename(item); e.Handled = true; }
    }

    private void NodeRenameBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox tb && tb.DataContext is ExplorerNodeViewModel item)
            Explorer().CommitRename(item);
    }

    private void AddSectionButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button || button.ContextMenu is null) return;
        button.ContextMenu.PlacementTarget = button;
        button.ContextMenu.IsOpen = true;
    }

    private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (e.NewValue is ExplorerNodeViewModel node)
        {
            Explorer().SelectNode(node);
        }
    }

    private void Border_ContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        if (sender is Border b && b.DataContext is ExplorerNodeViewModel node)
        {
            Explorer().SelectNode(node);
        }
    }

    private void ColumnContextMenu_Opened(object sender, RoutedEventArgs e)
    {
        if (sender is not ContextMenu menu)
            return;

        if (menu.PlacementTarget is FrameworkElement element &&
            element.DataContext is ColumnItemViewModel column)
        {
            Explorer().RefreshMoveToGroupOptions(column);
        }
    }

    private ProjectExplorerViewModel Explorer()
        => ((MainWindowViewModel)DataContext).Explorer;
}
