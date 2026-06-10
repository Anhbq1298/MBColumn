using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public sealed class EtabsSectionForceFilterService : IEtabsSectionForceFilterService
{
    public IReadOnlyList<MbColumnMappedForceRow> FilterForcesForSection(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows,
        EtabsImportedObjectType objectType)
    {
        if (section.SelectedItems.Count == 0 || allForceRows.Count == 0)
        {
            return [];
        }

        var selectedKeys = section.SelectedItems
            .ToLookup(item => item.ForceLookupKey, StringComparer.OrdinalIgnoreCase);

        var groups = new Dictionary<string, (EtabsForceResultDto? Bottom, EtabsForceResultDto? Top)>(
            StringComparer.OrdinalIgnoreCase);

        foreach (var row in allForceRows)
        {
            var lookupKey = $"{row.StoryName}|{row.Label}";
            if (!selectedKeys.Contains(lookupKey))
            {
                continue;
            }

            var groupKey = $"{row.StoryName}|{row.Label}|{row.LoadCombination}";
            groups.TryGetValue(groupKey, out var pair);

            if (string.Equals(row.Station, "Bottom", StringComparison.OrdinalIgnoreCase))
            {
                groups[groupKey] = (row, pair.Top);
            }
            else if (string.Equals(row.Station, "Top", StringComparison.OrdinalIgnoreCase))
            {
                groups[groupKey] = (pair.Bottom, row);
            }
        }

        var results = new List<MbColumnMappedForceRow>(groups.Count);

        foreach (var (_, pair) in groups)
        {
            var bot = pair.Bottom;
            var top = pair.Top;
            var ref_ = bot ?? top;
            if (ref_ is null)
            {
                continue;
            }

            results.Add(EtabsToMbColumnForceMapper.MapStationPair(
                section.SectionName,
                objectType,
                ref_.LoadCombination,
                ref_.StoryName,
                ref_.Label,
                bot,
                top,
                round: true));
        }

        return results;
    }

    public IReadOnlyList<MbColumnSectionImportItem> FindMissingItems(
        MbColumnSectionImport section,
        IReadOnlyList<EtabsForceResultDto> allForceRows)
    {
        if (section.SelectedItems.Count == 0)
        {
            return [];
        }

        var foundKeys = allForceRows
            .Select(r => $"{r.StoryName}|{r.Label}")
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return section.SelectedItems
            .Where(item => !foundKeys.Contains(item.ForceLookupKey))
            .ToList();
    }
}
