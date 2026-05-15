namespace MBColumn.Application.DTOs.ImportExport;

public sealed record IrregularRebarCsvDto(
    string RebarIndex,
    double X,
    double Y,
    string? BarSize,
    double? AreaMm2);
