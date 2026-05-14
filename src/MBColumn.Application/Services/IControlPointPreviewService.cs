using MBColumn.Application.DTOs;

namespace MBColumn.Application.Services;

public interface IControlPointPreviewService
{
    ControlPointPreviewResult BuildPreview(
        CalculationResultDto result,
        ControlPointThetaSelectionMode mode,
        double currentThetaDegrees,
        double? customThetaDegrees = null);
}
