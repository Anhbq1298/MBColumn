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
        ValidationMessages = [];
        StoryNames = input.Stories
            .OrderBy(s => s.SortIndex)
            .Select(s => s.Name)
            .ToList();

        addTierCommand = new RelayCommand(AddTier);
        removeTierCommand = new RelayCommand(RemoveSelectedTier, () => SelectedTier is not null);
        previewCommand = new RelayCommand(PreviewGrouping, CanBuildGrouping);
        applyCommand = new RelayCommand(ApplyAutoGrouping, CanBuildGrouping);
        cancelCommand = new RelayCommand(() => RequestClose?.Invoke(this, false));

        statusText = WpfResourceText.Get("AutoGrouping_Status_Ready");
        AddTier();
    }

    private readonly RelayCommand addTierCommand;
    private readonly RelayCommand removeTierCommand;
    private readonly RelayCommand previewCommand;
    private readonly RelayCommand applyCommand;
    private readonly RelayCommand cancelCommand;

    public event EventHandler<bool>? RequestClose;

    public ObservableCollection<AutoGroupingTier> Tiers { get; }
    public IReadOnlyList<string> StoryNames { get; }
    public ObservableCollection<AutoGroupingTierSummaryRow> TierSummaryRows { get; }
    public ObservableCollection<AutoGroupingPreviewRow> PreviewRows { get; }
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

    public ICommand AddTierCommand => addTierCommand;
    public ICommand RemoveTierCommand => removeTierCommand;
    public ICommand PreviewCommand => previewCommand;
    public ICommand ApplyCommand => applyCommand;
    public ICommand CancelCommand => cancelCommand;

    public int PreviewRowCount => PreviewRows.Count;
    public bool HasTierSummaryRows => TierSummaryRows.Count > 0;
    public bool HasPreviewRows => PreviewRows.Count > 0;
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
        RaiseCommandStates();
    }

    private void PreviewGrouping()
    {
        var result = BuildCurrentResult();
        LoadResult(result);

        StatusText = result.HasErrors
            ? WpfResourceText.Get("AutoGrouping_Status_PreviewHasErrors")
            : WpfResourceText.Format("AutoGrouping_Status_PreviewCompleteFormat", result.PreviewRows.Count);
    }

    private void ApplyAutoGrouping()
    {
        var result = BuildCurrentResult();
        LoadResult(result);

        if (result.HasErrors)
        {
            StatusText = WpfResourceText.Get("AutoGrouping_Status_ApplyBlocked");
            return;
        }

        AppliedResult = result;
        RequestClose?.Invoke(this, true);
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

        ValidationMessages.Clear();
        foreach (var message in result.ValidationMessages)
            ValidationMessages.Add(new AutoGroupingValidationMessageViewModel(message));

        Raise(nameof(PreviewRowCount));
        Raise(nameof(HasTierSummaryRows));
        Raise(nameof(HasPreviewRows));
        Raise(nameof(HasValidationMessages));
    }

    private bool CanBuildGrouping()
        => input.Columns.Count > 0 && StoryNames.Count > 0 && Tiers.Count > 0;

    private void RaiseCommandStates()
    {
        removeTierCommand.RaiseCanExecuteChanged();
        previewCommand.RaiseCanExecuteChanged();
        applyCommand.RaiseCanExecuteChanged();
    }
}
