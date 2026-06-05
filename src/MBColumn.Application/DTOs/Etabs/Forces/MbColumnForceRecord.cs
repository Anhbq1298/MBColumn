namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// MB Column-ready force row with convention-mapped values and a geometry-based identity GUID.
/// Force convention:
///   NEd  = -P   (positive = compression, negative = tension)
///   Vx   = V2   (V2 + M3 are one shear/moment pair)
///   Vy   = V3   (V3 + M2 are one shear/moment pair)
///   Mx   = M2
///   My   = M3
/// </summary>
public sealed class MbColumnForceRecord
{
    /// <summary>Generated MB Column load case name: {OutputCase}-{Label}-{Story}-Bottom/Top</summary>
    public string MBCLCNName { get; set; } = string.Empty;

    /// <summary>
    /// Stable geometry-based GUID assigned when the ETABS column is matched to an MB Column record.
    /// Empty when the record has not yet been matched.
    /// </summary>
    public Guid MBColumnGuid { get; set; }

    public string Story       { get; set; } = string.Empty;
    public string ColumnLabel { get; set; } = string.Empty;
    public string UniqueName  { get; set; } = string.Empty;

    public string OriginalOutputCase { get; set; } = string.Empty;
    /// <summary>Bottom or Top</summary>
    public string EndLocation { get; set; } = string.Empty;

    public double Station { get; set; }

    // MB Column convention (all in target unit system)
    /// <summary>Axial force. Positive = compression, negative = tension.</summary>
    public double NEd { get; set; }
    public double Vx  { get; set; }
    public double Vy  { get; set; }
    public double Mx  { get; set; }
    public double My  { get; set; }
    public double T   { get; set; }

    public EtabsForceSourceType SourceType { get; set; }
    public EtabsForceObjectType ObjectType { get; set; }

    /// <summary>Unmatched / Matched / Ambiguous — set during GUID-matching refresh.</summary>
    public string MatchStatus { get; set; } = string.Empty;
}
