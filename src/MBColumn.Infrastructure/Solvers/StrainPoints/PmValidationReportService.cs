using MBColumn.Application.DTOs;
using MBColumn.Application.Interfaces;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Solvers.Integration;
using System.Text;

namespace MBColumn.Infrastructure.Solvers.StrainPoints;

public sealed class PmValidationReportService : IPmValidationReportService
{
    private readonly IDesignCodeServiceFactory _codeFactory;

    public PmValidationReportService(IDesignCodeServiceFactory codeFactory)
    {
        _codeFactory = codeFactory;
    }

    public PmValidationReportDto BuildReport(ColumnInputDto input, ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel)
    {
        var codeService = _codeFactory.Get(input.DesignCode);
        IStrainLimitDesignCodeAdapter codeAdapter = input.DesignCode == DesignCodeType.Ec2 
            ? new Ec2StrainLimitAdapter((Ec2DesignCodeService)codeService) 
            : new Aci318StrainLimitAdapter((Aci318DesignCodeService)codeService);

        var integrator = SectionIntegratorFactory.Create(input.IntegrationMethod);
        var strategy = new StrainControlledSevenPointStrategy(integrator, codeAdapter, codeService);
        var comparisonSvc = new PmComparisonService(strategy, codeService);

        var comparisonResult = comparisonSvc.Compare(
            section, concrete, steel, input.SelectedPmAngleDegrees, 
            new SolverSettings { IntegrationMethod = input.IntegrationMethod });

        var sb = new StringBuilder();
        
        sb.AppendLine("# Code-Strict 7-Point P–M Strain Validation Report");
        sb.AppendLine();
        sb.AppendLine("## Input Data");
        sb.AppendLine($"- **Design Code**: {input.DesignCode}");
        sb.AppendLine($"- **Section Shape**: {section.Shape}");
        sb.AppendLine($"- **Concrete**: {concrete.Grade} (fc' = {concrete.FcMpa:F1} MPa)");
        sb.AppendLine($"- **Steel**: {steel.Grade} (fy = {steel.FyMpa:F1} MPa, Es = {steel.EsMpa:F1} MPa)");
        sb.AppendLine($"- **Rebar Layout**: {section.RebarLayout.Bars.Count} bars, {section.RebarLayout.Preset}");
        sb.AppendLine();
        
        sb.AppendLine("## 7-Point Comparison Table");
        sb.AppendLine();
        sb.AppendLine("| Point Name | Target Strain | c (mm) | Pn_7Point | Mn_7Point | Pn_Fiber | Mn_Fiber | Pn_Poly | Mn_Poly | ΔP_Fib(%) | ΔM_Fib(%) | ΔP_Pol(%) | ΔM_Pol(%) | Pass/Fail | Notes |");
        sb.AppendLine("|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|");

        foreach (var r in comparisonResult)
        {
            string p7 = (r.Pn_7Point / 1000.0).ToString("F1");
            string m7 = (r.Mn_7Point / 1000000.0).ToString("F1");
            string pfib = (r.Pn_Fiber / 1000.0).ToString("F1");
            string mfib = (r.Mn_Fiber / 1000000.0).ToString("F1");
            string ppol = (r.Pn_Polygon / 1000.0).ToString("F1");
            string mpol = (r.Mn_Polygon / 1000000.0).ToString("F1");
            string dpf = r.DeltaP_Fiber_Percent.ToString("F2");
            string dmf = r.DeltaM_Fiber_Percent.ToString("F2");
            string dpp = r.DeltaP_Polygon_Percent.ToString("F2");
            string dmp = r.DeltaM_Polygon_Percent.ToString("F2");
            string c = r.NeutralAxisDepth > 10000 ? "∞" : r.NeutralAxisDepth.ToString("F2");
            string status = r.PassFail ? "PASS" : "FAIL";

            sb.AppendLine($"| {r.PointName} | {r.TargetStrainState} | {c} | {p7} | {m7} | {pfib} | {mfib} | {ppol} | {mpol} | {dpf} | {dmf} | {dpp} | {dmp} | {status} | {r.Notes} |");
        }

        sb.AppendLine();
        sb.AppendLine("## Output Formats");
        sb.AppendLine("- Forces are in kN, Moments are in kNm.");
        sb.AppendLine("- Pure compression point deviations between Fiber/Polygon and 7-Point solver are expected, because the 7-Point uses analytic exact pure compression, while Fiber/Polygon sweep at a maximum bounding depth.");
        
        var rowDtos = comparisonResult.Select(r => new SevenPointValidationRowDto(
            r.PointName,
            r.TargetStrainState,
            r.NeutralAxisDepth,
            r.Pn_7Point,
            r.Mn_7Point,
            input.IntegrationMethod == SectionIntegrationMethod.Fiber ? r.Pn_Fiber : r.Pn_Polygon,
            input.IntegrationMethod == SectionIntegrationMethod.Fiber ? r.Mn_Fiber : r.Mn_Polygon,
            input.IntegrationMethod == SectionIntegrationMethod.Fiber ? r.DeltaP_Fiber_Percent : r.DeltaP_Polygon_Percent,
            input.IntegrationMethod == SectionIntegrationMethod.Fiber ? r.DeltaM_Fiber_Percent : r.DeltaM_Polygon_Percent
        )).ToList();

        return new PmValidationReportDto(sb.ToString(), rowDtos);
    }
}
