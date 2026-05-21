namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsImportMetadataDto
{
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
}
