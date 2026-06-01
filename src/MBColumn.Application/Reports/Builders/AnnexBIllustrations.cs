using System.Text;

namespace MBColumn.Application.Reports.Builders;

/// <summary>
/// Generates SVG diagrams illustrating the Fibre and Polygon section integration methods.
/// </summary>
internal static class AnnexBIllustrations
{
    // ── Layout constants ──────────────────────────────────────────────────────
    private const int W = 520, H = 310;

    // Section rectangle
    private const int Sx = 110, Sy = 40, Sw = 300, Sh = 220;

    // Neutral axis: screen coords of two endpoints (outside the section)
    private const double NaX1 = 70, NaY1 = 230, NaX2 = 430, NaY2 = 70;

    private static double YatNA(double x)
        => NaY1 + (NaY2 - NaY1) / (NaX2 - NaX1) * (x - NaX1);

    // ── Rebar positions (inside section) ─────────────────────────────────────
    // Section: x[110..410], y[40..260]. Cover 20px → rebar zone x[130..390], y[60..240].
    // Top/bottom: 6 bars, step 52. Left/right interior: 3 bars, step 45.
    private static readonly (double x, double y)[] Rebars =
    [
        (130, 60), (182, 60), (234, 60), (286, 60), (338, 60), (390, 60),
        (390, 105), (390, 150), (390, 195),
        (390, 240), (338, 240), (286, 240), (234, 240), (182, 240), (130, 240),
        (130, 195), (130, 150), (130, 105),
    ];

    // ── Public API ────────────────────────────────────────────────────────────

    internal static string FibreMethodSvg()
    {
        const int fs = 20; // fibre size
        var sb = StartSvg();

        // Tension zone background
        ClipToSection(sb, () =>
        {
            sb.Append($"<rect x='{Sx}' y='{Sy}' width='{Sw}' height='{Sh}' fill='#F9FAFB'/>");
        });

        // Fibre grid
        for (int gx = Sx; gx < Sx + Sw; gx += fs)
        {
            for (int gy = Sy; gy < Sy + Sh; gy += fs)
            {
                double cx = gx + fs / 2.0, cy = gy + fs / 2.0;
                bool comp = cy < YatNA(cx);

                // skip if outside section
                if (cx < Sx || cx > Sx + Sw || cy < Sy || cy > Sy + Sh) continue;

                double strain = comp ? (YatNA(cx) - cy) / (YatNA(Sx) - Sy) : 0;
                strain = Math.Clamp(strain, 0, 1);

                string fill, stroke;
                if (comp)
                {
                    int r = (int)(147 + (1 - strain) * (59 - 147));
                    int g = (int)(197 + (1 - strain) * (130 - 197));
                    int b = (int)(253 + (1 - strain) * (246 - 253));
                    fill = $"rgb({r},{g},{b})";
                    stroke = "#3B82F6";
                }
                else
                {
                    fill = "#E5E7EB";
                    stroke = "#D1D5DB";
                }
                sb.Append($"<rect x='{gx + 1}' y='{gy + 1}' width='{fs - 2}' height='{fs - 2}' fill='{fill}' stroke='{stroke}' stroke-width='0.4'/>");
            }
        }

        // Rebar circles
        foreach (var (rx, ry) in Rebars)
            sb.Append($"<circle cx='{rx}' cy='{ry}' r='6' fill='#6B7280' stroke='#374151' stroke-width='1.2'/>");

        // Section outline
        sb.Append($"<rect x='{Sx}' y='{Sy}' width='{Sw}' height='{Sh}' fill='none' stroke='#111827' stroke-width='2.5'/>");

        // Neutral axis
        DrawNA(sb);

        // Compression zone bracket + label
        double naAtSx = YatNA(Sx);
        sb.Append($"<line x1='{Sx - 16}' y1='{Sy}' x2='{Sx - 16}' y2='{naAtSx}' stroke='#1E40AF' stroke-width='1.5' marker-start='url(#arrowUp)' marker-end='url(#arrowDown)'/>");
        RotText(sb, "c  (NA depth)", Sx - 28, (Sy + naAtSx) / 2, -90, "#1E40AF", 10);

        // Labels
        Label(sb, "Compression fibres", 245, 95, "#1E40AF");
        Label(sb, "(parabolic stress gradient)", 245, 108, "#6B7280", 8);
        Label(sb, "Tension zone  (ignored)", 200, 215, "#9CA3AF");
        Label(sb, "Rebar  Asi", 390, 155, "#374151", 9.5);

        // Legend row
        int lx = Sx, ly = H - 30;
        sb.Append($"<rect x='{lx}' y='{ly}' width='13' height='13' fill='#93C5FD' stroke='#3B82F6' stroke-width='0.8'/>");
        Label(sb, "Compression fibre", lx + 18, ly + 10, "#374151", 9);
        sb.Append($"<rect x='{lx + 155}' y='{ly}' width='13' height='13' fill='#E5E7EB' stroke='#D1D5DB' stroke-width='0.8'/>");
        Label(sb, "Tension fibre (ignored)", lx + 173, ly + 10, "#374151", 9);
        sb.Append($"<line x1='{lx + 355}' y1='{ly + 6}' x2='{lx + 375}' y2='{ly + 6}' stroke='#DC2626' stroke-width='2' stroke-dasharray='6,3'/>");
        Label(sb, "Neutral axis", lx + 380, ly + 10, "#DC2626", 9);

        EndSvg(sb);
        return sb.ToString();
    }

    internal static string PolygonMethodSvg()
    {
        var sb = StartSvg();

        // Compute compression polygon vertices (section clipped above NA)
        // Section corners: TL(Sx,Sy) TR(Sx+Sw,Sy) BR(Sx+Sw,Sy+Sh) BL(Sx,Sy+Sh)
        // NA enters left edge at (Sx, YatNA(Sx)) and exits right edge at (Sx+Sw, YatNA(Sx+Sw))
        double naLeft  = YatNA(Sx);
        double naRight = YatNA(Sx + Sw);

        string compPoly  = $"{Sx},{Sy} {Sx + Sw},{Sy} {Sx + Sw},{naRight} {Sx},{naLeft}";
        string tensPoly  = $"{Sx},{naLeft} {Sx + Sw},{naRight} {Sx + Sw},{Sy + Sh} {Sx},{Sy + Sh}";

        // Tension background
        sb.Append($"<polygon points='{tensPoly}' fill='#F9FAFB'/>");

        // Compression polygon — filled
        sb.Append($"<polygon points='{compPoly}' fill='#BFDBFE' stroke='none'/>");

        // Hatch lines inside compression polygon to show it's exact
        for (int hy = (int)Sy + 14; hy < (int)Math.Min(naLeft, naRight); hy += 18)
            sb.Append($"<line x1='{Sx}' y1='{hy}' x2='{Sx + Sw}' y2='{hy}' stroke='#93C5FD' stroke-width='0.8'/>");

        // Polygon boundary highlight
        sb.Append($"<polygon points='{compPoly}' fill='none' stroke='#1D4ED8' stroke-width='2'/>");

        // Rebar circles
        foreach (var (rx, ry) in Rebars)
            sb.Append($"<circle cx='{rx}' cy='{ry}' r='6' fill='#6B7280' stroke='#374151' stroke-width='1.2'/>");

        // Section outline
        sb.Append($"<rect x='{Sx}' y='{Sy}' width='{Sw}' height='{Sh}' fill='none' stroke='#111827' stroke-width='2.5'/>");

        // Neutral axis
        DrawNA(sb);

        // Polygon vertices markers
        double[][] verts =
        [
            [(double)Sx,        (double)Sy],
            [(double)(Sx + Sw), (double)Sy],
            [(double)(Sx + Sw), naRight],
            [(double)Sx,        naLeft],
        ];
        string[] vLabels = ["P1", "P2", "P3", "P4"];
        double[] vOffX   = [-16, 6, 8, -18];
        double[] vOffY   = [-6, -6, 8, 8];
        for (int i = 0; i < verts.Length; i++)
        {
            sb.Append($"<circle cx='{verts[i][0]}' cy='{verts[i][1]}' r='4.5' fill='#1D4ED8' stroke='white' stroke-width='1'/>");
            sb.Append($"<text x='{verts[i][0] + vOffX[i]}' y='{verts[i][1] + vOffY[i]}' font-size='9.5' fill='#1E40AF' font-family='Segoe UI,sans-serif' font-weight='600'>{vLabels[i]}</text>");
        }

        // Strip annotation (one horizontal strip in the middle of compression zone)
        double stripY = Sy + (naLeft - Sy) * 0.55;
        double stripLeft  = Sx;
        double stripRight = Sx + Sw;
        sb.Append($"<rect x='{stripLeft}' y='{stripY - 6}' width='{stripRight - stripLeft}' height='12' fill='#3B82F6' fill-opacity='0.25' stroke='#3B82F6' stroke-width='1.2' stroke-dasharray='4,2'/>");
        Label(sb, "horizontal strip  b(y)·Δy", (stripLeft + stripRight) / 2 - 50, stripY + 3, "#1D4ED8", 8.5);

        // c arrow on left
        sb.Append($"<line x1='{Sx - 16}' y1='{Sy}' x2='{Sx - 16}' y2='{naLeft}' stroke='#1E40AF' stroke-width='1.5'/>");
        sb.Append($"<line x1='{Sx - 21}' y1='{Sy}' x2='{Sx - 11}' y2='{Sy}' stroke='#1E40AF' stroke-width='1.5'/>");
        sb.Append($"<line x1='{Sx - 21}' y1='{naLeft}' x2='{Sx - 11}' y2='{naLeft}' stroke='#1E40AF' stroke-width='1.5'/>");
        RotText(sb, "c  (NA depth)", Sx - 30, (Sy + naLeft) / 2, -90, "#1E40AF", 10);

        // Labels
        Label(sb, "Exact compression polygon  Pc", 175, 80, "#1D4ED8");
        Label(sb, "(Sutherland-Hodgman clipping)", 175, 93, "#6B7280", 8);
        Label(sb, "Tension zone  (ignored)", 210, 218, "#9CA3AF");

        // Legend row
        int lx = Sx, ly = H - 30;
        sb.Append($"<rect x='{lx}' y='{ly}' width='13' height='13' fill='#BFDBFE' stroke='#1D4ED8' stroke-width='1'/>");
        Label(sb, "Compression polygon Pc", lx + 18, ly + 10, "#374151", 9);
        sb.Append($"<circle cx='{lx + 185}' cy='{ly + 6}' r='4.5' fill='#1D4ED8' stroke='white' stroke-width='1'/>");
        Label(sb, "Polygon vertex", lx + 195, ly + 10, "#374151", 9);
        sb.Append($"<line x1='{lx + 310}' y1='{ly + 6}' x2='{lx + 330}' y2='{ly + 6}' stroke='#DC2626' stroke-width='2' stroke-dasharray='6,3'/>");
        Label(sb, "Neutral axis", lx + 335, ly + 10, "#DC2626", 9);

        EndSvg(sb);
        return sb.ToString();
    }

    // ── Helpers ───────────────────────────────────────────────────────────────

    private static StringBuilder StartSvg()
    {
        var sb = new StringBuilder();
        sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{W}' height='{H}' viewBox='0 0 {W} {H}'>");
        sb.Append("<defs>");
        sb.Append("<marker id='arrowUp' markerWidth='6' markerHeight='6' refX='3' refY='6' orient='auto'>");
        sb.Append("<path d='M3,6 L0,0 L6,0 Z' fill='#1E40AF'/></marker>");
        sb.Append("<marker id='arrowDown' markerWidth='6' markerHeight='6' refX='3' refY='0' orient='auto'>");
        sb.Append("<path d='M3,0 L0,6 L6,6 Z' fill='#1E40AF'/></marker>");
        sb.Append("</defs>");
        sb.Append("<rect width='100%' height='100%' fill='white'/>");
        return sb;
    }

    private static void EndSvg(StringBuilder sb) => sb.Append("</svg>");

    private static void DrawNA(StringBuilder sb)
    {
        sb.Append($"<line x1='{NaX1}' y1='{NaY1}' x2='{NaX2}' y2='{NaY2}' stroke='#DC2626' stroke-width='2.2' stroke-dasharray='10,5'/>");
        sb.Append($"<text x='{NaX2 + 5}' y='{NaY2 + 8}' font-size='11' fill='#DC2626' font-family='Segoe UI,sans-serif' font-weight='600'>NA</text>");
    }

    private static void Label(StringBuilder sb, string text, double x, double y, string color, double size = 10)
        => sb.Append($"<text x='{x:F0}' y='{y:F0}' font-size='{size}' fill='{color}' font-family='Segoe UI,sans-serif'>{text}</text>");

    private static void RotText(StringBuilder sb, string text, double x, double y, double angle, string color, double size)
        => sb.Append($"<text transform='translate({x:F0},{y:F0}) rotate({angle})' text-anchor='middle' font-size='{size}' fill='{color}' font-family='Segoe UI,sans-serif'>{text}</text>");

    private static void ClipToSection(StringBuilder sb, Action draw)
    {
        sb.Append($"<clipPath id='secClip'><rect x='{Sx}' y='{Sy}' width='{Sw}' height='{Sh}'/></clipPath>");
        sb.Append("<g clip-path='url(#secClip)'>");
        draw();
        sb.Append("</g>");
    }
}
