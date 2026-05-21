using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsColumnImportService
{
    IReadOnlyList<EtabsColumnImportDto> GetCandidateColumns();
    IReadOnlyList<string> GetLoadCombinations();
}
