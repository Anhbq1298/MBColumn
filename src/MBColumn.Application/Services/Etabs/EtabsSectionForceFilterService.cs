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
            return [];

        var selectedKeys = section.SelectedItems
            .ToLookup(
                item => item.ForceLookupKey,
                StringComparer.OrdinalIgnoreCase);

        var results = new List<MbColumnMappedForceRow>();

        foreach (var forceRow in allForceRows)
        {
            var lookupKey = $"{forceRow.StoryName}|{forceRow.Label}";
            if (!selectedKeys.Contains(lookupKey)) continue;

            var (mx, my) = MapEtabsMomentsToMbColumn(forceRow.M2, forceRow.M3);

            results.Add(new MbColumnMappedForceRow
            {
                MbColumnSectionName = section.SectionName,
                LoadCaseName        = BuildLoadCaseName(forceRow.LoadCombination, forceRow.StoryName, forceRow.Label, forceRow.Station),
                ObjectType          = objectType,
                Story               = forceRow.StoryName,
                Label               = forceRow.Label,
                LoadCombo           = forceRow.LoadCombination,
                Location            = forceRow.Station,
                P                   = forceRow.P,
                Mx                  = mx,
                My                  = my
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

    private static string BuildLoadCaseName(string loadCombo, string story, string label, string location)
    {
        var raw = $"{loadCombo}_{story}_{label}_{location}";
        return raw
            .Replace(" ", "")
            .Replace("/", "_")
            .Replace("\\", "_")
            .Replace(":", "_")
            .Replace(";", "_");
    }

    private static (double Mx, double My) MapEtabsMomentsToMbColumn(double m2, double m3)
    {
        // Default: M2 → Mx, M3 → My (confirm axis convention with project team if needed)
        return (m2, m3);
    }
}
