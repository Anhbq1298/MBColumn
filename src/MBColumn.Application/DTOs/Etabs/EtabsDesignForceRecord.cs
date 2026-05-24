namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsDesignForceRecord
{
    public required string SourceTableKey { get; init; }
    public required IReadOnlyDictionary<string, string> Fields { get; init; }
}
