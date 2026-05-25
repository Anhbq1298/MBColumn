namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsPierObjectKey
{
    public string Story { get; set; } = "";
    public string PierName { get; set; } = "";
    public double X1 { get; set; }
    public double Y1 { get; set; }
    public double X2 { get; set; }
    public double Y2 { get; set; }
    public double CenterX { get; set; }
    public double CenterY { get; set; }
    public double Length { get; set; }
    public double AngleDegrees { get; set; }

    public string Key => $"{Story}-{PierName}";
}
