namespace MBColumn.Application.DTOs.Etabs;

public enum EtabsForceExtractionMode
{
    TopBottom,
    Envelope
}

public enum EtabsForceRefreshTargetMode
{
    CurrentSectionOnly,
    ExplicitBindings
}

public sealed class EtabsForceRefreshRequest
{
    public List<EtabsSectionBinding> Bindings { get; set; } = [];
    public List<string> SelectedLoadCombinations { get; set; } = [];
    public List<string> SelectedLoadCases { get; set; } = [];
    public MbColumnForceSourceMode ForceSource { get; set; } = MbColumnForceSourceMode.DesignForces;
    public EtabsForceExtractionMode ExtractionMode { get; set; } = EtabsForceExtractionMode.TopBottom;
    public bool ImportTop { get; set; } = true;
    public bool ImportBottom { get; set; } = true;
    public bool ImportEnvelope { get; set; } = false;
    public bool AppendAsNewLoads { get; set; } = false;
    public bool RefreshAllSections { get; set; } = false;
    public EtabsForceRefreshTargetMode TargetMode { get; set; } = EtabsForceRefreshTargetMode.CurrentSectionOnly;
    public int? TargetSectionId { get; set; }
    public string TargetMetadataId { get; set; } = "";
    public List<string> SelectedSectionNames { get; set; } = [];
    public bool AllowSourceModelMismatch { get; set; }
    public bool SourceModelMismatchConfirmed { get; set; }
    public string SourceResolutionMethod { get; set; } = "";
    public List<string> ResolvedEtabsObjectUniqueNames { get; set; } = [];
}
