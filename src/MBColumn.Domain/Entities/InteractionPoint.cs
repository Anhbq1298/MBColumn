namespace MBColumn.Domain.Entities;

public sealed record InteractionPoint(
    int DepthIndex,
    int AngleIndex,
    double ThetaDegrees,
    double NeutralAxisDepthMm,
    double Pn,
    double Mnx,
    double Mny,
    double Phi,
    double MaxTensionSteelStrain,
    double ConcretePn = 0.0,
    double SteelPn = 0.0,
    double ConcreteMnx = 0.0,
    double ConcreteMny = 0.0,
    double SteelMnx = 0.0,
    double SteelMny = 0.0,
    double MaxConcreteStrain = 0.0,
    double MinConcreteStrain = 0.0,
    double MaxSteelStrain = 0.0,
    double MinSteelStrain = 0.0,
    string StateLabel = "")
{
    public double PhiPn => Pn * Phi;
    public double PhiMnx => Mnx * Phi;
    public double PhiMny => Mny * Phi;
}

