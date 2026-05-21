namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class CadPointViewModel : ViewModelBase
{
    private double x;
    private double y;

    public CadPointViewModel(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X { get => x; set => Set(ref x, value); }
    public double Y { get => y; set => Set(ref y, value); }
}
