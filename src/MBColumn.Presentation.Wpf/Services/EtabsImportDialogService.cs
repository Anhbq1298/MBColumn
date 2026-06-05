using MBColumn.Application.Services.Etabs;
using MBColumn.Application.Services;
using MBColumn.Infrastructure.Etabs;
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
    private readonly IEtabsDesignForceImportService? designForceImportService;
    private readonly IImportedEtabsForceCache? importedForceCache;
    private readonly IEtabsForceTableService? forceTableService;
    private readonly IEtabsColumnIdentityService? columnIdentityService;

    public EtabsImportDialogService(
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsForceImportService forceImportService,
        IEtabsForceCacheService? forceCacheService = null,
        IEtabsPierShellImportService? pierShellImportService = null,
        IIrregularPierGeometryBuilder? irregularGeometryBuilder = null,
        IEtabsDesignForceImportService? designForceImportService = null,
        IImportedEtabsForceCache? importedForceCache = null,
        IEtabsForceTableService? forceTableService = null,
        IEtabsColumnIdentityService? columnIdentityService = null)
    {
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.forceImportService = forceImportService;
        this.forceCacheService = forceCacheService;
        this.pierShellImportService = pierShellImportService;
        this.irregularGeometryBuilder = irregularGeometryBuilder;
        this.designForceImportService = designForceImportService;
        this.importedForceCache = importedForceCache;
        this.forceTableService = forceTableService;
        this.columnIdentityService = columnIdentityService;
    }

    public EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames,
        IReadOnlyList<GroupRecord> targetGroups,
        int? defaultTargetGroupId,
        MBColumn.Domain.Enums.UnitSystem targetSystem)
    {
        IEtabsForceCacheResolver? forceCacheResolver = null;
        if (importedForceCache is not null && designForceImportService is not null)
            forceCacheResolver = new EtabsForceCacheResolver(importedForceCache, designForceImportService, targetSystem);

        var sectionForceFilter = new EtabsSectionForceFilterService();

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
            designForceImportService,
            importedForceCache,
            targetSystem,
            forceCacheResolver,
            sectionForceFilter,
            forceTableService,
            columnIdentityService);

        var window = new EtabsImportWindow(vm) { Owner = owner };
        return window.ShowDialog() == true ? vm.ImportResult : null;
    }
}
