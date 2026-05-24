namespace MBColumn.Application.DTOs.Etabs;

public sealed class MbColumnSectionImportItem
{
    public EtabsImportedObjectType ObjectType { get; set; }
    public string Story { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;

    public string Key => $"{ObjectType}|{Story}|{Label}";
    public string ForceLookupKey => $"{Story}|{Label}";
}
