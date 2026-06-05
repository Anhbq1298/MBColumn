using MBColumn.Application.DTOs.Etabs;
using SMath = System.Math;

namespace MBColumn.Application.Services.Etabs;

public sealed class EtabsSectionForceFilterService : IEtabsSectionForceFilterService
{
    public IReadOnlyList<MbColumnMappedForceRow> FilterForcesForSection(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows,
        EtabsImportedObjectType objectType)
    {
        if (section.SelectedItems.Count == 0 || allForceRows.Count == 0)
            return [];

        var selectedKeys = section.SelectedItems
            .ToLookup(item => item.ForceLookupKey, StringComparer.OrdinalIgnoreCase);

        // Collect matching rows keyed by (story|label|combo) → (Bottom, Top)
        var groups = new Dictionary<string, (EtabsForceResultDto? Bottom, EtabsForceResultDto? Top)>(
            StringComparer.OrdinalIgnoreCase);

        foreach (var row in allForceRows)
        {
            var lookupKey = $"{row.StoryName}|{row.Label}";
            if (!selectedKeys.Contains(lookupKey)) continue;

            var groupKey = $"{row.StoryName}|{row.Label}|{row.LoadCombination}";
            groups.TryGetValue(groupKey, out var pair);

            if (string.Equals(row.Station, "Bottom", StringComparison.OrdinalIgnoreCase))
                groups[groupKey] = (row, pair.Top);
            else if (string.Equals(row.Station, "Top", StringComparison.OrdinalIgnoreCase))
                groups[groupKey] = (pair.Bottom, row);
            // rows that are neither Bottom nor Top (already filtered upstream) are ignored
        }

        var results = new List<MbColumnMappedForceRow>(groups.Count);

        foreach (var (_, pair) in groups)
        {
            var bot = pair.Bottom;
            var top = pair.Top;
            var ref_ = bot ?? top;
            if (ref_ is null) continue;

            // NEd = min(bottom, top) — positive = compression
            double nedBot = bot?.P ?? top!.P;
            double nedTop = top?.P ?? bot!.P;
            double ned = SMath.Min(nedBot, nedTop);

            // Vx/Vy = max absolute value between stations
            double vx = SMath.Max(SMath.Abs(bot?.V2 ?? 0), SMath.Abs(top?.V2 ?? 0));
            double vy = SMath.Max(SMath.Abs(bot?.V3 ?? 0), SMath.Abs(top?.V3 ?? 0));

            // Moments kept per end
            double mxBot = bot?.M2 ?? top!.M2;
            double mxTop = top?.M2 ?? bot!.M2;
            double myBot = bot?.M3 ?? top!.M3;
            double myTop = top?.M3 ?? bot!.M3;

            double mxUsed = SMath.Abs(mxTop) >= SMath.Abs(mxBot) ? mxTop : mxBot;
            double myUsed = SMath.Abs(myTop) >= SMath.Abs(myBot) ? myTop : myBot;

            results.Add(new MbColumnMappedForceRow
            {
                MbColumnSectionName = section.SectionName,
                CaseName   = ref_.LoadCombination,
                ObjectType = objectType,
                Story      = ref_.StoryName,
                Label      = ref_.Label,
                NEd        = SMath.Round(ned, 3),
                Vx         = SMath.Round(vx, 3),
                Vy         = SMath.Round(vy, 3),
                MxTop      = SMath.Round(mxTop, 3),
                MxBottom   = SMath.Round(mxBot, 3),
                MyTop      = SMath.Round(myTop, 3),
                MyBottom   = SMath.Round(myBot, 3),
                MxUsed     = SMath.Round(mxUsed, 3),
                MyUsed     = SMath.Round(myUsed, 3)
            });
        }

        return results;
    }

    public IReadOnlyList<MbColumnSectionImportItem> FindMissingItems(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows)
    {
        if (section.SelectedItems.Count == 0) return [];

        var foundKeys = allForceRows
            .Select(r => $"{r.StoryName}|{r.Label}")
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return section.SelectedItems
            .Where(item => !foundKeys.Contains(item.ForceLookupKey))
            .ToList();
    }
}
