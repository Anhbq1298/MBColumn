namespace MBColumn.Presentation.Wpf.ViewModels;

public enum DiagramViewportType { PM2D, MxMy2D, Pmm3D, PMx2D, PMy2D }

public sealed class ViewportOptionViewModel : ViewModelBase
{
    private bool isSelected;

    public ViewportOptionViewModel(DiagramViewportType type, string displayName, bool selected = true)
    {
        Type = type;
        DisplayName = displayName;
        isSelected = selected;
    }

    public DiagramViewportType Type { get; }
    public string DisplayName { get; }

    public bool IsSelected
    {
        get => isSelected;
        set => Set(ref isSelected, value);
    }
}

