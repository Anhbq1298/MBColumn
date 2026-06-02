namespace MBColumn.Application.RebarSuggestion;

/// <summary>
/// Designs the shear link set for a given longitudinal rebar candidate per EC2 §9.5.3.
///
/// InternalLinksX / InternalLinksY are computed from the same geometric formula used
/// by InputViewModel.UpdateEc2LinkChecks so that Apply will produce a passing check:
///
///   xClear = width  - 2*(cover + linkDiameter)
///   yClear = height - 2*(cover + linkDiameter)
///   gX     = xClear / (InnerLegsX + 1)   must be ≤ threshold (default 150 mm)
///   gY     = yClear / (InnerLegsY + 1)
///
///   → InnerLegsX_min = max(0, ceil(xClear / threshold) - 1)
///   → InnerLegsY_min = max(0, ceil(yClear / threshold) - 1)
///
/// Feasibility: the required number of inner legs must not exceed the number of
/// intermediate longitudinal bars on each face (nTop-2 and nLeft-2 respectively).
/// If infeasible the candidate should be rejected by the engine.
/// </summary>
public static class ShearLinkDesigner
{
    public static ShearLinkDesignResult Design(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input)
    {
        var dto = input.BaseInput;
        var c   = input.Constraints;

        double db   = candidate.Bar.DiameterMm;
        double bMin = Math.Min(dto.Width, dto.Height);

        // ── EC2 §9.5.3(1): link diameter ─────────────────────────────────────
        double dswMinEc2 = Math.Max(6.0, 0.25 * db);
        double dswMin    = c.MinLinkDiameterMm > 0
            ? Math.Max(dswMinEc2, c.MinLinkDiameterMm)
            : dswMinEc2;

        // ── EC2 §9.5.3(3): link spacing ──────────────────────────────────────
        double svMaxEc2 = Math.Min(20.0 * db, Math.Min(bMin, 400.0));
        double svMax    = c.MaxLinkSpacingMm > 0
            ? Math.Min(svMaxEc2, c.MaxLinkSpacingMm)
            : svMaxEc2;
        double svDesign = Math.Floor(svMax / 5.0) * 5.0; // round down to nearest 5 mm

        // ── Select smallest available link bar meeting diameter requirement ───
        var linkBars     = input.AllowedLinkBars;
        var selectedLink = linkBars
            .Where(b => b.DiameterMm >= dswMin - 1e-6)
            .OrderBy(b => b.DiameterMm)
            .FirstOrDefault();

        bool noBarFound = selectedLink is null;
        selectedLink ??= linkBars.OrderByDescending(b => b.DiameterMm).FirstOrDefault();

        double dsw = selectedLink?.DiameterMm ?? (dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0);

        // ── EC2 §9.5.3(6): internal cross-tie gap check ───────────────────────
        double threshold = c.CrossTieThresholdMm > 0 ? c.CrossTieThresholdMm : 150.0;
        double cover     = dto.Cover;

        // xClear / yClear: distance between INNER faces of the perimeter link legs
        // (matches the formula in InputViewModel.UpdateEc2LinkChecks exactly)
        double xClear = dto.Width  - 2.0 * (cover + dsw);
        double yClear = dto.Height - 2.0 * (cover + dsw);

        // Minimum inner legs so that gX = xClear/(InnerLegsX+1) ≤ threshold
        int linksX = RequiredInnerLegs(xClear, threshold);
        int linksY = RequiredInnerLegs(yClear, threshold);

        // Feasibility: inner legs must be placeable at intermediate bar positions
        int maxLinksX = Math.Max(0, candidate.BarsOnTopBottomFace - 2);
        int maxLinksY = Math.Max(0, candidate.BarsOnLeftRightFace - 2);
        bool feasible = linksX <= maxLinksX && linksY <= maxLinksY;

        // Actual gaps after clamping (for reporting; engine rejects if infeasible)
        double gX = xClear > 0 ? xClear / (linksX + 1) : 0;
        double gY = yClear > 0 ? yClear / (linksY + 1) : 0;
        bool gapPass = gX <= threshold + 1e-6 && gY <= threshold + 1e-6;

        return new ShearLinkDesignResult
        {
            LinkBarName            = selectedLink?.Name         ?? "—",
            LinkBarLabel           = selectedLink?.DisplayLabel ?? selectedLink?.Name ?? "—",
            LinkDiameterMm         = dsw,
            LinkSpacingMm          = svDesign,
            InternalLinksRequired  = linksX + linksY > 0,
            InternalLinksX         = linksX,
            InternalLinksY         = linksY,
            ActualGapX             = gX,
            ActualGapY             = gY,
            ThresholdMm            = threshold,
            GapCheckPass           = gapPass,
            IsLinkCheckFeasible    = feasible,
            MinRequiredDiameterMm  = dswMinEc2,
            MaxAllowedSpacingMm    = svMaxEc2,
            NoSuitableLinkBarFound = noBarFound
        };
    }

    // ── Formula ───────────────────────────────────────────────────────────────

    /// <summary>
    /// Minimum inner legs count so that clear_span / (n + 1) ≤ threshold.
    /// Mirrors the EC2 Check 3 formula in InputViewModel.UpdateEc2LinkChecks.
    /// </summary>
    public static int RequiredInnerLegs(double clearSpanMm, double thresholdMm)
    {
        if (clearSpanMm <= thresholdMm + 1e-6) return 0;
        // Need (n+1) ≥ clearSpan/threshold  →  n ≥ ceil(clearSpan/threshold) - 1
        return Math.Max(0, (int)Math.Ceiling(clearSpanMm / thresholdMm - 1e-9) - 1);
    }
}
