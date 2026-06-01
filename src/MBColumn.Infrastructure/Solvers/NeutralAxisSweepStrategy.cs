using MBColumn.Domain.Entities;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Solvers;

public sealed class NeutralAxisSweepStrategy : ISweepStrategy
{
    public IReadOnlyList<NeutralAxisState> GenerateStates(PmmInput input)
    {
        int angleCount = SMath.Max(1, (int)SMath.Round(360.0 / input.Settings.AngleStepDegrees));
        int depthCount = SMath.Max(2, input.Settings.NeutralAxisSamples);
        double cMax = 10.0 * SMath.Max(input.Section.WidthMm, input.Section.HeightMm);
        double ecu = input.DesignCode.ConcreteUltimateStrain(input.Concrete.FcMpa);
        double peakCompressionStrain = input.DesignCode.ConcretePeakStrain(input.Concrete.FcMpa);
        bool useEc2 = input.DesignCode.UseEc2CompressionDomain;
        var states = new List<NeutralAxisState>(angleCount * depthCount);

        for (int d = 0; d < depthCount; d++)
        {
            double c = 0.1 + d * (cMax - 0.1) / (depthCount - 1);
            for (int a = 0; a < angleCount; a++)
            {
                double theta = a * input.Settings.AngleStepDegrees * SMath.PI / 180.0;
                double nx = SMath.Cos(theta);
                double ny = SMath.Sin(theta);
                double maxProjection = ProjectExtreme(input.Section, nx, ny);
                double minProjection = ProjectMin(input.Section, nx, ny);
                double hTheta = maxProjection - minProjection;

                double epsExtreme;
                double epsFar;
                if (useEc2)
                {
                    if (c <= hTheta)
                    {
                        // Domains A/B — flexure. Reduces to the legacy εcu plane through the neutral axis.
                        // c < hθ → epsFar < 0 (tension); c = hθ → epsFar = 0 (far fibre at the neutral axis).
                        epsExtreme = ecu;
                        epsFar = ecu * (1.0 - hTheta / c);
                    }
                    else
                    {
                        // Domain C — high-compression transition. Pivot toward uniform εc3 (EC2 Fig 6.1).
                        // t = 0 at c = hθ (εcu3, 0); t = 1 at c = cMax (εc3, εc3 = pure compression).
                        double t = (c - hTheta) / (cMax - hTheta);
                        epsExtreme = Lerp(ecu, peakCompressionStrain, t);
                        epsFar = Lerp(0.0, peakCompressionStrain, t);
                    }
                }
                else
                {
                    // Legacy / ACI — uniform εcu plane; GetStrainAtProjection uses the original formula.
                    epsExtreme = ecu;
                    epsFar = ecu * (1.0 - hTheta / c);
                }

                states.Add(new NeutralAxisState
                {
                    DepthIndex = d,
                    AngleIndex = a,
                    ThetaRad = theta,
                    NeutralAxisDepth = c,
                    ExtremeCompressionStrain = epsExtreme,
                    FarFiberStrain = epsFar,
                    NeutralAxisOffset = maxProjection - c,
                    MaxProjection = maxProjection,
                    MinProjection = minProjection,
                    SectionDepthAlongNormal = hTheta,
                    UseEc2CompressionDomain = useEc2,
                    CompressionNormal = new Vector2D(nx, ny)
                });
            }
        }

        return states;
    }

    private static double Lerp(double a, double b, double t) => a + (b - a) * t;

    public static double ProjectExtreme(ColumnSection section, double nx, double ny)
    {
        if (section is CircularSection circular)
        {
            return circular.RadiusMm;
        }

        if (section is IrregularSection irregular)
        {
            double max = double.NegativeInfinity;
            foreach (var p in irregular.BoundaryPoints)
            {
                double proj = p.X * nx + p.Y * ny;
                if (proj > max) max = proj;
            }
            return max;
        }

        double hx = section.WidthMm / 2.0;
        double hy = section.HeightMm / 2.0;
        return SMath.Max(
            SMath.Abs(hx * nx + hy * ny),
            SMath.Abs(hx * nx - hy * ny));
    }

    // Minimum (far-fibre) projection onto the compression normal. Rectangular and circular
    // sections are symmetric about the origin, so min = −max; irregular sections need the
    // actual minimum over the boundary.
    public static double ProjectMin(ColumnSection section, double nx, double ny)
    {
        if (section is IrregularSection irregular)
        {
            double min = double.PositiveInfinity;
            foreach (var p in irregular.BoundaryPoints)
            {
                double proj = p.X * nx + p.Y * ny;
                if (proj < min) min = proj;
            }
            return min;
        }

        return -ProjectExtreme(section, nx, ny);
    }
}
