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
    double LengthMm,
    string LinkedSection,
    string Status)
{
    public bool HasCoordinates { get; init; }
    public double BottomXmm { get; init; }
    public double BottomYmm { get; init; }
    public double BottomZmm { get; init; }
    public double TopXmm { get; init; }
    public double TopYmm { get; init; }
    public double TopZmm { get; init; }
    public double CenterXmm { get; init; }
    public double CenterYmm { get; init; }
    public double CenterZmm { get; init; }
}
