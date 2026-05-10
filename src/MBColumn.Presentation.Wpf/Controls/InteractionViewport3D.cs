using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MBColumn.Application.DTOs;

namespace MBColumn.Presentation.Wpf.Controls;

public sealed class InteractionViewport3D : FrameworkElement
{
    private const double DefaultYaw = 0;
    private const double DefaultPitch = 0;
    private const double DefaultZoom = 1.12;

    private double yaw = DefaultYaw;
    private double pitch = DefaultPitch;
    private double zoom = DefaultZoom;
    private Vector pan = new(0, 0);
    private Point? dragStart;
    private MouseButton dragButton;
    private CachedScene? cachedScene;

    public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(nameof(Points), typeof(IEnumerable<ControlPointDto>), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(null, OnDataChanged));
    public static readonly DependencyProperty DemandPointProperty = DependencyProperty.Register(nameof(DemandPoint), typeof(ControlPointDto), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(null, OnDataChanged));
    public static readonly DependencyProperty DemandPointsProperty = DependencyProperty.Register(nameof(DemandPoints), typeof(IEnumerable<ControlPointDto>), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(null, OnDataChanged));
    public static readonly DependencyProperty GoverningPointProperty = DependencyProperty.Register(nameof(GoverningPoint), typeof(ControlPointDto), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(null, OnDataChanged));
    public static readonly DependencyProperty ShowGridProperty = DependencyProperty.Register(nameof(ShowGrid), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, OnOptionChanged));
    public static readonly DependencyProperty ShowWireframeProperty = DependencyProperty.Register(nameof(ShowWireframe), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, OnOptionChanged));
    public static readonly DependencyProperty ShowSurfaceProperty = DependencyProperty.Register(nameof(ShowSurface), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, OnOptionChanged));
    public static readonly DependencyProperty ShowLabelsProperty = DependencyProperty.Register(nameof(ShowLabels), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowDemandPointProperty = DependencyProperty.Register(nameof(ShowDemandPoint), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowGoverningPointProperty = DependencyProperty.Register(nameof(ShowGoverningPoint), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ResetVersionProperty = DependencyProperty.Register(nameof(ResetVersion), typeof(int), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(0, OnResetChanged));
    public static readonly DependencyProperty UnitLabelsProperty = DependencyProperty.Register(nameof(UnitLabels), typeof(string), typeof(InteractionViewport3D), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SelectedPmAngleProperty = DependencyProperty.Register(nameof(SelectedPmAngle), typeof(double), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty SelectedAxialLoadProperty = DependencyProperty.Register(nameof(SelectedAxialLoad), typeof(double), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowSlicePlaneProperty = DependencyProperty.Register(nameof(ShowSlicePlane), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));
    public static readonly DependencyProperty ShowAxialLoadSliceProperty = DependencyProperty.Register(nameof(ShowAxialLoadSlice), typeof(bool), typeof(InteractionViewport3D), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsRender));

    public InteractionViewport3D()
    {
        Focusable = true;
        ClipToBounds = true;
        MouseWheel += (_, e) => { zoom = Math.Clamp(zoom * (e.Delta > 0 ? 1.12 : 0.89), 0.25, 25); InvalidateVisual(); };
        MouseDown += OnMouseDown;
        MouseUp += (_, _) => { dragStart = null; ReleaseMouseCapture(); };
        MouseMove += OnMouseMove;
    }

    public IEnumerable<ControlPointDto>? Points { get => (IEnumerable<ControlPointDto>?)GetValue(PointsProperty); set => SetValue(PointsProperty, value); }
    public ControlPointDto? DemandPoint { get => (ControlPointDto?)GetValue(DemandPointProperty); set => SetValue(DemandPointProperty, value); }
    public IEnumerable<ControlPointDto>? DemandPoints { get => (IEnumerable<ControlPointDto>?)GetValue(DemandPointsProperty); set => SetValue(DemandPointsProperty, value); }
    public ControlPointDto? GoverningPoint { get => (ControlPointDto?)GetValue(GoverningPointProperty); set => SetValue(GoverningPointProperty, value); }
    public bool ShowGrid { get => (bool)GetValue(ShowGridProperty); set => SetValue(ShowGridProperty, value); }
    public bool ShowWireframe { get => (bool)GetValue(ShowWireframeProperty); set => SetValue(ShowWireframeProperty, value); }
    public bool ShowSurface { get => (bool)GetValue(ShowSurfaceProperty); set => SetValue(ShowSurfaceProperty, value); }
    public bool ShowLabels { get => (bool)GetValue(ShowLabelsProperty); set => SetValue(ShowLabelsProperty, value); }
    public bool ShowDemandPoint { get => (bool)GetValue(ShowDemandPointProperty); set => SetValue(ShowDemandPointProperty, value); }
    public bool ShowGoverningPoint { get => (bool)GetValue(ShowGoverningPointProperty); set => SetValue(ShowGoverningPointProperty, value); }
    public int ResetVersion { get => (int)GetValue(ResetVersionProperty); set => SetValue(ResetVersionProperty, value); }
    public string UnitLabels { get => (string)GetValue(UnitLabelsProperty); set => SetValue(UnitLabelsProperty, value); }
    public double SelectedPmAngle { get => (double)GetValue(SelectedPmAngleProperty); set => SetValue(SelectedPmAngleProperty, value); }
    public double SelectedAxialLoad { get => (double)GetValue(SelectedAxialLoadProperty); set => SetValue(SelectedAxialLoadProperty, value); }
    public bool ShowSlicePlane { get => (bool)GetValue(ShowSlicePlaneProperty); set => SetValue(ShowSlicePlaneProperty, value); }
    public bool ShowAxialLoadSlice { get => (bool)GetValue(ShowAxialLoadSliceProperty); set => SetValue(ShowAxialLoadSliceProperty, value); }

    public void ResetCamera()
    {
        yaw = DefaultYaw;
        pitch = DefaultPitch;
        zoom = DefaultZoom;
        pan = new Vector(0, 0);
        InvalidateVisual();
    }

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);
        dc.DrawRoundedRectangle(Brushes.White, new Pen(new SolidColorBrush(Color.FromRgb(214, 222, 230)), 1), new Rect(0, 0, ActualWidth, ActualHeight), 6, 6);
        DrawText(dc, "Left drag rotate | Wheel zoom | Right/middle drag pan | Double-click reset", 9.0, new SolidColorBrush(Color.FromRgb(82, 97, 111)), new Point(12, 10));

        EnsureScene();
        if (cachedScene is null)
        {
            DrawText(dc, "No 3D surface data", 13, Brushes.Gray, new Point(20, 44));
            return;
        }

        var scene = cachedScene;
        Func<double, double, double, ProjectedPoint> proj = (x, y, z) => Project(x, y, z, scene.Bounds);

        if (ShowSlicePlane) DrawPmAngleSlicePlane(dc, scene, proj);
        if (ShowAxialLoadSlice) DrawAxialLoadSlicePlane(dc, scene, proj);
        if (ShowGrid) DrawGrid(dc, scene, proj);
        if (ShowWireframe) DrawNominalWireframe(dc, scene, proj);
        if (ShowSurface) DrawDesignSurface(dc, scene, proj);
        if (ShowWireframe)
        {
            DrawDesignEdges(dc, scene, proj);
        }
        DrawAxes(dc, scene, proj);

        if (ShowDemandPoint) DrawDemandMarkers(dc, scene.DemandPts, proj);
        if (ShowLabels) DrawSliceLabels(dc, scene);
        DrawOrientationCube(dc);
    }

    private void EnsureScene()
    {
        if (cachedScene is not null) return;

        var all = (Points ?? []).Where(IsFinite).ToList();
        var demands = (DemandPoints ?? Enumerable.Empty<ControlPointDto>()).Where(IsFinite).ToList();
        if (demands.Count == 0 && DemandPoint is not null && IsFinite(DemandPoint)) demands.Add(DemandPoint);
        if (ShowDemandPoint) all.AddRange(demands);
        if (all.Count == 0) { cachedScene = null; return; }

        var surface = all.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference).ToList();
        var design = surface.Where(p => !p.IsNominal).ToList();
        var nominal = surface.Where(p => p.IsNominal).ToList();
        var bounds = ComputeBounds(all);

        var designRows = BuildStructuredRows(design);
        var nominalRows = BuildStructuredRows(nominal);
        var designQuads = BuildQuads(designRows);
        var designEdges = BuildStructuredWire(designRows);
        var nominalWire = BuildStructuredWire(nominalRows);

        double angleRad = SelectedPmAngle * Math.PI / 180.0;
        double sliceDirX = Math.Cos(angleRad);
        double sliceDirY = Math.Sin(angleRad);
        double sliceExtent = Math.Max(bounds.MaxX - bounds.MinX, bounds.MaxY - bounds.MinY) * 0.68;

        var demandPts = demands.Select(p => (p.X, p.Y, p.Z, p.Label)).ToList();

        cachedScene = new CachedScene(
            bounds,
            designQuads,
            designEdges,
            nominalWire,
            sliceDirX,
            sliceDirY,
            sliceExtent,
            demandPts);
    }

    private static IReadOnlyList<IReadOnlyList<ControlPointDto>> BuildStructuredRows(IReadOnlyList<ControlPointDto> points)
    {
        return points
            .GroupBy(DepthRowKey)
            .OrderBy(g => g.Key)
            .Select(g => (IReadOnlyList<ControlPointDto>)g.OrderBy(p => NormalizeTheta(p.ThetaDegrees)).ToList())
            .Where(g => g.Count > 2)
            .ToList();
    }

    private static IReadOnlyList<SurfaceQuad> BuildQuads(IReadOnlyList<IReadOnlyList<ControlPointDto>> rows)
    {
        var quads = new List<SurfaceQuad>();
        for (int i = 0; i < rows.Count - 1; i++)
        {
            var a = rows[i];
            var b = rows[i + 1];
            int count = Math.Min(a.Count, b.Count);
            for (int j = 0; j < count; j++)
            {
                int next = (j + 1) % count;
                var q = new SurfaceQuad(Point3.From(a[j]), Point3.From(a[next]), Point3.From(b[next]), Point3.From(b[j]));
                if (q.IsValid) quads.Add(q);
            }
        }

        // spColumn keeps the first/last structured rings as tiny perturbed pole rings.
        // This WPF renderer is a painter-style projection rather than a true 3D mesh
        // pipeline, so close those pole openings visually without changing the DTO
        // control points or engineering surface topology.
        if (rows.Count > 0)
        {
            AddPoleClosureFaces(quads, rows[0], reverseWinding: true);
            AddPoleClosureFaces(quads, rows[^1], reverseWinding: false);
        }

        return quads;
    }

    private static void AddPoleClosureFaces(ICollection<SurfaceQuad> quads, IReadOnlyList<ControlPointDto> ring, bool reverseWinding)
    {
        if (ring.Count < 3) return;

        var center = new Point3(
            ring.Average(p => p.X),
            ring.Average(p => p.Y),
            ring.Average(p => p.Z));

        for (int i = 0; i < ring.Count; i++)
        {
            var a = Point3.From(ring[i]);
            var b = Point3.From(ring[(i + 1) % ring.Count]);
            var q = reverseWinding
                ? new SurfaceQuad(center, b, a, center)
                : new SurfaceQuad(center, a, b, center);
            if (q.IsValid) quads.Add(q);
        }
    }

    private static IReadOnlyList<Line3> BuildStructuredWire(IReadOnlyList<IReadOnlyList<ControlPointDto>> rows)
    {
        var lines = new List<Line3>();
        foreach (var row in rows)
        {
            for (int j = 0; j < row.Count; j++)
            {
                lines.Add(new Line3(Point3.From(row[j]), Point3.From(row[(j + 1) % row.Count])));
            }
        }

        if (rows.Count > 1)
        {
            int count = rows.Min(r => r.Count);
            for (int theta = 0; theta < count; theta++)
            {
                for (int row = 0; row < rows.Count - 1; row++)
                {
                    lines.Add(new Line3(Point3.From(rows[row][theta]), Point3.From(rows[row + 1][theta])));
                }
            }
        }

        return lines;
    }

    private void InvalidateScene()
    {
        cachedScene = null;
        InvalidateVisual();
    }

    private void DrawDesignSurface(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var projected = new List<ProjectedQuad>();
        foreach (var quad in scene.DesignQuads)
        {
            if (ProjectQuad(quad, proj) is ProjectedQuad projectedQuad)
            {
                projected.Add(projectedQuad);
            }
        }

        projected = projected.OrderByDescending(q => q.Depth).ToList();

        foreach (var q in projected)
        {
            var shade = (byte)Math.Clamp(172 + q.Light * 45, 158, 218);
            var brush = new SolidColorBrush(Color.FromArgb(138, 120, shade, 232));
            brush.Freeze();

            var geo = new StreamGeometry();
            using var ctx = geo.Open();
            ctx.BeginFigure(q.P0, true, true);
            ctx.LineTo(q.P1, false, false);
            ctx.LineTo(q.P2, false, false);
            ctx.LineTo(q.P3, false, false);
            geo.Freeze();
            dc.DrawGeometry(brush, null, geo);
        }
    }

    private void DrawDesignEdges(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var pen = new Pen(new SolidColorBrush(Color.FromArgb(150, 0, 75, 133)), 0.45);
        pen.Freeze();
        DrawLines(dc, scene.DesignEdges, proj, pen);
    }

    private void DrawNominalWireframe(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var pen = new Pen(new SolidColorBrush(Color.FromArgb(150, 172, 178, 186)), 0.42);
        pen.Freeze();
        DrawLines(dc, scene.NominalWire, proj, pen);
    }

    private static void DrawLines(DrawingContext dc, IEnumerable<Line3> lines, Func<double, double, double, ProjectedPoint> proj, Pen pen)
    {
        foreach (var line in lines)
        {
            var a = proj(line.A.X, line.A.Y, line.A.Z);
            var b = proj(line.B.X, line.B.Y, line.B.Z);
            if (IsFinite(a.Screen) && IsFinite(b.Screen)) dc.DrawLine(pen, a.Screen, b.Screen);
        }
    }

    private ProjectedQuad? ProjectQuad(SurfaceQuad q, Func<double, double, double, ProjectedPoint> proj)
    {
        var p0 = proj(q.P0.X, q.P0.Y, q.P0.Z);
        var p1 = proj(q.P1.X, q.P1.Y, q.P1.Z);
        var p2 = proj(q.P2.X, q.P2.Y, q.P2.Z);
        var p3 = proj(q.P3.X, q.P3.Y, q.P3.Z);
        if (!IsFinite(p0.Screen) || !IsFinite(p1.Screen) || !IsFinite(p2.Screen) || !IsFinite(p3.Screen)) return null;

        var normal = Normal(q.P0, q.P1, q.P2);
        var light = Normalize(new Point3(-0.35, -0.45, 0.82));
        double intensity = Math.Max(0.12, Dot(normal, light));
        double depth = (p0.Depth + p1.Depth + p2.Depth + p3.Depth) / 4.0;
        return new ProjectedQuad(p0.Screen, p1.Screen, p2.Screen, p3.Screen, depth, intensity);
    }

    private void DrawPmAngleSlicePlane(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var b = scene.Bounds;
        double ext = scene.SliceExtent;
        double angleRad = SelectedPmAngle * Math.PI / 180.0;
        double dx = Math.Cos(angleRad);
        double dy = Math.Sin(angleRad);
        var v0 = proj(-ext * dx, -ext * dy, b.MinZ);
        var v1 = proj(-ext * dx, -ext * dy, b.MaxZ);
        var v2 = proj(ext * dx, ext * dy, b.MaxZ);
        var v3 = proj(ext * dx, ext * dy, b.MinZ);
        if (!IsFinite(v0.Screen) || !IsFinite(v1.Screen) || !IsFinite(v2.Screen) || !IsFinite(v3.Screen)) return;

        var fill = new SolidColorBrush(Color.FromArgb(82, 150, 220, 175));
        fill.Freeze();
        var border = new Pen(new SolidColorBrush(Color.FromArgb(145, 58, 160, 92)), 0.9);
        border.Freeze();
        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(v0.Screen, true, true);
        ctx.LineTo(v1.Screen, false, false);
        ctx.LineTo(v2.Screen, false, false);
        ctx.LineTo(v3.Screen, false, false);
        geo.Freeze();
        dc.DrawGeometry(fill, border, geo);
    }

    private void DrawAxialLoadSlicePlane(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var b = scene.Bounds;
        double z = Math.Clamp(SelectedAxialLoad, b.MinZ, b.MaxZ);
        double ext = scene.SliceExtent * 0.92;
        var v0 = proj(-ext, -ext, z);
        var v1 = proj(ext, -ext, z);
        var v2 = proj(ext, ext, z);
        var v3 = proj(-ext, ext, z);
        if (!IsFinite(v0.Screen) || !IsFinite(v1.Screen) || !IsFinite(v2.Screen) || !IsFinite(v3.Screen)) return;

        var fill = new SolidColorBrush(Color.FromArgb(46, 135, 180, 225));
        var border = new Pen(new SolidColorBrush(Color.FromArgb(120, 70, 120, 160)), 0.85);
        fill.Freeze();
        border.Freeze();

        var geo = new StreamGeometry();
        using var ctx = geo.Open();
        ctx.BeginFigure(v0.Screen, true, true);
        ctx.LineTo(v1.Screen, false, false);
        ctx.LineTo(v2.Screen, false, false);
        ctx.LineTo(v3.Screen, false, false);
        geo.Freeze();
        dc.DrawGeometry(fill, border, geo);
    }

    private void DrawSliceLabels(DrawingContext dc, CachedScene scene)
    {
        var forceUnit = string.IsNullOrEmpty(UnitLabels) || !UnitLabels.Contains(',') ? "" : UnitLabels.Split(',')[1].Trim();
        var brush = new SolidColorBrush(Color.FromRgb(31, 41, 51));
        brush.Freeze();
        var basePoint = new Point(14, Math.Max(36, ActualHeight - 58));
        if (ShowSlicePlane) DrawText(dc, $"PM at \u03b8 = {SelectedPmAngle:F1}\u00b0", 10.5, brush, basePoint);
        if (ShowAxialLoadSlice) DrawText(dc, $"Mx-My at P = {SelectedAxialLoad:F1} {forceUnit}", 10.5, brush, new Point(basePoint.X, basePoint.Y + 18));
    }

    private void DrawGrid(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var b = scene.Bounds;
        var pen = new Pen(new SolidColorBrush(Color.FromArgb(42, 180, 190, 210)), 0.55);
        pen.Freeze();
        for (int i = 0; i <= 8; i++)
        {
            double t = i / 8.0;
            double x = b.MinX + (b.MaxX - b.MinX) * t;
            double y = b.MinY + (b.MaxY - b.MinY) * t;
            dc.DrawLine(pen, proj(x, b.MinY, 0).Screen, proj(x, b.MaxY, 0).Screen);
            dc.DrawLine(pen, proj(b.MinX, y, 0).Screen, proj(b.MaxX, y, 0).Screen);
        }
    }

    private void DrawAxes(DrawingContext dc, CachedScene scene, Func<double, double, double, ProjectedPoint> proj)
    {
        var axes = BuildEngineeringAxes(scene.Bounds);
        var xEnd = proj(axes.MxPositive.X, axes.MxPositive.Y, axes.MxPositive.Z).Screen;
        var yEnd = proj(axes.MyPositive.X, axes.MyPositive.Y, axes.MyPositive.Z).Screen;
        var zEnd = proj(axes.PPositive.X, axes.PPositive.Y, axes.PPositive.Z).Screen;
        var xNeg = proj(axes.MxNegative.X, axes.MxNegative.Y, axes.MxNegative.Z).Screen;
        var yNeg = proj(axes.MyNegative.X, axes.MyNegative.Y, axes.MyNegative.Z).Screen;
        var zBase = proj(axes.PNegative.X, axes.PNegative.Y, axes.PNegative.Z).Screen;

        var xPen = new Pen(new SolidColorBrush(Color.FromRgb(255, 0, 0)), 2.2);
        var yPen = new Pen(new SolidColorBrush(Color.FromRgb(0, 185, 95)), 2.0);
        var zPen = new Pen(new SolidColorBrush(Color.FromRgb(0, 0, 255)), 2.2);
        xPen.Freeze(); yPen.Freeze(); zPen.Freeze();

        dc.DrawLine(xPen, xNeg, xEnd);
        dc.DrawLine(yPen, yNeg, yEnd);
        dc.DrawLine(zPen, zBase, zEnd);
        DrawArrow(dc, xEnd, xPen);
        DrawArrow(dc, yEnd, yPen);
        DrawArrow(dc, zEnd, zPen);

        if (ShowLabels)
        {
            var momentUnit = string.IsNullOrEmpty(UnitLabels) ? "" : $" ({UnitLabels.Split(',')[0].Trim()})";
            var forceUnit = string.IsNullOrEmpty(UnitLabels) || !UnitLabels.Contains(',') ? "" : $" ({UnitLabels.Split(',')[1].Trim()})";
            DrawText(dc, $"Mx{momentUnit}", 11, xPen.Brush, new Point(xEnd.X + 4, xEnd.Y - 14));
            DrawText(dc, $"My{momentUnit}", 11, yPen.Brush, new Point(yEnd.X + 4, yEnd.Y - 14));
            DrawText(dc, $"P{forceUnit}", 11, zPen.Brush, new Point(zEnd.X + 4, zEnd.Y - 14));
        }
    }

    public static AxisDefinitions BuildEngineeringAxesForTesting(double minX, double maxX, double minY, double maxY, double minZ, double maxZ)
        => BuildEngineeringAxes(new Bounds3D(minX, maxX, minY, maxY, minZ, maxZ));

    private static AxisDefinitions BuildEngineeringAxes(Bounds3D b)
    {
        const double axisExtend = 0.28;
        double xSpan = Math.Max(1e-9, b.MaxX - b.MinX);
        double ySpan = Math.Max(1e-9, b.MaxY - b.MinY);
        double zSpan = Math.Max(1e-9, b.MaxZ - b.MinZ);
        double xExt = xSpan * axisExtend;
        double yExt = ySpan * axisExtend;
        double zExt = zSpan * axisExtend;

        return new AxisDefinitions(
            new Point3(b.MinX - xExt, 0, 0),
            new Point3(b.MaxX + xExt, 0, 0),
            new Point3(0, b.MinY - yExt, 0),
            new Point3(0, b.MaxY + yExt, 0),
            new Point3(0, 0, Math.Min(0, b.MinZ) - zExt),
            new Point3(0, 0, b.MaxZ + zExt),
            new Point3(0, 0, 0));
    }

    private static void DrawArrow(DrawingContext dc, Point tip, Pen pen)
    {
        dc.DrawEllipse(pen.Brush, null, tip, 3, 3);
    }

    private void DrawOrientationCube(DrawingContext dc)
    {
        const double size = 52;
        var origin = new Point(Math.Max(72, ActualWidth - 72), Math.Max(72, ActualHeight - 58));
        var cube = new[]
        {
            new Point3(-1, -1, -1), new Point3(1, -1, -1), new Point3(1, 1, -1), new Point3(-1, 1, -1),
            new Point3(-1, -1, 1), new Point3(1, -1, 1), new Point3(1, 1, 1), new Point3(-1, 1, 1)
        };
        var edges = new[] { (0,1), (1,2), (2,3), (3,0), (4,5), (5,6), (6,7), (7,4), (0,4), (1,5), (2,6), (3,7) };
        var projected = cube.Select(p => ProjectOrientation(p, origin, size * 0.28)).ToArray();
        var edgePen = new Pen(new SolidColorBrush(Color.FromArgb(130, 160, 170, 184)), 0.8);
        edgePen.Freeze();
        foreach (var (a, b) in edges) dc.DrawLine(edgePen, projected[a], projected[b]);

        DrawOrientationAxis(dc, origin, new Point3(1.65, 0, 0), "Mx", Color.FromRgb(255, 0, 0), size);
        DrawOrientationAxis(dc, origin, new Point3(0, 1.65, 0), "My", Color.FromRgb(0, 185, 95), size);
        DrawOrientationAxis(dc, origin, new Point3(0, 0, 1.65), "P", Color.FromRgb(0, 0, 255), size);
    }

    private void DrawOrientationAxis(DrawingContext dc, Point origin, Point3 axis, string label, Color color, double size)
    {
        var brush = new SolidColorBrush(color);
        var pen = new Pen(brush, 1.35);
        brush.Freeze();
        pen.Freeze();
        var end = ProjectOrientation(axis, origin, size * 0.28);
        dc.DrawLine(pen, origin, end);
        dc.DrawEllipse(brush, null, end, 2.2, 2.2);
        DrawText(dc, label, 8.5, brush, new Point(end.X + 2, end.Y - 9));
    }

    private Point ProjectOrientation(Point3 p, Point origin, double scale)
    {
        double yr = yaw * Math.PI / 180.0;
        double pr = pitch * Math.PI / 180.0;
        double cosY = Math.Cos(yr), sinY = Math.Sin(yr);
        double cosP = Math.Cos(pr), sinP = Math.Sin(pr);
        double x1 = p.X * cosY - p.Y * sinY;
        double y1 = p.X * sinY + p.Y * cosY;
        double zView = p.Z * cosP - y1 * sinP;
        return new Point(origin.X + x1 * scale, origin.Y - zView * scale);
    }

    private void DrawDemandMarkers(DrawingContext dc, IReadOnlyList<(double X, double Y, double Z, string Label)> points, Func<double, double, double, ProjectedPoint> proj)
    {
        foreach (var point in points)
        {
            DrawMarker(dc, (point.X, point.Y, point.Z), proj, Color.FromRgb(227, 27, 35), string.IsNullOrWhiteSpace(point.Label) ? "Demand" : point.Label);
        }
    }

    private void DrawMarker(DrawingContext dc, (double X, double Y, double Z)? pt, Func<double, double, double, ProjectedPoint> proj, Color color, string label)
    {
        if (pt is null) return;
        var p = proj(pt.Value.X, pt.Value.Y, pt.Value.Z).Screen;
        if (!IsFinite(p)) return;

        var brush = new SolidColorBrush(color);
        brush.Freeze();
        dc.DrawEllipse(brush, new Pen(Brushes.White, 1.2), p, 5.6, 5.6);
        if (ShowLabels) DrawText(dc, label, 11, brush, new Point(p.X + 7, p.Y - 12));
    }

    private ProjectedPoint Project(double x, double y, double z, Bounds3D b)
    {
        double maxR = Math.Max(Math.Max(Math.Abs(b.MinX), Math.Abs(b.MaxX)), Math.Max(Math.Abs(b.MinY), Math.Abs(b.MaxY)));
        double maxP = Math.Max(Math.Abs(b.MinZ), Math.Abs(b.MaxZ));
        
        double sx = maxR < 1e-9 ? 0 : x / maxR;
        double sy = maxR < 1e-9 ? 0 : y / maxR;
        double sz = maxP < 1e-9 ? 0 : z / maxP;

        double yr = yaw * Math.PI / 180.0;
        double pr = pitch * Math.PI / 180.0;
        double cosY = Math.Cos(yr), sinY = Math.Sin(yr);
        double cosP = Math.Cos(pr), sinP = Math.Sin(pr);

        double x1 = sx * cosY - sy * sinY;
        double y1 = sx * sinY + sy * cosY;
        double zView = sz * cosP - y1 * sinP;
        double depth = y1 * cosP + sz * sinP;
        double size = Math.Min(ActualWidth, ActualHeight) * 0.42 * zoom;
        return new ProjectedPoint(new Point(ActualWidth / 2 + x1 * size + pan.X, ActualHeight / 2 - zView * size + pan.Y), depth);
    }



    private static Bounds3D ComputeBounds(IReadOnlyList<ControlPointDto> pts)
    {
        if (pts.Count == 0) return new Bounds3D(-1, 1, -1, 1, -1, 1);
        return new Bounds3D(
            Math.Min(0, pts.Min(p => p.X)), Math.Max(0, pts.Max(p => p.X)),
            Math.Min(0, pts.Min(p => p.Y)), Math.Max(0, pts.Max(p => p.Y)),
            Math.Min(0, pts.Min(p => p.Z)), Math.Max(0, pts.Max(p => p.Z)));
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2) { ResetCamera(); return; }
        Focus();
        CaptureMouse();
        dragStart = e.GetPosition(this);
        dragButton = e.ChangedButton;
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (dragStart is not Point start) return;
        var now = e.GetPosition(this);
        var delta = now - start;

        if (e.LeftButton == MouseButtonState.Pressed && dragButton == MouseButton.Left)
        {
            yaw += delta.X * 0.45;
            pitch = Math.Clamp(pitch - delta.Y * 0.35, -80, 80);
        }
        else if (e.RightButton == MouseButtonState.Pressed || e.MiddleButton == MouseButtonState.Pressed)
        {
            pan += delta;
        }

        dragStart = now;
        InvalidateVisual();
    }

    private static double NormalizeTheta(double theta)
    {
        var value = theta % 360.0;
        return value < 0 ? value + 360.0 : value;
    }

    private static double DepthRowKey(ControlPointDto point)
    {
        if (point.SliceKey.StartsWith("depth=", StringComparison.OrdinalIgnoreCase) &&
            double.TryParse(point.SliceKey["depth=".Length..], out double depthIndex))
        {
            return depthIndex;
        }

        return Math.Round(point.NeutralAxisDepth, 6);
    }

    private static Point3 Normal(Point3 a, Point3 b, Point3 c)
    {
        var u = new Point3(b.X - a.X, b.Y - a.Y, b.Z - a.Z);
        var v = new Point3(c.X - a.X, c.Y - a.Y, c.Z - a.Z);
        return Normalize(new Point3(u.Y * v.Z - u.Z * v.Y, u.Z * v.X - u.X * v.Z, u.X * v.Y - u.Y * v.X));
    }

    private static Point3 Normalize(Point3 p)
    {
        double length = Math.Sqrt(p.X * p.X + p.Y * p.Y + p.Z * p.Z);
        return length < 1e-12 ? new Point3(0, 0, 1) : new Point3(p.X / length, p.Y / length, p.Z / length);
    }

    private static double Dot(Point3 a, Point3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    private static bool IsFinite(ControlPointDto p) => IsFinite(p.X) && IsFinite(p.Y) && IsFinite(p.Z);
    private static bool IsFinite(Point p) => IsFinite(p.X) && IsFinite(p.Y);
    private static bool IsFinite(double value) => !double.IsNaN(value) && !double.IsInfinity(value);

    private static void DrawText(DrawingContext dc, string text, double size, Brush brush, Point point)
    {
        var ft = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), size, brush, 1.25);
        dc.DrawText(ft, point);
    }

    private static void OnResetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is InteractionViewport3D view) view.ResetCamera();
    }

    private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is InteractionViewport3D view) view.InvalidateScene();
    }

    private static void OnOptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is InteractionViewport3D view) view.InvalidateScene();
    }

    private sealed record Bounds3D(double MinX, double MaxX, double MinY, double MaxY, double MinZ, double MaxZ);
    public readonly record struct AxisDefinitions(Point3 MxNegative, Point3 MxPositive, Point3 MyNegative, Point3 MyPositive, Point3 PNegative, Point3 PPositive, Point3 Origin);

    public readonly record struct Point3(double X, double Y, double Z)
    {
        public static Point3 From(ControlPointDto p) => new(p.X, p.Y, p.Z);
    }

    private readonly record struct Line3(Point3 A, Point3 B);
    private readonly record struct ProjectedPoint(Point Screen, double Depth);
    private readonly record struct ProjectedQuad(Point P0, Point P1, Point P2, Point P3, double Depth, double Light);

    private readonly record struct SurfaceQuad(Point3 P0, Point3 P1, Point3 P2, Point3 P3)
    {
        public bool IsValid => IsFinite(P0.X) && IsFinite(P1.X) && IsFinite(P2.X) && IsFinite(P3.X);
    }

    private sealed record CachedScene(
        Bounds3D Bounds,
        IReadOnlyList<SurfaceQuad> DesignQuads,
        IReadOnlyList<Line3> DesignEdges,
        IReadOnlyList<Line3> NominalWire,
        double SliceDirX,
        double SliceDirY,
        double SliceExtent,
        IReadOnlyList<(double X, double Y, double Z, string Label)> DemandPts);
}

