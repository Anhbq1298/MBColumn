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

public sealed class EtabsFallbackCandidateViewModel : ViewModelBase
{
    public EtabsFallbackCandidateViewModel(EtabsColumnObjectKey source)
    {
        Source = source;
    }

    public EtabsColumnObjectKey Source { get; }
    public string UniqueName => Source.UniqueName;
    public string Label => Source.Label;
    public string Story => Source.Story;
    public string Coordinates => $"I/J: ({Source.BottomX:N1}, {Source.BottomY:N1}) / ({Source.TopX:N1}, {Source.TopY:N1})";
    public string SectionProperty => Source.SectionPropertyName;
    public string DisplayText => $"{UniqueName} | {Label} | {Story} | {Coordinates} | {SectionProperty}";
}

internal enum SourceObjectResolutionStatus
{
    Resolved,
    RequiresSelection,
    Failed
}

internal sealed record EtabsStoredObjectRef(string Story, string UniqueName);

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
    private string sourceStory = "-";
    private string columnLabel = "-";
    private string etabsObjectIds = "-";
    private string etabsObjectIdsToolTip = "-";
    private string sourceMappingMessage = "";
    private bool isSourceModelConfirmationRequired;
    private bool isSourceModelConfirmed;
    private bool modelNameOrPathDiffered;
    private bool hasMultipleFallbackCandidates;
    private EtabsFallbackCandidateViewModel? selectedFallbackCandidate;
    private string pendingResolutionObjectKey = "";
    private bool pendingMultipleCandidateResolution;

    private string statusMessage = "";
    private bool isBusy;
    private string busyText = "";
    private bool useDesignForces = false;

    // Load source selection
    private bool loadCombinationsSelected = true;
    private bool loadCasesSelected = false;

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
        FallbackCandidates = [];

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
                    StoryRange = FirstNonEmpty(meta.EtabsStoryRangeText, meta.StoryName);
                    SourceStory = FormatListOrFallback(meta.EtabsSourceStories, meta.StoryName);

                    ColumnLabel = FormatColumnLabel(meta);

                    var objectRefs = ResolveStoredObjectRefs(currentSnapshot);
                    EtabsObjectIds = FormatObjectNamesForDisplay(objectRefs);
                    EtabsObjectIdsToolTip = FormatObjectNamesForToolTip(objectRefs);
                    SourceMappingMessage = BuildSourceMappingMessage(meta, objectRefs);

                    MetadataId = meta.EtabsColumnGroupId;
                }
                else
                {
                    ImportedFromEtabs = "No";
                    StoryRange = "-";
                    SourceStory = "-";
                    ColumnLabel = "-";
                    EtabsObjectIds = "-";
                    EtabsObjectIdsToolTip = "-";
                    SourceMappingMessage = "";
                    MetadataId = "-";

                    HasMetadataError = true;
                    StatusMessage = "This section does not contain ETABS source metadata. Re-import is only available for sections originally imported from ETABS.";
                }
            }
        }

        connectCommand = new AsyncRelayCommand(InitializeAsync, () => !IsBusy && !HasMetadataError);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));
        importCommand = new AsyncRelayCommand(ImportAsync,
            () => IsConnected
                && LoadCombinations.Any(c => c.IsSelected)
                && !IsBusy
                && !HasMetadataError
                && (!IsSourceModelConfirmationRequired || IsSourceModelConfirmed)
                && (!HasMultipleFallbackCandidates || SelectedFallbackCandidate is not null));
        selectAllCombosCommand = new RelayCommand(() => SetAllCombos(true), () => LoadCombinations.Count > 0);
        clearAllCombosCommand = new RelayCommand(() => SetAllCombos(false), () => LoadCombinations.Count > 0);

        ResetPreview();
        _ = InitializeAsync();
    }

    public event EventHandler<bool>? RequestClose;
    public EtabsForceRefreshResult? Result => applyResult;

    public ObservableCollection<EtabsLoadCombinationViewModel> LoadCombinations { get; }
    public ObservableCollection<EtabsForceRefreshSectionRowViewModel> SectionRows { get; }
    public ObservableCollection<EtabsFallbackCandidateViewModel> FallbackCandidates { get; }

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
    public string SourceStory { get => sourceStory; private set => Set(ref sourceStory, value); }
    public string ColumnLabel { get => columnLabel; private set => Set(ref columnLabel, value); }
    public string EtabsObjectIds { get => etabsObjectIds; private set => Set(ref etabsObjectIds, value); }
    public string EtabsObjectIdsToolTip { get => etabsObjectIdsToolTip; private set => Set(ref etabsObjectIdsToolTip, value); }
    public string SourceMappingMessage { get => sourceMappingMessage; private set { Set(ref sourceMappingMessage, value); Raise(nameof(HasSourceMappingMessage)); } }
    public bool HasSourceMappingMessage => !string.IsNullOrWhiteSpace(SourceMappingMessage);
    public bool IsSourceModelConfirmationRequired { get => isSourceModelConfirmationRequired; private set { Set(ref isSourceModelConfirmationRequired, value); RaiseCommands(); } }
    public bool IsSourceModelConfirmed { get => isSourceModelConfirmed; set { if (Set(ref isSourceModelConfirmed, value)) RaiseCommands(); } }
    public bool ModelNameOrPathDiffered { get => modelNameOrPathDiffered; private set => Set(ref modelNameOrPathDiffered, value); }
    public bool HasMultipleFallbackCandidates { get => hasMultipleFallbackCandidates; private set { Set(ref hasMultipleFallbackCandidates, value); RaiseCommands(); } }
    public EtabsFallbackCandidateViewModel? SelectedFallbackCandidate
    {
        get => selectedFallbackCandidate;
        set
        {
            if (Set(ref selectedFallbackCandidate, value))
                RaiseCommands();
        }
    }

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
                if (snapshot is null) continue;

                var binding = BuildBindingFromSnapshot(snapshot, col.Name);
                if (binding is not null)
                    bindings.Add(binding);
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
                    var expectedModelName = FirstNonEmpty(
                        snapshot?.EtabsMetadata?.EtabsSourceModelName,
                        snapshot?.EtabsMetadata?.SourceModelName);
                    var expectedModelPath = FirstNonEmpty(snapshot?.EtabsMetadata?.SourceModelPath);

                    if (IsConnectedModelDifferent(info.ModelName, info.ModelPath, expectedModelName, expectedModelPath))
                    {
                        ModelMismatchWarning = "The connected ETABS model name/path is different from the original source stored in this MB Column Section metadata. Please confirm that the currently connected ETABS model is the intended source before re-importing forces.";
                        ModelNameOrPathDiffered = true;
                        IsSourceModelConfirmationRequired = true;
                    }
                    else
                    {
                        ModelMismatchWarning = "";
                        ModelNameOrPathDiffered = false;
                        IsSourceModelConfirmationRequired = false;
                        IsSourceModelConfirmed = false;
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
            StatusMessage = "No matching ETABS column object was found. The app checked stored Unique Name first, then fallback search by XY coordinate and story range.";
            return;
        }

        if (!LoadCombinations.Any(c => c.IsSelected))
        {
            StatusMessage = "Please select at least one load case or load combination.";
            return;
        }

        if (IsSourceModelConfirmationRequired && !IsSourceModelConfirmed)
        {
            StatusMessage = "Please confirm this is the intended ETABS source model for this section before importing.";
            return;
        }

        IsBusy = true;
        BusyText = "Importing forces...";
        StatusMessage = "";

        try
        {
            var extractionMode = ResolveExtractionModeFromCurrentSection();

            var request = new EtabsForceRefreshRequest
            {
                Bindings = bindings,
                SelectedLoadCombinations = LoadCombinationsSelected ? LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).Intersect(allCombinations, StringComparer.OrdinalIgnoreCase).ToList() : [],
                SelectedLoadCases = LoadCasesSelected ? LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).Intersect(allCases, StringComparer.OrdinalIgnoreCase).ToList() : [],
                ForceSource = UseDesignForces ? MbColumnForceSourceMode.DesignForces : MbColumnForceSourceMode.ElementForces,
                ExtractionMode = extractionMode,
                ImportTop = extractionMode == EtabsForceExtractionMode.TopBottom,
                ImportBottom = extractionMode == EtabsForceExtractionMode.TopBottom,
                ImportEnvelope = extractionMode == EtabsForceExtractionMode.Envelope,
                AppendAsNewLoads = BehaviorAppend,
                RefreshAllSections = false,
                TargetMode = EtabsForceRefreshTargetMode.CurrentSectionOnly,
                TargetSectionId = currentColumnId,
                TargetMetadataId = MetadataId,
                SelectedSectionNames = [CurrentSectionName],
                AllowSourceModelMismatch = IsSourceModelConfirmationRequired,
                SourceModelMismatchConfirmed = IsSourceModelConfirmed
            };

            var mappingValidation = await Task.Run(() =>
                refreshService.ValidateEtabsSourceObjectMapping(request, unitSystem));

            var resolution = ResolveSourceObjects(request, mappingValidation);
            if (resolution == SourceObjectResolutionStatus.RequiresSelection)
            {
                StatusMessage = "Multiple ETABS objects match the stored XY location and story range. Please select the intended source object.";
                IsBusy = false;
                return;
            }

            if (resolution == SourceObjectResolutionStatus.Failed || !IsMappingValidationPassed(mappingValidation))
            {
                StatusMessage = BuildMappingValidationMessage(mappingValidation);
                IsBusy = false;
                return;
            }

            request.ResolvedEtabsObjectUniqueNames = request.Bindings
                .SelectMany(binding => binding.ColumnObjects)
                .Select(column => column.UniqueName)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

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
                StatusMessage = "No matching ETABS column object was found. The app checked stored Unique Name first, then fallback search by XY coordinate and story range.";
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

    private SourceObjectResolutionStatus ResolveSourceObjects(
        EtabsForceRefreshRequest request,
        EtabsBindingValidationResult validation)
    {
        if (pendingMultipleCandidateResolution && SelectedFallbackCandidate is not null)
        {
            ReplaceColumnObject(request.Bindings, pendingResolutionObjectKey, SelectedFallbackCandidate.Source);
            request.SourceResolutionMethod = "Manual selection from multiple matches";
            MarkHealthResolved(validation, pendingResolutionObjectKey);
            ClearFallbackCandidates();
            return SourceObjectResolutionStatus.Resolved;
        }

        var unresolved = validation.ObjectHealthList
            .Where(health => health.Status != EtabsBindingHealthStatus.Ok)
            .ToList();

        if (unresolved.Count == 0)
        {
            request.SourceResolutionMethod = "Stored Unique Name";
            ClearFallbackCandidates();
            return SourceObjectResolutionStatus.Resolved;
        }

        var multiple = unresolved.FirstOrDefault(health =>
            health.Status == EtabsBindingHealthStatus.MultipleRemapCandidates
            && health.RemapCandidateObjects.Count > 1);
        if (multiple is not null)
        {
            FallbackCandidates.Clear();
            foreach (var candidate in multiple.RemapCandidateObjects)
                FallbackCandidates.Add(new EtabsFallbackCandidateViewModel(candidate));

            pendingResolutionObjectKey = multiple.ObjectKey;
            pendingMultipleCandidateResolution = true;
            SelectedFallbackCandidate = null;
            HasMultipleFallbackCandidates = true;
            return SourceObjectResolutionStatus.RequiresSelection;
        }

        var singleFallbacks = unresolved
            .Where(health => health.Status == EtabsBindingHealthStatus.PossibleRemap
                && health.RemapCandidateObjects.Count == 1)
            .ToList();

        if (singleFallbacks.Count == unresolved.Count)
        {
            foreach (var health in singleFallbacks)
            {
                ReplaceColumnObject(request.Bindings, health.ObjectKey, health.RemapCandidateObjects[0]);
                health.Status = EtabsBindingHealthStatus.Ok;
            }

            request.SourceResolutionMethod = "Fallback XY + story range";
            ClearFallbackCandidates();
            return SourceObjectResolutionStatus.Resolved;
        }

        return SourceObjectResolutionStatus.Failed;
    }

    private void ClearFallbackCandidates()
    {
        FallbackCandidates.Clear();
        SelectedFallbackCandidate = null;
        HasMultipleFallbackCandidates = false;
        pendingResolutionObjectKey = "";
        pendingMultipleCandidateResolution = false;
    }

    private static void MarkHealthResolved(EtabsBindingValidationResult validation, string objectKey)
    {
        var health = validation.ObjectHealthList.FirstOrDefault(item =>
            string.Equals(item.ObjectKey, objectKey, StringComparison.OrdinalIgnoreCase));
        if (health is not null)
            health.Status = EtabsBindingHealthStatus.Ok;
    }

    private static void ReplaceColumnObject(
        IReadOnlyList<EtabsSectionBinding> bindings,
        string objectKey,
        EtabsColumnObjectKey replacement)
    {
        foreach (var binding in bindings.Where(binding => binding.ObjectType == EtabsImportedObjectType.Column))
        {
            for (var i = 0; i < binding.ColumnObjects.Count; i++)
            {
                if (string.Equals(binding.ColumnObjects[i].Key, objectKey, StringComparison.OrdinalIgnoreCase))
                {
                    binding.ColumnObjects[i] = replacement;
                    return;
                }
            }
        }
    }

    private static EtabsSectionBinding? BuildBindingFromSnapshot(ColumnInputSnapshot snapshot, string sectionName)
    {
        var binding = snapshot.EtabsBinding;
        var meta = snapshot.EtabsMetadata;

        if (binding is not null)
        {
            if (string.IsNullOrWhiteSpace(binding.MbColumnSectionName))
                binding.MbColumnSectionName = sectionName;
            if (binding.SourceModel is null)
                binding.SourceModel = BuildSourceModel(meta);

            if (binding.ObjectType == EtabsImportedObjectType.Column && binding.ColumnObjects.Count == 0)
            {
                var metadataObjects = BuildColumnObjectsFromMetadata(meta);
                if (metadataObjects.Count > 0)
                    binding.ColumnObjects = metadataObjects;
            }

            return binding;
        }

        if (meta?.IsEtabsImportedSection != true)
            return null;

        var columnObjects = BuildColumnObjectsFromMetadata(meta);
        if (columnObjects.Count == 0)
            return null;

        return new EtabsSectionBinding
        {
            MbColumnSectionId = FirstNonEmpty(meta.EtabsTierId, sectionName),
            MbColumnSectionName = sectionName,
            ObjectType = EtabsImportedObjectType.Column,
            ForceSource = MbColumnForceSourceMode.DesignForces,
            ColumnObjects = columnObjects,
            LoadCombinations = meta.SelectedLoadCombinations
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList(),
            Locations = ["Top", "Bottom"],
            SourceModel = BuildSourceModel(meta)
        };
    }

    private static List<EtabsColumnObjectKey> BuildColumnObjectsFromMetadata(EtabsImportMetadataDto? meta)
    {
        if (meta is null)
            return [];

        var objectNames = ResolveMetadataObjectNames(meta);
        var stories = ResolveMetadataStories(meta);
        var labels = ResolveMetadataLabels(meta);
        var hasCountOnlyObjectMetadata = IsCountOnlyObjectMetadata(meta, objectNames);
        if (hasCountOnlyObjectMetadata)
            objectNames = [];

        if (objectNames.Count == 0
            && stories.Count == 0
            && labels.Count == 0
            && meta.EtabsGroupX == 0
            && meta.EtabsGroupY == 0)
        {
            return [];
        }

        var count = Math.Max(1, objectNames.Count);
        var objects = new List<EtabsColumnObjectKey>(count);
        for (var i = 0; i < count; i++)
        {
            objects.Add(new EtabsColumnObjectKey
            {
                UniqueName = objectNames.ElementAtOrDefault(i) ?? "",
                Story = stories.ElementAtOrDefault(i) ?? stories.FirstOrDefault() ?? meta.StoryName,
                Label = labels.ElementAtOrDefault(i) ?? labels.FirstOrDefault() ?? FirstNonEmpty(meta.Label, meta.PierName),
                X = meta.EtabsGroupX,
                Y = meta.EtabsGroupY,
                SectionPropertyName = FirstNonEmpty(meta.EtabsSectionPropertyName, meta.EtabsSectionName)
            });
        }

        return objects;
    }

    private static EtabsModelFingerprint BuildSourceModel(EtabsImportMetadataDto? meta)
        => new()
        {
            ModelFilePath = FirstNonEmpty(meta?.SourceModelPath),
            ModelFileName = FirstNonEmpty(meta?.EtabsSourceModelName, meta?.SourceModelName),
            ImportedAt = meta?.EtabsImportedAt == default
                ? meta?.ImportedAt ?? DateTime.MinValue
                : meta?.EtabsImportedAt ?? DateTime.MinValue
        };

    private static List<string> ResolveMetadataObjectNames(EtabsImportMetadataDto meta)
    {
        var values = new List<string>();
        if (meta.EtabsSourceFrameIds is { Count: > 0 })
            values.AddRange(meta.EtabsSourceFrameIds);
        if (!string.IsNullOrWhiteSpace(meta.EtabsObjectName))
            values.Add(meta.EtabsObjectName);

        return values
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(value => value.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static bool IsCountOnlyObjectMetadata(EtabsImportMetadataDto meta, IReadOnlyList<string> objectNames)
        => objectNames.Count == 1
            && int.TryParse(objectNames[0], out _)
            && string.IsNullOrWhiteSpace(meta.EtabsObjectName);

    private static List<string> ResolveMetadataStories(EtabsImportMetadataDto meta)
    {
        var values = new List<string>();
        if (meta.EtabsSourceStories is { Count: > 0 })
            values.AddRange(meta.EtabsSourceStories);
        if (!string.IsNullOrWhiteSpace(meta.StoryName))
            values.Add(meta.StoryName);

        return values
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(value => value.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static List<string> ResolveMetadataLabels(EtabsImportMetadataDto meta)
    {
        var values = new List<string>();
        if (meta.EtabsSourceLabels is { Count: > 0 })
            values.AddRange(meta.EtabsSourceLabels);
        if (!string.IsNullOrWhiteSpace(meta.Label))
            values.Add(meta.Label);
        if (!string.IsNullOrWhiteSpace(meta.PierName))
            values.Add(meta.PierName);

        return values
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(value => value.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private EtabsForceExtractionMode ResolveExtractionModeFromCurrentSection()
    {
        var snapshot = currentColumnId.HasValue
            ? projectService.LoadColumnInput(currentColumnId.Value)
            : null;

        return ResolveExtractionModeFromOriginalImport(snapshot);
    }

    private static EtabsForceExtractionMode ResolveExtractionModeFromOriginalImport(ColumnInputSnapshot? snapshot)
    {
        var tier = snapshot?.EtabsTierMetadata;
        if (tier is not null && tier.ImportTop && tier.ImportBottom)
            return EtabsForceExtractionMode.TopBottom;

        return ExistingImportEtabsDefaultExtractionMode();
    }

    private static EtabsForceExtractionMode ExistingImportEtabsDefaultExtractionMode()
        => EtabsForceExtractionMode.TopBottom;

    private static IReadOnlyList<EtabsStoredObjectRef> ResolveStoredObjectRefs(ColumnInputSnapshot snapshot)
    {
        var values = new List<EtabsStoredObjectRef>();

        if (snapshot.EtabsMetadata?.EtabsSourceFrameIds is { Count: > 0 })
        {
            var stories = snapshot.EtabsMetadata.EtabsSourceStories ?? [];
            for (var i = 0; i < snapshot.EtabsMetadata.EtabsSourceFrameIds.Count; i++)
            {
                var name = snapshot.EtabsMetadata.EtabsSourceFrameIds[i];
                var story = i < stories.Count ? stories[i] : snapshot.EtabsMetadata.StoryName;
                values.Add(new EtabsStoredObjectRef(story, name));
            }
        }

        if (!string.IsNullOrWhiteSpace(snapshot.EtabsMetadata?.EtabsObjectName))
            values.Add(new EtabsStoredObjectRef(snapshot.EtabsMetadata.StoryName, snapshot.EtabsMetadata.EtabsObjectName));

        if (snapshot.EtabsBinding?.ColumnObjects is { Count: > 0 })
            values.AddRange(snapshot.EtabsBinding.ColumnObjects.Select(c => new EtabsStoredObjectRef(c.Story, c.UniqueName)));

        if (snapshot.EtabsTierMetadata?.SourceObjects is { Count: > 0 })
            values.AddRange(snapshot.EtabsTierMetadata.SourceObjects.Select(source => new EtabsStoredObjectRef(source.Story, source.ObjectName)));

        return values
            .Where(value => !string.IsNullOrWhiteSpace(value.UniqueName))
            .Select(value => new EtabsStoredObjectRef(value.Story?.Trim() ?? "", value.UniqueName.Trim()))
            .Where(value => !IsCountOnlyObjectName(value.UniqueName))
            .GroupBy(value => $"{value.Story}|{value.UniqueName}", StringComparer.OrdinalIgnoreCase)
            .Select(group => group.First())
            .ToList();
    }

    private static string FormatObjectNamesForDisplay(IReadOnlyList<EtabsStoredObjectRef> objectRefs)
    {
        if (objectRefs.Count == 0)
            return "Not stored";

        const int maxVisible = 5;
        var visible = objectRefs.Take(maxVisible).ToList();
        var suffix = objectRefs.Count > maxVisible ? $" +{objectRefs.Count - maxVisible} more" : "";

        var grouped = visible
            .GroupBy(item => string.IsNullOrWhiteSpace(item.Story) ? "Story not stored" : item.Story, StringComparer.OrdinalIgnoreCase)
            .Select(group => $"{group.Key}: {string.Join(", ", group.Select(item => item.UniqueName))}");

        return string.Join("; ", grouped) + suffix;
    }

    private static string FormatObjectNamesForToolTip(IReadOnlyList<EtabsStoredObjectRef> objectRefs)
    {
        if (objectRefs.Count == 0)
            return "Not stored";

        var grouped = objectRefs
            .GroupBy(item => string.IsNullOrWhiteSpace(item.Story) ? "Story not stored" : item.Story, StringComparer.OrdinalIgnoreCase)
            .Select(group => $"{group.Key}: {string.Join(", ", group.Select(item => item.UniqueName))}");

        return string.Join(Environment.NewLine, grouped);
    }

    private static string FormatColumnLabel(EtabsImportMetadataDto meta)
    {
        var value = FormatListOrFallback(meta.EtabsSourceLabels, FirstNonEmpty(meta.Label, meta.PierName));
        return string.IsNullOrWhiteSpace(value) || value == "-"
            ? "Not stored"
            : value;
    }

    private static string FormatListOrFallback(IEnumerable<string>? values, string? fallback)
    {
        var joined = string.Join(", ", (values ?? [])
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(value => value.Trim())
            .Distinct(StringComparer.OrdinalIgnoreCase));
        return string.IsNullOrWhiteSpace(joined) ? FirstNonEmpty(fallback, "-") : joined;
    }

    private static string FirstNonEmpty(params string?[] values)
        => values.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value))?.Trim() ?? "";

    private static bool IsConnectedModelDifferent(
        string connectedModelName,
        string connectedModelPath,
        string expectedModelName,
        string expectedModelPath)
    {
        var hasExpectedName = !string.IsNullOrWhiteSpace(expectedModelName);
        var hasExpectedPath = !string.IsNullOrWhiteSpace(expectedModelPath);
        if (!hasExpectedName && !hasExpectedPath)
            return false;

        if (hasExpectedName
            && !string.Equals(
                System.IO.Path.GetFileName(connectedModelName),
                System.IO.Path.GetFileName(expectedModelName),
                StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return hasExpectedPath
            && !string.IsNullOrWhiteSpace(connectedModelPath)
            && !string.Equals(
                System.IO.Path.GetFullPath(connectedModelPath),
                System.IO.Path.GetFullPath(expectedModelPath),
                StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsCountOnlyObjectName(string value)
        => int.TryParse(value, out _);

    private static string BuildSourceMappingMessage(EtabsImportMetadataDto meta, IReadOnlyList<EtabsStoredObjectRef> objectRefs)
    {
        var hasLabels = (meta.EtabsSourceLabels?.Any(label => !string.IsNullOrWhiteSpace(label)) == true)
            || !string.IsNullOrWhiteSpace(meta.Label)
            || !string.IsNullOrWhiteSpace(meta.PierName);

        if (objectRefs.Count == 0)
            return "ETABS object unique names are missing from this section metadata. The app will try to resolve the source object using story, XY location, and label.";

        if (!hasLabels)
            return "Column/Pier label is not stored. Re-import will use stored ETABS object unique names.";

        return "";
    }

    private static bool IsMappingValidationPassed(EtabsBindingValidationResult validation)
        => !validation.ModelChanged
            && validation.ObjectHealthList.Count > 0
            && validation.ObjectHealthList.All(h => h.Status == EtabsBindingHealthStatus.Ok);

    private static string BuildMappingValidationMessage(EtabsBindingValidationResult validation)
    {
        var firstIssue = validation.ObjectHealthList.FirstOrDefault(h => h.Status != EtabsBindingHealthStatus.Ok);
        if (validation.ModelChanged)
            return "The connected ETABS model name/path is different from the original source stored in this MB Column Section metadata. Please confirm that the currently connected ETABS model is the intended source before re-importing forces.";
        if (firstIssue?.Status == EtabsBindingHealthStatus.MultipleRemapCandidates)
            return "Multiple ETABS objects match the stored XY location and story range. Please select the intended source object.";
        if (firstIssue?.Status == EtabsBindingHealthStatus.StoryMismatch)
            return "The ETABS object was found, but its story does not match the section metadata. Please check the source mapping before importing.";
        if (firstIssue?.Status == EtabsBindingHealthStatus.XyMismatch)
            return "The ETABS object was found, but its XY location does not match the section metadata within tolerance. Please check the source mapping before importing.";
        if (!string.IsNullOrWhiteSpace(firstIssue?.Message))
            return firstIssue.Message!;

        return "No matching ETABS column object was found. The app checked stored Unique Name first, then fallback search by XY coordinate and story range.";
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
