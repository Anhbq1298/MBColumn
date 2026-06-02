using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.RebarSuggestion;

/// <summary>
/// Designs the shear link set for a given longitudinal rebar candidate.
///
/// EC2 §9.5.3 rules applied:
///   Link diameter:  dsw ≥ max(6 mm, 0.25 × max longitudinal diameter)
///   Link spacing:   sv  ≤ min(20 × min longitudinal diameter, b_min, 400 mm)
///   Cross-ties:     every bar > crossTieThreshold mm from a restrained bar
///                   needs an internal cross-tie (EC2 §9.5.3(6))
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

        // ── EC2 link diameter limit ────────────────────────────────────────────
        double dswMinEc2 = Math.Max(6.0, 0.25 * db);
        double dswMin    = c.MinLinkDiameterMm > 0
            ? Math.Max(dswMinEc2, c.MinLinkDiameterMm)
            : dswMinEc2;

        // ── EC2 link spacing limit ─────────────────────────────────────────────
        double svMaxEc2 = Math.Min(20.0 * db, Math.Min(bMin, 400.0));
        double svMax    = c.MaxLinkSpacingMm > 0
            ? Math.Min(svMaxEc2, c.MaxLinkSpacingMm)
            : svMaxEc2;

        // Round down to nearest 5 mm (practical detailing)
        double svDesign = Math.Floor(svMax / 5.0) * 5.0;

        // ── Select smallest available link bar that meets diameter requirement ──
        var linkBars     = input.AllowedLinkBars;
        var selectedLink = linkBars
            .Where(b => b.DiameterMm >= dswMin - 1e-6)
            .OrderBy(b => b.DiameterMm)
            .FirstOrDefault();

        bool noBarFound = selectedLink is null;

        // Fallback to largest available if nothing meets the minimum
        selectedLink ??= linkBars
            .OrderByDescending(b => b.DiameterMm)
            .FirstOrDefault();

        // ── Internal cross-tie count (EC2 §9.5.3(6)) ──────────────────────────
        double threshold = c.CrossTieThresholdMm > 0 ? c.CrossTieThresholdMm : 150.0;
        (int linksX, int linksY) = ComputeInternalLinkCounts(candidate, input, threshold);

        return new ShearLinkDesignResult
        {
            LinkBarName            = selectedLink?.Name         ?? "—",
            LinkBarLabel           = selectedLink?.DisplayLabel ?? selectedLink?.Name ?? "—",
            LinkDiameterMm         = selectedLink?.DiameterMm   ?? 0,
            LinkSpacingMm          = svDesign,
            InternalLinksRequired  = linksX + linksY > 0,
            InternalLinksX         = linksX,
            InternalLinksY         = linksY,
            MinRequiredDiameterMm  = dswMinEc2,
            MaxAllowedSpacingMm    = svMaxEc2,
            NoSuitableLinkBarFound = noBarFound
        };
    }

    // ── Internal cross-tie geometry ───────────────────────────────────────────

    /// <summary>
    /// Returns (linksX, linksY):
    ///   linksX = cross-ties for top/bottom face → InnerLegsX in InputViewModel
    ///   linksY = cross-ties for left/right face → InnerLegsY in InputViewModel
    /// </summary>
    private static (int linksX, int linksY) ComputeInternalLinkCounts(
        RebarSuggestionCandidate candidate,
        RebarSuggestionInput input,
        double threshold)
    {
        var    dto   = input.BaseInput;
        double db    = candidate.Bar.DiameterMm;
        double link  = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;
        double cover = dto.Cover;

        double availW = dto.Width  - 2.0 * (cover + link + db / 2.0);
        double availH = dto.Height - 2.0 * (cover + link + db / 2.0);

        int nTop  = candidate.BarsOnTopBottomFace;
        int nLeft = candidate.BarsOnLeftRightFace;

        // linksX: cross-ties spanning the depth (connect top↔bottom intermediate bar pairs)
        // linksY: cross-ties spanning the width  (connect left↔right intermediate bar pairs)
        int linksX = CrossTiesForFace(nTop,  availW, threshold);
        int linksY = CrossTiesForFace(nLeft, availH, threshold);

        return (linksX, linksY);
    }

    /// <summary>
    /// Minimum cross-ties needed so that every intermediate bar on a face
    /// is within <paramref name="threshold"/> of a directly restrained bar
    /// (corner or previously cross-tied bar). Uses a greedy left-to-right scan.
    /// </summary>
    private static int CrossTiesForFace(int nBars, double availableLength, double threshold)
    {
        if (nBars <= 2 || availableLength <= 0) return 0;

        double spacing = availableLength / (nBars - 1);

        // Directly restrained bars: initially just the two corner bars
        var restrained = new HashSet<int> { 0, nBars - 1 };
        int crossTies  = 0;

        // Iteratively find the leftmost unrestrained bar and place a cross-tie
        // at the rightmost bar within threshold of that bar's position.
        while (true)
        {
            int leftmostUnrestrained = -1;
            for (int i = 1; i < nBars - 1; i++)
            {
                if (!IsRestrained(i, spacing, restrained, threshold))
                {
                    leftmostUnrestrained = i;
                    break;
                }
            }

            if (leftmostUnrestrained < 0) break; // all bars covered

            double unPos    = leftmostUnrestrained * spacing;
            // Place cross-tie at the furthest intermediate bar within threshold of unPos
            int rightmost   = Math.Min(nBars - 2, (int)Math.Floor((unPos + threshold) / spacing));
            restrained.Add(rightmost);
            crossTies++;
        }

        return crossTies;
    }

    private static bool IsRestrained(
        int barIndex, double spacing,
        HashSet<int> directlyRestrained,
        double threshold)
    {
        double pos = barIndex * spacing;
        foreach (int r in directlyRestrained)
        {
            if (Math.Abs(r * spacing - pos) <= threshold + 1e-6)
                return true;
        }
        return false;
    }
}
