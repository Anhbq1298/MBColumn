namespace MBColumn.Application.Reports.Models;

public sealed record ReportSection(
    string Number,
    string Title,
    IReadOnlyList<ReportBlock> Blocks);
