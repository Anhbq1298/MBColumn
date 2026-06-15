using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Etabs.Forces;
using SMath = System.Math;

namespace MBColumn.Application.Services.Etabs;

/// <summary>
/// Single ETABS-to-MBColumn force convention mapper.
/// MBColumn X is ETABS local 2, and MBColumn Y is ETABS local 3.
/// Therefore Mx = ETABS M2 and My = ETABS M3. This is axis-based;
/// shear-flexure design pairs remain Vx/V2 with My/M3 and Vy/V3 with Mx/M2.
/// </summary>
public static class EtabsToMbColumnForceMapper
{
    public static double RawEtabsPToNEd(double etabsP) => -etabsP;
    public static double RawEtabsV2ToVx(double etabsV2) => etabsV2;
    public static double RawEtabsV3ToVy(double etabsV3) => etabsV3;
    public static double RawEtabsM2ToMx(double etabsM2) => etabsM2;
    public static double RawEtabsM3ToMy(double etabsM3) => etabsM3;

    /// <summary>
    /// EtabsForceResultDto.P is already converted to MBColumn compression-positive
    /// by ETABS extraction services. Use this to avoid double-converting axial force.
    /// </summary>
    public static double ImportedResultPToNEd(double importedResultP) => importedResultP;

    public static MbColumnMappedForceRow MapStationPair(
        string sectionName,
        EtabsImportedObjectType objectType,
        string caseName,
        string story,
        string label,
        EtabsForceResultDto? bottom,
        EtabsForceResultDto? top,
        bool round = false)
    {
        if (bottom is null && top is null)
        {
            throw new ArgumentException("At least one ETABS station force row is required.");
        }

        var ref_ = bottom ?? top!;
        double nedBot = ImportedResultPToNEd(bottom?.P ?? top!.P);
        double nedTop = ImportedResultPToNEd(top?.P ?? bottom!.P);

        double mxTop = RawEtabsM2ToMx(top?.M2 ?? bottom!.M2);
        double mxBottom = RawEtabsM2ToMx(bottom?.M2 ?? top!.M2);
        double myTop = RawEtabsM3ToMy(top?.M3 ?? bottom!.M3);
        double myBottom = RawEtabsM3ToMy(bottom?.M3 ?? top!.M3);

        double vx = SMath.Max(
            SMath.Abs(RawEtabsV2ToVx(bottom?.V2 ?? 0.0)),
            SMath.Abs(RawEtabsV2ToVx(top?.V2 ?? 0.0)));
        double vy = SMath.Max(
            SMath.Abs(RawEtabsV3ToVy(bottom?.V3 ?? 0.0)),
            SMath.Abs(RawEtabsV3ToVy(top?.V3 ?? 0.0)));

        double mxUsed = SMath.Abs(mxTop) >= SMath.Abs(mxBottom) ? mxTop : mxBottom;
        double myUsed = SMath.Abs(myTop) >= SMath.Abs(myBottom) ? myTop : myBottom;

        var row = new MbColumnMappedForceRow
        {
            MbColumnSectionName = sectionName,
            CaseName = caseName,
            ObjectType = objectType,
            Story = story,
            Label = label,
            SourceObjectName = string.IsNullOrWhiteSpace(ref_.ObjectName) ? label : ref_.ObjectName,
            ForceStation = BuildStationText(bottom, top),
            NEd = SMath.Min(nedBot, nedTop),
            Vx = vx,
            Vy = vy,
            MxTop = mxTop,
            MxBottom = mxBottom,
            MyTop = myTop,
            MyBottom = myBottom,
            MxUsed = mxUsed,
            MyUsed = myUsed
        };

        return round ? Round(row) : row;
    }

    private static string BuildStationText(EtabsForceResultDto? bottom, EtabsForceResultDto? top)
    {
        var bottomStation = bottom?.Station?.Trim() ?? "";
        var topStation = top?.Station?.Trim() ?? "";

        if (bottom is not null && top is not null)
            return string.Equals(bottomStation, topStation, StringComparison.OrdinalIgnoreCase)
                ? bottomStation
                : $"{bottomStation}/{topStation}".Trim('/');

        return string.IsNullOrWhiteSpace(bottomStation) ? topStation : bottomStation;
    }

    public static MbColumnForceRecord MapRawEtabsRecord(
        EtabsForceRecord source,
        string loadCaseName,
        string location,
        double forceFactor,
        double momentFactor)
        => new()
        {
            MBCLCNName = loadCaseName,
            Story = source.Story,
            ColumnLabel = source.Label,
            UniqueName = source.UniqueName,
            OriginalOutputCase = source.OutputCase,
            EndLocation = location,
            Station = source.Station,
            NEd = SMath.Round(RawEtabsPToNEd(source.P) * forceFactor, 3),
            Vx = SMath.Round(RawEtabsV2ToVx(source.V2) * forceFactor, 3),
            Vy = SMath.Round(RawEtabsV3ToVy(source.V3) * forceFactor, 3),
            Mx = SMath.Round(RawEtabsM2ToMx(source.M2) * momentFactor, 3),
            My = SMath.Round(RawEtabsM3ToMy(source.M3) * momentFactor, 3),
            T = SMath.Round(source.T * momentFactor, 3),
            SourceType = source.SourceType,
            ObjectType = source.ObjectType,
            MatchStatus = string.Empty
        };

    private static MbColumnMappedForceRow Round(MbColumnMappedForceRow row)
    {
        row.NEd = SMath.Round(row.NEd, 3);
        row.Vx = SMath.Round(row.Vx, 3);
        row.Vy = SMath.Round(row.Vy, 3);
        row.MxTop = SMath.Round(row.MxTop, 3);
        row.MxBottom = SMath.Round(row.MxBottom, 3);
        row.MyTop = SMath.Round(row.MyTop, 3);
        row.MyBottom = SMath.Round(row.MyBottom, 3);
        row.MxUsed = SMath.Round(row.MxUsed, 3);
        row.MyUsed = SMath.Round(row.MyUsed, 3);
        return row;
    }
}
