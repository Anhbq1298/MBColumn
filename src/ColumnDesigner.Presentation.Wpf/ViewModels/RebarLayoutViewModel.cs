namespace ColumnDesigner.Presentation.Wpf.ViewModels;

public sealed class RebarLayoutViewModel
{
    public RebarLayoutViewModel(Action changed)
    {
        Top = new RebarSideInputViewModel("Top", changed);
        Bottom = new RebarSideInputViewModel("Bottom", changed);
        Left = new RebarSideInputViewModel("Left", changed);
        Right = new RebarSideInputViewModel("Right", changed);
    }

    public RebarSideInputViewModel Top { get; }
    public RebarSideInputViewModel Bottom { get; }
    public RebarSideInputViewModel Left { get; }
    public RebarSideInputViewModel Right { get; }
}
