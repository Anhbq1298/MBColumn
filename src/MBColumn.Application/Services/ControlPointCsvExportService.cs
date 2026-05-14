using MBColumn.Application.DTOs;
using System.Globalization;
using System.Text;

namespace MBColumn.Application.Services;

public sealed class ControlPointCsvExportService : IControlPointCsvExportService
{
    private static readonly string[] Headers = ["θ", "Pt.", "P", "Mθ+", "Mθ-", "c", "εs,max", "εc,max", "Remarks"];

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
                Format(row.MThetaPositive),
                Format(row.MThetaNegative),
                Format(row.NeutralAxisDepth),
                Format(row.SteelStrainMax),
                Format(row.ConcreteStrainMax),
                Escape(row.Remarks)
            }));
        }

        File.WriteAllText(path, builder.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
    }

    private static string Format(double value) => value.ToString("G17", CultureInfo.InvariantCulture);

    private static string Escape(string value)
        => value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r')
            ? $"\"{value.Replace("\"", "\"\"")}\""
            : value;
}
