using MBColumn.Application.DTOs;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.RebarSuggestion;

/// <summary>
/// Generates rebar layout candidates for rectangular / square sections using a
/// spacing-first approach: starts from InitialTargetSpacingMm (default 150 mm)
/// and reduces by SpacingReductionStepMm until MinimumSpacingSearchLimitMm.
/// The four corner bars are always present (nTop >= 2, nLeft >= 2).
/// Rebar count is derived from spacing — never iterated directly.
/// </summary>
public sealed class RectangularPerimeterCandidateGenerator : IRebarCandidateGenerator
{
    private const double CoordinateTolerance = 1e-6;

    public IReadOnlyList<RebarSuggestionCandidate> Generate(RebarSuggestionInput input)
    {
        var dto         = input.BaseInput;
        var constraints = input.Constraints;

        double widthMm   = dto.Width;
        double heightMm  = dto.Height;
        double coverMm   = dto.Cover;
        double linkDiaMm = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;

        double minBarDia      = constraints.MinimumBarDiameterMm;
        double initialSpacing = constraints.InitialTargetSpacingMm > 0 ? constraints.InitialTargetSpacingMm : 150.0;
        double spacingStep    = constraints.SpacingReductionStepMm  > 0 ? constraints.SpacingReductionStepMm  : 10.0;
        double minSpacingLimit= constraints.MinimumSpacingSearchLimitMm > 0
            ? constraints.MinimumSpacingSearchLimitMm : 50.0;

        var candidates = new List<RebarSuggestionCandidate>();

        foreach (var bar in input.AllowedBars)
        {
            double db   = bar.DiameterMm;
            if (db < minBarDia - 1e-6) continue;

            double area            = bar.AreaMm2;
            double coverToBarCtr   = coverMm + linkDiaMm + db / 2.0;
            double availableWidth  = widthMm  - 2.0 * coverToBarCtr;
            double availableHeight = heightMm - 2.0 * coverToBarCtr;

            // Section too small for this bar diameter
            if (availableWidth <= 0 || availableHeight <= 0) continue;

            double xLeft   = -widthMm  / 2.0 + coverToBarCtr;
            double xRight  =  widthMm  / 2.0 - coverToBarCtr;
            double yBottom = -heightMm / 2.0 + coverToBarCtr;
            double yTop    =  heightMm / 2.0 - coverToBarCtr;

            var seen = new HashSet<(int nTop, int nLeft)>();

            for (double targetSpacing = initialSpacing;
                 targetSpacing >= minSpacingLimit - 1e-9;
                 targetSpacing -= spacingStep)
            {
                // Minimum n per side is 2 (corner bars always present)
                int nTop  = Math.Max(2, CalculateSideBarCount(availableWidth,  targetSpacing));
                int nLeft = Math.Max(2, CalculateSideBarCount(availableHeight, targetSpacing));

                // Apply layout type filter
                bool isEqual = nTop == nLeft;
                if (isEqual  && !constraints.AllowAllSidesEqualLayout)  continue;
                if (!isEqual && !constraints.AllowSidesDifferentLayout) continue;

                if (!seen.Add((nTop, nLeft))) continue;

                // Pre-filter: bar centroids must have positive clear space
                // (catches degenerate geometries before coordinate generation)
                double clearX = nTop  > 1 ? availableWidth  / (nTop  - 1) - db : double.PositiveInfinity;
                double clearY = nLeft > 1 ? availableHeight / (nLeft - 1) - db : double.PositiveInfinity;
                if (clearX <= 0 || clearY <= 0) continue;

                var coords = GenerateCoordinates(nTop, nLeft, xLeft, xRight, yBottom, yTop, db, area, bar.Name);
                if (coords is null) continue;

                // totalBars = nTop + nBottom + nLeft + nRight - 4
                // (nTop = nBottom, nLeft = nRight for symmetric perimeter layout)
                int totalBars = 2 * nTop + 2 * nLeft - 4;
                double totalAs = totalBars * area;
                double acMm2   = widthMm * heightMm;
                double rho     = totalAs / acMm2;

                var layoutType = isEqual
                    ? RebarCandidateLayoutType.AllSidesEqual
                    : RebarCandidateLayoutType.SideDifferentSymmetric;

                candidates.Add(new RebarSuggestionCandidate
                {
                    Bar                 = bar,
                    TotalBarCount       = totalBars,
                    BarsOnTopBottomFace = nTop,
                    BarsOnLeftRightFace = nLeft,
                    Coordinates         = coords,
                    TotalSteelAreaMm2   = totalAs,
                    ReinforcementRatio  = rho,
                    LayoutType          = layoutType
                });
            }
        }

        return candidates;
    }

    // Returns the minimum number of bars on a side so that actual spacing <= targetSpacing.
    // Formula: n = ceil(availableLength / targetSpacing) + 1
    // Derivation: spacing = availableLength / (n-1) => n = availableLength/spacing + 1
    private static int CalculateSideBarCount(double availableLength, double targetSpacing)
        => (int)Math.Ceiling(availableLength / targetSpacing) + 1;

    private static IReadOnlyList<RebarCoordinateDto>? GenerateCoordinates(
        int nTop, int nLeft,
        double xLeft, double xRight, double yBottom, double yTop,
        double db, double area, string barName)
    {
        int expected = 2 * nTop + 2 * nLeft - 4;
        var bars = new List<RebarCoordinateDto>(expected);

        // Top and bottom sides: nTop bars from xLeft to xRight
        AddSide(bars, nTop, xLeft, yTop,    xRight, yTop,    db, area, barName, "Top");
        AddSide(bars, nTop, xLeft, yBottom, xRight, yBottom, db, area, barName, "Bottom");

        // Left and right sides: intermediate bars only (corners already added above)
        AddIntermediateBars(bars, nLeft - 2, xLeft,  yBottom, xLeft,  yTop, db, area, barName, "Left");
        AddIntermediateBars(bars, nLeft - 2, xRight, yBottom, xRight, yTop, db, area, barName, "Right");

        return bars.Count == expected ? bars : null;
    }

    private static void AddSide(
        List<RebarCoordinateDto> bars,
        int count, double x0, double y0, double x1, double y1,
        double db, double area, string barName, string side)
    {
        for (int i = 0; i < count; i++)
        {
            double t = count == 1 ? 0.5 : (double)i / (count - 1);
            AddUnique(bars, x0 + (x1 - x0) * t, y0 + (y1 - y0) * t, db, area, barName, side);
        }
    }

    private static void AddIntermediateBars(
        List<RebarCoordinateDto> bars,
        int count, double x0, double y0, double x1, double y1,
        double db, double area, string barName, string side)
    {
        for (int i = 1; i <= count; i++)
        {
            double t = (double)i / (count + 1);
            AddUnique(bars, x0 + (x1 - x0) * t, y0 + (y1 - y0) * t, db, area, barName, side);
        }
    }

    private static void AddUnique(
        List<RebarCoordinateDto> bars,
        double x, double y, double diameter, double area, string barName, string side)
    {
        foreach (var existing in bars)
        {
            if (Math.Abs(existing.X - x) <= CoordinateTolerance &&
                Math.Abs(existing.Y - y) <= CoordinateTolerance)
                return;
        }
        bars.Add(new RebarCoordinateDto($"B{bars.Count + 1}", x, y, diameter, area, barName, side));
    }
}
