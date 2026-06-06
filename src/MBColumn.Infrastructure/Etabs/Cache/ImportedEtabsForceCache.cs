using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;

namespace MBColumn.Infrastructure.Etabs;

/// <summary>
/// In-memory singleton cache for the raw ETABS design force database preloaded during Import ETABS.
/// The cache is invalidated whenever the model file path changes or <see cref="Clear"/> is called.
/// </summary>
public sealed class ImportedEtabsForceCache : IImportedEtabsForceCache
{
    private ImportedEtabsForceDatabase? current;

    public ImportedEtabsForceDatabase? Current => current;

    public bool HasCache => current is not null;

    public bool HasValidCache(string currentModelFilePath)
    {
        if (current is null) return false;
        return string.Equals(
            current.ModelFilePath, currentModelFilePath, StringComparison.OrdinalIgnoreCase);
    }

    public void Set(ImportedEtabsForceDatabase database)
    {
        current = database;
    }

    public void Clear()
    {
        current = null;
    }
}
