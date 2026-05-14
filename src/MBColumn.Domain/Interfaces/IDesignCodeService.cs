namespace MBColumn.Domain.Interfaces;

public interface IDesignCodeService
{
    // --- Concrete strain limits (fck-dependent per EC2 Table 3.1 / ACI §22.2.2.1) ---

    /// <summary>
    /// Ultimate concrete compression strain at the extreme compression fibre.
    /// ACI 318: 0.003 (constant). EC2 Table 3.1: εcu2, fck-dependent.
    /// </summary>
    double ConcreteUltimateStrain(double fckMpa);

    /// <summary>
    /// Concrete strain at onset of the plateau / peak stress.
    /// ACI (Hognestad fiber): 2×εcu/3. EC2 Table 3.1: εc2, fck-dependent.
    /// </summary>
    double ConcretePeakStrain(double fckMpa);

    /// <summary>
    /// Exponent n for the parabolic-rectangular concrete stress-strain model.
    /// ACI Hognestad: 2.0. EC2 Table 3.1: fck-dependent.
    /// </summary>
    double ConcreteParabolicExponent(double fckMpa);

    // --- Rectangular stress block ---

    /// <summary>
    /// Uniform stress factor for the rectangular compression block.
    /// ACI: 0.85 × f'c (Whitney block). EC2: used internally — not applicable.
    /// </summary>
    double ConcreteStressBlockFactor { get; }

    /// <summary>
    /// EC2 η (eta) strength effectiveness factor for the simplified rectangular block.
    /// EC2 Table 3.1: 1.0 for fck ≤ 50 MPa, decreasing above.
    /// ACI: always 1.0.
    /// </summary>
    double ConcreteEffectiveStrengthFactor(double fckMpa);

    /// <summary>β₁ (ACI) or λ (EC2) depth factor for the rectangular stress block.</summary>
    double Beta1(double fcMpa);

    // --- Member-level reduction factor ---

    double Phi(double tensileSteelStrain, double fyMpa, double esMpa);
    double NominalCompressionLimit(double maximumNominalCompressionN);
    double CompressionDesignLimit(double maximumPhiCompressionN);

    // --- Steel ---

    /// <summary>Design steel strength. ACI: fyk unchanged. EC2: fyk / γs (γs = 1.15).</summary>
    double SteelDesignStrength(double fykMpa);

    /// <summary>
    /// Maximum allowable design steel tensile strain.
    /// ACI: practical cap 0.08 (no code-explicit limit).
    /// EC2 §3.2.7(2): εud = 0.9 × εuk = 0.045.
    /// </summary>
    double SteelMaxTensileStrain(double fykMpa, double esMpa);

    // --- EC2-specific ---

    /// <summary>Strength coefficient αcc (EC2 §3.1.6). Singapore/UK NA default: 0.85.</summary>
    double AlphaCc { get; set; }

    bool UseLetterControlPoints { get; }
}
