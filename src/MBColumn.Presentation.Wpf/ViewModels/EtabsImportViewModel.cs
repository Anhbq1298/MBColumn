using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Domain.Enums;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsImportViewModel : ViewModelBase
{
    private const string AllPiers = "All Piers";
    private const string AllStories = "All Stories";
    private const string AllLabels = "All Labels";
    private const string AllSections = "All Sections";

    private readonly HashSet<string> existingSectionNames;
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
    private string selectedPierFilter = AllPiers;
    private string selectedStoryFilter = AllStories;
    private string selectedLabelFilter = AllLabels;
    private string selectedUniqueSectionFilter = AllSections;
    private string loadCombinationFilterText = "";
    private EtabsColumnImportRowViewModel? selectedColumn;
    private EtabsSectionMappingViewModel? selectedMapping;
    private EtabsDuplicateHandlingOption selectedDuplicateHandling;

    public EtabsImportViewModel(IReadOnlyCollection<string> existingSectionNames)
    {
        this.existingSectionNames = existingSectionNames.ToHashSet(StringComparer.OrdinalIgnoreCase);

        Columns = [];
        FilteredColumns = CollectionViewSource.GetDefaultView(Columns);
        FilteredColumns.Filter = FilterColumn;

        SectionMappings = [];
        LoadCombinations = [];
        FilteredLoadCombinations = CollectionViewSource.GetDefaultView(LoadCombinations);
        FilteredLoadCombinations.Filter = FilterLoadCombination;
        ForceRows = [];
        SummaryRows = [];

        PierFilters = [AllPiers];
        StoryFilters = [AllStories];
        LabelFilters = [AllLabels];
        UniqueSectionFilters = [AllSections];

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
    public ObservableCollection<string> PierFilters { get; }
    public ObservableCollection<string> StoryFilters { get; }
    public ObservableCollection<string> LabelFilters { get; }
    public ObservableCollection<string> UniqueSectionFilters { get; }
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

    public string SelectedPierFilter
    {
        get => selectedPierFilter;
        set
        {
            if (selectedPierFilter == value) return;
            selectedPierFilter = value;
            Raise();
            FilteredColumns.Refresh();
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
            FilteredColumns.Refresh();
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

    public string SelectedUniqueSectionFilter
    {
        get => selectedUniqueSectionFilter;
        set
        {
            if (selectedUniqueSectionFilter == value) return;
            selectedUniqueSectionFilter = value;
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
            RaiseMappingPreviewProperties();
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
            if (CurrentStep == 4)
            {
                BuildSummaryRows();
            }
        }
    }

    public bool IsStep1 => CurrentStep == 1;
    public bool IsStep2 => CurrentStep == 2;
    public bool IsStep3 => CurrentStep == 3;
    public bool IsStep4 => CurrentStep == 4;
    public string StepTitle => CurrentStep switch
    {
        1 => "Connect & Select Columns",
        2 => "Define Section & Rebar",
        3 => "Import Forces",
        _ => "Create Sections"
    };
    public string NextButtonText => CurrentStep == 4 ? "Create Sections" : "Next";
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
            : $"b = {SelectedColumn.Width:0.#} mm, h = {SelectedColumn.Height:0.#} mm";
    public string ColumnPreviewRebar => SelectedColumn is null
        ? "-"
        : SelectedColumn.IsCircular ? "Mock preview: equal angular bars" : "Mock preview: perimeter bars";
    public string MappingPreviewTitle => SelectedMapping is null ? "No mapping selected" : SelectedMapping.UniqueSection;
    public bool IsMappingPreviewRectangular => SelectedMapping?.IsRectangular == true;
    public bool IsMappingPreviewCircular => SelectedMapping?.IsCircular == true;
    public string MappingPreviewDimensions => SelectedMapping?.Dimensions ?? "-";
    public string MappingPreviewRebar => SelectedMapping?.RebarTemplate ?? "-";
    public string ForceConventionNote => "Forces are imported using ETABS local axis convention and converted to MBColumn units. Please verify sign convention before design.";

    private void Connect()
    {
        IsConnected = true;
        ConnectionStatus = "Connected to ETABS (mock data)";
        ModelName = "Office Tower Mock";
        ModelPath = @"C:\Models\Office Tower Mock.edb";
        PresentUnits = "kN, m, C";
        StoryCount = 8;
        PierCount = 3;
        FrameObjectCount = 256;
        UnitConversionMessage = "ETABS data will be converted from kN, m to kN, mm.";

        Columns.Clear();
        foreach (var column in CreateMockColumns())
        {
            Columns.Add(column);
        }

        ResetColumnFilters();
        SelectedColumn = Columns.FirstOrDefault();
        Raise(nameof(SelectedColumnCount));
        RaiseCommandStates();
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
            CurrentStep = 2;
            return;
        }

        if (CurrentStep == 2)
        {
            RefreshLoadCombinations();
            GenerateForceRows();
            CurrentStep = 3;
            return;
        }

        if (CurrentStep == 3)
        {
            BuildSummaryRows();
            CurrentStep = 4;
            return;
        }

        CreateSections();
    }

    private bool CanMoveNext()
        => CurrentStep switch
        {
            1 => IsConnected && SelectedColumnCount > 0,
            2 => SectionMappings.Count > 0 && SectionMappings.All(m => m.HasValidDefinition),
            3 => SelectedLoadCombinationCount > 0 && SelectedForceRowCount > 0,
            4 => SummaryCreateCount > 0,
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
                source.Material);

            if (source.IsRectangular)
            {
                mapping.BarsAlongWidth = source.Width >= 500 ? 5 : 4;
                mapping.BarsAlongHeight = source.Height >= 700 ? 5 : 4;
            }
            else
            {
                mapping.TotalBars = source.Diameter >= 800 ? 16 : 12;
            }

            SectionMappings.Add(mapping);
        }

        SelectedMapping = SectionMappings.FirstOrDefault();
        RaiseCommandStates();
    }

    private void RefreshLoadCombinations()
    {
        if (LoadCombinations.Count > 0)
        {
            return;
        }

        LoadCombinations.Add(new EtabsLoadCombinationViewModel("1.2D + 1.6L", OnLoadCombinationSelectionChanged, true));
        LoadCombinations.Add(new EtabsLoadCombinationViewModel("1.2D + 1.0Ex + 0.3L", OnLoadCombinationSelectionChanged, true));
        LoadCombinations.Add(new EtabsLoadCombinationViewModel("1.2D + 1.0Ey + 0.3L", OnLoadCombinationSelectionChanged, true));
        LoadCombinations.Add(new EtabsLoadCombinationViewModel("0.9D + 1.0Ex", OnLoadCombinationSelectionChanged));
        LoadCombinations.Add(new EtabsLoadCombinationViewModel("0.9D + 1.0Ey", OnLoadCombinationSelectionChanged));
        LoadCombinations.Add(new EtabsLoadCombinationViewModel("1.4D", OnLoadCombinationSelectionChanged));
        FilteredLoadCombinations.Refresh();
        RaiseCounts();
    }

    private void GenerateForceRows()
    {
        ForceRows.Clear();

        var selectedColumns = Columns.Where(c => c.IsSelected).ToList();
        var selectedCombos = LoadCombinations.Where(c => c.IsSelected).Select(c => c.Name).ToList();

        for (var columnIndex = 0; columnIndex < selectedColumns.Count; columnIndex++)
        {
            var column = selectedColumns[columnIndex];
            for (var comboIndex = 0; comboIndex < selectedCombos.Count; comboIndex++)
            {
                var combo = selectedCombos[comboIndex];
                var shapeFactor = column.IsCircular ? 1.12 : 1.0;
                var p = Math.Round((1750 + columnIndex * 210 + comboIndex * 160) * shapeFactor, 1);
                var m2 = Math.Round(105.0 + columnIndex * 18.0 + comboIndex * 22.0, 1);
                var m3 = Math.Round(88.0 + columnIndex * 16.0 + comboIndex * 19.0, 1);
                var v2 = Math.Round(35.0 + columnIndex * 4.0 + comboIndex * 5.0, 1);
                var v3 = Math.Round(29.0 + columnIndex * 3.0 + comboIndex * 4.0, 1);

                ForceRows.Add(new EtabsForceImportRowViewModel(
                    OnForceSelectionChanged,
                    column.ObjectName,
                    column.Pier,
                    column.Story,
                    column.Label,
                    column.EtabsSectionName,
                    combo,
                    p,
                    m2,
                    m3,
                    v2,
                    v3,
                    "Ready"));
            }
        }

        RaiseCounts();
        RaiseCommandStates();
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
                mapping.SectionType,
                mapping.Dimensions,
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

        var isCircular = mapping.SectionType == SectionShapeType.Circular;
        var barCount = isCircular ? mapping.TotalBars : mapping.RectangularBarCount;
        var snapshot = new ColumnInputSnapshot
        {
            UnitSystem = UnitSystem.Metric.ToString(),
            DesignCode = DesignCodeType.Aci318Style.ToString(),
            Ec2Solver = Ec2SolverType.Fiber.ToString(),
            IntegrationMethod = SectionIntegrationMethod.Fiber.ToString(),
            AlphaCc = 0.85,
            SectionShape = mapping.SectionType.ToString(),
            Width = isCircular ? mapping.Diameter : mapping.Width,
            Height = isCircular ? mapping.Diameter : mapping.Height,
            Diameter = isCircular ? mapping.Diameter : Math.Max(mapping.Width, mapping.Height),
            Cover = mapping.Cover,
            Fc = InferConcreteStrength(mapping.Material),
            Fy = 420,
            Es = 200000,
            MaterialLibrary = MaterialLibraryType.Custom.ToString(),
            BarSize = mapping.BarSize,
            BarCount = barCount,
            Spacing = mapping.TieSpacing,
            RebarLayoutType = isCircular ? "EqualSpacing" : "SidesDifferent",
            TopBarCount = isCircular ? 0 : mapping.BarsAlongWidth,
            BottomBarCount = isCircular ? 0 : mapping.BarsAlongWidth,
            LeftBarCount = isCircular ? 0 : mapping.BarsAlongHeight,
            RightBarCount = isCircular ? 0 : mapping.BarsAlongHeight,
            IrregularBarSize = mapping.BarSize,
            IrregularSpacing = mapping.TieSpacing,
            IrregularRebarMode = "EqualSpacing",
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
                MBColumnUnitsAtImport = "kN, mm",
                SelectedLoadCombinations = loadCases.Select(lc => lc.Label).ToList()
            }
        };

        return snapshot;
    }

    private bool FilterColumn(object item)
    {
        if (item is not EtabsColumnImportRowViewModel column) return false;
        return MatchesFilter(SelectedPierFilter, AllPiers, column.Pier)
               && MatchesFilter(SelectedStoryFilter, AllStories, column.Story)
               && MatchesFilter(SelectedLabelFilter, AllLabels, column.Label)
               && MatchesFilter(SelectedUniqueSectionFilter, AllSections, column.UniqueSection);
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

    private IReadOnlyList<EtabsColumnImportRowViewModel> CreateMockColumns()
        =>
        [
            new(OnColumnSelectionChanged, "C-L01-025", "P1", "L01", "C25", "Rectangular 400 x 600", "R400X600", "C35", SectionShapeType.Rectangular, 400, 600, 0, "", "Ready"),
            new(OnColumnSelectionChanged, "C-L02-025", "P1", "L02", "C25", "Rectangular 400 x 600", "R400X600", "C35", SectionShapeType.Rectangular, 400, 600, 0, "", "Ready"),
            new(OnColumnSelectionChanged, "C-L03-009", "P2", "L03", "C9", "Rectangular 500 x 700", "R500X700", "C40", SectionShapeType.Rectangular, 500, 700, 0, "", "Ready"),
            new(OnColumnSelectionChanged, "CW-L04-P2", "CoreWall", "L04", "P2", "Rectangular 600 x 900", "CORE600X900", "C45", SectionShapeType.Rectangular, 600, 900, 0, "", "Ready"),
            new(OnColumnSelectionChanged, "C-L05-002", "", "L05", "C2", "Circular D600", "CIRC600", "C35", SectionShapeType.Circular, 0, 0, 600, "", "Ready"),
            new(OnColumnSelectionChanged, "C-L06-010", "P2", "L06", "C10", "Circular D800", "CIRC800", "C45", SectionShapeType.Circular, 0, 0, 800, "", "Ready")
        ];

    private void ResetColumnFilters()
    {
        ResetFilter(PierFilters, AllPiers, Columns.Select(c => c.Pier).Where(v => !string.IsNullOrWhiteSpace(v)));
        ResetFilter(StoryFilters, AllStories, Columns.Select(c => c.Story));
        ResetFilter(LabelFilters, AllLabels, Columns.Select(c => c.Label));
        ResetFilter(UniqueSectionFilters, AllSections, Columns.Select(c => c.UniqueSection));
        selectedPierFilter = AllPiers;
        selectedStoryFilter = AllStories;
        selectedLabelFilter = AllLabels;
        selectedUniqueSectionFilter = AllSections;
        Raise(nameof(SelectedPierFilter));
        Raise(nameof(SelectedStoryFilter));
        Raise(nameof(SelectedLabelFilter));
        Raise(nameof(SelectedUniqueSectionFilter));
        FilteredColumns.Refresh();
    }

    private static void ResetFilter(ObservableCollection<string> target, string allValue, IEnumerable<string> values)
    {
        target.Clear();
        target.Add(allValue);
        foreach (var value in values.Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(v => v, StringComparer.OrdinalIgnoreCase))
        {
            target.Add(value);
        }
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
        RaiseMappingPreviewProperties();
        if (CurrentStep == 4)
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
        Raise(nameof(IsStep4));
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

    private void RaiseMappingPreviewProperties()
    {
        Raise(nameof(MappingPreviewTitle));
        Raise(nameof(IsMappingPreviewRectangular));
        Raise(nameof(IsMappingPreviewCircular));
        Raise(nameof(MappingPreviewDimensions));
        Raise(nameof(MappingPreviewRebar));
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
