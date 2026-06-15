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
    private double? krX;
    private double? kPhiX;
    private double? krY;
    private double? kPhiY;
    private double? betaX;
    private double? betaY;
    private double? phiEffX;
    private double? phiEffY;
    private double? minimumMomentX;
    private double? minimumMomentY;
    private bool isActive;
    private bool hasValidationError;
    private string status = "Ready";
    private string originalLoadCaseName = "";
    private string sourceObjectName = "";
    private string sourceObjectLabel = "";
    private string story = "";
    private string station = "";
    private string source = "Manual";
    private double? memberLengthOverrideMm;
    private bool isEtabsImportedLoad;
    private string etabsLoadCaseOrCombo = "";
    private string etabsFrameId = "";
    private string etabsForceStation = "";
    private DateTime? etabsForceImportedAt;
    private readonly double lengthDisplayScale;
    private bool _suppressSlendernessNotifications;
    private bool _pendingSlendernessRaise;

    public LoadCaseViewModel(string id, string name, double pu, double mux, double muy, bool isActive = true,
        MBColumn.Domain.Enums.UnitSystem unitSystem = MBColumn.Domain.Enums.UnitSystem.Metric)
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
        // mm → m for metric; mm → ft for imperial (1 ft = 304.8 mm)
        lengthDisplayScale = unitSystem == MBColumn.Domain.Enums.UnitSystem.Metric ? 0.001 : 1.0 / 304.8;
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
    public double? MxUsed { get => mxUsed; set { Set(ref mxUsed, value); Raise(nameof(MxUsedResultLatex)); Raise(nameof(MxUsedExpandedLatex)); } }
    public double? MyUsed { get => myUsed; set { Set(ref myUsed, value); Raise(nameof(MyUsedResultLatex)); Raise(nameof(MyUsedExpandedLatex)); } }
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
    public string MomentRatioXResultLatex => $@"M_{{01}}={FmtMoment(M01x)},\quad M_{{02}}={FmtMoment(M02x)},\quad r_m={Fmt(RmX)}";
    public string MomentRatioYResultLatex => $@"M_{{01}}={FmtMoment(M01y)},\quad M_{{02}}={FmtMoment(M02y)},\quad r_m={Fmt(RmY)}";
    public string RmXOnlyLatex => RmX.HasValue ? $@"r_{{m,x}}={RmX.Value:F4}" : @"r_{m,x}=-";
    public string RmYOnlyLatex => RmY.HasValue ? $@"r_{{m,y}}={RmY.Value:F4}" : @"r_{m,y}=-";
    public double? FactorN { get => factorN; set { Set(ref factorN, value); Raise(nameof(FactorNLatex)); Raise(nameof(FactorALatex)); Raise(nameof(FactorBLatex)); Raise(nameof(FactorCxLatex)); Raise(nameof(FactorCyLatex)); RaiseSlendernessLatex(); } }
    public double? FactorA { get => factorA; set { Set(ref factorA, value); Raise(nameof(FactorALatex)); } }
    public double? FactorB { get => factorB; set { Set(ref factorB, value); Raise(nameof(FactorBLatex)); RaiseSlendernessLatex(); } }
    public double? FactorCx { get => factorCx; set { Set(ref factorCx, value); Raise(nameof(FactorCxLatex)); } }
    public double? FactorCy { get => factorCy; set { Set(ref factorCy, value); Raise(nameof(FactorCyLatex)); } }
    public double? NominalCurvatureX { get => nominalCurvatureX; set { Set(ref nominalCurvatureX, value); RaiseSlendernessLatex(); } }
    public double? E2X { get => e2X; set { Set(ref e2X, value); RaiseSlendernessLatex(); } }
    public double? NominalCurvatureY { get => nominalCurvatureY; set { Set(ref nominalCurvatureY, value); RaiseSlendernessLatex(); } }
    public double? E2Y { get => e2Y; set { Set(ref e2Y, value); RaiseSlendernessLatex(); } }
    public double? KrX { get => krX; set { Set(ref krX, value); RaiseSlendernessLatex(); } }
    public double? KPhiX { get => kPhiX; set { Set(ref kPhiX, value); RaiseSlendernessLatex(); } }
    public double? KrY { get => krY; set { Set(ref krY, value); RaiseSlendernessLatex(); } }
    public double? KPhiY { get => kPhiY; set { Set(ref kPhiY, value); RaiseSlendernessLatex(); } }
    public double? BetaX { get => betaX; set { Set(ref betaX, value); RaiseSlendernessLatex(); } }
    public double? BetaY { get => betaY; set { Set(ref betaY, value); RaiseSlendernessLatex(); } }
    public double? PhiEffX { get => phiEffX; set { Set(ref phiEffX, value); RaiseSlendernessLatex(); } }
    public double? PhiEffY { get => phiEffY; set { Set(ref phiEffY, value); RaiseSlendernessLatex(); } }
    public double? MinimumMomentX { get => minimumMomentX; set { Set(ref minimumMomentX, value); RaiseSlendernessLatex(); } }
    public double? MinimumMomentY { get => minimumMomentY; set { Set(ref minimumMomentY, value); RaiseSlendernessLatex(); } }

    public string FactorNLatex => factorN.HasValue ? $@"n={factorN.Value:F3}" : "n=-";
    public string FactorALatex => factorA.HasValue ? $@"A={factorA.Value:F3}" : "A=-";
    public string FactorBLatex => factorB.HasValue ? $@"B={factorB.Value:F3}" : "B=-";
    public string FactorCxLatex => factorCx.HasValue ? $@"C_x={factorCx.Value:F3}" : "C_x=-";
    public string FactorCyLatex => factorCy.HasValue ? $@"C_y={factorCy.Value:F3}" : "C_y=-";

    public string NominalCurvatureX1rLatex => nominalCurvatureX.HasValue
        ? $@"\frac{{1}}{{r_x}}={nominalCurvatureX.Value * 1000:F5}\;\mathrm{{m}}^{{-1}}"
        : @"\frac{1}{r_x}=-";
    public string NominalCurvatureY1rLatex => nominalCurvatureY.HasValue
        ? $@"\frac{{1}}{{r_y}}={nominalCurvatureY.Value * 1000:F5}\;\mathrm{{m}}^{{-1}}"
        : @"\frac{1}{r_y}=-";
    public string NominalCurvatureXE2Latex => e2X.HasValue
        ? $@"e_{{2,x}}={e2X.Value:F2}\;\mathrm{{mm}}"
        : @"e_{2,x}=-";
    public string NominalCurvatureYE2Latex => e2Y.HasValue
        ? $@"e_{{2,y}}={e2Y.Value:F2}\;\mathrm{{mm}}"
        : @"e_{2,y}=-";

    // "Slender" means the nominal curvature branch was selected (lambda > lambda_lim).
    // Do NOT gate on M2 > 0: when n >> nu the Kr factor clamps to 0, giving M2 = 0,
    // but the user still needs to see the Kr/Kphi/1r/e2 rows to understand why M2 = 0.
    public bool IsAnyAxisSlender =>
        (LambdaX.HasValue && LambdaLimitX.HasValue && LambdaX.Value > LambdaLimitX.Value) ||
        (LambdaY.HasValue && LambdaLimitY.HasValue && LambdaY.Value > LambdaLimitY.Value);
    public bool IsNeitherAxisSlender => !IsAnyAxisSlender && HasSlendernessData;
    public bool HasEc2Results => M02x.HasValue || M02y.HasValue;
    public bool HasSlendernessData => LambdaX.HasValue || LambdaY.HasValue;

    public string BranchFormulaLatex => @"\lambda<\lambda_{lim}\Rightarrow M_2=0,\quad \lambda\geq\lambda_{lim}\Rightarrow\text{nominal curvature}";
    public string NominalCurvatureFormulaLatex => @"M_{0e}=\max(0.6M_{02}+0.4M_{01},0.4M_{02}),\quad M_2=N_{Ed}e_2";
    public string NominalCurvatureXResultLatex => $@"M_{{0e}}={FmtMoment(M0ex)},\quad M_2={FmtMoment(M2x)}";
    public string NominalCurvatureYResultLatex => $@"M_{{0e}}={FmtMoment(M0ey)},\quad M_2={FmtMoment(M2y)}";
    public string NominalCurvatureXM0eLatex => $@"M_{{0e,x}}={FmtMoment(M0ex)}";
    public string NominalCurvatureYM0eLatex => $@"M_{{0e,y}}={FmtMoment(M0ey)}";
    public string NominalCurvatureXM2Latex => $@"M_{{2,x}}={FmtMoment(M2x)}";
    public string NominalCurvatureYM2Latex => $@"M_{{2,y}}={FmtMoment(M2y)}";
    public string M01XResultLatex => M01x.HasValue ? $@"M_{{01,x}}={FmtMoment(M01x)}" : @"M_{01,x}=-";
    public string M02XResultLatex => M02x.HasValue ? $@"M_{{02,x}}={FmtMoment(M02x)}" : @"M_{02,x}=-";
    public string M01YResultLatex => M01y.HasValue ? $@"M_{{01,y}}={FmtMoment(M01y)}" : @"M_{01,y}=-";
    public string M02YResultLatex => M02y.HasValue ? $@"M_{{02,y}}={FmtMoment(M02y)}" : @"M_{02,y}=-";
    public string M0eEquivXLatex => BuildM0eEquivalentLatex("x", M01x, M02x, M0ex);
    public string M0eEquivYLatex => BuildM0eEquivalentLatex("y", M01y, M02y, M0ey);
    public string KrXLatex => BuildKrLatex("x", KrX);
    public string KrYLatex => BuildKrLatex("y", KrY);
    public string KPhiXLatex => BuildKPhiLatex("x", KPhiX, BetaX, PhiEffX);
    public string KPhiYLatex => BuildKPhiLatex("y", KPhiY, BetaY, PhiEffY);
    public string MomentUsedFormulaLatex => @"M_{Ed}=\max(M_{02},\;M_{0e}+M_2,\;M_{01}+0.5M_2,\;M_{min})";
    public string EffectiveMomentUsedFormulaLatex => HasSlendernessData
        ? MomentUsedFormulaLatex
        : @"M_{Ed}=\max(M_{02},\;M_{min})";
    public string MxUsedResultLatex => MxUsed.HasValue ? $@"M_{{Ed,x}}={FmtMoment(MxUsed)}" : @"M_{Ed,x}=\mathrm{auto}";
    public string MyUsedResultLatex => MyUsed.HasValue ? $@"M_{{Ed,y}}={FmtMoment(MyUsed)}" : @"M_{Ed,y}=\mathrm{auto}";
    public string MxUsedExpandedLatex => BuildMomentUsedExpandedLatex("x", MxUsed, M02x, M0ex, M2x, M01x, MinimumMomentX);
    public string MyUsedExpandedLatex => BuildMomentUsedExpandedLatex("y", MyUsed, M02y, M0ey, M2y, M01y, MinimumMomentY);

    // Row 11 sub-rows: both M0e max() candidates — show whenever slenderness data is available (M2 may be 0 for stocky/Kr=0)
    public string M0eCand1XLatex => M01x.HasValue && M02x.HasValue && M2x.HasValue
        ? $@"0.6\times{Fmt(M02x)}+0.4\times{Fmt(M01x)}={FmtMoment(0.6*M02x.Value+0.4*M01x.Value)}"
        : "";
    public string M0eCand2XLatex => M02x.HasValue && M2x.HasValue
        ? $@"0.4\times{Fmt(M02x)}={FmtMoment(0.4*M02x.Value)}"
        : "";
    public string M0eCand1YLatex => M01y.HasValue && M02y.HasValue && M2y.HasValue
        ? $@"0.6\times{Fmt(M02y)}+0.4\times{Fmt(M01y)}={FmtMoment(0.6*M02y.Value+0.4*M01y.Value)}"
        : "";
    public string M0eCand2YLatex => M02y.HasValue && M2y.HasValue
        ? $@"0.4\times{Fmt(M02y)}={FmtMoment(0.4*M02y.Value)}"
        : "";

    // Row 12 sub-rows: all Mused max() candidates — show whenever slenderness data is available
    public string MxCandM02Latex => M02x.HasValue ? $@"M_{{02,x}}={FmtMoment(M02x)}" : "";
    public string MxCandM0ePlusM2Latex => M0ex.HasValue && M2x.HasValue
        ? $@"\left|M_{{0e,x}}\right|+M_{{2,x}}={Fmt(Math.Abs(M0ex.Value))}+{Fmt(M2x.Value)}={FmtMoment(Math.Abs(M0ex.Value)+M2x.Value)}"
        : "";
    public string MxCandM01Plus05M2Latex => M01x.HasValue && M2x.HasValue
        ? $@"M_{{01,x}}+0.5M_{{2,x}}={Fmt(M01x.Value)}+0.5\times{Fmt(M2x.Value)}={FmtMoment(M01x.Value+0.5*M2x.Value)}"
        : "";
    public string MxCandMinimumMomentLatex => MinimumMomentX.HasValue ? $@"M_{{min,x}}={FmtMoment(MinimumMomentX)}" : "";
    public string MyCandM02Latex => M02y.HasValue ? $@"M_{{02,y}}={FmtMoment(M02y)}" : "";
    public string MyCandM0ePlusM2Latex => M0ey.HasValue && M2y.HasValue
        ? $@"\left|M_{{0e,y}}\right|+M_{{2,y}}={Fmt(Math.Abs(M0ey.Value))}+{Fmt(M2y.Value)}={FmtMoment(Math.Abs(M0ey.Value)+M2y.Value)}"
        : "";
    public string MyCandM01Plus05M2Latex => M01y.HasValue && M2y.HasValue
        ? $@"M_{{01,y}}+0.5M_{{2,y}}={Fmt(M01y.Value)}+0.5\times{Fmt(M2y.Value)}={FmtMoment(M01y.Value+0.5*M2y.Value)}"
        : "";
    public string MyCandMinimumMomentLatex => MinimumMomentY.HasValue ? $@"M_{{min,y}}={FmtMoment(MinimumMomentY)}" : "";
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
    public bool IsEtabsImportedLoad { get => isEtabsImportedLoad; set => Set(ref isEtabsImportedLoad, value); }
    public string EtabsLoadCaseOrCombo { get => etabsLoadCaseOrCombo; set => Set(ref etabsLoadCaseOrCombo, value); }
    public string EtabsFrameId { get => etabsFrameId; set => Set(ref etabsFrameId, value); }
    public string EtabsForceStation { get => etabsForceStation; set => Set(ref etabsForceStation, value); }
    public DateTime? EtabsForceImportedAt { get => etabsForceImportedAt; set => Set(ref etabsForceImportedAt, value); }

    /// <summary>Per-case member length in the user's member-length display unit (m or ft). Null = use global length.</summary>
    public double? MemberLengthOverrideDisplay
    {
        get => memberLengthOverrideMm.HasValue ? memberLengthOverrideMm.Value * lengthDisplayScale : (double?)null;
        set
        {
            var mm = value.HasValue ? value.Value / lengthDisplayScale : (double?)null;
            if (Set(ref memberLengthOverrideMm, mm))
                Raise(nameof(MemberLengthOverrideDisplay));
        }
    }

    /// <summary>Per-case member length in mm (internal unit). Null = use global length.</summary>
    public double? MemberLengthOverrideMm
    {
        get => memberLengthOverrideMm;
        set
        {
            if (Set(ref memberLengthOverrideMm, value))
                Raise(nameof(MemberLengthOverrideDisplay));
        }
    }

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
            MyUsed = MyUsed,
            MemberLengthOverrideMm = memberLengthOverrideMm
        };

    public void ClearEc2SlendernessResults()
    {
        BeginBatchUpdate();
        try
        {
            ClearEc2SlendernessResultsCore();
        }
        finally
        {
            EndBatchUpdate();
        }
    }

    private void ClearEc2SlendernessResultsCore()
    {
        // Revert to direct end-moment envelope (sign-preserving max-abs governing value)
        MxUsed = ComputeDefaultMxUsed();
        MyUsed = ComputeDefaultMyUsed();
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
        KrX = null;
        KPhiX = null;
        KrY = null;
        KPhiY = null;
        BetaX = null;
        BetaY = null;
        PhiEffX = null;
        PhiEffY = null;
        MinimumMomentX = null;
        MinimumMomentY = null;
    }

    /// <summary>Computes the default MxUsed as the end moment with the larger absolute value, preserving sign.</summary>
    public double? ComputeDefaultMxUsed()
        => (MxTop.HasValue && MxBottom.HasValue)
            ? (Math.Abs(MxTop.Value) >= Math.Abs(MxBottom.Value) ? MxTop : MxBottom)
            : null;

    /// <summary>Computes the default MyUsed as the end moment with the larger absolute value, preserving sign.</summary>
    public double? ComputeDefaultMyUsed()
        => (MyTop.HasValue && MyBottom.HasValue)
            ? (Math.Abs(MyTop.Value) >= Math.Abs(MyBottom.Value) ? MyTop : MyBottom)
            : null;

    private string BuildKrLatex(string axis, double? kr)
    {
        if (!kr.HasValue)
            return $@"K_{{r,{axis}}}=-";

        double? omega = FactorB.HasValue ? Math.Max(0.0, (FactorB.Value * FactorB.Value - 1.0) / 2.0) : null;
        if (FactorN.HasValue && omega.HasValue)
        {
            double nu = 1.0 + omega.Value;
            return $@"K_{{r,{axis}}}=\min\!\left(1,\frac{{{Fmt4(nu)}-{Fmt4(FactorN.Value)}}}{{{Fmt4(nu)}-0.4000}}\right)={Fmt4(kr.Value)}";
        }

        return $@"K_{{r,{axis}}}={Fmt4(kr.Value)}";
    }

    private static string BuildKPhiLatex(string axis, double? kPhi, double? beta, double? phiEff)
    {
        if (!kPhi.HasValue)
            return $@"K_{{\varphi,{axis}}}=-";

        if (beta.HasValue && phiEff.HasValue)
        {
            return $@"K_{{\varphi,{axis}}}=\max(1,1+{Fmt4(beta.Value)}\times{Fmt3(phiEff.Value)})={Fmt4(kPhi.Value)}";
        }

        return $@"K_{{\varphi,{axis}}}={Fmt4(kPhi.Value)}";
    }

    private static string BuildM0eEquivalentLatex(string axis, double? m01, double? m02, double? m0e)
    {
        if (!m01.HasValue || !m02.HasValue || !m0e.HasValue)
            return $@"M_{{0e,{axis}}}=-";

        double candidate1 = 0.6 * m02.Value + 0.4 * m01.Value;
        double candidate2 = 0.4 * m02.Value;
        string sign = m0e.Value < -1e-9 ? "-" : "";

        return $@"M_{{0e,{axis}}}={sign}\max({Fmt(candidate1)},{Fmt(candidate2)})={FmtMoment(m0e.Value)}";
    }

    private static string BuildMomentUsedExpandedLatex(
        string axis,
        double? used,
        double? m02,
        double? m0e,
        double? m2,
        double? m01,
        double? minimumMoment)
    {
        if (!used.HasValue)
            return $@"M_{{Ed,{axis}}}=\mathrm{{auto}}";

        var candidates = new List<double>();
        if (m02.HasValue)
            candidates.Add(Math.Abs(m02.Value));
        if (m0e.HasValue && m2.HasValue)
            candidates.Add(Math.Abs(m0e.Value) + Math.Abs(m2.Value));
        if (m01.HasValue && m2.HasValue)
            candidates.Add(Math.Abs(m01.Value) + 0.5 * Math.Abs(m2.Value));
        if (minimumMoment.HasValue)
            candidates.Add(Math.Abs(minimumMoment.Value));

        if (candidates.Count == 0)
            return $@"M_{{Ed,{axis}}}={FmtMoment(used.Value)}";

        string candidateText = string.Join(",", candidates.Select(v => Fmt(v)));
        return $@"M_{{Ed,{axis}}}=\max({candidateText})={FmtMoment(Math.Abs(used.Value))}";
    }

    private static string Fmt(double? value) => value.HasValue ? value.Value.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) : "-";

    private static string FmtMoment(double? value)
        => value.HasValue ? $@"{Fmt(value)}\;\mathrm{{kN\cdot m}}" : "-";

    private static string Fmt3(double value) => value.ToString("F3", System.Globalization.CultureInfo.InvariantCulture);

    private static string Fmt4(double value) => value.ToString("F4", System.Globalization.CultureInfo.InvariantCulture);

    private static bool IsSlender(double? m2) => m2.HasValue && Math.Abs(m2.Value) > 1e-9;

    internal void BeginBatchUpdate()
    {
        _suppressSlendernessNotifications = true;
        _pendingSlendernessRaise = false;
    }

    internal void EndBatchUpdate()
    {
        _suppressSlendernessNotifications = false;
        if (_pendingSlendernessRaise)
        {
            _pendingSlendernessRaise = false;
            RaiseSlendernessLatex();
        }
    }

    private void RaiseSlendernessLatex()
    {
        if (_suppressSlendernessNotifications)
        {
            _pendingSlendernessRaise = true;
            return;
        }
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
        Raise(nameof(M01XResultLatex));
        Raise(nameof(M02XResultLatex));
        Raise(nameof(M01YResultLatex));
        Raise(nameof(M02YResultLatex));
        Raise(nameof(NominalCurvatureX1rLatex));
        Raise(nameof(NominalCurvatureY1rLatex));
        Raise(nameof(NominalCurvatureXE2Latex));
        Raise(nameof(NominalCurvatureYE2Latex));
        Raise(nameof(KrXLatex));
        Raise(nameof(KrYLatex));
        Raise(nameof(KPhiXLatex));
        Raise(nameof(KPhiYLatex));
        Raise(nameof(MxUsedResultLatex));
        Raise(nameof(MyUsedResultLatex));
        Raise(nameof(MxUsedExpandedLatex));
        Raise(nameof(MyUsedExpandedLatex));
        Raise(nameof(M0eCand1XLatex));
        Raise(nameof(M0eCand2XLatex));
        Raise(nameof(M0eCand1YLatex));
        Raise(nameof(M0eCand2YLatex));
        Raise(nameof(MxCandM02Latex));
        Raise(nameof(MxCandM0ePlusM2Latex));
        Raise(nameof(MxCandM01Plus05M2Latex));
        Raise(nameof(MxCandMinimumMomentLatex));
        Raise(nameof(MyCandM02Latex));
        Raise(nameof(MyCandM0ePlusM2Latex));
        Raise(nameof(MyCandM01Plus05M2Latex));
        Raise(nameof(MyCandMinimumMomentLatex));
        Raise(nameof(RmXOnlyLatex));
        Raise(nameof(RmYOnlyLatex));
        Raise(nameof(M0eEquivXLatex));
        Raise(nameof(M0eEquivYLatex));
        Raise(nameof(IsAnyAxisSlender));
        Raise(nameof(IsNeitherAxisSlender));
        Raise(nameof(HasEc2Results));
        Raise(nameof(HasSlendernessData));
        Raise(nameof(EffectiveMomentUsedFormulaLatex));
    }
}
