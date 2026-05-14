using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;

using System.Globalization;
using System.Text;

namespace MBColumn.Application.Services;

public static class PmCurveBuilderService
{
    private const int AxialLevels = 100;
    private const double AciTiedCompressionPhi = 0.65;
    private const double AciTiedAxialCapFactor = 0.80;
    public static bool EnableDebugDiagnostics { get; set; }
    public static PmCurveBuildDiagnostics? LastDiagnostics { get; private set; }

    public static IReadOnlyList<ControlPointDto> BuildPmAngleCurve(IEnumerable<ControlPoint> source, double designCompressionLimitDisplay, double angleDegrees)
        => BuildAngleCurve(source, designCompressionLimitDisplay, null, angleDegrees);

    public static IReadOnlyList<ControlPointDto> BuildPmAngleCurve(IEnumerable<ControlPoint> source, double designCompressionLimitDisplay, double nominalCompressionLimitDisplay, double angleDegrees)
        => BuildAngleCurve(source, designCompressionLimitDisplay, nominalCompressionLimitDisplay, angleDegrees);

    public static IReadOnlyList<ChartReferenceLineDto> BuildPmAngleReferenceLines(IReadOnlyList<ControlPointDto> points)
    {
        var pmax = points.FirstOrDefault(p => p.IsReference && p.Label.Equals("Pmax", StringComparison.OrdinalIgnoreCase));
        if (pmax is null) return [];

        double pmaxY = pmax.Y;
        double tolerance = Math.Max(Math.Abs(pmaxY) * 1e-6, 1e-6);
        var designCap = points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
            .Where(p => Math.Abs(p.Y - pmaxY) <= tolerance)
            .OrderBy(p => p.X)
            .ToList();
        if (designCap.Count < 2) return [];

        var left = designCap.First();
        var right = designCap.Last();
        var compressionTransitionPoint = FindAciCompressionTransitionPoint(points, pmaxY);
        if (compressionTransitionPoint is null) return [];

        return
        [
            new ChartReferenceLineDto(compressionTransitionPoint.X, compressionTransitionPoint.Y, left.X, left.Y, "", "CompressionTransition"),
            new ChartReferenceLineDto(compressionTransitionPoint.X, compressionTransitionPoint.Y, right.X, right.Y, "", "CompressionTransition")
        ];
    }

    private static ControlPointDto? FindAciCompressionTransitionPoint(IReadOnlyList<ControlPointDto> points, double designCapP)
    {
        // Draw the upper factored compression transition from the reduced
        // pure-compression point, not from the outer nominal Po point. For ACI tied
        // columns the decompiled reduction factors are C = 0.65 and A = 0.80, so:
        //   transition P = 0.65 * Po
        //   design cap P = 0.80 * transition P
        // The current MVP uses tied rectangular columns, so this follows that path.
        var nominal = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && p.IsNominal).ToList();
        double transitionP;

        if (Math.Abs(designCapP) > 1e-9)
        {
            transitionP = designCapP / AciTiedAxialCapFactor;
        }
        else if (nominal.Count > 0)
        {
            double nominalPo = nominal.Max(p => p.Y);
            transitionP = AciTiedCompressionPhi * nominalPo;
        }
        else
        {
            return null;
        }

        return new ControlPointDto(
            DiagramType: DiagramType.PM,
            X: 0.0,
            Y: transitionP,
            Z: 0.0,
            P: transitionP,
            Mx: 0.0,
            My: 0.0,
            Phi: AciTiedCompressionPhi,
            ThetaDegrees: 0.0,
            NeutralAxisDepth: 0.0,
            Label: "",
            GroupKey: "AciCompressionTransition",
            IsDemand: false,
            IsGoverning: false,
            IsReference: true,
            IsNominal: false);
    }

    private static IReadOnlyList<ControlPointDto> BuildAngleCurve(IEnumerable<ControlPoint> source, double designCompressionLimitDisplay, double? nominalCompressionLimitDisplay, double angleDegrees)
    {
        var raw = source.ToList();
        var clean = raw.Where(IsValid).ToList();
        var capacity = clean.Where(p => !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint).ToList();
        var designCapacity = capacity.Where(p => !IsNominalPoint(p)).ToList();
        if (designCapacity.Count == 0) return [];

        var designRows = designCapacity
            .GroupBy(p => p.GroupKey)
            .Select(g => g.OrderByDescending(DesignDisplayP).ToList())
            .Where(g => g.Count > 1)
            .ToList();
        double designPMaxRaw = designCapacity.Max(DesignDisplayP);
        double designPMin = designCapacity.Min(DesignDisplayP);
        double designCap = Math.Min(designPMaxRaw, designCompressionLimitDisplay);
        
        var design = BuildAngleEnvelopeLoop(designRows, designCap, designPMin, angleDegrees, nominal: false, forceStraightTrimCap: true).ToList();

        // Build nominal curve separately to respect its own (usually higher) cap
        var nominalPointsSource = capacity.Where(IsNominalPoint).ToList();
        Console.WriteLine($"DEBUG: capacity={capacity.Count}, nominalSource={nominalPointsSource.Count}");
        var nominalRows = nominalPointsSource
            .GroupBy(p => p.GroupKey)
            .Select(g => g.OrderByDescending(p => p.NominalDisplayP).ToList())
            .Where(g => g.Count > 1)
            .ToList();
        
        double nominalPMaxRaw = nominalPointsSource.Count > 0 ? nominalPointsSource.Max(p => p.NominalDisplayP) : designPMaxRaw / 0.65;
        double nominalPMin = nominalPointsSource.Count > 0 ? nominalPointsSource.Min(p => p.NominalDisplayP) : designPMin / 0.9;
        double nominalCap = Math.Min(nominalPMaxRaw, nominalCompressionLimitDisplay ?? double.MaxValue);

        var nominal = BuildAngleEnvelopeLoop(nominalRows, nominalCap, nominalPMin, angleDegrees, nominal: true, forceStraightTrimCap: true).ToList();

        var result = new List<ControlPointDto>(design.Select(p => ToAngleDto(p, "DesignCapacity", isNominal: false)));
        result.AddRange(nominal.Select(p => ToAngleDto(p, "NominalCapacity", isNominal: true)));
        result.Add(ReferenceDto(designCompressionLimitDisplay, "Pmax"));
        result.Add(ReferenceDto(designPMin, "Pmin"));

        var demand = clean.FirstOrDefault(p => p.IsDemandPoint);
        if (demand is not null) result.Add(ProjectMarkerAngle(demand, angleDegrees, "Demand"));
        var governing = clean.FirstOrDefault(p => p.IsGoverningPoint);
        if (governing is not null) result.Add(ProjectMarkerAngle(governing, angleDegrees, "Governing"));

        if (EnableDebugDiagnostics)
        {
            var warnings = ValidateAngleSourcePairing(capacity, angleDegrees)
                .ToList();
            LastDiagnostics = new PmCurveBuildDiagnostics(
                raw.Count,
                clean.Count,
                raw.Count - clean.Count,
                designRows.Count == 0 ? 0 : designRows.Max(row => row.Count),
                design.Count(p => p.IsPositiveBranch),
                design.Count(p => !p.IsPositiveBranch),
                design.Count,
                NominalAndDesignSeparated: true,
                SmoothingApplied: false,
                NominalPositiveBranchCount: nominal.Count(p => p.IsPositiveBranch),
                NominalNegativeBranchCount: nominal.Count(p => !p.IsPositiveBranch),
                FinalNominalCurveCount: nominal.Count,
                DesignPMaxDisplay: designCap,
                NominalPMaxDisplay: nominal.Count == 0 ? 0 : nominal.Max(p => p.P),
                ValidationWarnings: warnings);
        }

        return result;
    }

    private static IReadOnlyList<AngleEnvelopePoint> BuildAngleEnvelopeLoop(
        IReadOnlyList<IReadOnlyList<ControlPoint>> thetaRows,
        double pMax,
        double pMin,
        double angleDegrees,
        bool nominal,
        bool forceStraightTrimCap)
    {
        double pRange = Math.Max(1e-9, pMax - pMin);
        double pTol = pRange * 1e-6;
        var positive = new List<AngleEnvelopePoint>();
        var negative = new List<AngleEnvelopePoint>();
        double angleRad = angleDegrees * Math.PI / 180.0;
        double cos = Math.Cos(angleRad);
        double sin = Math.Sin(angleRad);
        StraightTrimSegment? trimSegment = forceStraightTrimCap
            ? BuildStraightAciTrimSegment(thetaRows, pMax, pTol, angleDegrees, nominal)
            : null;

        int sampledLevels = trimSegment is null ? AxialLevels : AxialLevels - 1;
        for (int i = 0; i < sampledLevels; i++)
        {
            double p = pMin + (pRange * i / (AxialLevels - 1));
            var ring = BuildRingAtP(thetaRows, p, pTol, nominal).OrderBy(r => r.ThetaDegrees).ToList();
            if (ring.Count < 3) continue;

            var intersections = IntersectRing(ring, r => -r.Mx * sin + r.My * cos, r => r.Mx * cos + r.My * sin);
            if (intersections.Count == 0) continue;

            var max = intersections.MaxBy(x => x.Moment)!;
            var min = intersections.MinBy(x => x.Moment)!;
            positive.Add(new AngleEnvelopePoint(max.Moment, p, max.Mx, max.My, max.Phi, max.ThetaDegrees, max.NeutralAxisDepth, IsPositiveBranch: true));
            negative.Add(new AngleEnvelopePoint(min.Moment, p, min.Mx, min.My, min.Phi, min.ThetaDegrees, min.NeutralAxisDepth, IsPositiveBranch: false));
        }

        // Same cap-snap as BuildEnvelopeLoop â€” guarantee the topmost sample is exactly at pMax.
        if (trimSegment is not null && ValidateStraightTrimSegment(trimSegment.Value, pMax, pTol))
        {
            positive.Add(trimSegment.Value.Positive);
            negative.Add(trimSegment.Value.Negative);
        }
        else if (trimSegment is not null)
        {
            // Degenerate cap: trim segment exists but M=0 on both sides (EC2 pure compression).
            // Close both branches at the apex (M=0, pMax) so the diagram has a pointed head.
            var apex = trimSegment.Value.Positive with { P = pMax };
            if (positive.Count > 0) positive[^1] = apex;
            if (negative.Count > 0) negative[^1] = apex;
        }
        else
        {
            if (positive.Count > 0) positive[^1] = positive[^1] with { P = pMax };
            if (negative.Count > 0) negative[^1] = negative[^1] with { P = pMax };
        }

        ExcludeTrimSegmentFromSmoothing();
        negative.Reverse();
        return RemoveDuplicateAngleEnvelope(positive.Concat(negative).ToList(), pTol);
    }

    private static double GetAciDesignPmax(double designCompressionLimitDisplay)
        => designCompressionLimitDisplay;

    private static AngleEnvelopePoint RemovePhi(AngleEnvelopePoint point)
    {
        double phi = Math.Abs(point.Phi) < 1e-12 ? 1.0 : point.Phi;
        return point with
        {
            Mtheta = point.Mtheta / phi,
            P = point.P / phi,
            Mx = point.Mx / phi,
            My = point.My / phi
        };
    }

    private static StraightTrimSegment? BuildStraightAciTrimSegment(
        IReadOnlyList<IReadOnlyList<ControlPoint>> thetaRows,
        double designCompressionLimitDisplay,
        double tolerance,
        double angleDegrees,
        bool nominal)
    {
        double capP = GetAciDesignPmax(designCompressionLimitDisplay);
        var intersections = FindDesignCurveIntersectionsAtP(thetaRows, capP, tolerance, angleDegrees, nominal);
        if (intersections.Count < 2)
        {
            return null;
        }

        var positive = intersections.MaxBy(p => p.Mtheta);
        var negative = intersections.MinBy(p => p.Mtheta);

        // The ACI compression trim is a constructed cap, not a sampled curve.
        // Force both endpoints to one axial ordinate so the renderer draws a
        // single straight horizontal segment between left and right intersections.
        return new StraightTrimSegment(
            positive with { P = capP, IsPositiveBranch = true },
            negative with { P = capP, IsPositiveBranch = false });
    }

    private static IReadOnlyList<AngleEnvelopePoint> FindDesignCurveIntersectionsAtP(
        IReadOnlyList<IReadOnlyList<ControlPoint>> thetaRows,
        double capP,
        double tolerance,
        double angleDegrees,
        bool nominal)
    {
        double angleRad = angleDegrees * Math.PI / 180.0;
        double cos = Math.Cos(angleRad);
        double sin = Math.Sin(angleRad);
        var ring = BuildRingAtP(thetaRows, capP, tolerance, nominal).OrderBy(r => r.ThetaDegrees).ToList();
        if (ring.Count < 3)
        {
            return [];
        }

        return IntersectRing(ring, r => -r.Mx * sin + r.My * cos, r => r.Mx * cos + r.My * sin)
            .Select(p => new AngleEnvelopePoint(p.Moment, capP, p.Mx, p.My, p.Phi, p.ThetaDegrees, p.NeutralAxisDepth, IsPositiveBranch: false))
            .ToList();
    }

    private static double InterpolateMomentAtP(AngleEnvelopePoint a, AngleEnvelopePoint b, double p)
    {
        double denominator = b.P - a.P;
        double t = Math.Abs(denominator) < 1e-12 ? 0.5 : (p - a.P) / denominator;
        return Lerp(a.Mtheta, b.Mtheta, Math.Clamp(t, 0, 1));
    }

    private static void ExcludeTrimSegmentFromSmoothing()
    {
        // There is intentionally no PM display smoothing pipeline. Keeping this
        // named boundary makes the ACI trim rule explicit: cap endpoints are
        // emitted as adjacent true control points and must not become a spline.
    }

    private static bool ValidateStraightTrimSegment(StraightTrimSegment segment, double capP, double tolerance)
    {
        if (!IsFinite(segment.Positive.Mtheta) || !IsFinite(segment.Negative.Mtheta))
        {
            return false;
        }

        if (Math.Abs(segment.Positive.P - capP) > tolerance || Math.Abs(segment.Negative.P - capP) > tolerance)
        {
            return false;
        }

        return Math.Abs(segment.Positive.Mtheta - segment.Negative.Mtheta) > tolerance * 0.01;
    }

    // â”€â”€â”€â”€ Ring interpolation â”€â”€â”€â”€

    private static IReadOnlyList<RingPoint> BuildRingAtP(IEnumerable<IReadOnlyList<ControlPoint>> thetaRows, double p, double tolerance, bool nominal)
    {
        var result = new List<RingPoint>();
        foreach (var row in thetaRows)
        {
            var point = InterpolateAtP(row, p, tolerance, nominal);
            if (point is not null) result.Add(point.Value);
        }
        return result;
    }

    private static RingPoint? InterpolateAtP(IReadOnlyList<ControlPoint> row, double p, double tolerance, bool nominal)
    {
        for (int i = 0; i < row.Count - 1; i++)
        {
            var a = row[i];
            var b = row[i + 1];
            double aP = nominal ? a.NominalDisplayP : DesignDisplayP(a);
            double bP = nominal ? b.NominalDisplayP : DesignDisplayP(b);

            bool aAbove = aP >= p - tolerance;
            bool bBelow = bP <= p + tolerance;
            bool nonDegenerate = aP - bP > tolerance;
            if (aAbove && bBelow && nonDegenerate)
            {
                double denom = bP - aP;
                double t = Math.Abs(denom) < tolerance ? 0 : (p - aP) / denom;
                t = Math.Clamp(t, 0, 1);

                double aMx = nominal ? a.NominalDisplayMx : DesignDisplayMx(a);
                double bMx = nominal ? b.NominalDisplayMx : DesignDisplayMx(b);
                double aMy = nominal ? a.NominalDisplayMy : DesignDisplayMy(a);
                double bMy = nominal ? b.NominalDisplayMy : DesignDisplayMy(b);

                return new RingPoint(
                    Lerp(aMx, bMx, t), Lerp(aMy, bMy, t), p,
                    Lerp(a.Phi, b.Phi, t), Lerp(a.ThetaDegrees, b.ThetaDegrees, t),
                    Lerp(a.NeutralAxisDepth, b.NeutralAxisDepth, t));
            }
        }
        return null;
    }

    // â”€â”€â”€â”€ Ring-to-PM intersection â”€â”€â”€â”€

    private static IReadOnlyList<CurvePoint> IntersectRing(IReadOnlyList<RingPoint> ring, Func<RingPoint, double> crossSelector, Func<RingPoint, double> momentSelector)
    {
        var result = new List<CurvePoint>();
        for (int i = 0; i < ring.Count; i++)
        {
            var a = ring[i];
            var b = ring[(i + 1) % ring.Count];
            double ca = crossSelector(a);
            double cb = crossSelector(b);
            if (Math.Abs(ca) < 1e-9)
            {
                result.Add(ToCurvePoint(a, momentSelector(a)));
                continue;
            }
            if ((ca > 0 && cb < 0) || (ca < 0 && cb > 0))
            {
                double t = -ca / (cb - ca);
                result.Add(new CurvePoint(
                    Lerp(momentSelector(a), momentSelector(b), t),
                    Lerp(a.Mx, b.Mx, t),
                    Lerp(a.My, b.My, t),
                    Lerp(a.P, b.P, t),
                    Lerp(a.Phi, b.Phi, t),
                    Lerp(a.ThetaDegrees, b.ThetaDegrees, t),
                    Lerp(a.NeutralAxisDepth, b.NeutralAxisDepth, t)));
            }
        }
        return result;
    }

    // â”€â”€â”€â”€ Validation â”€â”€â”€â”€

    public static string BuildPmInteractionDebugCsv(IEnumerable<ControlPoint> source, PmDebugMomentAxis axis = PmDebugMomentAxis.Mx, double angleDegrees = 0.0)
    {
        var rows = BuildDebugRows(source, axis, angleDegrees).ToList();
        var sb = new StringBuilder();
        sb.AppendLine("Index,ThetaDeg,NeutralAxisDepth,StrainState,Pn_kN,Mn_kNm,Phi,PhiPn_kN,PhiMn_kNm,SourceCurve");

        foreach (var row in rows)
        {
            sb.AppendLine(string.Join(",", [
                row.Index.ToString(CultureInfo.InvariantCulture),
                row.ThetaDegrees.ToString("G17", CultureInfo.InvariantCulture),
                row.NeutralAxisDepth.ToString("G17", CultureInfo.InvariantCulture),
                Csv(row.StrainState),
                row.PnKn.ToString("G17", CultureInfo.InvariantCulture),
                row.MnKnm.ToString("G17", CultureInfo.InvariantCulture),
                row.Phi.ToString("G17", CultureInfo.InvariantCulture),
                row.PhiPnKn.ToString("G17", CultureInfo.InvariantCulture),
                row.PhiMnKnm.ToString("G17", CultureInfo.InvariantCulture),
                Csv(row.SourceCurve)
            ]));
        }

        return sb.ToString();
    }

    public static void ExportPmInteractionDebugCsv(string path, IEnumerable<ControlPoint> source, PmDebugMomentAxis axis = PmDebugMomentAxis.Mx, double angleDegrees = 0.0)
        => File.WriteAllText(path, BuildPmInteractionDebugCsv(source, axis, angleDegrees), Encoding.UTF8);

    public static IReadOnlyList<string> ValidateNominalReducedSourcePairing(IEnumerable<ControlPoint> source, PmDebugMomentAxis axis = PmDebugMomentAxis.Mx, double angleDegrees = 0.0)
        => ValidateSourcePairing(source.Where(p => !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint), ToCurveAxis(axis), angleDegrees);

    public static IReadOnlyList<string> ValidateNominalReducedCurvePairing(IReadOnlyList<ControlPointDto> points)
    {
        var warnings = new List<string>();
        var nominal = points.Where(p => p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        var reduced = points.Where(p => !p.IsNominal && !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();

        if (nominal.Count != reduced.Count)
        {
            warnings.Add($"Nominal/reduced curve point count differs: nominal={nominal.Count}, reduced={reduced.Count}.");
        }

        int count = Math.Min(nominal.Count, reduced.Count);
        for (int i = 0; i < count; i++)
        {
            if (Math.Abs(nominal[i].ThetaDegrees - reduced[i].ThetaDegrees) > 1e-9 ||
                Math.Abs(nominal[i].NeutralAxisDepth - reduced[i].NeutralAxisDepth) > 1e-9)
            {
                warnings.Add($"Nominal/reduced curve ordering differs at index {i}: nominal(theta={nominal[i].ThetaDegrees:G6}, c={nominal[i].NeutralAxisDepth:G6}), reduced(theta={reduced[i].ThetaDegrees:G6}, c={reduced[i].NeutralAxisDepth:G6}).");
                break;
            }

            AddPhiWarning(warnings, $"curve[{i}].P", reduced[i].P, nominal[i].P * nominal[i].Phi);
            AddPhiWarning(warnings, $"curve[{i}].Mx", reduced[i].Mx, nominal[i].Mx * nominal[i].Phi);
            AddPhiWarning(warnings, $"curve[{i}].My", reduced[i].My, nominal[i].My * nominal[i].Phi);
        }

        return warnings;
    }

    private static IEnumerable<PmDebugCsvRow> BuildDebugRows(IEnumerable<ControlPoint> source, PmDebugMomentAxis axis, double angleDegrees)
    {
        var capacity = source
            .Where(p => !p.IsDemandPoint && !p.IsGoverningPoint && !p.IsReferencePoint)
            .ToList();

        var nominal = capacity.Where(IsNominalPoint).ToDictionary(DebugPairKey);
        var reduced = capacity.Where(p => !IsNominalPoint(p)).ToDictionary(DebugPairKey);
        var keys = nominal.Keys.Concat(reduced.Keys)
            .Distinct()
            .OrderBy(k => k.SortKey)
            .ThenBy(k => k.SliceKey, StringComparer.Ordinal)
            .ToList();

        int index = 0;
        foreach (var key in keys)
        {
            if (nominal.TryGetValue(key, out var nominalPoint))
            {
                yield return ToDebugRow(index++, nominalPoint, axis, angleDegrees, "Nominal Capacity");
            }

            var reducedPoint = reduced.TryGetValue(key, out var rp) ? rp : nominalPoint;
            if (reducedPoint is not null)
            {
                yield return ToDebugRow(index++, reducedPoint, axis, angleDegrees, "Phi-Reduced Capacity");
            }
        }

        foreach (var marker in source.Where(p => p.IsGoverningPoint || p.IsDemandPoint).OrderBy(p => p.SortKey))
        {
            yield return ToDebugRow(index++, marker, axis, angleDegrees, marker.IsDemandPoint ? "Demand" : "Active Design");
        }
    }

    private static PmDebugCsvRow ToDebugRow(int index, ControlPoint point, PmDebugMomentAxis axis, double angleDegrees, string sourceCurve)
    {
        double mn = MomentNmm(point, axis, angleDegrees, reduced: false);
        double phiMn = mn * point.Phi;
        return new PmDebugCsvRow(
            index,
            point.ThetaDegrees,
            point.NeutralAxisDepth,
            string.IsNullOrWhiteSpace(point.RegionClassification) ? "-" : point.RegionClassification,
            point.Pn / 1000.0,
            mn / 1_000_000.0,
            point.Phi,
            point.Pn * point.Phi / 1000.0,
            phiMn / 1_000_000.0,
            sourceCurve);
    }

    private static IReadOnlyList<string> ValidateSourcePairing(IEnumerable<ControlPoint> capacity, CurveAxis axis, double angleDegrees = 0.0)
    {
        var warnings = new List<string>();
        var nominal = capacity.Where(IsNominalPoint)
            .OrderBy(p => p.SortKey)
            .ThenBy(p => p.SliceKey, StringComparer.Ordinal)
            .ToList();
        var reduced = capacity.Where(p => !IsNominalPoint(p))
            .OrderBy(p => p.SortKey)
            .ThenBy(p => p.SliceKey, StringComparer.Ordinal)
            .ToList();

        if (nominal.Count != reduced.Count)
        {
            warnings.Add($"Nominal/reduced source point count differs: nominal={nominal.Count}, reduced={reduced.Count}.");
        }

        int count = Math.Min(nominal.Count, reduced.Count);
        for (int i = 0; i < count; i++)
        {
            var n = nominal[i];
            var r = reduced[i];
            if (!DebugPairKey(n).Equals(DebugPairKey(r)))
            {
                warnings.Add($"Nominal/reduced source ordering differs at index {i}: nominal={DebugPairKey(n)}, reduced={DebugPairKey(r)}.");
                break;
            }

            double nMoment = axis == CurveAxis.Mx ? n.NominalDisplayMx : n.NominalDisplayMy;
            double rMoment = axis == CurveAxis.Mx ? r.ReducedDisplayMx : r.ReducedDisplayMy;
            AddPhiWarning(warnings, $"source[{i}].P", r.ReducedDisplayP, n.NominalDisplayP * n.Phi);
            AddPhiWarning(warnings, $"source[{i}].M", rMoment, nMoment * n.Phi);
        }

        return warnings;
    }

    private static IReadOnlyList<string> ValidateAngleSourcePairing(IEnumerable<ControlPoint> capacity, double angleDegrees)
    {
        var warnings = new List<string>();
        var nominal = capacity.Where(IsNominalPoint)
            .OrderBy(p => p.SortKey)
            .ThenBy(p => p.SliceKey, StringComparer.Ordinal)
            .ToList();
        var reduced = capacity.Where(p => !IsNominalPoint(p))
            .OrderBy(p => p.SortKey)
            .ThenBy(p => p.SliceKey, StringComparer.Ordinal)
            .ToList();

        if (nominal.Count != reduced.Count)
        {
            warnings.Add($"Nominal/reduced source point count differs: nominal={nominal.Count}, reduced={reduced.Count}.");
        }

        int count = Math.Min(nominal.Count, reduced.Count);
        for (int i = 0; i < count; i++)
        {
            var n = nominal[i];
            var r = reduced[i];
            if (!DebugPairKey(n).Equals(DebugPairKey(r)))
            {
                warnings.Add($"Nominal/reduced source ordering differs at index {i}: nominal={DebugPairKey(n)}, reduced={DebugPairKey(r)}.");
                break;
            }

            AddPhiWarning(warnings, $"source[{i}].P", r.ReducedDisplayP, n.NominalDisplayP * n.Phi);
            AddPhiWarning(warnings, $"source[{i}].Mtheta",
                ProjectMomentDisplay(r, angleDegrees, reduced: true),
                ProjectMomentDisplay(n, angleDegrees, reduced: false) * n.Phi);
        }

        return warnings;
    }

    private static IReadOnlyList<string> ValidateAngleLoopPairing(IReadOnlyList<AngleEnvelopePoint> nominal, IReadOnlyList<AngleEnvelopePoint> reduced)
    {
        var warnings = new List<string>();
        if (nominal.Count != reduced.Count)
        {
            warnings.Add($"Nominal/reduced rendered loop point count differs: nominal={nominal.Count}, reduced={reduced.Count}.");
        }

        int count = Math.Min(nominal.Count, reduced.Count);
        for (int i = 0; i < count; i++)
        {
            if (Math.Abs(nominal[i].ThetaDegrees - reduced[i].ThetaDegrees) > 1e-9 ||
                Math.Abs(nominal[i].NeutralAxisDepth - reduced[i].NeutralAxisDepth) > 1e-9 ||
                nominal[i].IsPositiveBranch != reduced[i].IsPositiveBranch)
            {
                warnings.Add($"Nominal/reduced rendered loop ordering differs at index {i}.");
                break;
            }

            AddPhiWarning(warnings, $"loop[{i}].P", reduced[i].P, nominal[i].P * nominal[i].Phi);
            AddPhiWarning(warnings, $"loop[{i}].Mtheta", reduced[i].Mtheta, nominal[i].Mtheta * nominal[i].Phi);
            AddPhiWarning(warnings, $"loop[{i}].Mx", reduced[i].Mx, nominal[i].Mx * nominal[i].Phi);
            AddPhiWarning(warnings, $"loop[{i}].My", reduced[i].My, nominal[i].My * nominal[i].Phi);
        }

        return warnings;
    }

    private static void AddPhiWarning(ICollection<string> warnings, string label, double actual, double expected)
    {
        double tolerance = Math.Max(Math.Abs(expected) * 1e-6, 1e-6);
        if (Math.Abs(actual - expected) > tolerance)
        {
            warnings.Add($"{label}: expected phi-scaled value {expected:G6}, got {actual:G6}.");
        }
    }

    private static DebugKey DebugPairKey(ControlPoint point)
        => new(point.SliceKey, point.SortKey);

    private static CurveAxis ToCurveAxis(PmDebugMomentAxis axis)
        => axis == PmDebugMomentAxis.My ? CurveAxis.My : CurveAxis.Mx;

    private static double MomentNmm(ControlPoint point, PmDebugMomentAxis axis, double angleDegrees, bool reduced)
    {
        double mx = reduced ? point.PhiMnx : point.Mnx;
        double my = reduced ? point.PhiMny : point.Mny;
        if (axis == PmDebugMomentAxis.My) return my;
        if (axis == PmDebugMomentAxis.Mtheta)
        {
            double radians = angleDegrees * Math.PI / 180.0;
            return mx * Math.Cos(radians) + my * Math.Sin(radians);
        }

        return mx;
    }

    private static double ProjectMomentDisplay(ControlPoint point, double angleDegrees, bool reduced)
    {
        double mx = reduced ? DesignDisplayMx(point) : point.NominalDisplayMx;
        double my = reduced ? DesignDisplayMy(point) : point.NominalDisplayMy;
        double radians = angleDegrees * Math.PI / 180.0;
        return mx * Math.Cos(radians) + my * Math.Sin(radians);
    }

    private static string Csv(string value)
        => value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r')
            ? $"\"{value.Replace("\"", "\"\"")}\""
            : value;

    /// <summary>
    /// Validates a PM capacity polyline for common defects: interior points, mixed
    /// nominal/design, NaN/Infinity, reference or demand leakage.
    /// Returns a list of defect descriptions (empty = valid).
    /// </summary>
    public static IReadOnlyList<string> ValidatePmCapacityPolyline(IReadOnlyList<ControlPointDto> points)
    {
        var defects = new List<string>();
        var capacity = points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();

        // Check no reference/demand/governing in capacity groups
        foreach (var p in capacity)
        {
            if (p.Label == "Demand") defects.Add($"Demand point found in capacity: ({p.X:F3}, {p.Y:F3})");
            if (p.Label == "Governing") defects.Add($"Governing point found in capacity: ({p.X:F3}, {p.Y:F3})");
            if (p.Label == "Pmax" || p.Label == "Pmin") defects.Add($"Reference point '{p.Label}' in capacity: ({p.X:F3}, {p.Y:F3})");
            if (double.IsNaN(p.X) || double.IsInfinity(p.X)) defects.Add($"NaN/Inf X at ({p.X}, {p.Y})");
            if (double.IsNaN(p.Y) || double.IsInfinity(p.Y)) defects.Add($"NaN/Inf Y at ({p.X}, {p.Y})");
        }

        // Check design/nominal are not mixed within the same group
        foreach (var g in capacity.GroupBy(p => p.GroupKey))
        {
            bool hasNom = g.Any(p => p.IsNominal);
            bool hasDes = g.Any(p => !p.IsNominal);
            if (hasNom && hasDes) defects.Add($"Mixed nominal/design in group '{g.Key}'");
        }

        // Check for duplicate consecutive points inside each rendered curve group.
        // Design and nominal branches are intentionally separate polylines.
        foreach (var group in capacity.GroupBy(p => new { p.GroupKey, p.IsNominal }))
        {
            var curve = group.ToList();
            for (int i = 1; i < curve.Count; i++)
            {
                if (Math.Abs(curve[i].X - curve[i - 1].X) < 1e-12 &&
                    Math.Abs(curve[i].Y - curve[i - 1].Y) < 1e-12)
                    defects.Add($"Duplicate consecutive point in group '{group.Key.GroupKey}' at ({curve[i].X:F3}, {curve[i].Y:F3})");
            }
        }



        return defects;
    }

    /// <summary>
    /// Validates that the ACI compression trim segment of a design PM curve is a clean straight
    /// horizontal line at exactly <paramref name="designPMaxDisplay"/>.
    /// Returns a list of defect descriptions (empty = valid).
    /// </summary>
    public static IReadOnlyList<string> ValidateStraightTrimSegment(IReadOnlyList<ControlPointDto> points, double designPMaxDisplay)
    {
        var defects = new List<string>();
        double pTol = Math.Max(Math.Abs(designPMaxDisplay) * 1e-6, 1e-9);

        var design = points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
            .ToList();

        // No design points at all above the cap.
        if (design.Any(p => p.Y > designPMaxDisplay + pTol))
            defects.Add($"Design curve has points above designPMax={designPMaxDisplay:G6}: max Y={design.Max(p => p.Y):G6}");

        // Exactly 2 points should sit at the cap level (positive and negative branch cap endpoints).
        var atCap = design.Where(p => Math.Abs(p.Y - designPMaxDisplay) <= pTol).ToList();
        if (atCap.Count != 2)
            defects.Add($"Expected exactly 2 cap points at Pâ‰ˆ{designPMaxDisplay:G6}, found {atCap.Count}");

        if (atCap.Count >= 2)
        {
            // Both must be at the same P (horizontal segment).
            double pSpread = atCap.Max(p => p.Y) - atCap.Min(p => p.Y);
            if (pSpread > pTol)
                defects.Add($"Cap segment is not horizontal: P spread={pSpread:G4}");

            // The two cap points must be consecutive in the design curve.
            int idx0 = design.IndexOf(atCap[0]);
            int idx1 = design.IndexOf(atCap[1]);
            if (Math.Abs(idx0 - idx1) != 1)
                defects.Add($"Cap points are not consecutive in the curve (indices {idx0}, {idx1})");
        }

        return defects;
    }

    // â”€â”€â”€â”€ DTO conversion helpers â”€â”€â”€â”€

    private static CurvePoint ToCurvePoint(RingPoint p, double moment) => new(moment, p.Mx, p.My, p.P, p.Phi, p.ThetaDegrees, p.NeutralAxisDepth);

    private static ControlPointDto ToAngleDto(AngleEnvelopePoint point, string branch, bool isNominal)
        => new(DiagramType.PM, point.Mtheta, point.P, point.P, point.P,
            point.Mx, point.My, point.Phi, point.ThetaDegrees, point.NeutralAxisDepth,
            branch, branch, false, false, false, isNominal);

    private static ControlPointDto ProjectMarkerAngle(ControlPoint point, double angleDegrees, string group)
    {
        double angleRad = angleDegrees * Math.PI / 180.0;
        double mtheta = point.DisplayMx * Math.Cos(angleRad) + point.DisplayMy * Math.Sin(angleRad);
        return new ControlPointDto(DiagramType.PM, mtheta, point.DisplayP, point.DisplayP, point.DisplayP,
            point.DisplayMx, point.DisplayMy, point.Phi, point.ThetaDegrees, point.NeutralAxisDepth,
            point.Label, group, point.IsDemandPoint, point.IsGoverningPoint, point.IsReferencePoint, false);
    }

    private static ControlPointDto ReferenceDto(double axial, string label)
        => new(DiagramType.PM, 0, axial, axial, axial, 0, 0, 1, 0, 0, label, "Reference", false, false, true, false);

    private static IReadOnlyList<AngleEnvelopePoint> RemoveDuplicateAngleEnvelope(IReadOnlyList<AngleEnvelopePoint> points, double pTol)
    {
        var result = new List<AngleEnvelopePoint>();
        foreach (var pt in points)
        {
            if (result.Count == 0 || Math.Abs(result[^1].Mtheta - pt.Mtheta) > pTol * 0.01 || Math.Abs(result[^1].P - pt.P) > pTol)
                result.Add(pt);
        }
        return result;
    }

    private static double DesignDisplayP(ControlPoint p) => IsFinite(p.ReducedDisplayP) ? p.ReducedDisplayP : p.DisplayP;
    private static double DesignDisplayMx(ControlPoint p) => IsFinite(p.ReducedDisplayMx) ? p.ReducedDisplayMx : p.DisplayMx;
    private static double DesignDisplayMy(ControlPoint p) => IsFinite(p.ReducedDisplayMy) ? p.ReducedDisplayMy : p.DisplayMy;
    private static bool IsValid(ControlPoint p) => IsFinite(p.DisplayP) && IsFinite(p.DisplayMx) && IsFinite(p.DisplayMy);
    private static bool IsNominalPoint(ControlPoint p) => p.GroupKey.Contains("Nominal", StringComparison.OrdinalIgnoreCase) || p.Label.Contains("Nominal", StringComparison.OrdinalIgnoreCase) || p.Label == "Pn,max";
    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);
    private static double Lerp(double a, double b, double t) => a + (b - a) * t;

    public enum PmDebugMomentAxis { Mx, My, Mtheta }
    private enum CurveAxis { Mx, My }
    private readonly record struct RingPoint(double Mx, double My, double P, double Phi, double ThetaDegrees, double NeutralAxisDepth);
    private readonly record struct CurvePoint(double Moment, double Mx, double My, double P, double Phi, double ThetaDegrees, double NeutralAxisDepth);
    private readonly record struct AngleEnvelopePoint(double Mtheta, double P, double Mx, double My, double Phi, double ThetaDegrees, double NeutralAxisDepth, bool IsPositiveBranch);
    private readonly record struct StraightTrimSegment(AngleEnvelopePoint Positive, AngleEnvelopePoint Negative);
    private readonly record struct DebugKey(string SliceKey, double SortKey);
    private readonly record struct PmDebugCsvRow(
        int Index,
        double ThetaDegrees,
        double NeutralAxisDepth,
        string StrainState,
        double PnKn,
        double MnKnm,
        double Phi,
        double PhiPnKn,
        double PhiMnKnm,
        string SourceCurve);
}

public sealed record PmCurveBuildDiagnostics(
    int RawInteractionPointCount,
    int ValidPointCount,
    int InvalidPointCount,
    int PBinsCount,
    int PositiveBranchCount,
    int NegativeBranchCount,
    int FinalCapacityCurveCount,
    bool NominalAndDesignSeparated,
    bool SmoothingApplied,
    int NominalPositiveBranchCount = 0,
    int NominalNegativeBranchCount = 0,
    int FinalNominalCurveCount = 0,
    double DesignPMaxDisplay = 0,
    double NominalPMaxDisplay = 0,
    IReadOnlyList<string>? ValidationWarnings = null);
