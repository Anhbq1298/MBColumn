using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using System.Globalization;
using System.Text;
using SystemMath = System.Math;

namespace MBColumn.Infrastructure.Reports.Graphics;

/// <summary>
/// Renders section geometry and interaction diagrams as inline SVG strings.
/// The nested <see cref="SectionGeometryRenderer"/> is importable via
/// <c>using static MBColumn.Infrastructure.Reports.Graphics.InteractionDiagramSvgRenderer;</c>
/// </summary>
public static class InteractionDiagramSvgRenderer
{
    public static string RenderDiagram(DiagramBlock block, int svgWidth = 500, int svgHeight = 400)
    {
        const int frameLeft = 74;
        const int frameTop = 26;
        const int frameRight = 34;
        const int frameBottom = 64;

        int availableW = SystemMath.Max(120, svgWidth - frameLeft - frameRight);
        int availableH = SystemMath.Max(120, svgHeight - frameTop - frameBottom);
        int plotSize = SystemMath.Max(120, SystemMath.Min(availableW, availableH));
        int plotX = frameLeft + (availableW - plotSize) / 2;
        int plotY = frameTop + (availableH - plotSize) / 2;

        var finitePoints = block.Points.Where(IsFinite).ToList();
        var finiteLines = block.ReferenceLines
            .Where(l => IsFinite(l.StartX) && IsFinite(l.StartY) && IsFinite(l.EndX) && IsFinite(l.EndY))
            .ToList();

        if (finitePoints.Count == 0 && finiteLines.Count == 0)
        {
            return "<svg xmlns='http://www.w3.org/2000/svg'/>";
        }

        var domain = BuildDomain(block, finitePoints, finiteLines);
        double plotW = plotSize;
        double plotH = plotSize;

        double ScaleX(double v) => plotX + (v - domain.XMin) / domain.XRange * plotW;
        double ScaleY(double v) => plotY + plotH - (v - domain.YMin) / domain.YRange * plotH;

        var xTicks = GenerateTicks(domain.XMin, domain.XMax, 6, 5);
        var yTicks = GenerateTicks(domain.YMin, domain.YMax, 6, 5);
        double axisX = ScaleX(0);
        double axisY = ScaleY(0);
        double screenCenterX = plotX + plotW / 2.0;

        var envelopeGroups = BuildEnvelopeGroups(finitePoints);
        var specialPoints = finitePoints.Where(p => p.IsSpecialPoint).OrderBy(p => p.CpNumber).ThenBy(p => p.Label).ToList();
        var demandPoint = finitePoints
            .Where(p => p.IsDemand)
            .OrderByDescending(p => p.Utilization)
            .ThenBy(p => p.Label)
            .FirstOrDefault();

        var radialLine = SelectDemandRadialLine(block.ReferenceLines, demandPoint);
        double? radialEndX = null;
        double? radialEndY = null;

        if (demandPoint is not null)
        {
            var intersection = FindCapacityIntersection(envelopeGroups, demandPoint);
            if (intersection is not null)
            {
                radialEndX = intersection.Value.X;
                radialEndY = intersection.Value.Y;
            }
            else
            {
                radialEndX = demandPoint.X;
                radialEndY = demandPoint.Y;
                Console.WriteLine("[Warning] No valid intersection found between demand ray and envelope. Falling back to demand point.");
                System.Diagnostics.Debug.WriteLine("[Warning] No valid intersection found between demand ray and envelope. Falling back to demand point.");
            }
        }
        else if (radialLine is not null)
        {
            radialEndX = radialLine.EndX;
            radialEndY = radialLine.EndY;
        }

        var sb = new StringBuilder();
        sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgWidth}' height='{svgHeight}' viewBox='0 0 {svgWidth} {svgHeight}' preserveAspectRatio='xMidYMid meet' font-family='Inter, Arial, sans-serif'>");
        sb.Append($"<rect width='{svgWidth}' height='{svgHeight}' fill='white'/>");
        sb.Append($"<rect x='{plotX}' y='{plotY}' width='{plotW:F1}' height='{plotH:F1}' rx='4' ry='4' fill='#FCFEFF' stroke='#D6E4F1' stroke-width='1.2'/>");

        AppendGridLines(sb, xTicks.MinorTicks, true, plotX, plotY, plotW, plotH, ScaleX, ScaleY, "#EAF4FB", 0.9);
        AppendGridLines(sb, yTicks.MinorTicks, false, plotX, plotY, plotW, plotH, ScaleX, ScaleY, "#EAF4FB", 0.9);
        AppendGridLines(sb, xTicks.MajorTicks.Where(v => SystemMath.Abs(v) > 1e-9), true, plotX, plotY, plotW, plotH, ScaleX, ScaleY, "#CFE4F6", 1.15);
        AppendGridLines(sb, yTicks.MajorTicks.Where(v => SystemMath.Abs(v) > 1e-9), false, plotX, plotY, plotW, plotH, ScaleX, ScaleY, "#CFE4F6", 1.15);

        double startX = radialLine?.StartX ?? 0;
        double startY = radialLine?.StartY ?? 0;
        double endX = radialEndX ?? radialLine?.EndX ?? 0;
        double endY = radialEndY ?? radialLine?.EndY ?? 0;
        bool shouldDrawRadial = (demandPoint is not null) || (radialLine is not null);

        if (shouldDrawRadial)
        {
            sb.Append(
                FormattableString.Invariant(
                    $"<line x1='{ScaleX(startX):F1}' y1='{ScaleY(startY):F1}' x2='{ScaleX(endX):F1}' y2='{ScaleY(endY):F1}' stroke='#DB252F' stroke-width='2.0' stroke-dasharray='8,6' stroke-linecap='round'/>"));
        }

        foreach (var group in envelopeGroups)
        {
            if (group.Count < 2)
            {
                continue;
            }

            var path = new StringBuilder();
            for (int i = 0; i < group.Count; i++)
            {
                double px = ScaleX(group[i].X);
                double py = ScaleY(group[i].Y);
                path.Append(i == 0 ? FormattableString.Invariant($"M{px:F1},{py:F1}") : FormattableString.Invariant($" L{px:F1},{py:F1}"));
            }

            if (group.Count > 2 && !PointsCoincide(group[0], group[^1]))
            {
                path.Append(" Z");
            }

            sb.Append($"<path d='{path}' fill='none' stroke='#004B85' stroke-width='3.2' stroke-linejoin='round' stroke-linecap='round'/>");
        }

        AppendAxes(sb, xTicks, yTicks, plotX, plotY, plotW, plotH, axisX, axisY, ScaleX, ScaleY);
        AppendControlPoints(sb, specialPoints, ScaleX, ScaleY, screenCenterX);
        AppendDemandPoint(sb, demandPoint, ScaleX, ScaleY, screenCenterX, plotX + plotW, plotY);
        AppendAxisLabels(sb, block.XAxisLabel, block.YAxisLabel, plotX, plotY, plotW, plotH, axisX, axisY);

        sb.Append("</svg>");
        return sb.ToString();
    }

    private static (double XMin, double XMax, double YMin, double YMax, double XRange, double YRange) BuildDomain(
        DiagramBlock block,
        IReadOnlyList<ControlPointDto> points,
        IReadOnlyList<ChartReferenceLineDto> lines)
    {
        var xs = points.Select(p => p.X)
            .Concat(lines.SelectMany(l => new[] { l.StartX, l.EndX }))
            .Concat(new[] { 0.0 })
            .ToList();
        var ys = points.Select(p => p.Y)
            .Concat(lines.SelectMany(l => new[] { l.StartY, l.EndY }))
            .Concat(new[] { 0.0 })
            .ToList();

        double xMin = xs.Min();
        double xMax = xs.Max();
        double yMin = ys.Min();
        double yMax = ys.Max();

        ExpandRange(ref xMin, ref xMax);
        ExpandRange(ref yMin, ref yMax);

        if (block.UseEqualAspect)
        {
            double maxAbs = SystemMath.Max(SystemMath.Max(SystemMath.Abs(xMin), SystemMath.Abs(xMax)), SystemMath.Max(SystemMath.Abs(yMin), SystemMath.Abs(yMax)));
            xMin = -maxAbs;
            xMax = maxAbs;
            yMin = -maxAbs;
            yMax = maxAbs;
        }
        else
        {
            BalanceRangeAroundZero(ref xMin, ref xMax);
            BalanceRangeAroundZero(ref yMin, ref yMax);
        }

        double xRange = SystemMath.Max(xMax - xMin, 1e-6);
        double yRange = SystemMath.Max(yMax - yMin, 1e-6);
        return (xMin, xMax, yMin, yMax, xRange, yRange);
    }

    private static void ExpandRange(ref double min, ref double max)
    {
        if (SystemMath.Abs(max - min) < 1e-9)
        {
            double delta = SystemMath.Max(1.0, SystemMath.Abs(max) * 0.2);
            min -= delta;
            max += delta;
        }

        double margin = (max - min) * 0.07;
        min -= margin;
        max += margin;
    }

    private static void BalanceRangeAroundZero(ref double min, ref double max)
    {
        min = SystemMath.Min(min, 0);
        max = SystemMath.Max(max, 0);
    }

    private static List<List<ControlPointDto>> BuildEnvelopeGroups(IReadOnlyList<ControlPointDto> points)
    {
        var filtered = points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint && !p.IsNominal)
            .GroupBy(p => p.GroupKey)
            .Select(g => g.ToList())
            .Where(g => g.Count >= 2)
            .ToList();

        if (filtered.Count > 0)
        {
            return filtered;
        }

        return points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint)
            .GroupBy(p => p.GroupKey)
            .Select(g => g.ToList())
            .Where(g => g.Count >= 2)
            .ToList();
    }

    private static (double X, double Y)? FindCapacityIntersection(
        List<List<ControlPointDto>> envelopeGroups,
        ControlPointDto demandPoint)
    {
        double dx = demandPoint.X;
        double dy = demandPoint.Y;
        double len = SystemMath.Sqrt(dx * dx + dy * dy);
        if (len < 1e-9)
        {
            return null;
        }

        var intersections = new List<(double t, double x, double y)>();

        foreach (var group in envelopeGroups)
        {
            if (group.Count < 2)
            {
                continue;
            }

            int n = group.Count;
            bool isClosed = n > 2 && !PointsCoincide(group[0], group[^1]);
            int limit = isClosed ? n : n - 1;

            for (int i = 0; i < limit; i++)
            {
                var pA = group[i];
                var pB = group[(i + 1) % n];

                double ax = pA.X;
                double ay = pA.Y;
                double bx = pB.X;
                double by = pB.Y;

                double segDx = bx - ax;
                double segDy = by - ay;

                double det = dy * segDx - dx * segDy;
                if (SystemMath.Abs(det) < 1e-12)
                {
                    continue;
                }

                double t = (ay * segDx - ax * segDy) / det;
                double u = (dx * ay - dy * ax) / det;

                const double eps = 1e-9;
                if (t >= -eps && u >= -eps && u <= 1.0 + eps)
                {
                    double clampedU = SystemMath.Max(0.0, SystemMath.Min(1.0, u));
                    double ix = ax + clampedU * segDx;
                    double iy = ay + clampedU * segDy;
                    intersections.Add((t, ix, iy));
                }
            }
        }

        if (intersections.Count == 0)
        {
            return null;
        }

        var insideIntersections = intersections.Where(it => it.t >= 1.0 - 1e-5).ToList();
        if (insideIntersections.Count > 0)
        {
            var best = insideIntersections.OrderBy(it => it.t).First();
            return (best.x, best.y);
        }
        else
        {
            var best = intersections.Where(it => it.t >= -1e-9).OrderByDescending(it => it.t).FirstOrDefault();
            if (best.t >= -1e-9)
            {
                return (best.x, best.y);
            }
        }

        return null;
    }

    private static ChartReferenceLineDto? SelectDemandRadialLine(IReadOnlyList<ChartReferenceLineDto> lines, ControlPointDto? demandPoint)
    {
        var proportional = lines
            .Where(l => string.Equals(l.LineType, "Proportional", StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (proportional.Count == 0)
        {
            if (demandPoint is null)
            {
                return null;
            }

            return new ChartReferenceLineDto(0, 0, demandPoint.X, demandPoint.Y, demandPoint.Label, "Demand", true);
        }

        if (demandPoint is null)
        {
            return proportional[0];
        }

        return proportional
            .OrderBy(l => DistanceSquared(l.EndX, l.EndY, demandPoint.X, demandPoint.Y))
            .First();
    }

    private static void AppendGridLines(
        StringBuilder sb,
        IEnumerable<double> ticks,
        bool isVertical,
        double plotX,
        double plotY,
        double plotW,
        double plotH,
        Func<double, double> scaleX,
        Func<double, double> scaleY,
        string stroke,
        double strokeWidth)
    {
        foreach (double value in ticks)
        {
            if (isVertical)
            {
                double x = scaleX(value);
                sb.Append(FormattableString.Invariant($"<line x1='{x:F1}' y1='{plotY:F1}' x2='{x:F1}' y2='{plotY + plotH:F1}' stroke='{stroke}' stroke-width='{strokeWidth:F2}'/>"));
            }
            else
            {
                double y = scaleY(value);
                sb.Append(FormattableString.Invariant($"<line x1='{plotX:F1}' y1='{y:F1}' x2='{plotX + plotW:F1}' y2='{y:F1}' stroke='{stroke}' stroke-width='{strokeWidth:F2}'/>"));
            }
        }
    }

    private static void AppendAxes(
        StringBuilder sb,
        AxisTicks xTicks,
        AxisTicks yTicks,
        double plotX,
        double plotY,
        double plotW,
        double plotH,
        double axisX,
        double axisY,
        Func<double, double> scaleX,
        Func<double, double> scaleY)
    {
        sb.Append(FormattableString.Invariant($"<line x1='{plotX:F1}' y1='{axisY:F1}' x2='{plotX + plotW:F1}' y2='{axisY:F1}' stroke='#1F2937' stroke-width='1.8'/>"));
        sb.Append(FormattableString.Invariant($"<polygon points='{plotX + plotW - 10:F1},{axisY - 4.5:F1} {plotX + plotW:F1},{axisY:F1} {plotX + plotW - 10:F1},{axisY + 4.5:F1}' fill='#1F2937'/>"));

        sb.Append(FormattableString.Invariant($"<line x1='{axisX:F1}' y1='{plotY:F1}' x2='{axisX:F1}' y2='{plotY + plotH:F1}' stroke='#1F2937' stroke-width='1.8'/>"));
        sb.Append(FormattableString.Invariant($"<polygon points='{axisX - 4.5:F1},{plotY + 10:F1} {axisX:F1},{plotY:F1} {axisX + 4.5:F1},{plotY + 10:F1}' fill='#1F2937'/>"));

        foreach (double x in xTicks.MajorTicks)
        {
            double px = scaleX(x);
            sb.Append(FormattableString.Invariant($"<line x1='{px:F1}' y1='{axisY - 5:F1}' x2='{px:F1}' y2='{axisY + 5:F1}' stroke='#334155' stroke-width='1.1'/>"));
            sb.Append(FormattableString.Invariant($"<text x='{px:F1}' y='{axisY + 24:F1}' text-anchor='middle' font-size='16' font-weight='500' fill='#334155'>{EscapeXml(FormatTick(x))}</text>"));
        }

        foreach (double x in xTicks.MinorTicks)
        {
            double px = scaleX(x);
            sb.Append(FormattableString.Invariant($"<line x1='{px:F1}' y1='{axisY - 2.5:F1}' x2='{px:F1}' y2='{axisY + 2.5:F1}' stroke='#64748B' stroke-width='0.8'/>"));
        }

        foreach (double y in yTicks.MajorTicks)
        {
            double py = scaleY(y);
            sb.Append(FormattableString.Invariant($"<line x1='{axisX - 5:F1}' y1='{py:F1}' x2='{axisX + 5:F1}' y2='{py:F1}' stroke='#334155' stroke-width='1.1'/>"));
            sb.Append(FormattableString.Invariant($"<text x='{axisX + 11:F1}' y='{py + 5:F1}' text-anchor='start' font-size='16' font-weight='500' fill='#334155'>{EscapeXml(FormatTick(y))}</text>"));
        }

        foreach (double y in yTicks.MinorTicks)
        {
            double py = scaleY(y);
            sb.Append(FormattableString.Invariant($"<line x1='{axisX - 2.5:F1}' y1='{py:F1}' x2='{axisX + 2.5:F1}' y2='{py:F1}' stroke='#64748B' stroke-width='0.8'/>"));
        }
    }

    private static void AppendControlPoints(
        StringBuilder sb,
        IReadOnlyList<ControlPointDto> points,
        Func<double, double> scaleX,
        Func<double, double> scaleY,
        double screenCenterX)
    {
        foreach (var point in points)
        {
            double px = scaleX(point.X);
            double py = scaleY(point.Y);
            string fill = GetSpecialPointColor(point.Label);
            sb.Append(FormattableString.Invariant($"<path d='{BuildTrianglePath(px, py, 8.0)}' fill='{fill}' stroke='white' stroke-width='2.1' stroke-linejoin='round'/>"));
            sb.Append(FormattableString.Invariant($"<path d='{BuildTrianglePath(px, py, 8.0)}' fill='none' stroke='#334155' stroke-opacity='0.45' stroke-width='0.8' stroke-linejoin='round'/>"));
        }
    }

    private static void AppendDemandPoint(
        StringBuilder sb,
        ControlPointDto? point,
        Func<double, double> scaleX,
        Func<double, double> scaleY,
        double screenCenterX,
        double plotRight,
        double plotTop)
    {
        if (point is null)
        {
            return;
        }

        double px = scaleX(point.X);
        double py = scaleY(point.Y);
        sb.Append(FormattableString.Invariant($"<circle cx='{px:F1}' cy='{py:F1}' r='6.6' fill='#DB252F' stroke='#FFFFFF' stroke-width='2.2'/>"));
        sb.Append(FormattableString.Invariant($"<circle cx='{px:F1}' cy='{py:F1}' r='7.8' fill='none' stroke='#111827' stroke-width='0.9' stroke-opacity='0.55'/>"));

        string label = BuildDemandLabel(point);
        double approxWidth = 10.5 * label.Length + 22;
        bool placeRight = px < screenCenterX;
        double boxX = placeRight ? px + 12 : px - approxWidth - 12;
        boxX = SystemMath.Max(6, SystemMath.Min(plotRight - approxWidth - 6, boxX));
        double boxY = SystemMath.Max(plotTop + 6, py - 31);

        sb.Append(FormattableString.Invariant($"<rect x='{boxX:F1}' y='{boxY:F1}' width='{approxWidth:F1}' height='25' rx='3' ry='3' fill='white' fill-opacity='0.96' stroke='#9CA3AF' stroke-width='0.9'/>"));
        sb.Append(FormattableString.Invariant($"<text x='{boxX + 11:F1}' y='{boxY + 18:F1}' font-size='17' font-weight='700' fill='#B91C1C'>{EscapeXml(label)}</text>"));
    }

    private static void AppendAxisLabels(
        StringBuilder sb,
        string xLabel,
        string yLabel,
        double plotX,
        double plotY,
        double plotW,
        double plotH,
        double axisX,
        double axisY)
    {
        double xLabelX = plotX + plotW - 16;
        double xLabelY = axisY - 14;
        if (xLabelY < plotY + 24)
        {
            xLabelY = plotY + 24;
        }

        if (xLabelY > plotY + plotH - 12)
        {
            xLabelY = plotY + plotH - 12;
        }

        double yLabelX = axisX + 12;
        if (yLabelX > plotX + plotW - 24)
        {
            yLabelX = plotX + plotW - 24;
        }

        if (yLabelX < plotX + 24)
        {
            yLabelX = plotX + 24;
        }

        double yLabelY = plotY + 24;

        sb.Append(FormattableString.Invariant($"<text x='{xLabelX:F1}' y='{xLabelY:F1}' text-anchor='end' font-size='20' font-weight='700' fill='#1F2937'>{EscapeXml(xLabel)}</text>"));
        sb.Append(FormattableString.Invariant($"<text x='{yLabelX:F1}' y='{yLabelY:F1}' text-anchor='start' font-size='20' font-weight='700' fill='#1F2937'>{EscapeXml(yLabel)}</text>"));
    }

    private static AxisTicks GenerateTicks(double min, double max, int targetMajorCount, int minorDivisions)
    {
        if (double.IsNaN(min) || double.IsInfinity(min) || double.IsNaN(max) || double.IsInfinity(max) || SystemMath.Abs(max - min) < 1e-12)
        {
            min = -1;
            max = 1;
        }

        if (max < min)
        {
            (min, max) = (max, min);
        }

        double major = NiceNumber((max - min) / SystemMath.Max(1, targetMajorCount), true);
        double minor = major / SystemMath.Max(1, minorDivisions);
        double tickMin = SystemMath.Floor(min / major) * major;
        double tickMax = SystemMath.Ceiling(max / major) * major;

        var majorTicks = GenerateTickValues(tickMin, tickMax, major);
        var minorTickKeys = new HashSet<long>(majorTicks.Select(v => Quantize(v / minor)));
        var minorTicks = new List<double>();
        double firstMinor = SystemMath.Ceiling(min / minor) * minor;
        for (double value = firstMinor; value <= max + minor * 0.5; value += minor)
        {
            long key = Quantize(value / minor);
            if (!minorTickKeys.Contains(key))
            {
                minorTicks.Add(SystemMath.Abs(value) < minor * 1e-8 ? 0 : value);
            }
        }

        return new AxisTicks(tickMin, tickMax, major, minor, majorTicks, minorTicks);
    }

    private static List<double> GenerateTickValues(double min, double max, double step)
    {
        var ticks = new List<double>();
        double first = SystemMath.Ceiling(min / step) * step;
        for (double value = first; value <= max + step * 0.5; value += step)
        {
            ticks.Add(SystemMath.Abs(value) < step * 1e-8 ? 0 : value);
        }

        return ticks;
    }

    private static long Quantize(double value) => (long)SystemMath.Round(value * 1_000_000);

    private static double NiceNumber(double value, bool round)
    {
        if (value <= 0 || double.IsNaN(value) || double.IsInfinity(value))
        {
            return 1;
        }

        double exponent = SystemMath.Floor(SystemMath.Log10(value));
        double fraction = value / SystemMath.Pow(10, exponent);
        double niceFraction;
        if (round)
        {
            niceFraction = fraction < 1.5 ? 1 : fraction < 2.25 ? 2 : fraction < 3.5 ? 2.5 : fraction < 7.5 ? 5 : 10;
        }
        else
        {
            niceFraction = fraction <= 1 ? 1 : fraction <= 2 ? 2 : fraction <= 2.5 ? 2.5 : fraction <= 5 ? 5 : 10;
        }

        return niceFraction * SystemMath.Pow(10, exponent);
    }

    private static string BuildTrianglePath(double centerX, double centerY, double radius)
    {
        return FormattableString.Invariant(
            $"M{centerX:F1},{centerY - radius:F1} L{centerX + radius * 0.88:F1},{centerY + radius * 0.72:F1} L{centerX - radius * 0.88:F1},{centerY + radius * 0.72:F1} Z");
    }

    private static bool PointsCoincide(ControlPointDto a, ControlPointDto b)
        => SystemMath.Abs(a.X - b.X) < 1e-9 && SystemMath.Abs(a.Y - b.Y) < 1e-9;

    private static double DistanceSquared(double x1, double y1, double x2, double y2)
    {
        double dx = x1 - x2;
        double dy = y1 - y2;
        return dx * dx + dy * dy;
    }

    private static string GetSpecialPointColor(string label)
    {
        return label switch
        {
            "Max Compression" => "#D62828",
            "Zero Tension" => "#F08C00",
            "50% Yield" => "#E6B800",
            "Balanced" => "#2E8B57",
            "Tension Control" => "#2563EB",
            "Pure Bending" => "#5B21B6",
            "Max Tension" => "#C026D3",
            _ => "#D76B0F"
        };
    }

    private static bool IsFinite(ControlPointDto point) => IsFinite(point.X) && IsFinite(point.Y);

    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);

    private static string FormatTick(double value)
    {
        if (SystemMath.Abs(value) < 1e-10)
        {
            return "0";
        }

        return value.ToString("#,##0.##", CultureInfo.InvariantCulture);
    }

    private static string EscapeXml(string value)
        => value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;").Replace("\"", "&quot;");

    private static string BuildDemandLabel(ControlPointDto point)
    {
        string name = ShortLabel(point.Label, 14);
        if (!string.IsNullOrWhiteSpace(point.StatusText))
        {
            return $"{name} ({point.StatusText})";
        }

        return point.Utilization > 1e-9 ? $"{name} UR {point.Utilization:0.###}" : name;
    }

    private static string ShortLabel(string? value, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "";
        }

        return value.Length <= maxLength ? value : value[..(maxLength - 1)] + "...";
    }

    private sealed record AxisTicks(
        double Min,
        double Max,
        double MajorInterval,
        double MinorInterval,
        IReadOnlyList<double> MajorTicks,
        IReadOnlyList<double> MinorTicks);

    public static class SectionGeometryRenderer
    {
        public static string RenderSection(
            SectionShapeType shape,
            double widthMm,
            double heightMm,
            double diameterMm,
            double coverMm,
            IReadOnlyList<RebarCoordinateDto> rebars)
        {
            return shape switch
            {
                SectionShapeType.Circular => RenderCircular(diameterMm, coverMm, rebars),
                SectionShapeType.Irregular => RenderIrregular(rebars),
                _ => RenderRectangular(widthMm, heightMm, coverMm, rebars),
            };
        }

        private static string RenderRectangular(
            double widthMm, double heightMm, double coverMm,
            IReadOnlyList<RebarCoordinateDto> rebars)
        {
            const double svgSize = 200;
            double scale = svgSize / SystemMath.Max(widthMm, heightMm) * 0.85;
            double ox = (svgSize - widthMm * scale) / 2;
            double oy = (svgSize - heightMm * scale) / 2;

            var sb = new StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}' font-family='Inter, Segoe UI, sans-serif'>");
            sb.Append($"<rect x='0' y='0' width='{svgSize}' height='{svgSize}' fill='white'/>");

            double bw = widthMm * scale;
            double bh = heightMm * scale;
            sb.Append($"<rect x='{ox:F1}' y='{oy:F1}' width='{bw:F1}' height='{bh:F1}' fill='#E0E0E0' stroke='#333' stroke-width='1.5'/>");

            double cv = coverMm * scale;
            sb.Append($"<rect x='{ox + cv:F1}' y='{oy + cv:F1}' width='{bw - 2 * cv:F1}' height='{bh - 2 * cv:F1}' fill='none' stroke='#999' stroke-width='0.5' stroke-dasharray='3,2'/>");

            foreach (var rebar in rebars)
            {
                double rx = ox + (widthMm / 2 + rebar.X) * scale;
                double ry = oy + (heightMm / 2 - rebar.Y) * scale;
                double barR = SystemMath.Max(2, rebar.Diameter / 2 * scale);
                sb.Append($"<circle cx='{rx:F1}' cy='{ry:F1}' r='{barR:F1}' fill='#333'/>");
            }

            sb.Append("</svg>");
            return sb.ToString();
        }

        private static string RenderCircular(
            double diamMm, double coverMm,
            IReadOnlyList<RebarCoordinateDto> rebars)
        {
            const double svgSize = 200;
            double cx = svgSize / 2;
            double cy = svgSize / 2;
            double r = diamMm / 2;
            double scale = (svgSize * 0.85) / diamMm;
            double svgR = r * scale;
            double svgCoverR = (r - coverMm) * scale;

            var sb = new StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}' font-family='Inter, Segoe UI, sans-serif'>");
            sb.Append($"<rect x='0' y='0' width='{svgSize}' height='{svgSize}' fill='white'/>");
            sb.Append($"<circle cx='{cx:F1}' cy='{cy:F1}' r='{svgR:F1}' fill='#E0E0E0' stroke='#333' stroke-width='1.5'/>");
            sb.Append($"<circle cx='{cx:F1}' cy='{cy:F1}' r='{svgCoverR:F1}' fill='none' stroke='#999' stroke-width='0.5' stroke-dasharray='3,2'/>");

            foreach (var rebar in rebars)
            {
                double rx = cx + rebar.X * scale;
                double ry = cy - rebar.Y * scale;
                double barR = SystemMath.Max(2, rebar.Diameter / 2 * scale);
                sb.Append($"<circle cx='{rx:F1}' cy='{ry:F1}' r='{barR:F1}' fill='#333'/>");
            }

            sb.Append("</svg>");
            return sb.ToString();
        }

        private static string RenderIrregular(IReadOnlyList<RebarCoordinateDto> rebars)
        {
            const double svgSize = 200;
            var sb = new StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}' font-family='Inter, Segoe UI, sans-serif'>");
            sb.Append($"<rect x='0' y='0' width='{svgSize}' height='{svgSize}' fill='white'/>");
            sb.Append("<text x='100' y='100' text-anchor='middle' font-size='12' fill='#555'>Irregular section</text>");
            sb.Append("</svg>");
            return sb.ToString();
        }
    }
}
