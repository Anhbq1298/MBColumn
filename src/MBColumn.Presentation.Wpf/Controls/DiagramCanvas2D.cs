using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MBColumn.Application.DTOs;

namespace MBColumn.Presentation.Wpf.Controls;

public class DiagramCanvas2D : FrameworkElement
{
    public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(nameof(Points), typeof(IEnumerable<ControlPointDto>), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ReferenceLinesProperty = DependencyProperty.Register(nameof(ReferenceLines), typeof(IEnumerable<ChartReferenceLineDto>), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty XAxisLabelProperty = DependencyProperty.Register(nameof(XAxisLabel), typeof(string), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata("X", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty YAxisLabelProperty = DependencyProperty.Register(nameof(YAxisLabel), typeof(string), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata("Y", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowGridProperty = DependencyProperty.Register(nameof(ShowGrid), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowLabelsProperty = DependencyProperty.Register(nameof(ShowLabels), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowLegendProperty = DependencyProperty.Register(nameof(ShowLegend), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowDemandPointProperty = DependencyProperty.Register(nameof(ShowDemandPoint), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowGoverningPointProperty = DependencyProperty.Register(nameof(ShowGoverningPoint), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowReferenceLinesProperty = DependencyProperty.Register(nameof(ShowReferenceLines), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty RatioProperty = DependencyProperty.Register(nameof(Ratio), typeof(double), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ResetVersionProperty = DependencyProperty.Register(nameof(ResetVersion), typeof(int), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0, OnResetChanged));
    public static readonly DependencyProperty ShowNominalCurveProperty = DependencyProperty.Register(nameof(ShowNominalCurve), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowCapacityControlPointsProperty = DependencyProperty.Register(nameof(ShowCapacityControlPoints), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SelectedPointProperty = DependencyProperty.Register(nameof(SelectedPoint), typeof(ControlPointDto), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty BoundsOverrideProperty = DependencyProperty.Register(nameof(BoundsOverride), typeof(Rect?), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty UseEqualAspectProperty = DependencyProperty.Register(nameof(UseEqualAspect), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty InsetFigureProperty = DependencyProperty.Register(nameof(InsetFigure), typeof(PmChartInsetFigureDto), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

    private const double HitTolerance = 10.0;

    public DiagramCanvas2D()
    {
        Focusable = true;
        MouseMove += OnMouseMove;
        MouseLeave += (_, _) => ToolTip = null;
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        SizeChanged += (_, _) => InvalidateVisual();
    }

    public IEnumerable<ControlPointDto>? Points { get => (IEnumerable<ControlPointDto>?)GetValue(PointsProperty); set => SetValue(PointsProperty, value); }
    public IEnumerable<ChartReferenceLineDto>? ReferenceLines { get => (IEnumerable<ChartReferenceLineDto>?)GetValue(ReferenceLinesProperty); set => SetValue(ReferenceLinesProperty, value); }
    public string XAxisLabel { get => (string)GetValue(XAxisLabelProperty); set => SetValue(XAxisLabelProperty, value); }
    public string YAxisLabel { get => (string)GetValue(YAxisLabelProperty); set => SetValue(YAxisLabelProperty, value); }
    public bool ShowGrid { get => (bool)GetValue(ShowGridProperty); set => SetValue(ShowGridProperty, value); }
    public bool ShowLabels { get => (bool)GetValue(ShowLabelsProperty); set => SetValue(ShowLabelsProperty, value); }
    public bool ShowLegend { get => (bool)GetValue(ShowLegendProperty); set => SetValue(ShowLegendProperty, value); }
    public bool ShowDemandPoint { get => (bool)GetValue(ShowDemandPointProperty); set => SetValue(ShowDemandPointProperty, value); }
    public bool ShowGoverningPoint { get => (bool)GetValue(ShowGoverningPointProperty); set => SetValue(ShowGoverningPointProperty, value); }
    public bool ShowReferenceLines { get => (bool)GetValue(ShowReferenceLinesProperty); set => SetValue(ShowReferenceLinesProperty, value); }
    public double Ratio { get => (double)GetValue(RatioProperty); set => SetValue(RatioProperty, value); }
    public int ResetVersion { get => (int)GetValue(ResetVersionProperty); set => SetValue(ResetVersionProperty, value); }
    public bool ShowNominalCurve { get => (bool)GetValue(ShowNominalCurveProperty); set => SetValue(ShowNominalCurveProperty, value); }
    public bool ShowCapacityControlPoints { get => (bool)GetValue(ShowCapacityControlPointsProperty); set => SetValue(ShowCapacityControlPointsProperty, value); }
    public ControlPointDto? SelectedPoint { get => (ControlPointDto?)GetValue(SelectedPointProperty); set => SetValue(SelectedPointProperty, value); }
    public Rect? BoundsOverride { get => (Rect?)GetValue(BoundsOverrideProperty); set => SetValue(BoundsOverrideProperty, value); }
    public bool UseEqualAspect { get => (bool)GetValue(UseEqualAspectProperty); set => SetValue(UseEqualAspectProperty, value); }
    public PmChartInsetFigureDto? InsetFigure { get => (PmChartInsetFigureDto?)GetValue(InsetFigureProperty); set => SetValue(InsetFigureProperty, value); }

    public void ResetView() => InvalidateVisual();

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);
        dc.DrawRoundedRectangle(Brushes.White, new Pen(new SolidColorBrush(Color.FromRgb(214, 222, 230)), 1), new Rect(0, 0, ActualWidth, ActualHeight), 6, 6);
        var points = VisiblePoints((Points ?? []).Where(IsFinite)).ToList();
        var plot = new Rect(76, 62, Math.Max(10, ActualWidth - 116), Math.Max(10, ActualHeight - 126));
        dc.PushClip(new RectangleGeometry(new Rect(0, 0, ActualWidth, ActualHeight)));
        if (points.Count == 0)
        {
            DrawText(dc, "No chart data", 13, Brushes.Gray, new Point(20, 20), FontWeights.Normal);
            dc.Pop();
            return;
        }

        var transformPoints = ShowReferenceLines
            ? points.Concat(ReferenceLineBoundsPoints()).ToList()
            : points;
        var transform = ChartTransformHelper.AutoFit2D(transformPoints, plot, BoundsOverride, UseEqualAspect);
        AxisRenderer2D.Draw(dc, transform, XAxisLabel, YAxisLabel, ShowGrid);
        DrawCapacity(dc, transform, points);
        DrawCapacityControlPoints(dc, transform, points);
        DrawReferences(dc, transform, points);
        DrawConstructionReferenceLines(dc, transform);
        DrawSpecialPoints(dc, transform, points);
        DrawSelectedPoint(dc, transform);
        DrawInsetFigure(dc, plot);
        if (ShowLegend)
        {
            LegendRenderer.Draw(dc, new Point(Math.Max(plot.Left + 12, plot.Right - 146), 16), ShowNominalCurve);
        }
        dc.Pop();
    }

    private void DrawCapacity(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> points)
    {
        var activeDesignPen = new Pen(new SolidColorBrush(Color.FromArgb(120, 0, 75, 133)), 2.2);
        var reducedDesignPen = new Pen(new SolidColorBrush(Color.FromRgb(0, 75, 133)), 1.35) { DashStyle = DashStyles.Dash };
        var nominalPen = new Pen(new SolidColorBrush(Color.FromRgb(200, 40, 40)), 1.4) { DashStyle = DashStyles.Dash };
        double? designCompressionCap = DesignCompressionCap(points);

        foreach (var group in points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).GroupBy(p => p.GroupKey))
        {
            var ordered = group.ToList();
            if (ordered.Count < 2) continue;

            bool isNominal = ordered[0].IsNominal;
            if (isNominal && !ShowNominalCurve) continue;

            var geo = BuildPolylineGeometry(transform, ordered);
            if (isNominal)
            {
                dc.DrawGeometry(null, nominalPen, geo);
                continue;
            }

            // Draw the uncapped phi-reduced interaction curve as the dashed
            // continuation. The ACI compression cap is a rendering boundary,
            // not a geometry vertex or roof segment.
            dc.DrawGeometry(null, reducedDesignPen, geo);
            DrawBelowCapSegments(dc, transform, ordered, designCompressionCap, activeDesignPen);
        }
    }

    private static double? DesignCompressionCap(IReadOnlyList<ControlPointDto> points)
    {
        var cap = points.FirstOrDefault(p => p.IsReference && p.Label.Equals("Pmax", StringComparison.OrdinalIgnoreCase));
        return cap is null ? null : cap.Y;
    }

    private static void DrawBelowCapSegments(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered, double? cap, Pen pen)
    {
        if (cap is null)
        {
            dc.DrawGeometry(null, pen, BuildPolylineGeometry(transform, ordered));
            return;
        }

        var clipped = ClipPolylineBelowY(ordered, cap.Value);
        foreach (var segment in clipped.Where(s => s.Count > 1))
        {
            dc.DrawGeometry(null, pen, BuildOpenPolylineGeometry(transform, segment));
        }
    }

    private static IReadOnlyList<IReadOnlyList<ControlPointDto>> ClipPolylineBelowY(IReadOnlyList<ControlPointDto> ordered, double cap)
    {
        var segments = new List<IReadOnlyList<ControlPointDto>>();
        var current = new List<ControlPointDto>();

        for (int i = 0; i < ordered.Count; i++)
        {
            var a = ordered[i];
            var b = ordered[(i + 1) % ordered.Count];
            bool aInside = a.Y <= cap;
            bool bInside = b.Y <= cap;

            if (aInside && current.Count == 0)
            {
                current.Add(a);
            }

            if (aInside && bInside)
            {
                if (!ReferenceEquals(b, ordered[0]) || i < ordered.Count - 1)
                {
                    current.Add(b);
                }
            }
            else if (aInside && !bInside)
            {
                current.Add(InterpolateAtY(a, b, cap));
                AddSegment(segments, current);
                current = [];
            }
            else if (!aInside && bInside)
            {
                current = [InterpolateAtY(a, b, cap), b];
            }
        }

        AddSegment(segments, current);
        return segments;
    }

    private static void AddSegment(List<IReadOnlyList<ControlPointDto>> segments, List<ControlPointDto> current)
    {
        if (current.Count > 1)
        {
            segments.Add(current);
        }
    }

    private static ControlPointDto InterpolateAtY(ControlPointDto a, ControlPointDto b, double y)
    {
        double denominator = b.Y - a.Y;
        double t = Math.Abs(denominator) < 1e-12 ? 0.0 : (y - a.Y) / denominator;
        t = Math.Clamp(t, 0.0, 1.0);
        return a with
        {
            X = Lerp(a.X, b.X, t),
            Y = y,
            Z = Lerp(a.Z, b.Z, t),
            P = y,
            Mx = Lerp(a.Mx, b.Mx, t),
            My = Lerp(a.My, b.My, t),
            Phi = Lerp(a.Phi, b.Phi, t),
            ThetaDegrees = Lerp(a.ThetaDegrees, b.ThetaDegrees, t),
            NeutralAxisDepth = Lerp(a.NeutralAxisDepth, b.NeutralAxisDepth, t)
        };
    }

    private static StreamGeometry BuildPolylineGeometry(ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered)
    {
        var geo = new StreamGeometry();
        using (var ctx = geo.Open())
        {
            ctx.BeginFigure(transform.ToScreen(ordered[0].X, ordered[0].Y), false, false);
            foreach (var p in ordered.Skip(1))
            {
                ctx.LineTo(transform.ToScreen(p.X, p.Y), true, false);
            }
            // Close the loop: PM envelopes and MM diagrams are closed polylines
            if (ordered.Count > 2)
            {
                ctx.LineTo(transform.ToScreen(ordered[0].X, ordered[0].Y), true, false);
            }
        }
        geo.Freeze();
        return geo;
    }

    private static StreamGeometry BuildOpenPolylineGeometry(ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered)
    {
        var geo = new StreamGeometry();
        using (var ctx = geo.Open())
        {
            ctx.BeginFigure(transform.ToScreen(ordered[0].X, ordered[0].Y), false, false);
            foreach (var p in ordered.Skip(1))
            {
                ctx.LineTo(transform.ToScreen(p.X, p.Y), true, false);
            }
        }
        geo.Freeze();
        return geo;
    }

    private void DrawCapacityControlPoints(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> points)
    {
        if (!ShowCapacityControlPoints) return;

        var designBrush = new SolidColorBrush(Color.FromRgb(0, 75, 133));
        var nominalBrush = new SolidColorBrush(Color.FromRgb(200, 40, 40));
        foreach (var point in points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && (!p.IsNominal || ShowNominalCurve)))
        {
            var brush = point.IsNominal ? nominalBrush : designBrush;
            dc.DrawEllipse(Brushes.White, new Pen(brush, 0.8), transform.ToScreen(point.X, point.Y), 2.2, 2.2);
        }
    }

    private void DrawReferences(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> points)
    {
        if (!ShowReferenceLines) return;
        foreach (var p in points.Where(p => p.IsReference))
        {
            var pen = ReferencePen(p.Label);
            var a = transform.ToScreen(transform.MinX, p.Y);
            var b = transform.ToScreen(transform.MaxX, p.Y);
            dc.DrawLine(pen, a, b);
            var label = ReferenceDisplayLabel(p.Label);
            if (ShowLabels && !string.IsNullOrWhiteSpace(label))
            {
                DrawText(dc, label, 10.5, pen.Brush, new Point(b.X - 72, b.Y - 16), FontWeights.SemiBold);
            }
        }
    }

    private static Pen ReferencePen(string label)
    {
        var color = label.Equals("Pn,max", StringComparison.OrdinalIgnoreCase)
            ? Color.FromRgb(200, 40, 40)
            : Color.FromRgb(48, 103, 190);
        return new Pen(new SolidColorBrush(color), 1) { DashStyle = DashStyles.Dash };
    }

    private static string ReferenceDisplayLabel(string label)
        => label.Equals("Pmax", StringComparison.OrdinalIgnoreCase)
            ? "(\u03c6Pn,max)"
            : label.Equals("Pn,max", StringComparison.OrdinalIgnoreCase)
                ? "(Pn,max)"
                : label.Equals("Pmin", StringComparison.OrdinalIgnoreCase)
                    ? "(Pmin)"
                    : "";

    private void DrawConstructionReferenceLines(DrawingContext dc, ChartTransformHelper transform)
    {
        if (!ShowReferenceLines) return;
        var pen = new Pen(new SolidColorBrush(Color.FromRgb(48, 103, 190)), 1) { DashStyle = DashStyles.Dash };
        foreach (var line in ReferenceLines ?? [])
        {
            var a = transform.ToScreen(line.StartX, line.StartY);
            var b = transform.ToScreen(line.EndX, line.EndY);
            if (IsFinite(a) && IsFinite(b))
            {
                dc.DrawLine(pen, a, b);
            }
        }
    }

    private IEnumerable<ControlPointDto> ReferenceLineBoundsPoints()
    {
        foreach (var line in ReferenceLines ?? [])
        {
            yield return new ControlPointDto(MBColumn.Domain.Enums.DiagramType.PM, line.StartX, line.StartY, line.StartY, line.StartY, 0, 0, 1, 0, 0, line.Label, "ReferenceLine", false, false, true, false);
            yield return new ControlPointDto(MBColumn.Domain.Enums.DiagramType.PM, line.EndX, line.EndY, line.EndY, line.EndY, 0, 0, 1, 0, 0, line.Label, "ReferenceLine", false, false, true, false);
        }
    }

    private void DrawSpecialPoints(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> points)
    {
        foreach (var p in points.Where(p => ShowDemandPoint && p.IsDemand))
        {
            var color = Color.FromRgb(227, 27, 35);
            var brush = new SolidColorBrush(color);
            var pt = transform.ToScreen(p.X, p.Y);
            dc.DrawEllipse(brush, new Pen(Brushes.White, 1), pt, 5, 5);
            if (ShowLabels)
            {
                DrawText(dc, p.Label, 11, brush, new Point(pt.X + 7, pt.Y - 15), FontWeights.SemiBold);
            }
        }
        foreach (var p in points.Where(p => p.GroupKey == "LabeledPoint"))
        {
            var brush = new SolidColorBrush(Color.FromRgb(48, 63, 159)); // Indigo 700
            var pt = transform.ToScreen(p.X, p.Y);
            dc.DrawEllipse(Brushes.White, new Pen(brush, 1.5), pt, 4.5, 4.5);
            if (ShowLabels)
            {
                DrawText(dc, $"@ {p.Label}", 10.5, brush, new Point(pt.X + 8, pt.Y - 12), FontWeights.Normal);
            }
        }
    }

    private void DrawSelectedPoint(DrawingContext dc, ChartTransformHelper transform)
    {
        if (SelectedPoint is null) return;
        var sp = SelectedPoint;
        var pt = transform.ToScreen(sp.X, sp.Y);
        var fill = new SolidColorBrush(Color.FromRgb(227, 27, 35));
        var stroke = new Pen(new SolidColorBrush(Color.FromRgb(31, 41, 51)), 1.5);
        dc.DrawEllipse(fill, stroke, pt, 6.5, 6.5);
    }

    private void DrawInsetFigure(DrawingContext dc, Rect plot)
    {
        var inset = InsetFigure;
        if (inset is null || inset.SectionBoundaryPoints.Count < 3) return;

        double side = Math.Clamp(Math.Min(ActualWidth, ActualHeight) * 0.21, 108.0, 154.0);
        side = Math.Min(side, Math.Max(80.0, Math.Min(plot.Width * 0.28, plot.Height * 0.34)));
        var bounds = new Rect(plot.Left + 12, Math.Max(plot.Top + 54, plot.Bottom - side - 12), side, side);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromArgb(232, 255, 255, 255)), new Pen(new SolidColorBrush(Color.FromArgb(185, 148, 163, 184)), 0.8), bounds, 6, 6);

        var sectionBounds = GetInsetContentBounds(inset.SectionBoundaryPoints);
        if (sectionBounds.Width <= 0 || sectionBounds.Height <= 0) return;

        double legendHeight = 38.0;
        var sketchBounds = new Rect(bounds.Left, bounds.Top, bounds.Width, Math.Max(40.0, bounds.Height - legendHeight));
        double padding = 18.0;
        double scale = Math.Min((sketchBounds.Width - 2 * padding) / sectionBounds.Width, (sketchBounds.Height - 2 * padding) / sectionBounds.Height);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0) return;

        var center = new Point(sketchBounds.Left + sketchBounds.Width / 2.0, sketchBounds.Top + sketchBounds.Height / 2.0);
        Point Map(InsetPointDto p) => new(center.X + p.X * scale, center.Y - p.Y * scale);

        var sectionGeometry = BuildPolygonGeometry(inset.SectionBoundaryPoints, Map);
        var coverGeometry = inset.CoverBoundaryPoints.Count >= 3 ? BuildPolygonGeometry(inset.CoverBoundaryPoints, Map) : null;
        var compressionGeometry = inset.CompressionZonePolygon.Count >= 3 ? BuildPolygonGeometry(inset.CompressionZonePolygon, Map) : null;
        var tensionGeometry = inset.TensionZonePolygon.Count >= 3 ? BuildPolygonGeometry(inset.TensionZonePolygon, Map) : null;
        var sectionPen = new Pen(new SolidColorBrush(Color.FromRgb(45, 55, 72)), 1.2);
        var coverPen = new Pen(new SolidColorBrush(Color.FromArgb(170, 96, 111, 128)), 0.8) { DashStyle = DashStyles.Dash };
        var axisPen = new Pen(new SolidColorBrush(Color.FromArgb(210, 39, 94, 145)), 1.0);
        var thetaBrush = new SolidColorBrush(Color.FromRgb(196, 87, 33));
        var thetaPen = new Pen(thetaBrush, 1.3);
        var neutralAxisPen = new Pen(new SolidColorBrush(Color.FromRgb(31, 41, 55)), 1.2) { DashStyle = DashStyles.Dash };
        var compressionFill = new SolidColorBrush(Color.FromArgb(92, 245, 158, 11));
        var tensionFill = new SolidColorBrush(Color.FromArgb(58, 100, 116, 139));

        if (tensionGeometry is not null)
        {
            dc.DrawGeometry(tensionFill, null, tensionGeometry);
        }

        if (compressionGeometry is not null)
        {
            dc.DrawGeometry(compressionFill, null, compressionGeometry);
        }

        dc.DrawGeometry(new SolidColorBrush(Color.FromArgb(35, 100, 116, 139)), sectionPen, sectionGeometry);
        if (coverGeometry is not null)
        {
            dc.DrawGeometry(null, coverPen, coverGeometry);
        }

        DrawInsetLine(dc, inset.XAxisLine, Map, axisPen, arrow: true);
        DrawInsetLine(dc, inset.YAxisLine, Map, axisPen, arrow: true);
        DrawText(dc, "x", 9, axisPen.Brush, Offset(Map(inset.XAxisLine.End), 3, -10), FontWeights.SemiBold);
        DrawText(dc, "y", 9, axisPen.Brush, Offset(Map(inset.YAxisLine.End), 3, -10), FontWeights.SemiBold);

        double thetaRadius = Math.Max(Math.Min(sectionBounds.Width, sectionBounds.Height) * 0.18, 1.0);
        DrawThetaDimension(dc, Map, inset.ThetaDegrees, thetaRadius, thetaBrush);
        DrawInsetLine(dc, inset.ThetaLine, Map, thetaPen, arrow: true);

        if (inset.NeutralAxisLine is not null)
        {
            DrawInsetLine(dc, inset.NeutralAxisLine, Map, neutralAxisPen, arrow: false);
            DrawText(dc, "NA", 8.5, neutralAxisPen.Brush, Offset(Map(inset.NeutralAxisLine.End), -18, -11), FontWeights.SemiBold);
        }

        var barBrush = new SolidColorBrush(Color.FromRgb(0, 75, 133));
        foreach (var bar in inset.RebarPoints)
        {
            var pt = Map(bar);
            dc.DrawEllipse(barBrush, new Pen(Brushes.White, 0.7), pt, 2.7, 2.7);
        }

        string caption = string.IsNullOrWhiteSpace(inset.SelectedLoadCaseName)
            ? $"Î¸ = {inset.ThetaDegrees:0.#}Â°"
            : $"{inset.SelectedLoadCaseName}  Î¸ = {inset.ThetaDegrees:0.#}Â°";
        DrawInsetLegend(dc, bounds, caption, compressionFill, tensionFill);
    }

    private static void DrawInsetLegend(DrawingContext dc, Rect bounds, string caption, Brush compressionFill, Brush tensionFill)
    {
        var textBrush = new SolidColorBrush(Color.FromRgb(71, 85, 105));
        double left = bounds.Left + 6.0;
        double y = bounds.Bottom - 35.0;
        DrawText(dc, caption, 7.2, textBrush, new Point(left, y), FontWeights.Normal);
        DrawLegendItem(dc, new Point(left, y + 13.0), compressionFill, "Concrete in compression", textBrush);
        DrawLegendItem(dc, new Point(left, y + 25.0), tensionFill, "Concrete in tension - ignored", textBrush);
    }

    private static void DrawLegendItem(DrawingContext dc, Point origin, Brush fill, string label, Brush textBrush)
    {
        var swatch = new Rect(origin.X, origin.Y + 2.0, 8.0, 6.0);
        dc.DrawRectangle(fill, new Pen(new SolidColorBrush(Color.FromArgb(160, 71, 85, 105)), 0.5), swatch);
        DrawText(dc, label, 6.4, textBrush, new Point(origin.X + 12.0, origin.Y - 1.0), FontWeights.Normal);
    }

    private static Rect GetInsetContentBounds(IReadOnlyList<InsetPointDto> points)
    {
        double minX = points.Min(p => p.X);
        double maxX = points.Max(p => p.X);
        double minY = points.Min(p => p.Y);
        double maxY = points.Max(p => p.Y);
        return new Rect(new Point(minX, minY), new Point(maxX, maxY));
    }

    private static Geometry BuildPolygonGeometry(IReadOnlyList<InsetPointDto> points, Func<InsetPointDto, Point> map)
    {
        var geometry = new StreamGeometry();
        using var ctx = geometry.Open();
        ctx.BeginFigure(map(points[0]), true, true);
        foreach (var point in points.Skip(1))
        {
            ctx.LineTo(map(point), true, false);
        }

        geometry.Freeze();
        return geometry;
    }

    private static void DrawInsetLine(DrawingContext dc, InsetLineDto line, Func<InsetPointDto, Point> map, Pen pen, bool arrow)
    {
        var a = map(line.Start);
        var b = map(line.End);
        dc.DrawLine(pen, a, b);
        if (arrow)
        {
            DrawArrow(dc, b, Math.Atan2(b.Y - a.Y, b.X - a.X), pen.Brush);
        }
    }

    private static void DrawThetaDimension(DrawingContext dc, Func<InsetPointDto, Point> map, double thetaDegrees, double radius, Brush brush)
    {
        double theta = NormalizePositiveAngle(thetaDegrees);
        var center = map(new InsetPointDto(0, 0));
        var start = map(new InsetPointDto(radius, 0));
        double screenRadius = Math.Max(2.0, (start - center).Length);

        if (theta > 0.5)
        {
            double arcTheta = Math.Min(theta, 359.5);
            double radians = arcTheta * Math.PI / 180.0;
            var end = map(new InsetPointDto(radius * Math.Cos(radians), radius * Math.Sin(radians)));
            var pen = new Pen(brush, 0.9);
            var geometry = new StreamGeometry();
            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(start, false, false);
                ctx.ArcTo(end, new Size(screenRadius, screenRadius), 0.0, arcTheta > 180.0, SweepDirection.Counterclockwise, true, false);
            }

            dc.DrawGeometry(null, pen, geometry);
            double tangentAngle = Math.Atan2(-Math.Cos(radians), -Math.Sin(radians));
            DrawArrow(dc, end, tangentAngle, brush);
        }

        double labelAngle = (theta > 0.5 ? Math.Min(theta, 359.5) / 2.0 : 12.0) * Math.PI / 180.0;
        var labelPoint = map(new InsetPointDto(radius * 1.22 * Math.Cos(labelAngle), radius * 1.22 * Math.Sin(labelAngle)));
        DrawText(dc, "Î¸", 8.0, brush, Offset(labelPoint, 3, -9), FontWeights.SemiBold);
    }

    private static double NormalizePositiveAngle(double angle)
    {
        if (double.IsNaN(angle) || double.IsInfinity(angle)) return 0.0;
        var normalized = angle % 360.0;
        return normalized < 0 ? normalized + 360.0 : normalized;
    }

    private static void DrawArrow(DrawingContext dc, Point tip, double angle, Brush brush)
    {
        double size = 5.0;
        var p1 = new Point(tip.X - Math.Cos(angle - 0.48) * size, tip.Y - Math.Sin(angle - 0.48) * size);
        var p2 = new Point(tip.X - Math.Cos(angle + 0.48) * size, tip.Y - Math.Sin(angle + 0.48) * size);
        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(tip, true, true);
        ctx.LineTo(p1, true, false);
        ctx.LineTo(p2, true, false);
        dc.DrawGeometry(brush, null, geo);
    }

    private static Point Offset(Point point, double dx, double dy) => new(point.X + dx, point.Y + dy);

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var position = e.GetPosition(this);
        var hitResult = HitTestPoint(position);
        SelectedPoint = hitResult;
        InvalidateVisual();
    }

    private ControlPointDto? HitTestPoint(Point position)
    {
        var points = HitTestablePoints().ToList();
        if (points.Count == 0) return null;

        var plot = new Rect(76, 62, Math.Max(10, ActualWidth - 116), Math.Max(10, ActualHeight - 126));
        var transform = ChartTransformHelper.AutoFit2D(VisiblePoints(Points ?? []).Where(IsFinite), plot, BoundsOverride, UseEqualAspect);

        var nearest = points
            .Select(p => new { Point = p, Screen = transform.ToScreen(p.X, p.Y) })
            .Select(x => new { x.Point, Distance = (x.Screen - position).Length })
            .Where(x => x.Distance < HitTolerance)
            .OrderBy(x => x.Distance)
            .FirstOrDefault();

        return nearest?.Point;
    }

    private IEnumerable<ControlPointDto> HitTestablePoints()
    {
        return VisiblePoints(Points ?? []).Where(p =>
            (!p.IsReference || p.GroupKey == "LabeledPoint") &&
            (p.IsDemand || (!p.IsDemand && !p.IsGoverning)));
    }

    private void OnMouseMove(object sender, MouseEventArgs e) => UpdateTooltip(e.GetPosition(this));

    private void UpdateTooltip(Point position)
    {
        var points = VisiblePoints(Points ?? []).Where(p => p.IsDemand || ((!p.IsReference || p.GroupKey == "LabeledPoint") && !p.IsDemand && !p.IsGoverning)).ToList();
        if (points.Count == 0) return;
        var plot = new Rect(76, 62, Math.Max(10, ActualWidth - 116), Math.Max(10, ActualHeight - 126));
        var transform = ChartTransformHelper.AutoFit2D(points, plot, BoundsOverride, UseEqualAspect);
        var nearest = points.Select(p => new { Point = p, Screen = transform.ToScreen(p.X, p.Y) })
            .Select(x => new { x.Point, Distance = (x.Screen - position).Length })
            .Where(x => x.Distance < HitTolerance)
            .OrderBy(x => x.Distance)
            .FirstOrDefault();
        ToolTip = nearest is null ? null : TooltipRenderer.Build(nearest.Point, Ratio);
    }

    private static bool IsFinite(ControlPointDto p) => !double.IsNaN(p.X) && !double.IsInfinity(p.X) && !double.IsNaN(p.Y) && !double.IsInfinity(p.Y);
    private static bool IsFinite(Point p) => !double.IsNaN(p.X) && !double.IsInfinity(p.X) && !double.IsNaN(p.Y) && !double.IsInfinity(p.Y);
    private static double Lerp(double a, double b, double t) => a + (b - a) * t;

    private IEnumerable<ControlPointDto> VisiblePoints(IEnumerable<ControlPointDto> source)
        => source.Where(p =>
            (!p.IsReference || ShowReferenceLines) &&
            (!p.IsDemand || ShowDemandPoint) &&
            !p.IsGoverning &&
            (!p.IsNominal || ShowNominalCurve));

    private static void DrawText(DrawingContext dc, string text, double size, Brush brush, Point point, FontWeight weight)
    {
        var ft = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal), size + 1, brush, 1.25);
        dc.DrawText(ft, point);
    }

    private static void OnResetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DiagramCanvas2D chart) chart.ResetView();
    }
}

