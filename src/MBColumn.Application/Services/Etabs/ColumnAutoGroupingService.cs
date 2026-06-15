using System.Globalization;
using System.Text.RegularExpressions;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public sealed class ColumnAutoGroupingService
{
    private const double XyGroupingToleranceMm = 10.0;
    private const double ShiftedColumnWarningToleranceMm = 10.0;
    private readonly ColumnGroupingValidator validator;

    public ColumnAutoGroupingService(ColumnGroupingValidator? validator = null)
    {
        this.validator = validator ?? new ColumnGroupingValidator();
    }

    public AutoGroupingResult Build(ColumnAutoGroupingRequest request)
    {
        var columns = request.Columns
            .Where(c => c.SectionType != SectionShapeType.Irregular)
            .Where(c => !string.IsNullOrWhiteSpace(c.StoryName))
            .ToList();

        var tiers = request.Tiers
            .Select(t => t.Clone())
            .ToList();

        var resolver = new StoryTierResolver(request.Stories, tiers);
        var result = new AutoGroupingResult();
        result.ValidationMessages.AddRange(validator.ValidateSetup(columns, request.Stories, tiers, resolver));

        if (columns.Count > 0 && columns.Any(c => !c.HasCoordinates))
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningCoordinateFallback));
        }

        AddShiftedColumnWarnings(result, columns);

        if (result.HasErrors)
            return result;

        var tierMatchCounts = tiers.ToDictionary(t => t, _ => 0);
        var matchedColumns = new List<MatchedColumn>();

        foreach (var column in columns)
        {
            var range = resolver.ResolveFirstTier(column.StoryName);
            if (range is null)
                continue;

            var tier = range.Tier;
            if (!LabelFilterMatcher.Matches(column.Label, tier.LabelFilter))
                continue;

            tierMatchCounts[tier]++;
            matchedColumns.Add(new MatchedColumn(column, tier, range.TierOrder));
        }

        AddCoverageMessages(result, columns, tiers, tierMatchCounts, resolver);

        var columnGroups = BuildColumnGroups(matchedColumns);
        var finalGroups = BuildTierAndSectionGroups(result, columnGroups, resolver);

        if (finalGroups.Count == 0)
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Error,
                AutoGroupingResourceKeys.ErrorNoMatchingGroups));
            return result;
        }

        AssignSectionNames(finalGroups, request.ReservedSectionNames);
        result.Groups = finalGroups;
        result.PreviewRows = BuildPreviewRows(finalGroups);
        result.TierSummaryRows = BuildTierSummaryRows(finalGroups);
        return result;
    }

    private static void AddShiftedColumnWarnings(
        AutoGroupingResult result,
        IReadOnlyList<EtabsColumnImportDto> columns)
    {
        foreach (var column in columns)
        {
            if (!column.HasCoordinates)
                continue;

            var shift = Distance(column.BottomXmm, column.BottomYmm, column.TopXmm, column.TopYmm);
            if (shift <= ShiftedColumnWarningToleranceMm)
                continue;

            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningShiftedColumn,
                string.IsNullOrWhiteSpace(column.ObjectName) ? column.Label : column.ObjectName,
                shift));
        }
    }

    private static void AddCoverageMessages(
        AutoGroupingResult result,
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<AutoGroupingTier> tiers,
        IReadOnlyDictionary<AutoGroupingTier, int> tierMatchCounts,
        StoryTierResolver resolver)
    {
        foreach (var tier in tiers)
        {
            if (tierMatchCounts.TryGetValue(tier, out var count) && count > 0)
                continue;

            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningEmptyTier,
                tier.TierName));
        }

        var ungroupedStories = columns
            .Select(c => c.StoryName)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Where(s => !resolver.IsCovered(s))
            .ToList();

        if (ungroupedStories.Count > 0)
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningUngroupedStories,
                string.Join(", ", ungroupedStories)));
        }
    }

    private static IReadOnlyList<ColumnIdentityGroup> BuildColumnGroups(IReadOnlyList<MatchedColumn> columns)
    {
        var buckets = new Dictionary<SpatialBucket, List<ColumnIdentityGroup>>();
        var fallbackGroups = new Dictionary<string, ColumnIdentityGroup>(StringComparer.OrdinalIgnoreCase);
        var groups = new List<ColumnIdentityGroup>();

        foreach (var column in columns)
        {
            if (!column.Column.HasCoordinates)
            {
                var key = BuildFallbackColumnGroupKey(column.Column);
                if (!fallbackGroups.TryGetValue(key, out var fallbackGroup))
                {
                    fallbackGroup = new ColumnIdentityGroup(key, hasCoordinates: false);
                    fallbackGroups[key] = fallbackGroup;
                    groups.Add(fallbackGroup);
                }

                fallbackGroup.Add(column);
                continue;
            }

            var x = column.Column.CenterXmm;
            var y = column.Column.CenterYmm;
            var bucket = SpatialBucket.From(x, y, XyGroupingToleranceMm);

            ColumnIdentityGroup? matchedGroup = null;
            for (var dx = -1; dx <= 1 && matchedGroup is null; dx++)
            {
                for (var dy = -1; dy <= 1 && matchedGroup is null; dy++)
                {
                    var candidateBucket = new SpatialBucket(bucket.X + dx, bucket.Y + dy);
                    if (!buckets.TryGetValue(candidateBucket, out var candidates))
                        continue;

                    matchedGroup = candidates.FirstOrDefault(group =>
                        Distance(group.GroupXmm, group.GroupYmm, x, y) <= XyGroupingToleranceMm);
                }
            }

            if (matchedGroup is null)
            {
                matchedGroup = new ColumnIdentityGroup("", hasCoordinates: true);
                groups.Add(matchedGroup);

                if (!buckets.TryGetValue(bucket, out var bucketGroups))
                {
                    bucketGroups = [];
                    buckets[bucket] = bucketGroups;
                }

                bucketGroups.Add(matchedGroup);
            }

            matchedGroup.Add(column);
        }

        return groups
            .OrderBy(group => group.HasCoordinates ? 0 : 1)
            .ThenBy(group => group.HasCoordinates ? group.GroupXmm : 0)
            .ThenBy(group => group.GroupYmm)
            .ThenBy(group => group.FallbackKey, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static List<AutoGroupedColumnSection> BuildTierAndSectionGroups(
        AutoGroupingResult result,
        IReadOnlyList<ColumnIdentityGroup> columnGroups,
        StoryTierResolver resolver)
    {
        var finalGroups = new List<AutoGroupedColumnSection>();

        for (var groupIndex = 0; groupIndex < columnGroups.Count; groupIndex++)
        {
            var columnGroup = columnGroups[groupIndex];
            var columnGroupId = $"CG-{groupIndex + 1:000}";
            var columnGroupName = columnGroup.HasCoordinates
                ? FormatColumnGroupName(columnGroupId, columnGroup.GroupXmm, columnGroup.GroupYmm)
                : FormatFallbackColumnGroupName(columnGroupId, columnGroup.FallbackKey);

            foreach (var tierGroup in columnGroup.Items
                         .GroupBy(item => item.Tier)
                         .OrderBy(group => group.Min(item => item.TierOrder)))
            {
                var tier = tierGroup.Key;
                var orderedItems = tierGroup
                    .OrderBy(item => StoryIndex(resolver, item.Column.StoryName))
                    .ThenBy(item => item.Column.StoryName, StringComparer.OrdinalIgnoreCase)
                    .ThenBy(item => item.Column.ObjectName, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                var sectionNames = DistinctDisplayValues(orderedItems.Select(item => item.Column.EtabsSectionName));
                var materialNames = DistinctDisplayValues(orderedItems.Select(item => item.Column.MaterialName));
                var splitRuns = SplitBySectionChange(orderedItems);
                var splitBySection = splitRuns.Count > 1;

                if (sectionNames.Count > 1)
                {
                    result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                        AutoGroupingValidationSeverity.Warning,
                        AutoGroupingResourceKeys.WarningMixedSections,
                        tier.TierName,
                        columnGroupName,
                        string.Join(", ", sectionNames)));

                    result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                        AutoGroupingValidationSeverity.Info,
                        AutoGroupingResourceKeys.InfoMixedSectionsSplit,
                        tier.TierName,
                        columnGroupName));
                }

                if (materialNames.Count > 1)
                {
                    result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                        AutoGroupingValidationSeverity.Warning,
                        AutoGroupingResourceKeys.WarningMixedMaterials,
                        tier.TierName,
                        columnGroupName,
                        string.Join(", ", materialNames)));
                }

                for (var runIndex = 0; runIndex < splitRuns.Count; runIndex++)
                {
                    var run = splitRuns[runIndex];
                    if (run.Count == 0)
                        continue;

                    var fromStory = run[0].Column.StoryName.Trim();
                    var toStory = run[^1].Column.StoryName.Trim();
                    var tierName = splitBySection
                        ? $"{tier.TierName.Trim()}{BuildAlphaSuffix(runIndex)}"
                        : tier.TierName.Trim();

                    finalGroups.Add(new AutoGroupedColumnSection
                    {
                        ColumnGroupId = columnGroupId,
                        ColumnGroupName = columnGroupName,
                        GroupXmm = columnGroup.GroupXmm,
                        GroupYmm = columnGroup.GroupYmm,
                        ManualTierName = tier.TierName.Trim(),
                        TierName = tierName,
                        FromStory = fromStory,
                        ToStory = toStory,
                        LabelFilter = tier.LabelFilter.Trim(),
                        ColumnLabel = columnGroupName,
                        SplitEtabsSectionName = DistinctDisplayValues(run.Select(item => item.Column.EtabsSectionName)).FirstOrDefault() ?? "",
                        WasSplitByEtabsSection = splitBySection,
                        SourceEtabsItems = run.Select(item => item.Column).ToList()
                    });
                }
            }
        }

        return finalGroups;
    }

    private static List<List<MatchedColumn>> SplitBySectionChange(IReadOnlyList<MatchedColumn> orderedItems)
    {
        var runs = new List<List<MatchedColumn>>();
        List<MatchedColumn>? current = null;
        string? currentSection = null;

        foreach (var item in orderedItems)
        {
            var section = NormalizeSectionName(item.Column.EtabsSectionName);
            if (current is null || !string.Equals(currentSection, section, StringComparison.OrdinalIgnoreCase))
            {
                current = [];
                runs.Add(current);
                currentSection = section;
            }

            current.Add(item);
        }

        return runs;
    }

    private static List<AutoGroupingPreviewRow> BuildPreviewRows(IEnumerable<AutoGroupedColumnSection> groups)
        => groups
            .Select(group =>
            {
                var sectionNames = DistinctDisplayValues(group.SourceEtabsItems.Select(i => i.EtabsSectionName));
                var materialNames = DistinctDisplayValues(group.SourceEtabsItems.Select(i => i.MaterialName));
                return new AutoGroupingPreviewRow
                {
                    ColumnGroupId = group.ColumnGroupId,
                    ColumnGroupName = group.ColumnGroupName,
                    GroupXmm = group.GroupXmm,
                    GroupYmm = group.GroupYmm,
                    TierName = group.TierName,
                    StoryRange = group.StoryRange,
                    ColumnLabel = group.ColumnGroupName,
                    MbColumnSectionName = group.MbColumnSectionName,
                    Count = group.SourceEtabsItems.Count,
                    EtabsSectionsDisplayText = string.Join(", ", sectionNames),
                    MaterialsDisplayText = string.Join(", ", materialNames),
                    HasMixedSections = sectionNames.Count > 1,
                    HasMixedMaterials = materialNames.Count > 1
                };
            })
            .ToList();

    private static List<AutoGroupingTierSummaryRow> BuildTierSummaryRows(IEnumerable<AutoGroupedColumnSection> groups)
        => groups
            .GroupBy(group => new
            {
                group.ManualTierName,
                group.FromStory,
                group.ToStory
            })
            .Select(group => new AutoGroupingTierSummaryRow
            {
                TierName = group.Key.ManualTierName,
                StoryRange = string.Equals(group.Key.FromStory, group.Key.ToStory, StringComparison.OrdinalIgnoreCase)
                    ? group.Key.FromStory
                    : $"{group.Key.FromStory}-{group.Key.ToStory}",
                ColumnSectionCount = group.Count(),
                ObjectCount = group.Sum(section => section.SourceEtabsItems.Count)
            })
            .ToList();

    private static void AssignSectionNames(
        IReadOnlyList<AutoGroupedColumnSection> groups,
        IReadOnlyCollection<string> reservedSectionNames)
    {
        var reserved = new HashSet<string>(reservedSectionNames, StringComparer.OrdinalIgnoreCase);
        foreach (var group in groups)
        {
            var sectionName = string.IsNullOrWhiteSpace(group.SplitEtabsSectionName)
                ? "Section"
                : group.SplitEtabsSectionName;
            var rawName = $"{group.ColumnGroupId}_{group.TierName}_{group.StoryRange}_{sectionName}";
            var mbSectionName = NextAvailableName(SanitizeName(rawName), reserved);
            group.MbColumnSectionName = mbSectionName;
            reserved.Add(mbSectionName);
        }
    }

    private static IReadOnlyList<string> DistinctDisplayValues(IEnumerable<string> values)
        => values
            .Select(v => v.Trim())
            .Where(v => !string.IsNullOrWhiteSpace(v))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(v => v, StringComparer.OrdinalIgnoreCase)
            .ToList();

    private static string NextAvailableName(string baseName, HashSet<string> reservedNames)
    {
        if (!reservedNames.Contains(baseName))
            return baseName;

        var index = 2;
        string candidate;
        do
        {
            candidate = $"{baseName}_Import_{index++}";
        }
        while (reservedNames.Contains(candidate));

        return candidate;
    }

    private static string SanitizeName(string raw)
    {
        var chars = raw
            .Trim()
            .Select(c => char.IsLetterOrDigit(c) || c is '_' or '-' ? c : '_')
            .ToArray();
        var result = new string(chars);
        while (result.Contains("__", StringComparison.Ordinal))
            result = result.Replace("__", "_", StringComparison.Ordinal);

        return string.IsNullOrWhiteSpace(result) ? "ETABS_Section" : result.Trim('_');
    }

    private static string FormatColumnGroupName(string id, double xMm, double yMm)
        => string.Format(CultureInfo.InvariantCulture, "{0} [X={1:0.00}, Y={2:0.00}]", id, xMm / 1000.0, yMm / 1000.0);

    private static string FormatFallbackColumnGroupName(string id, string fallbackKey)
        => string.IsNullOrWhiteSpace(fallbackKey)
            ? id
            : $"{id} [{fallbackKey}]";

    private static string BuildFallbackColumnGroupKey(EtabsColumnImportDto column)
    {
        if (!string.IsNullOrWhiteSpace(column.Label))
            return column.Label.Trim();
        if (!string.IsNullOrWhiteSpace(column.PierName))
            return column.PierName.Trim();
        if (!string.IsNullOrWhiteSpace(column.ObjectName))
            return column.ObjectName.Trim();

        return "(No label)";
    }

    private static int StoryIndex(StoryTierResolver resolver, string storyName)
        => resolver.TryGetStoryIndex(storyName, out var index) ? index : int.MaxValue;

    private static string NormalizeSectionName(string sectionName)
        => string.IsNullOrWhiteSpace(sectionName) ? "(none)" : sectionName.Trim();

    private static string BuildAlphaSuffix(int index)
    {
        var value = index;
        var chars = new Stack<char>();
        do
        {
            chars.Push((char)('A' + value % 26));
            value = value / 26 - 1;
        }
        while (value >= 0);

        return new string(chars.ToArray());
    }

    private static double Distance(double x1, double y1, double x2, double y2)
    {
        var dx = x1 - x2;
        var dy = y1 - y2;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private sealed record MatchedColumn(EtabsColumnImportDto Column, AutoGroupingTier Tier, int TierOrder);

    private readonly record struct SpatialBucket(long X, long Y)
    {
        public static SpatialBucket From(double x, double y, double bucketSize)
            => new(
                (long)Math.Floor(x / bucketSize),
                (long)Math.Floor(y / bucketSize));
    }

    private sealed class ColumnIdentityGroup
    {
        private double xSum;
        private double ySum;

        public ColumnIdentityGroup(string fallbackKey, bool hasCoordinates)
        {
            FallbackKey = fallbackKey;
            HasCoordinates = hasCoordinates;
        }

        public string FallbackKey { get; }
        public bool HasCoordinates { get; }
        public List<MatchedColumn> Items { get; } = [];
        public double GroupXmm => Items.Count == 0 ? 0 : xSum / Items.Count;
        public double GroupYmm => Items.Count == 0 ? 0 : ySum / Items.Count;

        public void Add(MatchedColumn column)
        {
            Items.Add(column);
            if (!column.Column.HasCoordinates)
                return;

            xSum += column.Column.CenterXmm;
            ySum += column.Column.CenterYmm;
        }
    }

    private static class LabelFilterMatcher
    {
        public static bool Matches(string label, string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return true;

            var tokens = filter
                .Split([',', ';'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (tokens.Count == 0)
                return true;

            var excludes = tokens
                .Where(IsExclude)
                .Select(t => t[1..].Trim())
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .ToList();

            if (excludes.Any(token => MatchesToken(label, token)))
                return false;

            var includes = tokens
                .Where(t => !IsExclude(t))
                .ToList();

            return includes.Count == 0 || includes.Any(token => MatchesToken(label, token));
        }

        private static bool IsExclude(string token)
            => token.StartsWith('!') || token.StartsWith('-');

        private static bool MatchesToken(string label, string token)
        {
            label ??= "";
            if (token.Contains('*', StringComparison.Ordinal) || token.Contains('?', StringComparison.Ordinal))
            {
                var pattern = "^" + Regex.Escape(token).Replace("\\*", ".*", StringComparison.Ordinal)
                    .Replace("\\?", ".", StringComparison.Ordinal) + "$";
                return Regex.IsMatch(label, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }

            return label.Contains(token, StringComparison.OrdinalIgnoreCase);
        }
    }
}
