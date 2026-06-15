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
                col.UniqueName,
                "",
                col.Story,
                col.Label,
                col.Key,
                col.SectionPropertyName,
                "",
                Domain.Enums.SectionShapeType.Rectangular,
                0, 0, 0, 0, "", "Ready")
            {
                HasCoordinates = col.X != 0 || col.Y != 0 || col.BottomX != 0 || col.BottomY != 0 || col.TopX != 0 || col.TopY != 0,
                BottomXmm = col.BottomX,
                BottomYmm = col.BottomY,
                TopXmm = col.TopX,
                TopYmm = col.TopY,
                CenterXmm = col.X,
                CenterYmm = col.Y
            }))
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
