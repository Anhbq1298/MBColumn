using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsResultStateService
{
    EtabsResultState CheckElementForceAvailability(IReadOnlyList<string> loadCombinations);
    EtabsResultState CheckDesignForceAvailability(IReadOnlyList<string> loadCombinations);
}
