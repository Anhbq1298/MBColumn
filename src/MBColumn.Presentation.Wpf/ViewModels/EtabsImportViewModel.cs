using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services.Etabs;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    private readonly IEtabsPierShellImportService? pierShellImportService;
    private readonly IIrregularPierGeometryBuilder? irregularGeometryBuilder;
    private readonly Dictionary<string, IReadOnlyList<Point2D>> pierBoundaryCache = new(StringComparer.OrdinalIgnoreCase);
    private bool pierGroupsLoaded;
    private readonly RelayCommand connectCommand;
    private readonly RelayCommand disconnectCommand;
    private readonly RelayCommand backCommand;
    private readonly RelayCommand nextCommand;
    private readonly RelayCommand cancelCommand;
    private readonly RelayCommand selectAllCombosCommand;
    private readonly RelayCommand clearAllCombosCommand;
    private readonly RelayCommand refreshCombosCommand;

    private int currentStep = 1;
    private bool isConnected;
    private string connectionStatus = "Not connected";
    private string modelName = "-";
    private string modelPath = "-";
    private string presentUnits = "-";
    private int storyCount;
    private int pierCount;
    private int frameObjectCount;
    private string unitConversionMessage = "Connect to ETABS to read model units.";
    private string selectedSectionTypeFilter = AllTypes;
    private string selectedStoryFilter = AllStories;
    private string selectedLabelFilter = AllLabels;
    private string loadCombinationFilterText = "";
    private EtabsColumnImportRowViewModel? selectedColumn;
    private EtabsSectionMappingViewModel? selectedMapping;
    private EtabsDuplicateHandlingOption selectedDuplicateHandling;
    private PointCollection? boundaryPreviewPointCollection;
    private double previewCanvasWidth = 200;
    private double previewCanvasHeight = 200;
    private string previewStatusText = "Select a row to preview boundary.";

    public EtabsImportViewModel(
        IReadOnlyCollection<string> existingSectionNames,
        IEtabsConnectionService connectionService,
        IEtabsColumnImportService columnImportService,
        IEtabsForceImportService forceImportService,
        IEtabsPierShellImportService? pierShellImportService = null,
        IIrregularPierGeometryBuilder? irregularGeometryBuilder = null)
    {
        this.existingSectionNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        this.connectionService = connectionService;
        this.columnImportService = columnImportService;
        this.forceImportService = forceImportService;
        this.pierShellImportService = pierShellImportService;
        this.irregularGeometryBuilder = irregularGeometryBuilder;

        Columns = [];
        FilteredColumns = CollectionViewSource.GetDefaultView(Columns);
        FilteredColumns.Filter = FilterColumn;

        SectionMappings = [];
        LoadCombinations = [];
        FilteredLoadCombinations = CollectionViewSource.GetDefaultView(LoadCombinations);
        FilteredLoadCombinations.Filter = FilterLoadCombination;
        ForceRows = [];
        SummaryRows = [];

        SectionTypeFilters = [AllTypes, TypeRectangular, TypeCircular, TypeIrregularPier];
        StoryFilters = [AllStories];
        LabelFilters = [AllLabels];

        DuplicateHandlingOptions =
        [
            new(EtabsDuplicateHandlingMode.CreateCopy, "Create copy"),
            new(EtabsDuplicateHandlingMode.SkipExisting, "Skip existing"),
            new(EtabsDuplicateHandlingMode.UpdateExisting, "Update existing")
        ];
        selectedDuplicateHandling = DuplicateHandlingOptions[0];

        connectCommand = new RelayCommand(Connect, () => !IsConnected);
        disconnectCommand = new RelayCommand(Disconnect, () => IsConnected);
        backCommand = new RelayCommand(Back, () => CurrentStep > 1);
        nextCommand = new RelayCommand(Next, CanMoveNext);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));
        selectAllCombosCommand = new RelayCommand(() => SetAllLoadCombinations(true), () => LoadCombinations.Count > 0);
        clearAllCombosCommand = new RelayCommand(() => SetAllLoadCombinations(false), () => LoadCombinations.Count > 0);
        refreshCombosCommand = new RelayCommand(RefreshLoadCombinations, () => IsConnected);
    }

    public event EventHandler<bool>? RequestClose;

    public EtabsImportDialogResult? ImportResult { get; private set; }
    public ObservableCollection<EtabsColumnImportRowViewModel> Columns { get; }
    public ICollectionView FilteredColumns { get; }
    public ObservableCollection<EtabsSectionMappingViewModel> SectionMappings { get; }
    public ObservableCollection<EtabsLoadCombinationViewModel> LoadCombinations { get; }
    public ICollectionView FilteredLoadCombinations { get; }
    public ObservableCollection<EtabsForceImportRowViewModel> ForceRows { get; }
    public ObservableCollection<EtabsImportSummaryRowViewModel> SummaryRows { get; }
    public IReadOnlyList<string> SectionTypeFilters { get; }
    public ObservableCollection<string> StoryFilters { get; }
    public ObservableCollection<string> LabelFilters { get; }
    public IReadOnlyList<EtabsDuplicateHandlingOption> DuplicateHandlingOptions { get; }

    public ICommand ConnectCommand => connectCommand;
    public ICommand DisconnectCommand => disconnectCommand;
    public ICommand BackCommand => backCommand;
    public ICommand NextCommand => nextCommand;
    public ICommand CancelCommand => cancelCommand;
    public ICommand SelectAllCombosCommand => selectAllCombosCommand;
    public ICommand ClearAllCombosCommand => clearAllCombosCommand;
    public ICommand RefreshCombosCommand => refreshCombosCommand;

    public int CurrentStep
    {
        get => currentStep;
        private set
        {
            if (currentStep == value) return;
            currentStep = value;
            Raise();
            RaiseStepProperties();
            RaiseCommandStates();
        }
    }

    public bool IsConnected
    {
        get => isConnected;
        private set
        {
            if (isConnected == value) return;
            isConnected = value;
            Raise();
            RaiseCommandStates();
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

    // Section type → Story → Label cascade
    public string SelectedSectionTypeFilter
    {
        get => selectedSectionTypeFilter;
        set
        {
            if (selectedSectionTypeFilter == value) return;
            selectedSectionTypeFilter = value;
            Raise();

            // Lazily load pier groups the first time the user selects this filter
            if (value == TypeIrregularPier && !pierGroupsLoaded && isConnected && pierShellImportService is not null)
            {
                LoadPierGroupsAsync();
                return; // LoadPierGroupsAsync calls RebuildStoryFilters when done
            }

            RebuildStoryFilters();
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
            if (CurrentStep == 3)
            {
                BuildSummaryRows();
            }
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

    public bool IsStep1 => CurrentStep == 1;
    public bool IsStep2 => CurrentStep == 2;
    public bool IsStep3 => CurrentStep == 3;
    public bool IsStep4 => false;
    public string StepTitle => CurrentStep switch
    {
        1 => "Connect & Select Columns",
        2 => "Import Forces",
        _ => "Create Sections"
    };
    public string NextButtonText => CurrentStep == 3 ? "Create Sections" : "Next";
    public int SelectedColumnCount => Columns.Count(c => c.IsSelected);
    public int SelectedLoadCombinationCount => LoadCombinations.Count(c => c.IsSelected);
    public int SelectedForceRowCount => ForceRows.Count(f => f.IsSelected);
    public int SummaryCreateCount => SummaryRows.Count(r => !r.IsSkipped);
    public string ColumnPreviewTitle => SelectedColumn is null
        ? "No column highlighted"
        : $"{SelectedColumn.Pier} / {SelectedColumn.Story} / {SelectedColumn.Label}";
    public bool IsColumnPreviewRectangular => SelectedColumn?.IsRectangular == true;
    public bool IsColumnPreviewCircular => SelectedColumn?.IsCircular == true;
    public string ColumnPreviewDimensions => SelectedColumn is null
        ? "-"
        : SelectedColumn.IsCircular
            ? $"D = {SelectedColumn.Diameter:0.#} mm"
            : SelectedColumn.IsIrregular
                ? "Pier shell (boundary computed from ETABS area objects)"
                : $"b = {SelectedColumn.Width:0.#} mm, h = {SelectedColumn.Height:0.#} mm";
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
        UnitConversionMessage = $"ETABS data will be converted from {info.PresentUnits} to kN, mm.";

        Columns.Clear();
        pierBoundaryCache.Clear();

        // Load frame columns (rectangular + circular)
        try
        {
            foreach (var dto in columnImportService.GetCandidateColumns())
            {
                Columns.Add(new EtabsColumnImportRowViewModel(
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
                    dto.LinkedSection,
                    dto.Status));
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
        ResetColumnFilters();
        SelectedColumn = Columns.FirstOrDefault();
        Raise(nameof(SelectedColumnCount));
        RaiseCommandStates();
    }

    private void LoadPierGroupsAsync()
    {
        pierGroupsLoaded = true; // set early to prevent re-entry
        ConnectionStatus = "Loading pier groups…";

        _ = Task.Run(() =>
        {
            try
            {
                var groups = pierShellImportService!.GetPierGroups();

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    // Remove any stale pier rows first (e.g. from a previous partial load)
                    var staleRows = Columns.Where(c => c.IsIrregular).ToList();
                    foreach (var row in staleRows)
                        Columns.Remove(row);

                    foreach (var (pier, story, sectionProp) in groups)
                    {
                        Columns.Add(new EtabsColumnImportRowViewModel(
                            OnColumnSelectionChanged,
                            $"pier:{pier}:{story}",
                            pier,
                            story,
                            pier,
                            $"{pier}|{story}",
                            pier,
                            sectionProp,
                            SectionShapeType.Irregular,
                            0, 0, 0,
                            "",
                            "Ready"));
                    }

                    ConnectionStatus = groups.Count == 0
                        ? "Connected — no pier groups found."
                        : $"Connected — {groups.Count} pier group(s) loaded.";

                    RebuildStoryFilters();
                    Raise(nameof(SelectedColumnCount));
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
        ForceRows.Clear();
        SummaryRows.Clear();
        pierBoundaryCache.Clear();
        pierGroupsLoaded = false;
        SelectedColumn = null;
        SelectedMapping = null;
        CurrentStep = 1;
        ResetColumnFilters();
        RaiseCounts();
    }

    private void Back()
    {
        if (CurrentStep > 1)
        {
            CurrentStep--;
        }
    }

    private void Next()
    {
        if (CurrentStep == 1)
        {
            BuildSectionMappings();
            RefreshLoadCombinations();
            GenerateForceRows();
            CurrentStep = 2;
            return;
        }

        if (CurrentStep == 2)
        {
            BuildSummaryRows();
            CurrentStep = 3;
            return;
        }

        CreateSections();
    }

    private bool CanMoveNext()
        => CurrentStep switch
        {
            1 => IsConnected && SelectedColumnCount > 0,
            2 => SelectedLoadCombinationCount > 0 && SelectedForceRowCount > 0,
            3 => SummaryCreateCount > 0,
            _ => false
        };

    private void CreateSections()
    {
        var sections = SummaryRows
            .Where(row => !row.IsSkipped)
            .Select(row => new EtabsImportedSectionInput(
                row.NewSectionName,
                CreateSnapshot(row),
                row.UpdateExisting))
            .ToList();

        if (sections.Count == 0)
        {
            return;
        }

        ImportResult = new EtabsImportDialogResult(sections);
        RequestClose?.Invoke(this, true);
    }

    private void BuildSectionMappings()
    {
        var existingMappings = SectionMappings.ToDictionary(m => m.UniqueSection, StringComparer.OrdinalIgnoreCase);
        SectionMappings.Clear();

        foreach (var group in Columns.Where(c => c.IsSelected).GroupBy(c => c.SectionKey))
        {
            var source = group.First();
            if (existingMappings.TryGetValue(source.UniqueSection, out var existing))
            {
                SectionMappings.Add(existing);
                continue;
            }

            var mapping = new EtabsSectionMappingViewModel(
                OnMappingChanged,
                source.EtabsSectionName,
                source.UniqueSection,
                source.SectionType,
                source.Width,
                source.Height,
                source.Diameter,
                source.Material,
                DefaultEtabsBarSize,
                DefaultEtabsCoverMm,
                DefaultEtabsSpacingMm);

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
            foreach (var name in columnImportService.GetLoadCombinations())
            {
                LoadCombinations.Add(new EtabsLoadCombinationViewModel(name, OnLoadCombinationSelectionChanged));
            }
        }
        catch (Exception ex)
        {
            ConnectionStatus = $"Warning: could not load combinations — {ex.Message}";
        }

        FilteredLoadCombinations.Refresh();
        RaiseCounts();
    }

    private void GenerateForceRows()
    {
        ForceRows.Clear();

        var selectedCombos = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList();
        if (selectedCombos.Count == 0)
        {
            RaiseCounts();
            RaiseCommandStates();
            return;
        }

        // Frame column forces
        var selectedFrameColumns = Columns.Where(c => c.IsSelected && !c.IsIrregular).ToList();
        if (selectedFrameColumns.Count > 0)
        {
            try
            {
                var columnDtos = selectedFrameColumns.Select(c => new EtabsColumnImportDto(
                    c.ObjectName, c.Pier, c.Story, c.Label,
                    c.UniqueSection, c.EtabsSectionName, c.Material,
                    c.SectionType, c.Width, c.Height, c.Diameter, c.LinkedSection, c.Status)).ToList();

                foreach (var force in forceImportService.GetForces(columnDtos, selectedCombos))
                    AddForceRow(force);
            }
            catch (Exception ex)
            {
                ConnectionStatus = $"Warning: could not load frame forces — {ex.Message}";
            }
        }

        // Pier forces (Bottom + Top per story+pier+combo)
        var selectedPiers = Columns
            .Where(c => c.IsSelected && c.IsIrregular)
            .Select(c => (c.Pier, c.Story))
            .ToList();

        if (selectedPiers.Count > 0)
        {
            try
            {
                foreach (var force in forceImportService.GetPierForces(selectedPiers, selectedCombos))
                    AddForceRow(force);
            }
            catch (Exception ex)
            {
                ConnectionStatus = $"Warning: could not load pier forces — {ex.Message}";
            }
        }

        RaiseCounts();
        RaiseCommandStates();
    }

    private void AddForceRow(EtabsForceResultDto force)
    {
        ForceRows.Add(new EtabsForceImportRowViewModel(
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
            force.Status));
    }

    private void BuildSummaryRows()
    {
        SummaryRows.Clear();
        var reservedNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var mode = SelectedDuplicateHandling.Mode;

        foreach (var column in Columns.Where(c => c.IsSelected))
        {
            var mapping = SectionMappings.First(m => string.Equals(m.UniqueSection, column.UniqueSection, StringComparison.OrdinalIgnoreCase));
            var baseName = BuildDefaultSectionName(column);
            var exists = existingSectionNames.Contains(baseName);
            var isSkipped = exists && mode == EtabsDuplicateHandlingMode.SkipExisting;
            var updateExisting = exists && mode == EtabsDuplicateHandlingMode.UpdateExisting;
            var finalName = updateExisting ? baseName : NextAvailableName(baseName, reservedNames);
            var loadCaseCount = ForceRows.Count(f => f.IsSelected && f.ObjectName == column.ObjectName);
            var status = isSkipped
                ? "Skipped"
                : updateExisting
                    ? "Update existing"
                    : string.Equals(finalName, baseName, StringComparison.OrdinalIgnoreCase) ? "Ready" : "Create copy";

            if (!isSkipped && !updateExisting)
            {
                reservedNames.Add(finalName);
            }

            SummaryRows.Add(new EtabsImportSummaryRowViewModel(
                column,
                mapping,
                finalName,
                column.Pier,
                column.Story,
                column.Label,
                SectionShapeType.Irregular,
                mapping.BoundarySummary,
                mapping.RebarTemplate,
                loadCaseCount,
                status,
                isSkipped,
                updateExisting));
        }

        Raise(nameof(SummaryCreateCount));
        RaiseCommandStates();
    }

    private ColumnInputSnapshot CreateSnapshot(EtabsImportSummaryRowViewModel row)
    {
        var mapping = row.Mapping;
        var selectedForces = ForceRows
            .Where(force => force.IsSelected && force.ObjectName == row.SourceColumn.ObjectName)
            .ToList();
        var primaryForce = selectedForces.FirstOrDefault();
        var loadCases = selectedForces
            .Select((force, index) => new SnapshotLoadCase
            {
                Id = $"etabs_{index + 1}",
                Label = force.LoadCombination,
                Pu = force.P,
                Mux = force.M2,
                Muy = force.M3,
                IsActive = true
            })
            .ToList();

        IReadOnlyList<Point2D> boundary;
        string importMode = "FrameSection";
        List<string> sourceShells = [];
        List<string> sourceSectionProps = [];
        string? boundaryWarning = null;

        if (mapping.IsIrregular)
        {
            var (irr, shells, props, warn) = BuildIrregularBoundary(row.Pier, row.Story, mapping);
            boundary = irr;
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

        var snapshot = new ColumnInputSnapshot
        {
            UnitSystem = UnitSystem.Metric.ToString(),
            DesignCode = DesignCodeType.Aci318Style.ToString(),
            Ec2Solver = Ec2SolverType.Fiber.ToString(),
            IntegrationMethod = SectionIntegrationMethod.Polygon.ToString(),
            AlphaCc = 0.85,
            SectionShape = SectionShapeType.Irregular.ToString(),
            Width = boundingWidth,
            Height = boundingHeight,
            Diameter = Math.Max(boundingWidth, boundingHeight),
            Cover = mapping.Cover,
            Fc = InferConcreteStrength(mapping.Material),
            Fy = 420,
            Es = 200000,
            MaterialLibrary = MaterialLibraryType.Custom.ToString(),
            BarSize = mapping.BarSize,
            BarCount = rebars.Count,
            Spacing = mapping.TieSpacing,
            RebarLayoutType = "CustomCoordinates",
            TopBarCount = 0,
            BottomBarCount = 0,
            LeftBarCount = 0,
            RightBarCount = 0,
            IrregularBarSize = mapping.BarSize,
            IrregularSpacing = mapping.TieSpacing,
            IrregularRebarMode = "CustomCoordinates",
            BoundaryPoints = boundary
                .Select((point, index) => new SnapshotBoundaryPoint
                {
                    PtIndex = index + 1,
                    X = Math.Round(point.X, 6),
                    Y = Math.Round(point.Y, 6)
                })
                .ToList(),
            Rebars = rebars,
            Pu = primaryForce?.P ?? 0,
            Mux = primaryForce?.M2 ?? 0,
            Muy = primaryForce?.M3 ?? 0,
            PmAngleDegrees = 0,
            AxialLoad = 0,
            LoadCases = loadCases,
            EtabsMetadata = new EtabsImportMetadataDto
            {
                SourceModelPath = ModelPath,
                SourceModelName = ModelName,
                EtabsObjectName = row.SourceColumn.ObjectName,
                PierName = row.Pier,
                StoryName = row.Story,
                Label = row.Label,
                EtabsSectionName = row.SourceColumn.EtabsSectionName,
                UniqueSectionDisplayName = row.SourceColumn.UniqueSection,
                ImportedAt = DateTime.UtcNow,
                ImportedUnits = PresentUnits,
                MBColumnUnitsAtImport = "kN, kNm",
                SelectedLoadCombinations = loadCases.Select(lc => lc.Label).ToList(),
                ImportMode = importMode,
                SourceShellNames = sourceShells,
                SourceAreaSectionProperties = sourceSectionProps,
                IrregularBoundaryWarning = boundaryWarning
            }
        };

        return snapshot;
    }

    private (IReadOnlyList<Point2D> Boundary,
             List<string> ShellNames,
             List<string> SectionProps,
             string? Warning)
        BuildIrregularBoundary(string pier, string story, EtabsSectionMappingViewModel mapping)
    {
        if (pierShellImportService is null || irregularGeometryBuilder is null)
        {
            return (BuildBoundaryPoints(mapping), [], [],
                "Pier shell service not available — rectangular fallback used.");
        }

        try
        {
            var segments = pierShellImportService.GetSegments(pier, story);
            if (segments.Count == 0)
            {
                return (BuildBoundaryPoints(mapping), [], [],
                    $"No shell segments found for pier '{pier}', story '{story}' — rectangular fallback used.");
            }

            var result = irregularGeometryBuilder.BuildBoundary(segments);
            if (result.IsEmpty)
            {
                return (BuildBoundaryPoints(mapping),
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
                [.. result.SourceShellNames],
                [.. result.SourceSectionProperties],
                warning);
        }
        catch (Exception ex)
        {
            return (BuildBoundaryPoints(mapping), [], [],
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
            BoundaryPreviewPointCollection = null;
            PreviewStatusText = "Select a row to preview boundary.";
            Raise(nameof(HasBoundaryPreview));
            return;
        }

        IReadOnlyList<Point2D>? points = null;

        if (col.IsIrregular)
        {
            // Check cache first (no COM call needed)
            if (pierBoundaryCache.TryGetValue(col.UniqueSection, out var cached))
            {
                points = cached;
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
                            SetPreviewPoints(result, capturedCol.SectionTypeDisplay);
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

        SetPreviewPoints(points, col.SectionTypeDisplay);
        Raise(nameof(HasBoundaryPreview));
    }

    private void SetPreviewPoints(IReadOnlyList<Point2D> points, string typeLabel)
    {
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
        PreviewStatusText = $"{typeLabel}  ·  {points.Count} pts  ·  {maxX - minX:0.#} × {maxY - minY:0.#} mm";
    }

    private IReadOnlyList<Point2D>? GetOrComputePierBoundaryForPreview(EtabsColumnImportRowViewModel column)
    {
        var key = column.UniqueSection;

        if (pierBoundaryCache.TryGetValue(key, out var cached))
            return cached;

        if (pierShellImportService is null || irregularGeometryBuilder is null)
            return null;

        try
        {
            var segments = pierShellImportService.GetSegments(column.Pier, column.Story);
            if (segments.Count == 0) return null;

            var result = irregularGeometryBuilder.BuildBoundary(segments);
            if (result.IsEmpty) return null;

            var centered = result.ClockwisePolylines[0];

            pierBoundaryCache[key] = centered;
            return centered;
        }
        catch
        {
            return null;
        }
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

        if (selectedSectionTypeFilter != AllTypes)
        {
            var typeMatch = selectedSectionTypeFilter switch
            {
                TypeRectangular => column.IsRectangular,
                TypeCircular => column.IsCircular,
                TypeIrregularPier => column.IsIrregular,
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
        selectedSectionTypeFilter = AllTypes;
        Raise(nameof(SelectedSectionTypeFilter));
        RebuildStoryFilters();
    }

    private IEnumerable<EtabsColumnImportRowViewModel> FilteredByType()
    {
        if (selectedSectionTypeFilter == AllTypes) return Columns;
        return selectedSectionTypeFilter switch
        {
            TypeRectangular => Columns.Where(c => c.IsRectangular),
            TypeCircular => Columns.Where(c => c.IsCircular),
            TypeIrregularPier => Columns.Where(c => c.IsIrregular),
            _ => Columns
        };
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

    private void OnColumnSelectionChanged()
    {
        Raise(nameof(SelectedColumnCount));
        RaiseCommandStates();
    }

    private void OnMappingChanged()
    {
        if (CurrentStep == 3)
        {
            BuildSummaryRows();
        }

        RaiseCommandStates();
    }

    private void OnLoadCombinationSelectionChanged()
    {
        GenerateForceRows();
        RaiseCounts();
        RaiseCommandStates();
    }

    private void OnForceSelectionChanged()
    {
        Raise(nameof(SelectedForceRowCount));
        RaiseCommandStates();
    }

    private void RaiseCounts()
    {
        Raise(nameof(SelectedColumnCount));
        Raise(nameof(SelectedLoadCombinationCount));
        Raise(nameof(SelectedForceRowCount));
        Raise(nameof(SummaryCreateCount));
    }

    private void RaiseStepProperties()
    {
        Raise(nameof(IsStep1));
        Raise(nameof(IsStep2));
        Raise(nameof(IsStep3));
        Raise(nameof(StepTitle));
        Raise(nameof(NextButtonText));
    }

    private void RaiseColumnPreviewProperties()
    {
        Raise(nameof(ColumnPreviewTitle));
        Raise(nameof(IsColumnPreviewRectangular));
        Raise(nameof(IsColumnPreviewCircular));
        Raise(nameof(ColumnPreviewDimensions));
        Raise(nameof(ColumnPreviewRebar));
    }

    private void RaiseCommandStates()
    {
        connectCommand.RaiseCanExecuteChanged();
        disconnectCommand.RaiseCanExecuteChanged();
        backCommand.RaiseCanExecuteChanged();
        nextCommand.RaiseCanExecuteChanged();
        selectAllCombosCommand.RaiseCanExecuteChanged();
        clearAllCombosCommand.RaiseCanExecuteChanged();
        refreshCombosCommand.RaiseCanExecuteChanged();
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
}

public sealed class EtabsLoadCombinationViewModel : ViewModelBase
{
    private readonly Action selectionChanged;
    private bool isSelected;

    public EtabsLoadCombinationViewModel(string name, Action selectionChanged, bool isSelected = false)
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
            selectionChanged();
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
