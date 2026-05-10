using System.Windows;
using ColumnDesigner.Application.DTOs;

namespace ColumnDesigner.Presentation.Wpf.Controls;

public sealed class ChartTransformHelper
{
    public ChartTransformHelper(IEnumerable<ControlPointDto> points, Rect plot, Rect? boundsOverride = null, bool useEqualAspect = false)
    {
        Plot = plot;
        if (boundsOverride.HasValue)
        {
            MinX = boundsOverride.Value.Left;
            MaxX = boundsOverride.Value.Right;
            MinY = boundsOverride.Value.Top;
            MaxY = boundsOverride.Value.Bottom;
        }
        else
        {
            var list = points.ToList();
            MinX = list.Count == 0 ? -1 : list.Min(p => p.X);
            MaxX = list.Count == 0 ? 1 : list.Max(p => p.X);
            MinY = list.Count == 0 ? -1 : list.Min(p => p.Y);
            MaxY = list.Count == 0 ? 1 : list.Max(p => p.Y);
        }
        IncludeZero();
        Pad();
        SnapToBounds();
        if (useEqualAspect)
        {
            ApplyEqualAspect();
        }
    }

    public double MinX { get; private set; }
    public double MaxX { get; private set; }
    public double MinY { get; private set; }
    public double MaxY { get; private set; }
    public Rect Plot { get; }

    public static ChartTransformHelper AutoFit2D(IEnumerable<ControlPointDto> points, Rect plot, Rect? boundsOverride = null, bool useEqualAspect = false)
        => new(points, plot, boundsOverride, useEqualAspect);

    public Point ToScreen(double x, double y)
    {
        double px = Plot.Left + (x - MinX) / (MaxX - MinX) * Plot.Width;
        double py = Plot.Bottom - (y - MinY) / (MaxY - MinY) * Plot.Height;
        return new Point(px, py);
    }

    public Point ToData(Point screen)
    {
        double x = MinX + (screen.X - Plot.Left) / Plot.Width * (MaxX - MinX);
        double y = MinY + (Plot.Bottom - screen.Y) / Plot.Height * (MaxY - MinY);
        return new Point(x, y);
    }

    public IEnumerable<double> TicksX() => Ticks(MinX, MaxX);
    public IEnumerable<double> TicksY() => Ticks(MinY, MaxY);
    public AxisTicks AxisTicksX() => AxisTickService.Generate(MinX, MaxX, Math.Max(4, (int)(Plot.Width / 80)));
    public AxisTicks AxisTicksY() => AxisTickService.Generate(MinY, MaxY, Math.Max(4, (int)(Plot.Height / 60)));
    public double AxisXValue => MinY <= 0 && MaxY >= 0 ? 0 : MinY > 0 ? MinY : MaxY;
    public double AxisYValue => MinX <= 0 && MaxX >= 0 ? 0 : MinX > 0 ? MinX : MaxX;

    private void IncludeZero()
    {
        MinX = Math.Min(MinX, 0); MaxX = Math.Max(MaxX, 0);
        MinY = Math.Min(MinY, 0); MaxY = Math.Max(MaxY, 0);
        if (Math.Abs(MaxX - MinX) < 1e-9) { MinX -= 1; MaxX += 1; }
        if (Math.Abs(MaxY - MinY) < 1e-9) { MinY -= 1; MaxY += 1; }
    }

    private void Pad()
    {
        double dx = MaxX - MinX;
        double dy = MaxY - MinY;
        MinX -= dx * 0.08; MaxX += dx * 0.08;
        MinY -= dy * 0.08; MaxY += dy * 0.08;
    }

    private void SnapToBounds()
    {
        var xTicks = AxisTickService.Generate(MinX, MaxX, Math.Max(4, (int)(Plot.Width / 80)));
        MinX = Math.Min(MinX, xTicks.Min);
        MaxX = Math.Max(MaxX, xTicks.Max);

        var yTicks = AxisTickService.Generate(MinY, MaxY, Math.Max(4, (int)(Plot.Height / 60)));
        MinY = Math.Min(MinY, yTicks.Min);
        MaxY = Math.Max(MaxY, yTicks.Max);
    }

    private void ApplyEqualAspect()
    {
        if (Plot.Width <= 0 || Plot.Height <= 0) return;

        double dx = MaxX - MinX;
        double dy = MaxY - MinY;
        if (dx <= 1e-12 || dy <= 1e-12) return;

        double plotAspect = Plot.Width / Plot.Height;
        double dataAspect = dx / dy;
        double cx = (MinX + MaxX) * 0.5;
        double cy = (MinY + MaxY) * 0.5;

        if (dataAspect < plotAspect)
        {
            double targetDx = dy * plotAspect;
            MinX = cx - targetDx * 0.5;
            MaxX = cx + targetDx * 0.5;
        }
        else
        {
            double targetDy = dx / plotAspect;
            MinY = cy - targetDy * 0.5;
            MaxY = cy + targetDy * 0.5;
        }
    }

    private static IEnumerable<double> Ticks(double min, double max)
    {
        double span = max - min;
        double step = NiceStep(span / 6.0);
        double first = Math.Ceiling(min / step) * step;
        for (double v = first; v <= max + step * 0.5; v += step)
        {
            yield return Math.Abs(v) < step * 1e-8 ? 0 : v;
        }
    }

    private static double NiceStep(double raw)
    {
        if (raw <= 0 || double.IsNaN(raw) || double.IsInfinity(raw)) return 1;
        double pow = Math.Pow(10, Math.Floor(Math.Log10(raw)));
        double n = raw / pow;
        double nice = n <= 1 ? 1 : n <= 2 ? 2 : n <= 5 ? 5 : 10;
        return nice * pow;
    }
}
