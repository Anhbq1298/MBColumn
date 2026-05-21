namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class CadRebarViewModel : ViewModelBase
{
    private double x;
    private double y;
    private string barSize;
    private double? areaMm2;

    public CadRebarViewModel(double x, double y, string barSize, double? areaMm2)
    {
        this.x = x;
        this.y = y;
        this.barSize = barSize;
        this.areaMm2 = areaMm2;
    }

    public double X { get => x; set => Set(ref x, value); }
    public double Y { get => y; set => Set(ref y, value); }
    public string BarSize { get => barSize; set => Set(ref barSize, value); }
    public double? AreaMm2 { get => areaMm2; set => Set(ref areaMm2, value); }
}
