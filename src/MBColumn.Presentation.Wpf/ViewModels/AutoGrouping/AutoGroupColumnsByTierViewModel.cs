using System.Collections.ObjectModel;
using System.Windows.Input;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;
using MBColumn.Application.Services.Etabs;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;

namespace MBColumn.Presentation.Wpf.ViewModels.AutoGrouping;

public sealed class AutoGroupColumnsByTierViewModel : ViewModelBase
{
    private readonly AutoGroupColumnsDialogInput input;
    private readonly ColumnAutoGroupingService groupingService;
    private AutoGroupingTier? selectedTier;
    private AutoGroupingResult? previewResult;
    private int currentStep = 1;
    private string statusText;

    public AutoGroupColumnsByTierViewModel(
        AutoGroupColumnsDialogInput input,
        ColumnAutoGroupingService? groupingService = null)
    {
        this.input = input;
        this.groupingService = groupingService ?? new ColumnAutoGroupingService();

        Tiers = [];
        TierSummaryRows = [];
        PreviewRows = [];
        ColumnPreviewGroups = [];
        ValidationMessages = [];
        StoryNames = input.Stories
            .OrderBy(s => s.SortIndex)
            .Select(s => s.Name)
            .ToList();

        addTierCommand = new RelayCommand(AddTier);
        removeTierCommand = new RelayCommand(RemoveSelectedTier, () => SelectedTier is not null);
        previewCommand = new RelayCommand(PreviewGrouping, CanBuildGrouping);
        backCommand = new RelayCommand(GoBack, () => CurrentStep == 2);
        applyCommand = new RelayCommand(ApplyAutoGrouping, () => CurrentStep == 2 && previewResult is { HasErrors: false });
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));

        statusText = WpfResourceText.Get("AutoGrouping_Status_Ready");
        AddTier();
    }

    private readonly RelayCommand addTierCommand;
    private readonly RelayCommand removeTierCommand;
    private readonly RelayCommand previewCommand;
    private readonly RelayCommand backCommand;
    private readonly RelayCommand applyCommand;
    private readonly RelayCommand cancelCommand;

    public event EventHandler<bool>? RequestClose;

    public ObservableCollection<AutoGroupingTier> Tiers { get; }
    public IReadOnlyList<string> StoryNames { get; }
    public ObservableCollection<AutoGroupingTierSummaryRow> TierSummaryRows { get; }
    public ObservableCollection<AutoGroupingPreviewRow> PreviewRows { get; }
    public ObservableCollection<AutoGroupingColumnPreviewGroupViewModel> ColumnPreviewGroups { get; }
    public ObservableCollection<AutoGroupingValidationMessageViewModel> ValidationMessages { get; }

    public AutoGroupingResult? AppliedResult { get; private set; }

    public AutoGroupingTier? SelectedTier
    {
        get => selectedTier;
        set
        {
            if (!Set(ref selectedTier, value)) return;
            removeTierCommand.RaiseCanExecuteChanged();
        }
    }

    public string StatusText
    {
        get => statusText;
        private set => Set(ref statusText, value);
    }

    public int CurrentStep
    {
        get => currentStep;
        private set
        {
            if (!Set(ref currentStep, value)) return;
            Raise(nameof(IsTierDefinitionsStep));
            Raise(nameof(IsGroupingPreviewStep));
            Raise(nameof(CanGoBack));
            RaiseCommandStates();
        }
    }

    public bool IsTierDefinitionsStep => CurrentStep == 1;
    public bool IsGroupingPreviewStep => CurrentStep == 2;
    public bool CanGoBack => CurrentStep == 2;

    public ICommand AddTierCommand => addTierCommand;
    public ICommand RemoveTierCommand => removeTierCommand;
    public ICommand PreviewCommand => previewCommand;
    public ICommand BackCommand => backCommand;
    public ICommand ApplyCommand => applyCommand;
    public ICommand CancelCommand => cancelCommand;

    public int PreviewRowCount => PreviewRows.Count;
    public bool HasTierSummaryRows => TierSummaryRows.Count > 0;
    public bool HasPreviewRows => PreviewRows.Count > 0;
    public bool HasColumnPreviewGroups => ColumnPreviewGroups.Count > 0;
    public bool HasValidationMessages => ValidationMessages.Count > 0;

    private void AddTier()
    {
        var tierNumber = Tiers.Count + 1;
        var tier = new AutoGroupingTier
        {
            TierName = WpfResourceText.Format("AutoGrouping_DefaultTierNameFormat", tierNumber),
            FromStory = StoryNames.FirstOrDefault() ?? string.Empty,
            ToStory = StoryNames.LastOrDefault() ?? string.Empty,
            LabelFilter = string.Empty
        };

        Tiers.Add(tier);
        SelectedTier = tier;
        InvalidatePreview();
        RaiseCommandStates();
    }

    private void RemoveSelectedTier()
    {
        if (SelectedTier is null)
            return;

        var index = Tiers.IndexOf(SelectedTier);
        Tiers.Remove(SelectedTier);
        SelectedTier = Tiers.Count == 0
            ? null
            : Tiers[Math.Clamp(index, 0, Tiers.Count - 1)];
        InvalidatePreview();
        RaiseCommandStates();
    }

    private void PreviewGrouping()
    {
        var result = BuildCurrentResult();
        LoadResult(result);
        previewResult = result;
        CurrentStep = 2;

        StatusText = result.HasErrors
            ? WpfResourceText.Get("AutoGrouping_Status_PreviewHasErrors")
            : WpfResourceText.Format("AutoGrouping_Status_PreviewCompleteFormat", ColumnPreviewGroups.Count);
    }

    private void ApplyAutoGrouping()
    {
        var result = previewResult ?? BuildCurrentResult();
        if (!ReferenceEquals(result, previewResult))
            LoadResult(result);

        if (result.HasErrors)
        {
            StatusText = WpfResourceText.Get("AutoGrouping_Status_ApplyBlocked");
            return;
        }

        AppliedResult = result;
        RequestClose?.Invoke(this, true);
    }

    private void GoBack()
    {
        CurrentStep = 1;
        StatusText = WpfResourceText.Get("AutoGrouping_Status_Ready");
    }

    private AutoGroupingResult BuildCurrentResult()
        => groupingService.Build(new ColumnAutoGroupingRequest(
            input.Columns,
            input.Stories,
            Tiers.Select(t => t.Clone()).ToList(),
            input.ReservedSectionNames));

    private void LoadResult(AutoGroupingResult result)
    {
        TierSummaryRows.Clear();
        foreach (var row in result.TierSummaryRows)
            TierSummaryRows.Add(row);

        PreviewRows.Clear();
        foreach (var row in result.PreviewRows)
            PreviewRows.Add(row);

        ColumnPreviewGroups.Clear();
        foreach (var group in result.PreviewRows
                     .GroupBy(row => row.ColumnLabel, StringComparer.OrdinalIgnoreCase)
                     .OrderBy(group => group.Key, StringComparer.OrdinalIgnoreCase))
        {
            ColumnPreviewGroups.Add(new AutoGroupingColumnPreviewGroupViewModel(group.Key, group));
        }

        ValidationMessages.Clear();
        foreach (var message in result.ValidationMessages)
            ValidationMessages.Add(new AutoGroupingValidationMessageViewModel(message));

        Raise(nameof(PreviewRowCount));
        Raise(nameof(HasTierSummaryRows));
        Raise(nameof(HasPreviewRows));
        Raise(nameof(HasColumnPreviewGroups));
        Raise(nameof(HasValidationMessages));
        RaiseCommandStates();
    }

    private void InvalidatePreview()
    {
        previewResult = null;
        if (CurrentStep == 2)
            CurrentStep = 1;
        applyCommand.RaiseCanExecuteChanged();
    }

    private bool CanBuildGrouping()
        => input.Columns.Count > 0 && StoryNames.Count > 0 && Tiers.Count > 0;

    private void RaiseCommandStates()
    {
        removeTierCommand.RaiseCanExecuteChanged();
        previewCommand.RaiseCanExecuteChanged();
        backCommand.RaiseCanExecuteChanged();
        applyCommand.RaiseCanExecuteChanged();
    }
}

public sealed class AutoGroupingColumnPreviewGroupViewModel
{
    public AutoGroupingColumnPreviewGroupViewModel(
        string columnLabel,
        IEnumerable<AutoGroupingPreviewRow> rows)
    {
        ColumnLabel = string.IsNullOrWhiteSpace(columnLabel) ? "(No label)" : columnLabel;
        Items = new ObservableCollection<AutoGroupingPreviewRow>(
            rows.OrderBy(row => row.TierName, StringComparer.OrdinalIgnoreCase)
                .ThenBy(row => row.MbColumnSectionName, StringComparer.OrdinalIgnoreCase));
    }

    public string ColumnLabel { get; }
    public ObservableCollection<AutoGroupingPreviewRow> Items { get; }
    public int SectionCount => Items.Count;
    public int TotalObjects => Items.Sum(item => item.Count);
    public string TiersDisplayText => string.Join(", ",
        Items.Select(item => item.TierName)
            .Where(tier => !string.IsNullOrWhiteSpace(tier))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(tier => tier, StringComparer.OrdinalIgnoreCase));
}
