namespace MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;

public sealed class BeforeAfterRowViewModel : ViewModelBase
{
    private string _after = string.Empty;
    private string _condition = "Frozen";

    public string Parameter { get; init; } = string.Empty;
    public string Before { get; init; } = string.Empty;
    public string Unit { get; init; } = string.Empty;
    public bool IsFrozen { get; init; }

    public string After
    {
        get => _after;
        set
        {
            if (!Set(ref _after, value)) return;
            Condition = IsFrozen ? "Frozen"
                      : value == Before ? "Unchanged"
                      : "Changed";
        }
    }

    public string Condition
    {
        get => _condition;
        private set => Set(ref _condition, value);
    }
}
