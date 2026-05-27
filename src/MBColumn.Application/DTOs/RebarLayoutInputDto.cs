namespace MBColumn.Application.DTOs;

public sealed record RebarLayoutInputDto(
    RebarLayoutType LayoutType,
    int TotalBars,
    string BarSize,
    double Cover,
    RebarSideInputDto Top,
    RebarSideInputDto Bottom,
    RebarSideInputDto Left,
    RebarSideInputDto Right,
    double Spacing = 150.0)
{
    public double StirrupDiameterMm { get; init; } = 0.0;
}

