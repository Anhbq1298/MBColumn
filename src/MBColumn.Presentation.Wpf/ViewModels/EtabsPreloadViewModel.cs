using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Data;
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
    private readonly RelayCommand proceedCommand;
    private readonly RelayCommand nextCommand;
    private readonly RelayCommand selectAllCombosCommand;
    private readonly RelayCommand clearAllCombosCommand;
    private CancellationTokenSource? cts;
    private TaskCompletionSource<bool>? comboSelectionTcs;
    private bool cancelled;

    private double progress;
    private string statusMessage = "Initializing…";
    private bool hasError;
    private bool isComplete;
    private bool isAwaitingComboSelection;
    private string loadComboFilterText = "";

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
            new() { Label = "Element forces" },
            new() { Label = "Columns", IsSubStep = true },
            new() { Label = "Piers",   IsSubStep = true },
            new() { Label = "Design forces" },
            new() { Label = "Columns", IsSubStep = true },
            new() { Label = "Piers",   IsSubStep = true },
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

        AvailableCombinations = [];
        FilteredCombinations = new ListCollectionView(AvailableCombinations)
        {
            Filter = o => o is EtabsLoadCombinationViewModel c &&
                          (string.IsNullOrEmpty(loadComboFilterText) ||
                           c.Name.Contains(loadComboFilterText, StringComparison.OrdinalIgnoreCase))
        };

        CancelCommand = new RelayCommand(Cancel);
        proceedCommand = new RelayCommand(OnProceed,
            () => IsAwaitingComboSelection && AvailableCombinations.Any(c => c.IsSelected));
        nextCommand = new RelayCommand(() => RequestClose?.Invoke(this, true), () => IsComplete);
        selectAllCombosCommand = new RelayCommand(
            () => { foreach (var c in AvailableCombinations) c.IsSelected = true; },
            () => IsAwaitingComboSelection);
        clearAllCombosCommand = new RelayCommand(
            () => { foreach (var c in AvailableCombinations) c.IsSelected = false; },
            () => IsAwaitingComboSelection);
    }

    public ObservableCollection<EtabsPreloadStep> Steps { get; }
    public ObservableCollection<EtabsLoadCombinationViewModel> AvailableCombinations { get; }
    public ListCollectionView FilteredCombinations { get; }

    public int CompletedCount => Steps.Count(s => s.IsDone || s.IsError);
    public string CompletedStepsText => $"[{CompletedCount}/{Steps.Count}]";
    public int SelectedComboCount => AvailableCombinations.Count(c => c.IsSelected);
    public string ComboSelectionCountText => $"[{SelectedComboCount}/{AvailableCombinations.Count}]";

    public EtabsPreloadData? Result { get; private set; }
    public ICommand CancelCommand { get; }
    public ICommand ProceedCommand => proceedCommand;
    public ICommand NextCommand => nextCommand;
    public ICommand SelectAllCombosCommand => selectAllCombosCommand;
    public ICommand ClearAllCombosCommand => clearAllCombosCommand;
    public event EventHandler<bool>? RequestClose;

    public double Progress        { get => progress;       private set => Set(ref progress, value); }
    public string StatusMessage   { get => statusMessage;  private set => Set(ref statusMessage, value); }
    public bool   HasError        { get => hasError;       private set => Set(ref hasError, value); }
    public bool IsComplete
    {
        get => isComplete;
        private set
        {
            Set(ref isComplete, value);
            nextCommand.RaiseCanExecuteChanged();
        }
    }

    public bool IsAwaitingComboSelection
    {
        get => isAwaitingComboSelection;
        private set
        {
            Set(ref isAwaitingComboSelection, value);
            proceedCommand.RaiseCanExecuteChanged();
            selectAllCombosCommand.RaiseCanExecuteChanged();
            clearAllCombosCommand.RaiseCanExecuteChanged();
        }
    }

    public string LoadComboFilterText
    {
        get => loadComboFilterText;
        set
        {
            if (loadComboFilterText == value) return;
            loadComboFilterText = value;
            Raise();
            FilteredCombinations.Refresh();
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
        progressDriftCts?.Cancel();
        comboSelectionTcs?.TrySetResult(false);
        RequestClose?.Invoke(this, false);
    }

    private void OnProceed()
    {
        IsAwaitingComboSelection = false;
        StatusMessage = "Proceeding with import…";
        comboSelectionTcs?.TrySetResult(true);
    }

    private void OnComboSelectionChanged()
    {
        Raise(nameof(SelectedComboCount));
        Raise(nameof(ComboSelectionCountText));
        proceedCommand.RaiseCanExecuteChanged();
    }

    private CancellationTokenSource? progressDriftCts;

    private void StartProgressDrift(double start, double target, double expectedDurationSeconds)
    {
        progressDriftCts?.Cancel();
        progressDriftCts = new CancellationTokenSource();
        var token = progressDriftCts.Token;

        Progress = start;
        var steps = expectedDurationSeconds * 20;
        var stepVal = (target - start) / steps;
        var maxLimit = start + (target - start) * 0.95;

        Task.Run(async () =>
        {
            for (int i = 0; i < steps; i++)
            {
                if (token.IsCancellationRequested) return;
                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                {
                    if (Progress < maxLimit) Progress += stepVal;
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

    private static EtabsDesignForceTable EmptyTable(string key) =>
        new() { TableKey = key, FieldKeys = [], Records = [] };

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

        // ─── Step 3: Load combination names ────────────────────────────────
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

        // ─── PAUSE: let user select combinations ───────────────────────────
        comboSelectionTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        AvailableCombinations.Clear();
        foreach (var name in combos)
            AvailableCombinations.Add(new EtabsLoadCombinationViewModel(name, _ => OnComboSelectionChanged()));

        Raise(nameof(SelectedComboCount));
        Raise(nameof(ComboSelectionCountText));
        IsAwaitingComboSelection = true;
        StatusMessage = $"{combos.Count} combinations available — select then click Proceed.";

        await comboSelectionTcs.Task;
        if (cancelled) return;

        var selectedCombos = AvailableCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList();
        Steps[2].SetDone($"{combos.Count} combinations · {selectedCombos.Count} selected");

        // ─── Steps 3–8: Force import ───────────────────────────────────────
        if (designForceImportService is not null && forceCache is not null)
        {
            try
            {
                bool hasCols = columns.Any(c => c.SectionType != SectionShapeType.Irregular);
                bool hasPiers = pierShellImportService is not null &&
                    await Task.Run(() => pierShellImportService.GetPierGroups(targetUnitSystem).Count > 0, ct);

                // ─── Element forces (parent) ───────────────────────────────
                Steps[3].SetRunning();

                // ─── 4: Element forces — columns ──────────────────────────
                EtabsDesignForceTable colElem;
                if (hasCols)
                {
                    Steps[4].SetRunning($"Loading for {selectedCombos.Count} combo(s)…");
                    StatusMessage = "Loading column element forces…";
                    StartProgressDrift(45, 60, 7.0);
                    colElem = await Task.Run(
                        () => designForceImportService.LoadColumnElementForcesTable(targetUnitSystem, selectedCombos), ct);
                    StopProgressDrift(60);
                    Steps[4].SetDone($"{colElem.Records.Count:N0} rows");
                    Progress = 60;
                }
                else
                {
                    Steps[4].SetDone("N/A");
                    colElem = EmptyTable("Element Forces - Columns");
                }

                if (ct.IsCancellationRequested) return;

                // ─── 5: Element forces — piers ────────────────────────────
                EtabsDesignForceTable pierElem;
                if (hasPiers)
                {
                    Steps[5].SetRunning($"Loading for {selectedCombos.Count} combo(s)…");
                    StatusMessage = "Loading pier element forces…";
                    StartProgressDrift(60, 72, 5.0);
                    pierElem = await Task.Run(
                        () => designForceImportService.LoadPierElementForcesTable(targetUnitSystem, selectedCombos), ct);
                    StopProgressDrift(72);
                    Steps[5].SetDone($"{pierElem.Records.Count:N0} rows");
                    Progress = 72;
                }
                else
                {
                    Steps[5].SetDone("N/A");
                    pierElem = EmptyTable("Pier Forces");
                }

                Steps[3].SetDone();

                if (ct.IsCancellationRequested) return;

                // ─── Design forces (parent) ────────────────────────────────
                Steps[6].SetRunning();

                // ─── 7: Design forces — columns ───────────────────────────
                EtabsDesignForceTable colDesign;
                if (hasCols)
                {
                    Steps[7].SetRunning("Checking design results…");
                    StatusMessage = "Loading column design forces…";
                    StartProgressDrift(72, 86, 7.0);
                    colDesign = await Task.Run(
                        () => designForceImportService.LoadColumnDesignForcesTable(targetUnitSystem, selectedCombos), ct);
                    StopProgressDrift(86);

                    if (colDesign.HasRecords)
                        Steps[7].SetDone($"{colDesign.Records.Count:N0} rows");
                    else
                        Steps[7].SetError("Not yet designed — run concrete design in ETABS first");

                    Progress = 86;
                }
                else
                {
                    Steps[7].SetDone("N/A");
                    colDesign = EmptyTable("Design Forces - Columns");
                }

                if (ct.IsCancellationRequested) return;

                // ─── 8: Design forces — piers ─────────────────────────────
                EtabsDesignForceTable pierDesign;
                if (hasPiers)
                {
                    Steps[8].SetRunning("Checking design results…");
                    StatusMessage = "Loading pier design forces…";
                    StartProgressDrift(86, 97, 5.0);
                    pierDesign = await Task.Run(
                        () => designForceImportService.LoadPierDesignForcesTable(targetUnitSystem, selectedCombos), ct);
                    StopProgressDrift(97);

                    if (pierDesign.HasRecords)
                        Steps[8].SetDone($"{pierDesign.Records.Count:N0} rows");
                    else
                        Steps[8].SetError("Not yet designed — run concrete design in ETABS first");

                    Progress = 97;
                }
                else
                {
                    Steps[8].SetDone("N/A");
                    pierDesign = EmptyTable("Design Forces - Piers");
                }

                Steps[6].SetDone();

                var db = designForceImportService.BuildDatabase(
                    info.ModelPath, info.ModelName,
                    targetUnitSystem,
                    colElem, pierElem, colDesign, pierDesign);

                bool hasDesign = db.ColumnForces.HasRecords || db.PierForces.HasRecords;
                StatusMessage = hasDesign
                    ? "Ready — opening import dialog…"
                    : "Design results not found for selected combinations. Import continues with element forces only.";

                Progress = 100;
                forceCache.Set(db);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                foreach (var s in Steps.Skip(3)) s.SetError($"skipped ({ex.Message})");
            }
        }
        else
        {
            foreach (var s in Steps.Skip(3)) s.SetDone("N/A");
            Progress = 100;
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
            SelectedLoadCombinations = selectedCombos,
        };

        StatusMessage = "All done — click Next to continue.";
        IsComplete = true;
    }
}
