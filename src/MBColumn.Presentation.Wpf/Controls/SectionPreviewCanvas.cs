using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.ViewModels;

namespace MBColumn.Presentation.Wpf.Controls;

public sealed class SectionPreviewCanvas : FrameworkElement
{
    public static readonly DependencyProperty SectionWidthProperty = DependencyProperty.Register(nameof(SectionWidth), typeof(double), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SectionHeightProperty = DependencyProperty.Register(nameof(SectionHeight), typeof(double), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SectionShapeProperty = DependencyProperty.Register(nameof(SectionShape), typeof(SectionShapeType), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(SectionShapeType.Rectangular, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty CoverProperty = DependencyProperty.Register(nameof(Cover), typeof(double), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty UnitSystemProperty = DependencyProperty.Register(nameof(UnitSystem), typeof(UnitSystem), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(UnitSystem.Metric, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty RebarsProperty = DependencyProperty.Register(nameof(Rebars), typeof(IEnumerable), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnPreviewCollectionPropertyChanged));
    public static readonly DependencyProperty SectionLabelProperty = DependencyProperty.Register(nameof(SectionLabel), typeof(string), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty RebarLabelProperty = DependencyProperty.Register(nameof(RebarLabel), typeof(string), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty CoverLabelProperty = DependencyProperty.Register(nameof(CoverLabel), typeof(string), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register(nameof(IsValid), typeof(bool), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register(nameof(ErrorMessage), typeof(string), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata("Invalid section input", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty BoundaryPointsProperty = DependencyProperty.Register(nameof(BoundaryPoints), typeof(IEnumerable), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnPreviewCollectionPropertyChanged));
    public static readonly DependencyProperty StirrupDiameterMmProperty = DependencyProperty.Register(nameof(StirrupDiameterMm), typeof(double), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty InnerLegsXProperty = DependencyProperty.Register(nameof(InnerLegsX), typeof(int), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty InnerLegsYProperty = DependencyProperty.Register(nameof(InnerLegsY), typeof(int), typeof(SectionPreviewCanvas), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double SectionWidth { get => (double)GetValue(SectionWidthProperty); set => SetValue(SectionWidthProperty, value); }
    public double SectionHeight { get => (double)GetValue(SectionHeightProperty); set => SetValue(SectionHeightProperty, value); }
    public SectionShapeType SectionShape { get => (SectionShapeType)GetValue(SectionShapeProperty); set => SetValue(SectionShapeProperty, value); }
    public double Cover { get => (double)GetValue(CoverProperty); set => SetValue(CoverProperty, value); }
    public UnitSystem UnitSystem { get => (UnitSystem)GetValue(UnitSystemProperty); set => SetValue(UnitSystemProperty, value); }
    public IEnumerable? Rebars { get => (IEnumerable?)GetValue(RebarsProperty); set => SetValue(RebarsProperty, value); }
    public string SectionLabel { get => (string)GetValue(SectionLabelProperty); set => SetValue(SectionLabelProperty, value); }
    public string RebarLabel { get => (string)GetValue(RebarLabelProperty); set => SetValue(RebarLabelProperty, value); }
    public string CoverLabel { get => (string)GetValue(CoverLabelProperty); set => SetValue(CoverLabelProperty, value); }
    public bool IsValid { get => (bool)GetValue(IsValidProperty); set => SetValue(IsValidProperty, value); }
    public string ErrorMessage { get => (string)GetValue(ErrorMessageProperty); set => SetValue(ErrorMessageProperty, value); }
    public IEnumerable? BoundaryPoints { get => (IEnumerable?)GetValue(BoundaryPointsProperty); set => SetValue(BoundaryPointsProperty, value); }
    public double StirrupDiameterMm { get => (double)GetValue(StirrupDiameterMmProperty); set => SetValue(StirrupDiameterMmProperty, value); }
    public int InnerLegsX { get => (int)GetValue(InnerLegsXProperty); set => SetValue(InnerLegsXProperty, value); }
    public int InnerLegsY { get => (int)GetValue(InnerLegsYProperty); set => SetValue(InnerLegsYProperty, value); }

    private struct RenderedRebar
    {
        public Point Center;
        public double Radius;
        public string Label;
    }

    private readonly List<RenderedRebar> _renderedRebars = new();
    private RenderedRebar? _hoveredRebar;

    private static readonly SolidColorBrush NavyBrush = GetFrozenBrush(Color.FromRgb(0, 75, 133));
    private static readonly SolidColorBrush DarkNavyBrush = GetFrozenBrush(Color.FromRgb(0, 58, 102));
    private static readonly SolidColorBrush GreyBrush = GetFrozenBrush(Color.FromRgb(123, 135, 148));
    private static readonly SolidColorBrush TextBrush = GetFrozenBrush(Color.FromRgb(31, 41, 51));
    private static readonly SolidColorBrush RedBrush = GetFrozenBrush(Color.FromRgb(227, 27, 35));

    private static readonly SolidColorBrush FillBrush = GetFrozenBrush(Color.FromArgb(30, 0, 75, 133));
    private static readonly Pen BoundaryPen = GetFrozenPen(NavyBrush, 1.5);
    private static readonly Pen CoverDashPen = GetFrozenPen(GreyBrush, 0.75, DashStyles.Dash);

    private static readonly SolidColorBrush MajorGridBrush = GetFrozenBrush(Color.FromArgb(0xD0, 203, 213, 225));
    private static readonly SolidColorBrush MinorGridBrush = GetFrozenBrush(Color.FromArgb(0xB0, 241, 245, 249));
    private static readonly Pen MajorGridPen = GetFrozenPen(MajorGridBrush, 0.6);
    private static readonly Pen MinorGridPen = GetFrozenPen(MinorGridBrush, 0.35);

    private static readonly SolidColorBrush AxisBrush = GetFrozenBrush(Colors.Black);
    private static readonly Pen AxisPen = GetFrozenPen(AxisBrush, 1.0);

    private static readonly SolidColorBrush RebarBrush = GetFrozenBrush(Color.FromRgb(220, 38, 38));

    private static readonly SolidColorBrush CentroidBrush = GetFrozenBrush(Color.FromRgb(220, 38, 38));
    private static readonly Pen CentroidPen = GetFrozenPen(Brushes.White, 0.8);

    private static readonly SolidColorBrush DimBrush = GetFrozenBrush(Color.FromRgb(100, 116, 139));
    private static readonly Pen DimPen = GetFrozenPen(DimBrush, 0.8);

    private static SolidColorBrush GetFrozenBrush(Color color)
    {
        var brush = new SolidColorBrush(color);
        brush.Freeze();
        return brush;
    }

    private static Pen GetFrozenPen(Brush brush, double thickness, DashStyle? dashStyle = null)
    {
        var pen = new Pen(brush, thickness);
        if (dashStyle != null)
        {
            pen.DashStyle = dashStyle;
        }
        pen.Freeze();
        return pen;
    }

    private static void OnPreviewCollectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not SectionPreviewCanvas canvas) return;
        if (e.OldValue is INotifyCollectionChanged old) old.CollectionChanged -= canvas.OnPreviewCollectionChanged;
        if (e.NewValue is INotifyCollectionChanged neu) neu.CollectionChanged += canvas.OnPreviewCollectionChanged;
        canvas.InvalidateVisual();
    }

    private void OnPreviewCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) => InvalidateVisual();

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        // Compute centered square frame bounds
        double size = Math.Min(ActualWidth, ActualHeight);
        double leftOffset = (ActualWidth - size) / 2.0;
        double topOffset = (ActualHeight - size) / 2.0;
        var frameRect = new Rect(leftOffset, topOffset, size, size);

        var borderPen = new Pen(new SolidColorBrush(IsValid ? Color.FromRgb(214, 222, 230) : Color.FromRgb(245, 158, 11)), IsValid ? 1 : 2);
        dc.DrawRoundedRectangle(Brushes.White, borderPen, frameRect, 5, 5);

        if (!IsValid)
        {
            DrawText(dc, string.IsNullOrWhiteSpace(ErrorMessage) ? "Invalid section input" : ErrorMessage, 14, Brushes.DarkOrange, new Point(frameRect.Left + 18, frameRect.Top + frameRect.Height / 2 - 10), FontWeights.SemiBold);
            return;
        }

        if (SectionShape == SectionShapeType.Irregular)
        {
            DrawIrregularSection(dc);
            return;
        }

        if (SectionWidth <= 0 || SectionHeight <= 0)
        {
            DrawText(dc, string.IsNullOrWhiteSpace(ErrorMessage) ? "Invalid section input" : ErrorMessage, 14, Brushes.DarkOrange, new Point(frameRect.Left + 18, frameRect.Top + frameRect.Height / 2 - 10), FontWeights.SemiBold);
            return;
        }

        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double w = SectionWidth * factor;
        double h = SectionHeight * factor;
        double c = Cover * factor;
        double scale = 1.25 * Math.Min((frameRect.Width - 68) / w, (frameRect.Height - 84) / h);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = w * scale;
        double sh = h * scale;
        double x0 = frameRect.Left + (frameRect.Width - sw) / 2.0;
        double y0 = frameRect.Top + (frameRect.Height - sh) / 2.0;
        var section = new Rect(x0, y0, sw, sh);
        var center = new Point(section.Left + section.Width / 2.0, section.Top + section.Height / 2.0);

        // 1. Gridlines
        double clipL = frameRect.Left + 1;
        double clipT = frameRect.Top + 1;
        double clipR = frameRect.Right - 1;
        double clipB = frameRect.Bottom - 1;

        double wMinX = (clipL - center.X) / scale;
        double wMaxX = (clipR - center.X) / scale;
        double wMinY = (center.Y - clipB) / scale;
        double wMaxY = (center.Y - clipT) / scale;

        DrawGridLines(dc, center.X, center.Y, scale, wMinX, wMaxX, wMinY, wMaxY,
            clipL, clipT, clipR, clipB);

        // 4. Concrete boundary & fill (including Cover and Stirrup lines)
        if (SectionShape == SectionShapeType.Circular)
        {
            double rx = section.Width / 2.0;
            double ry = section.Height / 2.0;
            dc.DrawEllipse(FillBrush, BoundaryPen, center, rx, ry);
            double coverRadius = Math.Max(0, rx - c * scale);
            dc.DrawEllipse(null, CoverDashPen, center, coverRadius, coverRadius);

            double hoopRadius = Math.Max(0, rx - (c + StirrupDiameterMm / 2.0) * scale);
            if (hoopRadius > 0)
            {
                var activePen = GetStirrupPen();
                dc.DrawEllipse(null, activePen, center, hoopRadius, hoopRadius);
            }
        }
        else
        {
            dc.DrawRectangle(FillBrush, BoundaryPen, section);
            var coverRect = new Rect(section.Left + c * scale, section.Top + c * scale,
                Math.Max(0, section.Width - 2 * c * scale), Math.Max(0, section.Height - 2 * c * scale));
            dc.DrawRectangle(null, CoverDashPen, coverRect);

            // Stirrup: centerline at cover + stirrupRadius from each face
            double stirrupInset = (c + StirrupDiameterMm / 2.0) * scale;
            double stirrupW = section.Width - 2 * stirrupInset;
            double stirrupH = section.Height - 2 * stirrupInset;
            if (stirrupW > 0 && stirrupH > 0)
            {
                var stirrupRect = new Rect(section.Left + stirrupInset, section.Top + stirrupInset, stirrupW, stirrupH);
                var activePen = GetStirrupPen();
                dc.DrawRoundedRectangle(null, activePen, stirrupRect, 2.5, 2.5);

                double sLeft = section.Left + stirrupInset;
                double sTop = section.Top + stirrupInset;

                // Collect bar positions (mm, centroid-origin) with radius
                var barData = new List<(double X, double Y, double R)>();
                if (Rebars != null)
                {
                    foreach (var item in Rebars)
                    {
                        if (item is PreviewRebarPoint pr)
                            barData.Add((pr.X, pr.Y, pr.Diameter / 2.0));
                        else if (item is MBColumn.Application.DTOs.RebarCoordinateDto rc)
                            barData.Add((rc.X, rc.Y, rc.Diameter / 2.0));
                    }
                }

                // Inner legs X: vertical lines snapped to top-face intermediate bar positions
                int nIX = InnerLegsX;
                if (nIX > 0)
                {
                    var positions = GetInnerLegPositions(barData, nIX, isX: true, center, scale, sLeft, stirrupW, sTop, stirrupH);
                    foreach (var (pos, barR) in positions)
                    {
                        double lx = pos + barR * scale;
                        dc.DrawLine(activePen, new Point(lx, sTop), new Point(lx, sTop + stirrupH));
                    }
                }

                // Inner legs Y: horizontal lines snapped to left-face intermediate bar positions
                int nIY = InnerLegsY;
                if (nIY > 0)
                {
                    var positions = GetInnerLegPositions(barData, nIY, isX: false, center, scale, sLeft, stirrupW, sTop, stirrupH);
                    foreach (var (pos, barR) in positions)
                    {
                        double ly = pos + barR * scale;
                        dc.DrawLine(activePen, new Point(sLeft, ly), new Point(sLeft + stirrupW, ly));
                    }
                }
            }
        }

        // 5. Local axes / centroid
        DrawAxes(dc, center, frameRect);

        // 6. Rebars
        _renderedRebars.Clear();
        if (Rebars != null)
        {
            foreach (var item in Rebars)
            {
                double cx = 0, cy = 0, dia = 0;
                string label = "";
                if (item is PreviewRebarPoint pr) { cx = pr.X; cy = pr.Y; dia = pr.Diameter; label = pr.Label; }
                else if (item is MBColumn.Application.DTOs.RebarCoordinateDto rc) { cx = rc.X; cy = rc.Y; dia = rc.Diameter; label = rc.BarSizeLabel; }
                else continue;

                var pt = new Point(center.X + cx * scale, center.Y - cy * scale);
                double r = Math.Max(3.5, dia * scale / 2.0);
                dc.DrawEllipse(RebarBrush, new Pen(Brushes.White, 0.6), pt, r, r);
                _renderedRebars.Add(new RenderedRebar { Center = pt, Radius = r, Label = label });
            }
        }

        // 7. Hover tooltip
        if (_hoveredRebar != null)
        {
            DrawHoverTooltip(dc, _hoveredRebar.Value);
        }
    }

    private void DrawIrregularSection(DrawingContext dc)
    {
        var bpts = new List<Point>();
        if (BoundaryPoints != null)
        {
            foreach (var bp in BoundaryPoints)
            {
                if (bp is PreviewBoundaryPoint pbp) bpts.Add(new Point(pbp.X, pbp.Y));
                else if (bp is MBColumn.Application.DTOs.InsetPointDto ip) bpts.Add(new Point(ip.X, ip.Y));
            }
        }
        if (bpts.Count < 3) return;

        var rebars = new List<(double X, double Y, double Diameter, string Label)>();
        if (Rebars != null)
        {
            foreach (var item in Rebars)
            {
                if (item is PreviewRebarPoint pr) rebars.Add((pr.X, pr.Y, pr.Diameter, pr.Label));
                else if (item is MBColumn.Application.DTOs.RebarCoordinateDto rc) rebars.Add((rc.X, rc.Y, rc.Diameter, rc.BarSizeLabel));
            }
        }

        // Define centered square frame
        double size = Math.Min(ActualWidth, ActualHeight);
        double leftOffset = (ActualWidth - size) / 2.0;
        double topOffset = (ActualHeight - size) / 2.0;
        var frameRect = new Rect(leftOffset, topOffset, size, size);

        double minX = Math.Min(0.0, bpts.Min(p => p.X));
        double maxX = Math.Max(0.0, bpts.Max(p => p.X));
        double minY = Math.Min(0.0, bpts.Min(p => p.Y));
        double maxY = Math.Max(0.0, bpts.Max(p => p.Y));

        if (rebars.Count > 0)
        {
            minX = Math.Min(minX, rebars.Min(p => p.X));
            maxX = Math.Max(maxX, rebars.Max(p => p.X));
            minY = Math.Min(minY, rebars.Min(p => p.Y));
            maxY = Math.Max(maxY, rebars.Max(p => p.Y));
        }

        double bboxW = maxX - minX, bboxH = maxY - minY;
        if (bboxW <= 0 || bboxH <= 0) return;

        double scale = 1.25 * Math.Min((frameRect.Width - 68) / bboxW, (frameRect.Height - 84) / bboxH);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = bboxW * scale, sh = bboxH * scale;
        double x0 = frameRect.Left + (frameRect.Width - sw) / 2.0;
        double y0 = frameRect.Top + (frameRect.Height - sh) / 2.0;

        // ox, oy such that screenX = ox + worldX * scale, screenY = oy - worldY * scale
        double ox = x0 - minX * scale;
        double oy = y0 + maxY * scale;

        double ToScreenX(double x) => ox + x * scale;
        double ToScreenY(double y) => oy - y * scale;

        // 1. Gridlines
        double clipL = frameRect.Left + 1;
        double clipT = frameRect.Top + 1;
        double clipR = frameRect.Right - 1;
        double clipB = frameRect.Bottom - 1;

        double wMinX = (clipL - ox) / scale;
        double wMaxX = (clipR - ox) / scale;
        double wMinY = (oy - clipB) / scale;
        double wMaxY = (oy - clipT) / scale;

        DrawGridLines(dc, ox, oy, scale, wMinX, wMaxX, wMinY, wMaxY,
            clipL, clipT, clipR, clipB);

        // 4. Concrete boundary & fill
        var geo = new StreamGeometry();
        using (var ctx = geo.Open())
        {
            ctx.BeginFigure(new Point(ToScreenX(bpts[0].X), ToScreenY(bpts[0].Y)), true, true);
            for (int i = 1; i < bpts.Count; i++)
                ctx.LineTo(new Point(ToScreenX(bpts[i].X), ToScreenY(bpts[i].Y)), true, false);
        }
        dc.DrawGeometry(FillBrush, BoundaryPen, geo);

        // Cover offset line (no text label)
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double coverMm = Cover * factor;
        if (coverMm > 0)
        {
            try
            {
                var boundary = bpts.Select(p => new Point2D(p.X, p.Y)).ToList();
                var coverPoly = PolygonGeometry.OffsetPolygon(boundary, coverMm);
                if (coverPoly != null && coverPoly.Count >= 3)
                {
                    var coverGeo = new StreamGeometry();
                    using (var ctx = coverGeo.Open())
                    {
                        ctx.BeginFigure(new Point(ToScreenX(coverPoly[0].X), ToScreenY(coverPoly[0].Y)), false, true);
                        for (int i = 1; i < coverPoly.Count; i++)
                            ctx.LineTo(new Point(ToScreenX(coverPoly[i].X), ToScreenY(coverPoly[i].Y)), true, false);
                    }
                    dc.DrawGeometry(null, CoverDashPen, coverGeo);
                }
            }
            catch { }
        }

        // 5. Local axes / centroid
        var origin = new Point(ToScreenX(0.0), ToScreenY(0.0));
        DrawAxes(dc, origin, frameRect);

        // 6. Rebars
        _renderedRebars.Clear();
        foreach (var item in rebars)
        {
            var pt = new Point(ToScreenX(item.X), ToScreenY(item.Y));
            double r = Math.Max(3.5, item.Diameter * scale / 2.0);
            dc.DrawEllipse(RebarBrush, new Pen(Brushes.White, 0.6), pt, r, r);
            _renderedRebars.Add(new RenderedRebar { Center = pt, Radius = r, Label = item.Label });
        }

        // 7. Hover tooltip
        if (_hoveredRebar != null)
        {
            DrawHoverTooltip(dc, _hoveredRebar.Value);
        }
    }

    protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
    {
        base.OnMouseMove(e);
        var mousePos = e.GetPosition(this);
        RenderedRebar? newHovered = null;

        foreach (var rebar in _renderedRebars)
        {
            double distSq = (mousePos.X - rebar.Center.X) * (mousePos.X - rebar.Center.X) +
                            (mousePos.Y - rebar.Center.Y) * (mousePos.Y - rebar.Center.Y);
            double hitRadius = Math.Max(6.0, rebar.Radius + 3.0);
            if (distSq <= hitRadius * hitRadius)
            {
                newHovered = rebar;
                break;
            }
        }

        if (newHovered?.Center != _hoveredRebar?.Center)
        {
            _hoveredRebar = newHovered;
            InvalidateVisual();
        }
    }

    protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
    {
        base.OnMouseLeave(e);
        if (_hoveredRebar != null)
        {
            _hoveredRebar = null;
            InvalidateVisual();
        }
    }

    private static void DrawGridLines(DrawingContext dc,
        double ox, double oy, double scale,
        double wMinX, double wMaxX, double wMinY, double wMaxY,
        double clipL, double clipT, double clipR, double clipB)
    {
        double rangeX = wMaxX - wMinX;
        double rangeY = wMaxY - wMinY;
        if (rangeX <= 0 || rangeY <= 0) return;

        double spacing = NiceGridSpacing(Math.Max(rangeX, rangeY));

        double raw = Math.Max(rangeX, rangeY) / 5.0;
        double magnitude = Math.Pow(10, Math.Floor(Math.Log10(raw)));
        double normalized = raw / magnitude;
        double nice = normalized < 1.5 ? 1 : normalized < 3.5 ? 2 : normalized < 7.5 ? 5 : 10;
        
        double minorSpacing = spacing / 5.0;
        if (Math.Abs(nice - 2) < 0.1) minorSpacing = spacing / 4.0;

        // Draw minor gridlines
        double startX = Math.Floor(wMinX / minorSpacing) * minorSpacing;
        for (double wx = startX; wx <= wMaxX + minorSpacing * 0.5; wx += minorSpacing)
        {
            double nearestMajor = Math.Round(wx / spacing) * spacing;
            if (Math.Abs(wx - nearestMajor) < minorSpacing * 0.1) continue;

            double sx = ox + wx * scale;
            if (sx < clipL - 1 || sx > clipR + 1) continue;
            dc.DrawLine(MinorGridPen, new Point(sx, clipT), new Point(sx, clipB));
        }

        double startY = Math.Floor(wMinY / minorSpacing) * minorSpacing;
        for (double wy = startY; wy <= wMaxY + minorSpacing * 0.5; wy += minorSpacing)
        {
            double nearestMajor = Math.Round(wy / spacing) * spacing;
            if (Math.Abs(wy - nearestMajor) < minorSpacing * 0.1) continue;

            double sy = oy - wy * scale;
            if (sy < clipT - 1 || sy > clipB + 1) continue;
            dc.DrawLine(MinorGridPen, new Point(clipL, sy), new Point(clipR, sy));
        }

        // Draw major gridlines
        startX = Math.Floor(wMinX / spacing) * spacing;
        for (double wx = startX; wx <= wMaxX + spacing * 0.5; wx += spacing)
        {
            double sx = ox + wx * scale;
            if (sx < clipL - 1 || sx > clipR + 1) continue;
            dc.DrawLine(MajorGridPen, new Point(sx, clipT), new Point(sx, clipB));
        }

        startY = Math.Floor(wMinY / spacing) * spacing;
        for (double wy = startY; wy <= wMaxY + spacing * 0.5; wy += spacing)
        {
            double sy = oy - wy * scale;
            if (sy < clipT - 1 || sy > clipB + 1) continue;
            dc.DrawLine(MajorGridPen, new Point(clipL, sy), new Point(clipR, sy));
        }
    }

    private static double NiceGridSpacing(double range)
    {
        if (range <= 0) return 100;
        double raw = range / 5.0;
        double magnitude = Math.Pow(10, Math.Floor(Math.Log10(raw)));
        double normalized = raw / magnitude;
        double nice = normalized < 1.5 ? 1 : normalized < 3.5 ? 2 : normalized < 7.5 ? 5 : 10;
        return nice * magnitude;
    }

    private void DrawAxes(DrawingContext dc, Point origin, Rect frameRect)
    {
        double xLeft = frameRect.Left + 4;
        double xRight = frameRect.Right - 4;
        double yBottom = frameRect.Bottom - 4;
        double yTop = frameRect.Top + 4;

        if (xLeft >= xRight || yTop >= yBottom) return;

        // X axis (horizontal crossing)
        dc.DrawLine(AxisPen, new Point(xLeft, origin.Y), new Point(xRight, origin.Y));
        // Right arrow & label (positive X)
        DrawArrow(dc, new Point(xRight, origin.Y), 0, AxisBrush);
        DrawText(dc, "X", 13, AxisBrush, new Point(xRight - 14, origin.Y - 16), FontWeights.SemiBold);
        // Left arrow & label (negative X)
        DrawArrow(dc, new Point(xLeft, origin.Y), Math.PI, AxisBrush);
        DrawText(dc, "-X", 13, AxisBrush, new Point(xLeft + 6, origin.Y - 16), FontWeights.SemiBold);

        // Y axis (vertical crossing)
        dc.DrawLine(AxisPen, new Point(origin.X, yBottom), new Point(origin.X, yTop));
        // Top arrow & label (positive Y)
        DrawArrow(dc, new Point(origin.X, yTop), -Math.PI / 2, AxisBrush);
        DrawText(dc, "Y", 13, AxisBrush, new Point(origin.X + 6, yTop + 2), FontWeights.SemiBold);
        // Bottom arrow & label (negative Y)
        DrawArrow(dc, new Point(origin.X, yBottom), Math.PI / 2, AxisBrush);
        DrawText(dc, "-Y", 13, AxisBrush, new Point(origin.X + 6, yBottom - 16), FontWeights.SemiBold);

        // Centroid: red circle with white border
        dc.DrawEllipse(CentroidBrush, CentroidPen, origin, 3.5, 3.5);
    }

    private string UnitText => UnitSystem == UnitSystem.Metric ? "mm" : "in";

    private static void DrawDimension(DrawingContext dc, Point a, Point b, string label, Brush brush, bool vertical = false)
    {
        dc.DrawLine(DimPen, a, b);
        DrawArrow(dc, a, vertical ? Math.PI / 2 : Math.PI, brush);
        DrawArrow(dc, b, vertical ? -Math.PI / 2 : 0, brush);

        if (vertical)
        {
            var centerPoint = new Point(a.X - 12, (a.Y + b.Y) / 2.0);
            var ft = new FormattedText(label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Inter, Arial, Segoe UI"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                11, brush, 1.25);

            dc.PushTransform(new RotateTransform(-90, centerPoint.X, centerPoint.Y));
            dc.DrawText(ft, new Point(centerPoint.X - ft.Width / 2.0, centerPoint.Y - ft.Height / 2.0));
            dc.Pop();
        }
        else
        {
            var labelPoint = new Point((a.X + b.X) / 2 - 34, a.Y + 4);
            DrawText(dc, label, 11, brush, labelPoint, FontWeights.Normal);
        }
    }

    private static void DrawArrow(DrawingContext dc, Point tip, double angle, Brush brush)
    {
        double s = 5.5;
        var p1 = new Point(tip.X - Math.Cos(angle - 0.45) * s, tip.Y - Math.Sin(angle - 0.45) * s);
        var p2 = new Point(tip.X - Math.Cos(angle + 0.45) * s, tip.Y - Math.Sin(angle + 0.45) * s);
        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(tip, true, true);
        ctx.LineTo(p1, true, false);
        ctx.LineTo(p2, true, false);
        dc.DrawGeometry(brush, null, geo);
    }

    private static void DrawText(DrawingContext dc, string value, double size, Brush brush, Point point, FontWeight weight)
    {
        if (string.IsNullOrEmpty(value)) return;
        var ft = new FormattedText(value, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Inter, Arial, Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal),
            size, brush, 1.25);
        dc.DrawText(ft, point);
    }

    private void DrawHoverTooltip(DrawingContext dc, RenderedRebar rebar)
    {
        string label = rebar.Label;
        if (string.IsNullOrEmpty(label)) return;

        var ft = new FormattedText(label, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Inter, Arial, Segoe UI"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
            11, Brushes.White, 1.25);

        double paddingX = 8;
        double paddingY = 4;
        double width = ft.Width + paddingX * 2;
        double height = ft.Height + paddingY * 2;

        double tx = rebar.Center.X - width / 2.0;
        double ty = rebar.Center.Y - rebar.Radius - height - 6;

        if (tx < 4) tx = 4;
        if (tx + width > ActualWidth - 4) tx = ActualWidth - width - 4;
        if (ty < 4) ty = rebar.Center.Y + rebar.Radius + 6;

        var rect = new Rect(tx, ty, width, height);

        var tooltipBg = GetFrozenBrush(Color.FromRgb(30, 41, 59));
        var tooltipBorder = GetFrozenPen(GetFrozenBrush(Color.FromRgb(71, 85, 105)), 0.8);
        dc.DrawRoundedRectangle(tooltipBg, tooltipBorder, rect, 4, 4);

        dc.DrawText(ft, new Point(tx + paddingX, ty + paddingY));
    }

    private Pen? _cachedStirrupPen;
    private double _cachedStirrupDiamMm = -1;

    private Pen GetStirrupPen()
    {
        if (_cachedStirrupPen is null || _cachedStirrupDiamMm != StirrupDiameterMm)
        {
            double thick = Math.Max(0.7, Math.Min(3.0, StirrupDiameterMm * 0.11));
            _cachedStirrupPen = new Pen(new SolidColorBrush(Color.FromRgb(220, 30, 30)), thick);
            _cachedStirrupPen.Freeze();
            _cachedStirrupDiamMm = StirrupDiameterMm;
        }
        return _cachedStirrupPen;
    }

    private static List<(double Pos, double BarR)> GetInnerLegPositions(
        List<(double X, double Y, double R)> bars,
        int count,
        bool isX,
        Point center,
        double scale,
        double sLeft,
        double stirrupW,
        double sTop,
        double stirrupH)
    {
        const double faceTolMm = 8.0;
        if (bars.Count >= 3)
        {
            List<(double Pos, double R)> faceBars;
            if (isX)
            {
                double maxY = bars.Max(b => b.Y);
                faceBars = bars.Where(b => Math.Abs(b.Y - maxY) < faceTolMm)
                               .OrderBy(b => b.X)
                               .Select(b => (Pos: center.X + b.X * scale, R: b.R))
                               .ToList();
            }
            else
            {
                double minX = bars.Min(b => b.X);
                faceBars = bars.Where(b => Math.Abs(b.X - minX) < faceTolMm)
                               .OrderByDescending(b => b.Y)
                               .Select(b => (Pos: center.Y - b.Y * scale, R: b.R))
                               .ToList();
            }
            if (faceBars.Count > 2)
                return PickEvenly(faceBars.Skip(1).Take(faceBars.Count - 2).ToList(), count);
        }
        double extent = isX ? stirrupW : stirrupH;
        double start = isX ? sLeft : sTop;
        return Enumerable.Range(1, count)
                         .Select(i => (start + (double)i / (count + 1) * extent, 0.0))
                         .ToList();
    }

    private static List<(double Pos, double R)> PickEvenly(List<(double Pos, double R)> source, int count)
    {
        if (source.Count == 0 || count <= 0) return [];
        if (count >= source.Count) return [.. source];
        var result = new List<(double, double)>(count);
        for (int i = 0; i < count; i++)
        {
            int idx = count == 1
                ? source.Count / 2
                : (int)Math.Round((double)i * (source.Count - 1) / (count - 1));
            result.Add(source[Math.Min(idx, source.Count - 1)]);
        }
        return result;
    }
}
