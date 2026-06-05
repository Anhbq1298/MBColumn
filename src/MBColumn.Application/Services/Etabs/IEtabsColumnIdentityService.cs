using MBColumn.Application.DTOs.Etabs.Identity;

namespace MBColumn.Application.Services.Etabs;

/// <summary>
/// Builds and matches geometry-based identities for ETABS column objects.
/// The permanent identity is a GUID derived from normalized endpoint coordinates,
/// not from ETABS object names or UniqueNames.
/// </summary>
public interface IEtabsColumnIdentityService
{
    /// <summary>
    /// Reads all column objects in the current ETABS model and returns their
    /// current geometry records with computed <see cref="EtabsColumnGeometryRecord.GeometrySignature"/>.
    /// </summary>
    IReadOnlyList<EtabsColumnGeometryRecord> GetCurrentGeometryRecords(double coordinateTolerance = 0.001);

    /// <summary>
    /// Builds an <see cref="MbColumnIdentity"/> from an ETABS frame object by reading
    /// its endpoint coordinates and generating a deterministic GUID.
    /// </summary>
    MbColumnIdentity BuildIdentity(
        string etabsName,
        string uniqueName,
        string columnLabel,
        string story,
        double coordinateTolerance = 0.001);

    /// <summary>
    /// Matches the stored <paramref name="identity"/> against the current ETABS geometry index.
    /// Returns the single matching record, or null with a reason ("Unmatched" / "Ambiguous").
    /// </summary>
    (EtabsColumnGeometryRecord? Match, string Status) FindMatch(
        MbColumnIdentity identity,
        IReadOnlyList<EtabsColumnGeometryRecord> currentGeometry);

    /// <summary>
    /// Builds a normalized geometry signature string from rounded coordinates.
    /// Format: "Column|{XBot:F6}|{YBot:F6}|{ZBot:F6}|{XTop:F6}|{YTop:F6}|{ZTop:F6}"
    /// </summary>
    string BuildGeometrySignature(
        double xBot, double yBot, double zBot,
        double xTop, double yTop, double zTop,
        double tolerance = 0.001);

    /// <summary>
    /// Generates a deterministic <see cref="Guid"/> from a geometry signature string.
    /// </summary>
    Guid BuildGuidFromSignature(string geometrySignature);
}
