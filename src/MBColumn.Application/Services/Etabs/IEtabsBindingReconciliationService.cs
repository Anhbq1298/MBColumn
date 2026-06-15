using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IEtabsBindingReconciliationService
{
    EtabsBindingValidationResult ValidateBindings(
        IReadOnlyList<EtabsSectionBinding> bindings,
        string currentModelPath,
        string currentModelName,
        IReadOnlyList<EtabsColumnObjectKey> currentColumns,
        IReadOnlyList<string> currentPierLabels,
        IReadOnlyList<string> currentLoadCombinations);

    EtabsObjectBindingHealth ReconcileColumnObject(
        EtabsColumnObjectKey savedKey,
        IReadOnlyList<EtabsColumnObjectKey> availableColumns,
        double xyToleranceMm = 25.0);

    EtabsObjectBindingHealth ReconcilePierObject(
        EtabsPierObjectKey savedKey,
        IReadOnlyList<EtabsPierObjectKey> availablePiers,
        double centerToleranceMm = 25.0,
        double angleTolerance = 2.0,
        double lengthTolerance = 25.0);
}
