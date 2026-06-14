using System.Globalization;

namespace MBColumn.Application.Services;

/// <summary>
/// Centralised theta-angle conversion between the two conventions used in MBColumn.
///
/// <para><b>Compression-normal angle (θc)</b> — the direction of the axis perpendicular
/// to the neutral axis, pointing toward the compression zone.  This is the angle
/// stored on <c>InteractionPoint.ThetaDegrees</c> and on
/// <c>CalculationResultDto.GoverningThetaDegrees</c>.</para>
///
/// <para><b>Moment angle (θM)</b> — the direction of the resultant moment vector
/// in the Mx-My plane.  This is the angle displayed to the user everywhere in
/// the UI and in reports.</para>
///
/// <para>Relationship:  <c>θM = θc + 90°</c>  /  <c>θc = θM − 90°</c></para>
/// </summary>
public static class PmmAngleConvention
{
    public const string DegreeSymbol = "\u00b0";

    /// <summary>Normalise any angle to the range [0, 360).</summary>
    public static double NormalizeAngle(double angleDegrees)
    {
        if (double.IsNaN(angleDegrees) || double.IsInfinity(angleDegrees)) return 0.0;
        var normalized = angleDegrees % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    /// <summary>
    /// Convert compression-normal (solver) angle → user-facing moment angle.
    /// <c>θM = NormalizeAngle(θc + 90)</c>
    /// </summary>
    public static double MomentFromCompressionNormal(double thetaCompressionDegrees)
        => NormalizeAngle(thetaCompressionDegrees + 90.0);

    /// <summary>
    /// Convert user-facing moment angle → compression-normal (solver) angle.
    /// <c>θc = NormalizeAngle(θM − 90)</c>
    /// </summary>
    public static double CompressionNormalFromMoment(double thetaMomentDegrees)
        => NormalizeAngle(thetaMomentDegrees - 90.0);

    /// <summary>
    /// Format a user-facing moment theta consistently for PMM details and reports.
    /// </summary>
    public static string FormatMomentTheta(double thetaMomentDegrees)
        => NormalizeAngle(thetaMomentDegrees).ToString("0.0", CultureInfo.InvariantCulture) + DegreeSymbol;
}
