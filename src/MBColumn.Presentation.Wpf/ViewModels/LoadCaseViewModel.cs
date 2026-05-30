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
    private double? factorN;
    private double? factorA;
    private double? factorB;
    private double? factorCx;
    private double? factorCy;
    private double? nominalCurvatureX;
    private double? e2X;
    private double? nominalCurvatureY;
    private double? e2Y;
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
        set { if (Set(ref pu, value)) Raise(nameof(NEd)); }
    }
    public double Mux
    {
        get => mux;
        set { if (Set(ref mux, value)) Raise(nameof(Mx)); }
    }
    public double Muy
    {
        get => muy;
        set { if (Set(ref muy, value)) Raise(nameof(My)); }
    }
    /// <summary>Shear force in X direction in the current display force unit.</summary>
    public double Vux
    {
        get => vux;
        set { if (Set(ref vux, value)) Raise(nameof(Vx)); }
    }
    /// <summary>Shear force in Y direction in the current display force unit.</summary>
    public double Vuy
    {
        get => vuy;
        set { if (Set(ref vuy, value)) Raise(nameof(Vy)); }
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
    public double? MxUsed { get => mxUsed; set { Set(ref mxUsed, value); Raise(nameof(MxUsedResultLatex)); } }
    public double? MyUsed { get => myUsed; set { Set(ref myUsed, value); Raise(nameof(MyUsedResultLatex)); } }
    public double? LambdaX { get => lambdaX; set { Set(ref lambdaX, value); Raise(nameof(Ec2BranchXText)); RaiseSlendernessLatex(); } }
    public double? LambdaLimitX { get => lambdaLimitX; set { Set(ref lambdaLimitX, value); Raise(nameof(Ec2BranchXText)); RaiseSlendernessLatex(); } }
    public double? RmX { get => rmX; set { Set(ref rmX, value); RaiseSlendernessLatex(); } }
    public double? M01x { get => m01x; set { Set(ref m01x, value); RaiseSlendernessLatex(); } }
    public double? M02x { get => m02x; set { Set(ref m02x, value); RaiseSlendernessLatex(); } }
    public double? M0ex { get => m0ex; set { Set(ref m0ex, value); RaiseSlendernessLatex(); } }
    public double? M2x { get => m2x; set { Set(ref m2x, value); RaiseSlendernessLatex(); } }
    public double? LambdaY { get => lambdaY; set { Set(ref lambdaY, value); Raise(nameof(Ec2BranchYText)); RaiseSlendernessLatex(); } }
    public double? LambdaLimitY { get => lambdaLimitY; set { Set(ref lambdaLimitY, value); Raise(nameof(Ec2BranchYText)); RaiseSlendernessLatex(); } }
    public double? RmY { get => rmY; set { Set(ref rmY, value); RaiseSlendernessLatex(); } }
    public double? M01y { get => m01y; set { Set(ref m01y, value); RaiseSlendernessLatex(); } }
    public double? M02y { get => m02y; set { Set(ref m02y, value); RaiseSlendernessLatex(); } }
    public double? M0ey { get => m0ey; set { Set(ref m0ey, value); RaiseSlendernessLatex(); } }
    public double? M2y { get => m2y; set { Set(ref m2y, value); RaiseSlendernessLatex(); } }
    public string Ec2BranchXText => LambdaX.HasValue && LambdaLimitX.HasValue
        ? LambdaX.Value >= LambdaLimitX.Value ? "Nominal curvature" : "Stocky, M2 = 0"
        : "-";
    public string Ec2BranchYText => LambdaY.HasValue && LambdaLimitY.HasValue
        ? LambdaY.Value >= LambdaLimitY.Value ? "Nominal curvature" : "Stocky, M2 = 0"
        : "-";
    public string Ec2BranchXLatex => LambdaX.HasValue && LambdaLimitX.HasValue
        ? LambdaX.Value >= LambdaLimitX.Value ? @"\mathrm{Nominal\;curvature}" : @"\mathrm{Stocky:}\;M_2=0"
        : "-";
    public string Ec2BranchYLatex => LambdaY.HasValue && LambdaLimitY.HasValue
        ? LambdaY.Value >= LambdaLimitY.Value ? @"\mathrm{Nominal\;curvature}" : @"\mathrm{Stocky:}\;M_2=0"
        : "-";
    public string LambdaFormulaLatex => @"\lambda=\frac{l_0}{i}";
    public string LambdaXResultLatex => LambdaX.HasValue ? $@"\lambda_x={LambdaX.Value:F2}" : @"\lambda_x=-";
    public string LambdaYResultLatex => LambdaY.HasValue ? $@"\lambda_y={LambdaY.Value:F2}" : @"\lambda_y=-";
    public string LambdaLimitFormulaLatex => @"\lambda_{lim}=\frac{20ABC}{\sqrt n}";
    public string LambdaLimitXResultLatex => LambdaLimitX.HasValue ? $@"\lambda_{{lim,x}}={LambdaLimitX.Value:F2}" : @"\lambda_{lim,x}=-";
    public string LambdaLimitYResultLatex => LambdaLimitY.HasValue ? $@"\lambda_{{lim,y}}={LambdaLimitY.Value:F2}" : @"\lambda_{lim,y}=-";
    public string MomentRatioFormulaLatex => @"r_m=\frac{M_{01}}{M_{02}}";
    public string MomentRatioXResultLatex => $@"M_{{01}}={Fmt(M01x)},\quad M_{{02}}={Fmt(M02x)},\quad r_m={Fmt(RmX)}";
    public string MomentRatioYResultLatex => $@"M_{{01}}={Fmt(M01y)},\quad M_{{02}}={Fmt(M02y)},\quad r_m={Fmt(RmY)}";
    public double? FactorN { get => factorN; set { Set(ref factorN, value); Raise(nameof(FactorNLatex)); Raise(nameof(FactorALatex)); Raise(nameof(FactorBLatex)); Raise(nameof(FactorCxLatex)); Raise(nameof(FactorCyLatex)); } }
    public double? FactorA { get => factorA; set { Set(ref factorA, value); Raise(nameof(FactorALatex)); } }
    public double? FactorB { get => factorB; set { Set(ref factorB, value); Raise(nameof(FactorBLatex)); } }
    public double? FactorCx { get => factorCx; set { Set(ref factorCx, value); Raise(nameof(FactorCxLatex)); } }
    public double? FactorCy { get => factorCy; set { Set(ref factorCy, value); Raise(nameof(FactorCyLatex)); } }
    public double? NominalCurvatureX { get => nominalCurvatureX; set { Set(ref nominalCurvatureX, value); RaiseSlendernessLatex(); } }
    public double? E2X { get => e2X; set { Set(ref e2X, value); RaiseSlendernessLatex(); } }
    public double? NominalCurvatureY { get => nominalCurvatureY; set { Set(ref nominalCurvatureY, value); RaiseSlendernessLatex(); } }
    public double? E2Y { get => e2Y; set { Set(ref e2Y, value); RaiseSlendernessLatex(); } }

    public string FactorNLatex => factorN.HasValue ? $@"n={factorN.Value:F3}" : "n=-";
    public string FactorALatex => factorA.HasValue ? $@"A={factorA.Value:F3}" : "A=-";
    public string FactorBLatex => factorB.HasValue ? $@"B={factorB.Value:F3}" : "B=-";
    public string FactorCxLatex => factorCx.HasValue ? $@"C_x={factorCx.Value:F3}" : "C_x=-";
    public string FactorCyLatex => factorCy.HasValue ? $@"C_y={factorCy.Value:F3}" : "C_y=-";

    public string NominalCurvatureX1rLatex => nominalCurvatureX.HasValue
        ? $@"\frac{{1}}{{r_x}}={nominalCurvatureX.Value * 1000:F5}\;\text{{m}}^{{-1}}"
        : @"\frac{1}{r_x}=-";
    public string NominalCurvatureY1rLatex => nominalCurvatureY.HasValue
        ? $@"\frac{{1}}{{r_y}}={nominalCurvatureY.Value * 1000:F5}\;\text{{m}}^{{-1}}"
        : @"\frac{1}{r_y}=-";
    public string NominalCurvatureXE2Latex => e2X.HasValue
        ? $@"e_{{2,x}}={e2X.Value:F2}\;\text{{mm}}"
        : @"e_{2,x}=-";
    public string NominalCurvatureYE2Latex => e2Y.HasValue
        ? $@"e_{{2,y}}={e2Y.Value:F2}\;\text{{mm}}"
        : @"e_{2,y}=-";

    public bool IsAnyAxisSlender => IsSlender(M2x) || IsSlender(M2y);
    public bool IsNeitherAxisSlender => !IsAnyAxisSlender && (M2x.HasValue || M2y.HasValue);

    public string BranchFormulaLatex => @"\lambda<\lambda_{lim}\Rightarrow M_2=0,\quad \lambda\geq\lambda_{lim}\Rightarrow\text{nominal curvature}";
    public string NominalCurvatureFormulaLatex => @"M_{0e}=\max(0.6M_{02}+0.4M_{01},0.4M_{02}),\quad M_2=N_{Ed}e_2";
    public string NominalCurvatureXResultLatex => $@"M_{{0e}}={Fmt(M0ex)},\quad M_2={Fmt(M2x)}";
    public string NominalCurvatureYResultLatex => $@"M_{{0e}}={Fmt(M0ey)},\quad M_2={Fmt(M2y)}";
    public string NominalCurvatureXM0eLatex => IsSlender(M2x)
        ? $@"M_{{0e}}=\max(0.6\times{Fmt(M02x)}+0.4\times{Fmt(M01x)},0.4\times{Fmt(M02x)})={Fmt(M0ex)}"
        : $@"M_{{0e}}={Fmt(M0ex)}";
    public string NominalCurvatureYM0eLatex => IsSlender(M2y)
        ? $@"M_{{0e}}=\max(0.6\times{Fmt(M02y)}+0.4\times{Fmt(M01y)},0.4\times{Fmt(M02y)})={Fmt(M0ey)}"
        : $@"M_{{0e}}={Fmt(M0ey)}";
    public string NominalCurvatureXM2Latex => $@"M_2={Fmt(M2x)}";
    public string NominalCurvatureYM2Latex => $@"M_2={Fmt(M2y)}";
    public string MomentUsedFormulaLatex => @"M_{used}=\max(M_{02},M_{0e}+M_2,M_{01}+0.5M_2,N_{Ed}e_0)";
    public string MxUsedResultLatex => MxUsed.HasValue ? $@"M_x={MxUsed.Value:F2}" : @"M_x=\mathrm{auto}";
    public string MyUsedResultLatex => MyUsed.HasValue ? $@"M_y={MyUsed.Value:F2}" : @"M_y=\mathrm{auto}";
    public bool IsActive { get => isActive; set => Set(ref isActive, value); }
    public bool HasValidationError { get => hasValidationError; set => Set(ref hasValidationError, value); }
    public string Status
    {
        get => status;
        set
        {
            if (Set(ref status, value))
            {
                Raise(nameof(SlendernessStatusText));
                Raise(nameof(CalculationStatusText));
            }
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
        FactorN = null;
        FactorA = null;
        FactorB = null;
        FactorCx = null;
        FactorCy = null;
        NominalCurvatureX = null;
        E2X = null;
        NominalCurvatureY = null;
        E2Y = null;
    }

    private static string Fmt(double? value) => value.HasValue ? value.Value.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) : "-";

    private static bool IsSlender(double? m2) => m2.HasValue && Math.Abs(m2.Value) > 1e-9;

    private void RaiseSlendernessLatex()
    {
        Raise(nameof(LambdaXResultLatex));
        Raise(nameof(LambdaYResultLatex));
        Raise(nameof(LambdaLimitXResultLatex));
        Raise(nameof(LambdaLimitYResultLatex));
        Raise(nameof(Ec2BranchXLatex));
        Raise(nameof(Ec2BranchYLatex));
        Raise(nameof(MomentRatioXResultLatex));
        Raise(nameof(MomentRatioYResultLatex));
        Raise(nameof(NominalCurvatureXResultLatex));
        Raise(nameof(NominalCurvatureYResultLatex));
        Raise(nameof(NominalCurvatureXM0eLatex));
        Raise(nameof(NominalCurvatureYM0eLatex));
        Raise(nameof(NominalCurvatureXM2Latex));
        Raise(nameof(NominalCurvatureYM2Latex));
        Raise(nameof(NominalCurvatureX1rLatex));
        Raise(nameof(NominalCurvatureY1rLatex));
        Raise(nameof(NominalCurvatureXE2Latex));
        Raise(nameof(NominalCurvatureYE2Latex));
        Raise(nameof(MxUsedResultLatex));
        Raise(nameof(MyUsedResultLatex));
        Raise(nameof(IsAnyAxisSlender));
        Raise(nameof(IsNeitherAxisSlender));
    }
}
