namespace MBColumn.Application.DTOs;

public sealed record ChartReferenceLineDto(
    double StartX,
    double StartY,
    double EndX,
    double EndY,
    string Label,
    string LineType,
    bool IsDashed = true);

