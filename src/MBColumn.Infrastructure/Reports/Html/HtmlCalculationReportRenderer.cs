using MBColumn.Application.Reports.Models;

namespace MBColumn.Infrastructure.Reports.Html;

public sealed class HtmlCalculationReportRenderer
{
    private readonly ReportWebViewRenderer _renderer = new();

    public void RenderToFile(ReportData data, string filePath)
    {
        string html = _renderer.BuildHtml(data);
        File.WriteAllText(filePath, html, System.Text.Encoding.UTF8);
    }
}
