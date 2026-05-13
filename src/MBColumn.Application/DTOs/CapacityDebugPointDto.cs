namespace MBColumn.Application.DTOs;

public sealed record CapacityDebugPointDto(
    string Label,
    double ThetaDegrees,
    double NeutralAxisDepthMm,
    double TensileStrain,
    double Phi,
    double PnDisplay,
    double PhiPnDisplay,
    double MnxDisplay,
    double PhiMnxDisplay,
    double MnyDisplay,
    double PhiMnyDisplay,
    double ConcretePnDisplay,
    double SteelPnDisplay,
    string RegionClassification);
