using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.Rebar;

public sealed class SingaporeRebarDatabase : IRebarDatabase
{
    private static readonly int[] Diameters = [10, 13, 16, 20, 25, 32, 40];
    private readonly IReadOnlyList<RebarDefinition> bars = Diameters
        .Select(d => new RebarDefinition($"T{d}", $"T{d} - {d} mm", d, d == 25 ? 491.0 : (d == 20 ? 314.0 : System.Math.PI * d * d / 4.0), RebarUnitType.SingaporeMetric))
        .ToList();

    public IReadOnlyList<RebarDefinition> GetBars() => bars;

    public bool TryGet(string name, out RebarDefinition definition)
    {
        definition = bars.FirstOrDefault(b => string.Equals(b.Name, name, StringComparison.OrdinalIgnoreCase))!;
        return definition is not null;
    }
}

