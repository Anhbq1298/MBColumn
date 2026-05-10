using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services;

public interface IRebarCoordinateBuilderService
{
    IReadOnlyList<RebarCoordinateDto> Build(
        RebarLayoutInputDto layout,
        double width,
        double height,
        LengthUnit lengthUnit,
        UnitSystem unitSystem);
}

