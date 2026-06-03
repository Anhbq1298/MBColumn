namespace MBColumn.Application.DTOs.Etabs;

public sealed class MbColumnMappedForceRow
{
    public string MbColumnSectionName { get; set; } = string.Empty;
    public string LoadCaseName { get; set; } = string.Empty;
    public EtabsImportedObjectType ObjectType { get; set; }
    public string Story { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string LoadCombo { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double P { get; set; }
    public double Vx { get; set; }
    public double Vy { get; set; }
    public double Mx { get; set; }
    public double My { get; set; }
}
