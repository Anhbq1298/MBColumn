using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsColumnImportService
{
    IReadOnlyList<EtabsColumnImportDto> GetCandidateColumns(UnitSystem targetSystem);
    IReadOnlyList<string> GetLoadCombinations();
}
