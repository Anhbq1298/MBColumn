using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsForceRefreshSectionRowViewModel : ViewModelBase
{
    public string SectionName { get; set; } = "";
    public string StatusText { get; set; } = "";
    public int OldRows { get; set; }
    public int NewRows { get; set; }
    public int ChangedRows { get; set; }
    public int AddedRows { get; set; }
    public int RemovedRows { get; set; }
    public int MissingObjects { get; set; }
    public string ActionText { get; set; } = "";
    public string SeverityColor { get; set; } = "Green";

    public bool IsExpanded { get; set; }
    public List<EtabsForceRowChange> RowChanges { get; set; } = [];
}

public sealed class EtabsForceRefreshViewModel : ViewModelBase
{
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsForceRefreshService refreshService;
    private readonly IProjectService projectService;
    private readonly UnitSystem unitSystem;

    private readonly RelayCommand connectCommand;
    private readonly RelayCommand cancelCommand;
    private readonly AsyncRelayCommand buildPreviewCommand;
    private readonly RelayCommand applyCommand;
    private readonly RelayCommand selectAllCombosCommand;
    private readonly RelayCommand clearAllCombosCommand;

    private int currentStep = 1;
    private bool isConnected;
    private string connectionStatus = "Not connected";
    private string modelName = "-";
    private string modelPath = "-";
    private string statusMessage = "";
    private bool isBusy;
    private string busyText = "";
    private bool useDesignForces = true;
    private bool importTop = true;
    private bool importBottom = true;
    private bool refreshAllSections = true;
    private string loadComboFilterText = "";
    private EtabsForceRefreshPreview? preview;
    private EtabsForceRefreshResult? applyResult;

    public EtabsForceRefreshViewModel(
        IEtabsConnectionService connectionService,
        IEtabsForceRefreshService refreshService,
        IProjectService projectService,
        IReadOnlyList<EtabsSectionBinding> existingBindings,
        IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> existingLoadCasesBySection,
        UnitSystem unitSystem)
    {
        this.connectionService = connectionService;
        this.refreshService = refreshService;
        this.projectService = projectService;
        this.unitSystem = unitSystem;

        ExistingBindings = existingBindings.ToList();
        ExistingLoadCasesBySection = existingLoadCasesBySection;

        LoadCombinations = [];
        SectionRows = [];

        connectCommand = new RelayCommand(Connect, () => !IsConnected);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));
        buildPreviewCommand = new AsyncRelayCommand(BuildPreviewAsync,
            () => IsConnected && LoadCombinations.Any(c => c.IsSelected) && !IsBusy);
        applyCommand = new RelayCommand(Apply,
            () => Preview is not null && !IsBusy);
        selectAllCombosCommand = new RelayCommand(() => SetAllCombos(true), () => LoadCombinations.Count > 0);
        clearAllCombosCommand = new RelayCommand(() => SetAllCombos(false), () => LoadCombinations.Count > 0);
    }

    public event EventHandler<bool>? RequestClose;
    public EtabsForceRefreshResult? Result => applyResult;

    public List<EtabsSectionBinding> ExistingBindings { get; }
    public IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> ExistingLoadCasesBySection { get; }
    public ObservableCollection<EtabsLoadCombinationViewModel> LoadCombinations { get; }
    public ObservableCollection<EtabsForceRefreshSectionRowViewModel> SectionRows { get; }

    public ICommand ConnectCommand => connectCommand;
    public ICommand CancelCommand => cancelCommand;
    public ICommand BuildPreviewCommand => buildPreviewCommand;
    public ICommand ApplyCommand => applyCommand;
    public ICommand SelectAllCombosCommand => selectAllCombosCommand;
    public ICommand ClearAllCombosCommand => clearAllCombosCommand;

    public int CurrentStep
    {
        get => currentStep;
        private set
        {
            if (currentStep == value) return;
            currentStep = value;
            Raise();
            Raise(nameof(IsStep1));
            Raise(nameof(IsStep2));
            Raise(nameof(IsStep3));
        }
    }
    public bool IsStep1 => currentStep == 1;
    public bool IsStep2 => currentStep == 2;
    public bool IsStep3 => currentStep == 3;

    public bool IsConnected
    {
        get => isConnected;
        private set
        {
            if (isConnected == value) return;
            isConnected = value;
            Raise();
            RaiseCommands();
        }
    }

    public string ConnectionStatus { get => connectionStatus; private set => Set(ref connectionStatus, value); }
    public string ModelName { get => modelName; private set => Set(ref modelName, value); }
    public string ModelPath { get => modelPath; private set => Set(ref modelPath, value); }
    public string StatusMessage { get => statusMessage; set => Set(ref statusMessage, value); }
    public bool IsBusy { get => isBusy; private set { Set(ref isBusy, value); RaiseCommands(); } }
    public string BusyText { get => busyText; private set => Set(ref busyText, value); }

    public bool UseDesignForces
    {
        get => useDesignForces;
        set
        {
            if (useDesignForces == value) return;
            useDesignForces = value;
            Raise();
            Raise(nameof(UseElementForces));
            ResetPreview();
        }
    }

    public bool UseElementForces
    {
        get => !useDesignForces;
        set { if (value) UseDesignForces = false; }
    }

    public bool ImportTop
    {
        get => importTop;
        set { Set(ref importTop, value); ResetPreview(); }
    }

    public bool ImportBottom
    {
        get => importBottom;
        set { Set(ref importBottom, value); ResetPreview(); }
    }

    public bool RefreshAllSections
    {
        get => refreshAllSections;
        set { Set(ref refreshAllSections, value); Raise(nameof(RefreshSelectedSectionsOnly)); ResetPreview(); }
    }

    public bool RefreshSelectedSectionsOnly
    {
        get => !refreshAllSections;
        set { if (value) RefreshAllSections = false; }
    }

    public string LoadComboFilterText
    {
        get => loadComboFilterText;
        set { Set(ref loadComboFilterText, value); RefreshFilteredCombos(); }
    }

    public EtabsForceRefreshPreview? Preview
    {
        get => preview;
        private set
        {
            Set(ref preview, value);
            Raise(nameof(HasPreview));
            Raise(nameof(PreviewSectionsAffected));
            Raise(nameof(PreviewCombosSelected));
            Raise(nameof(PreviewExistingRows));
            Raise(nameof(PreviewNewRows));
            Raise(nameof(PreviewChangedRows));
            Raise(nameof(PreviewAddedRows));
            Raise(nameof(PreviewRemovedRows));
            Raise(nameof(PreviewHasWarnings));
            RaiseCommands();
        }
    }

    public bool HasPreview => preview is not null;
    public int PreviewSectionsAffected => preview?.SectionsAffected ?? 0;
    public int PreviewCombosSelected => preview?.LoadCombinationsSelected ?? 0;
    public int PreviewExistingRows => preview?.ExistingLoadRows ?? 0;
    public int PreviewNewRows => preview?.NewLoadRows ?? 0;
    public int PreviewChangedRows => preview?.ChangedRows ?? 0;
    public int PreviewAddedRows => preview?.AddedRows ?? 0;
    public int PreviewRemovedRows => preview?.RemovedRows ?? 0;
    public bool PreviewHasWarnings => preview?.HasWarnings ?? false;

    public int LinkedSectionCount => ExistingBindings.Count;
    public int SelectedComboCount => LoadCombinations.Count(c => c.IsSelected);
    public string ForceSourceLabel => UseDesignForces ? "Design Forces" : "Element Forces";

    private void Connect()
    {
        ConnectionStatus = "Connecting...";
        var result = connectionService.ConnectToRunningEtabs();

        if (!result.IsConnected)
        {
            ConnectionStatus = result.Message;
            IsConnected = false;
            return;
        }

        var info = result.ModelInfo!;
        ModelName = info.ModelName;
        ModelPath = info.ModelPath;
        IsConnected = true;
        ConnectionStatus = result.Message;

        LoadCombinations.Clear();
        try
        {
            // Load combination names only — no force rows yet
            // We get combos from model info or a separate call
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Connected but could not load combinations: {ex.Message}";
        }

        StatusMessage = $"Connected to {info.ModelName}. Select load combinations and click 'Preview Refresh'.";
        CurrentStep = 2;
    }

    public void SetAvailableCombinations(IReadOnlyList<string> combos)
    {
        LoadCombinations.Clear();
        foreach (var name in combos)
            LoadCombinations.Add(new EtabsLoadCombinationViewModel(name, _ => OnComboSelectionChanged()));

        // Pre-select combos that were used in the last import
        var lastCombos = ExistingBindings
            .SelectMany(b => b.LoadCombinations)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var combo in LoadCombinations)
        {
            if (lastCombos.Contains(combo.Name))
                combo.IsSelected = true;
        }

        RaiseCommands();
        Raise(nameof(SelectedComboCount));
    }

    private async Task BuildPreviewAsync()
    {
        if (ExistingBindings.Count == 0)
        {
            StatusMessage = "No ETABS-linked sections found. Import from ETABS first.";
            return;
        }

        if (!LoadCombinations.Any(c => c.IsSelected))
        {
            StatusMessage = "Select at least one load combination.";
            return;
        }

        IsBusy = true;
        BusyText = "Checking ETABS results...";
        StatusMessage = "";

        try
        {
            var request = BuildRefreshRequest();

            // Check result state
            var state = await Task.Run(() => refreshService.CheckResultState(request));

            if (state != EtabsResultState.Ready)
            {
                StatusMessage = BuildResultStateMessage(state);
                IsBusy = false;
                return;
            }

            BusyText = "Pulling selected forces...";

            var builtPreview = await Task.Run(() =>
                refreshService.BuildPreview(request, ExistingLoadCasesBySection, unitSystem));

            Preview = builtPreview;
            SectionRows.Clear();
            foreach (var section in builtPreview.SectionSummaries)
                SectionRows.Add(MapSectionSummary(section));

            CurrentStep = 3;
            StatusMessage = builtPreview.HasWarnings
                ? $"Preview ready with warnings. {builtPreview.RemapRequired} section(s) need remap."
                : "Preview ready. Review changes and click Apply.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Preview failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
            BusyText = "";
        }
    }

    private void Apply()
    {
        if (Preview is null) return;

        IsBusy = true;
        BusyText = "Applying forces...";

        try
        {
            applyResult = refreshService.Apply(Preview);
            StatusMessage = applyResult.Message;
            RequestClose?.Invoke(this, true);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Apply failed: {ex.Message}";
            applyResult = null;
        }
        finally
        {
            IsBusy = false;
            BusyText = "";
        }
    }

    private EtabsForceRefreshRequest BuildRefreshRequest()
    {
        return new EtabsForceRefreshRequest
        {
            Bindings = ExistingBindings,
            SelectedLoadCombinations = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList(),
            ForceSource = UseDesignForces ? MbColumnForceSourceMode.DesignForces : MbColumnForceSourceMode.ElementForces,
            ImportTop = ImportTop,
            ImportBottom = ImportBottom,
            RefreshAllSections = RefreshAllSections
        };
    }

    private static EtabsForceRefreshSectionRowViewModel MapSectionSummary(EtabsSectionRefreshSummary s)
    {
        var color = s.Status switch
        {
            EtabsBindingHealthStatus.Ok => "Green",
            EtabsBindingHealthStatus.PossibleRemap or EtabsBindingHealthStatus.MultipleRemapCandidates => "Orange",
            EtabsBindingHealthStatus.MissingObject or EtabsBindingHealthStatus.ModelChanged => "Red",
            _ => "Gray"
        };

        return new EtabsForceRefreshSectionRowViewModel
        {
            SectionName = s.SectionName,
            StatusText = s.Status.ToString(),
            OldRows = s.OldRowCount,
            NewRows = s.NewRowCount,
            ChangedRows = s.ChangedRows,
            AddedRows = s.AddedRows,
            RemovedRows = s.RemovedRows,
            MissingObjects = s.MissingObjects,
            ActionText = s.RecommendedAction switch
            {
                EtabsSectionRefreshAction.Update => "Update",
                EtabsSectionRefreshAction.KeepOld => "Keep old",
                EtabsSectionRefreshAction.NeedsRemap => "Review",
                EtabsSectionRefreshAction.Skip => "Skip",
                _ => "-"
            },
            SeverityColor = color,
            RowChanges = s.RowChanges
        };
    }

    private static string BuildResultStateMessage(EtabsResultState state)
        => state switch
        {
            EtabsResultState.AnalysisRequired =>
                "ETABS analysis results are not available or may be outdated for the selected combinations.\nRun analysis in ETABS, then retry.",
            EtabsResultState.DesignRequired =>
                "ETABS design results are not available for the selected combinations.\nRun design in ETABS, then retry.",
            EtabsResultState.AnalysisAndDesignRequired =>
                "ETABS analysis and design results are not available.\nRun analysis and design in ETABS, then retry.",
            _ => ""
        };

    private void SetAllCombos(bool selected)
    {
        foreach (var c in LoadCombinations)
            c.IsSelected = selected;
        Raise(nameof(SelectedComboCount));
        RaiseCommands();
    }

    private void OnComboSelectionChanged()
    {
        Raise(nameof(SelectedComboCount));
        RaiseCommands();
        ResetPreview();
    }

    private void RefreshFilteredCombos()
    {
        // In a real implementation this would update a filtered collection view
    }

    private void ResetPreview()
    {
        Preview = null;
        SectionRows.Clear();
        if (currentStep == 3)
            CurrentStep = 2;
    }

    private void RaiseCommands()
    {
        buildPreviewCommand.RaiseCanExecuteChanged();
        applyCommand.RaiseCanExecuteChanged();
        connectCommand.RaiseCanExecuteChanged();
        selectAllCombosCommand.RaiseCanExecuteChanged();
        clearAllCombosCommand.RaiseCanExecuteChanged();
    }
}
