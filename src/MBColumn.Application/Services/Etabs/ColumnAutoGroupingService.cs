using System.Text.RegularExpressions;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public sealed class ColumnAutoGroupingService
{
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
            .Where(c => !string.IsNullOrWhiteSpace(c.Label))
            .ToList();

        var tiers = request.Tiers
            .Select(t => t.Clone())
            .ToList();

        var resolver = new StoryTierResolver(request.Stories, tiers);
        var result = new AutoGroupingResult();
        result.ValidationMessages.AddRange(validator.ValidateSetup(columns, request.Stories, tiers, resolver));

        if (result.HasErrors)
            return result;

        var preliminaryGroups = new Dictionary<PreliminaryGroupKey, List<EtabsColumnImportDto>>();
        var tierMatchCounts = tiers.ToDictionary(t => t, _ => 0);

        foreach (var column in columns)
        {
            var range = resolver.ResolveFirstTier(column.StoryName);
            if (range is null)
                continue;

            var tier = range.Tier;
            if (!LabelFilterMatcher.Matches(column.Label, tier.LabelFilter))
                continue;

            tierMatchCounts[tier]++;
            var key = new PreliminaryGroupKey(tier, range.TierOrder, column.Label.Trim());
            if (!preliminaryGroups.TryGetValue(key, out var groupItems))
            {
                groupItems = [];
                preliminaryGroups[key] = groupItems;
            }

            groupItems.Add(column);
        }

        AddCoverageMessages(result, columns, tiers, tierMatchCounts, resolver);
        var finalGroups = SplitMixedSectionGroups(result, preliminaryGroups);

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
        return result;
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

    private static List<AutoGroupedColumnSection> SplitMixedSectionGroups(
        AutoGroupingResult result,
        IReadOnlyDictionary<PreliminaryGroupKey, List<EtabsColumnImportDto>> preliminaryGroups)
    {
        var finalGroups = new List<AutoGroupedColumnSection>();

        foreach (var group in preliminaryGroups.OrderBy(g => g.Key.TierOrder).ThenBy(g => g.Key.Label, StringComparer.OrdinalIgnoreCase))
        {
            var tier = group.Key.Tier;
            var sectionNames = DistinctDisplayValues(group.Value.Select(i => i.EtabsSectionName));
            var materialNames = DistinctDisplayValues(group.Value.Select(i => i.MaterialName));
            var splitBySection = sectionNames.Count > 1;

            if (splitBySection)
            {
                result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Warning,
                    AutoGroupingResourceKeys.WarningMixedSections,
                    tier.TierName,
                    group.Key.Label,
                    string.Join(", ", sectionNames)));

                result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Info,
                    AutoGroupingResourceKeys.InfoMixedSectionsSplit,
                    tier.TierName,
                    group.Key.Label));
            }

            if (materialNames.Count > 1)
            {
                result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Warning,
                    AutoGroupingResourceKeys.WarningMixedMaterials,
                    tier.TierName,
                    group.Key.Label,
                    string.Join(", ", materialNames)));
            }

            var splitGroups = splitBySection
                ? group.Value.GroupBy(i => i.EtabsSectionName, StringComparer.OrdinalIgnoreCase)
                : [group.Value.GroupBy(_ => string.Empty).First()];

            foreach (var split in splitGroups.OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase))
            {
                finalGroups.Add(new AutoGroupedColumnSection
                {
                    TierName = tier.TierName.Trim(),
                    FromStory = tier.FromStory.Trim(),
                    ToStory = tier.ToStory.Trim(),
                    LabelFilter = tier.LabelFilter.Trim(),
                    ColumnLabel = group.Key.Label,
                    SplitEtabsSectionName = split.Key,
                    WasSplitByEtabsSection = splitBySection,
                    SourceEtabsItems = split.ToList()
                });
            }
        }

        return finalGroups;
    }

    private static List<AutoGroupingPreviewRow> BuildPreviewRows(IEnumerable<AutoGroupedColumnSection> groups)
        => groups
            .Select(group =>
            {
                var sectionNames = DistinctDisplayValues(group.SourceEtabsItems.Select(i => i.EtabsSectionName));
                var materialNames = DistinctDisplayValues(group.SourceEtabsItems.Select(i => i.MaterialName));
                return new AutoGroupingPreviewRow
                {
                    TierName = group.TierName,
                    StoryRange = group.StoryRange,
                    ColumnLabel = group.ColumnLabel,
                    MbColumnSectionName = group.MbColumnSectionName,
                    Count = group.SourceEtabsItems.Count,
                    EtabsSectionsDisplayText = string.Join(", ", sectionNames),
                    MaterialsDisplayText = string.Join(", ", materialNames),
                    HasMixedSections = sectionNames.Count > 1,
                    HasMixedMaterials = materialNames.Count > 1
                };
            })
            .ToList();

    private static void AssignSectionNames(
        IReadOnlyList<AutoGroupedColumnSection> groups,
        IReadOnlyCollection<string> reservedSectionNames)
    {
        var reserved = new HashSet<string>(reservedSectionNames, StringComparer.OrdinalIgnoreCase);
        var labelTierCounts = groups
            .GroupBy(g => g.ColumnLabel, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.TierName).Distinct(StringComparer.OrdinalIgnoreCase).Count(),
                StringComparer.OrdinalIgnoreCase);

        foreach (var group in groups)
        {
            var needsTierPrefix = group.WasSplitByEtabsSection
                || labelTierCounts.TryGetValue(group.ColumnLabel, out var tierCount) && tierCount > 1
                || reserved.Contains(SanitizeName(group.ColumnLabel));

            var rawName = needsTierPrefix
                ? $"{group.TierName}_{group.ColumnLabel}"
                : group.ColumnLabel;

            if (group.WasSplitByEtabsSection)
                rawName = $"{rawName}_{group.SplitEtabsSectionName}";

            var sectionName = NextAvailableName(SanitizeName(rawName), reserved);
            group.MbColumnSectionName = sectionName;
            reserved.Add(sectionName);
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

    private sealed record PreliminaryGroupKey(AutoGroupingTier Tier, int TierOrder, string Label);

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
            => token.StartsWith("!", StringComparison.Ordinal) || token.StartsWith("-", StringComparison.Ordinal);

        private static bool MatchesToken(string label, string token)
        {
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
