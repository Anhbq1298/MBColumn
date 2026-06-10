namespace MBColumn.Application.DTOs.Etabs;

/// <summary>
/// ETABS force row after unit conversion. P is already converted to MBColumn
/// compression-positive convention by the extraction service; M2/M3 and V2/V3
/// keep their ETABS local-axis names until the central convention mapper assigns
/// them to MBColumn Mx/My and Vx/Vy.
/// </summary>
public sealed record EtabsForceResultDto(
    string ObjectName,
    string PierName,
    string StoryName,
    string Label,
    string EtabsSectionName,
    string LoadCombination,
    double P,
    double M2,
    double M3,
    double V2,
    double V3,
    string Station,
    string Status);
