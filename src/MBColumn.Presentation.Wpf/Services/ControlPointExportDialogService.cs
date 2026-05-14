using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.ViewModels;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class ControlPointExportDialogService : IControlPointExportDialogService
{
    private readonly IControlPointPreviewService previewService;
    private readonly IControlPointCsvExportService csvExportService;

    public ControlPointExportDialogService()
        : this(new ControlPointPreviewService(new UnitConversionService()), new ControlPointCsvExportService())
    {
    }

    public ControlPointExportDialogService(
        IControlPointPreviewService previewService,
        IControlPointCsvExportService csvExportService)
    {
        this.previewService = previewService;
        this.csvExportService = csvExportService;
    }

    public void ShowDialog(CalculationResultDto result, double currentThetaDegrees, Window? owner)
    {
        var viewModel = new ExportControlPointsViewModel(result, currentThetaDegrees, previewService, csvExportService);
        var window = new ExportControlPointsWindow(viewModel)
        {
            Owner = owner
        };
        window.ShowDialog();
    }
}
