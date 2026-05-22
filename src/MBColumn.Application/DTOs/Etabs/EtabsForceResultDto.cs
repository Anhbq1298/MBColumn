namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsForceResultDto(
    string ObjectName,
    string PierName,
    string StoryName,
    string Label,
    string EtabsSectionName,
    string LoadCombination,
    double P,
    double M2,
    double M3,
    double V2,
    double V3,
    string Station,
    string Status);
