namespace MBColumn.Application.DTOs.Etabs.AutoGrouping;

public sealed record ColumnAutoGroupingRequest(
    IReadOnlyList<EtabsColumnImportDto> Columns,
    IReadOnlyList<AutoGroupingStory> Stories,
    IReadOnlyList<AutoGroupingTier> Tiers,
    IReadOnlyCollection<string> ReservedSectionNames);
