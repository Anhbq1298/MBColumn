using MBColumn.Domain.Enums;

namespace MBColumn.Domain.Entities;

public sealed record ControlPoint(
    string Id,
    DiagramType DiagramType,
    double Pn,
    double Mnx,
    double Mny,
    double Phi,
    double PhiPn,
    double PhiMnx,
    double PhiMny,
    double DisplayP,
    double DisplayMx,
    double DisplayMy,
    double NominalDisplayP,
    double NominalDisplayMx,
    double NominalDisplayMy,
    double ThetaDegrees,
    double NeutralAxisDepth,
    bool IsDemandPoint,
    bool IsGoverningPoint,
    bool IsReferencePoint,
    string Label,
    double SortKey,
    string GroupKey,
    string SliceKey,
    double ReducedDisplayP = double.NaN,
    double ReducedDisplayMx = double.NaN,
    double ReducedDisplayMy = double.NaN,
    string RegionClassification = "")
{
    public bool IsSpecialPoint { get; init; } = false;
}

