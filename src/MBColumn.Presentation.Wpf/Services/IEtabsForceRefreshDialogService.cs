using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using System.Collections.Generic;

namespace MBColumn.Presentation.Wpf.Services;

public interface IEtabsForceRefreshDialogService
{
    EtabsForceRefreshResult? ShowDialog(
        System.Windows.Window? owner,
        IReadOnlyList<ColumnRecord> allColumns,
        int? currentColumnId,
        int? currentFolderId,
        UnitSystem unitSystem);
}
