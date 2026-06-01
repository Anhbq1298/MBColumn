using System.Globalization;
using System.Linq;
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
    public static readonly DependencyProperty ShowDemandPointProperty = DependencyProperty.Register(nameof(ShowDemandPoint), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowGoverningPointProperty = DependencyProperty.Register(nameof(ShowGoverningPoint), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowReferenceLinesProperty = DependencyProperty.Register(nameof(ShowReferenceLines), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty RatioProperty = DependencyProperty.Register(nameof(Ratio), typeof(double), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ResetVersionProperty = DependencyProperty.Register(nameof(ResetVersion), typeof(int), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0, OnResetChanged));
    public static readonly DependencyProperty ShowNominalCurveProperty = DependencyProperty.Register(nameof(ShowNominalCurve), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowCapacityControlPointsProperty = DependencyProperty.Register(nameof(ShowCapacityControlPoints), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowInteractionHintProperty = DependencyProperty.Register(nameof(ShowInteractionHint), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SelectedPointProperty = DependencyProperty.Register(nameof(SelectedPoint), typeof(ControlPointDto), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public static readonly DependencyProperty BoundsOverrideProperty = DependencyProperty.Register(nameof(BoundsOverride), typeof(Rect?), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty UseEqualAspectProperty = DependencyProperty.Register(nameof(UseEqualAspect), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty InsetFigureProperty = DependencyProperty.Register(nameof(InsetFigure), typeof(PmChartInsetFigureDto), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty XGridStepProperty = DependencyProperty.Register(nameof(XGridStep), typeof(double), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty YGridStepProperty = DependencyProperty.Register(nameof(YGridStep), typeof(double), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty HighlightedDemandLabelProperty = DependencyProperty.Register(nameof(HighlightedDemandLabel), typeof(string), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowSpecialPointsProperty = DependencyProperty.Register(nameof(ShowSpecialPoints), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowDemandLabelProperty = DependencyProperty.Register(nameof(ShowDemandLabel), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowCpLabelsProperty = DependencyProperty.Register(nameof(ShowCpLabels), typeof(bool), typeof(DiagramCanvas2D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

    private const double HitTolerance = 10.0;
    private const double MinZoom = 0.35;
    private const double MaxZoom = 18.0;
    private double viewZoom = 1.0;
    private Point? viewCenter;
    private Point? hoverPosition;
    private ControlPointDto? hoverPoint;
    private bool isPanning;
    private Point panStartScreen;
    private Point panStartCenter;

    public DiagramCanvas2D()
    {
        Focusable = true;
        MouseMove += OnMouseMove;
        MouseLeave += (_, _) => { hoverPoint = null; hoverPosition = null; InvalidateVisual(); };
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        MouseRightButtonDown += OnPanMouseDown;
        MouseDown += OnAnyMouseDown;
        MouseUp += OnAnyMouseUp;
        MouseWheel += OnMouseWheel;
        SizeChanged += (_, _) => InvalidateVisual();
    }

    public IEnumerable<ControlPointDto>? Points { get => (IEnumerable<ControlPointDto>?)GetValue(PointsProperty); set => SetValue(PointsProperty, value); }
    public IEnumerable<ChartReferenceLineDto>? ReferenceLines { get => (IEnumerable<ChartReferenceLineDto>?)GetValue(ReferenceLinesProperty); set => SetValue(ReferenceLinesProperty, value); }
    public string XAxisLabel { get => (string)GetValue(XAxisLabelProperty); set => SetValue(XAxisLabelProperty, value); }
    public string YAxisLabel { get => (string)GetValue(YAxisLabelProperty); set => SetValue(YAxisLabelProperty, value); }
    public bool ShowGrid { get => (bool)GetValue(ShowGridProperty); set => SetValue(ShowGridProperty, value); }
    public bool ShowLabels { get => (bool)GetValue(ShowLabelsProperty); set => SetValue(ShowLabelsProperty, value); }
    public bool ShowDemandPoint { get => (bool)GetValue(ShowDemandPointProperty); set => SetValue(ShowDemandPointProperty, value); }
    public bool ShowGoverningPoint { get => (bool)GetValue(ShowGoverningPointProperty); set => SetValue(ShowGoverningPointProperty, value); }
    public bool ShowReferenceLines { get => (bool)GetValue(ShowReferenceLinesProperty); set => SetValue(ShowReferenceLinesProperty, value); }
    public double Ratio { get => (double)GetValue(RatioProperty); set => SetValue(RatioProperty, value); }
    public int ResetVersion { get => (int)GetValue(ResetVersionProperty); set => SetValue(ResetVersionProperty, value); }
    public bool ShowNominalCurve { get => (bool)GetValue(ShowNominalCurveProperty); set => SetValue(ShowNominalCurveProperty, value); }
    public bool ShowCapacityControlPoints { get => (bool)GetValue(ShowCapacityControlPointsProperty); set => SetValue(ShowCapacityControlPointsProperty, value); }
    public bool ShowInteractionHint { get => (bool)GetValue(ShowInteractionHintProperty); set => SetValue(ShowInteractionHintProperty, value); }
    public ControlPointDto? SelectedPoint { get => (ControlPointDto?)GetValue(SelectedPointProperty); set => SetValue(SelectedPointProperty, value); }
    public Rect? BoundsOverride { get => (Rect?)GetValue(BoundsOverrideProperty); set => SetValue(BoundsOverrideProperty, value); }
    public bool UseEqualAspect { get => (bool)GetValue(UseEqualAspectProperty); set => SetValue(UseEqualAspectProperty, value); }
    public PmChartInsetFigureDto? InsetFigure { get => (PmChartInsetFigureDto?)GetValue(InsetFigureProperty); set => SetValue(InsetFigureProperty, value); }
    public double XGridStep { get => (double)GetValue(XGridStepProperty); set => SetValue(XGridStepProperty, value); }
    public double YGridStep { get => (double)GetValue(YGridStepProperty); set => SetValue(YGridStepProperty, value); }
    public string? HighlightedDemandLabel { get => (string?)GetValue(HighlightedDemandLabelProperty); set => SetValue(HighlightedDemandLabelProperty, value); }
    public bool ShowSpecialPoints { get => (bool)GetValue(ShowSpecialPointsProperty); set => SetValue(ShowSpecialPointsProperty, value); }
    public bool ShowDemandLabel   { get => (bool)GetValue(ShowDemandLabelProperty);   set => SetValue(ShowDemandLabelProperty, value); }
    public bool ShowCpLabels      { get => (bool)GetValue(ShowCpLabelsProperty);      set => SetValue(ShowCpLabelsProperty, value); }

    public void ResetView()
    {
        viewZoom = 1.0;
        viewCenter = null;
        isPanning = false;
        Cursor = Cursors.Arrow;
        ReleaseMouseCapture();
        InvalidateVisual();
    }

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);
        dc.DrawRoundedRectangle(Brushes.White, new Pen(new SolidColorBrush(Color.FromRgb(226, 233, 240)), 1), new Rect(0, 0, ActualWidth, ActualHeight), 7, 7);
        var allFinitePoints = (Points ?? []).Where(IsFinite).ToList();
        var points = VisiblePoints(allFinitePoints).ToList();
        var plot = GetPlotRect();
        dc.PushClip(new RectangleGeometry(new Rect(0, 0, ActualWidth, ActualHeight)));
        if (points.Count == 0)
        {
            DrawText(dc, "No chart data", 13, Brushes.Gray, new Point(20, 20), FontWeights.Normal);
            dc.Pop();
            return;
        }

        var transform = BuildTransform(points, plot);
        DrawPlotSurface(dc, plot);
        AxisRenderer2D.Draw(dc, transform, XAxisLabel, YAxisLabel, ShowGrid, XGridStep, YGridStep, ShowLabels);
        DrawCapacity(dc, transform, allFinitePoints);
        DrawCapacityControlPoints(dc, transform, points);
        DrawReferences(dc, transform, points);
        DrawConstructionReferenceLines(dc, transform);
        DrawSpecialPoints(dc, transform, points);
        DrawSelectedPoint(dc, transform);
        DrawHoverOverlay(dc, transform, plot);
        DrawInsetFigure(dc, plot);
        DrawInteractionHint(dc);
        dc.Pop();
    }

    private Rect GetPlotRect()
    {
        const double leftMargin = 76;
        const double topMargin = 52;
        const double bottomMargin = 56;
        var xAxisLabelWidth = string.IsNullOrWhiteSpace(XAxisLabel)
            ? 0
            : CreateText(XAxisLabel, 12, Brushes.Black, FontWeights.SemiBold).Width;
        var rightMargin = Math.Max(74, xAxisLabelWidth + 18);

        return new Rect(
            leftMargin,
            topMargin,
            Math.Max(10, ActualWidth - leftMargin - rightMargin),
            Math.Max(10, ActualHeight - topMargin - bottomMargin));
    }

    private ChartTransformHelper BuildTransform(IReadOnlyList<ControlPointDto> visiblePoints, Rect plot)
    {
        var transformPoints = ShowReferenceLines
            ? visiblePoints.Concat(ReferenceLineBoundsPoints()).ToList()
            : visiblePoints;
        var baseTransform = ChartTransformHelper.AutoFit2D(transformPoints, plot, BoundsOverride, UseEqualAspect);
        if (viewZoom <= 1.0001 && viewCenter is null)
        {
            return baseTransform;
        }

        var center = viewCenter ?? new Point((baseTransform.MinX + baseTransform.MaxX) * 0.5, (baseTransform.MinY + baseTransform.MaxY) * 0.5);
        double width = (baseTransform.MaxX - baseTransform.MinX) / Math.Max(MinZoom, viewZoom);
        double height = (baseTransform.MaxY - baseTransform.MinY) / Math.Max(MinZoom, viewZoom);
        var bounds = new Rect(new Point(center.X - width * 0.5, center.Y - height * 0.5), new Point(center.X + width * 0.5, center.Y + height * 0.5));
        return ChartTransformHelper.AutoFit2D(transformPoints, plot, bounds, useEqualAspect: false, exactBounds: true);
    }

    private ChartTransformHelper BuildCurrentTransform()
    {
        var points = VisiblePoints((Points ?? []).Where(IsFinite)).ToList();
        return BuildTransform(points, GetPlotRect());
    }

    private static void DrawPlotSurface(DrawingContext dc, Rect plot)
    {
        var fill = new LinearGradientBrush(Color.FromRgb(253, 254, 255), Color.FromRgb(248, 251, 254), 90);
        var border = new Pen(new SolidColorBrush(Color.FromRgb(225, 232, 241)), 0.8);
        dc.DrawRoundedRectangle(fill, border, plot, 5, 5);
    }

    private void DrawCapacity(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> points)
    {
        var activeDesignPen = new Pen(new SolidColorBrush(Color.FromRgb(0, 75, 133)), 1.4)
        {
            LineJoin = PenLineJoin.Round,
            StartLineCap = PenLineCap.Round,
            EndLineCap = PenLineCap.Round
        };
        var reducedDesignPen = new Pen(new SolidColorBrush(Color.FromRgb(0, 75, 133)), 0.95)
        {
            DashStyle = DashStyles.Dash,
            LineJoin = PenLineJoin.Round,
            StartLineCap = PenLineCap.Round,
            EndLineCap = PenLineCap.Round
        };
        var nominalPen = new Pen(new SolidColorBrush(Color.FromRgb(200, 40, 40)), 1.1)
        {
            LineJoin = PenLineJoin.Round,
            StartLineCap = PenLineCap.Round,
            EndLineCap = PenLineCap.Round
        };
        double? designCompressionCap = DesignCompressionCap(points);

        foreach (var group in points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint).GroupBy(p => p.GroupKey))
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

            DrawAboveCapSegments(dc, transform, ordered, designCompressionCap, reducedDesignPen);
            DrawBelowCapSegments(dc, transform, ordered, designCompressionCap, activeDesignPen);
        }
    }

    private static double? DesignCompressionCap(IReadOnlyList<ControlPointDto> points)
    {
        var cap = points.FirstOrDefault(p => p.IsReference && p.Label.Equals("Pmax", StringComparison.OrdinalIgnoreCase));
        return cap?.Y;
    }

    private static void DrawBelowCapSegments(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered, double? cap, Pen pen)
    {
        if (cap is null)
        {
            dc.DrawGeometry(null, pen, BuildPolylineGeometry(transform, ordered));
            return;
        }

        var clipped = ClipClosedPolylineBelowY(ordered, cap.Value);
        if (clipped.Count > 2)
        {
            dc.DrawGeometry(null, pen, BuildOpenPolylineGeometry(transform, clipped));
        }
    }

    private static void DrawAboveCapSegments(DrawingContext dc, ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered, double? cap, Pen pen)
    {
        if (cap is null) return;

        var clipped = ClipOpenPolylineAboveY(ordered, cap.Value);
        foreach (var segment in clipped.Where(s => s.Count > 1))
        {
            dc.DrawGeometry(null, pen, BuildOpenPolylineGeometry(transform, segment));
        }
    }

    public static IReadOnlyList<ControlPointDto> ClipClosedPolylineBelowYForTesting(IReadOnlyList<ControlPointDto> ordered, double cap)
        => ClipClosedPolylineBelowY(ordered, cap);

    private static IReadOnlyList<ControlPointDto> ClipClosedPolylineBelowY(IReadOnlyList<ControlPointDto> ordered, double cap)
    {
        if (ordered.Count == 0) return [];

        var clipped = new List<ControlPointDto>();
        for (int i = 0; i < ordered.Count; i++)
        {
            var a = ordered[(i + ordered.Count - 1) % ordered.Count];
            var b = ordered[i];
            bool aInside = a.Y <= cap;
            bool bInside = b.Y <= cap;

            if (bInside)
            {
                if (!aInside)
                {
                    clipped.Add(InterpolateAtY(a, b, cap));
                }

                clipped.Add(b);
            }
            else if (aInside)
            {
                clipped.Add(InterpolateAtY(a, b, cap));
            }
        }

        return RemoveAdjacentDuplicates(clipped);
    }

    public static IReadOnlyList<IReadOnlyList<ControlPointDto>> ClipOpenPolylineAboveYForTesting(IReadOnlyList<ControlPointDto> ordered, double cap)
        => ClipOpenPolylineAboveY(ordered, cap);

    private static IReadOnlyList<IReadOnlyList<ControlPointDto>> ClipOpenPolylineAboveY(IReadOnlyList<ControlPointDto> ordered, double cap)
    {
        if (ordered.Count == 0) return [];

        var segments = new List<IReadOnlyList<ControlPointDto>>();
        var current = new List<ControlPointDto>();

        // Find a starting index that is below the cap to avoid wrap-around segments
        int start = 0;
        for (int i = 0; i < ordered.Count; i++)
        {
            if (ordered[i].Y <= cap)
            {
                start = i;
                break;
            }
        }

        for (int i = 0; i < ordered.Count; i++)
        {
            var a = ordered[(start + i) % ordered.Count];
            var b = ordered[(start + i + 1) % ordered.Count];
            bool aInside = a.Y > cap;
            bool bInside = b.Y > cap;

            if (!aInside && bInside)
            {
                current = [InterpolateAtY(a, b, cap), b];
            }
            else if (aInside && bInside)
            {
                current.Add(b);
            }
            else if (aInside && !bInside)
            {
                current.Add(InterpolateAtY(a, b, cap));
                AddOpenSegment(segments, current);
                current = [];
            }
        }

        AddOpenSegment(segments, current);
        return segments;
    }

    private static void AddOpenSegment(List<IReadOnlyList<ControlPointDto>> segments, List<ControlPointDto> current)
    {
        var cleaned = RemoveAdjacentDuplicates(current);
        if (cleaned.Count > 1)
        {
            segments.Add(cleaned);
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

    private static IReadOnlyList<ControlPointDto> RemoveAdjacentDuplicates(IReadOnlyList<ControlPointDto> points)
    {
        var result = new List<ControlPointDto>();
        foreach (var point in points)
        {
            if (result.Count == 0 ||
                Math.Abs(result[^1].X - point.X) > 1e-9 ||
                Math.Abs(result[^1].Y - point.Y) > 1e-9)
            {
                result.Add(point);
            }
        }

        if (result.Count > 1 &&
            Math.Abs(result[0].X - result[^1].X) <= 1e-9 &&
            Math.Abs(result[0].Y - result[^1].Y) <= 1e-9)
        {
            result.RemoveAt(result.Count - 1);
        }

        return result;
    }

    private static StreamGeometry BuildPolylineGeometry(ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered)
        => BuildSmoothPolylineGeometry(transform, ordered, closed: true);

    private static StreamGeometry BuildOpenPolylineGeometry(ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered)
        => BuildSmoothPolylineGeometry(transform, ordered, closed: false);

    private static StreamGeometry BuildSmoothPolylineGeometry(ChartTransformHelper transform, IReadOnlyList<ControlPointDto> ordered, bool closed)
    {
        var screenPoints = ordered.Select(p => transform.ToScreen(p.X, p.Y)).ToList();
        if (screenPoints.Count < 2)
        {
            return new StreamGeometry();
        }

        var geo = new StreamGeometry();
        using (var ctx = geo.Open())
        {
            ctx.BeginFigure(screenPoints[0], false, closed);
            int count = screenPoints.Count;

            if (count == 2)
            {
                ctx.LineTo(screenPoints[1], true, false);
            }
            else if (closed)
            {
                for (int i = 0; i < count; i++)
                {
                    var p0 = screenPoints[(i + count - 1) % count];
                    var p1 = screenPoints[i];
                    var p2 = screenPoints[(i + 1) % count];
                    var p3 = screenPoints[(i + 2) % count];

                    var (c1, c2) = ClampedBezierControlPoints(p0, p1, p2, p3);
                    ctx.BezierTo(c1, c2, p2, true, false);
                }
            }
            else
            {
                for (int i = 0; i < count - 1; i++)
                {
                    var p0 = i == 0 ? screenPoints[0] : screenPoints[i - 1];
                    var p1 = screenPoints[i];
                    var p2 = screenPoints[i + 1];
                    var p3 = i + 2 < count ? screenPoints[i + 2] : screenPoints[count - 1];

                    var (c1, c2) = ClampedBezierControlPoints(p0, p1, p2, p3);
                    ctx.BezierTo(c1, c2, p2, true, false);
                }
            }
        }

        geo.Freeze();
        return geo;
    }

    /// <summary>
    /// Compute Bézier control points for a Catmull-Rom segment from p1 to p2,
    /// with tangent magnitudes clamped to prevent overshooting at sharp turns.
    /// </summary>
    private static (Point C1, Point C2) ClampedBezierControlPoints(Point p0, Point p1, Point p2, Point p3)
    {
        // Chord lengths between consecutive points
        double d01 = PointDistance(p0, p1);
        double d12 = PointDistance(p1, p2);
        double d23 = PointDistance(p2, p3);

        // Raw Catmull-Rom tangent vectors (divided by 6 for Bézier conversion)
        double t1x = (p2.X - p0.X) / 6.0;
        double t1y = (p2.Y - p0.Y) / 6.0;
        double t2x = (p3.X - p1.X) / 6.0;
        double t2y = (p3.Y - p1.Y) / 6.0;

        // Clamp tangent magnitudes: each control arm should not exceed
        // one-third of the shorter adjacent chord to avoid overshooting.
        double maxArm1 = Math.Max(1e-6, Math.Min(d01, d12)) * 0.333;
        double arm1Len = Math.Sqrt(t1x * t1x + t1y * t1y);
        if (arm1Len > maxArm1)
        {
            double scale = maxArm1 / arm1Len;
            t1x *= scale;
            t1y *= scale;
        }

        double maxArm2 = Math.Max(1e-6, Math.Min(d12, d23)) * 0.333;
        double arm2Len = Math.Sqrt(t2x * t2x + t2y * t2y);
        if (arm2Len > maxArm2)
        {
            double scale = maxArm2 / arm2Len;
            t2x *= scale;
            t2y *= scale;
        }

        var c1 = new Point(p1.X + t1x, p1.Y + t1y);
        var c2 = new Point(p2.X - t2x, p2.Y - t2y);
        return (c1, c2);
    }

    private static double PointDistance(Point a, Point b)
    {
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        return Math.Sqrt(dx * dx + dy * dy);
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
        var demandPoints = ShowDemandPoint ? points.Where(p => p.IsDemand).ToList() : [];
        var highlighted = HighlightedDemandLabel;
        var hasHighlight = !string.IsNullOrEmpty(highlighted);

        // Draw non-highlighted demand points first (behind the highlighted one)
        foreach (var p in demandPoints)
        {
            var isHighlighted = hasHighlight && string.Equals(p.Label, highlighted, StringComparison.OrdinalIgnoreCase);
            if (isHighlighted) continue;

            var pt = transform.ToScreen(p.X, p.Y);
            if (hasHighlight)
            {
                // Dim unselected points when something is highlighted
                dc.DrawEllipse(new SolidColorBrush(Color.FromArgb(80, 227, 27, 35)), null, pt, 3.5, 3.5);
            }
            else
            {
                // Normal: solid dot, no label
                dc.DrawEllipse(new SolidColorBrush(Color.FromRgb(227, 27, 35)), new Pen(Brushes.White, 1), pt, 5, 5);
            }
        }

        // Draw highlighted demand point on top with ring + label
        foreach (var p in demandPoints.Where(p => hasHighlight && string.Equals(p.Label, highlighted, StringComparison.OrdinalIgnoreCase)))
        {
            if (p.Utilization > 0)
            {
                var originPt = transform.ToScreen(0, 0);
                double t = 1.0;
                var designCurve = points.Where(pt => !pt.IsDemand && !pt.IsGoverning && !pt.IsReference && !pt.IsSpecialPoint && !pt.IsNominal).ToList();
                if (designCurve.Count > 1 && (Math.Abs(p.X) > 1e-6 || Math.Abs(p.Y) > 1e-6))
                {
                    t = FindRayIntersectionMultiplier(designCurve, p.X, p.Y);
                }
                
                double? cap = DesignCompressionCap(points);
                if (cap.HasValue && p.Y * t > cap.Value && p.Y > 1e-6)
                {
                    t = cap.Value / p.Y;
                }
                
                double tDisplay = Math.Max(1.0, t);
                var capacityPt = transform.ToScreen(p.X * tDisplay, p.Y * tDisplay);
                
                var rayPen = new Pen(new SolidColorBrush(Color.FromArgb(180, 227, 27, 35)), 1.2) { DashStyle = DashStyles.Dash };
                rayPen.Freeze();
                dc.DrawLine(rayPen, originPt, capacityPt);
            }

            var pt = transform.ToScreen(p.X, p.Y);
            var redBrush = new SolidColorBrush(Color.FromRgb(227, 27, 35));
            var ringPen = new Pen(new SolidColorBrush(Color.FromRgb(31, 41, 51)), 1.5);
            redBrush.Freeze();
            ringPen.Freeze();
            dc.DrawEllipse(redBrush, ringPen, pt, 7, 7);
            if (ShowDemandLabel)
                DrawText(dc, p.Label, 11, redBrush, new Point(pt.X + 10, pt.Y - 16), FontWeights.SemiBold);
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
        if (ShowSpecialPoints)
        {
            double screenCenterX = transform.ToScreen(0, 0).X;
            foreach (var p in points.Where(p => p.IsSpecialPoint))
            {
                var brush = GetSpecialPointBrush(p.Label);
                var pt = transform.ToScreen(p.X, p.Y);
                
                var geometry = new StreamGeometry();
                using (var ctx = geometry.Open())
                {
                    ctx.BeginFigure(new Point(pt.X, pt.Y - 7.5), true, true);
                    ctx.LineTo(new Point(pt.X + 7, pt.Y + 6), true, false);
                    ctx.LineTo(new Point(pt.X - 7, pt.Y + 6), true, false);
                }
                geometry.Freeze();
                var haloPen = new Pen(Brushes.White, 3.0) { LineJoin = PenLineJoin.Round };
                haloPen.Freeze();
                dc.DrawGeometry(brush, haloPen, geometry);
                var outlinePen = new Pen(new SolidColorBrush(Color.FromArgb(130, 20, 20, 20)), 0.7);
                outlinePen.Freeze();
                dc.DrawGeometry(null, outlinePen, geometry);

                if (ShowCpLabels && p.CpNumber > 0)
                {
                    string cpLabel = $"CP-{p.CpNumber:D2}";
                    var ft = CreateText(cpLabel, 10, brush, FontWeights.SemiBold);
                    double lx = pt.X >= screenCenterX
                        ? pt.X + 8
                        : pt.X - ft.Width - 8;
                    double ly = pt.Y - ft.Height / 2;
                    dc.DrawText(ft, new Point(lx, ly));
                }
            }
        }
    }

    private static double FindRayIntersectionMultiplier(IReadOnlyList<ControlPointDto> polygon, double dx, double dy)
    {
        double bestT = 1000.0;
        int count = polygon.Count;
        for (int i = 0; i < count; i++)
        {
            var p1 = polygon[i];
            var p2 = polygon[(i + 1) % count]; // check closing segment too

            double cross = dx * (p2.Y - p1.Y) - dy * (p2.X - p1.X);
            if (Math.Abs(cross) > 1e-6)
            {
                double u = (dy * p1.X - dx * p1.Y) / cross;
                if (u >= -1e-6 && u <= 1 + 1e-6)
                {
                    double t = (p1.X * p2.Y - p1.Y * p2.X) / cross;
                    if (t > 1e-6 && t < bestT)
                    {
                        bestT = t;
                    }
                }
            }
        }
        return bestT == 1000.0 ? 1.0 : bestT;
    }

    private static Brush GetSpecialPointBrush(string label)
    {
        var color = label switch
        {
            "Max Compression" => Color.FromRgb(255, 0, 0),    // Red
            "Zero Tension"    => Color.FromRgb(255, 165, 0),  // Orange
            "50% Yield"       => Color.FromRgb(255, 215, 0),  // Gold
            "Balanced"        => Color.FromRgb(0, 128, 0),    // Green
            "Tension Control" => Color.FromRgb(0, 0, 255),    // Blue
            "Pure Bending"    => Color.FromRgb(75, 0, 130),   // Indigo
            "Max Tension"     => Color.FromRgb(238, 130, 238),// Violet
            _                 => Color.FromRgb(215, 107, 15)  // Default orange
        };
        return new SolidColorBrush(color);
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

    private void DrawHoverOverlay(DrawingContext dc, ChartTransformHelper transform, Rect plot)
    {
        if (hoverPosition is not { } mouse || hoverPoint is not { } point || !plot.Contains(mouse))
        {
            return;
        }

        var screen = transform.ToScreen(point.X, point.Y);
        if (!IsFinite(screen)) return;

        var crosshairPen = new Pen(new SolidColorBrush(Color.FromArgb(130, 47, 127, 208)), 0.9) { DashStyle = DashStyles.Dash };
        var guidePen = new Pen(new SolidColorBrush(Color.FromArgb(90, 15, 23, 42)), 0.7);
        dc.DrawLine(crosshairPen, new Point(screen.X, plot.Top), new Point(screen.X, plot.Bottom));
        dc.DrawLine(crosshairPen, new Point(plot.Left, screen.Y), new Point(plot.Right, screen.Y));

        dc.DrawLine(guidePen, new Point(screen.X, screen.Y), new Point(screen.X, plot.Bottom));
        dc.DrawLine(guidePen, new Point(plot.Left, screen.Y), new Point(screen.X, screen.Y));

        var haloBrush = new SolidColorBrush(Color.FromArgb(46, 47, 127, 208));
        var ringPen = new Pen(new SolidColorBrush(Color.FromRgb(47, 127, 208)), 1.8);
        dc.DrawEllipse(haloBrush, null, screen, 11, 11);
        dc.DrawEllipse(Brushes.White, ringPen, screen, 5.5, 5.5);

        DrawAxisChip(dc, AxisTickService.Format(point.X), new Point(screen.X, plot.Bottom + 16), horizontal: true);
        DrawAxisChip(dc, AxisTickService.Format(point.Y), new Point(plot.Left - 44, screen.Y - 10), horizontal: false);
        DrawHoverCard(dc, point, screen, plot);
    }

    private static void DrawAxisChip(DrawingContext dc, string text, Point anchor, bool horizontal)
    {
        var ft = CreateText(text, 9.0, Brushes.White, FontWeights.SemiBold);
        double width = Math.Max(44, ft.Width + 12);
        double height = 20;
        var rect = horizontal
            ? new Rect(anchor.X - width * 0.5, anchor.Y, width, height)
            : new Rect(anchor.X, anchor.Y, width, height);
        var fill = new SolidColorBrush(Color.FromRgb(37, 99, 160));
        dc.DrawRoundedRectangle(fill, null, rect, 5, 5);
        dc.DrawText(ft, new Point(rect.Left + (rect.Width - ft.Width) * 0.5, rect.Top + 2.5));
    }

    private void DrawHoverCard(DrawingContext dc, ControlPointDto point, Point screen, Rect plot)
    {
        string title = string.IsNullOrWhiteSpace(point.Label) ? PointTypeLabel(point) : point.Label;
        string line1 = $"P {point.P:F2}";
        string line2 = $"Mx {point.Mx:F2}   My {point.My:F2}";
        string line3 = point.IsDemand ? $"D/C {Math.Max(point.Utilization, Ratio):F3}" : $"Phi {point.Phi:F3}";

        var titleText = CreateText(title, 10.5, new SolidColorBrush(Color.FromRgb(15, 23, 42)), FontWeights.SemiBold);
        var line1Text = CreateText(line1, 9.5, new SolidColorBrush(Color.FromRgb(71, 85, 105)), FontWeights.Normal);
        var line2Text = CreateText(line2, 9.5, new SolidColorBrush(Color.FromRgb(71, 85, 105)), FontWeights.Normal);
        var line3Text = CreateText(line3, 9.5, new SolidColorBrush(Color.FromRgb(47, 127, 208)), FontWeights.SemiBold);
        double width = Math.Max(138, new[] { titleText.Width, line1Text.Width, line2Text.Width, line3Text.Width }.Max() + 22);
        double height = 78;
        double left = screen.X + 14;
        double top = screen.Y - height - 12;
        if (left + width > plot.Right - 8) left = screen.X - width - 14;
        if (top < plot.Top + 8) top = screen.Y + 14;
        if (top + height > plot.Bottom - 8) top = plot.Bottom - height - 8;

        var rect = new Rect(left, top, width, height);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromArgb(246, 255, 255, 255)),
            new Pen(new SolidColorBrush(Color.FromRgb(203, 213, 225)), 0.8), rect, 7, 7);
        dc.DrawRectangle(new SolidColorBrush(Color.FromRgb(47, 127, 208)), null, new Rect(rect.Left, rect.Top, 4, rect.Height));
        dc.DrawText(titleText, new Point(rect.Left + 12, rect.Top + 8));
        dc.DrawText(line1Text, new Point(rect.Left + 12, rect.Top + 28));
        dc.DrawText(line2Text, new Point(rect.Left + 12, rect.Top + 44));
        dc.DrawText(line3Text, new Point(rect.Left + 12, rect.Top + 60));
    }

    private static string PointTypeLabel(ControlPointDto point)
    {
        if (point.IsDemand) return "Demand";
        if (point.IsReference) return "Reference";
        return point.IsNominal ? "Nominal capacity" : "Design capacity";
    }

    private void DrawInsetFigure(DrawingContext dc, Rect plot)
    {
        var inset = InsetFigure;
        if (inset is null || inset.SectionBoundaryPoints.Count < 3) return;

        double side = Math.Clamp(Math.Min(ActualWidth, ActualHeight) * 0.21, 108.0, 154.0);
        side = Math.Min(side, Math.Max(80.0, Math.Min(plot.Width * 0.28, plot.Height * 0.34)));
        double insetWidth = Math.Max(side, 160.0);
        var bounds = new Rect(plot.Left + 12, Math.Max(plot.Top + 54, plot.Bottom - side - 12), insetWidth, side);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromArgb(232, 255, 255, 255)), new Pen(new SolidColorBrush(Color.FromArgb(185, 148, 163, 184)), 0.8), bounds, 6, 6);

        var sectionBounds = GetInsetContentBounds(inset.SectionBoundaryPoints);
        if (sectionBounds.Width <= 0 || sectionBounds.Height <= 0) return;

        dc.PushClip(new RectangleGeometry(bounds, 6, 6));

        double legendHeight = 42.0;
        var sketchBounds = new Rect(bounds.Left, bounds.Top, bounds.Width, Math.Max(40.0, bounds.Height - legendHeight));
        double padding = 18.0;
        double scale = Math.Min((sketchBounds.Width - 2 * padding) / sectionBounds.Width, (sketchBounds.Height - 2 * padding) / sectionBounds.Height);
        if (double.IsNaN(scale) || double.IsInfinity(scale) || scale <= 0)
        {
            dc.Pop();
            return;
        }

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
            dc.DrawGeometry(tensionFill, null, tensionGeometry);

        if (compressionGeometry is not null)
            dc.DrawGeometry(compressionFill, null, compressionGeometry);

        dc.DrawGeometry(new SolidColorBrush(Color.FromArgb(35, 100, 116, 139)), sectionPen, sectionGeometry);
        if (coverGeometry is not null)
            dc.DrawGeometry(null, coverPen, coverGeometry);

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
            ? $"\u03b8 = {inset.ThetaDegrees:0.#}\u00b0"
            : $"{inset.SelectedLoadCaseName}  \u03b8 = {inset.ThetaDegrees:0.#}\u00b0";
        DrawInsetLegend(dc, bounds, caption, compressionFill, tensionFill);

        dc.Pop();
    }

    private static void DrawInsetLegend(DrawingContext dc, Rect bounds, string caption, Brush compressionFill, Brush tensionFill)
    {
        var textBrush = new SolidColorBrush(Color.FromRgb(71, 85, 105));
        double left = bounds.Left + 6.0;
        double y = bounds.Bottom - 38.0;
        DrawText(dc, caption, 7.2, textBrush, new Point(left, y), FontWeights.Normal);
        DrawLegendItem(dc, new Point(left, y + 13.0), compressionFill, "Concrete in compression", textBrush);
        DrawLegendItem(dc, new Point(left, y + 26.0), tensionFill, "Concrete in tension (ignored)", textBrush);
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
        DrawText(dc, "\u03b8", 8.0, brush, Offset(labelPoint, 3, -9), FontWeights.SemiBold);
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
        Focus();
        if (e.ClickCount >= 2)
        {
            ResetView();
            e.Handled = true;
            return;
        }

        var position = e.GetPosition(this);
        var hitResult = HitTestPoint(position);
        if (hitResult is not null)
        {
            SelectedPoint = hitResult;
            hoverPoint = hitResult;
            hoverPosition = position;
            InvalidateVisual();
            return;
        }

        BeginPan(position);
    }

    private void OnPanMouseDown(object sender, MouseButtonEventArgs e)
    {
        Focus();
        BeginPan(e.GetPosition(this));
        e.Handled = true;
    }

    private void OnAnyMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Middle)
        {
            Focus();
            BeginPan(e.GetPosition(this));
            e.Handled = true;
        }
    }

    private void OnAnyMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (isPanning && (e.ChangedButton == MouseButton.Left || e.ChangedButton == MouseButton.Right || e.ChangedButton == MouseButton.Middle))
        {
            EndPan();
            e.Handled = true;
        }
    }

    private void OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var position = e.GetPosition(this);
        var plot = GetPlotRect();
        if (!plot.Contains(position)) return;

        var oldTransform = BuildCurrentTransform();
        var dataBefore = oldTransform.ToData(position);
        viewCenter ??= new Point((oldTransform.MinX + oldTransform.MaxX) * 0.5, (oldTransform.MinY + oldTransform.MaxY) * 0.5);
        viewZoom = Math.Clamp(viewZoom * (e.Delta > 0 ? 1.16 : 0.86), MinZoom, MaxZoom);
        var newTransform = BuildCurrentTransform();
        var dataAfter = newTransform.ToData(position);
        viewCenter = new Point(viewCenter.Value.X + dataBefore.X - dataAfter.X, viewCenter.Value.Y + dataBefore.Y - dataAfter.Y);
        hoverPosition = position;
        hoverPoint = FindNearestPoint(position);
        InvalidateVisual();
        e.Handled = true;
    }

    private void BeginPan(Point position)
    {
        var transform = BuildCurrentTransform();
        viewCenter ??= new Point((transform.MinX + transform.MaxX) * 0.5, (transform.MinY + transform.MaxY) * 0.5);
        panStartCenter = viewCenter.Value;
        panStartScreen = position;
        isPanning = true;
        Cursor = Cursors.SizeAll;
        CaptureMouse();
    }

    private void EndPan()
    {
        isPanning = false;
        Cursor = Cursors.Arrow;
        ReleaseMouseCapture();
    }

    private ControlPointDto? HitTestPoint(Point position)
    {
        if (!GetPlotRect().Contains(position)) return null;

        var points = HitTestablePoints().ToList();
        if (points.Count == 0) return null;

        var transform = BuildCurrentTransform();

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

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        var position = e.GetPosition(this);
        if (isPanning && viewCenter is not null)
        {
            var transform = BuildCurrentTransform();
            var delta = position - panStartScreen;
            double dataDx = -delta.X / Math.Max(1.0, transform.Plot.Width) * (transform.MaxX - transform.MinX);
            double dataDy = delta.Y / Math.Max(1.0, transform.Plot.Height) * (transform.MaxY - transform.MinY);
            viewCenter = new Point(panStartCenter.X + dataDx, panStartCenter.Y + dataDy);
            hoverPoint = null;
            hoverPosition = null;
            InvalidateVisual();
            return;
        }

        hoverPosition = position;
        hoverPoint = FindNearestPoint(position);
        Cursor = GetPlotRect().Contains(position) ? Cursors.Cross : Cursors.Arrow;
        InvalidateVisual();
    }

    private ControlPointDto? FindNearestPoint(Point position)
    {
        var points = HitTestablePoints().ToList();
        if (points.Count == 0) return null;

        var plot = GetPlotRect();
        if (!plot.Contains(position)) return null;

        var transform = BuildCurrentTransform();
        var nearest = points
            .Select(p => new { Point = p, Screen = transform.ToScreen(p.X, p.Y) })
            .Select(x => new { x.Point, Distance = (x.Screen - position).Length })
            .Where(x => x.Distance < HitTolerance)
            .OrderBy(x => x.Distance)
            .FirstOrDefault();

        return nearest?.Point;
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

    private void DrawInteractionHint(DrawingContext dc)
    {
        if (ActualWidth < 420) return;

        string zoomText = viewZoom > 1.01 ? $"  {viewZoom * 100:0}%" : "";
        string text = $"Wheel zoom | Drag pan | Double-click reset{zoomText}";
        var ft = CreateText(text, 8.0, new SolidColorBrush(Color.FromRgb(82, 97, 111)), FontWeights.Normal);
        var rect = new Rect(ActualWidth - ft.Width - 24, 10, ft.Width + 14, 19);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromArgb(232, 248, 251, 254)),
            new Pen(new SolidColorBrush(Color.FromRgb(226, 233, 240)), 0.8), rect, 11, 11);
        dc.DrawText(ft, new Point(rect.Left + 7, rect.Top + 2.7));
    }

    private static void DrawText(DrawingContext dc, string text, double size, Brush brush, Point point, FontWeight weight)
    {
        var ft = CreateText(text, size, brush, weight);
        dc.DrawText(ft, point);
    }

    private static FormattedText CreateText(string text, double size, Brush brush, FontWeight weight)
        => new(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal), size + 1, brush, 1.25);

    private static void OnResetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is DiagramCanvas2D chart) chart.ResetView();
    }
}

