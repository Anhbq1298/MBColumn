namespace ColumnDesigner.Domain.Entities;

public sealed record Rebar(
    string Name,
    double DiameterMm,
    double AreaMm2,
    double XMm,
    double YMm);
