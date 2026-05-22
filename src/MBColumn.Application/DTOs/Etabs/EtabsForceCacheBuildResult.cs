namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsForceCacheBuildResult(
    bool Success,
    int RowCount,
    string Message);
