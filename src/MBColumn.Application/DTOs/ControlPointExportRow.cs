namespace MBColumn.Application.DTOs;

public sealed class ControlPointExportRow
{
    public double ThetaDeg { get; init; }
    public int PointIndex { get; init; }
    public double P { get; init; }
    public double MThetaPositive { get; init; }
    public double MThetaNegative { get; init; }
    public double NeutralAxisDepth { get; init; }
    public double SteelStrainMax { get; init; }
    public double ConcreteStrainMax { get; init; }
    public string Remarks { get; init; } = "";
}

public enum ControlPointThetaSelectionMode
{
    CurrentView,
    CustomTheta,
    AllTheta
}

public sealed record ControlPointPreviewResult(
    IReadOnlyList<ControlPointExportRow> Rows,
    IReadOnlyList<double> ThetaValues,
    string EmptyStateMessage = "");
