namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>
/// Distinguishes whether forces originate from raw analysis output (element forces)
/// or from the ETABS concrete design module (design forces).
/// Integer values are pinned to match MbColumnForceSourceMode to prevent silent
/// wrong-branch errors if code ever casts between the two types.
/// </summary>
public enum EtabsForceSourceType
{
    DesignForces = 0,
    ElementForces = 1
}
