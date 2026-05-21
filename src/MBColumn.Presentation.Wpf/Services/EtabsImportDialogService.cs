using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class EtabsImportDialogService : IEtabsImportDialogService
{
    public EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames)
    {
        var vm = new EtabsImportViewModel(existingSectionNames);
        var window = new EtabsImportWindow(vm)
        {
            Owner = owner
        };

        return window.ShowDialog() == true ? vm.ImportResult : null;
    }
}
