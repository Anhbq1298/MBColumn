using MBColumn.Application.DTOs;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class InputViewModel : ViewModelBase
{
    private UnitSystem unitSystem = UnitSystem.Metric;
    private DesignCodeType selectedDesignCode = DesignCodeType.Aci318Style;
    private Ec2SolverType selectedEc2Solver = Ec2SolverType.Boundary;
    private readonly IRebarDatabase metricBars;
    private readonly IRebarDatabase imperialBars;
    private readonly IRebarCoordinateBuilderService rebarCoordinateBuilder;
    private double width;
    private double height;
    private double cover;
    private string barSize = "";
    private int barCount;
    private string layoutPreset = "Perimeter bars";
    private RebarLayoutType selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
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
        ApplyMetricDefaults();
        UpdateSectionPreview();
        AddLoadCaseCommand = new RelayCommand(AddLoadCase);
        DeleteLoadCaseCommand = new RelayCommand<LoadCaseViewModel>(DeleteLoadCase);
        DeleteSelectedLoadCasesCommand = new RelayCommand<object>(DeleteSelectedLoadCases);
        RemoveDuplicateLoadCasesCommand = new RelayCommand(RemoveDuplicateLoadCases);
    }

    public IReadOnlyList<UnitSystem> UnitSystems { get; } = [UnitSystem.Metric, UnitSystem.Imperial];
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
    public IReadOnlyList<RebarLayoutTypeOption> RebarLayoutTypes { get; } =
    [
        new(RebarLayoutType.AllSidesEqual, "All Sides Equal"),
        new(RebarLayoutType.SidesDifferent, "Sides Different")
    ];
    public IReadOnlyList<string> LayoutPresets { get; } = ["4 corner bars", "Perimeter bars"];
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

    public double Width { get => width; set { Set(ref width, value); Raise(nameof(SectionWidth)); UpdateSectionPreview(); } }
    public double Height { get => height; set { Set(ref height, value); Raise(nameof(SectionHeight)); UpdateSectionPreview(); } }
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

            Raise();
            Raise(nameof(IsAllSidesEqualLayout));
            Raise(nameof(IsSidesDifferentLayout));
            Raise(nameof(LayoutPreset));
            Raise(nameof(SelectedRebarLayout));
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

    public double SectionWidth { get => Width; set => Width = value; }
    public double SectionHeight { get => Height; set => Height = value; }
    public string SelectedRebarSize { get => BarSize; set => BarSize = value; }
    public int NumberOfBars { get => BarCount; set => BarCount = value; }
    public string SelectedRebarLayout { get => LayoutPreset; set => LayoutPreset = value; }
    public UnitSystem SelectedUnitSystem { get => UnitSystem; set => UnitSystem = value; }
    public bool IsAllSidesEqualLayout => SelectedRebarLayoutType == RebarLayoutType.AllSidesEqual;
    public bool IsSidesDifferentLayout => SelectedRebarLayoutType == RebarLayoutType.SidesDifferent;
    public RebarLayoutViewModel RebarLayout { get; }
    public ObservableCollection<PreviewRebarPoint> PreviewRebars { get; } = [];
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
        var layout = CreateRebarLayoutInput();
        var generatedCoordinates = rebarCoordinateBuilder.Build(layout, Width, Height, layoutLengthUnit, UnitSystem);
        return new(UnitSystem, Width, Height, Cover, BarSize, BarCount, LayoutPreset, Fc, Fy, Es, Pu, Mux, Muy,
            forceUnit,
            layoutLengthUnit,
            momentUnit,
            UnitSystem == UnitSystem.Metric ? StressUnit.MPa : StressUnit.Ksi,
            SelectedPmAngleDegrees,
            SelectedAxialLoad)
        {
            LoadCases = lcDtos,
            RebarLayoutType = SelectedRebarLayoutType,
            TopRebarSide = layout.Top,
            BottomRebarSide = layout.Bottom,
            LeftRebarSide = layout.Left,
            RightRebarSide = layout.Right,
            RebarCoordinates = generatedCoordinates,
            DesignCode = SelectedDesignCode,
            Ec2Solver = SelectedEc2Solver
        };
    }

    public void UpdateSectionPreview()
    {
        PreviewRebars.Clear();
        ClearSideWarnings();
        RebarLayoutWarning = "";
        Raise(nameof(HasRebarLayoutWarning));
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

        IsSectionPreviewValid = true;
        SectionPreviewErrorMessage = "";
        SectionPreviewLabel = $"{Width:0.###} x {Height:0.###} {LengthLabel}";
        RebarPreviewLabel = $"{PreviewRebars.Count}-{BarSize}";
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
        width = 700; height = 700; cover = 55; barSize = "T25"; barCount = 28;
        layoutPreset = "All Sides Equal";
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
        SyncSideGlobalInputs();
        SeedSideCountsFromTotalBars();
        fc = 28; fy = 420; es = 200000; pu = 2500; mux = 250; muy = 180; selectedAxialLoad = 0;
        LoadCases.Clear(); nextLoadCaseIndex = 2;
        AddPrimaryLoadCase();
        RaiseDefaults();
    }

    private void ApplyImperialDefaults()
    {
        width = 28; height = 28; cover = 2.2; barSize = "#8"; barCount = 28;
        layoutPreset = "All Sides Equal";
        selectedRebarLayoutType = RebarLayoutType.AllSidesEqual;
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
        Raise(nameof(Width)); Raise(nameof(Height)); Raise(nameof(Cover)); Raise(nameof(BarSize)); Raise(nameof(BarCount)); Raise(nameof(LayoutPreset));
        Raise(nameof(Fc)); Raise(nameof(Fy)); Raise(nameof(Es)); Raise(nameof(Pu)); Raise(nameof(Mux)); Raise(nameof(Muy)); Raise(nameof(SelectedAxialLoad));
        Raise(nameof(SectionWidth)); Raise(nameof(SectionHeight)); Raise(nameof(SelectedRebarSize)); Raise(nameof(NumberOfBars)); Raise(nameof(SelectedRebarLayout));
        Raise(nameof(SelectedRebarLayoutType)); Raise(nameof(IsAllSidesEqualLayout)); Raise(nameof(IsSidesDifferentLayout));
        Raise(nameof(SelectedDesignCode)); Raise(nameof(FcLabel)); Raise(nameof(FyLabel));
    }
}

public sealed record DesignCodeOption(DesignCodeType Code, string DisplayName);
public sealed record Ec2SolverOption(Ec2SolverType Solver, string DisplayName);

