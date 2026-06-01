using MBColumn.Application.Reports.Models;
using System.Text;
using System.Globalization;

namespace MBColumn.Infrastructure.Reports.Svg;

public static class DiagramSvgRenderer
{
    public static string Render(DiagramBlock diag)
    {
        if (diag.Points == null || diag.Points.Count == 0) return "";

        double minX = 0, maxX = 0, minY = 0, maxY = 0;
        foreach (var p in diag.Points)
        {
            if (p.X < minX) minX = p.X;
            if (p.X > maxX) maxX = p.X;
            if (p.Y < minY) minY = p.Y;
            if (p.Y > maxY) maxY = p.Y;
        }

        // Add padding
        double padX = (maxX - minX) * 0.1;
        double padY = (maxY - minY) * 0.1;
        if (padX == 0) padX = 10;
        if (padY == 0) padY = 10;
        
        minX -= padX; maxX += padX;
        minY -= padY; maxY += padY;

        if (diag.UseEqualAspect)
        {
            double rangeX = maxX - minX;
            double rangeY = maxY - minY;
            double maxRange = System.Math.Max(rangeX, rangeY);
            double cx = (minX + maxX) / 2;
            double cy = (minY + maxY) / 2;
            minX = cx - maxRange / 2;
            maxX = cx + maxRange / 2;
            minY = cy - maxRange / 2;
            maxY = cy + maxRange / 2;
        }

        double width = 600;
        double height = 400;
        
        double scaleX = width / (maxX - minX);
        double scaleY = height / (maxY - minY);
        
        string F(double v) => v.ToString("F1", CultureInfo.InvariantCulture);
        
        double TransformX(double x) => (x - minX) * scaleX;
        double TransformY(double y) => height - (y - minY) * scaleY;

        var sb = new StringBuilder();
        sb.AppendLine($@"<svg width=""{width}"" height=""{height}"" viewBox=""0 0 {width} {height}"" xmlns=""http://www.w3.org/2000/svg"" font-family=""Inter, Segoe UI, sans-serif"">");

        // Grid lines (simplified, just origin for now)
        sb.AppendLine($@"<line x1=""0"" y1=""{F(TransformY(0))}"" x2=""{width}"" y2=""{F(TransformY(0))}"" stroke=""#888"" stroke-width=""1"" />");
        sb.AppendLine($@"<line x1=""{F(TransformX(0))}"" y1=""0"" x2=""{F(TransformX(0))}"" y2=""{height}"" stroke=""#888"" stroke-width=""1"" />");

        // Axis labels
        sb.AppendLine($@"<text x=""{width - 10}"" y=""{F(TransformY(0) - 10)}"" font-family=""Inter, Segoe UI, sans-serif"" font-size=""12"" fill=""#555"" text-anchor=""end"">{diag.XAxisLabel}</text>");
        sb.AppendLine($@"<text x=""{F(TransformX(0) + 10)}"" y=""20"" font-family=""Inter, Segoe UI, sans-serif"" font-size=""12"" fill=""#555"">{diag.YAxisLabel}</text>");

        // Capacity Envelopes
        foreach (var group in diag.Points.Where(p => !p.IsDemand && !p.IsGoverning && !p.IsReference && !p.IsSpecialPoint).GroupBy(p => p.GroupKey))
        {
            var ordered = group.ToList();
            if (ordered.Count < 2) continue;

            bool isNominal = ordered[0].IsNominal;
            string fill = isNominal ? "none" : "#EBF5FB";
            string fillOpacity = isNominal ? "0" : "0.3";
            string stroke = isNominal ? "#C82828" : "#004B85";
            string strokeWidth = isNominal ? "1.5" : "2";

            sb.Append($@"<polygon points=""");
            foreach (var p in ordered)
                sb.Append($"{F(TransformX(p.X))},{F(TransformY(p.Y))} ");
            sb.AppendLine($@""" fill=""{fill}"" fill-opacity=""{fillOpacity}"" stroke=""{stroke}"" stroke-width=""{strokeWidth}"" stroke-linejoin=""round"" />");
        }

        // Reference Lines
        if (diag.ReferenceLines != null)
        {
            foreach (var line in diag.ReferenceLines)
            {
                sb.AppendLine($@"<line x1=""{F(TransformX(line.StartX))}"" y1=""{F(TransformY(line.StartY))}"" x2=""{F(TransformX(line.EndX))}"" y2=""{F(TransformY(line.EndY))}"" stroke=""#2980B9"" stroke-width=""1"" stroke-dasharray=""4 4"" />");
            }
        }

        // Demand Point
        var demandPoint = diag.Points.FirstOrDefault(p => p.IsDemand);
        if (demandPoint != null)
        {
            sb.AppendLine($@"<circle cx=""{F(TransformX(demandPoint.X))}"" cy=""{F(TransformY(demandPoint.Y))}"" r=""5"" fill=""#E74C3C"" />");
        }

        sb.AppendLine("</svg>");
        return sb.ToString();
    }
}
