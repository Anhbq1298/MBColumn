using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
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

    private static readonly SolidColorBrush NavyBrush = new(Color.FromRgb(0, 75, 133));
    private static readonly SolidColorBrush DarkNavyBrush = new(Color.FromRgb(0, 58, 102));
    private static readonly SolidColorBrush GreyBrush = new(Color.FromRgb(123, 135, 148));
    private static readonly SolidColorBrush TextBrush = new(Color.FromRgb(31, 41, 51));
    private static readonly SolidColorBrush RedBrush = new(Color.FromRgb(227, 27, 35));
    private static readonly SolidColorBrush FillBrush = new(Color.FromRgb(244, 247, 250));
    private static readonly SolidColorBrush GridBrush = new(Color.FromArgb(80, 180, 190, 200));
    private static readonly Pen GridPen = new(new SolidColorBrush(Color.FromArgb(70, 170, 180, 195)), 0.4);
    private static readonly Pen BoundaryPen = new(NavyBrush, 1.0);
    private static readonly Pen CoverDashPen = new(GreyBrush, 0.7) { DashStyle = DashStyles.Dash };
    private static readonly Pen AxisXPen = new(RedBrush, 0.8);
    private static readonly Pen AxisYPen = new(NavyBrush, 0.8);
    private static readonly Pen CrossPen = new(TextBrush, 0.8);

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
        var borderPen = new Pen(new SolidColorBrush(IsValid ? Color.FromRgb(214, 222, 230) : Color.FromRgb(245, 158, 11)), IsValid ? 1 : 2);
        dc.DrawRoundedRectangle(Brushes.White, borderPen, new Rect(0, 0, ActualWidth, ActualHeight), 5, 5);

        if (!IsValid)
        {
            DrawText(dc, string.IsNullOrWhiteSpace(ErrorMessage) ? "Invalid section input" : ErrorMessage, 14, Brushes.DarkOrange, new Point(18, ActualHeight / 2 - 10), FontWeights.SemiBold);
            return;
        }

        if (SectionShape == SectionShapeType.Irregular)
        {
            DrawIrregularSection(dc);
            return;
        }

        if (SectionWidth <= 0 || SectionHeight <= 0)
        {
            DrawText(dc, string.IsNullOrWhiteSpace(ErrorMessage) ? "Invalid section input" : ErrorMessage, 14, Brushes.DarkOrange, new Point(18, ActualHeight / 2 - 10), FontWeights.SemiBold);
            return;
        }

        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double w = SectionWidth * factor;
        double h = SectionHeight * factor;
        double c = Cover * factor;
        double topText = 46, leftDim = 48, bottomDim = 38, rightPad = 20;
        double scale = Math.Min((ActualWidth - leftDim - rightPad) / w, (ActualHeight - topText - bottomDim) / h);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = w * scale;
        double sh = h * scale;
        double x0 = leftDim + (ActualWidth - leftDim - rightPad - sw) / 2.0;
        double y0 = topText + (ActualHeight - topText - bottomDim - sh) / 2.0;
        var section = new Rect(x0, y0, sw, sh);
        var center = new Point(section.Left + section.Width / 2.0, section.Top + section.Height / 2.0);

        // Coordinate transform: screenX = center.X + worldX * scale, screenY = center.Y - worldY * scale
        // World range for standard sections: worldX in [-w/2, w/2], worldY in [-h/2, h/2] (mm)
        DrawGridLines(dc, center.X, center.Y, scale, -w / 2, w / 2, -h / 2, h / 2,
            x0, y0, x0 + sw, y0 + sh);

        DrawText(dc, SectionLabel, 12, TextBrush, new Point(12, 8), FontWeights.SemiBold);
        DrawText(dc, RebarLabel, 11, DarkNavyBrush, new Point(12, 24), FontWeights.Normal);

        if (SectionShape == SectionShapeType.Circular)
        {
            double rx = section.Width / 2.0;
            double ry = section.Height / 2.0;
            dc.DrawEllipse(FillBrush, BoundaryPen, center, rx, ry);
            double coverRadius = Math.Max(0, rx - c * scale);
            dc.DrawEllipse(null, CoverDashPen, center, coverRadius, coverRadius);
        }
        else
        {
            dc.DrawRectangle(FillBrush, BoundaryPen, section);
            var coverRect = new Rect(section.Left + c * scale, section.Top + c * scale,
                Math.Max(0, section.Width - 2 * c * scale), Math.Max(0, section.Height - 2 * c * scale));
            dc.DrawRectangle(null, CoverDashPen, coverRect);
        }

        DrawAxes(dc, center, Math.Min(32, sw / 4), Math.Min(32, sh / 4));

        foreach (var item in Rebars?.OfType<PreviewRebarPoint>() ?? [])
        {
            var pt = new Point(center.X + item.X * scale, center.Y - item.Y * scale);
            double r = Math.Max(2.5, item.Diameter * scale / 2.0);
            dc.DrawEllipse(DarkNavyBrush, new Pen(Brushes.White, 0.6), pt, r, r);
        }

        if (SectionShape == SectionShapeType.Circular)
            DrawDimension(dc, new Point(section.Left, section.Bottom + 14), new Point(section.Right, section.Bottom + 14), $"D = {SectionWidth:0.###} {UnitText}", TextBrush);
        else
        {
            DrawDimension(dc, new Point(section.Left, section.Bottom + 14), new Point(section.Right, section.Bottom + 14), $"b = {SectionWidth:0.###} {UnitText}", TextBrush);
            DrawDimension(dc, new Point(section.Left - 16, section.Bottom), new Point(section.Left - 16, section.Top), $"h = {SectionHeight:0.###} {UnitText}", TextBrush, vertical: true);
        }
    }

    private void DrawIrregularSection(DrawingContext dc)
    {
        var bpts = BoundaryPoints?.OfType<PreviewBoundaryPoint>().ToList();
        if (bpts == null || bpts.Count < 3) return;

        var rebars = Rebars?.OfType<PreviewRebarPoint>().ToList() ?? [];

        double topText = 46, leftDim = 48, bottomDim = 38, rightPad = 20;
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

        double scale = Math.Min((ActualWidth - leftDim - rightPad) / bboxW, (ActualHeight - topText - bottomDim) / bboxH);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = bboxW * scale, sh = bboxH * scale;
        double x0 = leftDim + (ActualWidth - leftDim - rightPad - sw) / 2.0;
        double y0 = topText + (ActualHeight - topText - bottomDim - sh) / 2.0;

        // ox, oy such that screenX = ox + worldX * scale, screenY = oy - worldY * scale
        double ox = x0 - minX * scale;
        double oy = y0 + maxY * scale;

        double ToScreenX(double x) => ox + x * scale;
        double ToScreenY(double y) => oy - y * scale;

        DrawGridLines(dc, ox, oy, scale, minX, maxX, minY, maxY, x0, y0, x0 + sw, y0 + sh);

        DrawText(dc, SectionLabel, 12, TextBrush, new Point(12, 8), FontWeights.SemiBold);
        DrawText(dc, RebarLabel, 11, DarkNavyBrush, new Point(12, 24), FontWeights.Normal);

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

        var origin = new Point(ToScreenX(0.0), ToScreenY(0.0));
        DrawAxes(dc, origin, Math.Min(32, sw / 4), Math.Min(32, sh / 4));

        foreach (var item in rebars)
        {
            var pt = new Point(ToScreenX(item.X), ToScreenY(item.Y));
            double r = Math.Max(2.5, item.Diameter * scale / 2.0);
            dc.DrawEllipse(DarkNavyBrush, new Pen(Brushes.White, 0.6), pt, r, r);
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

        // Vertical lines
        double startX = Math.Floor(wMinX / spacing) * spacing;
        for (double wx = startX; wx <= wMaxX + spacing * 0.5; wx += spacing)
        {
            double sx = ox + wx * scale;
            if (sx < clipL - 1 || sx > clipR + 1) continue;
            dc.DrawLine(GridPen, new Point(sx, clipT), new Point(sx, clipB));
        }

        // Horizontal lines
        double startY = Math.Floor(wMinY / spacing) * spacing;
        for (double wy = startY; wy <= wMaxY + spacing * 0.5; wy += spacing)
        {
            double sy = oy - wy * scale;
            if (sy < clipT - 1 || sy > clipB + 1) continue;
            dc.DrawLine(GridPen, new Point(clipL, sy), new Point(clipR, sy));
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

    private static void DrawAxes(DrawingContext dc, Point origin, double halfW, double halfH)
    {
        // X axis (red)
        dc.DrawLine(AxisXPen, origin, new Point(origin.X + halfW, origin.Y));
        DrawArrow(dc, new Point(origin.X + halfW, origin.Y), 0, RedBrush);
        DrawText(dc, "x", 9, RedBrush, new Point(origin.X + halfW + 2, origin.Y - 8), FontWeights.SemiBold);

        // Y axis (navy)
        dc.DrawLine(AxisYPen, origin, new Point(origin.X, origin.Y - halfH));
        DrawArrow(dc, new Point(origin.X, origin.Y - halfH), -Math.PI / 2, NavyBrush);
        DrawText(dc, "y", 9, NavyBrush, new Point(origin.X + 3, origin.Y - halfH - 12), FontWeights.SemiBold);

        // Origin cross
        dc.DrawLine(CrossPen, new Point(origin.X - 5, origin.Y), new Point(origin.X + 5, origin.Y));
        dc.DrawLine(CrossPen, new Point(origin.X, origin.Y - 5), new Point(origin.X, origin.Y + 5));
    }

    private string UnitText => UnitSystem == UnitSystem.Metric ? "mm" : "in";

    private static void DrawDimension(DrawingContext dc, Point a, Point b, string label, Brush brush, bool vertical = false)
    {
        var pen = new Pen(brush, 0.8);
        dc.DrawLine(pen, a, b);
        DrawArrow(dc, a, vertical ? Math.PI / 2 : Math.PI, brush);
        DrawArrow(dc, b, vertical ? -Math.PI / 2 : 0, brush);
        var labelPoint = vertical ? new Point(a.X - 40, (a.Y + b.Y) / 2 - 8) : new Point((a.X + b.X) / 2 - 34, a.Y + 4);
        DrawText(dc, label, 9.5, brush, labelPoint, FontWeights.Normal);
    }

    private static void DrawArrow(DrawingContext dc, Point tip, double angle, Brush brush)
    {
        double s = 4.5;
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
            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal),
            size, brush, 1.25);
        dc.DrawText(ft, point);
    }
}
