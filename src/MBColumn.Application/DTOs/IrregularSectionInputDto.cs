namespace MBColumn.Application.DTOs;

// User-coordinate inputs for an irregular section.
// Coordinates are in millimetres (solver-internal length unit).
public sealed record IrregularSectionInputDto(
    IReadOnlyList<IrregularBoundaryPointDto> BoundaryPoints,
    IReadOnlyList<IrregularRebarInputDto> Rebars,
    double CoverMm,
    IrregularRebarModeType RebarMode);
