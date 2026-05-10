namespace MBColumn.Domain.Interfaces;

public interface IDesignCodeService
{
    double ConcreteUltimateStrain { get; }
    double ConcreteStressBlockFactor { get; }
    double Beta1(double fcMpa);
    double Phi(double tensileSteelStrain, double fyMpa, double esMpa);
    double CompressionDesignLimit(double maximumPhiCompressionN);
    // Returns the design steel strength from the characteristic (input) value.
    // ACI: returns fyk unchanged (phi handles member-level reduction).
    // EC2:  returns fyk / Î³s where Î³s = 1.15.
    double SteelDesignStrength(double fykMpa);
}

