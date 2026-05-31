using MBColumn.Application.Services;
using MBColumn.Presentation.Wpf.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class ColumnItemViewModel : ExplorerNodeViewModel
{
    private readonly IProjectService projectService;
    private SectionStatus status;

    public ColumnItemViewModel(
        ColumnRecord record,
        Action<ExplorerNodeViewModel> onSelect,
        Action<ColumnItemViewModel> onDuplicate,
        Action<ColumnItemViewModel> onDelete,
        IProjectService projectService)
    {
        Id = record.Id;
        GroupId = record.GroupId;
        Name = record.Name;
        EditName = record.Name;
        this.projectService = projectService;
        status = SectionStatus.NotCalculated;
        SelectCommand = new RelayCommand(() => onSelect(this));
        BeginRenameCommand = new RelayCommand(() => { EditName = Name; IsRenaming = true; });
        DuplicateCommand = new RelayCommand(() => onDuplicate(this));
        DeleteCommand = new RelayCommand(() => onDelete(this));
    }

    public int? GroupId { get; set; }

    public ObservableCollection<GroupActionViewModel> MoveToGroupOptions { get; } = new();

    public SectionStatus Status
    {
        get => status;
        set
        {
            if (status == value)
            {
                if (value == SectionStatus.Calculated)
                {
                    Raise(nameof(StatusText));
                    Raise(nameof(OverallStatus));
                }
                return;
            }
            status = value;
            Raise();
            Raise(nameof(StatusText));
            Raise(nameof(OverallStatus));
        }
    }

    public string StatusText
    {
        get
        {
            if (Status == SectionStatus.Calculated)
            {
                var result = projectService.LoadColumnResult(Id);
                if (result is not null)
                {
                    string overall = "PASS";
                    if (result.Status != CapacityStatus.Pass) overall = "FAIL";
                    else if (result.GoverningShearResult?.HasDemand == true && result.GoverningShearResult.GoverningStatus != CapacityStatus.Pass) overall = "FAIL";
                    else if (result.RebarCompliance != null && !result.RebarCompliance.AllPass) overall = "PASS WITH WARNING";
                    return $"Calculated - {overall}";
                }
                return "Calculated";
            }

            return Status switch
            {
                SectionStatus.Outdated => "Outdated",
                SectionStatus.Error => "Error",
                _ => "Not calculated"
            };
        }
    }

    public string OverallStatus
    {
        get
        {
            if (Status != SectionStatus.Calculated) return "None";
            var result = projectService.LoadColumnResult(Id);
            if (result is null) return "None";
            if (result.Status != CapacityStatus.Pass) return "FAIL";
            if (result.GoverningShearResult?.HasDemand == true && result.GoverningShearResult.GoverningStatus != CapacityStatus.Pass) return "FAIL";
            if (result.RebarCompliance != null && !result.RebarCompliance.AllPass) return "WARNING";
            return "PASS";
        }
    }

    public ICommand DuplicateCommand { get; }
}
