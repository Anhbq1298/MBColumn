namespace MBColumn.Application.RebarSuggestion;

/// <summary>
/// Designs the shear link set for a passing longitudinal rebar candidate.
///
/// STEP 1 — Link diameter: EC2 §9.5.3(1)
///   dsw ≥ max(6, 0.25 × db)
///
/// STEP 2 — Inner legs from gap check: EC2 §9.5.3(6)
///   ΔX = xClear / (InnerLegsX + 1) ≤ threshold  → InnerLegsX_min
///   ΔY = yClear / (InnerLegsY + 1) ≤ threshold  → InnerLegsY_min
///
/// STEP 3 — Extra inner legs from shear demand
///   Required Asw/s = VxUtilization × (Asw/s)_existing
///   At the detailing spacing cap, extra legs needed:
///     TotX_required = ceil(reqX × svMaxDetail / barArea)
///     InnerLegsX = max(InnerLegsX_gap, TotX_required − 2)
///
/// STEP 4 — Spacing from shear demand
///   sv = min(svMaxDetail, TotX × barArea / reqX, TotY × barArea / reqY)
///   rounded down to nearest 5 mm, ≥ 50 mm
///
/// The algorithm iterates from the smallest qualifying link bar upward until
/// the design satisfies both detailing and shear demand, or exhausts options.
/// </summary>
public static class ShearLinkDesigner
{
    private const double MinPracticalSpacingMm = 50.0;
    private const double SpacingRoundMm        = 5.0;

    public static ShearLinkDesignResult Design(
        RebarSuggestionCandidate  candidate,
        RebarSuggestionInput      input,
        CandidateEvaluationResult? eval = null)
    {
        var dto = input.BaseInput;
        var c   = input.Constraints;

        double db   = candidate.Bar.DiameterMm;
        double bMin = Math.Min(dto.Width, dto.Height);

        // ── EC2 §9.5.3(1): minimum link diameter ─────────────────────────────
        double dswMinEc2 = Math.Max(6.0, 0.25 * db);
        double dswMin    = c.MinLinkDiameterMm > 0
            ? Math.Max(dswMinEc2, c.MinLinkDiameterMm)
            : dswMinEc2;

        // ── EC2 §9.5.3(3): detailing spacing upper-bound ─────────────────────
        double svMaxEc2    = Math.Min(20.0 * db, Math.Min(bMin, 400.0));
        double svMaxDetail = c.MaxLinkSpacingMm > 0
            ? Math.Min(svMaxEc2, c.MaxLinkSpacingMm)
            : svMaxEc2;

        // ── Gap threshold (EC2 §9.5.3(6)) ────────────────────────────────────
        double threshold = c.CrossTieThresholdMm > 0 ? c.CrossTieThresholdMm : 150.0;
        double cover     = dto.Cover;

        // ── Shear demand: required Asw/s from utilization × existing Asw/s ───
        double existLinkDia  = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;
        double existBarArea  = Math.PI * existLinkDia * existLinkDia / 4.0;
        double existSpacing  = dto.LinkSpacingMm  > 0 ? dto.LinkSpacingMm  : 200.0;
        double existTotX     = dto.TotalLegsX     > 0 ? dto.TotalLegsX     : 2.0;
        double existTotY     = dto.TotalLegsY     > 0 ? dto.TotalLegsY     : 2.0;

        double existAswsX = existTotX * existBarArea / existSpacing;
        double existAswsY = existTotY * existBarArea / existSpacing;

        double vxUtil = eval?.VxUtilization ?? 0;
        double vyUtil = eval?.VyUtilization ?? 0;

        double reqX = vxUtil > 1e-9 ? vxUtil * existAswsX : 0;
        double reqY = vyUtil > 1e-9 ? vyUtil * existAswsY : 0;
        bool   hasShearDemand = reqX > 1e-9 || reqY > 1e-9;

        int maxLinksX = Math.Max(0, candidate.BarsOnTopBottomFace - 2);
        int maxLinksY = Math.Max(0, candidate.BarsOnLeftRightFace  - 2);

        // ── Candidate link bars: smallest qualifying first ────────────────────
        var linkBars = input.AllowedLinkBars
            .Where(b => b.DiameterMm >= dswMin - 1e-6)
            .OrderBy(b => b.DiameterMm)
            .ToList();

        bool noBarFound = linkBars.Count == 0;
        if (noBarFound)
        {
            var fb = input.AllowedLinkBars.OrderByDescending(b => b.DiameterMm).FirstOrDefault();
            if (fb is not null) linkBars = [fb];
        }

        ShearLinkDesignResult? best = null;

        foreach (var linkBar in linkBars)
        {
            double dsw     = linkBar.DiameterMm;
            double barArea = Math.PI * dsw * dsw / 4.0;

            // ── PHASE 1: Gap check (EC2 §9.5.3(6) min distance first) ───────
            // Gap geometry: EC2 check uses cover + dsw (outer face of link)
            double xClear = dto.Width  - 2.0 * (cover + dsw);
            double yClear = dto.Height - 2.0 * (cover + dsw);

            // Minimum inner legs from gap check (detailing)
            int gapLinksX = RequiredInnerLegs(xClear, threshold);
            int gapLinksY = RequiredInnerLegs(yClear, threshold);

            // ── PHASE 2: Extra inner legs to satisfy shear strength ───────────
            // Phase 1 (gap check) already set the MINIMUM inner legs.
            // Phase 2 may increase them further so that at the detailing spacing cap
            // the provided Asw/s ≥ required Asw/s.
            // TotX_required = ceil(reqX × svMaxDetail / barArea)
            int demandTotX = reqX > 1e-9
                ? (int)Math.Ceiling(reqX * svMaxDetail / barArea - 1e-9)
                : 2;
            int demandTotY = reqY > 1e-9
                ? (int)Math.Ceiling(reqY * svMaxDetail / barArea - 1e-9)
                : 2;

            int linksX = Math.Max(gapLinksX, demandTotX - 2);
            int linksY = Math.Max(gapLinksY, demandTotY - 2);

            // Clamp to physical maximum (intermediate bar count)
            linksX = Math.Min(linksX, maxLinksX);
            linksY = Math.Min(linksY, maxLinksY);

            // Feasibility: gap check must still pass after clamping
            if (linksX < gapLinksX || linksY < gapLinksY) continue;

            int totX = 2 + linksX;
            int totY = 2 + linksY;

            // Gap values after final inner leg count
            double gX = xClear > 0 ? xClear / totX : 0;
            double gY = yClear > 0 ? yClear / totY : 0;
            bool gapPass = gX <= threshold + 1e-6 && gY <= threshold + 1e-6;

            // ── Spacing: start from detailing cap, reduce for shear demand ───
            double sv = svMaxDetail;
            if (reqX > 1e-9) sv = Math.Min(sv, totX * barArea / reqX);
            if (reqY > 1e-9) sv = Math.Min(sv, totY * barArea / reqY);

            sv = RoundDown(sv);
            sv = Math.Max(sv, MinPracticalSpacingMm);

            double provX = totX * barArea / sv;
            double provY = totY * barArea / sv;
            bool   shearOk = (!hasShearDemand)
                          || (provX >= reqX - 1e-9 && provY >= reqY - 1e-9);

            var candidate_result = Build(
                linkBar, dsw, sv,
                linksX, linksY, gX, gY, threshold, gapPass, feasible: true,
                reqX, reqY, provX, provY, shearOk, hasShearDemand,
                dswMinEc2, svMaxEc2, noBarFound);

            // Keep best result; stop as soon as shear is satisfied
            if (best is null || (!best.ShearDemandSatisfied && shearOk))
                best = candidate_result;

            if (shearOk) break;
        }

        // ── Fallback if no bar list ──────────────────────────────────────────
        if (best is null)
        {
            var fb  = input.AllowedLinkBars.OrderByDescending(b => b.DiameterMm).FirstOrDefault();
            double dsw  = fb?.DiameterMm ?? existLinkDia;
            double area = Math.PI * dsw * dsw / 4.0;
            double xC   = dto.Width  - 2.0 * (cover + dsw);
            double yC   = dto.Height - 2.0 * (cover + dsw);
            int lx = RequiredInnerLegs(xC, threshold);
            int ly = RequiredInnerLegs(yC, threshold);
            int tx = 2 + lx, ty = 2 + ly;
            double sv = RoundDown(Math.Max(svMaxDetail, MinPracticalSpacingMm));
            best = Build(fb, dsw, sv, lx, ly,
                xC > 0 ? xC / tx : 0, yC > 0 ? yC / ty : 0,
                threshold, gapPass: true, feasible: false,
                reqX, reqY, tx * area / sv, ty * area / sv,
                shearOk: false, hasShearDemand,
                dswMinEc2, svMaxEc2, noBarFound: true);
        }

        return best;
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static ShearLinkDesignResult Build(
        Domain.Interfaces.RebarDefinition? bar, double dsw, double sv,
        int linksX, int linksY,
        double gX, double gY, double threshold, bool gapPass, bool feasible,
        double reqX, double reqY, double provX, double provY,
        bool shearOk, bool hasShearDemand,
        double dswMinEc2, double svMaxEc2, bool noBarFound)
        => new()
        {
            LinkBarName            = bar?.Name         ?? "—",
            LinkBarLabel           = bar?.DisplayLabel ?? bar?.Name ?? "—",
            LinkDiameterMm         = dsw,
            LinkSpacingMm          = sv,
            InternalLinksX         = linksX,
            InternalLinksY         = linksY,
            InternalLinksRequired  = linksX + linksY > 0,
            ActualGapX             = gX,
            ActualGapY             = gY,
            ThresholdMm            = threshold,
            GapCheckPass           = gapPass,
            IsLinkCheckFeasible    = feasible,
            RequiredAswsX          = reqX,
            RequiredAswsY          = reqY,
            ProvidedAswsX          = provX,
            ProvidedAswsY          = provY,
            ShearDemandSatisfied   = !hasShearDemand || shearOk,
            HasShearDemand         = hasShearDemand,
            MinRequiredDiameterMm  = dswMinEc2,
            MaxAllowedSpacingMm    = svMaxEc2,
            NoSuitableLinkBarFound = noBarFound
        };

    /// <summary>
    /// Minimum inner legs so that clear_span / (n + 1) ≤ threshold.
    /// Matches InputViewModel.UpdateEc2LinkChecks exactly.
    /// </summary>
    public static int RequiredInnerLegs(double clearSpanMm, double thresholdMm)
    {
        if (clearSpanMm <= thresholdMm + 1e-6) return 0;
        return Math.Max(0, (int)Math.Ceiling(clearSpanMm / thresholdMm - 1e-9) - 1);
    }

    private static double RoundDown(double v) => Math.Floor(v / SpacingRoundMm) * SpacingRoundMm;
}
