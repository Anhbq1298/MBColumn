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
    private double scale = 1.0;
    private double offsetX;
    private double offsetY;
    private object? selected;
    private bool isDragging;
    private bool isPanning;
    private Point lastMouse;

    public SectionCadEditorWindow(InputViewModel source)
    {
        InitializeComponent();
        vm = new SectionCadEditorViewModel(source);
        DataContext = vm;
        vm.BoundaryPoints.CollectionChanged += OnCollectionChanged;
        vm.Rebars.CollectionChanged += OnCollectionChanged;
        foreach (var p in vm.BoundaryPoints) p.PropertyChanged += OnItemChanged;
        foreach (var r in vm.Rebars) r.PropertyChanged += OnItemChanged;
        Loaded += (_, _) => FitToExtents();
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

        if (!isDragging || selected is null) return;
        var world = ScreenToWorld(pos);
        if (selected is CadPointViewModel p)
        {
            p.X = Math.Round(world.X, 3);
            p.Y = Math.Round(world.Y, 3);
        }
        else if (selected is CadRebarViewModel r)
        {
            r.X = Math.Round(world.X, 3);
            r.Y = Math.Round(world.Y, 3);
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

    private void Render()
    {
        if (DrawingCanvas.ActualWidth <= 0 || DrawingCanvas.ActualHeight <= 0) return;
        DrawingCanvas.Children.Clear();
        DrawGrid();
        DrawBoundary();
        DrawRebars();
    }

    private void DrawGrid()
    {
        var step = 100.0;
        var tl = ScreenToWorld(new Point(0, 0));
        var br = ScreenToWorld(new Point(DrawingCanvas.ActualWidth, DrawingCanvas.ActualHeight));
        var minX = Math.Floor(Math.Min(tl.X, br.X) / step) * step;
        var maxX = Math.Ceiling(Math.Max(tl.X, br.X) / step) * step;
        var minY = Math.Floor(Math.Min(tl.Y, br.Y) / step) * step;
        var maxY = Math.Ceiling(Math.Max(tl.Y, br.Y) / step) * step;

        for (var x = minX; x <= maxX; x += step)
        {
            var a = WorldToScreen(new Point(x, minY));
            var b = WorldToScreen(new Point(x, maxY));
            DrawingCanvas.Children.Add(new Line { X1 = a.X, Y1 = a.Y, X2 = b.X, Y2 = b.Y, Stroke = Brushes.Gainsboro, StrokeThickness = 1 });
        }
        for (var y = minY; y <= maxY; y += step)
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
