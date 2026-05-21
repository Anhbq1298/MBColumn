using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsSectionImportMapper
{
    ColumnInputSnapshot CreateSnapshot(
        EtabsColumnImportDto column,
        EtabsSectionMappingDto mapping,
        IReadOnlyList<EtabsForceResultDto> forces,
        EtabsImportMetadataDto metadata);
}
