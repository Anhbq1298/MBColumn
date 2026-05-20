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

    // Column rename handlers
    private void ColumnRenameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (sender is not TextBox tb || tb.DataContext is not ColumnItemViewModel item) return;
        if (e.Key == Key.Enter) { Explorer().CommitRename(item); e.Handled = true; }
        else if (e.Key == Key.Escape) { Explorer().CancelRename(item); e.Handled = true; }
    }

    private void ColumnRenameBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox tb && tb.DataContext is ColumnItemViewModel item)
            Explorer().CommitRename(item);
    }

    // Project rename handlers
    private void ProjectRenameBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) { Explorer().CommitRenameProject(); e.Handled = true; }
        else if (e.Key == Key.Escape) { Explorer().CancelRenameProject(); e.Handled = true; }
    }

    private void ProjectRenameBox_LostFocus(object sender, RoutedEventArgs e)
        => Explorer().CommitRenameProject();

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button || button.ContextMenu is null) return;
        button.ContextMenu.PlacementTarget = button;
        button.ContextMenu.IsOpen = true;
    }

    private ProjectExplorerViewModel Explorer()
        => ((MainWindowViewModel)DataContext).Explorer;
}
