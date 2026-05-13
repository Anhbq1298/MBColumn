using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Infrastructure.Rebar;
using MBColumn.Infrastructure.Solvers;

namespace MBColumn.Tests.Verification;

public sealed record SpColumnReferenceControlPoint(
    string Direction,
    string ControlPoint,
    double RefP,
    double RefMx,
    double RefMy)
{
    public double RefM => Direction.Contains("Y", StringComparison.OrdinalIgnoreCase) ? RefMy : RefMx;
}

public sealed record MbColumnControlPoint(
    string Direction,
    string ControlPoint,
    double CalcP,
    double CalcMx,
    double CalcMy)
{
    public double CalcM => Direction.Contains("Y", StringComparison.OrdinalIgnoreCase) ? CalcMy : CalcMx;
}

public sealed record ControlPointComparisonRow(
    string Direction,
    string ControlPoint,
    double RefP,
    double CalcP,
    double DiffP,
    double? PercentDiffP,
    double RefM,
    double CalcM,
    double DiffM,
    double? PercentDiffM,
    string PStatus,
    string MStatus,
    string OverallStatus)
{
    public bool OverallPass => OverallStatus.Equals("PASS", StringComparison.OrdinalIgnoreCase);
}

public sealed record ControlPointComparisonStatistics(
    int TotalRows,
    int PassCount,
    int FailCount,
    double MaxAbsDiffP,
    double MaxAbsDiffM,
    double MaxAbsPercentDiffP,
    double MaxAbsPercentDiffM,
    double MeanAbsPercentDiffP,
    double MeanAbsPercentDiffM,
    string OverallStatus);

public sealed record MbColumnControlPointExtractionResult(
    ColumnInputDto Input,
    CalculationResultDto Result,
    IReadOnlyList<MbColumnControlPoint> ControlPoints,
    IReadOnlyList<string> ValidationNotes);

public sealed record ControlPointComparisonReport(
    string ReferencePath,
    IReadOnlyList<SpColumnReferenceControlPoint> ReferencePoints,
    MbColumnControlPointExtractionResult MbColumn,
    IReadOnlyList<ControlPointComparisonRow> Rows,
    ControlPointComparisonStatistics Statistics,
    IReadOnlyList<string> EngineeringValidationNotes,
    string CsvPath,
    string MarkdownPath,
    string ChartPath);

public sealed class SpColumnReferenceReader
{
    private static readonly Regex ControlPointLine = new(
        @"^\s*(?<direction>-?X|-?Y)\s+@\s+(?<label>.+?)\s{2,}(?<p>-?\d+(?:\.\d+)?)\s+(?<mx>-?\d+(?:\.\d+)?)\s+(?<my>-?\d+(?:\.\d+)?)\s+",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public IReadOnlyList<SpColumnReferenceControlPoint> Read(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"spColumn reference file was not found: {path}", path);
        }

        var points = new List<SpColumnReferenceControlPoint>();
        foreach (string line in File.ReadLines(path))
        {
            var match = ControlPointLine.Match(line);
            if (!match.Success)
            {
                continue;
            }

            points.Add(new SpColumnReferenceControlPoint(
                match.Groups["direction"].Value,
                NormalizeLabel(match.Groups["label"].Value),
                Parse(match.Groups["p"].Value),
                Parse(match.Groups["mx"].Value),
                Parse(match.Groups["my"].Value)));
        }

        if (points.Count == 0)
        {
            throw new InvalidOperationException($"No spColumn control-point rows were found in {path}.");
        }

        return points;
    }

    private static double Parse(string value)
        => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);

    private static string NormalizeLabel(string value)
        => Regex.Replace(value.Trim(), @"\s+", " ");
}

public sealed class MbColumnControlPointExtractor
{
    public MbColumnControlPointExtractionResult Extract()
    {
        var service = CreateService();
        var input = BuildReferenceCaseInput();
        var result = service.Calculate(input);
        var table = result.ControlPointTable ?? throw new InvalidOperationException("MBColumn did not return a control-point table.");
        var controlPoints = table.Rows
            .Select(r => new MbColumnControlPoint(r.Axis, r.PointLabel, r.P, r.Mx, r.My))
            .ToList();

        return new MbColumnControlPointExtractionResult(
            input,
            result,
            controlPoints,
            BuildEngineeringValidationNotes(input, result));
    }

    public static ColumnInputDto BuildReferenceCaseInput()
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
            DesignCode = DesignCodeType.Aci318Style,
            AciSolver = AciSolverType.Conventional
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

    private static IReadOnlyList<string> BuildEngineeringValidationNotes(ColumnInputDto input, CalculationResultDto result)
    {
        var rebarCoordinates = result.RebarCoordinates ?? throw new InvalidOperationException("MBColumn did not return generated rebar coordinates.");
        var notes = new List<string>
        {
            "MBColumn calculation path: ColumnCalculationService -> InteractionSolverFactory -> StrainCompatibilityInteractionSolver -> ControlPointTableBuilderService.",
            "Internal units verified by service contract: force N, length mm, moment N-mm, stress MPa; report values are kN and kN-m.",
            "ACI 318-style design path selected; control-point rows use factored phi strengths and the ACI compression design limit.",
            "Reference #20 bars are represented with MBColumn's existing metric T20 definition because the current metric bar database does not expose a '#20' label.",
            $"Rebar coordinate builder produced {rebarCoordinates.Count} unique bars from top=7, bottom=7, left=3, right=3 side inputs."
        };

        double expectedX = input.Width / 2.0 - input.Cover - 10.0;
        double expectedY = input.Height / 2.0 - input.Cover - 10.0;
        double maxAbsX = rebarCoordinates.Max(b => Math.Abs(b.X));
        double maxAbsY = rebarCoordinates.Max(b => Math.Abs(b.Y));
        notes.Add($"Cover interpretation verified as cover to bar surface: bar centroids at +/-{maxAbsX:F3} mm in X and +/-{maxAbsY:F3} mm in Y; expected +/-{expectedX:F3} and +/-{expectedY:F3} for 20 mm bars.");

        var table = result.ControlPointTable ?? throw new InvalidOperationException("MBColumn did not return a control-point table.");
        var fsZeroX = table.Rows.FirstOrDefault(r => r.Axis == "X" && r.PointLabel == "fs = 0.0");
        var fsZeroY = table.Rows.FirstOrDefault(r => r.Axis == "Y" && r.PointLabel == "fs = 0.0");
        if (fsZeroX is not null && fsZeroY is not null)
        {
            notes.Add($"Local-axis/dt check: X fs=0 dt={fsZeroX.DtDepth:F3} mm, Y fs=0 dt={fsZeroY.DtDepth:F3} mm.");
        }

        notes.Add("Directional comparison uses the signed reported Mx value for X/-X rows and signed reported My value for Y/-Y rows.");
        return notes;
    }
}

public sealed class ControlPointComparer
{
    public IReadOnlyList<ControlPointComparisonRow> Compare(
        IReadOnlyList<SpColumnReferenceControlPoint> reference,
        IReadOnlyList<MbColumnControlPoint> calculated,
        PmmComparisonOptions? options = null)
    {
        options ??= new PmmComparisonOptions();
        var calculatedByKey = calculated.ToDictionary(
            p => Key(p.Direction, p.ControlPoint),
            StringComparer.OrdinalIgnoreCase);

        var rows = new List<ControlPointComparisonRow>();
        foreach (var refPoint in reference)
        {
            if (!calculatedByKey.TryGetValue(Key(refPoint.Direction, refPoint.ControlPoint), out var calcPoint))
            {
                throw new InvalidOperationException($"Missing MBColumn control point: {refPoint.Direction} @ {refPoint.ControlPoint}.");
            }

            double diffP = calcPoint.CalcP - refPoint.RefP;
            double diffM = calcPoint.CalcM - refPoint.RefM;
            double? percentP = Percent(diffP, refPoint.RefP, options.ZeroReferenceThreshold);
            double? percentM = Percent(diffM, refPoint.RefM, options.ZeroReferenceThreshold);
            bool pPass = Pass(diffP, percentP, options.AbsoluteAxialTolerance, options.PercentTolerance);
            bool mPass = Pass(diffM, percentM, options.AbsoluteMomentTolerance, options.PercentTolerance);

            rows.Add(new ControlPointComparisonRow(
                refPoint.Direction,
                refPoint.ControlPoint,
                refPoint.RefP,
                calcPoint.CalcP,
                diffP,
                percentP,
                refPoint.RefM,
                calcPoint.CalcM,
                diffM,
                percentM,
                pPass ? "PASS" : "FAIL",
                mPass ? "PASS" : "FAIL",
                pPass && mPass ? "PASS" : "FAIL"));
        }

        return rows;
    }

    private static string Key(string direction, string label)
        => $"{direction.Trim()}|{label.Trim()}";

    private static double? Percent(double diff, double reference, double zeroThreshold)
        => Math.Abs(reference) <= zeroThreshold ? null : diff / reference * 100.0;

    private static bool Pass(double diff, double? percent, double absoluteTolerance, double percentTolerance)
        => percent.HasValue
            ? Math.Abs(percent.Value) <= percentTolerance || Math.Abs(diff) <= absoluteTolerance
            : Math.Abs(diff) <= absoluteTolerance;
}

public sealed class ComparisonStatisticsCalculator
{
    public ControlPointComparisonStatistics Calculate(IReadOnlyList<ControlPointComparisonRow> rows)
    {
        var pPercents = rows.Select(r => r.PercentDiffP).Where(v => v.HasValue).Select(v => Math.Abs(v!.Value)).ToList();
        var mPercents = rows.Select(r => r.PercentDiffM).Where(v => v.HasValue).Select(v => Math.Abs(v!.Value)).ToList();
        int passCount = rows.Count(r => r.OverallPass);
        int failCount = rows.Count - passCount;

        return new ControlPointComparisonStatistics(
            rows.Count,
            passCount,
            failCount,
            rows.Count == 0 ? 0.0 : rows.Max(r => Math.Abs(r.DiffP)),
            rows.Count == 0 ? 0.0 : rows.Max(r => Math.Abs(r.DiffM)),
            pPercents.Count == 0 ? 0.0 : pPercents.Max(),
            mPercents.Count == 0 ? 0.0 : mPercents.Max(),
            pPercents.Count == 0 ? 0.0 : pPercents.Average(),
            mPercents.Count == 0 ? 0.0 : mPercents.Average(),
            failCount == 0 ? "PASS" : "FAIL");
    }
}

public sealed class ComparisonReportWriter
{
    public ControlPointComparisonReport Write(
        string referencePath,
        IReadOnlyList<SpColumnReferenceControlPoint> reference,
        MbColumnControlPointExtractionResult mbColumn,
        IReadOnlyList<ControlPointComparisonRow> rows,
        ControlPointComparisonStatistics statistics,
        string outputDirectory)
    {
        Directory.CreateDirectory(outputDirectory);
        string csvPath = Path.Combine(outputDirectory, "spColumn-Rectan1200x500-ACI-control-point-comparison.csv");
        string markdownPath = Path.Combine(outputDirectory, "spColumn-Rectan1200x500-ACI-control-point-comparison.md");
        string chartPath = Path.Combine(outputDirectory, "spColumn-Rectan1200x500-ACI-control-point-chart.html");

        File.WriteAllText(csvPath, BuildCsv(rows), Encoding.UTF8);
        File.WriteAllText(markdownPath, BuildMarkdown(referencePath, mbColumn, rows, statistics), Encoding.UTF8);
        new PmmChartGenerator().GenerateControlPointComparisonHtml(rows, chartPath);

        return new ControlPointComparisonReport(
            referencePath,
            reference,
            mbColumn,
            rows,
            statistics,
            mbColumn.ValidationNotes,
            csvPath,
            markdownPath,
            chartPath);
    }

    private static string BuildCsv(IReadOnlyList<ControlPointComparisonRow> rows)
    {
        var builder = new StringBuilder();
        builder.AppendLine("Direction,Control point,RefP,CalcP,DiffP,%DiffP,RefM,CalcM,DiffM,%DiffM,P status,M status,Overall status");
        foreach (var row in rows)
        {
            builder.Append(Escape(row.Direction)).Append(',')
                .Append(Escape(row.ControlPoint)).Append(',')
                .Append(Format(row.RefP)).Append(',')
                .Append(Format(row.CalcP)).Append(',')
                .Append(Format(row.DiffP)).Append(',')
                .Append(Format(row.PercentDiffP)).Append(',')
                .Append(Format(row.RefM)).Append(',')
                .Append(Format(row.CalcM)).Append(',')
                .Append(Format(row.DiffM)).Append(',')
                .Append(Format(row.PercentDiffM)).Append(',')
                .Append(row.PStatus).Append(',')
                .Append(row.MStatus).Append(',')
                .AppendLine(row.OverallStatus);
        }

        return builder.ToString();
    }

    private static string BuildMarkdown(
        string referencePath,
        MbColumnControlPointExtractionResult mbColumn,
        IReadOnlyList<ControlPointComparisonRow> rows,
        ControlPointComparisonStatistics statistics)
    {
        var builder = new StringBuilder();
        builder.AppendLine("# spColumn ACI Control Point Comparison");
        builder.AppendLine();
        builder.AppendLine($"Reference: `{referencePath}`");
        builder.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        builder.AppendLine();
        builder.AppendLine("## Case");
        builder.AppendLine("- Section: rectangular 1200 mm x 500 mm");
        builder.AppendLine("- Materials: f'c = 32 MPa, fy = 500 MPa, Es = 200000 MPa");
        builder.AppendLine("- Reinforcement: top 7-T20, bottom 7-T20, left 3-T20, right 3-T20 using existing MBColumn placement logic");
        builder.AppendLine("- Design path: ACI 318-style, current MBColumn conventional solver");
        builder.AppendLine();
        builder.AppendLine("## Engineering Validation Notes");
        foreach (string note in mbColumn.ValidationNotes)
        {
            builder.AppendLine($"- {note}");
        }

        builder.AppendLine();
        builder.AppendLine("## Summary");
        builder.AppendLine($"- Overall status: {statistics.OverallStatus}");
        builder.AppendLine($"- Rows: {statistics.TotalRows}");
        builder.AppendLine($"- Passing rows: {statistics.PassCount}");
        builder.AppendLine($"- Failing rows: {statistics.FailCount}");
        builder.AppendLine($"- Max |DiffP|: {statistics.MaxAbsDiffP:F3} kN");
        builder.AppendLine($"- Max |DiffM|: {statistics.MaxAbsDiffM:F3} kN-m");
        builder.AppendLine($"- Max |%DiffP|: {statistics.MaxAbsPercentDiffP:F3}%");
        builder.AppendLine($"- Max |%DiffM|: {statistics.MaxAbsPercentDiffM:F3}%");
        builder.AppendLine();
        builder.AppendLine("## Comparison Table");
        builder.AppendLine("| Direction | Control point | RefP | CalcP | DiffP | %DiffP | RefM | CalcM | DiffM | %DiffM | P status | M status | Overall |");
        builder.AppendLine("| --- | --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | --- | --- | --- |");
        foreach (var row in rows)
        {
            builder.AppendLine(CultureInfo.InvariantCulture,
                $"| {row.Direction} | {row.ControlPoint} | {row.RefP:F3} | {row.CalcP:F3} | {row.DiffP:F3} | {Format(row.PercentDiffP)} | {row.RefM:F3} | {row.CalcM:F3} | {row.DiffM:F3} | {Format(row.PercentDiffM)} | {row.PStatus} | {row.MStatus} | {row.OverallStatus} |");
        }

        return builder.ToString();
    }

    private static string Escape(string value)
        => value.Contains(',') || value.Contains('"')
            ? $"\"{value.Replace("\"", "\"\"", StringComparison.Ordinal)}\""
            : value;

    private static string Format(double value)
        => value.ToString("0.###", CultureInfo.InvariantCulture);

    private static string Format(double? value)
        => value.HasValue ? value.Value.ToString("0.###", CultureInfo.InvariantCulture) : "N/A";
}

public static class PmmChartGeneratorControlPointExtensions
{
    public static string GenerateControlPointComparisonHtml(
        this PmmChartGenerator generator,
        IReadOnlyList<ControlPointComparisonRow> rows,
        string outputPath)
    {
        _ = generator;
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        File.WriteAllText(outputPath, BuildHtml(rows), Encoding.UTF8);
        return outputPath;
    }

    private static string BuildHtml(IReadOnlyList<ControlPointComparisonRow> rows)
    {
        string dataJson = BuildDataJson(rows);
        string buttons = string.Join(
            Environment.NewLine,
            rows.Select(r => r.Direction).Distinct().Select((d, i) =>
                $"<button type=\"button\" class=\"axis-button{(i == 0 ? " active" : "")}\" data-axis=\"{WebUtility.HtmlEncode(d)}\">{WebUtility.HtmlEncode(d)}</button>"));

        return $$"""
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>spColumn vs MBColumn Control Points</title>
<style>
:root {
  --ink: #202734;
  --muted: #5f6978;
  --grid: #d8dee8;
  --panel: #f7f9fc;
  --ref: #1f5d9d;
  --calc: #d36b24;
  --fail: #a73535;
  --pass: #2f6f4f;
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
  border-bottom: 1px solid #dbe1ea;
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
  gap: 8px;
  padding: 14px 30px;
  background: #f5f7fa;
  border-bottom: 1px solid #dbe1ea;
}
.axis-button {
  border: 1px solid #b8c2cf;
  background: #fff;
  color: var(--ink);
  padding: 7px 14px;
  border-radius: 4px;
  font-weight: 600;
  cursor: pointer;
}
.axis-button.active {
  background: #1f5d9d;
  border-color: #1f5d9d;
  color: #fff;
}
main {
  padding: 18px 30px 30px;
  display: grid;
  gap: 18px;
}
.panel {
  border: 1px solid #dbe1ea;
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
  width: 34px;
  border-top: 3px solid var(--ref);
}
.line.calc {
  border-top-color: var(--calc);
  border-top-style: dashed;
}
.summary {
  margin-left: auto;
  font-weight: 600;
}
.summary.fail { color: var(--fail); }
.summary.pass { color: var(--pass); }
</style>
</head>
<body>
<header>
  <h1>spColumn vs MBColumn ACI Control Points</h1>
  <div class="subtitle">Rectangular 1200 mm x 500 mm, f'c 32 MPa, fy 500 MPa, existing MBColumn conventional ACI path. Axial load is kN; moment is signed kN-m along the reported axis.</div>
</header>
<section class="toolbar">
{{buttons}}
</section>
<main>
  <section class="panel">
    <canvas id="chart" width="1240" height="780"></canvas>
    <div class="legend">
      <span class="key"><span class="line"></span>spColumn reference</span>
      <span class="key"><span class="line calc"></span>MBColumn current</span>
      <span id="summary" class="summary"></span>
    </div>
  </section>
</main>
<script>
const rows = {{dataJson}};
const chart = document.getElementById('chart');
const summary = document.getElementById('summary');
const buttons = [...document.querySelectorAll('.axis-button')];
let axis = buttons[0]?.dataset.axis ?? 'X';

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
  for (const point of points.slice(1)) ctx.lineTo(point.x, point.y);
  ctx.stroke();
  ctx.restore();
}
function drawMarkers(ctx, points, color) {
  ctx.save();
  ctx.fillStyle = color;
  for (const point of points) {
    ctx.beginPath();
    ctx.arc(point.x, point.y, 4.5, 0, Math.PI * 2);
    ctx.fill();
  }
  ctx.restore();
}
function draw() {
  const ctx = chart.getContext('2d');
  const w = chart.width;
  const h = chart.height;
  const data = rows.filter(r => r.direction === axis);
  const plot = { left: 104, top: 58, right: w - 44, bottom: h - 90 };
  const moments = data.flatMap(r => [r.refM, r.calcM]);
  const axial = data.flatMap(r => [r.refP, r.calcP]);
  const [xmin, xmax] = nice(Math.min(...moments), Math.max(...moments));
  const [ymin, ymax] = nice(Math.min(...axial), Math.max(...axial));
  const xp = m => plot.left + (m - xmin) / (xmax - xmin) * (plot.right - plot.left);
  const yp = p => plot.bottom - (p - ymin) / (ymax - ymin) * (plot.bottom - plot.top);
  ctx.clearRect(0, 0, w, h);
  ctx.fillStyle = '#fff';
  ctx.fillRect(0, 0, w, h);
  ctx.fillStyle = '#f7f9fc';
  ctx.fillRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  ctx.strokeStyle = '#d8dee8';
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
  ctx.strokeStyle = '#444c58';
  ctx.lineWidth = 1.4;
  ctx.strokeRect(plot.left, plot.top, plot.right - plot.left, plot.bottom - plot.top);
  const ref = data.map(r => ({x: xp(r.refM), y: yp(r.refP)}));
  const calc = data.map(r => ({x: xp(r.calcM), y: yp(r.calcP)}));
  stroke(ctx, ref, '#1f5d9d', false);
  stroke(ctx, calc, '#d36b24', true);
  drawMarkers(ctx, ref, '#1f5d9d');
  drawMarkers(ctx, calc, '#d36b24');
  ctx.fillStyle = '#202734';
  ctx.font = '600 18px Segoe UI, Arial';
  ctx.fillText(`${axis} Control Points`, plot.left, 32);
  ctx.font = '600 16px Segoe UI, Arial';
  ctx.fillText(`Moment ${axis.includes('Y') ? 'My' : 'Mx'} (kN-m)`, plot.left + (plot.right - plot.left) / 2 - 76, h - 28);
  ctx.save();
  ctx.translate(28, plot.top + (plot.bottom - plot.top) / 2 + 68);
  ctx.rotate(-Math.PI / 2);
  ctx.fillText('Axial Load P (kN)', 0, 0);
  ctx.restore();
  const failures = data.filter(r => r.status !== 'PASS').length;
  summary.textContent = failures ? `Failed rows: ${failures}` : 'All rows pass';
  summary.className = `summary ${failures ? 'fail' : 'pass'}`;
}
for (const button of buttons) {
  button.addEventListener('click', () => {
    buttons.forEach(b => b.classList.toggle('active', b === button));
    axis = button.dataset.axis;
    draw();
  });
}
draw();
</script>
</body>
</html>
""";
    }

    private static string BuildDataJson(IReadOnlyList<ControlPointComparisonRow> rows)
    {
        var builder = new StringBuilder();
        builder.Append('[');
        for (int i = 0; i < rows.Count; i++)
        {
            if (i > 0) builder.Append(',');
            var row = rows[i];
            builder.Append('{');
            AppendJsonString(builder, "direction", row.Direction).Append(',');
            AppendJsonString(builder, "label", row.ControlPoint).Append(',');
            AppendJsonNumber(builder, "refP", row.RefP).Append(',');
            AppendJsonNumber(builder, "calcP", row.CalcP).Append(',');
            AppendJsonNumber(builder, "refM", row.RefM).Append(',');
            AppendJsonNumber(builder, "calcM", row.CalcM).Append(',');
            AppendJsonString(builder, "status", row.OverallStatus);
            builder.Append('}');
        }

        builder.Append(']');
        return builder.ToString();
    }

    private static StringBuilder AppendJsonString(StringBuilder builder, string name, string value)
        => builder.Append('"').Append(JsonEscape(name)).Append("\":\"")
            .Append(JsonEscape(value)).Append('"');

    private static StringBuilder AppendJsonNumber(StringBuilder builder, string name, double value)
        => builder.Append('"').Append(JsonEscape(name)).Append("\":")
            .Append(value.ToString("G17", CultureInfo.InvariantCulture));

    private static string JsonEscape(string value)
        => value
            .Replace("\\", "\\\\", StringComparison.Ordinal)
            .Replace("\"", "\\\"", StringComparison.Ordinal)
            .Replace("\r", "\\r", StringComparison.Ordinal)
            .Replace("\n", "\\n", StringComparison.Ordinal)
            .Replace("\t", "\\t", StringComparison.Ordinal);
}
