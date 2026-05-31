using MBColumn.Domain.Entities;
using MBColumn.Domain.Interfaces;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers.Integration;

public sealed class FiberSectionIntegrator : ISectionIntegrator
{
    private readonly Dictionary<string, ConcreteFiber[]> fiberCache = new();

    public SectionIntegrationResult Integrate(
        ColumnSection section,
        ConcreteMaterial concrete,
        SteelMaterial steel,
        IDesignCodeService designCode,
        NeutralAxisState neutralAxis,
        SolverSettings settings)
    {
        var fibers = GetConcreteFibers(section, settings);
        double nx = neutralAxis.CompressionNormal.X;
        double ny = neutralAxis.CompressionNormal.Y;
        bool useBilinear = designCode.UseEc2CompressionDomain;
        double peakStrain = useBilinear
            ? designCode.ConcreteRectangularPeakStrain(concrete.FcMpa)
            : designCode.ConcretePeakStrain(concrete.FcMpa);
        double exponent = designCode.ConcreteParabolicExponent(concrete.FcMpa);
        double concreteStressCap = designCode.ConcreteStressBlockFactor
            * designCode.ConcreteEffectiveStrengthFactor(concrete.FcMpa)
            * concrete.FcMpa;

        double concreteN = 0.0;
        double concreteMx = 0.0;
        double concreteMy = 0.0;
        double maxConcreteStrain = double.NegativeInfinity;
        double minConcreteStrain = double.PositiveInfinity;
        bool hasConcreteCompression = false;

        foreach (var fiber in fibers)
        {
            double strain = neutralAxis.GetStrainAtProjection(fiber.X * nx + fiber.Y * ny);
            maxConcreteStrain = SMath.Max(maxConcreteStrain, strain);
            minConcreteStrain = SMath.Min(minConcreteStrain, strain);
            if (strain <= 0.0) continue;

            hasConcreteCompression = true;
            double stress = ConcreteStress(strain, peakStrain, exponent, concreteStressCap, designCode.SupportsNominalReferenceCurve, useBilinear);
            double force = stress * fiber.Area;
            concreteN += force;
            concreteMx -= force * fiber.Y;
            concreteMy += force * fiber.X;
        }

        var steelResult = IntegrateSteel(section, steel, designCode, concrete, neutralAxis, null, peakStrain, exponent, concreteStressCap);

        return new SectionIntegrationResult
        {
            NominalP = concreteN + steelResult.N,
            NominalMx = concreteMx + steelResult.Mx,
            NominalMy = concreteMy + steelResult.My,
            ConcreteForce = concreteN,
            SteelForce = steelResult.N,
            ConcreteMx = concreteMx,
            ConcreteMy = concreteMy,
            SteelMx = steelResult.Mx,
            SteelMy = steelResult.My,
            MaxTensionSteelStrain = steelResult.MaxTensionStrain,
            MaxConcreteStrain = NormalizeExtreme(maxConcreteStrain),
            MinConcreteStrain = NormalizeExtreme(minConcreteStrain),
            MaxSteelStrain = NormalizeExtreme(steelResult.MaxStrain),
            MinSteelStrain = NormalizeExtreme(steelResult.MinStrain),
            HasConcreteCompression = hasConcreteCompression
        };
    }

    internal static SteelIntegration IntegrateSteel(
        ColumnSection section,
        SteelMaterial steel,
        IDesignCodeService designCode,
        ConcreteMaterial concrete,
        NeutralAxisState neutralAxis,
        double? stressBlockProjection,
        double concretePeakStrain,
        double concreteExponent,
        double concreteStressCap)
    {
        double nx = neutralAxis.CompressionNormal.X;
        double ny = neutralAxis.CompressionNormal.Y;
        bool useBilinear = designCode.UseEc2CompressionDomain;
        double fyd = designCode.SteelDesignStrength(steel.FyMpa);
        double epsUd = designCode.SteelMaxTensileStrain(steel.FyMpa, steel.EsMpa);
        double steelN = 0.0;
        double steelMx = 0.0;
        double steelMy = 0.0;
        double maxTensionStrain = 0.0;
        double maxSteelStrain = double.NegativeInfinity;
        double minSteelStrain = double.PositiveInfinity;

        foreach (var bar in section.RebarLayout.Bars)
        {
            double projection = bar.XMm * nx + bar.YMm * ny;
            double strain = neutralAxis.GetStrainAtProjection(projection);
            maxSteelStrain = SMath.Max(maxSteelStrain, strain);
            minSteelStrain = SMath.Min(minSteelStrain, strain);
            if (strain < 0.0)
            {
                maxTensionStrain = SMath.Min(SMath.Max(maxTensionStrain, -strain), epsUd);
            }

            double stress = SMath.Clamp(steel.EsMpa * strain, -fyd, fyd);
            double displacedConcrete = 0.0;
            if (strain > 0.0)
            {
                displacedConcrete = stressBlockProjection is double blockProjection
                    ? projection >= blockProjection ? concreteStressCap : 0.0
                    : ConcreteStress(strain, concretePeakStrain, concreteExponent, concreteStressCap, designCode.SupportsNominalReferenceCurve, useBilinear);
            }

            double force = (stress - displacedConcrete) * bar.AreaMm2;
            steelN += force;
            steelMx -= force * bar.YMm;
            steelMy += force * bar.XMm;
        }

        return new SteelIntegration(steelN, steelMx, steelMy, maxTensionStrain, maxSteelStrain, minSteelStrain);
    }

    internal static double ConcreteStress(double strain, double peakStrain, double exponent, double stressCap, bool useHognestad, bool useBilinear = false)
    {
        if (strain <= 0.0) return 0.0;
        if (strain >= peakStrain) return stressCap;
        double r = strain / peakStrain;
        // EC2 bilinear (Fig 3.4): linear ascending branch to εc3, then constant plateau to εcu3.
        if (useBilinear) return stressCap * r;
        return useHognestad
            ? stressCap * (2.0 * r - SMath.Pow(r, exponent))
            : stressCap * (1.0 - SMath.Pow(1.0 - r, exponent));
    }

    private ConcreteFiber[] GetConcreteFibers(ColumnSection section, SolverSettings settings)
    {
        string key = section switch
        {
            RectangularSection r => $"R:{r.WidthMm:G17}:{r.HeightMm:G17}:{settings.RectangularFiberCountX}:{settings.RectangularFiberCountY}",
            CircularSection c => $"C:{c.DiameterMm:G17}:{settings.CircularRadialFiberCount}:{settings.CircularAngularFiberCount}",
            _ => $"{section.Shape}:{section.WidthMm:G17}:{section.HeightMm:G17}:{settings.RectangularFiberCountX}:{settings.RectangularFiberCountY}"
        };

        if (fiberCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var fibers = section is CircularSection circular
            ? BuildCircularFibers(circular, settings.CircularRadialFiberCount, settings.CircularAngularFiberCount)
            : BuildRectangularFibers(section, settings.RectangularFiberCountX, settings.RectangularFiberCountY);
        fiberCache[key] = fibers;
        return fibers;
    }

    private static ConcreteFiber[] BuildRectangularFibers(ColumnSection section, int countX, int countY)
    {
        int nx = SMath.Max(8, countX);
        int ny = SMath.Max(8, countY);
        double dx = section.WidthMm / nx;
        double dy = section.HeightMm / ny;
        double area = dx * dy;
        double x0 = -section.WidthMm / 2.0 + dx / 2.0;
        double y0 = -section.HeightMm / 2.0 + dy / 2.0;
        var fibers = new ConcreteFiber[nx * ny];
        int index = 0;
        for (int ix = 0; ix < nx; ix++)
        {
            double x = x0 + ix * dx;
            for (int iy = 0; iy < ny; iy++)
            {
                fibers[index++] = new ConcreteFiber(x, y0 + iy * dy, area);
            }
        }

        return fibers;
    }

    private static ConcreteFiber[] BuildCircularFibers(CircularSection section, int radialCount, int angularCount)
    {
        int nr = SMath.Max(8, radialCount);
        int nt = SMath.Max(16, angularCount);
        double radius = section.RadiusMm;
        double dr = radius / nr;
        var fibers = new List<ConcreteFiber>(nr * nt);

        for (int ir = 0; ir < nr; ir++)
        {
            double r1 = ir * dr;
            double r2 = (ir + 1) * dr;
            double r = 2.0 * (r2 * r2 * r2 - r1 * r1 * r1) / (3.0 * (r2 * r2 - r1 * r1));
            double area = SMath.PI * (r2 * r2 - r1 * r1) / nt;
            for (int it = 0; it < nt; it++)
            {
                double theta = (it + 0.5) * 2.0 * SMath.PI / nt;
                fibers.Add(new ConcreteFiber(r * SMath.Cos(theta), r * SMath.Sin(theta), area));
            }
        }

        return fibers.ToArray();
    }

    private static double NormalizeExtreme(double value)
        => double.IsInfinity(value) || double.IsNaN(value) ? 0.0 : value;

    internal readonly record struct ConcreteFiber(double X, double Y, double Area);
    internal readonly record struct SteelIntegration(double N, double Mx, double My, double MaxTensionStrain, double MaxStrain, double MinStrain);
}
