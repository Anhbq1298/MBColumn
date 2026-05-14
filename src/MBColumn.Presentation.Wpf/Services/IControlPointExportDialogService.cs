using MBColumn.Application.DTOs;
using System.Windows;

namespace MBColumn.Presentation.Wpf.Services;

public interface IControlPointExportDialogService
{
    void ShowDialog(CalculationResultDto result, double currentThetaDegrees, Window? owner);
}
