using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;
using System.Globalization;
using System.Text;
using SMath = System.Math;

namespace MBColumn.Infrastructure.Reports.Graphics;

/// <summary>
/// Generates SVG diagrams for section geometry and rebar layout.
/// All coordinates in mm; SVG output is scaled to fit a fixed viewport.
/// </summary>
public static class SectionGeometryRenderer
{
    private const int ViewW = 400;
    private const int ViewH = 400;
    private const int PadL  = 48;   // left: room for h= label
    private const int PadR  = 20;
    private const int PadT  = 36;   // top: room for title
    private const int PadB  = 44;   // bottom: room for b= label

    private static string D(double v, int decimals = 1) =>
        v.ToString($"F{decimals}", CultureInfo.InvariantCulture);

    // ── Public API ────────────────────────────────────────────────────────────

    public static string RenderRectangularSection(double widthMm, double heightMm, double coverMm,
        IReadOnlyList<RebarCoordinateDto> bars, double linkDiameterMm = 0.0, int totalLegsX = 2, int totalLegsY = 2)
    {
        int plotW = ViewW - PadL - PadR;
        int plotH = ViewH - PadT - PadB;
        double scaleX = plotW / widthMm;
        double scaleY = plotH / heightMm;
        double scale  = SMath.Min(scaleX, scaleY);

        double sw = widthMm  * scale;
        double sh = heightMm * scale;
        double ox = PadL + (plotW - sw) / 2.0;
        double oy = PadT + (plotH - sh) / 2.0;
        double cx = ox + sw / 2, cy = oy + sh / 2;

        double barR    = bars.Count > 0 ? SMath.Max(bars[0].Diameter / 2.0 * scale * 0.9, 3.5) : 4.0;
        double covPx   = coverMm * scale;
        double totalAs = bars.Sum(b => b.Area);
        double ag      = widthMm * heightMm;
        double rho     = ag > 0 ? totalAs / ag * 100 : 0;
        string barLabel = bars.Count > 0 ? bars[0].BarSizeLabel : "";
        string title    = $"{D(widthMm, 0)} × {D(heightMm, 0)} mm";
        string sub      = bars.Count > 0 ? $"{bars.Count}-{barLabel}  (ρ = {D(rho, 2)}%)" : "";

        var sb = new StringBuilder();
        sb.AppendLine($@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""{ViewW}"" height=""{ViewH}"" viewBox=""0 0 {ViewW} {ViewH}"" font-family=""Inter, Segoe UI, sans-serif"" font-size=""10"">");

        // ── Title block ────────────────────────────────────────────────────────
        sb.AppendLine($@"  <text x=""{D(cx)}"" y=""14"" text-anchor=""middle"" font-weight=""bold"" font-size=""12"" fill=""#1A3A5C"">{title}</text>");
        if (!string.IsNullOrEmpty(sub))
            sb.AppendLine($@"  <text x=""{D(cx)}"" y=""27"" text-anchor=""middle"" font-size=""10"" fill=""#555"">{sub}</text>");

        // ── Section fill & outline ─────────────────────────────────────────────
        sb.AppendLine($@"  <rect x=""{D(ox)}"" y=""{D(oy)}"" width=""{D(sw)}"" height=""{D(sh)}"" fill=""#EEF4FB"" stroke=""#1A3A5C"" stroke-width=""2""/>");

        DrawRectangularLinks(sb, bars, scale, cx, cy, ox, oy, sw, sh, coverMm, linkDiameterMm, totalLegsX, totalLegsY);

        // ── Cover outline (dashed) ─────────────────────────────────────────────
        sb.AppendLine($@"  <rect x=""{D(ox + covPx)}"" y=""{D(oy + covPx)}"" width=""{D(sw - 2 * covPx)}"" height=""{D(sh - 2 * covPx)}"" fill=""none"" stroke=""#5B8DB8"" stroke-width=""1"" stroke-dasharray=""5 3""/>");

        // ── Local axes ─────────────────────────────────────────────────────────
        double axLen = SMath.Min(sw, sh) * 0.22;
        sb.AppendLine($@"  <line x1=""{D(cx)}"" y1=""{D(cy + axLen)}"" x2=""{D(cx)}"" y2=""{D(cy - axLen)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <line x1=""{D(cx - axLen)}"" y1=""{D(cy)}"" x2=""{D(cx + axLen)}"" y2=""{D(cy)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(cx + axLen + 3)}"" y=""{D(cy + 4)}"" fill=""#666"" font-size=""9"">X</text>");
        sb.AppendLine($@"  <text x=""{D(cx - 4)}"" y=""{D(cy - axLen - 3)}"" fill=""#666"" font-size=""9"">Y</text>");
        sb.AppendLine($@"  <circle cx=""{D(cx)}"" cy=""{D(cy)}"" r=""2.5"" fill=""#C0392B""/>");

        // ── Rebar dots ─────────────────────────────────────────────────────────
        foreach (var bar in bars)
        {
            double bx = cx + bar.X * scale;
            double by = cy - bar.Y * scale;
            sb.AppendLine($@"  <circle cx=""{D(bx)}"" cy=""{D(by)}"" r=""{D(barR)}"" fill=""#1A3A5C"" stroke=""white"" stroke-width=""0.8""/>");
        }

        // ── Dimension annotations ──────────────────────────────────────────────
        // Bottom: b = xxx mm
        double dimY = oy + sh + 20;
        sb.AppendLine($@"  <line x1=""{D(ox)}"" y1=""{D(dimY)}"" x2=""{D(ox + sw)}"" y2=""{D(dimY)}"" stroke=""#333"" stroke-width=""1"" marker-start=""url(#arr)"" marker-end=""url(#arr)""/>");
        sb.AppendLine($@"  <text x=""{D(cx)}"" y=""{D(dimY + 11)}"" text-anchor=""middle"" fill=""#333"" font-size=""10"">b = {D(widthMm, 0)} mm</text>");
        // Left: h = xxx mm
        double dimX = ox - 20;
        sb.AppendLine($@"  <line x1=""{D(dimX)}"" y1=""{D(oy)}"" x2=""{D(dimX)}"" y2=""{D(oy + sh)}"" stroke=""#333"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(dimX - 3)}"" y=""{D(cy + 4)}"" text-anchor=""middle"" fill=""#333"" font-size=""10"" transform=""rotate(-90 {D(dimX - 3)} {D(cy)})"">h = {D(heightMm, 0)} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public static string RenderCircularSection(double diameterMm, double coverMm,
        IReadOnlyList<RebarCoordinateDto> bars, double linkDiameterMm = 0.0)
    {
        int plotW = ViewW - PadL - PadR;
        int plotH = ViewH - PadT - PadB;
        double scale = SMath.Min(plotW, plotH) / diameterMm;
        double rPx = diameterMm / 2.0 * scale;
        double cx  = ViewW / 2.0;
        double cy  = PadT + (plotH) / 2.0;

        double barR    = bars.Count > 0 ? SMath.Max(bars[0].Diameter / 2.0 * scale * 0.9, 3.5) : 4.0;
        double totalAs = bars.Sum(b => b.Area);
        double ag      = SMath.PI * SMath.Pow(diameterMm / 2.0, 2);
        double rho     = ag > 0 ? totalAs / ag * 100 : 0;
        string barLabel = bars.Count > 0 ? bars[0].BarSizeLabel : "";
        string title    = $"D = {D(diameterMm, 0)} mm";
        string sub      = bars.Count > 0 ? $"{bars.Count}-{barLabel}  (ρ = {D(rho, 2)}%)" : "";

        var sb = new StringBuilder();
        sb.AppendLine($@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""{ViewW}"" height=""{ViewH}"" viewBox=""0 0 {ViewW} {ViewH}"" font-family=""Inter, Segoe UI, sans-serif"" font-size=""10"">");

        sb.AppendLine($@"  <text x=""{D(cx)}"" y=""14"" text-anchor=""middle"" font-weight=""bold"" font-size=""12"" fill=""#1A3A5C"">{title}</text>");
        if (!string.IsNullOrEmpty(sub))
            sb.AppendLine($@"  <text x=""{D(cx)}"" y=""27"" text-anchor=""middle"" font-size=""10"" fill=""#555"">{sub}</text>");

        sb.AppendLine($@"  <circle cx=""{D(cx)}"" cy=""{D(cy)}"" r=""{D(rPx)}"" fill=""#EEF4FB"" stroke=""#1A3A5C"" stroke-width=""2""/>");

        double hoopR = (diameterMm / 2.0 - coverMm - SMath.Max(linkDiameterMm, 0.0) / 2.0) * scale;
        if (hoopR > 0)
            sb.AppendLine($@"  <circle cx=""{D(cx)}"" cy=""{D(cy)}"" r=""{D(hoopR)}"" fill=""none"" stroke=""#2E6F9E"" stroke-width=""1.4""/>");

        double covR = (diameterMm / 2.0 - coverMm) * scale;
        if (covR > 0)
            sb.AppendLine($@"  <circle cx=""{D(cx)}"" cy=""{D(cy)}"" r=""{D(covR)}"" fill=""none"" stroke=""#5B8DB8"" stroke-width=""1"" stroke-dasharray=""5 3""/>");

        double axLen = rPx * 0.3;
        sb.AppendLine($@"  <line x1=""{D(cx)}"" y1=""{D(cy + axLen)}"" x2=""{D(cx)}"" y2=""{D(cy - axLen)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <line x1=""{D(cx - axLen)}"" y1=""{D(cy)}"" x2=""{D(cx + axLen)}"" y2=""{D(cy)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(cx + axLen + 3)}"" y=""{D(cy + 4)}"" fill=""#666"" font-size=""9"">X</text>");
        sb.AppendLine($@"  <text x=""{D(cx - 4)}"" y=""{D(cy - axLen - 3)}"" fill=""#666"" font-size=""9"">Y</text>");
        sb.AppendLine($@"  <circle cx=""{D(cx)}"" cy=""{D(cy)}"" r=""2.5"" fill=""#C0392B""/>");

        foreach (var bar in bars)
        {
            double bx = cx + bar.X * scale;
            double by = cy - bar.Y * scale;
            sb.AppendLine($@"  <circle cx=""{D(bx)}"" cy=""{D(by)}"" r=""{D(barR)}"" fill=""#1A3A5C"" stroke=""white"" stroke-width=""0.8""/>");
        }

        // Diameter dimension line
        double dimY = cy + rPx + 18;
        sb.AppendLine($@"  <line x1=""{D(cx - rPx)}"" y1=""{D(dimY)}"" x2=""{D(cx + rPx)}"" y2=""{D(dimY)}"" stroke=""#333"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(cx)}"" y=""{D(dimY + 11)}"" text-anchor=""middle"" fill=""#333"" font-size=""10"">D = {D(diameterMm, 0)} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public static string RenderIrregularSection(
        double coverMm,
        IReadOnlyList<RebarCoordinateDto> bars,
        IReadOnlyList<InsetPointDto> boundaryPoints)
    {
        if (boundaryPoints.Count < 3)
            return RenderRectangularSection(1.0, 1.0, coverMm, bars);

        double minX = boundaryPoints.Min(p => p.X);
        double maxX = boundaryPoints.Max(p => p.X);
        double minY = boundaryPoints.Min(p => p.Y);
        double maxY = boundaryPoints.Max(p => p.Y);
        double widthMm = SMath.Max(maxX - minX, 1.0);
        double heightMm = SMath.Max(maxY - minY, 1.0);

        int plotW = ViewW - PadL - PadR;
        int plotH = ViewH - PadT - PadB;
        double scale = SMath.Min(plotW / widthMm, plotH / heightMm);
        double sw = widthMm * scale;
        double sh = heightMm * scale;
        double ox = PadL + (plotW - sw) / 2.0;
        double oy = PadT + (plotH - sh) / 2.0;

        double ToSvgX(double x) => ox + (x - minX) * scale;
        double ToSvgY(double y) => oy + (maxY - y) * scale;

        double axisX = ToSvgX(0.0);
        double axisY = ToSvgY(0.0);
        if (axisX < ox || axisX > ox + sw || axisY < oy || axisY > oy + sh)
        {
            axisX = ox + sw / 2.0;
            axisY = oy + sh / 2.0;
        }

        double barR = bars.Count > 0 ? SMath.Max(bars[0].Diameter / 2.0 * scale * 0.9, 3.5) : 4.0;
        double totalAs = bars.Sum(b => b.Area);
        double ag = PolygonArea(boundaryPoints);
        double rho = ag > 0 ? totalAs / ag * 100 : 0;
        string barLabel = bars.Count > 0 ? bars[0].BarSizeLabel : "";
        string title = $"{D(widthMm, 0)} x {D(heightMm, 0)} mm";
        string sub = bars.Count > 0 ? $"{bars.Count}-{barLabel}  (rho = {D(rho, 2)}%)" : "";
        string polygon = string.Join(" ", boundaryPoints.Select(p => $"{D(ToSvgX(p.X))},{D(ToSvgY(p.Y))}"));

        var sb = new StringBuilder();
        sb.AppendLine($@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""{ViewW}"" height=""{ViewH}"" viewBox=""0 0 {ViewW} {ViewH}"" font-family=""Inter, Segoe UI, sans-serif"" font-size=""10"">");

        sb.AppendLine($@"  <text x=""{D(ox + sw / 2.0)}"" y=""14"" text-anchor=""middle"" font-weight=""bold"" font-size=""12"" fill=""#1A3A5C"">{title}</text>");
        if (!string.IsNullOrEmpty(sub))
            sb.AppendLine($@"  <text x=""{D(ox + sw / 2.0)}"" y=""27"" text-anchor=""middle"" font-size=""10"" fill=""#555"">{sub}</text>");

        sb.AppendLine($@"  <polygon points=""{polygon}"" fill=""#EEF4FB"" stroke=""#1A3A5C"" stroke-width=""2""/>");

        double axLen = SMath.Min(sw, sh) * 0.22;
        sb.AppendLine($@"  <line x1=""{D(axisX)}"" y1=""{D(axisY + axLen)}"" x2=""{D(axisX)}"" y2=""{D(axisY - axLen)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <line x1=""{D(axisX - axLen)}"" y1=""{D(axisY)}"" x2=""{D(axisX + axLen)}"" y2=""{D(axisY)}"" stroke=""#888"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(axisX + axLen + 3)}"" y=""{D(axisY + 4)}"" fill=""#666"" font-size=""9"">X</text>");
        sb.AppendLine($@"  <text x=""{D(axisX - 4)}"" y=""{D(axisY - axLen - 3)}"" fill=""#666"" font-size=""9"">Y</text>");
        sb.AppendLine($@"  <circle cx=""{D(axisX)}"" cy=""{D(axisY)}"" r=""2.5"" fill=""#C0392B""/>");

        foreach (var bar in bars)
        {
            double bx = ToSvgX(bar.X);
            double by = ToSvgY(bar.Y);
            sb.AppendLine($@"  <circle cx=""{D(bx)}"" cy=""{D(by)}"" r=""{D(barR)}"" fill=""#1A3A5C"" stroke=""white"" stroke-width=""0.8""/>");
        }

        double dimY = oy + sh + 20;
        sb.AppendLine($@"  <line x1=""{D(ox)}"" y1=""{D(dimY)}"" x2=""{D(ox + sw)}"" y2=""{D(dimY)}"" stroke=""#333"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(ox + sw / 2.0)}"" y=""{D(dimY + 11)}"" text-anchor=""middle"" fill=""#333"" font-size=""10"">b = {D(widthMm, 0)} mm</text>");

        double dimX = ox - 20;
        sb.AppendLine($@"  <line x1=""{D(dimX)}"" y1=""{D(oy)}"" x2=""{D(dimX)}"" y2=""{D(oy + sh)}"" stroke=""#333"" stroke-width=""1""/>");
        sb.AppendLine($@"  <text x=""{D(dimX - 3)}"" y=""{D(oy + sh / 2.0 + 4)}"" text-anchor=""middle"" fill=""#333"" font-size=""10"" transform=""rotate(-90 {D(dimX - 3)} {D(oy + sh / 2.0)})"">h = {D(heightMm, 0)} mm</text>");

        sb.AppendLine("</svg>");
        return sb.ToString();
    }

    public static string RenderSection(SectionShapeType shape,
        double widthMm, double heightMm, double diameterMm, double coverMm,
        IReadOnlyList<RebarCoordinateDto> bars,
        double linkDiameterMm = 0.0,
        int totalLegsX = 2,
        int totalLegsY = 2,
        IReadOnlyList<InsetPointDto>? irregularBoundaryPoints = null) => shape switch
    {
        SectionShapeType.Circular => RenderCircularSection(diameterMm, coverMm, bars, linkDiameterMm),
        SectionShapeType.Irregular when irregularBoundaryPoints is { Count: >= 3 }
            => RenderIrregularSection(coverMm, bars, irregularBoundaryPoints),
        _ => RenderRectangularSection(widthMm, heightMm, coverMm, bars, linkDiameterMm, totalLegsX, totalLegsY)
    };

    // ── Helpers ───────────────────────────────────────────────────────────────

    private sealed class ApproxEqualityComparer(double tolerance) : IEqualityComparer<double>
    {
        public bool Equals(double x, double y) => SMath.Abs(x - y) <= tolerance;
        public int GetHashCode(double obj) => SMath.Round(obj / tolerance).GetHashCode();
    }

    private static void DrawRectangularLinks(
        StringBuilder sb,
        IReadOnlyList<RebarCoordinateDto> bars,
        double scale,
        double cx,
        double cy,
        double ox,
        double oy,
        double sw,
        double sh,
        double coverMm,
        double linkDiameterMm,
        int totalLegsX,
        int totalLegsY)
    {
        double tieInsetPx = (coverMm + SMath.Max(linkDiameterMm, 0.0) / 2.0) * scale;
        double tieX = ox + tieInsetPx;
        double tieY = oy + tieInsetPx;
        double tieW = sw - 2.0 * tieInsetPx;
        double tieH = sh - 2.0 * tieInsetPx;
        if (tieW <= 0 || tieH <= 0)
            return;

        const string stroke = "#2E6F9E";
        sb.AppendLine($@"  <rect x=""{D(tieX)}"" y=""{D(tieY)}"" width=""{D(tieW)}"" height=""{D(tieH)}"" rx=""3"" ry=""3"" fill=""none"" stroke=""{stroke}"" stroke-width=""1.4""/>");

        if (bars.Count < 4)
            return;

        const double eps = 2.0;
        var xGroups = bars.Select(b => b.X).Distinct(new ApproxEqualityComparer(eps)).OrderBy(x => x).ToList();
        var yGroups = bars.Select(b => b.Y).Distinct(new ApproxEqualityComparer(eps)).OrderBy(y => y).ToList();

        int innerVerticalLegs = SMath.Max(0, totalLegsX - 2);
        foreach (double xMm in SelectInteriorGroups(xGroups, innerVerticalLegs))
        {
            double px = cx + xMm * scale;
            sb.AppendLine($@"  <line x1=""{D(px)}"" y1=""{D(tieY)}"" x2=""{D(px)}"" y2=""{D(tieY + tieH)}"" stroke=""{stroke}"" stroke-width=""1.2"" opacity=""0.9""/>");
        }

        int innerHorizontalLegs = SMath.Max(0, totalLegsY - 2);
        foreach (double yMm in SelectInteriorGroups(yGroups, innerHorizontalLegs))
        {
            double py = cy - yMm * scale;
            sb.AppendLine($@"  <line x1=""{D(tieX)}"" y1=""{D(py)}"" x2=""{D(tieX + tieW)}"" y2=""{D(py)}"" stroke=""{stroke}"" stroke-width=""1.2"" opacity=""0.9""/>");
        }
    }

    private static IEnumerable<double> SelectInteriorGroups(IReadOnlyList<double> groups, int count)
    {
        if (count <= 0 || groups.Count <= 2)
            yield break;

        var interior = groups.Skip(1).Take(groups.Count - 2).ToList();
        if (count >= interior.Count)
        {
            foreach (double value in interior)
                yield return value;
            yield break;
        }

        for (int i = 0; i < count; i++)
        {
            int index = (int)SMath.Round((i + 1.0) * (interior.Count + 1.0) / (count + 1.0) - 1.0);
            index = SMath.Clamp(index, 0, interior.Count - 1);
            yield return interior[index];
        }
    }

    private static void DrawAxes(StringBuilder sb, double cx, double cy, double len)
    {
        sb.AppendLine($@"  <line x1=""{D(cx - len)}"" y1=""{D(cy)}"" x2=""{D(cx + len)}"" y2=""{D(cy)}"" stroke=""#A0A0A0"" stroke-width=""1"" stroke-dasharray=""3 2""/>");
        sb.AppendLine($@"  <line x1=""{D(cx)}"" y1=""{D(cy - len)}"" x2=""{D(cx)}"" y2=""{D(cy + len)}"" stroke=""#A0A0A0"" stroke-width=""1"" stroke-dasharray=""3 2""/>");
        sb.AppendLine($@"  <text x=""{D(cx + len + 3)}"" y=""{D(cy + 4)}"" fill=""#666"" font-size=""9"">+X</text>");
        sb.AppendLine($@"  <text x=""{D(cx - 5)}"" y=""{D(cy - len - 3)}"" fill=""#666"" font-size=""9"">+Y</text>");
    }

    private static void AppendDimension(StringBuilder sb,
        double x1, double y1, double x2, double y2, string label, bool horizontal)
    {
        sb.AppendLine($@"  <line x1=""{D(x1)}"" y1=""{D(y1)}"" x2=""{D(x2)}"" y2=""{D(y2)}"" stroke=""#555"" stroke-width=""1""/>");
        double mx = (x1 + x2) / 2, my = (y1 + y2) / 2;
        string anchor = horizontal ? "middle" : "end";
        double tx = horizontal ? mx : mx - 3;
        double ty = horizontal ? my - 3 : my + 4;
        sb.AppendLine($@"  <text x=""{D(tx)}"" y=""{D(ty)}"" text-anchor=""{anchor}"" fill=""#333"" font-size=""9"">{label}</text>");
    }

    private static double PolygonArea(IReadOnlyList<InsetPointDto> points)
    {
        if (points.Count < 3)
            return 0.0;

        double sum = 0.0;
        for (int i = 0; i < points.Count; i++)
        {
            var a = points[i];
            var b = points[(i + 1) % points.Count];
            sum += a.X * b.Y - b.X * a.Y;
        }

        return SMath.Abs(sum) * 0.5;
    }
}
