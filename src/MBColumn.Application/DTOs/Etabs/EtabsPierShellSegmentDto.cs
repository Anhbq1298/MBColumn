namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsPierShellSegmentDto(
    string ShellName,
    string PierLabel,
    string StoryName,
    string AreaLabel,
    string SectionProperty,
    double ThicknessMm,
    (double X, double Y) Start,
    (double X, double Y) End);
