namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class PolylineDraft
{
    public List<(double X, double Y)> Points { get; } = [];
    public (double X, double Y)? PreviewPoint { get; set; }
    public bool IsActive => Points.Count > 0;

    public void Clear()
    {
        Points.Clear();
        PreviewPoint = null;
    }
}
