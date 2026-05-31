using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

internal static class MaterialValidator
{
    public static void Validate(ColumnInputDto input, ValidationContext ctx)
    {
        if (input.Fc <= 0) ctx.Error("Concrete strength must be positive.", "Fc");
        if (input.Fy <= 0) ctx.Error("Steel yield strength must be positive.", "Fy");
        if (input.Es <= 0) ctx.Error("Steel modulus must be positive.", "Es");
        if (input.GammaC <= 0) ctx.Error("γc must be positive.", "GammaC");
    }
}
