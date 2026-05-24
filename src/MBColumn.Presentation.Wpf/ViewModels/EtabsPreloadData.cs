using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class EtabsPreloadData
{
    public string ModelName { get; init; } = "";
    public string ModelPath { get; init; } = "";
    public string PresentUnits { get; init; } = "";
    public int StoryCount { get; init; }
    public int PierCount { get; init; }
    public int FrameObjectCount { get; init; }
    public IReadOnlyList<EtabsColumnImportDto> Columns { get; init; } = [];
    public IReadOnlyList<string> LoadCombinations { get; init; } = [];
}
