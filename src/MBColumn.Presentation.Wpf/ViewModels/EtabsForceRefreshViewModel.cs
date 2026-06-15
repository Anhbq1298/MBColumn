using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IProjectService projectService;
    private readonly IReadOnlyList<ColumnRecord> allColumns;
    private readonly int? currentColumnId;
    private readonly int? currentFolderId;
    private readonly UnitSystem unitSystem;

    private readonly AsyncRelayCommand connectCommand;
    private readonly RelayCommand cancelCommand;
    private readonly AsyncRelayCommand importCommand;
    private readonly RelayCommand selectAllCombosCommand;
    private readonly RelayCommand clearAllCombosCommand;

    private bool isConnected;
    private string connectionStatusText = "Not connected";
    private string modelName = "-";
    private string modelPath = "-";
    private string presentUnits = "-";
    private string currentSectionName = "-";
    private string metadataId = "-";
    private string modelMismatchWarning = "";
    private bool hasMetadataError;

    // Source mapping
    private string importedFromEtabs = "No";
    private string storyRange = "-";
    private string columnLabel = "-";
    private string etabsObjectIds = "-";

    private string statusMessage = "";
    private bool isBusy;
    private string busyText = "";
    private bool useDesignForces = true;

    // Load source selection
    private bool loadCombinationsSelected = true;
    private bool loadCasesSelected = false;

    // Force extraction selection
    private bool forceExtractionTopBottom = true;
    private bool forceExtractionEnvelope = false;

    // Behavior selection
    private bool behaviorReplace = true;
    private bool behaviorAppend = false;

    private string loadComboFilterText = "";
    private EtabsForceRefreshPreview? preview;
    private EtabsForceRefreshResult? applyResult;

    private List<string> allCombinations = [];
    private List<string> allCases = [];

    public EtabsForceRefreshViewModel(
        IEtabsConnectionService connectionService,
        IEtabsForceRefreshService refreshService,
        IEtabsColumnImportService columnImportService,
        IProjectService projectService,
        IReadOnlyList<ColumnRecord> allColumns,
        int? currentColumnId,
        int? currentFolderId,
        UnitSystem unitSystem)
    {
        this.connectionService = connectionService;
        this.refreshService = refreshService;
        this.columnImportService = columnImportService;
        this.projectService = projectService;
        this.allColumns = allColumns;
        this.currentColumnId = currentColumnId;
        this.currentFolderId = currentFolderId;
        this.unitSystem = unitSystem;

        LoadCombinations = [];
        SectionRows = [];

        // Load metadata and populate panels
        if (currentColumnId.HasValue)
        {
            var currentSnapshot = projectService.LoadColumnInput(currentColumnId.Value);
            if (currentSnapshot != null)
            {
                CurrentSectionName = currentSnapshot.DesignTierName;
                if (string.IsNullOrWhiteSpace(CurrentSectionName))
                {
                    var colRecord = allColumns.FirstOrDefault(c => c.Id == currentColumnId.Value);
                    CurrentSectionName = colRecord?.Name ?? "-";
                }

                var meta = currentSnapshot.EtabsMetadata;
                if (meta != null && meta.IsEtabsImportedSection)
                {
                    ImportedFromEtabs = "Yes";
                    StoryRange = meta.EtabsStoryRangeText;
                    if (string.IsNullOrWhiteSpace(StoryRange)) StoryRange = meta.StoryName;
                    
                    ColumnLabel = string.Join(", ", meta.EtabsSourceLabels ?? []);
                    if (string.IsNullOrWhiteSpace(ColumnLabel)) ColumnLabel = meta.Label;
                    if (string.IsNullOrWhiteSpace(ColumnLabel) && !string.IsNullOrWhiteSpace(meta.PierName)) ColumnLabel = meta.PierName;
                    
                    EtabsObjectIds = string.Join(", ", meta.EtabsSourceFrameIds ?? []);
                    if (string.IsNullOrWhiteSpace(EtabsObjectIds)) EtabsObjectIds = meta.EtabsObjectName;
                    
                    MetadataId = meta.EtabsColumnGroupId;
                }
                else
                {
                    ImportedFromEtabs = "No";
                    StoryRange = "-";
                    ColumnLabel = "-";
                    EtabsObjectIds = "-";
                    MetadataId = "-";

                    HasMetadataError = true;
                    StatusMessage = "This section does not contain ETABS source metadata. Re-import is only available for sections originally imported from ETABS.";
                }
            }
        }

        connectCommand = new AsyncRelayCommand(InitializeAsync, () => !IsBusy && !HasMetadataError);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));
        importCommand = new AsyncRelayCommand(ImportAsync,
            () => IsConnected && LoadCombinations.Any(c => c.IsSelected) && !IsBusy && !HasMetadataError);
        selectAllCombosCommand = new RelayCommand(() => SetAllCombos(true), () => LoadCombinations.Count > 0);
        clearAllCombosCommand = new RelayCommand(() => SetAllCombos(false), () => LoadCombinations.Count > 0);

        ResetPreview();
        _ = InitializeAsync();
    }

    public event EventHandler<bool>? RequestClose;
    public EtabsForceRefreshResult? Result => applyResult;

    public ObservableCollection<EtabsLoadCombinationViewModel> LoadCombinations { get; }
    public ObservableCollection<EtabsForceRefreshSectionRowViewModel> SectionRows { get; }

    public ICommand ConnectCommand => connectCommand;
    public ICommand CancelCommand => cancelCommand;
    public ICommand ImportCommand => importCommand;
    public ICommand SelectAllCombosCommand => selectAllCombosCommand;
    public ICommand ClearAllCombosCommand => clearAllCombosCommand;

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

    public string ConnectionStatusText { get => connectionStatusText; private set => Set(ref connectionStatusText, value); }
    public string ModelName { get => modelName; private set => Set(ref modelName, value); }
    public string ModelPath { get => modelPath; private set => Set(ref modelPath, value); }
    public string PresentUnits { get => presentUnits; private set => Set(ref presentUnits, value); }
    public string CurrentSectionName { get => currentSectionName; private set => Set(ref currentSectionName, value); }
    public string MetadataId { get => metadataId; private set => Set(ref metadataId, value); }
    public string ModelMismatchWarning { get => modelMismatchWarning; private set { Set(ref modelMismatchWarning, value); Raise(nameof(HasModelMismatchWarning)); } }
    public bool HasModelMismatchWarning => !string.IsNullOrEmpty(ModelMismatchWarning);
    public bool HasMetadataError { get => hasMetadataError; private set => Set(ref hasMetadataError, value); }

    public string ImportedFromEtabs { get => importedFromEtabs; private set => Set(ref importedFromEtabs, value); }
    public string StoryRange { get => storyRange; private set => Set(ref storyRange, value); }
    public string ColumnLabel { get => columnLabel; private set => Set(ref columnLabel, value); }
    public string EtabsObjectIds { get => etabsObjectIds; private set => Set(ref etabsObjectIds, value); }

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

    // Load Source Selection Properties
    public bool LoadCombinationsSelected
    {
        get => loadCombinationsSelected;
        set
        {
            if (Set(ref loadCombinationsSelected, value))
            {
                RefreshSelectionList();
                ResetPreview();
            }
        }
    }

    public bool LoadCasesSelected
    {
        get => loadCasesSelected;
        set
        {
            if (Set(ref loadCasesSelected, value))
            {
                RefreshSelectionList();
                ResetPreview();
            }
        }
    }

    // Force Extraction Properties
    public bool ForceExtractionTopBottom
    {
        get => forceExtractionTopBottom;
        set
        {
            if (Set(ref forceExtractionTopBottom, value) && value)
            {
                ForceExtractionEnvelope = false;
                ResetPreview();
            }
        }
    }

    public bool ForceExtractionEnvelope
    {
        get => forceExtractionEnvelope;
        set
        {
            if (Set(ref forceExtractionEnvelope, value) && value)
            {
                ForceExtractionTopBottom = false;
                ResetPreview();
            }
        }
    }

    // Behavior Properties
    public bool BehaviorReplace
    {
        get => behaviorReplace;
        set
        {
            if (Set(ref behaviorReplace, value) && value)
            {
                BehaviorAppend = false;
                ResetPreview();
            }
        }
    }

    public bool BehaviorAppend
    {
        get => behaviorAppend;
        set
        {
            if (Set(ref behaviorAppend, value) && value)
            {
                BehaviorReplace = false;
                ResetPreview();
            }
        }
    }

    public string LoadComboFilterText
    {
        get => loadComboFilterText;
        set { Set(ref loadComboFilterText, value); RefreshSelectionList(); }
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

    public List<EtabsSectionBinding> ExistingBindings
    {
        get
        {
            var scopedColumns = GetScopedColumns();
            var bindings = new List<EtabsSectionBinding>();
            foreach (var col in scopedColumns)
            {
                var snapshot = projectService.LoadColumnInput(col.Id);
                if (snapshot?.EtabsBinding is not null)
                    bindings.Add(snapshot.EtabsBinding);
            }
            return bindings;
        }
    }

    public int SelectedComboCount => LoadCombinations.Count(c => c.IsSelected);
    public string ForceSourceLabel => UseDesignForces ? "Design Forces" : "Element Forces";

    private async Task InitializeAsync()
    {
        if (IsBusy || HasMetadataError) return;

        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            IsBusy = true;
            BusyText = "Connecting to ETABS...";
            ConnectionStatusText = "Connecting...";
            StatusMessage = "Connecting to ETABS, please wait...";
            ResetPreview();
        });

        try
        {
            // Connect in a background thread so we don't freeze the UI
            var result = await Task.Run(() => connectionService.ConnectToRunningEtabs(unitSystem));

            if (result.IsConnected)
            {
                var info = result.ModelInfo!;
                
                // Load combinations and cases in the background while still connected
                var combos = await Task.Run(() => columnImportService.GetLoadCombinations());
                var cases = await Task.Run(() => columnImportService.GetLoadCases());

                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                {
                    ModelName = info.ModelName;
                    ModelPath = info.ModelPath;
                    PresentUnits = info.PresentUnits;
                    IsConnected = true;
                    ConnectionStatusText = "Connected";

                    // Check model mismatch
                    var snapshot = projectService.LoadColumnInput(currentColumnId ?? 0);
                    var expectedModel = snapshot?.EtabsMetadata?.EtabsSourceModelName;
                    if (string.IsNullOrWhiteSpace(expectedModel)) expectedModel = snapshot?.EtabsMetadata?.SourceModelName;

                    if (!string.IsNullOrWhiteSpace(expectedModel) && 
                        !string.Equals(System.IO.Path.GetFileName(info.ModelName), System.IO.Path.GetFileName(expectedModel), StringComparison.OrdinalIgnoreCase))
                    {
                        ModelMismatchWarning = "The connected ETABS model may not match the original source model for this section. Please confirm before importing.";
                    }
                    else
                    {
                        ModelMismatchWarning = "";
                    }

                    allCombinations = combos.ToList();
                    allCases = cases.ToList();
                    RefreshSelectionList();
                    StatusMessage = "";
                });
            }
            else
            {
                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                {
                    ConnectionStatusText = "Not connected";
                    IsConnected = false;
                    StatusMessage = "ETABS is not connected. Please reconnect to the source model before re-importing forces.";
                });
            }
        }
        catch (Exception ex)
        {
            System.Windows.Application.Current?.Dispatcher.Invoke(() =>
            {
                ConnectionStatusText = "Error connecting";
                StatusMessage = $"Error: {ex.Message}";
                IsConnected = false;
            });
        }
        finally
        {
            System.Windows.Application.Current?.Dispatcher.Invoke(() =>
            {
                IsBusy = false;
                BusyText = "";
                RaiseCommands();
            });
        }
    }

    private void RefreshSelectionList()
    {
        var selectedNames = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
        
        LoadCombinations.Clear();

        if (LoadCombinationsSelected)
        {
            foreach (var name in allCombinations)
            {
                if (string.IsNullOrWhiteSpace(LoadComboFilterText) || name.Contains(LoadComboFilterText, StringComparison.OrdinalIgnoreCase))
                {
                    LoadCombinations.Add(new EtabsLoadCombinationViewModel(name, _ => OnComboSelectionChanged(), selectedNames.Contains(name)));
                }
            }
        }

        if (LoadCasesSelected)
        {
            foreach (var name in allCases)
            {
                if (string.IsNullOrWhiteSpace(LoadComboFilterText) || name.Contains(LoadComboFilterText, StringComparison.OrdinalIgnoreCase))
                {
                    LoadCombinations.Add(new EtabsLoadCombinationViewModel(name, _ => OnComboSelectionChanged(), selectedNames.Contains(name)));
                }
            }
        }

        Raise(nameof(SelectedComboCount));
        RaiseCommands();
    }

    private IReadOnlyList<ColumnRecord> GetScopedColumns()
    {
        if (currentColumnId.HasValue)
        {
            return allColumns.Where(c => c.Id == currentColumnId.Value).ToList();
        }
        return [];
    }

    private async Task ImportAsync()
    {
        if (HasMetadataError)
        {
            StatusMessage = "This section does not contain ETABS source metadata. Re-import is only available for sections originally imported from ETABS.";
            return;
        }

        if (!IsConnected)
        {
            StatusMessage = "ETABS is not connected. Please reconnect to the source model before re-importing forces.";
            return;
        }

        var bindings = ExistingBindings;
        if (bindings.Count == 0)
        {
            StatusMessage = "No matching ETABS column object was found from this section metadata. Please check the source mapping.";
            return;
        }

        if (!LoadCombinations.Any(c => c.IsSelected))
        {
            StatusMessage = "Please select at least one load case or load combination.";
            return;
        }

        IsBusy = true;
        BusyText = "Importing forces...";
        StatusMessage = "";

        try
        {
            var request = new EtabsForceRefreshRequest
            {
                Bindings = bindings,
                SelectedLoadCombinations = LoadCombinationsSelected ? LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).Intersect(allCombinations, StringComparer.OrdinalIgnoreCase).ToList() : [],
                SelectedLoadCases = LoadCasesSelected ? LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).Intersect(allCases, StringComparer.OrdinalIgnoreCase).ToList() : [],
                ForceSource = UseDesignForces ? MbColumnForceSourceMode.DesignForces : MbColumnForceSourceMode.ElementForces,
                ImportTop = ForceExtractionTopBottom,
                ImportBottom = ForceExtractionTopBottom,
                ImportEnvelope = ForceExtractionEnvelope,
                AppendAsNewLoads = BehaviorAppend,
                RefreshAllSections = true
            };

            var state = await Task.Run(() => refreshService.CheckResultState(request));

            if (state != EtabsResultState.Ready)
            {
                StatusMessage = BuildResultStateMessage(state);
                IsBusy = false;
                return;
            }

            var builtPreview = await Task.Run(() =>
                refreshService.BuildPreview(request, GetExistingLoadCasesBySection(), unitSystem));

            if (builtPreview.SectionsAffected == 0 || builtPreview.NewLoadRows == 0)
            {
                StatusMessage = "No matching ETABS column object was found from this section metadata. Please check the source mapping.";
                IsBusy = false;
                return;
            }

            applyResult = refreshService.Apply(builtPreview);
            StatusMessage = applyResult.Message;
            RequestClose?.Invoke(this, true);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Import failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
            BusyText = "";
        }
    }

    private IReadOnlyDictionary<string, IReadOnlyList<SnapshotLoadCase>> GetExistingLoadCasesBySection()
    {
        var existingLoadCasesBySection = new Dictionary<string, IReadOnlyList<SnapshotLoadCase>>(StringComparer.OrdinalIgnoreCase);
        var scopedColumns = GetScopedColumns();
        foreach (var col in scopedColumns)
        {
            var snapshot = projectService.LoadColumnInput(col.Id);
            if (snapshot is not null)
            {
                existingLoadCasesBySection[col.Name] = snapshot.LoadCases.Where(IsEtabsLoadCase).ToList();
            }
        }
        return existingLoadCasesBySection;
    }

    private static bool IsEtabsLoadCase(SnapshotLoadCase loadCase)
        => loadCase.IsEtabsImportedLoad
            || string.Equals(loadCase.Source, "ETABS", StringComparison.OrdinalIgnoreCase)
            || loadCase.Id.StartsWith("etabs_", StringComparison.OrdinalIgnoreCase);

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

    private void ResetPreview()
    {
        Preview = null;
        SectionRows.Clear();
    }

    private void RaiseCommands()
    {
        importCommand.RaiseCanExecuteChanged();
        connectCommand.RaiseCanExecuteChanged();
        selectAllCombosCommand.RaiseCanExecuteChanged();
        clearAllCombosCommand.RaiseCanExecuteChanged();
    }
}
