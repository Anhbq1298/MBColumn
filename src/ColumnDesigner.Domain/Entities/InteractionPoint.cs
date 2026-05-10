namespace ColumnDesigner.Domain.Entities;

public sealed record InteractionPoint(
    int DepthIndex,
    int AngleIndex,
    double ThetaDegrees,
    double NeutralAxisDepthMm,
    double Pn,
    double Mnx,
    double Mny,
    double Phi,
    double MaxTensionSteelStrain)
{
    public double PhiPn => Pn * Phi;
    public double PhiMnx => Mnx * Phi;
    public double PhiMny => Mny * Phi;
}
