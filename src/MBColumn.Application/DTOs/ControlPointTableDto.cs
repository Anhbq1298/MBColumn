namespace MBColumn.Application.DTOs;

public sealed record ControlPointTableRowDto(
    string Axis,        // "X", "Y", "-X", "-Y"
    string PointLabel,  // "Max compression", "Allowable comp.", etc.
    double P,           // Factored axial load in display units (kN or kip)
    double Mx,          // Factored X-moment in display units
    double My,          // Factored Y-moment in display units
    double NaDepth,     // Neutral axis depth in display length units
    double DtDepth,     // Extreme tension steel depth in display length units
    double EpsilonT,    // Maximum tensile steel strain (negative = all bars in compression)
    double Phi          // ACI strength reduction factor
);

public sealed record ControlPointTableDto(
    IReadOnlyList<ControlPointTableRowDto> Rows,
    string ForceUnitLabel,
    string MomentUnitLabel,
    string LengthUnitLabel
);

