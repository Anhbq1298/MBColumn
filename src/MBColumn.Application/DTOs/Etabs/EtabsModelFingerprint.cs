namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsModelFingerprint
{
    public string ModelFilePath { get; set; } = "";
    public string ModelFileName { get; set; } = "";
    public DateTime ImportedAt { get; set; }
}
