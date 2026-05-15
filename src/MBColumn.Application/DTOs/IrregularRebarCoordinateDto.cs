namespace MBColumn.Application.DTOs;

public sealed record IrregularRebarCoordinateDto(
    string RebarIndex,
    double X,
    double Y,
    string? BarSize,
    double? AreaMm2);
