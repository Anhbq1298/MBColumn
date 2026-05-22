using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsPierShellImportService
{
    IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName);
}
