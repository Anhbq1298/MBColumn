using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsColumnImportService
{
    IReadOnlyList<EtabsColumnImportDto> GetCandidateColumns(UnitSystem targetSystem);
    IReadOnlyList<string> GetLoadCombinations();
    /// <summary>Returns story names sorted ascending by elevation (index 0 = lowest floor).</summary>
    IReadOnlyList<(string Name, double Elevation)> GetStoryElevations();
}
