using MBColumn.Application.DTOs;
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
    private double rectSpacing = 150.0;
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
    private bool _isGeneratingRebars = false;
    private int nextLoadCaseIndex = 2;

    public InputViewModel(IRebarDatabase metricBars, IRebarDatabase imperialBars)
        : this(metricBars, imperialBars, new RebarCoordinateBuilderService(new UnitConversionService(), metricBars, imperialBars))
    {
    }

    public InputViewModel(IRebarDatabase metricBars, IRebarDatabase imperialBars, IRebarCoordinateBuilderService rebarCoordinateBuilder)
    {
        this.metricBars = metricBars;
        this.imperialBars = imperialBars;
        this.rebarCoordinateBuilder = rebarCoordinateBuilder;
        RebarLayout = new RebarLayoutViewModel(UpdateSectionPreview);
        IrregularInput = new IrregularSectionInputViewModel(new IrregularSectionCsvService());
        IrregularInput.BoundaryPoints.CollectionChanged += (_, _) => { if (!_isGeneratingRebars) UpdateSectionPreview(); };
        IrregularInput.PropertyChanged += (sender, args) =>
        {
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
    }

    public IReadOnlyList<UnitSystem> UnitSystems { get; } = [UnitSystem.Metric, UnitSystem.Imperial];
    public ICommand GenerateIrregularRebarsCommand { get; }
    public ICommand GenerateEqualSpacingRebarsCommand { get; }
    public IReadOnlyList<DesignCodeOption> DesignCodes { get; } =
    [
        new(DesignCodeType.Aci318Style, "ACI 318"),
        new(DesignCodeType.Ec2,         "Eurocode 2")
    ];
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

    public IReadOnlyList<RebarLayoutTypeOption> RebarLayoutTypes { get; } =
    [
        new(RebarLayoutType.AllSidesEqual, "All Sides Equal"),
        new(RebarLayoutType.SidesDifferent, "Sides Different")
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
            _isGeneratingRebars = true;
            try
            {
                IrregularInput.LoadDefaultLShape();
            }
            finally
            {
                _isGeneratingRebars = false;
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
            layoutPreset = value == RebarLayoutType.AllSidesEqual ? "All Sides Equal" : "Sides Different";
            if (selectedRebarLayoutType == RebarLayoutType.SidesDifferent)
            {
                SeedSideCountsFromTotalBars();
            }

            if (value == RebarLayoutType.CustomCoordinates)
            {
                IrregularInput.RebarMode = IrregularRebarModeType.CustomCoordinates;
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
            UpdateSectionPreview();
        }
    }
    public double Fc { get => fc; set => Set(ref fc, value); }
    public double Fy { get => fy; set => Set(ref fy, value); }
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
            SectionPreviewLabel = $"Irregular ({IrregularInput.BoundaryPoints.Count} pts)";
            RebarPreviewLabel = $"{IrregularInput.Rebars.Count} rebars";
            CoverPreviewLabel = $"Cover = {Cover:0.###} {LengthLabel}";
            if (valid)
            {
                foreach (var pt in IrregularInput.BoundaryPoints)
                    PreviewBoundaryPoints.Add(new PreviewBoundaryPoint(pt.X, pt.Y));

                var xs = IrregularInput.BoundaryPoints.Select(p => p.X).ToList();
                var ys = IrregularInput.BoundaryPoints.Select(p => p.Y).ToList();
                double bboxCx = (xs.Min() + xs.Max()) / 2.0;
                double bboxCy = (ys.Min() + ys.Max()) / 2.0;
                foreach (var r in IrregularInput.Rebars)
                {
                    double area = r.AreaMm2 ?? 0;
                    double diam = area > 0 ? 2.0 * Math.Sqrt(area / Math.PI) : 20.0;
                    PreviewRebars.Add(new PreviewRebarPoint(r.X - bboxCx, r.Y - bboxCy, diam, r.BarSize ?? ""));
                }
            }
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

    private void ApplyMetricDefaults()
    {
        width = 700; height = 700; diameter = 700; cover = 55; barSize = "T25"; barCount = 28;
        layoutPreset = "All Sides Equal";
        selectedSectionShape = SectionShapeType.Rectangular;
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        selectedIntegrationMethod = SectionIntegrationMethod.Fiber;
        SyncSideGlobalInputs();
        SeedSideCountsFromTotalBars();
        fc = 28; fy = 420; es = 200000; pu = 2500; mux = 250; muy = 180; selectedAxialLoad = 0;
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
        SyncSideGlobalInputs();
        SeedSideCountsFromTotalBars();
        fc = 4; fy = 60; es = 29000; pu = 560; mux = 185; muy = 130; selectedAxialLoad = 0;
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

        // Convert boundary points to Point2D list
        var boundary = IrregularInput.BoundaryPoints.Select(p => new Point2D(p.X, p.Y)).ToList();
        
        // Compute offset distance: cover + barDiameter / 2
        double barDiameter = selectedBar.DiameterMm;
        
        // Cover is in current unit system. Convert to mm if imperial.
        double factor = UnitSystem == UnitSystem.Metric ? 1.0 : 25.4;
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
        _isGeneratingRebars = true;
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
            _isGeneratingRebars = false;
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

        _isGeneratingRebars = true;
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
            _isGeneratingRebars = false;
        }
    }
}

public sealed record DesignCodeOption(DesignCodeType Code, string DisplayName);
public sealed record Ec2SolverOption(Ec2SolverType Solver, string DisplayName);
public sealed record SectionIntegrationMethodOption(SectionIntegrationMethod Method, string DisplayName);

