using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Presentation.Wpf.Services;

public sealed record EtabsImportDialogResult(IReadOnlyList<EtabsImportedSectionInput> Sections, EtabsModelInfoDto? ModelInfo = null);

public sealed record EtabsImportedSectionInput(
    string SectionName,
    ColumnInputSnapshot Snapshot,
    bool UpdateExisting,
    int? TargetGroupId,
    string TargetGroupName,
    bool CreateTargetGroup);
