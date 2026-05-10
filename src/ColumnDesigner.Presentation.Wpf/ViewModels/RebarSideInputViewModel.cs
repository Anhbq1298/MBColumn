using ColumnDesigner.Application.DTOs;

namespace ColumnDesigner.Presentation.Wpf.ViewModels;

public sealed class RebarSideInputViewModel : ViewModelBase
{
    private readonly Action changed;
    private int barCount;
    private string barSize = "";
    private double cover;
    private string barCountWarning = "";

    public RebarSideInputViewModel(string name, Action changed)
    {
        Name = name;
        this.changed = changed;
    }

    public string Name { get; }
    public bool IsBarSizeEditable => false;
    public bool IsCoverEditable => false;

    public int BarCount
    {
        get => barCount;
        set
        {
            if (barCount == value) return;
            barCount = value;
            Raise();
            changed();
        }
    }

    public string BarSize { get => barSize; private set => Set(ref barSize, value); }
    public double Cover { get => cover; private set => Set(ref cover, value); }
    public string BarCountWarning { get => barCountWarning; private set => Set(ref barCountWarning, value); }
    public bool HasBarCountWarning => !string.IsNullOrWhiteSpace(BarCountWarning);

    public RebarSideInputDto ToDto(string globalBarSize, double globalCover)
        => new(BarCount, globalBarSize, globalCover);

    public void SetGlobalInputs(string globalBarSize, double globalCover)
    {
        BarSize = globalBarSize;
        Cover = globalCover;
    }

    public void SetBarCountSilently(int value)
    {
        if (barCount == value) return;
        barCount = value;
        Raise(nameof(BarCount));
    }

    public void SetWarning(string message)
    {
        BarCountWarning = message;
        Raise(nameof(HasBarCountWarning));
    }
}
