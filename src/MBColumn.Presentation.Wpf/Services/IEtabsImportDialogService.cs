using MBColumn.Application.Services;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.Services;

public interface IEtabsImportDialogService
{
    EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames,
        IReadOnlyList<GroupRecord> targetGroups,
        int? defaultTargetGroupId,
        UnitSystem targetSystem);
}
