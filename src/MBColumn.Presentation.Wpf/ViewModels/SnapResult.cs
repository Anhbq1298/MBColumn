namespace MBColumn.Presentation.Wpf.ViewModels;

public enum SnapKind { None, Grid, Midpoint }

public sealed class SnapResult
{
    public double X { get; init; }
    public double Y { get; init; }
    public SnapKind Kind { get; init; }
    public bool HasSnap => Kind != SnapKind.None;
}
