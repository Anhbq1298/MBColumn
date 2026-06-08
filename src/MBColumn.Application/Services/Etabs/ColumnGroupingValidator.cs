using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public sealed class ColumnGroupingValidator
{
    public List<AutoGroupingValidationMessage> ValidateSetup(
        IReadOnlyList<EtabsColumnImportDto> columns,
        IReadOnlyList<AutoGroupingStory> stories,
        IReadOnlyList<AutoGroupingTier> tiers,
        StoryTierResolver resolver)
    {
        var messages = new List<AutoGroupingValidationMessage>();

        if (columns.Count == 0)
        {
            messages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Error,
                AutoGroupingResourceKeys.ErrorNoEtabsColumns));
        }

        if (stories.Count == 0)
        {
            messages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Error,
                AutoGroupingResourceKeys.ErrorNoStories));
        }

        if (tiers.Count == 0)
        {
            messages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Error,
                AutoGroupingResourceKeys.ErrorNoTiers));
        }

        for (var i = 0; i < tiers.Count; i++)
        {
            var tier = tiers[i];
            var displayName = string.IsNullOrWhiteSpace(tier.TierName) ? (i + 1).ToString() : tier.TierName.Trim();

            if (string.IsNullOrWhiteSpace(tier.TierName))
            {
                messages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Error,
                    AutoGroupingResourceKeys.ErrorTierNameRequired,
                    i + 1));
            }

            if (string.IsNullOrWhiteSpace(tier.FromStory) || string.IsNullOrWhiteSpace(tier.ToStory))
            {
                messages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Error,
                    AutoGroupingResourceKeys.ErrorTierStoriesRequired,
                    displayName));
                continue;
            }

            if (!resolver.TryGetStoryIndex(tier.FromStory, out _))
            {
                messages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Error,
                    AutoGroupingResourceKeys.ErrorUnknownStory,
                    displayName,
                    tier.FromStory));
            }

            if (!resolver.TryGetStoryIndex(tier.ToStory, out _))
            {
                messages.Add(new AutoGroupingValidationMessage(
                    AutoGroupingValidationSeverity.Error,
                    AutoGroupingResourceKeys.ErrorUnknownStory,
                    displayName,
                    tier.ToStory));
            }
        }

        var columnStories = columns
            .Where(c => c.SectionType != SectionShapeType.Irregular)
            .Select(c => c.StoryName)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        foreach (var overlap in resolver.FindOverlaps(columnStories))
        {
            messages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningOverlappingStory,
                overlap.StoryName,
                string.Join(", ", overlap.Tiers.Select(t => t.TierName))));
        }

        return messages;
    }
}
