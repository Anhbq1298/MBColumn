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
    public NominalCapacity Nominal => new(Pn, Mnx, Mny);
    public double PhiPn => Pn * Phi;
    public double PhiMnx => Mnx * Phi;
    public double PhiMny => Mny * Phi;
    public ReducedCapacity Reduced => new(PhiPn, PhiMnx, PhiMny, Phi);
    public StrainState StrainState => new(
        MaxTensionSteelStrain,
        MaxConcreteStrain,
        MinConcreteStrain,
        MaxSteelStrain,
        MinSteelStrain,
        StateLabel);
}

public sealed record NominalCapacity(double Pn, double Mnx, double Mny);

public sealed record ReducedCapacity(double PhiPn, double PhiMnx, double PhiMny, double Phi);

public sealed record StrainState(
    double MaxTensionSteelStrain,
    double MaxConcreteStrain,
    double MinConcreteStrain,
    double MaxSteelStrain,
    double MinSteelStrain,
    string RegionClassification);

