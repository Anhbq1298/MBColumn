using MBColumn.Application.DTOs;
using MBColumn.Domain.Entities;

namespace MBColumn.Application.Interfaces;

public interface IPmValidationReportService
{
    PmValidationReportDto BuildReport(ColumnInputDto input, ColumnSection section, ConcreteMaterial concrete, SteelMaterial steel);
}
