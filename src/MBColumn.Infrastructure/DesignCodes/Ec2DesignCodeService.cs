using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// Eurocode 2 (EN 1992-1-1:2004) implementation of IDesignCodeService.
/// Material partial factors: γc = 1.5, γs = 1.15 (Table 2.1N).
/// Strength coefficient: αcc = 0.85 (Singapore/UK National Annex, clause 3.1.6(1)P).
/// Concrete strain limits and parabolic parameters follow Table 3.1 with
/// piecewise-linear interpolation for 50 MPa &lt; fck ≤ 90 MPa.
/// </summary>
public sealed class Ec2DesignCodeService : IDesignCodeService
{
    private const double GammaC = 1.50;  // EC2 Table 2.1N
    private const double GammaS = 1.15;  // EC2 Table 2.1N
    public EurocodeConcreteStrainProfile EurocodeConcreteStrainProfile { get; set; } = EurocodeConcreteStrainProfile.Ec2;

    // ── Concrete strain limits (EC2 Table 3.1, parabolic-rectangular model) ─────────

    /// <summary>εcu2: ultimate concrete strain at the extreme compression fibre.</summary>
    public double ConcreteUltimateStrain(double fckMpa)
        => EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3
            ? ConcreteRectangularUltimateStrain(fckMpa)
            : ConcreteParabolicUltimateStrain(fckMpa);

    private static double ConcreteParabolicUltimateStrain(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.0035;
        if (fckMpa >= 90.0) return 0.0026;
        return PiecewiseLinear(fckMpa,
            (50, 0.0035), (55, 0.0031), (60, 0.0029), (70, 0.0027), (80, 0.0026), (90, 0.0026));
    }

    /// <summary>εc2: concrete strain at onset of the parabolic plateau.</summary>
    public double ConcretePeakStrain(double fckMpa)
        => EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3
            ? ConcreteRectangularPeakStrain(fckMpa)
            : ConcreteParabolicPeakStrain(fckMpa);

    private static double ConcreteParabolicPeakStrain(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.0020;
        if (fckMpa >= 90.0) return 0.0026;
        return PiecewiseLinear(fckMpa,
            (50, 0.0020), (55, 0.0022), (60, 0.0023), (70, 0.0024), (80, 0.0025), (90, 0.0026));
    }

    /// <summary>n: exponent for the parabolic ascending branch (Table 3.1).</summary>
    public double ConcreteParabolicExponent(double fckMpa)
    {
        if (fckMpa <= 50.0) return 2.0;
        if (fckMpa >= 90.0) return 1.4;
        return PiecewiseLinear(fckMpa,
            (50, 2.0), (55, 1.75), (60, 1.6), (70, 1.45), (80, 1.4), (90, 1.4));
    }

    // ── Rectangular stress block (EC2 §3.1.7, Table 3.1) ────────────────────────────

    /// <summary>
    /// εcu3: ultimate strain for the simplified rectangular block model.
    /// Per Table 3.1, εcu3 == εcu2 at each fck breakpoint.
    /// </summary>
    public double ConcreteRectangularUltimateStrain(double fckMpa) => ConcreteParabolicUltimateStrain(fckMpa);

    /// <summary>EC2 follows the Fig 6.1 strain-domain pivot toward uniform εc3 near pure compression.</summary>
    public bool UseEc2CompressionDomain => true;
    public bool UseBilinearConcreteStress => EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3;

    /// <summary>εc3: strain at onset of the uniform plateau for the rectangular block.</summary>
    public double ConcreteRectangularPeakStrain(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.00175;
        if (fckMpa >= 90.0) return 0.0023;
        return PiecewiseLinear(fckMpa,
            (50, 0.00175), (55, 0.0018), (60, 0.0019), (70, 0.0020), (80, 0.0022), (90, 0.0023));
    }

    /// <summary>η: effectiveness factor for the rectangular block stress level.</summary>
    public double ConcreteEffectiveStrengthFactor(double fckMpa)
    {
        if (fckMpa <= 50.0) return 1.0;
        if (fckMpa >= 90.0) return 0.8;
        return PiecewiseLinear(fckMpa,
            (50, 1.0), (55, 0.975), (60, 0.95), (70, 0.9), (80, 0.85), (90, 0.8));
    }

    // λ: depth factor for the simplified rectangular block.
    public double Beta1(double fcMpa)
    {
        if (fcMpa <= 50.0) return 0.8;
        return System.Math.Max(0.8 - (fcMpa - 50.0) / 400.0, 0.5);
    }

    // EC2 uses material partial factors, not a member-level φ.
    // φ = 1.0 so InteractionPoint.PhiPn == Pn (already at design level).
    public double Phi(double tensileSteelStrain, double fyMpa, double esMpa) => 1.0;

    // EC2 has no equivalent of ACI's 0.80 tied-column compression cap.
    public double NominalCompressionLimit(double maximumNominalCompressionN) => maximumNominalCompressionN;
    public double CompressionDesignLimit(double maximumPhiCompressionN)       => maximumPhiCompressionN;

    // Net stress factor = αcc / γc (applied to fck inside the solver, not here).
    // Kept for structural consistency with ACI; EC2 solvers compute fcd directly.
    public double ConcreteStressBlockFactor => AlphaCc / GammaC;

    // EC2 §3.2.7(2): εud = 0.9 × εuk. Standard εuk = 0.05 → εud = 0.045.
    // National Annex may raise εuk to 0.075 for Class C steel.
    public double EpsilonUd { get; set; } = 0.045;
    public double SteelMaxTensileStrain(double fykMpa, double esMpa) => EpsilonUd;

    // EC2 Table 2.1N: γs = 1.15.
    public double SteelDesignStrength(double fykMpa) => fykMpa / GammaS;

    /// <summary>
    /// αcc — long-term concrete strength coefficient (EC2 §3.1.6(1)P).
    /// Default 0.85 per Singapore SS EN 1992-1-1 and UK NA.
    /// </summary>
    public double AlphaCc { get; set; } = 0.85;

    public bool UseLetterControlPoints => true;
    public bool SupportsNominalReferenceCurve => false;

    // ── Helpers ─────────────────────────────────────────────────────────────────────

    private static double PiecewiseLinear(double x, params (double X, double Y)[] table)
    {
        for (int i = 0; i < table.Length - 1; i++)
        {
            var (x0, y0) = table[i];
            var (x1, y1) = table[i + 1];
            if (x >= x0 && x <= x1)
            {
                double t = (x - x0) / (x1 - x0);
                return y0 + t * (y1 - y0);
            }
        }
        return table[^1].Y;
    }
}
