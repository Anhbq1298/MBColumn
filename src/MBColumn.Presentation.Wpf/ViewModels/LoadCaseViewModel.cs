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
    private double? mxTop;
    private double? mxBottom;
    private double? myTop;
    private double? myBottom;
    private double? mxUsed;
    private double? myUsed;
    private double? lambdaX;
    private double? lambdaLimitX;
    private double? rmX;
    private double? m01x;
    private double? m02x;
    private double? m0ex;
    private double? m2x;
    private double? lambdaY;
    private double? lambdaLimitY;
    private double? rmY;
    private double? m01y;
    private double? m02y;
    private double? m0ey;
    private double? m2y;
    private bool isActive;
    private bool hasValidationError;
    private string status = "Ready";
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
        this.mxTop = mux;
        this.mxBottom = mux;
        this.myTop = muy;
        this.myBottom = muy;
        this.isActive = isActive;
    }

    public string Id { get => id; set => Set(ref id, value); }
    public string Name { get => name; set => Set(ref name, value); }
    public double Pu
    {
        get => pu;
        set
        {
            Set(ref pu, value);
            Raise(nameof(NEd));
        }
    }
    public double Mux
    {
        get => mux;
        set
        {
            Set(ref mux, value);
            Raise(nameof(Mx));
        }
    }
    public double Muy
    {
        get => muy;
        set
        {
            Set(ref muy, value);
            Raise(nameof(My));
        }
    }
    /// <summary>Shear force in X direction in the current display force unit.</summary>
    public double Vux
    {
        get => vux;
        set
        {
            Set(ref vux, value);
            Raise(nameof(Vx));
        }
    }
    /// <summary>Shear force in Y direction in the current display force unit.</summary>
    public double Vuy
    {
        get => vuy;
        set
        {
            Set(ref vuy, value);
            Raise(nameof(Vy));
        }
    }
    public double NEd { get => Pu; set => Pu = value; }
    public double Vx { get => Vux; set => Vux = value; }
    public double Vy { get => Vuy; set => Vuy = value; }
    public double Mx { get => Mux; set => Mux = value; }
    public double My { get => Muy; set => Muy = value; }
    public double? MxTop { get => mxTop; set => Set(ref mxTop, value); }
    public double? MxBottom { get => mxBottom; set => Set(ref mxBottom, value); }
    public double? MyTop { get => myTop; set => Set(ref myTop, value); }
    public double? MyBottom { get => myBottom; set => Set(ref myBottom, value); }
    public double? MxUsed { get => mxUsed; set => Set(ref mxUsed, value); }
    public double? MyUsed { get => myUsed; set => Set(ref myUsed, value); }
    public double? LambdaX { get => lambdaX; set { Set(ref lambdaX, value); Raise(nameof(Ec2BranchXText)); } }
    public double? LambdaLimitX { get => lambdaLimitX; set { Set(ref lambdaLimitX, value); Raise(nameof(Ec2BranchXText)); } }
    public double? RmX { get => rmX; set => Set(ref rmX, value); }
    public double? M01x { get => m01x; set => Set(ref m01x, value); }
    public double? M02x { get => m02x; set => Set(ref m02x, value); }
    public double? M0ex { get => m0ex; set => Set(ref m0ex, value); }
    public double? M2x { get => m2x; set => Set(ref m2x, value); }
    public double? LambdaY { get => lambdaY; set { Set(ref lambdaY, value); Raise(nameof(Ec2BranchYText)); } }
    public double? LambdaLimitY { get => lambdaLimitY; set { Set(ref lambdaLimitY, value); Raise(nameof(Ec2BranchYText)); } }
    public double? RmY { get => rmY; set => Set(ref rmY, value); }
    public double? M01y { get => m01y; set => Set(ref m01y, value); }
    public double? M02y { get => m02y; set => Set(ref m02y, value); }
    public double? M0ey { get => m0ey; set => Set(ref m0ey, value); }
    public double? M2y { get => m2y; set => Set(ref m2y, value); }
    public string Ec2BranchXText => LambdaX.HasValue && LambdaLimitX.HasValue
        ? LambdaX.Value >= LambdaLimitX.Value ? "Nominal curvature" : "Stocky, M2 = 0"
        : "-";
    public string Ec2BranchYText => LambdaY.HasValue && LambdaLimitY.HasValue
        ? LambdaY.Value >= LambdaLimitY.Value ? "Nominal curvature" : "Stocky, M2 = 0"
        : "-";
    public bool IsActive { get => isActive; set => Set(ref isActive, value); }
    public bool HasValidationError { get => hasValidationError; set => Set(ref hasValidationError, value); }
    public string Status
    {
        get => status;
        set
        {
            Set(ref status, value);
            Raise(nameof(SlendernessStatusText));
            Raise(nameof(CalculationStatusText));
        }
    }
    public string SlendernessStatusText => Status;
    public string CalculationStatusText => Status;
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
            Vuy = Vuy,
            MxTop = MxTop,
            MxBottom = MxBottom,
            MyTop = MyTop,
            MyBottom = MyBottom,
            MxUsed = MxUsed,
            MyUsed = MyUsed
        };

    public void ClearEc2SlendernessResults()
    {
        MxUsed = null;
        MyUsed = null;
        LambdaX = null;
        LambdaLimitX = null;
        RmX = null;
        M01x = null;
        M02x = null;
        M0ex = null;
        M2x = null;
        LambdaY = null;
        LambdaLimitY = null;
        RmY = null;
        M01y = null;
        M02y = null;
        M0ey = null;
        M2y = null;
    }
}

