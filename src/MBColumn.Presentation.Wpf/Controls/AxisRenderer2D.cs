using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

public static class AxisRenderer2D
{
    private static readonly Brush AxisBrush = new SolidColorBrush(Color.FromRgb(51, 65, 85)); // dark slate
    private static readonly Brush ZeroAxisBrush = new SolidColorBrush(Color.FromRgb(15, 23, 42)); // very dark, for zero axis
    private static readonly Brush GridBrush = new SolidColorBrush(Color.FromRgb(203, 213, 225)); // light blue-grey
    private static readonly Brush MinorGridBrush = new SolidColorBrush(Color.FromRgb(241, 245, 249)); // very light
    private static readonly Brush TextBrush = new SolidColorBrush(Color.FromRgb(31, 41, 51));

    public static void Draw(DrawingContext dc, ChartTransformHelper transform, string xLabel, string yLabel, bool showGrid, double xMajorStep = 0, double yMajorStep = 0)
    {
        var gridPen = new Pen(GridBrush, 1.0);
        var minorGridPen = new Pen(MinorGridBrush, 0.6);
        var axisPen = new Pen(AxisBrush, 1.2);
        var zeroAxisPen = new Pen(ZeroAxisBrush, 1.8);
        var tickPen = new Pen(AxisBrush, 1.2);
        var minorTickPen = new Pen(AxisBrush, 0.6);

        var xTicks = xMajorStep > 0
            ? AxisTickService.GenerateFixed(transform.MinX, transform.MaxX, xMajorStep)
            : transform.AxisTicksX();
        var yTicks = yMajorStep > 0
            ? AxisTickService.GenerateFixed(transform.MinY, transform.MaxY, yMajorStep)
            : transform.AxisTicksY();
        var axis = transform.ToScreen(transform.AxisYValue, transform.AxisXValue);

        if (showGrid)
        {
            foreach (double x in xTicks.MinorTicks)
            {
                dc.DrawLine(minorGridPen, transform.ToScreen(x, transform.MinY), transform.ToScreen(x, transform.MaxY));
            }

            foreach (double y in yTicks.MinorTicks)
            {
                dc.DrawLine(minorGridPen, transform.ToScreen(transform.MinX, y), transform.ToScreen(transform.MaxX, y));
            }
        }

        foreach (double x in xTicks.MajorTicks)
        {
            var p0 = transform.ToScreen(x, transform.MinY);
            var p1 = transform.ToScreen(x, transform.MaxY);
            if (showGrid && Math.Abs(x) > 1e-9) dc.DrawLine(gridPen, p0, p1);
            
            // Major tick and label
            var pTick = transform.ToScreen(x, transform.AxisXValue);
            dc.DrawLine(tickPen, new Point(pTick.X, axis.Y - 5), new Point(pTick.X, axis.Y + 5));
            DrawText(dc, AxisTickService.Format(x), 10, new Point(pTick.X - 14, axis.Y + 8));
        }

        foreach (double x in xTicks.MinorTicks)
        {
            var p = transform.ToScreen(x, transform.AxisXValue);
            dc.DrawLine(minorTickPen, new Point(p.X, axis.Y - 2), new Point(p.X, axis.Y + 2));
        }

        foreach (double y in yTicks.MajorTicks)
        {
            var p0 = transform.ToScreen(transform.MinX, y);
            var p1 = transform.ToScreen(transform.MaxX, y);
            if (showGrid && Math.Abs(y) > 1e-9) dc.DrawLine(gridPen, p0, p1);
            
            // Major tick and label
            var pTick = transform.ToScreen(transform.AxisYValue, y);
            dc.DrawLine(tickPen, new Point(axis.X - 5, pTick.Y), new Point(axis.X + 5, pTick.Y));
            DrawText(dc, AxisTickService.Format(y), 10, new Point(axis.X + 8, pTick.Y - 8));
        }

        foreach (double y in yTicks.MinorTicks)
        {
            var p = transform.ToScreen(transform.AxisYValue, y);
            dc.DrawLine(minorTickPen, new Point(axis.X - 2, p.Y), new Point(axis.X + 2, p.Y));
        }

        // Draw axes (use thicker zero line if axis represents zero)
        var xAxis0 = transform.ToScreen(transform.MinX, transform.AxisXValue);
        var xAxis1 = transform.ToScreen(transform.MaxX, transform.AxisXValue);
        var yAxis0 = transform.ToScreen(transform.AxisYValue, transform.MinY);
        var yAxis1 = transform.ToScreen(transform.AxisYValue, transform.MaxY);
        
        dc.DrawLine(Math.Abs(transform.AxisXValue) < 1e-9 ? zeroAxisPen : axisPen, xAxis0, xAxis1);
        dc.DrawLine(Math.Abs(transform.AxisYValue) < 1e-9 ? zeroAxisPen : axisPen, yAxis0, yAxis1);
        
        // Titles
        DrawText(dc, xLabel, 12, new Point(transform.Plot.Right - 74, transform.Plot.Bottom + 30), FontWeights.SemiBold);
        DrawText(dc, yLabel, 12, new Point(transform.Plot.Left + 8, transform.Plot.Top - 34), FontWeights.SemiBold);
    }

    private static void DrawText(DrawingContext dc, string text, double size, Point point, FontWeight? weight = null)
    {
        var ft = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight ?? FontWeights.Normal, FontStretches.Normal), size + 1, TextBrush, 1.25);
        dc.DrawText(ft, point);
    }
}

