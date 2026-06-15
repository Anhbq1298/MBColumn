namespace MBColumn.Application.DTOs.Etabs;

public enum EtabsBindingHealthStatus
{
    Ok,
    ModelChanged,
    StoryMismatch,
    XyMismatch,
    MissingObject,
    MissingCombo,
    PossibleRemap,
    MultipleRemapCandidates,
    NoForceRowsFound
}
