using System.Collections.ObjectModel;

namespace MBColumn.Application.DTOs.Etabs;

public sealed class MbColumnSectionImport
{
    public string SectionName { get; set; } = string.Empty;
    public ObservableCollection<MbColumnSectionImportItem> SelectedItems { get; set; } = [];
}
