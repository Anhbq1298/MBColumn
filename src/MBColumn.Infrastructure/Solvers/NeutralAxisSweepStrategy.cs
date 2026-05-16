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
                states.Add(new NeutralAxisState
                {
                    DepthIndex = d,
                    AngleIndex = a,
                    ThetaRad = theta,
                    NeutralAxisDepth = c,
                    ExtremeCompressionStrain = ecu,
                    NeutralAxisOffset = maxProjection - c,
                    CompressionNormal = new Vector2D(nx, ny)
                });
            }
        }

        return states;
    }

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
}
