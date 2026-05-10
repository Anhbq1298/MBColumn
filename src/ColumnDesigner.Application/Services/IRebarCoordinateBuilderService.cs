using ColumnDesigner.Application.DTOs;
using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Application.Services;

public interface IRebarCoordinateBuilderService
{
    IReadOnlyList<RebarCoordinateDto> Build(
        RebarLayoutInputDto layout,
        double width,
        double height,
        LengthUnit lengthUnit,
        UnitSystem unitSystem);
}
