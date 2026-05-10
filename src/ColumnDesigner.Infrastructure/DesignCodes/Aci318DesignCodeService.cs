using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Infrastructure.DesignCodes;

public sealed class Aci318DesignCodeService : IDesignCodeService
{
    public double ConcreteUltimateStrain => 0.003;
    public double ConcreteStressBlockFactor => 0.85;

    public double Beta1(double fcMpa)
    {
        if (fcMpa <= 28.0) return 0.85;
        double beta = 0.85 - 0.05 * ((fcMpa - 28.0) / 7.0);
        return System.Math.Clamp(beta, 0.65, 0.85);
    }

    public double Phi(double tensileSteelStrain, double fyMpa, double esMpa)
    {
        // Simplified tied-column ACI-style phi transition. Compression is positive and tensile
        // steel strain is supplied as a positive tensile magnitude.
        double yieldStrain = fyMpa / esMpa;
        double compressionControlled = yieldStrain;
        const double tensionControlled = 0.005;
        const double minPhi = 0.65;
        const double maxPhi = 0.90;
        double t = (tensileSteelStrain - compressionControlled) / (tensionControlled - compressionControlled);
        return minPhi + System.Math.Clamp(t, 0.0, 1.0) * (maxPhi - minPhi);
    }

    public double CompressionDesignLimit(double maximumPhiCompressionN) => 0.80 * maximumPhiCompressionN;

    // ACI phi handles member-level reduction; steel yield strength is used as-is.
    public double SteelDesignStrength(double fykMpa) => fykMpa;
}
