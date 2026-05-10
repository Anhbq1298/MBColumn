using ColumnDesigner.Domain.Entities;
using ColumnDesigner.Domain.Enums;
using ColumnDesigner.Domain.Interfaces;

namespace ColumnDesigner.Application.Services;

public sealed class ControlPointBuilderService(IUnitConversionService units) : IControlPointBuilder
{
    private const double MatchToleranceN = 1e-6;
    private const double SpColumnPolePerturbationMoment = 0.0001;

    public DiagramControlPointSet Build(
        InteractionSurface surface,
        LoadDemand demand,
        double selectedPmAngleDegrees,
        double selectedAxialLoadN,
        UnitSystem unitSystem,
        RatioResult ratioResult,
        IDesignCodeService code)
    {
        double maxPhiPn = surface.Points.Where(p => p.PhiPn > 0).Select(p => p.PhiPn).DefaultIfEmpty(0).Max();
        double compressionLimit = code.CompressionDesignLimit(maxPhiPn);
        double compressionLimitDisplay = DisplayForce(compressionLimit, unitSystem);
        var pm = BuildPm(surface, demand, selectedPmAngleDegrees, unitSystem, ratioResult, compressionLimit);
        var mm = BuildMm(surface, demand, selectedAxialLoadN, unitSystem, ratioResult, compressionLimit);
        var pmm = BuildSurface(surface, demand, unitSystem, ratioResult, compressionLimit);
        var mm3d = BuildMmSlice(surface, demand, selectedAxialLoadN, unitSystem, ratioResult, compressionLimit);
        return new DiagramControlPointSet(pm, mm, pmm, mm3d, compressionLimitDisplay);
    }

    private IReadOnlyList<ControlPoint> BuildPm(InteractionSurface surface, LoadDemand demand, double angleDegrees, UnitSystem unitSystem, RatioResult ratio, double compressionLimit)
    {
        int angleIndex = NearestAngleIndex(surface, angleDegrees);
        int oppositeIndex = (angleIndex + surface.AngleCount / 2) % surface.AngleCount;

        // Reference behavior: PM points are stitched from one angular row followed by the opposite row
        // in reverse depth order. This gives the familiar left/right PM loop and preserves row ordering.
        var branch = surface.Points.Where(p => p.AngleIndex == angleIndex).OrderBy(p => p.DepthIndex)
            .Concat(surface.Points.Where(p => p.AngleIndex == oppositeIndex).OrderByDescending(p => p.DepthIndex))
            .ToList();

        var points = branch.Select((p, i) => ToControl(p, DiagramType.PM, unitSystem, i, "Factored", $"PM-{angleIndex}", compressionLimit, useMomentMagnitude: true)).ToList();
        double pMax = points.Max(p => p.PhiPn);
        double pMin = points.Min(p => p.PhiPn);
        points.Add(Reference(DiagramType.PM, unitSystem, pMax, "Pmax", points.Count, "Reference", $"PM-{angleIndex}"));
        points.Add(Reference(DiagramType.PM, unitSystem, pMin, "Pmin", points.Count, "Reference", $"PM-{angleIndex}"));
        points.Add(Demand(DiagramType.PM, demand, unitSystem, points.Count, "Demand", $"PM-{angleIndex}", useMomentMagnitude: true));
        if (ratio.GoverningPoint is not null)
        {
            points.Add(ToControl(ratio.GoverningPoint, DiagramType.PM, unitSystem, points.Count, "Governing", $"PM-{angleIndex}", compressionLimit, useMomentMagnitude: true) with { IsGoverningPoint = true, Label = "Governing" });
        }

        return points.OrderBy(p => p.SortKey).ToList();
    }

    private IReadOnlyList<ControlPoint> BuildMm(InteractionSurface surface, LoadDemand demand, double axialLoadN, UnitSystem unitSystem, RatioResult ratio, double compressionLimit)
    {
        var points = new List<ControlPoint>();
        // Design boundary: interpolate using factored PhiPn
        for (int a = 0; a < surface.AngleCount; a++)
        {
            var p = InterpolateAtAxial(surface, a, axialLoadN, factored: true);
            points.Add(ToControl(p, DiagramType.MM, unitSystem, a, "DesignCapacity", $"P={DisplayForce(axialLoadN, unitSystem):F1}", compressionLimit, useMomentMagnitude: false));
        }

        // Nominal boundary: interpolate using unfactored Pn, display as NominalDisplayMx/My
        for (int a = 0; a < surface.AngleCount; a++)
        {
            var p = InterpolateAtAxial(surface, a, axialLoadN, factored: false);
            var cp = ToControl(p, DiagramType.MM, unitSystem, a + surface.AngleCount, "NominalCapacity", $"P={DisplayForce(axialLoadN, unitSystem):F1}", double.MaxValue, useMomentMagnitude: false);
            // Override display values to use nominal (Mnx/Mny) instead of factored
            cp = cp with { DisplayMx = cp.NominalDisplayMx, DisplayMy = cp.NominalDisplayMy };
            points.Add(cp);
        }

        points.Add(Demand(DiagramType.MM, demand, unitSystem, points.Count, "Demand", "SelectedPu", useMomentMagnitude: false));
        if (ratio.GoverningPoint is not null)
        {
            points.Add(ToControl(ratio.GoverningPoint, DiagramType.MM, unitSystem, points.Count, "Governing", "SelectedPu", compressionLimit, useMomentMagnitude: false) with { IsGoverningPoint = true, Label = "Governing" });
        }

        return RemoveConsecutiveDuplicates(points).OrderBy(p => p.SortKey).ToList();
    }

    private IReadOnlyList<ControlPoint> BuildSurface(InteractionSurface surface, LoadDemand demand, UnitSystem unitSystem, RatioResult ratio, double compressionLimit)
    {
        var points = new List<ControlPoint>();
        
        // Design surface (factored)
        points.AddRange(surface.Points
            .Select(p => ToControl(p, DiagramType.Pm3D, unitSystem, p.DepthIndex * surface.AngleCount + p.AngleIndex, $"theta={p.ThetaDegrees:F0}", $"depth={p.DepthIndex}", compressionLimit, useMomentMagnitude: false)));
            
        // Nominal surface (unfactored)
        points.AddRange(surface.Points
            .Select(p => 
            {
                var cp = ToControl(p, DiagramType.Pm3D, unitSystem, p.DepthIndex * surface.AngleCount + p.AngleIndex, $"Nominal_theta={p.ThetaDegrees:F0}", $"depth={p.DepthIndex}", double.MaxValue, useMomentMagnitude: false);
                return cp with { DisplayMx = cp.NominalDisplayMx, DisplayMy = cp.NominalDisplayMy, DisplayP = cp.NominalDisplayP };
            }));
            
        points.Add(Demand(DiagramType.Pm3D, demand, unitSystem, points.Count, "Demand", "Demand", useMomentMagnitude: false));
        if (ratio.GoverningPoint is not null)
        {
            points.Add(ToControl(ratio.GoverningPoint, DiagramType.Pm3D, unitSystem, points.Count, "Governing", "Governing", compressionLimit, useMomentMagnitude: false) with { IsGoverningPoint = true, Label = "Governing" });
        }

        return ApplySpColumnPolePerturbation(points, surface.DepthCount);
    }

    private static IReadOnlyList<ControlPoint> ApplySpColumnPolePerturbation(IReadOnlyList<ControlPoint> points, int depthCount)
    {
        // spColumn nudges the first and last BiCurve rings by 0.0001 in the
        // theta direction so the pole rings are tiny loops instead of 36
        // perfectly coincident points. This avoids degenerate surface faces.
        return points.Select(p =>
        {
            if (p.DiagramType != DiagramType.Pm3D || p.IsDemandPoint || p.IsGoverningPoint || p.IsReferencePoint)
            {
                return p;
            }

            if (!TryDepthIndex(p.SliceKey, out int depthIndex) || (depthIndex != 0 && depthIndex != depthCount - 1))
            {
                return p;
            }

            double angleRad = p.ThetaDegrees * Math.PI / 180.0;
            double dx = SpColumnPolePerturbationMoment * Math.Cos(angleRad);
            double dy = SpColumnPolePerturbationMoment * Math.Sin(angleRad);
            return p with
            {
                DisplayMx = p.DisplayMx + dx,
                DisplayMy = p.DisplayMy + dy,
                NominalDisplayMx = p.NominalDisplayMx + dx,
                NominalDisplayMy = p.NominalDisplayMy + dy
            };
        }).ToList();
    }

    private static bool TryDepthIndex(string sliceKey, out int depthIndex)
    {
        depthIndex = 0;
        return sliceKey.StartsWith("depth=", StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(sliceKey["depth=".Length..], out depthIndex);
    }

    private IReadOnlyList<ControlPoint> BuildMmSlice(InteractionSurface surface, LoadDemand demand, double axialLoadN, UnitSystem unitSystem, RatioResult ratio, double compressionLimit)
    {
        var points = new List<ControlPoint>();
        for (int a = 0; a < surface.AngleCount; a++)
        {
            var p = InterpolateAtAxial(surface, a, axialLoadN, factored: true);
            // MmSlice points are used for the Mx-My ring; use uncapped P so interpolation
            // at any axial level stays consistent with the unclipped surface.
            points.Add(ToControl(p, DiagramType.Mm3D, unitSystem, a, $"theta={p.ThetaDegrees:F0}", $"P={DisplayForce(axialLoadN, unitSystem):F1}", double.MaxValue, useMomentMagnitude: false));
        }

        points.Add(Demand(DiagramType.Mm3D, demand, unitSystem, points.Count, "Demand", "SelectedPu", useMomentMagnitude: false));
        if (ratio.GoverningPoint is not null)
        {
            points.Add(ToControl(ratio.GoverningPoint, DiagramType.Mm3D, unitSystem, points.Count, "Governing", "SelectedPu", compressionLimit, useMomentMagnitude: false) with { IsGoverningPoint = true, Label = "Governing" });
        }

        return points;
    }

    private ControlPoint ToControl(InteractionPoint point, DiagramType diagramType, UnitSystem unitSystem, double sortKey, string label, string sliceKey, double compressionLimit, bool useMomentMagnitude)
    {
        double phiPn = point.PhiPn > 0 ? Math.Min(point.PhiPn, compressionLimit) : point.PhiPn;
        double phiMx = point.PhiMnx;
        double phiMy = point.PhiMny;
        double displayMx = useMomentMagnitude ? DisplayMoment(Math.Sqrt(phiMx * phiMx + phiMy * phiMy), unitSystem) * Math.Sign(phiMy == 0 ? phiMx : phiMy) : DisplayMoment(phiMx, unitSystem);

        // Nominal display values: always use raw Pn/Mnx/Mny (no phi, no compression cap).
        double nominalDisplayMx = useMomentMagnitude
            ? DisplayMoment(Math.Sqrt(point.Mnx * point.Mnx + point.Mny * point.Mny), unitSystem) * Math.Sign(point.Mny == 0 ? point.Mnx : point.Mny)
            : DisplayMoment(point.Mnx, unitSystem);

        return new ControlPoint(
            $"{diagramType}-{sliceKey}-{sortKey:F0}",
            diagramType,
            point.Pn,
            point.Mnx,
            point.Mny,
            point.Phi,
            phiPn,
            phiMx,
            phiMy,
            DisplayForce(phiPn, unitSystem),
            displayMx,
            useMomentMagnitude ? 0 : DisplayMoment(phiMy, unitSystem),
            DisplayForce(point.Pn, unitSystem),
            nominalDisplayMx,
            useMomentMagnitude ? 0 : DisplayMoment(point.Mny, unitSystem),
            point.ThetaDegrees,
            point.NeutralAxisDepthMm,
            false,
            false,
            false,
            label,
            sortKey,
            label,
            sliceKey);
    }

    private ControlPoint Demand(DiagramType diagramType, LoadDemand demand, UnitSystem unitSystem, double sortKey, string group, string slice, bool useMomentMagnitude)
    {
        double mx = useMomentMagnitude ? Math.Sqrt(demand.MuxNmm * demand.MuxNmm + demand.MuyNmm * demand.MuyNmm) : demand.MuxNmm;
        double displayMx = DisplayMoment(mx, unitSystem);
        double displayMy = useMomentMagnitude ? 0 : DisplayMoment(demand.MuyNmm, unitSystem);
        double displayP = DisplayForce(demand.PuN, unitSystem);
        return new ControlPoint($"Demand-{diagramType}", diagramType, demand.PuN, demand.MuxNmm, demand.MuyNmm, 1, demand.PuN, demand.MuxNmm, demand.MuyNmm, displayP, displayMx, displayMy, displayP, displayMx, displayMy, 0, 0, true, false, false, "Demand", sortKey, group, slice);
    }

    private ControlPoint Reference(DiagramType diagramType, UnitSystem unitSystem, double axialN, string label, double sortKey, string group, string slice)
    {
        double displayP = DisplayForce(axialN, unitSystem);
        return new ControlPoint($"Reference-{label}", diagramType, axialN, 0, 0, 1, axialN, 0, 0, displayP, 0, 0, displayP, 0, 0, 0, 0, false, false, true, label, sortKey, group, slice);
    }

    private static int NearestAngleIndex(InteractionSurface surface, double angleDegrees)
    {
        double normalized = ((angleDegrees % 360) + 360) % 360;
        double step = 360.0 / surface.AngleCount;
        return (int)Math.Round(normalized / step) % surface.AngleCount;
    }

    private static InteractionPoint InterpolateAtAxial(InteractionSurface surface, int angleIndex, double axialN, bool factored)
    {
        var points = surface.Points.Where(p => p.AngleIndex == angleIndex).OrderBy(p => p.DepthIndex).ToList();
        for (int i = 0; i < points.Count - 1; i++)
        {
            double pa = factored ? points[i].PhiPn : points[i].Pn;
            double pb = factored ? points[i + 1].PhiPn : points[i + 1].Pn;
            if ((pa <= axialN && pb >= axialN) || (pa >= axialN && pb <= axialN))
            {
                double t = Math.Abs(pb - pa) < MatchToleranceN ? 0 : (axialN - pa) / (pb - pa);
                return Lerp(points[i], points[i + 1], t);
            }
        }

        return points.MinBy(p => Math.Abs((factored ? p.PhiPn : p.Pn) - axialN))!;
    }

    private static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t)
        => new(a.DepthIndex, a.AngleIndex, Linear(a.ThetaDegrees, b.ThetaDegrees, t), Linear(a.NeutralAxisDepthMm, b.NeutralAxisDepthMm, t), Linear(a.Pn, b.Pn, t), Linear(a.Mnx, b.Mnx, t), Linear(a.Mny, b.Mny, t), Linear(a.Phi, b.Phi, t), Linear(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, t));

    private static double Linear(double a, double b, double t) => a + (b - a) * t;

    private static IReadOnlyList<ControlPoint> RemoveConsecutiveDuplicates(IReadOnlyList<ControlPoint> points)
    {
        var result = new List<ControlPoint>();
        foreach (var p in points)
        {
            if (result.Count == 0 || Math.Abs(result[^1].PhiPn - p.PhiPn) > 1e-6 || Math.Abs(result[^1].PhiMnx - p.PhiMnx) > 1e-6 || Math.Abs(result[^1].PhiMny - p.PhiMny) > 1e-6)
            {
                result.Add(p);
            }
        }

        return result;
    }

    private double DisplayForce(double forceN, UnitSystem unitSystem) => units.ForceFromN(forceN, unitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip);
    private double DisplayMoment(double momentNmm, UnitSystem unitSystem) => units.MomentFromNmm(momentNmm, unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt);
}
