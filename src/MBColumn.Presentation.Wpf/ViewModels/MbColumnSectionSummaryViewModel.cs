namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class MbColumnSectionSummaryViewModel
{
    public string SectionName { get; init; } = string.Empty;
    public string ObjectType { get; init; } = string.Empty;
    public int SelectedItems { get; init; }
    public int MatchedForceRows { get; init; }
    public int MissingItems { get; init; }
    public string Status => MissingItems == 0 ? "OK" : $"{MissingItems} missing";
}
