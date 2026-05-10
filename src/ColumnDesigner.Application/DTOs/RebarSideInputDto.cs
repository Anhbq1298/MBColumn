namespace ColumnDesigner.Application.DTOs;

public sealed record RebarSideInputDto(
    int BarCount,
    string BarSize,
    double Cover);
