namespace MBColumn.Application.DTOs.Etabs.Identity;

/// <summary>
/// Stable identity record for an MB Column object.
/// The permanent key is <see cref="MBColumnGuid"/>, derived from normalized
/// endpoint coordinates so it survives ETABS renames, re-meshes, and model transfers.
/// The LastKnown* fields are cached metadata only — not used for matching.
/// </summary>
public sealed class MbColumnIdentity
{
    /// <summary>
    /// Deterministic GUID generated from the normalized geometry signature.
    /// This is the permanent identity of the MB Column object.
    /// </summary>
    public Guid MBColumnGuid { get; set; }

    public string ObjectType { get; set; } = "Column";

    // Cached ETABS metadata — updated on each successful match but not used as the key.
    public string LastKnownEtabsName    { get; set; } = string.Empty;
    public string LastKnownUniqueName   { get; set; } = string.Empty;
    public string LastKnownColumnLabel  { get; set; } = string.Empty;
    public string LastKnownStory        { get; set; } = string.Empty;

    // Normalized endpoint coordinates in model length units (rounded to CoordinateTolerance).
    public double XBot { get; set; }
    public double YBot { get; set; }
    public double ZBot { get; set; }
    public double XTop { get; set; }
    public double YTop { get; set; }
    public double ZTop { get; set; }

    /// <summary>
    /// Hash key: "Column|{XBot}|{YBot}|{ZBot}|{XTop}|{YTop}|{ZTop}"
    /// with coordinates rounded to <see cref="CoordinateTolerance"/>.
    /// </summary>
    public string GeometrySignature { get; set; } = string.Empty;

    /// <summary>Tolerance used when rounding coordinates to build the signature (model units).</summary>
    public double CoordinateTolerance { get; set; } = 0.001;
}
