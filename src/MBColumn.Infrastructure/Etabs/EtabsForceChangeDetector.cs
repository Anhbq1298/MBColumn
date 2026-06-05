using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using static System.Math;

namespace MBColumn.Infrastructure.Etabs;

public sealed class EtabsForceChangeDetector : IEtabsForceChangeDetector
{
    private const double Tolerance = 1e-6;

    public EtabsSectionRefreshSummary CompareSectionForces(
        string sectionName,
        IReadOnlyList<SnapshotLoadCase> existingLoadCases,
        IReadOnlyList<MbColumnMappedForceRow> newForceRows,
        EtabsBindingHealthStatus bindingStatus)
    {
        // Match key: OriginalLoadCaseName|Story|SourceObjectLabel ↔ CaseName|Story|Label
        var oldByKey = existingLoadCases.ToDictionary(
            lc => RowKey(lc.OriginalLoadCaseName, lc.Story, lc.SourceObjectLabel ?? lc.Label),
            StringComparer.OrdinalIgnoreCase);

        var newByKey = newForceRows.ToDictionary(
            r => RowKey(r.CaseName, r.Story, r.Label),
            StringComparer.OrdinalIgnoreCase);

        var changes = new List<EtabsForceRowChange>();
        int changedCount = 0, addedCount = 0, removedCount = 0;

        foreach (var kvp in newByKey)
        {
            if (oldByKey.TryGetValue(kvp.Key, out var old))
            {
                var row = kvp.Value;
                bool hasChange =
                    Abs(row.NEd - old.Pu) > Tolerance
                    || Abs(row.MxTop    - (old.MxTop    ?? 0)) > Tolerance
                    || Abs(row.MxBottom - (old.MxBottom ?? 0)) > Tolerance
                    || Abs(row.MyTop    - (old.MyTop    ?? 0)) > Tolerance
                    || Abs(row.MyBottom - (old.MyBottom ?? 0)) > Tolerance;

                if (hasChange) changedCount++;

                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    OldP  = old.Pu,
                    NewP  = row.NEd,
                    OldMx = old.MxTop,
                    NewMx = row.MxTop,
                    OldMy = old.MyTop,
                    NewMy = row.MyTop,
                    Status = hasChange ? EtabsForceRowChangeStatus.Changed : EtabsForceRowChangeStatus.Unchanged
                });
            }
            else
            {
                addedCount++;
                var row = kvp.Value;
                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    NewP  = row.NEd,
                    NewMx = row.MxTop,
                    NewMy = row.MyTop,
                    Status = EtabsForceRowChangeStatus.Added
                });
            }
        }

        foreach (var kvp in oldByKey)
        {
            if (!newByKey.ContainsKey(kvp.Key))
            {
                removedCount++;
                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    OldP  = kvp.Value.Pu,
                    OldMx = kvp.Value.MxTop,
                    OldMy = kvp.Value.MyTop,
                    Status = EtabsForceRowChangeStatus.Removed
                });
            }
        }

        var action = bindingStatus switch
        {
            EtabsBindingHealthStatus.Ok                         => EtabsSectionRefreshAction.Update,
            EtabsBindingHealthStatus.PossibleRemap              => EtabsSectionRefreshAction.NeedsRemap,
            EtabsBindingHealthStatus.MultipleRemapCandidates    => EtabsSectionRefreshAction.NeedsRemap,
            EtabsBindingHealthStatus.MissingObject              => EtabsSectionRefreshAction.KeepOld,
            EtabsBindingHealthStatus.ModelChanged               => EtabsSectionRefreshAction.KeepOld,
            _                                                   => EtabsSectionRefreshAction.KeepOld
        };

        var missingObjects = newForceRows.Count == 0 && existingLoadCases.Count > 0
            ? existingLoadCases.Count : 0;

        return new EtabsSectionRefreshSummary
        {
            SectionName       = sectionName,
            Status            = bindingStatus,
            OldRowCount       = existingLoadCases.Count,
            NewRowCount       = newForceRows.Count,
            ChangedRows       = changedCount,
            AddedRows         = addedCount,
            RemovedRows       = removedCount,
            MissingObjects    = missingObjects,
            RecommendedAction = action,
            RowChanges        = changes,
            NewForceRows      = newForceRows.ToList()
        };
    }

    private static string RowKey(string caseName, string story, string? label)
        => $"{caseName}|{story}|{label ?? ""}";
}
