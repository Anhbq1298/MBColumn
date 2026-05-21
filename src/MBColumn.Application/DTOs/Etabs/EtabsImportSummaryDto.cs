using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsImportSummaryDto(
    string NewSectionName,
    string PierName,
    string StoryName,
    string Label,
    SectionShapeType SectionType,
    string Dimensions,
    string Rebar,
    int LoadCaseCount,
    string Status);
