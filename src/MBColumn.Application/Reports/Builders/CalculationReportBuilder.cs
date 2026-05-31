using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Builders.Aci;
using MBColumn.Application.Reports.Builders.Ec2;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Reports.Builders;

/// <summary>
/// Entry point for report generation. Routes to the appropriate code-specific
/// builder based on <see cref="CalculationResultDto.DesignCode"/>.
/// </summary>
public sealed class CalculationReportBuilder
{
    public ReportData Build(
        string projectName,
        string groupName,
        string designTierName,
        CalculationResultDto result,
        IDesignCodeService codeService,
        IUnitConversionService unitService,
        string? sectionSvg,
        DiagramBlock? pmDiagram = null,
        DiagramBlock? mmDiagram = null)
    {
        return result.DesignCode switch
        {
            DesignCodeType.Ec2 => new Ec2ReportBuilder().Build(
                projectName, groupName, designTierName,
                result, codeService, unitService,
                sectionSvg, pmDiagram, mmDiagram),

            _ => new AciReportBuilder().Build(
                projectName, groupName, designTierName,
                result, codeService, unitService,
                sectionSvg, pmDiagram, mmDiagram),
        };
    }
}
