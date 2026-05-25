namespace MBColumn.Application.DTOs.Etabs;

public sealed class EtabsObjectBindingHealth
{
    public string SectionName { get; set; } = "";
    public string ObjectKey { get; set; } = "";
    public EtabsBindingHealthStatus Status { get; set; }
    public string? SuggestedRemapKey { get; set; }
    public List<string> RemapCandidates { get; set; } = [];
    public string? Message { get; set; }
}

public sealed class EtabsBindingValidationResult
{
    public bool ModelChanged { get; set; }
    public string CurrentModelPath { get; set; } = "";
    public string CurrentModelName { get; set; } = "";
    public List<EtabsObjectBindingHealth> ObjectHealthList { get; set; } = [];
    public List<string> MissingCombinations { get; set; } = [];
    public bool IsValid =>
        !ModelChanged &&
        ObjectHealthList.All(h => h.Status == EtabsBindingHealthStatus.Ok) &&
        MissingCombinations.Count == 0;
    public bool HasRemapNeeded =>
        ObjectHealthList.Any(h =>
            h.Status is EtabsBindingHealthStatus.PossibleRemap or EtabsBindingHealthStatus.MultipleRemapCandidates);
}
