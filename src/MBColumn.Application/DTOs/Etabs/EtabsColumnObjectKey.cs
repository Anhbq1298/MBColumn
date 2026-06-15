namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsColumnObjectKey
{
    public string Story { get; set; } = "";
    public string Label { get; set; } = "";
    public string UniqueName { get; set; } = "";
    public double X { get; set; }
    public double Y { get; set; }
    public double BottomX { get; set; }
    public double BottomY { get; set; }
    public double TopX { get; set; }
    public double TopY { get; set; }
    public string SectionPropertyName { get; set; } = "";

    public string Key => !string.IsNullOrWhiteSpace(UniqueName)
        ? UniqueName
        : $"{Story}-{Label}";
}
