namespace MBColumn.Application.DTOs.Etabs;

public sealed class ImportedEtabsForceDatabase
{
    public required string ModelFilePath { get; init; }
    public required string ModelName { get; init; }
    public required DateTime ImportedAt { get; init; }

    // Raw eUnits enum value stored as int to avoid Infrastructure COM dependency in Application layer
    public int DatabaseUnits { get; init; }

    public required EtabsDesignForceTable ColumnForces { get; init; }
    public required EtabsDesignForceTable PierForces { get; init; }
    public required IReadOnlyList<string> Warnings { get; init; }
}
