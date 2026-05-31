using MBColumn.Application.DTOs.Etabs.Forces;

namespace MBColumn.Application.Interfaces.Etabs;

/// <summary>
/// Pure gateway interface for reading raw analysis element forces from ETABS.
/// Implemented in Infrastructure.Etabs — Application has no ETABSv1 dependency.
/// </summary>
public interface IEtabsElementForceImportGateway
{
    Task<EtabsForceImportResultDto> ImportAsync(EtabsForceImportRequestDto request, CancellationToken cancellationToken = default);
}
