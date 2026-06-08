namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupingSectionMetadata
{
    public string TierName { get; set; } = string.Empty;
    public string FromStory { get; set; } = string.Empty;
    public string ToStory { get; set; } = string.Empty;
    public string LabelFilter { get; set; } = string.Empty;
    public string ColumnLabel { get; set; } = string.Empty;
}
