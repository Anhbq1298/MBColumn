using MBColumn.Application.DTOs.ImportExport;

namespace MBColumn.Application.Services.ImportExport;

public interface IIrregularSectionCsvService
{
    IReadOnlyList<IrregularBoundaryPointCsvDto> ImportBoundary(string filePath);
    IReadOnlyList<IrregularRebarCsvDto> ImportRebars(string filePath);

    IReadOnlyList<IrregularBoundaryPointCsvDto> ParseBoundary(string csvText);
    IReadOnlyList<IrregularRebarCsvDto> ParseRebars(string csvText);

    void ExportBoundary(string filePath, IReadOnlyList<IrregularBoundaryPointCsvDto> points);
    void ExportRebars(string filePath, IReadOnlyList<IrregularRebarCsvDto> rebars);

    string SerializeBoundary(IReadOnlyList<IrregularBoundaryPointCsvDto> points);
    string SerializeRebars(IReadOnlyList<IrregularRebarCsvDto> rebars);
}
