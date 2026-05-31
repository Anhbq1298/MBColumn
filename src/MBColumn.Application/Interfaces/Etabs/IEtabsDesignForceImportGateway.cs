using MBColumn.Application.DTOs.Etabs.Forces;

namespace MBColumn.Application.Interfaces.Etabs;

/// <summary>
/// Pure gateway interface for reading design forces from the ETABS concrete design module.
/// Implemented in Infrastructure.Etabs — Application has no ETABSv1 dependency.
/// </summary>
public interface IEtabsDesignForceImportGateway
{
    Task<EtabsForceImportResultDto> ImportAsync(EtabsForceImportRequestDto request, CancellationToken cancellationToken = default);
}
