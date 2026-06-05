using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record LoadCaseResultDto(
    string LoadCaseId,
    string LoadCaseName,
    double PuDisplay,
    double MuxDisplay,
    double MuyDisplay,
    double PmmRatio,
    CapacityStatus Status,
    double Phi,
    double GoverningThetaDegrees,
    double GoverningNeutralAxisDepth)
{
    public double CapacityPDisplay { get; init; }
    public double CapacityMxDisplay { get; init; }
    public double CapacityMyDisplay { get; init; }
    public string SlendernessStatus { get; init; } = "";
    public double? LambdaX { get; init; }
    public double? LambdaLimitX { get; init; }
    public double? LambdaY { get; init; }
    public double? LambdaLimitY { get; init; }
    public double? M2xDisplay { get; init; }
    public double? M2yDisplay { get; init; }

    /// <summary>Shear check result for this load case; null when shear forces are zero or not checked.</summary>
    public ShearResultDto? ShearResult { get; init; }

    /// <summary>
    /// Mx design moment actually used for the interaction check, in the display moment unit.
    /// When slenderness is OFF: governing end moment (max-abs of MxTop/MxBottom), sign preserved.
    /// When slenderness is ON: EC2 amplified moment.
    /// </summary>
    public double? MxUsedDisplay { get; init; }

    /// <summary>
    /// My design moment actually used for the interaction check, in the display moment unit.
    /// When slenderness is OFF: governing end moment (max-abs of MyTop/MyBottom), sign preserved.
    /// When slenderness is ON: EC2 amplified moment.
    /// </summary>
    public double? MyUsedDisplay { get; init; }

    /// <summary>"DirectEnvelope" when MxUsed/MyUsed come from the end-moment envelope; "Slenderness" when from EC2 calculation.</summary>
    public string MxUsedSource { get; init; } = "DirectEnvelope";
}

