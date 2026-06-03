using MBColumn.Application.DTOs;
using MBColumn.Application.RebarSuggestion;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Domain.Units;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels.AutomatedRebarDesign;

public sealed class AutomatedRebarDesignViewModel : ViewModelBase
{
    private readonly RebarSuggestionEngine _engine;
    private readonly RebarSuggestionInput _baseInput;
    private readonly IReadOnlyList<RebarDefinition> _allAvailableBars;
    private readonly IReadOnlyList<RebarDefinition> _shearLinkBars;
    private readonly CalculationResultDto? _beforeResult;
    private readonly UnitProfile _unitProfile;

    private bool _isRunning;
    private bool _hasResults;
    private string _statusMessage = "Configure constraints on the right, then click Auto.";
    private CandidateSuggestionRowViewModel? _selectedCandidate;
    private RebarSuggestionOption? _selectedOption;
    private RebarSuggestionOption? _appliedOption;
    private CancellationTokenSource? _cts;
    private static readonly IUnitConversionService DisplayUnits = new UnitConversionService();

    // ── Preview canvas state ───────────────────────────────────────────────────
    private IReadOnlyList<RebarCoordinateDto> _previewRebars = [];
    private string _previewSectionLabel  = string.Empty;
    private string _previewRebarLabel    = string.Empty;
    private string _previewCoverLabel    = string.Empty;
    private bool   _previewIsValid       = false;
    private string _previewStatusText    = "Run Auto, then select a candidate to preview its layout.";
    private int    _selectedTabIndex     = 1;
    private double _previewLinkDiameterMm = 10.0;
    private int    _previewInnerLegsX    = 0;
    private int    _previewInnerLegsY    = 0;

    // ── Parameters tab ────────────────────────────────────────────────────────
    private double _targetPmmRatio   = 1.00;
    private int    _maxSuggestions   = 20;

    private double _initialSpacingMm    = 150.0;
    private double _spacingStepMm       = 10.0;
    private double _minSpacingLimitMm   = 50.0;
    private double _maxBarSpacingMm     = 300.0;
    private double _minBarDiameterMm    = 20.0;

    private bool _allowAllSidesEqual  = true;
    private bool _allowSidesDifferent = true;

    // ── Code / Detailing tab ──────────────────────────────────────────────────
    private bool   _checkMinRho        = true;
    private bool   _checkMaxRho        = true;
    private bool   _checkClearSpacing  = true;
    private double _aggregateSize      = 20.0;
    private bool   _checkBarInsideLink = true;
    private bool   _requireCornerBars  = true;
    private bool   _checkTieDiameter   = true;
    private bool   _checkTieSpacing    = true;
    private bool   _checkUnsupportedBar = true;
    private bool   _warnInternalLinks   = true;

    // ── Shear link design inputs ──────────────────────────────────────────────
    private double _minLinkDiameterMm    = 10.0;   // practical minimum (T10)
    private double _maxLinkSpacingMm     = 0;      // 0 = EC2 auto
    private double _crossTieThresholdMm  = 150.0;
    private double _targetShearUtil      = 1.00;

    // Toggles
    private readonly ObservableCollection<AllowedBarToggleViewModel>  _allowedBarToggles  = new();
    private readonly ObservableCollection<AllowedLinkBarToggleViewModel> _allowedLinkToggles = new();

    public AutomatedRebarDesignViewModel(
        RebarSuggestionEngine engine,
        RebarSuggestionInput baseInput,
        IReadOnlyList<RebarDefinition> allAvailableBars,
        IReadOnlyList<RebarDefinition>? shearLinkBars = null,
        CalculationResultDto? beforeResult = null)
    {
        _engine           = engine;
        _baseInput        = baseInput;
        _allAvailableBars = allAvailableBars;
        _shearLinkBars    = shearLinkBars ?? Array.Empty<RebarDefinition>();
        _beforeResult     = beforeResult;
        _unitProfile      = UnitProfile.For(baseInput.BaseInput.UnitSystem);

        InitialiseBarToggles(allAvailableBars);
        InitialiseLinkBarToggles(_shearLinkBars);
        InitialiseBeforeAfterRows();
        InitialiseCheckRows();

        AutoCommand    = new AsyncRelayCommand(RunAutoAsync, () => !IsRunning);
        PreviewCommand = new RelayCommand(Preview, () => SelectedOption is not null);
        ApplyCommand   = new RelayCommand(Apply, () => SelectedOption is not null && !IsRunning);
        CancelCommand  = new RelayCommand(Cancel);
    }

    // ── Commands ──────────────────────────────────────────────────────────────
    public ICommand AutoCommand { get; }
    public RelayCommand PreviewCommand { get; }
    public RelayCommand ApplyCommand { get; }
    public ICommand CancelCommand { get; }

    // ── Preview canvas ────────────────────────────────────────────────────────
    public UnitSystem PreviewUnitSystem => _unitProfile.UnitSystem;
    public string LengthLabel => _unitProfile.SectionSizeLabel;
    public string AreaLabel => _unitProfile.RebarAreaLabel;
    public string StressLabel => _unitProfile.StressLabel;
    public string AswsLabel => $"{AreaLabel}/{LengthLabel}";
    public string CandidateSteelAreaHeader => $"As {AreaLabel}";
    public string CandidateClearSpacingHeader => $"Clr {LengthLabel}";
    public string CandidateLinkSpacingHeader => $"Sv {LengthLabel}";
    public string InitialSpacingLabel => $"Initial spacing ({LengthLabel})";
    public string SpacingStepLabel => $"Reduction step ({LengthLabel})";
    public string MinSpacingLimitLabel => $"Min spacing limit ({LengthLabel})";
    public string MaxBarSpacingLabel => $"Max bar spacing ({LengthLabel})";
    public string MinDiameterLabel => $"Min diameter ({LengthLabel})";
    public string MinLinkDiameterLabel => $"Min link dia. ({LengthLabel}, 0=auto)";
    public string MaxLinkSpacingLabel => $"Max link spacing ({LengthLabel}, 0=auto)";
    public string CrossTieThresholdLabel => $"Cross-tie threshold ({LengthLabel})";
    public string AggregateSizeLabel => $"Aggregate size ({LengthLabel})";

    public double PreviewSectionWidthMm    => _baseInput.BaseInput.Width;
    public double PreviewSectionHeightMm   => _baseInput.BaseInput.Height;
    public double PreviewCoverMm           => _baseInput.BaseInput.Cover;
    public double PreviewSectionWidthDisplay => DisplayLength(PreviewSectionWidthMm);
    public double PreviewSectionHeightDisplay => DisplayLength(PreviewSectionHeightMm);
    public double PreviewCoverDisplay => DisplayLength(PreviewCoverMm);
    public double PreviewStirrupDiameterMm => _baseInput.BaseInput.LinkDiameterMm > 0
        ? _baseInput.BaseInput.LinkDiameterMm : 10.0;

    public IReadOnlyList<RebarCoordinateDto> PreviewRebars
    {
        get => _previewRebars;
        private set => Set(ref _previewRebars, value);
    }
    public string PreviewSectionLabel  { get => _previewSectionLabel;  private set => Set(ref _previewSectionLabel,  value); }
    public string PreviewRebarLabel    { get => _previewRebarLabel;    private set => Set(ref _previewRebarLabel,    value); }
    public string PreviewCoverLabel    { get => _previewCoverLabel;    private set => Set(ref _previewCoverLabel,    value); }
    public bool   PreviewIsValid       { get => _previewIsValid;       private set => Set(ref _previewIsValid,       value); }
    public string PreviewStatusText    { get => _previewStatusText;    private set => Set(ref _previewStatusText,    value); }
    public int    SelectedTabIndex     { get => _selectedTabIndex;     set => Set(ref _selectedTabIndex, value); }
    public double PreviewLinkDiameterMm { get => _previewLinkDiameterMm; private set => Set(ref _previewLinkDiameterMm, value); }
    public int    PreviewInnerLegsX    { get => _previewInnerLegsX;   private set => Set(ref _previewInnerLegsX,   value); }
    public int    PreviewInnerLegsY    { get => _previewInnerLegsY;   private set => Set(ref _previewInnerLegsY,   value); }

    // ── State ─────────────────────────────────────────────────────────────────
    public bool IsRunning
    {
        get => _isRunning;
        private set
        {
            Set(ref _isRunning, value);
            Raise(nameof(CanApply));
            ApplyCommand.RaiseCanExecuteChanged();
            PreviewCommand.RaiseCanExecuteChanged();
        }
    }
    public bool HasResults { get => _hasResults; private set => Set(ref _hasResults, value); }
    public string StatusMessage { get => _statusMessage; private set => Set(ref _statusMessage, value); }
    public bool CanApply => SelectedOption is not null && !IsRunning;

    public RebarSuggestionOption? AppliedOption
    {
        get => _appliedOption;
        private set => Set(ref _appliedOption, value);
    }
    public bool DialogResult { get; private set; }

    // ── Left panel collections ─────────────────────────────────────────────────
    public ObservableCollection<BeforeAfterRowViewModel>  ParameterRows  { get; } = new();
    public ObservableCollection<CheckSummaryRowViewModel> CheckRows      { get; } = new();
    public ObservableCollection<CandidateSuggestionRowViewModel> CandidateRows { get; } = new();

    public CandidateSuggestionRowViewModel? SelectedCandidate
    {
        get => _selectedCandidate;
        set
        {
            if (!Set(ref _selectedCandidate, value)) return;
            _selectedOption = value?.Option;
            Raise(nameof(SelectedOption));
            Raise(nameof(CanApply));
            ApplyCommand.RaiseCanExecuteChanged();
            PreviewCommand.RaiseCanExecuteChanged();
            if (value?.Option is not null)
            {
                UpdateAfterColumns(value.Option);
                UpdatePreviewCanvas(value.Option);
                SelectedTabIndex = 0;
            }
            else
            {
                ClearPreviewCanvas();
            }
        }
    }
    public RebarSuggestionOption? SelectedOption => _selectedOption;

    // ── Right panel: toggles ──────────────────────────────────────────────────
    public ObservableCollection<AllowedBarToggleViewModel>     AllowedBarToggles  => _allowedBarToggles;
    public ObservableCollection<AllowedLinkBarToggleViewModel>  AllowedLinkToggles => _allowedLinkToggles;

    // ── Right panel: Parameters tab ───────────────────────────────────────────
    public double TargetPmmRatio   { get => _targetPmmRatio;   set => Set(ref _targetPmmRatio, value); }
    public int    MaxSuggestions   { get => _maxSuggestions;   set => Set(ref _maxSuggestions, value); }

    public double InitialSpacingMm   { get => _initialSpacingMm;   set => Set(ref _initialSpacingMm, value); }
    public double SpacingStepMm      { get => _spacingStepMm;      set => Set(ref _spacingStepMm, value); }
    public double MinSpacingLimitMm  { get => _minSpacingLimitMm;  set => Set(ref _minSpacingLimitMm, value); }
    public double MaxBarSpacingMm    { get => _maxBarSpacingMm;    set => Set(ref _maxBarSpacingMm, value); }
    public double MinBarDiameterMm   { get => _minBarDiameterMm;   set => Set(ref _minBarDiameterMm, value); }
    public double InitialSpacingDisplay { get => DisplayLength(_initialSpacingMm); set => SetLengthFromDisplay(ref _initialSpacingMm, value, nameof(InitialSpacingDisplay)); }
    public double SpacingStepDisplay { get => DisplayLength(_spacingStepMm); set => SetLengthFromDisplay(ref _spacingStepMm, value, nameof(SpacingStepDisplay)); }
    public double MinSpacingLimitDisplay { get => DisplayLength(_minSpacingLimitMm); set => SetLengthFromDisplay(ref _minSpacingLimitMm, value, nameof(MinSpacingLimitDisplay)); }
    public double MaxBarSpacingDisplay { get => DisplayLength(_maxBarSpacingMm); set => SetLengthFromDisplay(ref _maxBarSpacingMm, value, nameof(MaxBarSpacingDisplay)); }
    public double MinBarDiameterDisplay { get => DisplayLength(_minBarDiameterMm); set => SetLengthFromDisplay(ref _minBarDiameterMm, value, nameof(MinBarDiameterDisplay)); }

    public bool AllowAllSidesEqual  { get => _allowAllSidesEqual;  set => Set(ref _allowAllSidesEqual, value); }
    public bool AllowSidesDifferent { get => _allowSidesDifferent; set => Set(ref _allowSidesDifferent, value); }

    // ── Right panel: Code / Detailing ─────────────────────────────────────────
    public bool   CheckMinRho         { get => _checkMinRho;        set => Set(ref _checkMinRho, value); }
    public bool   CheckMaxRho         { get => _checkMaxRho;        set => Set(ref _checkMaxRho, value); }
    public bool   CheckClearSpacing   { get => _checkClearSpacing;  set => Set(ref _checkClearSpacing, value); }
    public double AggregateSize       { get => _aggregateSize;      set => Set(ref _aggregateSize, value); }
    public bool   CheckBarInsideLink  { get => _checkBarInsideLink; set => Set(ref _checkBarInsideLink, value); }
    public bool   RequireCornerBars   { get => _requireCornerBars;  set => Set(ref _requireCornerBars, value); }
    public bool   CheckTieDiameter    { get => _checkTieDiameter;   set => Set(ref _checkTieDiameter, value); }
    public bool   CheckTieSpacing     { get => _checkTieSpacing;    set => Set(ref _checkTieSpacing, value); }
    public bool   CheckUnsupportedBar { get => _checkUnsupportedBar; set => Set(ref _checkUnsupportedBar, value); }
    public bool   WarnInternalLinks   { get => _warnInternalLinks;  set => Set(ref _warnInternalLinks, value); }

    // ── Shear link design inputs ──────────────────────────────────────────────
    public double MinLinkDiameterMm   { get => _minLinkDiameterMm;   set => Set(ref _minLinkDiameterMm, value); }
    public double MaxLinkSpacingMm    { get => _maxLinkSpacingMm;    set => Set(ref _maxLinkSpacingMm, value); }
    public double CrossTieThresholdMm { get => _crossTieThresholdMm; set => Set(ref _crossTieThresholdMm, value); }
    public double MinLinkDiameterDisplay { get => DisplayLength(_minLinkDiameterMm); set => SetLengthFromDisplay(ref _minLinkDiameterMm, value, nameof(MinLinkDiameterDisplay)); }
    public double MaxLinkSpacingDisplay { get => DisplayLength(_maxLinkSpacingMm); set => SetLengthFromDisplay(ref _maxLinkSpacingMm, value, nameof(MaxLinkSpacingDisplay)); }
    public double CrossTieThresholdDisplay { get => DisplayLength(_crossTieThresholdMm); set => SetLengthFromDisplay(ref _crossTieThresholdMm, value, nameof(CrossTieThresholdDisplay)); }
    public double TargetShearUtil     { get => _targetShearUtil;     set => Set(ref _targetShearUtil, value); }
    public double AggregateSizeDisplay { get => DisplayLength(_aggregateSize); set => SetLengthFromDisplay(ref _aggregateSize, value, nameof(AggregateSizeDisplay)); }

    // ── Design Summary ────────────────────────────────────────────────────────
    private string _candidateCountsText = "—";
    public  string CandidateCountsText  { get => _candidateCountsText; private set => Set(ref _candidateCountsText, value); }

    private string _summaryText = "Run Auto to see suggestions.";
    public  string SummaryText  { get => _summaryText; private set => Set(ref _summaryText, value); }

    private string _bestPmmConfig = "—";  public string BestPmmConfig  { get => _bestPmmConfig;  private set => Set(ref _bestPmmConfig, value); }
    private string _bestPmmValue  = "—";  public string BestPmmValue   { get => _bestPmmValue;   private set => Set(ref _bestPmmValue,  value); }
    private string _bestPmmRho    = "—";  public string BestPmmRho     { get => _bestPmmRho;     private set => Set(ref _bestPmmRho,    value); }
    private string _bestPmmLink   = "—";  public string BestPmmLink    { get => _bestPmmLink;    private set => Set(ref _bestPmmLink,   value); }

    private string _lowestRhoConfig = "—"; public string LowestRhoConfig { get => _lowestRhoConfig; private set => Set(ref _lowestRhoConfig, value); }
    private string _lowestRhoValue  = "—"; public string LowestRhoValue  { get => _lowestRhoValue;  private set => Set(ref _lowestRhoValue,  value); }
    private string _lowestRhoPmm    = "—"; public string LowestRhoPmm    { get => _lowestRhoPmm;    private set => Set(ref _lowestRhoPmm,    value); }
    private string _lowestRhoLink   = "—"; public string LowestRhoLink   { get => _lowestRhoLink;   private set => Set(ref _lowestRhoLink,   value); }

    // ──────────────────────────────────────────────────────────────────────────

    private async Task RunAutoAsync()
    {
        IsRunning = true;
        StatusMessage = "Generating candidates…";

        _cts?.Cancel();
        _cts?.Dispose();
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        try
        {
            var constraints = BuildConstraintSet();
            var allowedBars = _allowedBarToggles
                .Where(t => t.IsEnabled)
                .Select(t => t.Bar)
                .ToList();
            var allowedLinkBars = _allowedLinkToggles
                .Where(t => t.IsEnabled)
                .Select(t => t.Bar)
                .ToList();

            if (allowedBars.Count == 0)
            {
                StatusMessage = "No bar sizes selected. Enable at least one bar size.";
                return;
            }

            var input = new RebarSuggestionInput
            {
                BaseInput       = _baseInput.BaseInput,
                Constraints     = constraints,
                AllowedBars     = allowedBars,
                AllowedLinkBars = allowedLinkBars
            };

            var progress = new Progress<(int done, int total)>(p =>
                StatusMessage = $"Evaluating candidates… {p.done} / {p.total}");

            var result = await Task.Run(() => _engine.Suggest(input, progress, token), token);
            PopulateResults(result);
        }
        catch (OperationCanceledException)
        {
            StatusMessage = "Auto design cancelled.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
        finally
        {
            IsRunning = false;
        }
    }

    private void Preview()
    {
        if (SelectedOption is null) return;
        SelectedTabIndex = 0;
    }

    private void Apply()
    {
        if (SelectedOption is null) return;
        AppliedOption = SelectedOption;
        DialogResult  = true;
        DisposeCts();
        CloseRequested?.Invoke(this, EventArgs.Empty);
    }

    private void Cancel()
    {
        _cts?.Cancel();
        DisposeCts();
        DialogResult = false;
        CloseRequested?.Invoke(this, EventArgs.Empty);
    }

    private void DisposeCts()
    {
        _cts?.Dispose();
        _cts = null;
    }

    public override void Dispose() => DisposeCts();

    public event EventHandler? CloseRequested;

    // ── Initialisation ────────────────────────────────────────────────────────

    private void InitialiseBarToggles(IReadOnlyList<RebarDefinition> bars)
    {
        _allowedBarToggles.Clear();
        foreach (var bar in bars.Where(b => b.DiameterMm >= 20.0))
            _allowedBarToggles.Add(new AllowedBarToggleViewModel(bar, isEnabled: true));
    }

    private void InitialiseLinkBarToggles(IReadOnlyList<RebarDefinition> bars)
    {
        _allowedLinkToggles.Clear();
        foreach (var bar in bars)
            _allowedLinkToggles.Add(new AllowedLinkBarToggleViewModel(bar, isEnabled: true));
    }

    private void InitialiseBeforeAfterRows()
    {
        var dto = _baseInput.BaseInput;
        ParameterRows.Clear();

        double totalAs = dto.RebarCoordinates?.Sum(r => r.Area) ?? 0;
        double acMm2   = dto.Width * dto.Height;
        double rho     = acMm2 > 0 ? totalAs / acMm2 * 100 : 0;

        string nxBefore = "—", nyBefore = "—";
        if (dto.TopRebarSide is { } top && top.BarCount > 0)
        {
            nxBefore = $"{top.BarCount}";
            nyBefore = dto.LeftRebarSide is { } left ? $"{left.BarCount + 2}" : "—";
        }
        else if (dto.BarCount >= 4 && dto.RebarLayoutType == RebarLayoutType.AllSidesEqual)
        {
            int nx = (dto.BarCount - 4) / 4 + 2;
            nxBefore = nyBefore = $"{nx}";
        }

        Add("Width b",               FormatLength(dto.Width),    LengthLabel,  frozen: true);
        Add("Depth h",               FormatLength(dto.Height),   LengthLabel,  frozen: true);
        Add("Concrete cover",        FormatLength(dto.Cover),    LengthLabel,  frozen: true);
        Add("Link diameter",         dto.LinkDiameterMm > 0 ? FormatLength(dto.LinkDiameterMm) : "—", LengthLabel, frozen: true);
        Add("Longitudinal bar dia.", dto.BarSize,          "—",   frozen: false);
        Add("No. of bars",           $"{dto.BarCount}",    "—",   frozen: false);
        Add("Bars along X face",     nxBefore,             "—",   frozen: false);
        Add("Bars along Y face",     nyBefore,             "—",   frozen: false);
        Add("Layout type",           "Perimeter",          "—",   frozen: true);
        Add("Total steel area As",   FormatArea(totalAs),  AreaLabel, frozen: false);
        Add("Steel ratio ρ",         $"{rho:F2}",          "%",   frozen: false);
        Add("Link bar (auto)",       "—",                  "—",   frozen: false);
        Add("Link spacing (auto)",   "—",                  LengthLabel,  frozen: false);
        Add("Internal cross-ties",   "—",                  "—",   frozen: false);
        Add("fck",                   FormatStress(dto.Fc), StressLabel, frozen: true);
        Add("fyk",                   FormatStress(dto.Fy), StressLabel, frozen: true);

        void Add(string param, string before, string unit, bool frozen)
        {
            var row = new BeforeAfterRowViewModel
            {
                Parameter = param, Before = before, Unit = unit, IsFrozen = frozen
            };
            row.After = before;
            ParameterRows.Add(row);
        }
    }

    private void InitialiseCheckRows()
    {
        CheckRows.Clear();
        var r = _beforeResult;

        string pmmBefore = r is not null ? $"{r.Ratio:F2}" : "—";
        string vxBefore  = r?.GoverningShearResult is { } s  ? $"{s.UtilisationX:F2}"  : "—";
        string vyBefore  = r?.GoverningShearResult is { } sv ? $"{sv.UtilisationY:F2}" : "—";
        bool pmmPass = r is null || r.Ratio <= 1.0;
        bool vxPass  = r?.GoverningShearResult is null || r.GoverningShearResult.UtilisationX <= 1.0;
        bool vyPass  = r?.GoverningShearResult is null || r.GoverningShearResult.UtilisationY <= 1.0;

        string GetC(string name)
        {
            if (r?.RebarCompliance is null) return "—";
            var chk = r.RebarCompliance.Checks.FirstOrDefault(c =>
                c.Description.Contains(name, StringComparison.OrdinalIgnoreCase));
            return chk is null ? "—" : (chk.Pass ? "OK" : "Fail");
        }
        bool GetCPass(string name)
        {
            if (r?.RebarCompliance is null) return true;
            var chk = r.RebarCompliance.Checks.FirstOrDefault(c =>
                c.Description.Contains(name, StringComparison.OrdinalIgnoreCase));
            return chk?.Pass ?? true;
        }

        void Add(string name, string before, bool pass) =>
            CheckRows.Add(new CheckSummaryRowViewModel { CheckName = name, Before = before, IsPassBefore = pass });

        Add("PMM utilization",           pmmBefore,                          pmmPass);
        Add("Vx utilization",            vxBefore,                           vxPass);
        Add("Vy utilization",            vyBefore,                           vyPass);
        Add("Minimum ρ",                 GetC("Min"),                        GetCPass("Min"));
        Add("Maximum ρ",                 GetC("Max"),                        GetCPass("Max"));
        Add("Clear spacing",             "—",                                true);
        Add("Corner bars",               "OK",                               true);
        Add("Bars inside link boundary", "OK",                               true);
        Add("Tie compatibility",         GetC("link diameter"),              GetCPass("link diameter"));
        Add("Unsupported bar distance",  "—",                               true);
        Add("Internal link warning",     "—",                               true);
        Add("Link bar (auto)",           "—",                               true);
        Add("Link spacing (auto)",       "—",                               true);
        Add("Cross-ties",                "—",                               true);
        Add("Asw/s (X) demand",          "—",                               true);
        Add("Asw/s (Y) demand",          "—",                               true);
        Add("Overall", r is null ? "—" : (pmmPass && vxPass && vyPass ? "OK" : "Failed"),
            r is null || (pmmPass && vxPass && vyPass));
    }

    private void PopulateResults(RebarSuggestionResult result)
    {
        CandidateRows.Clear();
        foreach (var opt in result.Options)
        {
            string shearDisplay = opt.MaximumShearUtilization.HasValue
                ? $"{opt.MaximumShearUtilization.Value:F2}" : "—";

            string spacingStatus = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingFailed)
                ? "Failed"
                : opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingTight)
                    ? "Warn" : "OK";

            string layoutLabel = opt.LayoutType switch
            {
                RebarCandidateLayoutType.AllSidesEqual          => "Equal",
                RebarCandidateLayoutType.SideDifferentSymmetric => "Sym",
                _                                               => "Asym"
            };

            string clearDisplay = opt.MinimumClearSpacingMm is > 0 and < double.PositiveInfinity
                ? $"{FormatLength(opt.MinimumClearSpacingMm)} {LengthLabel}" : "—";

            var lnk = opt.ShearLinkDesign;
            string linkLabel    = lnk is not null ? lnk.LinkBarLabel : "—";
            string linkSpacing  = lnk is not null ? $"{FormatLength(lnk.LinkSpacingMm)} {LengthLabel}" : "—";
            string intLinks = lnk is not null
                ? $"X:{lnk.InternalLinksX} Y:{lnk.InternalLinksY}"
                : "—";

            CandidateRows.Add(new CandidateSuggestionRowViewModel
            {
                Rank                      = opt.Rank,
                Config                    = opt.ConfigurationName,
                LayoutTypeLabel           = layoutLabel,
                TotalSteelAreaMm2         = opt.TotalSteelAreaMm2,
                SteelAreaDisplay          = $"{FormatArea(opt.TotalSteelAreaMm2)} {AreaLabel}",
                ReinforcementRatioPercent = opt.ReinforcementRatio * 100,
                MaxPmmUtilization         = opt.MaximumPmmUtilization,
                MaxShearDisplay           = shearDisplay,
                SpacingStatus             = spacingStatus,
                MinClearSpacingDisplay    = clearDisplay,
                LinkLabel                 = linkLabel,
                LinkSpacingDisplay        = linkSpacing,
                InternalLinksDisplay      = intLinks,
                RecommendationTag         = opt.RecommendationTag,
                Status                    = opt.Status,
                Reason                    = opt.Reason,
                Option                    = opt
            });
        }

        var best = CandidateRows.FirstOrDefault();
        if (best is not null) SelectedCandidate = best;

        UpdateDesignSummary(result);
        StatusMessage = result.SummaryMessage;
        HasResults    = true;
    }

    private void UpdateDesignSummary(RebarSuggestionResult result)
    {
        CandidateCountsText = $"{result.TotalCandidateCount} candidates — " +
                              $"{result.PassedCandidateCount} passed, {result.FailedCandidateCount} filtered";

        string FormatLink(RebarSuggestionOption? opt) =>
            opt?.ShearLinkDesign is { } lnk
                ? $"{lnk.LinkBarLabel} @ {FormatLength(lnk.LinkSpacingMm)} {LengthLabel}" +
                  (lnk.InternalLinkCount > 0
                      ? $" + {lnk.InternalLinksX}x/{lnk.InternalLinksY}y cross-ties"
                      : string.Empty)
                : "—";

        var bestPmm   = result.BestPmmUtilizationOption;
        var lowestRho = result.LowestRebarRatioOption;

        BestPmmConfig = bestPmm?.ConfigurationName ?? "None";
        BestPmmValue  = bestPmm is not null ? $"{bestPmm.MaximumPmmUtilization:F2}" : "—";
        BestPmmRho    = bestPmm is not null ? $"{bestPmm.ReinforcementRatio * 100:F2}%" : "—";
        BestPmmLink   = FormatLink(bestPmm);

        LowestRhoConfig = lowestRho?.ConfigurationName ?? "None";
        LowestRhoValue  = lowestRho is not null ? $"{lowestRho.ReinforcementRatio * 100:F2}%" : "—";
        LowestRhoPmm    = lowestRho is not null ? $"{lowestRho.MaximumPmmUtilization:F2}" : "—";
        LowestRhoLink   = FormatLink(lowestRho);

        if (bestPmm is not null && lowestRho is not null)
        {
            bool same = bestPmm.ConfigurationName == lowestRho.ConfigurationName
                        && bestPmm.TotalBarCount  == lowestRho.TotalBarCount
                        && bestPmm.BarSizeName    == lowestRho.BarSizeName;
            SummaryText = same
                ? "Both criteria select the same candidate."
                : $"Best PMM: {bestPmm.ConfigurationName}  |  Lowest ρ: {lowestRho.ConfigurationName}";
        }
        else
        {
            SummaryText = bestPmm is null && lowestRho is null
                ? "No passing candidate. Try a higher Target PMM Ratio or adjust spacing limits."
                : bestPmm?.ConfigurationName ?? lowestRho?.ConfigurationName ?? "—";
        }
    }

    private void UpdateAfterColumns(RebarSuggestionOption opt)
    {
        SetAfter("Longitudinal bar dia.",  opt.BarSizeName);
        SetAfter("No. of bars",            $"{opt.TotalBarCount}");
        SetAfter("Bars along X face",      $"{opt.BarsOnTopBottomFace}");
        SetAfter("Bars along Y face",      $"{opt.BarsOnLeftRightFace}");
        SetAfter("Total steel area As",    FormatArea(opt.TotalSteelAreaMm2));
        SetAfter("Steel ratio ρ",          $"{opt.ReinforcementRatio * 100:F2}");

        if (opt.ShearLinkDesign is { } lnk)
        {
            SetAfter("Link bar (auto)",      lnk.LinkBarLabel);
            SetAfter("Link spacing (auto)",  FormatLength(lnk.LinkSpacingMm));
            SetAfter("Internal cross-ties",
                lnk.InternalLinkCount > 0
                    ? $"X:{lnk.InternalLinksX}  Y:{lnk.InternalLinksY}"
                    : "0 (peripheral only)");
        }

        void SetAfter(string param, string value)
        {
            var row = ParameterRows.FirstOrDefault(r => r.Parameter == param);
            if (row is not null) row.After = value;
        }

        UpdateCheckRow("PMM utilization", $"{opt.MaximumPmmUtilization:F2}", opt.MaximumPmmUtilization <= _targetPmmRatio);
        UpdateCheckRow("Vx utilization", opt.VxUtilization.HasValue ? $"{opt.VxUtilization:F2}" : "—", opt.VxUtilization is null or <= 1.0);
        UpdateCheckRow("Vy utilization", opt.VyUtilization.HasValue ? $"{opt.VyUtilization:F2}" : "—", opt.VyUtilization is null or <= 1.0);

        bool rhoLow  = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ReinforcementRatioTooLow);
        bool rhoHigh = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ReinforcementRatioTooHigh);
        UpdateCheckRow("Minimum ρ", rhoLow  ? "Failed" : "OK", !rhoLow);
        UpdateCheckRow("Maximum ρ", rhoHigh ? "Failed" : "OK", !rhoHigh);

        bool spaceFail = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingFailed);
        bool spaceWarn = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingTight);
        UpdateCheckRow("Clear spacing", spaceFail ? "Failed" : spaceWarn ? "Warn" : "OK", !spaceFail);

        bool corner = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.MissingCornerBar);
        UpdateCheckRow("Corner bars", corner ? "Failed" : "OK", !corner);

        bool outside = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.BarOutsideLinkBoundary);
        UpdateCheckRow("Bars inside link boundary", outside ? "Failed" : "OK", !outside);

        bool tieIssue = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.TieCompatibilityIssue);
        UpdateCheckRow("Tie compatibility", tieIssue ? "Warn" : "OK", true);

        bool internalLinksProvided = opt.ShearLinkDesign?.InternalLinksRequired == true;
        bool unsupported = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.InternalLinksRequired);
        UpdateCheckRow("Unsupported bar distance",
            internalLinksProvided ? "Resolved by cross-ties" : unsupported ? "Warn" : "OK",
            true);
        UpdateCheckRow("Internal link warning",
            internalLinksProvided ? "Cross-ties provided" : unsupported ? "Yes" : "No",
            true);

        if (opt.ShearLinkDesign is { } ld)
        {
            bool noBar = ld.NoSuitableLinkBarFound;
            UpdateCheckRow("Link bar (auto)",    ld.LinkBarLabel,                 !noBar);
            UpdateCheckRow("Link spacing (auto)", $"{FormatLength(ld.LinkSpacingMm)} {LengthLabel}", true);
            UpdateCheckRow("Cross-ties",
                $"ΔX={FormatLength(ld.ActualGapX)} ΔY={FormatLength(ld.ActualGapY)} {LengthLabel}" +
                (ld.GapCheckPass ? " ✓" : " ✗") +
                $"  (X:{ld.InternalLinksX} Y:{ld.InternalLinksY})",
                ld.GapCheckPass);

            if (ld.HasShearDemand)
            {
                UpdateCheckRow("Asw/s (X) demand",
                    $"req {FormatAsws(ld.RequiredAswsX)}  prov {FormatAsws(ld.ProvidedAswsX)} {AswsLabel}",
                    ld.ProvidedAswsX >= ld.RequiredAswsX - 1e-9);
                UpdateCheckRow("Asw/s (Y) demand",
                    $"req {FormatAsws(ld.RequiredAswsY)}  prov {FormatAsws(ld.ProvidedAswsY)} {AswsLabel}",
                    ld.ProvidedAswsY >= ld.RequiredAswsY - 1e-9);
            }
        }

        bool overall = opt.Status != RebarSuggestionStatus.Failed;
        UpdateCheckRow("Overall", overall ? (opt.Status == RebarSuggestionStatus.Warning ? "Acceptable" : "OK") : "Failed", overall);

        void UpdateCheckRow(string name, string after, bool pass)
        {
            var row = CheckRows.FirstOrDefault(r => r.CheckName == name);
            if (row is null) return;
            row.After       = after;
            row.IsPassAfter = pass;
            row.Status      = pass ? "OK" : "Failed";
            row.Condition   = after == row.Before ? "Unchanged" : "Changed";
        }
    }

    private void UpdatePreviewCanvas(RebarSuggestionOption opt)
    {
        var dto = _baseInput.BaseInput;
        PreviewRebars       = opt.Coordinates;
        PreviewSectionLabel = $"b = {FormatLength(dto.Width)} x h = {FormatLength(dto.Height)} {LengthLabel}";
        PreviewCoverLabel   = $"Cover = {FormatLength(dto.Cover)} {LengthLabel}";
        PreviewIsValid      = opt.Status != Domain.Enums.RebarSuggestionStatus.Failed;

        if (opt.ShearLinkDesign is { } lnk)
        {
            PreviewLinkDiameterMm = lnk.LinkDiameterMm > 0 ? lnk.LinkDiameterMm : PreviewStirrupDiameterMm;
            PreviewInnerLegsX     = lnk.InternalLinksX;
            PreviewInnerLegsY     = lnk.InternalLinksY;

            string crossTieNote = lnk.InternalLinkCount > 0
                ? $"  X-ties: X{lnk.InternalLinksX}/Y{lnk.InternalLinksY}  ΔX={FormatLength(lnk.ActualGapX)} ΔY={FormatLength(lnk.ActualGapY)} {LengthLabel}"
                : string.Empty;
            PreviewRebarLabel = $"{opt.TotalBarCount}{opt.BarSizeName}  ρ={opt.ReinforcementRatio * 100:F2}%  |  " +
                                $"{lnk.LinkBarLabel}@{FormatLength(lnk.LinkSpacingMm)}{LengthLabel}{crossTieNote}";
        }
        else
        {
            PreviewLinkDiameterMm = PreviewStirrupDiameterMm;
            PreviewInnerLegsX     = 0;
            PreviewInnerLegsY     = 0;
            PreviewRebarLabel = $"{opt.TotalBarCount}{opt.BarSizeName}   As = {FormatArea(opt.TotalSteelAreaMm2)} {AreaLabel}   ρ = {opt.ReinforcementRatio * 100:F2}%";
        }

        string tagNote = string.IsNullOrEmpty(opt.RecommendationTag) ? string.Empty : $"  [{opt.RecommendationTag}]";
        PreviewStatusText = $"Rank #{opt.Rank} — {opt.Reason}{tagNote}";
    }

    private void ClearPreviewCanvas()
    {
        PreviewRebars         = [];
        PreviewSectionLabel   = string.Empty;
        PreviewRebarLabel     = string.Empty;
        PreviewCoverLabel     = string.Empty;
        PreviewIsValid        = false;
        PreviewStatusText     = "Run Auto, then select a candidate to preview its layout.";
        PreviewLinkDiameterMm = PreviewStirrupDiameterMm;
        PreviewInnerLegsX     = 0;
        PreviewInnerLegsY     = 0;
    }

    private double DisplayLength(double valueMm)
        => DisplayUnits.LengthFromMm(valueMm, _unitProfile.SectionSizeUnit);

    private double LengthToMm(double displayValue)
        => DisplayUnits.LengthToMm(displayValue, _unitProfile.SectionSizeUnit);

    private bool SetLengthFromDisplay(ref double storageMm, double displayValue, string propertyName)
        => Set(ref storageMm, LengthToMm(displayValue), propertyName);

    private double DisplayArea(double valueMm2)
    {
        double scale = DisplayLength(1.0);
        return valueMm2 * scale * scale;
    }

    private double DisplayAsws(double valueMm2PerMm)
        => valueMm2PerMm * DisplayLength(1.0);

    private double DisplayStress(double valueMpa)
        => DisplayUnits.StressFromMpa(valueMpa, _unitProfile.StressUnit);

    private string FormatLength(double valueMm)
        => _unitProfile.SectionSizeUnit == LengthUnit.Millimeter
            ? $"{DisplayLength(valueMm):F0}"
            : $"{DisplayLength(valueMm):F2}";

    private string FormatArea(double valueMm2)
        => _unitProfile.SectionSizeUnit == LengthUnit.Millimeter
            ? $"{DisplayArea(valueMm2):F0}"
            : $"{DisplayArea(valueMm2):F3}";

    private string FormatAsws(double valueMm2PerMm)
        => _unitProfile.SectionSizeUnit == LengthUnit.Millimeter
            ? $"{DisplayAsws(valueMm2PerMm):F3}"
            : $"{DisplayAsws(valueMm2PerMm):F4}";

    private string FormatStress(double valueMpa)
        => _unitProfile.StressUnit == StressUnit.MPa
            ? $"{DisplayStress(valueMpa):F0}"
            : $"{DisplayStress(valueMpa):F2}";

    private RebarSuggestionConstraintSet BuildConstraintSet()
    {
        var longNames = _allowedBarToggles.Where(t => t.IsEnabled).Select(t => t.Bar.Name).ToList();
        var linkNames = _allowedLinkToggles.Where(t => t.IsEnabled).Select(t => t.Bar.Name).ToList();

        return new RebarSuggestionConstraintSet
        {
            AllowedBarSizeNames          = longNames,
            AllowedLinkBarSizeNames      = linkNames,
            MinimumBarDiameterMm         = _minBarDiameterMm,
            InitialTargetSpacingMm       = _initialSpacingMm,
            SpacingReductionStepMm       = _spacingStepMm,
            MinimumSpacingSearchLimitMm  = _minSpacingLimitMm,
            MaximumBarSpacingMm          = _maxBarSpacingMm,
            UserTargetPmmRatio           = _targetPmmRatio,
            MinLinkDiameterMm            = _minLinkDiameterMm,
            MaxLinkSpacingMm             = _maxLinkSpacingMm,
            CrossTieThresholdMm          = _crossTieThresholdMm,
            TargetShearUtilization       = _targetShearUtil,
            AllowAllSidesEqualLayout     = _allowAllSidesEqual,
            AllowSidesDifferentLayout    = _allowSidesDifferent,
            RequireSymmetricLayout       = true,
            RequireCornerBars            = _requireCornerBars,
            CheckClearSpacing            = _checkClearSpacing,
            CheckReinforcementRatio      = _checkMinRho || _checkMaxRho,
            CheckTieCompatibility        = _checkTieDiameter || _checkTieSpacing,
            AggregateSizeMm              = _aggregateSize,
            MaximumSuggestionsToShow     = _maxSuggestions
        };
    }
}

// ── Support types ─────────────────────────────────────────────────────────────

public sealed class AllowedBarToggleViewModel(RebarDefinition bar, bool isEnabled) : ViewModelBase
{
    private bool _isEnabled = isEnabled;
    public RebarDefinition Bar   { get; } = bar;
    public string Label => Bar.DisplayLabel ?? Bar.Name;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
}

public sealed class AllowedLinkBarToggleViewModel(RebarDefinition bar, bool isEnabled) : ViewModelBase
{
    private bool _isEnabled = isEnabled;
    public RebarDefinition Bar   { get; } = bar;
    public string Label => Bar.DisplayLabel ?? Bar.Name;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
}
