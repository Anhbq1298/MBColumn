namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// Raw design force row from the ETABS concrete design module.
/// Already post-processed by ETABS — combo name and station/location are preserved
/// as source metadata so they can be tracked through to DemandCase.
/// </summary>
public sealed record EtabsDesignForceRowDto(
    string SourceObjectName,
    string? SourceObjectLabel,
    string? Story,
    string DesignCombo,
    string? DesignStationOrLocation,
    double Pu,
    double Mu2,
    double Mu3,
    double Vu2,
    double Vu3,
    EtabsForceUnitContextDto UnitContext);
