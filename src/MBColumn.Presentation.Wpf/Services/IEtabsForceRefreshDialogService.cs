using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.Services;

public interface IEtabsForceRefreshDialogService
{
    EtabsForceRefreshResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyList<EtabsSectionBinding> existingBindings,
        IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> existingLoadCasesBySection,
        UnitSystem unitSystem);
}
