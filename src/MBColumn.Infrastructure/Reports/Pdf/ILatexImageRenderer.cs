namespace MBColumn.Infrastructure.Reports.Pdf;

public interface ILatexImageRenderer
{
    /// <summary>
    /// Renders a LaTeX expression to a PNG byte array.
    /// Returns null if the expression cannot be rendered.
    /// </summary>
    byte[]? RenderToPng(string latex, double scale);
}
