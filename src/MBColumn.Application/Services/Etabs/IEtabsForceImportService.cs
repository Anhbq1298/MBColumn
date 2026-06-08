using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceImportService
{
    IReadOnlyList<EtabsForceResultDto> GetDesignForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    IReadOnlyList<EtabsForceResultDto> GetPierForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    IReadOnlyList<EtabsForceResultDto> GetElementForces(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);

    IReadOnlyList<EtabsForceResultDto> GetPierElementForces(
        IReadOnlyList<(string PierLabel, string StoryName)> piers,
        IReadOnlyList<string> loadCombinations,
        UnitSystem targetSystem);
}
