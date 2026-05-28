using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Etabs;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Persistence;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;
using MBColumn.Infrastructure.Solvers.StrainPoints;
using MBColumn.Presentation.Wpf.Services;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Composition;

public sealed class AppComposition : IDisposable
{
    public IProjectService ProjectService { get; }
    public IMessageService MessageService { get; }
    public IProjectFileDialogService ProjectFileDialogService { get; }
    public IProjectNameDialogService ProjectNameDialogService { get; }
    public IEtabsImportDialogService EtabsImportDialogService { get; }
    public IEtabsForceRefreshDialogService EtabsForceRefreshDialogService { get; }
    public ProjectSession ProjectSession { get; }

    private readonly ColumnCalculationService calculationService;
    private readonly IRebarDatabase metricBars;
    private readonly IRebarDatabase imperialBars;
    private readonly IRebarCoordinateBuilderService rebarCoordinates;

    private AppComposition()
    {
        ProjectService = new ProjectService();
        MessageService = new MessageBoxService();
        ProjectFileDialogService = new ProjectFileDialogService();
        ProjectNameDialogService = new ProjectNameDialogService();
        ProjectSession = new ProjectSession();

        var etabsConnection = new EtabsConnectionService();
        var etabsColumns = new EtabsColumnImportService(etabsConnection);
        var etabsForces = new EtabsForceImportService(etabsConnection);
        var etabsForceCache = new EtabsForceCacheService();
        var etabsPierShells = new EtabsPierShellImportService(etabsConnection);
        var irregularGeometry = new IrregularPierGeometryBuilder();
        var etabsDesignForceImport = new EtabsDesignForceImportService(etabsConnection);
        var importedForceCache = new ImportedEtabsForceCache();
        EtabsImportDialogService = new EtabsImportDialogService(
            etabsConnection, etabsColumns, etabsForces, etabsForceCache, etabsPierShells, irregularGeometry,
            etabsDesignForceImport, importedForceCache);

        var forceMapper = new EtabsForceMapper();
        var changeDetector = new EtabsForceChangeDetector();
        var resultStateService = new EtabsResultStateService(etabsConnection);
        var reconciliationService = new EtabsBindingReconciliationService();
        IEtabsForceRefreshService forceRefreshService = new EtabsForceRefreshService(
            etabsConnection, etabsForces, etabsColumns,
            reconciliationService, forceMapper, changeDetector, resultStateService);

        EtabsForceRefreshDialogService = new EtabsForceRefreshDialogService(
            etabsConnection, forceRefreshService, etabsColumns, ProjectService);

        IDesignCodeService aciCode = new Aci318DesignCodeService();
        IDesignCodeService ec2Code = new Ec2DesignCodeService();
        IDesignCodeServiceFactory codeFactory = new DesignCodeServiceFactory(aciCode, ec2Code);
        IInteractionSolverFactory solverFactory = new InteractionSolverFactory(aciCode, ec2Code);
        IUnitConversionService units = new UnitConversionService();
        metricBars = new SingaporeRebarDatabase();
        imperialBars = new ImperialRebarDatabase();
        IRatioCheckService ratio = new RatioCheckService();
        IControlPointBuilder control = new ControlPointBuilderService(units);
        var diagrams = new DiagramDataService();
        var validation = new InputValidationService();
        rebarCoordinates = new RebarCoordinateBuilderService(units, metricBars, imperialBars);

        // Shear design services
        IShearDesignService ec2Shear = new Ec2ShearDesignService();
        IShearDesignServiceFactory shearFactory = new ShearDesignServiceFactory(ec2Shear);
        var shearCheck = new ShearCheckService(units);
        var complianceCheck = new RebarComplianceCheckService(units);

        calculationService = new ColumnCalculationService(
            solverFactory,
            codeFactory,
            units,
            ratio,
            control,
            diagrams,
            validation,
            rebarCoordinates,
            new PmValidationReportService(codeFactory),
            shearCheck,
            shearFactory,
            complianceCheck);
    }

    public static AppComposition Create()
        => new();

    public MainWindowViewModel CreateMainWindowViewModel()
    {
        var input = new InputViewModel(metricBars, imperialBars, rebarCoordinates, new DxfImportDialogService());
        return new MainWindowViewModel(
            calculationService,
            ProjectService,
            input,
            () => new InputViewModel(metricBars, imperialBars, rebarCoordinates, new DxfImportDialogService()),
            MessageService,
            ProjectFileDialogService,
            ProjectNameDialogService,
            EtabsImportDialogService,
            ProjectSession,
            EtabsForceRefreshDialogService);
    }

    public void Dispose()
    {
        if (ProjectService is IDisposable disposableProjectService)
            disposableProjectService.Dispose();
    }
}
