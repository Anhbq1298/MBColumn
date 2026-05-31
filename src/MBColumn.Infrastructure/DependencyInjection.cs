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
using Microsoft.Extensions.DependencyInjection;

namespace MBColumn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Math / units
        services.AddSingleton<IUnitConversionService, UnitConversionService>();

        // Rebar databases — keyed so both metric and imperial can be resolved when needed
        services.AddKeyedSingleton<IRebarDatabase, SingaporeRebarDatabase>("metric");
        services.AddKeyedSingleton<IRebarDatabase, ImperialRebarDatabase>("imperial");

        // Design codes
        services.AddSingleton<Aci318DesignCodeService>();
        services.AddSingleton<Ec2DesignCodeService>();
        services.AddSingleton<IDesignCodeServiceFactory, DesignCodeServiceFactory>();
        services.AddSingleton<IInteractionSolverFactory, InteractionSolverFactory>();
        services.AddSingleton<IShearDesignServiceFactory, ShearDesignServiceFactory>();

        // ETABS integration
        services.AddSingleton<EtabsConnectionService>();
        services.AddSingleton<EtabsColumnImportService>();
        services.AddSingleton<EtabsForceImportService>();
        services.AddSingleton<EtabsForceCacheService>();
        services.AddSingleton<EtabsPierShellImportService>();
        services.AddSingleton<EtabsDesignForceImportService>();
        services.AddSingleton<IImportedEtabsForceCache, ImportedEtabsForceCache>();
        services.AddSingleton<EtabsForceMapper>();
        services.AddSingleton<EtabsForceChangeDetector>();
        services.AddSingleton<EtabsResultStateService>();
        services.AddSingleton<IEtabsBindingReconciliationService, EtabsBindingReconciliationService>();
        services.AddSingleton<IEtabsForceRefreshService, EtabsForceRefreshService>();
        services.AddSingleton<IrregularPierGeometryBuilder>();

        // Persistence
        services.AddSingleton<IProjectService, ProjectService>();

        // Report services
        services.AddSingleton<PmValidationReportService>();

        return services;
    }
}
