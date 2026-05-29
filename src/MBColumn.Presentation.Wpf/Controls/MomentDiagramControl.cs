using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.Controls;

/// <summary>
/// Renders a bending moment diagram (BMD) for a column member end.
/// Shows a vertical column stick with horizontal moment axes at top (y=0)
/// and bottom (y=-L). Moment values are plotted as dots on the axes,
/// scaled proportionally, with hatch-filled polygon area.
/// Left = negative, Right = positive.
/// </summary>
public sealed class MomentDiagramControl : FrameworkElement
{
    public static readonly DependencyProperty MomentTopProperty = DependencyProperty.Register(
        nameof(MomentTop), typeof(double?), typeof(MomentDiagramControl),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty MomentBottomProperty = DependencyProperty.Register(
        nameof(MomentBottom), typeof(double?), typeof(MomentDiagramControl),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty DiagramColorProperty = DependencyProperty.Register(
        nameof(DiagramColor), typeof(Color), typeof(MomentDiagramControl),
        new FrameworkPropertyMetadata(Colors.Red, FrameworkPropertyMetadataOptions.AffectsRender));

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(MomentDiagramControl),
        new FrameworkPropertyMetadata("M", FrameworkPropertyMetadataOptions.AffectsRender));

    public double? MomentTop
    {
        get => (double?)GetValue(MomentTopProperty);
        set => SetValue(MomentTopProperty, value);
    }

    public double? MomentBottom
    {
        get => (double?)GetValue(MomentBottomProperty);
        set => SetValue(MomentBottomProperty, value);
    }

    public Color DiagramColor
    {
        get => (Color)GetValue(DiagramColorProperty);
        set => SetValue(DiagramColorProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        double w = ActualWidth;
        double h = ActualHeight;
        if (w < 20 || h < 40) return;

        // Layout geometry
        double titleH = 22;
        double padSide = w * 0.10;
        double padTop = titleH + 8;
        double padBot = 22;

        double topY = padTop;          // y-coordinate of top axis
        double botY = h - padBot;      // y-coordinate of bottom axis
        double centerX = w / 2.0;
        double maxOffset = (w - 2 * padSide) / 2.0 * 0.88; // max pixel offset from center

        // Brushes & pens
        var diagBrush = new SolidColorBrush(DiagramColor);
        diagBrush.Freeze();
        var colColor = Color.FromRgb(0, 70, 213);
        var colBrush = new SolidColorBrush(colColor);
        colBrush.Freeze();
        var colPen = new Pen(colBrush, 1.8);
        colPen.Freeze();
        var axisPen = new Pen(Brushes.Gray, 0.7);
        axisPen.Freeze();
        var diagPen = new Pen(diagBrush, 1.2);
        diagPen.Freeze();

        // Background
        dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, w, h));

        // ─── Title ───
        var titleFt = MakeText(Title ?? "M", 15, diagBrush, FontWeights.Bold);
        dc.DrawText(titleFt, new Point(centerX - titleFt.Width / 2, 2));

        // ─── Column stick ───
        dc.DrawLine(colPen, new Point(centerX, topY), new Point(centerX, botY));

        // ─── Horizontal axes ───
        double axL = padSide;
        double axR = w - padSide;
        DrawHorizontalAxis(dc, axisPen, axL, axR, topY);
        DrawHorizontalAxis(dc, axisPen, axL, axR, botY);

        // (−) / (+) labels — placed inside the diagram to avoid overlapping the value labels
        var minusFt = MakeText("(−)", 10, Brushes.Gray);
        var plusFt = MakeText("(+)", 10, Brushes.Gray);
        dc.DrawText(minusFt, new Point(axL + 2, topY + 4));
        dc.DrawText(plusFt, new Point(axR - plusFt.Width - 2, topY + 4));
        dc.DrawText(MakeText("(−)", 10, Brushes.Gray), new Point(axL + 2, botY - minusFt.Height - 2));
        dc.DrawText(MakeText("(+)", 10, Brushes.Gray), new Point(axR - plusFt.Width - 2, botY - plusFt.Height - 2));



        // ─── Moment values ───
        double mTop = MomentTop ?? 0;
        double mBot = MomentBottom ?? 0;
        double maxAbs = Math.Max(Math.Abs(mTop), Math.Abs(mBot));
        if (maxAbs < 1e-9) maxAbs = 1.0; // prevent division by zero

        double topX = centerX + (mTop / maxAbs) * maxOffset;
        double botX = centerX + (mBot / maxAbs) * maxOffset;

        // ─── Hatch-filled polygon ───
        var polygon = new StreamGeometry();
        using (var ctx = polygon.Open())
        {
            ctx.BeginFigure(new Point(centerX, topY), true, true);
            ctx.LineTo(new Point(topX, topY), true, false);
            ctx.LineTo(new Point(botX, botY), true, false);
            ctx.LineTo(new Point(centerX, botY), true, false);
        }
        polygon.Freeze();

        var hatchBrush = CreateHatchBrush(DiagramColor);
        dc.DrawGeometry(hatchBrush, null, polygon);

        // Outline
        dc.DrawLine(diagPen, new Point(centerX, topY), new Point(topX, topY));
        dc.DrawLine(diagPen, new Point(topX, topY), new Point(botX, botY));
        dc.DrawLine(diagPen, new Point(botX, botY), new Point(centerX, botY));

        // ─── Moment dots ───
        double dotR = 5;
        dc.DrawEllipse(diagBrush, null, new Point(topX, topY), dotR, dotR);
        dc.DrawEllipse(diagBrush, null, new Point(botX, botY), dotR, dotR);

        // ─── Joint circles on column ───
        double jR = 6;
        var jPen = new Pen(colBrush, 1.5);
        jPen.Freeze();
        dc.DrawEllipse(Brushes.White, jPen, new Point(centerX, topY), jR, jR);
        dc.DrawEllipse(colBrush, null, new Point(centerX, topY), 2.5, 2.5);
        dc.DrawEllipse(Brushes.White, jPen, new Point(centerX, botY), jR, jR);
        dc.DrawEllipse(colBrush, null, new Point(centerX, botY), 2.5, 2.5);

        // ─── Value labels ───
        if (MomentTop.HasValue)
        {
            var ft = MakeText($"Top = {MomentTop.Value:F1}", 10, diagBrush, FontWeights.Bold);
            double lx = ClampX(topX - ft.Width / 2, ft.Width, w);
            dc.DrawText(ft, new Point(lx, topY - 17));
        }
        if (MomentBottom.HasValue)
        {
            var ft = MakeText($"Bot = {MomentBottom.Value:F1}", 10, diagBrush, FontWeights.Bold);
            double lx = ClampX(botX - ft.Width / 2, ft.Width, w);
            dc.DrawText(ft, new Point(lx, botY + 5));
        }
    }

    private static void DrawHorizontalAxis(DrawingContext dc, Pen pen, double left, double right, double y)
    {
        dc.DrawLine(pen, new Point(left, y), new Point(right, y));

        // Left arrow
        var la = new StreamGeometry();
        using (var ctx = la.Open())
        {
            ctx.BeginFigure(new Point(left, y), true, true);
            ctx.LineTo(new Point(left + 7, y - 3), false, false);
            ctx.LineTo(new Point(left + 7, y + 3), false, false);
        }
        la.Freeze();
        dc.DrawGeometry(Brushes.Gray, null, la);

        // Right arrow
        var ra = new StreamGeometry();
        using (var ctx = ra.Open())
        {
            ctx.BeginFigure(new Point(right, y), true, true);
            ctx.LineTo(new Point(right - 7, y - 3), false, false);
            ctx.LineTo(new Point(right - 7, y + 3), false, false);
        }
        ra.Freeze();
        dc.DrawGeometry(Brushes.Gray, null, ra);
    }

    private static DrawingBrush CreateHatchBrush(Color color)
    {
        var pen = new Pen(new SolidColorBrush(color), 0.8);
        pen.Freeze();
        var drawing = new GeometryDrawing
        {
            Pen = pen,
            Geometry = new LineGeometry(new Point(0, 8), new Point(8, 0))
        };
        drawing.Freeze();
        var brush = new DrawingBrush
        {
            Drawing = drawing,
            TileMode = TileMode.Tile,
            Viewport = new Rect(0, 0, 8, 8),
            ViewportUnits = BrushMappingMode.Absolute
        };
        brush.Freeze();
        return brush;
    }

    private static FormattedText MakeText(string text, double size, Brush fg,
        FontWeight? weight = null, FontStyle? style = null)
    {
        return new FormattedText(
            text,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface(
                new FontFamily("Segoe UI"),
                style ?? FontStyles.Normal,
                weight ?? FontWeights.Normal,
                FontStretches.Normal),
            size + 1, fg, 1.25);
    }

    private static double ClampX(double x, double textW, double canvasW)
        => Math.Max(2, Math.Min(x, canvasW - textW - 2));
}
