namespace MBColumn.Application.DTOs.Etabs;

/// <summary>
/// One merged row per (section, combo) in the Force Preview grid.
/// Bottom and Top stations are collapsed into a single row:
///   NEd  = min(NEd_bottom, NEd_top)          — positive = compression
///   Vx   = max(|Vx_bottom|, |Vx_top|)
///   Vy   = max(|Vy_bottom|, |Vy_top|)
///   Mx/MyTop/Bottom kept separate for slenderness / end-moment checks.
/// </summary>
public sealed class MbColumnMappedForceRow
{
    public string MbColumnSectionName { get; set; } = string.Empty;
    /// <summary>Output case / combo name only (no label/story/location suffix).</summary>
    public string CaseName { get; set; } = string.Empty;
    public EtabsImportedObjectType ObjectType { get; set; }
    public string Story { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;

    /// <summary>Positive = compression, negative = tension.</summary>
    public double NEd { get; set; }
    public double Vx { get; set; }
    public double Vy { get; set; }

    public double MxTop    { get; set; }
    public double MxBottom { get; set; }
    public double MyTop    { get; set; }
    public double MyBottom { get; set; }

    /// <summary>Governing Mx end moment: the value whose absolute magnitude is larger, sign preserved.</summary>
    public double MxUsed { get; set; }
    /// <summary>Governing My end moment: the value whose absolute magnitude is larger, sign preserved.</summary>
    public double MyUsed { get; set; }
}
