using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class DxfImportDialogService : IDxfImportDialogService
{
    public DxfSectionImportResult? ShowDialog(System.Windows.Window? owner)
    {
        var vm = new DxfImportViewModel(new DxfImportService());
        var window = new DxfImportWindow(vm)
        {
            Owner = owner
        };

        return window.ShowDialog() == true ? vm.ImportResult : null;
    }
}
