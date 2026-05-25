using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsForceChangeDetector
{
    EtabsSectionRefreshSummary CompareSectionForces(
        string sectionName,
        IReadOnlyList<SnapshotLoadCase> existingLoadCases,
        IReadOnlyList<MbColumnMappedForceRow> newForceRows,
        EtabsBindingHealthStatus bindingStatus);
}
