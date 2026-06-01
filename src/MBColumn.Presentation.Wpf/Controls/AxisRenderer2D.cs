using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

public static class AxisRenderer2D
{
    private static readonly Brush AxisBrush = new SolidColorBrush(Color.FromRgb(55, 65, 81));
    private static readonly Brush ZeroAxisBrush = new SolidColorBrush(Color.FromRgb(30, 41, 59));
    private static readonly Brush GridBrush = new SolidColorBrush(Color.FromArgb(0xD0, 203, 213, 225));
    private static readonly Brush MinorGridBrush = new SolidColorBrush(Color.FromArgb(0xB0, 241, 245, 249));
    private static readonly Brush TextBrush = new SolidColorBrush(Color.FromRgb(31, 41, 51));
    private static readonly Brush PAxisLabelBrush = new SolidColorBrush(Color.FromRgb(37, 99, 235));   // blue for P (vertical) axis
    private static readonly Brush MAxisLabelBrush = new SolidColorBrush(Color.FromRgb(220, 38, 38));   // red for M (horizontal) axis

    public static void Draw(DrawingContext dc, ChartTransformHelper transform, string xLabel, string yLabel, bool showGrid, double xMajorStep = 0, double yMajorStep = 0, bool showLabels = true)
    {
        var gridPen = new Pen(GridBrush, 0.6);
        var minorGridPen = new Pen(MinorGridBrush, 0.3);
        var axisPen = new Pen(AxisBrush, 1.0);
        var zeroAxisPen = new Pen(ZeroAxisBrush, 1.4);
        var tickPen = new Pen(AxisBrush, 1.0);
        var minorTickPen = new Pen(AxisBrush, 0.5);

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

        var lastXLabel = double.NegativeInfinity;
        const double minXLabelSpacing = 54;
        foreach (double x in xTicks.MajorTicks)
        {
            var p0 = transform.ToScreen(x, transform.MinY);
            var p1 = transform.ToScreen(x, transform.MaxY);
            if (showGrid && Math.Abs(x) > 1e-9) dc.DrawLine(gridPen, p0, p1);
            
            // Major tick and label
            var pTick = transform.ToScreen(x, transform.AxisXValue);
            dc.DrawLine(tickPen, new Point(pTick.X, axis.Y - 5), new Point(pTick.X, axis.Y + 5));
            if (pTick.X - lastXLabel >= minXLabelSpacing || Math.Abs(x) < 1e-9)
            {
                DrawText(dc, AxisTickService.Format(x), 10, new Point(pTick.X - 14, axis.Y + 8));
                lastXLabel = pTick.X;
            }
        }

        foreach (double x in xTicks.MinorTicks)
        {
            var p = transform.ToScreen(x, transform.AxisXValue);
            dc.DrawLine(minorTickPen, new Point(p.X, axis.Y - 2), new Point(p.X, axis.Y + 2));
        }

        var lastYLabel = double.PositiveInfinity;
        const double minYLabelSpacing = 18;
        foreach (double y in yTicks.MajorTicks)
        {
            var p0 = transform.ToScreen(transform.MinX, y);
            var p1 = transform.ToScreen(transform.MaxX, y);
            if (showGrid && Math.Abs(y) > 1e-9) dc.DrawLine(gridPen, p0, p1);
            
            // Major tick and label
            var pTick = transform.ToScreen(transform.AxisYValue, y);
            dc.DrawLine(tickPen, new Point(axis.X - 5, pTick.Y), new Point(axis.X + 5, pTick.Y));
            if (lastYLabel - pTick.Y >= minYLabelSpacing || Math.Abs(y) < 1e-9)
            {
                DrawText(dc, AxisTickService.Format(y), 10, new Point(axis.X + 8, pTick.Y - 8));
                lastYLabel = pTick.Y;
            }
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
        
        // Titles — anchored to the axis ends so they track the actual axis lines
        if (showLabels)
        {
            var yft = CreateFormattedText(yLabel, 12, FontWeights.SemiBold, PAxisLabelBrush);
            dc.DrawText(yft, new Point(yAxis1.X - yft.Width / 2, yAxis1.Y - yft.Height - 6));

            var xft = CreateFormattedText(xLabel, 12, FontWeights.SemiBold, MAxisLabelBrush);
            dc.DrawText(xft, new Point(xAxis1.X + 6, xAxis1.Y - xft.Height / 2));
        }
    }

    private static void DrawText(DrawingContext dc, string text, double size, Point point, FontWeight? weight = null)
    {
        var ft = CreateFormattedText(text, size, weight ?? FontWeights.Normal, TextBrush);
        dc.DrawText(ft, point);
    }

    private static FormattedText CreateFormattedText(string text, double size, FontWeight weight, Brush brush)
    {
        return new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight, FontStretches.Normal),
            size + 1, brush, 1.25);
    }
}

