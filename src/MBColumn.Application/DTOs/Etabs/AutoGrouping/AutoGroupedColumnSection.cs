namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupedColumnSection
{
    public string TierName { get; set; } = string.Empty;
    public string FromStory { get; set; } = string.Empty;
    public string ToStory { get; set; } = string.Empty;
    public string LabelFilter { get; set; } = string.Empty;
    public string ColumnLabel { get; set; } = string.Empty;
    public string MbColumnSectionName { get; set; } = string.Empty;
    public string SplitEtabsSectionName { get; set; } = string.Empty;
    public bool WasSplitByEtabsSection { get; set; }
    public List<EtabsColumnImportDto> SourceEtabsItems { get; set; } = [];

    public string StoryRange => string.Equals(FromStory, ToStory, StringComparison.OrdinalIgnoreCase)
        ? FromStory
        : $"{FromStory}-{ToStory}";
}
