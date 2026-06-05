namespace MBColumn.Application.DTOs.Etabs.Forces;

public static class EtabsTableKeyResolver
{
    // Canonical primary table keys — EtabsForceTableService uses these
    // with a fallback list for older ETABS versions.
    public static string GetEtabsTableKey(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType)
    {
        return (sourceType, objectType) switch
        {
            (EtabsForceSourceType.ElementForces, EtabsForceObjectType.Column) => "Element Forces - Columns",
            (EtabsForceSourceType.ElementForces, EtabsForceObjectType.Pier)   => "Pier Forces",
            (EtabsForceSourceType.DesignForces,  EtabsForceObjectType.Column) => "Design Forces - Columns",
            (EtabsForceSourceType.DesignForces,  EtabsForceObjectType.Pier)   => "Design Forces - Piers",
            _ => throw new NotSupportedException(
                     $"Unsupported ETABS force source/object type: {sourceType}/{objectType}.")
        };
    }

    // Fallback keys tried when the canonical key returns no data (ETABS version differences).
    public static IReadOnlyList<string> GetFallbackTableKeys(
        EtabsForceSourceType sourceType,
        EtabsForceObjectType objectType)
    {
        return (sourceType, objectType) switch
        {
            (EtabsForceSourceType.DesignForces, EtabsForceObjectType.Column) =>
                ["Design Forces - Columns", "Concrete Column Design Forces",
                 "Concrete Design 1 - Column Summary", "Concrete Column Design Summary"],
            (EtabsForceSourceType.DesignForces, EtabsForceObjectType.Pier) =>
                ["Design Forces - Piers", "Shear Wall Pier Design Forces",
                 "Shear Wall 1 - Pier Summary", "Shear Wall Pier Summary"],
            _ => [GetEtabsTableKey(sourceType, objectType)]
        };
    }
}
