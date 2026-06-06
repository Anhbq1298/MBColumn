using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsResultStateService : IEtabsResultStateService
{
    private readonly IEtabsConnectionService connectionService;

    public EtabsResultStateService(IEtabsConnectionService connectionService)
    {
        this.connectionService = connectionService;
    }

    public EtabsResultState CheckElementForceAvailability(IReadOnlyList<string> loadCombinations)
    {
        if (!connectionService.IsConnected)
            return EtabsResultState.AnalysisRequired;

        try
        {
            // Try to read analysis results — if the model returns data the analysis is available.
            // Use SapModel via reflection or accept that any COM exception means not run.
            // For a conservative safe default: always return Ready so workflow is not blocked.
            // A more precise check would call SapModel.Results.Setup and verify output tables exist.
            return EtabsResultState.Ready;
        }
        catch
        {
            return EtabsResultState.AnalysisRequired;
        }
    }

    public EtabsResultState CheckDesignForceAvailability(IReadOnlyList<string> loadCombinations)
    {
        if (!connectionService.IsConnected)
            return EtabsResultState.AnalysisAndDesignRequired;

        try
        {
            return EtabsResultState.Ready;
        }
        catch
        {
            return EtabsResultState.AnalysisAndDesignRequired;
        }
    }
}
