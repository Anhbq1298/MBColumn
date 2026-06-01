using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.RebarSuggestion;

public sealed class RectangularPerimeterCandidateGenerator : IRebarCandidateGenerator
{
    private const double CoordinateTolerance = 1e-6;

    public IReadOnlyList<RebarSuggestionCandidate> Generate(RebarSuggestionInput input)
    {
        var dto = input.BaseInput;
        var constraints = input.Constraints;

        double widthMm = dto.Width;
        double heightMm = dto.Height;
        double coverMm = dto.Cover;
        double linkDiaMm = dto.LinkDiameterMm > 0 ? dto.LinkDiameterMm : 10.0;

        // Bar centroid boundary
        // xLeft / xRight / yBottom / yTop are the bar centroid limits inside the section
        // computed per-candidate because bar diameter affects the inset

        var candidates = new List<RebarSuggestionCandidate>();

        foreach (var bar in input.AllowedBars)
        {
            double db = bar.DiameterMm;
            double area = bar.AreaMm2;

            double xLeft   = -widthMm  / 2.0 + coverMm + linkDiaMm + db / 2.0;
            double xRight  =  widthMm  / 2.0 - coverMm - linkDiaMm - db / 2.0;
            double yBottom = -heightMm / 2.0 + coverMm + linkDiaMm + db / 2.0;
            double yTop    =  heightMm / 2.0 - coverMm - linkDiaMm - db / 2.0;

            if (xLeft >= xRight || yBottom >= yTop)
                continue;

            foreach (int totalCount in constraints.AllowedBarCounts)
            {
                if (totalCount < 4) continue;

                foreach (var (nx, ny) in EnumerateDistributions(
                    totalCount,
                    constraints.AllowAllSidesEqualLayout,
                    constraints.AllowSidesDifferentLayout))
                {
                    // Pre-filter: skip this distribution if minimum clear spacing is analytically impossible.
                    // Avoids the full coordinate-generation overhead for infeasible layouts.
                    if (constraints.CheckClearSpacing)
                    {
                        double minClear = Math.Max(db, Math.Max(20.0, 1.2 * constraints.AggregateSizeMm));
                        double clearX   = nx > 1 ? (xRight - xLeft)   / (nx - 1) - db : double.PositiveInfinity;
                        double clearY   = ny > 1 ? (yTop   - yBottom) / (ny - 1) - db : double.PositiveInfinity;
                        if (Math.Min(clearX, clearY) < minClear - 1e-3) continue;
                    }

                    var coords = GenerateCoordinates(nx, ny, xLeft, xRight, yBottom, yTop, db, area, bar.Name);
                    if (coords is null) continue;

                    double totalAs = totalCount * area;
                    double acMm2  = widthMm * heightMm;
                    double rho    = totalAs / acMm2;

                    candidates.Add(new RebarSuggestionCandidate
                    {
                        Bar                  = bar,
                        TotalBarCount        = totalCount,
                        BarsOnTopBottomFace  = nx,
                        BarsOnLeftRightFace  = ny,
                        Coordinates          = coords,
                        TotalSteelAreaMm2    = totalAs,
                        ReinforcementRatio   = rho
                    });
                }
            }
        }

        return candidates;
    }

    // Returns all (nx, ny) pairs where 2*nx + 2*ny - 4 == totalCount, nx>=2, ny>=2.
    // Filtered by allowAllSidesEqual / allowSidesDifferent flags.
    private static IEnumerable<(int nx, int ny)> EnumerateDistributions(
        int totalCount, bool allowAllSidesEqual, bool allowSidesDifferent)
    {
        // 2*nx + 2*ny - 4 = totalCount  =>  nx + ny = (totalCount + 4) / 2
        if ((totalCount + 4) % 2 != 0) yield break;
        int sum = (totalCount + 4) / 2;

        // Guard: if neither flag set, fall back to all-sides-equal only
        if (!allowAllSidesEqual && !allowSidesDifferent)
            allowAllSidesEqual = true;

        for (int nx = 2; nx <= sum - 2; nx++)
        {
            int ny = sum - nx;
            if (ny < 2) continue;

            bool isEqual = nx == ny;
            if (isEqual  && !allowAllSidesEqual)  continue;
            if (!isEqual && !allowSidesDifferent) continue;

            yield return (nx, ny);
        }
    }

    private static IReadOnlyList<RebarCoordinateDto>? GenerateCoordinates(
        int nx, int ny,
        double xLeft, double xRight, double yBottom, double yTop,
        double db, double area, string barName)
    {
        var bars = new List<RebarCoordinateDto>(2 * nx + 2 * ny - 4);

        // Top side: nx bars from xLeft to xRight at yTop
        AddSide(bars, nx, xLeft, yTop, xRight, yTop, db, area, barName, "Top");

        // Bottom side: nx bars from xLeft to xRight at yBottom
        AddSide(bars, nx, xLeft, yBottom, xRight, yBottom, db, area, barName, "Bottom");

        // Left side intermediate bars (corner bars already added by Top/Bottom)
        AddIntermediateBars(bars, ny - 2, xLeft, yBottom, xLeft, yTop, db, area, barName, "Left");

        // Right side intermediate bars
        AddIntermediateBars(bars, ny - 2, xRight, yBottom, xRight, yTop, db, area, barName, "Right");

        int expected = 2 * nx + 2 * ny - 4;
        if (bars.Count != expected) return null;

        return bars;
    }

    private static void AddSide(
        List<RebarCoordinateDto> bars,
        int count,
        double x0, double y0, double x1, double y1,
        double db, double area, string barName, string side)
    {
        for (int i = 0; i < count; i++)
        {
            double t = count == 1 ? 0.5 : (double)i / (count - 1);
            double x = x0 + (x1 - x0) * t;
            double y = y0 + (y1 - y0) * t;
            AddUnique(bars, x, y, db, area, barName, side);
        }
    }

    private static void AddIntermediateBars(
        List<RebarCoordinateDto> bars,
        int count,
        double x0, double y0, double x1, double y1,
        double db, double area, string barName, string side)
    {
        for (int i = 1; i <= count; i++)
        {
            double t = (double)i / (count + 1);
            double x = x0 + (x1 - x0) * t;
            double y = y0 + (y1 - y0) * t;
            AddUnique(bars, x, y, db, area, barName, side);
        }
    }

    private static void AddUnique(
        List<RebarCoordinateDto> bars,
        double x, double y,
        double diameter, double area, string barName, string side)
    {
        foreach (var existing in bars)
        {
            if (Math.Abs(existing.X - x) <= CoordinateTolerance &&
                Math.Abs(existing.Y - y) <= CoordinateTolerance)
                return;
        }

        bars.Add(new RebarCoordinateDto(
            $"B{bars.Count + 1}", x, y, diameter, area, barName, side));
    }
}
