namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsForceRefreshPreview
{
    public int SectionsAffected { get; set; }
    public int LoadCombinationsSelected { get; set; }
    public int ExistingLoadRows { get; set; }
    public int NewLoadRows { get; set; }
    public int ChangedRows { get; set; }
    public int AddedRows { get; set; }
    public int RemovedRows { get; set; }
    public int MissingObjects { get; set; }
    public int MissingCombos { get; set; }
    public int RemapRequired { get; set; }
    public bool HasWarnings => MissingObjects > 0 || MissingCombos > 0 || RemapRequired > 0;
    public List<EtabsSectionRefreshSummary> SectionSummaries { get; set; } = [];
    public EtabsBindingValidationResult? ValidationResult { get; set; }
}
