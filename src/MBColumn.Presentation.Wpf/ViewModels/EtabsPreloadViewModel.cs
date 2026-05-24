using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsPreloadViewModel : ViewModelBase
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IEtabsPierShellImportService? pierShellImportService;
    private readonly IEtabsDesignForceImportService? designForceImportService;
    private readonly IImportedEtabsForceCache? forceCache;
    private readonly UnitSystem targetUnitSystem;
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
        this.pierShellImportService = pierShellImportService;
        this.designForceImportService = designForceImportService;
        this.forceCache = forceCache;
        this.targetUnitSystem = targetUnitSystem;

        Steps = [
            new() { Label = "Connecting to ETABS" },
            new() { Label = "Loading columns & sections" },
            new() { Label = "Loading load combinations" },
            new() { Label = "Importing element forces" },
            new() { Label = "Importing design forces" },
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
    }

    public ObservableCollection<EtabsPreloadStep> Steps { get; }
    public int CompletedCount => Steps.Count(s => s.IsDone || s.IsError);
    public string CompletedStepsText => $"[{CompletedCount}/{Steps.Count}]";
    public EtabsPreloadData? Result { get; private set; }
    public ICommand CancelCommand { get; }
    public event EventHandler<bool>? RequestClose;

    public double Progress        { get => progress;       private set => Set(ref progress, value); }
    public string StatusMessage   { get => statusMessage;  private set => Set(ref statusMessage, value); }
    public bool   HasError        { get => hasError;       private set => Set(ref hasError, value); }
    public bool   IsComplete      { get => isComplete;     private set => Set(ref isComplete, value); }

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
        progressDriftCts?.Cancel();
        RequestClose?.Invoke(this, false);
    }

    private CancellationTokenSource? progressDriftCts;

    private void StartProgressDrift(double start, double target, double expectedDurationSeconds)
    {
        progressDriftCts?.Cancel();
        progressDriftCts = new CancellationTokenSource();
        var token = progressDriftCts.Token;

        Progress = start;
        var steps = expectedDurationSeconds * 20; // 20 steps per second (50ms interval)
        var stepVal = (target - start) / steps;
        var maxLimit = start + (target - start) * 0.95; // Only drift up to 95%

        Task.Run(async () =>
        {
            for (int i = 0; i < steps; i++)
            {
                if (token.IsCancellationRequested) return;

                // Update on UI thread
                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                {
                    if (Progress < maxLimit)
                    {
                        Progress += stepVal;
                    }
                });

                await Task.Delay(50, CancellationToken.None);
            }
        }, token);
    }

    private void StopProgressDrift(double finalVal)
    {
        progressDriftCts?.Cancel();
        Progress = finalVal;
    }

    private async Task RunPreloadAsync(CancellationToken ct)
    {
        // ─── Step 1: Connect ───────────────────────────────────────────────
        Steps[0].SetRunning();
        StatusMessage = "Connecting to ETABS…";
        await Task.Yield();

        EtabsConnectionResultDto connResult;
        try
        {
            connResult = connectionService.ConnectToRunningEtabs();
        }
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
        Progress = 15;

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
            Progress = 30;
        }
        catch (Exception ex)
        {
            Steps[1].SetError(ex.Message);
            HasError = true;
            StatusMessage = $"Failed to load columns: {ex.Message}";
            return;
        }

        if (ct.IsCancellationRequested) return;

        // ─── Step 3: Load combinations ─────────────────────────────────────
        Steps[2].SetRunning();
        StatusMessage = "Loading load combinations…";
        await Task.Yield();

        IReadOnlyList<string> combos = [];
        try
        {
            combos = columnImportService.GetLoadCombinations();
            Steps[2].SetDone($"{combos.Count} combinations");
            Progress = 45;
        }
        catch (Exception ex)
        {
            Steps[2].SetError(ex.Message);
            HasError = true;
            StatusMessage = $"Failed to load combinations: {ex.Message}";
            return;
        }

        if (ct.IsCancellationRequested) return;

        // ─── Step 4 & 5: Load Forces (Element + Design) ─────────────────────
        if (designForceImportService is not null && forceCache is not null)
        {
            try
            {
                if (forceCache.HasValidCache(info.ModelPath))
                {
                    Steps[3].SetDone("cached");
                    Steps[4].SetDone("cached");
                    Progress = 100;
                }
                else
                {
                    int colElementRows = 0;
                    int pierElementRows = 0;
                    int colDesignRows = 0;
                    int pierDesignRows = 0;

                    var db = await Task.Run(() =>
                    {
                        bool hasCols = columns.Any(c => c.SectionType != MBColumn.Domain.Enums.SectionShapeType.Irregular);
                        bool hasPiers = false;
                        if (pierShellImportService is not null)
                        {
                            var pierGroups = pierShellImportService.GetPierGroups(targetUnitSystem);
                            hasPiers = pierGroups.Count > 0;
                        }

                        return designForceImportService.ImportDesignForces(
                            info.ModelPath,
                            info.ModelName,
                            hasCols,
                            hasPiers,
                            (phase, tableName, rowCount) =>
                            {
                                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                                {
                                    if (rowCount == 0)
                                    {
                                        // Start of sub-phase
                                        if (phase == 1) // Column Element
                                        {
                                            Steps[3].SetRunning("Loading columns element forces…");
                                            StatusMessage = "Loading columns element forces…";
                                            StartProgressDrift(45, 57.5, 3.0);
                                        }
                                        else if (phase == 2) // Pier Element
                                        {
                                            Steps[3].UpdateDetail("Loading piers element forces…");
                                            StatusMessage = "Loading piers element forces…";
                                            StartProgressDrift(57.5, 70.0, 3.0);
                                        }
                                        else if (phase == 3) // Column Design
                                        {
                                            Steps[3].SetDone($"{(colElementRows + pierElementRows):N0} rows");
                                            
                                            Steps[4].SetRunning("Loading columns design forces…");
                                            StatusMessage = "Loading columns design forces…";
                                            StartProgressDrift(70, 85.0, 3.0);
                                        }
                                        else if (phase == 4) // Pier Design
                                        {
                                            Steps[4].UpdateDetail("Loading piers design forces…");
                                            StatusMessage = "Loading piers design forces…";
                                            StartProgressDrift(85.0, 100.0, 3.0);
                                        }
                                    }
                                    else
                                    {
                                        // End of sub-phase
                                        if (phase == 1)
                                        {
                                            colElementRows = rowCount;
                                            StopProgressDrift(57.5);
                                        }
                                        else if (phase == 2)
                                        {
                                            pierElementRows = rowCount;
                                            StopProgressDrift(70.0);
                                        }
                                        else if (phase == 3)
                                        {
                                            colDesignRows = rowCount;
                                            StopProgressDrift(85.0);
                                        }
                                        else if (phase == 4)
                                        {
                                            pierDesignRows = rowCount;
                                            StopProgressDrift(100.0);
                                        }
                                    }
                                });
                            });
                    }, ct);

                    forceCache.Set(db);
                    Steps[3].SetDone($"{(colElementRows + pierElementRows):N0} rows");
                    Steps[4].SetDone($"{(colDesignRows + pierDesignRows):N0} rows");
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                Steps[3].SetError($"skipped ({ex.Message})");
                Steps[4].SetError($"skipped ({ex.Message})");
            }
        }
        else
        {
            Steps[3].SetDone("N/A");
            Steps[4].SetDone("N/A");
            Progress = 100;
        }

        Result = new EtabsPreloadData
        {
            ModelName      = info.ModelName,
            ModelPath      = info.ModelPath,
            PresentUnits   = info.PresentUnits,
            StoryCount     = info.StoryCount,
            PierCount      = info.PierCount,
            FrameObjectCount = info.FrameObjectCount,
            Columns        = columns,
            LoadCombinations = combos,
        };

        StatusMessage = "Ready — opening import dialog…";
        IsComplete = true;

        await Task.Delay(350, CancellationToken.None);

        System.Windows.Application.Current?.Dispatcher.Invoke(
            () => RequestClose?.Invoke(this, true));
    }
}
