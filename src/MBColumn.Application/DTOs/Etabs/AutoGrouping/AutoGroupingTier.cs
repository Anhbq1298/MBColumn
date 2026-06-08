namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupingTier
{
    public string TierName { get; set; } = string.Empty;
    public string FromStory { get; set; } = string.Empty;
    public string ToStory { get; set; } = string.Empty;
    public string LabelFilter { get; set; } = string.Empty;

    public AutoGroupingTier Clone() => new()
    {
        TierName = TierName,
        FromStory = FromStory,
        ToStory = ToStory,
        LabelFilter = LabelFilter
    };
}
