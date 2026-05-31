namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed record PreviewRebarPoint(int Index, double X, double Y, double Diameter, string Label)
{
    public double Area => System.Math.PI * System.Math.Pow(Diameter / 2.0, 2);
}

