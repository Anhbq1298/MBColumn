using System.Globalization;

namespace MBColumn.Application.Services.ImportExport;

public sealed class DxfExportService
{
    public void Export(
        string filePath,
        IReadOnlyList<(double X, double Y)> boundaryPoints,
        IReadOnlyList<(double X, double Y, double AreaMm2)> rebars)
    {
        using var w = new StreamWriter(filePath, append: false, System.Text.Encoding.ASCII);

        WriteHeader(w);
        WriteTablesSection(w);
        WriteEntitiesSection(w, boundaryPoints, rebars);
        WriteFooter(w);
    }

    private static void WriteHeader(StreamWriter w)
    {
        w.WriteLine("  0\nSECTION");
        w.WriteLine("  2\nHEADER");
        w.WriteLine("  9\n$ACADVER");
        w.WriteLine("  1\nAC1015");
        w.WriteLine("  0\nENDSEC");
    }

    private static void WriteTablesSection(StreamWriter w)
    {
        w.WriteLine("  0\nSECTION");
        w.WriteLine("  2\nTABLES");

        // LAYER table with BOUNDARY and REBAR entries
        w.WriteLine("  0\nTABLE");
        w.WriteLine("  2\nLAYER");
        w.WriteLine(" 70\n2");

        WriteLayerEntry(w, "BOUNDARY", 5);  // blue
        WriteLayerEntry(w, "REBAR", 1);     // red

        w.WriteLine("  0\nENDTAB");
        w.WriteLine("  0\nENDSEC");
    }

    private static void WriteLayerEntry(StreamWriter w, string name, int colorIndex)
    {
        w.WriteLine("  0\nLAYER");
        w.WriteLine($"  2\n{name}");
        w.WriteLine(" 70\n0");
        w.WriteLine($" 62\n{colorIndex}");
        w.WriteLine("  6\nCONTINUOUS");
    }

    private static void WriteEntitiesSection(
        StreamWriter w,
        IReadOnlyList<(double X, double Y)> boundary,
        IReadOnlyList<(double X, double Y, double AreaMm2)> rebars)
    {
        w.WriteLine("  0\nSECTION");
        w.WriteLine("  2\nENTITIES");

        if (boundary.Count >= 2)
        {
            w.WriteLine("  0\nLWPOLYLINE");
            w.WriteLine("  8\nBOUNDARY");
            w.WriteLine(" 70\n1");       // closed flag
            w.WriteLine($" 90\n{boundary.Count}");
            foreach (var (x, y) in boundary)
            {
                w.WriteLine($" 10\n{F(x)}");
                w.WriteLine($" 20\n{F(y)}");
            }
        }

        foreach (var (cx, cy, areaMm2) in rebars)
        {
            double radius = areaMm2 > 0 ? Math.Sqrt(areaMm2 / Math.PI) : 12.5;
            w.WriteLine("  0\nCIRCLE");
            w.WriteLine("  8\nREBAR");
            w.WriteLine($" 10\n{F(cx)}");
            w.WriteLine($" 20\n{F(cy)}");
            w.WriteLine($" 40\n{F(radius)}");
        }

        w.WriteLine("  0\nENDSEC");
    }

    private static void WriteFooter(StreamWriter w) => w.WriteLine("  0\nEOF");

    private static string F(double v) => v.ToString("G10", CultureInfo.InvariantCulture);
}
