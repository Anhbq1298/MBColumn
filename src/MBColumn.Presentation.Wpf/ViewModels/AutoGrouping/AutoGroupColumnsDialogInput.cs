using MBColumn.Application.DTOs.Etabs;
using MBColumn.Application.DTOs.Etabs.AutoGrouping;

namespace MBColumn.Presentation.Wpf.ViewModels.AutoGrouping;

public sealed class AutoGroupColumnsDialogInput
{
    public IReadOnlyList<EtabsColumnImportDto> Columns { get; init; } = [];
    public IReadOnlyList<AutoGroupingStory> Stories { get; init; } = [];
    public IReadOnlyCollection<string> ReservedSectionNames { get; init; } = [];
}
