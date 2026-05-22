using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceImportService
{
    IReadOnlyList<EtabsForceResultDto> GetForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    // Returns pier forces (Top + Bottom) for the requested pier+story pairs.
    // model.Results.PierForce returns all piers at once; this method filters to the requested set.
    IReadOnlyList<EtabsForceResultDto> GetPierForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);
}
