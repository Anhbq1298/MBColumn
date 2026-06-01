namespace MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;

public sealed class CheckSummaryRowViewModel : ViewModelBase
{
    private string _after = "—";
    private string _condition = "—";
    private string _status = "—";
    private bool _isPassBefore;
    private bool _isPassAfter;

    public string CheckName { get; init; } = string.Empty;
    public string Before { get; init; } = "—";

    public string After
    {
        get => _after;
        set => Set(ref _after, value);
    }

    public string Condition
    {
        get => _condition;
        set => Set(ref _condition, value);
    }

    public string Status
    {
        get => _status;
        set => Set(ref _status, value);
    }

    public bool IsPassBefore
    {
        get => _isPassBefore;
        set => Set(ref _isPassBefore, value);
    }

    public bool IsPassAfter
    {
        get => _isPassAfter;
        set => Set(ref _isPassAfter, value);
    }
}
