using MBColumn.Application.DTOs.ImportExport;

namespace MBColumn.Application.Services.ImportExport;

public interface IDxfImportService
{
    IReadOnlyList<string> GetLayerNames(string filePath);
    DxfSectionImportResult ImportSection(DxfSectionImportRequest request);
}
