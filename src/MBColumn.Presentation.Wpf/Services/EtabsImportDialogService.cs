using MBColumn.Application.Services.Etabs;
using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.ViewModels;
using MBColumn.Presentation.Wpf.Views;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class EtabsImportDialogService : IEtabsImportDialogService
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IEtabsForceImportService forceImportService;
    private readonly IEtabsForceCacheService? forceCacheService;
    private readonly IEtabsPierShellImportService? pierShellImportService;
    private readonly IIrregularPierGeometryBuilder? irregularGeometryBuilder;

    public EtabsImportDialogService(
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsForceImportService forceImportService,
        IEtabsForceCacheService? forceCacheService = null,
        IEtabsPierShellImportService? pierShellImportService = null,
        IIrregularPierGeometryBuilder? irregularGeometryBuilder = null)
    {
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.forceImportService = forceImportService;
        this.forceCacheService = forceCacheService;
        this.pierShellImportService = pierShellImportService;
        this.irregularGeometryBuilder = irregularGeometryBuilder;
    }

    public EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames,
        IReadOnlyList<GroupRecord> targetGroups,
        int? defaultTargetGroupId,
        MBColumn.Domain.Enums.UnitSystem targetSystem)
    {
        var vm = new EtabsImportViewModel(
            existingSectionNames,
            targetGroups,
            defaultTargetGroupId,
            connectionService,
            columnImportService,
            forceImportService,
            forceCacheService,
            pierShellImportService,
            irregularGeometryBuilder,
            targetSystem);

        var window = new EtabsImportWindow(vm)
        {
            Owner = owner
        };

        return window.ShowDialog() == true ? vm.ImportResult : null;
    }
}
