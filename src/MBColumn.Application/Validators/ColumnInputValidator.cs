using MBColumn.Application.DTOs;

namespace MBColumn.Application.Validators;

public sealed class ColumnInputValidator
{
    public ValidationResultDto Validate(ColumnInputDto input)
    {
        var ctx = new ValidationContext();

        SectionGeometryValidator.Validate(input, ctx);
        RebarValidator.Validate(input, ctx);
        MaterialValidator.Validate(input, ctx);

        if (input.IncludeEc2Slenderness)
            SlendernessValidator.Validate(input, ctx);
        else
            LoadCaseValidator.Validate(input, ctx);

        return ctx.ToResult();
    }
}
