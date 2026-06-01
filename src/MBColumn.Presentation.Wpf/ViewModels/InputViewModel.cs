using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.ImportExport;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.RebarSuggestion;
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
    private DesignCodeType selectedDesignCode = DesignCodeType.Ec2;
    private Ec2SolverType selectedEc2Solver = Ec2SolverType.Fiber;
    private EurocodeConcreteStrainProfile selectedEurocodeConcreteStrainProfile = EurocodeConcreteStrainProfile.Ec2;
    private SectionIntegrationMethod selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
    private readonly IRebarDatabase metricBars;
    private readonly IRebarDatabase imperialBars;
    private readonly IRebarCoordinateBuilderService rebarCoordinateBuilder;
    private readonly IDxfImportDialogService? dxfImportDialogService;
    private readonly IAutoDesignRebarDialogService? autoDesignRebarDialogService;
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
    private MaterialLibraryType selectedMaterialLibrary = MaterialLibraryType.Europe;
    private RebarSetLibraryType selectedRebarSetLibrary = RebarSetLibraryType.SingaporeMetric;
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
    private double gammaC = 1.50;
    private double? memberLengthL;
    private bool includeEc2Slenderness;
    private double? kx = 1.0;
    private double? ky = 1.0;
    private double? phiEff;
    private bool useDefaultAWhenPhiEffUnknown = true;
    private double stirrupDiameterMm = 10.0;
    private RebarDefinition? selectedStirrupBar;
    private double linkSpacingMm = 200.0;
    private string selectedCircularHoopType = "Closed hoop";
    private int innerLegsX = 0;
    private int innerLegsY = 0;
    // EC2 link check results (updated in UpdateEc2LinkChecks)
    private string ec2Check1Text = "—";
    private bool ec2Check1Pass = true;
    private string ec2Check2Text = "—";
    private bool ec2Check2Pass = true;
    private string ec2Check3Text = "—";
    private bool ec2Check3Pass = true;
    private string ec2AswsXText = "—";
    private string ec2AswsYText = "—";
    private string ec2AswsXLatex = "";
    private string ec2AswsYLatex = "";
    private bool _isUpdatingPreview = false;
    private string previewAreaText = "—";
    private string previewIxxText = "—";
    private string previewIyyText = "—";
    private string previewIxText = "—";
    private string previewIyText = "—";
    private string previewAsTotalText = "—";
    private string previewFcdText = "—";
    private string previewFydText = "—";
    private string previewEcmText = "—";
    private string previewDxText = "—";
    private string previewDyText = "—";
    private string previewOmegaText = "—";
    private string previewNRatioText = "—";
    private string previewRebarPercentageText = "—";
    private string previewShapeSummaryText = "";
    private string previewRebarLayoutText = "";
    private int _generatingRebarsDepth = 0;
    private bool _isGeneratingRebars => _generatingRebarsDepth > 0;
    private bool isDxfImportedSection = false;
    private int nextLoadCaseIndex = 2;
    private bool isApplyingMaterialPreset = false;
    private string designTierName = "";
    private string designTierSource = "";
    private EtabsTierImportMetadataDto? etabsTierMetadata;
    private EtabsImportMetadataDto? etabsMetadata;
    private LoadCaseViewModel? selectedLoadCase;
    private LoadCaseViewModel? slendernessCalculationLoadCase;
    private bool isSlendernessCalculationDetailsOpen;
    private bool isRefreshingSlendernessState;

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
        IDxfImportDialogService? dxfImportDialogService = null,
        IAutoDesignRebarDialogService? autoDesignRebarDialogService = null)
    {
        this.metricBars = metricBars;
        this.imperialBars = imperialBars;
        this.rebarCoordinateBuilder = rebarCoordinateBuilder;
        this.dxfImportDialogService = dxfImportDialogService;
        this.autoDesignRebarDialogService = autoDesignRebarDialogService;
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
        LoadCases.CollectionChanged += LoadCases_CollectionChanged;
        ApplyMetricDefaults();
        SelectedLoadCase = LoadCases.FirstOrDefault();
        RefreshSlendernessUiState();
        UpdateSectionPreview();
        AddLoadCaseCommand = new RelayCommand(AddLoadCase);
        DuplicateLoadCaseCommand = new RelayCommand<LoadCaseViewModel>(DuplicateLoadCase);
        DeleteLoadCaseCommand = new RelayCommand<LoadCaseViewModel>(DeleteLoadCase);
        DeleteSelectedLoadCasesCommand = new RelayCommand<object>(DeleteSelectedLoadCases);
        RemoveDuplicateLoadCasesCommand = new RelayCommand(RemoveDuplicateLoadCases);
        ImportLoadCasesCommand = new RelayCommand(ImportLoadCases);
        ExportLoadCasesCommand = new RelayCommand(ExportLoadCases);
        GenerateIrregularRebarsCommand = new RelayCommand(GenerateIrregularRebars);
        GenerateEqualSpacingRebarsCommand = new RelayCommand(GenerateEqualSpacingRebars);
        ImportDxfCommand = new RelayCommand(ImportDxf, () => this.dxfImportDialogService is not null);
        ExportDxfCommand = new RelayCommand(ExportDxf, () => IsIrregularSection && IrregularInput.BoundaryPoints.Count >= 3);
        ShowSlendernessCalculationDetailsCommand = new RelayCommand<object?>(
            ShowSlendernessCalculationDetails,
            loadCase => IncludeEc2Slenderness && loadCase is LoadCaseViewModel);
        CloseSlendernessCalculationDetailsCommand = new RelayCommand(CloseSlendernessCalculationDetails);
        AutoDesignRebarCommand = new RelayCommand(
            OpenAutoDesignRebar,
            () => autoDesignRebarDialogService is not null && IsRectangularSection);
    }

    public IReadOnlyList<UnitSystem> UnitSystems { get; } = [UnitSystem.Metric, UnitSystem.Imperial];
    public ICommand GenerateIrregularRebarsCommand { get; }
    public ICommand GenerateEqualSpacingRebarsCommand { get; }
    public ICommand ImportDxfCommand { get; }
    public ICommand ExportDxfCommand { get; }
    public ICommand AutoDesignRebarCommand { get; }
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

    public IReadOnlyList<RebarSetLibraryOption> RebarSetLibraries { get; } =
    [
        new(RebarSetLibraryType.SingaporeMetric, "Metric / Singapore T bars"),
        new(RebarSetLibraryType.UnitedStatesImperial, "US / Imperial # bars")
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
            if (value != MaterialLibraryType.Custom)
            {
                SetRebarSetLibrary(RebarSetLibraryFor(value), resetSelections: true);
            }
        }
    }

    public IReadOnlyList<MaterialGradeOption> AvailableConcreteGrades => ConcreteGradesFor(selectedMaterialLibrary);
    public IReadOnlyList<MaterialGradeOption> AvailableSteelGrades => SteelGradesFor(selectedMaterialLibrary);
    public bool AreMaterialGradesEnabled => selectedMaterialLibrary != MaterialLibraryType.Custom;
    public bool AreMaterialInputsEnabled => selectedMaterialLibrary == MaterialLibraryType.Custom;

    public RebarSetLibraryType SelectedRebarSetLibrary
    {
        get => selectedRebarSetLibrary;
        set => SetRebarSetLibrary(value, resetSelections: true);
    }

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
            Raise(nameof(ShowEurocodeConcreteStrainProfileOption));
            Raise(nameof(ShowAlphaCcOption));
            RaiseMaterialDerivedProperties();
        }
    }
    public string FcLabel => selectedDesignCode == DesignCodeType.Ec2 ? "fck" : "f'c";
    public string FyLabel => selectedDesignCode == DesignCodeType.Ec2 ? "fyk" : "fy";

    public IReadOnlyList<Ec2SolverOption> Ec2SolverOptions { get; } =
    [
        new(Ec2SolverType.Fiber, "Fiber")
    ];

    public IReadOnlyList<EurocodeConcreteStrainProfileOption> EurocodeConcreteStrainProfiles { get; } =
    [
        new(EurocodeConcreteStrainProfile.Ec2, "EC2 (εc2 / εcu2)"),
        new(EurocodeConcreteStrainProfile.Ec3, "EC3 (εc3 / εcu3)")
    ];

    public Ec2SolverType SelectedEc2Solver
    {
        get => selectedEc2Solver;
        set => Set(ref selectedEc2Solver, value);
    }

    public bool ShowEc2SolverOption => selectedDesignCode == DesignCodeType.Ec2;

    public EurocodeConcreteStrainProfile SelectedEurocodeConcreteStrainProfile
    {
        get => selectedEurocodeConcreteStrainProfile;
        set
        {
            if (!Set(ref selectedEurocodeConcreteStrainProfile, value)) return;
            RaiseMaterialDerivedProperties();
        }
    }

    public bool ShowEurocodeConcreteStrainProfileOption => selectedDesignCode == DesignCodeType.Ec2;

    public double AlphaCc
    {
        get => alphaCc;
        set
        {
            if (!Set(ref alphaCc, value)) return;
            RaiseMaterialDerivedProperties();
            RefreshSlendernessUiState();
        }
    }
    public double GammaC
    {
        get => gammaC;
        set
        {
            if (!Set(ref gammaC, value)) return;
            RaiseMaterialDerivedProperties();
            RefreshSlendernessUiState();
        }
    }
    public bool ShowAlphaCcOption => selectedDesignCode == DesignCodeType.Ec2;
    public double? MemberLengthL
    {
        get => memberLengthL;
        set
        {
            if (!Set(ref memberLengthL, value)) return;
            Raise(nameof(MemberLengthLInM));
            Raise(nameof(L0xText));
            Raise(nameof(L0yText));
            Raise(nameof(L0xLatex));
            Raise(nameof(L0yLatex));
            RaiseImperfectionLatex();
            RefreshSlendernessUiState();
        }
    }
    public double? MemberLengthLInM
    {
        get => memberLengthL.HasValue ? memberLengthL / 1000.0 : (double?)null;
        set => MemberLengthL = value.HasValue ? value * 1000.0 : (double?)null;
    }
    public bool IncludeEc2Slenderness
    {
        get => includeEc2Slenderness;
        set
        {
            Set(ref includeEc2Slenderness, value);
            Raise(nameof(DemandInputModeText));
            Raise(nameof(SlendernessSettingsVisibility));
            if (!includeEc2Slenderness)
            {
                CloseSlendernessCalculationDetails();
            }
            RefreshSlendernessUiState();
        }
    }
    public double? Kx
    {
        get => kx;
        set
        {
            if (!Set(ref kx, value)) return;
            Raise(nameof(L0xText));
            Raise(nameof(L0xLatex));
            RaiseImperfectionLatex();
            RefreshSlendernessUiState();
        }
    }
    public double? Ky
    {
        get => ky;
        set
        {
            if (!Set(ref ky, value)) return;
            Raise(nameof(L0yText));
            Raise(nameof(L0yLatex));
            RaiseImperfectionLatex();
            RefreshSlendernessUiState();
        }
    }
    public double? PhiEff
    {
        get => phiEff;
        set
        {
            if (!Set(ref phiEff, value)) return;
            useDefaultAWhenPhiEffUnknown = !value.HasValue;
            Raise(nameof(UseDefaultAWhenPhiEffUnknown));
            Raise(nameof(AFactorDisplayText));
            RefreshSlendernessUiState();
        }
    }
    public bool UseDefaultAWhenPhiEffUnknown
    {
        get => useDefaultAWhenPhiEffUnknown;
        set => Set(ref useDefaultAWhenPhiEffUnknown, value);
    }
    public string AFactorDisplayText =>
        !PhiEff.HasValue
            ? "A = 0.7 (fallback, φeff blank)"
            : $"A = 1/(1+0.2×{PhiEff:F2}) = {1.0 / (1.0 + 0.2 * PhiEff.Value):F3}";
    public string DemandInputModeText => IncludeEc2Slenderness
        ? "Demand input mode: Member end forces"
        : "Demand input mode: Direct section forces";
    public bool SlendernessSettingsVisibility => IncludeEc2Slenderness;
    public string L0xText => MemberLengthL is > 0 && Kx is > 0 ? $"{Kx.Value * MemberLengthL.Value / 1000.0:F2}" : "auto";
    public string L0yText => MemberLengthL is > 0 && Ky is > 0 ? $"{Ky.Value * MemberLengthL.Value / 1000.0:F2}" : "auto";
    public string L0xLatex => MemberLengthL is > 0 && Kx is > 0
        ? $@"l_{{0x}}=k_xL={Kx.Value:F2}\times{MemberLengthL.Value:F0}={Kx.Value * MemberLengthL.Value:F0}\;\mathrm{{mm}}"
        : @"l_{0x}=k_xL";
    public string L0yLatex => MemberLengthL is > 0 && Ky is > 0
        ? $@"l_{{0y}}=k_yL={Ky.Value:F2}\times{MemberLengthL.Value:F0}={Ky.Value * MemberLengthL.Value:F0}\;\mathrm{{mm}}"
        : @"l_{0y}=k_yL";
    public string ImperfectionFormulaLatex => @"e_i=\frac{l_0}{400},\quad M_i=N_{Ed}e_i";
    public string MinimumEccentricityFormulaLatex => @"e_0=\max\left(\frac{h}{30},20\;\text{mm}\right),\quad M_{used}\geq N_{Ed}e_0";
    public string ImperfectionXCalculationLatex => BuildImperfectionAxisLatex("x", Kx);
    public string ImperfectionYCalculationLatex => BuildImperfectionAxisLatex("y", Ky);
    public string MinimumEccentricityXCalculationLatex => BuildMinimumEccentricityAxisLatex("x", CurrentSectionHeightMm());
    public string MinimumEccentricityYCalculationLatex => BuildMinimumEccentricityAxisLatex("y", CurrentSectionWidthMm());
    public string ImperfectionCalculationText => BuildImperfectionCalculationText();
    public string MinimumEccentricityCalculationText => BuildMinimumEccentricityCalculationText();

    public IReadOnlyList<RebarDefinition> AvailableStirrupBars => AvailableBars;

    public RebarDefinition SelectedStirrupBar
    {
        get => selectedStirrupBar
            ?? AvailableBars.FirstOrDefault(b => Math.Abs(b.DiameterMm - 10.0) < 0.1)
            ?? AvailableBars.First();
        set
        {
            if (Equals(selectedStirrupBar, value)) return;
            selectedStirrupBar = value;
            stirrupDiameterMm = value?.DiameterMm ?? 10.0;
            Raise();
            Raise(nameof(StirrupDiameterMm));
            Raise(nameof(CircularHoopCentrelineDiameter));
            Raise(nameof(CircularHoopCentrelineDiameterText));
            UpdateSectionPreview();
        }
    }

    public double StirrupDiameterMm => stirrupDiameterMm;
    public double CircularHoopCentrelineDiameterMm
    {
        get
        {
            double diameterMm = UnitSystem == UnitSystem.Metric ? Diameter : Diameter * 25.4;
            double coverMm = UnitSystem == UnitSystem.Metric ? Cover : Cover * 25.4;
            return Math.Max(diameterMm - 2.0 * coverMm - StirrupDiameterMm, 0.0);
        }
    }
    public double CircularHoopCentrelineDiameter =>
        UnitSystem == UnitSystem.Metric ? CircularHoopCentrelineDiameterMm : CircularHoopCentrelineDiameterMm / 25.4;
    public string CircularHoopCentrelineDiameterText => CircularHoopCentrelineDiameterMm > 0
        ? $"{CircularHoopCentrelineDiameter:F2}"
        : "auto";
    public IReadOnlyList<string> CircularHoopTypes { get; } = ["Closed hoop", "Spiral"];
    public string SelectedCircularHoopType
    {
        get => selectedCircularHoopType;
        set
        {
            if (selectedCircularHoopType == value) return;
            Set(ref selectedCircularHoopType, value);
            UpdateSectionPreview();
        }
    }
    public double LinkSpacingMm
    {
        get => linkSpacingMm;
        set
        {
            if (linkSpacingMm == value) return;
            Set(ref linkSpacingMm, value);
            Raise(nameof(LinkSpacing));
            UpdateEc2LinkChecks();
        }
    }

    public double LinkSpacing
    {
        get => UnitSystem == UnitSystem.Metric ? linkSpacingMm : linkSpacingMm / 25.4;
        set
        {
            double valueMm = UnitSystem == UnitSystem.Metric ? value : value * 25.4;
            if (Math.Abs(linkSpacingMm - valueMm) <= 1e-9) return;
            linkSpacingMm = valueMm;
            Raise();
            Raise(nameof(LinkSpacingMm));
            UpdateEc2LinkChecks();
        }
    }

    // Maximum inner legs X = intermediate bars on top face = Top.BarCount - 2 (strip corners)
    // For AllSidesEqual/EqualSpacing: Left.BarCount is seeded as perSide (n+2), so subtract 2 to get intermediate
    // For SidesDifferent: Left.BarCount is already the user-entered intermediate count
    public int MaxInnerLegsX => IsRectangularSection ? Math.Max(0, RebarLayout.Top.BarCount - 2) : 0;
    public int MaxInnerLegsY => IsRectangularSection
        ? (selectedRebarLayoutType == RebarLayoutType.SidesDifferent
            ? Math.Max(0, RebarLayout.Left.BarCount)
            : Math.Max(0, RebarLayout.Left.BarCount - 2))
        : 0;

    public int InnerLegsX
    {
        get => innerLegsX;
        set
        {
            if (value < 0) value = 0;
            value = Math.Min(value, MaxInnerLegsX);
            if (innerLegsX == value) return;
            innerLegsX = value;
            Raise();
            Raise(nameof(TotalLegsX));
            UpdateEc2LinkChecks();
            UpdateSectionPreview();
        }
    }

    public int InnerLegsY
    {
        get => innerLegsY;
        set
        {
            if (value < 0) value = 0;
            value = Math.Min(value, MaxInnerLegsY);
            if (innerLegsY == value) return;
            innerLegsY = value;
            Raise();
            Raise(nameof(TotalLegsY));
            UpdateEc2LinkChecks();
            UpdateSectionPreview();
        }
    }

    public int TotalLegsX => 2 + innerLegsX;
    public int TotalLegsY => 2 + innerLegsY;

    public string Ec2Check1Text { get => ec2Check1Text; private set => Set(ref ec2Check1Text, value); }
    public bool Ec2Check1Pass { get => ec2Check1Pass; private set => Set(ref ec2Check1Pass, value); }
    public string Ec2Check2Text { get => ec2Check2Text; private set => Set(ref ec2Check2Text, value); }
    public bool Ec2Check2Pass { get => ec2Check2Pass; private set => Set(ref ec2Check2Pass, value); }
    public string Ec2Check3Text { get => ec2Check3Text; private set => Set(ref ec2Check3Text, value); }
    public bool Ec2Check3Pass { get => ec2Check3Pass; private set => Set(ref ec2Check3Pass, value); }
    public string Ec2AswsXText { get => ec2AswsXText; private set => Set(ref ec2AswsXText, value); }
    public string Ec2AswsYText { get => ec2AswsYText; private set => Set(ref ec2AswsYText, value); }
    public string Ec2AswsXLatex { get => ec2AswsXLatex; private set => Set(ref ec2AswsXLatex, value); }
    public string Ec2AswsYLatex { get => ec2AswsYLatex; private set => Set(ref ec2AswsYLatex, value); }

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
    public IReadOnlyList<RebarDefinition> AvailableBars => ActiveRebarDatabase.GetBars();
    public string LengthLabel => UnitSystem == UnitSystem.Metric ? "mm" : "in";
    public string AreaLabel => UnitSystem == UnitSystem.Metric ? "mm²" : "in²";
    public string ForceLabel => UnitSystem == UnitSystem.Metric ? "kN" : "kip";
    public string MomentLabel => UnitSystem == UnitSystem.Metric ? "kN-m" : "kip-ft";
    public string StressLabel => UnitSystem == UnitSystem.Metric ? "MPa" : "ksi";
    public string DemandForceHeader => $"NEd ({ForceLabel})";
    public string DemandMomentXHeader => $"Mx ({MomentLabel})";
    public string DemandMomentYHeader => $"My ({MomentLabel})";
    public string ShearVuxHeader => $"Vx ({ForceLabel})";
    public string ShearVuyHeader => $"Vy ({ForceLabel})";
    public string MxTopHeader => $"Mx Top ({MomentLabel})";
    public string MxBottomHeader => $"Mx Bottom ({MomentLabel})";
    public string MyTopHeader => $"My Top ({MomentLabel})";
    public string MyBottomHeader => $"My Bottom ({MomentLabel})";
    public string MxUsedHeader => $"Mx Used ({MomentLabel})";
    public string MyUsedHeader => $"My Used ({MomentLabel})";
    public string RebarDiameterUnitLabel => selectedRebarSetLibrary == RebarSetLibraryType.SingaporeMetric ? "mm" : "in";
    public string LinkSpacingUnitLabel => LengthLabel;

    public UnitSystem UnitSystem
    {
        get => unitSystem;
        set
        {
            if (unitSystem == value) return;
            unitSystem = value;
            if (unitSystem == UnitSystem.Metric) ApplyMetricDefaults(); else ApplyImperialDefaults();
            Raise(nameof(UnitSystem));
            Raise(nameof(SelectedRebarSetLibrary));
            Raise(nameof(AvailableBars));
            Raise(nameof(AvailableStirrupBars));
            Raise(nameof(SelectedStirrupBar));
            Raise(nameof(LengthLabel));
            Raise(nameof(AreaLabel));
            Raise(nameof(ForceLabel));
            Raise(nameof(MomentLabel));
            Raise(nameof(StressLabel));
            RaiseUnitDependentLabels();
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
            if (width <= 0) width = isMetric ? 700 : 28;
            if (height <= 0) height = isMetric ? 700 : 28;
            if (cover <= 0) cover = isMetric ? 55 : 2.2;
            if (string.IsNullOrEmpty(barSize)) barSize = DefaultMainBarName(selectedRebarSetLibrary);
            if (barCount <= 0) barCount = 28;

            selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
            layoutPreset = "All Sides Equal";
            SyncSideGlobalInputs();
            SeedSideCountsFromTotalBars();
        }
        else if (shape == SectionShapeType.Circular)
        {
            if (diameter <= 0) diameter = isMetric ? 700 : 28;
            if (cover <= 0) cover = isMetric ? 55 : 2.2;
            if (string.IsNullOrEmpty(barSize)) barSize = DefaultMainBarName(selectedRebarSetLibrary);
            if (barCount <= 0) barCount = 28;
            if (spacing <= 0) spacing = isMetric ? 150 : 6;

            selectedRebarLayoutType = RebarLayoutType.EqualSpacing;
            layoutPreset = "Equal Spacing";
            GenerateEqualSpacingRebars();
        }
        else if (shape == SectionShapeType.Irregular)
        {
            if (cover <= 0) cover = isMetric ? 55 : 2.2;
            if (string.IsNullOrEmpty(IrregularInput.BarSize)) IrregularInput.BarSize = DefaultMainBarName(selectedRebarSetLibrary);
            if (IrregularInput.Spacing <= 0) IrregularInput.Spacing = isMetric ? 150 : 6;

            selectedRebarLayoutType = RebarLayoutType.EqualSpacing;
            layoutPreset = "Equal Spacing";
            IrregularInput.RebarMode = IrregularRebarModeType.EqualSpacing;

            if (IrregularInput.BoundaryPoints.Count == 0)
            {
                _generatingRebarsDepth++;
                try
                {
                    IrregularInput.LoadDefaultLShape();
                }
                finally
                {
                    _generatingRebarsDepth--;
                }
            }
            GenerateIrregularRebars();
        }
    }

    private static RebarLayoutType CoerceRebarLayoutForShape(RebarLayoutType layoutType, SectionShapeType shape)
    {
        if (shape == SectionShapeType.Circular)
        {
            return layoutType == RebarLayoutType.CustomCoordinates
                ? RebarLayoutType.CustomCoordinates
                : RebarLayoutType.EqualSpacing;
        }

        if (shape == SectionShapeType.Irregular)
        {
            return layoutType == RebarLayoutType.CustomCoordinates
                ? RebarLayoutType.CustomCoordinates
                : RebarLayoutType.EqualSpacing;
        }

        return layoutType;
    }

    private static string RebarLayoutDisplayName(RebarLayoutType layoutType)
        => layoutType switch
        {
            RebarLayoutType.AllSidesEqual => "All Sides Equal",
            RebarLayoutType.EqualSpacing => "Equal Spacing",
            RebarLayoutType.CustomCoordinates => "Custom Coordinates",
            _ => "Sides Different"
        };

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
    public double Diameter { get => diameter; set { Set(ref diameter, value); Raise(nameof(SectionWidth)); Raise(nameof(SectionHeight)); Raise(nameof(CircularHoopCentrelineDiameter)); Raise(nameof(CircularHoopCentrelineDiameterText)); UpdateSectionPreview(); } }
    public double Cover { get => cover; set { Set(ref cover, value); Raise(nameof(CircularHoopCentrelineDiameter)); Raise(nameof(CircularHoopCentrelineDiameterText)); SyncSideGlobalInputs(); UpdateSectionPreview(); } }
    public string BarSize { get => barSize; set { Set(ref barSize, value); Raise(nameof(SelectedRebarSize)); SyncSideGlobalInputs(); UpdateSectionPreview(); } }
    public int BarCount { get => barCount; set { Set(ref barCount, value); Raise(nameof(NumberOfBars)); SyncEqualSideCounts(); UpdateSectionPreview(); } }
    public string LayoutPreset { get => layoutPreset; set { Set(ref layoutPreset, value); Raise(nameof(SelectedRebarLayout)); UpdateSectionPreview(); } }
    public RebarLayoutType SelectedRebarLayoutType
    {
        get => selectedRebarLayoutType;
        set
        {
            value = CoerceRebarLayoutForShape(value, SelectedSectionShape);
            if (selectedRebarLayoutType == value) return;
            selectedRebarLayoutType = value;
            layoutPreset = RebarLayoutDisplayName(value);
            if (selectedRebarLayoutType == RebarLayoutType.SidesDifferent && IsRectangularSection)
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
            Raise(nameof(ShowTotalBarsInput));
            Raise(nameof(IsRectangularEqualSpacingLayout));
            UpdateSectionPreview();
        }
    }
    public double Fc
    {
        get => fc;
        set
        {
            if (!Set(ref fc, value)) return;
            if (!isApplyingMaterialPreset) SyncSelectedConcreteGradeToValue();
            RaiseMaterialDerivedProperties();
            RefreshSlendernessUiState();
        }
    }

    public double Fy
    {
        get => fy;
        set
        {
            if (!Set(ref fy, value)) return;
            if (!isApplyingMaterialPreset) SyncSelectedSteelGradeToValue();
            RaiseMaterialDerivedProperties();
            RefreshSlendernessUiState();
        }
    }

    public double Es
    {
        get => es;
        set
        {
            if (!Set(ref es, value)) return;
            RaiseMaterialDerivedProperties();
            RefreshSlendernessUiState();
        }
    }
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
    public ICommand DuplicateLoadCaseCommand { get; }
    public ICommand DeleteLoadCaseCommand { get; }
    public ICommand DeleteSelectedLoadCasesCommand { get; }
    public ICommand RemoveDuplicateLoadCasesCommand { get; }
    public ICommand ImportLoadCasesCommand { get; }
    public ICommand ExportLoadCasesCommand { get; }
    public ICommand ShowSlendernessCalculationDetailsCommand { get; }
    public ICommand CloseSlendernessCalculationDetailsCommand { get; }

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
    public string PreviewIxText { get => previewIxText; private set => Set(ref previewIxText, value); }
    public string PreviewIyText { get => previewIyText; private set => Set(ref previewIyText, value); }
    public string PreviewAsTotalText { get => previewAsTotalText; private set => Set(ref previewAsTotalText, value); }
    public string PreviewFcdText { get => previewFcdText; private set => Set(ref previewFcdText, value); }
    public string PreviewFydText { get => previewFydText; private set => Set(ref previewFydText, value); }
    public string PreviewEcmText { get => previewEcmText; private set => Set(ref previewEcmText, value); }
    public string PreviewDxText { get => previewDxText; private set => Set(ref previewDxText, value); }
    public string PreviewDyText { get => previewDyText; private set => Set(ref previewDyText, value); }
    public string PreviewOmegaText { get => previewOmegaText; private set => Set(ref previewOmegaText, value); }
    public string PreviewNRatioText { get => previewNRatioText; private set => Set(ref previewNRatioText, value); }
    public string PreviewRebarPercentageText { get => previewRebarPercentageText; private set => Set(ref previewRebarPercentageText, value); }
    public string PreviewShapeSummaryText { get => previewShapeSummaryText; private set => Set(ref previewShapeSummaryText, value); }
    public string PreviewRebarLayoutText { get => previewRebarLayoutText; private set => Set(ref previewRebarLayoutText, value); }
    public LoadCaseViewModel? SelectedLoadCase
    {
        get => selectedLoadCase;
        set
        {
            if (ReferenceEquals(selectedLoadCase, value)) return;
            Set(ref selectedLoadCase, value);
            UpdateSectionPropertiesPanel();
        }
    }
    public LoadCaseViewModel? SlendernessCalculationLoadCase
    {
        get => slendernessCalculationLoadCase;
        private set
        {
            Set(ref slendernessCalculationLoadCase, value);
            Raise(nameof(ImperfectionCalculationText));
            Raise(nameof(MinimumEccentricityCalculationText));
            RaiseImperfectionLatex();
        }
    }
    public bool IsSlendernessCalculationDetailsOpen
    {
        get => isSlendernessCalculationDetailsOpen;
        private set => Set(ref isSlendernessCalculationDetailsOpen, value);
    }
    public string SlendernessWarningText => BuildSlendernessWarningText();
    public bool HasSlendernessWarnings => !string.IsNullOrWhiteSpace(SlendernessWarningText);
    public string FcdDisplayText => Fc > 0 && GammaC > 0 ? $"{AlphaCc * StressInputToMpa(Fc) / GammaC:F2}" : "auto";
    public string FcmDisplayText => Fc > 0 ? $"{StressInputToMpa(Fc) + 8.0:F2}" : "auto";
    public string EcmDisplayText => Fc > 0 ? $"{22000.0 * Math.Pow((StressInputToMpa(Fc) + 8.0) / 10.0, 0.3):F0}" : "auto";

    public bool IsEc2 => SelectedDesignCode == DesignCodeType.Ec2;
    public string ConcreteUltimateStrainSubscript => IsEc2 && selectedEurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3 ? "cu3" : IsEc2 ? "cu2" : "cu";
    public string ConcretePeakStrainSubscript => IsEc2 && selectedEurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3 ? "c3" : IsEc2 ? "c2" : "c0";
    public string ConcreteUltimateStrainLabel => "\u03b5" + ConcreteUltimateStrainSubscript;
    public string ConcretePeakStrainLabel => "\u03b5" + ConcretePeakStrainSubscript;
    
    public double EpsilonC2
    {
        get
        {
            if (IsEc2)
            {
                double fck = StressInputToMpa(Fc);
                return selectedEurocodeConcreteStrainProfile == EurocodeConcreteStrainProfile.Ec3
                    ? EurocodeConcreteStrainProfileValues.Ec3Peak(fck)
                    : EurocodeConcreteStrainProfileValues.Ec2Peak(fck);
            }
            return 0.0020;
        }
    }

    public double EpsilonCu2
    {
        get
        {
            if (IsEc2)
            {
                double fck = StressInputToMpa(Fc);
                return EurocodeConcreteStrainProfileValues.Ec2Ultimate(fck);
            }
            return 0.003;
        }
    }

    public double EpsilonYd
    {
        get
        {
            double esVal = StressInputToMpa(Es);
            if (esVal <= 0.0) return 0.0;
            if (IsEc2)
            {
                double fyd = StressInputToMpa(Fy) / 1.15;
                return fyd / esVal;
            }
            return StressInputToMpa(Fy) / esVal;
        }
    }

    public double EpsilonUd => IsEc2 ? 0.045 : 0.08;

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
                EurocodeConcreteStrainProfile = SelectedEurocodeConcreteStrainProfile,
                IntegrationMethod = SectionIntegrationMethod.Polygon,
                AlphaCc = AlphaCc,
                GammaC = GammaC,
                IncludeEc2Slenderness = IncludeEc2Slenderness,
                MemberLengthL = MemberLengthL,
                Kx = Kx,
                Ky = Ky,
                PhiEff = PhiEff,
                UseDefaultAWhenPhiEffUnknown = UseDefaultAWhenPhiEffUnknown,
                RebarSetLibrary = selectedRebarSetLibrary,
                Irregular = irregularDto,
                LinkDiameterMm = stirrupDiameterMm,
                LinkSpacingMm = linkSpacingMm,
                CircularHoopCentrelineDiameterMm = IsCircularSection ? CircularHoopCentrelineDiameterMm : 0.0,
                TotalLegsX = TotalLegsX,
                TotalLegsY = TotalLegsY
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
                    : rebarCoordinateBuilder.BuildCircular(Diameter, Cover, finalBarCount, BarSize, layoutLengthUnit, UnitSystem, stirrupDiameterMm, selectedRebarSetLibrary);
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
                EurocodeConcreteStrainProfile = SelectedEurocodeConcreteStrainProfile,
                IntegrationMethod = SelectedIntegrationMethod,
                AlphaCc = AlphaCc,
                GammaC = GammaC,
                IncludeEc2Slenderness = IncludeEc2Slenderness,
                MemberLengthL = MemberLengthL,
                Kx = Kx,
                Ky = Ky,
                PhiEff = PhiEff,
                UseDefaultAWhenPhiEffUnknown = UseDefaultAWhenPhiEffUnknown,
                RebarSetLibrary = selectedRebarSetLibrary,
                LinkDiameterMm = stirrupDiameterMm,
                LinkSpacingMm = linkSpacingMm,
                CircularHoopCentrelineDiameterMm = CircularHoopCentrelineDiameterMm,
                TotalLegsX = TotalLegsX,
                TotalLegsY = TotalLegsY
            };
        }

        var layout = CreateRebarLayoutInput();
        IReadOnlyList<RebarCoordinateDto>? generatedCoordinates = null;
        try
        {
            generatedCoordinates = IsCustomRebarCoordinates
                ? BuildCustomRebarCoordinates()
                : rebarCoordinateBuilder.Build(layout, Width, Height, layoutLengthUnit, UnitSystem, selectedRebarSetLibrary);
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
            EurocodeConcreteStrainProfile = SelectedEurocodeConcreteStrainProfile,
            IntegrationMethod = SelectedIntegrationMethod,
            AlphaCc = AlphaCc,
            GammaC = GammaC,
            IncludeEc2Slenderness = IncludeEc2Slenderness,
            MemberLengthL = MemberLengthL,
            Kx = Kx,
            Ky = Ky,
            PhiEff = PhiEff,
            UseDefaultAWhenPhiEffUnknown = UseDefaultAWhenPhiEffUnknown,
            RebarSetLibrary = selectedRebarSetLibrary,
            LinkDiameterMm = stirrupDiameterMm,
            LinkSpacingMm = linkSpacingMm,
            CircularHoopCentrelineDiameterMm = IsCircularSection ? CircularHoopCentrelineDiameterMm : 0.0,
            TotalLegsX = TotalLegsX,
            TotalLegsY = TotalLegsY
        };
    }

    public void UpdateSectionPreview()
    {
        ReClampInnerLegs();
        if (_isUpdatingPreview) return;
        _isUpdatingPreview = true;
        try
        {
            UpdateSectionPreviewInternal();
            UpdateEc2LinkChecks();
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
                int ptIndex = 1;
                foreach (var pt in IrregularInput.BoundaryPoints)
                    PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(ptIndex++, pt.X, pt.Y));
                int rebarIndex = 1;
                foreach (var r in IrregularInput.Rebars)
                {
                    double area = r.AreaMm2 ?? 0;
                    double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : 20.0;
                    PreviewRebars.Add(new PreviewRebarPoint(rebarIndex++, r.X, r.Y, diam, r.BarSize ?? ""));
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

            int customRebarIndex = 1;
            foreach (var b in customCoordinates)
            {
                PreviewRebars.Add(new PreviewRebarPoint(customRebarIndex++, b.X, b.Y, b.Diameter, b.BarSizeLabel));
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

            double w = UnitSystem == UnitSystem.Metric ? Width : Width * 25.4;
            double h = UnitSystem == UnitSystem.Metric ? Height : Height * 25.4;
            PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(1, -w / 2.0, h / 2.0));
            PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(2, w / 2.0, h / 2.0));
            PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(3, w / 2.0, -h / 2.0));
            PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(4, -w / 2.0, -h / 2.0));

            double uFactor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
            var uBars = AvailableBars;
            var uBar = uBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? uBars.FirstOrDefault();
            double uBarDiameterMm = uBar?.DiameterMm ?? 20.0;

            int rectEqRebarIndex = 1;
            foreach (var r in IrregularInput.Rebars)
            {
                double area = r.AreaMm2 ?? 0;
                double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : uBarDiameterMm;
                PreviewRebars.Add(new PreviewRebarPoint(rectEqRebarIndex++, r.X, r.Y, diam / uFactor, r.BarSize ?? ""));
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

        double wBase = UnitSystem == UnitSystem.Metric ? Width : Width * 25.4;
        double hBase = UnitSystem == UnitSystem.Metric ? Height : Height * 25.4;
        PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(1, -wBase / 2.0, hBase / 2.0));
        PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(2, wBase / 2.0, hBase / 2.0));
        PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(3, wBase / 2.0, -hBase / 2.0));
        PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(4, -wBase / 2.0, -hBase / 2.0));

        IReadOnlyList<RebarCoordinateDto> bars;
        try
        {
            bars = rebarCoordinateBuilder.Build(CreateRebarLayoutInput(), Width, Height, UnitSystem == UnitSystem.Metric ? LengthUnit.Millimeter : LengthUnit.Inch, UnitSystem, selectedRebarSetLibrary);
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

        int genRebarIndex = 1;
        foreach (var b in bars)
        {
            PreviewRebars.Add(new PreviewRebarPoint(genRebarIndex++, b.X, b.Y, b.Diameter, b.BarSizeLabel));
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

        double boundaryRadius = (UnitSystem == UnitSystem.Metric ? Diameter : Diameter * 25.4) / 2.0;
        int segments = 36;
        for (int i = 0; i < segments; i++)
        {
            double angle = 2.0 * Math.PI * i / segments;
            PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(i + 1, boundaryRadius * Math.Cos(angle), boundaryRadius * Math.Sin(angle)));
        }

        if (SelectedRebarLayoutType == RebarLayoutType.EqualSpacing)
        {
            double cFactor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
            var cBars = AvailableBars;
            var cBar = cBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase)) ?? cBars.FirstOrDefault();
            double cBarDiameterMm = cBar?.DiameterMm ?? 20.0;

            int circEqRebarIndex = 1;
            foreach (var r in IrregularInput.Rebars)
            {
                double area = r.AreaMm2 ?? 0;
                double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : cBarDiameterMm;
                PreviewRebars.Add(new PreviewRebarPoint(circEqRebarIndex++, r.X, r.Y, diam / cFactor, r.BarSize ?? ""));
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
        double radiusMm = diameterMm / 2.0 - coverMm - stirrupDiameterMm - barDiameterMm / 2.0;
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
            PreviewRebars.Add(new PreviewRebarPoint(i + 1, x, y, previewBarDiameter, bar.DisplayLabel));
            
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
            RebarLayout.Right.ToDto(BarSize, Cover))
        { StirrupDiameterMm = stirrupDiameterMm };

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
        ReClampInnerLegs();
    }

    private void ReClampInnerLegs()
    {
        Raise(nameof(MaxInnerLegsX));
        Raise(nameof(MaxInnerLegsY));
        int cx = Math.Max(0, Math.Min(innerLegsX, MaxInnerLegsX));
        int cy = Math.Max(0, Math.Min(innerLegsY, MaxInnerLegsY));
        bool changed = false;
        if (cx != innerLegsX) { innerLegsX = cx; Raise(nameof(InnerLegsX)); Raise(nameof(TotalLegsX)); changed = true; }
        if (cy != innerLegsY) { innerLegsY = cy; Raise(nameof(InnerLegsY)); Raise(nameof(TotalLegsY)); changed = true; }
        if (changed) UpdateEc2LinkChecks();
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
        SelectedLoadCase = lc;
        RefreshSlendernessUiState();
    }

    private void DuplicateLoadCase(LoadCaseViewModel source)
    {
        var lc = new LoadCaseViewModel(
            Guid.NewGuid().ToString("N")[..8],
            $"{source.Name}_copy",
            source.Pu,
            source.Mux,
            source.Muy)
        {
            Vux = source.Vux,
            Vuy = source.Vuy,
            MxTop = source.MxTop,
            MxBottom = source.MxBottom,
            MyTop = source.MyTop,
            MyBottom = source.MyBottom,
            IsActive = source.IsActive
        };
        int idx = LoadCases.IndexOf(source);
        LoadCases.Insert(idx + 1, lc);
        SelectedLoadCase = lc;
        RefreshSlendernessUiState();
    }

    private void DeleteLoadCase(LoadCaseViewModel lc)
    {
        LoadCases.Remove(lc);
        EnsureAtLeastOneLoadCase();
        if (SelectedLoadCase == lc) SelectedLoadCase = LoadCases.FirstOrDefault();
        if (SlendernessCalculationLoadCase == lc) CloseSlendernessCalculationDetails();
        RefreshSlendernessUiState();
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
        if (SelectedLoadCase is null || !LoadCases.Contains(SelectedLoadCase))
            SelectedLoadCase = LoadCases.FirstOrDefault();
        if (SlendernessCalculationLoadCase is null || !LoadCases.Contains(SlendernessCalculationLoadCase))
            CloseSlendernessCalculationDetails();
        RefreshSlendernessUiState();
    }

    private void ShowSlendernessCalculationDetails(object? parameter)
    {
        var loadCase = parameter as LoadCaseViewModel;
        if (!IncludeEc2Slenderness || loadCase is null)
        {
            return;
        }

        SelectedLoadCase = loadCase;
        SlendernessCalculationLoadCase = loadCase;
        IsSlendernessCalculationDetailsOpen = true;
    }

    private void CloseSlendernessCalculationDetails()
    {
        IsSlendernessCalculationDetailsOpen = false;
        SlendernessCalculationLoadCase = null;
    }

    private void RaiseImperfectionLatex()
    {
        Raise(nameof(ImperfectionXCalculationLatex));
        Raise(nameof(ImperfectionYCalculationLatex));
        Raise(nameof(MinimumEccentricityXCalculationLatex));
        Raise(nameof(MinimumEccentricityYCalculationLatex));
    }

    private string LatexLengthUnit => UnitSystem == UnitSystem.Metric ? @"\text{mm}" : @"\text{in}";

    private string LatexMomentUnit => UnitSystem == UnitSystem.Metric ? @"\mathrm{kN\cdot m}" : @"\mathrm{kip\cdot in}";

    private string BuildImperfectionAxisLatex(string axis, double? k)
    {
        var lc = SlendernessCalculationLoadCase;
        if (lc?.NEd is not double nEd || k is not > 0 || MemberLengthL is not > 0)
            return $@"e_{{i{axis}}}=\text{{pending}}";

        double l0 = k.Value * MemberLengthL.Value;
        double ei = l0 / 400.0;
        double imperfectionMoment = ForceLengthToMoment(nEd, ei);
        return $@"e_{{i{axis}}}=\frac{{{l0:F2}}}{{400}}={ei:F2}\,{LatexLengthUnit},\quad N_{{Ed}}e_{{i{axis}}}={imperfectionMoment:F2}\,{LatexMomentUnit}";
    }

    private string BuildMinimumEccentricityAxisLatex(string axis, double dimensionMm)
    {
        double dimension = UnitSystem == UnitSystem.Metric ? dimensionMm : dimensionMm / 25.4;
        double minE = UnitSystem == UnitSystem.Metric ? 20.0 : 20.0 / 25.4;
        double e0 = Math.Max(dimension / 30.0, minE);
        var lc = SlendernessCalculationLoadCase;
        if (lc?.NEd is not double nEd)
            return $@"e_{{0{axis}}}=\max\left(\frac{{{dimension:F2}}}{{30}},{minE:F2}\right)={e0:F2}\,{LatexLengthUnit}";

        double minMoment = ForceLengthToMoment(nEd, e0);
        return $@"e_{{0{axis}}}=\max\left(\frac{{{dimension:F2}}}{{30}},{minE:F2}\right)={e0:F2}\,{LatexLengthUnit},\quad N_{{Ed}}e_{{0{axis}}}={minMoment:F2}\,{LatexMomentUnit}";
    }

    private string BuildImperfectionCalculationText()
    {
        var lc = SlendernessCalculationLoadCase;
        if (lc?.NEd is not double nEd || MemberLengthL is not > 0)
            return "Imperfection values are available after NEd, L, kx, and ky are provided.";

        string x = BuildImperfectionAxisText("Mx", Kx, nEd, lc.MxTop, lc.MxBottom, lc.M01x, lc.M02x);
        string y = BuildImperfectionAxisText("My", Ky, nEd, lc.MyTop, lc.MyBottom, lc.M01y, lc.M02y);
        return $"{x}\n{y}";
    }

    private string BuildImperfectionAxisText(string axis, double? k, double nEd, double? mTop, double? mBot, double? m01, double? m02)
    {
        if (k is not > 0 || MemberLengthL is not > 0)
            return $"{axis}: missing effective length factor.";

        double l0 = k.Value * MemberLengthL.Value;
        double ei = l0 / 400.0;
        double imperfectionMoment = ForceLengthToMoment(nEd, ei);
        string m01Text = m01.HasValue ? $"{m01.Value:F2}" : "pending";
        string m02Text = m02.HasValue ? $"{m02.Value:F2}" : "pending";

        string header = $"{axis}: ei = {l0:F2} / 400 = {ei:F2} {LengthLabel}\n" +
                        $"NEd x ei = {nEd:F2} x {ei:F2} = {imperfectionMoment:F2} {MomentLabel}";

        if (mTop.HasValue && mBot.HasValue)
        {
            double larger = Math.Abs(mTop.Value) >= Math.Abs(mBot.Value) ? mTop.Value : mBot.Value;
            double sign = Math.Abs(larger) < 1e-9 ? 1.0 : Math.Sign(larger);
            double addedMoment = sign * imperfectionMoment;
            string addStr = addedMoment >= 0 ? $"+ {imperfectionMoment:F2}" : $"- {imperfectionMoment:F2}";
            return $"{header}\n" +
                   $"{axis} Top: {mTop.Value:F2} {addStr} = {mTop.Value + addedMoment:F2} {MomentLabel}\n" +
                   $"{axis} Bot: {mBot.Value:F2} {addStr} = {mBot.Value + addedMoment:F2} {MomentLabel}\n" +
                   $"→ M01 = {m01Text}, M02 = {m02Text} {MomentLabel}";
        }

        return $"{header}\nM01 / M02 after imperfection = {m01Text} / {m02Text} {MomentLabel}";
    }

    private string BuildMinimumEccentricityCalculationText()
    {
        double dimensionX = UnitSystem == UnitSystem.Metric ? CurrentSectionHeightMm() : CurrentSectionHeightMm() / 25.4;
        double dimensionY = UnitSystem == UnitSystem.Metric ? CurrentSectionWidthMm() : CurrentSectionWidthMm() / 25.4;
        double minE = UnitSystem == UnitSystem.Metric ? 20.0 : 20.0 / 25.4;
        double e0x = Math.Max(dimensionX / 30.0, minE);
        double e0y = Math.Max(dimensionY / 30.0, minE);
        var lc = SlendernessCalculationLoadCase;
        if (lc?.NEd is not double nEd)
            return $"Mx: e0 = max({dimensionX:F2} / 30, {minE:F2}) = {e0x:F2} {LengthLabel}\nMy: e0 = max({dimensionY:F2} / 30, {minE:F2}) = {e0y:F2} {LengthLabel}.";

        double minMomentX = ForceLengthToMoment(nEd, e0x);
        double minMomentY = ForceLengthToMoment(nEd, e0y);
        return $"Mx: e0 = max({dimensionX:F2} / 30, {minE:F2}) = {e0x:F2} {LengthLabel}\nNEd x e0 = {minMomentX:F2} {MomentLabel}\nMy: e0 = max({dimensionY:F2} / 30, {minE:F2}) = {e0y:F2} {LengthLabel}\nNEd x e0 = {minMomentY:F2} {MomentLabel}.";
    }

    private double ForceLengthToMoment(double force, double length)
        => UnitSystem == UnitSystem.Metric
            ? force * length / 1000.0
            : force * length / 12.0;

    private void RemoveDuplicateLoadCases()
    {
        var seen = new HashSet<(double, double, double)>();
        var duplicates = LoadCases
            .Where(lc => !seen.Add((Math.Round(lc.Pu, 6), Math.Round(lc.Mux, 6), Math.Round(lc.Muy, 6))))
            .ToList();
        foreach (var dup in duplicates)
            LoadCases.Remove(dup);
    }

    private void ExportLoadCases()
    {
        var dlg = new Microsoft.Win32.SaveFileDialog
        {
            FileName = "LoadCases.csv",
            DefaultExt = ".csv",
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        };
        if (dlg.ShowDialog() == true)
        {
            try
            {
                var lines = new System.Collections.Generic.List<string> { "Case Name,P,Mx,My,Source,Include" };
                foreach (var lc in LoadCases)
                {
                    lines.Add($"{lc.Name},{lc.Pu},{lc.Mux},{lc.Muy},{lc.Source},{lc.IsActive}");
                }
                System.IO.File.WriteAllLines(dlg.FileName, lines);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to export: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }

    private void ImportLoadCases()
    {
        var dlg = new Microsoft.Win32.OpenFileDialog
        {
            DefaultExt = ".csv",
            Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        };
        if (dlg.ShowDialog() == true)
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(dlg.FileName);
                if (lines.Length <= 1) return;
                var imported = new System.Collections.Generic.List<LoadCaseViewModel>();
                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(',');
                    if (parts.Length >= 4)
                    {
                        var lc = new LoadCaseViewModel(
                            Guid.NewGuid().ToString("N")[..8],
                            parts[0],
                            double.TryParse(parts[1], out var p) ? p : 0,
                            double.TryParse(parts[2], out var mx) ? mx : 0,
                            double.TryParse(parts[3], out var my) ? my : 0,
                            parts.Length > 5 ? (bool.TryParse(parts[5], out var inc) ? inc : true) : true
                        );
                        if (parts.Length > 4) lc.Source = parts[4];
                        imported.Add(lc);
                    }
                }
                if (imported.Count > 0)
                {
                    LoadCases.Clear();
                    foreach (var lc in imported) LoadCases.Add(lc);
                    SelectedLoadCase = LoadCases.FirstOrDefault();
                    RefreshSlendernessUiState();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to import: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
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

    private IRebarDatabase ActiveRebarDatabase => RebarDatabaseFor(selectedRebarSetLibrary);

    private IRebarDatabase RebarDatabaseFor(RebarSetLibraryType library)
        => library == RebarSetLibraryType.SingaporeMetric ? metricBars : imperialBars;

    private static RebarSetLibraryType RebarSetLibraryFor(MaterialLibraryType library)
        => library == MaterialLibraryType.America
            ? RebarSetLibraryType.UnitedStatesImperial
            : RebarSetLibraryType.SingaporeMetric;

    private void SetRebarSetLibrary(RebarSetLibraryType library, bool resetSelections, bool updatePreview = true)
    {
        if (selectedRebarSetLibrary == library && !resetSelections) return;

        var oldDb = ActiveRebarDatabase;
        oldDb.TryGet(barSize, out var oldPrimaryBar);
        oldDb.TryGet(IrregularInput.BarSize, out var oldIrregularBar);
        var oldStirrupBar = selectedStirrupBar;

        selectedRebarSetLibrary = library;

        if (resetSelections)
        {
            barSize = SelectReplacementBarName(oldPrimaryBar, DefaultMainBarName(library));
            if (!string.IsNullOrWhiteSpace(IrregularInput.BarSize))
            {
                IrregularInput.BarSize = SelectReplacementBarName(oldIrregularBar ?? oldPrimaryBar, DefaultMainBarName(library));
            }

            selectedStirrupBar = SelectReplacementBar(oldStirrupBar, DefaultStirrupBarName(library));
            stirrupDiameterMm = selectedStirrupBar?.DiameterMm ?? DefaultStirrupDiameterMm(library);
            SyncSideGlobalInputs();
        }

        Raise(nameof(SelectedRebarSetLibrary));
        Raise(nameof(AvailableBars));
        Raise(nameof(AvailableStirrupBars));
        Raise(nameof(SelectedStirrupBar));
        Raise(nameof(StirrupDiameterMm));
        Raise(nameof(BarSize));
        Raise(nameof(SelectedRebarSize));
        RaiseUnitDependentLabels();

        if (updatePreview)
        {
            UpdateSectionPreview();
        }
    }

    private string SelectReplacementBarName(RebarDefinition? previous, string fallbackName)
        => SelectReplacementBar(previous, fallbackName)?.Name
           ?? ActiveRebarDatabase.GetBars().FirstOrDefault()?.Name
           ?? fallbackName;

    private RebarDefinition? SelectReplacementBar(RebarDefinition? previous, string fallbackName)
    {
        var bars = ActiveRebarDatabase.GetBars();
        if (previous is not null && bars.Count > 0)
        {
            return bars.OrderBy(b => Math.Abs(b.DiameterMm - previous.DiameterMm)).First();
        }

        return ActiveRebarDatabase.TryGet(fallbackName, out var fallback)
            ? fallback
            : bars.FirstOrDefault();
    }

    private RebarSetLibraryType InferRebarSetLibrary(string? primaryBarSize, string? stirrupBarSize)
    {
        if (BelongsToDatabase(metricBars, primaryBarSize) || BelongsToDatabase(metricBars, stirrupBarSize))
        {
            return RebarSetLibraryType.SingaporeMetric;
        }

        if (BelongsToDatabase(imperialBars, primaryBarSize) || BelongsToDatabase(imperialBars, stirrupBarSize))
        {
            return RebarSetLibraryType.UnitedStatesImperial;
        }

        return unitSystem == UnitSystem.Metric
            ? RebarSetLibraryType.SingaporeMetric
            : RebarSetLibraryType.UnitedStatesImperial;
    }

    private static bool BelongsToDatabase(IRebarDatabase database, string? barSize)
        => !string.IsNullOrWhiteSpace(barSize) && database.TryGet(barSize, out _);

    private static string DefaultMainBarName(RebarSetLibraryType library)
        => library == RebarSetLibraryType.SingaporeMetric ? "T25" : "#8";

    private static string DefaultStirrupBarName(RebarSetLibraryType library)
        => library == RebarSetLibraryType.SingaporeMetric ? "T10" : "#3";

    private static double DefaultStirrupDiameterMm(RebarSetLibraryType library)
        => library == RebarSetLibraryType.SingaporeMetric ? 10.0 : 9.525;

    private void RaiseUnitDependentLabels()
    {
        Raise(nameof(DemandForceHeader));
        Raise(nameof(DemandMomentXHeader));
        Raise(nameof(DemandMomentYHeader));
        Raise(nameof(ShearVuxHeader));
        Raise(nameof(ShearVuyHeader));
        Raise(nameof(MxTopHeader));
        Raise(nameof(MxBottomHeader));
        Raise(nameof(MyTopHeader));
        Raise(nameof(MyBottomHeader));
        Raise(nameof(MxUsedHeader));
        Raise(nameof(MyUsedHeader));
        Raise(nameof(RebarDiameterUnitLabel));
        Raise(nameof(LinkSpacingUnitLabel));
        Raise(nameof(LinkSpacing));
        Raise(nameof(CircularHoopCentrelineDiameter));
        Raise(nameof(CircularHoopCentrelineDiameterText));
        Raise(nameof(CurrentForceUnit));
        Raise(nameof(CurrentMomentUnit));
    }

    private void ApplyMetricDefaults()
    {
        selectedRebarSetLibrary = RebarSetLibraryType.SingaporeMetric;
        width = 700; height = 700; diameter = 700; cover = 55; barSize = "T25"; barCount = 28;
        IrregularInput.BarSize = "T25";
        layoutPreset = "All Sides Equal";
        selectedSectionShape = SectionShapeType.Rectangular;
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
        memberLengthL = 3500.0;
        includeEc2Slenderness = false;
        kx = 1.0; ky = 1.0; phiEff = null; useDefaultAWhenPhiEffUnknown = true;
        stirrupDiameterMm = 10.0; metricBars.TryGet("T10", out var _t10); selectedStirrupBar = _t10;
        linkSpacingMm = 200.0; innerLegsX = 0; innerLegsY = 0;
        selectedMaterialLibrary = MaterialLibraryType.Europe;
        selectedConcreteGrade = EuropeanConcreteGrades[2]; // C30/37
        selectedSteelGrade = EuropeanSteelGrades[2]; // B500B
        gammaC = 1.50;
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
        selectedRebarSetLibrary = RebarSetLibraryType.UnitedStatesImperial;
        width = 28; height = 28; diameter = 28; cover = 2.2; barSize = "#8"; barCount = 28;
        IrregularInput.BarSize = "#8";
        layoutPreset = "All Sides Equal";
        selectedSectionShape = SectionShapeType.Rectangular;
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
        memberLengthL = 140.0;
        includeEc2Slenderness = false;
        kx = 1.0; ky = 1.0; phiEff = null; useDefaultAWhenPhiEffUnknown = true;
        stirrupDiameterMm = 9.525; selectedStirrupBar = imperialBars.GetBars().FirstOrDefault();
        linkSpacingMm = 8.0 * 25.4; innerLegsX = 0; innerLegsY = 0;
        selectedMaterialLibrary = MaterialLibraryType.America;
        selectedConcreteGrade = AmericanConcreteGrades[1];
        selectedSteelGrade = AmericanSteelGrades[1];
        gammaC = 1.50;
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
        Raise(nameof(SelectedRebarSetLibrary)); Raise(nameof(AvailableBars));
        RaiseUnitDependentLabels();
        Raise(nameof(SectionWidth)); Raise(nameof(SectionHeight)); Raise(nameof(SelectedRebarSize)); Raise(nameof(NumberOfBars)); Raise(nameof(SelectedRebarLayout));
        Raise(nameof(RebarLayoutTypes)); Raise(nameof(SelectedRebarLayoutType));
        Raise(nameof(IsEqualSpacingLayout)); Raise(nameof(IsAllSidesEqualLayout)); Raise(nameof(IsSidesDifferentLayout)); Raise(nameof(IsRectangularEqualSpacingLayout));
        Raise(nameof(ShowTotalBarsInput)); Raise(nameof(IsCustomRebarCoordinates)); Raise(nameof(IsRebarCoordinatesEditable));
        Raise(nameof(SelectedDesignCode)); Raise(nameof(SelectedEurocodeConcreteStrainProfile)); Raise(nameof(SelectedIntegrationMethod)); Raise(nameof(FcLabel)); Raise(nameof(FyLabel));
        Raise(nameof(AlphaCc)); Raise(nameof(GammaC)); Raise(nameof(ShowAlphaCcOption));
        Raise(nameof(MemberLengthL)); Raise(nameof(IncludeEc2Slenderness)); Raise(nameof(Kx)); Raise(nameof(Ky)); Raise(nameof(PhiEff));
        Raise(nameof(UseDefaultAWhenPhiEffUnknown)); Raise(nameof(DemandInputModeText)); Raise(nameof(L0xText)); Raise(nameof(L0yText));
        RaiseMaterialDerivedProperties();
        Raise(nameof(SelectedStirrupBar)); Raise(nameof(AvailableStirrupBars)); Raise(nameof(StirrupDiameterMm));
        Raise(nameof(LinkSpacingMm)); Raise(nameof(InnerLegsX)); Raise(nameof(InnerLegsY));
        Raise(nameof(MaxInnerLegsX)); Raise(nameof(MaxInnerLegsY));
        Raise(nameof(TotalLegsX)); Raise(nameof(TotalLegsY));
        Raise(nameof(Ec2Check1Text)); Raise(nameof(Ec2Check1Pass));
        Raise(nameof(Ec2Check2Text)); Raise(nameof(Ec2Check2Pass));
        Raise(nameof(Ec2Check3Text)); Raise(nameof(Ec2Check3Pass));
        Raise(nameof(Ec2AswsXText)); Raise(nameof(Ec2AswsYText));
        Raise(nameof(Ec2AswsXLatex)); Raise(nameof(Ec2AswsYLatex));
    }

    public void ResetToDefaults()
    {
        SelectedDesignCode = DesignCodeType.Ec2;
        SelectedMaterialLibrary = unitSystem == UnitSystem.Metric ? MaterialLibraryType.Europe : MaterialLibraryType.America;

        if (unitSystem == UnitSystem.Metric) ApplyMetricDefaults(); else ApplyImperialDefaults();
        
        UpdateSectionPreview();
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

    private void ExportDxf()
    {
        if (IrregularInput.BoundaryPoints.Count < 3) return;

        var dialog = new Microsoft.Win32.SaveFileDialog
        {
            Title = "Export as DXF",
            Filter = "DXF Files (*.dxf)|*.dxf|All Files (*.*)|*.*",
            FileName = "section.dxf"
        };
        if (dialog.ShowDialog() != true) return;

        try
        {
            var boundary = IrregularInput.BoundaryPoints
                .Select(p => (p.X, p.Y))
                .ToList();

            var rebars = IrregularInput.Rebars
                .Select(r => (r.X, r.Y, r.AreaMm2 ?? 0.0))
                .ToList();

            new DxfExportService().Export(dialog.FileName, boundary, rebars);

            System.Windows.MessageBox.Show(
                $"DXF exported to:\n{dialog.FileName}",
                "Export Complete",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show(
                $"DXF export failed:\n{ex.Message}",
                "Export Error",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Error);
        }
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

    private void UpdateEc2LinkChecks()
    {
        if (IsIrregularSection)
        {
            Ec2Check1Text = "—"; Ec2Check1Pass = true;
            Ec2Check2Text = "—"; Ec2Check2Pass = true;
            Ec2Check3Text = "—"; Ec2Check3Pass = true;
            Ec2AswsXText = "—"; Ec2AswsYText = "—";
            Ec2AswsXLatex = ""; Ec2AswsYLatex = "";
            return;
        }

        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;

        if (IsCircularSection)
        {
            double dSw0 = stirrupDiameterMm;
            var barDef0 = AvailableBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase));
            double dMain0 = barDef0?.DiameterMm ?? 20.0;
            double diamMm = Diameter * factor;

            // Check 1: tie Ø ≥ max(6, 0.25·dMain)  EC2 §9.5.3(1)
            double minDiam0 = Math.Max(6.0, 0.25 * dMain0);
            bool c10 = dSw0 >= minDiam0 - 1e-6;
            Ec2Check1Text = $"Ø{dSw0:0} ≥ max(6, 0.25·Ø{dMain0:0.#}) = {minDiam0:0.#} mm  {(c10 ? "✓" : "✗")}";
            Ec2Check1Pass = c10;

            // Check 2: pitch ≤ min(20·dMain, D, 400)  EC2 §9.5.3(3)
            double sMax0 = Math.Min(Math.Min(20.0 * dMain0, diamMm), 400.0);
            bool c20 = linkSpacingMm <= sMax0 + 1e-6;
            Ec2Check2Text = $"s = {linkSpacingMm:0} ≤ min(20·{dMain0:0.#}, D={diamMm:0}, 400) = {sMax0:0} mm  {(c20 ? "✓" : "✗")}";
            Ec2Check2Pass = c20;

            // No inner-legs check for circular
            Ec2Check3Text = "—"; Ec2Check3Pass = true;

            // Asw/s for circular tie (1 closed ring per pitch)
            double aSwMm2_0 = Math.PI * dSw0 * dSw0 / 4.0;
            double asws0 = linkSpacingMm > 0 ? aSwMm2_0 / linkSpacingMm : 0;
            Ec2AswsXText = $"Asw/s (circular tie) = {aSwMm2_0:0.##}/{linkSpacingMm:0} = {asws0:0.###} mm²/mm";
            Ec2AswsYText = "—";
            Ec2AswsXLatex = $@"\frac{{A_h}}{{s}}=\frac{{{aSwMm2_0:0.##}}}{{{linkSpacingMm:0}}}={asws0:0.###}\;\mathrm{{mm^2/mm}}";
            Ec2AswsYLatex = "";
            return;
        }

        double widthMm = Width * factor;
        double heightMm = Height * factor;
        double coverMm = Cover * factor;
        double dSw = stirrupDiameterMm;
        var barDef = AvailableBars.FirstOrDefault(b => string.Equals(b.Name, BarSize, StringComparison.OrdinalIgnoreCase));
        double dMain = barDef?.DiameterMm ?? 20.0;

        // Check 1: d_sw ≥ max(6, 0.25 × d_main)  EC2 §9.5.3(1)
        double minDiam = Math.Max(6.0, 0.25 * dMain);
        bool c1 = dSw >= minDiam - 1e-6;
        Ec2Check1Text = $"Ø{dSw:0} ≥ max(6, 0.25·Ø{dMain:0.#}) = {minDiam:0.#} mm  {(c1 ? "✓" : "✗")}";
        Ec2Check1Pass = c1;

        // Check 2: s ≤ min(20×d_main, b_min, 400)  EC2 §9.5.3(3)
        double bMin = Math.Min(widthMm, heightMm);
        double sMax = Math.Min(Math.Min(20.0 * dMain, bMin), 400.0);
        bool c2 = linkSpacingMm <= sMax + 1e-6;
        Ec2Check2Text = $"s = {linkSpacingMm:0} ≤ min(20·{dMain:0.#}, {bMin:0}, 400) = {sMax:0} mm  {(c2 ? "✓" : "✗")}";
        Ec2Check2Pass = c2;

        // Check 3: gap between restrained positions ≤ 150 mm  EC2 §9.5.3(6)
        int totX = 2 + innerLegsX;
        int totY = 2 + innerLegsY;
        double xClear = widthMm - 2.0 * (coverMm + dSw);
        double yClear = heightMm - 2.0 * (coverMm + dSw);
        double gX = totX > 1 && xClear > 0 ? xClear / (totX - 1) : double.PositiveInfinity;
        double gY = totY > 1 && yClear > 0 ? yClear / (totY - 1) : double.PositiveInfinity;
        bool c3 = gX <= 150.0 + 1e-6 && gY <= 150.0 + 1e-6;
        string gXStr = double.IsInfinity(gX) ? "∞" : $"{gX:0}";
        string gYStr = double.IsInfinity(gY) ? "∞" : $"{gY:0}";
        Ec2Check3Text = $"ΔX = {gXStr} mm,  ΔY = {gYStr} mm  (≤ 150 mm)  {(c3 ? "✓" : "✗")}";
        Ec2Check3Pass = c3;

        // Check 4 (info): Asw/s in X and Y directions  EC2 §9.5.3
        double aSwMm2 = Math.PI * dSw * dSw / 4.0;
        double aswX = linkSpacingMm > 0 ? totX * aSwMm2 / linkSpacingMm : 0;
        double aswY = linkSpacingMm > 0 ? totY * aSwMm2 / linkSpacingMm : 0;
        Ec2AswsXText = $"Asw/s (X) = {totX}×{aSwMm2:0.##}/{linkSpacingMm:0} = {aswX:0.###} mm²/mm";
        Ec2AswsYText = $"Asw/s (Y) = {totY}×{aSwMm2:0.##}/{linkSpacingMm:0} = {aswY:0.###} mm²/mm";
        Ec2AswsXLatex = $@"\left(\frac{{A_{{sw}}}}{{s}}\right)_x=\frac{{{totX}\times{aSwMm2:0.##}}}{{{linkSpacingMm:0}}}={aswX:0.###}\;\mathrm{{mm^2/mm}}";
        Ec2AswsYLatex = $@"\left(\frac{{A_{{sw}}}}{{s}}\right)_y=\frac{{{totY}\times{aSwMm2:0.##}}}{{{linkSpacingMm:0}}}={aswY:0.###}\;\mathrm{{mm^2/mm}}";
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
            PreviewIxText = ixxMm4 > 0 ? $"{Math.Sqrt(ixxMm4 / agMm2):F1} mm" : "—";
            PreviewIyText = iyyMm4 > 0 ? $"{Math.Sqrt(iyyMm4 / agMm2):F1} mm" : "—";
        }
        else
        {
            PreviewAreaText = "—";
            PreviewIxxText = "—";
            PreviewIyyText = "—";
            PreviewIxText = "—";
            PreviewIyText = "—";
        }

        // Diameter in PreviewRebarPoint is always in mm
        double totalAsMm2 = PreviewRebars.Sum(r => Math.PI * Math.Pow(r.Diameter / 2.0, 2));
        int rebarCount = PreviewRebars.Count;
        PreviewAsTotalText = totalAsMm2 > 0 ? $"{totalAsMm2:N0} mm²" : "—";

        double fckMpa = StressInputToMpa(Fc);
        double fykMpa = StressInputToMpa(Fy);
        double fcd = GammaC > 0 ? AlphaCc * fckMpa / GammaC : 0.0;
        double fyd = fykMpa / 1.15;
        double ecm = fckMpa > 0 ? 22000.0 * Math.Pow((fckMpa + 8.0) / 10.0, 0.3) : 0.0;
        PreviewFcdText = fcd > 0 ? $"{fcd:F2} MPa" : "—";
        PreviewFydText = fyd > 0 ? $"{fyd:F2} MPa" : "—";
        PreviewEcmText = ecm > 0 ? $"{ecm:F0} MPa" : "—";

        double dxMm = RebarSpreadMm(PreviewRebars.Select(r => r.Y), 0.8 * CurrentSectionHeightMm());
        double dyMm = RebarSpreadMm(PreviewRebars.Select(r => r.X), 0.8 * CurrentSectionWidthMm());
        PreviewDxText = dxMm > 0 ? $"{dxMm:F1} mm" : "—";
        PreviewDyText = dyMm > 0 ? $"{dyMm:F1} mm" : "—";

        double omega = agMm2 > 0 && fcd > 0
            ? totalAsMm2 * fyd / (agMm2 * fcd)
            : 0.0;
        PreviewOmegaText = omega > 0 ? $"{omega:F3}" : "—";

        double nEdN = ForceInputToN(SelectedLoadCase?.NEd ?? Pu);
        double nRatio = agMm2 > 0 && fcd > 0 ? nEdN / (agMm2 * fcd) : 0.0;
        PreviewNRatioText = nRatio > 0 ? $"{nRatio:F3}" : "—";

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

        RefreshSlendernessUiState();
    }

    private void LoadCases_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems is not null)
        {
            foreach (LoadCaseViewModel item in e.OldItems)
            {
                item.PropertyChanged -= LoadCase_PropertyChanged;
            }
        }

        if (e.NewItems is not null)
        {
            foreach (LoadCaseViewModel item in e.NewItems)
            {
                item.PropertyChanged += LoadCase_PropertyChanged;
            }
        }

        if (SelectedLoadCase is null || !LoadCases.Contains(SelectedLoadCase))
        {
            SelectedLoadCase = LoadCases.FirstOrDefault();
        }

        RefreshSlendernessUiState();
    }

    private void LoadCase_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (ReferenceEquals(sender, SelectedLoadCase))
        {
            UpdateSectionPropertiesPanel();
        }

        RefreshSlendernessUiState();
    }

    private void RefreshSlendernessUiState()
    {
        if (isRefreshingSlendernessState) return;
        isRefreshingSlendernessState = true;
        try
        {
            foreach (var loadCase in LoadCases)
            {
                if (!loadCase.IsActive)
                {
                    loadCase.Status = "Excluded";
                    loadCase.HasValidationError = false;
                    loadCase.ClearEc2SlendernessResults();
                    continue;
                }

                if (!IncludeEc2Slenderness)
                {
                    loadCase.ClearEc2SlendernessResults();
                    loadCase.Status = "Ready";
                    loadCase.HasValidationError = false;
                    continue;
                }

                loadCase.ClearEc2SlendernessResults();

                bool globalMissing = MemberLengthL is not > 0 || Kx is not > 0 || Ky is not > 0;
                bool missingMoments = loadCase.MxTop is null ||
                    loadCase.MxBottom is null ||
                    loadCase.MyTop is null ||
                    loadCase.MyBottom is null;

                if (loadCase.NEd <= 0)
                {
                    loadCase.Status = "Invalid NEd";
                    loadCase.HasValidationError = true;
                }
                else if (globalMissing || missingMoments)
                {
                    loadCase.Status = "Missing Input";
                    loadCase.HasValidationError = true;
                }
                else
                {
                    loadCase.Status = "Ready";
                    loadCase.HasValidationError = false;
                }
            }

            if (IncludeEc2Slenderness && MemberLengthL is > 0 && Kx is > 0 && Ky is > 0)
            {
                double fckMpa = StressInputToMpa(Fc);
                double fykMpa = StressInputToMpa(Fy);
                double esMpa = StressInputToMpa(Es);

                if (fckMpa > 0 && fykMpa > 0 && esMpa > 0)
                {
                    double lengthFactor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
                    var bars = PreviewRebars.Select(r => new Rebar(
                        r.Label,
                        r.Diameter,
                        Math.PI * Math.Pow(r.Diameter / 2.0, 2),
                        r.X * lengthFactor,
                        r.Y * lengthFactor)).ToList();
                    var rebarLayout = new RebarLayout(LayoutPreset ?? "Custom", BarSize ?? "", Cover * lengthFactor, bars);

                    ColumnSection? section = null;
                    if (SelectedSectionShape == SectionShapeType.Rectangular && Width > 0 && Height > 0)
                    {
                        section = new RectangularSection(Width * lengthFactor, Height * lengthFactor, rebarLayout);
                    }
                    else if (SelectedSectionShape == SectionShapeType.Circular && Diameter > 0)
                    {
                        section = new CircularSection(Diameter * lengthFactor, rebarLayout);
                    }
                    else if (SelectedSectionShape == SectionShapeType.Irregular && IrregularInput != null && IrregularInput.BoundaryPoints.Count >= 3)
                    {
                        try
                        {
                            var mapper = new MBColumn.Application.Mappers.IrregularSectionMapper(new MBColumn.Application.Services.IrregularSectionValidationService());
                            var irregularDto = IrregularInput.ToDto(Cover);
                            var mapResult = mapper.ValidateAndMap(irregularDto, out var irregular, out var _);
                            if (mapResult.IsValid && irregular != null)
                            {
                                section = irregular;
                            }
                        }
                        catch
                        {
                            // Ignore mapping errors
                        }
                    }

                    if (section != null)
                    {
                        var concrete = new Ec2ConcreteMaterialDto(fckMpa, GammaC, AlphaCc);
                        var steel = new SteelMaterial($"fy {fykMpa:F1}", fykMpa, esMpa);
                        double? memberLengthMm = MemberLengthL.Value * lengthFactor;
                        var settings = new Ec2SlendernessSettingsDto(
                            true,
                            Kx,
                            Ky,
                            PhiEff,
                            UseDefaultAWhenPhiEffUnknown);

                        var forceUnit = CurrentForceUnit;
                        var momentUnit = CurrentMomentUnit;
                        var lcDtos = LoadCases.Where(lc => lc.IsActive).Select(lc => lc.ToDto(forceUnit, momentUnit)).ToList();

                        var units = new UnitConversionService();
                        var service = new Ec2NominalCurvatureService(units);
                        var batchResult = service.Calculate(section, concrete, steel, new MemberGeometryInputDto(memberLengthMm), settings, lcDtos);

                        var byId = batchResult.LoadCases.ToDictionary(r => r.LoadCaseId);
                        foreach (var loadCase in LoadCases)
                        {
                            if (!loadCase.IsActive) continue;

                            if (byId.TryGetValue(loadCase.Id, out var slenderness))
                            {
                                loadCase.LambdaX = slenderness.X?.Lambda;
                                loadCase.LambdaLimitX = slenderness.X?.LambdaLimit;
                                loadCase.RmX = slenderness.X?.Rm;
                                loadCase.M01x = slenderness.X?.M01Nmm is double m01xVal
                                    ? units.MomentFromNmm(m01xVal, momentUnit)
                                    : null;
                                loadCase.M02x = slenderness.X?.M02Nmm is double m02xVal
                                    ? units.MomentFromNmm(m02xVal, momentUnit)
                                    : null;
                                loadCase.M0ex = slenderness.X?.M0eNmm is double m0exVal
                                    ? units.MomentFromNmm(m0exVal, momentUnit)
                                    : null;
                                loadCase.M2x = slenderness.X?.M2Nmm is double m2xVal
                                    ? units.MomentFromNmm(m2xVal, momentUnit)
                                    : null;
                                loadCase.NominalCurvatureX = slenderness.X?.NominalCurvature1PerMm;
                                loadCase.E2X = slenderness.X?.E2Mm;

                                loadCase.LambdaY = slenderness.Y?.Lambda;
                                loadCase.LambdaLimitY = slenderness.Y?.LambdaLimit;
                                loadCase.RmY = slenderness.Y?.Rm;
                                loadCase.M01y = slenderness.Y?.M01Nmm is double m01yVal
                                    ? units.MomentFromNmm(m01yVal, momentUnit)
                                    : null;
                                loadCase.M02y = slenderness.Y?.M02Nmm is double m02yVal
                                    ? units.MomentFromNmm(m02yVal, momentUnit)
                                    : null;
                                loadCase.M0ey = slenderness.Y?.M0eNmm is double m0eyVal
                                    ? units.MomentFromNmm(m0eyVal, momentUnit)
                                    : null;
                                loadCase.M2y = slenderness.Y?.M2Nmm is double m2yVal
                                    ? units.MomentFromNmm(m2yVal, momentUnit)
                                    : null;
                                loadCase.NominalCurvatureY = slenderness.Y?.NominalCurvature1PerMm;
                                loadCase.E2Y = slenderness.Y?.E2Mm;

                                loadCase.FactorN = slenderness.X?.FactorN ?? slenderness.Y?.FactorN;
                                loadCase.FactorA = slenderness.X?.FactorA ?? slenderness.Y?.FactorA;
                                loadCase.FactorB = slenderness.X?.FactorB ?? slenderness.Y?.FactorB;
                                loadCase.FactorCx = slenderness.X?.FactorC;
                                loadCase.FactorCy = slenderness.Y?.FactorC;

                                loadCase.MxUsed = slenderness.MxUsedNmm.HasValue
                                    ? units.MomentFromNmm(slenderness.MxUsedNmm.Value, momentUnit)
                                    : null;
                                loadCase.MyUsed = slenderness.MyUsedNmm.HasValue
                                    ? units.MomentFromNmm(slenderness.MyUsedNmm.Value, momentUnit)
                                    : null;
                                loadCase.Status = slenderness.Status;
                            }
                        }
                    }
                }
            }

            Raise(nameof(SlendernessWarningText));
            Raise(nameof(HasSlendernessWarnings));
        }
        finally
        {
            isRefreshingSlendernessState = false;
        }
    }

    private string BuildSlendernessWarningText()
    {
        var warnings = new List<string>
        {
            "Ecm is auto-calculated from fck. Manual override is not active."
        };

        if (!IncludeEc2Slenderness)
        {
            return string.Join(Environment.NewLine, warnings.Select(w => "- " + w));
        }

        if (MemberLengthL is not > 0)
            warnings.Add("Column length L is missing in Section & Rebar.");
        if (Kx is not > 0)
            warnings.Add("kx must be greater than zero.");
        if (Ky is not > 0)
            warnings.Add("ky must be greater than zero.");
        if (PhiEff is < 0)
            warnings.Add("Effective creep ratio phiEff must be zero or greater.");

        foreach (var loadCase in LoadCases.Where(lc => lc.IsActive))
        {
            if (loadCase.NEd <= 0)
                warnings.Add($"{loadCase.Name}: NEd is tensile or zero; EC2 column slenderness check is not applicable.");
            if (loadCase.MxTop is null || loadCase.MxBottom is null)
                warnings.Add($"{loadCase.Name}: Mx Top and Mx Bottom are required because slenderness is enabled.");
            if (loadCase.MyTop is null || loadCase.MyBottom is null)
                warnings.Add($"{loadCase.Name}: My Top and My Bottom are required because slenderness is enabled.");
        }

        return string.Join(Environment.NewLine, warnings.Distinct().Select(w => "- " + w));
    }

    private void RaiseMaterialDerivedProperties()
    {
        Raise(nameof(FcdDisplayText));
        Raise(nameof(FcmDisplayText));
        Raise(nameof(EcmDisplayText));
        Raise(nameof(PreviewFcdText));
        Raise(nameof(PreviewFydText));
        Raise(nameof(PreviewEcmText));
        Raise(nameof(PreviewOmegaText));
        Raise(nameof(IsEc2));
        Raise(nameof(ConcreteUltimateStrainLabel));
        Raise(nameof(ConcretePeakStrainLabel));
        Raise(nameof(ConcreteUltimateStrainSubscript));
        Raise(nameof(ConcretePeakStrainSubscript));
        Raise(nameof(ShowEurocodeConcreteStrainProfileOption));
        Raise(nameof(EpsilonCu2));
        Raise(nameof(EpsilonC2));
        Raise(nameof(EpsilonYd));
        Raise(nameof(EpsilonUd));
    }

    private double StressInputToMpa(double value)
        => UnitSystem == UnitSystem.Metric ? value : value * 6.894757293168;

    private double ForceInputToN(double value)
        => UnitSystem == UnitSystem.Metric ? value * 1000.0 : value * 4448.2216152605;

    private double CurrentSectionWidthMm()
    {
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        return (IsCircularSection ? Diameter : Width) * factor;
    }

    private double CurrentSectionHeightMm()
    {
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        return (IsCircularSection ? Diameter : Height) * factor;
    }

    private double RebarSpreadMm(IEnumerable<double> values, double fallbackMm)
    {
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
        var list = values.Select(v => v * factor).ToList();
        if (list.Count < 2)
        {
            return fallbackMm;
        }

        double spread = list.Max() - list.Min();
        return spread > 0 ? spread : fallbackMm;
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
        EurocodeConcreteStrainProfile = selectedEurocodeConcreteStrainProfile.ToString(),
        IntegrationMethod = selectedIntegrationMethod.ToString(),
        AlphaCc = alphaCc,
        GammaC = gammaC,
        SectionShape = selectedSectionShape.ToString(),
        Width = width, Height = height, Diameter = diameter, Cover = cover,
        MemberLengthL = memberLengthL,
        StirrupDiameterMm = stirrupDiameterMm,
        StirrupBarSize = selectedStirrupBar?.Name ?? "",
        LinkSpacingMm = linkSpacingMm,
        InnerLegsX = innerLegsX,
        InnerLegsY = innerLegsY,
        Fc = fc, Fy = fy, Es = es,
        MaterialLibrary = selectedMaterialLibrary.ToString(),
        BarSize = barSize,
        RebarSetLibrary = selectedRebarSetLibrary.ToString(),
        BarCount = barCount, Spacing = spacing,
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
        IncludeEc2Slenderness = includeEc2Slenderness,
        Kx = kx,
        Ky = ky,
        PhiEff = phiEff,
        UseDefaultAWhenPhiEffUnknown = useDefaultAWhenPhiEffUnknown,
        PmAngleDegrees = selectedPmAngleDegrees,
        AxialLoad = selectedAxialLoad,
        DesignTierName = designTierName,
        DesignTierSource = designTierSource,
        EtabsTierMetadata = etabsTierMetadata,
        EtabsMetadata = etabsMetadata,
        LoadCases = LoadCases
            .Select(lc => new SnapshotLoadCase
            {
                Id = lc.Id,
                Label = lc.Name,
                OriginalLoadCaseName = lc.OriginalLoadCaseName,
                SourceObjectName = lc.SourceObjectName,
                SourceObjectLabel = lc.SourceObjectLabel,
                Story = lc.Story,
                Station = lc.Station,
                Source = string.IsNullOrWhiteSpace(lc.Source) ? "Manual" : lc.Source,
                Pu = lc.Pu,
                Mux = lc.Mux,
                Muy = lc.Muy,
                MxTop = lc.MxTop,
                MxBottom = lc.MxBottom,
                MyTop = lc.MyTop,
                MyBottom = lc.MyBottom,
                MxUsed = lc.MxUsed,
                MyUsed = lc.MyUsed,
                Vux = lc.Vux,
                Vuy = lc.Vuy,
                IsActive = lc.IsActive
            })
            .ToList()
    };

    public void LoadFromSnapshot(ColumnInputSnapshot s)
    {
        isDxfImportedSection = false;
        designTierName = s.DesignTierName;
        designTierSource = s.DesignTierSource;
        etabsTierMetadata = s.EtabsTierMetadata;
        etabsMetadata = s.EtabsMetadata;
        unitSystem = Enum.TryParse<UnitSystem>(s.UnitSystem, out var us) ? us : UnitSystem.Metric;
        selectedDesignCode = Enum.TryParse<DesignCodeType>(s.DesignCode, out var dc) ? dc : DesignCodeType.Aci318Style;
        selectedEc2Solver = Enum.TryParse<Ec2SolverType>(s.Ec2Solver, out var ec2) ? ec2 : Ec2SolverType.Fiber;
        selectedEurocodeConcreteStrainProfile = Enum.TryParse<EurocodeConcreteStrainProfile>(s.EurocodeConcreteStrainProfile, out var strainProfile)
            ? strainProfile
            : EurocodeConcreteStrainProfile.Ec2;
        selectedIntegrationMethod = Enum.TryParse<SectionIntegrationMethod>(s.IntegrationMethod, out var im) ? im : SectionIntegrationMethod.Fiber;
        alphaCc = s.AlphaCc;
        gammaC = s.GammaC > 0 ? s.GammaC : 1.50;
        selectedSectionShape = Enum.TryParse<SectionShapeType>(s.SectionShape, out var ss) ? ss : SectionShapeType.Rectangular;
        width = s.Width; height = s.Height; diameter = s.Diameter; cover = s.Cover;
        memberLengthL = s.MemberLengthL;
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

        selectedRebarSetLibrary = Enum.TryParse<RebarSetLibraryType>(s.RebarSetLibrary, out var rebarSetLibrary)
            ? rebarSetLibrary
            : InferRebarSetLibrary(s.BarSize, s.StirrupBarSize);
        barSize = s.BarSize; barCount = s.BarCount; spacing = s.Spacing;
        var stirrupDb = ActiveRebarDatabase;
        if (!string.IsNullOrEmpty(s.StirrupBarSize) && stirrupDb.TryGet(s.StirrupBarSize, out var loadedStirrup))
        {
            selectedStirrupBar = loadedStirrup;
        }
        else if (s.StirrupDiameterMm > 0)
        {
            selectedStirrupBar = stirrupDb.GetBars().OrderBy(b => Math.Abs(b.DiameterMm - s.StirrupDiameterMm)).First();
        }
        else
        {
            stirrupDb.TryGet("T10", out var fallback);
            selectedStirrupBar = fallback ?? stirrupDb.GetBars().First();
        }
        stirrupDiameterMm = selectedStirrupBar?.DiameterMm ?? 10.0;
        linkSpacingMm = s.LinkSpacingMm > 0 ? s.LinkSpacingMm : 200.0;
        innerLegsX = Math.Max(0, s.InnerLegsX);
        innerLegsY = Math.Max(0, s.InnerLegsY);
        selectedRebarLayoutType = CoerceRebarLayoutForShape(
            Enum.TryParse<RebarLayoutType>(s.RebarLayoutType, out var rlt) ? rlt : RebarLayoutType.AllSidesEqual,
            selectedSectionShape);
        layoutPreset = RebarLayoutDisplayName(selectedRebarLayoutType);
        pu = s.Pu; mux = s.Mux; muy = s.Muy;
        includeEc2Slenderness = s.IncludeEc2Slenderness;
        kx = s.Kx ?? 1.0;
        ky = s.Ky ?? 1.0;
        phiEff = s.PhiEff;
        useDefaultAWhenPhiEffUnknown = s.UseDefaultAWhenPhiEffUnknown;
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
            LoadCases.Add(new LoadCaseViewModel(lc.Id, lc.Label, lc.Pu, lc.Mux, lc.Muy, lc.IsActive)
            {
                Vux = lc.Vux,
                Vuy = lc.Vuy,
                MxTop = lc.MxTop,
                MxBottom = lc.MxBottom,
                MyTop = lc.MyTop,
                MyBottom = lc.MyBottom,
                MxUsed = lc.MxUsed,
                MyUsed = lc.MyUsed,
                OriginalLoadCaseName = lc.OriginalLoadCaseName,
                SourceObjectName = lc.SourceObjectName,
                SourceObjectLabel = lc.SourceObjectLabel,
                Story = lc.Story,
                Station = lc.Station,
                Source = string.IsNullOrWhiteSpace(lc.Source) ? "Manual" : lc.Source
            });
            if (int.TryParse(lc.Label.Replace("LC", ""), out var n) && n >= nextLoadCaseIndex)
                nextLoadCaseIndex = n + 1;
        }

        if (LoadCases.Count == 0) AddPrimaryLoadCase();
        SelectedLoadCase = LoadCases.FirstOrDefault();
        
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
        RefreshSlendernessUiState();
    }

    public void ApplySlendernessResults(CalculationResultDto result)
    {
        isRefreshingSlendernessState = true;
        try
        {
            if (!result.IncludeEc2Slenderness)
            {
                foreach (var loadCase in LoadCases)
                {
                    loadCase.ClearEc2SlendernessResults();
                    loadCase.Status = loadCase.IsActive ? "Ready" : "Excluded";
                }

                return;
            }

            var units = new UnitConversionService();
            var byId = result.Ec2Slenderness.LoadCases.ToDictionary(r => r.LoadCaseId);
            foreach (var loadCase in LoadCases)
            {
                if (!byId.TryGetValue(loadCase.Id, out var slenderness))
                {
                    continue;
                }

                loadCase.LambdaX = slenderness.X?.Lambda;
                loadCase.LambdaLimitX = slenderness.X?.LambdaLimit;
                loadCase.RmX = slenderness.X?.Rm;
                loadCase.M01x = slenderness.X?.M01Nmm is double m01xVal
                    ? units.MomentFromNmm(m01xVal, CurrentMomentUnit)
                    : null;
                loadCase.M02x = slenderness.X?.M02Nmm is double m02xVal
                    ? units.MomentFromNmm(m02xVal, CurrentMomentUnit)
                    : null;
                loadCase.M0ex = slenderness.X?.M0eNmm is double m0exVal
                    ? units.MomentFromNmm(m0exVal, CurrentMomentUnit)
                    : null;
                loadCase.M2x = slenderness.X?.M2Nmm is double m2xVal
                    ? units.MomentFromNmm(m2xVal, CurrentMomentUnit)
                    : null;
                loadCase.NominalCurvatureX = slenderness.X?.NominalCurvature1PerMm;
                loadCase.E2X = slenderness.X?.E2Mm;

                loadCase.LambdaY = slenderness.Y?.Lambda;
                loadCase.LambdaLimitY = slenderness.Y?.LambdaLimit;
                loadCase.RmY = slenderness.Y?.Rm;
                loadCase.M01y = slenderness.Y?.M01Nmm is double m01yVal
                    ? units.MomentFromNmm(m01yVal, CurrentMomentUnit)
                    : null;
                loadCase.M02y = slenderness.Y?.M02Nmm is double m02yVal
                    ? units.MomentFromNmm(m02yVal, CurrentMomentUnit)
                    : null;
                loadCase.M0ey = slenderness.Y?.M0eNmm is double m0eyVal
                    ? units.MomentFromNmm(m0eyVal, CurrentMomentUnit)
                    : null;
                loadCase.M2y = slenderness.Y?.M2Nmm is double m2yVal
                    ? units.MomentFromNmm(m2yVal, CurrentMomentUnit)
                    : null;
                loadCase.NominalCurvatureY = slenderness.Y?.NominalCurvature1PerMm;
                loadCase.E2Y = slenderness.Y?.E2Mm;

                loadCase.FactorN = slenderness.X?.FactorN ?? slenderness.Y?.FactorN;
                loadCase.FactorA = slenderness.X?.FactorA ?? slenderness.Y?.FactorA;
                loadCase.FactorB = slenderness.X?.FactorB ?? slenderness.Y?.FactorB;
                loadCase.FactorCx = slenderness.X?.FactorC;
                loadCase.FactorCy = slenderness.Y?.FactorC;

                loadCase.MxUsed = slenderness.MxUsedNmm.HasValue
                    ? units.MomentFromNmm(slenderness.MxUsedNmm.Value, CurrentMomentUnit)
                    : null;
                loadCase.MyUsed = slenderness.MyUsedNmm.HasValue
                    ? units.MomentFromNmm(slenderness.MyUsedNmm.Value, CurrentMomentUnit)
                    : null;
                loadCase.Status = slenderness.Status;
            }
        }
        finally
        {
            isRefreshingSlendernessState = false;
        }

        Raise(nameof(SlendernessWarningText));
        Raise(nameof(HasSlendernessWarnings));
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
                double radiusMm = diameterMm / 2.0 - coverMm - stirrupDiameterMm - barDiameter / 2.0;
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
                double offsetMm = coverMm + stirrupDiameterMm + barDiameter / 2.0;

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

    private void OpenAutoDesignRebar()
    {
        if (autoDesignRebarDialogService is null) return;
        if (!IsRectangularSection) return;

        var currentInput = ToDto();
        var owner = System.Windows.Application.Current?.MainWindow;
        var result = autoDesignRebarDialogService.ShowDialog(currentInput, owner);

        if (result is not null)
            ApplyAutoDesignOption(result);
    }

    private void ApplyAutoDesignOption(MBColumn.Application.RebarSuggestion.RebarSuggestionOption option)
    {
        BarSize = option.BarSizeName;

        int nx    = option.BarsOnTopBottomFace;
        int ny    = option.BarsOnLeftRightFace;
        int total = option.TotalBarCount;

        if (nx == ny && (total - 4) % 4 == 0)
        {
            BarCount = total;
            SelectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        }
        else
        {
            SelectedRebarLayoutType = RebarLayoutType.SidesDifferent;
            RebarLayout.Top.BarCount    = nx;
            RebarLayout.Bottom.BarCount = nx;
            RebarLayout.Left.BarCount   = Math.Max(0, ny - 2);
            RebarLayout.Right.BarCount  = Math.Max(0, ny - 2);
            BarCount = total;
        }

        UpdateSectionPreview();
    }
}

internal static class EurocodeConcreteStrainProfileValues
{
    public static double Ec2Peak(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.0020;
        if (fckMpa >= 90.0) return 0.0026;
        return PiecewiseLinear(fckMpa,
            (50, 0.0020), (55, 0.0022), (60, 0.0023), (70, 0.0024), (80, 0.0025), (90, 0.0026));
    }

    public static double Ec3Peak(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.00175;
        if (fckMpa >= 90.0) return 0.0023;
        return PiecewiseLinear(fckMpa,
            (50, 0.00175), (55, 0.0018), (60, 0.0019), (70, 0.0020), (80, 0.0022), (90, 0.0023));
    }

    public static double Ec2Ultimate(double fckMpa)
    {
        if (fckMpa <= 50.0) return 0.0035;
        if (fckMpa >= 90.0) return 0.0026;
        return PiecewiseLinear(fckMpa,
            (50, 0.0035), (55, 0.0031), (60, 0.0029), (70, 0.0027), (80, 0.0026), (90, 0.0026));
    }

    private static double PiecewiseLinear(double x, params (double X, double Y)[] table)
    {
        for (int i = 0; i < table.Length - 1; i++)
        {
            var (x0, y0) = table[i];
            var (x1, y1) = table[i + 1];
            if (x >= x0 && x <= x1)
            {
                double t = (x - x0) / (x1 - x0);
                return y0 + t * (y1 - y0);
            }
        }

        return table[^1].Y;
    }
}

public sealed record DesignCodeOption(DesignCodeType Code, string DisplayName);
public sealed record Ec2SolverOption(Ec2SolverType Solver, string DisplayName);
public sealed record EurocodeConcreteStrainProfileOption(EurocodeConcreteStrainProfile Profile, string DisplayName);
public sealed record SectionIntegrationMethodOption(SectionIntegrationMethod Method, string DisplayName);
public sealed record MaterialLibraryOption(MaterialLibraryType Library, string DisplayName);
public sealed record RebarSetLibraryOption(RebarSetLibraryType Library, string DisplayName);

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
