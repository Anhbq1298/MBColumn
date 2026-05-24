namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsDesignForceTable
{
    public required string TableKey { get; init; }
    public int TableVersion { get; init; }
    public required IReadOnlyList<string> FieldKeys { get; init; }
    public required IReadOnlyList<EtabsDesignForceRecord> Records { get; init; }
    public bool HasRecords => Records is { Count: > 0 };
}
