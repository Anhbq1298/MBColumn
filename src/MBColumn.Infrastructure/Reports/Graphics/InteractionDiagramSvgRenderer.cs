using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using SystemMath = System.Math;

namespace MBColumn.Infrastructure.Reports.Graphics;

/// <summary>
/// Renders section geometry and interaction diagrams as inline SVG strings.
/// The nested <see cref="SectionGeometryRenderer"/> is importable via
/// <c>using static MBColumn.Infrastructure.Reports.Graphics.InteractionDiagramSvgRenderer;</c>
/// </summary>
public static class InteractionDiagramSvgRenderer
{
    // ─── Interaction diagram SVG ────────────────────────────────────────────

    /// <summary>Renders a P-M interaction diagram to an inline SVG string.</summary>
    public static string RenderDiagram(DiagramBlock block, int svgWidth = 500, int svgHeight = 400)
    {
        const int paddingLeft = 55, paddingRight = 20, paddingTop = 20, paddingBottom = 45;

        int plotW = svgWidth  - paddingLeft - paddingRight;
        int plotH = svgHeight - paddingTop  - paddingBottom;

        // ── Data bounds ──────────────────────────────────────────────────────
        var allX = block.Points.Select(p => p.X).Concat(block.ReferenceLines.SelectMany(l => new[] { l.StartX, l.EndX })).ToList();
        var allY = block.Points.Select(p => p.Y).Concat(block.ReferenceLines.SelectMany(l => new[] { l.StartY, l.EndY })).ToList();

        if (!allX.Any()) return "<svg xmlns='http://www.w3.org/2000/svg'/>";

        double xMin = allX.Min(), xMax = allX.Max();
        double yMin = allY.Min(), yMax = allY.Max();

        // Force symmetric X range for equal-aspect diagrams
        if (block.UseEqualAspect)
        {
            double xRange = SystemMath.Max(SystemMath.Abs(xMin), SystemMath.Abs(xMax));
            xMin = -xRange; xMax = xRange;
        }

        double xRange2 = SystemMath.Max(xMax - xMin, 1e-6);
        double yRange  = SystemMath.Max(yMax - yMin, 1e-6);

        // Add 5 % margin
        xMin -= xRange2 * 0.05; xMax += xRange2 * 0.05;
        yMin -= yRange  * 0.05; yMax += yRange  * 0.05;
        xRange2 = xMax - xMin;
        yRange  = yMax - yMin;

        double ScaleX(double v) => paddingLeft  + (v - xMin) / xRange2 * plotW;
        double ScaleY(double v) => paddingTop   + plotH - (v - yMin) / yRange * plotH;

        // ── Build SVG ────────────────────────────────────────────────────────
        var sb = new System.Text.StringBuilder();
        sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgWidth}' height='{svgHeight}' viewBox='0 0 {svgWidth} {svgHeight}'>");
        sb.Append($"<rect width='{svgWidth}' height='{svgHeight}' fill='white'/>");

        // Plot area background
        sb.Append($"<rect x='{paddingLeft}' y='{paddingTop}' width='{plotW}' height='{plotH}' fill='#FAFAFA' stroke='#CCCCCC' stroke-width='1'/>");

        // Zero axes (if within range)
        if (xMin <= 0 && xMax >= 0)
        {
            double x0 = ScaleX(0);
            sb.Append($"<line x1='{x0:F1}' y1='{paddingTop}' x2='{x0:F1}' y2='{paddingTop + plotH}' stroke='#BBBBBB' stroke-width='0.7' stroke-dasharray='4,3'/>");
        }
        if (yMin <= 0 && yMax >= 0)
        {
            double y0 = ScaleY(0);
            sb.Append($"<line x1='{paddingLeft}' y1='{y0:F1}' x2='{paddingLeft + plotW}' y2='{y0:F1}' stroke='#BBBBBB' stroke-width='0.7' stroke-dasharray='4,3'/>");
        }

        // Reference lines
        foreach (var rl in block.ReferenceLines)
        {
            double x1 = ScaleX(rl.StartX), y1 = ScaleY(rl.StartY);
            double x2 = ScaleX(rl.EndX),   y2 = ScaleY(rl.EndY);
            string dash = rl.IsDashed ? " stroke-dasharray='6,4'" : "";
            sb.Append($"<line x1='{x1:F1}' y1='{y1:F1}' x2='{x2:F1}' y2='{y2:F1}' stroke='#E08030' stroke-width='1.2'{dash}/>");
        }

        // Capacity curve (non-demand, non-reference points, grouped by SliceKey/GroupKey)
        var capacityPoints = block.Points
            .Where(p => !p.IsDemand && !p.IsReference)
            .OrderBy(p => p.SortKey)
            .ToList();

        if (capacityPoints.Count >= 2)
        {
            var path = new System.Text.StringBuilder();
            for (int i = 0; i < capacityPoints.Count; i++)
            {
                double px = ScaleX(capacityPoints[i].X);
                double py = ScaleY(capacityPoints[i].Y);
                path.Append(i == 0 ? $"M{px:F1},{py:F1}" : $" L{px:F1},{py:F1}");
            }
            sb.Append($"<path d='{path}' fill='none' stroke='#1A3A5C' stroke-width='1.8' stroke-linejoin='round'/>");
        }

        // Demand points
        foreach (var p in block.Points.Where(p => p.IsDemand))
        {
            double px = ScaleX(p.X), py = ScaleY(p.Y);
            bool governs = p.IsGoverning;
            sb.Append($"<circle cx='{px:F1}' cy='{py:F1}' r='{(governs ? 6 : 4)}' fill='{(p.Utilization > 1.0 ? "#E74C3C" : "#27AE60")}' stroke='white' stroke-width='1'/>");
        }

        // Axis labels
        double midX = paddingLeft + plotW / 2.0;
        double midY = paddingTop  + plotH / 2.0;

        sb.Append($"<text x='{midX:F0}' y='{svgHeight - 6}' text-anchor='middle' font-size='11' fill='#444'>{EscapeXml(block.XLabel)}</text>");
        sb.Append($"<text x='13' y='{midY:F0}' text-anchor='middle' font-size='11' fill='#444' transform='rotate(-90 13 {midY:F0})'>{EscapeXml(block.YLabel)}</text>");

        // Axis tick values
        AppendAxisTicks(sb, xMin, xMax, paddingLeft, paddingTop + plotH + 4, plotW, isX: true);
        AppendAxisTicks(sb, yMin, yMax, paddingLeft - 4, paddingTop, plotH, isX: false);

        // Caption
        if (!string.IsNullOrEmpty(block.Caption))
            sb.Append($"<text x='{midX:F0}' y='{svgHeight - 24}' text-anchor='middle' font-size='9' fill='#666' font-style='italic'>{EscapeXml(block.Caption)}</text>");

        sb.Append("</svg>");
        return sb.ToString();
    }

    private static void AppendAxisTicks(
        System.Text.StringBuilder sb,
        double vMin, double vMax,
        double originPx, double baselinePx,
        double rangePx,
        bool isX)
    {
        int tickCount = 5;
        double step = NiceStep((vMax - vMin) / tickCount);
        double first = SystemMath.Ceiling(vMin / step) * step;

        for (double v = first; v <= vMax + step * 0.5; v += step)
        {
            double frac = (v - vMin) / (vMax - vMin);
            double px = isX ? originPx + frac * rangePx : baselinePx + (1.0 - frac) * rangePx;

            string label = SystemMath.Abs(v) < step * 0.01 ? "0" : FormatTick(v);

            if (isX)
                sb.Append($"<text x='{px:F1}' y='{baselinePx + 13}' text-anchor='middle' font-size='8' fill='#666'>{label}</text>");
            else
                sb.Append($"<text x='{originPx - 2}' y='{px + 3:F1}' text-anchor='end' font-size='8' fill='#666'>{label}</text>");
        }
    }

    private static double NiceStep(double roughStep)
    {
        if (roughStep <= 0) return 1;
        double exp = SystemMath.Floor(SystemMath.Log10(roughStep));
        double frac = roughStep / SystemMath.Pow(10, exp);
        double nice = frac < 1.5 ? 1 : frac < 3.5 ? 2 : frac < 7.5 ? 5 : 10;
        return nice * SystemMath.Pow(10, exp);
    }

    private static string FormatTick(double v)
    {
        if (SystemMath.Abs(v) >= 1000)  return $"{v / 1000:0.#}k";
        if (SystemMath.Abs(v) >= 10)    return $"{v:0.#}";
        if (SystemMath.Abs(v) >= 1)     return $"{v:0.##}";
        return $"{v:0.###}";
    }

    private static string EscapeXml(string s)
        => s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;");

    // ─── Nested class: section geometry renderer ────────────────────────────

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
                SectionShapeType.Circular  => RenderCircular(diameterMm, coverMm, rebars),
                SectionShapeType.Irregular => RenderIrregular(rebars),
                _                          => RenderRectangular(widthMm, heightMm, coverMm, rebars),
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

            var sb = new System.Text.StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}'>");
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
            double cx = svgSize / 2, cy = svgSize / 2;
            double r = diamMm / 2;
            double scale = (svgSize * 0.85) / diamMm;
            double svgR = r * scale;
            double svgCoverR = (r - coverMm) * scale;

            var sb = new System.Text.StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}'>");
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
            var sb = new System.Text.StringBuilder();
            sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{svgSize}' height='{svgSize}' viewBox='0 0 {svgSize} {svgSize}'>");
            sb.Append($"<rect x='0' y='0' width='{svgSize}' height='{svgSize}' fill='white'/>");
            sb.Append("<text x='100' y='100' text-anchor='middle' font-size='12' fill='#555'>Irregular section</text>");
            sb.Append("</svg>");
            return sb.ToString();
        }
    }
}
