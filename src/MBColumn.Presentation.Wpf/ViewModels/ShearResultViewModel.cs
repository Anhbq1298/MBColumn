using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Presentation.Wpf.ViewModels;

/// <summary>
/// Display ViewModel for the governing shear check result shown in the Results tab.
/// All numeric values are already in the user's display unit (kN or kip).
/// </summary>
public sealed class ShearResultViewModel : ViewModelBase
{
    private ShearResultDto? dto;

    public void Load(ShearResultDto? result)
    {
        dto = result;
        Raise(string.Empty); // raise all
    }

    public bool HasResult     => dto is not null;
    public bool IsNotApplicable => dto is null;

    public string ForceUnit   => dto?.ForceUnit ?? "kN";

    // ── X direction ──────────────────────────────────────────────────────────
    public string VEdXText    => dto is null ? "—" : $"{dto.VEdXDisplay:F1}";
    public string VRdcXText   => dto is null ? "—" : $"{dto.VRdcXDisplay:F1}";
    public string VRdsXText   => dto is null || dto.VRdsXDisplay == 0 ? "—" : $"{dto.VRdsXDisplay:F1}";
    public string VRdMaxXText => dto is null || dto.VRdMaxXDisplay == 0 ? "—" : $"{dto.VRdMaxXDisplay:F1}";
    public string VRdXText    => dto is null ? "—" : $"{dto.VRdXDisplay:F1}";
    public string UtilXText   => dto is null ? "—" : $"{dto.UtilisationX:F3}";
    public string StatusXText => dto is null ? "—" : dto.StatusX == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsXPass       => dto?.StatusX == CapacityStatus.Pass;
    public string LinksReqXText => dto?.LinksRequiredX == true ? "Links required" : "";
    public string CotThetaXText => dto is null || dto.CotThetaX == 0 ? "—" : $"cot θ = {dto.CotThetaX:F2}";

    // ── Y direction ──────────────────────────────────────────────────────────
    public string VEdYText    => dto is null ? "—" : $"{dto.VEdYDisplay:F1}";
    public string VRdcYText   => dto is null ? "—" : $"{dto.VRdcYDisplay:F1}";
    public string VRdsYText   => dto is null || dto.VRdsYDisplay == 0 ? "—" : $"{dto.VRdsYDisplay:F1}";
    public string VRdMaxYText => dto is null || dto.VRdMaxYDisplay == 0 ? "—" : $"{dto.VRdMaxYDisplay:F1}";
    public string VRdYText    => dto is null ? "—" : $"{dto.VRdYDisplay:F1}";
    public string UtilYText   => dto is null ? "—" : $"{dto.UtilisationY:F3}";
    public string StatusYText => dto is null ? "—" : dto.StatusY == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsYPass       => dto?.StatusY == CapacityStatus.Pass;
    public string LinksReqYText => dto?.LinksRequiredY == true ? "Links required" : "";
    public string CotThetaYText => dto is null || dto.CotThetaY == 0 ? "—" : $"cot θ = {dto.CotThetaY:F2}";

    // ── Governing ─────────────────────────────────────────────────────────────
    public string GoverningStatusText => dto is null ? "—" : dto.GoverningStatus == CapacityStatus.Pass ? "PASS" : "FAIL";
    public bool IsGoverningPass => dto?.GoverningStatus == CapacityStatus.Pass;
    public string GoverningUtilText => dto is null ? "—" : $"{dto.GoverningUtilisation:F3}";

    // ── Effective depths (always in mm for clarity) ───────────────────────────
    public string DEffXText => dto is null ? "—" : $"{dto.DEffXMm:F0} mm";
    public string DEffYText => dto is null ? "—" : $"{dto.DEffYMm:F0} mm";
}
