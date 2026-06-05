using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using static System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceMapper : IEtabsForceMapper
{
    public IReadOnlyList<MbColumnMappedForceRow> MapColumnForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem)
        => MergeForces(sectionName, forces, forceSource, EtabsImportedObjectType.Column,
                       f => f.Label);

    public IReadOnlyList<MbColumnMappedForceRow> MapPierForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        UnitSystem unitSystem)
        => MergeForces(sectionName, forces, forceSource, EtabsImportedObjectType.Pier,
                       f => string.IsNullOrWhiteSpace(f.PierName) ? f.Label : f.PierName);

    public IReadOnlyList<SnapshotLoadCase> ToLoadCases(IReadOnlyList<MbColumnMappedForceRow> rows)
    {
        return rows.Select((r, i) =>
        {
            // Sign-preserving max-abs: keep the end moment whose magnitude is larger
            double mxUsed = Abs(r.MxTop) >= Abs(r.MxBottom) ? r.MxTop : r.MxBottom;
            double myUsed = Abs(r.MyTop) >= Abs(r.MyBottom) ? r.MyTop : r.MyBottom;

            return new SnapshotLoadCase
            {
                Id                   = $"etabs_{i + 1}",
                Label                = $"{r.CaseName}-{r.Label}-{r.Story}",
                OriginalLoadCaseName = r.CaseName,
                SourceObjectName     = r.Label,
                SourceObjectLabel    = r.Label,
                Story                = r.Story,
                Station              = string.Empty,
                Source               = "ETABS",
                Pu                   = r.NEd,
                Mux                  = mxUsed,
                Muy                  = myUsed,
                Vux                  = r.Vx,
                Vuy                  = r.Vy,
                MxTop                = r.MxTop,
                MxBottom             = r.MxBottom,
                MyTop                = r.MyTop,
                MyBottom             = r.MyBottom,
                MxUsed               = mxUsed,
                MyUsed               = myUsed,
                IsActive             = true
            };
        }).ToList();
    }

    // -------------------------------------------------------------------------

    private static IReadOnlyList<MbColumnMappedForceRow> MergeForces(
        string sectionName,
        IReadOnlyList<EtabsForceResultDto> forces,
        MbColumnForceSourceMode forceSource,
        EtabsImportedObjectType objectType,
        Func<EtabsForceResultDto, string> labelSelector)
    {
        var rows = new List<MbColumnMappedForceRow>();

        var groups = forces.GroupBy(
            f => $"{f.StoryName}|{labelSelector(f)}|{f.LoadCombination}",
            StringComparer.OrdinalIgnoreCase);

        foreach (var group in groups)
        {
            var bot  = group.FirstOrDefault(f => f.Station.Equals("Bottom", StringComparison.OrdinalIgnoreCase));
            var top  = group.FirstOrDefault(f => f.Station.Equals("Top",    StringComparison.OrdinalIgnoreCase));
            var ref_ = bot ?? top ?? group.First();
            var lbl  = labelSelector(ref_);

            double nedBot = MapAxialForce(bot?.P ?? top!.P, forceSource);
            double nedTop = MapAxialForce(top?.P ?? bot!.P, forceSource);

            rows.Add(new MbColumnMappedForceRow
            {
                MbColumnSectionName = sectionName,
                CaseName   = ref_.LoadCombination,
                ObjectType = objectType,
                Story      = ref_.StoryName,
                Label      = lbl,
                NEd        = Min(nedBot, nedTop),
                Vx         = Max(Abs(bot?.V2 ?? 0), Abs(top?.V2 ?? 0)),
                Vy         = Max(Abs(bot?.V3 ?? 0), Abs(top?.V3 ?? 0)),
                MxTop      = top?.M2 ?? bot!.M2,
                MxBottom   = bot?.M2 ?? top!.M2,
                MyTop      = top?.M3 ?? bot!.M3,
                MyBottom   = bot?.M3 ?? top!.M3
            });
        }

        return rows;
    }

    private static double MapAxialForce(double etabsP, MbColumnForceSourceMode forceSource)
        => forceSource switch
        {
            MbColumnForceSourceMode.DesignForces  => etabsP,
            MbColumnForceSourceMode.ElementForces => -etabsP,
            _ => throw new InvalidOperationException($"Unsupported force source: {forceSource}")
        };
}
