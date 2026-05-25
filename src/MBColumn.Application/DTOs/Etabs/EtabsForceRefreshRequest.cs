namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsForceRefreshRequest
{
    public List<EtabsSectionBinding> Bindings { get; set; } = [];
    public List<string> SelectedLoadCombinations { get; set; } = [];
    public MbColumnForceSourceMode ForceSource { get; set; } = MbColumnForceSourceMode.DesignForces;
    public bool ImportTop { get; set; } = true;
    public bool ImportBottom { get; set; } = true;
    public bool RefreshAllSections { get; set; } = true;
    public List<string> SelectedSectionNames { get; set; } = [];
}
