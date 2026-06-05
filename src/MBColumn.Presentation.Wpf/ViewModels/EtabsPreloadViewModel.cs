using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsPreloadViewModel : ViewModelBase
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly UnitSystem targetUnitSystem;
    private readonly RelayCommand nextCommand;
    private CancellationTokenSource? cts;
    private bool cancelled;

    private double progress;
    private string statusMessage = "Initializing…";
    private bool hasError;
    private bool isComplete;

    public EtabsPreloadViewModel(
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsPierShellImportService? pierShellImportService,
        IEtabsDesignForceImportService? designForceImportService,
        IImportedEtabsForceCache? forceCache,
        UnitSystem targetUnitSystem)
    {
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.targetUnitSystem = targetUnitSystem;

        Steps = [
            new() { Label = "Connecting to ETABS" },
            new() { Label = "Loading columns & sections" },
            new() { Label = "Loading load combinations" },
        ];

        foreach (var step in Steps)
        {
            step.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(EtabsPreloadStep.Status))
                {
                    Raise(nameof(CompletedCount));
                    Raise(nameof(CompletedStepsText));
                }
            };
        }

        CancelCommand = new RelayCommand(Cancel);
        nextCommand = new RelayCommand(() => RequestClose?.Invoke(this, true), () => IsComplete);
    }

    public ObservableCollection<EtabsPreloadStep> Steps { get; }

    public int CompletedCount => Steps.Count(s => s.IsDone || s.IsError);
    public string CompletedStepsText => $"[{CompletedCount}/{Steps.Count}]";

    public EtabsPreloadData? Result { get; private set; }
    public ICommand CancelCommand { get; }
    public ICommand NextCommand => nextCommand;
    public event EventHandler<bool>? RequestClose;

    public double Progress      { get => progress;      private set => Set(ref progress, value); }
    public string StatusMessage { get => statusMessage; private set => Set(ref statusMessage, value); }
    public bool   HasError      { get => hasError;      private set => Set(ref hasError, value); }
    public bool IsComplete
    {
        get => isComplete;
        private set
        {
            Set(ref isComplete, value);
            nextCommand.RaiseCanExecuteChanged();
        }
    }

    public async Task StartAsync()
    {
        cts = new CancellationTokenSource();
        await RunPreloadAsync(cts.Token);
    }

    public void Cancel()
    {
        if (cancelled) return;
        cancelled = true;
        cts?.Cancel();
        RequestClose?.Invoke(this, false);
    }

    private async Task RunPreloadAsync(CancellationToken ct)
    {
        // ─── Step 1: Connect ───────────────────────────────────────────────
        Steps[0].SetRunning();
        StatusMessage = "Connecting to ETABS…";
        await Task.Yield();

        EtabsConnectionResultDto connResult;
        try { connResult = connectionService.ConnectToRunningEtabs(); }
        catch (Exception ex)
        {
            Steps[0].SetError(ex.Message);
            StatusMessage = $"Connection failed: {ex.Message}";
            HasError = true;
            return;
        }

        if (!connResult.IsConnected)
        {
            Steps[0].SetError(connResult.Message);
            StatusMessage = connResult.Message;
            HasError = true;
            return;
        }

        var info = connResult.ModelInfo!;
        Steps[0].SetDone(info.ModelName);
        Progress = 33;
        if (ct.IsCancellationRequested) return;

        // ─── Step 2: Load columns ──────────────────────────────────────────
        Steps[1].SetRunning();
        StatusMessage = "Loading columns & sections…";
        await Task.Yield();

        IReadOnlyList<EtabsColumnImportDto> columns = [];
        try
        {
            columns = columnImportService.GetCandidateColumns(targetUnitSystem);
            Steps[1].SetDone($"{columns.Count} objects");
            Progress = 66;
        }
        catch (Exception ex)
        {
            Steps[1].SetError(ex.Message);
            HasError = true;
            StatusMessage = $"Failed to load columns: {ex.Message}";
            return;
        }

        if (ct.IsCancellationRequested) return;

        // ─── Step 3: Load combination names ────────────────────────────────
        Steps[2].SetRunning();
        StatusMessage = "Loading load combinations…";
        await Task.Yield();

        IReadOnlyList<string> combos = [];
        try
        {
            combos = columnImportService.GetLoadCombinations();
            Steps[2].SetDone($"{combos.Count} combinations");
            Progress = 100;
        }
        catch (Exception ex)
        {
            Steps[2].SetError(ex.Message);
            HasError = true;
            StatusMessage = $"Failed to load combinations: {ex.Message}";
            return;
        }

        Result = new EtabsPreloadData
        {
            ModelName                = info.ModelName,
            ModelPath                = info.ModelPath,
            PresentUnits             = info.PresentUnits,
            StoryCount               = info.StoryCount,
            PierCount                = info.PierCount,
            FrameObjectCount         = info.FrameObjectCount,
            Columns                  = columns,
            LoadCombinations         = combos,
            SelectedLoadCombinations = [],
        };

        StatusMessage = "Ready — click Next to continue.";
        IsComplete = true;
    }
}
