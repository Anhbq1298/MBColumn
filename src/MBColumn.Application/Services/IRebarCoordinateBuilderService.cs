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
        UnitSystem unitSystem,
        RebarSetLibraryType? rebarSetLibrary = null);

    IReadOnlyList<RebarCoordinateDto> BuildCircular(
        double diameter,
        double cover,
        int barCount,
        string barSize,
        LengthUnit lengthUnit,
        UnitSystem unitSystem,
        double stirrupDiameterMm = 0.0,
        RebarSetLibraryType? rebarSetLibrary = null);
}
