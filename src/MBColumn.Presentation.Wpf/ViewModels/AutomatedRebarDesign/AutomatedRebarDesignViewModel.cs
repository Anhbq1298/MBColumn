using MBColumn.Application.DTOs;
using MBColumn.Application.RebarSuggestion;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
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

    private bool _isRunning;
    private bool _hasResults;
    private string _statusMessage = "Configure constraints on the right, then click Auto.";
    private CandidateSuggestionRowViewModel? _selectedCandidate;
    private RebarSuggestionOption? _selectedOption;
    private RebarSuggestionOption? _appliedOption;
    private CancellationTokenSource? _cts;

    // ── Preview canvas state ───────────────────────────────────────────────────
    private IReadOnlyList<RebarCoordinateDto> _previewRebars = [];
    private string _previewSectionLabel  = string.Empty;
    private string _previewRebarLabel    = string.Empty;
    private string _previewCoverLabel    = string.Empty;
    private bool   _previewIsValid       = false;
    private string _previewStatusText    = "Run Auto, then select a candidate to preview its layout.";
    private int    _selectedTabIndex     = 1;

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
    private double _minLinkDiameterMm    = 0;      // 0 = EC2 auto
    private double _maxLinkSpacingMm     = 0;      // 0 = EC2 auto
    private double _crossTieThresholdMm  = 150.0;

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
    public double PreviewSectionWidthMm    => _baseInput.BaseInput.Width;
    public double PreviewSectionHeightMm   => _baseInput.BaseInput.Height;
    public double PreviewCoverMm           => _baseInput.BaseInput.Cover;
    public double PreviewStirrupDiameterMm => _baseInput.BaseInput.LinkDiameterMm > 0
        ? _baseInput.BaseInput.LinkDiameterMm : 10.0;

    public IReadOnlyList<RebarCoordinateDto> PreviewRebars
    {
        get => _previewRebars;
        private set => Set(ref _previewRebars, value);
    }
    public string PreviewSectionLabel { get => _previewSectionLabel; private set => Set(ref _previewSectionLabel, value); }
    public string PreviewRebarLabel   { get => _previewRebarLabel;   private set => Set(ref _previewRebarLabel,   value); }
    public string PreviewCoverLabel   { get => _previewCoverLabel;   private set => Set(ref _previewCoverLabel,   value); }
    public bool   PreviewIsValid      { get => _previewIsValid;      private set => Set(ref _previewIsValid,      value); }
    public string PreviewStatusText   { get => _previewStatusText;   private set => Set(ref _previewStatusText,   value); }
    public int    SelectedTabIndex    { get => _selectedTabIndex;    set => Set(ref _selectedTabIndex, value); }

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
        CloseRequested?.Invoke(this, EventArgs.Empty);
    }

    private void Cancel()
    {
        _cts?.Cancel();
        DialogResult = false;
        CloseRequested?.Invoke(this, EventArgs.Empty);
    }

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

        Add("Width b",               $"{dto.Width:F0}",    "mm",  frozen: true);
        Add("Depth h",               $"{dto.Height:F0}",   "mm",  frozen: true);
        Add("Concrete cover",        $"{dto.Cover:F0}",    "mm",  frozen: true);
        Add("Link diameter",         dto.LinkDiameterMm > 0 ? $"{dto.LinkDiameterMm:F0}" : "—", "mm", frozen: true);
        Add("Longitudinal bar dia.", dto.BarSize,          "—",   frozen: false);
        Add("No. of bars",           $"{dto.BarCount}",    "—",   frozen: false);
        Add("Bars along X face",     nxBefore,             "—",   frozen: false);
        Add("Bars along Y face",     nyBefore,             "—",   frozen: false);
        Add("Layout type",           "Perimeter",          "—",   frozen: true);
        Add("Total steel area As",   $"{totalAs:F0}",      "mm²", frozen: false);
        Add("Steel ratio ρ",         $"{rho:F2}",          "%",   frozen: false);
        Add("Link bar (auto)",       "—",                  "—",   frozen: false);
        Add("Link spacing (auto)",   "—",                  "mm",  frozen: false);
        Add("Internal cross-ties",   "—",                  "—",   frozen: false);
        Add("fck",                   $"{dto.Fc:F0}",       "MPa", frozen: true);
        Add("fyk",                   $"{dto.Fy:F0}",       "MPa", frozen: true);

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
                ? $"{opt.MinimumClearSpacingMm:F0}" : "—";

            var lnk = opt.ShearLinkDesign;
            string linkLabel    = lnk is not null ? lnk.LinkBarLabel : "—";
            string linkSpacing  = lnk is not null ? $"{lnk.LinkSpacingMm:F0}" : "—";
            string intLinks = lnk is not null
                ? (lnk.InternalLinkCount > 0
                    ? $"X:{lnk.InternalLinksX} Y:{lnk.InternalLinksY}"
                    : "0")
                : "—";

            CandidateRows.Add(new CandidateSuggestionRowViewModel
            {
                Rank                      = opt.Rank,
                Config                    = opt.ConfigurationName,
                LayoutTypeLabel           = layoutLabel,
                TotalSteelAreaMm2         = opt.TotalSteelAreaMm2,
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

        static string FormatLink(RebarSuggestionOption? opt) =>
            opt?.ShearLinkDesign is { } lnk
                ? $"{lnk.LinkBarLabel} @ {lnk.LinkSpacingMm:F0} mm" +
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
        SetAfter("Total steel area As",    $"{opt.TotalSteelAreaMm2:F0}");
        SetAfter("Steel ratio ρ",          $"{opt.ReinforcementRatio * 100:F2}");

        if (opt.ShearLinkDesign is { } lnk)
        {
            SetAfter("Link bar (auto)",      lnk.LinkBarLabel);
            SetAfter("Link spacing (auto)",  $"{lnk.LinkSpacingMm:F0}");
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

        bool unsupported = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.InternalLinksRequired);
        UpdateCheckRow("Unsupported bar distance", unsupported ? "Warn" : "OK", true);
        UpdateCheckRow("Internal link warning", unsupported ? "Yes" : "No", true);

        if (opt.ShearLinkDesign is { } ld)
        {
            bool noBar = ld.NoSuitableLinkBarFound;
            UpdateCheckRow("Link bar (auto)",    ld.LinkBarLabel,                 !noBar);
            UpdateCheckRow("Link spacing (auto)", $"{ld.LinkSpacingMm:F0} mm",    true);
            UpdateCheckRow("Cross-ties",
                ld.InternalLinkCount > 0
                    ? $"X:{ld.InternalLinksX}  Y:{ld.InternalLinksY}"
                    : "0 (peripheral only)",
                true);
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
        PreviewSectionLabel = $"b = {dto.Width:F0} × h = {dto.Height:F0} mm";
        PreviewRebarLabel   = $"{opt.TotalBarCount}{opt.BarSizeName}   As = {opt.TotalSteelAreaMm2:F0} mm²   ρ = {opt.ReinforcementRatio * 100:F2}%";
        PreviewCoverLabel   = $"Cover = {dto.Cover:F0} mm";
        PreviewIsValid      = opt.Status != Domain.Enums.RebarSuggestionStatus.Failed;

        string linkNote = opt.ShearLinkDesign is { } lnk
            ? $"  Link: {lnk.LinkBarLabel} @ {lnk.LinkSpacingMm:F0} mm" +
              (lnk.InternalLinkCount > 0
                  ? $", X:{lnk.InternalLinksX} Y:{lnk.InternalLinksY} cross-ties"
                  : string.Empty)
            : string.Empty;
        string tagNote  = string.IsNullOrEmpty(opt.RecommendationTag) ? string.Empty : $"  [{opt.RecommendationTag}]";
        PreviewStatusText = $"Rank #{opt.Rank} — {opt.Reason}{linkNote}{tagNote}";
    }

    private void ClearPreviewCanvas()
    {
        PreviewRebars       = [];
        PreviewSectionLabel = string.Empty;
        PreviewRebarLabel   = string.Empty;
        PreviewCoverLabel   = string.Empty;
        PreviewIsValid      = false;
        PreviewStatusText   = "Run Auto, then select a candidate to preview its layout.";
    }

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
