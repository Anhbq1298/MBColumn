namespace MBColumn.Application.DTOs.Etabs;

public enum EtabsForceRowChangeStatus
{
    Unchanged,
    Changed,
    Added,
    Removed
}

public sealed class EtabsForceRowChange
{
    public string LoadCaseName { get; set; } = "";
    public string Location { get; set; } = "";
    public double? OldP { get; set; }
    public double? NewP { get; set; }
    public double? OldMx { get; set; }
    public double? NewMx { get; set; }
    public double? OldMy { get; set; }
    public double? NewMy { get; set; }
    public EtabsForceRowChangeStatus Status { get; set; }

    public double DeltaP => (NewP ?? 0) - (OldP ?? 0);
    public double DeltaMx => (NewMx ?? 0) - (OldMx ?? 0);
    public double DeltaMy => (NewMy ?? 0) - (OldMy ?? 0);
}
