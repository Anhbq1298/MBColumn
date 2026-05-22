using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IIrregularPierGeometryBuilder
{
    EtabsIrregularBoundaryDto BuildBoundary(IReadOnlyList<EtabsPierShellSegmentDto> segments);
}
