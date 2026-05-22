using MBColumn.Application.Services.Etabs;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class EtabsImportDialogService : IEtabsImportDialogService
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IEtabsForceImportService forceImportService;

    public EtabsImportDialogService(
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsForceImportService forceImportService)
    {
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.forceImportService = forceImportService;
    }

    public EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames)
    {
        var vm = new EtabsImportViewModel(
            existingSectionNames,
            connectionService,
            columnImportService,
            forceImportService);

        var window = new EtabsImportWindow(vm)
        {
            Owner = owner
        };

        return window.ShowDialog() == true ? vm.ImportResult : null;
    }
}
