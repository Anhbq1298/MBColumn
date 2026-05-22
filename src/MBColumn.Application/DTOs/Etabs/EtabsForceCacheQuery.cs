namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsForceCacheQuery(
    IReadOnlyList<string>? ObjectNames = null,
    IReadOnlyList<string>? LoadCombinations = null,
    IReadOnlyList<string>? Stations = null);
