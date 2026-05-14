using MBColumn.Application.DTOs;

namespace MBColumn.Application.Services;

public interface IControlPointCsvExportService
{
    void Export(string path, IEnumerable<ControlPointExportRow> rows);
}
