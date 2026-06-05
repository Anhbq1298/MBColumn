namespace MBColumn.Application.DTOs.Etabs.Identity;

/// <summary>
/// Current ETABS column geometry as read live from the model.
/// Used to build a geometry index for matching existing MB Column records
/// by <see cref="MbColumnIdentity.GeometrySignature"/> during force refresh.
/// </summary>
public sealed class EtabsColumnGeometryRecord
{
    public string CurrentEtabsName   { get; set; } = string.Empty;
    public string CurrentUniqueName  { get; set; } = string.Empty;
    public string CurrentColumnLabel { get; set; } = string.Empty;
    public string CurrentStory       { get; set; } = string.Empty;

    // Endpoint coordinates in model length units (rounded to tolerance before building signature).
    public double XBot { get; set; }
    public double YBot { get; set; }
    public double ZBot { get; set; }
    public double XTop { get; set; }
    public double YTop { get; set; }
    public double ZTop { get; set; }

    /// <summary>
    /// Normalized geometry signature matching the format used in <see cref="MbColumnIdentity"/>.
    /// "Column|{XBot}|{YBot}|{ZBot}|{XTop}|{YTop}|{ZTop}"
    /// </summary>
    public string GeometrySignature { get; set; } = string.Empty;
}
