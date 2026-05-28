using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class LoadCaseViewModel : ViewModelBase
{
    private string id;
    private string name;
    private double pu;
    private double mux;
    private double muy;
    private double vux;
    private double vuy;
    private bool isActive;
    private bool hasValidationError;
    private string originalLoadCaseName = "";
    private string sourceObjectName = "";
    private string sourceObjectLabel = "";
    private string story = "";
    private string station = "";
    private string source = "Manual";

    public LoadCaseViewModel(string id, string name, double pu, double mux, double muy, bool isActive = true)
    {
        this.id = id;
        this.name = name;
        this.pu = pu;
        this.mux = mux;
        this.muy = muy;
        this.isActive = isActive;
    }

    public string Id { get => id; set => Set(ref id, value); }
    public string Name { get => name; set => Set(ref name, value); }
    public double Pu { get => pu; set => Set(ref pu, value); }
    public double Mux { get => mux; set => Set(ref mux, value); }
    public double Muy { get => muy; set => Set(ref muy, value); }
    /// <summary>Shear force in X direction in the current display force unit.</summary>
    public double Vux { get => vux; set => Set(ref vux, value); }
    /// <summary>Shear force in Y direction in the current display force unit.</summary>
    public double Vuy { get => vuy; set => Set(ref vuy, value); }
    public bool IsActive { get => isActive; set => Set(ref isActive, value); }
    public bool HasValidationError { get => hasValidationError; set => Set(ref hasValidationError, value); }
    public string OriginalLoadCaseName { get => originalLoadCaseName; set => Set(ref originalLoadCaseName, value); }
    public string SourceObjectName { get => sourceObjectName; set => Set(ref sourceObjectName, value); }
    public string SourceObjectLabel { get => sourceObjectLabel; set => Set(ref sourceObjectLabel, value); }
    public string Story { get => story; set => Set(ref story, value); }
    public string Station { get => station; set => Set(ref station, value); }
    public string Source { get => source; set => Set(ref source, value); }

    public LoadCaseDto ToDto(ForceUnit forceUnit, MomentUnit momentUnit)
        => new(Id, Name, Pu, Mux, Muy, IsActive, forceUnit, momentUnit)
        {
            Vux = Vux,
            Vuy = Vuy
        };
}

