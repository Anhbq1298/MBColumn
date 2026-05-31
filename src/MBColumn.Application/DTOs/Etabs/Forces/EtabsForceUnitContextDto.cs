using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs.Etabs.Forces;

/// <summary>Carries the unit system that the ETABS force values were read in.</summary>
public sealed record EtabsForceUnitContextDto(
    ForceUnit ForceUnit,
    MomentUnit MomentUnit,
    LengthUnit LengthUnit);
