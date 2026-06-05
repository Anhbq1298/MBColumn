using ETABSv1;
using MBColumn.Application.DTOs.Etabs.Identity;
using MBColumn.Application.Services.Etabs;
using System.Security.Cryptography;
using System.Text;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Etabs;

/// <summary>
/// Builds and matches geometry-based identities for ETABS column objects.
///
/// The permanent identity is a deterministic GUID derived from normalized endpoint
/// coordinates (XBot/YBot/ZBot/XTop/YTop/ZTop), so it survives ETABS renames,
/// re-meshes, and model transfers.
///
/// XY + ZBot + ZTop is used instead of XY-only because columns from different
/// stories share the same XY footprint.
/// </summary>
public sealed class EtabsColumnIdentityService : IEtabsColumnIdentityService
{
    private readonly EtabsConnectionService connection;

    public EtabsColumnIdentityService(EtabsConnectionService connection)
    {
        this.connection = connection;
    }

    // -------------------------------------------------------------------------
    // Public API
    // -------------------------------------------------------------------------

    public IReadOnlyList<EtabsColumnGeometryRecord> GetCurrentGeometryRecords(
        double coordinateTolerance = 0.001)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        int count         = 0;
        string[] names    = [];
        string[] labels   = [];
        string[] stories  = [];
        model.FrameObj.GetLabelNameList(ref count, ref names, ref labels, ref stories);

        var records = new List<EtabsColumnGeometryRecord>(count);

        for (var i = 0; i < count; i++)
        {
            var orientation = eFrameDesignOrientation.Null;
            if (model.FrameObj.GetDesignOrientation(names[i], ref orientation) != 0
                || orientation != eFrameDesignOrientation.Column)
                continue;

            if (!TryGetEndpoints(model, names[i], out var xBot, out var yBot, out var zBot,
                                                    out var xTop, out var yTop, out var zTop))
                continue;

            // Ensure bottom is the lower Z endpoint
            EnsureBottomIsLower(
                ref xBot, ref yBot, ref zBot,
                ref xTop, ref yTop, ref zTop);

            var sig = BuildGeometrySignature(xBot, yBot, zBot, xTop, yTop, zTop, coordinateTolerance);

            records.Add(new EtabsColumnGeometryRecord
            {
                CurrentEtabsName   = names[i],
                // ETABS frame object name is the canonical unique ID within the model.
                // UniqueName from database tables is kept in sync with this via LastKnown* fields.
                CurrentUniqueName  = names[i],
                CurrentColumnLabel = labels[i] ?? "",
                CurrentStory       = stories[i] ?? "",
                XBot = Snap(xBot, coordinateTolerance),
                YBot = Snap(yBot, coordinateTolerance),
                ZBot = Snap(zBot, coordinateTolerance),
                XTop = Snap(xTop, coordinateTolerance),
                YTop = Snap(yTop, coordinateTolerance),
                ZTop = Snap(zTop, coordinateTolerance),
                GeometrySignature = sig
            });
        }

        return records;
    }

    public MbColumnIdentity BuildIdentity(
        string etabsName,
        string uniqueName,
        string columnLabel,
        string story,
        double coordinateTolerance = 0.001)
    {
        var model = connection.Model
            ?? throw new InvalidOperationException("Not connected to ETABS.");

        if (!TryGetEndpoints(model, etabsName, out var xBot, out var yBot, out var zBot,
                                                out var xTop, out var yTop, out var zTop))
            throw new InvalidOperationException($"Could not read endpoints for ETABS object '{etabsName}'.");

        EnsureBottomIsLower(ref xBot, ref yBot, ref zBot, ref xTop, ref yTop, ref zTop);

        var sig  = BuildGeometrySignature(xBot, yBot, zBot, xTop, yTop, zTop, coordinateTolerance);
        var guid = BuildGuidFromSignature(sig);

        return new MbColumnIdentity
        {
            MBColumnGuid           = guid,
            ObjectType             = "Column",
            LastKnownEtabsName     = etabsName,
            LastKnownUniqueName    = uniqueName,
            LastKnownColumnLabel   = columnLabel,
            LastKnownStory         = story,
            XBot = Snap(xBot, coordinateTolerance),
            YBot = Snap(yBot, coordinateTolerance),
            ZBot = Snap(zBot, coordinateTolerance),
            XTop = Snap(xTop, coordinateTolerance),
            YTop = Snap(yTop, coordinateTolerance),
            ZTop = Snap(zTop, coordinateTolerance),
            GeometrySignature  = sig,
            CoordinateTolerance = coordinateTolerance
        };
    }

    public (EtabsColumnGeometryRecord? Match, string Status) FindMatch(
        MbColumnIdentity identity,
        IReadOnlyList<EtabsColumnGeometryRecord> currentGeometry)
    {
        var matches = currentGeometry
            .Where(g => string.Equals(g.GeometrySignature, identity.GeometrySignature,
                                      StringComparison.OrdinalIgnoreCase))
            .ToList();

        return matches.Count switch
        {
            0 => (null, "Unmatched"),
            1 => (matches[0], "Matched"),
            _ => (null, "Ambiguous")
        };
    }

    public string BuildGeometrySignature(
        double xBot, double yBot, double zBot,
        double xTop, double yTop, double zTop,
        double tolerance = 0.001)
    {
        var xb = Snap(xBot, tolerance);
        var yb = Snap(yBot, tolerance);
        var zb = Snap(zBot, tolerance);
        var xt = Snap(xTop, tolerance);
        var yt = Snap(yTop, tolerance);
        var zt = Snap(zTop, tolerance);

        return FormattableString.Invariant(
            $"Column|{xb:F6}|{yb:F6}|{zb:F6}|{xt:F6}|{yt:F6}|{zt:F6}");
    }

    public Guid BuildGuidFromSignature(string geometrySignature)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(geometrySignature));
        // Use first 16 bytes of SHA-256 as a deterministic GUID
        var guidBytes = new byte[16];
        Array.Copy(bytes, guidBytes, 16);
        // Set version 5 (name-based SHA-1 convention, repurposed for SHA-256 here)
        guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | 0x50);
        guidBytes[8] = (byte)((guidBytes[8] & 0x3F) | 0x80);
        return new Guid(guidBytes);
    }

    // -------------------------------------------------------------------------
    // Private helpers
    // -------------------------------------------------------------------------

    private static bool TryGetEndpoints(
        cSapModel model, string name,
        out double x1, out double y1, out double z1,
        out double x2, out double y2, out double z2)
    {
        x1 = y1 = z1 = x2 = y2 = z2 = 0;
        string p1 = "", p2 = "";
        if (model.FrameObj.GetPoints(name, ref p1, ref p2) != 0) return false;
        model.PointObj.GetCoordCartesian(p1, ref x1, ref y1, ref z1);
        model.PointObj.GetCoordCartesian(p2, ref x2, ref y2, ref z2);
        return true;
    }

    // Ensure the "Bot" endpoint always has the lower Z (standard column orientation).
    private static void EnsureBottomIsLower(
        ref double x1, ref double y1, ref double z1,
        ref double x2, ref double y2, ref double z2)
    {
        if (z1 <= z2) return;
        (x1, x2) = (x2, x1);
        (y1, y2) = (y2, y1);
        (z1, z2) = (z2, z1);
    }

    // Round coordinate to tolerance grid before using in signature.
    private static double Snap(double value, double tolerance)
        => SMath.Round(value / tolerance) * tolerance;
}
