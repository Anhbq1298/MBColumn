namespace MBColumn.Application.DTOs.Etabs;

public enum EtabsSectionRefreshAction
{
    Update,
    KeepOld,
    Skip,
    NeedsRemap
}

public sealed class EtabsSectionRefreshSummary
{
    public string SectionName { get; set; } = "";
    public EtabsBindingHealthStatus Status { get; set; }
    public int OldRowCount { get; set; }
    public int NewRowCount { get; set; }
    public int ChangedRows { get; set; }
    public int AddedRows { get; set; }
    public int RemovedRows { get; set; }
    public int MissingObjects { get; set; }
    public EtabsSectionRefreshAction RecommendedAction { get; set; }
    public List<EtabsForceRowChange> RowChanges { get; set; } = [];
    public List<MbColumnMappedForceRow> NewForceRows { get; set; } = [];
}
