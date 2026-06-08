using System.Collections.ObjectModel;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class EtabsAutoGroupingApplyService
{
    public IReadOnlyList<MbColumnSectionViewModel> Apply(
        AutoGroupingResult result,
        IReadOnlyList<EtabsColumnImportRowViewModel> sourceRows,
        ObservableCollection<MbColumnSectionViewModel> mbColumnSections,
        ObservableCollection<ProjectGroupOptionViewModel> targetGroups,
        Action onSectionChanged)
    {
        var rowsByObjectName = sourceRows
            .Where(row => !string.IsNullOrWhiteSpace(row.ObjectName))
            .GroupBy(row => row.ObjectName, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

        var ownersByObjectName = mbColumnSections
            .SelectMany(section => section.Items.Select(item => (item.ObjectName, Section: section, Item: item)))
            .GroupBy(entry => entry.ObjectName, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.ToList(), StringComparer.OrdinalIgnoreCase);

        var createdSections = new List<MbColumnSectionViewModel>();

        foreach (var group in result.Groups)
        {
            var rows = group.SourceEtabsItems
                .Select(item => rowsByObjectName.TryGetValue(item.ObjectName, out var row) ? row : null)
                .OfType<EtabsColumnImportRowViewModel>()
                .ToList();

            if (rows.Count == 0)
                continue;

            var ownedEntries = new List<(string ObjectName, MbColumnSectionViewModel Section, EtabsColumnImportRowViewModel Item)>();
            foreach (var row in rows)
            {
                if (ownersByObjectName.TryGetValue(row.ObjectName, out var owned))
                    ownedEntries.AddRange(owned);
            }

            foreach (var ownedGroup in ownedEntries.GroupBy(entry => entry.Section))
            {
                ownedGroup.Key.RemoveItems(ownedGroup.Select(entry => entry.Item));
            }

            var targetGroup = FindOrCreateTargetGroup(targetGroups, group.TierName);
            var section = new MbColumnSectionViewModel(
                group.MbColumnSectionName,
                onSectionChanged,
                isDuplicateName: name => mbColumnSections.Any(existing =>
                    !ReferenceEquals(existing, null)
                    && string.Equals(existing.SectionName, name, StringComparison.OrdinalIgnoreCase)))
            {
                SelectedTargetGroup = targetGroup,
                AutoGroupingMetadata = new AutoGroupingSectionMetadata
                {
                    TierName = group.TierName,
                    FromStory = group.FromStory,
                    ToStory = group.ToStory,
                    LabelFilter = group.LabelFilter,
                    ColumnLabel = group.ColumnLabel
                }
            };

            section.AddItems(rows);
            mbColumnSections.Add(section);
            createdSections.Add(section);
        }

        return createdSections;
    }

    private static ProjectGroupOptionViewModel FindOrCreateTargetGroup(
        ObservableCollection<ProjectGroupOptionViewModel> targetGroups,
        string tierName)
    {
        var existing = targetGroups.FirstOrDefault(group =>
            string.Equals(group.GroupName, tierName, StringComparison.OrdinalIgnoreCase));
        if (existing is not null)
            return existing;

        var created = new ProjectGroupOptionViewModel(null, tierName, createGroup: true);
        targetGroups.Add(created);
        return created;
    }
}
