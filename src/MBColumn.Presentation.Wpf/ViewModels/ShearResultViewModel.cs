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

    public void Load(ShearResultDto? result)
    {
        dto = result;
        Raise(string.Empty);
    }

    public bool HasResult => dto is not null;
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

    public string LinkAreaEquationText => dto is null || !HasLinks ? "-" :
        $"Ah = pi x phi_h^2 / 4 = {dto.LinkAhMm2:F2} mm2";
    public string LinkSpacingEquationText => dto is null || !HasLinks ? "-" :
        $"s = {dto.LinkSpacingMm:F0} mm, fywd = fyk / gamma_s = {dto.FywkMpa:F1} / 1.15 = {dto.FywdMpa:F1} MPa";
    public string CircularHoopEquationXText => BuildCircularHoopEquation(isX: true);
    public string CircularHoopEquationYText => BuildCircularHoopEquation(isX: false);
    public string RectangularLinkEquationXText => BuildRectangularLinkEquation(isX: true);
    public string RectangularLinkEquationYText => BuildRectangularLinkEquation(isX: false);
    public string VRdMaxEquationXText => BuildVRdMaxEquation(isX: true);
    public string VRdMaxEquationYText => BuildVRdMaxEquation(isX: false);
    public string MinAswEquationXText => BuildMinAswEquation(isX: true);
    public string MinAswEquationYText => BuildMinAswEquation(isX: false);

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

    public string KEquationXText => BuildKEquation(isX: true);
    public string KEquationYText => BuildKEquation(isX: false);
    public string RhoEquationXText => BuildRhoEquation(isX: true);
    public string RhoEquationYText => BuildRhoEquation(isX: false);
    public string VRdcEquationXText => BuildVRdcEquation(isX: true);
    public string VRdcEquationYText => BuildVRdcEquation(isX: false);
    public string UtilEquationXText => BuildUtilEquation(isX: true);
    public string UtilEquationYText => BuildUtilEquation(isX: false);

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
    public string VRdMaxFormulaLatex => @"V_{Rd,max}=\frac{\alpha_{cw}b_wz\nu_1f_{cd}}{\cot\theta+\tan\theta}";
    public string VRdMaxXSubLatex => BuildVRdMaxSubLatex(isX: true);
    public string VRdMaxYSubLatex => BuildVRdMaxSubLatex(isX: false);
    public string MinAswFormulaLatex => @"\frac{A_{sw}}{s}_{min}=\rho_{w,min}b_w=\frac{0.08\sqrt{f_{ck}}}{f_{yk}}b_w";
    public string MinAswXSubLatex => BuildMinAswSubLatex(isX: true);
    public string MinAswYSubLatex => BuildMinAswSubLatex(isX: false);
    public string UtilFormulaLatex => @"DCR=\frac{|V_{Ed}|}{V_{Rd}}";
    public string UtilXSubLatex => BuildUtilSubLatex(isX: true);
    public string UtilYSubLatex => BuildUtilSubLatex(isX: false);

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
        return $@"{axis}:\quad k={F(k, 3)},\;\rho_l={F(rho, 4)},\;b_w={F(bw, 0)}\;\mathrm{{mm}},\;d={F(d, 0)}\;\mathrm{{mm}}\Rightarrow V_{{Rd,c}}={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildCircularHoopSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        string axis = isX ? "x" : "y";
        return $@"{axis}:\quad V_{{Rd,s}}=\frac{{\pi}}{{2}}\frac{{{F(dto.LinkAhMm2, 2)}}}{{{F(dto.LinkSpacingMm, 0)}}}({F(dto.CircularHoopCentrelineDiameterMm, 0)})({F(dto.FywdMpa, 1)})({F(cot, 2)})={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildRectangularLinkSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double aswS = isX ? dto.AswSX : dto.AswSY;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        string axis = isX ? "x" : "y";
        return $@"{axis}:\quad V_{{Rd,s}}={F(aswS, 4)}({F(z, 0)})({F(dto.FywdMpa, 1)})({F(cot, 2)})={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildVRdMaxSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdMaxXDisplay : dto.VRdMaxYDisplay;
        string axis = isX ? "x" : "y";
        return $@"{axis}:\quad b_w={F(bw, 0)},\;z={F(z, 0)},\;f_{{cd}}={F(dto.FcdMpa, 2)},\;\cot\theta={F(cot, 2)}\Rightarrow V_{{Rd,max}}={F(v, 1)}\;\mathrm{{{ForceUnit}}}";
    }

    private string BuildMinAswSubLatex(bool isX)
    {
        if (dto is null || !HasLinks) return "";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double req = isX ? dto.AswSMinRequiredX : dto.AswSMinRequiredY;
        double prov = isX ? dto.AswSX : dto.AswSY;
        string axis = isX ? "x" : "y";
        return $@"{axis}:\quad \frac{{A_{{sw}}}}{{s}}_{{min}}=\frac{{0.08\sqrt{{{F(dto.FckMpa, 1)}}}}}{{{F(dto.FywkMpa, 1)}}}({F(bw, 0)})={F(req, 4)}\;\mathrm{{mm^2/mm}},\quad \frac{{A_{{sw}}}}{{s}}={F(prov, 4)}";
    }

    private string BuildUtilSubLatex(bool isX)
    {
        if (dto is null) return "";
        double vEd = isX ? dto.VEdXDisplay : dto.VEdYDisplay;
        double vRd = isX ? dto.VRdXDisplay : dto.VRdYDisplay;
        double util = isX ? dto.UtilisationX : dto.UtilisationY;
        string axis = isX ? "x" : "y";
        return $@"{axis}:\quad DCR=\frac{{|{F(vEd, 1)}|}}{{{F(vRd, 1)}}}={F(util, 3)}";
    }

    private string BuildKEquation(bool isX)
    {
        if (dto is null) return "-";
        double d = isX ? dto.DEffXMm : dto.DEffYMm;
        double k = isX ? dto.KFactorX : dto.KFactorY;
        return $"k = min(1 + sqrt(200 / d), 2.0) = min(1 + sqrt(200 / {d:F0}), 2.0) = {k:F3}";
    }

    private string BuildRhoEquation(bool isX)
    {
        if (dto is null) return "-";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double d = isX ? dto.DEffXMm : dto.DEffYMm;
        double rho = isX ? dto.RhoLX : dto.RhoLY;
        return $"rho_l = min(Asl / (bw x d), 0.02) = {rho:F4} using bw = {bw:F0} mm and d = {d:F0} mm";
    }

    private string BuildVRdcEquation(bool isX)
    {
        if (dto is null) return "-";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double d = isX ? dto.DEffXMm : dto.DEffYMm;
        double v = isX ? dto.VRdcXDisplay : dto.VRdcYDisplay;
        return $"VRd,c = [CRd,c k (100 rho_l fck)^(1/3) + k1 sigma_cp] bw d = {v:F1} {ForceUnit} (bw = {bw:F0}, d = {d:F0}, fck = {dto.FckMpa:F1} MPa)";
    }

    private string BuildCircularHoopEquation(bool isX)
    {
        if (dto is null || !HasLinks) return "-";
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        return $"VRd,s = (pi / 2) x (Ah / s) x D' x fywd x cot theta = (pi / 2) x ({dto.LinkAhMm2:F2} / {dto.LinkSpacingMm:F0}) x {dto.CircularHoopCentrelineDiameterMm:F0} x {dto.FywdMpa:F1} x {cot:F2} = {v:F1} {ForceUnit}";
    }

    private string BuildRectangularLinkEquation(bool isX)
    {
        if (dto is null || !HasLinks) return "-";
        double aswS = isX ? dto.AswSX : dto.AswSY;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdsXDisplay : dto.VRdsYDisplay;
        return $"VRd,s = (Asw / s) x z x fywd x cot theta = {aswS:F4} x {z:F0} x {dto.FywdMpa:F1} x {cot:F2} = {v:F1} {ForceUnit}";
    }

    private string BuildVRdMaxEquation(bool isX)
    {
        if (dto is null || !HasLinks) return "-";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double z = isX ? dto.ZXMm : dto.ZYMm;
        double cot = isX ? dto.CotThetaX : dto.CotThetaY;
        double v = isX ? dto.VRdMaxXDisplay : dto.VRdMaxYDisplay;
        return $"VRd,max = alpha_cw bw z nu1 fcd / (cot theta + tan theta) = {v:F1} {ForceUnit} (bw = {bw:F0}, z = {z:F0}, fcd = {dto.FcdMpa:F2} MPa, cot theta = {cot:F2})";
    }

    private string BuildMinAswEquation(bool isX)
    {
        if (dto is null || !HasLinks) return "-";
        double bw = isX ? dto.BwXMm : dto.BwYMm;
        double req = isX ? dto.AswSMinRequiredX : dto.AswSMinRequiredY;
        double prov = isX ? dto.AswSX : dto.AswSY;
        return $"Asw/s,min = rho_w,min x bw = 0.08 sqrt(fck) / fyk x {bw:F0} = {req:F4} mm2/mm; provided = {prov:F4} mm2/mm";
    }

    private string BuildUtilEquation(bool isX)
    {
        if (dto is null) return "-";
        double vEd = isX ? dto.VEdXDisplay : dto.VEdYDisplay;
        double vRd = isX ? dto.VRdXDisplay : dto.VRdYDisplay;
        double util = isX ? dto.UtilisationX : dto.UtilisationY;
        return $"DCR = |VEd| / VRd = |{vEd:F1}| / {vRd:F1} = {util:F3}";
    }
}
