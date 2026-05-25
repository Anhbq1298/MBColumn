namespace MBColumn.Application.DTOs;

public sealed class ReportVerificationPointRow
{
    public int Index { get; set; }
    public string PointCode { get; set; } = string.Empty;
    public string PointName { get; set; } = string.Empty;
    public string StrainDescription { get; set; } = string.Empty;

    public double? HandCalcAxialForce { get; set; }
    public double? HandCalcMoment { get; set; }
    public double? SolverAxialForce { get; set; }
    public double? SolverMoment { get; set; }
    public double? AxialForceDeviationPct { get; set; }
    public double? MomentDeviationPct { get; set; }

    public string Note { get; set; } = string.Empty;
}
