namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupingPreviewRow
{
    public string TierName { get; set; } = string.Empty;
    public string StoryRange { get; set; } = string.Empty;
    public string ColumnLabel { get; set; } = string.Empty;
    public string MbColumnSectionName { get; set; } = string.Empty;
    public int Count { get; set; }
    public string EtabsSectionsDisplayText { get; set; } = string.Empty;
    public string MaterialsDisplayText { get; set; } = string.Empty;
    public bool HasMixedSections { get; set; }
    public bool HasMixedMaterials { get; set; }
}
