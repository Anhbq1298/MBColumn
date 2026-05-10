using ColumnDesigner.Domain.Entities;
using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Application.Services;

public sealed class RatioCheckService : IRatioCheckService
{
    private const double NearZero = 1e-9;

    public RatioResult Check(InteractionSurface surface, LoadDemand demand)
    {
        double demandMoment = Math.Sqrt(demand.MuxNmm * demand.MuxNmm + demand.MuyNmm * demand.MuyNmm);
        if (demandMoment < NearZero)
        {
            double pCapacity = demand.PuN >= 0
                ? surface.Points.Max(p => p.PhiPn)
                : Math.Abs(surface.Points.Min(p => p.PhiPn));
            double ratio = pCapacity <= NearZero ? double.PositiveInfinity : Math.Abs(demand.PuN) / pCapacity;
            var gov = demand.PuN >= 0
                ? surface.Points.MaxBy(p => p.PhiPn)
                : surface.Points.MinBy(p => p.PhiPn);
            return new RatioResult(ratio, ratio <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail, gov, demandMoment, 0, "Pure axial demand.");
        }

        double demandAngle = Math.Atan2(demand.MuyNmm, demand.MuxNmm);
        double selectedCapacity = 0.0;
        InteractionPoint? governing = null;

        for (int a = 0; a < surface.AngleCount; a++)
        {
            var point = InterpolateAtAxial(surface, a, demand.PuN);
            double capAngle = Math.Atan2(point.PhiMny, point.PhiMnx);
            double alignment = Math.Cos(NormalizeRadians(capAngle - demandAngle));
            if (alignment <= 0.0)
            {
                continue;
            }

            double projected = Math.Sqrt(point.PhiMnx * point.PhiMnx + point.PhiMny * point.PhiMny) * alignment;
            if (projected > selectedCapacity)
            {
                selectedCapacity = projected;
                governing = point;
            }
        }

        double momentRatio = selectedCapacity <= NearZero ? double.PositiveInfinity : demandMoment / selectedCapacity;
        double axialLimit = demand.PuN >= 0 ? surface.Points.Max(p => p.PhiPn) : Math.Abs(surface.Points.Min(p => p.PhiPn));
        double axialRatio = axialLimit <= NearZero ? 0 : Math.Abs(demand.PuN) / axialLimit;
        double ratioResult = Math.Max(momentRatio, axialRatio);
        return new RatioResult(ratioResult, ratioResult <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail, governing, demandMoment, selectedCapacity, "Directional PMM capacity check.");
    }

    private static InteractionPoint InterpolateAtAxial(InteractionSurface surface, int angleIndex, double axialN)
    {
        var points = surface.Points.Where(p => p.AngleIndex == angleIndex).OrderBy(p => p.DepthIndex).ToList();
        for (int i = 0; i < points.Count - 1; i++)
        {
            var a = points[i];
            var b = points[i + 1];
            if ((a.PhiPn <= axialN && b.PhiPn >= axialN) || (a.PhiPn >= axialN && b.PhiPn <= axialN))
            {
                double t = Math.Abs(b.PhiPn - a.PhiPn) < NearZero ? 0.0 : (axialN - a.PhiPn) / (b.PhiPn - a.PhiPn);
                return Lerp(a, b, t);
            }
        }

        return points.MinBy(p => Math.Abs(p.PhiPn - axialN))!;
    }

    private static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t)
        => new(a.DepthIndex, a.AngleIndex, Linear(a.ThetaDegrees, b.ThetaDegrees, t), Linear(a.NeutralAxisDepthMm, b.NeutralAxisDepthMm, t), Linear(a.Pn, b.Pn, t), Linear(a.Mnx, b.Mnx, t), Linear(a.Mny, b.Mny, t), Linear(a.Phi, b.Phi, t), Linear(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, t));

    private static double Linear(double a, double b, double t) => a + (b - a) * t;
    private static double NormalizeRadians(double value) => Math.Atan2(Math.Sin(value), Math.Cos(value));
}
