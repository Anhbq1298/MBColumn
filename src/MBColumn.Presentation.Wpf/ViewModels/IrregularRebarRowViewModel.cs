namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class IrregularRebarRowViewModel : ViewModelBase
{
    private string rebarIndex = "";
    private double x;
    private double y;
    private string barSize = "";
    private double? areaMm2;

    public string RebarIndex { get => rebarIndex; set => Set(ref rebarIndex, value); }
    public double X { get => x; set => Set(ref x, value); }
    public double Y { get => y; set => Set(ref y, value); }
    public string BarSize { get => barSize; set => Set(ref barSize, value); }
    public double? AreaMm2 { get => areaMm2; set => Set(ref areaMm2, value); }
}
