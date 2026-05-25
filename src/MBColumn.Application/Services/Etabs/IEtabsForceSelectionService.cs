using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.Services.Etabs;

public sealed class EtabsForceScope
{
    public List<EtabsSectionBinding> Bindings { get; set; } = [];
    public List<string> LoadCombinations { get; set; } = [];
    public MbColumnForceSourceMode ForceSource { get; set; }
    public bool ImportTop { get; set; } = true;
    public bool ImportBottom { get; set; } = true;
}

public interface IEtabsForceSelectionService
{
    IReadOnlyList<EtabsColumnImportDto> BuildColumnScope(EtabsForceScope scope);
    IReadOnlyList<(string PierLabel, string StoryName)> BuildPierScope(EtabsForceScope scope);
}
