using MBColumn.Domain.Interfaces;

namespace MBColumn.Infrastructure.DesignCodes;

/// <summary>
/// Eurocode 2 (EN 1992-1-1:2004) implementation of IDesignCodeService.
/// Material partial factors: Î³c = 1.5, Î³s = 1.15 (Table 2.1N).
/// Long-term concrete factor: Î±cc = 0.85 (clause 3.1.6(1)P).
/// User supplies characteristic strengths fck and fyk; design values are derived here.
/// </summary>
public sealed class Ec2DesignCodeService : IDesignCodeService
{
    // EC2 Table 3.1: Îµcu2 = 0.0035 for fck â‰¤ C50/60 (parabolic-rectangular diagram).
    public double ConcreteUltimateStrain => 0.0035;

    // Net factor applied to fck to obtain equivalent uniform block stress.
    // Combined: ConcreteStressBlockFactor * fck = 1.0 * (AlphaCc/1.5) * fck.
    public double ConcreteStressBlockFactor => AlphaCc / 1.5;
    public double AlphaCc { get; set; } = 0.80;

    // EC2 3.1.7(3): lambda - depth factor for equivalent rectangular stress block.
    // lambda = 0.8                          for fck <= 50 MPa
    // lambda = 0.8 - (fck - 50) / 400      for 50 < fck <= 90 MPa  (min 0.5)
    public double Beta1(double fcMpa)
    {
        if (fcMpa <= 50.0) return 0.8;
        return System.Math.Max(0.8 - (fcMpa - 50.0) / 400.0, 0.5);
    }

    // EC2 uses material partial factors rather than a member-level Ï†.
    // Concrete is reduced via ConcreteStressBlockFactor; steel via SteelDesignStrength.
    // Return 1.0 so InteractionPoint.PhiPn == Pn (already the design value).
    public double Phi(double tensileSteelStrain, double fyMpa, double esMpa) => 1.0;

    // EC2 has no equivalent of ACI's 0.80 tied-column compression cap.
    // The full design axial capacity is available without further reduction.
    public double CompressionDesignLimit(double maximumPhiCompressionN) => maximumPhiCompressionN;

    // EC2 Table 2.1N: Î³s = 1.15 for persistent/transient design situations.
    // Converts user-input characteristic yield strength fyk â†’ design strength fyd.
    public double SteelDesignStrength(double fykMpa) => fykMpa / 1.15;

    public bool UseLetterControlPoints => true;
}

