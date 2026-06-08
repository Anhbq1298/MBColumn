namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed class AutoGroupingResult
{
    public List<AutoGroupedColumnSection> Groups { get; set; } = [];
    public List<AutoGroupingPreviewRow> PreviewRows { get; set; } = [];
    public List<AutoGroupingValidationMessage> ValidationMessages { get; set; } = [];

    public bool HasErrors => ValidationMessages.Any(m => m.Severity == AutoGroupingValidationSeverity.Error);
}
