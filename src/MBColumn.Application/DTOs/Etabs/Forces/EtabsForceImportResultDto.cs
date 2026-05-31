namespace MBColumn.Application.DTOs.Etabs.Forces;

public sealed record EtabsForceImportResultDto(
    bool Success,
    EtabsForceSourceType SourceType,
    IReadOnlyList<EtabsMappedLoadCaseDto> MappedLoadCases,
    string? ErrorMessage = null);
