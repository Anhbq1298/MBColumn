using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public interface IImportedEtabsForceCache
{
    ImportedEtabsForceDatabase? Current { get; }
    bool HasCache { get; }

    /// <summary>Returns true when the cache holds data for the given model file path.</summary>
    bool HasValidCache(string currentModelFilePath);

    void Set(ImportedEtabsForceDatabase database);
    void Clear();
}
