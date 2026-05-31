using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

internal static class LoadCaseValidator
{
    public static void Validate(ColumnInputDto input, ValidationContext ctx)
    {
        var activeCases = ValidatorHelpers.GetActiveCasesOrFallback(input);

        foreach (var lc in activeCases)
        {
            if (!double.IsFinite(lc.Pu)) ctx.Error($"{lc.Name}: NEd is required.", "LoadCases");
            if (!double.IsFinite(lc.Mux)) ctx.Error($"{lc.Name}: Mx is required.", "LoadCases");
            if (!double.IsFinite(lc.Muy)) ctx.Error($"{lc.Name}: My is required.", "LoadCases");
        }
    }
}
