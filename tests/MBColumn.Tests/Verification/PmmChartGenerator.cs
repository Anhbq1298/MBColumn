using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MBColumn.Tests.Verification;

public sealed class PmmChartGenerator
{
    private const int WidthPx = 1400;
    private const int HeightPx = 950;
    private const double LeftMargin = 125.0;
    private const double RightMargin = 255.0;
    private const double TopMargin = 118.0;
    private const double BottomMargin = 112.0;

    public IReadOnlyList<string> GenerateFromCsv(string csvPath, string outputDirectory)
    {
        if (!File.Exists(csvPath))
        {
            throw new FileNotFoundException($"PMM comparison CSV was not found: {csvPath}", csvPath);
        }

        Directory.CreateDirectory(outputDirectory);
        var rows = ReadRows(csvPath);
        var groups = rows
            .GroupBy(r => r.Theta)
            .Select(g => new ThetaChartData(g.Key, g.ToList()))
            .ToList();

        if (groups.Count == 0)
        {
            throw new InvalidOperationException("No PMM comparison rows were found for chart generation.");
        }

        var outputPaths = new List<string>();
        Exception? renderException = null;
        var renderThread = new Thread(() =>
        {
            try
            {
                foreach (var group in groups)
                {
                    string path = Path.Combine(outputDirectory, $"PMM_Comparison_Theta_{group.Theta}.png");
                    RenderThetaChart(group, path);
                    outputPaths.Add(path);
                }
            }
            catch (Exception ex)
            {
                renderException = ex;
            }
        });

        renderThread.SetApartmentState(ApartmentState.STA);
        renderThread.Start();
        renderThread.Join();

        if (renderException is not null)
        {
            throw renderException;
        }

        return outputPaths;
    }

    public string GenerateInteractiveHtmlFromCsv(string csvPath, string outputPath)
    {
        if (!File.Exists(csvPath))
        {
            throw new FileNotFoundException($"PMM comparison CSV was not found: {csvPath}", csvPath);
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        var rows = ReadRows(csvPath);
        var groups = rows
            .GroupBy(r => r.Theta)
            .OrderBy(g => g.Key)
            .Select(g => new ThetaChartData(g.Key, g.OrderBy(r => r.PointIndex).ToList()))
            .ToList();

        File.WriteAllText(outputPath, BuildHtml(groups), Encoding.UTF8);
        return outputPath;
    }

    private static IReadOnlyList<ChartRow> ReadRows(string csvPath)
    {
        var lines = File.ReadAllLines(csvPath);
        if (lines.Length < 2)
        {
            return [];
        }

        var headers = lines[0].Split(',').Select((name, index) => (name, index))
            .ToDictionary(x => x.name.Trim(), x => x.index, StringComparer.OrdinalIgnoreCase);

        int thetaIndex = RequireColumn(headers, "Theta");
        int pointIndex = RequireColumn(headers, "PointIndex");
        int calcPIndex = RequireAnyColumn(headers, "MBColumnP_kN", "CalcP", "CalcP_kN");
        int calcMIndex = RequireAnyColumn(headers, "MBColumnM_kNm", "CalcM", "CalcM_kNm");
        int refPIndex = RequireAnyColumn(headers, "ReferenceP_kN", "RefP", "RefP_kN");
        int refMIndex = RequireAnyColumn(headers, "ReferenceM_kNm", "RefM", "RefM_kNm");
        int overallIndex = RequireAnyColumn(headers, "OverallPass", "OverallStatus");

        var rows = new List<ChartRow>();
        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            var columns = lines[i].Split(',');
            rows.Add(new ChartRow(
                ParseInt(columns, thetaIndex),
                ParseInt(columns, pointIndex),
                ParseDouble(columns, calcPIndex),
                ParseDouble(columns, calcMIndex),
                ParseDouble(columns, refPIndex),
                ParseDouble(columns, refMIndex),
                IsPass(columns[overallIndex])));
        }

        return rows;
    }

    private static int RequireColumn(IReadOnlyDictionary<string, int> headers, string name)
        => headers.TryGetValue(name, out int index)
            ? index
            : throw new InvalidOperationException($"Required CSV column '{name}' was not found.");

    private static int RequireAnyColumn(IReadOnlyDictionary<string, int> headers, params string[] names)
    {
        foreach (string name in names)
        {
            if (headers.TryGetValue(name, out int index))
            {
                return index;
            }
        }

        throw new InvalidOperationException($"Required CSV column was not found. Tried: {string.Join(", ", names)}.");
    }

    private static int ParseInt(string[] columns, int index)
        => int.Parse(columns[index], CultureInfo.InvariantCulture);

    private static double ParseDouble(string[] columns, int index)
        => double.Parse(columns[index], CultureInfo.InvariantCulture);

    private static bool IsPass(string value)
        => value.Trim().Equals("PASS", StringComparison.OrdinalIgnoreCase) ||
           value.Trim().Equals("True", StringComparison.OrdinalIgnoreCase);

    private static void RenderThetaChart(ThetaChartData group, string outputPath)
    {
        var visual = new DrawingVisual();
        using (var dc = visual.RenderOpen())
        {
            DrawChart(dc, group);
        }

        var bitmap = new RenderTargetBitmap(WidthPx, HeightPx, 96, 96, PixelFormats.Pbgra32);
        bitmap.Render(visual);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bitmap));
        using var stream = File.Create(outputPath);
        encoder.Save(stream);
    }

    private static void DrawChart(DrawingContext dc, ThetaChartData group)
    {
        var allM = group.Rows.SelectMany(r => new[] { r.CalcM, r.RefM }).ToList();
        var allP = group.Rows.SelectMany(r => new[] { r.CalcP, r.RefP }).ToList();
        var xRange = NiceRange(0.0, allM.Max());
        var yRange = NiceRange(allP.Min(), allP.Max());

        var chart = new Rect(
            LeftMargin,
            TopMargin,
            WidthPx - LeftMargin - RightMargin,
            HeightPx - TopMargin - BottomMargin);

        dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, WidthPx, HeightPx));
        dc.DrawRectangle(new SolidColorBrush(Color.FromRgb(250, 251, 253)), null, chart);

        DrawGridAndAxes(dc, chart, xRange, yRange);
        DrawTitle(dc, group.Theta);

        var refPoints = group.Rows.Select(r => ToPoint(chart, xRange, yRange, r.RefM, r.RefP)).ToList();
        var calcPoints = group.Rows.Select(r => ToPoint(chart, xRange, yRange, r.CalcM, r.CalcP)).ToList();

        DrawPolyline(dc, refPoints, new Pen(new SolidColorBrush(Color.FromRgb(35, 94, 169)), 3.2));
        DrawPolyline(dc, calcPoints, DashedPen(Color.FromRgb(229, 125, 37), 3.2));

        DrawAxisLabels(dc, chart);
        DrawLegend(dc, chart, group.Rows.Count(r => !r.Pass));
        DrawFootnote(dc, group.Rows.Count);
    }

    private static void DrawGridAndAxes(DrawingContext dc, Rect chart, AxisRange xRange, AxisRange yRange)
    {
        var gridPen = new Pen(new SolidColorBrush(Color.FromRgb(220, 225, 232)), 1.0);
        var axisPen = new Pen(new SolidColorBrush(Color.FromRgb(68, 76, 88)), 1.6);
        var textBrush = new SolidColorBrush(Color.FromRgb(51, 58, 69));

        foreach (double x in BuildTicks(xRange.Min, xRange.Max, 8))
        {
            var pt = ToPoint(chart, xRange, yRange, x, yRange.Min);
            dc.DrawLine(gridPen, new Point(pt.X, chart.Top), new Point(pt.X, chart.Bottom));
            DrawText(dc, FormatNumber(x), 22, textBrush, new Point(pt.X - 28, chart.Bottom + 14));
        }

        foreach (double y in BuildTicks(yRange.Min, yRange.Max, 8))
        {
            var pt = ToPoint(chart, xRange, yRange, xRange.Min, y);
            dc.DrawLine(gridPen, new Point(chart.Left, pt.Y), new Point(chart.Right, pt.Y));
            DrawText(dc, FormatNumber(y), 22, textBrush, new Point(chart.Left - 92, pt.Y - 13));
        }

        dc.DrawRectangle(null, axisPen, chart);
    }

    private static void DrawTitle(DrawingContext dc, int theta)
    {
        var titleBrush = new SolidColorBrush(Color.FromRgb(28, 34, 44));
        var subtitleBrush = new SolidColorBrush(Color.FromRgb(88, 96, 110));
        DrawText(dc, "EUROCODE COMPARISON", 34, titleBrush, new Point(LeftMargin, 24), FontWeights.SemiBold);
        DrawText(dc, $"MB COLUMN VS S-CONCRETE - THETA {theta} deg", 25, titleBrush, new Point(LeftMargin, 62), FontWeights.SemiBold);
        DrawText(dc, "M is projected onto the reference N-vs-M theta axis; P axis is reversed with compression negative upward; point order preserved from CSV.", 18, subtitleBrush, new Point(LeftMargin, 92));
    }

    private static void DrawAxisLabels(DrawingContext dc, Rect chart)
    {
        var brush = new SolidColorBrush(Color.FromRgb(45, 52, 63));
        DrawText(dc, "Moment, M (kNm)", 24, brush, new Point(chart.Left + chart.Width / 2.0 - 92, HeightPx - 54), FontWeights.SemiBold);

        dc.PushTransform(new RotateTransform(-90, 40, chart.Top + chart.Height / 2.0));
        DrawText(dc, "Axial Load, P (kN)", 24, brush, new Point(40, chart.Top + chart.Height / 2.0 - 100), FontWeights.SemiBold);
        dc.Pop();
    }

    private static void DrawLegend(DrawingContext dc, Rect chart, int failedCount)
    {
        double x = chart.Right + 38;
        double y = chart.Top + 26;
        var textBrush = new SolidColorBrush(Color.FromRgb(39, 46, 56));
        var box = new Rect(chart.Right + 20, chart.Top + 10, 208, failedCount > 0 ? 138 : 104);
        dc.DrawRoundedRectangle(new SolidColorBrush(Color.FromRgb(255, 255, 255)), new Pen(new SolidColorBrush(Color.FromRgb(214, 219, 226)), 1.0), box, 4, 4);

        dc.DrawLine(new Pen(new SolidColorBrush(Color.FromRgb(35, 94, 169)), 3.0), new Point(x, y + 9), new Point(x + 46, y + 9));
        DrawText(dc, "PMM-SConc", 20, textBrush, new Point(x + 58, y));

        var mbPen = DashedPen(Color.FromRgb(229, 125, 37), 3.0);
        dc.DrawLine(mbPen, new Point(x, y + 42), new Point(x + 46, y + 42));
        DrawText(dc, "PMM-MB", 20, textBrush, new Point(x + 58, y + 33));

        if (failedCount > 0)
        {
            DrawText(dc, $"FAIL points: {failedCount}", 20, new SolidColorBrush(Color.FromRgb(150, 34, 34)), new Point(x + 58, y + 74));
        }
    }

    private static void DrawFootnote(DrawingContext dc, int pointCount)
    {
        var brush = new SolidColorBrush(Color.FromRgb(96, 104, 118));
        DrawText(dc, $"Source: generated comparison CSV. Plotted rows: {pointCount}. MB uses 100 PM samples resampled at reference P levels.", 17, brush, new Point(LeftMargin, HeightPx - 28));
    }

    private static void DrawPolyline(DrawingContext dc, IReadOnlyList<Point> points, Pen pen)
    {
        if (points.Count < 2)
        {
            return;
        }

        var geometry = new StreamGeometry();
        using (var context = geometry.Open())
        {
            context.BeginFigure(points[0], false, false);
            context.PolyLineTo(points.Skip(1).ToList(), true, false);
        }

        geometry.Freeze();
        dc.DrawGeometry(null, pen, geometry);
    }

    private static Pen DashedPen(Color color, double thickness)
    {
        var pen = new Pen(new SolidColorBrush(color), thickness)
        {
            DashStyle = new DashStyle([7.0, 5.0], 0.0)
        };
        return pen;
    }

    private static Point ToPoint(Rect chart, AxisRange xRange, AxisRange yRange, double x, double y)
    {
        double px = chart.Left + (x - xRange.Min) / (xRange.Max - xRange.Min) * chart.Width;
        double py = chart.Top + (y - yRange.Min) / (yRange.Max - yRange.Min) * chart.Height;
        return new Point(px, py);
    }

    private static string BuildHtml(IReadOnlyList<ThetaChartData> groups)
    {
        string dataJson = BuildDataJson(groups);
        string initialTheta = groups[0].Theta.ToString(CultureInfo.InvariantCulture);
        string options = string.Join(
            Environment.NewLine,
            groups.Select(g => $"<option value=\"{g.Theta.ToString(CultureInfo.InvariantCulture)}\">Theta {g.Theta.ToString(CultureInfo.InvariantCulture)} deg</option>"));

        return $$$"""
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>PMM Comparison Viewer</title>
<style>
:root {
  color-scheme: light;
  --ink: #202734;
  --muted: #5d6778;
  --grid: #dce2ea;
  --panel: #f8fafc;
  --blue: #235ea9;
  --orange: #e57d25;
}
* { box-sizing: border-box; }
body {
  margin: 0;
  font-family: "Segoe UI", Arial, sans-serif;
  color: var(--ink);
  background: #ffffff;
}
header {
  padding: 24px 32px 12px;
  border-bottom: 1px solid #d9e0e8;
}
h1 {
  margin: 0;
  font-size: 28px;
  letter-spacing: 0;
}
.subtitle {
  margin-top: 5px;
  color: var(--muted);
  font-size: 14px;
}
.toolbar {
  display: flex;
  flex-wrap: wrap;
  gap: 16px;
  align-items: center;
  padding: 16px 32px;
  background: #f5f7fa;
  border-bottom: 1px solid #d9e0e8;
}
label {
  font-size: 13px;
  font-weight: 600;
  color: #3b4554;
}
select, input[type="range"] {
  accent-color: var(--blue);
}
select {
  min-width: 160px;
  padding: 7px 10px;
  border: 1px solid #b9c3d0;
  background: #fff;
  color: var(--ink);
  border-radius: 4px;
}
main {
  display: grid;
  grid-template-columns: minmax(620px, 1fr);
  gap: 18px;
  padding: 20px 32px 32px;
}
.panel {
  border: 1px solid #d9e0e8;
  background: var(--panel);
}
.panel h2 {
  margin: 0;
  padding: 14px 18px 0;
  font-size: 17px;
}
canvas {
  display: block;
  width: 100%;
  height: auto;
  background: #fff;
}
.legend {
  display: flex;
  gap: 18px;
  align-items: center;
  padding: 0 18px 12px;
  color: var(--muted);
  font-size: 13px;
}
.key {
  display: inline-flex;
  align-items: center;
  gap: 7px;
}
.line {
  width: 36px;
  height: 0;
  border-top: 3px solid var(--blue);
}
.line.mb {
  border-top-color: var(--orange);
  border-top-style: dashed;
}
.stats {
  margin-left: auto;
  color: #9a2d2d;
}
</style>
</head>
<body>
<header>
  <h1>EUROCODE COMPARISON - MB COLUMN VS S-CONCRETE</h1>
  <div class="subtitle">Source: generated comparison CSV. M is projected onto the reference N-vs-M theta axis in kNm. P is kN with compression negative upward. MB uses 100 PM samples resampled at reference P levels. Curves preserve CSV point order.</div>
</header>
<section class="toolbar">
  <label for="thetaSelect">Theta</label>
  <select id="thetaSelect">{{{options}}}</select>
</section>
<main>
  <section class="panel">
    <h2>2D PM Curve</h2>
    <canvas id="chart2d" width="1180" height="760"></canvas>
    <div class="legend">
      <span class="key"><span class="line"></span>PMM-SConc</span>
      <span class="key"><span class="line mb"></span>PMM-MB</span>
      <span id="failStats" class="stats"></span>
    </div>
  </section>
</main>
<script>
const data = {{{dataJson}}};
const thetaSelect = document.getElementById('thetaSelect');
const chart2d = document.getElementById('chart2d');
const failStats = document.getElementById('failStats');
thetaSelect.value = '{{{initialTheta}}}';

function niceRange(min, max) {
  if (Math.abs(max - min) < 1e-9) max = min + 1;
  const pad = (max - min) * 0.07;
  return [min - pad, max + pad];
}

function ticks(min, max, count) {
  const raw = (max - min) / Math.max(1, count);
  const exp = Math.floor(Math.log10(Math.max(raw, 1e-9)));
  const frac = raw / Math.pow(10, exp);
  const nf = frac <= 1 ? 1 : frac <= 2 ? 2 : frac <= 5 ? 5 : 10;
  const step = nf * Math.pow(10, exp);
  const out = [];
  for (let v = Math.ceil(min / step) * step; v <= max + step * 0.5; v += step) out.push(Math.abs(v) < step * 1e-9 ? 0 : v);
  return out;
}

function fmt(v) {
  return Math.abs(v) >= 1000 ? v.toLocaleString(undefined, {maximumFractionDigits:0}) : v.toLocaleString(undefined, {maximumFractionDigits:1});
}

function strokePath(ctx, points, color, dashed=false, width=3) {
  if (points.length < 2) return;
  ctx.save();
  ctx.strokeStyle = color;
  ctx.lineWidth = width;
  ctx.setLineDash(dashed ? [8, 6] : []);
  ctx.beginPath();
  ctx.moveTo(points[0].x, points[0].y);
  for (const p of points.slice(1)) ctx.lineTo(p.x, p.y);
  ctx.stroke();
  ctx.restore();
}

function draw2d() {
  const theta = thetaSelect.value;
  const rows = data[theta];
  const ctx = chart2d.getContext('2d');
  const w = chart2d.width, h = chart2d.height;
  ctx.clearRect(0, 0, w, h);
  ctx.fillStyle = '#ffffff';
  ctx.fillRect(0, 0, w, h);
  const plot = {left: 92, top: 54, right: w - 32, bottom: h - 82};
  const allM = rows.flatMap(r => [r.refM, r.mbM]);
  const allP = rows.flatMap(r => [r.refP, r.mbP]);
  const [xmin, xmax] = niceRange(0, Math.max(...allM));
  const [ymin, ymax] = niceRange(Math.min(...allP), Math.max(...allP));
  const xp = m => plot.left + (m - xmin) / (xmax - xmin) * (plot.right - plot.left);
  const yp = p => plot.top + (p - ymin) / (ymax - ymin) * (plot.bottom - plot.top);

  ctx.fillStyle = '#f8fafc';
  ctx.fillRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  ctx.strokeStyle = '#444c58';
  ctx.strokeRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  ctx.font = '16px Segoe UI, Arial';
  ctx.fillStyle = '#343d4a';
  ctx.strokeStyle = '#dce2ea';
  ctx.lineWidth = 1;

  for (const x of ticks(xmin, xmax, 8)) {
    const px = xp(x);
    ctx.beginPath(); ctx.moveTo(px, plot.top); ctx.lineTo(px, plot.bottom); ctx.stroke();
    ctx.fillText(fmt(x), px - 20, plot.bottom + 30);
  }
  for (const y of ticks(ymin, ymax, 8)) {
    const py = yp(y);
    ctx.beginPath(); ctx.moveTo(plot.left, py); ctx.lineTo(plot.right, py); ctx.stroke();
    ctx.fillText(fmt(y), 14, py + 5);
  }

  const ref = rows.map(r => ({x: xp(r.refM), y: yp(r.refP)}));
  const mb = rows.map(r => ({x: xp(r.mbM), y: yp(r.mbP)}));
  strokePath(ctx, ref, '#235ea9', false, 3.2);
  strokePath(ctx, mb, '#e57d25', true, 3.2);

  ctx.fillStyle = '#202734';
  ctx.font = '600 18px Segoe UI, Arial';
  ctx.fillText(`Theta ${theta} deg`, plot.left, 30);
  ctx.font = '600 16px Segoe UI, Arial';
  ctx.fillText('Moment, M (kNm)', plot.left + (plot.right - plot.left) / 2 - 70, h - 24);
  ctx.save();
  ctx.translate(26, plot.top + (plot.bottom - plot.top) / 2 + 74);
  ctx.rotate(-Math.PI / 2);
  ctx.fillText('Axial Load, P (kN)', 0, 0);
  ctx.restore();

  const failCount = rows.filter(r => !r.pass).length;
  failStats.textContent = failCount ? `Failed rows: ${failCount}` : 'All rows pass';
}

function redraw() { draw2d(); }
thetaSelect.addEventListener('change', redraw);
redraw();
</script>
</body>
</html>
""";
    }

    private static string BuildDataJson(IReadOnlyList<ThetaChartData> groups)
    {
        var builder = new StringBuilder();
        builder.Append('{');
        for (int g = 0; g < groups.Count; g++)
        {
            if (g > 0) builder.Append(',');
            builder.Append('"').Append(groups[g].Theta.ToString(CultureInfo.InvariantCulture)).Append("\":[");
            for (int i = 0; i < groups[g].Rows.Count; i++)
            {
                var row = groups[g].Rows[i];
                if (i > 0) builder.Append(',');
                builder.Append('{');
                AppendJsonNumber(builder, "pointIndex", row.PointIndex).Append(',');
                AppendJsonNumber(builder, "mbP", row.CalcP).Append(',');
                AppendJsonNumber(builder, "mbM", row.CalcM).Append(',');
                AppendJsonNumber(builder, "refP", row.RefP).Append(',');
                AppendJsonNumber(builder, "refM", row.RefM).Append(',');
                builder.Append("\"pass\":").Append(row.Pass ? "true" : "false");
                builder.Append('}');
            }

            builder.Append(']');
        }

        builder.Append('}');
        return builder.ToString();
    }

    private static StringBuilder AppendJsonNumber(StringBuilder builder, string name, double value)
        => builder.Append('"').Append(WebUtility.HtmlEncode(name)).Append("\":").Append(value.ToString("G17", CultureInfo.InvariantCulture));

    private static AxisRange NiceRange(double min, double max)
    {
        if (Math.Abs(max - min) < 1e-9)
        {
            max = min + 1.0;
        }

        double span = max - min;
        double padding = span * 0.07;
        double niceMin = min - padding;
        double niceMax = max + padding;
        return new AxisRange(niceMin, niceMax);
    }

    private static IEnumerable<double> BuildTicks(double min, double max, int count)
    {
        double rawStep = (max - min) / Math.Max(1, count);
        double step = NiceStep(rawStep);
        double first = Math.Ceiling(min / step) * step;
        for (double value = first; value <= max + step * 0.5; value += step)
        {
            yield return Math.Abs(value) < step * 1e-9 ? 0.0 : value;
        }
    }

    private static double NiceStep(double rawStep)
    {
        double exponent = Math.Floor(Math.Log10(rawStep));
        double fraction = rawStep / Math.Pow(10.0, exponent);
        double niceFraction = fraction <= 1.0 ? 1.0 : fraction <= 2.0 ? 2.0 : fraction <= 5.0 ? 5.0 : 10.0;
        return niceFraction * Math.Pow(10.0, exponent);
    }

    private static string FormatNumber(double value)
        => Math.Abs(value) >= 1000.0 ? value.ToString("N0", CultureInfo.InvariantCulture) : value.ToString("N1", CultureInfo.InvariantCulture);

    private static void DrawText(
        DrawingContext dc,
        string text,
        double size,
        Brush brush,
        Point origin,
        FontWeight? weight = null)
    {
        var formatted = new FormattedText(
            text,
            CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            new Typeface(new FontFamily("Segoe UI"), FontStyles.Normal, weight ?? FontWeights.Normal, FontStretches.Normal),
            size,
            brush,
            1.0);
        dc.DrawText(formatted, origin);
    }

    private sealed record ChartRow(
        int Theta,
        int PointIndex,
        double CalcP,
        double CalcM,
        double RefP,
        double RefM,
        bool Pass);

    private sealed record ThetaChartData(int Theta, IReadOnlyList<ChartRow> Rows);

    private readonly record struct AxisRange(double Min, double Max);
}
