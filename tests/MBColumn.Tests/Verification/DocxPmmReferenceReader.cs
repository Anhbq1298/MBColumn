using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MBColumn.Tests.Verification;

public sealed class DocxPmmReferenceReader
{
    private static readonly XNamespace W = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

    public DocxPmmReferenceData Read(string docxPath)
    {
        if (!File.Exists(docxPath))
        {
            throw new FileNotFoundException($"PMM reference DOCX was not found: {docxPath}", docxPath);
        }

        var document = ReadDocumentXml(docxPath);
        var parameterRows = ReadParameterRows(document);
        var fullText = ReadFullText(document);
        var notes = new List<string>();

        string sectionShape = GetRequired(parameterRows, "Section type");
        string columnSize = GetRequired(parameterRows, "Column size");
        var (widthMm, heightMm) = ParseDimensions(columnSize);
        string designCode = GetRequired(parameterRows, "Concrete code");
        double fcMpa = ParseNumber(GetRequired(parameterRows, "fck"));
        double fyMpa = ParseNumber(GetRequired(parameterRows, "fyk (vertical bars)"));
        double esMpa = ParseNumber(GetRequired(parameterRows, "Es"));
        string verticalReinforcement = GetRequired(parameterRows, "Vertical reinforcement");
        var (barCount, barSize, barDiameterMm) = ParseVerticalReinforcement(verticalReinforcement);
        double totalAs = ParseNumber(GetRequired(parameterRows, "As"));
        string linkDescription = GetRequired(parameterRows, "Links");
        double? linkDiameterMm = ParseOptionalBarDiameter(linkDescription);
        string arrangement = GetRequired(parameterRows, "Bar arrangement");
        var thetaValues = ParseThetaValues(GetRequired(parameterRows, "Reference theta values"));
        int expectedPointCount = (int)ParseNumber(GetRequired(parameterRows, "Reference number of points per theta"));
        var (axialStart, axialEnd) = ParseAxialRange(GetRequired(parameterRows, "Reference axial range"));
        string momentUnit = GetRequired(parameterRows, "Reference moment unit");
        double clearCoverMm = ParseClearCover(fullText);

        var referencePoints = ParseReferencePoints(fullText, expectedPointCount, thetaValues, notes);
        ValidateReferencePointOrdering(referencePoints, thetaValues, notes);

        return new DocxPmmReferenceData(
            SourcePath: docxPath,
            SectionShape: sectionShape,
            WidthMm: widthMm,
            HeightMm: heightMm,
            ClearCoverMm: clearCoverMm,
            DesignCode: designCode,
            UnitSystem: "Metric: mm, MPa, kN, kNm",
            ConcreteStrengthMpa: fcMpa,
            SteelYieldStrengthMpa: fyMpa,
            SteelElasticModulusMpa: esMpa,
            VerticalReinforcement: verticalReinforcement,
            BarCount: barCount,
            BarSize: barSize,
            BarDiameterMm: barDiameterMm,
            TotalRebarAreaMm2: totalAs,
            LinkDescription: linkDescription,
            LinkDiameterMm: linkDiameterMm,
            BarArrangement: arrangement,
            ThetaDegrees: thetaValues,
            ExpectedPointCountPerTheta: expectedPointCount,
            ReferenceAxialStartKn: axialStart,
            ReferenceAxialEndKn: axialEnd,
            ReferenceMomentUnit: momentUnit,
            ReferenceMomentDefinition: "S-CONCRETE normal moment M, treated as resultant moment magnitude.",
            ReferenceSignConvention: "S-CONCRETE axial compression is negative in the reference table.",
            ReferencePoints: referencePoints,
            ExtractionNotes: notes);
    }

    private static XDocument ReadDocumentXml(string docxPath)
    {
        using var archive = ZipFile.OpenRead(docxPath);
        var entry = archive.GetEntry("word/document.xml")
            ?? throw new InvalidOperationException("DOCX does not contain word/document.xml.");
        using var stream = entry.Open();
        return XDocument.Load(stream);
    }

    private static Dictionary<string, string> ReadParameterRows(XDocument document)
    {
        var tables = document.Descendants(W + "tbl").ToList();
        if (tables.Count == 0)
        {
            throw new InvalidOperationException("No tables were found in the DOCX reference package.");
        }

        var rows = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var row in tables[0].Descendants(W + "tr"))
        {
            var cells = row.Elements(W + "tc").Select(ReadElementText).ToList();
            if (cells.Count >= 2 && !string.Equals(cells[0], "Parameter", StringComparison.OrdinalIgnoreCase))
            {
                rows[cells[0]] = cells[1];
            }
        }

        return rows;
    }

    private static string ReadFullText(XDocument document)
        => string.Concat(document.Descendants(W + "p").Select(ReadElementText).Where(t => !string.IsNullOrWhiteSpace(t)));

    private static string ReadElementText(XElement element)
        => string.Concat(element.Descendants(W + "t").Select(t => (string?)t ?? string.Empty)).Trim();

    private static string GetRequired(IReadOnlyDictionary<string, string> rows, string key)
    {
        if (!rows.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Required DOCX parameter '{key}' was not found.");
        }

        return value;
    }

    private static (double WidthMm, double HeightMm) ParseDimensions(string value)
    {
        var numbers = ReadNumbers(value).ToList();
        if (numbers.Count < 2)
        {
            throw new InvalidOperationException($"Could not parse section dimensions from '{value}'.");
        }

        return (numbers[0], numbers[1]);
    }

    private static (int Count, string Size, double DiameterMm) ParseVerticalReinforcement(string value)
    {
        var match = Regex.Match(value, @"(?<count>\d+)\s*(?<prefix>[A-Za-z]+)\s*(?<diameter>\d+(?:\.\d+)?)");
        if (!match.Success)
        {
            throw new InvalidOperationException($"Could not parse vertical reinforcement from '{value}'.");
        }

        int count = int.Parse(match.Groups["count"].Value, CultureInfo.InvariantCulture);
        string size = match.Groups["prefix"].Value.ToUpperInvariant() + match.Groups["diameter"].Value;
        double diameter = double.Parse(match.Groups["diameter"].Value, CultureInfo.InvariantCulture);
        return (count, size, diameter);
    }

    private static double? ParseOptionalBarDiameter(string value)
    {
        var match = Regex.Match(value, @"[A-Za-z]+(?<diameter>\d+(?:\.\d+)?)");
        return match.Success
            ? double.Parse(match.Groups["diameter"].Value, CultureInfo.InvariantCulture)
            : null;
    }

    private static IReadOnlyList<int> ParseThetaValues(string value)
        => ReadNumbers(value).Select(v => (int)Math.Round(v)).ToList();

    private static (double StartKn, double EndKn) ParseAxialRange(string value)
    {
        var numbers = ReadNumbers(value).ToList();
        if (numbers.Count < 2)
        {
            throw new InvalidOperationException($"Could not parse axial range from '{value}'.");
        }

        return (numbers[0], numbers[1]);
    }

    private static double ParseClearCover(string fullText)
    {
        var match = Regex.Match(fullText, @"Clear\s+cover\s*=\s*(?<cover>-?\d+(?:\.\d+)?)\s*mm", RegexOptions.IgnoreCase);
        if (!match.Success)
        {
            throw new InvalidOperationException("Required clear cover value was not found in the DOCX.");
        }

        return double.Parse(match.Groups["cover"].Value, CultureInfo.InvariantCulture);
    }

    private static IReadOnlyList<PmmReferencePoint> ParseReferencePoints(
        string fullText,
        int expectedPointCount,
        IReadOnlyList<int> thetaValues,
        List<string> notes)
    {
        var points = new List<PmmReferencePoint>();
        var blockPattern = new Regex(
            @"#\s*Points\s+(?<count>\d+)\s*Theta\s*\(Degrees\)\s*(?<theta>-?\d+(?:\.\d+)?)\s*AxialNormalLoad,\s*kNMoment,\s*kNm(?<data>.*?)(?=#\s*Points\s+\d+\s*Theta\s*\(Degrees\)|Additional\s+Section\s+Parameter|$)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        foreach (Match block in blockPattern.Matches(fullText))
        {
            int theta = (int)Math.Round(double.Parse(block.Groups["theta"].Value, CultureInfo.InvariantCulture));
            int declaredCount = int.Parse(block.Groups["count"].Value, CultureInfo.InvariantCulture);
            if (!thetaValues.Contains(theta))
            {
                notes.Add($"Reference block theta {theta} deg was present in Appendix A but not in the theta list table.");
            }

            var numbers = ReadNumbers(block.Groups["data"].Value).ToList();
            int parsedPairs = numbers.Count / 2;
            if (numbers.Count % 2 != 0)
            {
                notes.Add($"Theta {theta} has an odd number of numeric tokens; the final token was ignored.");
            }

            if (declaredCount != expectedPointCount)
            {
                notes.Add($"Theta {theta} declares {declaredCount} points; table summary expects {expectedPointCount}.");
            }

            if (parsedPairs != declaredCount)
            {
                notes.Add($"Theta {theta} declares {declaredCount} points; parser found {parsedPairs} P-M pairs.");
            }

            for (int i = 0; i < parsedPairs; i++)
            {
                double pKn = numbers[i * 2];
                double mKnm = numbers[i * 2 + 1];
                points.Add(new PmmReferencePoint(theta, i, pKn, mKnm, 0.0));
            }
        }

        var missingThetas = thetaValues.Except(points.Select(p => p.ThetaDegrees).Distinct()).ToList();
        if (missingThetas.Count > 0)
        {
            notes.Add($"Missing reference PM data for theta values: {string.Join(", ", missingThetas)}.");
        }

        if (points.Count == 0)
        {
            throw new InvalidOperationException("No reference PM points were parsed from Appendix A.");
        }

        return points;
    }

    private static void ValidateReferencePointOrdering(
        IReadOnlyList<PmmReferencePoint> points,
        IReadOnlyList<int> thetaValues,
        List<string> notes)
    {
        foreach (int theta in thetaValues)
        {
            var thetaPoints = points.Where(p => p.ThetaDegrees == theta).OrderBy(p => p.PointIndex).ToList();
            if (thetaPoints.Count == 0)
            {
                continue;
            }

            bool monotonic = thetaPoints.Zip(thetaPoints.Skip(1)).All(pair => pair.First.RefP >= pair.Second.RefP);
            notes.Add(monotonic
                ? $"Theta {theta} reference point order verified: axial load is monotonically decreasing from tension/zero toward compression."
                : $"Theta {theta} reference point order is not monotonic by axial load; nearest-neighbour matching may be required.");
        }
    }

    private static double ParseNumber(string value)
        => ReadNumbers(value).FirstOrDefault();

    private static IEnumerable<double> ReadNumbers(string value)
    {
        foreach (Match match in Regex.Matches(value, @"-?\d+(?:\.\d+)?"))
        {
            yield return double.Parse(match.Value, CultureInfo.InvariantCulture);
        }
    }
}
