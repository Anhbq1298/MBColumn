namespace MBColumn.Presentation.Wpf.Controls.MathRendering;

public sealed class MathEquationViewModel
{
    public string Latex { get; init; } = "";
    public string FallbackText { get; init; } = "";
    public MathRenderMode RenderMode { get; init; } = MathRenderMode.Inline;
    public double FontSize { get; init; } = 14.0;
    public bool UseEnhancedMath { get; init; } = true;
}
