using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using static System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsBindingReconciliationService : IEtabsBindingReconciliationService
{
    public EtabsBindingValidationResult ValidateBindings(
        IReadOnlyList<EtabsSectionBinding> bindings,
        string currentModelPath,
        string currentModelName,
        IReadOnlyList<EtabsColumnObjectKey> currentColumns,
        IReadOnlyList<string> currentPierLabels,
        IReadOnlyList<string> currentLoadCombinations)
    {
        var result = new EtabsBindingValidationResult
        {
            CurrentModelPath = currentModelPath,
            CurrentModelName = currentModelName
        };

        var anyBinding = bindings.FirstOrDefault();
        if (anyBinding?.SourceModel is not null)
        {
            bool pathChanged = !string.Equals(
                anyBinding.SourceModel.ModelFilePath, currentModelPath, StringComparison.OrdinalIgnoreCase);
            bool nameChanged = !string.Equals(
                anyBinding.SourceModel.ModelFileName, currentModelName, StringComparison.OrdinalIgnoreCase);
            result.ModelChanged = pathChanged || nameChanged;
        }

        var currentComboSet = currentLoadCombinations.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var columnIndex = ColumnIdentityIndex.Build(currentColumns);

        foreach (var binding in bindings)
        {
            foreach (var combo in binding.LoadCombinations)
            {
                if (!currentComboSet.Contains(combo) && !result.MissingCombinations.Contains(combo))
                    result.MissingCombinations.Add(combo);
            }

            if (binding.ObjectType == EtabsImportedObjectType.Column)
            {
                foreach (var col in binding.ColumnObjects)
                {
                    var health = ReconcileColumnObject(col, columnIndex);
                    health.SectionName = binding.MbColumnSectionName;
                    result.ObjectHealthList.Add(health);
                }
            }

            if (binding.ObjectType == EtabsImportedObjectType.Pier)
            {
                foreach (var pier in binding.PierObjects)
                {
                    bool directMatch = currentPierLabels.Contains(pier.PierName, StringComparer.OrdinalIgnoreCase);
                    result.ObjectHealthList.Add(new EtabsObjectBindingHealth
                    {
                        SectionName = binding.MbColumnSectionName,
                        ObjectKey = pier.Key,
                        Status = directMatch ? EtabsBindingHealthStatus.Ok : EtabsBindingHealthStatus.MissingObject
                    });
                }
            }
        }

        return result;
    }

    public EtabsObjectBindingHealth ReconcileColumnObject(
        EtabsColumnObjectKey savedKey,
        IReadOnlyList<EtabsColumnObjectKey> availableColumns,
        double xyToleranceMm = 25.0)
        => ReconcileColumnObject(savedKey, ColumnIdentityIndex.Build(availableColumns), xyToleranceMm);

    private static EtabsObjectBindingHealth ReconcileColumnObject(
        EtabsColumnObjectKey savedKey,
        ColumnIdentityIndex availableColumns,
        double xyToleranceMm = 25.0)
    {
        var direct = availableColumns.FindDirect(savedKey);
        if (direct is not null)
            return new EtabsObjectBindingHealth { ObjectKey = savedKey.Key, Status = EtabsBindingHealthStatus.Ok };

        var nearby = availableColumns.FindByStory(savedKey.Story)
            .Where(c => Distance(c.X, c.Y, savedKey.X, savedKey.Y) <= xyToleranceMm)
            .Where(c => string.IsNullOrWhiteSpace(savedKey.SectionPropertyName)
                || string.IsNullOrWhiteSpace(c.SectionPropertyName)
                || string.Equals(c.SectionPropertyName, savedKey.SectionPropertyName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return nearby.Count switch
        {
            0 => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.MissingObject,
                Message = $"No column found near {savedKey.Story}/{savedKey.Label} (XY tolerance {xyToleranceMm} mm)"
            },
            1 => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.PossibleRemap,
                SuggestedRemapKey = nearby[0].Key,
                Message = $"Label changed? {savedKey.Label} -> {nearby[0].Label}"
            },
            _ => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.MultipleRemapCandidates,
                RemapCandidates = nearby.Select(c => c.Key).ToList(),
                Message = $"{nearby.Count} candidates near {savedKey.Key}"
            }
        };
    }

    public EtabsObjectBindingHealth ReconcilePierObject(
        EtabsPierObjectKey savedKey,
        IReadOnlyList<EtabsPierObjectKey> availablePiers,
        double centerToleranceMm = 25.0,
        double angleTolerance = 2.0,
        double lengthTolerance = 25.0)
    {
        var direct = availablePiers.FirstOrDefault(p =>
            string.Equals(p.Story, savedKey.Story, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(p.PierName, savedKey.PierName, StringComparison.OrdinalIgnoreCase));

        if (direct is not null)
            return new EtabsObjectBindingHealth { ObjectKey = savedKey.Key, Status = EtabsBindingHealthStatus.Ok };

        var nearby = availablePiers
            .Where(p => string.Equals(p.Story, savedKey.Story, StringComparison.OrdinalIgnoreCase))
            .Where(p => Distance(p.CenterX, p.CenterY, savedKey.CenterX, savedKey.CenterY) <= centerToleranceMm)
            .Where(p => Abs(p.Length - savedKey.Length) <= lengthTolerance)
            .Where(p => AngleDiff(p.AngleDegrees, savedKey.AngleDegrees) <= angleTolerance)
            .ToList();

        return nearby.Count switch
        {
            0 => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.MissingObject,
                Message = $"No pier found near {savedKey.Key}"
            },
            1 => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.PossibleRemap,
                SuggestedRemapKey = nearby[0].Key,
                Message = $"Pier renamed? {savedKey.PierName} -> {nearby[0].PierName}"
            },
            _ => new EtabsObjectBindingHealth
            {
                ObjectKey = savedKey.Key,
                Status = EtabsBindingHealthStatus.MultipleRemapCandidates,
                RemapCandidates = nearby.Select(p => p.Key).ToList()
            }
        };
    }

    private static double Distance(double x1, double y1, double x2, double y2)
        => Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

    private static double AngleDiff(double a, double b)
    {
        double diff = Abs(a - b) % 180.0;
        return diff > 90.0 ? 180.0 - diff : diff;
    }

    private sealed class ColumnIdentityIndex
    {
        private readonly Dictionary<string, EtabsColumnObjectKey> byUniqueName;
        private readonly Dictionary<string, EtabsColumnObjectKey> byStoryLabel;
        private readonly Dictionary<string, List<EtabsColumnObjectKey>> byStory;

        private ColumnIdentityIndex(
            Dictionary<string, EtabsColumnObjectKey> byUniqueName,
            Dictionary<string, EtabsColumnObjectKey> byStoryLabel,
            Dictionary<string, List<EtabsColumnObjectKey>> byStory)
        {
            this.byUniqueName = byUniqueName;
            this.byStoryLabel = byStoryLabel;
            this.byStory = byStory;
        }

        public static ColumnIdentityIndex Build(IReadOnlyList<EtabsColumnObjectKey> columns)
        {
            var byUniqueName = new Dictionary<string, EtabsColumnObjectKey>(StringComparer.OrdinalIgnoreCase);
            var byStoryLabel = new Dictionary<string, EtabsColumnObjectKey>(StringComparer.OrdinalIgnoreCase);
            var byStory = new Dictionary<string, List<EtabsColumnObjectKey>>(StringComparer.OrdinalIgnoreCase);

            foreach (var column in columns)
            {
                if (!string.IsNullOrWhiteSpace(column.UniqueName))
                    byUniqueName.TryAdd(column.UniqueName, column);

                var storyLabelKey = BuildStoryLabelKey(column.Story, column.Label);
                if (!string.IsNullOrWhiteSpace(storyLabelKey))
                    byStoryLabel.TryAdd(storyLabelKey, column);

                if (!byStory.TryGetValue(column.Story, out var storyColumns))
                {
                    storyColumns = [];
                    byStory[column.Story] = storyColumns;
                }

                storyColumns.Add(column);
            }

            return new ColumnIdentityIndex(byUniqueName, byStoryLabel, byStory);
        }

        public EtabsColumnObjectKey? FindDirect(EtabsColumnObjectKey savedKey)
        {
            if (!string.IsNullOrWhiteSpace(savedKey.UniqueName)
                && byUniqueName.TryGetValue(savedKey.UniqueName, out var uniqueMatch))
            {
                return uniqueMatch;
            }

            var storyLabelKey = BuildStoryLabelKey(savedKey.Story, savedKey.Label);
            return !string.IsNullOrWhiteSpace(storyLabelKey)
                && byStoryLabel.TryGetValue(storyLabelKey, out var storyLabelMatch)
                ? storyLabelMatch
                : null;
        }

        public IReadOnlyList<EtabsColumnObjectKey> FindByStory(string story)
            => byStory.TryGetValue(story, out var columns) ? columns : [];

        private static string BuildStoryLabelKey(string story, string label)
            => string.IsNullOrWhiteSpace(story) || string.IsNullOrWhiteSpace(label)
                ? ""
                : $"{story.Trim()}|{label.Trim()}";
    }
}
