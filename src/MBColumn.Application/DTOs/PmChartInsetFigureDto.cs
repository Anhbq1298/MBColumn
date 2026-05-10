namespace MBColumn.Application.DTOs;

public sealed record InsetPointDto(double X, double Y);

public sealed record InsetLineDto(InsetPointDto Start, InsetPointDto End);

public sealed record PmChartInsetSelectedStateDto(
    string SelectedLoadCaseName,
    string SelectedLoadCaseStateId,
    double ThetaDegrees,
    double? NeutralAxisAngleDegrees,
    double? NeutralAxisDepth,
    double? P,
    double? Mx,
    double? My,
    double? Mtheta,
    bool IsEntireConcreteTension = false);

public sealed record PmChartInsetFigureDto(
    IReadOnlyList<InsetPointDto> SectionBoundaryPoints,
    IReadOnlyList<InsetPointDto> CoverBoundaryPoints,
    IReadOnlyList<InsetPointDto> RebarPoints,
    InsetLineDto XAxisLine,
    InsetLineDto YAxisLine,
    InsetLineDto ThetaLine,
    double ThetaDegrees,
    double? NeutralAxisAngleDegrees,
    InsetLineDto? NeutralAxisLine,
    double? NeutralAxisDepth,
    IReadOnlyList<InsetPointDto> CompressionZonePolygon,
    IReadOnlyList<InsetPointDto> TensionZonePolygon,
    string SelectedLoadCaseName,
    string SelectedLoadCaseStateId,
    double? P,
    double? Mx,
    double? My,
    double? Mtheta);

