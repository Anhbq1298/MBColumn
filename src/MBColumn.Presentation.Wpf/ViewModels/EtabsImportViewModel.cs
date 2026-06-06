using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Application.Services.Etabs;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Units;
using MBColumn.Presentation.Wpf.Collections;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsImportViewModel : ViewModelBase
{
    private const string AllTypes = "All";
    private const string TypeRectangular = "Rectangular";
    private const string TypeCircular = "Circular";
    private const string TypeIrregularPier = "Irregular / Pier";
    private const string EtabsElementFrame = "Frame";
    private const string EtabsElementShell = "Shell";
    private const string AllStories = "All Stories";
    private const string AllLabels = "All Labels";
    private const string DefaultEtabsBarSize = "T25";
    private const double DefaultEtabsBarDiameterMm = 25.0;
    private const double DefaultEtabsBarAreaMm2 = 491.0;
    private const double DefaultEtabsCoverMm = 50.0;
    private const double DefaultEtabsSpacingMm = 150.0;

    private readonly HashSet<string> existingSectionNames;
    private readonly IEtabsConnectionService connectionService;
    private readonly IEtabsColumnImportService columnImportService;
    private readonly IEtabsForceImportService forceImportService;
    private readonly IEtabsForceCacheService? forceCacheService;
    private readonly IEtabsPierShellImportService? pierShellImportService;
    private readonly IIrregularPierGeometryBuilder? irregularGeometryBuilder;
    private readonly IEtabsDesignForceImportService? designForceImportService;
    private readonly IImportedEtabsForceCache? importedForceCache;
    private readonly IEtabsForceCacheResolver? forceCacheResolver;
    private readonly IEtabsSectionForceFilterService? sectionForceFilter;
    private readonly IEtabsForceTableService? forceTableService;
    private readonly IEtabsColumnIdentityService? columnIdentityService;
    private readonly UnitSystem targetUnitSystem;
    private const int PierBoundaryCacheLimit = 500;
    private readonly Dictionary<string, (IReadOnlyList<Point2D> Outer, IReadOnlyList<IReadOnlyList<Point2D>> Openings)>
        pierBoundaryCache = new(StringComparer.OrdinalIgnoreCase);
    private bool pierGroupsLoaded;
    private readonly Dictionary<string, int> storyOrderMap = new(StringComparer.OrdinalIgnoreCase);
    private readonly RelayCommand connectCommand;
    private readonly RelayCommand disconnectCommand;
    private readonly RelayCommand cancelCommand;
    private readonly RelayCommand selectAllCombosCommand;
    private readonly RelayCommand clearAllCombosCommand;
    private readonly RelayCommand addTargetGroupCommand;
    private readonly RelayCommand applyImportCommand;
    private readonly RelayCommand createMbColumnSectionCommand;
    private readonly RelayCommand<MbColumnSectionViewModel> assignToSectionCommand;
    private readonly RelayCommand<MbColumnSectionViewModel> deleteMbColumnSectionCommand;
    private readonly AsyncRelayCommand buildForceCacheCommand;
    private readonly AsyncRelayCommand loadForcesCommand;
    private readonly RelayCommand goToFlow1Command;
    private readonly RelayCommand goToFlow2Command;
    private readonly RelayCommand goToFlow3Command;
    private readonly RelayCommand goBackCommand;
    private readonly RelayCommand reconnectCommand;
    private readonly RelayCommand reloadStoryDefinitionsCommand;
    private readonly RelayCommand reloadColumnConnectivityCommand;
    private readonly RelayCommand toggleModelInfoPanelCommand;

    private int currentFlow = 1;
    private bool isConnected;
    private MbColumnSectionViewModel? selectedMbColumnSection;
    private IReadOnlyList<Point2D> rawBoundaryPoints = [];
    private string forceCacheStatus = "Not built";
    private string connectionStatus = "Not connected";
    private string modelName = "-";
    private string modelPath = "-";
    private string presentUnits = "-";
    private int storyCount;
    private int pierCount;
    private int frameObjectCount;
    private string unitConversionMessage = "Connect to ETABS to read model units.";
    private string selectedEtabsElementFilter = EtabsElementFrame;
    private string selectedSectionTypeFilter = AllTypes;
    private string selectedStoryFilter = AllStories;
    private string selectedLabelFilter = AllLabels;
    private string loadCombinationFilterText = "";
    private string selectedForceType = "Design Forces";
    private bool isLoadingForces;
    private ProjectGroupOptionViewModel? selectedTargetGroup;
    private EtabsUniqueSectionOptionViewModel? selectedUniqueSection;
    private string tierName = "";
    private string lastGeneratedTierName = "";
    private string labelTextFilter = "";
    private EtabsColumnImportRowViewModel? selectedColumn;
    private EtabsSectionMappingViewModel? selectedMapping;
    private EtabsDuplicateHandlingOption selectedDuplicateHandling;
    private PointCollection? boundaryPreviewPointCollection;
    private double previewCanvasWidth = 200;
    private double previewCanvasHeight = 200;
    private string previewStatusText = "Select a row to preview boundary.";
    private DesignCodeType selectedImportDesignCode = DesignCodeType.Ec2;
    private MaterialGradeOption? selectedImportRebarGrade;
    private UnitSystem selectedImportUnitSystem = UnitSystem.Metric;
    private bool importIncludeSlenderness;
    private bool isModelInfoPanelOpen;

    private static readonly IReadOnlyList<MaterialGradeOption> AciRebarGrades =
    [
        new("Grade 40 / 280 MPa",  280.0,  40.0, 200000.0, 29000.0),
        new("Grade 60 / 420 MPa",  420.0,  60.0, 200000.0, 29000.0),
        new("Grade 75 / 520 MPa",  520.0,  75.0, 200000.0, 29000.0),
        new("Grade 80 / 550 MPa",  550.0,  80.0, 200000.0, 29000.0),
        new("Grade 100 / 690 MPa", 690.0, 100.0, 200000.0, 29000.0),
    ];

    private static readonly IReadOnlyList<MaterialGradeOption> Ec2RebarGrades =
    [
        new("B400",  400.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500A", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500B", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500C", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B550",  550.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
    ];

    public EtabsImportViewModel(
        IReadOnlyCollection<string> existingSectionNames,
        IReadOnlyList<GroupRecord> targetGroups,
        int? defaultTargetGroupId,
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsForceImportService forceImportService,
        IEtabsForceCacheService? forceCacheService = null,
        IEtabsPierShellImportService? pierShellImportService = null,
        IIrregularPierGeometryBuilder? irregularGeometryBuilder = null,
        IEtabsDesignForceImportService? designForceImportService = null,
        IImportedEtabsForceCache? importedForceCache = null,
        UnitSystem targetUnitSystem = UnitSystem.Metric,
        IEtabsForceCacheResolver? forceCacheResolver = null,
        IEtabsSectionForceFilterService? sectionForceFilter = null,
        IEtabsForceTableService? forceTableService = null,
        IEtabsColumnIdentityService? columnIdentityService = null)
    {
        this.existingSectionNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.forceImportService = forceImportService;
        this.forceCacheService = forceCacheService;
        this.pierShellImportService = pierShellImportService;
        this.irregularGeometryBuilder = irregularGeometryBuilder;
        this.designForceImportService = designForceImportService;
        this.importedForceCache = importedForceCache;
        this.targetUnitSystem = targetUnitSystem;
        selectedImportUnitSystem = targetUnitSystem;
        selectedImportRebarGrade = Ec2RebarGrades[2]; // B500B default
        this.forceCacheResolver = forceCacheResolver;
        this.sectionForceFilter = sectionForceFilter;
        this.forceTableService = forceTableService;
        this.columnIdentityService = columnIdentityService;

        Columns = new BulkObservableCollection<EtabsColumnImportRowViewModel>();
        FilteredColumns = new ListCollectionView(Columns);
        FilteredColumns.Filter = FilterColumn;
        TierObjectCandidatesView = new ListCollectionView(Columns);
        TierObjectCandidatesView.Filter = FilterTierObjectCandidate;

        SectionMappings = [];
        TargetGroups = [];
        foreach (var group in targetGroups)
        {
            TargetGroups.Add(new ProjectGroupOptionViewModel(group.Id, group.Name));
        }

        if (TargetGroups.Count == 0)
        {
            TargetGroups.Add(new ProjectGroupOptionViewModel(null, "ETABS Import", true));
        }

        selectedTargetGroup = TargetGroups.FirstOrDefault(g => g.GroupId == defaultTargetGroupId)
            ?? TargetGroups.FirstOrDefault();

        UniqueSectionOptions = [];
        StoryOptions = [];
        LoadCombinations = new BulkObservableCollection<EtabsLoadCombinationViewModel>();
        FilteredLoadCombinations = new ListCollectionView(LoadCombinations);
        FilteredLoadCombinations.Filter = FilterLoadCombination;
        ForceRows = new BulkObservableCollection<EtabsForceImportRowViewModel>();
        
        FilteredColumnMappedForceRows = new ListCollectionView(MbColumnMappedForceRows) { Filter = item => ((MbColumnMappedForceRowViewModel)item).ObjectType == "Column" };
        FilteredPierMappedForceRows = new ListCollectionView(MbColumnMappedForceRows) { Filter = item => ((MbColumnMappedForceRowViewModel)item).ObjectType == "Pier" };

        SummaryRows = [];
        MbColumnSections = [];

        EtabsElementFilters = [EtabsElementFrame, EtabsElementShell];
        SectionTypeFilters = [AllTypes, TypeRectangular, TypeCircular];
        StoryFilters = [AllStories];
        LabelFilters = [AllLabels];
        ForceTypeOptions = ["Design Forces", "Element Forces"];

        DuplicateHandlingOptions =
        [
            new(EtabsDuplicateHandlingMode.CreateCopy, "Create copy"),
            new(EtabsDuplicateHandlingMode.SkipExisting, "Skip existing"),
            new(EtabsDuplicateHandlingMode.UpdateExisting, "Update existing")
        ];
        selectedDuplicateHandling = DuplicateHandlingOptions[0];

        connectCommand = new RelayCommand(Connect, () => !IsConnected);
        disconnectCommand = new RelayCommand(Disconnect, () => IsConnected);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));
        selectAllCombosCommand = new RelayCommand(() => SetAllLoadCombinations(true), () => LoadCombinations.Count > 0);
        clearAllCombosCommand = new RelayCommand(() => SetAllLoadCombinations(false), () => LoadCombinations.Count > 0);
        addTargetGroupCommand = new RelayCommand(AddTargetGroup);
        applyImportCommand = new RelayCommand(ApplyImport, () => MbColumnSections.Any(g => g.Items.Count > 0));
        createMbColumnSectionCommand = new RelayCommand(CreateNewMbColumnSection);
        assignToSectionCommand = new RelayCommand<MbColumnSectionViewModel>(AssignSelectedItemsToSection);
        deleteMbColumnSectionCommand = new RelayCommand<MbColumnSectionViewModel>(DeleteMbColumnSection);
        buildForceCacheCommand = new AsyncRelayCommand(BuildForceCacheAsync,
            () => IsConnected && forceCacheService is not null && LoadCombinations.Count > 0);
        loadForcesCommand = new AsyncRelayCommand(GenerateForcesAsync,
            () => IsConnected && !IsLoadingForces && LoadCombinations.Any(c => c.IsSelected));
        goToFlow1Command = new RelayCommand(() => SetFlow(1));
        goToFlow2Command = new RelayCommand(GoToFlow2, () => IsConnected);
        goToFlow3Command = new RelayCommand(GoToFlow3);
        goBackCommand = new RelayCommand(() => SetFlow(currentFlow - 1), () => currentFlow > 1);
        reconnectCommand = new RelayCommand(Reconnect);
        reloadStoryDefinitionsCommand = new RelayCommand(ReloadStoryDefinitions, () => IsConnected);
        reloadColumnConnectivityCommand = new RelayCommand(ReloadColumnConnectivity, () => IsConnected);
        toggleModelInfoPanelCommand = new RelayCommand(() => IsModelInfoPanelOpen = !IsModelInfoPanelOpen);
    }

    public event EventHandler<bool>? RequestClose;

    /// <summary>Set by the View to prompt the user for a group name. Returns null if cancelled.</summary>
    public Func<string, string?>? RequestGroupName { get; set; }

    public EtabsImportDialogResult? ImportResult { get; private set; }
    public BulkObservableCollection<EtabsColumnImportRowViewModel> Columns { get; }
    public ICollectionView FilteredColumns { get; }
    public ICollectionView TierObjectCandidatesView { get; }
    public ObservableCollection<EtabsSectionMappingViewModel> SectionMappings { get; }
    public ObservableCollection<ProjectGroupOptionViewModel> TargetGroups { get; }
    public ObservableCollection<EtabsUniqueSectionOptionViewModel> UniqueSectionOptions { get; }
    public ObservableCollection<EtabsStoryOptionViewModel> StoryOptions { get; }
    public BulkObservableCollection<EtabsLoadCombinationViewModel> LoadCombinations { get; }
    public ICollectionView FilteredLoadCombinations { get; }
    public BulkObservableCollection<EtabsForceImportRowViewModel> ForceRows { get; }
    public BulkObservableCollection<MbColumnMappedForceRowViewModel> MbColumnMappedForceRows { get; }
        = new BulkObservableCollection<MbColumnMappedForceRowViewModel>();
    public ICollectionView FilteredColumnMappedForceRows { get; }
    public ICollectionView FilteredPierMappedForceRows { get; }
    public ObservableCollection<MbColumnSectionSummaryViewModel> MbColumnSectionSummaryRows { get; }
        = [];
    public ObservableCollection<EtabsImportSummaryRowViewModel> SummaryRows { get; }
    public ObservableCollection<EtabsColumnImportRowViewModel> AllAssignedItems { get; } = [];
    public ObservableCollection<MbColumnSectionViewModel> MbColumnSections { get; }
    public IReadOnlyList<string> EtabsElementFilters { get; }
    public ObservableCollection<string> SectionTypeFilters { get; }
    public ObservableCollection<string> StoryFilters { get; }
    public ObservableCollection<string> LabelFilters { get; }
    public IReadOnlyList<EtabsDuplicateHandlingOption> DuplicateHandlingOptions { get; }

    public ICommand ConnectCommand => connectCommand;
    public ICommand DisconnectCommand => disconnectCommand;
    public ICommand ReconnectCommand => reconnectCommand;
    public ICommand ReloadStoryDefinitionsCommand => reloadStoryDefinitionsCommand;
    public ICommand ReloadColumnConnectivityCommand => reloadColumnConnectivityCommand;
    public ICommand ToggleModelInfoPanelCommand => toggleModelInfoPanelCommand;

    public bool IsModelInfoPanelOpen
    {
        get => isModelInfoPanelOpen;
        private set => Set(ref isModelInfoPanelOpen, value);
    }
    public ICommand CancelCommand => cancelCommand;
    public ICommand SelectAllCombosCommand => selectAllCombosCommand;
    public ICommand ClearAllCombosCommand => clearAllCombosCommand;
    public ICommand AddTargetGroupCommand => addTargetGroupCommand;
    public ICommand ApplyImportCommand => applyImportCommand;
    public ICommand CreateMbColumnSectionCommand => createMbColumnSectionCommand;
    public ICommand AssignToSectionCommand => assignToSectionCommand;
    public ICommand DeleteMbColumnSectionCommand => deleteMbColumnSectionCommand;
    public ICommand BuildForceCacheCommand => buildForceCacheCommand;
    public ICommand LoadForcesCommand => loadForcesCommand;
    public ICommand GoToFlow1Command => goToFlow1Command;
    public ICommand GoToFlow2Command => goToFlow2Command;
    public ICommand GoToFlow3Command => goToFlow3Command;
    public ICommand GoBackCommand => goBackCommand;
    public bool IsForceCacheAvailable => forceCacheService is not null;
    public IReadOnlyList<string> ForceTypeOptions { get; }

    public string SelectedForceType
    {
        get => selectedForceType;
        set
        {
            if (selectedForceType == value) return;
            selectedForceType = value;
            Raise();
            Raise(nameof(UseDesignForces));
            Raise(nameof(UseElementForces));
            ForceRows.Clear();
            if (IsConnected && LoadCombinations.Any(c => c.IsSelected))
                GenerateForceRows();
            else
                ForceCacheStatus = "Select load cases then click Load Forces.";
        }
    }

    public bool UseDesignForces
    {
        get => selectedForceType == "Design Forces";
        set { if (value) SelectedForceType = "Design Forces"; }
    }

    public bool UseElementForces
    {
        get => selectedForceType == "Element Forces";
        set { if (value) SelectedForceType = "Element Forces"; }
    }

    public string DesignForcesStatusText
    {
        get
        {
            if (importedForceCache is null) return "Not available";
            if (!importedForceCache.HasValidCache(ModelPath)) return "Not imported";
            var db = importedForceCache.Current;
            return db?.ColumnForces.HasRecords == true || db?.PierForces.HasRecords == true
                ? "Imported"
                : "Not imported";
        }
    }

    public bool IsDesignForcesImported
        => importedForceCache?.HasValidCache(ModelPath) == true;

    public string ElementForcesStatusText
        => IsConnected ? "Available (live)" : "Not connected";

    public bool IsElementForcesAvailable => IsConnected;

    public int CurrentFlow
    {
        get => currentFlow;
        private set
        {
            if (currentFlow == value) return;
            currentFlow = value;
            Raise();
            Raise(nameof(IsFlow1));
            Raise(nameof(IsFlow2));
            Raise(nameof(IsFlow3));
            goBackCommand.RaiseCanExecuteChanged();
        }
    }
    public bool IsFlow1 => currentFlow == 1;
    public bool IsFlow2 => currentFlow == 2;
    public bool IsFlow3 => currentFlow == 3;

    // SectionPreviewCanvas bindings
    public IReadOnlyList<PreviewBoundaryPoint> BoundaryPreviewPoints
        => rawBoundaryPoints.Select((p, i) => new PreviewBoundaryPoint(i + 1, p.X, p.Y)).ToList();
    public SectionShapeType BoundaryPreviewSectionShape
        => SelectedColumn?.SectionType ?? SectionShapeType.Rectangular;
    public double BoundaryPreviewWidth
        => SelectedColumn is null ? 0 : SelectedColumn.IsCircular ? SelectedColumn.Diameter : SelectedColumn.Width;
    public double BoundaryPreviewHeight
        => SelectedColumn is null ? 0 : SelectedColumn.IsCircular ? SelectedColumn.Diameter : SelectedColumn.Height;
    public double BoundaryPreviewCover
        => SectionMappings.FirstOrDefault(m =>
            string.Equals(m.UniqueSection, SelectedColumn?.UniqueSection, StringComparison.OrdinalIgnoreCase))?.Cover
           ?? (targetUnitSystem == UnitSystem.Metric ? 50.0 : 2.0);
    public string BoundaryPreviewSectionLabel
        => SelectedColumn is null ? "" : $"{SelectedColumn.EtabsSectionName}  ·  {SelectedColumn.SectionTypeDisplay}";

    public UnitSystem TargetUnitSystem => targetUnitSystem;
    private UnitProfile TargetUnitProfile => UnitProfile.For(targetUnitSystem);
    private string TargetGeometryUnitSummary => $"{TargetUnitProfile.ForceLabel}, {TargetUnitProfile.SectionSizeLabel}";
    private string TargetForceMomentUnitSummary => $"{TargetUnitProfile.ForceLabel}, {TargetUnitProfile.MomentLabel}";

    // Design settings selected in Step 3 (Review & Import)
    public IReadOnlyList<DesignCodeOption> ImportDesignCodes { get; } =
    [
        new(DesignCodeType.Aci318Style, "ACI 318"),
        new(DesignCodeType.Ec2,         "Eurocode 2"),
    ];

    public IReadOnlyList<UnitSystemOption> ImportUnitSystems { get; } =
    [
        new(UnitSystem.Metric,   "Metric (kN, m)"),
        new(UnitSystem.Imperial, "Imperial (kip, ft)"),
    ];

    public DesignCodeType SelectedImportDesignCode
    {
        get => selectedImportDesignCode;
        set
        {
            if (selectedImportDesignCode == value) return;
            selectedImportDesignCode = value;
            Raise();
            Raise(nameof(AvailableImportRebarGrades));
            Raise(nameof(IsImportDesignCodeEc2));
            SelectedImportRebarGrade = AvailableImportRebarGrades.FirstOrDefault();
        }
    }

    public bool IsImportDesignCodeEc2 => selectedImportDesignCode == DesignCodeType.Ec2;

    public UnitSystem SelectedImportUnitSystem
    {
        get => selectedImportUnitSystem;
        set => Set(ref selectedImportUnitSystem, value);
    }

    public IReadOnlyList<MaterialGradeOption> AvailableImportRebarGrades
        => selectedImportDesignCode == DesignCodeType.Ec2 ? Ec2RebarGrades : AciRebarGrades;

    public MaterialGradeOption? SelectedImportRebarGrade
    {
        get => selectedImportRebarGrade;
        set => Set(ref selectedImportRebarGrade, value);
    }

    public bool ImportIncludeSlenderness
    {
        get => importIncludeSlenderness;
        set => Set(ref importIncludeSlenderness, value);
    }

    public bool IsBoundaryPreviewValid
        => SelectedColumn is not null
           && (SelectedColumn.IsIrregular
               ? rawBoundaryPoints.Count >= 3
               : SelectedColumn.IsCircular ? SelectedColumn.Diameter > 0 : SelectedColumn.Width > 0 && SelectedColumn.Height > 0);

    public MbColumnSectionViewModel? SelectedMbColumnSection
    {
        get => selectedMbColumnSection;
        set => Set(ref selectedMbColumnSection, value);
    }

    public bool IsLoadingForces
    {
        get => isLoadingForces;
        private set => Set(ref isLoadingForces, value);
    }

    public string ForceCacheStatus
    {
        get => forceCacheStatus;
        private set => Set(ref forceCacheStatus, value);
    }

    private int unassignedCount;
    public int UnassignedCount
    {
        get => unassignedCount;
        private set => Set(ref unassignedCount, value);
    }

    private int assignedCount;
    public int AssignedCount
    {
        get => assignedCount;
        private set => Set(ref assignedCount, value);
    }

    private int mbColumnSectionsReadyCount;
    public int MbColumnSectionsReadyCount
    {
        get => mbColumnSectionsReadyCount;
        private set => Set(ref mbColumnSectionsReadyCount, value);
    }

    private bool canApplyImport;
    public bool CanApplyImport
    {
        get => canApplyImport;
        private set => Set(ref canApplyImport, value);
    }

    private string flow1ValidationMessage = "";
    public string Flow1ValidationMessage
    {
        get => flow1ValidationMessage;
        private set => Set(ref flow1ValidationMessage, value);
    }
    public bool HasFlow1Warning => !string.IsNullOrEmpty(flow1ValidationMessage);

    private string flow2ValidationMessage = "";
    public string Flow2ValidationMessage
    {
        get => flow2ValidationMessage;
        private set => Set(ref flow2ValidationMessage, value);
    }
    public bool HasFlow2Warning => !string.IsNullOrEmpty(flow2ValidationMessage);

    private string assignmentConflictText = "";
    public string AssignmentConflictText
    {
        get => assignmentConflictText;
        private set => Set(ref assignmentConflictText, value);
    }
    public bool HasAssignmentConflict => !string.IsNullOrEmpty(assignmentConflictText);

    public bool IsConnected
    {
        get => isConnected;
        private set
        {
            if (isConnected == value) return;
            isConnected = value;
            Raise();
            RaiseCommandStates();
            Raise(nameof(ElementForcesStatusText));
            Raise(nameof(IsElementForcesAvailable));
        }
    }

    public string ConnectionStatus { get => connectionStatus; private set => Set(ref connectionStatus, value); }
    public string ModelName { get => modelName; private set => Set(ref modelName, value); }
    public string ModelPath { get => modelPath; private set => Set(ref modelPath, value); }
    public string PresentUnits { get => presentUnits; private set => Set(ref presentUnits, value); }
    public int StoryCount { get => storyCount; private set => Set(ref storyCount, value); }
    public int PierCount { get => pierCount; private set => Set(ref pierCount, value); }
    public int FrameObjectCount { get => frameObjectCount; private set => Set(ref frameObjectCount, value); }
    public string UnitConversionMessage { get => unitConversionMessage; private set => Set(ref unitConversionMessage, value); }

    // ETABS Element → Section Type → Story → Label cascade
    public string SelectedEtabsElementFilter
    {
        get => selectedEtabsElementFilter;
        set
        {
            if (selectedEtabsElementFilter == value) return;
            selectedEtabsElementFilter = value;
            Raise();
            Raise(nameof(IsSectionTypeFilterEnabled));
            RefreshSectionTypeFilters();

            if (value == EtabsElementShell && !pierGroupsLoaded && isConnected && pierShellImportService is not null)
            {
                LoadPierGroupsAsync();
                return; // LoadPierGroupsAsync calls RebuildStoryFilters when done
            }

            RebuildStoryFilters();
            RebuildUniqueSectionOptions();
            RebuildStoryOptions();
        }
    }

    public bool IsSectionTypeFilterEnabled => selectedEtabsElementFilter == EtabsElementFrame;

    public string SelectedSectionTypeFilter
    {
        get => selectedSectionTypeFilter;
        set
        {
            if (selectedSectionTypeFilter == value) return;
            selectedSectionTypeFilter = value;
            Raise();
            RebuildStoryFilters();
            RebuildUniqueSectionOptions();
            RebuildStoryOptions();
        }
    }

    public string SelectedStoryFilter
    {
        get => selectedStoryFilter;
        set
        {
            if (selectedStoryFilter == value) return;
            selectedStoryFilter = value;
            Raise();
            RebuildLabelFilters();
        }
    }

    public string SelectedLabelFilter
    {
        get => selectedLabelFilter;
        set
        {
            if (selectedLabelFilter == value) return;
            selectedLabelFilter = value;
            Raise();
            FilteredColumns.Refresh();
            RaiseImportSummary();
        }
    }

    public string LoadCombinationFilterText
    {
        get => loadCombinationFilterText;
        set
        {
            if (loadCombinationFilterText == value) return;
            loadCombinationFilterText = value;
            Raise();
            FilteredLoadCombinations.Refresh();
        }
    }

    public ProjectGroupOptionViewModel? SelectedTargetGroup
    {
        get => selectedTargetGroup;
        set
        {
            if (selectedTargetGroup == value) return;
            selectedTargetGroup = value;
            Raise();
            RaiseCommandStates();
        }
    }

    public EtabsUniqueSectionOptionViewModel? SelectedUniqueSection
    {
        get => selectedUniqueSection;
        set
        {
            if (selectedUniqueSection == value) return;
            selectedUniqueSection = value;
            Raise();
            ApplyTierObjectFilter();
            UpdateDefaultTierName();
            UpdateBoundaryPreviewFromUniqueSection();
            RaiseTierProperties();
            RaiseCommandStates();
        }
    }

    public string TierName
    {
        get => tierName;
        set
        {
            if (tierName == value) return;
            tierName = value;
            Raise();
            RaiseCommandStates();
        }
    }

    public string StoryFrom
        => StoryOptions.Where(s => s.IsSelected).OrderBy(s => s.SortIndex).FirstOrDefault()?.StoryName
           ?? StoryOptions.OrderBy(s => s.SortIndex).FirstOrDefault()?.StoryName ?? "";

    public string StoryTo
        => StoryOptions.Where(s => s.IsSelected).OrderBy(s => s.SortIndex).LastOrDefault()?.StoryName
           ?? StoryOptions.OrderBy(s => s.SortIndex).LastOrDefault()?.StoryName ?? "";

    public string LabelTextFilter
    {
        get => labelTextFilter;
        set
        {
            if (labelTextFilter == value) return;
            labelTextFilter = value;
            Raise();
            ApplyTierObjectFilter();
            UpdateDefaultTierName();
            RaiseTierProperties();
            RaiseCommandStates();
        }
    }

    public EtabsColumnImportRowViewModel? SelectedColumn
    {
        get => selectedColumn;
        set
        {
            if (selectedColumn == value) return;
            selectedColumn = value;
            Raise();
            RaiseColumnPreviewProperties();
            UpdateBoundaryPreview();
        }
    }

    public EtabsSectionMappingViewModel? SelectedMapping
    {
        get => selectedMapping;
        set
        {
            if (selectedMapping == value) return;
            selectedMapping = value;
            Raise();
        }
    }

    public EtabsDuplicateHandlingOption SelectedDuplicateHandling
    {
        get => selectedDuplicateHandling;
        set
        {
            if (selectedDuplicateHandling == value) return;
            selectedDuplicateHandling = value;
            Raise();
        }
    }

    // Boundary preview properties
    public PointCollection? BoundaryPreviewPointCollection
    {
        get => boundaryPreviewPointCollection;
        private set => Set(ref boundaryPreviewPointCollection, value);
    }
    public double PreviewCanvasWidth { get => previewCanvasWidth; private set => Set(ref previewCanvasWidth, value); }
    public double PreviewCanvasHeight { get => previewCanvasHeight; private set => Set(ref previewCanvasHeight, value); }
    public string PreviewStatusText { get => previewStatusText; private set => Set(ref previewStatusText, value); }
    public bool HasBoundaryPreview => BoundaryPreviewPointCollection is { Count: >= 3 };

    private int selectedColumnCount;
    public int SelectedColumnCount
    {
        get => selectedColumnCount;
        private set => Set(ref selectedColumnCount, value);
    }

    private int matchedTierObjectCount;
    public int MatchedTierObjectCount
    {
        get => matchedTierObjectCount;
        private set => Set(ref matchedTierObjectCount, value);
    }

    private int selectedLoadCombinationCount;
    public int SelectedLoadCombinationCount
    {
        get => selectedLoadCombinationCount;
        private set => Set(ref selectedLoadCombinationCount, value);
    }

    private int selectedForceRowCount;
    public int SelectedForceRowCount
    {
        get => selectedForceRowCount;
        private set => Set(ref selectedForceRowCount, value);
    }

    private int summaryCreateCount;
    public int SummaryCreateCount
    {
        get => summaryCreateCount;
        private set => Set(ref summaryCreateCount, value);
    }

    private int tierDemandCaseCount;
    public int TierDemandCaseCount
    {
        get => tierDemandCaseCount;
        private set => Set(ref tierDemandCaseCount, value);
    }
    public string PreviewTargetGroupName => SelectedTargetGroup?.GroupName ?? "";
    public string PreviewUniqueSectionName => SelectedUniqueSection?.SectionName ?? "";
    public string ColumnPreviewTitle => SelectedColumn is null
        ? "No column highlighted"
        : $"{SelectedColumn.Pier} / {SelectedColumn.Story} / {SelectedColumn.Label}";
    public bool IsColumnPreviewRectangular => SelectedColumn?.IsRectangular == true;
    public bool IsColumnPreviewCircular => SelectedColumn?.IsCircular == true;
    public string ColumnPreviewDimensions => SelectedColumn is null
        ? "-"
        : SelectedColumn.IsCircular
            ? $"D = {SelectedColumn.Diameter:0.#} {TargetUnitProfile.SectionSizeLabel}"
            : SelectedColumn.IsIrregular
                ? "Pier shell (boundary computed from ETABS area objects)"
                : $"b = {SelectedColumn.Width:0.#} {TargetUnitProfile.SectionSizeLabel}, h = {SelectedColumn.Height:0.#} {TargetUnitProfile.SectionSizeLabel}";
    public string ColumnPreviewRebar => SelectedColumn is null
        ? "-"
        : SelectedColumn.IsCircular ? "Mock preview: equal angular bars" : "Mock preview: perimeter bars";
    public string ForceConventionNote => "Forces are imported using ETABS local axis convention and converted to MBColumn units. Please verify sign convention before design.";

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
        PresentUnits = info.PresentUnits;
        StoryCount = info.StoryCount;
        PierCount = info.PierCount;
        FrameObjectCount = info.FrameObjectCount;
        UnitConversionMessage = $"ETABS data will be converted from {info.PresentUnits} to {TargetGeometryUnitSummary}.";

        Columns.Clear();
        pierBoundaryCache.Clear();

        // Load frame columns (rectangular + circular)
        try
        {
            using (FilteredColumns.DeferRefresh())
            using (TierObjectCandidatesView.DeferRefresh())
            {
                Columns.AddRange(columnImportService.GetCandidateColumns(targetUnitSystem)
                    .Select(dto => new EtabsColumnImportRowViewModel(
                        OnColumnSelectionChanged,
                        dto.ObjectName,
                        dto.PierName,
                        dto.StoryName,
                        dto.Label,
                        dto.UniqueSectionDisplayName,
                        dto.EtabsSectionName,
                        dto.MaterialName,
                        dto.SectionType,
                        dto.Width,
                        dto.Height,
                        dto.Diameter,
                        dto.LengthMm,
                        dto.LinkedSection,
                        dto.Status,
                        targetUnitSystem)));
            }
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Connected but failed to load frame columns: {ex.Message}";
        }

        // Pier groups are loaded lazily when the user selects "Irregular / Pier" type filter
        // to avoid blocking the UI thread with a full area-object scan on connect.
        pierGroupsLoaded = false;

        IsConnected = true;
        ConnectionStatus = result.Message;

        storyOrderMap.Clear();
        var storyElevations = columnImportService.GetStoryElevations();
        for (int i = 0; i < storyElevations.Count; i++)
            storyOrderMap[storyElevations[i].Name] = i;

        ResetColumnFilters();
        RebuildUniqueSectionOptions();
        RebuildStoryOptions();
        SelectedColumn = Columns.FirstOrDefault();
        Raise(nameof(SelectedColumnCount));
        RaiseTierProperties();
        RaiseCommandStates();

        // Kick off hidden background preload of raw design force tables so that
        // BuildForceCacheAsync can parse from memory instead of calling COM again.
        PreloadDesignForcesInBackground(info.ModelPath, info.ModelName);
    }

    private void PreloadDesignForcesInBackground(string modelFilePath, string modelName)
    {
        if (designForceImportService is null || importedForceCache is null) return;

        // Skip preload if same model already cached, but still write CSV for inspection
        if (importedForceCache.HasValidCache(modelFilePath))
        {
            _ = Task.Run(() => ExportColumnForceCsv(importedForceCache.Current!));
            return;
        }

        _ = Task.Run(() =>
        {
            try
            {
                var db = designForceImportService.ImportDesignForces(modelFilePath, modelName, targetUnitSystem);
                importedForceCache.Set(db);

                ExportColumnForceCsv(db);

                System.Windows.Application.Current?.Dispatcher.Invoke(() =>
                {
                    Raise(nameof(DesignForcesStatusText));
                    Raise(nameof(IsDesignForcesImported));
                });
            }
            catch
            {
                // Silent — preload failure must never break the main import workflow
            }
        });
    }

    private void LoadPierGroupsAsync()
    {
        pierGroupsLoaded = true; // set early to prevent re-entry
        ConnectionStatus = "Loading pier groups…";

        _ = Task.Run(() =>
        {
            try
            {
                var groups = pierShellImportService!.GetPierGroups(targetUnitSystem);
                var storyNames = pierShellImportService.GetStoryNames();
                var storyIndexMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < storyNames.Count; i++)
                {
                    storyIndexMap[storyNames[i]] = i;
                }

                // Group the pier groups by PierLabel
                var pierToGroups = groups
                    .GroupBy(g => g.PierLabel, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

                var newRows = new List<EtabsColumnImportRowViewModel>();

                foreach (var kvp in pierToGroups)
                {
                    var pier = kvp.Key;
                    var pierStories = kvp.Value
                        .Select(g => g.StoryName)
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .OrderBy(s => storyIndexMap.TryGetValue(s, out var idx) ? idx : 9999)
                        .ToList();

                    // Precompute boundaries for each story of this pier
                    var storyBoundaries = new Dictionary<string, (IReadOnlyList<Point2D> Outer, IReadOnlyList<IReadOnlyList<Point2D>> Openings)>(StringComparer.OrdinalIgnoreCase);
                    foreach (var story in pierStories)
                    {
                        var segments = pierShellImportService.GetSegments(pier, story, targetUnitSystem);
                        if (segments.Count > 0 && irregularGeometryBuilder is not null)
                        {
                            try
                            {
                                var boundaryDto = irregularGeometryBuilder.BuildBoundary(segments);
                                if (!boundaryDto.IsEmpty)
                                {
                                    storyBoundaries[story] = (boundaryDto.ClockwisePolylines[0], boundaryDto.OpeningPolylines);
                                }
                            }
                            catch { }
                        }
                        if (!storyBoundaries.ContainsKey(story))
                        {
                            storyBoundaries[story] = ([], []);
                        }
                    }

                    // Run contiguous grouping
                    var contiguousGroups = new List<List<string>>();
                    List<string>? currentGroup = null;

                    foreach (var story in pierStories)
                    {
                        if (currentGroup == null)
                        {
                            currentGroup = [story];
                            contiguousGroups.Add(currentGroup);
                        }
                        else
                        {
                            var firstStoryInGroup = currentGroup[0];
                            var boundaryFirst = storyBoundaries[firstStoryInGroup];
                            var boundaryCurrent = storyBoundaries[story];

                            if (AreBoundariesEqual(boundaryFirst.Outer, boundaryFirst.Openings, boundaryCurrent.Outer, boundaryCurrent.Openings))
                            {
                                currentGroup.Add(story);
                            }
                            else
                            {
                                currentGroup = [story];
                                contiguousGroups.Add(currentGroup);
                            }
                        }
                    }

                    // For each group, generate the UniqueSection name and create the rows
                    foreach (var groupList in contiguousGroups)
                    {
                        string uniqueSectionName;
                        if (groupList.Count == 1)
                        {
                            uniqueSectionName = $"{pier}|{groupList[0]}";
                        }
                        else
                        {
                            uniqueSectionName = $"{pier}|{groupList[0]}-{groupList[groupList.Count - 1]}";
                        }

                        // Also update pierBoundaryCache for this UniqueSection so preview/snapshot is instant
                        var firstStory = groupList[0];
                        var boundary = storyBoundaries[firstStory];
                        if (boundary.Outer.Count >= 3)
                        {
                            if (pierBoundaryCache.Count >= PierBoundaryCacheLimit)
                                pierBoundaryCache.Clear();
                            pierBoundaryCache[uniqueSectionName] = (boundary.Outer, boundary.Openings);
                        }

                        foreach (var story in groupList)
                        {
                            var prop = kvp.Value.FirstOrDefault(g => string.Equals(g.StoryName, story, StringComparison.OrdinalIgnoreCase)).SectionProperty ?? pier;

                            newRows.Add(new EtabsColumnImportRowViewModel(
                                OnColumnSelectionChanged,
                                $"pier:{pier}:{story}",
                                pier,
                                story,
                                pier,
                                uniqueSectionName,
                                pier,
                                prop,
                                SectionShapeType.Irregular,
                                0, 0, 0, 0,
                                "",
                                "Ready",
                                targetUnitSystem));
                        }
                    }
                }

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    // Remove any stale pier rows first (e.g. from a previous partial load)
                    var staleRows = Columns.Where(c => c.IsIrregular).ToList();
                    using (FilteredColumns.DeferRefresh())
                    using (TierObjectCandidatesView.DeferRefresh())
                    {
                        foreach (var row in staleRows)
                            Columns.Remove(row);

                        Columns.AddRange(newRows);
                    }

                    ConnectionStatus = groups.Count == 0
                        ? "Connected — no pier groups found."
                        : $"Connected — {groups.Count} pier group(s) loaded.";

                    RebuildStoryFilters();
                    RebuildUniqueSectionOptions();
                    RebuildStoryOptions();
                    Raise(nameof(SelectedColumnCount));
                    RaiseTierProperties();
                    RaiseCommandStates();
                });
            }
            catch (Exception ex)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    pierGroupsLoaded = false; // allow retry on next selection
                    ConnectionStatus = $"Failed to load pier groups: {ex.Message}";
                    RebuildStoryFilters();
                });
            }
        });
    }

    public void ApplyPreloadData(EtabsPreloadData data)
    {
        ModelName        = data.ModelName;
        ModelPath        = data.ModelPath;
        PresentUnits     = data.PresentUnits;
        StoryCount       = data.StoryCount;
        PierCount        = data.PierCount;
        FrameObjectCount = data.FrameObjectCount;
        UnitConversionMessage = $"ETABS data will be converted from {data.PresentUnits} to {TargetGeometryUnitSummary}.";

        using (FilteredColumns.DeferRefresh())
        using (TierObjectCandidatesView.DeferRefresh())
        {
            Columns.AddRange(data.Columns.Select(dto => new EtabsColumnImportRowViewModel(
                OnColumnSelectionChanged,
                dto.ObjectName,
                dto.PierName,
                dto.StoryName,
                dto.Label,
                dto.UniqueSectionDisplayName,
                dto.EtabsSectionName,
                dto.MaterialName,
                dto.SectionType,
                dto.Width,
                dto.Height,
                dto.Diameter,
                dto.LengthMm,
                dto.LinkedSection,
                dto.Status,
                targetUnitSystem)));
        }

        var combosToShow = data.SelectedLoadCombinations.Count > 0
            ? data.SelectedLoadCombinations
            : data.LoadCombinations;

        using (FilteredLoadCombinations.DeferRefresh())
        {
            LoadCombinations.AddRange(
                combosToShow.Select(name =>
                    new EtabsLoadCombinationViewModel(name, OnLoadCombinationSelectionChanged)));
        }
        FilteredLoadCombinations.Refresh();

        pierGroupsLoaded = false;
        IsConnected      = true;
        ConnectionStatus = "Connected to ETABS.";

        storyOrderMap.Clear();
        var storyElevations = columnImportService.GetStoryElevations();
        for (int i = 0; i < storyElevations.Count; i++)
            storyOrderMap[storyElevations[i].Name] = i;

        ResetColumnFilters();
        RebuildUniqueSectionOptions();
        RebuildStoryOptions();
        SelectedColumn = Columns.FirstOrDefault();
        Raise(nameof(SelectedColumnCount));
        Raise(nameof(DesignForcesStatusText));
        Raise(nameof(IsDesignForcesImported));
        RaiseCounts();
        RaiseTierProperties();
        RaiseCommandStates();

        PreloadDesignForcesInBackground(data.ModelPath, data.ModelName);
    }

    private void Disconnect()
    {
        IsConnected = false;
        ConnectionStatus = "Not connected";
        ModelName = "-";
        ModelPath = "-";
        PresentUnits = "-";
        StoryCount = 0;
        PierCount = 0;
        FrameObjectCount = 0;
        UnitConversionMessage = "Connect to ETABS to read model units.";
        Columns.Clear();
        SectionMappings.Clear();
        UniqueSectionOptions.Clear();
        StoryOptions.Clear();
        ForceRows.Clear();
        SummaryRows.Clear();
        MbColumnSections.Clear();
        SelectedMbColumnSection = null;
        forceCacheService?.Clear();
        importedForceCache?.Clear();
        ForceCacheStatus = forceCacheService is not null ? "Not built" : "Unavailable";
        pierBoundaryCache.Clear();
        pierGroupsLoaded = false;
        SelectedColumn = null;
        SelectedMapping = null;
        selectedUniqueSection = null;
        Raise(nameof(SelectedUniqueSection));
        ResetColumnFilters();
        TierObjectCandidatesView.Refresh();
        RaiseCounts();
        RaiseTierProperties();
    }

    private void Reconnect()
    {
        if (IsConnected) Disconnect();
        Connect();
    }

    private void ReloadStoryDefinitions()
    {
        if (!IsConnected) return;
        ConnectionStatus = "Reloading story definitions...";
        try
        {
            storyOrderMap.Clear();
            var storyElevations = columnImportService.GetStoryElevations();
            for (int i = 0; i < storyElevations.Count; i++)
                storyOrderMap[storyElevations[i].Name] = i;
            RebuildStoryOptions();
            RebuildStoryFilters();
            ConnectionStatus = $"Story definitions reloaded — {storyElevations.Count} stories.";
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Failed to reload story definitions: {ex.Message}";
        }
    }

    private void ReloadColumnConnectivity()
    {
        if (!IsConnected) return;
        ConnectionStatus = "Reloading column/pier connectivity...";
        try
        {
            using (FilteredColumns.DeferRefresh())
            using (TierObjectCandidatesView.DeferRefresh())
            {
                Columns.Clear();
                Columns.AddRange(columnImportService.GetCandidateColumns(targetUnitSystem)
                    .Select(dto => new EtabsColumnImportRowViewModel(
                        OnColumnSelectionChanged,
                        dto.ObjectName, dto.PierName, dto.StoryName, dto.Label,
                        dto.UniqueSectionDisplayName, dto.EtabsSectionName, dto.MaterialName,
                        dto.SectionType, dto.Width, dto.Height, dto.Diameter, dto.LengthMm,
                        dto.LinkedSection, dto.Status, targetUnitSystem)));
            }
            pierGroupsLoaded = false;
            pierBoundaryCache.Clear();
            RebuildUniqueSectionOptions();
            RebuildStoryOptions();
            SelectedColumn = Columns.FirstOrDefault();
            Raise(nameof(SelectedColumnCount));
            RaiseTierProperties();
            RaiseCommandStates();
            ConnectionStatus = $"Column/pier connectivity reloaded — {Columns.Count} items.";
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Failed to reload column/pier connectivity: {ex.Message}";
        }
    }

    private void CreateNewMbColumnSection()
    {
        var existingNames = MbColumnSections.Select(g => g.SectionName).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var name = NextAvailableGroupName("ETABS Import", existingNames);

        var section = new MbColumnSectionViewModel(
            name,
            OnMbColumnSectionChanged,
            isDuplicateName: n => MbColumnSections.Any(s => string.Equals(s.SectionName, n, StringComparison.OrdinalIgnoreCase)))
        {
            SelectedTargetGroup = SelectedTargetGroup
        };
        MbColumnSections.Add(section);
        SelectedMbColumnSection = section;
        RaiseImportSummary();
        applyImportCommand.RaiseCanExecuteChanged();
    }

    public void AssignSelectedItemsToSection(MbColumnSectionViewModel targetSection)
    {
        // Snapshot selected items, deduplicate by Story+Label+ObjectType key
        var snapshot = Columns.Where(c => c.IsSelected)
            .Where(c => !string.IsNullOrWhiteSpace(c.Story) && !string.IsNullOrWhiteSpace(c.Label))
            .GroupBy(c => $"{(c.IsIrregular ? "Pier" : "Column")}|{c.Story.Trim()}|{c.Label.Trim()}",
                StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First())
            .ToList();

        // Remove from any existing section first
        foreach (var col in snapshot)
        {
            foreach (var existing in MbColumnSections)
                existing.RemoveItem(col);
        }

        foreach (var col in snapshot)
            targetSection.AddItem(col);

        // Clear IsSelected — FilteredColumns.Refresh() may not fire SelectionChanged/RemovedItems
        foreach (var col in Columns)
            col.IsSelected = false;

        FilteredColumns.Refresh();
        RaiseImportSummary();
        applyImportCommand.RaiseCanExecuteChanged();
    }

    public void RemoveItemFromSection(MbColumnSectionViewModel section, EtabsColumnImportRowViewModel item)
    {
        section.RemoveItem(item);
        FilteredColumns.Refresh();
        RaiseImportSummary();
        applyImportCommand.RaiseCanExecuteChanged();
    }

    public void DeleteMbColumnSection(MbColumnSectionViewModel section)
    {
        foreach (var item in section.Items.ToList())
            section.RemoveItem(item);

        MbColumnSections.Remove(section);
        if (SelectedMbColumnSection == section)
            SelectedMbColumnSection = MbColumnSections.FirstOrDefault();

        RaiseImportSummary();
        applyImportCommand.RaiseCanExecuteChanged();
    }

    private void ApplyImport()
    {
        if (ForceRows.Count == 0
            && MbColumnSections.Any(g => g.Items.Count > 0)
            && LoadCombinations.Any(c => c.IsSelected))
        {
            GenerateForceRows();
        }

        var sections = new List<EtabsImportedSectionInput>();
        var reservedNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);

        foreach (var mbSection in MbColumnSections.Where(g => g.Items.Count > 0))
        {
            var snapshot = CreateGroupSnapshot(mbSection);
            if (snapshot is null) continue;

            var baseName = SanitizeName(mbSection.SectionName);
            var finalName = NextAvailableName(baseName, reservedNames);
            reservedNames.Add(finalName);

            var targetGroup = mbSection.SelectedTargetGroup ?? SelectedTargetGroup;
            sections.Add(new EtabsImportedSectionInput(
                finalName,
                snapshot,
                UpdateExisting: false,
                targetGroup?.GroupId,
                targetGroup?.GroupName ?? "",
                targetGroup?.CreateGroup == true));
        }

        if (sections.Count == 0) return;

        ImportResult = new EtabsImportDialogResult(
            sections,
            new Application.DTOs.Etabs.EtabsModelInfoDto(ModelName, ModelPath, PresentUnits, StoryCount, PierCount, FrameObjectCount));
        RequestClose?.Invoke(this, true);
    }

    private ColumnInputSnapshot? CreateGroupSnapshot(MbColumnSectionViewModel group)
    {
        if (group.Items.Count == 0) return null;

        var sourceColumn = group.Items[0];
        var mapping = SectionMappings.FirstOrDefault(m =>
            string.Equals(m.UniqueSection, sourceColumn.UniqueSection, StringComparison.OrdinalIgnoreCase))
            ?? SectionMappings.FirstOrDefault();

        if (mapping is null)
        {
            BuildSectionMappings();
            mapping = SectionMappings.FirstOrDefault(m =>
                string.Equals(m.UniqueSection, sourceColumn.UniqueSection, StringComparison.OrdinalIgnoreCase))
                ?? SectionMappings.FirstOrDefault();
        }

        if (mapping is null) return null;

        var selectedForces = GetSelectedForcesForItems(group.Items);
        var objectLengthByNameMm = group.Items
            .Where(i => i.LengthMm > 0)
            .GroupBy(i => i.ObjectName, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First().LengthMm, StringComparer.OrdinalIgnoreCase);
        var loadCases = BuildSnapshotLoadCases(selectedForces, objectLengthByNameMm);

        IReadOnlyList<Point2D> boundary;
        IReadOnlyList<IReadOnlyList<Point2D>> openings = [];
        string importMode = "FrameSection";
        List<string> sourceShells = [];
        List<string> sourceSectionProps = [];
        string? boundaryWarning = null;

        if (mapping.IsIrregular)
        {
            var (irr, ops, shells, props, warn) = BuildIrregularBoundary(
                sourceColumn.Pier, sourceColumn.Story, mapping);
            boundary = irr;
            openings = ops;
            sourceShells = shells;
            sourceSectionProps = props;
            boundaryWarning = warn;
            importMode = "IrregularPierShell";
        }
        else
        {
            boundary = BuildBoundaryPoints(mapping);
        }

        var rebars = BuildEqualSpacingCustomRebars(mapping, boundary);
        var bbox = PolygonGeometry.BoundingBox(boundary);
        var boundingWidth = mapping.IsCircular ? mapping.Diameter : (mapping.IsIrregular ? bbox.Width : mapping.Width);
        var boundingHeight = mapping.IsCircular ? mapping.Diameter : (mapping.IsIrregular ? bbox.Height : mapping.Height);
        var primaryForce = loadCases.FirstOrDefault();

        var importFy = selectedImportRebarGrade?.StressValue(selectedImportUnitSystem) ?? 420;
        var importEs = selectedImportRebarGrade?.ModulusValue(selectedImportUnitSystem) ?? 200000;
        var rawLengthGroup = group.Items.FirstOrDefault(i => i.LengthMm > 0)?.LengthMm ?? 0;
        // MemberLengthL in the snapshot is stored in section-size unit (mm for Metric, inches for Imperial)
        var importMemberLength = rawLengthGroup > 0
            ? (selectedImportUnitSystem == UnitSystem.Metric ? rawLengthGroup : rawLengthGroup / 25.4)
            : (double?)null;
        var snapshot = new ColumnInputSnapshot
        {
            UnitSystem = selectedImportUnitSystem.ToString(),
            DesignCode = selectedImportDesignCode.ToString(),
            Ec2Solver = Ec2SolverType.Fiber.ToString(),
            IntegrationMethod = (mapping.IsRectangular ? SectionIntegrationMethod.Polygon : SectionIntegrationMethod.Fiber).ToString(),
            AlphaCc = 0.85,
            SectionShape = mapping.IsRectangular ? SectionShapeType.Rectangular.ToString()
                         : mapping.IsCircular    ? SectionShapeType.Circular.ToString()
                         :                         SectionShapeType.Irregular.ToString(),
            Width = boundingWidth,
            Height = boundingHeight,
            Diameter = Math.Max(boundingWidth, boundingHeight),
            Cover = mapping.Cover,
            MemberLengthL = importMemberLength,
            IncludeEc2Slenderness = selectedImportDesignCode == DesignCodeType.Ec2 && importIncludeSlenderness,
            Fc = InferConcreteStrength(mapping.Material),
            Fy = importFy,
            Es = importEs,
            MaterialLibrary = MaterialLibraryType.Custom.ToString(),
            BarSize = mapping.BarSize,
            BarCount = mapping.IsRectangular ? mapping.RectangularBarCount
                     : mapping.IsCircular    ? mapping.TotalBars
                     :                         rebars.Count,
            Spacing = mapping.TieSpacing,
            RebarLayoutType = mapping.IsRectangular ? "SidesDifferent"
                            : mapping.IsCircular    ? "EqualSpacing"
                            :                         "CustomCoordinates",
            TopBarCount    = mapping.IsRectangular ? mapping.BarsAlongWidth  : 0,
            BottomBarCount = mapping.IsRectangular ? mapping.BarsAlongWidth  : 0,
            LeftBarCount   = mapping.IsRectangular ? mapping.BarsAlongHeight : 0,
            RightBarCount  = mapping.IsRectangular ? mapping.BarsAlongHeight : 0,
            IrregularBarSize = mapping.BarSize,
            IrregularSpacing = mapping.TieSpacing,
            IrregularRebarMode = mapping.IsIrregular ? "CustomCoordinates" : "EqualSpacing",
            BoundaryPoints = mapping.IsIrregular
                ? boundary.Select((pt, i) => new SnapshotBoundaryPoint { PtIndex = i + 1, X = Math.Round(pt.X, 6), Y = Math.Round(pt.Y, 6) }).ToList()
                : [],
            OpeningPoints = mapping.IsIrregular
                ? openings.Select(op => op.Select((pt, j) => new SnapshotBoundaryPoint { PtIndex = j + 1, X = Math.Round(pt.X, 6), Y = Math.Round(pt.Y, 6) }).ToList()).ToList()
                : [],
            Rebars = mapping.IsIrregular ? rebars : [],
            Pu = primaryForce?.Pu ?? 0,
            Mux = primaryForce?.Mux ?? 0,
            Muy = primaryForce?.Muy ?? 0,
            PmAngleDegrees = 0,
            AxialLoad = 0,
            LoadCases = loadCases,
            DesignTierName = group.SectionName,
            DesignTierSource = "ETABS",
            EtabsMetadata = new EtabsImportMetadataDto
            {
                SourceModelPath = ModelPath,
                SourceModelName = ModelName,
                EtabsObjectName = sourceColumn.ObjectName,
                PierName = sourceColumn.Pier,
                StoryName = sourceColumn.Story,
                Label = sourceColumn.Label,
                EtabsSectionName = sourceColumn.EtabsSectionName,
                UniqueSectionDisplayName = sourceColumn.UniqueSection,
                ImportedAt = DateTime.UtcNow,
                ImportedUnits = PresentUnits,
                MBColumnUnitsAtImport = TargetForceMomentUnitSummary,
                SelectedLoadCombinations = loadCases.Select(lc => lc.OriginalLoadCaseName).Distinct(StringComparer.OrdinalIgnoreCase).ToList(),
                ImportMode = importMode,
                SourceShellNames = sourceShells,
                SourceAreaSectionProperties = sourceSectionProps,
                IrregularBoundaryWarning = boundaryWarning,
                OpeningCount = openings.Count
            },
            EtabsTierMetadata = new EtabsTierImportMetadataDto
            {
                SourceModelPath = ModelPath,
                SourceModelName = ModelName,
                ImportedUnits = PresentUnits,
                MBColumnUnitsAtImport = TargetForceMomentUnitSummary,
                ShapeType = mapping.IsRectangular ? "Rectangular" : mapping.IsCircular ? "Circular" : "Irregular",
                SourceSectionName = sourceColumn.EtabsSectionName,
                UniqueSectionDisplayName = sourceColumn.UniqueSection,
                TargetGroupName = group.SelectedTargetGroup?.GroupName ?? "",
                TargetGroupId = group.SelectedTargetGroup?.GroupId,
                TierName = group.SectionName,
                StoryFrom = group.Items.Select(i => i.Story).OrderBy(s => s).FirstOrDefault() ?? "",
                StoryTo = group.Items.Select(i => i.Story).OrderBy(s => s).LastOrDefault() ?? "",
                LabelFilter = "",
                SourceObjects = group.Items.Select(i => new EtabsSourceObjectRefDto
                {
                    ObjectName = i.ObjectName,
                    Label = i.Label,
                    Story = i.Story,
                    SectionName = i.EtabsSectionName
                }).ToList(),
                SelectedLoadCombinations = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList(),
                ImportTop = true,
                ImportBottom = true,
                ImportMid = true,
                ImportedAt = DateTime.UtcNow
            },
            EtabsBinding = BuildEtabsSectionBinding(group, sourceColumn, mapping),
            LastEtabsRefreshAt = DateTime.UtcNow,
            LastEtabsRefreshSummary = $"Initial import · {LoadCombinations.Count(c => c.IsSelected)} combos"
        };

        return snapshot;
    }

    private Application.DTOs.Etabs.EtabsSectionBinding BuildEtabsSectionBinding(
        MbColumnSectionViewModel group,
        EtabsColumnImportRowViewModel sourceColumn,
        EtabsSectionMappingViewModel mapping)
    {
        var objectType = sourceColumn.IsIrregular
            ? Application.DTOs.Etabs.EtabsImportedObjectType.Pier
            : Application.DTOs.Etabs.EtabsImportedObjectType.Column;

        var forceSource = selectedForceType == "Element Forces"
            ? Application.DTOs.Etabs.MbColumnForceSourceMode.ElementForces
            : Application.DTOs.Etabs.MbColumnForceSourceMode.DesignForces;

        var locations = new List<string> { "Top", "Bottom", "Mid" };

        var binding = new Application.DTOs.Etabs.EtabsSectionBinding
        {
            MbColumnSectionId = group.SectionName,
            MbColumnSectionName = group.SectionName,
            ObjectType = objectType,
            ForceSource = forceSource,
            LoadCombinations = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList(),
            Locations = locations,
            SourceModel = new Application.DTOs.Etabs.EtabsModelFingerprint
            {
                ModelFilePath = ModelPath,
                ModelFileName = ModelName,
                ImportedAt = DateTime.UtcNow
            }
        };

        if (objectType == Application.DTOs.Etabs.EtabsImportedObjectType.Column)
        {
            binding.ColumnObjects = group.Items.Select(i => new Application.DTOs.Etabs.EtabsColumnObjectKey
            {
                Story = i.Story,
                Label = i.Label,
                UniqueName = i.ObjectName
            }).ToList();
        }
        else
        {
            binding.PierObjects = group.Items
                .GroupBy(i => i.Story)
                .Select(g2 => new Application.DTOs.Etabs.EtabsPierObjectKey
                {
                    Story = g2.Key,
                    PierName = g2.First().Pier
                }).ToList();
        }

        return binding;
    }

    private bool _isBuildingCache;

    private async Task BuildForceCacheAsync()
    {
        if (forceCacheService is null || _isBuildingCache) return;

        // Nothing assigned yet — skip silently
        if (!AllAssignedItems.Any()) return;

        try
        {
            _isBuildingCache = true;
            ForceCacheStatus = "Building…";
            buildForceCacheCommand.RaiseCanExecuteChanged();

            var allCombos    = LoadCombinations.Select(c => c.Name).ToList();
            var frameColumns = AllAssignedItems.Where(c => !c.IsIrregular).ToList();
            var piers        = AllAssignedItems.Where(c => c.IsIrregular).Select(c => (c.Pier, c.Story)).ToList();

            // Snapshot DTO list on the UI thread before switching to background
            var columnDtos = frameColumns.Select(c => new EtabsColumnImportDto(
                c.ObjectName, c.Pier, c.Story, c.Label,
                c.UniqueSection, c.EtabsSectionName, c.Material,
                c.SectionType, c.Width, c.Height, c.Diameter, c.LengthMm, c.LinkedSection, c.Status)).ToList();

            // Use the preloaded raw cache when it matches the current model — avoids a second COM call
            var rawDb      = importedForceCache?.HasValidCache(ModelPath) == true ? importedForceCache.Current : null;
            var useRawPath = rawDb is not null && designForceImportService is not null;

            var result = await Task.Run(() =>
            {
                var forces = new List<EtabsForceResultDto>();

                if (useRawPath)
                {
                    if (columnDtos.Count > 0)
                        forces.AddRange(designForceImportService!.ParseColumnForces(rawDb!, columnDtos, allCombos, targetUnitSystem));
                    if (piers.Count > 0)
                        forces.AddRange(designForceImportService!.ParsePierForces(rawDb!, piers, allCombos, targetUnitSystem));
                }
                else
                {
                    // Fall back to live COM calls (existing behaviour)
                    if (columnDtos.Count > 0)
                        forces.AddRange(forceImportService.GetForces(columnDtos, allCombos, targetUnitSystem));
                    if (piers.Count > 0)
                        forces.AddRange(forceImportService.GetPierForces(piers, allCombos, targetUnitSystem));
                }

                return forceCacheService.Build(forces);
            });

            ForceCacheStatus = result.RowCount == 0
                ? "No design forces found — ensure the ETABS model has been designed."
                : result.Message;
        }
        catch (Exception ex)
        {
            ForceCacheStatus = $"Force cache error: {ex.Message}";
        }
        finally
        {
            _isBuildingCache = false;
            buildForceCacheCommand.RaiseCanExecuteChanged();
        }
    }

    private void SetFlow(int flow)
    {
        CurrentFlow = Math.Clamp(flow, 1, 3);
    }

    private void GoToFlow2()
    {
        BuildSectionMappings();
        if (LoadCombinations.Count == 0 && IsConnected)
            RefreshLoadCombinations();
        SetFlow(2);
    }

    private void GoToFlow3()
    {
        GenerateForceRows();
        BuildSummaryRows();
        BuildMbColumnSectionSummary();
        SetFlow(3);
    }

    private void BuildMbColumnSectionSummary()
    {
        MbColumnSectionSummaryRows.Clear();
        if (sectionForceFilter is null) return;

        var allForceDtos = ForceRows
            .Where(r => r.IsSelected)
            .Select(r => new EtabsForceResultDto(
                r.ObjectName, r.Pier, r.Story, r.Label, r.EtabsSection,
                r.LoadCombination, r.P, r.M2, r.M3, r.V2, r.V3, r.Station, r.Status))
            .ToList();

        foreach (var mbSection in MbColumnSections.Where(s => s.Items.Count > 0))
        {
            var colItems  = mbSection.Items.Where(i => !i.IsIrregular).ToList();
            var pierItems = mbSection.Items.Where(i => i.IsIrregular).ToList();

            if (colItems.Count > 0)
            {
                var colSection = BuildSectionImport(mbSection.SectionName, colItems, EtabsImportedObjectType.Column);
                var matched = sectionForceFilter.FilterForcesForSection(colSection, allForceDtos, EtabsImportedObjectType.Column);
                var missing = sectionForceFilter.FindMissingItems(colSection, allForceDtos);
                MbColumnSectionSummaryRows.Add(new MbColumnSectionSummaryViewModel
                {
                    SectionName     = mbSection.SectionName,
                    ObjectType      = "Column",
                    SelectedItems   = colItems.Count,
                    MatchedForceRows = matched.Count,
                    MissingItems    = missing.Count
                });
            }

            if (pierItems.Count > 0)
            {
                var pierSection = BuildSectionImport(mbSection.SectionName, pierItems, EtabsImportedObjectType.Pier);
                var matched = sectionForceFilter.FilterForcesForSection(pierSection, allForceDtos, EtabsImportedObjectType.Pier);
                var missing = sectionForceFilter.FindMissingItems(pierSection, allForceDtos);
                MbColumnSectionSummaryRows.Add(new MbColumnSectionSummaryViewModel
                {
                    SectionName     = mbSection.SectionName,
                    ObjectType      = "Pier",
                    SelectedItems   = pierItems.Count,
                    MatchedForceRows = matched.Count,
                    MissingItems    = missing.Count
                });
            }
        }
    }

    private void OnMbColumnSectionChanged()
    {
        RaiseImportSummary();
        applyImportCommand.RaiseCanExecuteChanged();
        goToFlow2Command.RaiseCanExecuteChanged();
    }

    private void RaiseImportSummary()
    {
        int unassigned = 0;
        int assigned = 0;
        foreach (var c in Columns)
        {
            if (FilterColumn(c))
            {
                if (string.IsNullOrEmpty(c.ImportGroupName))
                    unassigned++;
                else
                    assigned++;
            }
        }
        UnassignedCount = unassigned;
        AssignedCount = assigned;
        MbColumnSectionsReadyCount = MbColumnSections.Count(g => g.Items.Count > 0);
        CanApplyImport = MbColumnSectionsReadyCount > 0;

        AllAssignedItems.Clear();
        foreach (var section in MbColumnSections)
            foreach (var item in section.Items)
                AllAssignedItems.Add(item);

        UpdateFlow1Validation();
        UpdateFlow2Validation();
    }

    private void UpdateFlow1Validation()
    {
        if (MbColumnSections.Count == 0)
        {
            Flow1ValidationMessage = "No MB Column Sections yet. Create at least one section and assign ETABS objects to it.";
            AssignmentConflictText = "";
            Raise(nameof(HasFlow1Warning));
            Raise(nameof(HasAssignmentConflict));
            return;
        }

        // Detect same Story+Label key assigned to multiple sections
        var keyToSections = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var conflicts = new List<string>();
        foreach (var section in MbColumnSections)
        {
            foreach (var item in section.Items)
            {
                var key = $"{(item.IsIrregular ? "Pier" : "Column")}|{item.Story}|{item.Label}";
                if (keyToSections.TryGetValue(key, out var otherSection))
                {
                    if (!string.Equals(otherSection, section.SectionName, StringComparison.OrdinalIgnoreCase))
                        conflicts.Add($"{item.Story}/{item.Label} in '{otherSection}' and '{section.SectionName}'");
                }
                else
                {
                    keyToSections[key] = section.SectionName;
                }
            }
        }

        AssignmentConflictText = conflicts.Count > 0
            ? $"Duplicate assignment: {string.Join("; ", conflicts.Take(3))}"
            : "";
        Raise(nameof(HasAssignmentConflict));

        var emptySections = MbColumnSections.Where(s => s.Items.Count == 0).Select(s => s.SectionName).ToList();
        if (emptySections.Count > 0)
        {
            Flow1ValidationMessage = $"Section(s) with no items: {string.Join(", ", emptySections.Take(3))}. Assign ETABS objects or delete empty sections.";
        }
        else if (conflicts.Count > 0)
        {
            Flow1ValidationMessage = AssignmentConflictText;
        }
        else
        {
            Flow1ValidationMessage = "";
        }

        Raise(nameof(HasFlow1Warning));
    }

    private void UpdateFlow2Validation()
    {
        var messages = new List<string>();

        if (!LoadCombinations.Any(c => c.IsSelected) && LoadCombinations.Count > 0)
            messages.Add("No load combinations selected — select at least one before loading forces.");

        if (ForceRows.Count == 0 && MbColumnSections.Any(s => s.Items.Count > 0))
            messages.Add("Forces not loaded — click 'Load Forces' to retrieve force data.");

        if (ForceRows.Count > 0 && MbColumnMappedForceRows.Count == 0 && MbColumnSections.Any(s => s.Items.Count > 0))
            messages.Add("No forces matched to any MB Column Section — verify Story/Label assignment in Step 1.");

        Flow2ValidationMessage = string.Join(" ", messages);
        Raise(nameof(HasFlow2Warning));
    }

    private void PrepareTierBuilder()
    {
        RebuildStoryOptions();
        ApplyTierObjectFilter();
        UpdateDefaultTierName();
        RaiseTierProperties();
    }

    private void AddTargetGroup()
    {
        var existingNames = TargetGroups
            .Select(g => g.GroupName)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);
        var suggested = NextAvailableGroupName("ETABS Import", existingNames);
        var name = RequestGroupName?.Invoke(suggested) ?? suggested;
        if (string.IsNullOrWhiteSpace(name)) return;
        var option = new ProjectGroupOptionViewModel(null, name.Trim(), true);
        TargetGroups.Add(option);
        SelectedTargetGroup = option;
    }

    private static string NextAvailableGroupName(string baseName, HashSet<string> existingNames)
    {
        if (!existingNames.Contains(baseName))
            return baseName;

        var index = 2;
        while (existingNames.Contains($"{baseName} {index}"))
            index++;

        return $"{baseName} {index}";
    }

    private void RebuildUniqueSectionOptions()
    {
        var previous = SelectedUniqueSection?.SectionName;
        UniqueSectionOptions.Clear();

        foreach (var group in FilteredByType()
                     .GroupBy(c => c.UniqueSection, StringComparer.OrdinalIgnoreCase)
                     .OrderBy(g => g.Key, StringComparer.OrdinalIgnoreCase))
        {
            var first = group.First();
            UniqueSectionOptions.Add(new EtabsUniqueSectionOptionViewModel(
                first.UniqueSection,
                first.EtabsSectionName,
                first.SectionType,
                group.Count(),
                ApplyTierObjectFilter));
        }

        SelectedUniqueSection = UniqueSectionOptions.FirstOrDefault(s =>
                string.Equals(s.SectionName, previous, StringComparison.OrdinalIgnoreCase))
            ?? UniqueSectionOptions.FirstOrDefault();

        foreach (var vm in UniqueSectionOptions)
            vm.IsSelected = vm == SelectedUniqueSection;
    }

    private void RebuildStoryOptions()
    {
        StoryOptions.Clear();

        // All stories from all columns matching element/type filter — not section-dependent
        var ascending = FilteredByType()
            .Select(c => c.Story)
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(s => storyOrderMap.TryGetValue(s, out var idx) ? idx : int.MaxValue)
            .ToList();

        // Display descending (highest elevation first = top of list), all selected by default
        void OnStorySelectionChanged() { TierObjectCandidatesView.Refresh(); UpdateDefaultTierName(); }
        for (int i = ascending.Count - 1; i >= 0; i--)
        {
            var vm = new EtabsStoryOptionViewModel(ascending[i], 0, i, OnStorySelectionChanged);
            vm.IsSelected = true;
            StoryOptions.Add(vm);
        }

        Raise(nameof(StoryFrom));
        Raise(nameof(StoryTo));
    }

    private void ApplyTierObjectFilter()
    {
        TierObjectCandidatesView.Refresh();
        Raise(nameof(SelectedColumnCount));
        Raise(nameof(MatchedTierObjectCount));
    }

    private bool FilterTierObjectCandidate(object item)
    {
        if (item is not EtabsColumnImportRowViewModel column)
            return false;

        if (!UniqueSectionOptions.Any(s => s.IsSelected &&
                string.Equals(s.SectionName, column.UniqueSection, StringComparison.OrdinalIgnoreCase)))
            return false;

        if (!IsStoryWithinRange(column.Story))
            return false;

        return string.IsNullOrWhiteSpace(LabelTextFilter)
               || column.Label.Contains(LabelTextFilter.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    private bool IsStoryWithinRange(string story)
    {
        if (StoryOptions.Count == 0 || string.IsNullOrWhiteSpace(story)) return true;
        var all = StoryOptions.All(s => s.IsSelected);
        if (all) return true;
        return StoryOptions.Any(s => s.IsSelected && string.Equals(s.StoryName, story, StringComparison.OrdinalIgnoreCase));
    }

    private int StoryIndex(string story)
        => StoryOptions.FirstOrDefault(s => string.Equals(s.StoryName, story, StringComparison.OrdinalIgnoreCase))?.SortIndex ?? -1;

    private void UpdateDefaultTierName()
    {
        if (SelectedUniqueSection is null)
            return;

        if (!string.IsNullOrWhiteSpace(TierName)
            && !string.Equals(TierName, lastGeneratedTierName, StringComparison.OrdinalIgnoreCase))
            return;

        var label = string.IsNullOrWhiteSpace(LabelTextFilter) ? "All" : LabelTextFilter.Trim();
        var storyRange = string.Equals(StoryFrom, StoryTo, StringComparison.OrdinalIgnoreCase)
            ? StoryFrom
            : $"{StoryFrom}-{StoryTo}";
        lastGeneratedTierName = SanitizeName($"{SelectedUniqueSection.SourceSectionName}_{storyRange}_{label}");
        tierName = lastGeneratedTierName;
        Raise(nameof(TierName));
    }

    private void UpdateBoundaryPreviewFromUniqueSection()
    {
        if (SelectedUniqueSection is null)
            return;

        var previewColumn = Columns.FirstOrDefault(c =>
            string.Equals(c.UniqueSection, SelectedUniqueSection.SectionName, StringComparison.OrdinalIgnoreCase));
        if (previewColumn is not null)
            SelectedColumn = previewColumn;
    }

    private void BuildSectionMappings()
    {
        var existingMappings = SectionMappings.ToDictionary(m => m.UniqueSection, StringComparer.OrdinalIgnoreCase);
        SectionMappings.Clear();

        foreach (var group in MbColumnSections.SelectMany(s => s.Items)
                                 .Concat(Columns.Where(c => c.IsSelected))
                                 .GroupBy(c => c.SectionKey))
        {
            var source = group.First();
            if (existingMappings.TryGetValue(source.UniqueSection, out var existing))
            {
                SectionMappings.Add(existing);
                continue;
            }

            var defaultBarSize = targetUnitSystem == UnitSystem.Metric ? "T25" : "#8";
            var defaultCover = targetUnitSystem == UnitSystem.Metric ? 50.0 : 2.0;
            var defaultSpacing = targetUnitSystem == UnitSystem.Metric ? 150.0 : 6.0;

            var mapping = new EtabsSectionMappingViewModel(
                OnMappingChanged,
                source.EtabsSectionName,
                source.UniqueSection,
                source.SectionType,
                source.Width,
                source.Height,
                source.Diameter,
                source.Material,
                defaultBarSize,
                defaultCover,
                defaultSpacing);

            if (source.IsRectangular)
            {
                mapping.BarsAlongWidth = source.Width >= 500 ? 5 : 4;
                mapping.BarsAlongHeight = source.Height >= 700 ? 5 : 4;
            }
            else if (!source.IsIrregular)
            {
                // Circular
                mapping.TotalBars = source.Diameter >= 800 ? 16 : 12;
            }
            // Irregular/pier: use constructor defaults (cover + spacing)

            SectionMappings.Add(mapping);
        }

        SelectedMapping = SectionMappings.FirstOrDefault();
        RaiseCommandStates();
    }

    private void RefreshLoadCombinations()
    {
        LoadCombinations.Clear();
        try
        {
            using (FilteredLoadCombinations.DeferRefresh())
            {
                LoadCombinations.AddRange(
                    columnImportService.GetLoadCombinations()
                        .Select(name => new EtabsLoadCombinationViewModel(name, OnLoadCombinationSelectionChanged)));
            }
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Warning: could not load combinations — {ex.Message}";
        }

        FilteredLoadCombinations.Refresh();
        RaiseCounts();

        if (forceCacheService is not null)
        {
            _ = BuildForceCacheAsync();
        }
    }

    private async Task GenerateForcesAsync()
    {
        var selectedCombos = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList();
        if (selectedCombos.Count == 0)
        {
            RaiseCounts();
            RaiseCommandStates();
            return;
        }

        // Snapshot inputs on UI thread before going async
        var isElementForces = selectedForceType == "Element Forces";
        var frameColumnDtos = AllAssignedItems
            .Where(c => !c.IsIrregular)
            .Select(c => new EtabsColumnImportDto(
                c.ObjectName, c.Pier, c.Story, c.Label,
                c.UniqueSection, c.EtabsSectionName, c.Material,
                c.SectionType, c.Width, c.Height, c.Diameter, c.LengthMm, c.LinkedSection, c.Status))
            .ToList();
        var pierPairs = AllAssignedItems
            .Where(c => c.IsIrregular)
            .Select(c => (c.Pier, c.Story))
            .ToList();

        ForceRows.Clear();
        IsLoadingForces = true;
        ForceCacheStatus = "Fetching forces from ETABS…";
        RaiseCommandStates();

        List<EtabsForceImportRowViewModel> rows = [];
        string? errorMsg = null;

        try
        {
            rows = await Task.Run(() =>
            {
                var result = new List<EtabsForceImportRowViewModel>();

                if (isElementForces)
                {
                    if (frameColumnDtos.Count > 0)
                        result.AddRange(forceImportService.GetElementForces(frameColumnDtos, selectedCombos, targetUnitSystem).Select(CreateForceRow));
                    if (pierPairs.Count > 0)
                        result.AddRange(forceImportService.GetPierElementForces(pierPairs, selectedCombos, targetUnitSystem).Select(CreateForceRow));
                }
                else
                {
                    if (frameColumnDtos.Count > 0)
                        result.AddRange(forceImportService.GetForces(frameColumnDtos, selectedCombos, targetUnitSystem).Select(CreateForceRow));
                    if (pierPairs.Count > 0)
                        result.AddRange(forceImportService.GetPierForces(pierPairs, selectedCombos, targetUnitSystem).Select(CreateForceRow));
                }

                return result;
            });
        }
        catch (Exception ex)
        {
            errorMsg = ex.Message;
        }
        finally
        {
            IsLoadingForces = false;
        }

        if (errorMsg is not null)
        {
            ForceCacheStatus = $"Error loading forces: {errorMsg}";
            RaiseCounts();
            RaiseCommandStates();
            return;
        }

        ForceRows.AddRange(rows);
        ApplyStationSelection();
        RaiseCounts();
        RaiseCommandStates();

        ForceCacheStatus = rows.Count == 0
            ? "No forces returned — check that columns are assigned to sections and the model has been designed in ETABS."
            : $"{rows.Count} row(s) loaded from live ETABS API.";

        GenerateSectionForceRows();
        UpdateFlow2Validation();
    }

    private void GenerateForceRows()
    {
        _ = GenerateForcesAsync();
    }

    public void GenerateSectionForceRows()
    {
        if (sectionForceFilter is null) return;

        MbColumnMappedForceRows.Clear();
        var sections = MbColumnSections.Where(s => s.Items.Count > 0).ToList();
        if (sections.Count == 0 || ForceRows.Count == 0) return;

        // Convert already-loaded ForceRows (respects combo + station selection) to DTOs
        var allForceDtos = ForceRows
            .Where(r => r.IsSelected)
            .Select(r => new EtabsForceResultDto(
                r.ObjectName, r.Pier, r.Story, r.Label, r.EtabsSection,
                r.LoadCombination, r.P, r.M2, r.M3, r.V2, r.V3, r.Station, r.Status))
            .ToList();

        if (allForceDtos.Count == 0) return;

        var totalMapped = 0;
        foreach (var mbSection in sections)
        {
            var colItems  = mbSection.Items.Where(i => !i.IsIrregular).ToList();
            var pierItems = mbSection.Items.Where(i => i.IsIrregular).ToList();

            if (colItems.Count > 0)
            {
                var colSection = BuildSectionImport(mbSection.SectionName, colItems, EtabsImportedObjectType.Column);
                var colRows = sectionForceFilter.FilterForcesForSection(colSection, allForceDtos, EtabsImportedObjectType.Column);
                foreach (var r in colRows)
                    MbColumnMappedForceRows.Add(new MbColumnMappedForceRowViewModel(r));
                totalMapped += colRows.Count;
            }

            if (pierItems.Count > 0)
            {
                var pierSection = BuildSectionImport(mbSection.SectionName, pierItems, EtabsImportedObjectType.Pier);
                var pierRows = sectionForceFilter.FilterForcesForSection(pierSection, allForceDtos, EtabsImportedObjectType.Pier);
                foreach (var r in pierRows)
                    MbColumnMappedForceRows.Add(new MbColumnMappedForceRowViewModel(r));
                totalMapped += pierRows.Count;
            }
        }

        if (totalMapped > 0)
            ForceCacheStatus = $"{totalMapped} mapped force row(s) across {sections.Count} section(s).";
    }

    private static MbColumnSectionImport BuildSectionImport(
        string sectionName,
        IEnumerable<EtabsColumnImportRowViewModel> items,
        EtabsImportedObjectType objectType)
        => new()
        {
            SectionName = sectionName,
            SelectedItems = new ObservableCollection<MbColumnSectionImportItem>(
                items.Select(i => new MbColumnSectionImportItem
                {
                    ObjectType = objectType,
                    Story = i.Story,
                    Label = i.Label
                }))
        };

    private EtabsForceImportRowViewModel CreateForceRow(EtabsForceResultDto force)
        => new(
            OnForceSelectionChanged,
            force.ObjectName,
            force.PierName,
            force.StoryName,
            force.Label,
            force.EtabsSectionName,
            force.LoadCombination,
            force.P,
            force.M2,
            force.M3,
            force.V2,
            force.V3,
            force.Station,
            force.Status);

    private void BuildSummaryRows()
    {
        SummaryRows.Clear();
        var reservedNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var mode = SelectedDuplicateHandling.Mode;
        var selectedColumns = Columns.Where(c => c.IsSelected).ToList();
        var sourceColumn = selectedColumns.FirstOrDefault();
        var mapping = SectionMappings.FirstOrDefault();
        if (sourceColumn is null || mapping is null)
        {
            Raise(nameof(SummaryCreateCount));
            RaiseCommandStates();
            return;
        }

        var baseName = SanitizeName(string.IsNullOrWhiteSpace(TierName) ? BuildDefaultSectionName(sourceColumn) : TierName);
        var exists = existingSectionNames.Contains(baseName);
        var isSkipped = exists && mode == EtabsDuplicateHandlingMode.SkipExisting;
        var updateExisting = exists && mode == EtabsDuplicateHandlingMode.UpdateExisting;
        var finalName = updateExisting ? baseName : NextAvailableName(baseName, reservedNames);
        var status = isSkipped
            ? "Skipped"
            : updateExisting
                ? "Update existing"
                : string.Equals(finalName, baseName, StringComparison.OrdinalIgnoreCase) ? "Ready" : "Create copy";

        SummaryRows.Add(new EtabsImportSummaryRowViewModel(
            sourceColumn,
            mapping,
            finalName,
            sourceColumn.Pier,
            $"{StoryFrom}-{StoryTo}".Trim('-'),
            LabelTextFilter,
            sourceColumn.SectionType,
            mapping.BoundarySummary,
            mapping.RebarTemplate,
            SelectedForceRowCount,
            status,
            isSkipped,
            updateExisting));

        Raise(nameof(SummaryCreateCount));
        RaiseTierProperties();
        RaiseCommandStates();
    }

    private ColumnInputSnapshot CreateSnapshot(EtabsImportSummaryRowViewModel row)
    {
        var mapping = row.Mapping;
        var selectedForces = GetSelectedForcesForItems(new[] { row.SourceColumn });
        var rowLengthByNameMm = row.SourceColumn.LengthMm > 0
            ? new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase) { [row.SourceColumn.ObjectName] = row.SourceColumn.LengthMm }
            : null;
        var loadCases = BuildSnapshotLoadCases(selectedForces, rowLengthByNameMm);
        var primaryForce = loadCases.FirstOrDefault();

        IReadOnlyList<Point2D> boundary;
        IReadOnlyList<IReadOnlyList<Point2D>> openings = [];
        string importMode = "FrameSection";
        List<string> sourceShells = [];
        List<string> sourceSectionProps = [];
        string? boundaryWarning = null;

        if (mapping.IsIrregular)
        {
            var (irr, ops, shells, props, warn) = BuildIrregularBoundary(row.Pier, row.SourceColumn.Story, mapping);
            boundary = irr;
            openings = ops;
            sourceShells = shells;
            sourceSectionProps = props;
            boundaryWarning = warn;
            importMode = "IrregularPierShell";
        }
        else
        {
            boundary = BuildBoundaryPoints(mapping);
        }

        var rebars = BuildEqualSpacingCustomRebars(mapping, boundary);
        var bbox = PolygonGeometry.BoundingBox(boundary);
        var boundingWidth = mapping.IsCircular ? mapping.Diameter : (mapping.IsIrregular ? bbox.Width : mapping.Width);
        var boundingHeight = mapping.IsCircular ? mapping.Diameter : (mapping.IsIrregular ? bbox.Height : mapping.Height);

        var snapshotFy = selectedImportRebarGrade?.StressValue(selectedImportUnitSystem) ?? 420;
        var snapshotEs = selectedImportRebarGrade?.ModulusValue(selectedImportUnitSystem) ?? 200000;
        var rawLengthRow = row.SourceColumn.LengthMm;
        var rowMemberLength = rawLengthRow > 0
            ? (selectedImportUnitSystem == UnitSystem.Metric ? rawLengthRow / 1000.0 : rawLengthRow / 12.0)
            : (double?)null;
        var snapshot = new ColumnInputSnapshot
        {
            UnitSystem = selectedImportUnitSystem.ToString(),
            DesignCode = selectedImportDesignCode.ToString(),
            Ec2Solver = Ec2SolverType.Fiber.ToString(),
            IntegrationMethod = (mapping.IsRectangular ? SectionIntegrationMethod.Polygon : SectionIntegrationMethod.Fiber).ToString(),
            AlphaCc = 0.85,
            SectionShape = mapping.IsRectangular ? SectionShapeType.Rectangular.ToString()
                         : mapping.IsCircular    ? SectionShapeType.Circular.ToString()
                         :                         SectionShapeType.Irregular.ToString(),
            Width = boundingWidth,
            Height = boundingHeight,
            Diameter = Math.Max(boundingWidth, boundingHeight),
            Cover = mapping.Cover,
            MemberLengthL = rowMemberLength,
            Fc = InferConcreteStrength(mapping.Material),
            Fy = snapshotFy,
            Es = snapshotEs,
            MaterialLibrary = MaterialLibraryType.Custom.ToString(),
            BarSize = mapping.BarSize,
            BarCount = mapping.IsRectangular ? mapping.RectangularBarCount
                     : mapping.IsCircular    ? mapping.TotalBars
                     :                         rebars.Count,
            Spacing = mapping.TieSpacing,
            RebarLayoutType = mapping.IsRectangular ? "SidesDifferent"
                            : mapping.IsCircular    ? "EqualSpacing"
                            :                         "CustomCoordinates",
            TopBarCount    = mapping.IsRectangular ? mapping.BarsAlongWidth  : 0,
            BottomBarCount = mapping.IsRectangular ? mapping.BarsAlongWidth  : 0,
            LeftBarCount   = mapping.IsRectangular ? mapping.BarsAlongHeight : 0,
            RightBarCount  = mapping.IsRectangular ? mapping.BarsAlongHeight : 0,
            IrregularBarSize = mapping.BarSize,
            IrregularSpacing = mapping.TieSpacing,
            IrregularRebarMode = mapping.IsIrregular ? "CustomCoordinates" : "EqualSpacing",
            BoundaryPoints = mapping.IsIrregular
                ? boundary.Select((point, index) => new SnapshotBoundaryPoint
                    {
                        PtIndex = index + 1,
                        X = Math.Round(point.X, 6),
                        Y = Math.Round(point.Y, 6)
                    }).ToList()
                : [],
            OpeningPoints = mapping.IsIrregular
                ? openings.Select(op => op.Select((pt, j) => new SnapshotBoundaryPoint
                    {
                        PtIndex = j + 1,
                        X = Math.Round(pt.X, 6),
                        Y = Math.Round(pt.Y, 6)
                    }).ToList()).ToList()
                : [],
            Rebars = mapping.IsIrregular ? rebars : [],
            Pu = primaryForce?.Pu ?? 0,
            Mux = primaryForce?.Mux ?? 0,
            Muy = primaryForce?.Muy ?? 0,
            PmAngleDegrees = 0,
            AxialLoad = 0,
            LoadCases = loadCases,
            EtabsMetadata = new EtabsImportMetadataDto
            {
                SourceModelPath = ModelPath,
                SourceModelName = ModelName,
                EtabsObjectName = row.SourceColumn.ObjectName,
                PierName = row.Pier,
                StoryName = row.SourceColumn.Story,
                Label = row.Label,
                EtabsSectionName = row.SourceColumn.EtabsSectionName,
                UniqueSectionDisplayName = row.SourceColumn.UniqueSection,
                ImportedAt = DateTime.UtcNow,
                ImportedUnits = PresentUnits,
                MBColumnUnitsAtImport = TargetForceMomentUnitSummary,
                SelectedLoadCombinations = loadCases.Select(lc => lc.Label).ToList(),
                ImportMode = importMode,
                SourceShellNames = sourceShells,
                SourceAreaSectionProperties = sourceSectionProps,
                IrregularBoundaryWarning = boundaryWarning,
                OpeningCount = openings.Count
            }
        };

        return snapshot;
    }

    private ColumnInputSnapshot CreateTierSnapshot(EtabsImportSummaryRowViewModel row)
    {
        var snapshot = CreateSnapshot(row);
        var selectedColumns = Columns.Where(c => c.IsSelected).ToList();
        var selectedForces = GetSelectedForcesForItems(selectedColumns);
        var tierLengthByNameMm = selectedColumns
            .Where(c => c.LengthMm > 0)
            .GroupBy(c => c.ObjectName, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First().LengthMm, StringComparer.OrdinalIgnoreCase);
        var loadCases = BuildSnapshotLoadCases(selectedForces, tierLengthByNameMm.Count > 0 ? tierLengthByNameMm : null);

        var primaryForce = loadCases.FirstOrDefault();
        snapshot.Pu = primaryForce?.Pu ?? 0;
        snapshot.Mux = primaryForce?.Mux ?? 0;
        snapshot.Muy = primaryForce?.Muy ?? 0;
        snapshot.LoadCases = loadCases;
        snapshot.DesignTierName = row.NewSectionName;
        snapshot.DesignTierSource = "ETABS";

        snapshot.EtabsTierMetadata = new EtabsTierImportMetadataDto
        {
            SourceModelPath = ModelPath,
            SourceModelName = ModelName,
            ImportedUnits = PresentUnits,
            MBColumnUnitsAtImport = TargetForceMomentUnitSummary,
            ShapeType = row.SectionType.ToString(),
            SourceSectionName = row.SourceColumn.EtabsSectionName,
            UniqueSectionDisplayName = row.SourceColumn.UniqueSection,
            TargetGroupName = SelectedTargetGroup?.GroupName ?? "",
            TargetGroupId = SelectedTargetGroup?.GroupId,
            TierName = row.NewSectionName,
            StoryFrom = StoryFrom,
            StoryTo = StoryTo,
            LabelFilter = LabelTextFilter,
            SourceObjects = selectedColumns
                .Select(c => new EtabsSourceObjectRefDto
                {
                    ObjectName = c.ObjectName,
                    Label = c.Label,
                    Story = c.Story,
                    SectionName = c.EtabsSectionName
                })
                .ToList(),
            SelectedLoadCombinations = LoadCombinations
                .Where(c => c.IsSelected)
                .Select(c => c.Name)
                .ToList(),
            ImportTop = true,
            ImportBottom = true,
            ImportMid = true,
            ImportedAt = DateTime.UtcNow
        };

        if (snapshot.EtabsMetadata is not null)
        {
            snapshot.EtabsMetadata.SelectedLoadCombinations = snapshot.LoadCases
                .Select(lc => lc.OriginalLoadCaseName)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        return snapshot;
    }

    private (IReadOnlyList<Point2D> Boundary,
             IReadOnlyList<IReadOnlyList<Point2D>> Openings,
             List<string> ShellNames,
             List<string> SectionProps,
             string? Warning)
        BuildIrregularBoundary(string pier, string story, EtabsSectionMappingViewModel mapping)
    {
        if (pierShellImportService is null || irregularGeometryBuilder is null)
        {
            return (BuildBoundaryPoints(mapping), [], [], [],
                "Pier shell service not available — rectangular fallback used.");
        }

        try
        {
            var segments = pierShellImportService.GetSegments(pier, story, targetUnitSystem);
            if (segments.Count == 0)
            {
                return (BuildBoundaryPoints(mapping), [], [], [],
                    $"No shell segments found for pier '{pier}', story '{story}' — rectangular fallback used.");
            }

            var result = irregularGeometryBuilder.BuildBoundary(segments);
            if (result.IsEmpty)
            {
                return (BuildBoundaryPoints(mapping), [],
                    [.. result.SourceShellNames], [.. result.SourceSectionProperties],
                    $"Geometry builder returned empty polygon — rectangular fallback used. {result.WarningMessage}");
            }

            var centeredPoints = result.ClockwisePolylines[0];

            var warning = result.HasMultiplePolylines
                ? $"Warning: {result.ClockwisePolylines.Count} disconnected shell groups — largest polygon used. {result.WarningMessage}"
                : result.WarningMessage;

            if (!string.IsNullOrEmpty(warning))
                MessageBox.Show(warning, "Irregular Section Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            return (centeredPoints,
                result.OpeningPolylines,
                [.. result.SourceShellNames],
                [.. result.SourceSectionProperties],
                warning);
        }
        catch (Exception ex)
        {
            return (BuildBoundaryPoints(mapping), [], [], [],
                $"Irregular boundary failed: {ex.Message} — rectangular fallback used.");
        }
    }

    // -------------------------------------------------------------------
    // Boundary preview for Step 1
    // -------------------------------------------------------------------

    private void UpdateBoundaryPreview()
    {
        var col = SelectedColumn;

        if (col is null)
        {
            rawBoundaryPoints = [];
            BoundaryPreviewPointCollection = null;
            PreviewStatusText = "Select a row to preview boundary.";
            Raise(nameof(HasBoundaryPreview));
            RaiseCanvasProperties();
            return;
        }

        IReadOnlyList<Point2D>? points = null;

        if (col.IsIrregular)
        {
            // Check cache first (no COM call needed)
            if (pierBoundaryCache.TryGetValue(col.UniqueSection, out var cached))
            {
                points = cached.Outer;
            }
            else
            {
                // Compute on background thread — don't block UI
                PreviewStatusText = "Computing pier boundary…";
                BoundaryPreviewPointCollection = null;
                Raise(nameof(HasBoundaryPreview));

                var capturedCol = col;
                _ = Task.Run(() =>
                {
                    var result = GetOrComputePierBoundaryForPreview(capturedCol);
                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Only apply if the user hasn't moved to a different row
                        if (SelectedColumn?.UniqueSection != capturedCol.UniqueSection) return;
                        if (result is { Count: >= 3 })
                        {
                            var opCount = pierBoundaryCache.TryGetValue(capturedCol.UniqueSection, out var c) ? c.Openings.Count : 0;
                            SetPreviewPoints(result, capturedCol.SectionTypeDisplay, opCount);
                        }
                        else
                            PreviewStatusText = "Could not compute pier boundary.";
                        Raise(nameof(HasBoundaryPreview));
                    });
                });
                return;
            }
        }
        else if (col.IsCircular && col.Diameter > 0)
        {
            var radius = col.Diameter / 2.0;
            const int n = 48;
            points = Enumerable.Range(0, n)
                .Select(i =>
                {
                    var angle = Math.PI / 2.0 - 2.0 * Math.PI * i / n;
                    return new Point2D(radius * Math.Cos(angle), radius * Math.Sin(angle));
                })
                .ToList();
        }
        else if (col.IsRectangular && col.Width > 0 && col.Height > 0)
        {
            var hw = col.Width / 2.0;
            var hh = col.Height / 2.0;
            points =
            [
                new Point2D(-hw, hh),
                new Point2D(hw, hh),
                new Point2D(hw, -hh),
                new Point2D(-hw, -hh)
            ];
        }

        if (points is null || points.Count < 3)
        {
            BoundaryPreviewPointCollection = null;
            PreviewStatusText = col.IsIrregular
                ? "Pier boundary not yet computed (connect to ETABS)."
                : "No valid boundary — check section dimensions.";
            Raise(nameof(HasBoundaryPreview));
            return;
        }

        var cachedOpenings = col.IsIrregular && pierBoundaryCache.TryGetValue(col.UniqueSection, out var cv) ? cv.Openings.Count : 0;
        SetPreviewPoints(points, col.SectionTypeDisplay, cachedOpenings);
        Raise(nameof(HasBoundaryPreview));
    }

    private void SetPreviewPoints(IReadOnlyList<Point2D> points, string typeLabel, int openingCount = 0)
    {
        rawBoundaryPoints = points;

        var minX = points.Min(p => p.X);
        var maxX = points.Max(p => p.X);
        var minY = points.Min(p => p.Y);
        var maxY = points.Max(p => p.Y);
        const double margin = 8.0;

        PreviewCanvasWidth = Math.Max(maxX - minX, 1.0) + margin * 2;
        PreviewCanvasHeight = Math.Max(maxY - minY, 1.0) + margin * 2;

        var pc = new PointCollection(points.Count);
        foreach (var pt in points)
        {
            // Flip Y so Y-up math coords render top-to-bottom in canvas coords
            pc.Add(new System.Windows.Point(pt.X - minX + margin, maxY - pt.Y + margin));
        }

        BoundaryPreviewPointCollection = pc;
        var openingSuffix = openingCount > 0 ? $"  ·  {openingCount} opening(s)" : "";
        PreviewStatusText = $"{typeLabel}  ·  {points.Count} pts  ·  {maxX - minX:0.#} x {maxY - minY:0.#} {TargetUnitProfile.SectionSizeLabel}{openingSuffix}";
        RaiseCanvasProperties();
    }

    private IReadOnlyList<Point2D>? GetOrComputePierBoundaryForPreview(EtabsColumnImportRowViewModel column)
    {
        var key = column.UniqueSection;

        if (pierBoundaryCache.TryGetValue(key, out var cached))
            return cached.Outer;

        if (pierShellImportService is null || irregularGeometryBuilder is null)
            return null;

        try
        {
            var segments = pierShellImportService.GetSegments(column.Pier, column.Story, targetUnitSystem);
            if (segments.Count == 0) return null;

            var result = irregularGeometryBuilder.BuildBoundary(segments);
            if (result.IsEmpty) return null;

            var centered = result.ClockwisePolylines[0];

            if (pierBoundaryCache.Count >= PierBoundaryCacheLimit)
                pierBoundaryCache.Clear();
            pierBoundaryCache[key] = (centered, result.OpeningPolylines);
            return centered;
        }
        catch
        {
            return null;
        }
    }

    private static IReadOnlyList<Point2D> NormalizePolygon(IReadOnlyList<Point2D> pts)
    {
        if (pts == null || pts.Count == 0) return [];
        int minIndex = 0;
        for (int i = 1; i < pts.Count; i++)
        {
            if (pts[i].X < pts[minIndex].X || (Math.Abs(pts[i].X - pts[minIndex].X) < 1e-6 && pts[i].Y < pts[minIndex].Y))
            {
                minIndex = i;
            }
        }
        if (minIndex == 0) return pts;
        var shifted = new List<Point2D>(pts.Count);
        for (int i = 0; i < pts.Count; i++)
        {
            shifted.Add(pts[(minIndex + i) % pts.Count]);
        }
        return shifted;
    }

    private static bool ArePolygonsEqual(IReadOnlyList<Point2D> poly1, IReadOnlyList<Point2D> poly2, double tolerance = 0.1)
    {
        if (poly1.Count != poly2.Count) return false;
        var norm1 = NormalizePolygon(poly1);
        var norm2 = NormalizePolygon(poly2);
        for (int i = 0; i < norm1.Count; i++)
        {
            if (Math.Abs(norm1[i].X - norm2[i].X) > tolerance || Math.Abs(norm1[i].Y - norm2[i].Y) > tolerance)
            {
                return false;
            }
        }
        return true;
    }

    private static bool AreOpeningsEqual(IReadOnlyList<IReadOnlyList<Point2D>> open1, IReadOnlyList<IReadOnlyList<Point2D>> open2)
    {
        if (open1.Count != open2.Count) return false;
        var matched = new bool[open2.Count];
        foreach (var o1 in open1)
        {
            bool found = false;
            for (int j = 0; j < open2.Count; j++)
            {
                if (!matched[j] && ArePolygonsEqual(o1, open2[j]))
                {
                    matched[j] = true;
                    found = true;
                    break;
                }
            }
            if (!found) return false;
        }
        return true;
    }

    private static bool AreBoundariesEqual(
        IReadOnlyList<Point2D> outer1, IReadOnlyList<IReadOnlyList<Point2D>> openings1,
        IReadOnlyList<Point2D> outer2, IReadOnlyList<IReadOnlyList<Point2D>> openings2)
    {
        bool empty1 = outer1 == null || outer1.Count < 3;
        bool empty2 = outer2 == null || outer2.Count < 3;
        if (empty1 && empty2) return true;
        if (empty1 || empty2) return false;
        return ArePolygonsEqual(outer1!, outer2!) && AreOpeningsEqual(openings1!, openings2!);
    }

    // -------------------------------------------------------------------

    private static IReadOnlyList<Point2D> BuildBoundaryPoints(EtabsSectionMappingViewModel mapping)
    {
        IReadOnlyList<Point2D> points;
        if (mapping.IsCircular)
        {
            var radius = mapping.Diameter / 2.0;
            const int segmentCount = 32;
            points = Enumerable.Range(0, segmentCount)
                .Select(index =>
                {
                    var angle = Math.PI / 2.0 - 2.0 * Math.PI * index / segmentCount;
                    return new Point2D(
                        Math.Round(radius * Math.Cos(angle), 6),
                        Math.Round(radius * Math.Sin(angle), 6));
                })
                .ToList();
        }
        else
        {
            var halfWidth = mapping.Width / 2.0;
            var halfHeight = mapping.Height / 2.0;
            points =
            [
                new Point2D(-halfWidth, halfHeight),
                new Point2D(halfWidth, halfHeight),
                new Point2D(halfWidth, -halfHeight),
                new Point2D(-halfWidth, -halfHeight)
            ];
        }

        return PolygonGeometry.EnsureClockwise(points);
    }

    private static List<SnapshotRebar> BuildEqualSpacingCustomRebars(
        EtabsSectionMappingViewModel mapping,
        IReadOnlyList<Point2D> boundary)
    {
        var (barDiameter, barArea) = ResolveMetricBar(mapping.BarSize);
        var offset = mapping.Cover + barDiameter / 2.0;
        var insetPolygon = PolygonGeometry.OffsetPolygon(boundary, offset);
        if (insetPolygon.Count < 3)
            return [];

        var spacing = mapping.TieSpacing > 0 ? mapping.TieSpacing : DefaultEtabsSpacingMm;

        if (mapping.IsRectangular)
            return BuildRectangularRebars(insetPolygon, mapping.BarSize, barArea, spacing);

        var perimeter = PolygonPerimeter(insetPolygon);
        if (!double.IsFinite(perimeter) || perimeter <= 0.0 || !double.IsFinite(spacing) || spacing <= 0.0)
            return [];

        var barCount = (int)Math.Max(4, Math.Round(perimeter / spacing));
        var rebars = new List<SnapshotRebar>(barCount);
        for (var index = 0; index < barCount; index++)
        {
            var point = PointAtDistance(insetPolygon, perimeter * index / barCount);
            rebars.Add(new SnapshotRebar
            {
                RebarIndex = (index + 1).ToString(),
                X = Math.Round(point.X, 6),
                Y = Math.Round(point.Y, 6),
                BarSize = mapping.BarSize,
                AreaMm2 = Math.Round(barArea, 6)
            });
        }

        return rebars;
    }

    private static List<SnapshotRebar> BuildRectangularRebars(
        IReadOnlyList<Point2D> insetPolygon,
        string barSize,
        double barArea,
        double spacing)
    {
        if (!double.IsFinite(spacing) || spacing <= 0.0)
            return [];

        var rebars = new List<SnapshotRebar>();
        var n = insetPolygon.Count;
        var rebarIndex = 1;

        for (var i = 0; i < n; i++)
        {
            var start = insetPolygon[i];
            var end = insetPolygon[(i + 1) % n];
            var sideLength = Distance(start, end);

            rebars.Add(new SnapshotRebar
            {
                RebarIndex = (rebarIndex++).ToString(),
                X = Math.Round(start.X, 6),
                Y = Math.Round(start.Y, 6),
                BarSize = barSize,
                AreaMm2 = Math.Round(barArea, 6)
            });

            var nIntermediate = Math.Max(0, (int)Math.Round(sideLength / spacing) - 1);
            for (var j = 1; j <= nIntermediate; j++)
            {
                var t = (double)j / (nIntermediate + 1);
                var pt = new Point2D(
                    start.X + (end.X - start.X) * t,
                    start.Y + (end.Y - start.Y) * t);
                rebars.Add(new SnapshotRebar
                {
                    RebarIndex = (rebarIndex++).ToString(),
                    X = Math.Round(pt.X, 6),
                    Y = Math.Round(pt.Y, 6),
                    BarSize = barSize,
                    AreaMm2 = Math.Round(barArea, 6)
                });
            }
        }

        return rebars;
    }

    private static double PolygonPerimeter(IReadOnlyList<Point2D> polygon)
    {
        var perimeter = 0.0;
        for (var index = 0; index < polygon.Count; index++)
        {
            perimeter += Distance(polygon[index], polygon[(index + 1) % polygon.Count]);
        }

        return perimeter;
    }

    private static Point2D PointAtDistance(IReadOnlyList<Point2D> polygon, double targetDistance)
    {
        var remaining = targetDistance;
        for (var index = 0; index < polygon.Count; index++)
        {
            var start = polygon[index];
            var end = polygon[(index + 1) % polygon.Count];
            var length = Distance(start, end);
            if (remaining <= length || index == polygon.Count - 1)
            {
                var t = length <= 1e-9 ? 0.0 : Math.Clamp(remaining / length, 0.0, 1.0);
                return new Point2D(
                    start.X + (end.X - start.X) * t,
                    start.Y + (end.Y - start.Y) * t);
            }

            remaining -= length;
        }

        return polygon[0];
    }

    private static double Distance(Point2D start, Point2D end)
    {
        var dx = end.X - start.X;
        var dy = end.Y - start.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private static (double Diameter, double Area) ResolveMetricBar(string barSize)
    {
        var match = Regex.Match(barSize, @"T(?<diameter>\d+)", RegexOptions.IgnoreCase);
        if (!match.Success || !double.TryParse(match.Groups["diameter"].Value, out var diameter) || diameter <= 0.0)
        {
            return (DefaultEtabsBarDiameterMm, DefaultEtabsBarAreaMm2);
        }

        var area = diameter switch
        {
            25 => 491.0,
            20 => 314.0,
            _ => Math.PI * diameter * diameter / 4.0
        };

        return (diameter, area);
    }

    private bool FilterColumn(object item)
    {
        if (item is not EtabsColumnImportRowViewModel column) return false;

        if (selectedEtabsElementFilter == EtabsElementFrame && column.IsIrregular) return false;
        if (selectedEtabsElementFilter == EtabsElementShell && !column.IsIrregular) return false;

        if (selectedEtabsElementFilter == EtabsElementFrame && selectedSectionTypeFilter != AllTypes)
        {
            var typeMatch = selectedSectionTypeFilter switch
            {
                TypeRectangular => column.IsRectangular,
                TypeCircular => column.IsCircular,
                _ => true
            };
            if (!typeMatch) return false;
        }

        return MatchesFilter(SelectedStoryFilter, AllStories, column.Story)
               && MatchesFilter(SelectedLabelFilter, AllLabels, column.Label);
    }

    private bool FilterLoadCombination(object item)
    {
        if (item is not EtabsLoadCombinationViewModel combo) return false;
        return string.IsNullOrWhiteSpace(LoadCombinationFilterText)
               || combo.Name.Contains(LoadCombinationFilterText, StringComparison.OrdinalIgnoreCase);
    }

    private static bool MatchesFilter(string selected, string allValue, string value)
        => string.Equals(selected, allValue, StringComparison.OrdinalIgnoreCase)
           || string.Equals(selected, value, StringComparison.OrdinalIgnoreCase);

    private void ResetColumnFilters()
    {
        selectedEtabsElementFilter = EtabsElementFrame;
        Raise(nameof(SelectedEtabsElementFilter));
        Raise(nameof(IsSectionTypeFilterEnabled));
        RefreshSectionTypeFilters();
        RebuildStoryFilters();
    }

    private void RefreshSectionTypeFilters()
    {
        SectionTypeFilters.Clear();

        if (selectedEtabsElementFilter == EtabsElementFrame)
        {
            SectionTypeFilters.Add(AllTypes);
            SectionTypeFilters.Add(TypeRectangular);
            SectionTypeFilters.Add(TypeCircular);
            selectedSectionTypeFilter = AllTypes;
        }
        else
        {
            SectionTypeFilters.Add(TypeIrregularPier);
            selectedSectionTypeFilter = TypeIrregularPier;
        }

        Raise(nameof(SelectedSectionTypeFilter));
    }

    private IEnumerable<EtabsColumnImportRowViewModel> FilteredByType()
    {
        IEnumerable<EtabsColumnImportRowViewModel> source = Columns;

        if (selectedEtabsElementFilter == EtabsElementFrame)
            source = source.Where(c => !c.IsIrregular);
        else if (selectedEtabsElementFilter == EtabsElementShell)
            source = source.Where(c => c.IsIrregular);

        if (selectedEtabsElementFilter == EtabsElementFrame && selectedSectionTypeFilter != AllTypes)
        {
            source = selectedSectionTypeFilter switch
            {
                TypeRectangular => source.Where(c => c.IsRectangular),
                TypeCircular => source.Where(c => c.IsCircular),
                _ => source
            };
        }

        return source;
    }

    private void RebuildStoryFilters()
    {
        ResetFilter(StoryFilters, AllStories, FilteredByType().Select(c => c.Story));
        selectedStoryFilter = AllStories;
        Raise(nameof(SelectedStoryFilter));
        RebuildLabelFilters();
    }

    private void RebuildLabelFilters()
    {
        var src = FilteredByType();
        if (SelectedStoryFilter != AllStories)
            src = src.Where(c => string.Equals(c.Story, SelectedStoryFilter, StringComparison.OrdinalIgnoreCase));

        ResetFilter(LabelFilters, AllLabels, src.Select(c => c.Label));
        selectedLabelFilter = AllLabels;
        Raise(nameof(SelectedLabelFilter));
        FilteredColumns.Refresh();
    }

    private static void ResetFilter(ObservableCollection<string> target, string allValue, IEnumerable<string> values)
    {
        target.Clear();
        target.Add(allValue);
        foreach (var value in values.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(v => v, StringComparer.OrdinalIgnoreCase))
            target.Add(value);
    }

    private void SetAllLoadCombinations(bool isSelected)
    {
        foreach (var combo in LoadCombinations)
        {
            combo.SetSelectedSilently(isSelected);
        }

        GenerateForceRows();
        RaiseCounts();
        RaiseCommandStates();
    }

    private void OnColumnSelectionChanged(EtabsColumnImportRowViewModel row)
    {
        SelectedColumnCount += row.IsSelected ? 1 : -1;
        if (FilterTierObjectCandidate(row))
            MatchedTierObjectCount += row.IsSelected ? 1 : -1;
        RaiseTierProperties();
        RaiseCommandStates();
    }

    private void OnMappingChanged()
    {
        RaiseCommandStates();
    }

    private void OnLoadCombinationSelectionChanged(EtabsLoadCombinationViewModel row)
    {
        SelectedLoadCombinationCount += row.IsSelected ? 1 : -1;
        RaiseCommandStates();
    }

    private void OnForceSelectionChanged(EtabsForceImportRowViewModel row)
    {
        SelectedForceRowCount += row.IsSelected ? 1 : -1;
        TierDemandCaseCount = SelectedForceRowCount;
        RaiseTierProperties();
        RaiseCommandStates();
    }

    private void ApplyStationSelection()
    {
        foreach (var force in ForceRows)
            force.IsSelected = true;

        Raise(nameof(SelectedForceRowCount));
    }

    private static string NormalizeDemandStation(string station, string status)
    {
        if (!string.IsNullOrWhiteSpace(station))
            return station;
        if (status.Contains("bottom", StringComparison.OrdinalIgnoreCase))
            return "Bottom";
        if (status.Contains("mid", StringComparison.OrdinalIgnoreCase))
            return "Mid";
        if (status.Contains("top", StringComparison.OrdinalIgnoreCase))
            return "Top";

        return "Top";
    }

    private static string BuildDemandCaseLabel(string originalLoadCase, string label, string story, string station)
    {
        var parts = new[] { originalLoadCase, label, story, station }
            .Where(part => !string.IsNullOrWhiteSpace(part))
            .Select(SanitizeName);
        return string.Join("-", parts);
    }

    private List<EtabsForceImportRowViewModel> GetSelectedForcesForItems(IEnumerable<EtabsColumnImportRowViewModel> items)
    {
        var itemList = items.ToList();
        if (itemList.Count == 0)
            return [];

        var objectNames = itemList
            .Select(item => item.ObjectName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var storyLabelKeys = itemList
            .Select(BuildStoryLabelKey)
            .Where(key => !string.IsNullOrWhiteSpace(key))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        return ForceRows
            .Where(force => force.IsSelected
                && (objectNames.Contains(force.ObjectName)
                    || storyLabelKeys.Contains(BuildStoryLabelKey(force))))
            .ToList();
    }

    private static List<SnapshotLoadCase> BuildSnapshotLoadCases(
        IReadOnlyList<EtabsForceImportRowViewModel> forces,
        IReadOnlyDictionary<string, double>? objectLengthByNameMm = null)
    {
        var result = new List<SnapshotLoadCase>();
        int index = 0;

        foreach (var group in forces.GroupBy(BuildEndMomentKey, StringComparer.OrdinalIgnoreCase))
        {
            var rows      = group.ToList();
            var topRow    = FindEndMomentRow(rows, top: true)  ?? rows[0];
            var bottomRow = FindEndMomentRow(rows, top: false) ?? rows[0];
            var anyRow    = rows[0];

            double mxTop    = topRow.M2;
            double mxBottom = bottomRow.M2;
            double myTop    = topRow.M3;
            double myBottom = bottomRow.M3;

            // Sign-preserving max-abs: keep the value whose magnitude is larger
            double mxUsed = Math.Abs(mxTop) >= Math.Abs(mxBottom) ? mxTop : mxBottom;
            double myUsed = Math.Abs(myTop) >= Math.Abs(myBottom) ? myTop : myBottom;

            // Most critical axial and shear: largest absolute value, sign preserved
            double pu  = rows.OrderByDescending(r => Math.Abs(r.P )).First().P;
            double vux = rows.OrderByDescending(r => Math.Abs(r.V2)).First().V2;
            double vuy = rows.OrderByDescending(r => Math.Abs(r.V3)).First().V3;

            // Per-case length from the source ETABS column object
            double? lengthOverrideMm = null;
            if (objectLengthByNameMm is not null
                && objectLengthByNameMm.TryGetValue(anyRow.ObjectName, out var objLen)
                && objLen > 0)
            {
                lengthOverrideMm = objLen;
            }

            var sourceLabel = ForceSourceLabel(anyRow);
            result.Add(new SnapshotLoadCase
            {
                Id                   = $"etabs_{++index}",
                OriginalLoadCaseName = anyRow.LoadCombination,
                SourceObjectName     = anyRow.ObjectName,
                SourceObjectLabel    = sourceLabel,
                Story                = anyRow.Story,
                Station              = "",
                Source               = "ETABS",
                Label = BuildDemandCaseLabel(anyRow.LoadCombination, sourceLabel, anyRow.Story, ""),
                Pu   = pu,
                Mux  = mxUsed,
                Muy  = myUsed,
                Vux  = vux,
                Vuy  = vuy,
                MxTop    = mxTop,
                MxBottom = mxBottom,
                MyTop    = myTop,
                MyBottom = myBottom,
                MxUsed   = mxUsed,
                MyUsed   = myUsed,
                IsActive = true,
                MemberLengthOverride = lengthOverrideMm
            });
        }

        return result;
    }

    private static Dictionary<string, (double MxTop, double MxBottom, double MyTop, double MyBottom)>
        BuildEndMomentLookup(IReadOnlyList<EtabsForceImportRowViewModel> forces)
    {
        var lookup = new Dictionary<string, (double, double, double, double)>(StringComparer.OrdinalIgnoreCase);

        foreach (var group in forces.GroupBy(BuildEndMomentKey, StringComparer.OrdinalIgnoreCase))
        {
            var rows = group.ToList();
            if (rows.Count == 0)
                continue;

            var top = FindEndMomentRow(rows, top: true) ?? rows[0];
            var bottom = FindEndMomentRow(rows, top: false) ?? top;
            lookup[group.Key] = (top.M2, bottom.M2, top.M3, bottom.M3);
        }

        return lookup;
    }

    private static EtabsForceImportRowViewModel? FindEndMomentRow(
        IReadOnlyList<EtabsForceImportRowViewModel> rows,
        bool top)
    {
        var named = rows.FirstOrDefault(row =>
        {
            var station = NormalizeDemandStation(row.Station, row.Status);
            return top
                ? station.Equals("Top", StringComparison.OrdinalIgnoreCase)
                : station.Equals("Bottom", StringComparison.OrdinalIgnoreCase)
                  || station.Equals("Bot", StringComparison.OrdinalIgnoreCase);
        });

        if (named is not null)
            return named;

        var numericRows = rows
            .Select(row => (Row: row, Station: TryParseStation(NormalizeDemandStation(row.Station, row.Status))))
            .Where(pair => pair.Station.HasValue)
            .ToList();

        if (numericRows.Count == 0)
            return null;

        return top
            ? numericRows.OrderByDescending(pair => pair.Station!.Value).First().Row
            : numericRows.OrderBy(pair => pair.Station!.Value).First().Row;
    }

    private static double? TryParseStation(string station)
        => double.TryParse(station, NumberStyles.Any, CultureInfo.InvariantCulture, out var value)
            ? value
            : null;

    private static string BuildEndMomentKey(EtabsForceImportRowViewModel force)
        => $"{force.ObjectName.Trim()}|{force.Story.Trim()}|{ForceSourceLabel(force)}|{force.LoadCombination.Trim()}";

    private static string BuildStoryLabelKey(EtabsColumnImportRowViewModel item)
        => BuildStoryLabelKey(item.Story, string.IsNullOrWhiteSpace(item.Label) ? item.Pier : item.Label);

    private static string BuildStoryLabelKey(EtabsForceImportRowViewModel force)
        => BuildStoryLabelKey(force.Story, ForceSourceLabel(force));

    private static string BuildStoryLabelKey(string story, string label)
        => string.IsNullOrWhiteSpace(story) || string.IsNullOrWhiteSpace(label)
            ? ""
            : $"{story.Trim()}|{label.Trim()}";

    private static string ForceSourceLabel(EtabsForceImportRowViewModel force)
        => string.IsNullOrWhiteSpace(force.Label) ? force.Pier : force.Label;

    private void RaiseCounts()
    {
        int selectedCols = 0, matchedTier = 0;
        foreach (var c in Columns)
        {
            if (c.IsSelected) selectedCols++;
            if (FilterTierObjectCandidate(c)) matchedTier++;
        }

        int selectedCombos = LoadCombinations.Count(c => c.IsSelected);
        int selectedForces = ForceRows.Count(f => f.IsSelected);
        int summaryCreate = SummaryRows.Count(r => !r.IsSkipped);

        SelectedColumnCount = selectedCols;
        MatchedTierObjectCount = matchedTier;
        SelectedLoadCombinationCount = selectedCombos;
        SelectedForceRowCount = selectedForces;
        SummaryCreateCount = summaryCreate;
        TierDemandCaseCount = selectedForces;
    }

    private void RaiseTierProperties()
    {
        Raise(nameof(MatchedTierObjectCount));
        Raise(nameof(TierDemandCaseCount));
        Raise(nameof(PreviewTargetGroupName));
        Raise(nameof(PreviewUniqueSectionName));
    }

    private void RaiseColumnPreviewProperties()
    {
        Raise(nameof(ColumnPreviewTitle));
        Raise(nameof(IsColumnPreviewRectangular));
        Raise(nameof(IsColumnPreviewCircular));
        Raise(nameof(ColumnPreviewDimensions));
        Raise(nameof(ColumnPreviewRebar));
        RaiseCanvasProperties();
    }

    private void RaiseCanvasProperties()
    {
        Raise(nameof(BoundaryPreviewPoints));
        Raise(nameof(BoundaryPreviewSectionShape));
        Raise(nameof(BoundaryPreviewWidth));
        Raise(nameof(BoundaryPreviewHeight));
        Raise(nameof(BoundaryPreviewCover));
        Raise(nameof(BoundaryPreviewSectionLabel));
        Raise(nameof(IsBoundaryPreviewValid));
    }

    private void RaiseCommandStates()
    {
        connectCommand.RaiseCanExecuteChanged();
        disconnectCommand.RaiseCanExecuteChanged();
        reloadStoryDefinitionsCommand.RaiseCanExecuteChanged();
        reloadColumnConnectivityCommand.RaiseCanExecuteChanged();
        applyImportCommand.RaiseCanExecuteChanged();
        selectAllCombosCommand.RaiseCanExecuteChanged();
        clearAllCombosCommand.RaiseCanExecuteChanged();
        loadForcesCommand.RaiseCanExecuteChanged();
        goToFlow2Command.RaiseCanExecuteChanged();
    }

    private static string BuildDefaultSectionName(EtabsColumnImportRowViewModel column)
    {
        var raw = !string.IsNullOrWhiteSpace(column.Pier)
            ? $"{column.Pier}_{column.Story}_{column.Label}"
            : !string.IsNullOrWhiteSpace(column.Label)
                ? $"{column.Story}_{column.Label}"
                : $"ETABS_{column.ObjectName}";
        return SanitizeName(raw);
    }

    private static string NextAvailableName(string baseName, HashSet<string> reservedNames)
    {
        if (!reservedNames.Contains(baseName))
        {
            return baseName;
        }

        var index = 2;
        string candidate;
        do
        {
            candidate = $"{baseName}_Import_{index++}";
        }
        while (reservedNames.Contains(candidate));

        return candidate;
    }

    private static string SanitizeName(string raw)
    {
        var chars = raw
            .Trim()
            .Select(c => char.IsLetterOrDigit(c) || c is '_' or '-' ? c : '_')
            .ToArray();
        var result = new string(chars);
        while (result.Contains("__", StringComparison.Ordinal))
        {
            result = result.Replace("__", "_", StringComparison.Ordinal);
        }

        return string.IsNullOrWhiteSpace(result) ? "ETABS_Section" : result.Trim('_');
    }

    private static double InferConcreteStrength(string material)
    {
        var match = Regex.Match(material, @"C(?<strength>\d+)", RegexOptions.IgnoreCase);
        return match.Success && double.TryParse(match.Groups["strength"].Value, out var value)
            ? value
            : 35;
    }

    private static void ExportColumnForceCsv(ImportedEtabsForceDatabase db)
    {
        try
        {
            var col = db.ColumnForces;
            if (!col.HasRecords) return;
            var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "mbcolumn_design_forces.csv");
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(string.Join(",", col.FieldKeys.Select(k => $"\"{k}\"")));
            foreach (var rec in col.Records)
            {
                sb.AppendLine(string.Join(",", col.FieldKeys.Select(k =>
                {
                    var v = rec.Fields.TryGetValue(k, out var val) ? val ?? "" : "";
                    return $"\"{v.Replace("\"", "\"\"")}\"";
                })));
            }
            System.IO.File.WriteAllText(path, sb.ToString(), System.Text.Encoding.UTF8);
        }
        catch { }
    }
}

public sealed class EtabsLoadCombinationViewModel : ViewModelBase
{
    private readonly Action<EtabsLoadCombinationViewModel> selectionChanged;
    private bool isSelected;

    public EtabsLoadCombinationViewModel(string name, Action<EtabsLoadCombinationViewModel> selectionChanged, bool isSelected = false)
    {
        Name = name;
        this.selectionChanged = selectionChanged;
        this.isSelected = isSelected;
    }

    public string Name { get; }

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected == value) return;
            isSelected = value;
            Raise();
            selectionChanged(this);
        }
    }

    public void SetSelectedSilently(bool value)
    {
        if (isSelected == value) return;
        isSelected = value;
        Raise(nameof(IsSelected));
    }
}

public sealed record EtabsDuplicateHandlingOption(EtabsDuplicateHandlingMode Mode, string DisplayName);

public sealed class ProjectGroupOptionViewModel
{
    public ProjectGroupOptionViewModel(int? groupId, string groupName, bool createGroup = false)
    {
        GroupId = groupId;
        GroupName = groupName;
        CreateGroup = createGroup;
    }

    public int? GroupId { get; }
    public string GroupName { get; }
    public bool CreateGroup { get; }
    public string DisplayName => CreateGroup ? $"{GroupName} (new)" : GroupName;
}

public sealed class EtabsUniqueSectionOptionViewModel : ViewModelBase
{
    private readonly Action? onChange;
    private bool isSelected;

    public EtabsUniqueSectionOptionViewModel(
        string sectionName,
        string sourceSectionName,
        SectionShapeType shapeType,
        int objectCount,
        Action? onChange = null)
    {
        SectionName = sectionName;
        SourceSectionName = sourceSectionName;
        ShapeType = shapeType;
        ObjectCount = objectCount;
        this.onChange = onChange;
    }

    public string SectionName { get; }
    public string SourceSectionName { get; }
    public SectionShapeType ShapeType { get; }
    public int ObjectCount { get; }
    public string DisplayName => $"{SectionName} ({ObjectCount} objects)";

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!Set(ref isSelected, value)) return;
            onChange?.Invoke();
        }
    }
}

public sealed class EtabsStoryOptionViewModel : ViewModelBase
{
    private readonly Action? onChange;
    private bool isSelected = true;

    public EtabsStoryOptionViewModel(string storyName, double elevation, int sortIndex, Action? onChange = null)
    {
        StoryName = storyName;
        Elevation = elevation;
        SortIndex = sortIndex;
        this.onChange = onChange;
    }

    public string StoryName { get; }
    public double Elevation { get; }
    public int SortIndex { get; }
    public string DisplayName => StoryName;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!Set(ref isSelected, value)) return;
            onChange?.Invoke();
        }
    }
}

public enum EtabsDuplicateHandlingMode
{
    SkipExisting,
    CreateCopy,
    UpdateExisting
}

public sealed class EtabsImportSummaryRowViewModel
{
    public EtabsImportSummaryRowViewModel(
        EtabsColumnImportRowViewModel sourceColumn,
        EtabsSectionMappingViewModel mapping,
        string newSectionName,
        string pier,
        string story,
        string label,
        SectionShapeType sectionType,
        string dimensions,
        string rebar,
        int loadCaseCount,
        string status,
        bool isSkipped,
        bool updateExisting)
    {
        SourceColumn = sourceColumn;
        Mapping = mapping;
        NewSectionName = newSectionName;
        Pier = pier;
        Story = story;
        Label = label;
        SectionType = sectionType;
        Dimensions = dimensions;
        Rebar = rebar;
        LoadCaseCount = loadCaseCount;
        Status = status;
        IsSkipped = isSkipped;
        UpdateExisting = updateExisting;
    }

    public EtabsColumnImportRowViewModel SourceColumn { get; }
    public EtabsSectionMappingViewModel Mapping { get; }
    public string NewSectionName { get; }
    public string Pier { get; }
    public string Story { get; }
    public string Label { get; }
    public SectionShapeType SectionType { get; }
    public string Dimensions { get; }
    public string Rebar { get; }
    public int LoadCaseCount { get; }
    public string Status { get; }
    public bool IsSkipped { get; }
    public bool UpdateExisting { get; }
}
