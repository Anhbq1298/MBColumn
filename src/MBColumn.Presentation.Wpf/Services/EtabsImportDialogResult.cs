using MBColumn.Application.DTOs.Persistence;

namespace MBColumn.Presentation.Wpf.Services;

public sealed record EtabsImportDialogResult(IReadOnlyList<EtabsImportedSectionInput> Sections);

public sealed record EtabsImportedSectionInput(
    string SectionName,
    ColumnInputSnapshot Snapshot,
    bool UpdateExisting);
