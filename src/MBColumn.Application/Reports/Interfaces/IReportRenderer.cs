using MBColumn.Application.Reports.Models;

namespace MBColumn.Application.Reports.Interfaces;

public interface IReportRenderer
{
    void RenderToFile(ReportData data, string outputPath);
    byte[] RenderToBytes(ReportData data);
}
