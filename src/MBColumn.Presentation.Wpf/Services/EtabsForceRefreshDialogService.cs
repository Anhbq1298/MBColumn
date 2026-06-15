using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;
using System.Collections.Generic;

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
        IReadOnlyList<ColumnRecord> allColumns,
        int? currentColumnId,
        int? currentFolderId,
        UnitSystem unitSystem)
    {
        var vm = new EtabsForceRefreshViewModel(
            connectionService,
            refreshService,
            columnImportService,
            projectService,
            allColumns,
            currentColumnId,
            currentFolderId,
            unitSystem);

        var window = new EtabsForceRefreshWindow(vm) { Owner = owner };
        return window.ShowDialog() == true ? vm.Result : null;
    }
}
