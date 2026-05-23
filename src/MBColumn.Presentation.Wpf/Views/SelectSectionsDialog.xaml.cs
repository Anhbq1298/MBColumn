using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MBColumn.Application.Services;

namespace MBColumn.Presentation.Wpf.Views;

public partial class SelectSectionsDialog : Window
{
    public class SectionSelectionItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    private readonly List<SectionSelectionItem> _items = new();

    public SelectSectionsDialog(IEnumerable<ColumnRecord> columns)
    {
        InitializeComponent();
        
        foreach (var col in columns)
        {
            _items.Add(new SectionSelectionItem { Id = col.Id, Name = col.Name, IsSelected = false });
        }
        
        SectionsListBox.ItemsSource = _items;
    }

    public IEnumerable<int> GetSelectedIds() => _items.Where(x => x.IsSelected).Select(x => x.Id);

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }
}
