namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class IrregularBoundaryPointViewModel : ViewModelBase
{
    private int ptIndex;
    private double x;
    private double y;

    public int PtIndex { get => ptIndex; set => Set(ref ptIndex, value); }
    public double X { get => x; set => Set(ref x, value); }
    public double Y { get => y; set => Set(ref y, value); }
}
