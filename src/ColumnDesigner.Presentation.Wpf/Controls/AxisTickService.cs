using System.Globalization;

namespace ColumnDesigner.Presentation.Wpf.Controls;

public sealed record AxisTicks(double Min, double Max, double MajorInterval, double MinorInterval, IReadOnlyList<double> MajorTicks, IReadOnlyList<double> MinorTicks);

public static class AxisTickService
{
    public static AxisTicks Generate(double min, double max, int targetMajorCount = 6, int minorDivisions = 5)
    {
        if (double.IsNaN(min) || double.IsInfinity(min) || double.IsNaN(max) || double.IsInfinity(max) || Math.Abs(max - min) < 1e-12)
        {
            min = -1;
            max = 1;
        }

        if (max < min)
        {
            (min, max) = (max, min);
        }

        double major = NiceNumber((max - min) / Math.Max(1, targetMajorCount), round: true);
        double minor = major / Math.Max(1, minorDivisions);
        
        double niceMin = Math.Floor(min / major) * major;
        double niceMax = Math.Ceiling(max / major) * major;

        return new AxisTicks(niceMin, niceMax, major, minor, GenerateTicks(niceMin, niceMax, major), GenerateMinorTicks(niceMin, niceMax, major, minor));
    }

    public static string Format(double value)
    {
        if (Math.Abs(value) < 1e-10) return "0";
        return value.ToString("#,##0.##", CultureInfo.InvariantCulture);
    }

    private static IReadOnlyList<double> GenerateTicks(double min, double max, double step)
    {
        var ticks = new List<double>();
        double first = Math.Ceiling(min / step) * step;
        for (double v = first; v <= max + step * 0.5; v += step)
        {
            ticks.Add(Math.Abs(v) < step * 1e-8 ? 0 : v);
        }

        return ticks;
    }

    private static IReadOnlyList<double> GenerateMinorTicks(double min, double max, double major, double minor)
    {
        var majorTicks = new HashSet<double>(GenerateTicks(min, max, major).Select(v => Math.Round(v / minor)));
        var ticks = new List<double>();
        double first = Math.Ceiling(min / minor) * minor;
        for (double v = first; v <= max + minor * 0.5; v += minor)
        {
            if (!majorTicks.Contains(Math.Round(v / minor)))
            {
                ticks.Add(Math.Abs(v) < minor * 1e-8 ? 0 : v);
            }
        }

        return ticks;
    }

    private static double NiceNumber(double value, bool round)
    {
        if (value <= 0 || double.IsNaN(value) || double.IsInfinity(value)) return 1;
        double exponent = Math.Floor(Math.Log10(value));
        double fraction = value / Math.Pow(10, exponent);
        double niceFraction;
        if (round)
            niceFraction = fraction < 1.5 ? 1 : fraction < 2.25 ? 2 : fraction < 3.5 ? 2.5 : fraction < 7.5 ? 5 : 10;
        else
            niceFraction = fraction <= 1 ? 1 : fraction <= 2 ? 2 : fraction <= 2.5 ? 2.5 : fraction <= 5 ? 5 : 10;
        return niceFraction * Math.Pow(10, exponent);
    }
}
