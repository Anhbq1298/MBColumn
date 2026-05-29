namespace MBColumn.Domain.Entities;

/// <summary>
/// Describes the transverse link (stirrup) reinforcement geometry used in shear checks.
/// TotalLegsX = links resisting shear in the X direction (legs spanning in the Y direction).
/// TotalLegsY = links resisting shear in the Y direction (legs spanning in the X direction).
/// For circular sections set IsCircularHoop = true and provide HoopCentrelineDiameterMm (D').
/// </summary>
public sealed record ShearLinkReinforcement(
    double LinkDiameterMm,
    double SpacingMm,
    int TotalLegsX,
    int TotalLegsY,
    double FywkMpa,
    bool IsCircularHoop = false,
    double HoopCentrelineDiameterMm = 0)
{
    /// <summary>Area of one hoop bar in mm².</summary>
    public double HoopAhMm2 => IsCircularHoop
        ? System.Math.PI * LinkDiameterMm * LinkDiameterMm / 4.0
        : 0;
}
