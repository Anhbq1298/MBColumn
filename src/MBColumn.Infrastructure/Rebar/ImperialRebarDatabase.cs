using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Math;

namespace MBColumn.Infrastructure.Rebar;

public sealed class ImperialRebarDatabase : IRebarDatabase
{
    private static readonly (string Name, double DiaIn, double AreaIn2)[] UsBars =
    [
        ("#3", 0.375, 0.11),
        ("#4", 0.500, 0.20),
        ("#5", 0.625, 0.31),
        ("#6", 0.750, 0.44),
        ("#7", 0.875, 0.60),
        ("#8", 1.000, 0.79),
        ("#9", 1.128, 1.00),
        ("#10", 1.270, 1.27),
        ("#11", 1.410, 1.56)
    ];

    private readonly IReadOnlyList<RebarDefinition> bars = UsBars
        .Select(b => new RebarDefinition(b.Name, $"{b.Name} - {b.DiaIn:0.###} in", b.DiaIn * 25.4, b.AreaIn2 * 25.4 * 25.4, RebarUnitType.UnitedStatesImperial))
        .ToList();

    public IReadOnlyList<RebarDefinition> GetBars() => bars;

    public bool TryGet(string name, out RebarDefinition definition)
    {
        definition = bars.FirstOrDefault(b => string.Equals(b.Name, name, StringComparison.OrdinalIgnoreCase))!;
        return definition is not null;
    }
}

