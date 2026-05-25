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
        var oldByKey = existingLoadCases.ToDictionary(lc => lc.Label, StringComparer.OrdinalIgnoreCase);
        var newByKey = newForceRows.ToDictionary(r => r.LoadCaseName, StringComparer.OrdinalIgnoreCase);

        var changes = new List<EtabsForceRowChange>();
        int changedCount = 0;
        int addedCount = 0;
        int removedCount = 0;

        // Check new rows vs existing
        foreach (var kvp in newByKey)
        {
            if (oldByKey.TryGetValue(kvp.Key, out var old))
            {
                bool hasChange = Abs(kvp.Value.P - old.Pu) > Tolerance
                    || Abs(kvp.Value.Mx - old.Mux) > Tolerance
                    || Abs(kvp.Value.My - old.Muy) > Tolerance;

                var status = hasChange ? EtabsForceRowChangeStatus.Changed : EtabsForceRowChangeStatus.Unchanged;
                if (hasChange) changedCount++;

                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    Location = kvp.Value.Location,
                    OldP = old.Pu,
                    NewP = kvp.Value.P,
                    OldMx = old.Mux,
                    NewMx = kvp.Value.Mx,
                    OldMy = old.Muy,
                    NewMy = kvp.Value.My,
                    Status = status
                });
            }
            else
            {
                addedCount++;
                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    Location = kvp.Value.Location,
                    NewP = kvp.Value.P,
                    NewMx = kvp.Value.Mx,
                    NewMy = kvp.Value.My,
                    Status = EtabsForceRowChangeStatus.Added
                });
            }
        }

        // Check for removed rows
        foreach (var kvp in oldByKey)
        {
            if (!newByKey.ContainsKey(kvp.Key))
            {
                removedCount++;
                changes.Add(new EtabsForceRowChange
                {
                    LoadCaseName = kvp.Key,
                    OldP = kvp.Value.Pu,
                    OldMx = kvp.Value.Mux,
                    OldMy = kvp.Value.Muy,
                    Status = EtabsForceRowChangeStatus.Removed
                });
            }
        }

        var action = bindingStatus switch
        {
            EtabsBindingHealthStatus.Ok => EtabsSectionRefreshAction.Update,
            EtabsBindingHealthStatus.PossibleRemap => EtabsSectionRefreshAction.NeedsRemap,
            EtabsBindingHealthStatus.MultipleRemapCandidates => EtabsSectionRefreshAction.NeedsRemap,
            EtabsBindingHealthStatus.MissingObject => EtabsSectionRefreshAction.KeepOld,
            EtabsBindingHealthStatus.ModelChanged => EtabsSectionRefreshAction.KeepOld,
            _ => EtabsSectionRefreshAction.KeepOld
        };

        var missingObjects = newForceRows.Count == 0 && existingLoadCases.Count > 0 ? existingLoadCases.Count : 0;

        return new EtabsSectionRefreshSummary
        {
            SectionName = sectionName,
            Status = bindingStatus,
            OldRowCount = existingLoadCases.Count,
            NewRowCount = newForceRows.Count,
            ChangedRows = changedCount,
            AddedRows = addedCount,
            RemovedRows = removedCount,
            MissingObjects = missingObjects,
            RecommendedAction = action,
            RowChanges = changes,
            NewForceRows = newForceRows.ToList()
        };
    }
}
