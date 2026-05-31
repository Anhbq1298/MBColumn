namespace MBColumn.Application.DTOs.Etabs.Forces;

public sealed record EtabsForceImportRequestDto(
    EtabsForceSourceType SourceType,
    IReadOnlyList<string> SectionNames,
    IReadOnlyList<string> LoadCombinations,
    IReadOnlyList<string> Locations);
