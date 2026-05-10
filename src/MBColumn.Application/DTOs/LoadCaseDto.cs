using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record LoadCaseDto(
    string Id,
    string Name,
    double Pu,
    double Mux,
    double Muy,
    bool IsActive,
    ForceUnit ForceUnit,
    MomentUnit MomentUnit);

