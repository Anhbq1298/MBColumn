namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsImportMetadataDto
{
    public bool IsEtabsImportedSection { get; set; }

    public string SourceModelPath { get; set; } = "";
    public string SourceModelName { get; set; } = "";
    public string EtabsObjectName { get; set; } = "";
    public string PierName { get; set; } = "";
    public string StoryName { get; set; } = "";
    public string Label { get; set; } = "";
    public string EtabsSectionName { get; set; } = "";
    public string UniqueSectionDisplayName { get; set; } = "";
    public DateTime ImportedAt { get; set; }
    public string ImportedUnits { get; set; } = "";
    public string MBColumnUnitsAtImport { get; set; } = "";
    public List<string> SelectedLoadCombinations { get; set; } = [];

    public string EtabsSourceModelName { get; set; } = "";
    public string EtabsColumnGroupId { get; set; } = "";
    public string EtabsTierId { get; set; } = "";
    public string EtabsSectionPropertyName { get; set; } = "";
    public string EtabsStoryRangeText { get; set; } = "";
    public double EtabsGroupX { get; set; }
    public double EtabsGroupY { get; set; }
    public List<string> EtabsSourceFrameIds { get; set; } = [];
    public List<string> EtabsSourceLabels { get; set; } = [];
    public List<string> EtabsSourceStories { get; set; } = [];
    public DateTime EtabsImportedAt { get; set; }

    // IrregularPierShell import fields (populated when ImportMode = "IrregularPierShell")
    public string ImportMode { get; set; } = "FrameSection";
    public List<string> SourceShellNames { get; set; } = [];
    public List<string> SourceAreaSectionProperties { get; set; } = [];
    public string? IrregularBoundaryWarning { get; set; }
    public int OpeningCount { get; set; }

    public List<EtabsForceReimportAuditLogDto> ForceReimportAuditLogs { get; set; } = [];
}
