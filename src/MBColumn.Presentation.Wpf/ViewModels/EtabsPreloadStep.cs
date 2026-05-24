namespace MBColumn.Presentation.Wpf.ViewModels;

public enum PreloadStepStatus { Pending, Running, Done, Error }

public sealed class EtabsPreloadStep : ViewModelBase
{
    private PreloadStepStatus status = PreloadStepStatus.Pending;
    private string detail = "";

    public string Label { get; init; } = "";

    public PreloadStepStatus Status
    {
        get => status;
        private set
        {
            Set(ref status, value);
            Raise(nameof(IsPending));
            Raise(nameof(IsRunning));
            Raise(nameof(IsDone));
            Raise(nameof(IsError));
        }
    }

    public string Detail
    {
        get => detail;
        private set
        {
            Set(ref detail, value);
            Raise(nameof(HasDetail));
        }
    }

    public bool IsPending => status == PreloadStepStatus.Pending;
    public bool IsRunning => status == PreloadStepStatus.Running;
    public bool IsDone    => status == PreloadStepStatus.Done;
    public bool IsError   => status == PreloadStepStatus.Error;
    public bool HasDetail => !string.IsNullOrEmpty(detail);

    public void SetRunning(string detail = "") { Detail = detail; Status = PreloadStepStatus.Running; }
    public void SetDone(string detail = "")  { Detail = detail; Status = PreloadStepStatus.Done; }
    public void SetError(string msg)         { Detail = msg;    Status = PreloadStepStatus.Error; }
    public void UpdateDetail(string value)   => Detail = value;
}
