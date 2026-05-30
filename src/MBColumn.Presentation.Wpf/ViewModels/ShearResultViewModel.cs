using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels;

/// <summary>
/// Display ViewModel for the governing shear check result (Results tab sidebar).
/// All force values in the user's display unit; lengths/stresses in mm / MPa.
/// </summary>
public sealed class ShearResultViewModel : ViewModelBase
{
    private ShearResultDto? dto;
    private IReadOnlyList<ShearEnvelopeSummaryRowViewModel> envelopeSummaryRows = [];

    public void Load(ShearResultDto? result)
        => Load(result, []);

    public void Load(ShearResultDto? result, IReadOnlyList<LoadCaseResultDto>? loadCaseResults)
    {
        dto = result;
        envelopeSummaryRows = BuildEnvelopeSummaryRows(loadCaseResults ?? [], result);
        Raise(string.Empty);
    }

    public bool HasResult => dto is not null;
    public IReadOnlyList<ShearEnvelopeSummaryRowViewModel> EnvelopeSummaryRows => envelopeSummaryRows;
    public bool HasEnvelopeSummary => envelopeSummaryRows.Count > 0;
    public bool HasDemand => dto?.HasDemand == true;
    public bool HasLinks => dto?.HasLinks == true;
    public string ForceUnit => dto?.ForceUnit ?? "kN";

    public bool IsCircularSection => dto?.SectionShape == SectionShapeType.Circular;
    public bool IsRectangularSection => !IsCircularSection;
    public bool IsCircularHoop => dto?.IsCircularHoop == true;
    public string DiameterText => dto is null ? "-" : $"{dto.DiameterMm:F0} mm";
    public string CircularBwNote => dto is null ? "" :
        $"EC2 6.2.2(5): bw = 0.8D = 0.8 x {dto.DiameterMm:F0} = {dto.BwXMm:F0} mm";

    public string BwXText => dto is null ? "-" : $"{dto.BwXMm:F0} mm";
    public string BwYText => dto is null ? "-" : $"{dto.BwYMm:F0} mm";
    public string DEffXText => dto is null ? "-" : $"{dto.DEffXMm:F0} mm";
    public string DEffYText => dto is null ? "-" : $"{dto.DEffYMm:F0} mm";
    public string KFactorXText => dto is null ? "-" : $"{dto.KFactorX:F3}";
    public string KFactorYText => dto is null ? "-" : $"{dto.KFactorY:F3}";
    public string SigCpText => dto is null ? "-" : $"{dto.SigCpMpa:F3} MPa";

    public string VEdXText => dto is null ? "-" : $"{dto.VEdXDisplay:F1}";
    public string VRdcXText => dto is null ? "-" : $"{dto.VRdcXDisplay:F1}";
    public string VEdYText => dto is null ? "-" : $"{dto.VEdYDisplay:F1}";
    public string VRdcYText => dto is null ? "-" : $"{dto.VRdcYDisplay:F1}";
    public string LinksReqXText => dto?.LinksRequiredX == true ? "Required" : "Not required";
    public string LinksReqYText => dto?.LinksRequiredY == true ? "Required" : "Not required";
    public bool IsLinksReqX => dto?.LinksRequiredX == true;
    public bool IsLinksReqY => dto?.LinksRequiredY == true;

    public string AswSXText => dto is null || !HasLinks ? "-" : $"{dto.AswSX:F4} mm2/mm";
    public string AswSYText => dto is null || !HasLinks ? "-" : $"{dto.AswSY:F4} mm2/mm";
    public string FywdText => dto is null || !HasLinks ? "-" : $"{dto.FywdMpa:F1} MPa";
    public string ZXText => dto is null || !HasLinks ? "-" : $"{dto.ZXMm:F0} mm";
    public string ZYText => dto is null || !HasLinks ? "-" : $"{dto.ZYMm:F0} mm";
    public string CotThetaXText => dto is null || dto.CotThetaX == 0 ? "-"
        : $"{dto.CotThetaX:F2} (theta={ThetaDeg(dto.CotThetaX):F1} deg)";
    public string CotThetaYText => dto is null || dto.CotThetaY == 0 ? "-"
        : $"{dto.CotThetaY:F2} (theta={ThetaDeg(dto.CotThetaY):F1} deg)";
    public string VRdsXText => dto is null || !HasLinks ? "-" : $"{dto.VRdsXDisplay:F1}";
    public string VRdsYText => dto is null || !HasLinks ? "-" : $"{dto.VRdsYDisplay:F1}";
    public string VRdMaxXText => dto is null || !HasLinks ? "-" : $"{dto.VRdMaxXDisplay:F1}";
    public string VRdMaxYText => dto is null || !HasLinks ? "-" : $"{dto.VRdMaxYDisplay:F1}";
    public string VRdXText => dto is null ? "-" : $"{dto.VRdXDisplay:F1}";
    public string VRdYText => dto is null ? "-" : $"{dto.VRdYDisplay:F1}";

    public bool IsStruttingCriticalX => dto?.IsStruttingCriticalX == true;
    public bool IsStruttingCriticalY => dto?.IsStruttingCriticalY == true;
    public bool AnyStruttingCritical => dto?.AnyStruttingCritical == true;
    public string StruttingWarningText => AnyStruttingCritical
        ? "Strut crushing - increase bw or fck"
        : "";

    public string AswSMinReqdXText => dto is null || !HasLinks ? "-" : $"{dto.AswSMinRequiredX:F4} mm2/mm";
    public string AswSMinReqdYText => dto is null || !HasLinks ? "-" : $"{dto.AswSMinRequiredY:F4} mm2/mm";
    public bool AswSMinPassX => dto?.AswSMinPassX != false;
    public bool AswSMinPassY => dto?.AswSMinPassY != false;
    public bool AnyMinAswSFail => dto?.AnyMinAswSFail == true;

    public string UtilXText => dto is null ? "-" : $"{dto.UtilisationX:F3}";
    public string UtilYText => dto is null ? "-" : $"{dto.UtilisationY:F3}";
    public string StatusXText => dto is null ? "-" : dto.StatusX == CapacityStatus.Pass ? "PASS" : "FAIL";
    public string StatusYText => dto is null ? "-" : dto.StatusY == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsXPass => dto?.StatusX == CapacityStatus.Pass;
    public bool IsYPass => dto?.StatusY == CapacityStatus.Pass;
    public string GoverningStatusText => dto is null ? "-" : dto.GoverningStatus == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsGoverningPass => dto?.GoverningStatus == CapacityStatus.Pass;
    public string GoverningUtilText => dto is null ? "-" : $"{dto.GoverningUtilisation:F3}";

    public string ConcreteFormulaLatex =>
        @"V_{Rd,c}=\max\left(\left[C_{Rd,c}k(100\rho_l f_{ck})^{1/3}+k_1\sigma_{cp}\right]b_wd,\;(v_{min}+k_1\sigma_{cp})b_wd\right)";
    public string ConcreteXSubLatex => BuildConcreteSubLatex(isX: true);
    public string ConcreteYSubLatex => BuildConcreteSubLatex(isX: false);
    public string LinkAreaLatex => @"A_h=\frac{\pi\phi_h^2}{4}";
    public string LinkAreaSubLatex => dto is null || !HasLinks ? "" :
        $@"A_h=\frac{{\pi({F(dto.LinkAhMm2 > 0 ? System.Math.Sqrt(4.0 * dto.LinkAhMm2 / System.Math.PI) : 0, 1)})^2}}{{4}}={F(dto.LinkAhMm2, 2)}\;\mathrm{{mm^2}}";
    public string LinkSteelSubLatex => dto is null || !HasLinks ? "" :
        $@"s={F(dto.LinkSpacingMm, 0)}\;\mathrm{{mm}},\qquad f_{{ywd}}=\frac{{f_{{yk}}}}{{\gamma_s}}=\frac{{{F(dto.FywkMpa, 1)}}}{{1.15}}={F(dto.FywdMpa, 1)}\;\mathrm{{MPa}}";
    public string CircularHoopFormulaLatex => @"V_{Rd,s}=\frac{\pi}{2}\frac{A_h}{s}D'f_{ywd}\cot\theta";
    public string CircularHoopXSubLatex => BuildCircularHoopSubLatex(isX: true);
    public string CircularHoopYSubLatex => BuildCircularHoopSubLatex(isX: false);
    public string RectangularLinkFormulaLatex => @"V_{Rd,s}=\frac{A_{sw}}{s}zf_{ywd}\cot\theta";
    public string RectangularLinkXSubLatex => BuildRectangularLinkSubLatex(isX: true);
    public string RectangularLinkYSubLatex => BuildRectangularLinkSubLatex(isX: false);
    public string RectangularLinkInputXSubLatex => BuildRectangularLinkInputSubLatex(isX: true);
    public string RectangularLinkInputYSubLatex => BuildRectangularLinkInputSubLatex(isX: false);
    public string VRdMaxFormulaLatex => @"V_{Rd,max}=\frac{\alpha_{cw}b_wz\nu_1f_{cd}}{\cot\theta+\tan\theta}";
    public string VRdMaxXSubLatex => BuildVRdMaxSubLatex(isX: true);
    public string VRdMaxYSubLatex => BuildVRdMaxSubLatex(isX: false);
    public string MinAswFormulaLatex => @"\frac{A_{sw}}{s}_{min}=\rho_{w,min}b_w=\frac{0.08\sqrt{f_{ck}}}{f_{yk}}b_w";
    public string MinAswXSubLatex => BuildMinAswSubLatex(isX: true);
    public string MinAswYSubLatex => BuildMinAswSubLatex(isX: false);
    public string UtilFormulaLatex => @"DCR=\frac{|V_{Ed}|}{V_{Rd}}";
    public string UtilXSubLatex => BuildUtilSubLatex(isX: true);
    public string UtilYSubLatex => BuildUtilSubLatex(isX: false);

    public string Step1UtilXSubLatex => BuildStep1UtilSubLatex(isX: true);
    public string Step1UtilYSubLatex => BuildStep1UtilSubLatex(isX: false);
    public string Step2UtilXSubLatex => BuildStep2UtilSubLatex(isX: true);
    public string Step2UtilYSubLatex => BuildStep2UtilSubLatex(isX: false);
    public string GoverningCaseName =>
        envelopeSummaryRows.FirstOrDefault(r => r.IsGoverning)?.CaseName ?? "";

    public bool ShowUtilisationPanel => HasDemand || (IsCircularHoop && HasLinks);

    public bool ShowLinksNotRequiredX => HasDemand && dto?.LinksRequiredX == false;
    public bool ShowLinksNotRequiredY => HasDemand && dto?.LinksRequiredY == false;
    public bool ShowLinksRequiredX => HasDemand && dto?.LinksRequiredX == true;
    public bool ShowLinksRequiredY => HasDemand && dto?.LinksRequiredY == true;
    public bool ShowStep2FailX => HasDemand && HasLinks && dto?.StatusX == CapacityStatus.Fail;
    public bool ShowStep2FailY => HasDemand && HasLinks && dto?.StatusY == CapacityStatus.Fail;
    public bool HasLinksAndDemand => HasLinks && HasDemand;

    private static double ThetaDeg(double cot) =>
        cot > 0 ? System.Math.Atan(1.0 / cot) * 180.0 / System.Math.PI : 0;

    private static string F(double value, int digits) =>
        value.ToString($"F{digits}", System.Globalization.CultureInfo.InvariantCulture);

    private string BuildConcreteSubLatex(bool isX)
    {
        if (dto is null) return "";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double d = isX ? dto.DEffXMm : dto.DEffYMm;
        double k = isX ? dto.KFactorX : dto.KFactorY;
        double rho = isX ? dto.RhoLX : dto.RhoLY;
        double v = isX ? dto.VRdcXDisplay : dto.VRdcYDisplay;
        string axis = isX ? "x" : "y";
        return $@"k={F(k, 3)},\;\rho_l={F(rho, 4)},\;b_w={F(bw, 0)}\;\mathrm{{mm}},\;d={F(d, 0)}\;\mathrm{{mm}}\Rightarrow V_{{Rd,c}}={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildCircularHoopSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        string axis = isX ? "x" : "y";
        return $@"V_{{Rd,s}}=\frac{{\pi}}{{2}}\frac{{{F(dto.LinkAhMm2, 2)}}}{{{F(dto.LinkSpacingMm, 0)}}}({F(dto.CircularHoopCentrelineDiameterMm, 0)})({F(dto.FywdMpa, 1)})({F(cot, 2)})={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildRectangularLinkSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double aswS = isX ? dto.AswSX : dto.AswSY;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        return $@"V_{{Rd,s}}={F(aswS, 4)}({F(z, 0)})({F(dto.FywdMpa, 1)})({F(cot, 2)})={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildRectangularLinkInputSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double aswS = isX ? dto.AswSX : dto.AswSY;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        return $@"\frac{{A_{{sw}}}}{{s}}={F(aswS, 4)}\;\mathrm{{mm^2/mm}},\quad z={F(z, 0)}\;\mathrm{{mm}},\quad \cot\theta={F(cot, 2)}";
    }

    private string BuildVRdMaxSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdMaxXDisplay : dto.VRdMaxYDisplay;
        string axis = isX ? "x" : "y";
        return $@"b_w={F(bw, 0)},\;z={F(z, 0)},\;f_{{cd}}={F(dto.FcdMpa, 2)},\;\cot\theta={F(cot, 2)}\Rightarrow V_{{Rd,max}}={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildMinAswSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double req = isX ? dto.AswSMinRequiredX : dto.AswSMinRequiredY;
        double prov = isX ? dto.AswSX : dto.AswSY;
        string axis = isX ? "x" : "y";
        return $@"\frac{{A_{{sw}}}}{{s}}_{{min}}=\frac{{0.08\sqrt{{{F(dto.FckMpa, 1)}}}}}{{{F(dto.FywkMpa, 1)}}}({F(bw, 0)})={F(req, 4)}\;\mathrm{{mm^2/mm}},\quad \frac{{A_{{sw}}}}{{s}}={F(prov, 4)}";
    }

    private string BuildUtilSubLatex(bool isX)
    {
        if (dto is null) return "";
        double vEd = isX ? dto.VEdXDisplay : dto.VEdYDisplay;
        double vRd = isX ? dto.VRdXDisplay : dto.VRdYDisplay;
        double util = isX ? dto.UtilisationX : dto.UtilisationY;
        string axis = isX ? "x" : "y";
        return $@"DCR=\frac{{|{F(vEd, 1)}|}}{{{F(vRd, 1)}}}={F(util, 3)}";
    }

    private string BuildStep1UtilSubLatex(bool isX)
    {
        if (dto is null || !HasDemand) return "";
        double vEd = Math.Abs(isX ? dto.VEdXDisplay : dto.VEdYDisplay);
        double vRdc = isX ? dto.VRdcXDisplay : dto.VRdcYDisplay;
        double util = vRdc > 0 ? vEd / vRdc : 0;
        return $@"\frac{{|V_{{Ed}}|}}{{V_{{Rd,c}}}}=\frac{{|{F(vEd, 1)}|}}{{{F(vRdc, 1)}\;\mathrm{{{ForceUnit}}}}}={F(util, 3)}";
    }

    private string BuildStep2UtilSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double vEd = Math.Abs(isX ? dto.VEdXDisplay : dto.VEdYDisplay);
        double vRds = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        double util = vRds > 0 ? vEd / vRds : 0;
        return $@"\frac{{|V_{{Ed}}|}}{{V_{{Rd,s}}}}=\frac{{|{F(vEd, 1)}|}}{{{F(vRds, 1)}\;\mathrm{{{ForceUnit}}}}}={F(util, 3)}";
    }

    private static IReadOnlyList<ShearEnvelopeSummaryRowViewModel> BuildEnvelopeSummaryRows(
        IReadOnlyList<LoadCaseResultDto> loadCaseResults,
        ShearResultDto? governing)
    {
        var candidates = loadCaseResults
            .Where(r => r.ShearResult is not null)
            .Select(r => (Case: r, Shear: r.ShearResult!))
            .ToList();

        if (candidates.Count == 0)
        {
            return governing is null
                ? []
                : MarkGoverning([
                    BuildRow("Vx envelope", "Envelope", governing.VEdXDisplay, governing.VRdXDisplay, governing.UtilisationX, governing.StatusX, governing.ForceUnit),
                    BuildRow("Vy envelope", "Envelope", governing.VEdYDisplay, governing.VRdYDisplay, governing.UtilisationY, governing.StatusY, governing.ForceUnit)
                ]);
        }

        var x = candidates
            .OrderByDescending(c => Math.Abs(c.Shear.VEdXDisplay))
            .ThenByDescending(c => c.Shear.UtilisationX)
            .First();
        var y = candidates
            .OrderByDescending(c => Math.Abs(c.Shear.VEdYDisplay))
            .ThenByDescending(c => c.Shear.UtilisationY)
            .First();

        return MarkGoverning([
            BuildRow("Vx envelope", x.Case.LoadCaseName, x.Shear.VEdXDisplay, x.Shear.VRdXDisplay, x.Shear.UtilisationX, x.Shear.StatusX, x.Shear.ForceUnit),
            BuildRow("Vy envelope", y.Case.LoadCaseName, y.Shear.VEdYDisplay, y.Shear.VRdYDisplay, y.Shear.UtilisationY, y.Shear.StatusY, y.Shear.ForceUnit)
        ]);
    }

    private static ShearEnvelopeSummaryRowViewModel BuildRow(
        string direction,
        string caseName,
        double demand,
        double capacity,
        double ratio,
        CapacityStatus status,
        string forceUnit)
        => new(
            Direction: direction,
            CaseName: caseName,
            Demand: Math.Abs(demand),
            Capacity: capacity,
            Ratio: ratio,
            Status: status,
            ForceUnit: forceUnit,
            IsGoverning: false);

    private static IReadOnlyList<ShearEnvelopeSummaryRowViewModel> MarkGoverning(IReadOnlyList<ShearEnvelopeSummaryRowViewModel> rows)
    {
        if (rows.Count == 0)
        {
            return rows;
        }

        double governingRatio = rows.Max(r => r.Ratio);
        return rows
            .Select(r => r with { IsGoverning = Math.Abs(r.Ratio - governingRatio) < 1e-9 })
            .ToList();
    }
}

public sealed record ShearEnvelopeSummaryRowViewModel(
    string Direction,
    string CaseName,
    double Demand,
    double Capacity,
    double Ratio,
    CapacityStatus Status,
    string ForceUnit,
    bool IsGoverning)
{
    public string DemandText => $"{Demand:F1} {ForceUnit}";
    public string CapacityText => $"{Capacity:F1} {ForceUnit}";
    public string RatioText => $"{Ratio:F3}";
    public string StatusText => Status == CapacityStatus.Pass ? "PASS" : "FAIL";
}
