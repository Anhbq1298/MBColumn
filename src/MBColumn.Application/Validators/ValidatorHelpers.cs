using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

internal static class ValidatorHelpers
{
    /// <summary>
    /// Returns the active load cases, falling back to a single default case built from the
    /// top-level Pu/Mux/Muy fields when no active cases are defined.
    /// Centralised here so LoadCaseValidator and SlendernessValidator stay in sync.
    /// </summary>
    public static List<LoadCaseDto> GetActiveCasesOrFallback(ColumnInputDto input)
    {
        var active = input.LoadCases?.Where(lc => lc.IsActive).ToList() ?? [];
        if (active.Count == 0)
            active = [new LoadCaseDto("default", "LC1", input.Pu, input.Mux, input.Muy, true, input.ForceUnit, input.MomentUnit)];
        return active;
    }
}
