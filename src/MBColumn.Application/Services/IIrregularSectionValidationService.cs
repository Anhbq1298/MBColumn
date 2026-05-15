using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;

namespace MBColumn.Application.Services;

public interface IIrregularSectionValidationService
{
    IrregularSectionValidationResult ValidateBoundary(IReadOnlyList<Point2D> points);

    IrregularSectionValidationResult ValidateRebars(
        IReadOnlyList<Point2D> boundary,
        IReadOnlyList<IrregularRebarInputDto> rebars,
        double coverMm);
}
