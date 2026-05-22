using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.Services;

public interface IEtabsImportDialogService
{
    EtabsImportDialogResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyCollection<string> existingSectionNames,
        UnitSystem targetSystem);
}
