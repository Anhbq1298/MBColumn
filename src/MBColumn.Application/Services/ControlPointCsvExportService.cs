using MBColumn.Application.DTOs;
using System.Globalization;
using System.Text;

namespace MBColumn.Application.Services;

public sealed class ControlPointCsvExportService : IControlPointCsvExportService
{
    private static readonly string[] Headers =
    [
        "\u03b8", "Pt.", "P", "Mx+", "My+", "M\u03b8+", "Mx-", "My-", "M\u03b8-",
        "NeutralAxisDepth", "\u03b5s", "\u03b5c", "\u03c6",
        "IntegrationMethod", "ConcreteFiberCountX", "ConcreteFiberCountY",
        "CircularRadialFiberCount", "CircularAngularFiberCount", "CirclePolygonSegmentCount",
        "Remarks"
    ];

    public void Export(string path, IEnumerable<ControlPointExportRow> rows)
    {
        var builder = new StringBuilder();
        builder.AppendLine(string.Join(",", Headers.Select(Escape)));

        foreach (var row in rows)
        {
            builder.AppendLine(string.Join(",", new[]
            {
                Format(row.ThetaDeg),
                row.PointIndex.ToString(CultureInfo.InvariantCulture),
                Format(row.P),
                Format(row.MxPositive),
                Format(row.MyPositive),
                Format(row.MThetaPositive),
                Format(row.MxNegative),
                Format(row.MyNegative),
                Format(row.MThetaNegative),
                Format(row.NeutralAxisDepth),
                Format(row.SteelStrainMax),
                Format(row.ConcreteStrainMax),
                Format(row.PhiFactor, "F2"),
                Escape(row.IntegrationMethod),
                row.ConcreteFiberCountX.ToString(CultureInfo.InvariantCulture),
                row.ConcreteFiberCountY.ToString(CultureInfo.InvariantCulture),
                row.CircularRadialFiberCount.ToString(CultureInfo.InvariantCulture),
                row.CircularAngularFiberCount.ToString(CultureInfo.InvariantCulture),
                row.CirclePolygonSegmentCount.ToString(CultureInfo.InvariantCulture),
                Escape(row.Remarks)
            }));
        }

        File.WriteAllText(path, builder.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    }

    private static string Format(double value, string format = "G17") => value.ToString(format, CultureInfo.InvariantCulture);

    private static string Escape(string value)
        => value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r')
            ? $"\"{value.Replace("\"", "\"\"")}\""
            : value;
}
