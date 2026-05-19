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

    private static void OnPreviewCollectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not SectionPreviewCanvas canvas)
        {
            return;
        }

        if (e.OldValue is INotifyCollectionChanged oldCollection)
        {
            oldCollection.CollectionChanged -= canvas.OnPreviewCollectionChanged;
        }

        if (e.NewValue is INotifyCollectionChanged newCollection)
        {
            newCollection.CollectionChanged += canvas.OnPreviewCollectionChanged;
        }

        canvas.InvalidateVisual();
    }

    private void OnPreviewCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        => InvalidateVisual();

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
        double topText = 50;
        double leftDim = 50;
        double bottomDim = 42;
        double rightPad = 24;
        double scale = Math.Min((ActualWidth - leftDim - rightPad) / w, (ActualHeight - topText - bottomDim) / h);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = w * scale;
        double sh = h * scale;
        double x0 = leftDim + (ActualWidth - leftDim - rightPad - sw) / 2.0;
        double y0 = topText + (ActualHeight - topText - bottomDim - sh) / 2.0;
        var section = new Rect(x0, y0, sw, sh);
        var navy = new SolidColorBrush(Color.FromRgb(0, 75, 133));
        var darkNavy = new SolidColorBrush(Color.FromRgb(0, 58, 102));
        var grey = new SolidColorBrush(Color.FromRgb(123, 135, 148));
        var text = new SolidColorBrush(Color.FromRgb(31, 41, 51));
        var center = new Point(section.Left + section.Width / 2.0, section.Top + section.Height / 2.0);

        DrawText(dc, SectionLabel, 13, text, new Point(14, 10), FontWeights.SemiBold);
        DrawText(dc, RebarLabel, 12, darkNavy, new Point(14, 28), FontWeights.Normal);
        DrawText(dc, CoverLabel, 12, grey, new Point(Math.Max(14, ActualWidth - 145), 28), FontWeights.Normal);

        if (SectionShape == SectionShapeType.Circular)
        {
            var fill = new SolidColorBrush(Color.FromRgb(244, 247, 250));
            double rx = section.Width / 2.0;
            double ry = section.Height / 2.0;
            dc.DrawEllipse(fill, new Pen(navy, 2), center, rx, ry);
            double coverRadius = Math.Max(0, rx - c * scale);
            dc.DrawEllipse(null, new Pen(grey, 1) { DashStyle = DashStyles.Dash }, center, coverRadius, coverRadius);
            DrawText(dc, "cover", 10, grey, new Point(center.X + coverRadius * 0.35, center.Y - coverRadius * 0.7), FontWeights.Normal);
        }
        else
        {
            dc.DrawRectangle(new SolidColorBrush(Color.FromRgb(244, 247, 250)), new Pen(navy, 2), section);
            var coverRect = new Rect(section.Left + c * scale, section.Top + c * scale, Math.Max(0, section.Width - 2 * c * scale), Math.Max(0, section.Height - 2 * c * scale));
            dc.DrawRectangle(null, new Pen(grey, 1) { DashStyle = DashStyles.Dash }, coverRect);
            DrawText(dc, "cover", 10, grey, new Point(coverRect.Left + 4, coverRect.Top + 4), FontWeights.Normal);
        }

        dc.DrawLine(new Pen(new SolidColorBrush(Color.FromRgb(227, 27, 35)), 1.2), center, new Point(center.X + Math.Min(34, section.Width / 4), center.Y));
        dc.DrawLine(new Pen(navy, 1.2), center, new Point(center.X, center.Y - Math.Min(34, section.Height / 4)));
        DrawArrow(dc, new Point(center.X + Math.Min(34, section.Width / 4), center.Y), 0, new SolidColorBrush(Color.FromRgb(227, 27, 35)));
        DrawArrow(dc, new Point(center.X, center.Y - Math.Min(34, section.Height / 4)), -Math.PI / 2, navy);
        DrawText(dc, "x", 10, new SolidColorBrush(Color.FromRgb(227, 27, 35)), new Point(center.X + Math.Min(38, section.Width / 4) + 2, center.Y - 8), FontWeights.SemiBold);
        DrawText(dc, "y", 10, navy, new Point(center.X + 5, center.Y - Math.Min(42, section.Height / 4) - 8), FontWeights.SemiBold);
        dc.DrawLine(new Pen(text, 1), new Point(center.X - 5, center.Y), new Point(center.X + 5, center.Y));
        dc.DrawLine(new Pen(text, 1), new Point(center.X, center.Y - 5), new Point(center.X, center.Y + 5));

        foreach (var item in Rebars?.OfType<PreviewRebarPoint>() ?? [])
        {
            var pt = new Point(center.X + item.X * scale, center.Y - item.Y * scale);
            double r = Math.Max(3.0, item.Diameter * scale / 2.0);
            dc.DrawEllipse(darkNavy, new Pen(Brushes.White, 0.8), pt, r, r);
        }

        if (SectionShape == SectionShapeType.Circular)
        {
            DrawDimension(dc, new Point(section.Left, section.Bottom + 16), new Point(section.Right, section.Bottom + 16), $"D = {SectionWidth:0.###} {UnitText}", text);
        }
        else
        {
            DrawDimension(dc, new Point(section.Left, section.Bottom + 16), new Point(section.Right, section.Bottom + 16), $"b = {SectionWidth:0.###} {UnitText}", text);
            DrawDimension(dc, new Point(section.Left - 18, section.Bottom), new Point(section.Left - 18, section.Top), $"h = {SectionHeight:0.###} {UnitText}", text, vertical: true);
        }
    }

    private void DrawIrregularSection(DrawingContext dc)
    {
        var bpts = BoundaryPoints?.OfType<PreviewBoundaryPoint>().ToList();

        if (bpts == null || bpts.Count < 3) return;

        double topText = 50, leftDim = 50, bottomDim = 42, rightPad = 24;
        double minX = bpts.Min(p => p.X), maxX = bpts.Max(p => p.X);
        double minY = bpts.Min(p => p.Y), maxY = bpts.Max(p => p.Y);
        double bboxW = maxX - minX, bboxH = maxY - minY;
        if (bboxW <= 0 || bboxH <= 0) return;

        double scale = Math.Min((ActualWidth - leftDim - rightPad) / bboxW, (ActualHeight - topText - bottomDim) / bboxH);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        double sw = bboxW * scale, sh = bboxH * scale;
        double x0 = leftDim + (ActualWidth - leftDim - rightPad - sw) / 2.0;
        double y0 = topText + (ActualHeight - topText - bottomDim - sh) / 2.0;

        double ToScreenX(double x) => x0 + (x - minX) * scale;
        double ToScreenY(double y) => y0 + (maxY - y) * scale;

        var navy = new SolidColorBrush(Color.FromRgb(0, 75, 133));
        var darkNavy = new SolidColorBrush(Color.FromRgb(0, 58, 102));
        var grey = new SolidColorBrush(Color.FromRgb(123, 135, 148));
        var text = new SolidColorBrush(Color.FromRgb(31, 41, 51));
        var red = new SolidColorBrush(Color.FromRgb(227, 27, 35));

        DrawText(dc, SectionLabel, 13, text, new Point(14, 10), FontWeights.SemiBold);
        DrawText(dc, RebarLabel, 12, darkNavy, new Point(14, 28), FontWeights.Normal);
        DrawText(dc, CoverLabel, 12, grey, new Point(Math.Max(14, ActualWidth - 145), 28), FontWeights.Normal);

        var fill = new SolidColorBrush(Color.FromRgb(244, 247, 250));
        var geo = new StreamGeometry();
        using (var ctx = geo.Open())
        {
            ctx.BeginFigure(new Point(ToScreenX(bpts[0].X), ToScreenY(bpts[0].Y)), true, true);
            for (int i = 1; i < bpts.Count; i++)
                ctx.LineTo(new Point(ToScreenX(bpts[i].X), ToScreenY(bpts[i].Y)), true, false);
        }
        dc.DrawGeometry(fill, new Pen(navy, 2), geo);

        double bboxCx = (minX + maxX) / 2.0, bboxCy = (minY + maxY) / 2.0;
        var center = new Point(ToScreenX(bboxCx), ToScreenY(bboxCy));

        dc.DrawLine(new Pen(red, 1.2), center, new Point(center.X + Math.Min(34, sw / 4), center.Y));
        dc.DrawLine(new Pen(navy, 1.2), center, new Point(center.X, center.Y - Math.Min(34, sh / 4)));
        DrawArrow(dc, new Point(center.X + Math.Min(34, sw / 4), center.Y), 0, red);
        DrawArrow(dc, new Point(center.X, center.Y - Math.Min(34, sh / 4)), -Math.PI / 2, navy);
        DrawText(dc, "x", 10, red, new Point(center.X + Math.Min(38, sw / 4) + 2, center.Y - 8), FontWeights.SemiBold);
        DrawText(dc, "y", 10, navy, new Point(center.X + 5, center.Y - Math.Min(42, sh / 4) - 8), FontWeights.SemiBold);
        dc.DrawLine(new Pen(text, 1), new Point(center.X - 5, center.Y), new Point(center.X + 5, center.Y));
        dc.DrawLine(new Pen(text, 1), new Point(center.X, center.Y - 5), new Point(center.X, center.Y + 5));

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
                    dc.DrawGeometry(null, new Pen(grey, 1) { DashStyle = DashStyles.Dash }, coverGeo);
                    double labelX = coverPoly.Min(p => ToScreenX(p.X)) + 4;
                    double labelY = coverPoly.Min(p => ToScreenY(p.Y)) + 4;
                    DrawText(dc, "cover", 10, grey, new Point(labelX, labelY), FontWeights.Normal);
                }
            }
            catch { }
        }

        foreach (var item in Rebars?.OfType<PreviewRebarPoint>() ?? [])
        {
            var pt = new Point(center.X + item.X * scale, center.Y - item.Y * scale);
            double r = Math.Max(3.0, item.Diameter * scale / 2.0);
            dc.DrawEllipse(darkNavy, new Pen(Brushes.White, 0.8), pt, r, r);
        }
    }

    private static List<(double X, double Y)>? ComputeInsetPolygon(IReadOnlyList<(double X, double Y)> pts, double offset)
    {
        int n = pts.Count;
        if (n < 3 || offset <= 0) return null;
        double area2 = 0;
        for (int i = 0; i < n; i++) { var a = pts[i]; var b = pts[(i + 1) % n]; area2 += a.X * b.Y - b.X * a.Y; }
        bool cw = area2 < 0;
        var result = new List<(double X, double Y)>(n);
        for (int i = 0; i < n; i++)
        {
            var pP = pts[(i - 1 + n) % n]; var pI = pts[i]; var pN = pts[(i + 1) % n];
            double dx1 = pI.X - pP.X, dy1 = pI.Y - pP.Y, len1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
            if (len1 > 1e-9) { dx1 /= len1; dy1 /= len1; }
            double dx2 = pN.X - pI.X, dy2 = pN.Y - pI.Y, len2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            if (len2 > 1e-9) { dx2 /= len2; dy2 /= len2; }
            double nx1 = cw ? dy1 : -dy1, ny1 = cw ? -dx1 : dx1;
            double nx2 = cw ? dy2 : -dy2, ny2 = cw ? -dx2 : dx2;
            double p1x = pP.X + offset * nx1, p1y = pP.Y + offset * ny1;
            double p2x = pI.X + offset * nx2, p2y = pI.Y + offset * ny2;
            double cross = dx1 * dy2 - dy1 * dx2;
            if (Math.Abs(cross) < 1e-6)
                result.Add((pI.X + offset * nx1, pI.Y + offset * ny1));
            else
            {
                double t = ((p2x - p1x) * dy2 - (p2y - p1y) * dx2) / cross;
                result.Add((p1x + t * dx1, p1y + t * dy1));
            }
        }
        return result;
    }

    private string UnitText => UnitSystem == UnitSystem.Metric ? "mm" : "in";

    private static void DrawDimension(DrawingContext dc, Point a, Point b, string label, Brush brush, bool vertical = false)
    {
        var pen = new Pen(brush, 1);
        dc.DrawLine(pen, a, b);
        DrawArrow(dc, a, vertical ? Math.PI / 2 : Math.PI, brush);
        DrawArrow(dc, b, vertical ? -Math.PI / 2 : 0, brush);
        var labelPoint = vertical ? new Point(a.X - 42, (a.Y + b.Y) / 2 - 8) : new Point((a.X + b.X) / 2 - 36, a.Y + 4);
        DrawText(dc, label, 10, brush, labelPoint, FontWeights.Normal);
    }

    private static void DrawArrow(DrawingContext dc, Point tip, double angle, Brush brush)
    {
        double s = 5;
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
        var ft = new FormattedText(value, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal), size, brush, 1.25);
        dc.DrawText(ft, point);
    }
}

