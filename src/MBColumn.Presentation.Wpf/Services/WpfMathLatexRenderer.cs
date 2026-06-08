using MBColumn.Infrastructure.Reports.Pdf;
using WpfMath;
using WpfMath.Parsers;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class WpfMathLatexRenderer : ILatexImageRenderer
{
    public byte[]? RenderToPng(string latex, double scale)
    {
        if (string.IsNullOrWhiteSpace(latex))
            return null;

        try
        {
            var normalized = latex
                .Replace(@"\\", @"\")
                .Replace(@"\ ", @"\,");

            var formula = WpfTeXFormulaParser.Instance.Parse(normalized);
            return formula.RenderToPng(scale, 0.0, 0.0, "Arial");
        }
        catch
        {
            return null;
        }
    }
}
