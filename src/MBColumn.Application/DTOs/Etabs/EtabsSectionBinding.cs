namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsSectionBinding
{
    public string MbColumnSectionId { get; set; } = "";
    public string MbColumnSectionName { get; set; } = "";

    public EtabsImportedObjectType ObjectType { get; set; }
    public MbColumnForceSourceMode ForceSource { get; set; }

    public List<EtabsColumnObjectKey> ColumnObjects { get; set; } = [];
    public List<EtabsPierObjectKey> PierObjects { get; set; } = [];
    public List<string> LoadCombinations { get; set; } = [];
    public List<string> Locations { get; set; } = [];

    public EtabsModelFingerprint SourceModel { get; set; } = new();
}
