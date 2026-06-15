namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsForceReimportAuditLogDto
{
    public DateTime ImportedAt { get; set; }
    public bool ModelNameOrPathDiffered { get; set; }
    public bool SourceModelConfirmedByUser { get; set; }
    public string ResolutionMethod { get; set; } = "";
    public List<string> ResolvedEtabsObjectUniqueNames { get; set; } = [];
    public string StoryCheckResult { get; set; } = "";
    public string XyCheckResult { get; set; } = "";
    public List<string> SelectedLoadCombinations { get; set; } = [];
    public List<string> SelectedLoadCases { get; set; } = [];
    public string ForceExtractionMode { get; set; } = "";
    public string ImportBehavior { get; set; } = "";
    public int DemandCasesImported { get; set; }
}
