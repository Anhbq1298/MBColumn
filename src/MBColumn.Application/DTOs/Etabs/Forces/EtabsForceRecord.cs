namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// Normalized ETABS force row produced after reading a cDatabaseTables table and
/// mapping source column names to a common schema.
/// Raw ETABS values — no MB Column convention applied yet.
/// P negative = compression in ETABS convention.
/// </summary>
public sealed class EtabsForceRecord
{
    public EtabsForceSourceType SourceType { get; set; }
    public EtabsForceObjectType ObjectType { get; set; }

    public string Story       { get; set; } = string.Empty;
    public string Label       { get; set; } = string.Empty;
    public string UniqueName  { get; set; } = string.Empty;
    public string OutputCase  { get; set; } = string.Empty;
    public string CaseType    { get; set; } = string.Empty;
    public string StepType    { get; set; } = string.Empty;

    /// <summary>Numeric station value in model length units as read from ETABS.</summary>
    public double Station { get; set; }

    // Raw ETABS force values (model units, not converted)
    public double P  { get; set; }
    public double V2 { get; set; }
    public double V3 { get; set; }
    public double T  { get; set; }
    public double M2 { get; set; }
    public double M3 { get; set; }
}
