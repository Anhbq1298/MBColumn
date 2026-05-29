namespace MBColumn.Infrastructure.DesignCodes;

public sealed class EurocodeCircularColumnShearCalculator
{
    public CircularShearResult Calculate(CircularShearInput input)
    {
        double ah = System.Math.PI * input.HoopDiameterMm * input.HoopDiameterMm / 4.0;

        double vRds =
            System.Math.PI / 2.0
            * (ah / input.HoopSpacingMm)
            * input.HoopCentrelineDiameterMm
            * input.FywdMpa
            * input.CotTheta;

        return new CircularShearResult(ah, vRds);
    }
}

public sealed record CircularShearInput(
    double HoopDiameterMm,
    double HoopSpacingMm,
    double HoopCentrelineDiameterMm,
    double FywdMpa,
    double CotTheta);

public sealed record CircularShearResult(
    double AhMm2,
    double VRdsN);
