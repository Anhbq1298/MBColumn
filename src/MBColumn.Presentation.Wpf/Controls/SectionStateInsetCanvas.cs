using System.Globalization;
using System.Windows;
using System.Windows.Media;
using MBColumn.Application.DTOs;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Sidebar panel that renders a PmChartInsetFigureDto (section with NA, compression/tension zones).
/// Fills its available area; legend sits at the bottom.
/// </summary>
public sealed class SectionStateInsetCanvas : FrameworkElement
{
    public static readonly DependencyProperty InsetFigureProperty = DependencyProperty.Register(
        nameof(InsetFigure), typeof(PmChartInsetFigureDto), typeof(SectionStateInsetCanvas),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

    public PmChartInsetFigureDto? InsetFigure
    {
        get => (PmChartInsetFigureDto?)GetValue(InsetFigureProperty);
        set => SetValue(InsetFigureProperty, value);
    }

    private const double LegendHeight = 0.0;
    private const double Padding = 28.0;

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        var borderBrush = new SolidColorBrush(Color.FromRgb(214, 222, 230));
        dc.DrawRoundedRectangle(Brushes.White, new Pen(borderBrush, 1), new Rect(0, 0, ActualWidth, ActualHeight), 6, 6);

        var inset = InsetFigure;
        if (inset is null || inset.SectionBoundaryPoints.Count < 3)
        {
            DrawText(dc, "No section data", 11, Brushes.Gray, new Point(12, 12), FontWeights.Normal);
            return;
        }

        var sectionBounds = GetContentBounds(GetDrawableBoundsPoints(inset));
        if (sectionBounds.Width <= 0 || sectionBounds.Height <= 0) return;

        double sketchHeight = Math.Max(40.0, ActualHeight - LegendHeight);
        double availW = ActualWidth - 2 * Padding;
        double availH = sketchHeight - 2 * Padding;
        double scale = Math.Min(availW / sectionBounds.Width, availH / sectionBounds.Height);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        var contentCenter = new InsetPointDto(
            sectionBounds.X + sectionBounds.Width / 2.0,
            sectionBounds.Y + sectionBounds.Height / 2.0);
        var center = new Point(ActualWidth / 2.0, Padding + (sketchHeight - 2 * Padding) / 2.0);
        Point Map(InsetPointDto p) => new(center.X + (p.X - contentCenter.X) * scale, center.Y - (p.Y - contentCenter.Y) * scale);

        dc.PushClip(new RectangleGeometry(new Rect(0, 0, ActualWidth, ActualHeight), 6, 6));

        var sectionGeo  = BuildPolygonGeometry(inset.SectionBoundaryPoints, Map);
        var coverGeo    = inset.CoverBoundaryPoints.Count >= 3 ? BuildPolygonGeometry(inset.CoverBoundaryPoints, Map) : null;
        var compGeo     = inset.CompressionZonePolygon.Count >= 3 ? BuildPolygonGeometry(inset.CompressionZonePolygon, Map) : null;
        var tensionGeo  = inset.TensionZonePolygon.Count >= 3 ? BuildPolygonGeometry(inset.TensionZonePolygon, Map) : null;

        var sectionPen      = new Pen(new SolidColorBrush(Color.FromRgb(45, 55, 72)), 1.2);
        var coverPen        = new Pen(new SolidColorBrush(Color.FromArgb(170, 96, 111, 128)), 0.8) { DashStyle = DashStyles.Dash };
        var axisPen         = new Pen(new SolidColorBrush(Color.FromArgb(210, 39, 94, 145)), 1.0);
        var thetaBrush      = new SolidColorBrush(Color.FromRgb(196, 87, 33));
        var thetaPen        = new Pen(thetaBrush, 1.3);
        var naPen           = new Pen(new SolidColorBrush(Color.FromRgb(31, 41, 55)), 1.2) { DashStyle = DashStyles.Dash };
        var compressionFill = new SolidColorBrush(Color.FromArgb(92, 245, 158, 11));
        var tensionFill     = new SolidColorBrush(Color.FromArgb(58, 100, 116, 139));

        if (tensionGeo is not null)
            dc.DrawGeometry(tensionFill, null, tensionGeo);
        if (compGeo is not null)
            dc.DrawGeometry(compressionFill, null, compGeo);

        dc.DrawGeometry(new SolidColorBrush(Color.FromArgb(35, 100, 116, 139)), sectionPen, sectionGeo);
        if (coverGeo is not null)
            dc.DrawGeometry(null, coverPen, coverGeo);

        DrawInsetLine(dc, inset.XAxisLine, Map, axisPen, arrow: true);
        DrawInsetLine(dc, inset.YAxisLine, Map, axisPen, arrow: true);
        DrawText(dc, "x", 8, axisPen.Brush, Offset(Map(inset.XAxisLine.End),  3, -10), FontWeights.SemiBold);
        DrawText(dc, "y", 8, axisPen.Brush, Offset(Map(inset.YAxisLine.End),  3, -10), FontWeights.SemiBold);

        DrawInsetLine(dc, inset.ThetaLine, Map, thetaPen, arrow: true);

        double thetaRadius = Math.Max(Math.Min(sectionBounds.Width, sectionBounds.Height) * 0.18, 1.0);
        DrawThetaArc(dc, Map, inset.ThetaDegrees, thetaRadius, thetaBrush);

        if (inset.NeutralAxisLine is not null)
        {
            DrawInsetLine(dc, inset.NeutralAxisLine, Map, naPen, arrow: false);
            DrawText(dc, "NA", 8, naPen.Brush, Offset(Map(inset.NeutralAxisLine.End), -18, -11), FontWeights.SemiBold);
        }

        var barBrush = new SolidColorBrush(Color.FromRgb(0, 75, 133));
        foreach (var bar in inset.RebarPoints)
        {
            var pt = Map(bar);
            dc.DrawEllipse(barBrush, new Pen(Brushes.White, 0.7), pt, 2.7, 2.7);
        }

        dc.Pop();
    }



    private static IReadOnlyList<InsetPointDto> GetDrawableBoundsPoints(PmChartInsetFigureDto inset)
    {
        var points = new List<InsetPointDto>(inset.SectionBoundaryPoints);
        points.AddRange(inset.CoverBoundaryPoints);
        points.AddRange(inset.RebarPoints);
        points.Add(inset.XAxisLine.Start);
        points.Add(inset.XAxisLine.End);
        points.Add(inset.YAxisLine.Start);
        points.Add(inset.YAxisLine.End);
        points.Add(inset.ThetaLine.Start);
        points.Add(inset.ThetaLine.End);

        if (inset.NeutralAxisLine is not null)
        {
            points.Add(inset.NeutralAxisLine.Start);
            points.Add(inset.NeutralAxisLine.End);
        }

        return points;
    }

    private static Rect GetContentBounds(IReadOnlyList<InsetPointDto> points)
    {
        double minX = points.Min(p => p.X), maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y), maxY = points.Max(p => p.Y);
        return new Rect(new Point(minX, minY), new Point(maxX, maxY));
    }

    private static Geometry BuildPolygonGeometry(IReadOnlyList<InsetPointDto> points, Func<InsetPointDto, Point> map)
    {
        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(map(points[0]), true, true);
        foreach (var p in points.Skip(1))
            ctx.LineTo(map(p), true, false);
        geo.Freeze();
        return geo;
    }

    private static void DrawInsetLine(DrawingContext dc, InsetLineDto line, Func<InsetPointDto, Point> map, Pen pen, bool arrow)
    {
        var a = map(line.Start);
        var b = map(line.End);
        dc.DrawLine(pen, a, b);
        if (arrow)
            DrawArrow(dc, b, Math.Atan2(b.Y - a.Y, b.X - a.X), pen.Brush);
    }

    private static void DrawThetaArc(DrawingContext dc, Func<InsetPointDto, Point> map, double thetaDegrees, double radius, Brush brush)
    {
        double theta = ((thetaDegrees % 360) + 360) % 360;
        var screenCenter = map(new InsetPointDto(0, 0));
        var screenStart  = map(new InsetPointDto(radius, 0));
        double screenRadius = Math.Max(2.0, (screenStart - screenCenter).Length);

        if (theta > 0.5)
        {
            double arcTheta = Math.Min(theta, 359.5);
            double radians  = arcTheta * Math.PI / 180.0;
            var end = map(new InsetPointDto(radius * Math.Cos(radians), radius * Math.Sin(radians)));
            var arcGeo = new StreamGeometry();
            using (var ctx = arcGeo.Open())
            {
                ctx.BeginFigure(screenStart, false, false);
                ctx.ArcTo(end, new Size(screenRadius, screenRadius), 0.0, arcTheta > 180.0, SweepDirection.Counterclockwise, true, false);
            }
            dc.DrawGeometry(null, new Pen(brush, 0.9), arcGeo);
            double tangent = Math.Atan2(-Math.Cos(radians), -Math.Sin(radians));
            DrawArrow(dc, end, tangent, brush);
        }

        double labelAngle = (theta > 0.5 ? Math.Min(theta, 359.5) / 2.0 : 12.0) * Math.PI / 180.0;
        var labelPt = map(new InsetPointDto(radius * 1.22 * Math.Cos(labelAngle), radius * 1.22 * Math.Sin(labelAngle)));
        DrawText(dc, "θ", 8.0, brush, Offset(labelPt, 3, -9), FontWeights.SemiBold);
    }

    private static void DrawArrow(DrawingContext dc, Point tip, double angle, Brush brush)
    {
        const double s = 5.0;
        var p1 = new Point(tip.X - Math.Cos(angle - 0.48) * s, tip.Y - Math.Sin(angle - 0.48) * s);
        var p2 = new Point(tip.X - Math.Cos(angle + 0.48) * s, tip.Y - Math.Sin(angle + 0.48) * s);
        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(tip, true, true);
        ctx.LineTo(p1, true, false);
        ctx.LineTo(p2, true, false);
        dc.DrawGeometry(brush, null, geo);
    }

    private static Point Offset(Point p, double dx, double dy) => new(p.X + dx, p.Y + dy);

    private static void DrawText(DrawingContext dc, string text, double size, Brush brush, Point point, FontWeight weight)
    {
        if (string.IsNullOrEmpty(text)) return;
        var ft = new FormattedText(text, CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal),
            size + 1, brush, 1.25);
        dc.DrawText(ft, point);
    }
}
