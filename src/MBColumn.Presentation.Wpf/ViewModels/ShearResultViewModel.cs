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
    public bool HasLinks  => dto?.HasLinks  == true;
    public string ForceUnit => dto?.ForceUnit ?? "kN";

    // ── Section properties ────────────────────────────────────────────────────
    public string BwXText    => dto is null ? "—" : $"{dto.BwXMm:F0} mm";
    public string BwYText    => dto is null ? "—" : $"{dto.BwYMm:F0} mm";
    public string DEffXText  => dto is null ? "—" : $"{dto.DEffXMm:F0} mm";
    public string DEffYText  => dto is null ? "—" : $"{dto.DEffYMm:F0} mm";
    public string KFactorXText => dto is null ? "—" : $"{dto.KFactorX:F3}";
    public string KFactorYText => dto is null ? "—" : $"{dto.KFactorY:F3}";
    public string SigCpText  => dto is null ? "—" : $"{dto.SigCpMpa:F3} MPa";

    // ── Step 1 — VRd,c ───────────────────────────────────────────────────────
    public string VEdXText   => dto is null ? "—" : $"{dto.VEdXDisplay:F1}";
    public string VRdcXText  => dto is null ? "—" : $"{dto.VRdcXDisplay:F1}";
    public string VEdYText   => dto is null ? "—" : $"{dto.VEdYDisplay:F1}";
    public string VRdcYText  => dto is null ? "—" : $"{dto.VRdcYDisplay:F1}";
    public string LinksReqXText => dto?.LinksRequiredX == true ? "Required" : "Not required";
    public string LinksReqYText => dto?.LinksRequiredY == true ? "Required" : "Not required";
    public bool IsLinksReqX  => dto?.LinksRequiredX == true;
    public bool IsLinksReqY  => dto?.LinksRequiredY == true;

    // ── Step 2 — VRd,s / VRd,max ─────────────────────────────────────────────
    public string AswSXText  => dto is null || !HasLinks ? "—" : $"{dto.AswSX:F4} mm²/mm";
    public string AswSYText  => dto is null || !HasLinks ? "—" : $"{dto.AswSY:F4} mm²/mm";
    public string FywdText   => dto is null || !HasLinks ? "—" : $"{dto.FywdMpa:F1} MPa";
    public string ZXText     => dto is null || !HasLinks ? "—" : $"{dto.ZXMm:F0} mm";
    public string ZYText     => dto is null || !HasLinks ? "—" : $"{dto.ZYMm:F0} mm";
    public string CotThetaXText => dto is null || dto.CotThetaX == 0 ? "—"
        : $"{dto.CotThetaX:F2} (θ={ThetaDeg(dto.CotThetaX):F1}°)";
    public string CotThetaYText => dto is null || dto.CotThetaY == 0 ? "—"
        : $"{dto.CotThetaY:F2} (θ={ThetaDeg(dto.CotThetaY):F1}°)";
    public string VRdsXText  => dto is null || !HasLinks ? "—" : $"{dto.VRdsXDisplay:F1}";
    public string VRdsYText  => dto is null || !HasLinks ? "—" : $"{dto.VRdsYDisplay:F1}";
    public string VRdMaxXText => dto is null || !HasLinks ? "—" : $"{dto.VRdMaxXDisplay:F1}";
    public string VRdMaxYText => dto is null || !HasLinks ? "—" : $"{dto.VRdMaxYDisplay:F1}";
    public string VRdXText   => dto is null ? "—" : $"{dto.VRdXDisplay:F1}";
    public string VRdYText   => dto is null ? "—" : $"{dto.VRdYDisplay:F1}";

    // ── Fix 4 — Strut crushing ────────────────────────────────────────────────
    public bool IsStruttingCriticalX => dto?.IsStruttingCriticalX == true;
    public bool IsStruttingCriticalY => dto?.IsStruttingCriticalY == true;
    public bool AnyStruttingCritical => dto?.AnyStruttingCritical == true;
    public string StruttingWarningText =>
        AnyStruttingCritical
            ? "Strut crushing — increase bw or fck"
            : "";

    // ── Fix 3 — §9.2.2(5) minimum Asw/s ─────────────────────────────────────
    public string AswSMinReqdXText => dto is null || !HasLinks ? "—" : $"{dto.AswSMinRequiredX:F4} mm²/mm";
    public string AswSMinReqdYText => dto is null || !HasLinks ? "—" : $"{dto.AswSMinRequiredY:F4} mm²/mm";
    public bool AswSMinPassX => dto?.AswSMinPassX != false;
    public bool AswSMinPassY => dto?.AswSMinPassY != false;
    public bool AnyMinAswSFail => dto?.AnyMinAswSFail == true;

    // ── Utilisation ───────────────────────────────────────────────────────────
    public string UtilXText  => dto is null ? "—" : $"{dto.UtilisationX:F3}";
    public string UtilYText  => dto is null ? "—" : $"{dto.UtilisationY:F3}";
    public string StatusXText => dto is null ? "—" : dto.StatusX == CapacityStatus.Pass ? "PASS" : "FAIL";
    public string StatusYText => dto is null ? "—" : dto.StatusY == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsXPass      => dto?.StatusX == CapacityStatus.Pass;
    public bool IsYPass      => dto?.StatusY == CapacityStatus.Pass;
    public string GoverningStatusText  => dto is null ? "—" : dto.GoverningStatus == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsGoverningPass        => dto?.GoverningStatus == CapacityStatus.Pass;
    public string GoverningUtilText    => dto is null ? "—" : $"{dto.GoverningUtilisation:F3}";

    private static double ThetaDeg(double cot) =>
        cot > 0 ? System.Math.Atan(1.0 / cot) * 180.0 / System.Math.PI : 0;
}
