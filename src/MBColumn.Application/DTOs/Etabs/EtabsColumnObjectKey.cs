namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsColumnObjectKey
{
    public string Story { get; set; } = "";
    public string Label { get; set; } = "";
    public string UniqueName { get; set; } = "";
    public double X { get; set; }
    public double Y { get; set; }

    public string Key => $"{Story}-{Label}";
}
