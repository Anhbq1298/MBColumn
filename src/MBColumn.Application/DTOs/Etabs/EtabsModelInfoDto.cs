namespace MBColumn.Application.DTOs.Etabs;

public sealed record EtabsModelInfoDto(
    string ModelName,
    string ModelPath,
    string PresentUnits,
    int StoryCount,
    int PierCount,
    int FrameObjectCount);
