using MBColumn.Presentation.Wpf.ViewModels.AutoGrouping;
using System.Windows;
using System.Windows.Controls;

namespace MBColumn.Presentation.Wpf.Views;

public partial class AutoGroupColumnsByTierView : Window
{
    public AutoGroupColumnsByTierView(AutoGroupColumnsByTierViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.RequestClose += (_, accepted) =>
        {
            DialogResult = accepted;
            Close();
        };
    }

    private void OnAvailableStoriesSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is not AutoGroupColumnsByTierViewModel viewModel)
            return;

        foreach (var item in e.AddedItems.OfType<StoryAssignmentItem>())
            item.IsSelected = true;
        foreach (var item in e.RemovedItems.OfType<StoryAssignmentItem>())
            item.IsSelected = false;

        viewModel.NotifyAvailableStorySelectionChanged();
    }
}
