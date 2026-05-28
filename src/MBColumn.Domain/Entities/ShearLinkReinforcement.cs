namespace MBColumn.Domain.Entities;

/// <summary>
/// Describes the transverse link (stirrup) reinforcement geometry used in shear checks.
/// TotalLegsX = links resisting shear in the X direction (legs spanning in the Y direction).
/// TotalLegsY = links resisting shear in the Y direction (legs spanning in the X direction).
/// </summary>
public sealed record ShearLinkReinforcement(
    double LinkDiameterMm,
    double SpacingMm,
    int TotalLegsX,
    int TotalLegsY,
    double FywkMpa);
