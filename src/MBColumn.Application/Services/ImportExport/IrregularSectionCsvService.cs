using System.Globalization;
using System.Text;
using MBColumn.Application.DTOs.ImportExport;

namespace MBColumn.Application.Services.ImportExport;

// CSV import/export for irregular boundary and rebar tables.
// Format is versioned with metadata lines that start with '#'.
// Parser must:
//   - skip blank lines and metadata/comment lines beginning with '#'
//   - require the exact header
//   - parse using invariant culture
//   - preserve data row order
public sealed class IrregularSectionCsvService : IIrregularSectionCsvService
{
    public const int Version = 1;
    public const string BoundaryHeader = "ptIndex,X,Y";
    public const string RebarHeader = "rebarIndex,X,Y,BarSize,AreaMm2";

    public IReadOnlyList<IrregularBoundaryPointCsvDto> ImportBoundary(string filePath)
        => ParseBoundary(File.ReadAllText(filePath, Encoding.UTF8));

    public IReadOnlyList<IrregularRebarCsvDto> ImportRebars(string filePath)
        => ParseRebars(File.ReadAllText(filePath, Encoding.UTF8));

    public IReadOnlyList<IrregularBoundaryPointCsvDto> ParseBoundary(string csvText)
    {
        var lines = SplitLines(csvText);
        int dataStart = FindHeader(lines, BoundaryHeader);
        var rows = new List<IrregularBoundaryPointCsvDto>();
        for (int i = dataStart; i < lines.Count; i++)
        {
            string raw = lines[i];
            if (IsSkippable(raw)) continue;
            var fields = SplitCsv(raw);
            if (fields.Length < 3)
            {
                throw new FormatException($"Boundary CSV row {i + 1} is malformed: expected 3 columns, got {fields.Length}.");
            }
            if (!int.TryParse(fields[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int idx))
            {
                throw new FormatException($"Boundary CSV row {i + 1}, column 'ptIndex': '{fields[0]}' is not a valid integer.");
            }
            double x = ParseDouble(fields[1], i + 1, "X");
            double y = ParseDouble(fields[2], i + 1, "Y");
            rows.Add(new IrregularBoundaryPointCsvDto(idx, x, y));
        }
        return rows;
    }

    public IReadOnlyList<IrregularRebarCsvDto> ParseRebars(string csvText)
    {
        var lines = SplitLines(csvText);
        int dataStart = FindHeader(lines, RebarHeader);
        var rows = new List<IrregularRebarCsvDto>();
        for (int i = dataStart; i < lines.Count; i++)
        {
            string raw = lines[i];
            if (IsSkippable(raw)) continue;
            var fields = SplitCsv(raw);
            if (fields.Length < 5)
            {
                throw new FormatException($"Rebar CSV row {i + 1} is malformed: expected 5 columns, got {fields.Length}.");
            }
            string index = fields[0];
            double x = ParseDouble(fields[1], i + 1, "X");
            double y = ParseDouble(fields[2], i + 1, "Y");
            string? barSize = string.IsNullOrWhiteSpace(fields[3]) ? null : fields[3];
            double? area = null;
            if (!string.IsNullOrWhiteSpace(fields[4]))
            {
                area = ParseDouble(fields[4], i + 1, "AreaMm2");
            }
            rows.Add(new IrregularRebarCsvDto(index, x, y, barSize, area));
        }
        return rows;
    }

    public void ExportBoundary(string filePath, IReadOnlyList<IrregularBoundaryPointCsvDto> points)
        => File.WriteAllText(filePath, SerializeBoundary(points), new UTF8Encoding(false));

    public void ExportRebars(string filePath, IReadOnlyList<IrregularRebarCsvDto> rebars)
        => File.WriteAllText(filePath, SerializeRebars(rebars), new UTF8Encoding(false));

    public string SerializeBoundary(IReadOnlyList<IrregularBoundaryPointCsvDto> points)
    {
        var sb = new StringBuilder();
        sb.Append("# MBColumnCsvVersion=").Append(Version).Append('\n');
        sb.Append("# DataType=IrregularBoundary\n");
        sb.Append("# CoordinateUnit=mm\n");
        sb.Append("# CoordinateOrigin=UserInput\n");
        sb.Append(BoundaryHeader).Append('\n');
        foreach (var p in points)
        {
            sb.Append(p.PtIndex.ToString(CultureInfo.InvariantCulture)).Append(',');
            sb.Append(p.X.ToString("R", CultureInfo.InvariantCulture)).Append(',');
            sb.Append(p.Y.ToString("R", CultureInfo.InvariantCulture)).Append('\n');
        }
        return sb.ToString();
    }

    public string SerializeRebars(IReadOnlyList<IrregularRebarCsvDto> rebars)
    {
        var sb = new StringBuilder();
        sb.Append("# MBColumnCsvVersion=").Append(Version).Append('\n');
        sb.Append("# DataType=IrregularRebar\n");
        sb.Append("# CoordinateUnit=mm\n");
        sb.Append("# CoordinateOrigin=UserInput\n");
        sb.Append(RebarHeader).Append('\n');
        foreach (var r in rebars)
        {
            sb.Append(r.RebarIndex).Append(',');
            sb.Append(r.X.ToString("R", CultureInfo.InvariantCulture)).Append(',');
            sb.Append(r.Y.ToString("R", CultureInfo.InvariantCulture)).Append(',');
            sb.Append(r.BarSize ?? "").Append(',');
            sb.Append(r.AreaMm2 is double a ? a.ToString("R", CultureInfo.InvariantCulture) : "");
            sb.Append('\n');
        }
        return sb.ToString();
    }

    private static int FindHeader(IReadOnlyList<string> lines, string expected)
    {
        for (int i = 0; i < lines.Count; i++)
        {
            string raw = lines[i];
            if (IsSkippable(raw)) continue;
            string normalized = raw.Trim().Replace(" ", "");
            string expectedNormalized = expected.Replace(" ", "");
            if (!string.Equals(normalized, expectedNormalized, StringComparison.Ordinal))
            {
                throw new FormatException(
                    $"CSV header mismatch. Expected '{expected}', got '{raw.Trim()}'.");
            }
            return i + 1;
        }
        throw new FormatException($"CSV header '{expected}' not found.");
    }

    private static bool IsSkippable(string line)
    {
        string trimmed = line.TrimStart();
        return trimmed.Length == 0 || trimmed.StartsWith('#');
    }

    private static List<string> SplitLines(string text)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(text)) return result;
        foreach (var line in text.Split('\n'))
        {
            result.Add(line.TrimEnd('\r'));
        }
        return result;
    }

    private static string[] SplitCsv(string line)
    {
        var fields = line.Split(',');
        for (int i = 0; i < fields.Length; i++)
        {
            fields[i] = fields[i].Trim();
        }
        return fields;
    }

    private static double ParseDouble(string field, int rowNumber, string columnName)
    {
        if (!double.TryParse(field, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new FormatException(
                $"CSV row {rowNumber}, column '{columnName}': '{field}' is not a valid number.");
        }
        return value;
    }
}
