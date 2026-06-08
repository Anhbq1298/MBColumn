namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupingTierSummaryRow
{
    public string TierName { get; set; } = string.Empty;
    public string StoryRange { get; set; } = string.Empty;
    public int ColumnSectionCount { get; set; }
    public int ObjectCount { get; set; }
}
