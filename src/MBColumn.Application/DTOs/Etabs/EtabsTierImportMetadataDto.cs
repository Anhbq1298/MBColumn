namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsTierImportMetadataDto
{
    public string SourceModelPath { get; set; } = "";
    public string SourceModelName { get; set; } = "";
    public string ImportedUnits { get; set; } = "";
    public string MBColumnUnitsAtImport { get; set; } = "kN, kNm";

    public string ShapeType { get; set; } = "";
    public string SourceSectionName { get; set; } = "";
    public string UniqueSectionDisplayName { get; set; } = "";

    public string TargetGroupName { get; set; } = "";
    public int? TargetGroupId { get; set; }

    public string TierName { get; set; } = "";
    public string StoryFrom { get; set; } = "";
    public string StoryTo { get; set; } = "";
    public string LabelFilter { get; set; } = "";

    public List<EtabsSourceObjectRefDto> SourceObjects { get; set; } = [];
    public List<string> SelectedLoadCombinations { get; set; } = [];

    public bool ImportTop { get; set; } = true;
    public bool ImportBottom { get; set; } = true;
    public bool ImportMid { get; set; }

    public DateTime ImportedAt { get; set; }
}

public sealed class EtabsSourceObjectRefDto
{
    public string ObjectName { get; set; } = "";
    public string Label { get; set; } = "";
    public string Story { get; set; } = "";
    public string SectionName { get; set; } = "";
}
