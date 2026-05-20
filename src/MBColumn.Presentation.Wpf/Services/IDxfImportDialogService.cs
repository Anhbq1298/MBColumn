using MBColumn.Application.DTOs.ImportExport;

namespace MBColumn.Presentation.Wpf.Services;

public interface IDxfImportDialogService
{
    DxfSectionImportResult? ShowDialog(System.Windows.Window? owner);
}
