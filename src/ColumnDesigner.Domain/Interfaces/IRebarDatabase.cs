using ColumnDesigner.Domain.Enums;

namespace ColumnDesigner.Domain.Interfaces;

public sealed record RebarDefinition(string Name, string DisplayLabel, double DiameterMm, double AreaMm2, RebarUnitType UnitType);

public interface IRebarDatabase
{
    IReadOnlyList<RebarDefinition> GetBars();
    bool TryGet(string name, out RebarDefinition definition);
}
