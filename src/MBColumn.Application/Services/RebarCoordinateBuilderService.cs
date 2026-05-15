using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public sealed class RebarCoordinateBuilderService(
    IUnitConversionService units,
    IRebarDatabase metricBars,
    IRebarDatabase imperialBars) : IRebarCoordinateBuilderService
{
    private const double CoordinateToleranceMm = 1e-6;

    public IReadOnlyList<RebarCoordinateDto> Build(
        RebarLayoutInputDto layout,
        double width,
        double height,
        LengthUnit lengthUnit,
        UnitSystem unitSystem)
    {
        var barDb = unitSystem == UnitSystem.Metric ? metricBars : imperialBars;
        if (!barDb.TryGet(layout.BarSize, out var bar))
        {
            throw new InvalidOperationException($"Unknown bar size '{layout.BarSize}'.");
        }

        double widthMm = units.LengthToMm(width, lengthUnit);
        double heightMm = units.LengthToMm(height, lengthUnit);
        double coverMm = units.LengthToMm(layout.Cover, lengthUnit);
        double x = widthMm / 2.0 - coverMm - bar.DiameterMm / 2.0;
        double y = heightMm / 2.0 - coverMm - bar.DiameterMm / 2.0;
        if (x <= 0 || y <= 0)
        {
            throw new InvalidOperationException("Rebar centroid is outside the concrete section.");
        }

        var sideCounts = GetSideCounts(layout);
        ValidateSideCounts(sideCounts, layout.LayoutType);
        ValidateSpacing(sideCounts.Top, 2.0 * x, bar.DiameterMm, "Top");
        ValidateSpacing(sideCounts.Bottom, 2.0 * x, bar.DiameterMm, "Bottom");
        ValidateSpacing(sideCounts.LeftInterm + 2, 2.0 * y, bar.DiameterMm, "Left");
        ValidateSpacing(sideCounts.RightInterm + 2, 2.0 * y, bar.DiameterMm, "Right");

        var bars = new List<RebarCoordinateDto>();
        AddSide(bars, "Top", sideCounts.Top, -x, y, x, y, bar);
        AddSide(bars, "Bottom", sideCounts.Bottom, -x, -y, x, -y, bar);
        AddIntermediateBars(bars, "Left", sideCounts.LeftInterm, -x, -y, -x, y, bar);
        AddIntermediateBars(bars, "Right", sideCounts.RightInterm, x, -y, x, y, bar);

        if (bars.Count == 0)
        {
            throw new InvalidOperationException("At least one physical rebar coordinate is required.");
        }

        return bars;
    }

    private static (int Top, int Bottom, int LeftInterm, int RightInterm) GetSideCounts(RebarLayoutInputDto layout)
    {
        if (layout.LayoutType == RebarLayoutType.AllSidesEqual)
        {
            if (layout.TotalBars < 4)
            {
                throw new InvalidOperationException("Total bars must be at least 4.");
            }

            if ((layout.TotalBars - 4) % 4 != 0)
            {
                throw new InvalidOperationException("For All Sides Equal layout, total bars must satisfy: totalBars = 4 + 4n. Examples: 8, 12, 16, 20, 24.");
            }

            int n = (layout.TotalBars - 4) / 4;
            int perSide = n + 2;
            return (perSide, perSide, n, n);
        }

        return (
            layout.Top.BarCount,
            layout.Bottom.BarCount,
            layout.Left.BarCount,
            layout.Right.BarCount);
    }

    private static void ValidateSideCounts((int Top, int Bottom, int LeftInterm, int RightInterm) sideCounts, RebarLayoutType layoutType)
    {
        if (sideCounts.Top < 0 || sideCounts.Bottom < 0 || sideCounts.LeftInterm < 0 || sideCounts.RightInterm < 0)
        {
            throw new InvalidOperationException("Side bar counts must be non-negative.");
        }

        if (layoutType == RebarLayoutType.SidesDifferent &&
            sideCounts.Top + sideCounts.Bottom + sideCounts.LeftInterm + sideCounts.RightInterm == 0)
        {
            throw new InvalidOperationException("At least one side must contain bars.");
        }
    }

    private static void ValidateSpacing(int count, double sideLengthMm, double diameterMm, string side)
    {
        if (count <= 1) return;

        double spacingMm = sideLengthMm / (count - 1);
        if (spacingMm + CoordinateToleranceMm < diameterMm)
        {
            throw new InvalidOperationException($"{side} side bar spacing is too small for the selected bar size.");
        }
    }

    private static void AddSide(
        List<RebarCoordinateDto> bars,
        string side,
        int count,
        double x0,
        double y0,
        double x1,
        double y1,
        RebarDefinition bar)
    {
        for (int i = 0; i < count; i++)
        {
            double t = count == 1 ? 0.5 : (double)i / (count - 1);
            double x = x0 + (x1 - x0) * t;
            double y = y0 + (y1 - y0) * t;
            AddUnique(bars, x, y, bar, side);
        }
    }

    private static void AddIntermediateBars(
        List<RebarCoordinateDto> bars,
        string side,
        int count,
        double x0,
        double y0,
        double x1,
        double y1,
        RebarDefinition bar)
    {
        if (count <= 0) return;
        // The endpoints are corners. We want 'count' bars strictly between them.
        for (int i = 1; i <= count; i++)
        {
            double t = (double)i / (count + 1);
            double x = x0 + (x1 - x0) * t;
            double y = y0 + (y1 - y0) * t;
            AddUnique(bars, x, y, bar, side);
        }
    }

    private static void AddUnique(List<RebarCoordinateDto> bars, double x, double y, RebarDefinition bar, string side)
    {
        if (bars.Any(existing =>
                Math.Abs(existing.X - x) <= CoordinateToleranceMm &&
                Math.Abs(existing.Y - y) <= CoordinateToleranceMm))
        {
            return;
        }

        bars.Add(new RebarCoordinateDto(
            $"B{bars.Count + 1}",
            x,
            y,
            bar.DiameterMm,
            bar.AreaMm2,
            bar.Name,
            side));
    }

    public IReadOnlyList<RebarCoordinateDto> BuildCircular(
        double diameter,
        double cover,
        int barCount,
        string barSize,
        LengthUnit lengthUnit,
        UnitSystem unitSystem)
    {
        var barDb = unitSystem == UnitSystem.Metric ? metricBars : imperialBars;
        if (!barDb.TryGet(barSize, out var bar))
        {
            throw new InvalidOperationException($"Unknown bar size '{barSize}'.");
        }

        double diameterMm = units.LengthToMm(diameter, lengthUnit);
        double coverMm = units.LengthToMm(cover, lengthUnit);
        // Bar centroid radius: from centre of section to centroid of bar
        double radiusMm = diameterMm / 2.0 - coverMm - bar.DiameterMm / 2.0;
        if (radiusMm <= 0)
        {
            throw new InvalidOperationException("Cover places rebar centroids outside the circular section boundary.");
        }

        if (barCount < 1)
        {
            throw new InvalidOperationException("At least one bar is required.");
        }

        var bars = new List<RebarCoordinateDto>(barCount);
        for (int i = 0; i < barCount; i++)
        {
            // Start from top (π/2) and distribute evenly clockwise
            double angle = Math.PI / 2.0 - 2.0 * Math.PI * i / barCount;
            double x = radiusMm * Math.Cos(angle);
            double y = radiusMm * Math.Sin(angle);
            bars.Add(new RebarCoordinateDto(
                $"B{i + 1}",
                x,
                y,
                