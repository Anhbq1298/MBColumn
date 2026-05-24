namespace MBColumn.Application.DTOs;
using System.Collections.Generic;

public sealed record PmValidationReportDto(
    string MarkdownReport,
    IReadOnlyList<SevenPointValidationRowDto> ValidationRows
);
