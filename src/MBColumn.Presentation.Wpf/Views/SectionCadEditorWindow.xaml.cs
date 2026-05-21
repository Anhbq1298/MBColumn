using MBColumn.Presentation.Wpf.ViewModels;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MBColumn.Presentation.Wpf.Views;

public partial class SectionCadEditorWindow : Window
{
    private readonly SectionCadEditorViewModel vm;
    private readonly CadSnapService snapService = new();
    private double scale = 1.0;
    private double offsetX;
    private double offsetY;
    private object? selected;
    private bool isDragging;
    private bool isPanning;
    private Point lastMouse;
    private SnapKind activeSnapKind = SnapKind.None;

    public SectionCadEditorWindow(InputViewModel source)
    {
        InitializeComponent();
        vm = new SectionCadEditorViewModel(source);
        DataContext = vm;
        vm.BoundaryPoints.CollectionChanged += OnCollectionChanged;
        vm.Rebars.CollectionChanged += OnCollectionChanged;
        foreach (var p in vm.BoundaryPoints) p.PropertyChanged += OnItemChanged;
        foreach (var r in vm.Rebars) r.PropertyChanged += OnItemChanged;
        vm.PropertyChanged += OnViewModelPropertyChanged;
        Loaded += (_, _) => FitToExtents();
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(SectionCadEditorViewModel.GridSpacing)
            or nameof(SectionCadEditorViewModel.IsSnapToGridEnabled)
            or nameof(SectionCadEditorViewModel.IsSnapToMidpointEnabled)
            or nameof(SectionCadEditorViewModel.ToolMode))
            Render();
    }

    private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems is not null)
            foreach (var item in e.NewItems.OfType<INotifyPropertyChanged>())
                item.PropertyChanged += OnItemChanged;
        if (e.OldItems is not null)
            foreach (var item in e.OldItems.OfType<INotifyPropertyChanged>())
                item.PropertyChanged -= OnItemChanged;
        Render();
    }

    private void OnItemChanged(object? sender, PropertyChangedEventArgs e) => Render();

    private void DrawingCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (offsetX == 0 && offsetY == 0)
            FitToExtents();
        else
            Render();
    }

    private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DrawingCanvas.Focus();
        lastMouse = e.GetPosition(DrawingCanvas);

        if (e.ChangedButton == MouseButton.Right)
        {
            isPanning = true;
            DrawingCanvas.CaptureMouse();
            return;
        }

        if (vm.ToolMode == CadToolMode.Polyline)
        {
            if (e.ClickCount == 2)
            {
                vm.FinishPolyline();
                Render();
                return;
            }
            var (x, y) = GetFinalPolylinePoint(lastMouse);
            vm.AddPolylinePoint(x, y);
            Render();
            return;
        }

        var world = ScreenToWorld(lastMouse);
        if (vm.ToolMode == CadToolMode.AddBoundaryPoint)
        {
            vm.AddBoundaryPoint(world.X, world.Y);
            Render();
            return;
        }
        if (vm.ToolMode == CadToolMode.AddRebar)
        {
            vm.AddRebar(world.X, world.Y);
            Render();
            return;
        }

        selected = HitTest(lastMouse);
        if (vm.ToolMode == CadToolMode.Delete)
        {
            DeleteSelected();
            Render();
            return;
        }

        if (selected is not null)
        {
            isDragging = true;
            DrawingCanvas.CaptureMouse();
            Render();
        }
    }

    private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        var pos = e.GetPosition(DrawingCanvas);

        if (isPanning)
        {
            offsetX += pos.X - lastMouse.X;
            offsetY += pos.Y - lastMouse.Y;
            lastMouse = pos;
            Render();
            return;
        }

        if (vm.ToolMode == CadToolMode.Polyline && vm.Draft.IsActive)
        {
            var (x, y) = GetFinalPolylinePoint(pos);
            vm.UpdatePolylinePreview(x, y);
            Render();
            return;
        }

        if (!isDragging || selected is null) return;
        var world = ScreenToWorld(pos);
        var (sx, sy) = ApplySnap(world.X, world.Y);
        if (selected is CadPointViewModel p)
        {
            p.X = Math.Round(sx, 3);
            p.Y = Math.Round(sy, 3);
        }
        else if (selected is CadRebarViewModel r)
        {
            r.X = Math.Round(sx, 3);
            r.Y = Math.Round(sy, 3);
        }
    }

    private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
    {
        isDragging = false;
        isPanning = false;
        DrawingCanvas.ReleaseMouseCapture();
    }

    private void DrawingCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        var before = ScreenToWorld(e.GetPosition(DrawingCanvas));
        scale *= e.Delta > 0 ? 1.12 : 1.0 / 1.12;
        scale = Math.Clamp(scale, 0.02, 50);
        var after = WorldToScreen(before);
        var mouse = e.GetPosition(DrawingCanvas);
        offsetX += mouse.X - after.X;
        offsetY += mouse.Y - after.Y;
        Render();
    }

    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (vm.ToolMode != CadToolMode.Polyline) return;
        if (e.Key == Key.Enter)
        {
            vm.FinishPolyline();
            Render();
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            vm.CancelPolyline();
            activeSnapKind = SnapKind.None;
            Render();
            e.Handled = true;
        }
    }

    // --- Polyline helpers ---

    private (double X, double Y) GetFinalPolylinePoint(Point screenPos)
    {
        var world = ScreenToWorld(screenPos);
        double x = world.X, y = world.Y;

        if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && vm.Draft.Points.Count > 0)
        {
            var last = vm.Draft.Points[^1];
            var dx = x - last.X;
            var dy = y - last.Y;
            if (Math.Abs(dx) >= Math.Abs(dy))
                y = last.Y;
            else
                x = last.X;
        }

        return ApplySnap(x, y);
    }

    private (double X, double Y) ApplySnap(double modelX, double modelY)
    {
        var result = snapService.Snap(modelX, modelY,
            vm.IsSnapToMidpointEnabled, vm.IsSnapToGridEnabled,
            vm.GridSpacing, scale,
            GetSnapSegments());
        activeSnapKind = result.Kind;
        return (result.X, result.Y);
    }

    private IEnumerable<(double X1, double Y1, double X2, double Y2)> GetSnapSegments()
    {
        var bp = vm.BoundaryPoints;
        if (bp.Count >= 2)
            for (var i = 0; i < bp.Count; i++)
            {
                var a = bp[i];
                var b = bp[(i + 1) % bp.Count];
                yield return (a.X, a.Y, b.X, b.Y);
            }

        var pts = vm.Draft.Points;
        for (var i = 0; i < pts.Count - 1; i++)
            yield return (pts[i].X, pts[i].Y, pts[i + 1].X, pts[i + 1].Y);
    }

    // --- Hit test & delete ---

    private object? HitTest(Point screen)
    {
        object? best = null;
        var bestDistance = 12.0;
        foreach (var p in vm.BoundaryPoints)
        {
            var s = WorldToScreen(new Point(p.X, p.Y));
            var d = Distance(screen, s);
            if (d < bestDistance) { bestDistance = d; best = p; }
        }
        foreach (var r in vm.Rebars)
        {
            var s = WorldToScreen(new Point(r.X, r.Y));
            var d = Distance(screen, s);
            if (d < bestDistance) { bestDistance = d; best = r; }
        }
        return best;
    }

    private void DeleteSelected()
    {
        if (selected is CadPointViewModel p) vm.BoundaryPoints.Remove(p);
        if (selected is CadRebarViewModel r) vm.Rebars.Remove(r);
        selected = null;
    }

    // --- Rendering ---

    private void Render()
    {
        if (DrawingCanvas.ActualWidth <= 0 || DrawingCanvas.ActualHeight <= 0) return;
        DrawingCanvas.Children.Clear();
        DrawGrid();
        DrawBoundary();
        DrawPolylineDraft();
        DrawRebars();
    }

    private void DrawGrid()
    {
        var modelStep = Math.Max(1.0, vm.GridSpacing);
        var screenStep = modelStep * scale;
        if (screenStep < 4.0) return;

        var tl = ScreenToWorld(new Point(0, 0));
        var br = ScreenToWorld(new Point(DrawingCanvas.ActualWidth, DrawingCanvas.ActualHeight));
        var minX = Math.Floor(Math.Min(tl.X, br.X) / modelStep) * modelStep;
        var maxX = Math.Ceiling(Math.Max(tl.X, br.X) / modelStep) * modelStep;
        var minY = Math.Floor(Math.Min(tl.Y, br.Y) / modelStep) * modelStep;
        var maxY = Math.Ceiling(Math.Max(tl.Y, br.Y) / modelStep) * modelStep;

        for (var x = minX; x <= maxX; x += modelStep)
        {
            var a = WorldToScreen(new Point(x, minY));
            var b = WorldToScreen(new Point(x, maxY));
            DrawingCanvas.Children.Add(new Line { X1 = a.X, Y1 = a.Y, X2 = b.X, Y2 = b.Y, Stroke = Brushes.Gainsboro, StrokeThickness = 1 });
        }
        for (var y = minY; y <= maxY; y += modelStep)
        {
            var a = WorldToScreen(new Point(minX, y));
            var b = WorldToScreen(new Point(maxX, y));
            DrawingCanvas.Children.Add(new Line { X1 = a.X, Y1 = a.Y, X2 = b.X, Y2 = b.Y, Stroke = Brushes.Gainsboro, StrokeThickness = 1 });
        }
    }

    private void DrawBoundary()
    {
        if (vm.BoundaryPoints.Count >= 2)
        {
            var polygon = new Polygon
            {
                Stroke = new SolidColorBrush(Color.FromRgb(0, 75, 133)),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Color.FromArgb(22, 29, 111, 184))
            };
            foreach (var p in vm.BoundaryPoints)
                polygon.Points.Add(WorldToScreen(new Point(p.X, p.Y)));
            DrawingCanvas.Children.Add(polygon);
        }

        foreach (var p in vm.BoundaryPoints)
            AddHandle(WorldToScreen(new Point(p.X, p.Y)), selected == p ? Brushes.OrangeRed : Brushes.White, Brushes.DarkBlue, 8);
    }

    private void DrawPolylineDraft()
    {
        if (vm.ToolMode != CadToolMode.Polyline) return;
        var pts = vm.Draft.Points;
        if (pts.Count == 0) return;

        var draftStroke = new SolidColorBrush(Color.FromRgb(0, 130, 220));
        var screenPts = pts.Select(p => WorldToScreen(new Point(p.X, p.Y))).ToList();

        for (var i = 0; i < screenPts.Count - 1; i++)
        {
            DrawingCanvas.Children.Add(new Line
            {
                X1 = screenPts[i].X, Y1 = screenPts[i].Y,
                X2 = screenPts[i + 1].X, Y2 = screenPts[i + 1].Y,
                Stroke = draftStroke,
                StrokeThickness = 2
            });
        }

        if (vm.Draft.PreviewPoint.HasValue)
        {
            var prev = WorldToScreen(new Point(vm.Draft.PreviewPoint.Value.X, vm.Draft.PreviewPoint.Value.Y));
            var last = screenPts[^1];
            DrawingCanvas.Children.Add(new Line
            {
                X1 = last.X, Y1 = last.Y,
                X2 = prev.X, Y2 = prev.Y,
                Stroke = draftStroke,
                StrokeThickness = 1.5,
                StrokeDashArray = new DoubleCollection([5, 4])
            });
            DrawSnapMarker(prev);
        }

        foreach (var sp in screenPts)
            AddHandle(sp, Brushes.White, draftStroke, 6);
    }

    private void DrawSnapMarker(Point screen)
    {
        const double size = 5.0;
        switch (activeSnapKind)
        {
            case SnapKind.Grid:
                DrawingCanvas.Children.Add(new Line { X1 = screen.X - size, Y1 = screen.Y, X2 = screen.X + size, Y2 = screen.Y, Stroke = Brushes.Teal, StrokeThickness = 1.5 });
                DrawingCanvas.Children.Add(new Line { X1 = screen.X, Y1 = screen.Y - size, X2 = screen.X, Y2 = screen.Y + size, Stroke = Brushes.Teal, StrokeThickness = 1.5 });
                break;
            case SnapKind.Midpoint:
                var diamond = new Polygon { Stroke = Brushes.DarkOrange, StrokeThickness = 1.5, Fill = Brushes.Transparent };
                diamond.Points.Add(new Point(screen.X, screen.Y - size));
                diamond.Points.Add(new Point(screen.X + size, screen.Y));
                diamond.Points.Add(new Point(screen.X, screen.Y + size));
                diamond.Points.Add(new Point(screen.X - size, screen.Y));
                DrawingCanvas.Children.Add(diamond);
                break;
        }
    }

    private void DrawRebars()
    {
        foreach (var r in vm.Rebars)
            AddHandle(WorldToScreen(new Point(r.X, r.Y)), selected == r ? Brushes.OrangeRed : Brushes.DarkBlue, Brushes.White, 10);
    }

    private void AddHandle(Point p, Brush fill, Brush stroke, double size)
    {
        var ellipse = new Ellipse { Width = size, Height = size, Fill = fill, Stroke = stroke, StrokeThickness = 1.5 };
        Canvas.SetLeft(ellipse, p.X - size / 2);
        Canvas.SetTop(ellipse, p.Y - size / 2);
        DrawingCanvas.Children.Add(ellipse);
    }

    // --- Fit / coordinate transforms ---

    private void Fit_Click(object sender, RoutedEventArgs e) => FitToExtents();

    private void FitToExtents()
    {
        var points = vm.BoundaryPoints.Select(p => new Point(p.X, p.Y))
            .Concat(vm.Rebars.Select(r => new Point(r.X, r.Y)))
            .ToList();
        if (points.Count == 0 || DrawingCanvas.ActualWidth <= 0 || DrawingCanvas.ActualHeight <= 0)
        {
            offsetX = DrawingCanvas.ActualWidth / 2;
            offsetY = DrawingCanvas.ActualHeight / 2;
            scale = 1;
            Render();
            return;
        }

        var minX = points.Min(p => p.X);
        var maxX = points.Max(p => p.X);
        var minY = points.Min(p => p.Y);
        var maxY = points.Max(p => p.Y);
        var width = Math.Max(1, maxX - minX);
        var height = Math.Max(1, maxY - minY);
        scale = Math.Min((DrawingCanvas.ActualWidth - 80) / width, (DrawingCanvas.ActualHeight - 80) / height);
        scale = Math.Clamp(scale, 0.02, 50);
        var center = new Point((minX + maxX) / 2, (minY + maxY) / 2);
        offsetX = DrawingCanvas.ActualWidth / 2 - center.X * scale;
        offsetY = DrawingCanvas.ActualHeight / 2 + center.Y * scale;
        Render();
    }

    private Point WorldToScreen(Point p) => new(p.X * scale + offsetX, -p.Y * scale + offsetY);
    private Point ScreenToWorld(Point p) => new((p.X - offsetX) / scale, -(p.Y - offsetY) / scale);
    private static double Distance(Point a, Point b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

    private void Apply_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            vm.ApplyToSource();
            DialogResult = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "CAD Lite Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
