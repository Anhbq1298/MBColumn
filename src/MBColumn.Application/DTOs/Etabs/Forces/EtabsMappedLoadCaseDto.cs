namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// MBColumn-ready demand row produced by the ETABS force mapper.
/// This is the common output regardless of whether the source was element forces
/// or design forces — source metadata is preserved so the UI and DB can display it.
/// </summary>
public sealed record EtabsMappedLoadCaseDto(
    string Id,
    string Name,
    string SourceObjectName,
    string? SourceObjectLabel,
    string? Story,
    EtabsForceSourceType SourceType,
    double Pu,
    double Mux,
    double Muy,
    double Vux,
    double Vuy,
    double? MxTop,
    double? MxBottom,
    double? MyTop,
    double? MyBottom,
    string? SourceLocation,
    string? SourceCombination);
