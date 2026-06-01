using System.Text;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

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
        var (nx, ny) = NaCompressionNormal();
        var (ex, ey, cDepth) = ExtremeCompressionPoint();
        var (px, py) = ProjectToNA(ex, ey);
        const double sampleX = 230;
        const double sampleY = 110;
        var (samplePx, samplePy) = ProjectToNA(sampleX, sampleY);

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
                double d = DistanceToNA(cx, cy);
                bool comp = d >= 0 && d <= cDepth;

                // skip if outside section
                if (cx < Sx || cx > Sx + Sw || cy < Sy || cy > Sy + Sh) continue;

                double strain = comp ? d / cDepth : 0;
                strain = Math.Clamp(strain, 0, 1);

                string fill, stroke;
                if (comp)
                {
                    fill = BlueGradient(strain);
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

        // Local axes and centroid reference
        double ox = Sx + Sw / 2.0, oy = Sy + Sh / 2.0;
        sb.Append($"<circle cx='{ox:F1}' cy='{oy:F1}' r='3.2' fill='#111827'/>");
        sb.Append($"<line x1='{ox:F1}' y1='{oy:F1}' x2='{ox + 34:F1}' y2='{oy:F1}' stroke='#374151' stroke-width='1.1' marker-end='url(#arrowGray)'/>");
        sb.Append($"<line x1='{ox:F1}' y1='{oy:F1}' x2='{ox:F1}' y2='{oy - 34:F1}' stroke='#374151' stroke-width='1.1' marker-end='url(#arrowGray)'/>");
        Label(sb, "x", ox + 39, oy + 4, "#374151", 8.5);
        Label(sb, "y", ox - 3, oy - 40, "#374151", 8.5);

        // Neutral axis
        DrawNA(sb);

        // Normal direction, compression depth c, and one signed fibre distance.
        double naMidX = (NaX1 + NaX2) / 2.0;
        double naMidY = (NaY1 + NaY2) / 2.0;
        sb.Append($"<line x1='{naMidX:F1}' y1='{naMidY:F1}' x2='{naMidX + nx * 52:F1}' y2='{naMidY + ny * 52:F1}' stroke='#1E40AF' stroke-width='1.8' marker-end='url(#arrowBlue)'/>");
        Label(sb, "normal to NA", naMidX + nx * 56 - 34, naMidY + ny * 56 - 4, "#1E40AF", 8.5);

        sb.Append($"<line x1='{px:F1}' y1='{py:F1}' x2='{ex:F1}' y2='{ey:F1}' stroke='#1E40AF' stroke-width='1.8' marker-start='url(#arrowBlue)' marker-end='url(#arrowBlue)'/>");
        RotText(sb, "c", (px + ex) / 2 - 8, (py + ey) / 2 + 4, -66, "#1E40AF", 11);
        sb.Append($"<circle cx='{ex:F1}' cy='{ey:F1}' r='4.5' fill='#1E40AF' stroke='white' stroke-width='1'/>");
        Label(sb, "extreme compression fibre", ex + 8, ey + 9, "#1E40AF", 8.5);

        sb.Append($"<circle cx='{sampleX:F1}' cy='{sampleY:F1}' r='4' fill='#0F766E' stroke='white' stroke-width='1'/>");
        sb.Append($"<line x1='{sampleX:F1}' y1='{sampleY:F1}' x2='{samplePx:F1}' y2='{samplePy:F1}' stroke='#0F766E' stroke-width='1.5' stroke-dasharray='4,3'/>");
        Label(sb, "d_i", (sampleX + samplePx) / 2 + 4, (sampleY + samplePy) / 2 + 3, "#0F766E", 10);

        // Labels
        Label(sb, "Compression fibres", 246, 92, "#1E40AF");
        Label(sb, "strain increases with d_i", 246, 105, "#6B7280", 8);
        Label(sb, "Concrete tension neglected", 192, 218, "#9CA3AF");
        Label(sb, "Rebar  Asi", 390, 155, "#374151", 9.5);

        // Legend row
        int lx = Sx, ly = H - 30;
        sb.Append($"<rect x='{lx}' y='{ly}' width='13' height='13' fill='#93C5FD' stroke='#3B82F6' stroke-width='0.8'/>");
        Label(sb, "Compression fibre", lx + 18, ly + 10, "#374151", 9);
        sb.Append($"<rect x='{lx + 155}' y='{ly}' width='13' height='13' fill='#E5E7EB' stroke='#D1D5DB' stroke-width='0.8'/>");
        Label(sb, "Tensile concrete = 0", lx + 173, ly + 10, "#374151", 9);
        sb.Append($"<line x1='{lx + 355}' y1='{ly + 6}' x2='{lx + 375}' y2='{ly + 6}' stroke='#DC2626' stroke-width='2' stroke-dasharray='6,3'/>");
        Label(sb, "Neutral axis", lx + 380, ly + 10, "#DC2626", 9);

        EndSvg(sb);
        return sb.ToString();
    }

    internal static string GoverningFibreMethodSvg(CalculationResultDto result)
    {
        if (!double.IsFinite(result.GoverningThetaDegrees)
            || !double.IsFinite(result.GoverningNeutralAxisDepth)
            || result.GoverningNeutralAxisDepth <= 1e-6)
        {
            return FibreMethodSvg();
        }

        var geometry = BuildGeometry(result);
        if (geometry.Boundary.Count < 3)
            return FibreMethodSvg();

        const int canvasW = 1120;
        const int canvasH = 760;
        const double sectionLeft = 270;
        const double sectionTop = 135;
        const double sectionW = 410;
        const double sectionH = 455;

        double theta = result.GoverningThetaDegrees * Math.PI / 180.0;
        double nx = Math.Cos(theta);
        double ny = Math.Sin(theta);
        double tx = -ny;
        double ty = nx;
        double c = result.GoverningNeutralAxisDepth;
        double maxProjection = geometry.Boundary.Max(p => Project(p, nx, ny));
        double minProjection = geometry.Boundary.Min(p => Project(p, nx, ny));
        double sectionDepth = Math.Max(maxProjection - minProjection, 1e-6);
        double neutralAxisOffset = maxProjection - c;
        var extreme = geometry.Boundary.MaxBy(p => Project(p, nx, ny));
        var naProjection = new Point2(extreme.X - c * nx, extreme.Y - c * ny);
        string ultimateStrainLabel = UltimateStrainLabel(result);
        var frame = BuildFrameForBox(
            geometry,
            sectionLeft,
            sectionTop,
            sectionW,
            sectionH,
            [
                extreme,
                naProjection,
                new Point2(neutralAxisOffset * nx + tx * sectionDepth * 0.85, neutralAxisOffset * ny + ty * sectionDepth * 0.85),
                new Point2(neutralAxisOffset * nx - tx * sectionDepth * 0.85, neutralAxisOffset * ny - ty * sectionDepth * 0.85)
            ]);

        var sb = StartSvg(canvasW, canvasH);
        sb.Append("<style>");
        sb.Append(".t{font-family:Segoe UI,Arial,sans-serif;fill:#111827}.small{font-size:17px}.micro{font-size:14px}.bold{font-weight:700}.italic{font-style:italic}");
        sb.Append("</style>");

        sb.Append("<text x='80' y='64' class='t bold' font-size='24'>Governing fibre strain state</text>");
        sb.Append($"<text x='80' y='94' class='t small'>θ = {result.GoverningThetaDegrees:0.#}°    c = {result.GoverningNeutralAxisDepth:0.#} mm    (d_i &gt; 0 toward compression)</text>");

        // Layer 1: concrete fibre strain field from the real section boundary.
        int gridX = FibreGridX(result);
        int gridY = FibreGridY(result);
        double dx = (geometry.MaxX - geometry.MinX) / gridX;
        double dy = (geometry.MaxY - geometry.MinY) / gridY;
        Point2? sampleFibre = null;
        double sampleScore = double.PositiveInfinity;
        double sampleTarget = Math.Min(c * 0.45, sectionDepth * 0.55);
        if (dx > 1e-9 && dy > 1e-9)
        {
            for (int ix = 0; ix < gridX; ix++)
            {
                for (int iy = 0; iy < gridY; iy++)
                {
                    var centre = new Point2(geometry.MinX + (ix + 0.5) * dx, geometry.MinY + (iy + 0.5) * dy);
                    if (!geometry.Contains(centre))
                        continue;

                    double d = Project(centre, nx, ny) - neutralAxisOffset;
                    bool compression = d >= 0.0;
                    double strain = Math.Clamp(d / c, 0.0, 1.0);
                    string fill;
                    string stroke;
                    if (compression)
                    {
                        fill = GrayGradient(strain);
                        stroke = "#9CA3AF";
                        double score = Math.Abs(d - sampleTarget) + 0.10 * Math.Abs(Project(centre, -ny, nx));
                        if (score < sampleScore)
                        {
                            sampleScore = score;
                            sampleFibre = centre;
                        }
                    }
                    else
                    {
                        fill = "#FFFFFF";
                        stroke = "#D1D5DB";
                    }

                    var a = frame.ToScreen(new Point2(centre.X - dx * 0.45, centre.Y - dy * 0.45));
                    var b = frame.ToScreen(new Point2(centre.X + dx * 0.45, centre.Y + dy * 0.45));
                    double x = Math.Min(a.X, b.X);
                    double y = Math.Min(a.Y, b.Y);
                    double w = Math.Abs(b.X - a.X);
                    double h = Math.Abs(b.Y - a.Y);
                    sb.Append($"<rect x='{x:F1}' y='{y:F1}' width='{w:F1}' height='{h:F1}' fill='{fill}' stroke='{stroke}' stroke-width='0.35'/>");
                }
            }
        }

        // Layer 2: section geometry and reinforcement.
        DrawRealSectionBoundary(sb, geometry, frame);

        foreach (var bar in result.RebarCoordinates)
        {
            var p = frame.ToScreen(new Point2(bar.X, bar.Y));
            double r = Math.Clamp(bar.Diameter * frame.Scale / 2.0, 3.5, 8.0);
            double d = bar.X * nx + bar.Y * ny - neutralAxisOffset;
            string stroke = d >= 0.0 ? "#111827" : "#4B5563";
            sb.Append($"<circle cx='{p.X:F1}' cy='{p.Y:F1}' r='{r:F1}' fill='#4B5563' stroke='{stroke}' stroke-width='1.6'/>");
            sb.Append($"<circle cx='{p.X - r * 0.28:F1}' cy='{p.Y - r * 0.30:F1}' r='{Math.Max(r * 0.18, 1.0):F1}' fill='#FFFFFF' fill-opacity='0.25'/>");
        }

        // Layer 3: annotations and governing strain geometry.
        DrawNeutralAxisManual(sb, frame, neutralAxisOffset, nx, ny, sectionDepth);
        DrawRealAxes(sb, frame);

        var ex = frame.ToScreen(extreme);
        var na = frame.ToScreen(naProjection);
        if (IsDrawable(ex) && IsDrawable(na))
        {
            DrawDimensionLine(sb, na, ex, "c", "#111827", 20);
            sb.Append($"<circle cx='{ex.X:F1}' cy='{ex.Y:F1}' r='7.2' fill='#374151' stroke='#111827' stroke-width='1.4'/>");
            sb.Append($"<line x1='{ex.X + 4:F1}' y1='{ex.Y - 4:F1}' x2='{ex.X + 34:F1}' y2='{ex.Y - 48:F1}' stroke='#111827' stroke-width='1.1'/>");
            sb.Append($"<text x='{ex.X + 40:F1}' y='{ex.Y - 50:F1}' class='t micro'>Extreme compression fibre</text>");
            sb.Append($"<text x='{ex.X + 40:F1}' y='{ex.Y - 33:F1}' class='t micro'>{ultimateStrainLabel}</text>");
        }

        var naCentre = new Point2(neutralAxisOffset * nx, neutralAxisOffset * ny);
        var normalStart = frame.ToScreen(new Point2(naCentre.X + tx * sectionDepth * 0.14, naCentre.Y + ty * sectionDepth * 0.14));
        var normalEnd = frame.ToScreen(new Point2(naCentre.X + tx * sectionDepth * 0.14 + sectionDepth * 0.12 * nx, naCentre.Y + ty * sectionDepth * 0.14 + sectionDepth * 0.12 * ny));
        sb.Append($"<line x1='{normalStart.X:F1}' y1='{normalStart.Y:F1}' x2='{normalEnd.X:F1}' y2='{normalEnd.Y:F1}' stroke='#111827' stroke-width='1.1' marker-end='url(#arrowGray)'/>");
        sb.Append($"<text x='{normalEnd.X + 6:F1}' y='{normalEnd.Y + 4:F1}' class='t micro'>n̂</text>");

        if (sampleFibre is Point2 sample)
        {
            DrawSignedDistance(sb, frame, sample, neutralAxisOffset, nx, ny);
        }

        DrawGrayscaleLegend(sb, 70, 210, ultimateStrainLabel);
        DrawStrainDistributionPanel(sb, 790, 120, ultimateStrainLabel);
        DrawDefinitionsBox(sb, 775, 455, ultimateStrainLabel);
        DrawFigureLegend(sb, 390, 620);

        EndSvg(sb);
        return sb.ToString();
    }

    internal static string PolygonMethodSvg()
    {
        var sb = StartSvg();
        var (ex, ey, _) = ExtremeCompressionPoint();
        var (px, py) = ProjectToNA(ex, ey);

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

        // c is measured perpendicular to the neutral axis.
        sb.Append($"<line x1='{px:F1}' y1='{py:F1}' x2='{ex:F1}' y2='{ey:F1}' stroke='#1E40AF' stroke-width='1.8' marker-start='url(#arrowBlue)' marker-end='url(#arrowBlue)'/>");
        RotText(sb, "c", (px + ex) / 2 - 8, (py + ey) / 2 + 4, -66, "#1E40AF", 11);
        sb.Append($"<circle cx='{ex:F1}' cy='{ey:F1}' r='4.5' fill='#1E40AF' stroke='white' stroke-width='1'/>");

        // Labels
        Label(sb, "Exact compression polygon  Pc", 175, 80, "#1D4ED8");
        Label(sb, "(Sutherland-Hodgman clipping)", 175, 93, "#6B7280", 8);
        Label(sb, "Concrete tension neglected", 190, 218, "#9CA3AF");

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

    private static StringBuilder StartSvg() => StartSvg(W, H);

    private static StringBuilder StartSvg(int width, int height)
    {
        var sb = new StringBuilder();
        sb.Append($"<svg xmlns='http://www.w3.org/2000/svg' width='{width}' height='{height}' viewBox='0 0 {width} {height}'>");
        sb.Append("<defs>");
        sb.Append("<marker id='arrowUp' markerWidth='6' markerHeight='6' refX='3' refY='6' orient='auto'>");
        sb.Append("<path d='M3,6 L0,0 L6,0 Z' fill='#1E40AF'/></marker>");
        sb.Append("<marker id='arrowDown' markerWidth='6' markerHeight='6' refX='3' refY='0' orient='auto'>");
        sb.Append("<path d='M3,0 L0,6 L6,6 Z' fill='#1E40AF'/></marker>");
        sb.Append("<marker id='arrowBlue' markerWidth='7' markerHeight='7' refX='3.5' refY='3.5' orient='auto'>");
        sb.Append("<path d='M0,0 L7,3.5 L0,7 Z' fill='#1E40AF'/></marker>");
        sb.Append("<marker id='arrowGray' markerWidth='6' markerHeight='6' refX='5.5' refY='3' orient='auto'>");
        sb.Append("<path d='M0,0 L6,3 L0,6 Z' fill='#374151'/></marker>");
        sb.Append("</defs>");
        sb.Append("<rect width='100%' height='100%' fill='white'/>");
        return sb;
    }

    private static void EndSvg(StringBuilder sb) => sb.Append("</svg>");

    private static void DrawNA(StringBuilder sb)
    {
        sb.Append($"<line x1='{NaX1}' y1='{NaY1}' x2='{NaX2}' y2='{NaY2}' stroke='#DC2626' stroke-width='2.2' stroke-dasharray='10,5'/>");
        sb.Append($"<text x='{NaX2 + 5}' y='{NaY2 + 8}' font-size='11' fill='#DC2626' font-family='Segoe UI,sans-serif' font-weight='600'>NA  theta</text>");
    }

    private static RealSectionGeometry BuildGeometry(CalculationResultDto result)
    {
        if (result.SectionShape == SectionShapeType.Circular && result.DiameterMm > 0)
        {
            double radius = result.DiameterMm / 2.0;
            int segments = Math.Clamp(result.CirclePolygonSegmentCount > 0 ? result.CirclePolygonSegmentCount : 96, 48, 160);
            var boundary = Enumerable.Range(0, segments)
                .Select(i =>
                {
                    double a = 2.0 * Math.PI * i / segments;
                    return new Point2(radius * Math.Cos(a), radius * Math.Sin(a));
                })
                .ToArray();
            return new RealSectionGeometry(boundary, p => p.X * p.X + p.Y * p.Y <= radius * radius + 1e-6);
        }

        if (result.SectionShape == SectionShapeType.Irregular && result.IrregularSectionBoundaryPoints.Count >= 3)
        {
            var boundary = result.IrregularSectionBoundaryPoints
                .Select(p => new Point2(p.X, p.Y))
                .ToArray();
            return new RealSectionGeometry(boundary, p => PointInPolygon(p, boundary));
        }

        double hx = Math.Max(result.SectionWidthMm, 1.0) / 2.0;
        double hy = Math.Max(result.SectionHeightMm, 1.0) / 2.0;
        Point2[] rect =
        [
            new(-hx, -hy),
            new(hx, -hy),
            new(hx, hy),
            new(-hx, hy),
        ];
        return new RealSectionGeometry(rect, p => p.X >= -hx && p.X <= hx && p.Y >= -hy && p.Y <= hy);
    }

    private static SvgFrame BuildFrame(RealSectionGeometry geometry, double neutralAxisOffset, double nx, double ny, double c)
    {
        double tx = -ny;
        double ty = nx;
        double halfLine = Math.Max(geometry.Width, geometry.Height) * 0.9;
        var naCentre = new Point2(neutralAxisOffset * nx, neutralAxisOffset * ny);
        var cEnd = new Point2((neutralAxisOffset + c) * nx, (neutralAxisOffset + c) * ny);
        var points = geometry.Boundary
            .Concat([
                cEnd,
                new(naCentre.X + tx * halfLine, naCentre.Y + ty * halfLine),
                new(naCentre.X - tx * halfLine, naCentre.Y - ty * halfLine),
            ])
            .ToArray();

        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);
        double width = Math.Max(maxX - minX, 1.0);
        double height = Math.Max(maxY - minY, 1.0);
        const double left = 70, top = 48, drawW = 380, drawH = 205;
        double scale = Math.Min(drawW / width, drawH / height);
        double cx = (minX + maxX) / 2.0;
        double cy = (minY + maxY) / 2.0;
        return new SvgFrame(scale, left + drawW / 2.0, top + drawH / 2.0, cx, cy);
    }

    private static SvgFrame BuildFrameForBox(
        RealSectionGeometry geometry,
        double left,
        double top,
        double drawW,
        double drawH,
        IReadOnlyList<Point2> extraPoints)
    {
        var points = geometry.Boundary.Concat(extraPoints).ToArray();
        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);
        double width = Math.Max(maxX - minX, 1.0);
        double height = Math.Max(maxY - minY, 1.0);
        double scale = Math.Min(drawW / width, drawH / height);
        double cx = (minX + maxX) / 2.0;
        double cy = (minY + maxY) / 2.0;
        return new SvgFrame(scale, left + drawW / 2.0, top + drawH / 2.0, cx, cy);
    }

    private static void DrawRealSectionBoundary(StringBuilder sb, RealSectionGeometry geometry, SvgFrame frame)
    {
        if (geometry.Boundary.Count == 0)
            return;

        string points = string.Join(" ", geometry.Boundary.Select(p =>
        {
            var s = frame.ToScreen(p);
            return $"{s.X:F1},{s.Y:F1}";
        }));
        sb.Append($"<polygon points='{points}' fill='none' stroke='#111827' stroke-width='1.55'/>");
    }

    private static void DrawRealNeutralAxis(StringBuilder sb, SvgFrame frame, double offset, double nx, double ny, string color)
    {
        double tx = -ny;
        double ty = nx;
        double halfLine = 10000.0;
        var centre = new Point2(offset * nx, offset * ny);
        var a = frame.ToScreen(new Point2(centre.X + tx * halfLine, centre.Y + ty * halfLine));
        var b = frame.ToScreen(new Point2(centre.X - tx * halfLine, centre.Y - ty * halfLine));
        sb.Append($"<line x1='{a.X:F1}' y1='{a.Y:F1}' x2='{b.X:F1}' y2='{b.Y:F1}' stroke='{color}' stroke-opacity='0.62' stroke-width='1.35' stroke-dasharray='8,5'/>");

        var mid = frame.ToScreen(centre);
        double labelX = Math.Clamp(mid.X + nx * 14.0, 32, W - 70);
        double labelY = Math.Clamp(mid.Y - ny * 14.0, 50, H - 52);
        double angle = Math.Atan2(b.Y - a.Y, b.X - a.X) * 180.0 / Math.PI;
        RotText(sb, "NA", labelX, labelY, angle, color, 9.2);
    }

    private static void DrawNeutralAxisManual(StringBuilder sb, SvgFrame frame, double offset, double nx, double ny, double sectionDepth)
    {
        double tx = -ny;
        double ty = nx;
        var centre = new Point2(offset * nx, offset * ny);
        double halfLine = sectionDepth * 0.95;
        var a = frame.ToScreen(new Point2(centre.X - tx * halfLine, centre.Y - ty * halfLine));
        var b = frame.ToScreen(new Point2(centre.X + tx * halfLine, centre.Y + ty * halfLine));
        sb.Append($"<line x1='{a.X:F1}' y1='{a.Y:F1}' x2='{b.X:F1}' y2='{b.Y:F1}' stroke='#111827' stroke-width='1.35' stroke-dasharray='8,7'/>");
        double angle = Math.Atan2(b.Y - a.Y, b.X - a.X) * 180.0 / Math.PI;
        RotText(sb, "NA", b.X + 14, b.Y + 12, angle, "#111827", 16);
    }

    private static void DrawRealAxes(StringBuilder sb, SvgFrame frame)
    {
        var origin = frame.ToScreen(new Point2(0, 0));
        if (!IsDrawable(origin))
            return;

        sb.Append($"<circle cx='{origin.X:F1}' cy='{origin.Y:F1}' r='3.2' fill='#111827'/>");
        sb.Append($"<line x1='{origin.X:F1}' y1='{origin.Y:F1}' x2='{origin.X + 42:F1}' y2='{origin.Y:F1}' stroke='#374151' stroke-width='1.25' marker-end='url(#arrowGray)'/>");
        sb.Append($"<line x1='{origin.X:F1}' y1='{origin.Y:F1}' x2='{origin.X:F1}' y2='{origin.Y - 42:F1}' stroke='#374151' stroke-width='1.25' marker-end='url(#arrowGray)'/>");
        Label(sb, "x", origin.X + 47, origin.Y + 4, "#374151", 8.5);
        Label(sb, "y", origin.X - 3, origin.Y - 48, "#374151", 8.5);
        Label(sb, "section axes", origin.X + 10, origin.Y - 9, "#6B7280", 7.8);
    }

    private static int FibreGridX(CalculationResultDto result)
    {
        if (result.SectionShape == SectionShapeType.Circular)
        {
            int n = (int)Math.Round(Math.Sqrt(Math.Max(1, result.CircularRadialFiberCount * result.CircularAngularFiberCount)));
            return Math.Clamp(n, 24, 58);
        }

        return Math.Clamp(result.ConcreteFiberCountX > 0 ? result.ConcreteFiberCountX : 36, 18, 56);
    }

    private static int FibreGridY(CalculationResultDto result)
    {
        if (result.SectionShape == SectionShapeType.Circular)
        {
            int n = (int)Math.Round(Math.Sqrt(Math.Max(1, result.CircularRadialFiberCount * result.CircularAngularFiberCount)));
            return Math.Clamp(n, 24, 58);
        }

        return Math.Clamp(result.ConcreteFiberCountY > 0 ? result.ConcreteFiberCountY : 36, 18, 56);
    }

    private static void DrawDimensionLine(StringBuilder sb, Point2 start, Point2 end, string label, string color, double size)
    {
        double dx = end.X - start.X;
        double dy = end.Y - start.Y;
        double length = Math.Sqrt(dx * dx + dy * dy);
        double ux = length > 1e-6 ? dx / length : 1.0;
        double uy = length > 1e-6 ? dy / length : 0.0;
        double ox = -uy * 10.0;
        double oy = ux * 10.0;
        double tickX = -uy * 6.0;
        double tickY = ux * 6.0;
        double sx = start.X + ox;
        double sy = start.Y + oy;
        double ex = end.X + ox;
        double ey = end.Y + oy;

        sb.Append($"<line x1='{start.X:F1}' y1='{start.Y:F1}' x2='{sx:F1}' y2='{sy:F1}' stroke='{color}' stroke-width='0.9' stroke-opacity='0.65'/>");
        sb.Append($"<line x1='{end.X:F1}' y1='{end.Y:F1}' x2='{ex:F1}' y2='{ey:F1}' stroke='{color}' stroke-width='0.9' stroke-opacity='0.65'/>");
        sb.Append($"<line x1='{sx:F1}' y1='{sy:F1}' x2='{ex:F1}' y2='{ey:F1}' stroke='{color}' stroke-width='1.5' marker-start='url(#arrowGray)' marker-end='url(#arrowGray)'/>");
        sb.Append($"<line x1='{sx - tickX:F1}' y1='{sy - tickY:F1}' x2='{sx + tickX:F1}' y2='{sy + tickY:F1}' stroke='{color}' stroke-width='1.1'/>");
        sb.Append($"<line x1='{ex - tickX:F1}' y1='{ey - tickY:F1}' x2='{ex + tickX:F1}' y2='{ey + tickY:F1}' stroke='{color}' stroke-width='1.1'/>");
        Label(sb, label, (sx + ex) / 2.0 + ox * 0.35, (sy + ey) / 2.0 + oy * 0.35, color, size);
    }

    private static void DrawSignedDistance(StringBuilder sb, SvgFrame frame, Point2 fibre, double neutralAxisOffset, double nx, double ny)
    {
        double d = Project(fibre, nx, ny) - neutralAxisOffset;
        var projected = new Point2(fibre.X - d * nx, fibre.Y - d * ny);
        var f = frame.ToScreen(fibre);
        var p = frame.ToScreen(projected);
        if (!IsDrawable(f) || !IsDrawable(p))
            return;

        sb.Append($"<circle cx='{f.X:F1}' cy='{f.Y:F1}' r='3.8' fill='#0F766E' stroke='white' stroke-width='1.1'/>");
        sb.Append($"<line x1='{p.X:F1}' y1='{p.Y:F1}' x2='{f.X:F1}' y2='{f.Y:F1}' stroke='#0F766E' stroke-width='1.35' stroke-dasharray='4,3'/>");
        DrawRightAngleMarker(sb, p, f, "#0F766E");
        Label(sb, "d_i", (f.X + p.X) / 2.0 + 5, (f.Y + p.Y) / 2.0 + 4, "#0F766E", 9.5);
    }

    private static void DrawRightAngleMarker(StringBuilder sb, Point2 vertex, Point2 normalPoint, string color)
    {
        double dx = normalPoint.X - vertex.X;
        double dy = normalPoint.Y - vertex.Y;
        double len = Math.Sqrt(dx * dx + dy * dy);
        if (len <= 1e-6)
            return;

        double ux = dx / len;
        double uy = dy / len;
        double tx = -uy;
        double ty = ux;
        const double size = 8.0;
        var a = new Point2(vertex.X + tx * size, vertex.Y + ty * size);
        var b = new Point2(a.X + ux * size, a.Y + uy * size);
        var c = new Point2(vertex.X + ux * size, vertex.Y + uy * size);
        sb.Append($"<polyline points='{a.X:F1},{a.Y:F1} {b.X:F1},{b.Y:F1} {c.X:F1},{c.Y:F1}' fill='none' stroke='{color}' stroke-width='1.15'/>");
    }

    private static void DrawGradientLegend(StringBuilder sb, double x, double y)
    {
        const int steps = 18;
        const double w = 7.0;
        for (int i = 0; i < steps; i++)
        {
            double t = i / (double)(steps - 1);
            sb.Append($"<rect x='{x + i * w:F1}' y='{y:F1}' width='{w + 0.6:F1}' height='10' fill='{BlueGradient(t)}' stroke='none'/>");
        }

        sb.Append($"<rect x='{x:F1}' y='{y:F1}' width='{steps * w:F1}' height='10' fill='none' stroke='#CBD5E1' stroke-width='0.7'/>");
        Label(sb, "neutral strain", x - 2, y + 23, "#374151", 8);
        Label(sb, "high epsilon_c", x + steps * w - 42, y + 23, "#1E3A8A", 8);
        sb.Append($"<rect x='{x + steps * w + 34:F1}' y='{y:F1}' width='12' height='10' fill='#F3F4F6' stroke='#DADDE2' stroke-width='0.7'/>");
        Label(sb, "Concrete tension neglected (ULS)", x + steps * w + 52, y + 9, "#6B7280", 8);
    }

    private static void DrawGrayscaleLegend(StringBuilder sb, double x, double y, string ultimateStrainLabel)
    {
        sb.Append($"<rect x='{x - 38:F1}' y='{y - 64:F1}' width='170' height='292' rx='4' fill='white' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<text x='{x + 46:F1}' y='{y - 38:F1}' text-anchor='middle' class='t small'>Concrete</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y - 18:F1}' text-anchor='middle' class='t small'>compression strain</text>");
        sb.Append($"<line x1='{x + 46:F1}' y1='{y - 8:F1}' x2='{x + 46:F1}' y2='{y + 13:F1}' stroke='#111827' stroke-width='0.9'/>");

        const int steps = 8;
        const double h = 22.0;
        for (int i = 0; i < steps; i++)
        {
            double t = 1.0 - i / (double)(steps - 1);
            sb.Append($"<rect x='{x + 30:F1}' y='{y + i * h:F1}' width='32' height='{h:F1}' fill='{GrayGradient(t)}' stroke='#9CA3AF' stroke-width='0.55'/>");
        }

        sb.Append($"<text x='{x - 20:F1}' y='{y + 12:F1}' class='t micro'>{ultimateStrainLabel}</text>");
        sb.Append($"<text x='{x - 20:F1}' y='{y + 30:F1}' class='t micro'>(max)</text>");
        sb.Append($"<text x='{x + 8:F1}' y='{y + steps * h - 42:F1}' class='t micro'>0</text>");
        sb.Append($"<text x='{x - 14:F1}' y='{y + steps * h - 22:F1}' class='t micro'>(at NA)</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y + steps * h + 34:F1}' text-anchor='middle' class='t micro'>Tension</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y + steps * h + 54:F1}' text-anchor='middle' class='t micro'>(neglected at ULS)</text>");
    }

    private static void DrawStrainDistributionPanel(StringBuilder sb, double x, double y, string ultimateStrainLabel)
    {
        sb.Append($"<rect x='{x - 28:F1}' y='{y - 34:F1}' width='260' height='285' rx='4' fill='white' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<text x='{x:F1}' y='{y:F1}' class='t bold small'>Linear strain distribution</text>");
        double ox = x + 5;
        double oy = y + 32;
        double w = 126;
        double h = 150;
        sb.Append($"<line x1='{ox:F1}' y1='{oy:F1}' x2='{ox:F1}' y2='{oy + h:F1}' stroke='#111827' stroke-width='1.1'/>");
        sb.Append($"<line x1='{ox:F1}' y1='{oy + h:F1}' x2='{ox + w:F1}' y2='{oy + h:F1}' stroke='#111827' stroke-width='1.1'/>");
        sb.Append($"<line x1='{ox:F1}' y1='{oy:F1}' x2='{ox + w:F1}' y2='{oy + h:F1}' stroke='#111827' stroke-width='1.3'/>");
        sb.Append($"<circle cx='{ox:F1}' cy='{oy:F1}' r='4.2' fill='#4B5563' stroke='#111827' stroke-width='1'/>");
        sb.Append($"<circle cx='{ox + w:F1}' cy='{oy + h:F1}' r='4.2' fill='white' stroke='#111827' stroke-width='1'/>");
        sb.Append($"<text x='{ox + 14:F1}' y='{oy + 4:F1}' class='t small'>{ultimateStrainLabel}</text>");
        sb.Append($"<text x='{ox + 62:F1}' y='{oy + 26:F1}' class='t small'>0</text>");
        sb.Append($"<text x='{ox + 62:F1}' y='{oy + 44:F1}' class='t micro'>(at extreme</text>");
        sb.Append($"<text x='{ox + 62:F1}' y='{oy + 60:F1}' class='t micro'>compression fibre)</text>");
        sb.Append($"<text x='{ox + w + 14:F1}' y='{oy + h - 18:F1}' class='t small'>0</text>");
        sb.Append($"<text x='{ox + w + 14:F1}' y='{oy + h:F1}' class='t small'>(at NA)</text>");

        double bx = x + 2;
        double by = y + 204;
        sb.Append($"<rect x='{bx:F1}' y='{by:F1}' width='150' height='62' fill='white' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<text x='{bx + 20:F1}' y='{by + 39:F1}' class='t small italic'>ε_i = {ultimateStrainLabel}</text>");
        sb.Append($"<text x='{bx + 102:F1}' y='{by + 25:F1}' class='t micro'>d_i</text>");
        sb.Append($"<line x1='{bx + 96:F1}' y1='{by + 31:F1}' x2='{bx + 132:F1}' y2='{by + 31:F1}' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<text x='{bx + 113:F1}' y='{by + 49:F1}' class='t micro'>c</text>");
    }

    private static void DrawDefinitionsBox(StringBuilder sb, double x, double y, string ultimateStrainLabel)
    {
        sb.Append($"<rect x='{x:F1}' y='{y:F1}' width='320' height='172' rx='4' fill='white' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<text x='{x + 14:F1}' y='{y + 22:F1}' class='t bold small'>Definitions</text>");
        sb.Append($"<text x='{x + 14:F1}' y='{y + 48:F1}' class='t micro'>d_i</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y + 48:F1}' class='t micro'>= signed perpendicular distance</text>");
        sb.Append($"<text x='{x + 60:F1}' y='{y + 64:F1}' class='t micro'>from NA (positive toward compression)</text>");
        sb.Append($"<text x='{x + 14:F1}' y='{y + 84:F1}' class='t micro'>c</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y + 84:F1}' class='t micro'>= perpendicular distance from NA</text>");
        sb.Append($"<text x='{x + 60:F1}' y='{y + 100:F1}' class='t micro'>to extreme compression fibre</text>");
        sb.Append($"<text x='{x + 14:F1}' y='{y + 124:F1}' class='t micro'>{ultimateStrainLabel}</text>");
        sb.Append($"<text x='{x + 46:F1}' y='{y + 124:F1}' class='t micro'>= ultimate concrete compressive strain</text>");
    }

    private static void DrawFigureLegend(StringBuilder sb, double x, double y)
    {
        sb.Append($"<rect x='{x - 18:F1}' y='{y - 20:F1}' width='390' height='112' rx='4' fill='white' stroke='#111827' stroke-width='0.9'/>");
        sb.Append($"<rect x='{x:F1}' y='{y:F1}' width='20' height='20' fill='white' stroke='#9CA3AF' stroke-width='1'/>");
        sb.Append($"<text x='{x + 34:F1}' y='{y + 16:F1}' class='t small'>Concrete tension neglected (ULS)</text>");
        sb.Append($"<rect x='{x:F1}' y='{y + 34:F1}' width='20' height='20' fill='#BFC3C8' stroke='#9CA3AF' stroke-width='1'/>");
        sb.Append($"<text x='{x + 34:F1}' y='{y + 50:F1}' class='t small'>Concrete in compression (strain &gt; 0)</text>");
        sb.Append($"<circle cx='{x + 10:F1}' cy='{y + 76:F1}' r='8.5' fill='#4B5563' stroke='#111827' stroke-width='1.3'/>");
        sb.Append($"<text x='{x + 34:F1}' y='{y + 82:F1}' class='t small'>Steel fibre (reinforcement bar)</text>");
    }

    private static void DrawStrainProfileMini(StringBuilder sb, double x, double y, string ultimateStrainLabel)
    {
        double h = 72;
        double w = 58;
        sb.Append($"<text x='{x:F1}' y='{y - 10:F1}' font-size='8.5' fill='#374151' font-family='Segoe UI,sans-serif' font-weight='600'>linear strain</text>");
        sb.Append($"<line x1='{x:F1}' y1='{y:F1}' x2='{x:F1}' y2='{y + h:F1}' stroke='#64748B' stroke-width='1'/>");
        sb.Append($"<line x1='{x:F1}' y1='{y + h:F1}' x2='{x + w:F1}' y2='{y + h:F1}' stroke='#64748B' stroke-width='1'/>");
        sb.Append($"<polyline points='{x:F1},{y:F1} {x + w:F1},{y + h:F1}' fill='none' stroke='#1E40AF' stroke-width='1.8'/>");
        sb.Append($"<circle cx='{x:F1}' cy='{y:F1}' r='2.6' fill='#1E3A8A'/>");
        sb.Append($"<circle cx='{x + w:F1}' cy='{y + h:F1}' r='2.6' fill='#B91C1C'/>");
        Label(sb, ultimateStrainLabel, x + 5, y + 4, "#1E3A8A", 7.8);
        Label(sb, "0 at NA", x + w - 2, y + h - 5, "#B91C1C", 7.8);
        Label(sb, $"ε_i = {ultimateStrainLabel} d_i / c", x - 15, y + h + 15, "#374151", 7.8);
    }

    private static bool PointInPolygon(Point2 point, IReadOnlyList<Point2> polygon)
    {
        bool inside = false;
        for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
        {
            var pi = polygon[i];
            var pj = polygon[j];
            bool crosses = (pi.Y > point.Y) != (pj.Y > point.Y);
            if (crosses)
            {
                double x = (pj.X - pi.X) * (point.Y - pi.Y) / (pj.Y - pi.Y) + pi.X;
                if (point.X < x)
                    inside = !inside;
            }
        }

        return inside;
    }

    private static double Project(Point2 point, double nx, double ny) => point.X * nx + point.Y * ny;

    private static string UltimateStrainLabel(CalculationResultDto result)
        => result.DesignCode == DesignCodeType.Ec2
            ? result.EurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3
                ? "εcu3"
                : "εcu2"
            : "εcu";

    private static string GrayGradient(double strain)
    {
        strain = Math.Clamp(strain, 0.0, 1.0);
        strain = Math.Pow(strain, 0.75);
        int c = (int)(250 + strain * (72 - 250));
        return $"rgb({c},{c},{c})";
    }

    private static string BlueGradient(double strain)
    {
        strain = Math.Clamp(strain, 0.0, 1.0);
        strain = Math.Pow(strain, 0.72);
        int r = (int)(250 + strain * (10 - 250));
        int g = (int)(253 + strain * (49 - 253));
        int b = (int)(255 + strain * (145 - 255));
        return $"rgb({r},{g},{b})";
    }

    private static bool IsDrawable(Point2 point)
        => double.IsFinite(point.X) && double.IsFinite(point.Y)
           && point.X > -W && point.X < 2 * W
           && point.Y > -H && point.Y < 2 * H;

    private static double NaLength()
    {
        double dx = NaX2 - NaX1;
        double dy = NaY2 - NaY1;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private static (double x, double y) NaCompressionNormal()
    {
        double length = NaLength();
        return ((NaY2 - NaY1) / length, -(NaX2 - NaX1) / length);
    }

    private static double DistanceToNA(double x, double y)
    {
        var (nx, ny) = NaCompressionNormal();
        return (x - NaX1) * nx + (y - NaY1) * ny;
    }

    private static (double x, double y) ProjectToNA(double x, double y)
    {
        var (nx, ny) = NaCompressionNormal();
        double d = DistanceToNA(x, y);
        return (x - d * nx, y - d * ny);
    }

    private static (double x, double y, double d) ExtremeCompressionPoint()
    {
        (double x, double y)[] corners =
        [
            (Sx, Sy),
            (Sx + Sw, Sy),
            (Sx + Sw, Sy + Sh),
            (Sx, Sy + Sh),
        ];

        var best = corners[0];
        double bestD = DistanceToNA(best.x, best.y);
        foreach (var corner in corners[1..])
        {
            double d = DistanceToNA(corner.x, corner.y);
            if (d > bestD)
            {
                best = corner;
                bestD = d;
            }
        }

        return (best.x, best.y, bestD);
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

    private readonly record struct Point2(double X, double Y);

    private sealed class RealSectionGeometry
    {
        private readonly Func<Point2, bool> _contains;

        internal RealSectionGeometry(IReadOnlyList<Point2> boundary, Func<Point2, bool> contains)
        {
            Boundary = boundary;
            _contains = contains;
            MinX = boundary.Min(p => p.X);
            MaxX = boundary.Max(p => p.X);
            MinY = boundary.Min(p => p.Y);
            MaxY = boundary.Max(p => p.Y);
        }

        internal IReadOnlyList<Point2> Boundary { get; }
        internal double MinX { get; }
        internal double MaxX { get; }
        internal double MinY { get; }
        internal double MaxY { get; }
        internal double Width => Math.Max(MaxX - MinX, 1.0);
        internal double Height => Math.Max(MaxY - MinY, 1.0);
        internal bool Contains(Point2 point) => _contains(point);
    }

    private readonly record struct SvgFrame(double Scale, double OriginX, double OriginY, double CentreX, double CentreY)
    {
        internal Point2 ToScreen(Point2 point)
            => new(OriginX + (point.X - CentreX) * Scale, OriginY - (point.Y - CentreY) * Scale);
    }
}
