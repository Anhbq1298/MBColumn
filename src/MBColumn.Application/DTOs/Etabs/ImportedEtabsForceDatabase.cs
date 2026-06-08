namespace MBColumn.Application.DTOs.Etabs;

public sealed class ImportedEtabsForceDatabase
{
    public required string ModelFilePath { get; init; }
    public required string ModelName { get; init; }
    public required DateTime ImportedAt { get; init; }

    // Raw eForce / eLength int values from GetDatabaseUnits_2; avoids Infrastructure COM dependency
    public int DatabaseForceUnits { get; init; }
    public int DatabaseLengthUnits { get; init; }

    // Legacy combined units field — kept for reference but not used for scale factor computation
    public int DatabaseUnits { get; init; }

    public required EtabsDesignForceTable ColumnForces { get; init; }
    public required EtabsDesignForceTable PierForces { get; init; }
    public required EtabsDesignForceTable ColumnElementForces { get; init; }
    public required EtabsDesignForceTable PierElementForces { get; init; }
    public required IReadOnlyList<string> Warnings { get; init; }
}
