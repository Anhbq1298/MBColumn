using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MBColumn.Presentation.Wpf.Collections;

/// <summary>
/// ObservableCollection that supports batch adds via AddRange,
/// firing a single Reset notification instead of one per item.
/// </summary>
public sealed class BulkObservableCollection<T> : ObservableCollection<T>
{
    private bool suppressNotifications;

    public void AddRange(IEnumerable<T> items)
    {
        suppressNotifications = true;
        try
        {
            foreach (var item in items)
                Items.Add(item);
        }
        finally
        {
            suppressNotifications = false;
        }
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (!suppressNotifications)
            base.OnCollectionChanged(e);
    }
}
