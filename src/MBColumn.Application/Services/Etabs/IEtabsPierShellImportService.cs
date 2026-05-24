using MBColumn.Application.DTOs.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsPierShellImportService
{
    IReadOnlyList<EtabsPierShellSegmentDto> GetSegments(string pierLabel, string storyName, UnitSystem targetSystem);

    // Returns all distinct pier+story groups found in the model, with the first encountered
    // section property as a material/section proxy for display purposes.
    IReadOnlyList<(string PierLabel, string StoryName, string SectionProperty)> GetPierGroups(UnitSystem targetSystem);

    // Returns the list of story names in vertical elevation order from the ETABS model.
    IReadOnlyList<string> GetStoryNames();
}
