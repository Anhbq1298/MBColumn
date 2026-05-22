using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsPierShellImportService
{
    IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName);

    // Returns all distinct pier+story groups found in the model, with the first encountered
    // section property as a material/section proxy for display purposes.
    IReadOnlyList<(string PierLabel, string StoryName, string SectionProperty)> GetPierGroups();
}
