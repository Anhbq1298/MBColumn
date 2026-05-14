using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public sealed class ControlPointPreviewService(IUnitConversionService units) : IControlPointPreviewService
{
    private const double ThetaTolerance = 1e-9;

    public ControlPointPreviewResult BuildPreview(
        CalculationResultDto result,
        ControlPointThetaSelectionMode mode,
        double currentThetaDegrees,
        double? customThetaDegrees = null)
    {
        if (result.Surface.Points.Count == 0)
        {
            return new ControlPointPreviewResult([], [], "No control points are available for export.");
        }

        var availableThetas = result.Surface.Points
            .Select(p => NormalizeAngle(p.ThetaDegrees))
            .Distinct()
            .OrderBy(t => t)
            .ToList();

        return mode switch
        {
            ControlPointThetaSelectionMode.CurrentView => BuildSingleThetaPreview(
                result,
                availableThetas,
                NormalizeAngle(currentThetaDegrees)),
            ControlPointThetaSelectionMode.CustomTheta => customThetaDegrees is null
                ? new ControlPointPreviewResult([], availableThetas, "Enter a valid theta angle to preview control points.")
                : BuildSingleThetaPreview(result, availableThetas, NormalizeAngle(customThetaDegrees.Value)),
            ControlPointThetaSelectionMode.AllTheta => BuildAllThetaPreview(result, availableThetas),
            _ => new ControlPointPreviewResult([], availableThetas, "No control points are available for export.")
        };
    }

    private ControlPointPreviewResult BuildSingleThetaPreview(
        CalculationResultDto result,
        IReadOnlyList<double> availableThetas,
        double requestedTheta)
    {
        if (availableThetas.Count == 0)
        {
            return new ControlPointPreviewResult([], [], "No control points are available for export.");
        }

        var rows = BuildThetaRows(result, availableThetas, requestedTheta);
        string message = rows.Count == 0
            ? $"No valid control points are available for \u03b8 = {requestedTheta:F1}\u00b0."
            : "";
        return new ControlPointPreviewResult(rows, [requestedTheta], message);
    }

    private ControlPointPreviewResult BuildAllThetaPreview(CalculationResultDto result, IReadOnlyList<double> availableThetas)
    {
        var rows = new List<ControlPointExportRow>();
        foreach (double theta in availableThetas)
        {
            rows.AddRange(BuildThetaRows(result, availableThetas, theta));
        }

        string message = rows.Count == 0
            ? "No valid control points are available for export."
            : "";
        return new ControlPointPreviewResult(rows, availableThetas, message);
    }

    private IReadOnlyList<ControlPointExportRow> BuildThetaRows(
        CalculationResultDto result,
        IReadOnlyList<double> availableThetas,
        double requestedTheta)
    {
        var points = ResolveThetaDataset(result.Surface, availableThetas, requestedTheta);
        if (points.Count == 0)
        {
            return [];
        }

        return points
            .OrderByDescending(p => p.PhiPn)
            .ThenBy(p => p.DepthIndex)
            .Select((point, index) => ToRow(result.UnitSystem, requestedTheta, index + 1, point))
            .ToList();
    }

    private IReadOnlyList<InteractionPoint> ResolveThetaDataset(
        InteractionSurface surface,
        IReadOnlyList<double> availableThetas,
        double requestedTheta)
    {
        double angleStep = 360.0 / surface.AngleCount;
        int exactIndex = FindExactThetaIndex(availableThetas, requestedTheta);
        if (exactIndex >= 0)
        {
            return surface.Points
                .Where(p => p.AngleIndex == exactIndex)
                .OrderBy(p => p.DepthIndex)
                .ToList();
        }

        double normalized = NormalizeAngle(requestedTheta);
        double scaled = normalized / angleStep;
        int lowerIndex = (int)Math.Floor(scaled) % surface.AngleCount;
        int upperIndex = (lowerIndex + 1) % surface.AngleCount;
        double lowerTheta = lowerIndex * angleStep;
        double upperTheta = upperIndex == 0 ? 360.0 : upperIndex * angleStep;
        double adjustedTheta = normalized;
        if (upperTheta <= lowerTheta)
        {
            upperTheta += 360.0;
            if (adjustedTheta < lowerTheta)
            {
                adjustedTheta += 360.0;
            }
        }

        double denominator = upperTheta - lowerTheta;
        double t = denominator < ThetaTolerance ? 0.0 : Math.Clamp((adjustedTheta - lowerTheta) / denominator, 0.0, 1.0);

        var lowerRow = surface.Points
            .Where(p => p.AngleIndex == lowerIndex)
            .OrderBy(p => p.DepthIndex)
            .ToList();
        var upperRow = surface.Points
            .Where(p => p.AngleIndex == upperIndex)
            .OrderBy(p => p.DepthIndex)
            .ToList();

        int count = Math.Min(lowerRow.Count, upperRow.Count);
        var result = new List<InteractionPoint>(count);
        for (int i = 0; i < count; i++)
        {
            result.Add(Lerp(lowerRow[i], upperRow[i], t, requestedTheta));
        }

        return result;
    }

    private ControlPointExportRow ToRow(UnitSystem unitSystem, double thetaDegrees, int pointIndex, InteractionPoint point)
    {
        double thetaRadians = thetaDegrees * Math.PI / 180.0;
        double mTheta = point.PhiMnx * Math.Cos(thetaRadians) + point.PhiMny * Math.Sin(thetaRadians);
        double displayLength = unitSystem == UnitSystem.Metric
            ? point.NeutralAxisDepthMm
            : units.LengthFromMm(point.NeutralAxisDepthMm, LengthUnit.Inch);

        return new ControlPointExportRow
        {
            ThetaDeg = thetaDegrees,
            PointIndex = pointIndex,
            P = DisplayForce(point.PhiPn, unitSystem),
            MThetaPositive = mTheta > 0 ? DisplayMoment(mTheta, unitSystem) : 0.0,
            MThetaNegative = mTheta < 0 ? DisplayMoment(mTheta, unitSystem) : 0.0,
            NeutralAxisDepth = displayLength,
            SteelStrainMax = MaxAbs(point.MaxSteelStrain, point.MinSteelStrain, point.MaxTensionSteelStrain),
            ConcreteStrainMax = MaxAbs(point.MaxConcreteStrain, point.MinConcreteStrain),
            Remarks = ResolveRemarks(point)
        };
    }

    private string ResolveRemarks(InteractionPoint point)
    {
        string label = point.StateLabel?.Trim() ?? "";
        if (label.Equals("Pure axial compression", StringComparison.OrdinalIgnoreCase))
        {
            return "Pure Compression";
        }

        if (label.Equals("Pure compression", StringComparison.OrdinalIgnoreCase))
        {
            return "Pure Compression";
        }

        if (label.Equals("Pure tension", StringComparison.OrdinalIgnoreCase))
        {
            return "Tension Controlled";
        }

        if (!string.IsNullOrWhiteSpace(label))
        {
            return label;
        }

        if (Math.Abs(point.Pn) <= 1e-6)
        {
            return "Pure Bending";
        }

        return "";
    }

    private static InteractionPoint Lerp(InteractionPoint a, InteractionPoint b, double t, double thetaDegrees)
        => new(
            a.DepthIndex,
            a.AngleIndex,
            thetaDegrees,
            Linear(a.NeutralAxisDepthMm, b.NeutralAxisDepthMm, t),
            Linear(a.Pn, b.Pn, t),
            Linear(a.Mnx, b.Mnx, t),
            Linear(a.Mny, b.Mny, t),
            Linear(a.Phi, b.Phi, t),
            Linear(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, t),
            Linear(a.ConcretePn, b.ConcretePn, t),
            Linear(a.SteelPn, b.SteelPn, t),
            Linear(a.ConcreteMnx, b.ConcreteMnx, t),
            Linear(a.ConcreteMny, b.ConcreteMny, t),
            Linear(a.SteelMnx, b.SteelMnx, t),
            Linear(a.SteelMny, b.SteelMny, t),
            Linear(a.MaxConcreteStrain, b.MaxConcreteStrain, t),
            Linear(a.MinConcreteStrain, b.MinConcreteStrain, t),
            Linear(a.MaxSteelStrain, b.MaxSteelStrain, t),
            Linear(a.MinSteelStrain, b.MinSteelStrain, t),
            string.IsNullOrWhiteSpace(a.StateLabel) ? b.StateLabel : a.StateLabel);

    private int FindExactThetaIndex(IReadOnlyList<double> availableThetas, double requestedTheta)
    {
        for (int i = 0; i < availableThetas.Count; i++)
        {
            if (Math.Abs(availableThetas[i] - requestedTheta) <= ThetaTolerance)
            {
                return i;
            }
        }

        return -1;
    }

    private double DisplayForce(double forceN, UnitSystem unitSystem)
        => units.ForceFromN(forceN, unitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip);

    private double DisplayMoment(double momentNmm, UnitSystem unitSystem)
        => units.MomentFromNmm(momentNmm, unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt);

    private static double MaxAbs(params double[] values)
        => values.Where(v => !double.IsNaN(v) && !double.IsInfinity(v)).Select(Math.Abs).DefaultIfEmpty(0.0).Max();

    private static double NormalizeAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle))
        {
            return 0.0;
        }

        double normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    private static double Linear(double a, double b, double t) => a + (b - a) * t;
}
