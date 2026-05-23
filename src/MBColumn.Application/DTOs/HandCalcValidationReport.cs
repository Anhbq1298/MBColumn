namespace MBColumn.Application.DTOs;

public sealed record HandCalcValidationReport(
    bool IsSupported,
    string NotSupportedReason,
    string AxisConvention,
    string SignConvention,
    string DesignCodeNote,
    IReadOnlyList<ControlPointValidationRow> Rows)
{
    public static HandCalcValidationReport NotSupported(string reason) =>
        new(false, reason, "", "", "", []);
}
