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
        var diagramService = new DiagramDataService();
        var pmAngle = diagramService.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, requestedTheta);
        var designPoints = pmAngle.ReducedCapacityPoints;
        if (designPoints.Count == 0) return [];

        var specialPts = pmAngle.SpecialCapacityPoints;
        var grouped = GroupByAxialLevel(designPoints);

        // For each special point, find the nearest normal group by P and mark it for exclusion
        // so the total stays at (N - specialCount) normal + specialCount rows.
        var excludedGroups = new HashSet<int>();
        foreach (var sp in specialPts)
        {
            int nearest = -1;
            double minDist = double.MaxValue;
            for (int i = 0; i < grouped.Count; i++)
            {
                if (excludedGroups.Contains(i)) continue;
                double dist = Math.Abs(grouped[i].Average(p => p.P) - sp.P);
                if (dist < minDist) { minDist = dist; nearest = i; }
            }
            if (nearest >= 0) excludedGroups.Add(nearest);
        }

        // Build normal rows without remarks
        var unsorted = new List<ControlPointExportRow>();
        for (int i = 0; i < grouped.Count; i++)
        {
            if (excludedGroups.Contains(i)) continue;
            var row = ToRow(result, requestedTheta, 0, grouped[i]);
            unsorted.Add(row with { Remarks = "" });
        }

        // Add special rows — match to nearest surface point for NA depth and strains
        foreach (var sp in specialPts)
        {
            var matched = MatchInteractionPoint(result, requestedTheta, sp);
            unsorted.Add(new ControlPointExportRow
            {
                ThetaDeg = requestedTheta,
                PointIndex = 0,
                P = sp.P,
                MThetaPositive = Math.Max(0.0, sp.X),
                MThetaNegative = Math.Min(0.0, sp.X),
                NeutralAxisDepth = matched is not null
                    ? DisplayLength(matched.NeutralAxisDepthMm, result.UnitSystem)
                    : DisplayLength(sp.NeutralAxisDepth, result.UnitSystem),
                SteelStrainMax = matched is null ? 0.0 : SignedMaxAbs(
                    matched.MaxSteelStrain, matched.MinSteelStrain, matched.MaxTensionSteelStrain,
                    double.NaN, double.NaN, double.NaN),
                ConcreteStrainMax = matched is null ? 0.0 : MaxPositive(
                    matched.MaxConcreteStrain, double.NaN),
                Remarks = sp.Label
            });
        }

        // Sort by P descending and assign sequential indices
        var sorted = unsorted.OrderByDescending(r => r.P).ToList();
        for (int i = 0; i < sorted.Count; i++)
            sorted[i] = sorted[i] with { PointIndex = i + 1 };

        return sorted;
    }

    private ControlPointExportRow ToRow(
        CalculationResultDto result,
        double thetaDegrees,
        int pointIndex,
        IReadOnlyList<ControlPointDto> group)
    {
        var positive = group.MaxBy(p => p.X);
        var negative = group.MinBy(p => p.X);
        var positiveMatch = positive is null ? null : MatchInteractionPoint(result, thetaDegrees, positive);
        var negativeMatch = negative is null ? null : MatchInteractionPoint(result, thetaDegrees, negative);

        double displayLength = DisplayLength(
            RepresentativeDepthMm(positiveMatch, negativeMatch, positive, negative),
            result.UnitSystem);

        return new ControlPointExportRow
        {
            ThetaDeg = thetaDegrees,
            PointIndex = pointIndex,
            P = group.Average(p => p.P),
            MThetaPositive = positive is null ? 0.0 : Math.Max(0.0, positive.X),
            MThetaNegative = negative is null ? 0.0 : Math.Min(0.0, negative.X),
            NeutralAxisDepth = displayLength,
            SteelStrainMax = SignedMaxAbs(
                positiveMatch?.MaxSteelStrain ?? double.NaN,
                positiveMatch?.MinSteelStrain ?? double.NaN,
                positiveMatch?.MaxTensionSteelStrain ?? double.NaN,
                negativeMatch?.MaxSteelStrain ?? double.NaN,
                negativeMatch?.MinSteelStrain ?? double.NaN,
                negativeMatch?.MaxTensionSteelStrain ?? double.NaN),
            ConcreteStrainMax = MaxPositive(
                positiveMatch?.MaxConcreteStrain ?? double.NaN,
                negativeMatch?.MaxConcreteStrain ?? double.NaN),
            Remarks = ResolveRemarks(positiveMatch, negativeMatch)
        };
    }

    private IReadOnlyList<IReadOnlyList<ControlPointDto>> GroupByAxialLevel(IReadOnlyList<ControlPointDto> points)
    {
        if (points.Count == 0)
        {
            return [];
        }

        double minP = points.Min(p => p.P);
        double maxP = points.Max(p => p.P);
        double tolerance = Math.Max((maxP - minP) * 1e-6, 1e-6);
        var ordered = points
            .OrderByDescending(p => p.P)
            .ThenByDescending(p => p.X)
            .ToList();

        var groups = new List<IReadOnlyList<ControlPointDto>>();
        var current = new List<ControlPointDto>();
        double? currentP = null;

        foreach (var point in ordered)
        {
            if (currentP is null || Math.Abs(point.P - currentP.Value) <= tolerance)
            {
                current.Add(point);
                currentP ??= point.P;
                continue;
            }

            groups.Add(current.ToList());
            current.Clear();
            current.Add(point);
            currentP = point.P;
        }

        if (current.Count > 0)
        {
            groups.Add(current.ToList());
        }

        return groups;
    }

    private InteractionPoint? MatchInteractionPoint(CalculationResultDto result, double requestedTheta, ControlPointDto point)
    {
        var best = result.Surface.Points
            .Select(surfacePoint => new
            {
                Point = surfacePoint,
                Score = MatchScore(result.UnitSystem, requestedTheta, point, surfacePoint)
            })
            .OrderBy(x => x.Score)
            .FirstOrDefault();

        return best?.Point;
    }

    private double MatchScore(UnitSystem unitSystem, double requestedTheta, ControlPointDto target, InteractionPoint candidate)
    {
        double candidateP = DisplayForce(candidate.PhiPn, unitSystem);
        double candidateMtheta = DisplayMoment(
            candidate.PhiMnx * Math.Cos(requestedTheta * Math.PI / 180.0) +
            candidate.PhiMny * Math.Sin(requestedTheta * Math.PI / 180.0),
            unitSystem);
        double candidateDepth = DisplayLength(candidate.NeutralAxisDepthMm, unitSystem);

        return Math.Abs(candidateP - target.P)
            + Math.Abs(candidateMtheta - target.X)
            + Math.Abs(candidateDepth - DisplayLength(target.NeutralAxisDepth, unitSystem));
    }

    private string ResolveRemarks(InteractionPoint? positive, InteractionPoint? negative)
    {
        string positiveLabel = ResolveRemark(positive);
        string negativeLabel = ResolveRemark(negative);

        if (string.IsNullOrWhiteSpace(positiveLabel))
        {
            return negativeLabel;
        }

        if (string.IsNullOrWhiteSpace(negativeLabel) || positiveLabel.Equals(negativeLabel, StringComparison.OrdinalIgnoreCase))
        {
            return positiveLabel;
        }

        return $"{positiveLabel} / {negativeLabel}";
    }

    private string ResolveRemark(InteractionPoint? point)
    {
        if (point is null)
        {
            return "";
        }

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

    private double DisplayForce(double forceN, UnitSystem unitSystem)
        => units.ForceFromN(forceN, unitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip);

    private double DisplayMoment(double momentNmm, UnitSystem unitSystem)
        => units.MomentFromNmm(momentNmm, unitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt);

    private double DisplayLength(double lengthMm, UnitSystem unitSystem)
        => unitSystem == UnitSystem.Metric ? lengthMm : units.LengthFromMm(lengthMm, LengthUnit.Inch);

    private static double RepresentativeDepthMm(
        InteractionPoint? positiveMatch,
        InteractionPoint? negativeMatch,
        ControlPointDto? positive,
        ControlPointDto? negative)
    {
        if (positiveMatch is not null && negativeMatch is not null)
        {
            return (positiveMatch.NeutralAxisDepthMm + negativeMatch.NeutralAxisDepthMm) * 0.5;
        }

        if (positiveMatch is not null)
        {
            return positiveMatch.NeutralAxisDepthMm;
        }

        if (negativeMatch is not null)
        {
            return negativeMatch.NeutralAxisDepthMm;
        }

        if (positive is not null && negative is not null)
        {
            return (positive.NeutralAxisDepth + negative.NeutralAxisDepth) * 0.5;
        }

        return positive?.NeutralAxisDepth ?? negative?.NeutralAxisDepth ?? 0.0;
    }

    private static double SignedMaxAbs(params double[] values)
    {
        var valid = values.Where(v => !double.IsNaN(v) && !double.IsInfinity(v)).ToList();
        if (valid.Count == 0) return 0.0;
        return valid.OrderByDescending(Math.Abs).First();
    }

    private static double MaxPositive(params double[] values)
        => values.Where(v => !double.IsNaN(v) && !double.IsInfinity(v) && v > 0).DefaultIfEmpty(0.0).Max();

    private static double NormalizeAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle))
        {
            return 0.0;
        }

        double normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }
}
