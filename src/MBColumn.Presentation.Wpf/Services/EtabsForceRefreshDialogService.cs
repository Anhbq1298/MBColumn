using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class EtabsForceRefreshDialogService : IEtabsForceRefreshDialogService
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsForceRefreshService refreshService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IProjectService projectService;

    public EtabsForceRefreshDialogService(
        IEtabsConnectionService connectionService,
        IEtabsForceRefreshService refreshService,
        IEtabsColumnImportService columnImportService,
        IProjectService projectService)
    {
        this.connectionService = connectionService;
        this.refreshService = refreshService;
        this.columnImportService = columnImportService;
        this.projectService = projectService;
    }

    public EtabsForceRefreshResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyList<EtabsSectionBinding> existingBindings,
        IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> existingLoadCasesBySection,
        UnitSystem unitSystem)
    {
        var vm = new EtabsForceRefreshViewModel(
            connectionService,
            refreshService,
            projectService,
            existingBindings,
            existingLoadCasesBySection,
            unitSystem);

        // Connect and load combinations eagerly so the user sees the combo list immediately
        var connectionResult = connectionService.ConnectToRunningEtabs();
        if (connectionResult.IsConnected)
        {
            try
            {
                var combos = columnImportService.GetLoadCombinations();
                vm.SetAvailableCombinations(combos);
            }
            catch { /* let user see connected state and retry */ }
        }

        var window = new EtabsForceRefreshWindow(vm) { Owner = owner };
        return window.ShowDialog() == true ? vm.Result : null;
    }
}
