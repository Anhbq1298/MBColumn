using MBColumn.Domain.Enums;

namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsSectionMappingDto(
    string EtabsSectionName,
    string UniqueSectionDisplayName,
    SectionShapeType SectionType,
    double Width,
    double Height,
    double Diameter,
    string MaterialName,
    string BarSize,
    int BarsAlongWidth,
    int BarsAlongHeight,
    int TotalBars,
    double Cover,
    double TieDiameter,
    double TieSpacing);
