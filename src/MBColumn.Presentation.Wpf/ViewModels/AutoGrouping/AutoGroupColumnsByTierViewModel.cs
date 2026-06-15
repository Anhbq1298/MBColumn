using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    private readonly List<StoryAssignmentItem> allStoryItems;
    private TierDefinitionItem? selectedTier;
    private AutoGroupingResult? previewResult;
    private int currentStep = 1;
    private string statusText;
    private int nextTierNumber = 1;

    public AutoGroupColumnsByTierViewModel(
        AutoGroupColumnsDialogInput input,
        ColumnAutoGroupingService? groupingService = null)
    {
        this.input = input;
        this.groupingService = groupingService ?? new ColumnAutoGroupingService();

        Tiers = [];
        AvailableStories = [];
        TierSummaryRows = [];
        PreviewRows = [];
        ColumnPreviewGroups = [];
        ValidationMessages = [];
        StoryNames = input.Stories
            .OrderBy(s => s.SortIndex)
            .Select(s => s.Name)
            .ToList();
        allStoryItems = input.Stories
            .OrderBy(s => s.SortIndex)
            .Select(s => new StoryAssignmentItem(s.Name, s.SortIndex))
            .ToList();
        foreach (var story in allStoryItems)
            AvailableStories.Add(story);

        addTierCommand = new RelayCommand(AddTier);
        removeTierCommand = new RelayCommand(RemoveSelectedTier, () => SelectedTier is not null);
        assignSelectedStoriesCommand = new RelayCommand(AssignSelectedStoriesToTier, () => SelectedTier is not null && AvailableStories.Count > 0);
        removeStoryFromTierCommand = new RelayCommand<StoryAssignmentItem>(RemoveStoryFromTier, story => story is not null);
        previewCommand = new RelayCommand(PreviewGrouping, CanBuildGrouping);
        backCommand = new RelayCommand(GoBack, () => CurrentStep == 2);
        applyCommand = new RelayCommand(ApplyAutoGrouping, () => CurrentStep == 2 && previewResult is { HasErrors: false });
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));

        statusText = WpfResourceText.Get("AutoGrouping_Status_Ready");
        AddTier();
    }

    private readonly RelayCommand addTierCommand;
    private readonly RelayCommand removeTierCommand;
    private readonly RelayCommand assignSelectedStoriesCommand;
    private readonly RelayCommand<StoryAssignmentItem> removeStoryFromTierCommand;
    private readonly RelayCommand previewCommand;
    private readonly RelayCommand backCommand;
    private readonly RelayCommand applyCommand;
    private readonly RelayCommand cancelCommand;

    public event EventHandler<bool>? RequestClose;

    public ObservableCollection<TierDefinitionItem> Tiers { get; }
    public ObservableCollection<StoryAssignmentItem> AvailableStories { get; }
    public IReadOnlyList<string> StoryNames { get; }
    public ObservableCollection<AutoGroupingTierSummaryRow> TierSummaryRows { get; }
    public ObservableCollection<AutoGroupingPreviewRow> PreviewRows { get; }
    public ObservableCollection<AutoGroupingColumnPreviewGroupViewModel> ColumnPreviewGroups { get; }
    public ObservableCollection<AutoGroupingValidationMessageViewModel> ValidationMessages { get; }

    public AutoGroupingResult? AppliedResult { get; private set; }

    public TierDefinitionItem? SelectedTier
    {
        get => selectedTier;
        set
        {
            if (!Set(ref selectedTier, value)) return;
            foreach (var tier in Tiers)
                tier.IsSelected = ReferenceEquals(tier, selectedTier);
            removeTierCommand.RaiseCanExecuteChanged();
            assignSelectedStoriesCommand.RaiseCanExecuteChanged();
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
    public ICommand AssignSelectedStoriesCommand => assignSelectedStoriesCommand;
    public ICommand RemoveStoryFromTierCommand => removeStoryFromTierCommand;
    public ICommand PreviewCommand => previewCommand;
    public ICommand BackCommand => backCommand;
    public ICommand ApplyCommand => applyCommand;
    public ICommand CancelCommand => cancelCommand;

    public int PreviewRowCount => PreviewRows.Count;
    public bool HasAvailableStories => AvailableStories.Count > 0;
    public bool HasTierSummaryRows => TierSummaryRows.Count > 0;
    public bool HasPreviewRows => PreviewRows.Count > 0;
    public bool HasColumnPreviewGroups => ColumnPreviewGroups.Count > 0;
    public bool HasValidationMessages => ValidationMessages.Count > 0;

    private void AddTier()
    {
        var tierNumber = nextTierNumber++;
        var tier = new TierDefinitionItem
        {
            TierId = Guid.NewGuid().ToString("N"),
            TierName = WpfResourceText.Format("AutoGrouping_DefaultTierNameFormat", tierNumber),
            LabelFilter = string.Empty
        };
        tier.AssignedStories.CollectionChanged += OnTierAssignedStoriesChanged;

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
        foreach (var story in SelectedTier.AssignedStories.ToList())
            UnassignStory(story);
        SelectedTier.AssignedStories.CollectionChanged -= OnTierAssignedStoriesChanged;
        Tiers.Remove(SelectedTier);
        SelectedTier = Tiers.Count == 0
            ? null
            : Tiers[Math.Clamp(index, 0, Tiers.Count - 1)];
        InvalidatePreview();
        RaiseCommandStates();
    }

    private void AssignSelectedStoriesToTier()
    {
        if (SelectedTier is null)
        {
            StatusText = WpfResourceText.Get("AutoGrouping_Status_SelectTierFirst");
            return;
        }

        var selectedStories = AvailableStories
            .Where(story => story.IsSelected)
            .OrderBy(story => story.SortIndex)
            .ToList();
        if (selectedStories.Count == 0)
        {
            StatusText = WpfResourceText.Get("AutoGrouping_Status_SelectStoriesFirst");
            return;
        }

        foreach (var story in selectedStories)
        {
            story.IsSelected = false;
            AvailableStories.Remove(story);
            story.AssignedTierId = SelectedTier.TierId;
            InsertStorySorted(SelectedTier.AssignedStories, story);
        }

        RefreshAssignmentState();
        InvalidatePreview();
        StatusText = WpfResourceText.Format("AutoGrouping_Status_AssignedStoriesFormat", selectedStories.Count, SelectedTier.TierName);
    }

    private void RemoveStoryFromTier(StoryAssignmentItem story)
    {
        UnassignStory(story);
        RefreshAssignmentState();
        InvalidatePreview();
    }

    private void UnassignStory(StoryAssignmentItem story)
    {
        var tier = Tiers.FirstOrDefault(t => string.Equals(t.TierId, story.AssignedTierId, StringComparison.Ordinal));
        tier?.AssignedStories.Remove(story);
        story.AssignedTierId = string.Empty;
        story.IsSelected = false;
        if (!AvailableStories.Contains(story))
            InsertStorySorted(AvailableStories, story);
    }

    private void PreviewGrouping()
    {
        var result = BuildCurrentResult();
        LoadResult(result);
        if (result.HasErrors)
        {
            previewResult = null;
            CurrentStep = 1;
            StatusText = BuildFirstErrorStatus(result);
            return;
        }

        previewResult = result;
        CurrentStep = 2;
        StatusText = WpfResourceText.Format("AutoGrouping_Status_PreviewCompleteFormat", ColumnPreviewGroups.Count);
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
    {
        var result = groupingService.Build(new ColumnAutoGroupingRequest(
            input.Columns,
            input.Stories,
            BuildDerivedTiers(),
            input.ReservedSectionNames));

        AddAssignmentBoardWarnings(result);
        return result;
    }

    private List<AutoGroupingTier> BuildDerivedTiers()
    {
        RefreshAssignmentState();
        return Tiers
            .Select(t => new AutoGroupingTier
            {
                TierName = t.TierName,
                FromStory = t.DerivedTopStory,
                ToStory = t.DerivedBottomStory,
                LabelFilter = t.LabelFilter
            })
            .ToList();
    }

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

    private static string BuildFirstErrorStatus(AutoGroupingResult result)
    {
        var firstError = result.ValidationMessages.FirstOrDefault(message =>
            message.Severity == AutoGroupingValidationSeverity.Error);
        if (firstError is null)
            return WpfResourceText.Get("AutoGrouping_Status_PreviewHasErrors");

        return WpfResourceText.Format(firstError.MessageKey, firstError.MessageArguments);
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

    public void NotifyAvailableStorySelectionChanged()
        => assignSelectedStoriesCommand.RaiseCanExecuteChanged();

    private void RaiseCommandStates()
    {
        removeTierCommand.RaiseCanExecuteChanged();
        assignSelectedStoriesCommand.RaiseCanExecuteChanged();
        removeStoryFromTierCommand.RaiseCanExecuteChanged();
        previewCommand.RaiseCanExecuteChanged();
        backCommand.RaiseCanExecuteChanged();
        applyCommand.RaiseCanExecuteChanged();
    }

    private void OnTierAssignedStoriesChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        RefreshAssignmentState();
        Raise(nameof(HasAvailableStories));
    }

    private void RefreshAssignmentState()
    {
        foreach (var tier in Tiers)
        {
            var assigned = tier.AssignedStories
                .OrderBy(story => story.SortIndex)
                .ToList();

            tier.DerivedTopStory = assigned.FirstOrDefault()?.StoryName ?? string.Empty;
            tier.DerivedBottomStory = assigned.LastOrDefault()?.StoryName ?? string.Empty;
            tier.WarningMessages.Clear();
            if (assigned.Count > 1 && HasStoryGap(assigned))
                tier.WarningMessages.Add(WpfResourceText.Get("AutoGrouping_Warning_NonContinuousTierStories"));
        }

        Raise(nameof(HasAvailableStories));
        RaiseCommandStates();
    }

    private void AddAssignmentBoardWarnings(AutoGroupingResult result)
    {
        if (AvailableStories.Count > 0)
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningUnassignedBoardStories,
                string.Join(", ", AvailableStories.Select(story => story.StoryName))));
        }

        if (AvailableStories.Any(story => string.Equals(story.StoryName, "BASE", StringComparison.OrdinalIgnoreCase)))
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningBaseUnassigned));
        }

        foreach (var tier in Tiers.Where(tier => tier.AssignedStories.Count > 1 && HasStoryGap(tier.AssignedStories.OrderBy(story => story.SortIndex).ToList())))
        {
            result.ValidationMessages.Add(new AutoGroupingValidationMessage(
                AutoGroupingValidationSeverity.Warning,
                AutoGroupingResourceKeys.WarningNonContinuousTierStories,
                tier.TierName));
        }
    }

    private static bool HasStoryGap(IReadOnlyList<StoryAssignmentItem> stories)
    {
        for (var i = 1; i < stories.Count; i++)
        {
            if (stories[i].SortIndex != stories[i - 1].SortIndex + 1)
                return true;
        }

        return false;
    }

    private static void InsertStorySorted(ObservableCollection<StoryAssignmentItem> target, StoryAssignmentItem story)
    {
        var index = 0;
        while (index < target.Count && target[index].SortIndex < story.SortIndex)
            index++;
        target.Insert(index, story);
    }
}

public sealed class StoryAssignmentItem : ViewModelBase
{
    private bool isSelected;
    private string assignedTierId = string.Empty;

    public StoryAssignmentItem(string storyName, int sortIndex)
    {
        StoryName = storyName;
        SortIndex = sortIndex;
    }

    public string StoryName { get; }
    public int SortIndex { get; }

    public bool IsSelected
    {
        get => isSelected;
        set => Set(ref isSelected, value);
    }

    public string AssignedTierId
    {
        get => assignedTierId;
        set => Set(ref assignedTierId, value);
    }
}

public sealed class TierDefinitionItem : ViewModelBase
{
    private string tierId = string.Empty;
    private string tierName = string.Empty;
    private string labelFilter = string.Empty;
    private string derivedTopStory = string.Empty;
    private string derivedBottomStory = string.Empty;
    private bool isSelected;

    public string TierId
    {
        get => tierId;
        set => Set(ref tierId, value);
    }

    public string TierName
    {
        get => tierName;
        set => Set(ref tierName, value);
    }

    public string LabelFilter
    {
        get => labelFilter;
        set => Set(ref labelFilter, value);
    }

    public ObservableCollection<StoryAssignmentItem> AssignedStories { get; } = [];
    public ObservableCollection<string> WarningMessages { get; } = [];

    public string DerivedTopStory
    {
        get => derivedTopStory;
        set => Set(ref derivedTopStory, value);
    }

    public string DerivedBottomStory
    {
        get => derivedBottomStory;
        set => Set(ref derivedBottomStory, value);
    }

    public bool IsSelected
    {
        get => isSelected;
        set => Set(ref isSelected, value);
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
