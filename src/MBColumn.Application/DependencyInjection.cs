using MBColumn.Application.Services;
using MBColumn.Application.Validators;
using MBColumn.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MBColumn.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Registers stable Application-layer services.
    /// ColumnCalculationService and ViewModels are still composed manually in AppComposition
    /// until ViewModel factories are migrated in a later phase.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ColumnInputValidator>();
        services.AddSingleton<InputValidationService>();
        services.AddSingleton<DiagramDataService>();
        services.AddSingleton<IRatioCheckService, RatioCheckService>();
        services.AddSingleton<IControlPointBuilder, ControlPointBuilderService>();
        services.AddSingleton<ShearCheckService>();
        services.AddSingleton<RebarComplianceCheckService>();
        services.AddSingleton<RebarCoordinateBuilderService>();
        services.AddSingleton<ControlPointCsvExportService>();
        return services;
    }
}
