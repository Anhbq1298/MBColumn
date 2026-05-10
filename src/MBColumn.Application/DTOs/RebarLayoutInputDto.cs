namespace MBColumn.Application.DTOs;

public sealed record RebarLayoutInputDto(
    RebarLayoutType LayoutType,
    int TotalBars,
    string BarSize,
    double Cover,
    RebarSideInputDto Top,
    RebarSideInputDto Bottom,
    RebarSideInputDto Left,
    RebarSideInputDto Right);

