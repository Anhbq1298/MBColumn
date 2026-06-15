using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Services.Etabs;

public sealed class EtabsForceRefreshResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public EtabsForceRefreshPreview? Preview { get; set; }
    public Dictionary<string, IReadOnlyList<SnapshotLoadCase>> UpdatedLoadCasesBySection { get; set; } = [];
    public EtabsForceReimportAuditLogDto? AuditLog { get; set; }
}

public interface IEtabsForceRefreshService
{
    EtabsResultState CheckResultState(EtabsForceRefreshRequest request);

    void RunEtabsAnalysis();
    void RunEtabsDesign();

    EtabsBindingValidationResult ValidateEtabsSourceObjectMapping(
        EtabsForceRefreshRequest request,
        UnitSystem unitSystem);

    EtabsBindingValidationResult ValidateEtabsSourceObjectMapping(
        EtabsForceRefreshRequest request,
        UnitSystem unitSystem,
        out EtabsModelInfoDto? connectedModelInfo);

    EtabsForceRefreshPreview BuildPreview(
        EtabsForceRefreshRequest request,
        IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> existingLoadCasesBySection,
        UnitSystem unitSystem);

    EtabsForceRefreshResult Apply(EtabsForceRefreshPreview preview);
}
