namespace ColumnDesigner.Domain.Entities;

public sealed record RebarLayout(
    string Preset,
    string BarSize,
    double CoverMm,
    IReadOnlyList<Rebar> Bars);
