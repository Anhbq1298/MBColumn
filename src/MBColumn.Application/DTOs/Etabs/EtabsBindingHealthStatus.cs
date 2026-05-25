namespace MBColumn.Application.DTOs.Etabs;

public enum EtabsBindingHealthStatus
{
    Ok,
    ModelChanged,
    MissingObject,
    MissingCombo,
    PossibleRemap,
    MultipleRemapCandidates,
    NoForceRowsFound
}
