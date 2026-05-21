using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsColumnImportDto(
    string ObjectName,
    string PierName,
    string StoryName,
    string Label,
    string UniqueSectionDisplayName,
    string EtabsSectionName,
    string MaterialName,
    SectionShapeType SectionType,
    double Width,
    double Height,
    double Diameter,
    string LinkedSection,
    string Status);
