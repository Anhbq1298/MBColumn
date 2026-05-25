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
        IReadOnlyList<string> currentStories,
        IReadOnlyList<string> currentColumnLabels,
        IReadOnlyList<string> currentPierLabels,
        IReadOnlyList<string> currentLoadCombinations)
    {
        var result = new EtabsBindingValidationResult
        {
            CurrentModelPath = currentModelPath,
            CurrentModelName = currentModelName
        };

        // Check model identity
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

        foreach (var binding in bindings)
        {
            // Check missing combinations
            foreach (var combo in binding.LoadCombinations)
            {
                if (!currentComboSet.Contains(combo) && !result.MissingCombinations.Contains(combo))
                    result.MissingCombinations.Add(combo);
            }

            // Check column objects
            if (binding.ObjectType == EtabsImportedObjectType.Column)
            {
                var currentCols = currentColumnLabels
                    .Select(label => new EtabsColumnObjectKey { Story = "", Label = label })
                    .ToList();

                foreach (var col in binding.ColumnObjects)
                {
                    // Simple label check — XY reconciliation requires live ETABS data
                    bool directMatch = currentColumnLabels.Contains(col.Label, StringComparer.OrdinalIgnoreCase)
                        || currentStories.Contains(col.Story, StringComparer.OrdinalIgnoreCase);

                    result.ObjectHealthList.Add(new EtabsObjectBindingHealth
                    {
                        SectionName = binding.MbColumnSectionName,
                        ObjectKey = col.Key,
                        Status = directMatch ? EtabsBindingHealthStatus.Ok : EtabsBindingHealthStatus.MissingObject
                    });
                }
            }

            // Check pier objects
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
    {
        // Direct match: same story + label
        var direct = availableColumns.FirstOrDefault(c =>
            string.Equals(c.Story, savedKey.Story, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(c.Label, savedKey.Label, StringComparison.OrdinalIgnoreCase));

        if (direct is not null)
            return new EtabsObjectBindingHealth { ObjectKey = savedKey.Key, Status = EtabsBindingHealthStatus.Ok };

        // Fallback: same story, XY proximity
        var nearby = availableColumns
            .Where(c => string.Equals(c.Story, savedKey.Story, StringComparison.OrdinalIgnoreCase))
            .Where(c => Distance(c.X, c.Y, savedKey.X, savedKey.Y) <= xyToleranceMm)
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
                Message = $"Label changed? {savedKey.Label} → {nearby[0].Label}"
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
        // Direct match
        var direct = availablePiers.FirstOrDefault(p =>
            string.Equals(p.Story, savedKey.Story, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(p.PierName, savedKey.PierName, StringComparison.OrdinalIgnoreCase));

        if (direct is not null)
            return new EtabsObjectBindingHealth { ObjectKey = savedKey.Key, Status = EtabsBindingHealthStatus.Ok };

        // Fallback: centerline match
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
                Message = $"Pier renamed? {savedKey.PierName} → {nearby[0].PierName}"
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
}
