namespace MBColumn.Application.DTOs;

// Validation-ready rebar definition: at least one of BarSize or AreaMm2 must be supplied.
public sealed record IrregularRebarInputDto(
    string RebarIndex,
    double X,
    double Y,
    string? BarSize,
    double? AreaMm2);
