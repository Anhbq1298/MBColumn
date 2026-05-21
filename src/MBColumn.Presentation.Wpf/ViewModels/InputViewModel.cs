using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Services;
using MBColumn.Application.Services.ImportExport;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using MBColumn.Application.Services.Geometry;
using MBColumn.Domain.Entities;
using MBColumn.Presentation.Wpf.Services;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class InputViewModel : ViewModelBase
{
    private UnitSystem unitSystem = UnitSystem.Metric;
    private DesignCodeType selectedDesignCode = DesignCodeType.Aci318Style;
    private Ec2SolverType selectedEc2Solver = Ec2SolverType.Fiber;
    private SectionIntegrationMethod selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
    private readonly IRebarDatabase metricBars;
    private readonly IRebarDatabase imperialBars;
    private readonly IRebarCoordinateBuilderService rebarCoordinateBuilder;
    private readonly IDxfImportDialogService? dxfImportDialogService;
    private double width;
    private double height;
    private double diameter;
    private double cover;
    private string barSize = "";
    private int barCount;
    private double spacing = 150.0;
    private string layoutPreset = "Perimeter bars";
    private SectionShapeType selectedSectionShape = SectionShapeType.Rectangular;
    private RebarLayoutType selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
    private MaterialLibraryType selectedMaterialLibrary = MaterialLibraryType.America;
    private MaterialGradeOption? selectedConcreteGrade;
    private MaterialGradeOption? selectedSteelGrade;
    private double fc;
    private double fy;
    private double es;
    private double pu;
    private double mux;
    private double muy;
    private double selectedPmAngleDegrees;
    private double selectedAxialLoad;
    private string sectionPreviewLabel = "";
    private string rebarPreviewLabel = "";
    private string coverPreviewLabel = "";
    private bool isSectionPreviewValid;
    private string sectionPreviewErrorMessage = "";
    private string rebarLayoutWarning = "";
    private double alphaCc = 0.85;
    private bool _isUpdatingPreview = false;
    private string previewAreaText = "—";
    private string previewIxxText = "—";
    private string previewIyyText = "—";
    private string previewRebarPercentageText = "—";
    private string previewShapeSummaryText = "";
    private string previewRebarLayoutText = "";
    private int _generatingRebarsDepth = 0;
    private bool _isGeneratingRebars => _generatingRebarsDepth > 0;
    private bool isDxfImportedSection = false;
    private int nextLoadCaseIndex = 2;
    private bool isApplyingMaterialPreset = false;

    private static readonly IReadOnlyList<MaterialGradeOption> AmericanConcreteGrades =
    [
        new("3 ksi / 21 MPa", 21.0, 3.0),
        new("4 ksi / 28 MPa", 28.0, 4.0),
        new("5 ksi / 35 MPa", 35.0, 5.0),
        new("6 ksi / 42 MPa", 42.0, 6.0),
        new("8 ksi / 55 MPa", 55.0, 8.0),
        new("10 ksi / 69 MPa", 69.0, 10.0),
        new("12 ksi / 83 MPa", 83.0, 12.0)
    ];

    private static readonly IReadOnlyList<MaterialGradeOption> EuropeanConcreteGrades =
    [
        new("C20/25", 20.0),
        new("C25/30", 25.0),
        new("C30/37", 30.0),
        new("C35/45", 35.0),
        new("C40/50", 40.0),
        new("C45/55", 45.0),
        new("C50/60", 50.0),
        new("C55/67", 55.0),
        new("C60/75", 60.0),
        new("C70/85", 70.0),
        new("C80/95", 80.0),
        new("C90/105", 90.0)
    ];

    private static readonly IReadOnlyList<MaterialGradeOption> AmericanSteelGrades =
    [
        new("Grade 40 / 280 MPa", 280.0, 40.0, 200000.0, 29000.0),
        new("Grade 60 / 420 MPa", 420.0, 60.0, 200000.0, 29000.0),
        new("Grade 75 / 520 MPa", 520.0, 75.0, 200000.0, 29000.0),
        new("Grade 80 / 550 MPa", 550.0, 80.0, 200000.0, 29000.0),
        new("Grade 100 / 690 MPa", 690.0, 100.0, 200000.0, 29000.0)
    ];

    private static readonly IReadOnlyList<MaterialGradeOption> EuropeanSteelGrades =
    [
        new("B400", 400.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500A", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500B", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B500C", 500.0, MetricModulus: 200000.0, ImperialModulus: 29000.0),
        new("B550", 550.0, MetricModulus: 200000.0, ImperialModulus: 29000.0)
    ];

    public InputViewModel(IRebarDatabase metricBars, IRebarDatabase imperialBars)
        : this(metricBars, imperialBars, new RebarCoordinateBuilderService(new UnitConversionService(), metricBars, imperialBars))
    {
    }

    public InputViewModel(
        IRebarDatabase metricBars,
        IRebarDatabase imperialBars,
        IRebarCoordinateBuilderService rebarCoordinateBuilder,
        IDxfImportDialogService? dxfImportDialogService = null)
    {
        this.metricBars = metricBars;
        this.imperialBars = imperialBars;
        this.rebarCoordinateBuilder = rebarCoordinateBuilder;
        this.dxfImportDialogService = dxfImportDialogService;
        RebarLayout = new RebarLayoutViewModel(UpdateSectionPreview);
        IrregularInput = new IrregularSectionInputViewModel(new IrregularSectionCsvService());
        IrregularInput.BoundaryPoints.CollectionChanged += (_, _) => { if (!_isGeneratingRebars) UpdateSectionPreview(); };
        IrregularInput.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(IrregularSectionInputViewModel.RebarMode))
            {
                SyncRebarLayoutTypeFromIrregularMode();
            }

            if (args.PropertyName == nameof(IrregularSectionInputViewModel.Spacing) ||
                args.PropertyName == nameof(IrregularSectionInputViewModel.BarSize) ||
                args.PropertyName == nameof(IrregularSectionInputViewModel.RebarMode))
            {
                UpdateSectionPreview();
            }
        };
        WireRebarsCollectionChanged();
        ApplyMetricDefaults();
        UpdateSectionPreview();
        AddLoadCaseCommand = new RelayCommand(AddLoadCase);
        DeleteLoadCaseCommand = new RelayCommand<LoadCaseViewModel>(DeleteLoadCase);
        DeleteSelectedLoadCasesCommand = new RelayCommand<object>(DeleteSelectedLoadCases);
        RemoveDuplicateLoadCasesCommand = new RelayCommand(RemoveDuplicateLoadCases);
        GenerateIrregularRebarsCommand = new RelayCommand(GenerateIrregularRebars);
        GenerateEqualSpacingRebarsCommand = new RelayCommand(GenerateEqualSpacingRebars);
        ImportDxfCommand = new RelayCommand(ImportDxf, () => this.dxfImportDialogService is not null);
    }

    public IReadOnlyList<UnitSystem> UnitSystems { get; } = [UnitSystem.Metric, UnitSystem.Imperial];
    public ICommand GenerateIrregularRebarsCommand { get; }
    public ICommand GenerateEqualSpacingRebarsCommand { get; }
    public ICommand ImportDxfCommand { get; }
    public IReadOnlyList<DesignCodeOption> DesignCodes { get; } =
    [
        new(DesignCodeType.Aci318Style, "ACI 318"),
        new(DesignCodeType.Ec2,         "Eurocode 2")
    ];
    public IReadOnlyList<MaterialLibraryOption> MaterialLibraries { get; } =
    [
        new(MaterialLibraryType.America, "America"),
        new(MaterialLibraryType.Europe, "Europe"),
        new(MaterialLibraryType.Custom, "Custom")
    ];

    public MaterialLibraryType SelectedMaterialLibrary
    {
        get => selectedMaterialLibrary;
        set
        {
            if (selectedMaterialLibrary == value) return;
            selectedMaterialLibrary = value;
            Raise();
            Raise(nameof(AreMaterialGradesEnabled));
            Raise(nameof(AreMaterialInputsEnabled));
            SelectDefaultMaterialGrades(applyValues: true);
        }
    }

    public IReadOnlyList<MaterialGradeOption> AvailableConcreteGrades => ConcreteGradesFor(selectedMaterialLibrary);
    public IReadOnlyList<MaterialGradeOption> AvailableSteelGrades => SteelGradesFor(selectedMaterialLibrary);
    public bool AreMaterialGradesEnabled => selectedMaterialLibrary != MaterialLibraryType.Custom;
    public bool AreMaterialInputsEnabled => selectedMaterialLibrary == MaterialLibraryType.Custom;

    public MaterialGradeOption? SelectedConcreteGrade
    {
        get => selectedConcreteGrade;
        set
        {
            if (Equals(selectedConcreteGrade, value)) return;
            selectedConcreteGrade = value;
            Raise();
            if (value is not null)
            {
                ApplyConcreteGrade(value);
            }
        }
    }

    public MaterialGradeOption? SelectedSteelGrade
    {
        get => selectedSteelGrade;
        set
        {
            if (Equals(selectedSteelGrade, value)) return;
            selectedSteelGrade = value;
            Raise();
            if (value is not null)
            {
                ApplySteelGrade(value);
            }
        }
    }

    public DesignCodeType SelectedDesignCode
    {
        get => selectedDesignCode;
        set
        {
            if (selectedDesignCode == value) return;
            Set(ref selectedDesignCode, value);
            Raise(nameof(FcLabel));
            Raise(nameof(FyLabel));
            Raise(nameof(ShowEc2SolverOption));
            Raise(nameof(ShowAlphaCcOption));
        }
    }
    public string FcLabel => selectedDesignCode == DesignCodeType.Ec2 ? "fck" : "f'c";
    public string FyLabel => selectedDesignCode == DesignCodeType.Ec2 ? "fyk" : "fy";

    public IReadOnlyList<Ec2SolverOption> Ec2SolverOptions { get; } =
    [
        new(Ec2SolverType.Fiber, "Fiber")
    ];

    public Ec2SolverType SelectedEc2Solver
    {
        get => selectedEc2Solver;
        set => Set(ref selectedEc2Solver, value);
    }

    public bool ShowEc2SolverOption => selectedDesignCode == DesignCodeType.Ec2;

    public double AlphaCc { get => alphaCc; set => Set(ref alphaCc, value); }
    public bool ShowAlphaCcOption => selectedDesignCode == DesignCodeType.Ec2;
    public IReadOnlyList<SectionIntegrationMethodOption> SectionIntegrationMethodOptions { get; } =
    [
        new(SectionIntegrationMethod.Fiber, "Fiber Integration"),
        new(SectionIntegrationMethod.Polygon, "Polygon Integration")
    ];

    public SectionIntegrationMethod SelectedIntegrationMethod
    {
        get => selectedIntegrationMethod;
        set => Set(ref selectedIntegrationMethod, value);
    }

    public IReadOnlyList<RebarLayoutTypeOption> RebarLayoutTypes =>
        IsCircularSection
            ? [
                new(RebarLayoutType.EqualSpacing, "Equal Spacing"),
                new(RebarLayoutType.CustomCoordinates, "Custom Coordinates")
              ]
            : [
                new(RebarLayoutType.AllSidesEqual, "All Sides Equal"),
                new(RebarLayoutType.SidesDifferent, "Sides Different"),
                new(RebarLayoutType.CustomCoordinates, "Custom Coordinates")
              ];
    public IReadOnlyList<string> LayoutPresets { get; } = ["4 corner bars", "Perimeter bars"];
    public IReadOnlyList<SectionShapeType> SectionShapes { get; } =
        [SectionShapeType.Rectangular, SectionShapeType.Circular, SectionShapeType.Irregular];
    public IReadOnlyList<RebarDefinition> AvailableBars => UnitSystem == UnitSystem.Metric ? metricBars.GetBars() : imperialBars.GetBars();
    public string LengthLabel => UnitSystem == UnitSystem.Metric ? "mm" : "in";
    public string ForceLabel => UnitSystem == UnitSystem.Metric ? "kN" : "kip";
    public string MomentLabel => UnitSystem == UnitSystem.Metric ? "kN-m" : "kip-ft";
    public string StressLabel => UnitSystem == UnitSystem.Metric ? "MPa" : "ksi";

    public UnitSystem UnitSystem
    {
        get => unitSystem;
        set
        {
            if (unitSystem == value) return;
            unitSystem = value;
            if (unitSystem == UnitSystem.Metric) ApplyMetricDefaults(); else ApplyImperialDefaults();
            Raise(nameof(UnitSystem));
            Raise(nameof(AvailableBars));
            Raise(nameof(LengthLabel));
            Raise(nameof(ForceLabel));
            Raise(nameof(MomentLabel));
            Raise(nameof(StressLabel));
            Raise(nameof(SelectedUnitSystem));
            UpdateSectionPreview();
        }
    }

    public SectionShapeType SelectedSectionShape
    {
        get => selectedSectionShape;
        set
        {
            if (selectedSectionShape == value) return;
            selectedSectionShape = value;
            isDxfImportedSection = false;
            
            ResetShapeDefaults(value);

            Raise();
            Raise(nameof(IsRectangularSection));
            Raise(nameof(IsCircularSection));
            Raise(nameof(IsIrregularSection));
            Raise(nameof(IsCircularEqualSpacingLayout));
            Raise(nameof(IsEqualSpacingLayout));
            Raise(nameof(IsAllSidesEqualLayout));
            Raise(nameof(IsSidesDifferentLayout));
            Raise(nameof(IsRectangularEqualSpacingLayout));
            Raise(nameof(SectionWidth));
            Raise(nameof(SectionHeight));
            Raise(nameof(RebarLayoutTypes));
            Raise(nameof(Diameter));
            Raise(nameof(Width));
            Raise(nameof(Height));
            Raise(nameof(Cover));
            Raise(nameof(BarSize));
            Raise(nameof(BarCount));
            Raise(nameof(LayoutPreset));
            Raise(nameof(SelectedRebarLayout));
            Raise(nameof(SelectedRebarLayoutType));
            Raise(nameof(ShowTotalBarsInput));
            Raise(nameof(Spacing));
            Raise(nameof(IsCustomRebarCoordinates));
            Raise(nameof(IsRebarCoordinatesEditable));
            UpdateSectionPreview();
        }
    }

    private void ResetShapeDefaults(SectionShapeType shape)
    {
        bool isMetric = UnitSystem == UnitSystem.Metric;
        if (shape == SectionShapeType.Rectangular)
        {
            width = isMetric ? 700 : 28;
            height = isMetric ? 700 : 28;
            cover = isMetric ? 55 : 2.2;
            barSize = isMetric ? "T25" : "#8";
            barCount = 28;
            selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
            layoutPreset = "All Sides Equal";
            SyncSideGlobalInputs();
            SeedSideCountsFromTotalBars();
        }
        else if (shape == SectionShapeType.Circular)
        {
            diameter = isMetric ? 700 : 28;
            cover = isMetric ? 55 : 2.2;
            barSize = isMetric ? "T25" : "#8";
            barCount = 28;
            selectedRebarLayoutType = RebarLayoutType.EqualSpacing;
            layoutPreset = "Equal Spacing";
            spacing = isMetric ? 150 : 6;
            GenerateEqualSpacingRebars();
        }
        else if (shape == SectionShapeType.Irregular)
        {
            cover = isMetric ? 55 : 2.2;
            selectedRebarLayoutType = RebarLayoutType.EqualSpacing;
            layoutPreset = "Equal Spacing";
            IrregularInput.BarSize = isMetric ? "T25" : "#8";
            IrregularInput.Spacing = isMetric ? 150 : 6;
            IrregularInput.RebarMode = IrregularRebarModeType.EqualSpacing;
            _generatingRebarsDepth++;
            try
            {
                IrregularInput.LoadDefaultLShape();
            }
            finally
            {
                _generatingRebarsDepth--;
            }
            GenerateIrregularRebars();
        }
    }
    public bool IsRectangularSection
    {
        get => SelectedSectionShape == SectionShapeType.Rectangular;
        set { if (value) SelectedSectionShape = SectionShapeType.Rectangular; }
    }
    public bool IsCircularSection
    {
        get => SelectedSectionShape == SectionShapeType.Circular;
        set { if (value) SelectedSectionShape = SectionShapeType.Circular; }
    }
    public double Width { get => width; set { Set(ref width, value); Raise(nameof(SectionWidth)); UpdateSectionPreview(); } }
    public double Height { get => height; set { Set(ref height, value); Raise(nameof(SectionHeight)); UpdateSectionPreview(); } }
    public double Diameter { get => diameter; set { Set(ref diameter, value); Raise(nameof(SectionWidth)); Raise(nameof(SectionHeight)); UpdateSectionPreview(); } }
    public double Cover { get => cover; set { Set(ref cover, value); SyncSideGlobalInputs(); UpdateSectionPreview(); } }
    public string BarSize { get => barSize; set { Set(ref barSize, value); Raise(nameof(SelectedRebarSize)); SyncSideGlobalInputs(); UpdateSectionPreview(); } }
    public int BarCount { get => barCount; set { Set(ref barCount, value); Raise(nameof(NumberOfBars)); SyncEqualSideCounts(); UpdateSectionPreview(); } }
    public string LayoutPreset { get => layoutPreset; set { Set(ref layoutPreset, value); Raise(nameof(SelectedRebarLayout)); UpdateSectionPreview(); } }
    public RebarLayoutType SelectedRebarLayoutType
    {
        get => selectedRebarLayoutType;
        set
        {
            if (selectedRebarLayoutType == value) return;
            selectedRebarLayoutType = value;
            layoutPreset = value switch
            {
                RebarLayoutType.AllSidesEqual => "All Sides Equal",
                RebarLayoutType.EqualSpacing => "Equal Spacing",
                RebarLayoutType.CustomCoordinates => "Custom Coordinates",
                _ => "Sides Different"
            };
            if (selectedRebarLayoutType == RebarLayoutType.SidesDifferent)
            {
                SeedSideCountsFromTotalBars();
            }

            if (value == RebarLayoutType.CustomCoordinates)
            {
                IrregularInput.RebarMode = IrregularRebarModeType.CustomCoordinates;
                IrregularInput.RebarValidationMessage = "";
            }
            else
            {
                IrregularInput.RebarMode = IrregularRebarModeType.EqualSpacing;
            }

            Raise();
            Raise(nameof(IsEqualSpacingLayout));
            Raise(nameof(IsAllSidesEqualLayout));
            Raise(nameof(IsSidesDifferentLayout));
            Raise(nameof(LayoutPreset));
            Raise(nameof(SelectedRebarLayout));
            Raise(nameof(IsCustomRebarCoordinates));
            Raise(nameof(IsAlgorithmicRebarCoordinates));
            Raise(nameof(IsRebarCoordinatesEditable));
            UpdateSectionPreview();
        }
    }
    public double Fc
    {
        get => fc;
        set
        {
            Set(ref fc, value);
            if (!isApplyingMaterialPreset)
            {
                SyncSelectedConcreteGradeToValue();
            }
        }
    }

    public double Fy
    {
        get => fy;
        set
        {
            Set(ref fy, value);
            if (!isApplyingMaterialPreset)
            {
                SyncSelectedSteelGradeToValue();
            }
        }
    }

    public double Es { get => es; set => Set(ref es, value); }
    public double Pu { get => pu; set => Set(ref pu, value); }
    public double Mux { get => mux; set => Set(ref mux, value); }
    public double Muy { get => muy; set => Set(ref muy, value); }
    public double SelectedPmAngleDegrees { get => selectedPmAngleDegrees; set => Set(ref selectedPmAngleDegrees, value); }
    public double SelectedAxialLoad { get => selectedAxialLoad; set => Set(ref selectedAxialLoad, value); }

    public double SectionWidth { get => IsCircularSection ? Diameter : Width; set { if (IsCircularSection) Diameter = value; else Width = value; } }
    public double SectionHeight { get => IsCircularSection ? Diameter : Height; set { if (IsCircularSection) Diameter = value; else Height = value; } }
    public string SelectedRebarSize { get => BarSize; set => BarSize = value; }
    public int NumberOfBars { get => BarCount; set => BarCount = value; }
    public string SelectedRebarLayout { get => LayoutPreset; set => LayoutPreset = value; }
    public UnitSystem SelectedUnitSystem { get => UnitSystem; set => UnitSystem = value; }
    public double Spacing { get => spacing; set { Set(ref spacing, value); UpdateSectionPreview(); } }
    public bool ShowTotalBarsInput => IsRectangularSection && SelectedRebarLayoutType == RebarLayoutType.AllSidesEqual;
    public bool IsEqualSpacingLayout => (IsRectangularSection || IsCircularSection) && SelectedRebarLayoutType == RebarLayoutType.EqualSpacing;
    public bool IsAllSidesEqualLayout => IsRectangularSection && SelectedRebarLayoutType == RebarLayoutType.AllSidesEqual;
    public bool IsSidesDifferentLayout => IsRectangularSection && SelectedRebarLayoutType == RebarLayoutType.SidesDifferent;
    public bool IsCircularEqualSpacingLayout => IsCircularSection;
    public bool IsRectangularEqualSpacingLayout => IsRectangularSection && SelectedRebarLayoutType == RebarLayoutType.EqualSpacing;
    public bool IsCustomRebarCoordinates => SelectedRebarLayoutType == RebarLayoutType.CustomCoordinates;
    public bool IsAlgorithmicRebarCoordinates => !IsCustomRebarCoordinates;
    public bool IsRebarCoordinatesEditable => IsIrregularSection || IsCustomRebarCoordinates;
    public RebarLayoutViewModel RebarLayout { get; }
    public IrregularSectionInputViewModel IrregularInput { get; }
    public bool IsIrregularSection
    {
        get => SelectedSectionShape == SectionShapeType.Irregular;
        set { if (value) SelectedSectionShape = SectionShapeType.Irregular; }
    }
    public ObservableCollection<PreviewRebarPoint> PreviewRebars { get; } = [];
    public ObservableCollection<PreviewBoundaryPoint> PreviewBoundaryPoints { get; } = [];
    public ObservableCollection<LoadCaseViewModel> LoadCases { get; } = [];
    public ICommand AddLoadCaseCommand { get; }
    public ICommand DeleteLoadCaseCommand { get; }
    public ICommand DeleteSelectedLoadCasesCommand { get; }
    public ICommand RemoveDuplicateLoadCasesCommand { get; }
    public string SectionPreviewLabel { get => sectionPreviewLabel; private set => Set(ref sectionPreviewLabel, value); }
    public string RebarPreviewLabel { get => rebarPreviewLabel; private set => Set(ref rebarPreviewLabel, value); }
    public string CoverPreviewLabel { get => coverPreviewLabel; private set => Set(ref coverPreviewLabel, value); }
    public bool IsSectionPreviewValid { get => isSectionPreviewValid; private set => Set(ref isSectionPreviewValid, value); }
    public string SectionPreviewErrorMessage { get => sectionPreviewErrorMessage; private set => Set(ref sectionPreviewErrorMessage, value); }
    public string RebarLayoutWarning { get => rebarLayoutWarning; private set => Set(ref rebarLayoutWarning, value); }
    public bool HasRebarLayoutWarning => !string.IsNullOrWhiteSpace(RebarLayoutWarning);
    public string PreviewAreaText { get => previewAreaText; private set => Set(ref previewAreaText, value); }
    public string PreviewIxxText { get => previewIxxText; private set => Set(ref previewIxxText, value); }
    public string PreviewIyyText { get => previewIyyText; private set => Set(ref previewIyyText, value); }
    public string PreviewRebarPercentageText { get => previewRebarPercentageText; private set => Set(ref previewRebarPercentageText, value); }
    public string PreviewShapeSummaryText { get => previewShapeSummaryText; private set => Set(ref previewShapeSummaryText, value); }
    public string PreviewRebarLayoutText { get => previewRebarLayoutText; private set => Set(ref previewRebarLayoutText, value); }

    public ForceUnit CurrentForceUnit => UnitSystem == UnitSystem.Metric ? ForceUnit.kN : ForceUnit.Kip;
    public MomentUnit CurrentMomentUnit => UnitSystem == UnitSystem.Metric ? MomentUnit.kNm : MomentUnit.KipFt;

    public ColumnInputDto ToDto()
    {
        var forceUnit = CurrentForceUnit;
        var momentUnit = CurrentMomentUnit;
        var lcDtos = LoadCases.Count > 0
            ? LoadCases.Select(lc => lc.ToDto(forceUnit, momentUnit)).ToList()
            : null;
        var layoutLengthUnit = UnitSystem == UnitSystem.Metric ? LengthUnit.Millimeter : LengthUnit.Inch;
        var stressUnit = UnitSystem == UnitSystem.Metric ? StressUnit.MPa : StressUnit.Ksi;

        if (SelectedSectionShape == SectionShapeType.Irregular)
        {
            if (IrregularInput?.RebarMode == IrregularRebarModeType.EqualSpacing)
            {
                GenerateIrregularRebarsInternal();
            }

            var irregularDto = IrregularInput?.ToDto(Cover) ?? new IrregularSectionInputDto(
                Array.Empty<IrregularBoundaryPointDto>(),
                Array.Empty<IrregularRebarInputDto>(),
                Cover,
                IrregularRebarModeType.CustomCoordinates);

            int finalBarCount = IrregularInput?.Rebars.Count ?? BarCount;
            return new(UnitSystem, Width, Height, Cover, BarSize, finalBarCount, LayoutPreset, Fc, Fy, Es, Pu, Mux, Muy,
                forceUnit, layoutLengthUnit, momentUnit, stressUnit, SelectedPmAngleDegrees, SelectedAxialLoad)
            {
                LoadCases = lcDtos,
                SectionShape = SectionShapeType.Irregular,
                DesignCode = SelectedDesignCode,
                Ec2Solver = SelectedEc2Solver,
                IntegrationMethod = SectionIntegrationMethod.Polygon,
                AlphaCc = AlphaCc,
                Irregular = irregularDto
            };
        }

        if (IsCircularSection)
        {
            IReadOnlyList<RebarCoordinateDto>? circularCoords = null;
            int finalBarCount = BarCount;
            if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing)
            {
                double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
                var bars = AvailableBars;
                var bar = bars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? bars.FirstOrDefault();
                double barDiameterMm = bar?.DiameterMm ?? 20.0;
                double diameterMm = Diameter * factor;
                double coverMm = Cover * factor;
                double radiusMm = diameterMm / 2.0 - coverMm - barDiameterMm / 2.0;
                if (radiusMm > 0 && Spacing > 0)
                {
                    double spacingMm = Spacing * factor;
                    double perimeterMm = 2.0 * Math.PI * radiusMm;
                    finalBarCount = (int)Math.Max(4, Math.Round(perimeterMm / spacingMm));
                }
            }

            try
            {
                circularCoords = IsCustomRebarCoordinates
                    ? BuildCustomRebarCoordinates()
                    : rebarCoordinateBuilder.BuildCircular(Diameter, Cover, finalBarCount, BarSize, layoutLengthUnit, UnitSystem);
            }
            catch
            {
                // Validation will surface the error before Calculate() is reached
            }

            return new(UnitSystem, Width, Height, Cover, BarSize, finalBarCount, LayoutPreset, Fc, Fy, Es, Pu, Mux, Muy,
                forceUnit, layoutLengthUnit, momentUnit, stressUnit, SelectedPmAngleDegrees, SelectedAxialLoad)
            {
                LoadCases = lcDtos,
                SectionShape = SectionShapeType.Circular,
                Diameter = Diameter,
                RebarCoordinates = circularCoords,
                DesignCode = SelectedDesignCode,
                Ec2Solver = SelectedEc2Solver,
                IntegrationMethod = SelectedIntegrationMethod,
                AlphaCc = AlphaCc
            };
        }

        var layout = CreateRebarLayoutInput();
        IReadOnlyList<RebarCoordinateDto>? generatedCoordinates = null;
        try
        {
            generatedCoordinates = IsCustomRebarCoordinates
                ? BuildCustomRebarCoordinates()
                : rebarCoordinateBuilder.Build(layout, Width, Height, layoutLengthUnit, UnitSystem);
        }
        catch
        {
            // Validation will surface the error before Calculate() is reached
        }

        return new(UnitSystem, Width, Height, Cover, BarSize, BarCount, LayoutPreset, Fc, Fy, Es, Pu, Mux, Muy,
            forceUnit, layoutLengthUnit, momentUnit, stressUnit, SelectedPmAngleDegrees, SelectedAxialLoad)
        {
            LoadCases = lcDtos,
            SectionShape = SelectedSectionShape,
            Diameter = Diameter,
            RebarLayoutType = SelectedRebarLayoutType,
            TopRebarSide = layout.Top,
            BottomRebarSide = layout.Bottom,
            LeftRebarSide = layout.Left,
            RightRebarSide = layout.Right,
            RebarCoordinates = generatedCoordinates,
            DesignCode = SelectedDesignCode,
            Ec2Solver = SelectedEc2Solver,
            IntegrationMethod = SelectedIntegrationMethod,
            AlphaCc = AlphaCc
        };
    }

    public void UpdateSectionPreview()
    {
        if (_isUpdatingPreview) return;
        _isUpdatingPreview = true;
        try
        {
            UpdateSectionPreviewInternal();
        }
        finally
        {
            _isUpdatingPreview = false;
        }
    }

    private void UpdateSectionPreviewInternal()
    {
        PreviewRebars.Clear();
        PreviewBoundaryPoints.Clear();
        ClearSideWarnings();
        RebarLayoutWarning = "";
        Raise(nameof(HasRebarLayoutWarning));

        if (SelectedSectionShape != SectionShapeType.Irregular)
        {
            IrregularInput.IsCustomCoordinatesOverride = IsCustomRebarCoordinates;
            SyncBoundaryPointsForShape();
        }
        else
        {
            IrregularInput.IsCustomCoordinatesOverride = false;
        }

        if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing)
        {
            if (SelectedSectionShape == SectionShapeType.Rectangular || SelectedSectionShape == SectionShapeType.Circular)
            {
                GenerateEqualSpacingRebarsInternal();
            }
            else if (SelectedSectionShape == SectionShapeType.Irregular && IrregularInput.RebarMode == IrregularRebarModeType.EqualSpacing)
            {
                GenerateIrregularRebarsInternal();
            }
        }

        if (SelectedSectionShape == SectionShapeType.Irregular)
        {
            bool valid = IrregularInput.BoundaryPoints.Count >= 3;
            IsSectionPreviewValid = valid;
            SectionPreviewErrorMessage = valid ? "" : "Add at least 3 boundary points.";
            SectionPreviewLabel = isDxfImportedSection
                ? $"Irregular imported from DXF ({IrregularInput.BoundaryPoints.Count} pts)"
                : $"Irregular ({IrregularInput.BoundaryPoints.Count} pts)";
            RebarPreviewLabel = $"{IrregularInput.Rebars.Count} rebars";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            if (valid)
            {
                foreach (var pt in IrregularInput.BoundaryPoints)
                    PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(pt.X, pt.Y));
                foreach (var r in IrregularInput.Rebars)
                {
                    double area = r.AreaMm2 ?? 0;
                    double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : 20.0;
                    PreviewRebars.Add(new PreviewRebarPoint(r.X, r.Y, diam, r.BarSize ?? ""));
                }
            }
            UpdateSectionPropertiesPanel();
            return;
        }

        if (IsCustomRebarCoordinates)
        {
            IReadOnlyList<RebarCoordinateDto> customCoordinates;
            try
            {
                customCoordinates = BuildCustomRebarCoordinates();
            }
            catch (Exception ex)
            {
                IsSectionPreviewValid = false;
                SectionPreviewErrorMessage = ex.Message;
                SectionPreviewLabel = IsCircularSection ? $"D = {Diameter:0.###} {LengthLabel}" : $"{Width:0.###} x {Height:0.###} {LengthLabel}";
                RebarPreviewLabel = "";
                CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
                return;
            }

            foreach (var b in customCoordinates)
            {
                PreviewRebars.Add(new PreviewRebarPoint(b.X, b.Y, b.Diameter, b.BarSizeLabel));
            }

            IsSectionPreviewValid = true;
            SectionPreviewErrorMessage = "";
            SectionPreviewLabel = IsCircularSection ? $"D = {Diameter:0.###} {LengthLabel}" : $"{Width:0.###} x {Height:0.###} {LengthLabel}";
            RebarPreviewLabel = $"{PreviewRebars.Count} custom rebars";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            UpdateSectionPropertiesPanel();
            return;
        }
        if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing && IsRectangularSection)
        {
            if (Width <= 0 || Height <= 0 || Cover <= 0)
            {
                IsSectionPreviewValid = false;
                SectionPreviewErrorMessage = "Invalid section input";
                SectionPreviewLabel = "";
                RebarPreviewLabel = "";
                CoverPreviewLabel = "";
                return;
            }

            double uFactor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
            var uBars = AvailableBars;
            var uBar = uBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? uBars.FirstOrDefault();
            double uBarDiameterMm = uBar?.DiameterMm ?? 20.0;

            foreach (var r in IrregularInput.Rebars)
            {
                double area = r.AreaMm2 ?? 0;
                double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : uBarDiameterMm;
                PreviewRebars.Add(new PreviewRebarPoint(r.X, r.Y, diam / uFactor, r.BarSize ?? ""));
            }

            IsSectionPreviewValid = true;
            SectionPreviewErrorMessage = "";
            SectionPreviewLabel = $"{Width:0.###} x {Height:0.###} {LengthLabel}";
            RebarPreviewLabel = $"{IrregularInput.Rebars.Count}-{BarSize}";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            UpdateSectionPropertiesPanel();
            return;
        }

        if (SelectedSectionShape == SectionShapeType.Circular)
        {
            UpdateCircularSectionPreview();
            return;
        }

        if (Width <= 0 || Height <= 0 || Cover <= 0 || Cover * 2 >= Math.Min(Width, Height))
        {
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = "Invalid section input";
            SectionPreviewLabel = "";
            RebarPreviewLabel = "";
            CoverPreviewLabel = "";
            return;
        }

        IReadOnlyList<RebarCoordinateDto> bars;
        try
        {
            bars = rebarCoordinateBuilder.Build(CreateRebarLayoutInput(), Width, Height, UnitSystem == UnitSystem.Metric ? LengthUnit.Millimeter : LengthUnit.Inch, UnitSystem);
        }
        catch (Exception ex)
        {
            ApplyRebarValidationMessage(ex.Message);
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = ex.Message;
            SectionPreviewLabel = "";
            RebarPreviewLabel = "";
            CoverPreviewLabel = "";
            return;
        }

        foreach (var b in bars)
        {
            PreviewRebars.Add(new PreviewRebarPoint(b.X, b.Y, b.Diameter, b.BarSizeLabel));
        }

        SyncRebarsToTable(bars);

        IsSectionPreviewValid = true;
        SectionPreviewErrorMessage = "";
        SectionPreviewLabel = $"{Width:0.###} x {Height:0.###} {LengthLabel}";

        var selectedBar = AvailableBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase));
        double barAreaMm2 = selectedBar?.AreaMm2 ?? 0;
        double totalAsMm2 = PreviewRebars.Count * barAreaMm2;
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double agMm2 = (Width * factor) * (Height * factor);
        double rho = agMm2 > 0 ? (totalAsMm2 / agMm2) : 0;

        RebarPreviewLabel = $"{PreviewRebars.Count}-{BarSize} (\u03c1 = {rho * 100:F2}%)";
        CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
        UpdateSectionPropertiesPanel();
    }

    private void UpdateCircularSectionPreview()
    {
        if (Diameter <= 0 || Cover <= 0)
        {
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = "Invalid circular section input";
            SectionPreviewLabel = Diameter > 0 ? $"D = {Diameter:0.###} {LengthLabel}" : "";
            RebarPreviewLabel = "";
            CoverPreviewLabel = Cover > 0 ? $"Cover = {Cover:0.###} {LengthLabel}" : "";
            return;
        }

        if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing)
        {
            double cFactor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
            var cBars = AvailableBars;
            var cBar = cBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? cBars.FirstOrDefault();
            double cBarDiameterMm = cBar?.DiameterMm ?? 20.0;

            foreach (var r in IrregularInput.Rebars)
            {
                double area = r.AreaMm2 ?? 0;
                double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : cBarDiameterMm;
                PreviewRebars.Add(new PreviewRebarPoint(r.X, r.Y, diam / cFactor, r.BarSize ?? ""));
            }

            IsSectionPreviewValid = true;
            SectionPreviewErrorMessage = "";
            SectionPreviewLabel = $"D = {Diameter:0.###} {LengthLabel}";
            RebarPreviewLabel = $"{IrregularInput.Rebars.Count}-{BarSize}";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            UpdateSectionPropertiesPanel();
            return;
        }

        if (BarCount < 1)
        {
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = "Invalid circular section input";
            SectionPreviewLabel = Diameter > 0 ? $"D = {Diameter:0.###} {LengthLabel}" : "";
            RebarPreviewLabel = "";
            CoverPreviewLabel = Cover > 0 ? $"Cover = {Cover:0.###} {LengthLabel}" : "";
            return;
        }

        var bars = AvailableBars;
        var bar = bars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? bars.FirstOrDefault();
        if (bar is null)
        {
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = "Invalid bar size";
            SectionPreviewLabel = $"D = {Diameter:0.###} {LengthLabel}";
            RebarPreviewLabel = "";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            return;
        }

        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double diameterMm = Diameter * factor;
        double coverMm = Cover * factor;
        double barDiameterMm = bar.DiameterMm;
        double radiusMm = diameterMm / 2.0 - coverMm - barDiameterMm / 2.0;
        if (radiusMm <= 0)
        {
            IsSectionPreviewValid = false;
            SectionPreviewErrorMessage = "Cover places bars outside the circular section";
            SectionPreviewLabel = $"D = {Diameter:0.###} {LengthLabel}";
            RebarPreviewLabel = "";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            return;
        }

        int effectiveBarCount = BarCount;
        if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing)
        {
            double spacingMm = Spacing * factor;
            if (spacingMm <= 0)
            {
                IsSectionPreviewValid = false;
                SectionPreviewErrorMessage = "Spacing must be greater than zero.";
                return;
            }
            double perimeterMm = 2.0 * Math.PI * radiusMm;
            effectiveBarCount = (int)Math.Max(4, Math.Round(perimeterMm / spacingMm));
        }

        double previewRadius = radiusMm / factor;
        double previewBarDiameter = barDiameterMm / factor;
        var circularCoords = new List<RebarCoordinateDto>(effectiveBarCount);
        for (int i = 0; i < effectiveBarCount; i++)
        {
            double angle = 2.0 * Math.PI * i / effectiveBarCount + Math.PI / 2.0;
            double x = previewRadius * Math.Cos(angle);
            double y = previewRadius * Math.Sin(angle);
            PreviewRebars.Add(new PreviewRebarPoint(x, y, previewBarDiameter, bar.DisplayLabel));
            
            circularCoords.Add(new RebarCoordinateDto(
                $"B{i + 1}",
                x,
                y,
                barDiameterMm / factor,
                bar.AreaMm2,
                bar.Name,
                "Circular"));
        }

        SyncRebarsToTable(circularCoords);

        IsSectionPreviewValid = true;
        SectionPreviewErrorMessage = "";
        SectionPreviewLabel = $"D = {Diameter:0.###} {LengthLabel}";

        double totalAsMm2 = effectiveBarCount * bar.AreaMm2;
        double agMm2 = Math.PI * Math.Pow(diameterMm / 2.0, 2);
        double rho = agMm2 > 0 ? (totalAsMm2 / agMm2) : 0;

        RebarPreviewLabel = $"{effectiveBarCount}-{BarSize} (\u03c1 = {rho * 100:F2}%)";
        CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
        UpdateSectionPropertiesPanel();
    }

    private RebarLayoutInputDto CreateRebarLayoutInput()
        => new(
            SelectedRebarLayoutType,
            BarCount,
            BarSize,
            Cover,
            RebarLayout.Top.ToDto(BarSize, Cover),
            RebarLayout.Bottom.ToDto(BarSize, Cover),
            RebarLayout.Left.ToDto(BarSize, Cover),
            RebarLayout.Right.ToDto(BarSize, Cover));

    private void SyncRebarLayoutTypeFromIrregularMode()
    {
        if (SelectedSectionShape != SectionShapeType.Irregular)
        {
            return;
        }

        var desired = IrregularInput.RebarMode == IrregularRebarModeType.CustomCoordinates
            ? RebarLayoutType.CustomCoordinates
            : RebarLayoutType.EqualSpacing;

        if (selectedRebarLayoutType != desired)
        {
            selectedRebarLayoutType = desired;
            layoutPreset = desired == RebarLayoutType.CustomCoordinates ? "Custom Coordinates" : "Equal Spacing";
            Raise(nameof(SelectedRebarLayoutType));
            Raise(nameof(SelectedRebarLayout));
            Raise(nameof(IsEqualSpacingLayout));
            Raise(nameof(IsCustomRebarCoordinates));
            Raise(nameof(IsAlgorithmicRebarCoordinates));
            Raise(nameof(IsRebarCoordinatesEditable));
        }

        if (desired == RebarLayoutType.CustomCoordinates)
        {
            IrregularInput.RebarValidationMessage = "";
        }
    }

    private void SyncSideGlobalInputs()
    {
        RebarLayout.Top.SetGlobalInputs(BarSize, Cover);
        RebarLayout.Bottom.SetGlobalInputs(BarSize, Cover);
        RebarLayout.Left.SetGlobalInputs(BarSize, Cover);
        RebarLayout.Right.SetGlobalInputs(BarSize, Cover);
    }

    private void SyncEqualSideCounts()
    {
        if (SelectedRebarLayoutType == RebarLayoutType.AllSidesEqual)
        {
            SeedSideCountsFromTotalBars();
        }
    }

    private void SeedSideCountsFromTotalBars()
    {
        int perSide;
        if (SelectedRebarLayoutType == RebarLayoutType.AllSidesEqual)
        {
            perSide = (BarCount >= 4 && (BarCount - 4) % 4 == 0) ? (BarCount - 4) / 4 + 2 : 0;
        }
        else
        {
            perSide = Math.Max(0, BarCount / 4);
        }
        RebarLayout.Top.SetBarCountSilently(perSide);
        RebarLayout.Bottom.SetBarCountSilently(perSide);
        RebarLayout.Left.SetBarCountSilently(perSide);
        RebarLayout.Right.SetBarCountSilently(perSide);
    }

    private void ClearSideWarnings()
    {
        RebarLayout.Top.SetWarning("");
        RebarLayout.Bottom.SetWarning("");
        RebarLayout.Left.SetWarning("");
        RebarLayout.Right.SetWarning("");
    }

    private void ApplyRebarValidationMessage(string message)
    {
        RebarLayoutWarning = message;
        Raise(nameof(HasRebarLayoutWarning));
        if (!IsSidesDifferentLayout)
        {
            return;
        }

        if (message.Contains("Top", StringComparison.OrdinalIgnoreCase)) RebarLayout.Top.SetWarning(message);
        if (message.Contains("Bottom", StringComparison.OrdinalIgnoreCase)) RebarLayout.Bottom.SetWarning(message);
        if (message.Contains("Left", StringComparison.OrdinalIgnoreCase)) RebarLayout.Left.SetWarning(message);
        if (message.Contains("Right", StringComparison.OrdinalIgnoreCase)) RebarLayout.Right.SetWarning(message);
        if (message.Contains("non-negative", StringComparison.OrdinalIgnoreCase))
        {
            if (RebarLayout.Top.BarCount < 0) RebarLayout.Top.SetWarning(message);
            if (RebarLayout.Bottom.BarCount < 0) RebarLayout.Bottom.SetWarning(message);
            if (RebarLayout.Left.BarCount < 0) RebarLayout.Left.SetWarning(message);
            if (RebarLayout.Right.BarCount < 0) RebarLayout.Right.SetWarning(message);
        }
    }

    private void AddLoadCase()
    {
        var source = LoadCases.LastOrDefault();
        var lc = new LoadCaseViewModel(
            Guid.NewGuid().ToString("N")[..8],
            $"LC{nextLoadCaseIndex++}",
            source?.Pu ?? Pu,
            source?.Mux ?? Mux,
            source?.Muy ?? Muy);
        LoadCases.Add(lc);
    }

    private void DeleteLoadCase(LoadCaseViewModel lc)
    {
        LoadCases.Remove(lc);
        EnsureAtLeastOneLoadCase();
    }

    private void DeleteSelectedLoadCases(object selectedItems)
    {
        if (selectedItems is not IList items) return;
        var selected = items.OfType<LoadCaseViewModel>().ToList();
        foreach (var lc in selected)
        {
            LoadCases.Remove(lc);
        }

        EnsureAtLeastOneLoadCase();
    }

    private void RemoveDuplicateLoadCases()
    {
        var seen = new HashSet<(double, double, double)>();
        var duplicates = LoadCases
            .Where(lc => !seen.Add((Math.Round(lc.Pu, 6), Math.Round(lc.Mux, 6), Math.Round(lc.Muy, 6))))
            .ToList();
        foreach (var dup in duplicates)
            LoadCases.Remove(dup);
    }

    private void SelectDefaultMaterialGrades(bool applyValues)
    {
        if (selectedMaterialLibrary == MaterialLibraryType.Custom)
        {
            selectedConcreteGrade = null;
            selectedSteelGrade = null;
            Raise(nameof(AvailableConcreteGrades));
            Raise(nameof(AvailableSteelGrades));
            Raise(nameof(SelectedConcreteGrade));
            Raise(nameof(SelectedSteelGrade));
            return;
        }

        selectedConcreteGrade = selectedMaterialLibrary == MaterialLibraryType.Europe
            ? EuropeanConcreteGrades[2]
            : AmericanConcreteGrades[1];
        selectedSteelGrade = selectedMaterialLibrary == MaterialLibraryType.Europe
            ? EuropeanSteelGrades[2]
            : AmericanSteelGrades[1];

        Raise(nameof(AvailableConcreteGrades));
        Raise(nameof(AvailableSteelGrades));
        Raise(nameof(SelectedConcreteGrade));
        Raise(nameof(SelectedSteelGrade));

        if (!applyValues) return;

        ApplyConcreteGrade(selectedConcreteGrade);
        ApplySteelGrade(selectedSteelGrade);
    }

    private void ApplyConcreteGrade(MaterialGradeOption grade)
    {
        isApplyingMaterialPreset = true;
        try
        {
            Fc = RoundMaterialValue(grade.StressValue(UnitSystem));
        }
        finally
        {
            isApplyingMaterialPreset = false;
        }
    }

    private void ApplySteelGrade(MaterialGradeOption grade)
    {
        isApplyingMaterialPreset = true;
        try
        {
            Fy = RoundMaterialValue(grade.StressValue(UnitSystem));
            if (grade.ModulusValue(UnitSystem) is double modulus)
            {
                Es = RoundMaterialValue(modulus);
            }
        }
        finally
        {
            isApplyingMaterialPreset = false;
        }
    }

    private void SyncSelectedConcreteGradeToValue()
    {
        var match = FindMatchingGrade(AvailableConcreteGrades, fc);
        if (Equals(selectedConcreteGrade, match)) return;

        selectedConcreteGrade = match;
        Raise(nameof(SelectedConcreteGrade));
    }

    private void SyncSelectedSteelGradeToValue()
    {
        var match = FindMatchingGrade(AvailableSteelGrades, fy);
        if (Equals(selectedSteelGrade, match)) return;

        selectedSteelGrade = match;
        Raise(nameof(SelectedSteelGrade));
    }

    private void SyncMaterialLibraryFromValues()
    {
        selectedMaterialLibrary = InferMaterialLibrary();
        selectedConcreteGrade = FindMatchingGrade(AvailableConcreteGrades, fc);
        selectedSteelGrade = FindMatchingGrade(AvailableSteelGrades, fy);
    }

    private MaterialLibraryType InferMaterialLibrary()
    {
        bool europeMatch =
            FindMatchingGrade(EuropeanConcreteGrades, fc) is not null ||
            FindMatchingGrade(EuropeanSteelGrades, fy) is not null;
        bool americaMatch =
            FindMatchingGrade(AmericanConcreteGrades, fc) is not null ||
            FindMatchingGrade(AmericanSteelGrades, fy) is not null;

        if (europeMatch && !americaMatch) return MaterialLibraryType.Europe;
        if (americaMatch && !europeMatch) return MaterialLibraryType.America;
        return selectedDesignCode == DesignCodeType.Ec2 ? MaterialLibraryType.Europe : MaterialLibraryType.America;
    }

    private static IReadOnlyList<MaterialGradeOption> ConcreteGradesFor(MaterialLibraryType library)
        => library switch
        {
            MaterialLibraryType.Europe => EuropeanConcreteGrades,
            MaterialLibraryType.Custom => [],
            _ => AmericanConcreteGrades
        };

    private static IReadOnlyList<MaterialGradeOption> SteelGradesFor(MaterialLibraryType library)
        => library switch
        {
            MaterialLibraryType.Europe => EuropeanSteelGrades,
            MaterialLibraryType.Custom => [],
            _ => AmericanSteelGrades
        };

    private MaterialGradeOption? FindMatchingGrade(IReadOnlyList<MaterialGradeOption> grades, double value)
        => grades.FirstOrDefault(grade => Math.Abs(RoundMaterialValue(grade.StressValue(UnitSystem)) - value) <= 0.0005);

    private static double RoundMaterialValue(double value) => Math.Round(value, 3);

    private void ApplyMetricDefaults()
    {
        width = 700; height = 700; diameter = 700; cover = 55; barSize = "T25"; barCount = 28;
        layoutPreset = "All Sides Equal";
        selectedSectionShape = SectionShapeType.Rectangular;
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
        selectedMaterialLibrary = MaterialLibraryType.America;
        selectedConcreteGrade = AmericanConcreteGrades[1];
        selectedSteelGrade = AmericanSteelGrades[1];
        SyncSideGlobalInputs();
        SeedSideCountsFromTotalBars();
        fc = selectedConcreteGrade.StressValue(UnitSystem.Metric);
        fy = selectedSteelGrade.StressValue(UnitSystem.Metric);
        es = selectedSteelGrade.ModulusValue(UnitSystem.Metric) ?? 200000;
        pu = 2500; mux = 250; muy = 180; selectedAxialLoad = 0;
        LoadCases.Clear(); nextLoadCaseIndex = 2;
        AddPrimaryLoadCase();
        RaiseDefaults();
    }

    private void ApplyImperialDefaults()
    {
        width = 28; height = 28; diameter = 28; cover = 2.2; barSize = "#8"; barCount = 28;
        layoutPreset = "All Sides Equal";
        selectedSectionShape = SectionShapeType.Rectangular;
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
        selectedMaterialLibrary = MaterialLibraryType.America;
        selectedConcreteGrade = AmericanConcreteGrades[1];
        selectedSteelGrade = AmericanSteelGrades[1];
        SyncSideGlobalInputs();
        SeedSideCountsFromTotalBars();
        fc = selectedConcreteGrade.StressValue(UnitSystem.Imperial);
        fy = selectedSteelGrade.StressValue(UnitSystem.Imperial);
        es = selectedSteelGrade.ModulusValue(UnitSystem.Imperial) ?? 29000;
        pu = 560; mux = 185; muy = 130; selectedAxialLoad = 0;
        LoadCases.Clear(); nextLoadCaseIndex = 2;
        AddPrimaryLoadCase();
        RaiseDefaults();
    }

    private void AddPrimaryLoadCase()
        => LoadCases.Add(new LoadCaseViewModel("lc1", "LC1", Pu, Mux, Muy));

    private void EnsureAtLeastOneLoadCase()
    {
        if (LoadCases.Count == 0)
        {
            AddPrimaryLoadCase();
        }
    }

    private void RaiseDefaults()
    {
        Raise(nameof(SelectedSectionShape)); Raise(nameof(IsRectangularSection)); Raise(nameof(IsCircularSection)); Raise(nameof(IsCircularEqualSpacingLayout));
        Raise(nameof(Width)); Raise(nameof(Height)); Raise(nameof(Diameter)); Raise(nameof(Cover)); Raise(nameof(BarSize)); Raise(nameof(BarCount)); Raise(nameof(LayoutPreset));
        Raise(nameof(Fc)); Raise(nameof(Fy)); Raise(nameof(Es)); Raise(nameof(Pu)); Raise(nameof(Mux)); Raise(nameof(Muy)); Raise(nameof(SelectedAxialLoad));
        Raise(nameof(SelectedMaterialLibrary)); Raise(nameof(AvailableConcreteGrades)); Raise(nameof(AvailableSteelGrades));
        Raise(nameof(SelectedConcreteGrade)); Raise(nameof(SelectedSteelGrade));
        Raise(nameof(AreMaterialGradesEnabled)); Raise(nameof(AreMaterialInputsEnabled));
        Raise(nameof(SectionWidth)); Raise(nameof(SectionHeight)); Raise(nameof(SelectedRebarSize)); Raise(nameof(NumberOfBars)); Raise(nameof(SelectedRebarLayout));
        Raise(nameof(SelectedRebarLayoutType)); Raise(nameof(IsAllSidesEqualLayout)); Raise(nameof(IsSidesDifferentLayout));
        Raise(nameof(SelectedDesignCode)); Raise(nameof(SelectedIntegrationMethod)); Raise(nameof(FcLabel)); Raise(nameof(FyLabel));
        Raise(nameof(AlphaCc)); Raise(nameof(ShowAlphaCcOption));
    }

    private IReadOnlyList<RebarCoordinateDto> BuildCustomRebarCoordinates()
    {
        if (IrregularInput.Rebars.Count == 0)
        {
            throw new InvalidOperationException("At least one custom rebar coordinate is required.");
        }

        var result = new List<RebarCoordinateDto>(IrregularInput.Rebars.Count);
        var bars = AvailableBars;
        for (int i = 0; i < IrregularInput.Rebars.Count; i++)
        {
            var row = IrregularInput.Rebars[i];
            var bar = bars.FirstOrDefault(b => string.Equals(b.Name, row.BarSize, StringComparison.OrdinalIgnoreCase));
            double area = row.AreaMm2 is > 0 ? row.AreaMm2.Value : bar?.AreaMm2 ?? 0.0;
            double diameter = area > 0.0 ? 2.0 * Math.Sqrt(area / Math.PI) : bar?.DiameterMm ?? 0.0;
            if (area <= 0.0 || diameter <= 0.0)
            {
                throw new InvalidOperationException($"Custom rebar row {i + 1} must provide a valid Area or Size.");
            }

            string label = !string.IsNullOrWhiteSpace(row.BarSize) ? row.BarSize : bar?.Name ?? $"A={area:0.###}";
            result.Add(new RebarCoordinateDto(
                string.IsNullOrWhiteSpace(row.RebarIndex) ? (i + 1).ToString() : row.RebarIndex,
                row.X,
                row.Y,
                diameter,
                area,
                label,
                "Custom"));
        }

        return result;
    }

    private bool _isSyncingRebars = false;
    private void SyncRebarsToTable(IReadOnlyList<RebarCoordinateDto> coords)
    {
        if (_isSyncingRebars || IsCustomRebarCoordinates) return;
        _isSyncingRebars = true;
        try
        {
            IrregularInput.Rebars.Clear();
            for (int i = 0; i < coords.Count; i++)
            {
                var c = coords[i];
                IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
                {
                    RebarIndex = string.IsNullOrWhiteSpace(c.Id) ? (i + 1).ToString() : c.Id,
                    X = Math.Round(c.X, 3),
                    Y = Math.Round(c.Y, 3),
                    AreaMm2 = Math.Round(c.Area, 3),
                    BarSize = c.BarSizeLabel
                });
            }
        }
        finally
        {
            _isSyncingRebars = false;
        }
    }

    private void ImportDxf()
    {
        if (dxfImportDialogService is null)
        {
            return;
        }

        var result = dxfImportDialogService.ShowDialog(System.Windows.Application.Current?.MainWindow);
        if (result is null)
        {
            return;
        }

        ApplyDxfImportResult(result);
    }

    public bool ApplyDxfImportResult(DxfSectionImportResult result)
    {
        if (!result.IsSuccess)
        {
            IrregularInput.BoundaryValidationMessage = string.Join(Environment.NewLine, result.Errors);
            return false;
        }

        var boundary = result.BoundaryVertices.ToList();
        var validator = new IrregularSectionValidationService(metricBars, imperialBars);
        var boundaryValidation = validator.ValidateBoundary(boundary);
        if (!boundaryValidation.IsValid)
        {
            IrregularInput.BoundaryValidationMessage = string.Join(Environment.NewLine, boundaryValidation.Issues.Select(i => i.Message));
            return false;
        }

        var rebarImportErrors = ValidateImportedDxfRebarsWithoutCover(boundary, result.Rebars);
        if (rebarImportErrors.Count > 0)
        {
            IrregularInput.RebarValidationMessage = string.Join(Environment.NewLine, rebarImportErrors);
            return false;
        }

        selectedSectionShape = SectionShapeType.Irregular;
        selectedRebarLayoutType = RebarLayoutType.CustomCoordinates;
        layoutPreset = "Custom Coordinates";
        isDxfImportedSection = true;

        _generatingRebarsDepth++;
        try
        {
            IrregularInput.BoundaryPoints.Clear();
            for (int i = 0; i < boundary.Count; i++)
            {
                IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel
                {
                    PtIndex = i + 1,
                    X = Math.Round(boundary[i].X, 6),
                    Y = Math.Round(boundary[i].Y, 6)
                });
            }

            IrregularInput.Rebars.Clear();
            for (int i = 0; i < result.Rebars.Count; i++)
            {
                var rebar = result.Rebars[i];
                IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
                {
                    RebarIndex = (i + 1).ToString(),
                    X = Math.Round(rebar.Center.X, 6),
                    Y = Math.Round(rebar.Center.Y, 6),
                    AreaMm2 = Math.Round(rebar.AreaMm2, 6),
                    BarSize = ""
                });
            }

            IrregularInput.RebarMode = IrregularRebarModeType.CustomCoordinates;
            IrregularInput.BoundaryValidationMessage = "";
            IrregularInput.RebarValidationMessage = "";
        }
        finally
        {
            _generatingRebarsDepth--;
        }

        Raise(nameof(SelectedSectionShape));
        Raise(nameof(IsRectangularSection));
        Raise(nameof(IsCircularSection));
        Raise(nameof(IsIrregularSection));
        Raise(nameof(IsCircularEqualSpacingLayout));
        Raise(nameof(IsEqualSpacingLayout));
        Raise(nameof(IsAllSidesEqualLayout));
        Raise(nameof(IsSidesDifferentLayout));
        Raise(nameof(IsRectangularEqualSpacingLayout));
        Raise(nameof(RebarLayoutTypes));
        Raise(nameof(SelectedRebarLayout));
        Raise(nameof(SelectedRebarLayoutType));
        Raise(nameof(IsCustomRebarCoordinates));
        Raise(nameof(IsAlgorithmicRebarCoordinates));
        Raise(nameof(IsRebarCoordinatesEditable));
        Raise(nameof(IrregularInput));

        UpdateSectionPreview();
        return true;
    }

    private static IReadOnlyList<string> ValidateImportedDxfRebarsWithoutCover(
        IReadOnlyList<Point2D> boundary,
        IReadOnlyList<DxfRebarImportItem> rebars)
    {
        var errors = new List<string>();
        if (rebars.Count == 0)
        {
            errors.Add("At least one imported rebar is required.");
            return errors;
        }

        for (int i = 0; i < rebars.Count; i++)
        {
            var rebar = rebars[i];
            if (!double.IsFinite(rebar.Center.X) ||
                !double.IsFinite(rebar.Center.Y) ||
                !double.IsFinite(rebar.AreaMm2) ||
                rebar.AreaMm2 <= 0.0)
            {
                errors.Add($"Imported rebar {i + 1} has invalid coordinate or area.");
                continue;
            }

            bool inside = PolygonGeometry.PointInPolygon(boundary, rebar.Center.X, rebar.Center.Y);
            double distance = PolygonGeometry.DistanceToBoundary(boundary, rebar.Center.X, rebar.Center.Y);
            if (!inside && distance > IrregularSectionValidationService.InsidePolygonToleranceMm)
            {
                errors.Add($"Imported rebar {i + 1} center is outside the boundary polygon.");
            }
        }

        return errors;
    }

    private void WireRebarsCollectionChanged()
    {
        IrregularInput.Rebars.CollectionChanged += (s, e) =>
        {
            if (e.NewItems is not null)
            {
                foreach (IrregularRebarRowViewModel item in e.NewItems)
                {
                    item.PropertyChanged += RebarRow_PropertyChanged;
                }
            }
            if (e.OldItems is not null)
            {
                foreach (IrregularRebarRowViewModel item in e.OldItems)
                {
                    item.PropertyChanged -= RebarRow_PropertyChanged;
                }
            }
            if (!_isGeneratingRebars)
                UpdateSectionPreview();
        };

        foreach (var item in IrregularInput.Rebars)
        {
            item.PropertyChanged += RebarRow_PropertyChanged;
        }
    }

    private void RebarRow_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        UpdateSectionPreview();
    }

    private void UpdateSectionPropertiesPanel()
    {
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double agMm2 = 0;
        double ixxMm4 = 0;
        double iyyMm4 = 0;

        if (SelectedSectionShape == SectionShapeType.Rectangular && Width > 0 && Height > 0)
        {
            double bMm = Width * factor;
            double hMm = Height * factor;
            agMm2 = bMm * hMm;
            ixxMm4 = bMm * Math.Pow(hMm, 3) / 12.0;
            iyyMm4 = hMm * Math.Pow(bMm, 3) / 12.0;
            PreviewShapeSummaryText = "Rectangular";
        }
        else if (SelectedSectionShape == SectionShapeType.Circular && Diameter > 0)
        {
            double dMm = Diameter * factor;
            agMm2 = Math.PI * dMm * dMm / 4.0;
            ixxMm4 = iyyMm4 = Math.PI * Math.Pow(dMm, 4) / 64.0;
            PreviewShapeSummaryText = "Circular";
        }
        else if (SelectedSectionShape == SectionShapeType.Irregular && IrregularInput.BoundaryPoints.Count >= 3)
        {
            var pts = IrregularInput.BoundaryPoints
                .Select(p => new Point2D(p.X * factor, p.Y * factor))
                .ToList();
            agMm2 = PolygonGeometry.Area(pts);
            (ixxMm4, iyyMm4) = ComputePolygonSecondMoments(pts);
            PreviewShapeSummaryText = isDxfImportedSection ? "Irregular (from DXF)" : "Irregular";
        }
        else
        {
            PreviewShapeSummaryText = "";
        }

        if (agMm2 > 0)
        {
            PreviewAreaText = $"{agMm2:N0} mm²";
            PreviewIxxText = FormatInertia(ixxMm4);
            PreviewIyyText = FormatInertia(iyyMm4);
        }
        else
        {
            PreviewAreaText = "—";
            PreviewIxxText = "—";
            PreviewIyyText = "—";
        }

        // Diameter in PreviewRebarPoint is always in mm
        double totalAsMm2 = PreviewRebars.Sum(r => Math.PI * Math.Pow(r.Diameter / 2.0, 2));
        int rebarCount = PreviewRebars.Count;

        PreviewRebarLayoutText = selectedRebarLayoutType switch
        {
            RebarLayoutType.AllSidesEqual => "All Sides Equal",
            RebarLayoutType.SidesDifferent => "Sides Different",
            RebarLayoutType.EqualSpacing => "Equal Spacing",
            RebarLayoutType.CustomCoordinates => "Custom Coordinates",
            _ => ""
        };

        if (rebarCount > 0 && agMm2 > 0)
            PreviewRebarPercentageText = $"{totalAsMm2 / agMm2 * 100.0:F2} %";
        else
            PreviewRebarPercentageText = "—";
    }

    private static (double Ixx, double Iyy) ComputePolygonSecondMoments(IReadOnlyList<Point2D> pts)
    {
        int n = pts.Count;
        if (n < 3) return (0, 0);
        double ixx = 0, iyy = 0;
        for (int i = 0; i < n; i++)
        {
            var a = pts[i];
            var b = pts[(i + 1) % n];
            double cross = a.X * b.Y - b.X * a.Y;
            ixx += (a.Y * a.Y + a.Y * b.Y + b.Y * b.Y) * cross;
            iyy += (a.X * a.X + a.X * b.X + b.X * b.X) * cross;
        }
        return (Math.Abs(ixx / 12.0), Math.Abs(iyy / 12.0));
    }

    private static string FormatInertia(double value)
    {
        if (value <= 0) return "—";
        if (value >= 1e12) return $"{value / 1e12:F3}×10¹² mm⁴";
        if (value >= 1e9) return $"{value / 1e9:F3}×10⁹ mm⁴";
        if (value >= 1e6) return $"{value / 1e6:F3}×10⁶ mm⁴";
        return $"{value:N0} mm⁴";
    }

    public ColumnInputSnapshot ToSnapshot() => new()
    {
        UnitSystem = unitSystem.ToString(),
        DesignCode = selectedDesignCode.ToString(),
        Ec2Solver = selectedEc2Solver.ToString(),
        IntegrationMethod = selectedIntegrationMethod.ToString(),
        AlphaCc = alphaCc,
        SectionShape = selectedSectionShape.ToString(),
        Width = width, Height = height, Diameter = diameter, Cover = cover,
        Fc = fc, Fy = fy, Es = es,
        MaterialLibrary = selectedMaterialLibrary.ToString(),
        BarSize = barSize, BarCount = barCount, Spacing = spacing,
        RebarLayoutType = selectedRebarLayoutType.ToString(),
        TopBarCount = RebarLayout.Top.BarCount,
        BottomBarCount = RebarLayout.Bottom.BarCount,
        LeftBarCount = RebarLayout.Left.BarCount,
        RightBarCount = RebarLayout.Right.BarCount,
        IrregularBarSize = IrregularInput.BarSize,
        IrregularSpacing = IrregularInput.Spacing,
        IrregularRebarMode = IrregularInput.RebarMode.ToString(),
        BoundaryPoints = IrregularInput.BoundaryPoints
            .Select(p => new SnapshotBoundaryPoint { PtIndex = p.PtIndex, X = p.X, Y = p.Y })
            .ToList(),
        Rebars = IrregularInput.Rebars
            .Select(r => new SnapshotRebar { RebarIndex = r.RebarIndex, X = r.X, Y = r.Y, BarSize = r.BarSize, AreaMm2 = r.AreaMm2 })
            .ToList(),
        Pu = pu, Mux = mux, Muy = muy,
        PmAngleDegrees = selectedPmAngleDegrees,
        AxialLoad = selectedAxialLoad,
        LoadCases = LoadCases
            .Select(lc => new SnapshotLoadCase { Id = lc.Id, Label = lc.Name, Pu = lc.Pu, Mux = lc.Mux, Muy = lc.Muy, IsActive = lc.IsActive })
            .ToList()
    };

    public void LoadFromSnapshot(ColumnInputSnapshot s)
    {
        isDxfImportedSection = false;
        unitSystem = Enum.TryParse<UnitSystem>(s.UnitSystem, out var us) ? us : UnitSystem.Metric;
        selectedDesignCode = Enum.TryParse<DesignCodeType>(s.DesignCode, out var dc) ? dc : DesignCodeType.Aci318Style;
        selectedEc2Solver = Enum.TryParse<Ec2SolverType>(s.Ec2Solver, out var ec2) ? ec2 : Ec2SolverType.Fiber;
        selectedIntegrationMethod = Enum.TryParse<SectionIntegrationMethod>(s.IntegrationMethod, out var im) ? im : SectionIntegrationMethod.Fiber;
        alphaCc = s.AlphaCc;
        selectedSectionShape = Enum.TryParse<SectionShapeType>(s.SectionShape, out var ss) ? ss : SectionShapeType.Rectangular;
        width = s.Width; height = s.Height; diameter = s.Diameter; cover = s.Cover;
        fc = s.Fc; fy = s.Fy; es = s.Es;
        if (Enum.TryParse<MaterialLibraryType>(s.MaterialLibrary, out var materialLibrary))
        {
            selectedMaterialLibrary = materialLibrary;
            selectedConcreteGrade = FindMatchingGrade(ConcreteGradesFor(selectedMaterialLibrary), fc);
            selectedSteelGrade = FindMatchingGrade(SteelGradesFor(selectedMaterialLibrary), fy);
        }
        else
        {
            SyncMaterialLibraryFromValues();
        }

        barSize = s.BarSize; barCount = s.BarCount; spacing = s.Spacing;
        selectedRebarLayoutType = Enum.TryParse<RebarLayoutType>(s.RebarLayoutType, out var rlt) ? rlt : RebarLayoutType.AllSidesEqual;
        pu = s.Pu; mux = s.Mux; muy = s.Muy;
        selectedPmAngleDegrees = s.PmAngleDegrees;
        selectedAxialLoad = s.AxialLoad;

        RebarLayout.Top.SetBarCountSilently(s.TopBarCount);
        RebarLayout.Bottom.SetBarCountSilently(s.BottomBarCount);
        RebarLayout.Left.SetBarCountSilently(s.LeftBarCount);
        RebarLayout.Right.SetBarCountSilently(s.RightBarCount);
        SyncSideGlobalInputs();

        LoadCases.Clear();
        nextLoadCaseIndex = 2;
        foreach (var lc in s.LoadCases)
        {
            LoadCases.Add(new LoadCaseViewModel(lc.Id, lc.Label, lc.Pu, lc.Mux, lc.Muy, lc.IsActive));
            if (int.TryParse(lc.Label.Replace("LC", ""), out var n) && n >= nextLoadCaseIndex)
                nextLoadCaseIndex = n + 1;
        }

        if (LoadCases.Count == 0) AddPrimaryLoadCase();

        _generatingRebarsDepth++;
        try
        {
            IrregularInput.BarSize = s.IrregularBarSize;
            IrregularInput.Spacing = s.IrregularSpacing;
            IrregularInput.RebarMode = Enum.TryParse<IrregularRebarModeType>(s.IrregularRebarMode, out var irm)
                ? irm : IrregularRebarModeType.EqualSpacing;
            IrregularInput.BoundaryPoints.Clear();
            foreach (var pt in s.BoundaryPoints)
                IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = pt.PtIndex, X = pt.X, Y = pt.Y });
            IrregularInput.Rebars.Clear();
            foreach (var r in s.Rebars)
                IrregularInput.Rebars.Add(new IrregularRebarRowViewModel { RebarIndex = r.RebarIndex, X = r.X, Y = r.Y, BarSize = r.BarSize ?? "", AreaMm2 = r.AreaMm2 });
        }
        finally
        {
            _generatingRebarsDepth--;
        }

        RaiseDefaults();
        UpdateSectionPreview();
    }

    private void SyncBoundaryPointsForShape()
    {
        IrregularInput.BoundaryPoints.Clear();

        if (SelectedSectionShape == SectionShapeType.Rectangular)
        {
            if (Width <= 0 || Height <= 0) return;
            double w = Width / 2.0;
            double h = Height / 2.0;
            IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = 1, X = Math.Round(-w, 3), Y = Math.Round(h, 3) });
            IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = 2, X = Math.Round(w, 3), Y = Math.Round(h, 3) });
            IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = 3, X = Math.Round(w, 3), Y = Math.Round(-h, 3) });
            IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel { PtIndex = 4, X = Math.Round(-w, 3), Y = Math.Round(-h, 3) });
        }
        else if (SelectedSectionShape == SectionShapeType.Circular)
        {
            if (Diameter <= 0) return;
            double r = Diameter / 2.0;
            const int n = 16;
            for (int i = 0; i < n; i++)
            {
                double angle = Math.PI / 2.0 - 2.0 * Math.PI * i / n;
                IrregularInput.BoundaryPoints.Add(new IrregularBoundaryPointViewModel
                {
                    PtIndex = i + 1,
                    X = Math.Round(r * Math.Cos(angle), 3),
                    Y = Math.Round(r * Math.Sin(angle), 3)
                });
            }
        }
    }

    private void GenerateIrregularRebars()
    {
        GenerateIrregularRebarsInternal();
        UpdateSectionPreview();
    }

    private void GenerateIrregularRebarsInternal()
    {
        if (IrregularInput.BoundaryPoints.Count < 3)
        {
            IrregularInput.RebarValidationMessage = "Boundary points must be defined before generating rebars.";
            return;
        }

        if (Cover <= 0)
        {
            IrregularInput.RebarValidationMessage = "Clear cover must be greater than zero.";
            return;
        }

        var available = AvailableBars;
        var selectedBar = available.FirstOrDefault(b => string.Equals(b.Name, IrregularInput.BarSize, System.StringComparison.OrdinalIgnoreCase));
        if (selectedBar == null)
        {
            IrregularInput.RebarValidationMessage = "Invalid bar size selected.";
            return;
        }

        double spacing = IrregularInput.Spacing;
        if (spacing <= 0)
        {
            IrregularInput.RebarValidationMessage = "Spacing must be greater than zero.";
            return;
        }

        // Cover is in current unit system. Convert to mm if imperial.
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        var boundary = IrregularInput.BoundaryPoints
            .Select(p => new Point2D(p.X * factor, p.Y * factor))
            .ToList();

        double barDiameter = selectedBar.DiameterMm;
        double coverMm = Cover * factor;
        double spacingMm = spacing * factor;
        double offsetMm = coverMm + barDiameter / 2.0;

        // Offset the boundary polygon
        System.Collections.Generic.IReadOnlyList<Point2D> insetPolygon;
        try
        {
            insetPolygon = PolygonGeometry.OffsetPolygon(boundary, offsetMm);
        }
        catch (System.Exception ex)
        {
            IrregularInput.RebarValidationMessage = $"Failed to offset polygon: {ex.Message}";
            return;
        }

        if (insetPolygon == null || insetPolygon.Count < 3)
        {
            IrregularInput.RebarValidationMessage = "Lớp bảo vệ (Cover) quá lớn làm co đa giác về rỗng hoặc không hợp lệ.";
            return;
        }

        // Generate rebars along the inset polygon
        _generatingRebarsDepth++;
        try
        {
            IrregularInput.Rebars.Clear();
            int rebarIndex = 1;

            int n = insetPolygon.Count;
            for (int i = 0; i < n; i++)
            {
                var pStart = insetPolygon[i];
                var pEnd = insetPolygon[(i + 1) % n];

                double dx = pEnd.X - pStart.X;
                double dy = pEnd.Y - pStart.Y;
                double len = System.Math.Sqrt(dx * dx + dy * dy);

                int segments = (int)System.Math.Max(1, System.Math.Ceiling(len / spacingMm));
                for (int j = 0; j < segments; j++)
                {
                    double t = (double)j / segments;
                    double rx = pStart.X + t * dx;
                    double ry = pStart.Y + t * dy;

                    double rxUser = rx / factor;
                    double ryUser = ry / factor;

                    IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
                    {
                        RebarIndex = rebarIndex.ToString(),
                        X = System.Math.Round(rxUser, 2),
                        Y = System.Math.Round(ryUser, 2),
                        BarSize = selectedBar.Name,
                        AreaMm2 = selectedBar.AreaMm2
                    });
                    rebarIndex++;
                }
            }

            IrregularInput.RebarValidationMessage = "";
        }
        finally
        {
            _generatingRebarsDepth--;
        }
    }

    private void GenerateEqualSpacingRebars()
    {
        GenerateEqualSpacingRebarsInternal();
        UpdateSectionPreview();
    }

    private void GenerateEqualSpacingRebarsInternal()
    {
        if (Cover <= 0)
        {
            return;
        }

        var available = AvailableBars;
        var selectedBar = available.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? available.FirstOrDefault();
        if (selectedBar == null)
        {
            return;
        }

        double spacing = Spacing;
        if (spacing <= 0)
        {
            return;
        }

        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        double coverMm = Cover * factor;
        double spacingMm = spacing * factor;
        double barDiameter = selectedBar.DiameterMm;

        _generatingRebarsDepth++;
        try
        {
            if (IsCircularSection)
            {
                double diameterMm = Diameter * factor;
                double radiusMm = diameterMm / 2.0 - coverMm - barDiameter / 2.0;
                if (radiusMm <= 0) return;

                double perimeterMm = 2.0 * Math.PI * radiusMm;
                int effectiveBarCount = (int)Math.Max(4, Math.Round(perimeterMm / spacingMm));

                double previewRadius = radiusMm / factor;
                IrregularInput.Rebars.Clear();
                for (int i = 0; i < effectiveBarCount; i++)
                {
                    double angle = 2.0 * Math.PI * i / effectiveBarCount + Math.PI / 2.0;
                    double x = previewRadius * Math.Cos(angle);
                    double y = previewRadius * Math.Sin(angle);

                    IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
                    {
                        RebarIndex = (i + 1).ToString(),
                        X = Math.Round(x, 2),
                        Y = Math.Round(y, 2),
                        BarSize = selectedBar.Name,
                        AreaMm2 = selectedBar.AreaMm2
                    });
                }
            }
            else if (IsRectangularSection)
            {
                double w = Width;
                double h = Height;
                var boundary = new List<Point2D>
                {
                    new Point2D(-w / 2.0, h / 2.0),
                    new Point2D(w / 2.0, h / 2.0),
                    new Point2D(w / 2.0, -h / 2.0),
                    new Point2D(-w / 2.0, -h / 2.0)
                };

                var boundaryMm = boundary.Select(p => new Point2D(p.X * factor, p.Y * factor)).ToList();
                double offsetMm = coverMm + barDiameter / 2.0;

                System.Collections.Generic.IReadOnlyList<Point2D> insetPolygon;
                try
                {
                    insetPolygon = PolygonGeometry.OffsetPolygon(boundaryMm, offsetMm);
                }
                catch
                {
                    return;
                }

                if (insetPolygon == null || insetPolygon.Count < 3)
                {
                    return;
                }

                IrregularInput.Rebars.Clear();
                int rebarIndex = 1;
                int n = insetPolygon.Count;
                for (int i = 0; i < n; i++)
                {
                    var pStart = insetPolygon[i];
                    var pEnd = insetPolygon[(i + 1) % n];

                    double dx = pEnd.X - pStart.X;
                    double dy = pEnd.Y - pStart.Y;
                    double len = System.Math.Sqrt(dx * dx + dy * dy);

                    int segments = (int)System.Math.Max(1, System.Math.Ceiling(len / spacingMm));
                    for (int j = 0; j < segments; j++)
                    {
                        double t = (double)j / segments;
                        double rx = pStart.X + t * dx;
                        double ry = pStart.Y + t * dy;

                        double rxUser = rx / factor;
                        double ryUser = ry / factor;

                        IrregularInput.Rebars.Add(new IrregularRebarRowViewModel
                        {
                            RebarIndex = rebarIndex.ToString(),
                            X = System.Math.Round(rxUser, 2),
                            Y = System.Math.Round(ryUser, 2),
                            BarSize = selectedBar.Name,
                            AreaMm2 = selectedBar.AreaMm2
                        });
                        rebarIndex++;
                    }
                }
            }
        }
        finally
        {
            _generatingRebarsDepth--;
        }
    }
}

public sealed record DesignCodeOption(DesignCodeType Code, string DisplayName);
public sealed record Ec2SolverOption(Ec2SolverType Solver, string DisplayName);
public sealed record SectionIntegrationMethodOption(SectionIntegrationMethod Method, string DisplayName);
public sealed record MaterialLibraryOption(MaterialLibraryType Library, string DisplayName);

public enum MaterialLibraryType
{
    America,
    Europe,
    Custom
}

public sealed record MaterialGradeOption(
    string DisplayName,
    double MetricValue,
    double? ImperialValue = null,
    double? MetricModulus = null,
    double? ImperialModulus = null)
{
    private const double MpaPerKsi = 6.894757293168;

    public double StressValue(UnitSystem unitSystem)
        => unitSystem == UnitSystem.Metric ? MetricValue : ImperialValue ?? MetricValue / MpaPerKsi;

    public double? ModulusValue(UnitSystem unitSystem)
        => unitSystem == UnitSystem.Metric ? MetricModulus : ImperialModulus ?? MetricModulus / MpaPerKsi;
}
