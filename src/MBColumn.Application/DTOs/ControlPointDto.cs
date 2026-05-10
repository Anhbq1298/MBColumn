using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs;

public sealed record ControlPointDto(
    DiagramType DiagramType,
    double X,
    double Y,
    double Z,
    double P,
    double Mx,
    double My,
    double Phi,
    double ThetaDegrees,
    double NeutralAxisDepth,
    string Label,
    string GroupKey,
    bool IsDemand,
    bool IsGoverning,
    bool IsReference,
    bool IsNominal,
    double SortKey = 0,
    string SliceKey = "",
    double Utilization = 0,
    string StatusText = "");

