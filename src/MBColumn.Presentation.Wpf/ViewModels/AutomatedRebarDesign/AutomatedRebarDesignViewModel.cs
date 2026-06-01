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
    private int    _selectedTabIndex     = 1; // start on Target tab; switches to Preview (0) on selection

    // ── Right panel: Target tab ───────────────────────────────────────────────
    private double _targetPmm = 0.90;
    private double _minPmm = 0.80;
    private double _maxPmm = 1.00;
    private double _targetRho = 2.0;
    private double _minPreferredRho = 1.0;
    private double _maxPreferredRho = 3.5;
    private RebarSuggestionPreset _preset = RebarSuggestionPreset.Balanced;
    private int _maxSuggestions = 10;
    private bool _showFailed = true;

    // ── Right panel: Search Space tab ─────────────────────────────────────────
    private bool _allowChangeDiameter = true;
    private bool _allowChangeCount = true;
    private bool _allowChangeSide = true;
    private bool _allowChangeTie = true;
    private bool _allowAllSidesEqual = true;
    private bool _allowSidesDifferent = true;

    // ── Right panel: Code/Detailing tab ───────────────────────────────────────
    private bool _checkMinRho = true;
    private bool _checkMaxRho = true;
    private bool _checkClearSpacing = true;
    private double _aggregateSize = 20.0;
    private bool _checkBarInsideLink = true;
    private bool _requireCornerBars = true;
    private bool _checkTieDiameter = true;
    private bool _checkTieSpacing = true;
    private bool _checkUnsupportedBar = true;
    private bool _warnInternalLinks = true;

    // Allowed bar/count toggles — driven by available bars + allowed sets
    private readonly ObservableCollection<AllowedBarToggleViewModel> _allowedBarToggles = new();
    private readonly ObservableCollection<AllowedCountToggleViewModel> _allowedCountToggles = new();

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
        InitialiseCountToggles();
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

    // ── Preview canvas (read-only section constants + per-selection state) ────
    public double PreviewSectionWidthMm    => _baseInput.BaseInput.Width;
    public double PreviewSectionHeightMm   => _baseInput.BaseInput.Height;
    public double PreviewCoverMm           => _baseInput.BaseInput.Cover;
    public double PreviewStirrupDiameterMm => _baseInput.BaseInput.LinkDiameterMm > 0 ? _baseInput.BaseInput.LinkDiameterMm : 10.0;

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

    public bool HasResults
    {
        get => _hasResults;
        private set => Set(ref _hasResults, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        private set => Set(ref _statusMessage, value);
    }

    public bool CanApply => SelectedOption is not null && !IsRunning;

    // Result of Apply — dialog host reads this
    public RebarSuggestionOption? AppliedOption
    {
        get => _appliedOption;
        private set => Set(ref _appliedOption, value);
    }

    // Dialog result flag
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
                SelectedTabIndex = 0; // jump to Section Preview tab
            }
            else
            {
                ClearPreviewCanvas();
            }
        }
    }

    public RebarSuggestionOption? SelectedOption => _selectedOption;

    // ── Right panel: Search Space toggles ─────────────────────────────────────
    public ObservableCollection<AllowedBarToggleViewModel>   AllowedBarToggles   => _allowedBarToggles;
    public ObservableCollection<AllowedCountToggleViewModel> AllowedCountToggles => _allowedCountToggles;

    // ── Right panel: Target ───────────────────────────────────────────────────
    public double TargetPmm         { get => _targetPmm;        set => Set(ref _targetPmm, value); }
    public double MinPmm            { get => _minPmm;           set => Set(ref _minPmm, value); }
    public double MaxPmm            { get => _maxPmm;           set => Set(ref _maxPmm, value); }
    public double TargetRho         { get => _targetRho;        set => Set(ref _targetRho, value); }
    public double MinPreferredRho   { get => _minPreferredRho;  set => Set(ref _minPreferredRho, value); }
    public double MaxPreferredRho   { get => _maxPreferredRho;  set => Set(ref _maxPreferredRho, value); }
    public RebarSuggestionPreset SelectedPreset { get => _preset; set => Set(ref _preset, value); }
    public int    MaxSuggestions    { get => _maxSuggestions;   set => Set(ref _maxSuggestions, value); }
    public bool   ShowFailed        { get => _showFailed;       set => Set(ref _showFailed, value); }

    public IReadOnlyList<PresetOption> PresetOptions { get; } =
    [
        new(RebarSuggestionPreset.Balanced,                         "Balanced"),
        new(RebarSuggestionPreset.MinimumSteel,                     "Minimum steel"),
        new(RebarSuggestionPreset.ClosestToTargetReinforcementRatio,"Closest to target ρ"),
        new(RebarSuggestionPreset.ClosestToTargetPmm,               "Closest to target PMM"),
        new(RebarSuggestionPreset.Conservative,                     "Conservative")
    ];

    // ── Right panel: Search Space ─────────────────────────────────────────────
    public bool AllowChangeDiameter   { get => _allowChangeDiameter;   set => Set(ref _allowChangeDiameter, value); }
    public bool AllowChangeCount      { get => _allowChangeCount;      set => Set(ref _allowChangeCount, value); }
    public bool AllowChangeSide       { get => _allowChangeSide;       set => Set(ref _allowChangeSide, value); }
    public bool AllowChangeTie        { get => _allowChangeTie;        set => Set(ref _allowChangeTie, value); }
    public bool AllowAllSidesEqual    { get => _allowAllSidesEqual;    set => Set(ref _allowAllSidesEqual, value); }
    public bool AllowSidesDifferent   { get => _allowSidesDifferent;   set => Set(ref _allowSidesDifferent, value); }

    // Shear link bar info (informational, not changed by auto-design)
    public string ShearLinkRangeText => _shearLinkBars.Count > 0
        ? $"Current stirrups: {_baseInput.BaseInput.LinkDiameterMm:F0} mm dia  |  Typical link range: {string.Join(", ", _shearLinkBars.Select(b => b.DisplayLabel ?? b.Name))}"
        : "No shear link data available.";

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

    // ── Design Summary (right-panel 4th tab) ──────────────────────────────────
    private string _summaryText = "Run Auto to see suggestions.";
    public string SummaryText
    {
        get => _summaryText;
        private set => Set(ref _summaryText, value);
    }

    private string _recommendedConfig = "—";
    public string RecommendedConfig
    {
        get => _recommendedConfig;
        private set => Set(ref _recommendedConfig, value);
    }

    private string _recommendedPmm = "—";
    public string RecommendedPmm
    {
        get => _recommendedPmm;
        private set => Set(ref _recommendedPmm, value);
    }

    private string _recommendedRho = "—";
    public string RecommendedRho
    {
        get => _recommendedRho;
        private set => Set(ref _recommendedRho, value);
    }

    private string _recommendedAs = "—";
    public string RecommendedAs
    {
        get => _recommendedAs;
        private set => Set(ref _recommendedAs, value);
    }

    private string _candidateCountsText = "—";
    public string CandidateCountsText
    {
        get => _candidateCountsText;
        private set => Set(ref _candidateCountsText, value);
    }

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

            if (allowedBars.Count == 0)
            {
                StatusMessage = "No bar sizes selected. Enable at least one bar size in the Search Space tab.";
                return;
            }

            var input = new RebarSuggestionInput
            {
                BaseInput   = _baseInput.BaseInput,
                Constraints = constraints,
                AllowedBars = allowedBars
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
        SelectedTabIndex = 0; // bring Section Preview tab into view
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
        foreach (var bar in bars)
        {
            _allowedBarToggles.Add(new AllowedBarToggleViewModel(bar, isEnabled: true));
        }
    }

    private void InitialiseCountToggles()
    {
        _allowedCountToggles.Clear();
        foreach (int count in new[] { 8, 12, 16, 20, 24, 28, 32 })
        {
            _allowedCountToggles.Add(new AllowedCountToggleViewModel(count, isEnabled: true));
        }
    }

    private void InitialiseBeforeAfterRows()
    {
        var dto = _baseInput.BaseInput;
        ParameterRows.Clear();

        double totalAs = dto.RebarCoordinates?.Sum(r => r.Area) ?? 0;
        double acMm2   = dto.Width * dto.Height;
        double rho     = acMm2 > 0 ? totalAs / acMm2 * 100 : 0;

        // Estimate nx/ny from current layout
        string nxBefore = "—", nyBefore = "—";
        if (dto.TopRebarSide is { } top && top.BarCount > 0)
        {
            nxBefore = $"{top.BarCount}";
            nyBefore = dto.LeftRebarSide is { } left
                ? $"{left.BarCount + 2}"   // intermediate + 2 corner bars
                : "—";
        }
        else if (dto.BarCount >= 4 && dto.RebarLayoutType == RebarLayoutType.AllSidesEqual)
        {
            int nx = (dto.BarCount - 4) / 4 + 2;
            nxBefore = $"{nx}";
            nyBefore = $"{nx}";
        }

        Add("Width b",               $"{dto.Width:F0}",   "mm",  frozen: true);
        Add("Depth h",               $"{dto.Height:F0}",  "mm",  frozen: true);
        Add("Concrete cover",        $"{dto.Cover:F0}",   "mm",  frozen: true);
        Add("Link diameter",         dto.LinkDiameterMm > 0 ? $"{dto.LinkDiameterMm:F0}" : "—", "mm", frozen: true);
        Add("Longitudinal bar dia.", dto.BarSize,         "—",   frozen: false);
        Add("No. of bars",           $"{dto.BarCount}",   "—",   frozen: false);
        Add("Bars along X face",     nxBefore,            "—",   frozen: false);
        Add("Bars along Y face",     nyBefore,            "—",   frozen: false);
        Add("Layout type",           "Perimeter",         "—",   frozen: true);
        Add("No. of layers",         "1",                 "—",   frozen: true);
        Add("Total steel area As",   $"{totalAs:F0}",     "mm²", frozen: false);
        Add("Steel ratio ρ",         $"{rho:F2}",         "%",   frozen: false);
        Add("fck",                   $"{dto.Fc:F0}",      "MPa", frozen: true);
        Add("fyk",                   $"{dto.Fy:F0}",      "MPa", frozen: true);
        Add("Tie spacing",           dto.LinkSpacingMm > 0 ? $"{dto.LinkSpacingMm:F0}" : "—", "mm", frozen: false);

        void Add(string param, string before, string unit, bool frozen)
        {
            var row = new BeforeAfterRowViewModel
            {
                Parameter = param,
                Before    = before,
                Unit      = unit,
                IsFrozen  = frozen
            };
            row.After = before;
            ParameterRows.Add(row);
        }
    }

    private void InitialiseCheckRows()
    {
        CheckRows.Clear();
        var r = _beforeResult;

        // Pull "Before" values from the last known calculation result
        string pmmBefore   = r is not null ? $"{r.Ratio:F2}"                               : "—";
        string vxBefore    = r?.GoverningShearResult is { } s ? $"{s.UtilisationX:F2}"     : "—";
        string vyBefore    = r?.GoverningShearResult is { } sv ? $"{sv.UtilisationY:F2}"   : "—";
        bool   pmmPass     = r is null || r.Ratio <= 1.0;
        bool   vxPass      = r?.GoverningShearResult is null || r.GoverningShearResult.UtilisationX <= 1.0;
        bool   vyPass      = r?.GoverningShearResult is null || r.GoverningShearResult.UtilisationY <= 1.0;

        // Compliance: parse from RebarCompliance.Checks
        string GetComplianceBefore(string checkName)
        {
            if (r?.RebarCompliance is null) return "—";
            var chk = r.RebarCompliance.Checks
                .FirstOrDefault(c => c.Description.Contains(checkName, StringComparison.OrdinalIgnoreCase));
            return chk is null ? "—" : (chk.Pass ? "OK" : "Fail");
        }

        bool GetCompliancePass(string checkName)
        {
            if (r?.RebarCompliance is null) return true;
            var chk = r.RebarCompliance.Checks
                .FirstOrDefault(c => c.Description.Contains(checkName, StringComparison.OrdinalIgnoreCase));
            return chk?.Pass ?? true;
        }

        void Add(string name, string before, bool pass)
        {
            CheckRows.Add(new CheckSummaryRowViewModel
            {
                CheckName    = name,
                Before       = before,
                IsPassBefore = pass
            });
        }

        Add("PMM utilization",         pmmBefore,                              pmmPass);
        Add("Vx utilization",          vxBefore,                               vxPass);
        Add("Vy utilization",          vyBefore,                               vyPass);
        Add("Minimum ρ",               GetComplianceBefore("Min"),             GetCompliancePass("Min"));
        Add("Maximum ρ",               GetComplianceBefore("Max"),             GetCompliancePass("Max"));
        Add("Clear spacing",           "—",                                    true);
        Add("Corner bars",             "OK",                                   true);
        Add("Bars inside link boundary", "OK",                                 true);
        Add("Tie compatibility",       GetComplianceBefore("link diameter"),   GetCompliancePass("link diameter"));
        Add("Unsupported bar distance", "—",                                   true);
        Add("Internal link warning",   "—",                                    true);
        Add("Overall",                 r is null ? "—" : (pmmPass && vxPass && vyPass ? "OK" : "Failed"),
                                       r is null || (pmmPass && vxPass && vyPass));
    }

    private void PopulateResults(RebarSuggestionResult result)
    {
        CandidateRows.Clear();
        foreach (var opt in result.Options)
        {
            string shearDisplay = opt.MaximumShearUtilization.HasValue
                ? $"{opt.MaximumShearUtilization.Value:F2}"
                : "—";

            string spacingStatus = opt.Warnings.Any(w =>
                    w.Type == RebarSuggestionWarningType.ClearSpacingFailed)
                ? "Failed"
                : opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingTight)
                    ? "Warn"
                    : "OK";

            CandidateRows.Add(new CandidateSuggestionRowViewModel
            {
                Rank                   = opt.Rank,
                Config                 = opt.ConfigurationName,
                TotalSteelAreaMm2      = opt.TotalSteelAreaMm2,
                ReinforcementRatioPercent = opt.ReinforcementRatio * 100,
                MaxPmmUtilization      = opt.MaximumPmmUtilization,
                MaxShearDisplay        = shearDisplay,
                SpacingStatus          = spacingStatus,
                Score                  = opt.Score,
                Status                 = opt.Status,
                Reason                 = opt.Reason,
                Option                 = opt
            });
        }

        // Auto-select best
        var best = CandidateRows.FirstOrDefault();
        if (best is not null) SelectedCandidate = best;

        // Update Design Summary tab
        UpdateDesignSummary(result);

        StatusMessage = result.SummaryMessage;
        HasResults    = true;
    }

    private void UpdateDesignSummary(RebarSuggestionResult result)
    {
        CandidateCountsText = $"{result.TotalCandidateCount} candidates — " +
                              $"{result.PassedCandidateCount} OK, " +
                              $"{result.WarningCandidateCount} warnings, " +
                              $"{result.FailedCandidateCount} failed";

        var rec = result.RecommendedOption;
        if (rec is not null)
        {
            RecommendedConfig = rec.ConfigurationName;
            RecommendedPmm    = $"{rec.MaximumPmmUtilization:F2}";
            RecommendedRho    = $"{rec.ReinforcementRatio * 100:F2}%";
            RecommendedAs     = $"{rec.TotalSteelAreaMm2:F0} mm²";
            SummaryText       = rec.Reason;
        }
        else
        {
            RecommendedConfig = "None";
            RecommendedPmm    = "—";
            RecommendedRho    = "—";
            RecommendedAs     = "—";
            SummaryText       = "No valid candidate found. Try allowing larger bar sizes or more bars.";
        }
    }

    private void UpdateAfterColumns(RebarSuggestionOption opt)
    {
        // Map option values to After column in ParameterRows
        SetAfter("Longitudinal bar dia.",  opt.BarSizeName);
        SetAfter("No. of bars",            $"{opt.TotalBarCount}");
        SetAfter("Bars along X face",      $"{opt.BarsOnTopBottomFace}");
        SetAfter("Bars along Y face",      $"{opt.BarsOnLeftRightFace}");
        SetAfter("Total steel area As",    $"{opt.TotalSteelAreaMm2:F0}");
        SetAfter("Steel ratio ρ",          $"{opt.ReinforcementRatio * 100:F2}");

        void SetAfter(string param, string value)
        {
            var row = ParameterRows.FirstOrDefault(r => r.Parameter == param);
            if (row is not null) row.After = value;
        }

        // Update Check Summary
        UpdateCheckRow("PMM utilization", $"{opt.MaximumPmmUtilization:F2}",
            opt.MaximumPmmUtilization <= _maxPmm);
        UpdateCheckRow("Vx utilization", opt.VxUtilization.HasValue ? $"{opt.VxUtilization:F2}" : "—",
            opt.VxUtilization is null or <= 1.0);
        UpdateCheckRow("Vy utilization", opt.VyUtilization.HasValue ? $"{opt.VyUtilization:F2}" : "—",
            opt.VyUtilization is null or <= 1.0);

        bool hasRhoLow  = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ReinforcementRatioTooLow);
        bool hasRhoHigh = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ReinforcementRatioTooHigh);
        UpdateCheckRow("Minimum ρ", hasRhoLow ? "Failed" : "OK", !hasRhoLow);
        UpdateCheckRow("Maximum ρ", hasRhoHigh ? "Failed" : "OK", !hasRhoHigh);

        bool spacingFail = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingFailed);
        bool spacingWarn = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.ClearSpacingTight);
        UpdateCheckRow("Clear spacing", spacingFail ? "Failed" : spacingWarn ? "Warn" : "OK", !spacingFail);

        bool missingCorner = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.MissingCornerBar);
        UpdateCheckRow("Corner bars", missingCorner ? "Failed" : "OK", !missingCorner);

        bool outsideLink = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.BarOutsideLinkBoundary);
        UpdateCheckRow("Bars inside link boundary", outsideLink ? "Failed" : "OK", !outsideLink);

        bool tieIssue = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.TieCompatibilityIssue);
        UpdateCheckRow("Tie compatibility", tieIssue ? "Warning" : "OK", true);

        bool unsupported = opt.Warnings.Any(w => w.Type == RebarSuggestionWarningType.InternalLinksRequired);
        UpdateCheckRow("Unsupported bar distance", unsupported ? "Warning" : "OK", true);
        UpdateCheckRow("Internal link warning", unsupported ? "Yes" : "No", true);

        bool overall = opt.Status != RebarSuggestionStatus.Failed;
        UpdateCheckRow("Overall", overall ? (opt.Status == RebarSuggestionStatus.Warning ? "Acceptable" : "OK") : "Failed", overall);

        void UpdateCheckRow(string name, string after, bool pass)
        {
            var row = CheckRows.FirstOrDefault(r => r.CheckName == name);
            if (row is null) return;
            row.After      = after;
            row.IsPassAfter = pass;
            row.Status     = pass ? "OK" : "Failed";
            row.Condition  = after == row.Before ? "Unchanged" : "Changed";
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
        PreviewStatusText   = $"Rank #{opt.Rank} — {opt.Reason}";
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
        var allowedBarNames = _allowedBarToggles
            .Where(t => t.IsEnabled)
            .Select(t => t.Bar.Name)
            .ToList();

        var allowedCounts = _allowedCountToggles
            .Where(t => t.IsEnabled)
            .Select(t => t.Count)
            .ToList();

        return new RebarSuggestionConstraintSet
        {
            TargetPmmUtilization               = _targetPmm,
            MinimumAcceptablePmmUtilization    = _minPmm,
            MaximumAcceptablePmmUtilization    = _maxPmm,
            TargetReinforcementRatio           = _targetRho / 100.0,
            MinimumPreferredReinforcementRatio  = _minPreferredRho / 100.0,
            MaximumPreferredReinforcementRatio  = _maxPreferredRho / 100.0,
            AllowedBarSizeNames                = allowedBarNames,
            AllowedBarCounts                   = allowedCounts,
            AllowChangeBarDiameter             = _allowChangeDiameter,
            AllowChangeBarCount                = _allowChangeCount,
            AllowChangeSideDistribution        = _allowChangeSide,
            AllowChangeTieSpacing              = _allowChangeTie,
            AllowAllSidesEqualLayout           = _allowAllSidesEqual,
            AllowSidesDifferentLayout          = _allowSidesDifferent,
            RequireSymmetricLayout             = true,
            RequireCornerBars                  = _requireCornerBars,
            CheckClearSpacing                  = _checkClearSpacing,
            CheckReinforcementRatio            = _checkMinRho || _checkMaxRho,
            CheckTieCompatibility              = _checkTieDiameter || _checkTieSpacing,
            AggregateSizeMm                    = _aggregateSize,
            Preset                             = _preset,
            ShowFailedCandidates               = _showFailed,
            MaximumSuggestionsToShow           = _maxSuggestions
        };
    }
}

// ── Support types ─────────────────────────────────────────────────────────────

public sealed class AllowedBarToggleViewModel(RebarDefinition bar, bool isEnabled) : ViewModelBase
{
    private bool _isEnabled = isEnabled;
    public RebarDefinition Bar { get; } = bar;
    public string Label => Bar.DisplayLabel ?? Bar.Name;
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
}

public sealed class AllowedCountToggleViewModel(int count, bool isEnabled) : ViewModelBase
{
    private bool _isEnabled = isEnabled;
    public int  Count     { get; } = count;
    public string Label   => Count.ToString();
    public bool IsEnabled { get => _isEnabled; set => Set(ref _isEnabled, value); }
}

public sealed record PresetOption(RebarSuggestionPreset Preset, string DisplayName);
