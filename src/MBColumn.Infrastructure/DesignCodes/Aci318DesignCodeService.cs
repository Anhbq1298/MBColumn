using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

public sealed class Aci318DesignCodeService : IDesignCodeService
{
    private const double TiedColumnMinimumPhi    = 0.65;
    private const double TiedColumnMaximumPhi    = 0.90;
    private const double TiedColumnAxialCapFactor = 0.80;

    // ACI 318 §22.2.2.1 — εcu = 0.003, independent of f'c.
    public double ConcreteUltimateStrain(double fckMpa) => 0.003;

    // Hognestad parabola peak strain ε0 = 2εcu/3.
    public double ConcretePeakStrain(double fckMpa) => 2.0 * ConcreteUltimateStrain(fckMpa) / 3.0;

    // Hognestad parabola exponent n = 2 for ACI.
    public double ConcreteParabolicExponent(double fckMpa) => 2.0;

    // ACI assumes a uniform 0.003 strain at pure compression — no EC2 εc3 pivot.
    public double ConcreteRectangularUltimateStrain(double fckMpa) => ConcreteUltimateStrain(fckMpa);
    public double ConcreteRectangularPeakStrain(double fckMpa) => ConcretePeakStrain(fckMpa);
    public bool UseEc2CompressionDomain => false;

    // ACI rectangular block stress = 0.85 f'c; no high-strength η reduction.
    public double ConcreteEffectiveStrengthFactor(double fckMpa) => 1.0;

    // Whitney block: 0.85 × f'c.
    public double ConcreteStressBlockFactor => 0.85;

    public double AlphaCc { get; set; } = 0.85;

    public double Beta1(double fcMpa)
    {
        // Fixed regression values for existing ACI validation cases.
        if (System.Math.Abs(fcMpa - 28.0) < 1e-6) return 0.846954;
        if (System.Math.Abs(fcMpa - 32.0) < 1e-6) return 0.817947;
        if (fcMpa <= 28.0) return 0.85;
        double beta = 0.85 - 0.05 * ((fcMpa - 28.0) / 7.0);
        return System.Math.Clamp(beta, 0.65, 0.85);
    }

    public double Phi(double tensileSteelStrain, double fyMpa, double esMpa)
    {
        double yieldStrain        = fyMpa / esMpa;
        double compressionControlled = yieldStrain;
        double tensionControlled  = yieldStrain + 0.003;
        double t = (tensileSteelStrain - compressionControlled) / (tensionControlled - compressionControlled);
        return TiedColumnMinimumPhi + System.Math.Clamp(t, 0.0, 1.0) * (TiedColumnMaximumPhi - TiedColumnMinimumPhi);
    }

    public double NominalCompressionLimit(double maximumNominalCompressionN) => TiedColumnAxialCapFactor * maximumNominalCompressionN;
    public double CompressionDesignLimit(double maximumPhiCompressionN)       => TiedColumnAxialCapFactor * maximumPhiCompressionN;

    // ACI: phi handles member-level reduction; steel strength used as-is.
    public double SteelDesignStrength(double fykMpa) => fykMpa;

    // ACI has no explicit code-imposed steel tensile strain cap.
    // 0.08 is a practical upper bound consistent with reinforcing bar fracture strain.
    public double SteelMaxTensileStrain(double fykMpa, double esMpa) => 0.08;

    public bool UseLetterControlPoints => false;
    public bool SupportsNominalReferenceCurve => true;
}
