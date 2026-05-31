using MBColumn.Application.DTOs;
using MBColumn.Application.Reports.Models;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Reports.Interfaces;

public interface ICalculationReportBuilder
{
    ReportData Build(
        string projectName,
        string groupName,
        string designTierName,
        CalculationResultDto result,
        IDesignCodeService designCode,
        IUnitConversionService units,
        string? sectionGeometrySvg = null,
        string? pmDiagramSvg = null,
        string? mmDiagramSvg = null,
        DiagramBlock? pmDiagram = null,
        DiagramBlock? mmDiagram = null);
}
