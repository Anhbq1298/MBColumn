using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceSelectionService : IEtabsForceSelectionService
{
    public IReadOnlyList<EtabsColumnImportDto> BuildColumnScope(EtabsForceScope scope)
    {
        return scope.Bindings
            .Where(b => b.ObjectType == EtabsImportedObjectType.Column)
            .SelectMany(b => b.ColumnObjects.Select(col => new EtabsColumnImportDto(
                col.Key,
                "",
                col.Story,
                col.Label,
                col.Key,
                col.Label,
                "",
                Domain.Enums.SectionShapeType.Rectangular,
                0, 0, 0, 0, "", "Ready")))
            .ToList();
    }

    public IReadOnlyList<(string PierLabel, string StoryName)> BuildPierScope(EtabsForceScope scope)
    {
        return scope.Bindings
            .Where(b => b.ObjectType == EtabsImportedObjectType.Pier)
            .SelectMany(b => b.PierObjects.Select(pier => (pier.PierName, pier.Story)))
            .Distinct()
            .ToList();
    }
}
