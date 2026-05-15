namespace MBColumn.Application.DTOs;

public sealed record ControlPointExportRow
{
    public double ThetaDeg { get; init; }
    public int PointIndex { get; init; }
    public double P { get; init; }
    public double MThetaPositive { get; init; }
    public double MThetaNegative { get; init; }
    public double NeutralAxisDepth { get; init; }
    public double SteelStrainMax { get; init; }
    public double ConcreteStrainMax { get; init; }
    public string IntegrationMethod { get; init; } = "";
    public int ConcreteFiberCountX { get; init; }
    public int ConcreteFiberCountY { get; init; }
    public int CircularRadialFiberCount { get; init; }
    public int CircularAngularFiberCount { get; init; }
    public int CirclePolygonSegmentCount { get; init; }
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
