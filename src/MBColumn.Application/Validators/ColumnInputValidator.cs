using MBColumn.Application.DTOs;
using MBColumn.Domain.Enums;

namespace MBColumn.Application.Validators;

public sealed class ColumnInputValidator
{
    public ValidationResultDto Validate(ColumnInputDto input)
    {
        var errors = new List<string>();

        if (input.SectionShape == SectionShapeType.Circular)
        {
            if (input.Diameter <= 0) errors.Add("Section diameter must be positive.");
            if (input.Cover <= 0) errors.Add("Concrete cover must be positive.");
            if (input.Diameter > 0 && input.Cover >= input.Diameter / 2.0)
                errors.Add("Cover must be less than the section radius (D/2).");
            if (input.BarCount < 4) errors.Add("Circular sections require at least 4 longitudinal bars.");
            if (string.IsNullOrWhiteSpace(input.BarSize)) errors.Add("A rebar size is required.");
        }
        else
        {
            if (input.Width <= 0) errors.Add("Section width must be positive.");
            if (input.Height <= 0) errors.Add("Section height must be positive.");
            if (input.Cover <= 0) errors.Add("Concrete cover must be positive.");
            if (input.Cover * 2 >= Math.Min(input.Width, input.Height)) errors.Add("Cover places bars outside the section.");
            if (input.RebarLayoutType == RebarLayoutType.AllSidesEqual)
            {
                if (input.BarCount < 4) errors.Add("Total bars must be at least 4.");
                if (input.BarCount % 4 != 0) errors.Add("Total bars must be divisible by 4 for All Sides Equal layout.");
            }
            else
            {
                var sides = new[]
                {
                    input.TopRebarSide?.BarCount ?? 0,
                    input.BottomRebarSide?.BarCount ?? 0,
                    input.LeftRebarSide?.BarCount ?? 0,
                    input.RightRebarSide?.BarCount ?? 0
                };
                if (sides.Any(count => count < 0)) errors.Add("Side bar counts must be non-negative.");
                if (sides.Sum() == 0) errors.Add("At least one side must contain bars.");
            }
            if (string.IsNullOrWhiteSpace(input.BarSize)) errors.Add("A rebar size is required.");
        }

        if (input.Fc <= 0) errors.Add("Concrete strength must be positive.");
        if (input.Fy <= 0) errors.Add("Steel yield strength must be positive.");
        if (input.Es <= 0) errors.Add("Steel modulus must be positive.");

        return errors.Count == 0 ? ValidationResultDto.Valid : new ValidationResultDto(false, errors);
    }
}
