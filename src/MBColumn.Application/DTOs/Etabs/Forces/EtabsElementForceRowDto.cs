namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// Raw element force row from ETABS analysis output (frame/pier station forces).
/// P, M2, M3, V2, V3 are in ETABS axis convention — mapping to MBColumn axes
/// is done by EtabsForceComponentMapper in Infrastructure.
/// </summary>
public sealed record EtabsElementForceRowDto(
    string SourceObjectName,
    string? SourceObjectLabel,
    string? Story,
    string LoadCaseOrCombo,
    double Station,
    double P,
    double V2,
    double V3,
    double T,
    double M2,
    double M3,
    EtabsForceUnitContextDto UnitContext);
