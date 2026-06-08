using MBColumn.Application.DTOs.Etabs.AutoGrouping;

namespace MBColumn.Application.Services.Etabs;

public sealed class StoryTierResolver
{
    private readonly Dictionary<string, AutoGroupingStory> storyByName;
    private readonly List<TierRange> ranges;

    public StoryTierResolver(
        IReadOnlyList<AutoGroupingStory> stories,
        IReadOnlyList<AutoGroupingTier> tiers)
    {
        storyByName = stories
            .GroupBy(s => s.Name, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.OrderBy(s => s.SortIndex).First(), StringComparer.OrdinalIgnoreCase);

        ranges = [];
        for (var i = 0; i < tiers.Count; i++)
        {
            var tier = tiers[i];
            if (!TryGetStoryIndex(tier.FromStory, out var fromIndex)
                || !TryGetStoryIndex(tier.ToStory, out var toIndex))
            {
                continue;
            }

            var start = Math.Min(fromIndex, toIndex);
            var end = Math.Max(fromIndex, toIndex);
            ranges.Add(new TierRange(tier, i, start, end));
        }
    }

    public IReadOnlyList<TierRange> Ranges => ranges;

    public bool TryGetStoryIndex(string storyName, out int sortIndex)
    {
        if (!string.IsNullOrWhiteSpace(storyName)
            && storyByName.TryGetValue(storyName.Trim(), out var story))
        {
            sortIndex = story.SortIndex;
            return true;
        }

        sortIndex = -1;
        return false;
    }

    public TierRange? ResolveFirstTier(string storyName)
    {
        if (!TryGetStoryIndex(storyName, out var storyIndex))
            return null;

        return ranges
            .OrderBy(r => r.TierOrder)
            .FirstOrDefault(r => r.Contains(storyIndex));
    }

    public bool IsCovered(string storyName)
        => ResolveFirstTier(storyName) is not null;

    public IReadOnlyList<(string StoryName, IReadOnlyList<AutoGroupingTier> Tiers)> FindOverlaps(
        IEnumerable<string> storyNames)
    {
        var result = new List<(string, IReadOnlyList<AutoGroupingTier>)>();

        foreach (var storyName in storyNames.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            if (!TryGetStoryIndex(storyName, out var storyIndex))
                continue;

            var matched = ranges
                .Where(r => r.Contains(storyIndex))
                .OrderBy(r => r.TierOrder)
                .Select(r => r.Tier)
                .ToList();

            if (matched.Count > 1)
                result.Add((storyName, matched));
        }

        return result;
    }

    public sealed record TierRange(AutoGroupingTier Tier, int TierOrder, int StartIndex, int EndIndex)
    {
        public bool Contains(int storyIndex) => storyIndex >= StartIndex && storyIndex <= EndIndex;
    }
}
