using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

public static class LegendRenderer
{
    public static void Draw(DrawingContext dc, Point origin, bool showNominal = true)
    {
        double height = showNominal ? 56 : 39;
        var background = new Rect(origin.X - 8, origin.Y - 10, 146, height);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromArgb(232, 255, 255, 255)), new Pen(new SolidColorBrush(Color.FromArgb(145, 214, 222, 230)), 0.8), background, 5, 5);

        int row = 0;
        DrawItem(dc, new Point(origin.X, origin.Y + 17 * row++), Color.FromRgb(0, 75, 133), "Design Capacity", DashStyles.Solid);
        if (showNominal)
        {
            DrawItem(dc, new Point(origin.X, origin.Y + 17 * row++), Color.FromRgb(200, 40, 40), "Nominal Capacity", DashStyles.Dash);
        }
        DrawItem(dc, new Point(origin.X, origin.Y + 17 * row), Color.FromRgb(227, 27, 35), "Demand", DashStyles.Solid);
    }

    private static void DrawItem(DrawingContext dc, Point p, Color color, string text, DashStyle dashStyle)
    {
        var brush = new SolidColorBrush(color);
        var pen = new Pen(brush, 2) { DashStyle = dashStyle };
        dc.DrawLine(pen, p, new Point(p.X + 18, p.Y));
        var ft = new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), 10.5, new SolidColorBrush(Color.FromRgb(31, 41, 51)), 1.25);
        dc.DrawText(ft, new Point(p.X + 24, p.Y - 8));
    }
}

