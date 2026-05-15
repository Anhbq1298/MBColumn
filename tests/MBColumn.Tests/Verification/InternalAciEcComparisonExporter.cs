using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;

namespace MBColumn.Tests.Verification;

public sealed record InternalCodeComparisonPoint(
    string Code,
    double AngleDegrees,
    int PointIndex,
    double Mtheta,
    double P);

public sealed record InternalCodeAngleSummary(
    double AngleDegrees,
    double AciPMax,
    double AciPMin,
    double AciMaxAbsM,
    double EcPMax,
    double EcPMin,
    double EcMaxAbsM,
    double PMaxDiff,
    double MaxAbsMDiff);

public sealed record InternalAciEcComparisonReport(
    string CsvPath,
    string HtmlPath,
    string MarkdownPath,
    string PdfPath,
    IReadOnlyList<InternalCodeComparisonPoint> Points,
    IReadOnlyList<InternalCodeAngleSummary> Summaries);

public sealed class InternalAciEcComparisonExporter
{
    private static readonly double[] Angles = [0.0, 30.0, 45.0, 60.0, 90.0];
    private const int ExportPointCount = 100;

    public InternalAciEcComparisonReport Export(string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);

        var service = CreateService();
        var aci = service.Calculate(BuildInput(DesignCodeType.Aci318Style));
        var ec = service.Calculate(BuildInput(DesignCodeType.Ec2));
        var diagramData = new DiagramDataService();

        var points = new List<InternalCodeComparisonPoint>();
        var summaries = new List<InternalCodeAngleSummary>();
        foreach (double angle in Angles)
        {
            var aciCurve = ExtractDesignCurve(diagramData.BuildPmAngleDiagramData(aci.ControlPoints, UnitSystem.Metric, angle).Points);
            var ecCurve = ExtractDesignCurve(diagramData.BuildPmAngleDiagramData(ec.ControlPoints, UnitSystem.Metric, angle).Points);

            var aciSample = ResampleCurve(aciCurve, ExportPointCount)
                .Select((p, i) => new InternalCodeComparisonPoint("ACI 318-style", angle, i + 1, p.Mtheta, p.P))
                .ToList();
            var ecSample = ResampleCurve(ecCurve, ExportPointCount)
                .Select((p, i) => new InternalCodeComparisonPoint("Eurocode 2", angle, i + 1, p.Mtheta, p.P))
                .ToList();

            points.AddRange(aciSample);
            points.AddRange(ecSample);
            summaries.Add(BuildSummary(angle, aciSample, ecSample));
        }

        string csvPath = Path.Combine(outputDirectory, "aci-vs-eurocode-1200x500-100pt-5angles.csv");
        string htmlPath = Path.Combine(outputDirectory, "aci-vs-eurocode-1200x500-overlay.html");
        string markdownPath = Path.Combine(outputDirectory, "aci-vs-eurocode-1200x500-summary.md");
        string pdfPath = Path.Combine(outputDirectory, "aci-vs-eurocode-1200x500-report.pdf");

        File.WriteAllText(csvPath, BuildCsv(points), Encoding.UTF8);
        File.WriteAllText(htmlPath, BuildHtml(points, summaries), Encoding.UTF8);
        File.WriteAllText(markdownPath, BuildMarkdown(csvPath, htmlPath, pdfPath, summaries), Encoding.UTF8);
        InternalAciEcPdfReportWriter.Write(pdfPath, summaries);

        return new InternalAciEcComparisonReport(csvPath, htmlPath, markdownPath, pdfPath, points, summaries);
    }

    private static ColumnInputDto BuildInput(DesignCodeType code)
        => new(
            UnitSystem.Metric,
            Width: 1200,
            Height: 500,
            Cover: 40,
            BarSize: "T20",
            BarCount: 20,
            RebarLayoutPreset: "Sides different",
            Fc: 32,
            Fy: 500,
            Es: 200000,
            Pu: 0,
            Mux: 0,
            Muy: 0,
            ForceUnit: ForceUnit.kN,
            LengthUnit: LengthUnit.Millimeter,
            MomentUnit: MomentUnit.kNm,
            StressUnit: StressUnit.MPa,
            SelectedPmAngleDegrees: 0,
            SelectedAxialLoad: 0)
        {
            RebarLayoutType = RebarLayoutType.SidesDifferent,
            TopRebarSide = new RebarSideInputDto(7, "T20", 40),
            BottomRebarSide = new RebarSideInputDto(7, "T20", 40),
            LeftRebarSide = new RebarSideInputDto(3, "T20", 40),
            RightRebarSide = new RebarSideInputDto(3, "T20", 40),
            DesignCode = code,
            Ec2Solver = Ec2SolverType.Fiber,
            AlphaCc = 0.85
        };

    private static ColumnCalculationService CreateService()
    {
        var aci = new Aci318DesignCodeService();
        var ec2 = new Ec2DesignCodeService();
        var codeFactory = new DesignCodeServiceFactory(aci, ec2);
        var solverFactory = new InteractionSolverFactory(aci, ec2);
        IUnitConversionService units = new UnitConversionService();
        IRebarDatabase metricBars = new SingaporeRebarDatabase();
        IRebarDatabase imperialBars = new ImperialRebarDatabase();
        IRatioCheckService ratio = new RatioCheckService();
        IControlPointBuilder control = new ControlPointBuilderService(units);
        return new ColumnCalculationService(
            solverFactory,
            codeFactory,
            units,
            metricBars,
            imperialBars,
            ratio,
            control,
            new DiagramDataService(),
            new InputValidationService());
    }

    private static IReadOnlyList<CurvePoint> ExtractDesignCurve(IReadOnlyList<ControlPointDto> points)
        => points
            .Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsNominal)
            .Select(p => new CurvePoint(p.X, p.Y))
            .Where(p => IsFinite(p.Mtheta) && IsFinite(p.P))
            .ToList();

    private static IReadOnlyList<CurvePoint> ResampleCurve(IReadOnlyList<CurvePoint> curve, int count)
    {
        if (curve.Count == 0)
        {
            return [];
        }

        if (curve.Count == 1)
        {
            return Enumerable.Repeat(curve[0], count).ToList();
        }

        var distances = new double[curve.Count];
        for (int i = 1; i < curve.Count; i++)
        {
            double dm = curve[i].Mtheta - curve[i - 1].Mtheta;
            double dp = curve[i].P - curve[i - 1].P;
            distances[i] = distances[i - 1] + Math.Sqrt(dm * dm + dp * dp);
        }

        double total = distances[^1];
        if (total <= 1e-9)
        {
            return Enumerable.Repeat(curve[0], count).ToList();
        }

        var result = new List<CurvePoint>(count);
        int segment = 1;
        for (int i = 0; i < count; i++)
        {
            double target = total * i / (count - 1);
            while (segment < distances.Length - 1 && distances[segment] < target)
            {
                segment++;
            }

            double start = distances[segment - 1];
            double end = distances[segment];
            double t = Math.Abs(end - start) < 1e-12 ? 0.0 : (target - start) / (end - start);
            result.Add(new CurvePoint(
                Lerp(curve[segment - 1].Mtheta, curve[segment].Mtheta, t),
                Lerp(curve[segment - 1].P, curve[segment].P, t)));
        }

        return result;
    }

    private static InternalCodeAngleSummary BuildSummary(
        double angle,
        IReadOnlyList<InternalCodeComparisonPoint> aci,
        IReadOnlyList<InternalCodeComparisonPoint> ec)
    {
        double aciPMax = aci.Max(p => p.P);
        double aciPMin = aci.Min(p => p.P);
        double aciMaxAbsM = aci.Max(p => Math.Abs(p.Mtheta));
        double ecPMax = ec.Max(p => p.P);
        double ecPMin = ec.Min(p => p.P);
        double ecMaxAbsM = ec.Max(p => Math.Abs(p.Mtheta));
        return new InternalCodeAngleSummary(
            angle,
            aciPMax,
            aciPMin,
            aciMaxAbsM,
            ecPMax,
            ecPMin,
            ecMaxAbsM,
            ecPMax - aciPMax,
            ecMaxAbsM - aciMaxAbsM);
    }

    private static string BuildCsv(IReadOnlyList<InternalCodeComparisonPoint> points)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Code,AngleDegrees,PointIndex,Mtheta_kNm,P_kN");
        foreach (var point in points)
        {
            builder.Append(Escape(point.Code)).Append(',')
                .Append(Format(point.AngleDegrees)).Append(',')
                .Append(point.PointIndex.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(Format(point.Mtheta)).Append(',')
                .AppendLine(Format(point.P));
        }

        return builder.ToString();
    }

    private static string BuildMarkdown(
        string csvPath,
        string htmlPath,
        string pdfPath,
        IReadOnlyList<InternalCodeAngleSummary> summaries)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# Internal ACI vs Eurocode PM Comparison");
        builder.AppendLine();
        builder.AppendLine("This report compares MBColumn against itself for the same section configuration. No external reference software is used.");
        builder.AppendLine();
        builder.AppendLine("## Configuration");
        builder.AppendLine("- Section: rectangular 1200 mm x 500 mm");
        builder.AppendLine("- Reinforcement: top 7-T20, bottom 7-T20, left 3-T20, right 3-T20");
        builder.AppendLine("- Cover: 40 mm to longitudinal bar surface");
        builder.AppendLine("- Concrete input: 32 MPa");
        builder.AppendLine("- Steel input: 500 MPa, Es = 200000 MPa");
        builder.AppendLine("- ACI path: ACI 318-style conventional solver, fy used directly, phi varies from 0.65 to 0.90, compression cap = 0.80 * max(phi Pn)");
        builder.AppendLine("- Eurocode path: EC2 Fiber solver, fyk/1.15 steel design strength, concrete factor alpha_cc/gamma_c with alpha_cc = 0.85, phi = 1.0, no ACI compression cap");
        builder.AppendLine("- Export: 100 resampled design-capacity PM points for each code at 5 angles");
        builder.AppendLine();
        builder.AppendLine("## Files");
        builder.AppendLine($"- CSV: `{csvPath}`");
        builder.AppendLine($"- HTML overlay: `{htmlPath}`");
        builder.AppendLine($"- PDF report: `{pdfPath}`");
        builder.AppendLine();
        builder.AppendLine("## Angle Summary");
        builder.AppendLine("| Angle | ACI Pmax | EC Pmax | EC-ACI Pmax | ACI max abs M | EC max abs M | EC-ACI max abs M |");
        builder.AppendLine("| ---: | ---: | ---: | ---: | ---: | ---: | ---: |");
        foreach (var s in summaries)
        {
            builder.AppendLine(CultureInfo.InvariantCulture,
                $"| {s.AngleDegrees:F0} | {s.AciPMax:F3} | {s.EcPMax:F3} | {s.PMaxDiff:F3} | {s.AciMaxAbsM:F3} | {s.EcMaxAbsM:F3} | {s.MaxAbsMDiff:F3} |");
        }

        builder.AppendLine();
        builder.AppendLine("## What Changes Between ACI and Eurocode");
        builder.AppendLine("- Concrete strain limit changes from 0.003 to 0.0035.");
        builder.AppendLine("- ACI uses a member-level phi factor and a tied-column axial compression cap.");
        builder.AppendLine("- Eurocode uses material partial factors, so the surface is already design-level and phi remains 1.0.");
        builder.AppendLine("- Eurocode steel strength is reduced to fyk / 1.15; ACI steel uses fy directly in the current implementation.");
        builder.AppendLine("- Because the two paths reduce strength differently, the PM envelopes are not expected to overlay exactly even for identical geometry and reinforcement.");
        return builder.ToString();
    }

    private static string BuildHtml(
        IReadOnlyList<InternalCodeComparisonPoint> points,
        IReadOnlyList<InternalCodeAngleSummary> summaries)
    {
        string dataJson = BuildDataJson(points);
        string summaryJson = BuildSummaryJson(summaries);
        string buttons = string.Join(
            Environment.NewLine,
            Angles.Select((angle, index) =>
                $"<button type=\"button\" class=\"angle-button{(index == 0 ? " active" : "")}\" data-angle=\"{Format(angle)}\">{Format(angle)} deg</button>"));

        return $$"""
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>ACI vs Eurocode Internal PM Overlay</title>
<style>
:root {
  --ink: #1f2836;
  --muted: #5c6675;
  --grid: #dbe2eb;
  --aci: #1f5d9d;
  --ec: #c95f22;
  --panel: #f8fafc;
}
* { box-sizing: border-box; }
body {
  margin: 0;
  font-family: "Segoe UI", Arial, sans-serif;
  color: var(--ink);
  background: #fff;
}
header {
  padding: 22px 30px 12px;
  border-bottom: 1px solid #d9e0e8;
}
h1 {
  margin: 0;
  font-size: 26px;
  letter-spacing: 0;
}
.subtitle {
  margin-top: 6px;
  color: var(--muted);
  font-size: 14px;
}
.toolbar {
  display: flex;
  flex-wrap: wrap;
  gap: 8px;
  padding: 14px 30px;
  background: #f5f7fa;
  border-bottom: 1px solid #d9e0e8;
}
.angle-button {
  border: 1px solid #b7c2d0;
  background: #fff;
  color: var(--ink);
  padding: 7px 14px;
  border-radius: 4px;
  font-weight: 600;
  cursor: pointer;
}
.angle-button.active {
  color: #fff;
  background: #1f5d9d;
  border-color: #1f5d9d;
}
main {
  padding: 18px 30px 30px;
  display: grid;
  gap: 18px;
}
.panel {
  border: 1px solid #d9e0e8;
  background: var(--panel);
}
canvas {
  display: block;
  width: 100%;
  height: auto;
  background: #fff;
}
.legend {
  display: flex;
  flex-wrap: wrap;
  gap: 18px;
  align-items: center;
  padding: 0 16px 14px;
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
  border-top: 3px solid var(--aci);
}
.line.ec {
  border-top-color: var(--ec);
  border-top-style: dashed;
}
.summary {
  margin-left: auto;
  font-weight: 600;
  color: #334155;
}
</style>
</head>
<body>
<header>
  <h1>MBColumn Internal PM Overlay: ACI vs Eurocode</h1>
  <div class="subtitle">Same 1200 mm x 500 mm section and reinforcement. Each curve is exported as 100 resampled design-capacity points. Moment axis is Mtheta in kN-m; axial load is P in kN.</div>
</header>
<section class="toolbar">
{{buttons}}
</section>
<main>
  <section class="panel">
    <canvas id="chart" width="1240" height="780"></canvas>
    <div class="legend">
      <span class="key"><span class="line"></span>ACI 318-style</span>
      <span class="key"><span class="line ec"></span>Eurocode 2</span>
      <span id="summary" class="summary"></span>
    </div>
  </section>
</main>
<script>
const rows = {{dataJson}};
const summaries = {{summaryJson}};
const chart = document.getElementById('chart');
const summary = document.getElementById('summary');
const buttons = [...document.querySelectorAll('.angle-button')];
let angle = buttons[0]?.dataset.angle ?? '0';

function nice(min, max) {
  if (Math.abs(max - min) < 1e-9) max = min + 1;
  const pad = (max - min) * 0.08;
  return [min - pad, max + pad];
}
function tickStep(min, max, count) {
  const raw = (max - min) / Math.max(count, 1);
  const exp = Math.floor(Math.log10(Math.max(Math.abs(raw), 1e-9)));
  const frac = raw / Math.pow(10, exp);
  const niceFrac = frac <= 1 ? 1 : frac <= 2 ? 2 : frac <= 5 ? 5 : 10;
  return niceFrac * Math.pow(10, exp);
}
function ticks(min, max, count) {
  const step = tickStep(min, max, count);
  const output = [];
  for (let v = Math.ceil(min / step) * step; v <= max + step * 0.5; v += step) output.push(Math.abs(v) < step * 1e-9 ? 0 : v);
  return output;
}
function fmt(value) {
  return Math.abs(value) >= 1000 ? value.toLocaleString(undefined, {maximumFractionDigits: 0}) : value.toLocaleString(undefined, {maximumFractionDigits: 1});
}
function stroke(ctx, points, color, dashed) {
  if (points.length < 2) return;
  ctx.save();
  ctx.strokeStyle = color;
  ctx.lineWidth = 3;
  ctx.setLineDash(dashed ? [9, 6] : []);
  ctx.beginPath();
  ctx.moveTo(points[0].x, points[0].y);
  for (const p of points.slice(1)) ctx.lineTo(p.x, p.y);
  ctx.stroke();
  ctx.restore();
}
function drawMarkers(ctx, points, color) {
  ctx.save();
  ctx.fillStyle = color;
  for (const p of points.filter((_, i) => i % 10 === 0)) {
    ctx.beginPath();
    ctx.arc(p.x, p.y, 3.5, 0, Math.PI * 2);
    ctx.fill();
  }
  ctx.restore();
}
function draw() {
  const ctx = chart.getContext('2d');
  const w = chart.width;
  const h = chart.height;
  const data = rows.filter(r => r.angle === Number(angle));
  const aci = data.filter(r => r.code === 'ACI 318-style');
  const ec = data.filter(r => r.code === 'Eurocode 2');
  const plot = { left: 104, top: 58, right: w - 44, bottom: h - 90 };
  const moments = data.map(r => r.m);
  const axial = data.map(r => r.p);
  const [xmin, xmax] = nice(Math.min(...moments), Math.max(...moments));
  const [ymin, ymax] = nice(Math.min(...axial), Math.max(...axial));
  const xp = m => plot.left + (m - xmin) / (xmax - xmin) * (plot.right - plot.left);
  const yp = p => plot.bottom - (p - ymin) / (ymax - ymin) * (plot.bottom - plot.top);
  ctx.clearRect(0, 0, w, h);
  ctx.fillStyle = '#fff';
  ctx.fillRect(0, 0, w, h);
  ctx.fillStyle = '#f8fafc';
  ctx.fillRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  ctx.strokeStyle = '#dbe2eb';
  ctx.lineWidth = 1;
  ctx.font = '15px Segoe UI, Arial';
  ctx.fillStyle = '#394252';
  for (const x of ticks(xmin, xmax, 8)) {
    const px = xp(x);
    ctx.beginPath(); ctx.moveTo(px, plot.top); ctx.lineTo(px, plot.bottom); ctx.stroke();
    ctx.fillText(fmt(x), px - 24, plot.bottom + 28);
  }
  for (const y of ticks(ymin, ymax, 8)) {
    const py = yp(y);
    ctx.beginPath(); ctx.moveTo(plot.left, py); ctx.lineTo(plot.right, py); ctx.stroke();
    ctx.fillText(fmt(y), 18, py + 5);
  }
  ctx.strokeStyle = '#465160';
  ctx.lineWidth = 1.4;
  ctx.strokeRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  const aciPts = aci.map(r => ({x: xp(r.m), y: yp(r.p)}));
  const ecPts = ec.map(r => ({x: xp(r.m), y: yp(r.p)}));
  stroke(ctx, aciPts, '#1f5d9d', false);
  stroke(ctx, ecPts, '#c95f22', true);
  drawMarkers(ctx, aciPts, '#1f5d9d');
  drawMarkers(ctx, ecPts, '#c95f22');
  ctx.fillStyle = '#1f2836';
  ctx.font = '600 18px Segoe UI, Arial';
  ctx.fillText(`PM Angle ${angle} deg`, plot.left, 32);
  ctx.font = '600 16px Segoe UI, Arial';
  ctx.fillText('Moment Mtheta (kN-m)', plot.left + (plot.right - plot.left) / 2 - 82, h - 28);
  ctx.save();
  ctx.translate(28, plot.top + (plot.bottom - plot.top) / 2 + 68);
  ctx.rotate(-Math.PI / 2);
  ctx.fillText('Axial Load P (kN)', 0, 0);
  ctx.restore();
  const s = summaries.find(x => x.angle === Number(angle));
  summary.textContent = s ? `EC-ACI Pmax: ${fmt(s.pMaxDiff)} kN | EC-ACI max |M|: ${fmt(s.mDiff)} kN-m` : '';
}
for (const button of buttons) {
  button.addEventListener('click', () => {
    buttons.forEach(b => b.classList.toggle('active', b === button));
    angle = button.dataset.angle;
    draw();
  });
}
draw();
</script>
</body>
</html>
""";
    }

    private static string BuildDataJson(IReadOnlyList<InternalCodeComparisonPoint> points)
    {
        var builder = new StringBuilder();
        builder.Append('[');
        for (int i = 0; i < points.Count; i++)
        {
            if (i > 0) builder.Append(',');
            var p = points[i];
            builder.Append('{');
            AppendJsonString(builder, "code", p.Code).Append(',');
            AppendJsonNumber(builder, "angle", p.AngleDegrees).Append(',');
            AppendJsonNumber(builder, "index", p.PointIndex).Append(',');
            AppendJsonNumber(builder, "m", p.Mtheta).Append(',');
            AppendJsonNumber(builder, "p", p.P);
            builder.Append('}');
        }

        builder.Append(']');
        return builder.ToString();
    }

    private static string BuildSummaryJson(IReadOnlyList<InternalCodeAngleSummary> summaries)
    {
        var builder = new StringBuilder();
        builder.Append('[');
        for (int i = 0; i < summaries.Count; i++)
        {
            if (i > 0) builder.Append(',');
            var s = summaries[i];
            builder.Append('{');
            AppendJsonNumber(builder, "angle", s.AngleDegrees).Append(',');
            AppendJsonNumber(builder, "pMaxDiff", s.PMaxDiff).Append(',');
            AppendJsonNumber(builder, "mDiff", s.MaxAbsMDiff);
            builder.Append('}');
        }

        builder.Append(']');
        return builder.ToString();
    }

    private static StringBuilder AppendJsonString(StringBuilder builder, string name, string value)
        => builder.Append('"').Append(JsonEscape(name)).Append("\":\"").Append(JsonEscape(value)).Append('"');

    private static StringBuilder AppendJsonNumber(StringBuilder builder, string name, double value)
        => builder.Append('"').Append(JsonEscape(name)).Append("\":").Append(value.ToString("G17", CultureInfo.InvariantCulture));

    private static string JsonEscape(string value)
        => value
            .Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal)
            .Replace("\r", "\\r", StringComparison.Ordinal)
            .Replace("\n", "\\n", StringComparison.Ordinal)
            .Replace("\t", "\\t", StringComparison.Ordinal);

    private static string Escape(string value)
        => value.Contains(',') || value.Contains('"')
            ? $"\"{value.Replace("\"", "\"\"", StringComparison.Ordinal)}\""
            : value;

    private static string Format(double value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static bool IsFinite(double value)
        => !double.IsNaN(value) && !double.IsInfinity(value);

    private static double Lerp(double a, double b, double t)
        => a + (b - a) * t;

    private readonly record struct CurvePoint(double Mtheta, double P);
}
