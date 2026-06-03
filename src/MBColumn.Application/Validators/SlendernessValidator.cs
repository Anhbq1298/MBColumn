using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

internal static class SlendernessValidator
{
    public static void Validate(ColumnInputDto input, ValidationContext ctx)
    {
        if (!input.IncludeEc2Slenderness) return;

        if (input.MemberLengthL is not > 0)
            ctx.Error("Column length L is required when EC2 slenderness amplification is enabled.", "MemberLengthL");
        if (input.Kx is not > 0)
            ctx.Error("kx must be greater than zero.", "Kx");
        if (input.Ky is not > 0)
            ctx.Error("ky must be greater than zero.", "Ky");
        if (input.PhiEff is < 0)
            ctx.Error("Effective creep ratio phiEff must be zero or greater.", "PhiEff");

        var activeCases = ValidatorHelpers.GetActiveCasesOrFallback(input);

        foreach (var lc in activeCases)
        {
            if (!double.IsFinite(lc.Pu)) ctx.Error($"{lc.Name}: NEd is required.", "LoadCases");
            if (lc.Pu < 0) continue; // tension — slenderness not applicable, skip validation
            if (lc.Pu == 0) ctx.Error($"{lc.Name}: NEd must be compression for EC2 column slenderness.", "LoadCases");
            if (lc.MxTop is null) ctx.Error($"{lc.Name}: Mx Top is required when EC2 slenderness amplification is enabled.", "LoadCases");
            if (lc.MxBottom is null) ctx.Error($"{lc.Name}: Mx Bottom is required when EC2 slenderness amplification is enabled.", "LoadCases");
            if (lc.MyTop is null) ctx.Error($"{lc.Name}: My Top is required when EC2 slenderness amplification is enabled.", "LoadCases");
            if (lc.MyBottom is null) ctx.Error($"{lc.Name}: My Bottom is required when EC2 slenderness amplification is enabled.", "LoadCases");
        }
    }
}
